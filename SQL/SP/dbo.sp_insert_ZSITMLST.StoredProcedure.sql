/****** Object:  StoredProcedure [dbo].[sp_insert_ZSITMLST]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_ZSITMLST]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_ZSITMLST]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 2005/08/11
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
2005-10-12	Allan Yuen		Add Columns
*/

CREATE PROCEDURE [dbo].[sp_insert_ZSITMLST] 

@Zil_cocde	nvarchar(6),
@zil_itmno	varchar(20),
@zil_itmnam	nvarchar(60),
@zil_um		varchar(6),
@zil_cur		varchar(6),
@zil_prc		numeric(13,4),
@zil_custum	varchar(6),
@zil_catcde1	nvarchar(20),
@zil_catcde2	nvarchar(20),
@zil_creusr	varchar(30)

AS

INSERT INTO ZSITMLST
(
zil_itmno,
zil_itmnam,
zil_um,
zil_cur,
zil_prc,
zil_custum,
zil_catcde1,
zil_catcde2,
zil_credat,
zil_creusr,
zil_upddat,
zil_updusr
)
values
(
@zil_itmno,
@zil_itmnam,
@zil_um,
@zil_cur,
@zil_prc,
@zil_custum,
@zil_catcde1,
@zil_catcde2,
getdate(),
@zil_creusr,
getdate(),
@zil_creusr
)






GO
GRANT EXECUTE ON [dbo].[sp_insert_ZSITMLST] TO [ERPUSER] AS [dbo]
GO
