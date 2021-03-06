/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SHDISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Johnson Lai
Date:		20th Jan, 2001
Description:	Delete data From SHDISPRM
Parameter:	1. Company
		2. Shipping No
		3. Invoice no
		4 D/P
		4 seqno			
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_SHDISPRM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hdp_cocde  nvarchar(6),
@hdp_shpno nvarchar(20),
@hdp_invno  nvarchar(20),
@hdp_type nvarchar(6),
@hdp_seqno int

----------------------------------------------  
AS

begin
Delete SHDISPRM
Where 
hdp_cocde =  @hdp_cocde and
hdp_shpno = @hdp_shpno and
hdp_invno = @hdp_invno and
hdp_type = @hdp_type and
hdp_seqno = @hdp_seqno

---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SHDISPRM] TO [ERPUSER] AS [dbo]
GO
