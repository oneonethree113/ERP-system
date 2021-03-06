/****** Object:  StoredProcedure [dbo].[sp_select_SCM00006_HDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCM00006_HDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCM00006_HDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/*
=================================================================
Program ID	: sp_select_SCM00006_HDR
Description	: Retrieve SC entries pending approval
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-05-10 	David Yue		SP Created
=================================================================
*/
--sp_select_SCM00006_HDR '','UCPP,EW,GU,HB,HH,HX,PG,TT,UCP','','','','','09/25/2016','10/25/2016','mis'

CREATE  procedure [dbo].[sp_select_SCM00006_HDR]
@cocde		varchar(6),
@cocdelist	varchar(1000),
@cus1nolist	varchar(1000),
@cus2nolist	varchar(1000),
@ordnolist	varchar(1000),
@itmnolist	varchar(1000),
@rvsdatFm	varchar(10),
@rvsdatTo	varchar(10),
@creusr		varchar(30)

as

create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_COCDE (tmp_cocde nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS2NO (tmp_cus2no nvarchar(10)) on [PRIMARY]
create table #TEMP_SCNO (tmp_scno nvarchar(20)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]

create table #TEMP_SCLIST(
 [action]	nvarchar(10),
 soh_cocde	nvarchar(10),
 soh_ordno	nvarchar(20),
 soh_ordsts	nvarchar(10),
 soh_cus1no	nvarchar(10),
 pri_cusnam	nvarchar(200),
 soh_cus2no	nvarchar(10),
 sec_cusnam	nvarchar(200),
 soh_rvsdat	nvarchar(12),
 soh_prctrmflg	nvarchar(10),
 soh_prctrm	nvarchar(200),
 soh_lastprctrm	nvarchar(200),
 soh_paytrmflg	nvarchar(10),
 soh_paytrm	nvarchar(200),
 soh_lastpaytrm	nvarchar(200),
 soh_rplflg	nvarchar(10),
 soh_clsflg	nvarchar(10),
 soh_timstp	int,
 tmp_appflg	nvarchar(10),
 tmp_reason	nvarchar(200))


declare	@fm nvarchar(100), @to nvarchar(100)

declare @strPart nvarchar(1000), @strRemain nvarchar(1000)

set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''


