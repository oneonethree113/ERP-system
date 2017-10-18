/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CLCUREX]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CLCUREX]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CLCUREX]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









create  PROCEDURE [dbo].[sp_physical_delete_CLCUREX]
@cce_cocde NVARCHAR(6),
@cce_frmcur	nvarchar(6),
@cce_tocur nvarchar(6),
@cce_effdat datetime,
@cce_updusr nvarchar(30)
AS

Begin

delete CLCUREX
where
cce_frmcur = @cce_frmcur and
cce_tocur = @cce_tocur and
cce_effdat = @cce_effdat

END





GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CLCUREX] TO [ERPUSER] AS [dbo]
GO
