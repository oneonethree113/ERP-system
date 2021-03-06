/****** Object:  StoredProcedure [dbo].[SP_Select_CopyItemMaster]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[SP_Select_CopyItemMaster]
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_CopyItemMaster]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO









/*  
=========================================================  
Program ID :   
Description    :   
Programmer   :   
ALTER  Date    :   
Last Modified   : 17 July 2003  
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================       
17 July 2003 Allan Yuen  For Merge Porject  
05 Sept 2003  Allan Yuen  Add Automatic add item alias   
    after active History item.  
26 July 2003  Allan Yuen  Add Wastage %  
23 May 2005 Allan Yuen  Add Custom Vendor Code  
15 July 2005 Allan Yuen  Add Product Develop item no, mbcode & mbname.  
04 Jan 2005 Allan Yuen  Add Factory Price Term  
09 MAR 2005 Allan Yuen  Add Product Type for External Vendor  
21 June 2006 Marco Chan  FtyBOMCst new calculation method with real storage  
*/  
  
  
  
  
CREATE PROCEDURE [dbo].[SP_Select_CopyItemMaster]   
  
@cocde nvarchar(6),  
@ibi_itmno nvarchar(20),  
@UsrID nvarchar(30) =  'SYSTEM'  
  
  
AS                                                                                                                                                                                                                                                             
    
                                                                                                                                                                                                                                                               
  
DECLARE  @Colcde nvarchar(2),  
  @Price nvarchar(2),  
  @Packing nvarchar(2),  
  @ibi_itmsts nvarchar(6)   
BEGIN   
  
 BEGIN    
  DECLARE cur_itmno CURSOR  
  FOR SELECT  
  ibi_itmno  
  FROM IMBASINFH  (nolock)
  WHERE    
   --ibi_cocde = @cocde and   
   ibi_itmno = @ibi_itmno  
  ORDER BY   
   ibi_itmno  
    
  OPEN cur_itmno  
  FETCH NEXT FROM cur_itmno INTO  
  @ibi_itmno  
    
  WHILE @@fetch_status = 0  
  BEGIN  
  --*****************************************************************************  
  --***************************IMBASINF***************************************  
  --*****************************************************************************  
   INSERT INTO IMBASINF  
   (ibi_cocde,  ibi_itmno,  ibi_orgitm,  ibi_lnecde, ibi_prdtyp,  
   ibi_curcde,  ibi_catlvl0,  ibi_catlvl1,  ibi_catlvl2,  
   ibi_catlvl3,  ibi_catlvl4,  ibi_itmsts,  ibi_typ,  
   ibi_engdsc,  ibi_chndsc,  ibi_venno,  ibi_cusven,  
   ibi_imgpth,  
   ibi_hamusa, ibi_hameur, ibi_dtyusa,  ibi_dtyeur,  
   ibi_cosmth, ibi_rmk,  ibi_tirtyp,  ibi_moqctn,  
   ibi_qty,  ibi_moa,  ibi_prvsts,  ibi_latrdat,  
   ibi_alsitmno, ibi_alscat,  ibi_orgdvenno,   
   -- 20040726 AY add wastage %  
   ibi_wastage,   
--ibi_pditmno, ibi_mbcde,  ibi_mbname,  
   -------------------------------------------------  
   ibi_itmnat,

	-- Added by Mark Lau 20090210
	ibi_dsgno	,
	ibi_finishing	,
	ibi_material	,
	ibi_prdsizeTyp	,
	ibi_prdsizeUnt,
	ibi_prdsizeVal	,
	ibi_moqunttyp	,

	ibi_prdicon,
	ibi_prdgrp,
	ibi_imgpthhr,
ibi_tradeven,
ibi_examven,
ibi_season,
ibi_designer,
ibi_devteam,
ibi_type,
ibi_year,
ibi_addreq_forma,
ibi_addreq_ccbi,
ibi_addreq_ster,
   ibi_creusr,    
   ibi_updusr,  ibi_credat,  ibi_upddat)  
  
   SELECT   
    --ibi_cocde, ibi_itmno,  ibi_orgitm,  ibi_lnecde,  
    ' ',  ibi_itmno,  ibi_orgitm,  ibi_lnecde, ibi_prdtyp,  
    ibi_curcde,  ibi_catlvl0,  ibi_catlvl1, ibi_catlvl2,  
    ibi_catlvl3,  ibi_catlvl4,    
    --ibi_itmsts,    
    -- AY Change the Item status to 'TBC' after activate.  
    'TBC',  
    ibi_typ,  
    ibi_engdsc,  ibi_chndsc,  ibi_venno, ibi_cusven,  
    ibi_imgpth,  
    ibi_hamusa, ibi_hameur, ibi_dtyusa,  ibi_dtyeur,  
    ibi_cosmth, ibi_rmk,  ibi_tirtyp,  ibi_moqctn,  
    ibi_qty,  ibi_moa,  ibi_prvsts,  ibi_latrdat,  
    ibi_alsitmno, ibi_alscat,  ibi_orgdvenno,   
    -- 20040726 AY add wastage %  
    ibi_wastage,   
