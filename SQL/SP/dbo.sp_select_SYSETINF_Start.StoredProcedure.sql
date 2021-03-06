/****** Object:  StoredProcedure [dbo].[sp_select_SYSETINF_Start]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYSETINF_Start]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYSETINF_Start]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
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
Author:		Johnson Lai 
Date:		17th September, 2001
Description:	Select data From SETUPINF
Parameter:	1. SYSTEM TYPE
************************************************************************/

CREATE procedure [dbo].[sp_select_SYSETINF_Start]

@ysi_cocde 	nvarchar(6)  = ' '

AS

begin

Select	
ysi_creusr as 'Del',
ysi_cde as 'Code',
ysi_dsc as 'Description',
ysi_value as 'Value',
ysi_def as 'Default (Y/N)',
ysi_sys as 'System'

from SYSETINF

where                                                                                                                                                                                                                                                                
--ysi_cocde	 = @ysi_cocde 
ysi_cocde = ' '
order by
ysi_typ
end








GO
GRANT EXECUTE ON [dbo].[sp_select_SYSETINF_Start] TO [ERPUSER] AS [dbo]
GO
