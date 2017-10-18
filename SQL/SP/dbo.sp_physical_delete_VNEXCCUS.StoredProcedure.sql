/****** Object:  StoredProcedure [dbo].[sp_physical_delete_VNEXCCUS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_VNEXCCUS]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_VNEXCCUS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 28/07/2003


CREATE PROCEDURE [dbo].[sp_physical_delete_VNEXCCUS] 

@vec_cocde 	nvarchar(6),
@vec_venno 	nvarchar(6),
@vec_cusno 	nvarchar(6)

AS

delete from VNEXCCUS
where 	
	--vci_cocde 	= @vci_cocde and
	vec_venno 	= @vec_venno
and 	vec_cusno	= @vec_cusno










GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_VNEXCCUS] TO [ERPUSER] AS [dbo]
GO
