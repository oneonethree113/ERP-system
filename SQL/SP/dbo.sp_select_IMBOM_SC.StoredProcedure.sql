/****** Object:  StoredProcedure [dbo].[sp_select_IMBOM_SC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBOM_SC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBOM_SC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- Checked by Allan Yuen at 28/07/2003  
  
/************************************************************************  
Author:  Kenny Chan  
Date:  11th JAN, 2002  
************************************************************************/  
-------------------------------------------------   
/************************************************************************  
Modification History
************************************************************************
Modified by	Modified on	Description
************************************************************************
Lester Wu		2006-05-17	Retrieve BOM PO Flag
************************************************************************/  

CREATE  PROCEDURE [dbo].[sp_select_IMBOM_SC]   
  
--EXEC sp_select_IMBOM_SC '','03B32V-VW0401'  
--EXEC sp_select_IMBOM_SC '','04B32V-VW04AZP5'  
  
  
@iba_cocde   nvarchar(6),  
@iba_itmno   nvarchar(20)  
  
AS  
  
  
CREATE TABLE #Tmp_SCBOMINF  
 (  
 [sbi_cocde] [nvarchar] (6) ,  -- Company Code  
 [sbi_ordno] [nvarchar] (20),  -- Order No.  
 [sbi_ordseq] [int] ,   -- Order Sequence  
 [sbi_itmno] [nvarchar] (20) ,  -- Item No.  
 [sbi_assitm] [nvarchar] (20) ,  -- Assorted Item No.  
 [sbi_assinrqty] [int] ,   -- Assorted Item Master Qty  
 [sbi_assmtrqty] [int] ,   -- Assorted Item Inner Qty  
 [sbi_bomitm] [nvarchar] (20) ,  -- Assorted Item BOM Item No.  
 [sbi_venno] [nvarchar] (6) ,  -- Assorted Item BOM Item's Vendor No.  
 [sbi_bomdsce] [nvarchar] (800),  -- Assorted Item BOM Item's English Description  
 [sbi_bomdscc] [nvarchar] (800) ,  -- Assorted Item BOM Item's Chinese Description  
 [sbi_colcde] [nvarchar] (30) ,  -- Assorted Item BOM Item's Color Code  
 [sbi_coldsc] [nvarchar] (300),   -- Assorted Item BOM Item's Color Description  
 [sbi_imperiod] [nvarchar] (7),   -- Assorted Item BOM Item's IM Period
 [sbi_pckunt] [nvarchar] (6),  -- Assorted Item BOM Item's UM  
 [sbi_ordqty] [int] ,   -- Assorted Item BOM Item's order Qty.  
 [sbi_fcurcde] [nvarchar] (6) ,  -- Current Assorted Item BOM PO Factory Cost's Currency  
 [sbi_ftyprc] [numeric](13, 4) ,  -- Current Assorted Item BOM PO Factory Price  
 [sbi_bcurcde] [nvarchar] (6) ,  -- Current Assorted Item BOM Cost Currency  
 [sbi_bomcst] [numeric](13, 4) ,  -- Current Assorted Item BOM Cost  
   
 [sbi_obcurcde] [nvarchar] (6) ,  -- Stored in IMBOMASS BOM Item Currency  
 [sbi_obomcst] [numeric](13, 4) ,  -- Stored in IMBOMASS BOM Cost  
 [sbi_obomprc] [numeric](13, 4) ,  -- Stored in IMBOMASS BOM Price  
  
 [sbi_creusr] [nvarchar] (30),  -- Create User  
 [sbi_updusr] [nvarchar] (30),  -- Update User  
 [sbi_credat] datetime,   -- Create Date & Time  
 [sbi_upddat] datetime,   -- Update Date & Time  
 [sbi_timstp] int,     -- Time Stamp  
 --Lester Wu 2006-05-17
 [sbi_bompoflg] char(1) -- BOM PO Flag
  
 )  
  

DECLARE  
 @ITMNO nvarchar(20),    
 @ASSITM nvarchar(20),  
 @ITMNO2 nvarchar(20),    
 @ASSITM2 nvarchar(20),  
 @COSTING char(1),  
 @CURCDE varchar(4),  
 @BOMBASPRC numeric (13,4),  
 @assinrqty int,  
 @mtrqty int  ,
 @PERIOD nvarchar(7) -- Frankie Cheung 20110224 Add Assd/Bom Period
   
  
--- Select Regular item with BOM item first ---  
DECLARE Assitm_cursor CURSOR FOR   
SELECT   
 IBA_ITMNO,   
 IBA_ASSITM,  
 IBA_COSTING,  
 IBA_CURCDE,  
 IBA_BOMBASPRC,   