--#TEMP_COCDE
if ltrim(rtrim(@cocdelist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cocdelist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select yco_cocde from SYCOMINF where yco_cocde between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select yco_cocde from SYCOMINF where yco_cocde like @strPart
		end
		else
		begin
			insert into #TEMP_INIT values (@strPart)
		end
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)
		if charindex('~', @strRemain) <> 0 
		begin
			set @fm = ltrim(left(@strRemain, charindex('~', @strRemain)-1))
			set @to = right(@strRemain, len(@strRemain) - charindex('~', @strRemain))
			insert into #TEMP_INIT
			select yco_cocde from SYCOMINF where yco_cocde between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select yco_cocde from SYCOMINF where yco_cocde like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_COCDE
	select distinct tmp_init from #TEMP_INIT
end



--#TEMP_CUS1NO
if ltrim(rtrim(@cus1nolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cus1nolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno like @strPart
		end
		else
		begin
			insert into #TEMP_INIT values (@strPart)
		end
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)
		if charindex('~', @strRemain) <> 0 
		begin
			set @fm = ltrim(left(@strRemain, charindex('~', @strRemain)-1))
			set @to = right(@strRemain, len(@strRemain) - charindex('~', @strRemain))
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CUS1NO
	select distinct tmp_init from #TEMP_INIT
end
else
begin

insert into #TEMP_CUS1NO
select 	distinct cbi_cusno
from CUBASINF (nolock)
left join SYSALREP on ysr_cocde = ' ' and  ysr_code1 = cbi_salrep
where
cbi_custyp = 'P' and cbi_cussts = 'A' and
(exists(select 1 from syusrright where yur_usrid = @creusr  and yur_doctyp = 'SC' and yur_lvl = 0)
	or cbi_saltem in (select yur_para from syusrright where yur_usrid = @creusr and yur_doctyp = 'SC' and yur_lvl = 1)
	or cbi_cusno in (select yur_para from syusrright where yur_usrid = @creusr and yur_doctyp = 'SC' and yur_lvl = 2)
) and cbi_cusno > '50000'
order by cbi_cusno

end

--#TEMP_CUS2NO
if ltrim(rtrim(@cus2nolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cus2nolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno like @strPart
		end
		else
		begin
			insert into #TEMP_INIT values (@strPart)
		end
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)
		if charindex('~', @strRemain) <> 0 
		begin
			set @fm = ltrim(left(@strRemain, charindex('~', @strRemain)-1))
			set @to = right(@strRemain, len(@strRemain) - charindex('~', @strRemain))
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CUS2NO
	select distinct tmp_init from #TEMP_INIT
end
else
begin

	insert into #TEMP_CUS2NO
	select 	distinct cbi_cusno
	from CUBASINF (nolock)
	left join SYSALREP on ysr_cocde = ' ' and  ysr_code1 = cbi_salrep
	where
	cbi_custyp = 'S' and cbi_cussts = 'A' and
	(exists(select 1 from syusrright where yur_usrid = @creusr  and yur_doctyp = 'SC' and yur_lvl = 0)
		or cbi_saltem in (select yur_para from syusrright where yur_usrid = @creusr and yur_doctyp = 'SC' and yur_lvl = 1)
		or cbi_cusno in (select yur_para from syusrright where yur_usrid = @creusr and yur_doctyp = 'SC' and yur_lvl = 2)
	) and cbi_cusno > '50000'
	union 
	select ''
	order by cbi_cusno

end


--#TEMP_SCNO
if ltrim(rtrim(@ordnolist)) <> ''
begin
	delete from #TEMP_INIT
	set @strRemain = @ordnolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select soh_ordno from SCORDHDR (nolock) where soh_ordno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select soh_ordno from SCORDHDR (nolock) where soh_ordno like @strPart
		end
		else
		begin
			insert into #TEMP_INIT values (@strPart)
		end
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)
		if charindex('~', @strRemain) <> 0 
		begin
			set @fm = ltrim(left(@strRemain, charindex('~', @strRemain)-1))
			set @to = right(@strRemain, len(@strRemain) - charindex('~', @strRemain))
			insert into #TEMP_INIT
			select soh_ordno from SCORDHDR where soh_ordno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select soh_ordno from SCORDHDR where soh_ordno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_SCNO
	select distinct tmp_init from #TEMP_INIT
end


--#TEMP_ITMNO
if ltrim(rtrim(@itmnolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @itmnolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno like @strPart
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno like @strPart
		end
		else
		begin
			insert into #TEMP_INIT values (@strPart)
		end
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)
		if charindex('~', @strRemain) <> 0 
		begin
			set @fm = ltrim(left(@strRemain, charindex('~', @strRemain)-1))
			set @to = right(@strRemain, len(@strRemain) - charindex('~', @strRemain))
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock)  where ibi_itmno like @strRemain
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_ITMNO
	select distinct tmp_init from #TEMP_INIT
end

declare @flg_cocde_table char(1), 
@flg_cus1no_table char(1),
@flg_cus2no_table char(1),
@flg_scno_table char(1),
@flg_itmno_table char(1)

if (select count(*) from #TEMP_COCDE) >= 1
	set @flg_cocde_table = 'Y'
else
	set @flg_cocde_table = 'N'

if (select count(*) from #TEMP_CUS1NO) >= 1
	set @flg_cus1no_table = 'Y'
else
	set @flg_cus1no_table = 'N'

if (select count(*) from #TEMP_CUS2NO) >= 1
	set @flg_cus2no_table = 'Y'
else
	set @flg_cus2no_table = 'N'

if (select count(*) from #TEMP_SCNO) >= 1
	set @flg_scno_table = 'Y'
else
	set @flg_scno_table = 'N'

if (select count(*) from #TEMP_ITMNO) >= 1
	set @flg_itmno_table = 'Y'
else
	set @flg_itmno_table = 'N'


insert into #TEMP_SCLIST
select distinct 'W' as 'action',
soh_cocde,
soh_ordno,
soh_ordsts,
soh_cus1no,
isnull(pri.cbi_cusno + ' - ' + pri.cbi_cussna,'') as 'pri_cusnam',
soh_cus2no,
isnull(sec.cbi_cusno + ' - ' + sec.cbi_cussna,'') as 'sec_cusnam',
convert(varchar(12),soh_rvsdat, 101) as 'soh_rvsdat',
soh_prctrmflg,
soh_prctrm + ' - ' + prc1.ysi_dsc as 'soh_prctrm',
soh_lastprctrm + ' - ' + prc2.ysi_dsc as 'soh_lastprctrm',
soh_paytrmflg,
soh_paytrm + ' - ' + pay1.ysi_dsc as 'soh_paytrm',
soh_lastpaytrm + ' - ' + pay2.ysi_dsc as 'soh_lastpaytrm',
soh_rplflg,
soh_clsflg,
cast(soh_timstp as int) as 'soh_timstp',
'Pass',''
from SCORDHDR (nolock)
left join SCORDDTL (nolock) on sod_ordno = soh_ordno
left join CUBASINF pri (nolock) on pri.cbi_cusno = soh_cus1no
left join CUBASINF sec (nolock) on sec.cbi_cusno = soh_cus2no
left join SYSETINF pay1 (nolock) on pay1.ysi_typ = '04' and pay1.ysi_cde = soh_paytrm
left join SYSETINF pay2 (nolock) on pay2.ysi_typ = '04' and pay2.ysi_cde = soh_lastpaytrm
left join SYSETINF prc1 (nolock) on prc1.ysi_typ = '03' and prc1.ysi_cde = soh_prctrm
left join SYSETINF prc2 (nolock) on prc2.ysi_typ = '03' and prc2.ysi_cde = soh_lastprctrm
where 
soh_rvsdat between @rvsdatFm + ' 00:00' and @rvsdatTo + ' 23:59'
and soh_ordsts = 'HLD'
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and soh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and soh_ordno in (select tmp_scno from #TEMP_SCNO (nolock))))


-- Check for user edit SC list
update #TEMP_SCLIST set tmp_appflg = 'Fail', tmp_reason = 'SC updated by approver!' from #TEMP_SCLIST a, UCPERPDB_AUD..SCORDHDR_AUD b where a.soh_cocde = b.soh_cocde and a.soh_ordno = b.soh_ordno and (soh_creusr = @creusr or soh_updusr = @creusr)
and b.soh_credat > '2016-12-28'
update #TEMP_SCLIST set tmp_appflg = 'Fail', tmp_reason = 'SC updated by approver!' from #TEMP_SCLIST a, UCPERPDB_AUD_2016..SCORDHDR_AUD b where a.soh_cocde = b.soh_cocde and a.soh_ordno = b.soh_ordno and (soh_creusr = @creusr or soh_updusr = @creusr)
and b.soh_credat > '2016-12-28'

select *,'W' as 'action_selall',
soh_prctrmflg as 'soh_prctrmflg_selall',
soh_paytrmflg as 'soh_paytrmflg_selall',
soh_rplflg as 'soh_rplflg_selall',
soh_clsflg as 'soh_clsflg_selall',
'' as 'keepselect'
 from #TEMP_SCLIST
order by soh_ordno



drop table #TEMP_INIT
drop table #TEMP_COCDE
drop table #TEMP_CUS1NO
drop table #TEMP_CUS2NO
drop table #TEMP_SCNO
drop table #TEMP_ITMNO
drop table #TEMP_SCLIST





















/*

declare
@cocdeSQL	varchar(2000),	@cus1noSQL	varchar(2000),	@cus2noSQL	varchar(2000),
@ordnoSQL	varchar(2000),	@itmnoSQL	varchar(2000),	@issdatSQL	varchar(400)

declare
@i 		int,		@start 		varchar(20),	@end 		nvarchar(20),
@value		varchar(20)

declare
@header		varchar(2000),	@conditionSQL	varchar(5500),	@footer		varchar(100),
@statementSQL	varchar(8000)



-- Process Company Code Condition --
if ltrim(rtrim(@cocdelist)) <> ''
begin
	set @cocdeSQL = ''
	set @i = 0
	
	while charindex(',',@cocdelist) <> 0
	begin
		set @i = charindex(',',@cocdelist)
		if @i = 0 and charindex(@cocdelist,@cocdeSQL) = 0
			set @i = len(@cocdelist)
		set @value = substring(@cocdelist, 0, @i)
		set @cocdelist = substring(@cocdelist,@i+1,len(@cocdelist)-@i)
		if ltrim(rtrim(@value)) <> ''
		begin
			if charindex('~',@value) > 0
			begin
				set @i = charindex('~',@value)
				set @start = substring(@value, 0, @i)
				set @end = substring(@value, @i+1,len(@value))
				set @cocdeSQL = @cocdeSQL + case len(@cocdeSQL) when 0 then '' else ' or soh_cocde ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @cocdeSQL = @cocdeSQL + case len(@cocdeSQL) when 0 then '' else ' or soh_cocde ' end + '= ''' + @value + ''''
			end
		end
	end

	if ltrim(rtrim(@cocdelist)) <> ''
	begin
		if charindex('~',@cocdelist) > 0
		begin
			set @i = charindex('~',@cocdelist)
			set @start = substring(@cocdelist, 0, @i)
			set @end = substring(@cocdelist, @i+1,len(@cocdelist))
			set @cocdeSQL = @cocdeSQL + case len(@cocdeSQL) when 0 then '' else ' or soh_cocde ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @cocdeSQL = @cocdeSQL + case len(@cocdeSQL) when 0 then '' else ' or soh_cocde ' end + '= ''' + @cocdelist + ''''
		end
	end
	
	set @cocdeSQL = 'soh_cocde ' + @cocdeSQL
end -- if ltrim(rtrim(@cocdelist)) <> ''


-- Process Primary Customer Condition --
if ltrim(rtrim(@cus1nolist)) <> ''
begin
	set @cus1noSQL = ''
	set @i = 0
	
	while charindex(',',@cus1nolist) <> 0
	begin
		set @i = charindex(',',@cus1nolist)
		if @i = 0 and charindex(@cus1nolist,@cus1noSQL) = 0
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
				set @cus1noSQL = @cus1noSQL + case len(@cus1noSQL) when 0 then '' else ' or soh_cus1no ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @cus1noSQL = @cus1noSQL + case len(@cus1noSQL) when 0 then '' else ' or soh_cus1no ' end + '= ''' + @value + ''''
			end
		end
	end
	
	if charindex(@cus1nolist, @cus1noSQL) = 0
	begin
		if charindex('~',@cus1nolist) > 0
		begin
			set @i = charindex('~',@cus1nolist)
			set @start = substring(@cus1nolist, 0, @i)
			set @end = substring(@cus1nolist, @i+1,len(@cus1nolist))
			set @cus1noSQL = @cus1noSQL + case len(@cus1noSQL) when 0 then '' else ' or soh_cus1no ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @cus1noSQL = @cus1noSQL + case len(@cus1noSQL) when 0 then '' else ' or soh_cus1no ' end + '= ''' + @cus1nolist + ''''
		end
	end
	
	set @cus1noSQL = 'soh_cus1no ' + @cus1noSQL
end -- if ltrim(rtrim(@cus1nolist)) <> ''

-- Process Secondary Customer Condition --
if ltrim(rtrim(@cus2nolist)) <> ''
begin
	set @cus2noSQL = ''
	set @i = 0
	
	while charindex(',',@cus2nolist) <> 0
	begin
		set @i = charindex(',',@cus2nolist)
		if @i = 0 and charindex(@cus2nolist,@cus2noSQL) = 0
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
				set @cus2noSQL = @cus2noSQL + case len(@cus2noSQL) when 0 then '' else ' or soh_cus2no ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @cus2noSQL = @cus2noSQL + case len(@cus2noSQL) when 0 then '' else ' or soh_cus2no ' end + '= ''' + @value + ''''
			end
		end
	end
	
	if charindex(@cus2nolist, @cus2noSQL) = 0
	begin
		if charindex('~',@cus2nolist) > 0
		begin
			set @i = charindex('~',@cus2nolist)
			set @start = substring(@cus2nolist, 0, @i)
			set @end = substring(@cus2nolist, @i+1,len(@cus2nolist))
			set @cus2noSQL = @cus2noSQL + case len(@cus2noSQL) when 0 then '' else ' or soh_cus2no ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @cus2noSQL = @cus2noSQL + case len(@cus2noSQL) when 0 then '' else ' or soh_cus2no ' end + '= ''' + @cus2nolist + ''''
		end
	end
	
	set @cus2noSQL = 'soh_cus2no ' + @cus2noSQL
end -- if ltrim(rtrim(@cus2nolist)) <> ''

-- Process SC Order No Condition --
if ltrim(rtrim(@ordnolist)) <> ''
begin 
	set @ordnoSQL = ''
	set @i = 0
	
	while charindex(',',@ordnolist) <> 0
	begin
		set @i = charindex(',',@ordnolist)
		if @i = 0 and charindex(@ordnolist,@ordnoSQL) = 0
			set @i = len(@ordnolist)
		set @value = substring(@ordnolist, 0, @i)
		set @ordnolist = substring(@ordnolist,@i+1,len(@ordnolist)-@i)
		if ltrim(rtrim(@value)) <> ''
		begin
			if charindex('~',@value) > 0
			begin
				set @i = charindex('~',@value)
				set @start = substring(@value, 0, @i)
				set @end = substring(@value, @i+1,len(@value))
				set @ordnoSQL = @ordnoSQL + case len(@ordnoSQL) when 0 then '' else ' or soh_ordno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @ordnoSQL = @ordnoSQL + case len(@ordnoSQL) when 0 then '' else ' or soh_ordno ' end + '= ''' + @value + ''''
			end
		end
	end
	
	if charindex(@ordnolist, @ordnoSQL) = 0
	begin
		if charindex('~',@ordnolist) > 0
		begin
			set @i = charindex('~',@ordnolist)
			set @start = substring(@ordnolist, 0, @i)
			set @end = substring(@ordnolist, @i+1,len(@ordnolist))
			set @ordnoSQL = @ordnoSQL + case len(@ordnoSQL) when 0 then '' else ' or soh_ordno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @ordnoSQL = @ordnoSQL + case len(@ordnoSQL) when 0 then '' else ' or soh_ordno ' end + '= ''' + @ordnolist + ''''
		end
	end
	
	set @ordnoSQL = 'soh_ordno ' + @ordnoSQL
end -- if ltrim(rtrim(@ordnolist)) <> ''

-- Process Item No Condition --
if ltrim(rtrim(@itmnolist)) <> ''
begin 
	set @itmnoSQL = ''
	set @i = 0
	
	while charindex(',',@itmnolist) <> 0
	begin
		set @i = charindex(',',@itmnolist)
		if @i = 0 and charindex(@itmnolist,@itmnoSQL) = 0
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
				set @itmnoSQL = @itmnoSQL + case len(@itmnoSQL) when 0 then '' else ' or sod_itmno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @itmnoSQL = @itmnoSQL + case len(@itmnoSQL) when 0 then '' else ' or sod_itmno ' end + '= ''' + @value + ''''
			end
		end
	end
	
	if charindex(@itmnolist, @itmnoSQL) = 0
	begin
		if charindex('~',@itmnolist) > 0
		begin
			set @i = charindex('~',@itmnolist)
			set @start = substring(@itmnolist, 0, @i)
			set @end = substring(@itmnolist, @i+1,len(@itmnolist))
			set @itmnoSQL = @itmnoSQL + case len(@itmnoSQL) when 0 then '' else ' or sod_itmno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @itmnoSQL = @itmnoSQL + case len(@itmnoSQL) when 0 then '' else ' or sod_itmno ' end + '= ''' + @itmnolist + ''''
		end
	end
	
	set @itmnoSQL = 'sod_itmno ' + @itmnoSQL
end -- if ltrim(rtrim(@itmnolist)) <> ''

-- Process Issue Date Condition --
if @rvsdatFm <> '' and @rvsdatTo <> ''
begin
	set @issdatSQL = 'soh_rvsdat between ''' + @rvsdatFm + ' 00:00'' and ''' + @rvsdatTo + ' 23:59'''
end -- if @prcCredatFm <> '' and @prcCredatTo <> ''

--select @cocdeSQL, @cus1noSQL, @cus2noSQL, @ordnoSQL, @itmnoSQL, @issdatSQL

-- Concatenate Query Statement --
--set @conditionSQL = 'soh_ordsts = ''HLD'' and sod_apprve = ''W'' and ((sod_ordqty / sod_mtrctn) < sod_moq or round(sod_itmprc, 2, 2) > round(sod_untprc, 2, 2))'
--set @conditionSQL = 'soh_ordsts = ''HLD'' and sod_apprve = ''W'' and ((sod_ordqty / sod_mtrctn) < sod_moq or sod_itmprc > sod_untprc)'
set @conditionSQL = 'soh_ordsts = ''HLD'' '
if @cocdeSQL <> ''
begin
	set @conditionSQL = @conditionSQL + case (len(@conditionSQL)) when 0 then '(' else ' and (' end + @cocdeSQL + ')'
end
if @cus1noSQL <> ''
begin
	set @conditionSQL = @conditionSQL + case (len(@conditionSQL)) when 0 then '(' else ' and (' end + @cus1noSQL + ')'
end
if @cus2noSQL <> ''
begin
	set @conditionSQL = @conditionSQL + case (len(@conditionSQL)) when 0 then '(' else ' and (' end + @cus2noSQL + ')'
end
if @ordnoSQL <> ''
begin
	set @conditionSQL = @conditionSQL + case (len(@conditionSQL)) when 0 then '(' else ' and (' end + @ordnoSQL + ')'
end
if @itmnoSQL <> ''
begin
	set @conditionSQL = @conditionSQL + case (len(@conditionSQL)) when 0 then '(' else ' and (' end + @itmnoSQL + ')'
end
if @issdatSQL <> ''
begin
	set @conditionSQL = @conditionSQL + case (len(@conditionSQL)) when 0 then '(' else ' and (' end + @issdatSQL + ')'
end

--print @conditionSQL

-- Construct SQL Statement
set @header = 'select distinct
 ''W'' as ''action'',
 soh_cocde,
 soh_ordno,
 soh_ordsts,
 soh_cus1no,
 isnull(pri.cbi_cusno + '' - '' + pri.cbi_cussna,'''') as ''pri_cusnam'',
 soh_cus2no,
 isnull(sec.cbi_cusno + '' - '' + sec.cbi_cussna,'''') as ''sec_cusnam'',
 convert(varchar(12),soh_rvsdat, 101) as ''soh_rvsdat'',
 soh_prctrmflg,
 soh_prctrm,
 soh_lastprctrm,
 soh_paytrmflg,
 soh_paytrm + '' - '' + pay1.ysi_dsc as ''soh_paytrm'',
 soh_lastpaytrm + '' - '' + pay2.ysi_dsc as ''soh_lastpaytrm'',
 soh_rplflg,
 soh_clsflg,
 cast(soh_timstp as int) as ''soh_timstp''
 from SCORDHDR (nolock)
 left join SCORDDTL (nolock) on sod_ordno = soh_ordno
 left join CUBASINF pri (nolock) on pri.cbi_cusno = soh_cus1no
 left join CUBASINF sec (nolock) on sec.cbi_cusno = soh_cus2no
 left join SYSETINF pay1 (nolock) on pay1.ysi_typ = ''04'' and pay1.ysi_cde = soh_paytrm
 left join SYSETINF pay2 (nolock) on pay2.ysi_typ = ''04'' and pay2.ysi_cde = soh_lastpaytrm
 where'
set @footer = 'order by soh_ordno'

set @statementSQL = @header + ' ' + @conditionSQL + ' ' + @footer

--print @statementSQL

-- Execute Constructed SQL Query
exec(@statementSQL)
--print @statementSQL



*/



GO
GRANT EXECUTE ON [dbo].[sp_select_SCM00006_HDR] TO [ERPUSER] AS [dbo]
GO
