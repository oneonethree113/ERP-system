/****** Object:  StoredProcedure [dbo].[sp_list_DYR00006]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_DYR00006]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_DYR00006]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
***********************************************************************
--sp_list_DYR00006 '','UCP','','','','','','','','01/01/2011','01/05/2011','mis'
*/

CREATE procedure [dbo].[sp_list_DYR00006]
@cocde nvarchar(6),
@cocdelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@cus2nolist nvarchar(1000),
@itmnolist nvarchar(1000),
@dvlist nvarchar(1000),
@pvlist nvarchar(1000),
@quissdatfm datetime,
@quissdatto datetime,
@qurvsdatfm datetime,
@qurvsdatto datetime,
@usrid nvarchar(30)
 
AS

BEGIN

SET NOCOUNT ON


create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_COCDE (tmp_cocde nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS2NO (tmp_cus2no nvarchar(10)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]
create table #TEMP_DV (tmp_dv nvarchar(10)) on [PRIMARY]
create table #TEMP_PV (tmp_pv nvarchar(10)) on [PRIMARY]

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
cbi_custyp = 'P' and --cbi_cussts = 'A' and
(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'SC' and yur_lvl = 0)
	or ysr_saltem in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 1)
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
cbi_custyp = 'S' and --cbi_cussts = 'A' and
(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'SC' and yur_lvl = 0)
	or ysr_saltem in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 1)
	or cbi_cusno in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 2)
) and cbi_cusno > '50000'
union 
select ''
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

