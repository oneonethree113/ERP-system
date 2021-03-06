/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUPDTLPVH]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMRKUPDTLPVH]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUPDTLPVH]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*  
=========================================================  
Program ID :   sp_select_IMMRKUPDTLPV
Description    :   
Programmer   :   Mark Lau
Create Date    :   
Last Modified   : 
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================       
*/  
   

CREATE procedure [dbo].[sp_select_IMMRKUPDTLPVH]  
@imp_cocde	nvarchar(6), 
@imp_itmno	nvarchar(20) 

 
AS  
  
begin  
  
  
 Select   
' ' as 'imp_del',           
imp_cocde,
imp_itmno,
imp_venno,
imp_pckseq,
imp_untcde,
imp_inrqty,
imp_mtrqty,
imp_cus1no,
imp_cus2no,
imp_conftr,
imp_prdven,
vbi_vensna,
imp_ventyp,
imp_curcde,
isnull(imp_calftyprc,0) as 'imp_calftyprc',
isnull(imp_negprc,0) as 'imp_negprc',
isnull(imp_ftybomcst,0) as 'imp_ftybomcst',
round(case when isnull(imp_negprc,0) <> 0 then isnull(imp_negprc,0) else isnull(imp_calftyprc,0) end + isnull(imp_ftybomcst,0) ,2) as ' imp_ftyprc',
imp_creusr,
imp_updusr
--imp_credat,
--imp_upddat,
--imp_timstp,
--' ' as 'imp_editflg'
from 
IMMRKUPDTLPVH
left join vnbasinf on vbi_venno = imp_prdven
where  
imp_itmno = @imp_itmno

order by imp_itmno

end


GO
GRANT EXECUTE ON [dbo].[sp_select_IMMRKUPDTLPVH] TO [ERPUSER] AS [dbo]
GO
