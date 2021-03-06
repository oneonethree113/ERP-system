/****** Object:  StoredProcedure [dbo].[sp_insert_SYS00004_UM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYS00004_UM]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYS00004_UM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE procedure [dbo].[sp_insert_SYS00004_UM]
@cocde	as nvarchar(6),                                                                                                                                                                                                                                                                
@MSEHI	as nvarchar(3),
@ZAEHL	as numeric(9),
@MSEHTE	as nvarchar(10),
@MSEHTM	as nvarchar(10),
@MSEHLE	as nvarchar(30),
@MSEHLM as nvarchar(30),
@dummy		char(1)

AS

begin


if ( select count(*) from syum where yum_msehte = @msehte) > 0
begin
update syum
set yum_msehi = @msehi, yum_msehtm = @msehtm,  yum_msehle = @msehle,  yum_msehlm = @msehlm,  yum_updusr = 'SAPUSER' ,yum_upddat = getdate()
 where yum_msehte = @msehte
end
else
begin
insert into syum (

	yum_cocde ,
	yum_msehi,
	yum_zaehl ,
	yum_msehte ,
	yum_msehtm ,
	yum_msehle ,
	yum_msehlm ,
	yum_creusr,
	yum_updusr ,
	yum_credat ,
	yum_upddat 
	
)
values
(
'',
@MSEHI	,
@ZAEHL	,
@MSEHTE	,
@MSEHTM	,
@MSEHLE	,
@MSEHLM ,
'SAPUSER',
'SAPUSER',
getdate(),
getdate()
)
end

end


GO
GRANT EXECUTE ON [dbo].[sp_insert_SYS00004_UM] TO [ERPUSER] AS [dbo]
GO
