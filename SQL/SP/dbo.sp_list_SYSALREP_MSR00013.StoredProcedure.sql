/****** Object:  StoredProcedure [dbo].[sp_list_SYSALREP_MSR00013]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYSALREP_MSR00013]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYSALREP_MSR00013]    Script Date: 09/29/2017 11:53:53 ******/
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
Description:	List data From SYSALREP
Parameter:	1. Company Code range    
		2. Sales Code range    
************************************************************************/

CREATE procedure [dbo].[sp_list_SYSALREP_MSR00013]
                                                                                                                                                                                                                                                                 

@ysr_cocde	nvarchar(6)  = ' '
                                               
 
AS

BEGIN

Select	Distinct ysr_cocde,	ysr_saltem

                                  

FROM	SYSALREP

--WHERE	ysr_cocde = @ysr_cocde
WHERE	ysr_cocde = ' '
order by ysr_saltem
END





GO
GRANT EXECUTE ON [dbo].[sp_list_SYSALREP_MSR00013] TO [ERPUSER] AS [dbo]
GO
