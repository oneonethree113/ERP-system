/****** Object:  StoredProcedure [dbo].[sp_select_POJBBSAP_UPD_Pending]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POJBBSAP_UPD_Pending]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POJBBSAP_UPD_Pending]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

















-- sp_select_POJBBSAP_UPD_Pending 'UCPP' 
      
CREATE procedure [dbo].[sp_select_POJBBSAP_UPD_Pending]      
@cocde varchar(6)      
as      
begin      



select 
pod.pod_scno,        
pod.pod_jobord,        
pod.pod_runno,        
pod.pod_itmno,        
vbi_vensna,        
'Y' as 'pjd_confrm',        
'' as 'pjd_batseq',        
'new' as 'pjd_recsts',        
vbi_venno as vencde  ,       
pjd_zutyp as 'zutype',
pjd_upd_rea as 'reason'
from 
POJBBDTL as p (nolock) 
left join POORDDTL as pod (nolock) on pod.pod_jobord = pjd_jobord  
left join VNBASINF  (nolock) on pod_prdven = vbi_venno
where
substring(pjd_batno,1,2) in (select ydc_prefix from sydocctl where ydc_doctyp = 'ZJ')
and pjd_creusr = 'MISBJ' 
and isnull(pjd_zutyp,'') <> ''
and pjd_jobord in
(
select pjd_jobord from POJBBDTL(nolock) 
where 
substring(pjd_batno,1,2) in (select ydc_prefix from sydocctl where ydc_doctyp = 'ZJ')
and pjd_creusr = 'MISBJ' 
and isnull(pjd_zutyp,'') <> ''
)
and pjd_credat =
( 
select max(pjd_credat) from POJBBDTL(nolock) 
where
substring(pjd_batno,1,2) in (select ydc_prefix from sydocctl where ydc_doctyp = 'ZJ')
and pjd_creusr = 'MISBJ' 
and isnull(pjd_zutyp,'') <> ''
and pjd_jobord = p.pjd_jobord
)
and pjd_jobord in
(
select distinct zsa_jobord from ZSCUPDAPPRV  where zsa_FLGHKUPDREQ = 'Y' and ( zsa_FLGYWAPPRV = 'N' or zsa_FLGSCAPPRV = 'N' ) 
)
and pod.pod_cocde = @cocde
  ORDER BY        
   pod.pod_jobord   
 
 END      
      
      
 
      



GO
GRANT EXECUTE ON [dbo].[sp_select_POJBBSAP_UPD_Pending] TO [ERPUSER] AS [dbo]
GO
