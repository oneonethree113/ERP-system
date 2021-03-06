/****** Object:  StoredProcedure [dbo].[sp_physical_delete_quelc]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_quelc]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_quelc]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/************************************************************************
Author:		Lester Wu
Date:		28th September, 2008
Description:	Delete data from QUELC
***********************************************************************
*/



CREATE PROCEDURE [dbo].[sp_physical_delete_quelc] 

@qec_cocde 	nvarchar(6),
@qec_qutno 	nvarchar(20),
@qec_qutseq 	int,
@qec_grpcde	nvarchar(6)

AS

delete from QUELC
where 	qec_cocde = @qec_cocde
and 	qec_qutno = @qec_qutno
and 	qec_qutseq = @qec_qutseq
and 	qec_grpcde = @qec_grpcde


GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_quelc] TO [ERPUSER] AS [dbo]
GO
