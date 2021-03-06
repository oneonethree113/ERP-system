/****** Object:  StoredProcedure [dbo].[sp_get_bpmrkup]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_get_bpmrkup]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_bpmrkup]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_get_bpmrkup] 

@catlvl4 	nvarchar(20),
@lnecde	nvarchar(10),
@imu_fmlopt	nvarchar(30) output,
@fml		nvarchar(10) output

AS

BEGIN

DECLARE
@debug		int
	
	if ltrim(rtrim(@lnecde)) <> ''
	begin
		if @lnecde <> '' 
		begin
			select @imu_fmlopt = yaf_fmlopt, @fml = yaf_fml from SYCATFML 
			where 	
				yaf_lnecde = @lnecde and
				yaf_catcde = @catlvl4
		end
	end
	else
	begin
		set @imu_fmlopt = ''
		set @fml = "*1"
	end

END


GO
GRANT EXECUTE ON [dbo].[sp_get_bpmrkup] TO [ERPUSER] AS [dbo]
GO
