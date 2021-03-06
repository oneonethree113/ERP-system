/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUOTNDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO












/*=========================================================
Program ID	: 	sp_select_QUOTNDTL
Description   	: 
Programmer  	: 	 
ALTER  Date   	: 	 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description

=========================================================
*/


CREATE             PROCEDURE [dbo].[sp_select_QUOTNDTL] 

@cocde	nvarchar(6),
@qutno	nvarchar(20)

AS


declare 
@del nvarchar(3),	
@upditmdtl nvarchar(3),	
@updmoqmoa nvarchar(3),	
@updassbom nvarchar(3),	
@converttopc nvarchar(3),	
@mode nvarchar(3)

set @del = 'N'
set @upditmdtl = 'N'
set @updmoqmoa = 'N'
set @updassbom = 'N'
set @converttopc = 'N'
set @mode = ''

-- temp CIH Currency, Price in Char Type
declare @CIH_Curr nvarchar(3),	@CIH_Amt nvarchar(13)
set @CIH_Curr  = ''
set @CIH_Amt = ''
------------------------------------------------------------------------------


select 
distinct
------------------------------ 1. Functional
@del as 'Del',	
@mode as 'mode',
@upditmdtl as 'upditmdtl',	
@updmoqmoa as 'updmoqmoa',	
@updassbom as 'updassbom',	
@converttopc as 'converttopc'	,
------------------------------ 2. Qutotation and Status
qud_cocde ,
qud_qutno ,
qud_qutseq ,
case (
	case ibi_itmsts when NULL then (
		select ibi_itmsts from IMBASINFH where ibi_itmno = qud_itmno )
	else
		ibi_itmsts end ) when NULL then qud_itmsts
else (
	case ibi_itmsts when NULL then (
		select ibi_itmsts from IMBASINFH where ibi_itmno = qud_itmno )
	else 
		ibi_itmsts end )
end as 'qud_itmsts' ,	
qud_qutitmsts,
------------------------------ 3. Item
qud_itmno ,	
qud_itmtyp,
qud_itmnotyp,	
qud_itmnoreal,	
qud_itmnotmp,
qud_itmnoven,	
case isnull(qud_itmnovenno, '') when '' then '' else qud_itmnovenno + ' - ' + isnull(itmven.vbi_vensna,'') end as 'qud_itmnovenno',	
qud_itmdsc ,	
isnull(qud_cusstyno,'') as 'qud_cusstyno' ,
qud_cusitm,
qud_alsitmno,
isnull(qud_upc,'') as 'qud_upc',
------------------------------ 4. Color
qud_colcde ,
qud_coldsc ,
qud_alscolcde,
qud_cuscol ,
------------------------------ 5. Packing and Terms
qud_pckseq ,
qud_untcde + ' / ' + convert(varchar(10),qud_inrqty) + ' / ' + convert(varchar(10), qud_mtrqty) + ' / ' + qud_prctrm + ' / ' + qud_ftyprctrm + ' / ' + qud_trantrm as 'qud_packterm',
qud_untcde ,
qud_inrqty ,
qud_mtrqty ,
isnull(qud_prctrm,'') as 'qud_prctrm',
isnull(qud_ftyprctrm,'') as 'qud_ftyprctrm',
qud_trantrm,
qud_conftr,	
Convert(varchar,qud_effdat,101) as 'qud_effdat',
Convert(varchar,qud_expdat,101) as 'qud_expdat',
qud_cus1no,
qud_cus2no,
cast(Convert(float, qud_cft) as nvarchar) as 'qud_cft' ,
isnull(qud_cbm ,0) as 'qud_cbm',
cast(Convert(float, qud_inrdin) as nvarchar) + 'x' + cast(Convert(float, qud_inrwin) as nvarchar)+ 'x' + cast(Convert(float, qud_inrhin) as nvarchar) as 'inner_in',
cast(Convert(float, qud_mtrdin) as nvarchar)+ 'x' + cast(Convert(float, qud_mtrwin) as nvarchar)+  'x' + cast(Convert(float, qud_mtrhin) as nvarchar) as 'master_in',	
cast(Convert(float, qud_inrdcm) as nvarchar)+ 'x' + cast(Convert(float, qud_inrwcm) as nvarchar)+ 'x' + cast(Convert(float, qud_inrhcm) as nvarchar) as 'inner_cm',	
cast(Convert(float, qud_mtrdcm) as nvarchar)+ 'x' + cast(Convert(float, qud_mtrwcm) as nvarchar)+ 'x' + cast(Convert(float, qud_mtrhcm) as nvarchar) as 'master_cm',
qud_inrdin ,
qud_inrwin ,
qud_inrhin ,
qud_mtrdin ,
qud_mtrwin ,
qud_mtrhin ,
qud_inrdcm ,
qud_inrwcm ,
qud_inrhcm ,
qud_mtrdcm ,
qud_mtrwcm ,
qud_mtrhcm ,
qud_qutdat ,	
qud_grswgt ,
qud_netwgt ,
qud_pckitr,
------------------------------ 6. Others and MOQ
qud_dept ,
qud_hstref ,	
cast(Convert(float, qud_moq) as nvarchar) as 'qud_moq' ,
qud_moqunttyp,
cast(Convert(float, qud_moa) as nvarchar) as 'qud_moa' ,
------------------------------ 7. Pricing in Quotation
qud_prcsec,	
qud_grsmgn,	
qud_curcde ,
qud_cus1sp ,	
qud_cus2sp ,	
qud_cus1dp ,
qud_cus2dp ,	
qud_discnt ,
qud_contopc,
isnull(qud_pcprc,0) as 'qud_pcprc',
qud_fcurcde,
qud_ftyprc ,
qud_ftycst,
qud_basprc,
------------------------------ 8. Pricing in Quotation Price Element
isnull(qpe_cocde, '') as 'qpe_cocde',
isnull(qpe_qutno, '') as 'qpe_qutno',
isnull(qpe_qutseq, 0) as 'qpe_qutseq',
isnull(qpe_itmno, '') as 'qpe_itmno',
isnull(qpe_untcde, '') as 'qpe_untcde',
isnull(qpe_inrqty, 0) as 'qpe_inrqty',
isnull(qpe_mtrqty, 0) as 'qpe_mtrqty',
isnull(qpe_cft, 0) as 'qpe_cft',
isnull(qpe_cbm, 0) as 'qpe_cbm',
isnull(qpe_ftyprctrm, '') as 'qpe_ftyprctrm',
isnull(qpe_prctrm, '') as 'qpe_prctrm',
isnull(qpe_trantrm, '') as 'qpe_trantrm',

