/****** Object:  StoredProcedure [dbo].[sp_list_level0]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_level0]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_level0]    Script Date: 09/29/2017 11:53:53 ******/
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

CREATE PROCEDURE [dbo].[sp_list_level0] 

@ycc_cocde	nvarchar(6) = ' '

AS

Select 
ycc_catcde
from SYCATCDE

where 
--ycc_cocde= @ycc_cocde and 
ycc_cocde= ' ' and 
ycc_level = '0'

Order By ycc_catcde









GO
GRANT EXECUTE ON [dbo].[sp_list_level0] TO [ERPUSER] AS [dbo]
GO
