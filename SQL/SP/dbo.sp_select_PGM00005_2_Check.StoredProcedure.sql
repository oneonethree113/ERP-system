/****** Object:  StoredProcedure [dbo].[sp_select_PGM00005_2_Check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PGM00005_2_Check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PGM00005_2_Check]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







------------------------------------------------- 
CREATE PROCEDURE [dbo].[sp_select_PGM00005_2_Check] 

@cocde  	nvarchar(6),
@from	  	nvarchar(20),
@to		nvarchar(20)

AS


select 
prd_reqno as 'pod_ordno',
prd_seq as 'pod_seq',
prd_itemno as 'pod_itemno',
prd_assitm as 'pod_assitm',
prd_pckunt + '/' + convert(varchar(10), prd_inrqty) + '/' + convert(varchar(10), prd_mtrqty) + '/' + prd_ftyprctrm + '/'+prd_hkprctrm + '/' + prd_trantrm as 'pod_packing',
prd_pkgitm as 'pod_pkgitm',
prd_pkgven as 'pod_pkgven',
vbi_vensna,
'Y' as 'pjd_confrm',
prd_ordno as 'R_pod_ordno',
prd_ordseq as 'R_pod_ordseq',
'' as 'pjd_batseq',
'new' as 'pjd_recsts',
'' as 'vencde',
prd_ttlordqty as 'pod_ttlordqty' ,
prd_untprc as 'pod_untprc',
prd_cate as 'pod_cate'

from PKREQDTL (nolock)
left join VNBASINF (nolock) on vbi_venno = prd_pkgven
left join PKREQHDR (nolock) on prd_reqno = prh_reqno
left join PKORDDTL (nolock) on pod_ordno = prd_ordno and pod_seq = prd_ordseq
where prd_cocde = @cocde and prd_reqno between @from and @to
--and prh_status = 'REL' and  (pod_status in ('OPE','APV','REL') or pod_status is null)
order by prd_seq








GO
GRANT EXECUTE ON [dbo].[sp_select_PGM00005_2_Check] TO [ERPUSER] AS [dbo]
GO