--Frankie Cheung 20110224 Add assd/bom period
case when year(iba_period) = 1900 then '' else
ltrim(str(year(iba_period))) + '-' + right('0' +  ltrim(str( month(iba_period))),2) end as 'iba_period'
FROM   
 IMBOMASS   
WHERE   
 IBA_ITMNO = @iba_itmno  
 and iba_typ = 'BOM'  
  
OPEN Assitm_cursor   
FETCH NEXT FROM Assitm_cursor   
INTO @ITMNO, @ASSITM,  @COSTING, @CURCDE , @BOMBASPRC
,@PERIOD -- Frankie Cheung 20110224 Add Assd/Bom Period
  
  
  
WHILE @@FETCH_STATUS = 0  
BEGIN  
 INSERT INTO  
  #Tmp_SCBOMINF  
 (  
  sbi_cocde,  sbi_ordno,  sbi_ordseq,  sbi_itmno,  
  sbi_assitm,  sbi_assinrqty, sbi_assmtrqty,  sbi_bomitm,  
  sbi_venno,  sbi_bomdsce, sbi_bomdscc, sbi_colcde,  
  sbi_coldsc,  
  sbi_imperiod, -- Frankie Cheung 20110224 Add Assd/Bom Period
  sbi_pckunt,  sbi_ordqty,  sbi_fcurcde,   
  sbi_ftyprc,  sbi_bcurcde, sbi_bomcst ,    
  sbi_obcurcde,  sbi_obomcst,  sbi_obomprc,  
  sbi_creusr,  
  sbi_updusr, sbi_credat,  sbi_upddat,  sbi_timstp, sbi_bompoflg
 )  
  
 SELECT    
  iba_cocde,  '',  '',  iba_itmno,    
  ' ' as 'iba_assitm', 1as 'iba_inrqty', 1as 'iba_mtrqty', iba_assitm,  
  ibi_venno,  ibi_engdsc,  ibi_chndsc,  iba_colcde,  
  isnull(icf_coldsc,'') as 'icf_coldsc',  
  @PERIOD, -- Frankie Cheung 20110224 Add Assd/Bom Period
  iba_pckunt, iba_bomqty, imu_bcurcde,  
  isnull(imu_ftycst, 0) as 'imu_ftycst',  
  imu_curcde,  
  isnull(imu_ftyprc, 0) as 'imu_ftyprc',   
  @CURCDE,  
  CASE  @COSTING  
   WHEN 'Y' THEN ISNULL(@BOMBASPRC ,'0')  
   ELSE '0'   
  end AS 'obomcst',  
  
  CASE  @COSTING  
   WHEN 'N' THEN ISNULL(@BOMBASPRC ,'0')  
   ELSE '0'  
  end  AS 'obomprc',  
  'SYSTEM',  'SYSTEM',  
  GETDATE(), GETDATE(),  cast(iba_timstp as int) as 'iba_timstp'  
  , iba_genpo	--Lester Wu 2006-05-17
 from   
  IMBOMASS  
  left join IMBASINF on ibi_itmno = iba_assitm  
  left join IMCOLINF on icf_itmno = iba_assitm and iba_colcde = icf_colcde  
--  left join IMCOLINF on icf_itmno = iba_assitm and iba_colcde = icf_vencol  
--  left join immrkup on imu_itmno = iba_assitm  
left join IMPRCINF on imu_itmno = iba_assitm
 where   
  iba_itmno =  @itmno  
  AND iba_assitm = @ASSITM    
    
  
  
  
 FETCH NEXT FROM Assitm_cursor   
 INTO @ITMNO, @ASSITM,  @COSTING, @CURCDE , @BOMBASPRC   
,@PERIOD -- Frankie Cheung 20110224 Add Assd/Bom Period
  
END  
  
CLOSE Assitm_cursor   
DEALLOCATE Assitm_cursor   
-----------------------------------------------  
  
--- Select Assortment Item with BOM item first ---  
DECLARE Assitm_cursor CURSOR FOR   
SELECT   
 IBA_ITMNO,   
 IBA_ASSITM  
FROM   
 IMBOMASS   
WHERE   
 IBA_ITMNO = @iba_itmno  
 and iba_typ <> 'BOM'  
  

  
  
---SELECT * FROM IMBOMASS WHERE IBA_ITMNO =  '04B32V-VW04A1' AND IBA_TYP <> 'BOM'  
--SELECT * FROM IMBOMASS WHERE IBA_ITMNO =  '03B32V-VW0401' AND IBA_TYP = 'BOM'  
--SELECT * FROM IMBOMASS WHERE IBA_ITMNO =  '04B32V-VG010A' AND IBA_TYP = 'BOM'  
  
