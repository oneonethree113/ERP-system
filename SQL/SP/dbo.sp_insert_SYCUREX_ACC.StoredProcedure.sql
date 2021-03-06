/****** Object:  StoredProcedure [dbo].[sp_insert_SYCUREX_ACC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYCUREX_ACC]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYCUREX_ACC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







create PROCEDURE [dbo].[sp_insert_SYCUREX_ACC]
@yce_cocde NVARCHAR(6),
@yce_frmcur	nvarchar(6),
@yce_tocur nvarchar(6),
@yce_buyrat numeric(16,11),
@yce_selrat numeric(16,11),
@yce_effdat datetime,
@yce_expdat datetime, 
@yce_iseff nvarchar(1),
@yce_display nvarchar(1),
@yce_creusr nvarchar(30)
AS

Begin

if ( @yce_iseff = 'Y' )
begin
	update SYCUREX_ACC
	set yce_iseff = 'N',
	yce_updusr = @yce_creusr ,
	yce_upddat = getdate()
	where yce_frmcur = @yce_frmcur and yce_tocur = @yce_tocur
end 
insert into SYCUREX_ACC (yce_cocde,yce_frmcur,yce_tocur,yce_buyrat,yce_selrat,yce_effdat,yce_expdat,yce_iseff,yce_creusr,yce_credat,yce_updusr,yce_upddat,yce_display)
values
('',@yce_frmcur,@yce_tocur,@yce_buyrat,@yce_selrat,@yce_effdat,@yce_expdat,@yce_iseff,@yce_creusr,getdate(),@yce_creusr,getdate(),@yce_display)

END



GO
GRANT EXECUTE ON [dbo].[sp_insert_SYCUREX_ACC] TO [ERPUSER] AS [dbo]
GO
