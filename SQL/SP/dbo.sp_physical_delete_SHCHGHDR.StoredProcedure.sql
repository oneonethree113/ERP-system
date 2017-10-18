/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SHCHGHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SHCHGHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SHCHGHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SHCHGHDR
***********************************************************************
*/


CREATE procedure [dbo].[sp_physical_delete_SHCHGHDR]

@sch_cocde	nvarchar(6),
@sch_docno 	nvarchar(20),
@sch_usrid	nvarchar(30)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------

delete FROM SHCHGHDR WHERE sch_docno = @sch_docno


END








GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SHCHGHDR] TO [ERPUSER] AS [dbo]
GO
