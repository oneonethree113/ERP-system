/****** Object:  StoredProcedure [dbo].[sp_insert_SYUSRGRP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYUSRGRP]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYUSRGRP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO







/*	Author : Tommy Ho	*/
/*
=========================================================
Program ID	: sp_insert_SYUSRGRP
Description   	: Add User Group and function access rights
Programmer  		Lewis To	: 
Create Date   	: 	8 Jul 2003
Last Modified  	: 	
Table Read(s) 	:	 SYUSRGRP
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
8 Jul 2003		Lewis To		Change to use Multi Comapny        
5 Jul 2004		Lester Wu		insert '' instead of 'UCPP'
14 Apr 2005	Lester Wu		add company group
=========================================================     
*/

------------------------------------------------- 
CREATE procedure [dbo].[sp_insert_SYUSRGRP]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yug_cocde 	nvarchar(6),
@yug_usrgrp  	nvarchar(6),
@yug_usrfun	nvarchar(10),
@yug_usrfun2	nvarchar(10),
@yug_fundsc	nvarchar(50),
@yug_assrig	nvarchar(4),
@yug_creusr	nvarchar(30),
@yug_grpdsc	nvarchar(100),
@yug_cogrp	nvarchar(6)
AS

declare @yug_funseq	int

--Set  @yug_funseq = (Select isnull(max(yug_funseq),0)  + 1 from SYUSRGRP where yug_cocde = @yug_cocde and yug_usrgrp = @yug_usrgrp)
Set  @yug_funseq = (Select isnull(max(yug_funseq),0)  + 1 from SYUSRGRP where yug_cocde = 'UCPP' and yug_usrgrp = @yug_usrgrp) -- Default to use UCPP for multi COmpany

insert into  SYUSRGRP
(	
	yug_cocde,	yug_usrgrp,	yug_usrfun,
	yug_fundsc,	yug_assrig,	yug_creusr,
	yug_updusr,	yug_credat,	yug_upddat,
	yug_funseq,	yug_grpdsc
	, yug_cogrp,yug_usrfun2	--Lester Wu 2005-04-14, add company group
)
values
(
--	@yug_cocde,	@yug_usrgrp, 	@yug_usrfun,
--	'UCPP',
	'',		@yug_usrgrp, 	@yug_usrfun,
	@yug_fundsc,	@yug_assrig,	@yug_creusr,
	@yug_creusr,	getdate(),		getdate(),
	@yug_funseq,	@yug_grpdsc
	,@yug_cogrp,@yug_usrfun2	--Lester Wu 2005-04-14, add company group
)      
---------------------------------------------------------------------------------------------------------------------------------------------------------------------








GO
GRANT EXECUTE ON [dbo].[sp_insert_SYUSRGRP] TO [ERPUSER] AS [dbo]
GO
