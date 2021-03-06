/****** Object:  StoredProcedure [dbo].[sp_update_SYLNECOL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYLNECOL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYLNECOL]    Script Date: 09/29/2017 11:53:54 ******/
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

CREATE procedure [dbo].[sp_update_SYLNECOL]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ylc_cocde	nvarchar(6)  = ' ',
@ylc_lnecde	nvarchar(12),
@ylc_colcde	nvarchar(30),
@ylc_coldsc	nvarchar(200),
@ylc_prmstd	nvarchar(1),
@ylc_updusr	nvarchar(30)
---------------------------------------------- 
 
AS


begin
update sylnecol
set 
--ylc_cocde = @ylc_cocde,
ylc_lnecde= @ylc_lnecde,
ylc_colcde=@ylc_colcde,
ylc_coldsc=@ylc_coldsc,
ylc_prmstd=@ylc_prmstd,
ylc_updusr = @ylc_updusr,
ylc_upddat=getdate()                                  
--------------------------------- 

where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--ylc_cocde = @ylc_cocde and 
--ylc_cocde = ' ' and 
ylc_lnecde= @ylc_lnecde and
ylc_colcde = @ylc_colcde

update sylneinf
set 
yli_updusr = @ylc_updusr,
yli_upddat=getdate()                                  
where
--yli_cocde = @ylc_cocde and 
yli_cocde = ' ' and 
yli_lnecde= @ylc_lnecde 


                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYLNECOL] TO [ERPUSER] AS [dbo]
GO
