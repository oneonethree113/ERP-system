/****** Object:  StoredProcedure [dbo].[sp_insert_SYCOLINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYCOLINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYCOLINF]    Script Date: 09/29/2017 11:53:53 ******/
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
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYCOLINF
Parameter:	1. Company Code range    
		2. Color Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYCOLINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@yci_cocde	nvarchar(6) = ' ',
@yci_colcde	nvarchar(30),
@yci_coldsc	nvarchar(200),
@yci_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYCOLINF

(
yci_cocde,
yci_colcde,	
yci_coldsc,
yci_creusr,
yci_updusr,
yci_credat,	
yci_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@yci_cocde,
' ',
@yci_colcde,
@yci_coldsc,
@yci_updusr,
@yci_updusr,
getdate(),
getdate()
)










GO
GRANT EXECUTE ON [dbo].[sp_insert_SYCOLINF] TO [ERPUSER] AS [dbo]
GO
