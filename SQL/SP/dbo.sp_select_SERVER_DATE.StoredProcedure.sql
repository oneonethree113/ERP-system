/****** Object:  StoredProcedure [dbo].[sp_select_SERVER_DATE]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SERVER_DATE]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SERVER_DATE]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_select_SERVER_DATE]

@cocde as nvarchar(6),
@usrid as nvarchar(30)

as

select getdate() as 'SERVER_DATE'



GO
GRANT EXECUTE ON [dbo].[sp_select_SERVER_DATE] TO [ERPUSER] AS [dbo]
GO
