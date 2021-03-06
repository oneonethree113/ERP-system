/****** Object:  StoredProcedure [dbo].[sp_select_qcrptgnl]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qcrptgnl]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qcrptgnl]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_select_qcrptgnl] 
@TmpRPTNo as nvarchar(30)

AS
begin

SELECT  qrc_page, 
	qrc_categ , 
	qrc_resultName, 	
	case CHARINDEX('complete', qrc_resultOptEng)   		  
		WHEN 0 THEN qrc_resultOptEng			  
		else '全;不全'			  
	END as 'qrc_resultOptEng',
	case CHARINDEX('complete', qrg_result)   	
	WHEN 0 
		THEN  qrg_result 
		else	Replace(Replace(qrg_result,'complete','全') ,'Incomplete','不全')	
	END as 'qrg_result',
	qrc_cdetyp, 
	qrg_detail, 
	case qrc_displayorder
	when 1 
	then 100 
	else qrc_displayorder end 
	as 'qrc_displayorder' 
from qcrptgnl LEFT JOIN
	qcrptcde 
	on qrg_inspcde= qrc_inspcde 
where qrg_tmprptno =@TmpRPTNo
	AND (qrc_page = 3 OR qrc_page= 4 ) 
order by qrc_page, 
	qrc_categ, 
	case qrc_displayorder 
		when 1 
		then 100 
	else qrc_displayorder 
end
END






GO
GRANT EXECUTE ON [dbo].[sp_select_qcrptgnl] TO [ERPUSER] AS [dbo]
GO
