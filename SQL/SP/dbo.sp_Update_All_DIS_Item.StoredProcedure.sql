/****** Object:  StoredProcedure [dbo].[sp_Update_All_DIS_Item]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_All_DIS_Item]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_All_DIS_Item]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003

CREATE PROCEDURE [dbo].[sp_Update_All_DIS_Item] 

@iba_cocde	nvarchar(6),
@iba_itmno 	nvarchar(4000),
@iba_usrid	nvarchar(30),
@Type		Nvarchar(10)

AS
Declare @sql nvarchar(4000)
IF @Type = 'DIS'
BEGIN

	--SET @Sql = 	'Update IMBASINF SET ibi_prvsts=ibi_itmsts,ibi_itmsts =''DIS'' ,  ibi_updusr = ' + '''' +@iba_usrid  + '''' +
	--		' Where ibi_itmno in ' + @iba_itmno + ' and ibi_cocde = ' + ''''+ @iba_cocde + ''''
	SET @Sql = 	'Update IMBASINF SET ibi_prvsts=ibi_itmsts,ibi_itmsts =''DIS'' ,  ibi_updusr = ' + '''' +@iba_usrid  + '''' +
			' Where ibi_itmno in ' + @iba_itmno-- + ''''
END
ELSE
BEGIN
	--SET @Sql = 	'Update IMBASINF SET ibi_itmsts =ibi_prvsts,  ibi_updusr = ' + '''' +@iba_usrid  + '''' +
	--		' Where ibi_itmno in ' + @iba_itmno + ' and ibi_cocde = ' + ''''+ @iba_cocde + ''''
	SET @Sql = 	'Update IMBASINF SET ibi_itmsts =ibi_prvsts,  ibi_updusr = ' + '''' +@iba_usrid  + '''' +
			' Where ibi_itmno in ' + @iba_itmno-- + ''''
END
--select @sql
exec (@sql)



GO
GRANT EXECUTE ON [dbo].[sp_Update_All_DIS_Item] TO [ERPUSER] AS [dbo]
GO
