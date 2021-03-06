/****** Object:  StoredProcedure [dbo].[sp_list_VTADTL_form]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VTADTL_form]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VTADTL_form]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE  PROCEDURE [dbo].[sp_list_VTADTL_form] 

@cocde	nvarchar(6),
@qutno	nvarchar(20)

AS

--select * from quotndtl where qud_qutno = 'gq0800116'
 







select
qud_qutno,	-- quotion number
qud_qutseq,	-- quotion sequence
'90' as 'vta_cms_setodr', --CMS Due-Set Order
'90' as 'vta_cms_newstore', --CMS Due-New Store
'90' as 'vta_cms_adodr', --CMS Due-Ad Order
'75' as 'vta_cms_rpnodr', --CMS Due-Replen Order
'75' as 'vta_cms_chodr', --CMS Due-Chase Order
'' as 'vta_cms_created', --CMS Created
'75' as 'vta_po_setodr', --PO Due-Set Order
'75' as 'vta_po_newstore', --PO Due-New Store
'75' as 'vta_po_adodr', --PO Due-Ad Order
'60' as 'vta_po_rpnodr', --PO Due-Replen Order
'60' as 'vta_po_chodr', --PO Due-Chase Order
'' as 'vta_po_written', --PO Written
'75' as 'vta_mold_setodr', --Molding-Set Order
'75' as 'vta_mold_newstore', --Molding-New Store
'75' as 'vta_mold_adodr', --Molding-Ad Order
'55' as 'vta_mold_rpnodr', --Molding-Replen Order
'55' as 'vta_mold_chodr', --Molding-Chase Order
'70' as 'vta_rm_setodr', --Raw Materials Procured-Set Order
'70' as 'vta_rm_newstore', --Raw Materials Procured-New Store
'70' as 'vta_rm_adodr', --Raw Materials Procured-Ad Order
'55' as 'vta_rm_rpnodr', --Raw Materials Procured-Replen Order
'55' as 'vta_rm_chodr', --Raw Materials Procured-Chase Order
'60' as 'vta_prdbeg_setodr', --Production Begins-Set Order
'60' as 'vta_prdbeg_newstore', --Production Begins-New Store
'60' as 'vta_prdbeg_adodr', --Production Begins-Ad Order
'45' as 'vta_prdbeg_rpnodr', --Production Begins-Replen Order
'45' as 'vta_prdbeg_chodr', --Production Begins-Chase Order
'30' as 'vta_fin_setodr', --Finishing-Set Order
'30' as 'vta_fin_newstore', --Finishing-New Store
'30' as 'vta_fin_adodr', --Finishing-Ad Order
'30' as 'vta_fin_rpnodr', --Finishing-Replen Order
'30' as 'vta_fin_chodr', --Finishing-Chase Order
'30' as 'vta_pkg_setodr', --Packaging-Set Order
'30' as 'vta_pkg_newstore', --Packaging-New Store
'30' as 'vta_pkg_adodr', --Packaging-Ad Order
'30' as 'vta_pkg_rpnodr', --Packaging-Replen Order
'30' as 'vta_pkg_chodr', --Packaging-Chase Order
'5' as 'vta_trs_setodr', --Transit-Set Order
'5' as 'vta_trs_newstore', --Transit-New Store
'5' as 'vta_trs_adodr', --Transit-Ad Order
'5' as 'vta_trs_rpnodr', --Transit-Replen Order
'5' as 'vta_trs_chodr' --Transit-Chase Order


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
GRANT EXECUTE ON [dbo].[sp_list_VTADTL_form] TO [ERPUSER] AS [dbo]
GO
