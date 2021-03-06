/****** Object:  StoredProcedure [dbo].[sp_select_untcde]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_untcde]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_untcde]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_select_untcde]
@JobNum	as nvarchar(10)
AS

declare @Prefix as  nvarchar(2)
set @Prefix = left(@JobNum, 2)
if  isnumeric(@Prefix) = 1
	select intcoc08 from intcoc where intcoc11 = @JobNum
else
begin
	declare @Numprt as nvarchar(6)
	set @Numprt = cast(right(@JobNum,len(@JobNum)-2) as int)

	select copd_up.BUNCODE from copd_up 
		left join  pnhd_up
		on pnhd_up.podtcode = copd_up.dtcode and pnhd_up.pono = copd_up.no and pnhd_up.line = copd_up.line
		where pnhd_up.dtcode = @Prefix AND pnhd_up.no  = @NumPrt

end





GO
GRANT EXECUTE ON [dbo].[sp_select_untcde] TO [ERPUSER] AS [dbo]
GO
