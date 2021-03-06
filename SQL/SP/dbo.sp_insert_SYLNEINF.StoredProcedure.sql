/****** Object:  StoredProcedure [dbo].[sp_insert_SYLNEINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYLNEINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYLNEINF]    Script Date: 09/29/2017 11:53:53 ******/
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
ALTER  Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		For Merge Porject
20031128	Lester Wu		Add One More Filed : @yli_pcfty
20040602   Lester Wu		Add One More Field : @yli_dsgcde
*/

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYLNEINF

************************************************************************/

CREATE   PROCEDURE [dbo].[sp_insert_SYLNEINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@yli_cocde	nvarchar(6) = ' ',
@yli_lnecde	nvarchar(10),
@yli_lnedsc	nvarchar(200),
--2003/11/28--
@yli_pcfty		nvarchar(20),
------------------
--2004/06/02--
@yli_dsgcde	nvarchar(6),
--------------------
@yli_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYLNEINF

(
yli_cocde,
yli_lnecde,	
yli_lnedsc,
--2003/11/28--
yli_pcfty,
----------------
--2004/06/02--
yli_dsgcde,
-----------------
yli_creusr,
yli_updusr,
yli_credat,	
yli_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@yli_cocde,
' ',
@yli_lnecde,
@yli_lnedsc,
@yli_pcfty,
@yli_dsgcde,
@yli_updusr,
@yli_updusr,
getdate(),
getdate()
)










GO
GRANT EXECUTE ON [dbo].[sp_insert_SYLNEINF] TO [ERPUSER] AS [dbo]
GO
