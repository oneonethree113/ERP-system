/****** Object:  StoredProcedure [dbo].[sp_list_DYR00008]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_DYR00008]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_DYR00008]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
***********************************************************************
--sp_list_DYR00008 '','UCP','','','','','','','','01/01/2011','01/05/2011','mis'
*/

CREATE procedure [dbo].[sp_list_DYR00008]
@cocde nvarchar(6),
@cocdelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@cus2nolist nvarchar(1000),
@itmnolist nvarchar(1000),
@dvlist nvarchar(1000),
@pvlist nvarchar(1000),
@srissdatfm datetime,
@srissdatto datetime,
@srrvsdatfm datetime,
@srrvsdatto datetime,
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
@flg_srissdat_fmto char(1),
@flg_srrvsdat_fmto char(1)

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


if @srissdatfm <> '1900/01/01'
begin
	set @flg_srissdat_fmto = 'Y'
	set @srissdatto = dateadd(DD,1,@srissdatto)
end
else
begin
	set @flg_srissdat_fmto = 'N'
end


if @srrvsdatfm <> '1900/01/01'
begin
	set @flg_srrvsdat_fmto = 'Y'
	set @srrvsdatto = dateadd(DD,1,@srrvsdatto)
end
else
begin
	set @flg_srrvsdat_fmto = 'N'
end




create table #TEMP_SRLIST
(
tmp_cocde	nvarchar(10),
tmp_srno	nvarchar(20),
tmp_srsts	nvarchar(10),
tmp_issdat	datetime,
tmp_rvsdat	datetime,
tmp_cv		nvarchar(6),
tmp_cvsna	nvarchar(100),
tmp_pv		nvarchar(6),
tmp_pvsna	nvarchar(100),
tmp_salrepdsc	nvarchar(200),
tmp_prctrm	nvarchar(6),
tmp_cus1no	nvarchar(6),
tmp_cus1sna	nvarchar(20),
tmp_cus2no	nvarchar(6),
tmp_cus2sna	nvarchar(20),
tmp_cussmppo	nvarchar(50),
tmp_cusdeldat	datetime,
tmp_vendeldat	datetime,
tmp_itmno	nvarchar(20),
tmp_venitm	nvarchar(20),
tmp_cusitm	nvarchar(20),
tmp_itmdsc	nvarchar(800),
tmp_engdsc	nvarchar(800),
tmp_chndsc	nvarchar(800),
tmp_vencol	nvarchar(30),
tmp_coldsc	nvarchar(300),
tmp_untcde	nvarchar(6),
tmp_inrqty	int,
tmp_mtrqty	int,
tmp_cft		numeric(11,4),
tmp_curcde	nvarchar(6),
tmp_ftyprc	numeric(13,4),
tmp_pckuntcde	nvarchar(6),
tmp_smpftyprc	numeric(13,4),
tmp_smpunt	nvarchar(6),
tmp_stkqty	int,
tmp_cusqty	int
)

if @flg_srissdat_fmto = 'Y'
begin

