/****** Object:  StoredProcedure [dbo].[sp_update_SYCONFTR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYCONFTR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYCONFTR]    Script Date: 09/29/2017 11:53:54 ******/
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
S A M U E L
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_update_SYCONFTR]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ycf_cocde	nvarchar(6) = ' ',
@ycf_code1	nvarchar(6),
@ycf_dsc1		nvarchar(200),
@ycf_code2	nvarchar(6),
@ycf_dsc2		nvarchar(200),
--@ycf_oper		nvarchar(1),
@ycf_value	numeric(12,4),
@ycf_systyp	nvarchar(1),
@ycf_updusr 	nvarchar(30)
---------------------------------------------- 
 
AS


begin
update syconftr

set 
--ycf_cocde = @ycf_cocde,
ycf_code1= @ycf_code1,
ycf_dsc1 = @ycf_dsc1,
ycf_code2 = @ycf_code2,
ycf_dsc2 = @ycf_dsc2,
/*
--ycf_oper = @ycf_oper,
*/
ycf_value = @ycf_value,
ycf_systyp = @ycf_systyp,
ycf_updusr = @ycf_updusr,
ycf_upddat=getdate()                                  
--------------------------------- 

 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--ycf_cocde = @ycf_cocde and 
--ycf_cocde = ' ' and 
ycf_code1 = @ycf_code1 and
ycf_code2 = @ycf_code2




 ---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYCONFTR] TO [ERPUSER] AS [dbo]
GO
