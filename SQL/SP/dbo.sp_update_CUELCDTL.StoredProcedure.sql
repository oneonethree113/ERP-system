/****** Object:  StoredProcedure [dbo].[sp_update_CUELCDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUELCDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUELCDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu   
Date:		12th September, 2008
Description:	Update data From CUELCDTL
***********************************************************************
*/

CREATE procedure [dbo].[sp_update_CUELCDTL]


@ced_cocde	nvarchar(6),
@ced_cusno	nvarchar(6),
@ced_grpcde	nvarchar(6),
@ced_seq	int,
@ced_cecde	nvarchar(6),
@ced_percent	numeric(13,4),
@ced_chg	char(1),
@ced_updusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


update CUELCDTL
set
ced_seq = @ced_seq,
ced_percent = @ced_percent,
ced_chg = @ced_chg,
ced_updusr = @ced_updusr,
ced_upddat = getdate()
WHERE	
ced_cusno = @ced_cusno and
ced_grpcde = @ced_grpcde and
ced_cecde = @ced_cecde


END







GO
GRANT EXECUTE ON [dbo].[sp_update_CUELCDTL] TO [ERPUSER] AS [dbo]
GO
