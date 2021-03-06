/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SAINVDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SAINVDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SAINVDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai
Date:		18th Feb, 2001
Description:	Delete data From SAINVDTL
Parameter:	1. Company
		2. Invno 
		3 Invseq			
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_SAINVDTL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@sid_cocde  nvarchar(6),
@sid_invno nvarchar(20),
@sid_invseq int

----------------------------------------------  
AS

begin

Delete SAINVDTL
Where 
sid_cocde =  @sid_cocde and
sid_invno = @sid_invno and
sid_invseq = @sid_invseq

---------------------------------------------------------- 
end




GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SAINVDTL] TO [ERPUSER] AS [dbo]
GO
