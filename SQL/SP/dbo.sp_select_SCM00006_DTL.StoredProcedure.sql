/****** Object:  StoredProcedure [dbo].[sp_select_SCM00006_DTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCM00006_DTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCM00006_DTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/*
=================================================================
Program ID	: sp_select_SCM00006_DTL
Description	: Retrieve SC Detail entries pending approval
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-05-10 	David Yue		SP Created
2014-04-28	David Yue		Added Mininum Price
=================================================================
*/
--sp_select_SCM00006_DTL '','UCPP,EW,GU,HB,HH,HX,PG,TT,UCP','','','','','09/25/2016','10/25/2016','mis'


CREATE  procedure [dbo].[sp_select_SCM00006_DTL]
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

create table #TEMP_SCDTLLIST(
[action]	nvarchar(10),
sod_cocde	nvarchar(10),
sod_ordno	nvarchar(20),
soh_ordsts	nvarchar(10),
sod_cus1no	nvarchar(10),
pri_cusnam	nvarchar(200),
sod_cus2no	nvarchar(10),
sec_cusnam	nvarchar(200),
soh_rvsdat	nvarchar(12),
sod_ordseq	int,
sod_itmno	nvarchar(20),
sod_colcde	nvarchar(50),
sod_pckunt	nvarchar(10),
sod_inrctn	int,
sod_mtrctn	int,
sod_cft		numeric(13,4),
packing		nvarchar(200),
below_moqmoa	nvarchar(20),
below_basprc	nvarchar(20),
sod_moqmoaflg	nvarchar(10),
sod_ordqty	int,
ordctn		int,
sod_moq		int,
sod_chguntprcflg	nvarchar(10),
sod_belprcflg	nvarchar(10),
sod_onetimeflg	nvarchar(10),
sod_curcde	nvarchar(10),
basprc		numeric(13,4),
selprc		numeric(13,4),
selprc_org		numeric(13,4),
sod_chgftycstflg	nvarchar(10),
sod_fcurcde	nvarchar(10),
sod_ftycst	numeric(13,4),
sod_ftycst_org	numeric(13,4),
sod_dvftycst	numeric(13,4),
sod_dvftycst_org	numeric(13,4),
sod_timstp	int,
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



insert into #TEMP_SCDTLLIST
select
case sod_moqmoaflg when 'W' then 'W' else
	case sod_onetimeflg when 'W' then 'W' else
		case sod_belprcflg when 'W' then 'W' else
			case sod_chgftycstflg when 'W' then 'W' else
				case sod_chguntprcflg when 'W' then 'W' else 'X' end 
			end
		end
	end
