/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PKREPORD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_PKREPORD]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PKREPORD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_physical_delete_PKREPORD] 
--------------------------------------------------------------------------------------------------------------------------------------

@pro_cocde nvarchar(20),
@pro_ordno nvarchar(20),
@pro_repord nvarchar(20)
--------------------------------------------------------------------------------------------------------------------------------------
AS

begin

Delete PKREPORD
where pro_cocde = @pro_cocde and 
	pro_ordno = @pro_ordno and 
	pro_repord = @pro_repord
	

end



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_PKREPORD] TO [ERPUSER] AS [dbo]
GO
