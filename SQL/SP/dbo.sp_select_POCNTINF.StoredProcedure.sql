/****** Object:  StoredProcedure [dbo].[sp_select_POCNTINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POCNTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POCNTINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/08/2003


/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Select data From POCNTINF
Parameter:	1. Company
		2. SC No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_POCNTINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pci_cocde nvarchar(6) ,
@pci_purord nvarchar(20)                                                
---------------------------------------------- 
 
AS
begin
Select 
*
--------------------------------- 
from POCNTINF
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
pci_cocde = @pci_cocde and
pci_purord = @pci_purord                                                                                 
---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_select_POCNTINF] TO [ERPUSER] AS [dbo]
GO
