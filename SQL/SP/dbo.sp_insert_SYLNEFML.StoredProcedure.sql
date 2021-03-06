/****** Object:  StoredProcedure [dbo].[sp_insert_SYLNEFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYLNEFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYLNEFML]    Script Date: 09/29/2017 11:53:53 ******/
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
20030715	Allan Yuen		Modify For Merge Porject
*/

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYLNEFML
Parameter:	1. Company Code range    
		2. Color Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYLNEFML] 
--------------------------------------------------------------------------------------------------------------------------------------

@ylf_cocde	nvarchar(6) = ' ',
@ylf_lnecde	nvarchar(12),
@ylf_fmlopt	nvarchar(5),
@ylf_deffml	nvarchar(3),
--@yfi_prcfml	nvarchar(50),
--@yfi_fml		nvarchar(300),
@ylf_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYLNEFML 

(
ylf_cocde,
ylf_lnecde,
ylf_fmlopt,
ylf_deffml,	
ylf_creusr,
ylf_updusr,
ylf_credat,
ylf_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@ylf_cocde,
' ',
@ylf_lnecde,
@ylf_fmlopt,
@ylf_deffml,	
@ylf_updusr,
@ylf_updusr,
getdate(),
getdate()
)

--INSERT INTO  SYFMLINF

--(
--yfi_cocde,
--yfi_fmlopt,
--yfi_prcfml,
--yfi_fml,
--yfi_creusr,
--yfi_updusr,
--yfi_credat,
--yfi_upddat
--)
--------------------------------------------------------------------------------------------------------------------------------------
--values
--(
--@ylf_cocde,
--@ylf_fmlopt,
--@yfi_prcfml,
--@yfi_fml,
--@ylf_updusr,
--@ylf_updusr,
--getdate(),
--getdate()
--)










GO
GRANT EXECUTE ON [dbo].[sp_insert_SYLNEFML] TO [ERPUSER] AS [dbo]
GO
