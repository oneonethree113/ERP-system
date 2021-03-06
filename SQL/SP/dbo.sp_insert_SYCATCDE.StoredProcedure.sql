/****** Object:  StoredProcedure [dbo].[sp_insert_SYCATCDE]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYCATCDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYCATCDE]    Script Date: 09/29/2017 11:53:53 ******/
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
2004/09/15	Lester Wu		Update MOA

*/


/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYLNECOL
Parameter:	1. Company Code range    
		2. Color Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYCATCDE] 
--------------------------------------------------------------------------------------------------------------------------------------

@ycc_cocde	nvarchar(6) = ' ',
@ycc_level	nvarchar(2),
@ycc_catcde	nvarchar(20),
@ycc_catdsc	nvarchar(200),
@ycc_fflag		char(1),		--Lester Wu 2004/09/21
--@ycc_moflag	char(1),		--
@ycc_moq		numeric(10),	--
@ycc_moa		numeric(13,4),	--Lester Wu 2004/09/21
@ycc_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYCATCDE

(
ycc_cocde,
ycc_level,
ycc_catcde,
ycc_catdsc,
ycc_fflag,		--Lester Wu 2004/09/21
--ycc_moflag,
ycc_moq,
ycc_moa,		--Lester Wu 2004/09/21
ycc_creusr,
ycc_updusr,
ycc_credat,
ycc_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@ycc_cocde,
' ',
@ycc_level,
@ycc_catcde,
@ycc_catdsc,
@ycc_fflag,	--Lester Wu 2004/09/21
--@ycc_moflag,
@ycc_moq,
@ycc_moa,	--Lester Wu 2004/09/15 Insert MOA
@ycc_updusr,
@ycc_updusr,
getdate(),
getdate()

)










GO
GRANT EXECUTE ON [dbo].[sp_insert_SYCATCDE] TO [ERPUSER] AS [dbo]
GO
