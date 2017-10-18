/****** Object:  StoredProcedure [dbo].[sp_list_SYSALREP_SAM00003]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYSALREP_SAM00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYSALREP_SAM00003]    Script Date: 09/29/2017 11:53:53 ******/
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

/************************************************************************
Author:		Johnson Lai
Date:		8th Feb, 2002
Description:	List data From SYSALREP
Parameter:	1. Company Code range   

************************************************************************/

CREATE procedure [dbo].[sp_list_SYSALREP_SAM00003]
                                                                                                                                                                                                                                                                 

@ysr_cocde	nvarchar(6)  = ' '
                                               
 
AS

BEGIN

Select	

*                                 

FROM	SYSALREP

--WHERE	ysr_cocde = @ysr_cocde
WHERE	ysr_cocde = ' '

order by ysr_code1
END






GO
GRANT EXECUTE ON [dbo].[sp_list_SYSALREP_SAM00003] TO [ERPUSER] AS [dbo]
GO
