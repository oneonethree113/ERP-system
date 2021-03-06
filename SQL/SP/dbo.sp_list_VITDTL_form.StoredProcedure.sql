/****** Object:  StoredProcedure [dbo].[sp_list_VITDTL_form]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VITDTL_form]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VITDTL_form]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








CREATE  PROCEDURE [dbo].[sp_list_VITDTL_form] 

@cocde	nvarchar(6),
@qutno	nvarchar(20)


AS


select
'' as 'vit_cat',
qud_itmno as 'vit_itmno',
qud_qutseq as 'vit_seq',
qud_itmdsc as 'vit_itm',
'' as 'vit_dpci', -- If exist dpci then dpci (styno) else styno
'' as 'vit_subcat',
quh_Year + ' ' + quh_Season + ' '+ quh_Desc as 'vit_program',
'' as 'vit_storecount',
'' as 'vit_spspw',
'' as 'vit_ttlunt', 
case qud_cus2dp when 0 then qud_cus1dp else qud_cus2dp end as 'vit_fobimuntcst',
'' as 'vit_domuntcst',
'' as 'vit_retcat',
qud_cususd as 'vit_untretail',
qud_mtrqty as 'vit_mstcasepck',
qud_inrqty as 'vit_inrcasepck',
qud_mtrdin as 'vit_length',
qud_mtrwin as 'vit_width',
qud_mtrhin as 'vit_height',
qud_grswgt as 'vit_weight',
'' as 'vit_port',
'' as 'vit_imfobpoint',
'' as 'vit_domfobpoint',
'' as 'vit_setdat',
'' as 'vit_tgtbrand',
isnull(qed_percent,0) as 'vit_dutyrat',
isnull(qed_amt,0) as 'vit_spduty',
yco_shtnam as 'vit_shtnam',	--Vendor Name
yco_venid as 'vit_venid',		--Vendor #
'' as vit_priftynam	-- Primary factory name



from QUOTNDTL (nolock)
left join QUOTNHDR (nolock) on quh_cocde = qud_cocde and quh_qutno = qud_qutno
left join SYCOMINF (nolock) on yco_cocde = qud_cocde
left join VNBASINF (nolock) on vbi_venno = qud_venno
left join SYSETINF sys03 (nolock) on sys03.ysi_cde = qud_prctrm and ysi_typ = '03'
left join QUELCDTL (nolock) on qed_qutno = qud_qutno and qed_qutseq = qud_qutseq and qed_grpcde = '001' and qed_cecde = '09' -- ELC Duty
left join QUELC (nolock) on qec_qutno = qud_qutno and qec_qutseq = qud_qutseq and qec_grpcde = '002' -- FCA
where qud_cocde = @cocde
and qud_qutno = @qutno
order by qud_qutseq












GO
GRANT EXECUTE ON [dbo].[sp_list_VITDTL_form] TO [ERPUSER] AS [dbo]
GO
