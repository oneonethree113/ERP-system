/****** Object:  StoredProcedure [dbo].[sp_update_SYCUREX_ACC_expdat]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYCUREX_ACC_expdat]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYCUREX_ACC_expdat]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


create PROCEDURE [dbo].[sp_update_SYCUREX_ACC_expdat]
@intput_date datetime
AS

Begin
declare @UpperDay Datetime
declare @LowerDay Datetime

set @UpperDay = (
SELECT TOP 1 yce_effdat FROM SYCUREX_ACC
WHERE yce_effdat > @intput_date 
ORDER BY yce_effdat ASC )

if ( @UpperDay is not null )
	Begin
	update SYCUREX_ACC
		set 
			yce_expdat = DATEADD(s,-1,@UpperDay)
		where
			yce_expdat = '12/31/1900 23:59:59'
	END
else 
	Begin
	update SYCUREX_ACC
		set 
			yce_expdat = '12/31/2099 23:59:59'
		where
			yce_expdat = '12/31/1900 23:59:59'
	END

	
set @LowerDay = (
SELECT TOP 1 yce_effdat FROM SYCUREX_ACC
WHERE yce_effdat < @intput_date 
ORDER BY yce_effdat DESC )

if ( @LowerDay is not null )
	Begin
	update SYCUREX_ACC
		set 
			yce_expdat = DATEADD(s,-1,@intput_date)
		where
			yce_effdat = @LowerDay
	END

update SYCUREX_ACC
	set 
		yce_iseff = 'N'

update SYCUREX_ACC
	set 
		yce_iseff = 'Y'
	where
		yce_effdat = @intput_date

END



GO
GRANT EXECUTE ON [dbo].[sp_update_SYCUREX_ACC_expdat] TO [ERPUSER] AS [dbo]
GO
