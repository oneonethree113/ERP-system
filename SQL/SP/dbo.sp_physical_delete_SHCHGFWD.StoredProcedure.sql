/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SHCHGFWD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SHCHGFWD]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SHCHGFWD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SHCHGFWD
***********************************************************************
*/


CREATE  procedure [dbo].[sp_physical_delete_SHCHGFWD]

@scf_cocde	nvarchar(6),
@scf_docno	nvarchar(20),
@scf_fwdnam	nvarchar(200)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------
	delete FROM	SHCHGFWD WHERE	scf_docno = @scf_docno
						and scf_fwdnam = @scf_fwdnam
END









GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SHCHGFWD] TO [ERPUSER] AS [dbo]
GO
