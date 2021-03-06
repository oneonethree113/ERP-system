/****** Object:  StoredProcedure [dbo].[sp_list_IMR00035]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMR00035]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMR00035]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












/*
=========================================================
Program ID	: 	sp_list_IMR00035
Description   	: 	
Programmer  	: 	David Yue
Date Created	:	2012-08-21
=========================================================
 Modification History                                    
=========================================================
2012-08-29	David Yue	Access Control for Internal/External User Group
=========================================================     
*/

CREATE       PROCEDURE [dbo].[sp_list_IMR00035]
@cocde		nvarchar(6),	@itmnolist	nvarchar(1000),	@dateFrom	nvarchar(10),
@dateTo		nvarchar(10),	@cus1nolist	nvarchar(1000),	@cus2nolist	nvarchar(1000),
@vennolist	nvarchar(1000),		@rptmode	nvarchar(4),	@creusr		nvarchar(30)

AS

set nocount on

declare
@itmnoqry	nvarchar(2000),	@i		int,		@value		nvarchar(50),
@start		nvarchar(20),	@end		nvarchar(20),	@credatqry	nvarchar(150),
@condition	nvarchar(2000),	@modqry		nvarchar(150),@cus1qry 	varchar(2000),
@cus2qry	varchar(2000)	,@dvqry	varchar(2000)

set @itmnoqry = ''
set @modqry = ''
set @credatqry = ''
set @condition = ''

-- Process Item Number Query --
if ltrim(rtrim(@itmnolist)) <> ''
begin 
	set @itmnoqry = ''
	set @i = 0
	
	while charindex(',',@itmnolist) <> 0
	begin
		set @i = charindex(',',@itmnolist)
		if @i = 0 and charindex(@itmnolist,@itmnoqry) = 0
			set @i = len(@itmnolist)
		set @value = substring(@itmnolist, 0, @i)
		set @itmnolist = substring(@itmnolist,@i+1,len(@itmnolist)-@i)
		if ltrim(rtrim(@value)) <> ''
		begin
			if charindex('~',@value) > 0
			begin
				set @i = charindex('~',@value)
				set @start = substring(@value, 0, @i)
				set @end = substring(@value, @i+1,len(@value))
				set @itmnoqry = @itmnoqry + case len(@itmnoqry) when 0 then '' else ' or imu_itmno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @itmnoqry = @itmnoqry + case len(@itmnoqry) when 0 then '' else ' or imu_itmno ' end + '= ''' + @value + ''''
			end
		end
	end
	
	if charindex(@itmnolist, @itmnoqry) = 0
	begin
		if charindex('~',@itmnolist) > 0
		begin
			set @i = charindex('~',@itmnolist)
			set @start = substring(@itmnolist, 0, @i)
			set @end = substring(@itmnolist, @i+1,len(@itmnolist))
			set @itmnoqry = @itmnoqry + case len(@itmnoqry) when 0 then '' else ' or imu_itmno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @itmnoqry = @itmnoqry + case len(@itmnoqry) when 0 then '' else ' or imu_itmno ' end + '= ''' + @itmnolist + ''''
		end
	end
	
	set @itmnoqry = 'imu_itmno ' + @itmnoqry
end -- if ltrim(rtrim(@itmnolist)) <> ''
---------------

-- Process cus1no Query --
 if ltrim(rtrim(@cus1nolist)) <> ''
begin
	set @cus1qry = ''
	set @i = 0
	
	while charindex(',',@cus1nolist) <> 0
	begin
		set @i = charindex(',',@cus1nolist)
		if @i = 0 and charindex(@cus1nolist,@cus1qry) = 0
			set @i = len(@cus1nolist)
		set @value = substring(@cus1nolist, 0, @i)
		set @cus1nolist = substring(@cus1nolist,@i+1,len(@cus1nolist)-@i)
		if ltrim(rtrim(@value)) <> ''
		begin
			if charindex('~',@value) > 0
			begin
				set @i = charindex('~',@value)
				set @start = substring(@value, 0, @i)
				set @end = substring(@value, @i+1,len(@value))
				set @cus1qry = @cus1qry + case len(@cus1qry) when 0 then '' else ' or imu_cus1no ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @cus1qry = @cus1qry + case len(@cus1qry) when 0 then '' else ' or imu_cus1no ' end + '= ''' + @value + ''''
			end
		end
	end
	
	if charindex(@cus1nolist, @cus1qry) = 0
	begin
		if charindex('~',@cus1nolist) > 0
		begin
			set @i = charindex('~',@cus1nolist)
			set @start = substring(@cus1nolist, 0, @i)
			set @end = substring(@cus1nolist, @i+1,len(@cus1nolist))
			set @cus1qry = @cus1qry + case len(@cus1qry) when 0 then '' else ' or imu_cus1no ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @cus1qry = @cus1qry + case len(@cus1qry) when 0 then '' else ' or imu_cus1no ' end + '= ''' + @cus1nolist + ''''
		end
	end
	
	set @cus1qry = 'imu_cus1no ' + @cus1qry
