/****** Object:  StoredProcedure [dbo].[sp_select_IMCALFML]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMCALFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMCALFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMCALFML]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@icf_cocde nvarchar(6),
@icf_typ nvarchar(20) 
                                               
---------------------------------------------- 
 
AS
begin

--if @icf_typ = 'ALL' 
--begin

select 
icf_cocde,
icf_vencde,
icf_cus1no,
icf_cus2no,
icf_prdlne,
icf_catlvl4,
icf_caltar,
icf_fml_fty,
icf_fml_hk,
fmlhk.yfi_fml as 'icf_fml_hk_dsc',
icf_def,
icf_effdat,
icf_expdat,
icf_creusr,
icf_updusr,
icf_credat,
icf_upddat
from IMCALFML (nolock)
left join SYFMLINF fmlhk (nolock) on yfi_fmlopt = icf_fml_hk

--end



end



GO
GRANT EXECUTE ON [dbo].[sp_select_IMCALFML] TO [ERPUSER] AS [dbo]
GO
