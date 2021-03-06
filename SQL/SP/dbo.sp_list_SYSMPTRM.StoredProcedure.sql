/****** Object:  StoredProcedure [dbo].[sp_list_SYSMPTRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYSMPTRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYSMPTRM]    Script Date: 09/29/2017 11:53:53 ******/
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

/*****************************************************************

Author:		Kath Ng     
Date:		27th November, 2001
Description:	List data from SYSMPTRM

*****************************************************************/


CREATE PROCEDURE [dbo].[sp_list_SYSMPTRM] 

@yst_cocde	nvarchar(6) = ' '

AS
-----------------------------------------------------------------------------------------------
SELECT	yst_cocde,	yst_trmcde,	yst_trmdsc,
	yst_charge,	yst_chgval,	yst_creusr,
	yst_updusr,	yst_credat,	yst_upddat

FROM SYSMPTRM

where 
--yst_cocde = @yst_cocde
yst_cocde = ' '
order by yst_trmcde



-----------------------------------------------------------------------------------------------





GO
GRANT EXECUTE ON [dbo].[sp_list_SYSMPTRM] TO [ERPUSER] AS [dbo]
GO