--ibi_pditmno, ibi_mbcde,  ibi_mbname,  
    --------------------------------------------------  
    ibi_itmnat,

	-- Added by Mark Lau 20090210
	ibi_dsgno	,
	ibi_finishing	,
	ibi_material	,
	ibi_prdsizeTyp	,
	ibi_prdsizeUnt,
	ibi_prdsizeVal	,
	ibi_moqunttyp	,
	
	ibi_prdicon,
	ibi_prdgrp,
	ibi_imgpthhr,
ibi_tradeven,
ibi_examven,
ibi_season,
ibi_designer,
ibi_devteam,
ibi_type,
ibi_year,
ibi_addreq_forma,
ibi_addreq_ccbi,
ibi_addreq_ster,
    ibi_creusr,       
    --ibi_updusr, ibi_credat,  ibi_upddat   
    @UsrID,  ibi_credat,  getdate()  
  
   FROM IMBASINFH  (nolock)
   WHERE   
    ibi_itmno = @ibi_itmno   
    --AND ibi_cocde = @cocde  
   --Check Status  
   Begin  
    if (Select count(*) From IMCOLINFH (nolock) where   
      --icf_cocde = @cocde and   
      icf_itmno = @ibi_itmno) > 0  
     SET @Colcde = 'Y'  
    else  
     SET @Colcde = 'N'  
    if (Select count(*) From IMPCKINFH (nolock) where   
      --ipi_cocde = @cocde and   
      ipi_itmno = @ibi_itmno) > 0  
  
     SET @Packing = 'Y'  
    else  
     SET @Packing = 'N'  
    if (Select count(*) From IMMRKUPH (nolock) where   
      --imu_cocde = @cocde and   
      imu_itmno = @ibi_itmno and   
      imu_basprc = 0) > 0  
     SET @Price = 'N'  
    else  
  
     SET @Price = 'Y'  
   End  
/*  
   IF @Colcde = 'Y' and @Packing = 'Y' and @Price = 'Y'   
    SET @ibi_itmsts = 'CMP'  
   Else  
    SET @ibi_itmsts = 'INC'  
  
  
   --- AY Hard code all the item will be 'TBC' after activate at 2004/04/06.  
   SET @ibi_itmsts = 'TBC'  
     
  
   UPDATE IMBASINF SET ibi_itmsts = @ibi_itmsts  
   WHERE ibi_itmno = @ibi_itmno --AND ibi_cocde = @cocde  
*/        
   DELETE FROM IMBASINFH  
   WHERE ibi_itmno = @ibi_itmno --AND ibi_cocde = @cocde  
  
  --*****************************************************************************  
  --***************************IMCSTINF****************************************  
  --*****************************************************************************  
  
   INSERT INTO IMCSTINF  
   (  
    ici_cocde, ici_itmno, ici_cstrmk, ici_expdat, ici_creusr, ici_updusr, ici_credat, ici_upddat  
   )  
   SELECT  
    ici_cocde, ici_itmno, ici_cstrmk, ici_expdat, ici_creusr,  @UsrID, ici_credat, getdate()  
   FROM  
    IMCSTINFH  (nolock)
   WHERE  
    ICI_ITMNO = @ibi_itmno  
  
   DELETE FROM IMCSTINFH  
   WHERE ici_itmno = @ibi_itmno   
  
  
  --*****************************************************************************  
  --***************************IMBOMASS**************************************  
  --*****************************************************************************  
     
   INSERT INTO IMBOMASS  
   (iba_cocde,  iba_itmno,  iba_assitm,  iba_typ,  
   iba_colcde,  iba_pckunt,  iba_bomqty, iba_inrqty,  
   iba_mtrqty,  iba_creusr,  iba_updusr, iba_credat,  
   iba_upddat,  iba_altitmno, iba_costing, iba_genpo,  
   iba_untcst,  iba_curcde,  iba_fmlopt,  iba_bombasprc,  
   iba_fcurcde,  iba_ftycst)  
   SELECT   
   --iba_cocde, iba_itmno, iba_assitm, iba_typ,  
   ' ',  iba_itmno,  iba_assitm,  iba_typ,  
   iba_colcde,  iba_pckunt,  iba_bomqty, iba_inrqty,  
   iba_mtrqty,    
