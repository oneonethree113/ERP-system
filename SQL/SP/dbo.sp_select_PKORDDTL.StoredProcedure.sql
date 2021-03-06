/****** Object:  StoredProcedure [dbo].[sp_select_PKORDDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[sp_select_PKORDDTL]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

	 
select 
pod_cocde, pod_ordno, pod_seq, pod_status, pod_itemno, 
pod_tmpitmno, pod_venno, pod_venitm, pod_pckunt, pod_inrqty,
 pod_mtrqty, pod_cft, pod_ftyprctrm, pod_hkprctrm, pod_trantrm,
 pod_pkgitm, pod_pkgven + ' - ' +  ven.vbi_vensna as 'pod_pkgven' , pod_cate+ ' - ' + ypc_pakna as 'pod_cate', pod_chndsc, pod_engdsc, 
pod_remark, pod_EInchL, pod_EInchW, pod_EInchH, pod_EcmL,
 pod_EcmW, pod_EcmH, pod_FInchL, pod_FinchW, pod_FinchH,
 pod_FcmL, pod_FcmW, pod_FcmH, pod_matral, pod_tiknes, 
pod_prtmtd, pod_clrfot, pod_clrbck, pod_finish, pod_matDsc,pod_tikDsc,pod_prtDsc, pod_rmtnce,
 pod_addres, pod_state, pod_cntry, pod_zip, pod_Tel, pod_cntper,
 pod_sctoqty, pod_qtyum, pod_curcde, pod_multip, pod_ordqty, pod_stkqty,
pod_wasper, pod_wasqty, pod_ttlordqty, 
cast(pod_untprc as numeric(13,5)) as 'pod_untprc' , 
cast(pod_ttlamtqty as numeric(13,2)) as 'pod_ttlamtqty' 
, pod_receqty, pod_Reqno, pod_Reqseq, pod_Conmak, pod_creusr, pod_updusr,
 pod_credat, pod_upddat,  cast(pod_timstp as int) as pod_timstp ,
pod_bonqty , pod_shpstr , pod_shpend , 
case pod_fty when '' then '' else isnull(fty.vbi_vensna,'')  + ' - ' + pod_fty  end as 'pod_fty',
isnull(pod_addres_fty,'') as pod_addres_fty,
isnull(pod_state_fty,'') as pod_state_fty,
isnull(pod_cntry_fty,'') as pod_cntry_fty,
isnull(pod_zip_fty,'') as pod_zip_fty,
isnull(pod_cntper_fty,'') as pod_cntper_fty,
isnull(pod_Tel_fty,'') as pod_Tel_fty,
pod_InWas,pod_MOA

from PKORDDTL
left join vnbasinf fty (nolock)  on   pod_fty = fty.vbi_venno
left join vnbasinf ven (nolock)  on pod_pkgven = ven.vbi_venno
 left join SYPAKCAT (nolock) on pod_cate = ypc_code
where pod_cocde = @code and pod_ordno =  @ordno

end





 














GO
GRANT EXECUTE ON [dbo].[sp_select_PKORDDTL] TO [ERPUSER] AS [dbo]
GO
