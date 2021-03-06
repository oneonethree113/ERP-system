/****** Object:  StoredProcedure [dbo].[sp_list_SYSALINF_CU]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYSALINF_CU]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYSALINF_CU]    Script Date: 09/29/2017 11:53:53 ******/
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
Description:	List data From SYSALINF
Parameter:	1. Company Code range    
		2. Sales Code range    
************************************************************************/


CREATE procedure [dbo].[sp_list_SYSALINF_CU]
                                                                                                                                                                                                                                                                 


@ssi_cocde	nvarchar(6)  = ' '
                                               
 
AS

BEGIN

Select	ssi_cocde,	ssi_typ,		ssi_saldiv,
	ssi_saltem,       ssi_salmgr,	
	ssi_creusr,	ssi_updusr,
	ssi_credat,	ssi_upddat,	cast(ssi_timstp as int) as ssi_timstp
                                  

FROM	SYSALINF

--WHERE	ysr_cocde = @ysr_cocde
WHERE	ssi_cocde = ' '  and ssi_typ = 'TEAM'
order by ssi_saltem

END









GO
GRANT EXECUTE ON [dbo].[sp_list_SYSALINF_CU] TO [ERPUSER] AS [dbo]
GO
