/****** Object:  StoredProcedure [dbo].[sp_update_SYCUREX_ACC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYCUREX_ACC]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYCUREX_ACC]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







create PROCEDURE [dbo].[sp_update_SYCUREX_ACC]
@yce_cocde NVARCHAR(6),
@yce_frmcur	nvarchar(6),
@yce_tocur nvarchar(6),
@yce_buyrat numeric(16,11),
@yce_selrat numeric(16,11),
@yce_effdat datetime,
@yce_expdat datetime,
@yce_iseff nvarchar(1),
@yce_display nvarchar(1),
@yce_updusr nvarchar(30)
AS

Begin
/*
update SYCUREX_ACC
set 
yce_iseff = 'N',
yce_updusr = @yce_updusr ,
yce_upddat = getdate()
where
yce_frmcur = @yce_frmcur and
yce_tocur = @yce_tocur
*/

update SYCUREX_ACC
set 
yce_buyrat = @yce_buyrat,
yce_selrat = @yce_selrat,
yce_iseff = @yce_iseff,
yce_updusr = @yce_updusr ,
yce_upddat = getdate()
where
yce_frmcur = @yce_frmcur and
yce_tocur = @yce_tocur and
yce_effdat = @yce_effdat and
yce_expdat = @yce_expdat
END



GO
GRANT EXECUTE ON [dbo].[sp_update_SYCUREX_ACC] TO [ERPUSER] AS [dbo]
GO