end 

--------------------cus1no part end
----------

-- Process cus2no Query --
begin

	if ltrim(rtrim(@cus2nolist)) <> ''
	begin
		set @cus2qry = ''
		set @i = 0
	
		while charindex(',',@cus2nolist) <> 0
		begin
			set @i = charindex(',',@cus2nolist)
			if @i = 0 and charindex(@cus2nolist,@cus2qry) = 0
				set @i = len(@cus2nolist)
			set @value = substring(@cus2nolist, 0, @i)
			set @cus2nolist = substring(@cus2nolist,@i+1,len(@cus2nolist)-@i)
			if ltrim(rtrim(@value)) <> ''
			begin
				if charindex('~',@value) > 0
				begin
					set @i = charindex('~',@value)
					set @start = substring(@value, 0, @i)
					set @end = substring(@value, @i+1,len(@value))
					set @cus2qry = @cus2qry + case len(@cus2qry) when 0 then '' else ' or imu_cus2no ' end + 'between ''' + @start + ''' and ''' + @end + ''''
				end
				else
				begin
					set @cus2qry = @cus2qry + case len(@cus2qry) when 0 then '' else ' or imu_cus2no ' end + '= ''' + @value + ''''
				end
			end
		end
	
		if charindex(@cus2nolist, @cus2qry) = 0
		begin
			if charindex('~',@cus2nolist) > 0
			begin
				set @i = charindex('~',@cus2nolist)
				set @start = substring(@cus2nolist, 0, @i)
				set @end = substring(@cus2nolist, @i+1,len(@cus2nolist))
				set @cus2qry = @cus2qry + case len(@cus2qry) when 0 then '' else ' or imu_cus2no ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @cus2qry = @cus2qry + case len(@cus2qry) when 0 then '' else ' or imu_cus2no ' end + '= ''' + @cus2nolist + ''''
			end
		end
	
		set @cus2qry = '  imu_cus2no ' + @cus2qry
	end -- if ltrim(rtrim(@cus2nolist)) <> ''
	--select @cus2qry
	--select * from #tempCus2no
end
---------------------------
----------------------cus2no part end

-- Process venno Query --
begin

	if ltrim(rtrim(@vennolist)) <> ''
	begin
		set @dvqry = ''
		set @i = 0
	
		while charindex(',',@vennolist) <> 0
		begin
			set @i = charindex(',',@vennolist)
			if @i = 0 and charindex(@vennolist,@dvqry) = 0
				set @i = len(@vennolist)
			set @value = substring(@vennolist, 0, @i)
			set @vennolist = substring(@vennolist,@i+1,len(@vennolist)-@i)
			if ltrim(rtrim(@value)) <> ''
			begin
				if charindex('~',@value) > 0
				begin
					set @i = charindex('~',@value)
					set @start = substring(@value, 0, @i)
					set @end = substring(@value, @i+1,len(@value))
					set @dvqry = @dvqry + case len(@dvqry) when 0 then '' else ' or imu_venno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
				end
				else
				begin
					set @dvqry = @dvqry + case len(@dvqry) when 0 then '' else ' or imu_venno ' end + '= ''' + @value + ''''
				end
			end
		end
	
		if charindex(@vennolist, @dvqry) = 0
		begin
			if charindex('~',@vennolist) > 0
			begin
				set @i = charindex('~',@vennolist)
				set @start = substring(@vennolist, 0, @i)
				set @end = substring(@vennolist, @i+1,len(@vennolist))
				set @dvqry = @dvqry + case len(@dvqry) when 0 then '' else ' or imu_venno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @dvqry = @dvqry + case len(@dvqry) when 0 then '' else ' or imu_venno ' end + '= ''' + @vennolist + ''''
			end
		end
	
		set @dvqry = ' imu_venno ' + @dvqry
	end -- if ltrim(rtrim(@vennolist)) <> ''
	--select @dvqry

	--select * from #tempVENno
end
---------------------------
----------------------venno part end
-- Process Report Mode Query --
if ltrim(rtrim(@rptmode)) = 'INT'
begin
	set @modqry = 'imu_prdven between ''A'' and ''Z'''
end
else if ltrim(rtrim(@rptmode)) = 'EXT'
begin
	set @modqry = 'imu_prdven between ''1'' and ''9999'''
end
else if ltrim(rtrim(@rptmode)) = 'ALL'
begin
	set @modqry = ''
end

-- Process Create Date Query --
if @dateFrom <> '' and @dateTo <> ''
begin
	set @credatqry = 'imu_credat between ''' + substring(@dateFrom,7,4) + '-' + substring(@dateFrom,1,2) + '-' + substring(@dateFrom,4,2) + ' 00:00.00'' and ''' +
				substring(@dateTo,7,4) + '-' + substring(@dateTo,1,2) + '-' + substring(@dateTo,4,2) + ' 23:59.99'''
