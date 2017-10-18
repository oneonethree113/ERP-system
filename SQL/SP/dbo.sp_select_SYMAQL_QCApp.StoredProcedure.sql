/****** Object:  StoredProcedure [dbo].[sp_select_SYMAQL_QCApp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYMAQL_QCApp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYMAQL_QCApp]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_select_SYMAQL_QCApp]

AS

BEGIN

SELECT
 yal_cocde
,yal_lotfm
,yal_lotto
,yal_sample
,yal_aql15
,yal_aql25
,yal_creusr
,yal_updusr
,convert(char, yal_credat,120) yal_credat
,convert(char, yal_upddat,120) yal_upddat
FROM	SYMAQL 

END

SET QUOTED_IDENTIFIER OFF 

GO
GRANT EXECUTE ON [dbo].[sp_select_SYMAQL_QCApp] TO [ERPUSER] AS [dbo]
GO
