/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_FYFILMAP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_FYFILMAP]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_FYFILMAP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Johnson Lai
Date:		Mar 05, 2002
Description:	Delete data From FYFILMAP
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_FYFILMAP]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ffm_cocde  nvarchar     (6),
@ffm_creusr  nvarchar     (30)
----------------------------------------------  

AS

begin

Delete FYFILMAP
Where 
ffm_cocde = @ffm_cocde  and
ffm_creusr = @ffm_creusr

---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_FYFILMAP] TO [ERPUSER] AS [dbo]
GO
