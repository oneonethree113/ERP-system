/****** Object:  StoredProcedure [dbo].[sp_insert_SHRMKVAL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SHRMKVAL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SHRMKVAL]    Script Date: 09/29/2017 11:53:53 ******/
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

CREATE PROCEDURE [dbo].[sp_insert_SHRMKVAL]
--Requrire parameters
@my_type varchar(2),
@my_module varchar(10),
@my_field nvarchar(40),
@my_field_id int,
@my_field_value nvarchar(2000),
@my_field_desc nvarchar(100),
@my_default char(1),
@my_pricust varchar(6),
@my_seccustno varchar(6),
@insert_usr nvarchar(30)

AS

DECLARE @statement nvarchar(4000)
DECLARE @where_statement varchar(512)
DECLARE @err_message nvarchar(255)

SET @statement = 
	"insert INTO SHRMKVAL VALUES ('" +
	@my_type + "','" +
	@my_module + "','" +
	@my_field + "'," +
	CAST(@my_field_id as char(3)) + ",'" +
	REPLACE(@my_field_value,'''','''''') + "','" +
	REPLACE(@my_field_desc,'''','''''') + "','" +
	@my_default + "','" +
	@my_pricust + "','" +
	@my_seccustno + "','" +
	@insert_usr + "','" +
	@insert_usr + "','" +
	convert(varchar(19), getdate(),20) + "','" +
	convert(varchar(19), getdate(),20) + "')"

EXEC sp_executesql @statement
	





GO
GRANT EXECUTE ON [dbo].[sp_insert_SHRMKVAL] TO [ERPUSER] AS [dbo]
GO
