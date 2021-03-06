/****** Object:  StoredProcedure [dbo].[sp_update_SYSMPTRM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYSMPTRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYSMPTRM]    Script Date: 09/29/2017 11:53:54 ******/
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
SAMUEL
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_update_SYSMPTRM]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yst_cocde nvarchar(6) = ' ',
@yst_trmcde nvarchar(6),
@yst_trmdsc nvarchar(200),
@yst_charge nvarchar(1),
@yst_chgval int,
@yst_updusr nvarchar(30)
---------------------------------------------- 
 
AS

begin
update sysmptrm
--set yst_cocde= @yst_cocde,
set
yst_trmcde= @yst_trmcde,
yst_trmdsc= @yst_trmdsc,
yst_charge= @yst_charge,
yst_chgval= @yst_chgval,
yst_updusr = @yst_updusr,
yst_upddat=getdate()                                  
--------------------------------- 

 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yst_cocde = @yst_cocde and 
--yst_cocde = ' ' and 
yst_trmcde = @yst_trmcde


                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYSMPTRM] TO [ERPUSER] AS [dbo]
GO
