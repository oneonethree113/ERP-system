/****** Object:  StoredProcedure [dbo].[sp_physical_delete_qucstemt]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_qucstemt]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_qucstemt]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/************************************************************************
Author:		Lester Wu
Date:		17th September, 2008
Description:	Delete data from QUCSTEMT
***********************************************************************
*/



CREATE PROCEDURE [dbo].[sp_physical_delete_qucstemt] 

@qce_cocde 	nvarchar(6),
@qce_qutno 	nvarchar(20),
@qce_qutseq 	int,
@qce_ceseq	int


AS

delete from QUCSTEMT
where 	qce_cocde = @qce_cocde
and 	qce_qutno = @qce_qutno
and 	qce_qutseq = @qce_qutseq
and 	qce_ceseq = @qce_ceseq


GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_qucstemt] TO [ERPUSER] AS [dbo]
GO
