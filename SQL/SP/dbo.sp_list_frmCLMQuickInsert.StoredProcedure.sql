/****** Object:  StoredProcedure [dbo].[sp_list_frmCLMQuickInsert]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_frmCLMQuickInsert]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_frmCLMQuickInsert]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE     PROCEDURE [dbo].[sp_list_frmCLMQuickInsert]
@cocdelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@cus2nolist nvarchar(1000),
@pvlist nvarchar(1000),
@itmnolist nvarchar(1000),
@scnolist nvarchar(1000),
@ponolist nvarchar(1000),
@jobnolist nvarchar(1000),
@invnolist nvarchar(1000),
@cusponolist nvarchar(1000),
@cusitmnolist nvarchar(1000),
@cusstylenolist nvarchar(1000),
@invissdatfm datetime,
@invissdatto datetime,
@scshipdatfm datetime,
@scshipdatto datetime,
@usrid nvarchar(30)

AS

create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_COCDE (tmp_cocde nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS2NO (tmp_cus2no nvarchar(10)) on [PRIMARY]
create table #TEMP_PV (tmp_pv nvarchar(10)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]
create table #TEMP_SCNO (tmp_scno nvarchar(20)) on [PRIMARY]
create table #TEMP_PONO (tmp_pono nvarchar(20)) on [PRIMARY]
create table #TEMP_JOBNO (tmp_jobno nvarchar(20)) on [PRIMARY]
create table #TEMP_INVNO (tmp_invno nvarchar(20)) on [PRIMARY]
create table #TEMP_CUSPONO (tmp_cuspono nvarchar(20)) on [PRIMARY]
create table #TEMP_CUSITMNO (tmp_cusitmno nvarchar(20)) on [PRIMARY]
create table #TEMP_CUSSTYLENO (tmp_cusstyleno nvarchar(20)) on [PRIMARY]


declare @fm nvarchar(100), @to nvarchar(100)
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
			print(charindex('%', @strRemain))
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
	(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'CA' and yur_lvl = 0)
		or ysr_saltem in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'CA' and yur_lvl = 1)
		or cbi_cusno in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'CA' and yur_lvl = 2)
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
	(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'CA' and yur_lvl = 0)
		or ysr_saltem in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'CA' and yur_lvl = 1)
		or cbi_cusno in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'CA' and yur_lvl = 2)
	) and cbi_cusno > '50000'
	union 
	select ''
	order by cbi_cusno
end

--#TEMP_PV
if ltrim(rtrim(@pvlist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @pvlist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select vbi_venno from VNBASINF (nolock) where vbi_venno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select vbi_venno from VNBASINF (nolock) where vbi_venno like @strPart
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
			select vbi_venno from VNBASINF (nolock) where vbi_venno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select vbi_venno from VNBASINF where vbi_venno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_PV
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

--#TEMP_SCNO
if ltrim(rtrim(@scnolist)) <> ''
begin
	delete from #TEMP_INIT
	set @strRemain = @scnolist
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

--#TEMP_PONO
if ltrim(rtrim(@ponolist)) <> ''
begin
	delete from #TEMP_INIT
	set @strRemain = @ponolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select poh_purord from POORDHDR (nolock) where poh_purord between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select poh_purord from POORDHDR (nolock) where poh_purord like @strPart
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
			select poh_purord from POORDHDR where poh_purord between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select poh_purord from POORDHDR where poh_purord like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_PONO
	select distinct tmp_init from #TEMP_INIT
end

--#TEMP_JOBNO
if ltrim(rtrim(@jobnolist)) <> ''
begin
	delete from #TEMP_INIT
	set @strRemain = @jobnolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select pod_jobord from POORDDTL (nolock) where pod_jobord between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select pod_jobord from POORDDTL (nolock) where pod_jobord like @strPart
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
			select pod_jobord from POORDDTL where pod_jobord between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select pod_jobord from POORDDTL where pod_jobord like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_JOBNO
	select distinct tmp_init from #TEMP_INIT
end

--#TEMP_INVNO
if ltrim(rtrim(@invnolist)) <> ''
begin
	delete from #TEMP_INIT
	set @strRemain = @invnolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select hid_invno from SHIPGDTL (nolock) where hid_invno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select hid_invno from SHIPGDTL (nolock) where hid_invno like @strPart
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
			select hid_invno from SHIPGDTL where hid_invno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select hid_invno from SHIPGDTL where hid_invno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_INVNO
	select distinct tmp_init from #TEMP_INIT
end


--#TEMP_CUSPONO
if ltrim(rtrim(@cusponolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cusponolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select soh_cuspo from SCORDHDR (nolock) where soh_cuspo between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select soh_cuspo from SCORDHDR where soh_cuspo like @strRemain
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
			select soh_cuspo from SCORDHDR (nolock) where soh_cuspo between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select soh_cuspo from SCORDHDR where soh_cuspo like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CUSPONO
	select distinct tmp_init from #TEMP_INIT
end

--#TEMP_CUSITMNO
if ltrim(rtrim(@cusitmnolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cusitmnolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select sod_cusitm from SCORDDTL (nolock) where sod_cusitm between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select sod_cusitm from SCORDDTL where sod_cusitm like @strRemain
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
			select sod_cusitm from SCORDDTL (nolock) where sod_cusitm between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select sod_cusitm from SCORDDTL where sod_cusitm like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CUSITMNO
	select distinct tmp_init from #TEMP_INIT
end

--#TEMP_CUSSTYLENO
if ltrim(rtrim(@cusstylenolist)) <> ''
begin

	delete from #TEMP_INIT

	set @strRemain = @cusstylenolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select sod_cusstyno from SCORDDTL (nolock) where sod_cusstyno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select sod_cusstyno from SCORDDTL where sod_cusstyno like @strRemain
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
			select sod_cusstyno from SCORDDTL (nolock) where sod_cusstyno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select sod_cusstyno from SCORDDTL where sod_cusstyno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CUSSTYLENO
	select distinct tmp_init from #TEMP_INIT
end


-------------------------------------------------------------------
declare
@flg_cocde_table char(1), 
@flg_cus1no_table char(1),
@flg_cus2no_table char(1),
@flg_pv_table char(1),
@flg_itmno_table char(1),
@flg_scno_table char(1),
@flg_pono_table char(1),
@flg_jobno_table char(1),
@flg_invno_table char(1),
@flg_cuspono_table char(1),
@flg_cusitmno_table char(1),
@flg_cusstyleno_table char(1)


if (select count(*) from #TEMP_COCDE) >= 1
	set @flg_cocde_table = 'Y'
else
	set @flg_cocde_table = 'N'

if ltrim(rtrim(@cus1nolist)) <> ''
	set @flg_cus1no_table = 'Y'
else
	set @flg_cus1no_table = 'N'

if ltrim(rtrim(@cus2nolist)) <> ''
	set @flg_cus2no_table = 'Y'
else
	set @flg_cus2no_table = 'N'

if ltrim(rtrim(@pvlist)) <> ''
	set @flg_pv_table = 'Y'
else
	set @flg_pv_table = 'N'

if (select count(*) from #TEMP_ITMNO) >= 1
	set @flg_itmno_table = 'Y'
else
	set @flg_itmno_table = 'N'

if (select count(*) from #TEMP_SCNO) >= 1
	set @flg_scno_table = 'Y'
else
	set @flg_scno_table = 'N'

if (select count(*) from #TEMP_PONO) >= 1
	set @flg_pono_table = 'Y'
else
	set @flg_pono_table = 'N'

if (select count(*) from #TEMP_JOBNO) >= 1
	set @flg_jobno_table = 'Y'
else
	set @flg_jobno_table = 'N'

if (select count(*) from #TEMP_INVNO) >= 1
	set @flg_invno_table = 'Y'
else
	set @flg_invno_table = 'N'

if (select count(*) from #TEMP_CUSPONO) >= 1
	set @flg_cuspono_table = 'Y'
else
	set @flg_cuspono_table = 'N'

if (select count(*) from #TEMP_CUSITMNO) >= 1
	set @flg_cusitmno_table = 'Y'
else
	set @flg_cusitmno_table = 'N'

if (select count(*) from #TEMP_CUSSTYLENO) >= 1
	set @flg_cusstyleno_table = 'Y'
else
	set @flg_cusstyleno_table = 'N'

set @invissdatto = dateadd(DD,1,@invissdatto)






create table #TEMP_TXLIST
(
tmp_cocde nvarchar(10),
tmp_scno nvarchar(20),
tmp_scseq int,
tmp_pono nvarchar(20),
tmp_poseq int,
tmp_shpno nvarchar(20),
tmp_shpseq int
)


insert into #TEMP_TXLIST
select
distinct
sod_cocde,
sod_ordno,
sod_ordseq,
pod_purord,
pod_purseq,
hid_shpno,
hid_shpseq
from 
SCORDHDR (nolock)
left join SCORDDTL (nolock) on sod_cocde = soh_cocde and sod_ordno = soh_ordno
left join POORDDTL (nolock) on pod_cocde = soh_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
left join SHIPGDTL (nolock) on hid_cocde = soh_cocde and hid_ordno = sod_ordno and hid_ordseq = sod_ordseq
left join SHIPGHDR (nolock) on hih_cocde = soh_cocde and hid_shpno = hih_shpno
where 
soh_issdat between @invissdatfm and @invissdatto
and hih_slnonb  between @scshipdatfm	 and @invissdatto
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and sod_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and sod_venno in (select tmp_pv from #TEMP_PV (nolock))))
and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and sod_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and sod_ordno in (select tmp_scno from #TEMP_SCNO (nolock))))
and ((@flg_pono_table = 'N') or (@flg_pono_table = 'Y' and pod_purord in (select tmp_pono from #TEMP_PONO (nolock))))
and ((@flg_jobno_table = 'N') or (@flg_jobno_table = 'Y' and pod_jobord in (select tmp_jobno from #TEMP_JOBNO (nolock))))
and ((@flg_invno_table = 'N') or (@flg_invno_table = 'Y' and hid_invno in (select tmp_invno from #TEMP_INVNO (nolock))))
and ((@flg_cuspono_table = 'N') or (@flg_cuspono_table = 'Y' and soh_cuspo in (select tmp_cuspono from #TEMP_CUSPONO (nolock))))
and ((@flg_cusitmno_table = 'N') or (@flg_cusitmno_table = 'Y' and sod_cusitm in (select tmp_cusitmno from #TEMP_CUSITMNO (nolock))))
and ((@flg_cusstyleno_table = 'N') or (@flg_cusstyleno_table = 'Y' and sod_cusstyno in (select tmp_cusstyleno from #TEMP_CUSSTYLENO (nolock))))



select distinct
'' as 'Add',
sod_cocde,
sod_ordno,
sod_ordseq,
pod_purord,
pod_purseq,
pod_jobord,
hih_issdat,
hih_slnonb,
hih_arrdat,
hid_invno,
hid_shpno, --- 20131122
hid_shpseq, --- 20131122
hid_untcde,  --- 20131122
hid_shpqty,
hid_untamt,
hid_ttlamt, --- 20131122
sod_itmno,
sod_itmtyp,
sod_itmdsc,
case sod_cuspo when '' then soh_cuspo else sod_cuspo end as 'sod_cuspo',
sod_cusitm,
sod_cusstyno,
sod_venitm,
sod_venno + ' - ' + vbi_vensna as 'sod_prdven',
vbi_ventyp,
sod_curcde,
sod_selprc,
sod_untprc,
sod_netuntprc,
case vbi_ventyp when 'E' then sod_fcurcde else sod_dvfcurcde end as 'sod_dvfcurcde',
case vbi_ventyp when 'E' then sod_ftyprc else sod_dvftyprc end as 'sod_dvftyprc',
sod_pckunt,
sod_ordqty,
sod_shpqty
from 
#TEMP_TXLIST (nolock)
left join SCORDHDR (nolock) on tmp_cocde = soh_cocde and tmp_scno = soh_ordno
left join SCORDDTL (nolock) on soh_cocde = sod_cocde and soh_ordno = sod_ordno and tmp_cocde = sod_cocde and tmp_scno = sod_ordno and tmp_scseq = sod_ordseq
left join POORDHDR (nolock) on tmp_cocde = poh_cocde and tmp_pono = poh_purord
left join POORDDTL (nolock) on poh_cocde = pod_cocde and poh_purord = pod_purord and tmp_cocde = pod_cocde and tmp_pono = pod_purord and tmp_poseq = pod_purseq
left join SHIPGHDR (nolock) on tmp_cocde = hih_cocde and tmp_shpno = hih_shpno
left join SHIPGDTL (nolock) on hih_cocde = hid_cocde and hih_shpno = hid_shpno and tmp_cocde = hid_cocde and tmp_shpno = hid_shpno and tmp_shpseq = hid_shpseq
left join VNBASINF (nolock) on sod_venno = vbi_venno
order by sod_cocde, sod_ordno, sod_ordseq


drop table #TEMP_INIT
drop table #TEMP_COCDE
drop table #TEMP_CUS1NO
drop table #TEMP_CUS2NO
drop table #TEMP_PV
drop table #TEMP_ITMNO
drop table #TEMP_SCNO
drop table #TEMP_PONO
drop table #TEMP_JOBNO
drop table #TEMP_INVNO
drop table #TEMP_CUSPONO
drop table #TEMP_CUSITMNO
drop table #TEMP_CUSSTYLENO
drop table #TEMP_TXLIST






GO
GRANT EXECUTE ON [dbo].[sp_list_frmCLMQuickInsert] TO [ERPUSER] AS [dbo]
GO
