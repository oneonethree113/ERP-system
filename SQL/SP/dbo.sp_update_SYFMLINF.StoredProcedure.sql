/****** Object:  StoredProcedure [dbo].[sp_update_SYFMLINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYFMLINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYFMLINF]    Script Date: 09/29/2017 11:53:54 ******/
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
CREATE procedure [dbo].[sp_update_SYFMLINF]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@yfi_cocde	nvarchar(6) = ' ',
@yfi_fmlopt	nvarchar(5),
@yfi_prcfml	nvarchar(50),
@yfi_fml		nvarchar(300),		
@yfi_updusr	nvarchar(30)
---------------------------------------------- 
 
AS


begin
update syfmlinf
set 
--yfi_cocde = @yfi_cocde,
yfi_fmlopt	= @yfi_fmlopt,	
yfi_prcfml	= @yfi_prcfml,		
yfi_fml = @yfi_fml,				
yfi_updusr	= @yfi_updusr,
yfi_upddat=getdate()                                  	

--------------------------------- 

where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yfi_cocde = @yfi_cocde and 
--yfi_cocde = ' ' and 
yfi_fmlopt = @yfi_fmlopt
                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYFMLINF] TO [ERPUSER] AS [dbo]
GO
