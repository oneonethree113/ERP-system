/****** Object:  StoredProcedure [dbo].[sp_select_SYCOLINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCOLINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCOLINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




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
CREATE procedure [dbo].[sp_select_SYCOLINF]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yci_cocde nvarchar(6)  = ' '

---------------------------------------------- 
 
AS
declare @yci_timstp int

--Set  @yci_timstp = (Select max(cast(yci_timstp as int)) from sycolinf where yci_cocde = @yci_cocde)
Set  @yci_timstp = (Select max(cast(yci_timstp as int)) from sycolinf where yci_cocde = ' ')

begin
 Select 
yci_creusr as 'yci_status',
yci_cocde,
yci_colcde,
yci_coldsc,
yci_creusr,
yci_updusr,
yci_credat,
yci_upddat,
@yci_timstp as yci_timstp 

/*
yci_creusr as 'yci_status'
*/
                                  
--------------------------------- 
 from SYCOLINF
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- yci_cocde = @yci_cocde
 yci_cocde = ' '

order by 
yci_cocde,
yci_colcde,
yci_creusr,
yci_updusr,
yci_credat,
yci_upddat                           
-------------------------- 

                                                           
---------------------------------------------------------- 
end








GO
GRANT EXECUTE ON [dbo].[sp_select_SYCOLINF] TO [ERPUSER] AS [dbo]
GO
