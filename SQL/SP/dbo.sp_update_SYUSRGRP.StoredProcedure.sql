/****** Object:  StoredProcedure [dbo].[sp_update_SYUSRGRP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYUSRGRP]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYUSRGRP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: sp_update_SYUSRGRP
Description   	: Check Item - Customer-Vendor-Company Relationship(Item can be quot by comapny ) 
Programmer  		Lewis To	: 
Create Date   	: 	7 Jul 2003
Last Modified  	: 	
Table Read(s) 	:	 imveninf,vnbasinf, cumcoven
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 8 Jul 2003		Lewis To		Change to harcode 'UCPP as  Company Code for multi Company      
 5 Jul 2004		Lester Wu		not compare company code 
14 Apr 2005	Lester Wu		add company group
=========================================================     
*/




------------------------------------------------- 
CREATE procedure [dbo].[sp_update_SYUSRGRP]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yug_cocde 	nvarchar(6),
@yug_usrgrp  	nvarchar(6),
@yug_usrfun	nvarchar(10),
@yug_usrfun2	nvarchar(10),
@yug_fundsc	nvarchar(50),
@yug_assrig	nvarchar(4),
@fun_befupd	nvarchar(10),
@yug_updusr	nvarchar(30),
@yug_cogrp	nvarchar(6)   	--Lester Wu 2005/04/14, add company group
------------------------------------ 
AS
 
update SYUSRGRP
SET
yug_usrfun = @yug_usrfun,
yug_usrfun2 = @yug_usrfun2,
yug_fundsc = @yug_fundsc,
yug_assrig = @yug_assrig,
yug_updusr=@yug_updusr,
yug_upddat = getdate()

where 
--yug_cocde = @yug_cocde and			-- remark to change hardcode to 'UCPP'
--yug_cocde = 'UCPP' and
yug_usrgrp = @yug_usrgrp and 
yug_usrfun = @fun_befupd
and yug_cogrp = @yug_cogrp		--Lester Wu 2005-04-14, add company group
---------------------------------------------------------------------------------------------------------------------------------------------------------------------










GO
GRANT EXECUTE ON [dbo].[sp_update_SYUSRGRP] TO [ERPUSER] AS [dbo]
GO
