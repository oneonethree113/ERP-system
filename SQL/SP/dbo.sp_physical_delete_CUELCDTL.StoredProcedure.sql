/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUELCDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUELCDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUELCDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu
Date:		12th September, 2008
Description:	delete data From CUELCDTL
***********************************************************************
*/

CREATE procedure [dbo].[sp_physical_delete_CUELCDTL]


@ced_cocde	nvarchar(6),
@ced_cusno	nvarchar(6),
@ced_grpcde	nvarchar(6),
@ced_cecde	nvarchar(6)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------

if @ced_grpcde = 'ALL' 
begin

delete FROM	CUELCDTL
WHERE	
ced_cusno = @ced_cusno

end
else
begin

delete FROM	CUELCDTL
WHERE	
ced_cusno = @ced_cusno and
ced_grpcde = @ced_grpcde and
ced_cecde = @ced_cecde


end

END






GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUELCDTL] TO [ERPUSER] AS [dbo]
GO
