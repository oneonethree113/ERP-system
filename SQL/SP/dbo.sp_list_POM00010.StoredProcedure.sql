/****** Object:  StoredProcedure [dbo].[sp_list_POM00010]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_POM00010]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_POM00010]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modification History
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modify on	-- Modify by	-- Modification
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
--sp_list_POM00010 '','UCPP,EW,GU,HB,HH,HX,PG,TT,UCP','','','','','','','','','','11/28/2016','12/28/2016','01/01/1900','01/01/1900','01/01/1900','01/01/1900','mis'
CREATE         PROCEDURE [dbo].[sp_list_POM00010]
@cocde nvarchar(6),
@cocdelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@cus2nolist nvarchar(1000),
@cusponolist nvarchar(1000),
@ponolist nvarchar(1000),
@scnolist nvarchar(1000),
@itmnolist nvarchar(1000),
@cvlist nvarchar(1000),
@pvlist nvarchar(1000),
@salesteamlist nvarchar(1000),
@poissdatfm datetime,
@poissdatto datetime,
@scissdatfm datetime,
@scissdatto datetime,
--@shpdatfm datetime,
--@shpdatto datetime,
@cuspodatfm datetime,
@cuspodatto datetime,
@usrid nvarchar(30)
AS

create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_COCDE (tmp_cocde nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS2NO (tmp_cus2no nvarchar(10)) on [PRIMARY]
create table #TEMP_CUSPONO (tmp_cuspono nvarchar(20)) on [PRIMARY]
create table #TEMP_PONO (tmp_pono nvarchar(20)) on [PRIMARY]
create table #TEMP_SCNO (tmp_scno nvarchar(20)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]
create table #TEMP_CV (tmp_cv nvarchar(10)) on [PRIMARY]
create table #TEMP_PV (tmp_pv nvarchar(10)) on [PRIMARY]
create table #TEMP_SALESTEAM (tmp_salesteam nvarchar(10)) on [PRIMARY]

create table #TEMP_POLIST(
tmp_cocde	nvarchar(10),
tmp_purord	nvarchar(20),
tmp_pursts	nvarchar(10),
tmp_cus1no	nvarchar(6),
tmp_cus2no	nvarchar(6),
tmp_cuspo	nvarchar(20),
tmp_scno	nvarchar(20),
tmp_cv		nvarchar(10),
tmp_appflg	char(1),
tmp_reason	nvarchar(200))




declare	@fm nvarchar(100), @to nvarchar(100)

declare @strPart nvarchar(1000), @strRemain nvarchar(1000)

set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''

declare	@fmCusPONo nvarchar(100), @toCusPONo nvarchar(100)
set @fmCusPONo = ''
set @toCusPONo = ''


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
(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'SC' and yur_lvl = 0)
	or cbi_saltem in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 1)
	or cbi_cusno in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 2)
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
(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'SC' and yur_lvl = 0)
	or cbi_saltem in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 1)
	or cbi_cusno in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 2)
) and cbi_cusno > '50000'
union 
select ''
order by cbi_cusno

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
			set @fmCusPONo = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @toCusPONo = right(@strPart, len(@strPart) - charindex('~', @strPart))
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
			set @fmCusPONo = ltrim(left(@strRemain, charindex('~', @strRemain)-1))
			set @toCusPONo = right(@strRemain, len(@strRemain) - charindex('~', @strRemain))
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CUSPONO
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

--#TEMP_CV
if ltrim(rtrim(@cvlist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cvlist
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
	insert into #TEMP_CV
	select distinct tmp_init from #TEMP_INIT
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


/*
select * from #TEMP_COCDE
select * from #TEMP_CUS1NO
select * from #TEMP_CUS2NO
select * from #TEMP_CUSPONO
select @fmCusPONo, @toCusPONo
select * from #TEMP_PONO
select * from #TEMP_SCNO
select * from #TEMP_ITMNO
select * from #TEMP_CV
select * from #TEMP_DV
select * from #TEMP_PV
select * from #TEMP_SALESTEAM
select * from #TEMP_SCLIST
*/
-------------------------------------------------------------------
declare @flg_cocde_table char(1), 
@flg_cus1no_table char(1),
@flg_cus2no_table char(1),
@flg_cuspono_table char(1),
@flg_cuspono_fmto char(1),
@flg_pono_table char(1),
@flg_scno_table char(1),
@flg_itmno_table char(1),
@flg_cv_table char(1),
@flg_pv_table char(1),
@flg_salesteam_table char(1),
@flg_poissdat_fmto char(1),
@flg_scissdat_fmto char(1),
--@flg_shpdat_fmto char(1),
@flg_cuspodat_fmto char(1)

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

