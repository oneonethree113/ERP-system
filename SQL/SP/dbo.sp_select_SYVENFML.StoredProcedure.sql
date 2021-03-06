/****** Object:  StoredProcedure [dbo].[sp_select_SYVENFML]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYVENFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYVENFML]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






-- Checked by Allan Yuen at 28/07/2003

/*'************************************
     S A M U E L

*/
CREATE PROCEDURE [dbo].[sp_select_SYVENFML]

@yvf_cocde	nvarchar(6) = ' ',
@yvf_venno	nvarchar(6),
-- Added by Mark Lau 20090204
@yvf_catcde	nvarchar(20),
@yvf_matcde	nvarchar(6)
AS

begin
Select 
yvf_creusr as 'yvf_status',
yvf_cocde,
yvf_venno,
yvf_fmlopt,
yfi_prcfml,
yfi_fml,
yvf_def,
yvf_effdat,
yvf_creusr,
yvf_updusr,
yvf_credat,
yvf_upddat,
cast(yvf_timstp as int) as yvf_timstp,
-- Added by Mark Lau 20090204
yvf_catcde,
yvf_matcde


from SYVENFML
--left join SYFMLINF a on a.yfi_cocde = @yvf_cocde and a.yfi_fmlopt = yvf_fmlopt
left join SYFMLINF a on a.yfi_fmlopt = yvf_fmlopt

where 
--yvf_cocde = @yvf_cocde and 
yvf_cocde = ' ' and 
yvf_venno = @yvf_venno and
--yfi_cocde = @yvf_cocde and
-- Added by Mark Lau 20090204
--yvf_catcde = @yvf_catcde and
yvf_matcde = @yvf_matcde

order by yvf_venno

end


GO
GRANT EXECUTE ON [dbo].[sp_select_SYVENFML] TO [ERPUSER] AS [dbo]
GO
