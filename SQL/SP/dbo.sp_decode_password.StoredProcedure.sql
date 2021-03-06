/****** Object:  StoredProcedure [dbo].[sp_decode_password]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_decode_password]
GO
/****** Object:  StoredProcedure [dbo].[sp_decode_password]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_decode_password] 

@cocde	nvarchar(6),
@usrid 	nvarchar(30)

AS

declare @pwd nvarchar(50), @lenpwd int, @i int, @X int, @Y int, @password nvarchar(50)

select @pwd = yup_paswrd from SYUSRPRF where yup_cocde = @cocde and yup_usrid = @usrid

set @password = ''	
set @lenpwd = Len(@pwd)
set @Y = 1
set @i = 0            
while @i < @lenpwd - 1
begin
              	If @Y <= @lenpwd
	begin
                      set @X = substring(@pwd, @Y,1)
                      set @password = @password + char((substring(@pwd, @Y + 1, @X)))
                      set @Y = @Y + @X + 1
                End
	set @i = @i +1
end
select @password



GO
GRANT EXECUTE ON [dbo].[sp_decode_password] TO [ERPUSER] AS [dbo]
GO
