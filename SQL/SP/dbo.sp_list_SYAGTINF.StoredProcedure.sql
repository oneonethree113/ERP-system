/****** Object:  StoredProcedure [dbo].[sp_list_SYAGTINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYAGTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYAGTINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
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

CREATE PROCEDURE [dbo].[sp_list_SYAGTINF] 

@yai_cocde 	nvarchar(6) = ' '
AS

Select * from SYAGTINF
--where yai_cocde = @yai_cocde
where yai_cocde = ' '
order by yai_agtcde








GO
GRANT EXECUTE ON [dbo].[sp_list_SYAGTINF] TO [ERPUSER] AS [dbo]
GO
