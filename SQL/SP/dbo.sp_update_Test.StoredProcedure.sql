/****** Object:  StoredProcedure [dbo].[sp_update_Test]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_Test]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_Test]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sp_update_Test] 

@cocde nvarchar(6)

AS

update vnbasinf
set vbi_venrat = 'W'






GO
GRANT EXECUTE ON [dbo].[sp_update_Test] TO [ERPUSER] AS [dbo]
GO
