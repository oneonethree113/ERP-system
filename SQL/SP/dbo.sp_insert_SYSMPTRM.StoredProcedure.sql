/****** Object:  StoredProcedure [dbo].[sp_insert_SYSMPTRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYSMPTRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYSMPTRM]    Script Date: 09/29/2017 11:53:53 ******/
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
Description:	Insert data into SYSMPTRM
Parameter:	
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYSMPTRM] 
--------------------------------------------------------------------------------------------------------------------------------------

@yst_cocde	nvarchar(6) = ' ',
@yst_trmcde	nvarchar(6),
@yst_trmdsc	nvarchar(200),
@yst_charge	nvarchar(1),
@yst_chgval	int,
@yst_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYSMPTRM

(
yst_cocde,
yst_trmcde,
yst_trmdsc,
yst_charge,
yst_chgval,
yst_creusr,
yst_updusr,
yst_credat,
yst_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@yst_cocde,
' ',
@yst_trmcde,
@yst_trmdsc,
@yst_charge,
@yst_chgval,
@yst_updusr,
@yst_updusr,
getdate(),
getdate()
)










GO
GRANT EXECUTE ON [dbo].[sp_insert_SYSMPTRM] TO [ERPUSER] AS [dbo]
GO
