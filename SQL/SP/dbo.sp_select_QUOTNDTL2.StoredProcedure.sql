/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUOTNDTL2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL2]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/*=========================================================
Program ID	: 	sp_select_QUOTNDTL2
Description   	: 
Programmer  	: 	Carlos Lui
Create Date   	: 	2012-06-07
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description

=========================================================
*/


CREATE  PROCEDURE [dbo].[sp_select_QUOTNDTL2] 

@cocde	nvarchar(6),
@qutno	nvarchar(20)

AS

declare @del nvarchar(3),	@mode nvarchar(3)

set @del = 'N'
set @mode = ''

-- temp CIH Currency, Price in Char Type
declare @CIH_Curr nvarchar(3),	@CIH_Amt nvarchar(13)
set @CIH_Curr  = ''
set @CIH_Amt = ''
------------------------------------------------------------------------------

select distinct
	@del as 'Del',	@mode as 'mode',
 	qud_cocde ,	qud_qutno ,	qud_qutseq ,
	qud_pdabpdiff,	qud_itmno ,	
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
	qud_itmdsc ,	qud_hstref ,	
	isnull(qud_cusstyno,'') as 'qud_cusstyno' ,
	isnull(qud_ftytmpitm,'') as 'qud_ftytmpitm',
	isnull(qud_ftytmpitmno,'') as 'qud_ftytmpitmno',
	qud_colcde ,	qud_alsitmno,	qud_alscolcde,
	qud_cuscol ,
	qud_coldsc ,	qud_pckseq ,	qud_curcde ,
	qud_cus1sp ,	qud_cus2sp ,	qud_cus1dp ,
	qud_cus2dp ,	qud_onetim ,	qud_discnt ,
	isnull(qce_amt,0) as 'qce_amt',
 	qud_untcde ,	qud_inrqty ,	qud_mtrqty ,
	qud_cft ,		qud_conftr,		qud_contopc,
	isnull(qud_pcprc,0) as 'qud_pcprc',
	qud_moq ,		qud_moqunttyp,	qud_moa ,	
	qud_smpqty ,	qud_hrmcde ,	qud_dtyrat ,
	qud_dept ,		qud_cususd ,	qud_cuscad ,
	qud_venno + ' - ' + ven.vbi_vensna + ' ('+
		(	case ven.vbi_vensts	when 'A' then 'Active)' 
					when 'I' then 'Inactive)'
					when 'D' then 'Discontinue)' end ) as 'qud_venno',	
	ven.vbi_vensts, 
	qud_subcde,	qud_venitm ,	qud_ftyprc ,
	qud_note ,		qud_image ,	qud_inrdin ,
	qud_inrwin ,	qud_inrhin ,	qud_mtrdin ,
	qud_mtrwin ,	qud_mtrhin ,	qud_inrdcm ,
	qud_inrwcm ,	qud_inrhcm ,	qud_mtrdcm ,
	qud_mtrwcm ,	qud_mtrhcm ,	qud_grswgt ,
	qud_netwgt ,	qud_cosmth ,	qud_creusr ,
	qud_updusr ,	qud_credat ,	qud_upddat ,
	qud_apprve, 	-- Re-arrange the position of Approve flag 2005-03-22 Lester Wu
	cast(qud_inrdin as nvarchar) + 'x' +
	cast(qud_inrwin as nvarchar)+ 'x' +
	cast(qud_inrhin as nvarchar)  as 'inner_in',
	cast(qud_mtrdin as nvarchar)+ 'x' +
	cast(qud_mtrwin as nvarchar)+  'x' +
	cast(qud_mtrhin as nvarchar) as 'master_in',	
	cast(qud_inrdcm as nvarchar)+ 'x' +
	cast(qud_inrwcm as nvarchar)+ 'x' +
	cast(qud_inrhcm as nvarchar) as 'inner_cm',	
	cast(qud_mtrdcm as nvarchar)+ 'x' +
	cast(qud_mtrwcm as nvarchar)+ 'x' +
	cast(qud_mtrhcm as nvarchar) as 'master_cm',
	cast(qud_timstp as int ) as 'qud_timstp',
	b.ysi_dsc,		qud_smpprc,	qud_cusitm,
	qud_prcsec,	qud_grsmgn,	qud_basprc,
	qud_tbm,		qud_tbmsts,	--qud_apprve,	-- Re-arrange the position of Approve flag
	qud_pckitr,		qud_stkqty,	qud_cusqty,
	qud_qutitmsts,	qud_smpunt,	qud_fcurcde,
	qud_itmtyp,	qud_ftycst,
	qud_prctrm + ' - ' + isnull(a.ysi_dsc,'') as 'qud_prctrm',
	ibi_catlvl3,		ven.vbi_ventyp,
	isnull(qud_moflag,'') as 'qud_moflag',
	isnull(qud_orgmoq,0) as 'qud_orgmoq',
	isnull(qud_orgmoa,0) as 'qud_orgmoa',
	-- Return temp CIH Currency and Amount for temp use
	@CIH_Curr as 'CIHCURR',
	@CIH_Amt as 'CIHAMT',
	-----------------------------------------------------------------------------------------------
	-- Return custom vendor and sub code
	qud_cusven + ' - ' + isnull(cusven.vbi_vensna,'') as 'qud_cusven',
	qud_cussub , 
	case isnull(qud_ftyprctrm,'') when '' then '' else qud_ftyprctrm + ' - ' + isnull(ftyprc.ysi_dsc,'') end as 'qud_ftyprctrm',
	isnull(qud_cbm ,0) as 'qud_cbm',
	isnull(qud_upc,'') as 'qud_upc',
	isnull(qud_specpck,'') as 'qud_specpck' ,
	isnull(custitmcat.ysi_dsc,'') as 'qud_custitmcat',
	qud_custitmcatfml,	qud_custitmcatamt,	qud_pmu,
	qud_imrmk,	qud_rndsts,
	isnull(qud_calpmu,0) as 'qud_calpmu',
	qud_qutdat,	qud_cus1no,	qud_cus2no,
	qud_trantrm,	qud_effdat, 	qud_expdat
from 	QUOTNDTL  (nolock)
left join 	SYSETINF b  (nolock) on	b.ysi_cocde = ' '		and
			b.ysi_typ = '07'		and
			b.ysi_cde = qud_cosmth
left join 	VNBASINF ven  (nolock) on 	ven.vbi_venno = qud_venno 
left join	IMBASINF  (nolock) on	ibi_itmno = qud_itmno
left join 	SYSETINF a  (nolock) on	a.ysi_cocde = ' '		and 
			a.ysi_cde = qud_prctrm	and
			a.ysi_typ = '03'
left join 	SYSETINF ftyprc  (nolock) on	ftyprc.ysi_cocde = ' '		and 
			ftyprc.ysi_cde = isnull(qud_ftyprctrm,'') and
			ftyprc.ysi_typ = '03'
left join 	VNBASINF cusven  (nolock) on qud_cusven = cusven.vbi_venno
left join 	SYSETINF custitmcat  (nolock)	on custitmcat.ysi_cocde = ' ' 	and 
			custitmcat.ysi_cde = isnull(qud_custitmcat,'') and
			custitmcat.ysi_typ = '18'
left join	QUCSTEMT  (nolock) on	qud_qutno = qce_qutno	and
			qud_qutseq = qce_qutseq	and
			qce_cecde = '04'
where	qud_cocde = @cocde	and
	qud_qutno = @qutno 
order by 	qud_qutseq

GO
GRANT EXECUTE ON [dbo].[sp_select_QUOTNDTL2] TO [ERPUSER] AS [dbo]
GO
