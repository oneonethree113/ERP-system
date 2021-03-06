/****** Object:  StoredProcedure [dbo].[sp_insert_SYUSRRIGHT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYUSRRIGHT]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYUSRRIGHT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/************************************************************************
Author:		Joe Yim
Date:		15th April, 2010
Description:	Insert data to SYUSRRIGHT

************************************************************************/

CREATE   PROCEDURE [dbo].[sp_insert_SYUSRRIGHT] 
--------------------------------------------------------------------------------------------------------------------------------------
@yur_cocde	nvarchar(6) = ' ',
@yur_cogrp	nvarchar(6),
@yur_usrid	nvarchar(30),
@yur_doctyp	nvarchar(2),
@yur_lvl		int,
@yur_para		nvarchar(30),
@yur_desc		nvarchar(100),
@yur_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYUSRRIGHT

(
yur_cogrp,
yur_usrid,
yur_doctyp,
yur_lvl,
yur_para,
yur_desc,
yur_creusr,
yur_updusr,
yur_credat,
yur_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
@yur_cogrp,
@yur_usrid,
@yur_doctyp,
@yur_lvl,
@yur_para,
@yur_desc,
@yur_updusr,
@yur_updusr,
getdate(),
getdate()
)







GO
GRANT EXECUTE ON [dbo].[sp_insert_SYUSRRIGHT] TO [ERPUSER] AS [dbo]
GO
