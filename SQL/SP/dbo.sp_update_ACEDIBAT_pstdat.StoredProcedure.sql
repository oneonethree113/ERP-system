/****** Object:  StoredProcedure [dbo].[sp_update_ACEDIBAT_pstdat]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_ACEDIBAT_pstdat]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_ACEDIBAT_pstdat]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



create procedure [dbo].[sp_update_ACEDIBAT_pstdat]
	@aeb_updusr	nvarchar(30)
AS
begin
DECLARE @month_today int
DECLARE @month_aeb_pstdat int
Declare @aeb_pstdat datetime
DECLARE @new_date datetime


--@month_aeb_pstdat = datepart(mm, max(aeb_pstdat) )
	--@month_today = datepart(mm, getdate()),
	
	
	select @aeb_pstdat = min(aeb_pstdat) from ACEDIBAT

	SELECT @new_date = dateadd(mm, 1, convert(varchar,DATEPART(yyyy, @aeb_pstdat)) + '-' + convert(varchar,datepart(mm,  @aeb_pstdat)) + '-' + '01')
	UPDATE ACEDIBAT
	SET 
		aeb_pstdat = @new_date,
		aeb_updusr = @aeb_updusr, 
		aeb_upddat = getdate()
		

END



GO
GRANT EXECUTE ON [dbo].[sp_update_ACEDIBAT_pstdat] TO [ERPUSER] AS [dbo]
GO
