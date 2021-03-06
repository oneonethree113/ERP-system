/****** Object:  StoredProcedure [dbo].[sp_select_SYCUREX]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCUREX]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCUREX]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[sp_select_SYCUREX]
	@cocde NVARCHAR(6),
	@frmcur	nvarchar(6),
	@geteffdat nvarchar(1)
AS

Begin

if ( @geteffdat = 'N' )
begin
select 
yce_cocde as 'DEL',
yce_cocde,
yce_frmcur,
yce_tocur,
yce_buyrat,
yce_selrat,
yce_effdat,
yce_iseff,
yce_creusr,
convert(nvarchar(10),yce_credat) as 'yce_credat',
yce_updusr ,
yce_upddat ,
yce_display

from SYCUREX
--where yce_display = 'Y'
order by yce_frmcur,yce_tocur asc
end

else if ( @geteffdat = 'Y' )

begin
select
distinct
yce_effdat,
yce_iseff
from SYCUREX
--where yce_display = 'Y'
order by yce_iseff desc, yce_effdat desc
end 

END


GO
GRANT EXECUTE ON [dbo].[sp_select_SYCUREX] TO [ERPUSER] AS [dbo]
GO