end -- if @dateFrom <> '' and @dateTo <> ''

-- Concatenate Query Statement --
if @itmnoqry <> ''
begin
	set @condition = '('+@itmnoqry+')'

	--test 
--	select @condition as '1'

end
if @modqry <> ''
begin
	set @condition = @condition + case (len(@condition)) when 0 then '(' else ' and (' end + @modqry + ')'
--	select @condition as '11'

end
if @credatqry <> ''
begin
	set @condition = @condition + case (len(@condition)) when 0 then '(' else ' and (' end + @credatqry + ')'
--	select @condition as '111'

end

if @cus1qry <> ''
begin
	set @condition = @condition + case (len(@condition)) when 0 then '(' else ' and (' end + @cus1qry + ')'
--	select @condition as '111'

end
if @cus2qry <> ''
begin
	set @condition = @condition + case (len(@condition)) when 0 then '(' else ' and (' end + @cus2qry + ')'
--	select @condition as '111'

end
if @dvqry <> ''
begin
	set @condition = @condition + case (len(@condition)) when 0 then '(' else ' and ( ' end + @dvqry + ')'
--	select @condition as '111'

end
declare @header nvarchar(3000)
set @header = 'select imu_itmno,
	imu_typ,
	imu_venno,
	imu_prdven,
	imu_pckunt,
	imu_inrqty,
	imu_mtrqty,
	imu_cft,
	imu_cus1no,
	imu_cus2no,
	imu_ftyprctrm,
	imu_hkprctrm,
	imu_trantrm,
	convert(nvarchar(10),imu_chgdat,101) as ''imu_chgdat'',
	imu_chgreason,
	convert(nvarchar(10),imu_effdat_before,101) as ''imu_effdat_before'',
	convert(nvarchar(10),imu_expdat_before,101) as ''imu_expdat_before'',
	imu_curcde_before,
	imu_ftycst_before,
	imu_ftycstA_before,
	imu_ftycstB_before,
	imu_ftycstC_before,
	imu_ftycstD_before,
	imu_ftycstE_before,
	imu_ftycstTran_before,
	imu_ftycstPack_before,
	imu_ftyprc_before,
	imu_ftyprcA_before,
	imu_ftyprcB_before,
	imu_ftyprcC_before,
	imu_ftyprcD_before,
	imu_ftyprcE_before,
	imu_ftyprcTran_before,
	imu_ftyprcPack_before,
	imu_bomcst_before,
	imu_ttlcst_before,
	imu_negprc_before,
	(imu_fmlopt_before + '' - '' + fml_before.yfi_fml) as ''imu_fmlopt_before'',
	imu_bcurcde_before,
	imu_itmprc_before,
	imu_bomprc_before,
	imu_basprc_before,
	imu_period_before,
	convert(nvarchar(10),imu_cstchgdat_before,101) as ''imu_cstchgdat_before'',
	convert(nvarchar(10),imu_effdat_after,101) as ''imu_effdat_after'',
	convert(nvarchar(10),imu_expdat_after,101) as ''imu_expdat_after'',
	imu_curcde_after,
	imu_ftycst_after,
	imu_ftycstA_after,
	imu_ftycstB_after,
	imu_ftycstC_after,
	imu_ftycstD_after,
	imu_ftycstE_after,
	imu_ftycstTran_after,
	imu_ftycstPack_after,
	imu_ftyprc_after,
	imu_ftyprcA_after,
	imu_ftyprcB_after,
	imu_ftyprcC_after,
	imu_ftyprcD_after,
	imu_ftyprcE_after,
	imu_ftyprcTran_after,
	imu_ftyprcPack_after,
	imu_bomcst_after,
	imu_ttlcst_after,
	imu_negprc_after,
	(imu_fmlopt_after + '' - '' + fml_after.yfi_fml) as ''imu_fmlopt_after'',
	imu_bcurcde_after,
	imu_itmprc_after,
	imu_bomprc_after,
	imu_basprc_after,
	imu_period_after,
	convert(nvarchar(10),imu_cstchgdat_after,101) as ''imu_cstchgdat_after''
from	IMPRCCHG 
	left join SYFMLINF fml_before on fml_before.yfi_fmlopt = isnull(imu_fmlopt_before,''B01'')
	left join  SYFMLINF fml_after on fml_after.yfi_fmlopt = imu_fmlOpt_after 
	where 1=1 and
	'

declare @sql nvarchar(4000)
set @sql = @header + @condition + ' order by imu_itmno, imu_pckunt, imu_inrqty, imu_mtrqty, imu_venno, imu_prdven, imu_cus1no, imu_cus2no, imu_ftyprctrm, imu_hkprctrm, imu_trantrm, imu_credat'

--select  @header as 'test'
--select @sql
exec(@sql)

set nocount off














GO
GRANT EXECUTE ON [dbo].[sp_list_IMR00035] TO [ERPUSER] AS [dbo]
GO
