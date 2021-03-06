/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMRKUP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO















--select * from imbasinf where ibi_credat > '2005-12-20'  
  
--sp_select_immrkup '','03A445-770740'  
--05SAFL-27LOA8  
--051774-F02R004  
  
  
  
/*  
=========================================================  
Program ID :   
Description    :   
Programmer   :   
Create Date    :   
Last Modified   : 15 July 2003  
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================       
20030715 Allan Yuen  Modify For Merge Porject  
20051228 Allan Yuen  Add Factory BOM Cost information  
20060210 Allan Yuen  User request not calculate bom cost if PV <> DV  
20060621 Marco Chan  User request to calculate fty bom cost if PV <> DV  
*/  
  
  
/************************************************************************  
Author:  Kenny Chan  
Date:  13th September, 2001  
Description: Select data From IMMRKUP  
Parameter: 1. Company  
  2. Item No.   
************************************************************************/  
CREATE procedure [dbo].[sp_select_IMMRKUP]  
@imu_cocde nvarchar(6) ,  
@imu_itmno nvarchar(20)   
  
AS  
  
  
begin  
  
declare   
 @ibi_curcde varchar(6),  
 @rate numeric (16,11),  
 @rate1 numeric (16,11),  
-- @imu_ftybomcst numeric (13,4),  
 @iba_curcde varchar (6),  
 @iba_untcst numeric(13,4),  
 @iba_bomqty int  
  
 -- Get Currency --  
 select @ibi_curcde = imu_curcde from immrkup where imu_itmno = @imu_itmno   
 ---------------------  
  
 -- Get Exchange Rate --  
 select @rate = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = @ibi_curcde   
 select @rate1 = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'  
 ----------------------------  
/*  
 set @imu_ftybomcst = 0  
  
 DECLARE IMBOMASS_cursor CURSOR FOR   
  select iba_curcde, iba_bomqty, iba_untcst from imbomass    
  where iba_itmno = @imu_itmno   
  
 OPEN IMBOMASS_cursor   
  
 FETCH NEXT FROM IMBOMASS_cursor   
 INTO @iba_curcde, @iba_bomqty, @iba_untcst  
  
 WHILE @@FETCH_STATUS = 0  
 BEGIN  
  -- Change logic to convert all currency to 'HKD'  
  --if @iba_curcde <> @ibi_curcde  
  --begin  
  -- if @iba_curcde = 'HKD'  
  -- begin  
  --  set @imu_ftybomcst = @imu_ftybomcst + ((@iba_bomqty * @iba_untcst) *  @rate)  
  -- end  
  -- ELSE  
  -- begin  
  --  set @imu_ftybomcst = @imu_ftybomcst + ((@iba_bomqty * @iba_untcst) /  @rate)  
  -- end  
  --end  
  --else  
  --begin  
  -- set @imu_ftybomcst = @imu_ftybomcst + (@iba_bomqty * @iba_untcst)  
  --end  
    
  if @iba_curcde = 'USD'  
   set @imu_ftybomcst = @imu_ftybomcst + ((@iba_bomqty * @iba_untcst) /  @rate1)   
  else  
   set @imu_ftybomcst = @imu_ftybomcst + (@iba_bomqty * @iba_untcst)   
  
  FETCH NEXT FROM IMBOMASS_cursor   
  INTO @iba_curcde, @iba_bomqty, @iba_untcst  
  
 END  
 CLOSE IMBOMASS_cursor   
 DEALLOCATE IMBOMASS_cursor   
  
 -- Round   
 --set @imu_ftybomcst = round(@imu_ftybomcst ,4)  
*/  
 Select   
' ' as 'imu_status',          -- 0  
imu_cocde,           -- 1  
imu_itmno,          -- 2  
imu_typ,           -- 3  
imu_ventyp,          -- 4  
imu_relatn,           -- 5  
imu_venno,          -- 6  
imu_prdven,          -- 7  
imu_pckseq,          -- 8  
--Frankie Cheung 20100304 Add Cost Change Date
--imu_upddat as 'imu_cstchgdat', -- 9
--CONVERT(CHAR(10), imu_cstchgdat, 101) as 'imu_cstchgdat', -- 9
--CONVERT(nvarchar(10), imu_cstchgdat, 101) as 'imu_cstchgdat', -- 9
-- Frankie Cheung 20110210 '' if 1900-01-01
case when imu_cstchgdat > '1900-01-01' then CONVERT(nvarchar(10), imu_cstchgdat, 101) else '' end as 'imu_cstchgdat', -- 9 

