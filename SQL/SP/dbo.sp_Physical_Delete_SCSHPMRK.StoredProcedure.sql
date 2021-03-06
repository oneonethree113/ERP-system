/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SCSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SCSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SCSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Kenny Chan
Date:		21th dec, 2001
Description:	Delete data From SCSHPMRK
Parameter:	1. Company
		2. SC No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_SCSHPMRK]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ssm_cocde  nvarchar     (6),
@ssm_ordno  nvarchar     (20),
@ssm_shptyp nvarchar     (6)
----------------------------------------------  
AS

begin
Delete SCSHPMRK
Where 
ssm_cocde = @ssm_cocde  and
ssm_ordno = @ssm_ordno and
ssm_shptyp = @ssm_shptyp
---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SCSHPMRK] TO [ERPUSER] AS [dbo]
GO
