/****** Object:  StoredProcedure [dbo].[sp_select_SYVENFML_Grp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYVENFML_Grp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYVENFML_Grp]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO









/*'************************************
     S A M U E L

*/
CREATE PROCEDURE [dbo].[sp_select_SYVENFML_Grp]

@yvf_cocde	nvarchar(6) = ' ',
@yvf_venno	nvarchar(6)

AS

begin
Select 
distinct 
yvf_effdat

from SYVENFML
--left join SYFMLINF a on a.yfi_cocde = @yvf_cocde and a.yfi_fmlopt = yvf_fmlopt
left join SYFMLINF a on a.yfi_fmlopt = yvf_fmlopt

where 
--yvf_cocde = @yvf_cocde and 
yvf_cocde = ' ' and 
yvf_venno = @yvf_venno
--yfi_cocde = @yvf_cocde and


order by yvf_effdat

end









GO
GRANT EXECUTE ON [dbo].[sp_select_SYVENFML_Grp] TO [ERPUSER] AS [dbo]
GO
