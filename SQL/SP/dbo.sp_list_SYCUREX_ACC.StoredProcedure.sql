/****** Object:  StoredProcedure [dbo].[sp_list_SYCUREX_ACC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYCUREX_ACC]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYCUREX_ACC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









create PROCEDURE [dbo].[sp_list_SYCUREX_ACC]
	@cocde NVARCHAR(6),
	@effdat datetime
AS

Begin


declare @effdat_real datetime

select @effdat_real = max(yce_effdat) from SYCUREX_ACC

if (select count(*) from SYCUREX_ACC where yce_effdat = @effdat + ' 00:00:00') = 0 
begin
	set @effdat = @effdat_real
end


select 
yce_cocde ,
yce_frmcur ,
yce_tocur ,
yce_buyrat ,
yce_selrat ,
yce_effdat ,
yce_expdat,
yce_iseff ,
yce_creusr ,
yce_credat ,
yce_updusr ,
yce_upddat 
from SYCUREX_ACC
where
(
( @effdat = '1900-01-01' and yce_iseff = 'Y' ) or ( yce_effdat = @effdat + ' 00:00:00' )
)

END




GO
GRANT EXECUTE ON [dbo].[sp_list_SYCUREX_ACC] TO [ERPUSER] AS [dbo]
GO
