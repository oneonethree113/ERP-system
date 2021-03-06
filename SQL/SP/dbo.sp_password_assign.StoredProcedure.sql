/****** Object:  StoredProcedure [dbo].[sp_password_assign]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_password_assign]
GO
/****** Object:  StoredProcedure [dbo].[sp_password_assign]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sp_password_assign] AS

set nocount on

DECLARE
@yup_cocde 	nvarchar(6),	@yup_usrid 	nvarchar(30),
@pwd nvarchar(30), 		@pass nvarchar(50),
@i int, 		@x int, 		@lenpwd int

DECLARE cur_SYUSRPRF CURSOR
FOR 	SELECT 	yup_cocde ,	yup_usrid
	FROM SYUSRPRF

OPEN cur_SYUSRPRF
FETCH NEXT FROM cur_SYUSRPRF INTO 
@yup_cocde ,		@yup_usrid

while @@fetch_status = 0
BEGIN

	set @pwd = @yup_usrid

	set  @lenpwd = Len(@pwd)

	set @i = 0 
	set @pass = ''
	
	while @i <= @lenpwd - 1
	begin
	        	set @x = ascii(substring(@pwd, @i + 1, 1))
		set @pass = @pass + LTrim(Str(Len(LTrim(Str((@x)))))) + LTrim(Str(@x))
		set @i = @i + 1 
	end	

	select @pass, @yup_usrid, @yup_cocde
	update SYUSRPRF set yup_paswrd = @pass 
		where yup_cocde = @yup_cocde and yup_usrid = @yup_usrid and yup_creusr = 'DATA' --yup_usrgrp <> 'SYA-S'

FETCH NEXT FROM cur_SYUSRPRF INTO 
@yup_cocde ,		@yup_usrid

END
CLOSE cur_SYUSRPRF
DEALLOCATE cur_SYUSRPRF

set nocount off







GO
GRANT EXECUTE ON [dbo].[sp_password_assign] TO [ERPUSER] AS [dbo]
GO
