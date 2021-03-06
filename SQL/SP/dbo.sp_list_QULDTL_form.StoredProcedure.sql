/****** Object:  StoredProcedure [dbo].[sp_list_QULDTL_form]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_QULDTL_form]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_QULDTL_form]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE  PROCEDURE [dbo].[sp_list_QULDTL_form] 

@cocde	nvarchar(6),
@qutno	nvarchar(20)


AS

declare @custno nvarchar(6)

select @custno = case quh_cus2no when '' then quh_cus1no else quh_cus2no end 
from QUOTNHDR where quh_cocde = @cocde and quh_qutno = @qutno



select
qud_qutseq as 'qld_seq',
qud_cusstyno as 'qld_venstk',
qud_itmdsc as 'qld_dsc',
'' as 'qld_rmk',
qud_basprc as 'qld_ftyprc',
qud_itmno as 'qld_ftyitm',
'' as 'qld_pck',
qud_basprc as 'qld_ftyprc2',
ce04.qce_amt as 'qld_pckcst',
ce07.qce_amt as 'qld_ctnlbl',
ce06.qce_amt as 'qld_mtltest',
'' as 'qld_netcst', -- cal
'0.00%' as 'qld_mrkup', 
qud_inrqty as 'qld_inrqty',
qud_mtrqty as 'qld_mtrqty',
qud_cft as 'qld_cft',
qud_untcde as 'qld_untcde',
substring(sys03.ysi_dsc, 5, len(sys03.ysi_dsc)) 'qld_fobport',
'' as 'qld_fobcst', -- cal
'' as 'qld_flgcst', -- cal
qud_hrmcde as 'qld_htsus',
isnull(elc09.qed_percent,0) as 'qld_dutrat',
'' as 'qld_dutamt', -- cal
'' as 'qld_comm', -- cal
fcc.qec_amt as 'qld_fcc',
elc.qec_amt as 'qld_elc',
qud_calpmu as 'qld_calpmu',
qud_cususd as 'qld_retail',
quh_Year + ' ' + quh_Season + ' '+ quh_Desc as 'qld_program',
'65%' as 'qld_tarfixmrk',
yco_shtnam as 'qld_ven',
cfr_flgrat as 'qld_flgrat',
'TBA' as 'qld_prdwgt',
'TBA' as 'qld_itmdim',
qud_mtrdin as 'qld_mtrdin',
qud_mtrwin as 'qld_mtrwin',
qud_mtrhin as 'qld_mtrhin', 
qud_grswgt as 'qld_grswgt',
isnull(qcb1.qcb_cpt, '') as 'qld_mcb1mat',
isnull(qcb1.qcb_cstpct, 0) as 'qld_mcb1cst',
isnull(qcb1.qcb_pct, 0) as 'qld_mcb1wgt',
isnull(qcb2.qcb_cpt, '') as 'qld_mcb2mat',
isnull(qcb2.qcb_cstpct, 0) as 'qld_mcb2cst',
isnull(qcb2.qcb_pct, 0) as 'qld_mcb2wgt',
isnull(qcb3.qcb_cpt, '') as 'qld_mcb3mat',
isnull(qcb3.qcb_cstpct, 0) as 'qld_mcb3cst',
isnull(qcb3.qcb_pct, 0) as 'qld_mcb3wgt',
isnull(qcb4.qcb_cpt, '') as 'qld_mcb4mat',
isnull(qcb4.qcb_cstpct, 0) as 'qld_mcb4cst',
isnull(qcb4.qcb_pct, 0) as 'qld_mcb4wgt',
isnull(qcb5.qcb_cpt, '') as 'qld_mcb5mat',
isnull(qcb5.qcb_cstpct, 0) as 'qld_mcb5cst',
isnull(qcb5.qcb_pct, 0) as 'qld_mcb5wgt',
isnull(qcb6.qcb_cpt, '') as 'qld_mcb6mat',
isnull(qcb6.qcb_cstpct, 0) as 'qld_mcb6cst',
isnull(qcb6.qcb_pct, 0) as 'qld_mcb6wgt',
qud_inrdin as 'qld_inrdin',
qud_inrwin as 'qld_inrwin',
qud_inrhin as 'qld_inrhin',
qud_netwgt as 'qld_netwgt',
'' as 'qld_ftyaddr',
'' as 'qld_ftynam',
'' as 'qld_ftycont',
'' as 'qld_cusitmdsc',
'' as 'qld_soucer',
'' as 'qld_prdman'




from QUOTNDTL (nolock)
left join QUOTNHDR (nolock) on quh_cocde = qud_cocde and quh_qutno = qud_qutno
left join SYCOMINF (nolock) on yco_cocde = qud_cocde
left join VNBASINF (nolock) on vbi_venno = qud_venno
left join SYSETINF sys03 (nolock) on sys03.ysi_cde = qud_prctrm and ysi_typ = '03'
left join QUCSTEMT ce04 (nolock) on ce04.qce_cocde = qud_cocde and ce04.qce_qutno = qud_qutno and ce04.qce_qutseq = qud_qutseq and ce04.qce_cecde = '04'
left join QUCSTEMT ce06 (nolock) on ce06.qce_cocde = qud_cocde and ce06.qce_qutno = qud_qutno and ce06.qce_qutseq = qud_qutseq and ce06.qce_cecde = '06'
left join QUCSTEMT ce07 (nolock) on ce07.qce_cocde = qud_cocde and ce07.qce_qutno = qud_qutno and ce07.qce_qutseq = qud_qutseq and ce07.qce_cecde = '07'
left join QUELCDTL elc09 (nolock) on elc09.qed_qutno = qud_qutno and elc09.qed_qutseq = qud_qutseq and elc09.qed_grpcde = '001' and elc09.qed_cecde = '09' -- ELC Duty
left join QUELC elc (nolock) on elc.qec_cocde = qud_cocde and elc.qec_qutno = qud_qutno and elc.qec_qutseq = qud_qutseq and elc.qec_grpcde = '001' -- ELC
left join QUELC fcc (nolock) on fcc.qec_cocde = qud_cocde and fcc.qec_qutno = qud_qutno and fcc.qec_qutseq = qud_qutseq and fcc.qec_grpcde = '002' -- FCC
left join CUFLGRAT (nolock) on cfr_cusno = @custno and cfr_prctrm = qud_prctrm
left join QUCPTBKD qcb1 (nolock) on qcb1.qcb_cocde = qud_cocde and qcb1.qcb_qutno = qud_qutno and qcb1.qcb_qutseq = qud_qutseq and qcb1.qcb_cptseq = 1
left join QUCPTBKD qcb2 (nolock) on qcb2.qcb_cocde = qud_cocde and qcb2.qcb_qutno = qud_qutno and qcb2.qcb_qutseq = qud_qutseq and qcb2.qcb_cptseq = 2
left join QUCPTBKD qcb3 (nolock) on qcb3.qcb_cocde = qud_cocde and qcb3.qcb_qutno = qud_qutno and qcb3.qcb_qutseq = qud_qutseq and qcb3.qcb_cptseq = 3
left join QUCPTBKD qcb4 (nolock) on qcb4.qcb_cocde = qud_cocde and qcb4.qcb_qutno = qud_qutno and qcb4.qcb_qutseq = qud_qutseq and qcb4.qcb_cptseq = 4
left join QUCPTBKD qcb5 (nolock) on qcb5.qcb_cocde = qud_cocde and qcb5.qcb_qutno = qud_qutno and qcb5.qcb_qutseq = qud_qutseq and qcb5.qcb_cptseq = 5
left join QUCPTBKD qcb6 (nolock) on qcb6.qcb_cocde = qud_cocde and qcb6.qcb_qutno = qud_qutno and qcb6.qcb_qutseq = qud_qutseq and qcb6.qcb_cptseq = 6
where qud_cocde = @cocde
and qud_qutno = @qutno
order by 	qud_qutseq










GO
GRANT EXECUTE ON [dbo].[sp_list_QULDTL_form] TO [ERPUSER] AS [dbo]
GO