isnull(qpe_fml_cus1no, '') as 'qpe_fml_cus1no',
isnull(qpe_fml_cus2no, '') as 'qpe_fml_cus2no',
isnull(qpe_fml_cat, '') as 'qpe_fml_cat',
isnull(qpe_fml_venno, '') as 'qpe_fml_venno',
isnull(qpe_fml_prctrm, '') as 'qpe_fml_prctrm',
isnull(qpe_fml_trantrm, '') as 'qpe_fml_trantrm',

isnull(qpe_fml_ventranflg, '') as 'qpe_fml_ventranflg',

isnull(qpe_fcurcde, '') as 'qpe_fcurcde',
isnull(qpe_ftycst, 0) as 'qpe_ftycst',
isnull(qpe_ftyprc, 0) as 'qpe_ftyprc',
isnull(qpe_curcde, '') as 'qpe_curcde',
isnull(qpe_basprc, 0) as 'qpe_basprc',
isnull(qpe_mu, 0) as 'qpe_mu',
isnull(qpe_mumin, 0) as 'qpe_mumin',
isnull(qpe_muprc, 0) as 'qpe_muprc',
isnull(qpe_muminprc, 0) as 'qpe_muminprc',
isnull(qpe_cus1sp, 0) as 'qpe_cus1sp',
isnull(qpe_cus1dp, 0) as 'qpe_cus1dp',
isnull(qpe_cushcstbufper, 0) as 'qpe_cushcstbufper',
isnull(qpe_cushcstbufamt, 0) as 'qpe_cushcstbufamt',
isnull(qpe_othdisper, 0) as 'qpe_othdisper',
isnull(qpe_maxapvper, 0) as 'qpe_maxapvper',
isnull(qpe_maxapvamt, 0) as 'qpe_maxapvamt',
isnull(qpe_spmuper, 0) as 'qpe_spmuper',
isnull(qpe_dpmuper, 0) as 'qpe_dpmuper',
isnull(qpe_cumu, 0) as 'qpe_cumu',
isnull(qpe_pm, 0) as 'qpe_pm',
isnull(qpe_cush, 0) as 'qpe_cush',
isnull(qpe_thccusper, 0) as 'qpe_thccusper',
isnull(qpe_upsper, 0) as 'qpe_upsper',
isnull(qpe_labper, 0) as 'qpe_labper',
isnull(qpe_faper, 0) as 'qpe_faper',
isnull(qpe_cstbufper, 0) as 'qpe_cstbufper',
isnull(qpe_othper, 0) as 'qpe_othper',
isnull(qpe_pliper, 0) as 'qpe_pliper',
isnull(qpe_dmdper, 0) as 'qpe_dmdper',
isnull(qpe_rbtper, 0) as 'qpe_rbtper',
isnull(qpe_subttlper, 0) as 'qpe_subttlper',
isnull(qpe_pkgper, 0) as 'qpe_pkgper',
isnull(qpe_comper, 0) as 'qpe_comper',
isnull(qpe_icmper, 0) as 'qpe_icmper',
isnull(qpe_stdprc, 0) as 'qpe_stdprc',
isnull(qpe_ftycstA, 0) as 'qpe_ftycstA',
isnull(qpe_ftycstB, 0) as 'qpe_ftycstB',
isnull(qpe_ftycstC, 0) as 'qpe_ftycstC',
isnull(qpe_ftycstD, 0) as 'qpe_ftycstD',
isnull(qpe_ftycstE, 0) as 'qpe_ftycstE',
isnull(qpe_ftycstTran, 0) as 'qpe_ftycstTran',
isnull(qpe_ftycstPack, 0) as 'qpe_ftycstPack',
isnull(qpe_lightspec, '') as 'qpe_lightspec',
isnull(qpe_creusr, '') as 'qpe_creusr',
isnull(qpe_updusr, '') as 'qpe_updusr',
isnull(qpe_credat, '1900/01/01') as 'qpe_credat',
isnull(qpe_upddat, '1900/01/01') as 'qpe_upddat',
isnull(cast(qpe_timstp as int ), '') as 'qpe_timstp',
------------------------------ 9. Sample and TO
qud_stkqty,	
qud_cusqty,
qud_smpqty ,
qud_smpunt,	
qud_smpprc,	
qud_rndsts,
isnull(qud_buyer, '') as 'qud_buyer',
isnull(qud_toqty, '') as 'qud_toqty',
isnull(qud_tormk, '') as 'qud_tormk',
isnull(qud_ftyshpstr, '1900/01/01') as 'qud_ftyshpstr',
isnull(qud_ftyshpend, '1900/01/01') as 'qud_ftyshpend',
isnull(qud_cushpstr, '1900/01/01') as 'qud_cushpstr',
isnull(qud_cushpend, '1900/01/01') as 'qud_cushpend',
------------------------------ 10. Vendor
qud_venno + ' - ' + ven.vbi_vensna + ' ('+ (case ven.vbi_vensts	when 'A' then 'Active)' when 'I' then 'Inactive)' when 'D' then 'Discontinue)' end ) as 'qud_venno',
ven.vbi_vensts, 
qud_venitm ,	
qud_cusven + ' - ' + isnull(cusven.vbi_vensna,'') as 'qud_cusven',
isnull(qud_DV, '') as 'qud_DV',
isnull(qud_TV, '') as 'qud_TV',
isnull(qud_ftyaud, '') as 'qud_ftyaud',
------------------------------ 11. Others
qud_cususdcur,
qud_cususd ,
qud_cuscadcur,
qud_cuscad ,
qud_note ,		
qud_image ,
qud_imgpth,
qud_hrmcde ,
qud_dtyrat ,
qud_cosmth ,
isnull(b.ysi_dsc,'') as 'ysi_dsc',
qud_apprve, 	
ibi_catlvl3,
ven.vbi_ventyp,
@CIH_Curr as 'CIHCURR',
@CIH_Amt as 'CIHAMT',

