/****** Object:  StoredProcedure [dbo].[sp_update_SHRMKVAL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SHRMKVAL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SHRMKVAL]    Script Date: 09/29/2017 11:53:54 ******/
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

CREATE PROCEDURE [dbo].[sp_update_SHRMKVAL]
--Require parameters
@my_type varchar(2),
@my_module varchar(10),
@my_field nvarchar(40),
@my_field_id int,
@my_field_value nvarchar(2000),
@my_field_desc nvarchar(100),
@my_default char(1),
@my_pricust varchar(6),
@my_seccust varchar(6),
@insert_usr nvarchar(30)

AS

DECLARE @statement nvarchar(4000)
DECLARE @where_statement varchar(512)
DECLARE @err_message nvarchar(255)

	SET @statement =
		"UPDATE SHRMKVAL SET" +
		" [hrt_rmkval] = '" + REPLACE(@my_field_value,'''','''''') +
		"', [hrt_rmkdsc] = '" + REPLACE(@my_field_desc,'''','''''') +
		"', [hrt_flgdef] = '" + @my_default +
		"', [hrt_updusr] = '" + @insert_usr +
		"', [hrt_upddat]= '" + convert(varchar(19), getdate(),20) +
		"'"
	SET @where_statement = 
		" WHERE [hrt_typ] = '" + @my_type +
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
GRANT EXECUTE ON [dbo].[sp_update_SHRMKVAL] TO [ERPUSER] AS [dbo]
GO
