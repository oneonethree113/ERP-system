/****** Object:  StoredProcedure [dbo].[sp_physical_delete_ZSCUPDAPPRV]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_ZSCUPDAPPRV]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_ZSCUPDAPPRV]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_physical_delete_ZSCUPDAPPRV] 
@zsa_cocde 		nvarchar(6)
AS
begin

Delete from ZSCUPDAPPRV


end


GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_ZSCUPDAPPRV] TO [ERPUSER] AS [dbo]
GO
