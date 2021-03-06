/****** Object:  StoredProcedure [dbo].[sp_select_QCRPTCDE_QCApp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCRPTCDE_QCApp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCRPTCDE_QCApp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_select_QCRPTCDE_QCApp]

AS

BEGIN

SELECT
 qrc_inspcde inspcde
,qrc_cdedsc cdedsc
,qrc_cdetyp cdetype
,qrc_flgimg flgimg
,qrc_flgdisp flgdisp
,qrc_page page
,qrc_categ categ
,qrc_displayorder displayorder
,qrc_resultName resultName
,qrc_resultNameEng resultNameEng
,qrc_resultOptEng resultOptEng
,qrc_resultOpt resultOpt
,qrc_detailName detailName
,qrc_creusr creusr
,qrc_updusr updusr
,convert(char, qrc_credat,120) credat
,convert(char, qrc_upddat,120) upddat
FROM	qcrptcde 

END

SET QUOTED_IDENTIFIER OFF 

GO
GRANT EXECUTE ON [dbo].[sp_select_QCRPTCDE_QCApp] TO [ERPUSER] AS [dbo]
GO
