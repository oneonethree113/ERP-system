/****** Object:  StoredProcedure [dbo].[sp_insert_SYCATFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYCATFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYCATFML]    Script Date: 09/29/2017 11:53:53 ******/
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
20030715	Allan Yuen		For Merge Porject
*/

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYLNEFML
Parameter:	1. Company Code range    
		2. Color Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYCATFML] 
--------------------------------------------------------------------------------------------------------------------------------------

@yaf_cocde	nvarchar(6) = ' ',
@yaf_lnecde	nvarchar(12),
@yaf_catcde	nvarchar(20),
@yaf_fmlopt	nvarchar(5),
@yaf_fml	nvarchar(300),
@yaf_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYCATFML

(
yaf_cocde,
yaf_lnecde,
yaf_catcde,
yaf_fmlopt,
yaf_fml,
yaf_creusr,
yaf_updusr,
yaf_credat,
yaf_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@yaf_cocde,
' ',
@yaf_lnecde,
@yaf_catcde,
@yaf_fmlopt,
@yaf_fml,	
@yaf_updusr,
@yaf_updusr,
getdate(),
getdate()
)


update sylneinf
set 
yli_updusr = @yaf_updusr,
yli_upddat=getdate()                                  
where
--at
--yli_cocde = @yaf_cocde and 
yli_cocde = ' ' and 
yli_lnecde= @yaf_lnecde






GO
GRANT EXECUTE ON [dbo].[sp_insert_SYCATFML] TO [ERPUSER] AS [dbo]
GO