--   iba_creusr,  iba_updusr, iba_credat,  iba_upddat,    
   iba_creusr,  @UsrID,  iba_credat,  getdate(),    
   iba_altitmno, iba_costing, iba_genpo,  
   iba_untcst,  iba_curcde,  iba_fmlopt,  iba_bombasprc,  
   iba_fcurcde,  iba_ftycst  
   FROM IMBOMASSH  (nolock)
   WHERE iba_itmno = @ibi_itmno --AND iba_cocde = @cocde     
  
   DELETE FROM IMBOMASSH  
   WHERE iba_itmno = @ibi_itmno --AND iba_cocde = @cocde  
  --*****************************************************************************  
  --***************************IMCOLINF***************************************  
  --*****************************************************************************  
     
   INSERT INTO IMCOLINF  
   (icf_cocde,  icf_itmno,  icf_colcde,  icf_colseq,  
   icf_vencol,  icf_coldsc,  icf_typ,  icf_ucpcde,  
   icf_eancde,  icf_asscol,  icf_swatchpath, icf_imgpath,  
   icf_venno,  icf_lnecde,  
   icf_creusr,  icf_updusr,  icf_credat,  icf_upddat)  
   SELECT   
   --icf_cocde, icf_itmno, icf_colcde, icf_colseq,  
   ' ',  icf_itmno,  icf_colcde,  icf_colseq,  
   icf_vencol,  icf_coldsc,  icf_typ,  icf_ucpcde,  
   icf_eancde,  icf_asscol,  icf_swatchpath, icf_imgpath,  
   icf_venno,  icf_lnecde,  
--   icf_creusr,  icf_updusr,  icf_credat,  icf_upddat  
   icf_creusr,  @UsrID,  icf_credat,  getdate()  

   FROM IMCOLINFH  (nolock)
   WHERE icf_itmno = @ibi_itmno --AND icf_cocde = @cocde    
  
   DELETE FROM IMCOLINFH  
   WHERE icf_itmno = @ibi_itmno --AND icf_cocde = @cocde  
  --*****************************************************************************  
  --***************************IMCTYINF***************************************  
  --*****************************************************************************  
       
   INSERT INTO IMCTYINF  
   (ici_cocde,  ici_itmno,  ici_ctyseq,  ici_ctycde,  
   ici_cusno,  ici_valdat,  ici_rmk,  ici_creusr,  
   ici_updusr,  ici_credat,  ici_upddat)  
   SELECT   
   --ici_cocde, ici_itmno,  ici_ctyseq, ici_ctycde,  
   ' ',  ici_itmno,  ici_ctyseq,  ici_ctycde,  
   ici_cusno,  ici_valdat,  ici_rmk,    
