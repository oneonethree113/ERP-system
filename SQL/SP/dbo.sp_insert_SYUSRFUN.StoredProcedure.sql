/****** Object:  StoredProcedure [dbo].[sp_insert_SYUSRFUN]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYUSRFUN]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYUSRFUN]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


-- Checked by Allan Yuen at 28/07/2003

/*	Author : Tommy Ho	*/

------------------------------------------------- 
CREATE procedure [dbo].[sp_insert_SYUSRFUN]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yuf_cocde 	nvarchar(6),
@yuf_usrfun	nvarchar(10),
@yuf_fundsc	nvarchar(50),
@yuf_creusr	nvarchar(30)

AS

insert into  SYUSRFUN
(	
	yuf_cocde,		yuf_usrfun,	yuf_fundsc,
	yuf_creusr,	yuf_updusr,	yuf_credat,	
	yuf_upddat
)
values
(
	@yuf_cocde,	@yuf_usrfun,	@yuf_fundsc,
	@yuf_creusr,	@yuf_creusr,	getdate(),
	getdate()
)      
---------------------------------------------------------------------------------------------------------------------------------------------------------------------




GO
GRANT EXECUTE ON [dbo].[sp_insert_SYUSRFUN] TO [ERPUSER] AS [dbo]
GO
