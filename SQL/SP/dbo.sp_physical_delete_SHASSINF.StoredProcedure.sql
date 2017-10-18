/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SHASSINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SHASSINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SHASSINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE  procedure [dbo].[sp_physical_delete_SHASSINF]
@ordno	varchar(20),
@ordseq	int

as

delete from SHASSINF
where	
	hai_shpno = @ordno and
	hai_shpseq = @ordseq 




GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SHASSINF] TO [ERPUSER] AS [dbo]
GO