--   ici_creusr,  ici_updusr,  ici_credat,  ici_upddat  
   ici_creusr,  @UsrID,  ici_credat,  getdate()  
   FROM IMCTYINFH  (nolock)
   WHERE ici_itmno = @ibi_itmno --AND ici_cocde = @cocde     
     
   DELETE FROM IMCTYINFH  
   WHERE ici_itmno = @ibi_itmno --AND ici_cocde = @cocde  
  --*****************************************************************************  
  --***************************IMMATBKD***************************************  
  --*****************************************************************************  
     
   INSERT INTO IMMATBKD  
   (ibm_cocde, ibm_itmno, ibm_matseq, ibm_mat,
    ibm_curcde, ibm_cst, ibm_cstper, ibm_wgtper,  
    ibm_creusr, ibm_updusr, ibm_credat,ibm_upddat)  
     
   SELECT   
   ' ',  ibm_itmno, ibm_matseq, ibm_mat,
   ibm_curcde, ibm_cst, ibm_cstper, ibm_wgtper,  
   ibm_creusr, @UsrID,  ibm_credat, getdate()  
   FROM IMMATBKDH  (nolock)
   WHERE ibm_itmno = @ibi_itmno --AND ibm_cocde = @cocde  
     
   DELETE FROM IMMATBKDH  
   WHERE ibm_itmno = @ibi_itmno --AND ibm_cocde = @cocde  
  --*****************************************************************************  
  --***************************IMMRKUP***************************************  
  --*****************************************************************************  
/*     
   INSERT INTO IMMRKUP  
  
   (imu_cocde, imu_itmno, imu_typ,  imu_ventyp,  
   imu_venno, imu_prdven,  imu_pckseq, imu_pckunt, imu_inrqty,  
   imu_mtrqty, imu_cft,  imu_curcde, imu_prctrm,  
   imu_relatn,  imu_fmlopt, imu_ftycst, imu_ftyprc,  
   imu_calftyprc, imu_bcurcde, imu_basprc, imu_negprc,  
   imu_creusr, imu_updusr, imu_credat, imu_upddat,  
   imu_bomcst, imu_ttlcst,  imu_alsbasprc, imu_itmprc,  
   imu_bomprc, imu_ftyprctrm, imu_ftybomcst,
   imu_conftr)  
   SELECT   
   ' ',  imu_itmno, imu_typ,  imu_ventyp,  
   --imu_cocde, imu_itmno, imu_typ,  imu_ventyp,  
   imu_venno, imu_prdven, imu_pckseq, imu_pckunt, imu_inrqty,  
   imu_mtrqty, imu_cft,  imu_curcde, imu_prctrm,  
   imu_relatn, imu_fmlopt, imu_ftycst, imu_ftyprc,  
   imu_calftyprc, imu_bcurcde, imu_basprc, imu_negprc,  
--   imu_creusr, imu_updusr, imu_credat, imu_upddat,  
   imu_creusr, @UsrID,  imu_credat, getdate(),  
   imu_bomcst, imu_ttlcst,  imu_alsbasprc, imu_itmprc,  
   imu_bomprc,  imu_ftyprctrm, imu_ftybomcst,
   imu_conftr  
   FROM IMMRKUPH  (nolock)
   WHERE imu_itmno = @ibi_itmno --AND imu_cocde = @cocde  
     
   DELETE FROM IMMRKUPH  
   WHERE imu_itmno = @ibi_itmno --AND imu_cocde = @cocde  
*/

  --*****************************************************************************  
  --***************************IMPRCINF***************************************  
  --*****************************************************************************  

