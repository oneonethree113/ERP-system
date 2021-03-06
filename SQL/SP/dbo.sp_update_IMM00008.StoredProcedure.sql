/****** Object:  StoredProcedure [dbo].[sp_update_IMM00008]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMM00008]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMM00008]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Author		: Lester Wu 
Create Date		: 2006-09-27
Description		: Script to batch Update Items base on data on Source Item
*/


-- sp_update_IMM00008 'UCPP','06A51DA002A01','06A51DA002A02,06A51DA002A03,06A51DA002A04,06A51DA002A05','ENG','MIS'

create procedure [dbo].[sp_update_IMM00008]
@cocde	varchar(6),
@srcItem	varchar(30),
@updItemList	varchar(1000),
@optList	varchar(40),
@userID	varchar(30)
as
Begin

create table #_ITMLST(_itm varchar(30))
declare	@itmRemain varchar(1000), @itmPart varchar(30)
declare	@isEngDsc char(1), @isMOQ char(1), @isExcl char(1), @isPV char(1), @isCstInfo char(1)
declare	@tmpItem varchar(30)
declare	@cstrmk nvarchar(4000) , @expdat datetime
Declare	@Row_Idx int,@Err_Idx int

	set @Row_Idx = 0
	set @Err_Idx = 0
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- Check Source Item
	
	
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
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
	
	if ( select count(1) from #_ITMLST left join  IMBASINF on ibi_itmno = _itm where ibi_itmsts not in ('TBC','INC','CMP') ) > 0
	begin
		select ibi_itmno + ' - ' + ibi_itmsts from #_ITMLST  left join IMBASINF on ibi_itmno = _itm where ibi_itmsts not in ('TBC','INC','CMP')
		return (99)
	end

	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- Check Options
	set @optList = upper(@optList)
	set @isEngDsc = 'N'
	if charindex('ENG',@optList) > 0	set @isEngDsc = 'Y'
	set @isMOQ = 'N'
	if charindex('MOQ',@optList) > 0	set @isMOQ = 'Y'
	set @isExcl = 'N'
	if charindex('EXC',@optList) > 0	set @isExcl = 'Y'
	set @isPV = 'N'
	if charindex('PV',@optList) > 0	set @isPV = 'Y'
	set @isCstInfo = 'N'
	if charindex('CST',@optList) > 0	set @isCstInfo = 'Y'
	
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	begin tran
		--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--
		if @isEngDsc = 'Y' or @isMOQ = 'Y'
		begin
			Update 
				bas
			
			Set
				-- English Description
				bas.ibi_engdsc = case when @isEngDsc = 'Y' then src.ibi_engdsc else bas.ibi_engdsc end , 
				-- MOQ / MOA
				bas.ibi_tirtyp = case when @isMOQ = 'Y' then src.ibi_tirtyp else bas.ibi_tirtyp end, 
				bas.ibi_moqctn = case when @isMOQ = 'Y' then src.ibi_moqctn else bas.ibi_moqctn end,
				bas.ibi_curcde = case when @isMOQ = 'Y' then src.ibi_curcde else bas.ibi_curcde end,
				bas.ibi_moa = case when @isMOQ = 'Y' then src.ibi_moa else bas.ibi_moa end,
				bas.ibi_qty = case when @isMOQ = 'Y' then src.ibi_qty else bas.ibi_qty end,
				bas.ibi_upddat = getdate(),
				bas.ibi_updusr = @userID
			From
				IMBASINF bas, IMBASINF src , #_ITMLST
			where
				bas.ibi_itmno = _itm and
				src.ibi_itmno = @srcItem
			
			select @Err_Idx = @@error, @Row_Idx = @@RowCount
		end
		--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--
		if @Err_Idx = 0 and @isCstInfo = 'Y'
		begin
			set @tmpItem = ''
			set @cstrmk = ''
			set @expdat = '01/01/1900'
			
			select @cstrmk = ici_cstrmk, @expdat = ici_expdat from IMCSTINF where ici_itmno = @srcItem
			
			select @Err_Idx = @@error, @Row_Idx = @@RowCount
			
			Declare cur_CostInfo Cursor
			For 
			select _itm from #_ITMLST
			
			
			open cur_CostInfo
			Fetch next from cur_CostInfo
			into @tmpItem
			
			while @@fetch_status = 0 and @Err_Idx = 0
			begin
				Update
					cst
				Set
					cst.ici_cstrmk = @cstrmk , 
					cst.ici_expdat = @expdat
				From
					IMCSTINF cst
				where
					cst.ici_itmno = @tmpItem

				select @Err_Idx = @@error, @Row_Idx = @@RowCount
				if @Err_Idx = 0 and @Row_Idx = 0
				begin
					insert into IMCSTINF (ici_cocde, ici_itmno, ici_cstrmk, ici_expdat, ici_creusr, ici_updusr, ici_credat, ici_upddat )
					values (@cocde,@tmpItem, @cstrmk, @expdat, @userID, @userID, getdate(), getdate() )

					select @Err_Idx = @@error, @Row_Idx = @@RowCount
				end
				
				Fetch next from cur_CostInfo
				into @tmpItem
			end
			close cur_CostInfo
			deallocate cur_CostInfo
		end
		
		--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--		
		if @Err_Idx  = 0 and @isExcl = 'Y'
		begin
			delete from IMCTYINF where ici_itmno in (select _itm from #_ITMLST)

			select @Err_Idx = @@error, @Row_Idx = @@RowCount

			if (@Err_Idx  = 0 and (select count(1) from IMCTYINF where ici_itmno = @srcItem) > 0 )
			begin
				insert into IMCTYINF (ici_cocde, ici_itmno, ici_ctyseq, ici_ctycde, ici_cusno, ici_valdat, ici_rmk, ici_creusr, ici_updusr, ici_credat, ici_upddat)
				select ici_cocde, _itm, ici_ctyseq, ici_ctycde, ici_cusno, ici_valdat, ici_rmk,@userID, @userID, getdate(), getdate()
				from #_ITMLST
				left join IMCTYINF on ici_itmno = @srcItem
				
				select @Err_Idx = @@error, @Row_Idx = @@RowCount
			end			

			
		end

		--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--		
		/*if @isPV = 'Y'
		begin
			select * from IMVENINF where ivi_itmno = '06A52DA005A06' --@tmpItem
			
			
		end*/
		--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--
	
	if @Err_Idx = 0 
	begin		
		commit tran
		return (0)
	end
	else
	begin
		rollback tran
		return (@Err_Idx)
	end
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
End




GO
GRANT EXECUTE ON [dbo].[sp_update_IMM00008] TO [ERPUSER] AS [dbo]
GO
