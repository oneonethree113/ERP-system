/****** Object:  StoredProcedure [dbo].[sp_select_SYSALREP_All]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYSALREP_All]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYSALREP_All]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




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
Author:		Samuel Chan    
Date:		18th September, 2001
Description:	Select data From SYSALREP

************************************************************************/

CREATE procedure [dbo].[sp_select_SYSALREP_All]
                                                                                                                                                                                                                                                                 

@ysr_cocde	nvarchar(6)  = ' '
                                               
 
AS

begin

Select	ysr_creusr as 'ysr_status',
 	ysr_cocde, ysr_code1,	ysr_code, ysr_dsc, 
	ysr_salmgr,	ysr_saltem,	ysr_ref,
	ysr_creusr,	ysr_updusr,	ysr_credat,
	ysr_upddat,
	cast(ysr_timstp as int) as ysr_timstp
                                  

 from SYSALREP
 where
                                                                                                                                                                                                                                                               

--ysr_cocde = @ysr_cocde
ysr_cocde = ' '
                           
order by 
--ysr_saltem
ysr_code1

end

GO
GRANT EXECUTE ON [dbo].[sp_select_SYSALREP_All] TO [ERPUSER] AS [dbo]
GO