if (select count(*) from #TEMP_CUSPONO) >= 1
	set @flg_cuspono_table = 'Y'
else
	set @flg_cuspono_table = 'N'

if @fmCusPONo <> ''
	set @flg_cuspono_fmto = 'Y'
else
	set @flg_cuspono_fmto = 'N'

if (select count(*) from #TEMP_PONO) >= 1
	set @flg_pono_table = 'Y'
else
	set @flg_pono_table = 'N'

if (select count(*) from #TEMP_SCNO) >= 1
	set @flg_scno_table = 'Y'
else
	set @flg_scno_table = 'N'

if (select count(*) from #TEMP_ITMNO) >= 1
	set @flg_itmno_table = 'Y'
else
	set @flg_itmno_table = 'N'

if (select count(*) from #TEMP_CV) >= 1
	set @flg_cv_table = 'Y'
else
	set @flg_cv_table = 'N'

if (select count(*) from #TEMP_PV) >= 1
	set @flg_pv_table = 'Y'
else
	set @flg_pv_table = 'N'

if (select count(*) from #TEMP_SALESTEAM) >= 1
	set @flg_salesteam_table = 'Y'
else
	set @flg_salesteam_table = 'N'

if @poissdatfm <> '01/01/1900'
begin
	set @flg_poissdat_fmto = 'Y'
	set @poissdatto = dateadd(DD,1,@poissdatto)
end
else
begin
	set @flg_poissdat_fmto = 'N'
end

if @scissdatfm <> '01/01/1900'
begin
	set @flg_scissdat_fmto = 'Y'
	set @scissdatto = dateadd(DD,1,@scissdatto)
end
else
begin
	set @flg_scissdat_fmto = 'N'
end

/*
if @shpdatfm <> '01/01/1900'
begin
	set @flg_shpdat_fmto = 'Y'
	set @shpdatto = dateadd(DD,1,@shpdatto)
end
else
begin
	set @flg_shpdat_fmto = 'N'
end
*/

if @cuspodatfm <> '01/01/1900'
begin
	set @flg_cuspodat_fmto = 'Y'
	set @cuspodatto =  dateadd(DD,1,@cuspodatto)
end
else
begin
	set @flg_cuspodat_fmto = 'N'
end

--select @flg_scissdat_fmto,@flg_poissdat_fmto,@poissdatfm, @poissdatto
--------------------------------------------------------------------

if @flg_scissdat_fmto = 'Y'
begin

insert into #TEMP_POLIST
select distinct poh_cocde, poh_purord, poh_pursts, poh_prmcus, poh_seccus, poh_cuspno, soh_ordno, poh_venno,'Y',''
from SCORDHDR (nolock)
left join SYSALREP on ysr_code1 = soh_salrep
, SCORDDTL (nolock), POORDDTL (nolock), POORDHDR (nolock)
where soh_issdat between @scissdatfm and @scissdatto
and soh_cocde = sod_cocde and soh_ordno = sod_ordno
and pod_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
and pod_cocde = poh_cocde and pod_purord = poh_purord
and poh_pursts in ('REL','CAN') and poh_signappflg <> 'Y'
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and soh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_cuspono_table = 'N') or (@flg_cuspono_table = 'Y' and soh_cuspo in (select tmp_cuspono from #TEMP_CUSPONO (nolock))))
and ((@flg_cuspono_fmto = 'N') or (@flg_cuspono_fmto = 'Y' and soh_cuspo between @fmCusPONo and @toCusPONo))
and ((@flg_pono_table = 'N') or (@flg_pono_table = 'Y' and poh_purord in (select tmp_pono from #TEMP_PONO (nolock))))
and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and soh_ordno in (select tmp_scno from #TEMP_SCNO (nolock))))
and ((@flg_cv_table = 'N') or (@flg_cv_table = 'Y' and sod_cusven in (select tmp_cv from #TEMP_CV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and sod_venno in (select tmp_pv from #TEMP_PV (nolock))))
--and ((@flg_shpdat_fmto = 'N') or (@flg_shpdat_fmto = 'Y' and sod_shpstr between @shpdatfm and @shpdatto))
and ((@flg_cuspodat_fmto = 'N') or (@flg_cuspodat_fmto = 'Y' and soh_cpodat between @cuspodatfm and @cuspodatto))
and ((@flg_poissdat_fmto = 'N') or (@flg_poissdat_fmto = 'Y' and poh_issdat between @poissdatfm and @poissdatto))

end
else if @flg_poissdat_fmto = 'Y'
begin

insert into #TEMP_POLIST
select distinct poh_cocde, poh_purord, poh_pursts, poh_prmcus, poh_seccus, poh_cuspno, pod_scno, poh_venno,'Y',''
from POORDHDR (nolock), POORDDTL (nolock)--, SCORDHDR (nolock)
where 
--poh_issdat between @poissdatfm and @poissdatto
poh_upddat between @poissdatfm and @poissdatto
and pod_cocde = poh_cocde and pod_purord = poh_purord and pod_scno <> ''
--and pod_cocde = soh_cocde and pod_scno = soh_ordno
and poh_pursts in ('REL','CAN') and poh_signappflg <> 'Y'
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and poh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and poh_prmcus in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and poh_seccus in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_cuspono_table = 'N') or (@flg_cuspono_table = 'Y' and poh_cuspno in (select tmp_cuspono from #TEMP_CUSPONO (nolock))))
and ((@flg_cuspono_fmto = 'N') or (@flg_cuspono_fmto = 'Y' and poh_cuspno between @fmCusPONo and @toCusPONo))
and ((@flg_pono_table = 'N') or (@flg_pono_table = 'Y' and poh_purord in (select tmp_pono from #TEMP_PONO (nolock))))
and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and pod_scno in (select tmp_scno from #TEMP_SCNO (nolock))))
and ((@flg_cv_table = 'N') or (@flg_cv_table = 'Y' and poh_venno in (select tmp_cv from #TEMP_CV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and pod_prdven in (select tmp_pv from #TEMP_PV (nolock))))
--and ((@flg_cuspodat_fmto = 'N') or (@flg_cuspodat_fmto = 'Y' and soh_cpodat between @cuspodatfm and @cuspodatto))
--and ((@flg_scissdat_fmto = 'N') or (@flg_scissdat_fmto = 'Y' and soh_issdat between @scissdatfm and @scissdatto))

end
else
begin

insert into #TEMP_POLIST
select distinct poh_cocde, poh_purord, poh_pursts, poh_prmcus, poh_seccus, poh_cuspno, soh_ordno, poh_venno,'Y',''
from SCORDHDR (nolock)
left join SYSALREP on ysr_code1 = soh_salrep
, SCORDDTL (nolock), POORDDTL (nolock), POORDHDR (nolock)
where soh_cpodat between @cuspodatfm and @cuspodatto
and soh_ordno = sod_ordno
and pod_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
and pod_cocde = poh_cocde and pod_purord = poh_purord
and poh_pursts in ('REL','CAN') and poh_signappflg <> 'Y'
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and soh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_cuspono_table = 'N') or (@flg_cuspono_table = 'Y' and soh_cuspo in (select tmp_cuspono from #TEMP_CUSPONO (nolock))))
and ((@flg_cuspono_fmto = 'N') or (@flg_cuspono_fmto = 'Y' and soh_cuspo between @fmCusPONo and @toCusPONo))
and ((@flg_pono_table = 'N') or (@flg_pono_table = 'Y' and poh_purord in (select tmp_pono from #TEMP_PONO (nolock))))
and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and soh_ordno in (select tmp_scno from #TEMP_SCNO (nolock))))
and ((@flg_cv_table = 'N') or (@flg_cv_table = 'Y' and sod_cusven in (select tmp_cv from #TEMP_CV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and sod_venno in (select tmp_pv from #TEMP_PV (nolock))))
--and ((@flg_shpdat_fmto = 'N') or (@flg_shpdat_fmto = 'Y' and sod_shpstr between @shpdatfm and @shpdatto))
and ((@flg_scissdat_fmto = 'N') or (@flg_scissdat_fmto = 'Y' and soh_issdat between @scissdatfm and @scissdatto))
and ((@flg_poissdat_fmto = 'N') or (@flg_poissdat_fmto = 'Y' and poh_issdat between @poissdatfm and @poissdatto))

end




-- Check for user edit po list
update #TEMP_POLIST set tmp_appflg = 'N', tmp_reason = 'PO updated by approver!' from #TEMP_POLIST, UCPERPDB_AUD..POORDDTL_AUD where tmp_cocde = pod_cocde and tmp_purord = pod_purord and 
(pod_creusr = @usrid or pod_updusr = @usrid)
update #TEMP_POLIST set tmp_appflg = 'N', tmp_reason = 'PO updated by approver!' from #TEMP_POLIST, UCPERPDB_AUD_2016..POORDDTL_AUD where tmp_cocde = pod_cocde and tmp_purord = pod_purord and 
(pod_creusr = @usrid or pod_updusr = @usrid)







--select * from #TEMP_POLIST


select 
case poh_signappflg when 'Y' then 'Y' else 'W' end as 'Act',
poh_signappflg as 'App Sts',
poh_appcount as 'App Cnt',
poh_appdat as 'App Date',
tmp_cocde as 'Comp',
tmp_purord as 'PO No',
tmp_pursts as 'PO Sts',
tmp_cus1no  as 'Pri Cust',
isnull(tmp_cus1no + ' - ' + c1.cbi_cussna,'') as 'Pri Cust Name',
tmp_cus2no as 'Sec Cust',
isnull(tmp_cus2no + ' - ' + c2.cbi_cussna,'') as 'Sec Cust Name',
convert(varchar(12),poh_issdat, 101) as 'PO Date',
tmp_cuspo as 'Cust PO No',
tmp_scno as 'SC No',
tmp_cv as 'CV',
isnull(tmp_cv + ' - ' + cv.vbi_vensna, '') as 'CV Name',
case poh_lastprctrm when '' then '' when poh_prctrm then '' else 'Y' end as 'Price Term Diff',
poh_prctrm as 'Curr Price Term',
poh_lastprctrm as 'Org Price Term',
case poh_lastpaytrm when '' then '' when poh_paytrm then '' else 'Y' end as 'Pay Term Diff',
poh_paytrm + ' - ' + pay1.ysi_dsc as 'Curr Pay Term',
poh_lastpaytrm + ' - ' + pay2.ysi_dsc as 'Org Pay Term',
case tmp_appflg when 'Y' then 'Pass' else 'Fail' end as 'Apv Check',
tmp_reason as 'Apv Reason'

from #TEMP_POLIST
left join POORDHDR (nolock) on poh_cocde = tmp_cocde and poh_purord = tmp_purord
left join CUBASINF c1 (nolock) on tmp_cus1no = c1.cbi_cusno
left join CUBASINF c2 (nolock) on tmp_cus2no = c2.cbi_cusno
left join VNBASINF cv (nolock) on tmp_cv = cv.vbi_venno
left join SYSETINF pay1 (nolock) on pay1.ysi_typ = '04' and pay1.ysi_cde = poh_paytrm
left join SYSETINF pay2 (nolock) on pay2.ysi_typ = '04' and pay2.ysi_cde = poh_lastpaytrm

where poh_purord is not null and poh_signappflg <> 'Y'
--order by tmp_cus1no, tmp_cus2no, tmp_purord
order by poh_issdat desc



drop table #TEMP_INIT
drop table #TEMP_COCDE
drop table #TEMP_CUS1NO
drop table #TEMP_CUS2NO
drop table #TEMP_CUSPONO
drop table #TEMP_SCNO
drop table #TEMP_PONO
drop table #TEMP_ITMNO
drop table #TEMP_CV
drop table #TEMP_PV
drop table #TEMP_SALESTEAM
drop table #TEMP_POLIST


GO
GRANT EXECUTE ON [dbo].[sp_list_POM00010] TO [ERPUSER] AS [dbo]
GO
