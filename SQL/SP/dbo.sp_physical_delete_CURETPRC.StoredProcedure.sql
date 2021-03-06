/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CURETPRC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CURETPRC]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CURETPRC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu
Date:		12th September, 2008
Description:	delete data From CURETPRC
***********************************************************************
*/

CREATE procedure [dbo].[sp_physical_delete_CURETPRC]


@crp_cocde	nvarchar(6),
@crp_cusno	nvarchar(6),
@crp_rpcde	nvarchar(6)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------

if @crp_rpcde = 'ALL' 
begin

delete FROM	CURETPRC
WHERE	
crp_cusno = @crp_cusno

end
else
begin

delete FROM	CURETPRC
WHERE	
crp_cusno = @crp_cusno and
crp_rpcde = @crp_rpcde

end

END






GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CURETPRC] TO [ERPUSER] AS [dbo]
GO
