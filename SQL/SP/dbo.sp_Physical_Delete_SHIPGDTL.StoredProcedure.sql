/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHIPGDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SHIPGDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHIPGDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Johnson Lai
Date:		20th Jan, 2001
Description:	Delete data From SHDISPRM
Parameter:	1. Company
		2. Shipping No		
		3 shpno			
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_SHIPGDTL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hid_cocde  nvarchar(6),
@hid_shpno nvarchar(20),
@hid_shpseq int

----------------------------------------------  
AS

begin

Delete SHIPGDTL
Where 
hid_cocde =  @hid_cocde and
hid_shpno = @hid_shpno and
hid_shpseq = @hid_shpseq

---------------------------------------------------------- 
end








GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SHIPGDTL] TO [ERPUSER] AS [dbo]
GO
