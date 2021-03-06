/****** Object:  StoredProcedure [dbo].[sp_Update_PODTLSHP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_PODTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_PODTLSHP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Wong Hong
Date:		4th dec, 2002
Description:	Update data From PODTLSHP
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Update_PODTLSHP]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pds_cocde  nvarchar(6), 	@pds_purord  nvarchar(20),
@pds_seq int,		@pds_shpseq int,
@pds_from datetime,  	@pds_to datetime, 		
@pds_ttlctn int,		@pds_updusr nvarchar(30)
---------------------------------------------- 
 
AS
begin
Update PODTLSHP SET
pds_from=@pds_from,
pds_to=@pds_to,
pds_ttlctn=@pds_ttlctn,
pds_updusr=@pds_updusr,
pds_upddat=GETDATE()
--------------------------------- 
Where                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
pds_cocde = @pds_cocde and
pds_purord = @pds_purord and
pds_seq = @pds_seq and
pds_shpseq = @pds_shpseq                                                                                                                                                                  
---------------------------------------------------------- 


end






GO
GRANT EXECUTE ON [dbo].[sp_Update_PODTLSHP] TO [ERPUSER] AS [dbo]
GO