insert into #TEMP_SRLIST
select
distinct
srh_cocde, 
srh_reqno, 
CASE WHEN srh_reqsts = 'A' THEN 'ACT' ELSE ' ' END,
srh_issdat, 
srh_rvsdat,
isnull(srh_venno,''),
isnull(VB1.vbi_vensna, ''),
isnull(srd_prdven,''),
isnull(VB2.vbi_vensna, ''),
srh_salrep + ' - ' + SYSALREP.ysr_dsc, 
srh_prctrm, 
srh_cus1no,
CUBASINF.cbi_cussna, 
isnull(srh_cus2no, ''),
isnull(CUBASINF_1.cbi_cussna, ''),
srh_cussmppo,
srh_cusdeldat,
srh_vendeldat,
srd_itmno,
srd_venitm,
srd_cusitm,
isnull(ibi_engdsc,''),
srd_engdsc, 
srd_chndsc,
srd_vencol,
srd_coldsc,
srd_untcde,
srd_inrqty,
srd_mtrqty,
srd_cft,
srd_curcde,
srd_ftyprc,
srd_untcde,
srd_smpftyprc,
srd_smpunt,
srd_stkqty,
srd_cusqty
from
SAREQDTL (nolock)
LEFT JOIN SAREQHDR (nolock) ON srh_cocde = srd_cocde AND srh_reqno = srd_reqno
LEFT JOIN CUBASINF (nolock) ON srh_cus1no = CUBASINF.cbi_cusno AND CUBASINF.cbi_custyp = 'P' 
LEFT JOIN CUBASINF CUBASINF_1 (nolock) ON srh_cus2no = CUBASINF_1.cbi_cusno AND CUBASINF_1.cbi_custyp = 'S' 
LEFT JOIN SYSALREP (nolock) ON srh_salrep = ysr_code1	
LEFT JOIN IMBASINF (nolock) ON IBI_ITMNO = srd_itmno 
LEFT JOIN VNBASINF VB1 (nolock) ON vb1.VBI_VENNO = srh_venno
LEFT JOIN VNBASINF VB2 (nolock) ON vb2.VBI_VENNO = srd_prdven
where srh_issdat between @srissdatfm and @srissdatto
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and srh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and srh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and srh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and srd_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_dv_table = 'N') or (@flg_dv_table = 'Y' and ibi_venno in (select tmp_dv from #TEMP_DV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and srd_prdven in (select tmp_pv from #TEMP_PV (nolock))))
order by srh_cocde, srh_reqno

end
else
begin

insert into #TEMP_SRLIST
select
distinct
srh_cocde, 
srh_reqno, 
CASE WHEN srh_reqsts = 'A' THEN 'ACT' ELSE ' ' END,
srh_issdat, 
srh_rvsdat,
isnull(srh_venno,''),
isnull(VB1.vbi_vensna, ''),
isnull(srd_prdven,''),
isnull(VB2.vbi_vensna, ''),
srh_salrep + ' - ' + SYSALREP.ysr_dsc, 
srh_prctrm, 
srh_cus1no,
CUBASINF.cbi_cussna, 
isnull(srh_cus2no, ''),
isnull(CUBASINF_1.cbi_cussna, ''),
srh_cussmppo,
srh_cusdeldat,
srh_vendeldat,
srd_itmno,
srd_venitm,
srd_cusitm,
isnull(ibi_engdsc,''),
srd_engdsc, 
srd_chndsc,
srd_vencol,
srd_coldsc,
srd_untcde,
srd_inrqty,
srd_mtrqty,
srd_cft,
srd_curcde,
srd_ftyprc,
srd_untcde,
srd_smpftyprc,
srd_smpunt,
srd_stkqty,
srd_cusqty
from
SAREQDTL (nolock)
LEFT JOIN SAREQHDR (nolock) ON srh_cocde = srd_cocde AND srh_reqno = srd_reqno
LEFT JOIN CUBASINF (nolock) ON srh_cus1no = CUBASINF.cbi_cusno AND CUBASINF.cbi_custyp = 'P' 
LEFT JOIN CUBASINF CUBASINF_1 (nolock) ON srh_cus2no = CUBASINF_1.cbi_cusno AND CUBASINF_1.cbi_custyp = 'S' 
LEFT JOIN SYSALREP (nolock) ON srh_salrep = ysr_code1	
LEFT JOIN IMBASINF (nolock) ON IBI_ITMNO = srd_itmno 
LEFT JOIN VNBASINF VB1 (nolock) ON vb1.VBI_VENNO = srh_venno
LEFT JOIN VNBASINF VB2 (nolock) ON vb2.VBI_VENNO = srd_prdven
where srh_rvsdat between @srrvsdatfm and @srrvsdatto
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and srh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and srh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and srh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and srd_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_dv_table = 'N') or (@flg_dv_table = 'Y' and ibi_venno in (select tmp_dv from #TEMP_DV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and srd_prdven in (select tmp_pv from #TEMP_PV (nolock))))
order by srh_cocde, srh_reqno




end

SET NOCOUNT OFF


select
tmp_cocde as [Company ID],
tmp_srno as [Sample Request No],
tmp_srsts as [Status],
convert(varchar(10),tmp_issdat,111) as [Issue Date],
convert(varchar(10),tmp_rvsdat,111) as [Revise Date],
tmp_cv as [CV],
tmp_cvsna as [CV Name],
tmp_pv as [PV],
tmp_pvsna as [PV Name],
tmp_salrepdsc as [Sales Rep],
tmp_prctrm as [Price Term],
tmp_cus1no as [Pri Cust],
tmp_cus1sna as [Pri Cust Name],
tmp_cus2no as [Sec Cust],
tmp_cus2sna as [Sec Cust Name],
tmp_cussmppo as [Cust Sample PO No],
convert(varchar(10),tmp_cusdeldat,111) as [Cust Req Delivery Date], 
convert(varchar(10),tmp_vendeldat,111) as [Ven Delivery Date],
tmp_itmno as [Item No],
tmp_venitm as [Ven Item No],
tmp_cusitm as [Cust Item No],
tmp_itmdsc as [IM Desc],
tmp_engdsc as [Eng Desc],
tmp_chndsc as [Chin Desc],
tmp_vencol as [Ven Color Code],
tmp_coldsc as [Color Desc],
tmp_untcde as [UM],
tmp_inrqty as [Inner],
tmp_mtrqty as [Master],
tmp_cft as [CFT],
tmp_curcde as [Currency],
tmp_ftyprc as [Item Cost],
tmp_pckuntcde as [Packing UM],
tmp_smpftyprc as [Item Sample Price],
tmp_smpunt as [Sample UM],
tmp_stkqty as [Sample for Stock],
tmp_cusqty as [Sample for Customer]
from #TEMP_SRLIST (nolock)


drop table #TEMP_INIT
drop table #TEMP_COCDE
drop table #TEMP_CUS1NO
drop table #TEMP_CUS2NO
drop table #TEMP_ITMNO
drop table #TEMP_DV
drop table #TEMP_PV

drop table #TEMP_SRLIST


END


GO
GRANT EXECUTE ON [dbo].[sp_list_DYR00008] TO [ERPUSER] AS [dbo]
GO