--#TEMP_DV
if ltrim(rtrim(@dvlist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @dvlist
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
	insert into #TEMP_DV
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



declare @flg_cocde_table char(1), 
@flg_cus1no_table char(1),
@flg_cus2no_table char(1),
@flg_itmno_table char(1),
@flg_dv_table char(1),
@flg_pv_table char(1),
@flg_quissdat_fmto char(1),
@flg_qurvsdat_fmto char(1)

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

if (select count(*) from #TEMP_DV) >= 1
	set @flg_dv_table = 'Y'
else
	set @flg_dv_table = 'N'

if (select count(*) from #TEMP_PV) >= 1
	set @flg_pv_table = 'Y'
else
	set @flg_pv_table = 'N'


if @quissdatfm <> '1900/01/01'
begin
	set @flg_quissdat_fmto = 'Y'
	set @quissdatto = dateadd(DD,1,@quissdatto)
end
else
begin
	set @flg_quissdat_fmto = 'N'
end


if @qurvsdatfm <> '1900/01/01'
begin
	set @flg_qurvsdat_fmto = 'Y'
	set @qurvsdatto = dateadd(DD,1,@qurvsdatto)
end
else
begin
	set @flg_qurvsdat_fmto = 'N'
end




create table #TEMP_QULIST
(
tmp_cocde	nvarchar(10),
tmp_qutno	nvarchar(20),
tmp_issdat	datetime,
tmp_rvsdat	datetime,
tmp_qutsts	nvarchar(10),
tmp_cus1no	nvarchar(6),
tmp_cus1sna	nvarchar(20),
tmp_cus1mkt	nvarchar(6),
tmp_cus2no	nvarchar(6),
tmp_cus2sna	nvarchar(20),
tmp_cus2mkt	nvarchar(6),
tmp_cusagt	nvarchar(6),
tmp_salrep	nvarchar(30),
tmp_prctrm	nvarchar(6),
tmp_paytrm	nvarchar(6),
tmp_smpprd	nvarchar(20),
tmp_smpfgt	nvarchar(20),
tmp_curcde	nvarchar(6),
tmp_itmno	nvarchar(20),
tmp_itmdsc	nvarchar(800),
tmp_engdsc	nvarchar(800),
tmp_colcde	nvarchar(30),
tmp_cuscol	nvarchar(30),
tmp_lnecde	nvarchar(20),
tmp_dsgcde	nvarchar(10),
tmp_dsgdsc	nvarchar(100),
tmp_catlvl0	nvarchar(20),
tmp_catlvl1	nvarchar(20),
tmp_catlvl2	nvarchar(20),
tmp_catlvl3	nvarchar(20),
tmp_catlvl4	nvarchar(20),
tmp_imdv	nvarchar(10),
tmp_imdvsna	nvarchar(40),
tmp_packing	nvarchar(100),
tmp_moq		int,
tmp_moa		numeric(11,4),
tmp_note	nvarchar(300),
tmp_pckitr	nvarchar(300),
tmp_cus1dp	numeric(13,4),
tmp_cus2dp	numeric(13,4),
tmp_hrmcde	nvarchar(12),
tmp_cususd	numeric(13,4),
tmp_cuscad	numeric(13,4),
tmp_quven	nvarchar(6),
tmp_subcde	nvarchar(20),
tmp_venitm	nvarchar(100),
tmp_fcurcde	nvarchar(6),
tmp_ftyprc	numeric(13,4),
tmp_smpqty	int,
tmp_cusitm	nvarchar(20)
)

if @flg_quissdat_fmto = 'Y'
begin

insert into #TEMP_QULIST
select 	
distinct
quh_cocde,
quh_qutno,
quh_issdat,
quh_rvsdat,
quh_qutsts,
quh_cus1no,
pri.cbi_cussna,
pri.cbi_mrktyp,
quh_cus2no,
sec.cbi_cussna,
sec.cbi_mrktyp,
quh_cusagt,
quh_salrep,
quh_prctrm,
quh_paytrm,
quh_smpprd,
quh_smpfgt,
quh_curcde,
qud_itmno,
qud_itmdsc,
ibi_engdsc,
qud_colcde,
qud_cuscol,
case vbi_ventyp when 'E' then icf_lnecde else ibi_lnecde end,
isnull(yli_dsgcde,''),
isnull(ysi_dsc,''),
ibi_catlvl0,
ibi_catlvl1,
ibi_catlvl2,
ibi_catlvl3,
ibi_catlvl4,
ibi_venno,
vbi_vensna,
qud_untcde + '/ ' + ltrim(str(qud_inrqty)) + '/ ' + ltrim(str(qud_mtrqty)) + '/ ' + ltrim(str(qud_cft,10,2)),
qud_moq,
qud_moa,
qud_note,
qud_pckitr,
qud_cus1dp,
qud_cus2dp,
qud_hrmcde,
qud_cususd,
qud_cuscad,
qud_venno,
qud_subcde,
qud_venitm,
qud_fcurcde,
qud_ftyprc,
qud_smpqty,
qud_cusitm
from QUOTNHDR (nolock)
left join QUOTNDTL (nolock) on quh_cocde = qud_cocde and quh_qutno = qud_qutno
left join IMCOLINF (nolock) on icf_itmno = qud_itmno and qud_colcde = icf_colcde
left join CUBASINF pri (nolock)	on quh_cus1no = pri.cbi_cusno
left join CUBASINF sec (nolock)	on quh_cus2no = sec.cbi_cusno
left join v_imbasinf_rpt (nolock) on qud_itmno = ibi_itmno
left join VNBASINF dsg (nolock)	on vbi_venno = ibi_venno
left join SYLNEINF (nolock) on ibi_lnecde = yli_lnecde
left join SYSETINF (nolock) on yli_dsgcde = ysi_cde and ysi_typ = 15
where quh_issdat between @quissdatfm and @quissdatto
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and quh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and quh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and quh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and qud_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_dv_table = 'N') or (@flg_dv_table = 'Y' and ibi_venno in (select tmp_dv from #TEMP_DV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and qud_venno in (select tmp_pv from #TEMP_PV (nolock))))


end
else
begin

insert into #TEMP_QULIST
select 	
distinct
quh_cocde,
quh_qutno,
quh_issdat,
quh_rvsdat,
quh_qutsts,
quh_cus1no,
pri.cbi_cussna,
pri.cbi_mrktyp,
quh_cus2no,
sec.cbi_cussna,
sec.cbi_mrktyp,
quh_cusagt,
quh_salrep,
quh_prctrm,
quh_paytrm,
quh_smpprd,
quh_smpfgt,
quh_curcde,
qud_itmno,
qud_itmdsc,
ibi_engdsc,
qud_colcde,
qud_cuscol,
case vbi_ventyp when 'E' then icf_lnecde else ibi_lnecde end,
isnull(yli_dsgcde,''),
isnull(ysi_dsc,''),
ibi_catlvl0,
ibi_catlvl1,
ibi_catlvl2,
ibi_catlvl3,
ibi_catlvl4,
ibi_venno,
vbi_vensna,
qud_untcde + '/ ' + ltrim(str(qud_inrqty)) + '/ ' + ltrim(str(qud_mtrqty)) + '/ ' + ltrim(str(qud_cft,10,2)),
qud_moq,
qud_moa,
qud_note,
qud_pckitr,
qud_cus1dp,
qud_cus2dp,
qud_hrmcde,
qud_cususd,
qud_cuscad,
qud_venno,
qud_subcde,
qud_venitm,
qud_fcurcde,
qud_ftyprc,
qud_smpqty,
qud_cusitm
from QUOTNHDR (nolock)
left join QUOTNDTL (nolock) on quh_cocde = qud_cocde and quh_qutno = qud_qutno
left join IMCOLINF (nolock) on icf_itmno = qud_itmno and qud_colcde = icf_colcde
left join CUBASINF pri (nolock)	on quh_cus1no = pri.cbi_cusno
left join CUBASINF sec (nolock)	on quh_cus2no = sec.cbi_cusno
left join v_imbasinf_rpt (nolock) on qud_itmno = ibi_itmno
left join VNBASINF dsg (nolock)	on vbi_venno = ibi_venno
left join SYLNEINF (nolock) on ibi_lnecde = yli_lnecde
left join SYSETINF (nolock) on yli_dsgcde = ysi_cde and ysi_typ = 15
where quh_rvsdat between @qurvsdatfm and @qurvsdatto
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and quh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and quh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and quh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and qud_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_dv_table = 'N') or (@flg_dv_table = 'Y' and ibi_venno in (select tmp_dv from #TEMP_DV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and qud_venno in (select tmp_pv from #TEMP_PV (nolock))))


end

SET NOCOUNT OFF


select
tmp_cocde as [Company ID],
tmp_qutno as [Quotation No],
convert(char,tmp_issdat,111) as [Issue Date],
convert(char,tmp_rvsdat,111) as [Revise Date],
tmp_qutsts as [Quotation Status],
tmp_cus1no as [Pri Customer Code],
tmp_cus1sna as [Pri Customer Short Name],
tmp_cus1mkt as [Pri Customer Market Type],
tmp_cus2no as [Sec Customer Code],
tmp_cus2sna as [Sec Customer Short Name],
tmp_cus2mkt as [Sec Customer Market Type],
tmp_cusagt as [Agent],
tmp_salrep as [Sales Rep],
tmp_prctrm as [Price Term],
tmp_paytrm as [Payment Term],
tmp_smpprd as [Sample Product Term],
tmp_smpfgt as [Sampe Freight Term],
tmp_curcde as [Currency],
tmp_itmno as [Item No],
tmp_itmdsc as [QU Item Desc],
tmp_engdsc as [IM Item Desc],
tmp_colcde as [Color Code],
tmp_cuscol as [Cust Color Code],
tmp_lnecde as [Product Line],
isnull(tmp_dsgcde,'') as [Designer Code],
isnull(tmp_dsgdsc,'') as [Designer Name],
tmp_catlvl0 as [Category L0],
tmp_catlvl1 as [Category L1],
tmp_catlvl2 as [Category L2],
tmp_catlvl3 as [Category L3],
tmp_catlvl4 as [Category L4],
tmp_imdv as [DV],
tmp_imdvsna as [DV Name],
tmp_packing as [Packing],
tmp_moq as [MOQ],
tmp_moa as [MOA],
tmp_note as [Notes],
tmp_pckitr as [Pack Instr],
tmp_cus1dp as [Discounted Price for Pri],
tmp_cus2dp as [Discounted Price for Sec],
tmp_hrmcde as [HSTU/Traiff#],
tmp_cususd as [Customer Retail(USD)],
tmp_cuscad as [Customer Retail(HKD)],
tmp_quven as [PV],
tmp_subcde as [Sub Code],
tmp_venitm as [Vendor Item No],
tmp_fcurcde as [Fty Currency],
tmp_ftyprc as [Fty Price],
tmp_smpqty as [Sample Qty],
tmp_cusitm as [Customer Item No]
from #TEMP_QULIST (nolock)


drop table #TEMP_INIT
drop table #TEMP_COCDE
drop table #TEMP_CUS1NO
drop table #TEMP_CUS2NO
drop table #TEMP_ITMNO
drop table #TEMP_DV
drop table #TEMP_PV

drop table #TEMP_QULIST


END


GO
GRANT EXECUTE ON [dbo].[sp_list_DYR00006] TO [ERPUSER] AS [dbo]
GO
