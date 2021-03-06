/****** Object:  StoredProcedure [dbo].[sp_update_SYHRMCDE]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYHRMCDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYHRMCDE]    Script Date: 09/29/2017 11:53:54 ******/
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

/*
Samuel
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_update_SYHRMCDE]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yhc_cocde	nvarchar(6) = ' ',
@yhc_tarzon	nvarchar(2),
@yhc_hrmcde	nvarchar(12),
@yhc_hrmdsc	nvarchar(300),
@yhc_dtyrat	numeric(6,3),
@yhc_updusr	nvarchar(30)
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
 
AS

begin
update syhrmcde
set 
--yhc_cocde = @yhc_cocde,
yhc_tarzon = @yhc_tarzon,
yhc_hrmcde = @yhc_hrmcde,
yhc_hrmdsc = @yhc_hrmdsc,
yhc_dtyrat = @yhc_dtyrat,
yhc_updusr = @yhc_updusr,
yhc_upddat=getdate()                                  
--------------------------------- 

 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yhc_cocde = @yhc_cocde and 
--yhc_cocde = ' ' and 
yhc_tarzon = @yhc_tarzon and 
yhc_hrmcde = @yhc_hrmcde


                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYHRMCDE] TO [ERPUSER] AS [dbo]
GO