OPEN Assitm_cursor   
FETCH NEXT FROM Assitm_cursor   
INTO @ITMNO, @ASSITM  
  
WHILE @@FETCH_STATUS = 0  
BEGIN  
 ------------------------------------------------  
 select   
  @assinrqty = iba_inrqty,  
  @mtrqty = iba_mtrqty  
 FROM  
  IMBOMASS  
 WHERE   
  IBA_ITMNO = @ITMNO AND  
  IBA_ASSITM = @ASSITM  
 ------------------------------------------------  
 DECLARE BOM_cursor CURSOR FOR   
 SELECT   
  IBA_ITMNO,   
  IBA_ASSITM,  
  IBA_COSTING,  
  IBA_CURCDE,  
  IBA_BOMBASPRC   
 FROM   
  IMBOMASS   
 WHERE   
  IBA_ITMNO = @ASSITM  
  and iba_typ = 'BOM'  
   
 OPEN BOM_cursor   
 FETCH NEXT FROM BOM_cursor   
 INTO @ITMNO2, @ASSITM2, @COSTING, @CURCDE , @BOMBASPRC   
  
 WHILE @@FETCH_STATUS = 0  
 BEGIN  
  INSERT INTO  
   #Tmp_SCBOMINF  
  (  
   sbi_cocde,  sbi_ordno,  sbi_ordseq,  sbi_itmno,  
   sbi_assitm,  sbi_assinrqty, sbi_assmtrqty,  sbi_bomitm,  
   sbi_venno,  sbi_bomdsce, sbi_bomdscc, sbi_colcde,  
   sbi_coldsc,  sbi_pckunt,  sbi_ordqty,  sbi_fcurcde,   
   sbi_ftyprc,  sbi_bcurcde, sbi_bomcst ,    
   sbi_obcurcde,  sbi_obomcst,  sbi_obomprc,  
   sbi_creusr,  
   sbi_updusr, sbi_credat,  sbi_upddat,  sbi_timstp  , sbi_bompoflg
  )  
  
  SELECT    
   iba_cocde,  '',  '',  @iba_itmno,    
   @ITMNO2, @ASSINRQTY, @MTRQTY, iba_assitm,  
   ibi_venno,  ibi_engdsc,  ibi_chndsc,  iba_colcde,  
   isnull(icf_coldsc,'') as 'icf_coldsc',  iba_pckunt,  iba_bomqty, imu_bcurcde,  
   isnull(imu_ftycst, 0) as 'imu_ftycst',  
   imu_curcde,  
   isnull(imu_ftyprc, 0) as 'imu_ftyprc',   
   @CURCDE,  
   CASE  @COSTING  
    WHEN 'Y' THEN ISNULL(@BOMBASPRC ,'0')  
    ELSE '0'  
   end AS 'obomcst',   
   CASE  @COSTING  
    WHEN 'N' THEN ISNULL(@BOMBASPRC ,'0')  
    ELSE '0'  
   end AS 'obomprc',  
   'SYSTEM',  'SYSTEM',  
   GETDATE(), GETDATE(),  cast(iba_timstp as int) as 'iba_timstp'  , 
   iba_genpo	--Lester Wu 2006-05-17
  from   
   IMBOMASS  
   left join IMBASINF on ibi_itmno = iba_assitm  
--   left join IMCOLINF on icf_itmno = iba_assitm and iba_colcde = icf_colcde  
   left join IMCOLINF on icf_itmno = iba_assitm and iba_colcde = icf_vencol  
--   left join immrkup on imu_itmno = iba_assitm  
left join IMPRCINF on imu_itmno = iba_assitm
  where   
   iba_itmno =  @itmno2 and iba_assitm = @ASSITM2   
  
  FETCH NEXT FROM BOM_cursor   
  INTO @ITMNO2, @ASSITM2, @COSTING, @CURCDE , @BOMBASPRC   
 END  
   
 CLOSE BOM_cursor   
 DEALLOCATE BOM_cursor   
  
 FETCH NEXT FROM Assitm_cursor   
 INTO @ITMNO, @ASSITM  
END  
  
CLOSE Assitm_cursor   
DEALLOCATE Assitm_cursor   
  
  
-----------------------------------------------  
  
  
  
  
  
  
  
  
  
--- Output Result ----  
select distinct * from #Tmp_SCBOMINF  
--- Output Result ----  
  
  
  
  
  










GO
GRANT EXECUTE ON [dbo].[sp_select_IMBOM_SC] TO [ERPUSER] AS [dbo]
GO