---- 12. consider to delete, temporary as reference
qud_onetim ,	
qud_pdabpdiff,	
isnull(qud_ftytmpitm,'') as 'qud_ftytmpitm',
isnull(qud_ftytmpitmno,'') as 'qud_ftytmpitmno',
'' as 'qce_amt',
qud_subcde,
qud_tbm,
qud_tbmsts,	
isnull(qud_moflag,'') as 'qud_moflag',
isnull(qud_orgmoq,0) as 'qud_orgmoq',
isnull(qud_orgmoa,0) as 'qud_orgmoa',
qud_cussub , 
isnull(qud_specpck,'') as 'qud_specpck' ,
isnull(custitmcat.ysi_dsc,'') as 'qud_custitmcat',
qud_custitmcatfml,
qud_custitmcatamt,
qud_pmu,
qud_imrmk,
isnull(qud_calpmu,0) as 'qud_calpmu',

--20131230
isnull(qud_toshipport,'') as 'qud_toshipport',


qud_creusr ,
qud_updusr ,
qud_credat ,
qud_upddat ,
cast(qud_timstp as int ) as 'qud_timstp'
----------20130902 for check status and appove ----
--
--

from 	QUOTNDTL (nolock)
left join 	SYSETINF b (nolock) on	b.ysi_cocde = ' '		and
			b.ysi_typ = '07'		and
			b.ysi_cde = qud_cosmth
left join 	VNBASINF ven (nolock) on 	ven.vbi_venno = qud_venno 
left join	IMBASINF (nolock) on	ibi_itmno = qud_itmno
left join 	VNBASINF cusven (nolock) on qud_cusven = cusven.vbi_venno
left join 	VNBASINF itmven (nolock) on qud_itmnovenno = itmven.vbi_venno
left join 	SYSETINF custitmcat (nolock)	on custitmcat.ysi_cocde = ' ' 	and 
			custitmcat.ysi_cde = isnull(qud_custitmcat,'') and
			custitmcat.ysi_typ = '18'
left   join 	QUPRCEMT (nolock) on qpe_cocde = qud_cocde and qpe_qutno = qud_qutno and qpe_qutseq = qud_qutseq
where	qud_cocde = @cocde	and
	qud_qutno = @qutno 
order by 	qud_qutseq























GO
GRANT EXECUTE ON [dbo].[sp_select_QUOTNDTL] TO [ERPUSER] AS [dbo]
GO
