/****** Object:  StoredProcedure [dbo].[sp_select_SHCBNHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHCBNHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHCBNHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen 27/07/2003


/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Select data From SHCBNHDR
Parameter:	1. Company
		2. Note No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SHCBNHDR]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hnh_cocde nvarchar(6) ,
@hnh_noteno nvarchar(20)                                                
---------------------------------------------- 
 
AS
begin
Select 
*,
cast(hnh_timstp as int) as hnh_timstp        
--------------------------------- 
from SHCBNHDR 
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
hnh_noteno = @hnh_noteno and      
hnh_cocde = @hnh_cocde                                                              
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_select_SHCBNHDR] TO [ERPUSER] AS [dbo]
GO
