/****** Object:  StoredProcedure [dbo].[sp_list_SYAGTTIR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYAGTTIR]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYAGTTIR]    Script Date: 09/29/2017 11:53:53 ******/
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


--Samuel

CREATE PROCEDURE [dbo].[sp_list_SYAGTTIR] 

@yat_cocde 	nvarchar(6) = ' '
AS

Select * from SYAGTTIR
--where yat_cocde = @yat_cocde
where yat_cocde = ' '









GO
GRANT EXECUTE ON [dbo].[sp_list_SYAGTTIR] TO [ERPUSER] AS [dbo]
GO
