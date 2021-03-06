/****** Object:  StoredProcedure [dbo].[sp_update_SYAGTTIR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYAGTTIR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYAGTTIR]    Script Date: 09/29/2017 11:53:54 ******/
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
CREATE procedure [dbo].[sp_update_SYAGTTIR]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yat_cocde	nvarchar(6) = ' ',
@yat_agtcde	nvarchar(6),
@yat_seq		int,
@yat_ngmf	numeric(7,2),
@yat_ngmt	numeric(7,2),
@yat_rate		numeric(6,3),
@yat_updusr 	nvarchar(30)
---------------------------------------------- 
 
AS

begin
update syagttir
--set yat_cocde= @yat_cocde,
set
yat_agtcde = @yat_agtcde,
yat_ngmf = @yat_ngmf,
yat_ngmt = @yat_ngmt,
yat_rate = @yat_rate,
yat_updusr = @yat_updusr,
yat_upddat=getdate()                                  
--------------------------------- 

where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yat_cocde = @yat_cocde and 
--yat_cocde = ' ' and 
yat_agtcde = @yat_agtcde and 
yat_seq = @yat_seq


---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYAGTTIR] TO [ERPUSER] AS [dbo]
GO