end as 'action',
sod_cocde,
sod_ordno,
soh_ordsts,
sod_cus1no,
isnull(pri.cbi_cusno + ' - ' + pri.cbi_cussna,'') as 'pri_cusnam',
sod_cus2no,
isnull(sec.cbi_cusno + ' - ' + sec.cbi_cussna,'') as 'sec_cusnam',
convert(varchar(12),soh_rvsdat, 101) as 'soh_rvsdat',
sod_ordseq,
sod_itmno,
sod_colcde,
sod_pckunt,
sod_inrctn,
sod_mtrctn,
sod_cft,
sod_pckunt + ' / ' + cast(sod_inrctn as varchar(10)) + ' / ' + cast(sod_mtrctn as varchar(10)) + ' / ' --+ cast(sod_cft as varchar(10)) 
+ sod_ftyprctrm + ' / ' + sod_hkprctrm as 'packing',
case when (sod_ordqty / sod_mtrctn) < sod_moq then 'Y' else 'N' end as 'below_moqmoa',
case when sod_itmprc <> sod_basprc and sod_itmprc > 0 then case when sod_itmprc > sod_untprc then 'MIN' else 'N' end else case when round(sod_itmprc,2,2) > round(sod_untprc,2,2) then 'BASIC' else 'N' end end as 'below_basprc',
sod_moqmoaflg,
sod_ordqty,
sod_ordqty / sod_mtrctn as 'ordctn',
sod_moq,
sod_chguntprcflg,
sod_belprcflg,
sod_onetimeflg,
sod_curcde,
sod_itmprc as 'basprc',
sod_untprc as 'selprc',
sod_untprc_org as 'selprc_org',
sod_chgftycstflg,
sod_fcurcde,
sod_ftycst,
sod_ftycst_org,
sod_dvftycst,
sod_dvftycst_org,
cast(sod_timstp as int) as 'sod_timstp',
'Pass',''
from SCORDHDR (nolock)
left join SCORDDTL (nolock) on sod_ordno = soh_ordno
left join CUBASINF pri (nolock) on pri.cbi_cusno = sod_cus1no
left join CUBASINF sec (nolock) on sec.cbi_cusno = sod_cus2no
where
soh_rvsdat between @rvsdatFm + ' 00:00' and  @rvsdatTo + ' 23:59'
and soh_ordsts = 'HLD' --and (sod_moqmoaflg = 'W' or sod_onetimeflg = 'W' or sod_belprcflg = 'W' or sod_chgftycstflg = 'W' or sod_chguntprcflg = 'W') 
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and soh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and soh_ordno in (select tmp_scno from #TEMP_SCNO (nolock))))


-- Check for user edit SC list
update #TEMP_SCDTLLIST set tmp_appflg = 'Fail', tmp_reason = 'SC updated by approver!' from #TEMP_SCDTLLIST a, UCPERPDB_AUD..SCORDDTL_AUD b where a.sod_cocde = b.sod_cocde and a.sod_ordno = b.sod_ordno and a.sod_ordseq = b.sod_ordseq and (b.sod_creusr = @creusr or b.sod_updusr = @creusr)
and b.sod_credat > '2016-12-28'

update #TEMP_SCDTLLIST set tmp_appflg = 'Fail', tmp_reason = 'SC updated by approver!' from #TEMP_SCDTLLIST a, UCPERPDB_AUD_2016..SCORDDTL_AUD b where a.sod_cocde = b.sod_cocde and a.sod_ordno = b.sod_ordno and a.sod_ordseq = b.sod_ordseq and (b.sod_creusr = @creusr or b.sod_updusr = @creusr)
and b.sod_credat > '2016-12-28'


select *,
case sod_moqmoaflg when 'W' then 'W' else
	case sod_onetimeflg when 'W' then 'W' else
		case sod_belprcflg when 'W' then 'W' else
			case sod_chgftycstflg when 'W' then 'W' else
				case sod_chguntprcflg when 'W' then 'W' else 'X' end 
			end
		end
	end
end as 'action_selall',
sod_moqmoaflg as 'sod_moqmoaflg_selall',
sod_chguntprcflg as 'sod_chguntprcflg_selall',
sod_belprcflg as 'sod_belprcflg_selall',
sod_onetimeflg as 'sod_onetimeflg_selall',
sod_chgftycstflg as 'sod_chgftycstflg_selall',
'' as 'keepselect' from #TEMP_SCDTLLIST
order by sod_ordno, sod_ordseq














drop table #TEMP_INIT
drop table #TEMP_COCDE
drop table #TEMP_CUS1NO
drop table #TEMP_CUS2NO
drop table #TEMP_SCNO
drop table #TEMP_ITMNO
drop table #TEMP_SCDTLLIST

/*



















declare
@cocdeSQL	varchar(2000),	@cus1noSQL	varchar(2000),	@cus2noSQL	varchar(2000),
@ordnoSQL	varchar(2000),	@itmnoSQL	varchar(2000),	@rvsdatSQL	varchar(400)

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
				set @cocdeSQL = @cocdeSQL + case len(@cocdeSQL) when 0 then '' else ' or sod_cocde ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @cocdeSQL = @cocdeSQL + case len(@cocdeSQL) when 0 then '' else ' or sod_cocde ' end + '= ''' + @value + ''''
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
			set @cocdeSQL = @cocdeSQL + case len(@cocdeSQL) when 0 then '' else ' or sod_cocde ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @cocdeSQL = @cocdeSQL + case len(@cocdeSQL) when 0 then '' else ' or sod_cocde ' end + '= ''' + @cocdelist + ''''
		end
	end
	
	set @cocdeSQL = 'sod_cocde ' + @cocdeSQL
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
				set @ordnoSQL = @ordnoSQL + case len(@ordnoSQL) when 0 then '' else ' or sod_ordno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @ordnoSQL = @ordnoSQL + case len(@ordnoSQL) when 0 then '' else ' or sod_ordno ' end + '= ''' + @value + ''''
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
			set @ordnoSQL = @ordnoSQL + case len(@ordnoSQL) when 0 then '' else ' or sod_ordno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @ordnoSQL = @ordnoSQL + case len(@ordnoSQL) when 0 then '' else ' or sod_ordno ' end + '= ''' + @ordnolist + ''''
		end
	end
	
	set @ordnoSQL = 'sod_ordno ' + @ordnoSQL
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
	set @rvsdatSQL = 'soh_rvsdat between ''' + @rvsdatFm + ' 00:00'' and ''' + @rvsdatTo + ' 23:59'''
end -- if @prcCredatFm <> '' and @prcCredatTo <> ''

--select @cocdeSQL, @cus1noSQL, @cus2noSQL, @ordnoSQL, @itmnoSQL, @rvsdatSQL

-- Concatenate Query Statement --
--set @conditionSQL = 'soh_ordsts = ''HLD'' and sod_apprve = ''W'' and ((sod_ordqty / sod_mtrctn) < sod_moq or round(sod_itmprc, 2, 2) > round(sod_untprc, 2, 2))'
--set @conditionSQL = 'soh_ordsts = ''HLD'' and sod_apprve = ''W'' and ((sod_ordqty / sod_mtrctn) < sod_moq or sod_itmprc > sod_untprc)'
set @conditionSQL = 'soh_ordsts = ''HLD'' and (sod_moqmoaflg = ''W'' or sod_onetimeflg = ''W'' or sod_belprcflg = ''W'' or sod_chgftycstflg = ''W'') '
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
if @rvsdatSQL <> ''
begin
	set @conditionSQL = @conditionSQL + case (len(@conditionSQL)) when 0 then '(' else ' and (' end + @rvsdatSQL + ')'
end

--print @conditionSQL

-- Construct SQL Statement
set @header = 'select
 ''W'' as ''action'',
 sod_cocde,
 sod_ordno,
 soh_ordsts,
 sod_cus1no,
 isnull(pri.cbi_cusno + '' - '' + pri.cbi_cussna,'''') as ''pri_cusnam'',
 sod_cus2no,
 isnull(sec.cbi_cusno + '' - '' + sec.cbi_cussna,'''') as ''sec_cusnam'',
 convert(varchar(12),soh_rvsdat, 101) as ''soh_rvsdat'',
 sod_ordseq,
 sod_itmno,
 sod_colcde,
 sod_pckunt,
 sod_inrctn,
 sod_mtrctn,
 sod_cft,
 sod_pckunt + '' / '' + cast(sod_inrctn as varchar(10)) + '' / '' + cast(sod_mtrctn as varchar(10)) + '' / '' + cast(sod_cft as varchar(10)) as ''packing'',
 case when (sod_ordqty / sod_mtrctn) < sod_moq then ''Y'' else ''N'' end as ''below_moqmoa'',
 case when sod_itmprc <> sod_basprc and sod_itmprc > 0 then case when sod_itmprc > sod_untprc then ''MIN'' else ''N'' end else case when round(sod_itmprc,2,2) > round(sod_untprc,2,2) then ''BASIC'' else ''N'' end end as ''below_basprc'',
 sod_moqmoaflg,
 sod_ordqty,
 sod_ordqty / sod_mtrctn as ''ordctn'',
 sod_moq,
 sod_belprcflg,
 sod_onetimeflg,
 sod_curcde,
 sod_itmprc as ''basprc'',
 sod_untprc as ''selprc'',
 sod_chgftycstflg,
 sod_fcurcde,
 sod_ftycst,
 sod_ftycst_org,
 sod_dvftycst,
 sod_dvftycst_org,
 cast(sod_timstp as int) as ''sod_timstp''
 from SCORDHDR (nolock)
 left join SCORDDTL (nolock) on sod_ordno = soh_ordno
 left join CUBASINF pri (nolock) on pri.cbi_cusno = sod_cus1no
 left join CUBASINF sec (nolock) on sec.cbi_cusno = sod_cus2no
 where'
set @footer = 'order by sod_ordno, sod_ordseq'
--case when round(sod_itmprc,2,2) > round(sod_untprc,2,2) then ''Y'' else ''N'' end as ''below_basprc'',
set @statementSQL = @header + ' ' + @conditionSQL + ' ' + @footer

--print @statementSQL

-- Execute Constructed SQL Query
exec(@statementSQL)

*/




GO
GRANT EXECUTE ON [dbo].[sp_select_SCM00006_DTL] TO [ERPUSER] AS [dbo]
GO
