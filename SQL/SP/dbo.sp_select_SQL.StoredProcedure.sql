/****** Object:  StoredProcedure [dbo].[sp_select_SQL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SQL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SQL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sp_select_SQL]

@cocde 	nvarchar(6),
@SQL 	nvarchar(3500)

AS	

exec (@sql)






GO
GRANT EXECUTE ON [dbo].[sp_select_SQL] TO [ERPUSER] AS [dbo]
GO