--cast(CONVERT(CHAR(10), imu_cstchgdat, 101) as nvarchar(10)) as 'imu_cstchgdat', -- 9
--right('0' +  ltrim(str( month(imu_cstchgdat))),2) + '/' + right('0' +  ltrim(str( day(imu_cstchgdat))),2) + '/' + ltrim(str(year(imu_cstchgdat))) as 'imu_cstchgdat',
cast(imu_pckunt as nvarchar(10) )+ ' / ' +       
cast(imu_inrqty  as nvarchar(10) )+ ' / ' +  
cast(imu_mtrqty as nvarchar(10) )+ ' / ' +  
cast(imu_cft as nvarchar(20) ) as 'imu_packing',	--10
imu_std,
imu_curcde,          -- 11
imu_ftycst,           -- 12  
imu_ftyprc,          -- 13 
isnull(imu_bomcst,0) as 'imu_bomcst',          -- 14
imu_ttlcst,           -- 15
imu_ftyprctrm ,          -- 16
cast(imu_fmlopt as nvarchar(10))  +  ' - ' + cast(yfi_fml as nvarchar(50) ) as 'imu_fmlopt',    -- 17
yfi_prcfml,           -- 18
imu_bcurcde,          -- 19
imu_itmprc,          -- 20
isnull(imu_bomprc,0) as 'imu_bomprc',          -- 21
imu_basprc,          -- 22
imu_prctrm as 'imu_prctrm1',         -- 23
imu_alsbasprc,          -- 24
cast(imu_fmlopt as nvarchar(10))  +  ' - ' + cast(yfi_fml as nvarchar(50) ) as 'imu_fmlopt_Production',   -- 25
imu_curcde as 'imu_Calcurcde',         -- 26
imu_calftyprc,          -- 27
imu_negprc,          -- 28
--@imu_ftybomcst  as 'imu_ftybomcst',        -- 29
--case   
-- when  imu_venno = imu_prdven and imu_curcde  = 'USD' then round((@imu_ftybomcst *  @rate1),5)  
-- when  imu_venno = imu_prdven and imu_curcde  <> 'USD' then @imu_ftybomcst  
-- when  imu_venno <> imu_prdven then 0  
--end as 'imu_ftybomcst',       -- 29
--case   
-- when  imu_curcde  = 'USD' then round((@imu_ftybomcst *  @rate1),5)  
-- when  imu_curcde  <> 'USD' then @imu_ftybomcst  
--end   
isnull(imu_ftybomcst,0) as 'imu_ftybomcst',       -- 29
--case   
-- when imu_venno = imu_prdven and imu_negprc  >  0 and imu_curcde  =   'USD' then imu_negprc +  (imu_ftybomcst *  @rate1)  
-- when imu_venno = imu_prdven and imu_negprc  >  0 and imu_curcde  <> 'USD' then imu_negprc +  imu_ftybomcst  
-- when imu_venno = imu_prdven and imu_negprc  =  0 and imu_curcde  =   'USD' then imu_calftyprc +  (imu_ftybomcst *  @rate1)  
-- when imu_venno = imu_prdven and imu_negprc  =  0 and imu_curcde  <> 'USD' then imu_calftyprc +  imu_ftybomcst  
--  
-- when imu_venno <> imu_prdven and imu_negprc  >  0 and imu_curcde  =   'USD' then imu_negprc   
-- when imu_venno <> imu_prdven and imu_negprc  >  0 and imu_curcde  <> 'USD' then imu_negprc  
-- when imu_venno <> imu_prdven and imu_negprc  =  0 and imu_curcde  =   'USD' then imu_calftyprc  
-- when imu_venno <> imu_prdven and imu_negprc  =  0 and imu_curcde  <> 'USD' then imu_calftyprc  
  
case   
 when imu_negprc  >  0 and imu_curcde  =   'USD' then imu_negprc +  (imu_ftybomcst *  @rate1)  
 when imu_negprc  >  0 and imu_curcde  <> 'USD' then imu_negprc +  imu_ftybomcst  
 when imu_negprc  =  0 and imu_curcde  =   'USD' then imu_calftyprc +  (imu_ftybomcst *  @rate1)  
 when imu_negprc  =  0 and imu_curcde  <> 'USD' then imu_calftyprc +  imu_ftybomcst  
end as 'imu_ttlftycost',          -- 30
imu_ftyprctrm as 'imu_ftyprctrm1' ,        -- 31
imu_prctrm,          -- 32
imu_creusr,          -- 33  
imu_updusr,          -- 34  
imu_credat,          -- 35  
imu_upddat,          -- 36  
cast(imu_timstp as int ) as imu_timstp ,         -- 37
imu_conftr

--case when year(ipi_qutdat) = 1900 then '' else
--ltrim(str(year(ipi_qutdat))) + '-' + right('0' +  ltrim(str( month(ipi_qutdat))),2) end as 'ipi_qutdat',	--38
-------------------------------------------
--cast(imu_pckunt as nvarchar(10) )+ ' / ' +       
--cast(imu_inrqty  as nvarchar(10) )+ ' / ' +  
--cast(imu_mtrqty as nvarchar(10) )+ ' / ' +  
--cast(imu_cft as nvarchar(20) )+ ' / ' +  
--cast(ipi_cbm as nvarchar(20) ) as 'ipi_packing', 	--39	--Frankie Cheung 20110308
--'STD' as 'cbi_cussna',
--'STD' as 'imd_cus1no',
--'' as 'imd_cus2no'



---------------------------------   
from IMMRKUP  
left join SYFMLINF on yfi_fmlopt = imu_fmlopt --and yfi_cocde = @imu_cocde  
left join impckinf on ipi_itmno = imu_itmno and ipi_pckseq = imu_pckseq	-- Frankie Cheung 20110308
 where  

-- imu_cocde = @imu_cocde and  
 imu_itmno = @imu_itmno-- and  
--((imu_cocde = @imu_cocde and imu_venno in (SELECT ibi_venno FROM IMBASINF WHERE ibi_cocde = @imu_cocde and ibi_itmno = imu_itmno)) or  
--(imu_ventyp = 'P' and imu_cocde = 'UCPP'))  
order by imu_packing, imu_prdven  

end  
  
  
  
  
  
  

















GO
GRANT EXECUTE ON [dbo].[sp_select_IMMRKUP] TO [ERPUSER] AS [dbo]
GO
