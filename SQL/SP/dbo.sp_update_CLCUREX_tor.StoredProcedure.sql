/****** Object:  StoredProcedure [dbo].[sp_update_CLCUREX_tor]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CLCUREX_tor]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CLCUREX_tor]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









create  PROCEDURE [dbo].[sp_update_CLCUREX_tor]
@cce_tor numeric(16,11),
@cce_updusr nvarchar(30)
AS

Begin

update CLCUREX
set 
cce_tor =@cce_tor,
cce_updusr = @cce_updusr ,
cce_upddat = getdate()

END





GO
GRANT EXECUTE ON [dbo].[sp_update_CLCUREX_tor] TO [ERPUSER] AS [dbo]
GO
