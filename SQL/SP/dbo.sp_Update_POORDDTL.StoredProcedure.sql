/****** Object:  StoredProcedure [dbo].[sp_Update_POORDDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_POORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_POORDDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Wong Hong
Date:		4th dec, 2002
Description:	Update data From POORDDTL
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Update_POORDDTL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pod_cocde  nvarchar(6), 	@pod_purord  nvarchar(20),
@pod_purseq int, 		@pod_rmk nvarchar(300),
@pod_candat  datetime,		@pod_shpstr  datetime,		
@pod_shpend  datetime,		@pod_chndsc	nvarchar(1600),
@pod_updusr nvarchar(30)
---------------------------------------------- 
 
AS
begin
Update POORDDTL SET
pod_rmk = @pod_rmk,
pod_shpstr=@pod_shpstr,
pod_shpend=@pod_shpend,
pod_candat=@pod_candat,
pod_chndsc = @pod_chndsc,
pod_updusr=@pod_updusr,
pod_upddat=GETDATE()
--------------------------------- 
Where                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
pod_cocde = @pod_cocde and
pod_purord = @pod_purord and
pod_purseq = @pod_purseq                                                                                 
---------------------------------------------------------- 


end




GO
GRANT EXECUTE ON [dbo].[sp_Update_POORDDTL] TO [ERPUSER] AS [dbo]
GO
