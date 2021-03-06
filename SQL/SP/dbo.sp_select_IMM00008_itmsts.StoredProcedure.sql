/****** Object:  StoredProcedure [dbo].[sp_select_IMM00008_itmsts]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00008_itmsts]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00008_itmsts]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[sp_select_IMM00008_itmsts]
@cocde	varchar(6),
@updItemList	varchar(1000)
as
Begin

	create table #_ITMLST(_itm varchar(30))
	declare	@itmRemain varchar(1000), @itmPart varchar(30)


	-- Check Update Items
	set @itmRemain = ltrim(rtrim(@updItemList))
	while charindex(',',@itmRemain) > 0 
	begin
		set @itmPart = ltrim(rtrim(left(@itmRemain, charindex(',', @itmRemain) - 1)))
		set @itmRemain = ltrim(rtrim(right(@itmRemain,len(@itmRemain) - charindex(',', @itmRemain))))
		if len(@itmPart) > 0 
		begin
			insert into #_ITMLST (_itm) values (@itmPart)
		end
	end
	if len(@itmRemain) > 0
	begin
		insert into #_ITMLST (_itm) values (@itmRemain)
	end
	
	select ibi_itmno,ibi_itmsts from IMBASINF
	where ibi_itmno in (
		select _itm from #_ITMLST
	) and
	ibi_itmsts not in ('TBC','INC','CMP')
End





GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00008_itmsts] TO [ERPUSER] AS [dbo]
GO
