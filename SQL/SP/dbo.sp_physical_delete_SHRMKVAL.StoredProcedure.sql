/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SHRMKVAL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SHRMKVAL]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SHRMKVAL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/***************************************************************************************************************************
History
***************************************************************************************************************************
Modified on		Modified by		Description
***************************************************************************************************************************
7-Aug-2014		Anthony			Create this stored procedure
****************************************************************************************************************************/

/*
*/

CREATE PROCEDURE [dbo].[sp_physical_delete_SHRMKVAL]
--Require parameters
@my_type varchar(2),
@my_module varchar(10),
@my_field nvarchar(40),
@my_field_id int,
@my_pricust varchar(6),
@my_seccust varchar(6)

AS

DECLARE @statement nvarchar(1024)
DECLARE @where_statement varchar(512)
DECLARE @err_message nvarchar(255)


	SET @statement =
		"DELETE FROM SHRMKVAL "
	SET @where_statement = 
		"WHERE [hrt_typ] = '" + @my_type +
		"' AND [hrt_mod] = '" + @my_module + 
		"' AND [hrt_rmkcde] = '" + @my_field + 
		"' AND [hrt_rmkid] = " + CAST(@my_field_id as char(3)) +
		" AND [hrt_pricustno] = '" + @my_pricust +
		"' AND [hrt_seccustno] = '" + @my_seccust +
		"'"


SET @statement = @statement + @where_statement
--PRINT 'STATEMENT:' + @statement
EXEC sp_executesql @statement




GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SHRMKVAL] TO [ERPUSER] AS [dbo]
GO
