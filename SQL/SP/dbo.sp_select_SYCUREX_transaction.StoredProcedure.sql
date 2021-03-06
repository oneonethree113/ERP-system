/****** Object:  StoredProcedure [dbo].[sp_select_SYCUREX_transaction]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCUREX_transaction]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCUREX_transaction]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE PROCEDURE [dbo].[sp_select_SYCUREX_transaction]
	@cocde NVARCHAR(6),
	@frmcur NVARCHAR(6),
	@tocur NVARCHAR(6),
	@effdat datetime,
	@dummy nvarchar(1)
AS

Begin

select 
yce_cocde ,
yce_frmcur ,
yce_tocur ,
yce_buyrat ,
yce_selrat ,
yce_effdat ,
yce_iseff ,
yce_creusr ,
yce_credat ,
yce_updusr ,
yce_upddat 
from SYCUREX
where
yce_frmcur = @frmcur
and
yce_tocur = @tocur
and
(
( @effdat = '1900-01-01' and yce_iseff = 'Y' ) or ( yce_effdat = @effdat + ' 00:00:00' )
)

END


GO
GRANT EXECUTE ON [dbo].[sp_select_SYCUREX_transaction] TO [ERPUSER] AS [dbo]
GO
