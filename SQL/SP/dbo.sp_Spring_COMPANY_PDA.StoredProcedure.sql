/****** Object:  StoredProcedure [dbo].[sp_Spring_COMPANY_PDA]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Spring_COMPANY_PDA]
GO
/****** Object:  StoredProcedure [dbo].[sp_Spring_COMPANY_PDA]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/************************************************************************
Author:		
Date:		
Description:	
****************

************************************************************************
=========================================================
Program ID	:  	sp_Spring_COMPANY_PDA
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
           
=========================================================     
*/
CREATE procedure [dbo].[sp_Spring_COMPANY_PDA]

as

--Select avalible Company Code ***********************
Select 
	yco_cocde 
from 
	sycominf (nolock)

GO
GRANT EXECUTE ON [dbo].[sp_Spring_COMPANY_PDA] TO [ERPUSER] AS [dbo]
GO