insert into IMPRCINF(
imu_cocde,
imu_itmno,
imu_typ,
imu_ventyp,
imu_venno,
imu_prdven,
imu_pckunt,
imu_conftr,
imu_inrqty,
imu_mtrqty,
imu_cft,
imu_cus1no,
imu_cus2no,
imu_ftyprctrm,
imu_hkprctrm,
imu_trantrm,
imu_effdat,
imu_expdat,
imu_status,
imu_curcde,
imu_ftycst,
imu_ftycstA,
imu_ftycstB,
imu_ftycstC,
imu_ftycstD,
imu_ftycstE,
imu_ftycstTran,
imu_ftycstPack,
imu_fml,
imu_fmlA,
imu_fmlB,
imu_fmlC,
imu_fmlD,
imu_fmlE,
imu_fmlTran,
imu_fmlPack,
imu_chgfp,
imu_chgfpA,
imu_chgfpB,
imu_chgfpC,
imu_chgfpD,
imu_chgfpE,
imu_chgfpTran,
imu_chgfpPack,
imu_ftyprc,
imu_ftyprcA,
imu_ftyprcB,
imu_ftyprcC,
imu_ftyprcD,
imu_ftyprcE,
imu_ftyprcTran,
imu_ftyprcPack,
imu_bomcst,
imu_ttlcst,
imu_hkadjper,
imu_negcst,
imu_negprc,
imu_fmlopt,
imu_bcurcde,
imu_itmprc,
imu_bomprc,
imu_basprc,
imu_period,
imu_cstchgdat,
imu_creusr,
imu_updusr,
imu_credat,
imu_upddat)
select
'',
imu_itmno,
imu_typ,
imu_ventyp,
imu_venno,
imu_prdven,
imu_pckunt,
imu_conftr,
imu_inrqty,
imu_mtrqty,
imu_cft,
imu_cus1no,
imu_cus2no,
imu_ftyprctrm,
imu_hkprctrm,
imu_trantrm,
imu_effdat,
imu_expdat,
imu_status,
imu_curcde,
imu_ftycst,
imu_ftycstA,
imu_ftycstB,
imu_ftycstC,
imu_ftycstD,
imu_ftycstE,
imu_ftycstTran,
imu_ftycstPack,
imu_fml,
imu_fmlA,
imu_fmlB,
imu_fmlC,
imu_fmlD,
imu_fmlE,
imu_fmlTran,
imu_fmlPack,
imu_chgfp,
imu_chgfpA,
imu_chgfpB,
imu_chgfpC,
imu_chgfpD,
imu_chgfpE,
imu_chgfpTran,
imu_chgfpPack,
imu_ftyprc,
imu_ftyprcA,
imu_ftyprcB,
imu_ftyprcC,
imu_ftyprcD,
imu_ftyprcE,
imu_ftyprcTran,
imu_ftyprcPack,
imu_bomcst,
imu_ttlcst,
imu_hkadjper,
imu_negcst,
imu_negprc,
imu_fmlopt,
imu_bcurcde,
imu_itmprc,
imu_bomprc,
imu_basprc,
imu_period,
imu_cstchgdat,
imu_creusr ,
imu_updusr ,
imu_credat ,
getdate() from IMPRCINFH (nolock)
WHERE imu_itmno = @ibi_itmno --AND imu_cocde = @cocde  

DELETE FROM IMPRCINFH  
WHERE imu_itmno = @ibi_itmno 


declare @ventyp nvarchar(10), @itmtyp nvarchar(10)
select @ventyp = vbi_ventyp, @itmtyp = ibi_typ from IMBASINF (nolock),VNBASINF (nolock) 
where ibi_itmno = @ibi_itmno and ibi_venno = vbi_venno


if @itmtyp <> 'BOM' and @ventyp = 'E' and (select count(*) from IMPRCINF (nolock) where imu_itmno = @ibi_itmno and imu_cus1no = '') >= 1
begin


insert into IMPRCINF
select 
imu_cocde,
imu_itmno,
imu_typ,
imu_ventyp,
imu_venno,
imu_prdven,
imu_pckunt,
imu_conftr,
imu_inrqty,
imu_mtrqty,
imu_cft,
cgi_cugrpcde,
imu_cus2no,
imu_ftyprctrm,
imu_hkprctrm,
imu_trantrm,
imu_effdat,
imu_expdat,
'INA',
imu_curcde,
imu_ftycst,
imu_ftycstA,
imu_ftycstB,
imu_ftycstC,
imu_ftycstD,
imu_ftycstE,
imu_ftycstTran,
imu_ftycstPack,
imu_fml,
imu_fmlA,
imu_fmlB,
imu_fmlC,
imu_fmlD,
imu_fmlE,
imu_fmlTran,
imu_fmlPack,
imu_chgfp,
imu_chgfpA,
imu_chgfpB,
imu_chgfpC,
imu_chgfpD,
imu_chgfpE,
imu_chgfpTran,
imu_chgfpPack,
imu_ftyprc,
imu_ftyprcA,
imu_ftyprcB,
imu_ftyprcC,
imu_ftyprcD,
imu_ftyprcE,
imu_ftyprcTran,
imu_ftyprcPack,
imu_bomcst,
imu_ttlcst,
imu_hkadjper,
imu_negcst,
imu_negprc,
imu_fmlopt,
imu_bcurcde,
imu_itmprc,
imu_bomprc,
imu_basprc,
imu_period,
imu_cstchgdat,
imu_sysgen,
imu_estprcflg,
imu_estprcref,
imu_creusr,
imu_updusr,
imu_credat,
imu_upddat,
null
 from IMPRCINF (nolock) 
