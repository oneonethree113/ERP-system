/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CAORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CAORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CAORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		26th Aug, 2011
Description:	delete data From CAORDDTL
***********************************************************************
*/

CREATE procedure [dbo].[sp_physical_delete_CAORDDTL]

@cad_cocde nvarchar(6),
@cad_caordno nvarchar(20),
@cad_caordseq int,
@usrid nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------

delete FROM CAORDDTL
WHERE	
cad_cocde = @cad_cocde and cad_caordno = @cad_caordno and cad_caordseq = @cad_caordseq




END








GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CAORDDTL] TO [ERPUSER] AS [dbo]
GO
