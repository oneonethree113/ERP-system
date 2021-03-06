/****** Object:  StoredProcedure [dbo].[sp_select_SCORDHDR_CUSTPO]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCORDHDR_CUSTPO]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCORDHDR_CUSTPO]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen 27/07/2003



/************************************************************************
Author:		Kenny Chan
Date:		19th dec, 2001
Description:	Select data From SCORDHDR
Parameter:	1. Company
		2. SC No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SCORDHDR_CUSTPO]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@soh_cocde nvarchar(6) ,
@soh_cus2no nvarchar(6),
@soh_cuspo nvarchar(30),
@soh_cus1no nvarchar(6)

---------------------------------------------- 
 
AS
begin
--------------------------------- 
Select count(*) as 'soh_cuspo'
from SCORDHDR
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
soh_cocde = @soh_cocde and
soh_cus1no = @soh_cus1no and
soh_cus2no = @soh_cus2no and
soh_cuspo = @soh_cuspo
---------------------------------------------------------- 
end




GO
GRANT EXECUTE ON [dbo].[sp_select_SCORDHDR_CUSTPO] TO [ERPUSER] AS [dbo]
GO
