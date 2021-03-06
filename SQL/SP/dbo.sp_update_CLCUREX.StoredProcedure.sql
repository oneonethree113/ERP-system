/****** Object:  StoredProcedure [dbo].[sp_update_CLCUREX]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CLCUREX]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CLCUREX]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









create  PROCEDURE [dbo].[sp_update_CLCUREX]
@cce_cocde NVARCHAR(6),
@cce_frmcur	nvarchar(6),
@cce_tocur nvarchar(6),
@cce_buyrat numeric(16,11),
@cce_selrat numeric(16,11),
@cce_effdat datetime,
@cce_iseff nvarchar(1),
@cce_display nvarchar(1),
@cce_tor numeric(16,11),
@cce_updusr nvarchar(30)
AS

Begin
/*
update CLCUREX
set 
cce_iseff = 'N',
cce_updusr = @cce_updusr ,
cce_upddat = getdate()
where
cce_frmcur = @cce_frmcur and
cce_tocur = @cce_tocur
*/

update CLCUREX
set 
cce_buyrat = @cce_buyrat,
cce_selrat = @cce_selrat,
cce_iseff = @cce_iseff,
cce_tor = @cce_tor,
cce_updusr = @cce_updusr ,
cce_upddat = getdate()
where
cce_frmcur = @cce_frmcur and
cce_tocur = @cce_tocur and
cce_effdat = @cce_effdat

END





GO
GRANT EXECUTE ON [dbo].[sp_update_CLCUREX] TO [ERPUSER] AS [dbo]
GO
