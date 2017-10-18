/****** Object:  StoredProcedure [dbo].[sp_list_SYPAKCAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYPAKCAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYPAKCAT]    Script Date: 09/29/2017 11:53:53 ******/
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
Author:		Kath Ng     
Date:		4th October, 2001
Description:	List data From SYPAKCAT
Parameter:	1. Company Code range    
		2. Sales Code range    
************************************************************************/

CREATE procedure [dbo].[sp_list_SYPAKCAT]
                                                                                                                                                                                                                                                                 

@ypc_cocde	nvarchar(6)  = ' '
                                               
 
AS

BEGIN

Select	 ypc_cocde,ypc_code,ypc_pakna,ypc_moq,ypc_dsc,ypc_creusr,ypc_updusr,ypc_credat,ypc_upddat
                                  

FROM	SYPAKCAT

--WHERE	ysr_cocde = @ysr_cocde
WHERE	ypc_cocde = ' '

END










GO
GRANT EXECUTE ON [dbo].[sp_list_SYPAKCAT] TO [ERPUSER] AS [dbo]
GO
