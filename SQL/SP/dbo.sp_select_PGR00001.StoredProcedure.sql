/****** Object:  StoredProcedure [dbo].[sp_select_PGR00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PGR00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PGR00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     procedure [dbo].[sp_select_PGR00001]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@codelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@cus2nolist nvarchar(1000),
@pkgREQlist nvarchar(1000),
@pkgitmlist nvarchar(1000),
@pkgprtco nvarchar(1000),
@sccde nvarchar(1000),
@tocde nvarchar(1000),
@reqcredatfm datetime,
@reqcredatto datetime,
@itmnolist nvarchar(1000),
@skunolist nvarchar(1000),
@cussnolist nvarchar(1000),
@usrid nvarchar(30)


---------------------------------------------- 

 
AS
 

declare @flg_cocde_table char(1), 
@flg_cus1no_table char(1),
@flg_cus2no_table char(1),
@flg_pkgorder_table char(1),
@flg_pkgitm_table char(1),
@flg_pkgprtco_table char(1),
@flg_scno_table char(1),
@flg_tono_table char(1),
@flg_reqcredat_fmto char(1),
@flg_itmno_table char(1),
@flg_skuno_table char(1),
@flg_cussno_table char(1)

declare	@fm nvarchar(100), @to nvarchar(100), @date3 datetime


declare @strPart nvarchar(1000), @strRemain nvarchar(1000)

set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''
set @date3  = ''


begin

create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_CODELIST (tmp_code nvarchar(1000)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS2NO (tmp_cus2no nvarchar(10)) on [PRIMARY]
create table #TEMP_PKGREQ (tmp_reqno nvarchar(20)) on [PRIMARY]
create table #TEMP_PKGITM (tmp_item nvarchar(20)) on [PRIMARY]
create table #TEMP_PKGPRTCO (tmp_venno nvarchar(20)) on [PRIMARY]
create table #TEMP_SCNO (tmp_scno nvarchar(20)) on [PRIMARY]
create table #TEMP_TONO (tmp_tono nvarchar(20)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]
create table #TEMP_SKUNO (tmp_skuno nvarchar(20)) on [PRIMARY]
create table #TEMP_CUSSNO (tmp_cussno nvarchar(20)) on [PRIMARY]
create table #TEMP_REPRINT (tmp_reqno nvarchar(20),	tmp_repordno nvarchar(200))


--#TEMP_COCDE
if ltrim(rtrim(@codelist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @codelist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))

		insert into #TEMP_INIT values (@strPart)
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)

		insert into #TEMP_INIT values (@strRemain)
	end
	insert into #TEMP_CODELIST
	select distinct tmp_init from #TEMP_INIT
end

--------------------------------------------------------------
--------------------------------------------------------------
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
			select sod_ordno from SCORDDTL where sod_ordno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select sod_ordno from SCORDDTL where sod_ordno like @strPart
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
			select sod_ordno from SCORDDTL where sod_ordno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select sod_ordno from SCORDDTL where sod_ordno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_SCNO
	select distinct tmp_init from #TEMP_INIT
end
 
--#TEMP_TONO
if ltrim(rtrim(@tocde)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @tocde
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select tod_toordno from TOORDDTL where tod_toordno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select tod_toordno from TOORDDTL where tod_toordno like @strPart
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
			select tod_toordno from TOORDDTL where tod_toordno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select tod_toordno from TOORDDTL where tod_toordno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_TONO
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

---


--#TEMP_PKGREQ 

if ltrim(rtrim(@pkgREQlist)) <> ''
  begin
	delete from #TEMP_INIT

	set @strRemain = @pkgREQlist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select pRh_REQno from PKreqHDR (nolock) where prh_reqno between @fm and @to
			
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select pRh_REQno  from PKreqHDR (nolock) where prh_reqno like @strPart
			 
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
			select prh_reqno from PKREQHDR (nolock) where prh_reqno between @fm and @to
			 
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select prh_reqno from PKREQHDR (nolock)  where prh_reqno like @strRemain
			 
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_PKGREQ 
	select distinct tmp_init from #TEMP_INIT
end

---

--#TEMP_PKGITM  
if ltrim(rtrim(@pkgitmlist)) <> ''
  begin
	delete from #TEMP_INIT

	set @strRemain = @pkgitmlist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select pib_pgitmno from PKIMBAIF (nolock) where pib_pgitmno between @fm and @to
			
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select pib_pgitmno from PKIMBAIF (nolock) where pib_pgitmno like @strPart
			 
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
			select pib_pgitmno from PKIMBAIF (nolock) where pib_pgitmno between @fm and @to
			 
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select pib_pgitmno from PKIMBAIF (nolock)  where pib_pgitmno like @strRemain
			 
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_PKGITM  
	select distinct tmp_init from #TEMP_INIT
end

---

--#TEMP_PKGITM  
if ltrim(rtrim(@pkgitmlist)) <> ''
  begin
	delete from #TEMP_INIT

	set @strRemain = @pkgitmlist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select pib_pgitmno from PKIMBAIF (nolock) where pib_pgitmno between @fm and @to
			
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select pib_pgitmno from PKIMBAIF (nolock) where pib_pgitmno like @strPart
			 
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
			select pib_pgitmno from PKIMBAIF (nolock) where pib_pgitmno between @fm and @to
			 
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select pib_pgitmno from PKIMBAIF (nolock)  where pib_pgitmno like @strRemain
			 
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_PKGITM  
	select distinct tmp_init from #TEMP_INIT
end

---

--#TEMP_PKGPRTCO   
if ltrim(rtrim(@pkgprtco)) <> ''
  begin
	delete from #TEMP_INIT

	set @strRemain = @pkgprtco
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
			and vbi_venflag in ('P','D') and vbi_vensts = 'A'
			
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select vbi_venno from VNBASINF (nolock) where vbi_venno like @strPart
			 and vbi_venflag in ('P','D') and vbi_vensts = 'A'
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
			  and vbi_venflag in ('P','D') and vbi_vensts = 'A'
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select vbi_venno from VNBASINF (nolock)  where vbi_venno like @strRemain
			   and vbi_venflag in ('P','D') and vbi_vensts = 'A'
		end
		else
		begin
-----------
			insert into #TEMP_INIT values (@strRemain)
-------------
		end
	end
	insert into #TEMP_PKGPRTCO   
	select distinct tmp_init from #TEMP_INIT
end

---

if (select count(*) from #TEMP_CODELIST) >= 1
	set @flg_cocde_table ='Y'
else
	set @flg_cocde_table ='N'

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
--test
--select * from #TEMP_SCNO

if (select count(*) from #TEMP_TONO) >= 1
	set @flg_tono_table = 'Y'
else
	set @flg_tono_table = 'N'

--test	
--select * from #TEMP_TONO

if @reqcredatfm <> '1900/01/01'
begin
	set @flg_reqcredat_fmto  = 'Y'
	set @reqcredatto = dateadd(DD,1,@reqcredatto)
end
else
begin
	set @flg_reqcredat_fmto  = 'N'
end

if (select count(*) from #TEMP_ITMNO) >= 1
	set @flg_itmno_table = 'Y'
else
	set @flg_itmno_table = 'N'

if (select count(*) from #TEMP_SKUNO) >= 1
	set @flg_skuno_table = 'Y'
else
	set @flg_skuno_table = 'N'

if (select count(*) from #TEMP_CUSSNO) >= 1
	set @flg_cussno_table = 'Y'
else
	set @flg_cussno_table = 'N'

if (select count(*) from #TEMP_PKGREQ ) >= 1
	set @flg_pkgorder_table  = 'Y'
else
	set @flg_pkgorder_table  = 'N'


if (select count(*) from #TEMP_PKGITM ) >=1 
	set @flg_pkgitm_table  = 'Y'
else
	set @flg_pkgitm_table  = 'N'

 if (select count(*) from #TEMP_PKGPRTCO  )>= 1
	set @flg_pkgprtco_table  = 'Y'
else
	set @flg_pkgprtco_table  = 'N'

--------------------------------------------------------------
--------------------------------------------------------------


--test
--select @flg_scno_table	 as '123'
--select @flg_scissdat_fmto
--select @flg_cus1no_table
--select @flg_cus2no_table
--select @flg_scno_table
--select @flg_tono_table
--select @flg_itmno_table


select	
'' as 'prd_act', 
isnull(prd_reqno,'') as 'prd_reqno', 
isnull(prd_seq,'') as 'prd_seq', 
isnull(prd_pkgitm,'') as 'prd_pkgitm', 
prd_pkgven + ' - ' + vbi_vennam as 'prd_pkgven' ,
isnull(sod_ordno,'') as 'sod_ordno',
isnull(tod_toordno,'') as 'tod_toordno',
prh_cus1no + ' - '  + cbi_cusnam as 'prh_cus1no',
prd_itemno,
prd_assitm,
prd_cusitm,
prd_sku,
prd_pckunt as 'um',
prd_inrqty as 'inr',
prd_mtrqty as 'mst',
prd_ftyprctrm,
prd_hkprctrm,
sod_trantrm,
prd_colcde,
sod_cuspo,
sod_ordqty as 'sctoqty',
sod_conftr,
prd_ordqty,
prd_bonqty as  'prd_wasqty',
prd_ttlordqty,
prd_curcde,
prd_untprc,
prd_multip,
isnull(peh_curcde,'HKD'),
0,
isnull(peh_price,0) as 'peh_price'
from	PKREQDTL (nolock)
	left join PKREQHDR (nolock) on prh_reqno = prd_reqno
	left join  SCORDDTL   (nolock) 
		on prd_SCTONO = sod_ordno and prd_SCTOSEQ = sod_ordseq 
		and 	sod_itmno is not null 			
	 left join SCORDHDR (nolock) on sod_ordno = soh_ordno
	left join  TOORDDTL   (nolock) 
			on prd_SCTONO = tod_toordno and prd_SCTOSEQ = tod_toordseq 
			and  tod_ftyitmno  is not null 
  left join TOORDHDR (nolock) on tod_toordno = toh_toordno
	left join PKIMBAIF (nolock) on pib_pgitmno = prd_pkgitm
	left join PKESDTL (nolock) on ped_reqno = prd_reqno and ped_reqseq = prd_seq
left join VNBASINF PC (nolock) on prd_pkgven = PC.vbi_venno
	left join PKESHDR (nolock) on peh_reqno = ped_reqno and 
					peh_itemno = ped_itemno and 
					peh_assitm = ped_assitm and 
					peh_colcde = ped_colcde and 
					peh_tmpitmno = ped_tmpitmno and 
					peh_venno = ped_venno and 
					peh_venitm = ped_venitm
	left join CUBASINF on cbi_cusno = prh_cus1no
	
	where 
	  ((@flg_pkgorder_table  = 'N') or (@flg_pkgorder_table  = 'Y' and prh_reqno in (select tmp_reqno  from #TEMP_PKGREQ (nolock))))
	  and
	(
	(@flg_reqcredat_fmto  = 'N') 
	or
	 (@flg_reqcredat_fmto  = 'Y' and (prh_credat between @reqcredatfm  and @reqcredatto  ))
	)
	and  ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
 	and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
	and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and sod_ordno  is not null and sod_ordno in (select tmp_scno from #TEMP_SCNO (nolock))))
	and ((@flg_tono_table = 'N') or (@flg_tono_table = 'Y' and  tod_toordno  is not null and tod_toordno in (select tmp_tono from #TEMP_TONO (nolock))))
	and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and sod_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
	and ((@flg_skuno_table = 'N') or (@flg_skuno_table = 'Y' and sod_cussku in (select tmp_skuno from #TEMP_skuno (nolock))))
	and ((@flg_cussno_table = 'N') or (@flg_cussno_table = 'Y' and sod_cusstyno in (select tmp_cussno from #TEMP_cussno (nolock))))
	and ((@flg_pkgorder_table  = 'N') or (@flg_pkgorder_table  = 'Y' and prh_reqno in (select tmp_reqno  from #TEMP_PKGREQ (nolock))))
	and ((@flg_pkgitm_table = 'N') or (@flg_pkgitm_table  = 'Y' and pib_pgitmno in (select  tmp_item  from #TEMP_PKGITM (nolock))))
	and ((@flg_pkgprtco_table ='N') or (@flg_pkgprtco_table  ='Y' and prd_pkgven in (select tmp_venno from #TEMP_PKGPRTCO (nolock))))
	and ((@flg_cocde_table = 'N') or (@flg_cocde_table ='Y' and soh_cocde in (select tmp_code from #TEMP_CODELIST(nolock))))
	and prh_status is not null
	and prd_itemno is  not null 
	--and sod_itmtyp = 'ASS'	
	--and tod_latest = 'Y'
	--and prh_status ='REL'
	--and toh_ordsts not in  ('CLO','CAN')
	--and iba_itmno is not null	
-- 	 order by  prd_reqno, prd_seq 
order by prd_itemno,prd_assitm

drop table #TEMP_INIT 
drop table #TEMP_CUS1NO 
drop table #TEMP_CUS2NO 
drop table #TEMP_PKGREQ 
drop table #TEMP_PKGITM 
drop table #TEMP_PKGPRTCO 
drop table #TEMP_SCNO
drop table #TEMP_TONO
drop table #TEMP_ITMNO 
drop table #TEMP_CODELIST
drop table #TEMP_REPRINT

end


GO
GRANT EXECUTE ON [dbo].[sp_select_PGR00001] TO [ERPUSER] AS [dbo]
GO
