/****** Object:  StoredProcedure [dbo].[sp_list_SYCLMAPS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYCLMAPS]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYCLMAPS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
ALTER  Date   	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
*/



CREATE PROCEDURE [dbo].[sp_list_SYCLMAPS] 

@ycc_cocde 	nvarchar(6) = ' '
AS

Select 
*
from SYCLMAPS









GO
GRANT EXECUTE ON [dbo].[sp_list_SYCLMAPS] TO [ERPUSER] AS [dbo]
GO