left join CUGRPINF (nolock) on  cgi_flg_ext = 'Y' and cgi_cugrpcde <> '1'
where imu_itmno = @ibi_itmno and imu_cus1no = ''

update IMPRCINF set imu_cus1no = '1', imu_status = 'INA'
where imu_itmno = @ibi_itmno and imu_cus1no = ''

update IMPRCINF set imu_status = 'TBC'
from IMPRCINF (nolock) ,VNCUGREL (nolock)
where imu_itmno = @ibi_itmno 
and imu_prdven = vcr_venno
and imu_cus1no = vcr_cugrpcde
and vcr_flg_ext = 'N'


delete from IMMOQMOA where imm_itmno = @ibi_itmno

insert into IMMOQMOA
select distinct '', ibi_itmno,imu_cus1no,'',2,
case smm_moqmoa when 'MOQ' then 'PC' when 'MOA' then '' else '' end,
case smm_moqmoa when 'MOQ' then smm_moq when 'MOA' then 0 else 0 end,
0,
case smm_moqmoa when 'MOQ' then '' when 'MOA' then 'USD' else 'USD' end,
case smm_moqmoa when 'MOQ' then 0 when 'MOA' then smm_moa else 10000 end,
'mis', 'mis', getdate(),getdate(), null
  from IMBASINF (nolock)
left join IMPRCINF (nolock) on ibi_itmno = imu_itmno --and imu_cus1no = 1
left join SYMOQMOA (nolock) on ibi_itmnat = smm_nat and imu_cus1no = smm_cugrpcde
where ibi_itmno = @ibi_itmno and imu_cus1no in (1,2,3)

insert into IMMOQMOA
select distinct '', ibi_itmno,imu_cus1no,imu_cus2no,2,
ibi_moqunttyp, ibi_moqctn, 0, ibi_curcde, ibi_moa,
'mis', 'mis', getdate(),getdate(), null
  from IMBASINF (nolock)
left join IMPRCINF (nolock) on ibi_itmno = imu_itmno --and imu_cus1no = 1
left join SYMOQMOA (nolock) on ibi_itmnat = smm_nat and imu_cus1no = smm_cugrpcde
where ibi_itmno = @ibi_itmno and imu_cus1no not in (1,2,3) and imu_cus1no <> ''





end
     

  --*****************************************************************************  
  --***************************IMPCKINF***************************************  
  --*****************************************************************************  
     
   INSERT INTO IMPCKINF  
   (ipi_cocde,  ipi_itmno,  ipi_pckseq,  ipi_pckunt,  
   ipi_mtrqty,  ipi_inrqty,  ipi_inrhin,  ipi_inrwin,  
   ipi_inrdin,  ipi_inrhcm,  ipi_inrwcm, ipi_inrdcm,  
   ipi_mtrhin,  ipi_mtrwin, ipi_mtrdin,  ipi_mtrhcm,  
   ipi_mtrwcm, ipi_mtrdcm, ipi_cft,  ipi_cbm,  
   ipi_grswgt,  ipi_netwgt,  ipi_pckitr,  ipi_creusr,  
   ipi_updusr,  ipi_credat,  ipi_upddat,
   ipi_conftr, ipi_cusno,
	-- Added by Mark Lau 20090210
	ipi_qutdat,ipi_cus1no,ipi_cus2no	
)  
   SELECT   
   ' ',  ipi_itmno,  ipi_pckseq,  ipi_pckunt,  
   --ipi_cocde, ipi_itmno,  ipi_pckseq,  ipi_pckunt,  
   ipi_mtrqty,  ipi_inrqty,  ipi_inrhin,  ipi_inrwin,  
   ipi_inrdin,  ipi_inrhcm,  ipi_inrwcm, ipi_inrdcm,  
   ipi_mtrhin,  ipi_mtrwin, ipi_mtrdin,  ipi_mtrhcm,  
   ipi_mtrwcm, ipi_mtrdcm, ipi_cft,  ipi_cbm,  
   ipi_grswgt,  ipi_netwgt,  ipi_pckitr,  ipi_creusr,  
