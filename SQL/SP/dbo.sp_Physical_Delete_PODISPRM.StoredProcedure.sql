/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_PODISPRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_PODISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_PODISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/08/2003


/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Delete data From PODISPRM
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_PODISPRM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pdp_cocde  nvarchar     (6),
@pdp_purord  nvarchar     (20),
@pdp_pdptyp  nvarchar     (1),
@pdp_seqno  int
----------------------------------------------  
AS

begin
Delete PODISPRM 
Where 
pdp_cocde = @pdp_cocde  and
pdp_purord = @pdp_purord and
pdp_pdptyp = @pdp_pdptyp and
pdp_seqno = @pdp_seqno 

---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_PODISPRM] TO [ERPUSER] AS [dbo]
GO
