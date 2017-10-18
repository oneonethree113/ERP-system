/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBASINF_check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_check]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/****** Object:  Stored Procedure dbo.sp_select_IMBASINF_check    Script Date: 03/14/2003 12:15:16 ******/

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject
*/

/************************************************************************
Author:		Lewis To
Date:		14th March, 2003
Description:	Select data From IMBASINF_check
Parameter:		1. Company
		2. Item No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMBASINF_check]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@ibi_cocde nvarchar(6) ,
@ibi_itmno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS

Select 
	ibi_cocde,
	ibi_itmno
from 
	imbasinf
where
-- 	ibi_cocde = @ibi_cocde and
 	ibi_itmno = @ibi_itmno






GO
GRANT EXECUTE ON [dbo].[sp_select_IMBASINF_check] TO [ERPUSER] AS [dbo]
GO