--   ipi_updusr,  ipi_credat,  ipi_upddat  
   @UsrID,  ipi_credat,  getdate(),
   ipi_conftr, ipi_cusno  ,
	-- Added by Mark Lau 20090210
	ipi_qutdat, ipi_cus1no,ipi_cus2no
   FROM IMPCKINFH  (nolock)
   WHERE ipi_itmno = @ibi_itmno --AND ipi_cocde = @cocde  
     
   DELETE FROM IMPCKINFH  
   WHERE ipi_itmno = @ibi_itmno --AND ipi_cocde = @cocde  
  --*****************************************************************************  
  --***************************IMSALBKG*************************************  
  --*****************************************************************************  
     
   INSERT INTO IMSALBKGH  
   (isb_cocde,  isb_itmno,  isb_yymm,  isb_mtdbok,  
   isb_mtdsal,  isb_mtdpur, isb_creusr,  isb_updusr,  
   isb_credat,  isb_upddat)  
   SELECT   
   ' ',  isb_itmno,  isb_yymm,  isb_mtdbok,  
   --isb_cocde, isb_itmno,  isb_yymm,  isb_mtdbok,  
   isb_mtdsal,  isb_mtdpur, isb_creusr,    
--   isb_updusr, isb_credat,  isb_upddat  
   @UsrID,  isb_credat,  getdate()  
   FROM IMSALBKGH  (nolock)
   WHERE isb_itmno = @ibi_itmno --AND isb_cocde = @cocde  
     
   DELETE FROM IMSALBKGH  
   WHERE isb_itmno = @ibi_itmno --AND isb_cocde = @cocde  
  --*****************************************************************************  
  --***************************IMVENINF***************************************  
  --*****************************************************************************  
     
   INSERT INTO IMVENINF  
   (ivi_cocde,  ivi_itmno,  ivi_venitm,  ivi_venno,  
   ivi_def,  ivi_subcde,  ivi_creusr,  ivi_updusr,  
   ivi_credat,  ivi_upddat)  
   SELECT   
   --ivi_cocde, ivi_itmno,  ivi_venitm,  ivi_venno,  
   ' ',  ivi_itmno,  ivi_venitm,  ivi_venno,  
   ivi_def,  ivi_subcde,    
--   ivi_creusr,  ivi_updusr,  ivi_credat,  ivi_upddat  
   ivi_creusr,  @UsrID,  ivi_credat,  getdate()  
  
   FROM IMVENINFH  (nolock)
   WHERE ivi_itmno = @ibi_itmno --AND ivi_cocde = @cocde  
     
   DELETE FROM IMVENINFH  
   WHERE ivi_itmno = @ibi_itmno --AND ivi_cocde = @cocde  
  --*****************************************************************************  
  --***************************IMVENPCK***************************************  
  --*****************************************************************************  
     
   INSERT INTO IMVENPCK  
   (ivp_cocde,  ivp_itmno,  ivp_pckseq, ivp_venno,  
   ivp_relatn,  ivp_creusr,  ivp_updusr, ivp_credat,  
   ivp_upddat)   
   SELECT   
   --ivp_cocde, ivp_itmno,  ivp_pckseq, ivp_venno,  
   ' ',  ivp_itmno,  ivp_pckseq, ivp_venno,  
   ivp_relatn,    
--   ivp_creusr,  ivp_updusr, ivp_credat,  ivp_upddat  
   ivp_creusr,  @UsrID,  ivp_credat,  getdate()  
  
   FROM IMVENPCKH  (nolock)
   WHERE ivp_itmno = @ibi_itmno --AND ivp_cocde = @cocde  
     
   DELETE FROM IMVENPCKH  
   WHERE ivp_itmno = @ibi_itmno --AND ivp_cocde = @cocde  
     
  
   FETCH NEXT FROM cur_itmno INTO  
   @ibi_itmno  
  END  
   
  CLOSE cur_itmno  
  DEALLOCATE cur_itmno  
   
 END  
  
 --- Update Alias Item No.  
 --exec sp_Update_AliasItemNo  
 ------------------------------------  
  
  
  
END


GO
GRANT EXECUTE ON [dbo].[SP_Select_CopyItemMaster] TO [ERPUSER] AS [dbo]
GO
