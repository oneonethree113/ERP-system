/****** Object:  StoredProcedure [dbo].[SP_INSERT_MENU_LOG]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[SP_INSERT_MENU_LOG]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_MENU_LOG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
Script to trace user menu click
Lester Wu 2006-05-03
*/


CREATE PROCEDURE [dbo].[SP_INSERT_MENU_LOG]
@COCDE	as varchar(6) , 
@MENU	as varchar(30) , 
@COGRP	as varchar(20) ,
@USERID	as varchar(30) 

AS
BEGIN

	INSERT INTO MENULOG (log_cogrp ,log_menu, log_creusr , log_credat)
	VALUES (isnull(@COGRP,''),@MENU,@USERID,getdate())

END






GO
GRANT EXECUTE ON [dbo].[SP_INSERT_MENU_LOG] TO [ERPUSER] AS [dbo]
GO
