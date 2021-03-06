/****** Object:  StoredProcedure [dbo].[sp_list_CLR00007_dt]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CLR00007_dt]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CLR00007_dt]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





create                procedure [dbo].[sp_list_CLR00007_dt]
@cocde nvarchar(1000),
@check char(1),
@cocdelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@cus2nolist nvarchar(1000),
@itmnolist nvarchar(1000),
@pvlist nvarchar(1000),
@saissdatfm datetime,
@saissdatto datetime,
@sarvsdatfm datetime,
@sarvsdatto datetime,
@clmcde nvarchar(1000),
@sccde nvarchar(1000),
@pocde nvarchar(1000),
@clmsts nvarchar(50),
@flag_donot_show_dtl nvarchar(1),
@usrid nvarchar(30)


 
AS

BEGIN



SET NOCOUNT ON


create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_COCDE (tmp_txcocde nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS2NO (tmp_cus2no nvarchar(10)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]
create table #TEMP_PV (tmp_pv nvarchar(10)) on [PRIMARY]
create table #TEMP_CLMNO (tmp_caordno nvarchar(20)) on [PRIMARY]
create table #TEMP_SCNO (tmp_scno nvarchar(20)) on [PRIMARY]
create table #TEMP_PONO (tmp_pono nvarchar(20)) on [PRIMARY]
create table #TEMP_CLMSTS (tmp_caordsts nvarchar(20)) on [PRIMARY]



declare	@fm nvarchar(100), @to nvarchar(100), @date3 datetime


declare @strPart nvarchar(1000), @strRemain nvarchar(1000)

set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''
set @date3  = ''

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
(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'CA' and yur_lvl = 0)
	or ysr_saltem in (select yur_para from syusrright where  yur_doctyp = 'CA' and yur_lvl = 1 and yur_usrid = @usrid)
	or cbi_cusno in (select yur_para from syusrright where yur_doctyp = 'CA' and yur_lvl = 2 and yur_usrid = @usrid)
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
--union 
--select ''
order by cbi_cusno

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

--#TEMP_CLMNO
if ltrim(rtrim(@clmcde)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @clmcde
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cah_caordno from CAORDHDR where cah_caordno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cah_caordno from CAORDHDR where cah_caordno like @strPart
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
			select cah_caordno from CAORDHDR where cah_caordno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cah_caordno from CAORDHDR where cah_caordno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CLMNO
	select distinct tmp_init from #TEMP_INIT
end
else
begin

insert into #TEMP_CLMNO
select 	--distinct 
cah_caordno
from CAORDHDR (nolock)

order by cah_caordno

end


--#TEMP_SCNO
if ltrim(rtrim(@sccde)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @sccde
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cad_scordno from CAORDDTL where cad_scordno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cad_scordno from CAORDDTL where cad_scordno like @strPart
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
			select cad_scordno from CAORDDTL where cad_scordno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cad_scordno from CAORDDTL where cad_scordno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_SCNO
	select distinct tmp_init from #TEMP_INIT
end
else
begin

insert into #TEMP_SCNO
select 	--distinct 
cad_scordno
from CAORDDTL (nolock)

order by cad_caordno

end

--#TEMP_PONO
if ltrim(rtrim(@pocde)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @pocde
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cad_popurord from CAORDDTL where cad_popurord between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cad_popurord from CAORDDTL where cad_popurord like @strPart
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
			select cad_popurord from CAORDDTL where cad_popurord between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cad_popurord from CAORDDTL where cad_popurord like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_PONO
	select distinct tmp_init from #TEMP_INIT
end
else
begin

insert into #TEMP_PONO
select 	--distinct 
cad_popurord
from CAORDDTL (nolock)

order by cad_caordno

end


--#TEMP_CLMSTS
if ltrim(rtrim(@clmsts)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @clmsts
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cah_caordsts from CAORDHDR where cah_caordsts between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cah_caordsts from CAORDHDR where cah_caordsts like @strPart
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
			select cah_caordsts from CAORDHDR where cah_caordsts between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cah_caordsts from CAORDHDR where cah_caordsts like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CLMSTS
	select distinct tmp_init from #TEMP_INIT
end
else
begin

insert into #TEMP_CLMSTS
select 	--distinct 
cah_caordsts
from CAORDHDR (nolock) 



end


declare @flg_cocde_table char(1), 
@flg_cus1no_table char(1),
@flg_cus2no_table char(1),
@flg_itmno_table char(1),
@flg_pv_table char(1),
@flg_clmno_table char(1),
@flg_scno_table char(1),
@flg_pono_table char(1),
@flg_clmsts_table char(1),
@flg_saissdat_fmto char(1),
@flg_sarvsdat_fmto char(1)


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

if (select count(*) from #TEMP_ITMNO) >= 1
	set @flg_itmno_table = 'Y'
else
	set @flg_itmno_table = 'N'


if (select count(*) from #TEMP_PV) >= 1
	set @flg_pv_table = 'Y'
else
	set @flg_pv_table = 'N'

if (select count(*) from #TEMP_CLMNO) >= 1
	set @flg_clmno_table = 'Y'
else
	set @flg_clmno_table = 'N'

if (select count(*) from #TEMP_SCNO) >= 1
	set @flg_scno_table = 'Y'
else
	set @flg_scno_table = 'N'

if (select count(*) from #TEMP_PONO) >= 1
	set @flg_pono_table = 'Y'
else
	set @flg_pono_table = 'N'

if (select count(*) from #TEMP_CLMSTS) >= 1
	set @flg_clmsts_table = 'Y'
else
	set @flg_clmsts_table = 'N'



if @saissdatfm <> '1900/01/01'
begin
	set @flg_saissdat_fmto = 'Y'
	set @saissdatto = dateadd(DD,1,@saissdatto)
end
else
begin
	set @flg_saissdat_fmto = 'N'
end


if @sarvsdatfm <> '1900/01/01'
begin
	set @flg_sarvsdat_fmto = 'Y'
	set @sarvsdatto = dateadd(DD,1,@sarvsdatto)
end
else
begin
	set @flg_sarvsdat_fmto = 'N'
end









if @flg_saissdat_fmto = 'Y'  or  @flg_sarvsdat_fmto= 'Y'
begin

if @flag_donot_show_dtl = 'Y' 
begin

select
                 cah_cus1no,
pri.cbi_cussna as 'cbi_cussna',
cah_caordno,
cad_shissdat,
cah_caordsts,
cah_caordsts_a,
cah_cmt_a,
cah_caordsts_b,
cah_cmt_b,
cah_venno,
cah_venno,
vbi_vensna,
cad_itmno,
cah_reason,
yct_dsc,
cah_caamt_final,
CAH_CATOINSCUR,
CAH_CATOHKOAMT,
CAH_CATOVNAMT,
cah_rmk,
cad_rmk

FROM               

CAORDHDR (nolock)

--left join CAORDDTL (nolock) on    cad_caordno = cah_caordno

left join CUBASINF pri on pri.cbi_cusno = cah_cus1no

left join CUBASINF sec on sec.cbi_cusno = cah_cus2no
left join SYCLMTYP clmtyp(nolock) on clmtyp.yct_cde = cah_clatyp
left join VNBASINF vbn (nolock) on vbn.vbi_venno  = cah_venno
left join SYUSRPRF usrteam (nolock) on usrteam.yup_usrid  = cah_creusr
left join SYUSRPRF applflg1 (nolock) on applflg1.yup_usrid  = cah_app1flgby
left join SYUSRPRF applflg2 (nolock) on applflg2.yup_usrid  = cah_app2flgby


where --cah_caordno = @clmcde
--and 
--20140309, set as credat
 	(
	(@flg_saissdat_fmto = 'N') 
	or
	 (@flg_saissdat_fmto = 'Y' and (cah_credat between @saissdatfm and @saissdatto ))
	)

and
 (
	(@flg_sarvsdat_fmto = 'N') 
	or
	 (@flg_sarvsdat_fmto = 'Y'   and  (cah_app1flgdat between @sarvsdatfm and @sarvsdatto))
	)
	
--cad_app1flgdat between @sarvsdatfm and @sarvsdatto))
--and((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and cah_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and cah_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and cah_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
--and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and cad_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and cah_venno in (select tmp_pv from #TEMP_PV (nolock))))
and ((@flg_clmno_table = 'N') or (@flg_clmno_table = 'Y' and cah_caordno in (select tmp_caordno from #TEMP_CLMNO (nolock))))
--and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and cah_scordno in (select tmp_scno from #TEMP_SCNO (nolock))))
--and ((@flg_pono_table = 'N') or (@flg_pono_table = 'Y' and cah_popurord in (select tmp_pono from #TEMP_PONO (nolock))))
and ((@flg_clmsts_table = 'N') or (@flg_clmsts_table = 'Y' and cah_caordsts in (select tmp_caordsts from #TEMP_CLMSTS (nolock))))
--and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and cah_txcocde in (select tmp_txcocde from #TEMP_COCDE (nolock))))
order by cah_cus1no, cah_cus2no, cah_caordno

end
else  --show dtl
begin
select
cah_cus1no,
pri.cbi_cussna as 'cbi_cussna',
cah_caordno,
cad_shissdat,
cah_caordsts,
cah_caordsts_a,
cah_cmt_a,
cah_caordsts_b,
cah_cmt_b,
cah_venno,
cah_venno,
vbi_vensna,
cad_itmno,
cah_reason,
yct_dsc,
cah_caamt_final,
CAH_CATOINSCUR,
CAH_CATOHKOAMT,
CAH_CATOVNAMT,
cah_rmk,
cad_rmk
FROM               

CAORDHDR (nolock)
left join CAORDDTL (nolock) on    cad_caordno = cah_caordno
left join CUBASINF pri on pri.cbi_cusno = cah_cus1no
left join CUBASINF sec on sec.cbi_cusno = cah_cus2no
left join SYCLMTYP clmtyp(nolock) on clmtyp.yct_cde = cah_clatyp
left join VNBASINF vbn (nolock) on vbn.vbi_venno  = cah_venno
left join SYUSRPRF usrteam (nolock) on usrteam.yup_usrid  = cah_creusr
left join SYUSRPRF applflg1 (nolock) on applflg1.yup_usrid  = cah_app1flgby
left join SYUSRPRF applflg2 (nolock) on applflg2.yup_usrid  = cah_app2flgby


where --cah_caordno = @clmcde
--and 
--20140309, set as credat
 	(
	(@flg_saissdat_fmto = 'N') 
	or
	 (@flg_saissdat_fmto = 'Y' and (cah_credat between @saissdatfm and @saissdatto ))
	)

and
 (
	(@flg_sarvsdat_fmto = 'N') 
	or
	 (@flg_sarvsdat_fmto = 'Y'   and  (cah_app1flgdat between @sarvsdatfm and @sarvsdatto))
	)
	
--cad_app1flgdat between @sarvsdatfm and @sarvsdatto))
--and((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and cah_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and cah_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and cah_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
--and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and cad_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and cah_venno in (select tmp_pv from #TEMP_PV (nolock))))
and ((@flg_clmno_table = 'N') or (@flg_clmno_table = 'Y' and cah_caordno in (select tmp_caordno from #TEMP_CLMNO (nolock))))
--and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and cah_scordno in (select tmp_scno from #TEMP_SCNO (nolock))))
--and ((@flg_pono_table = 'N') or (@flg_pono_table = 'Y' and cah_popurord in (select tmp_pono from #TEMP_PONO (nolock))))
and ((@flg_clmsts_table = 'N') or (@flg_clmsts_table = 'Y' and cah_caordsts in (select tmp_caordsts from #TEMP_CLMSTS (nolock))))
--and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and cah_txcocde in (select tmp_txcocde from #TEMP_COCDE (nolock))))
order by cah_cus1no, cah_cus2no, cah_caordno

--------------------------------------------------------

end

end

END


 



GO
GRANT EXECUTE ON [dbo].[sp_list_CLR00007_dt] TO [ERPUSER] AS [dbo]
GO
