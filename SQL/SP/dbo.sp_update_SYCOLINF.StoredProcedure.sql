/****** Object:  StoredProcedure [dbo].[sp_update_SYCOLINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYCOLINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYCOLINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003


/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		For Merge Porject
*/

------------------------------------------------- 
CREATE procedure [dbo].[sp_update_SYCOLINF]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yci_cocde nvarchar(6) = ' ' ,
@yci_colcde nvarchar(30),
@yci_coldsc nvarchar(200),
@yci_updusr nvarchar(30)
---------------------------------------------- 
 
AS


begin
update sycolinf
set yci_colcde= @yci_colcde,
yci_coldsc=@yci_coldsc,
yci_updusr = @yci_updusr,
yci_upddat=getdate()                                  
--------------------------------- 

 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- yci_cocde = @yci_cocde and 
--yci_cocde = ' ' and 
yci_colcde = @yci_colcde


                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYCOLINF] TO [ERPUSER] AS [dbo]
GO
