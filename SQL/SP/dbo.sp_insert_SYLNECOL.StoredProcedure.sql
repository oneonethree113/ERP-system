/****** Object:  StoredProcedure [dbo].[sp_insert_SYLNECOL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYLNECOL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYLNECOL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
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
20030715	Allan Yuen		Modify For Merge Porject
*/

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYLNECOL
Parameter:	1. Company Code range    
		2. Color Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYLNECOL] 
--------------------------------------------------------------------------------------------------------------------------------------

@ylc_cocde	nvarchar(6) = ' ',
@ylc_lnecde	nvarchar(12),
@ylc_colcde	nvarchar(30),
@ylc_coldsc	nvarchar(200),
@ylc_prmstd	nvarchar(1),
@ylc_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYLNECOL

(
ylc_cocde,
ylc_lnecde,	
ylc_colcde,
ylc_coldsc,
ylc_prmstd,
ylc_creusr,
ylc_updusr,
ylc_credat,
ylc_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@ylc_cocde,
' ',
@ylc_lnecde,
@ylc_colcde,
@ylc_coldsc,
@ylc_prmstd,
@ylc_updusr,
@ylc_updusr,
getdate(),
getdate()
)

update sylneinf
set 
yli_updusr = @ylc_updusr,
yli_upddat=getdate()                                  
where
--yli_cocde = @ylc_cocde and 
yli_cocde = ' ' and 
yli_lnecde= @ylc_lnecde






GO
GRANT EXECUTE ON [dbo].[sp_insert_SYLNECOL] TO [ERPUSER] AS [dbo]
GO
