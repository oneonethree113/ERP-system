/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CAORDITM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CAORDITM]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CAORDITM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		26th Aug, 2011
Description:	delete data From CAORDITM
***********************************************************************
*/

CREATE procedure [dbo].[sp_physical_delete_CAORDITM]

@cai_cocde nvarchar(6),
@cai_caordno nvarchar(20),
@cai_caordseq int,
@usrid nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------

delete FROM CAORDITM
WHERE	
cai_cocde = @cai_cocde and cai_caordno = @cai_caordno and cai_caordseq = @cai_caordseq




END








GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CAORDITM] TO [ERPUSER] AS [dbo]
GO
