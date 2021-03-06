/****** Object:  StoredProcedure [dbo].[create_all_audit_table_for_all_table]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[create_all_audit_table_for_all_table]
GO
/****** Object:  StoredProcedure [dbo].[create_all_audit_table_for_all_table]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[create_all_audit_table_for_all_table]
AS
SET NOCOUNT ON
DECLARE @table_name nvarchar(20)
DECLARE table_cursor CURSOR
    FOR SELECT name
 FROM sysobjects
 WHERE type = 'U' and name <> 'dtproperties'
 AND RIGHT(name,3) <> 'AUD'
 ORDER BY name
OPEN table_cursor
FETCH NEXT FROM table_cursor INTO @table_name
WHILE @@FETCH_STATUS = 0
BEGIN
 EXEC autogen_audit_table_for_a_table_1 @table_name
 FETCH NEXT FROM table_cursor INTO @table_name
END
CLOSE table_cursor
DEALLOCATE table_cursor
SET NOCOUNT OFF






GO
GRANT EXECUTE ON [dbo].[create_all_audit_table_for_all_table] TO [ERPUSER] AS [dbo]
GO
