/****** Object:  StoredProcedure [dbo].[sp_list_DYR00009]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_DYR00009]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_DYR00009]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
***********************************************************************
--sp_list_DYR00009 '','UCP','','','','','','01/01/2011','01/05/2011','','','','','LAYOUT001','mis'
*/

CREATE  procedure [dbo].[sp_list_DYR00009]
@cocde nvarchar(6),
@cocdelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@cus2nolist nvarchar(1000),
@itmnolist nvarchar(1000),
@dvlist nvarchar(1000),
@pvlist nvarchar(1000),
@scshpstrdatfm datetime,
@scshpstrdatto datetime,
@scissdatfm datetime,
@scissdatto datetime,
@shslndatfm datetime,
@shslndatto datetime,
@layout	nvarchar(10),
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
@flg_scissdat_fmto char(1),
@flg_shslndat_fmto char(1),
@flg_scshpstrdat_fmto char(1)


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


if @scissdatfm <> '01/01/1900'
begin
	set @flg_scissdat_fmto = 'Y'
	set @scissdatto = dateadd(DD,1,@scissdatto)
end
else
begin
	set @flg_scissdat_fmto = 'N'
end


if @shslndatfm <> '01/01/1900'
begin
	set @flg_shslndat_fmto = 'Y'
	set @shslndatto = dateadd(DD,1,@shslndatto)
end
else
begin
	set @flg_shslndat_fmto = 'N'
end


if @scshpstrdatfm <> '01/01/1900'
begin
	set @flg_scshpstrdat_fmto = 'Y'
	set @scshpstrdatto = dateadd(DD,1,@scshpstrdatto)
end
else
begin
	set @flg_scshpstrdat_fmto = 'N'
end


create table #TEMP_TX_SC
(
tmp_cocde	varchar(6),
tmp_ordno	varchar(20),
tmp_ordseq	int
)



if @flg_scshpstrdat_fmto = 'Y'
begin

insert into #TEMP_TX_SC
select distinct sod_cocde, sod_ordno, sod_ordseq
from SCORDHDR (nolock), SCORDDTL (nolock) where 
sod_shpstr between @scshpstrdatfm and @scshpstrdatto and
soh_cocde = sod_cocde and soh_ordno = sod_ordno 
order by sod_ordno, sod_ordseq

end
else if @flg_scissdat_fmto = 'Y'
begin

insert into #TEMP_TX_SC
select distinct sod_cocde, sod_ordno, sod_ordseq
from SCORDHDR (nolock), SCORDDTL (nolock) where 
soh_issdat between @scissdatfm and @scissdatto and
soh_cocde = sod_cocde and soh_ordno = sod_ordno 
order by sod_ordno, sod_ordseq

end
else if @flg_shslndat_fmto = 'Y'
begin

insert into #TEMP_TX_SC
select distinct sod_cocde, sod_ordno, sod_ordseq
from SHIPGHDR (nolock), SHIPGDTL (nolock), SCORDDTL (nolock) 
where 
hih_slnonb between @shslndatfm and @shslndatto and
hid_cocde = hih_cocde and hid_shpno = hih_shpno and
sod_cocde = hid_cocde and hid_ordno = sod_ordno and hid_ordseq = sod_ordseq
order by sod_ordno, sod_ordseq

end



create table #TEMP_SHPCKDIM
(
hpd_cocde	varchar(6),
hpd_shpno	varchar(20),
hpd_shpseq	int,
hpd_actcbm_cm	numeric(13,4),
hpd_modcbm_cm	numeric(13,4)
)

insert into #TEMP_SHPCKDIM
select hid_cocde, hid_shpno, hid_shpseq, sum(case hpd_dimtyp when 'Act' then hpd_cbm_cm else 0 end),sum(case hpd_dimtyp when 'Mod' then hpd_cbm_cm else 0 end) 
from #TEMP_TX_SC (nolock)
left join SHIPGDTL (nolock) on tmp_ordno = hid_ordno and tmp_ordseq = hid_ordseq
left join SHPCKDIM (nolock) on hid_shpno = hpd_shpno and hid_shpseq = hpd_shpseq 
where hid_shpno is not null
group by hid_cocde, hid_shpno, hid_shpseq








create table #TEMP_SCLIST
(
tmp_soh_cocde		varchar(6),
tmp_soh_ordno		varchar(20),
tmp_soh_ordsts		varchar(10),
tmp_soh_issdat		datetime,
tmp_soh_rvsdat		datetime,
tmp_soh_cus1sna		nvarchar(30),
tmp_soh_cus1no		varchar(10),
tmp_sho_cus2sna		nvarchar(30),
tmp_soh_cus2no		varchar(10),
tmp_soh_cttper		nvarchar(50),
tmp_soh_agt		nvarchar(20),
tmp_soh_salrepdsc	nvarchar(50),
tmp_ysr_saltem		nvarchar(20),
tmp_soh_cuspo		varchar(20),
tmp_soh_cpodat		datetime,
tmp_soh_resppo		nvarchar(20),
tmp_soh_bilcty		nvarchar(20),
tmp_soh_shpcty		nvarchar(20),
tmp_sod_shpstr		datetime,
tmp_sod_shpend		datetime,
tmp_sod_candat		datetime,
tmp_soh_prctrm		varchar(10),
tmp_soh_paytrm		nvarchar(300),
tmp_soh_ttlvol		numeric(13,4),
tmp_soh_cft		numeric(13,4),
tmp_soh_curcde		varchar(6),
tmp_soh_netamt		numeric(13,4),
tmp_sod_ordseq		int,
tmp_sod_itmno		varchar(20),
tmp_sod_itmdsc		nvarchar(200),
tmp_ibi_engdsc		nvarchar(200),
tmp_imu_ftycst		numeric(13,4),
tmp_imu_calftyprc	numeric(13,4),
tmp_imu_negprc		numeric(13,4),
tmp_imu_basprc		numeric(13,4),
tmp_ibi_lnecde		varchar(20),
tmp_yli_lnedsc		nvarchar(250),
tmp_yli_dsgcde		varchar(20),
tmp_yli_dsgdsc		varchar(250),
tmp_ibi_catlvl0		varchar(20),
tmp_ibi_catlvl0dsc	varchar(250),
tmp_ibi_catlvl1		varchar(20),
tmp_ibi_catlvl1dsc	varchar(250),
tmp_ibi_catlvl2		varchar(20),
tmp_ibi_catlvl2dsc	varchar(250),
tmp_ibi_catlvl3		varchar(20),
tmp_ibi_catlvl3dsc	varchar(250),
tmp_ibi_catlvl4		varchar(20),
tmp_ibi_catlvl4dsc	varchar(250),
tmp_ibi_typ		varchar(4),
tmp_imdv		varchar(6),
tmp_imdvdsc		nvarchar(100),
tmp_imdpv		varchar(6),
tmp_imdpvdsc		nvarchar(100),
tmp_imcv		varchar(6),
tmp_sod_dept		nvarchar(50),
tmp_packing		varchar(100),
tmp_sod_pckunt		varchar(6),
tmp_sod_conftr		int,
tmp_sod_inrctn		int,
tmp_sod_mtrctn		int,
tmp_sod_colcde		varchar(30),
tmp_sod_cft		numeric(11,4),
tmp_sod_cbm		numeric(11,4),
tmp_sod_coldsc		nvarchar(300),
tmp_sod_cusstyno	nvarchar(30),
tmp_sod_cusitm		varchar(30),
tmp_sod_cussku		varchar(30),
tmp_sod_ordqty		int,
tmp_sod_shpqty		int,
tmp_sod_itmprc		numeric(13,4),
tmp_sod_untprc		numeric(13,4),
tmp_sod_qutdat		datetime,
tmp_sod_netuntprc	numeric(13,4),
tmp_sod_selprc		numeric(13,4),
tmp_sod_discnt		numeric(6,3),
tmp_sod_moqchg		numeric(6,3),
tmp_sod_oneprc		char(1),
tmp_sod_ctnstr		int,
tmp_sod_ctnend		int,
tmp_sod_ttlctn		int,
tmp_sod_cususd		numeric(13,4),
tmp_sod_cuscad		numeric(13,4),
tmp_iba_itmno		varchar(20),
tmp_cv			varchar(10),
tmp_cvdsc		nvarchar(100),
tmp_pv			varchar(10),
tmp_pvdsc		nvarchar(100),
tmp_sod_subcde		varchar(50),
tmp_vbi_vennam		nvarchar(300),
tmp_sod_venitm		varchar(30),
tmp_sod_fcurcde		varchar(10),
tmp_sod_ftycst		numeric(13,4),
tmp_sod_bomcst		numeric(13,4),
tmp_sod_ftyprc		numeric(13,4),
tmp_dv			varchar(10),
tmp_dvdsc		nvarchar(100),
tmp_sod_dvfcurcde	varchar(10),
tmp_sod_dvftycst	numeric(13,4),
tmp_sod_dvbomcst	numeric(13,4),
tmp_sod_dvftyprc	numeric(13,4),
tmp_sod_imqutdat	datetime,
tmp_pod_purord		varchar(20),
tmp_pod_jobord		varchar(20),
tmp_poh_issdat		datetime,
tmp_pod_ordqty		int,
tmp_pod_recqty		int,
tmp_pod_shpstr		datetime,
tmp_pod_shpend		datetime,
tmp_hid_ctrcfs		varchar(20),
tmp_hid_shpno		varchar(20),
tmp_hid_shpseq		int,
tmp_hid_invno		varchar(20),
tmp_hiv_invdat		datetime,
tmp_hih_slnonb		datetime,
tmp_hih_arrdat		datetime,
tmp_hih_ves		nvarchar(30),
tmp_hih_voy		nvarchar(30),
tmp_hih_potloa		nvarchar(30),
tmp_hih_dst		nvarchar(60),
tmp_hid_cuspo		nvarchar(20),
tmp_hid_shpqty		int,
tmp_hid_untsel		varchar(6),
tmp_hid_selprc		numeric(11,4),
tmp_hid_ttlamt		numeric(13,4),
tmp_hid_grswgt		numeric(11,4),
tmp_hid_netwgt		numeric(11,4),
tmp_hid_actvol		numeric(11,4),
tmp_hiv_prctrm		varchar(20),
tmp_hiv_paytrm		varchar(20),
tmp_hiv_ttlamt		numeric(13,4),
tmp_hiv_ttlvol		numeric(13,4),
tmp_hiv_ttlctn		numeric(13,4)
)


--select @flg_scissdat_fmto,@flg_shslndat_fmto,@flg_scshpstrdat_fmto

--select @shslndatfm , @shslndatto
SET NOCOUNT OFF

if @layout = 'LAYOUT001'
begin

select 
distinct
soh_cocde as [Company ID],
convert(varchar(10),soh_issdat,101) as [Issue Date],
soh_ordno as [SC No],
soh_cus1no + ' - ' + ltrim(c1.cbi_cussna) as [Pri Customer],
isnull(soh_cus2no + ' - ' + ltrim(c2.cbi_cussna),'') as [Sec Customer],
isnull(i.ibi_catlvl4,'') as [Cat L4],
isnull(YCC4.YCC_CATDSC,'') as [Cat L4 Desc],
d.sod_itmno as [Item No],
d.sod_venitm as [PV Item],
d.sod_cusitm as [Cust Item],
left(i.ibi_engdsc, 200) as [IM Item Desc],
d.sod_colcde as [Color Code],
CAST(d.sod_pckunt AS nvarchar(6)) + ' / ' + CAST(d.sod_inrctn AS nvarchar(10)) + ' / ' + CAST(d.sod_mtrctn AS nvarchar(10)) + ' / ' + CAST(d.sod_cft AS nvarchar(10)) + ' / ' + CAST(d.sod_cbm AS nvarchar(10)) as [Packing],
d.sod_pckunt as [UM],
d.sod_conftr as [Conversion Factor],
d.sod_ordqty as [Order Qty],
d.sod_shpqty as [Total Shipped Qty],
ltrim(soh_curcde) as [Currency],
d.sod_pckcst as [Packaging $],
d.sod_itmcom as [Commission $],
d.sod_untprc as [Selling Price],
case year(d.sod_qutdat) when '1900' then '' else convert(char(4),year(d.sod_qutdat)) + '-' + left('0'+ convert(char(2),month(d.sod_qutdat)),2) end as [CIH Period], 
ibi_venno + ' - ' + isnull(vv.vbi_vensna, '') as [IM DV Name],
--vv.vbi_vensna as [IM DV Name],
d.sod_dvfcurcde as [DV Currency],
d.sod_dvftyprc as [DV TTL Cost],
case year(d.sod_imqutdat) when '1900' then '' else convert(char(4),year(d.sod_imqutdat)) + '-' + left('0'+ convert(char(2),month(d.sod_imqutdat)),2) end as [SC Period],
d.sod_venno + ' - ' + isnull(v.vbi_vensna, '') as [PV Name],
d.sod_fcurcde as [PV Currency],
d.sod_ftycst as [PV Item Cost],
d.sod_ftyprc as [PV TTL Cost],
convert(varchar(10),d.sod_shpstr,101) as [Ship Start Date],
convert(varchar(10),d.sod_shpend,101) as [Ship End Date],
isnull(s.hid_invno,'') as [Invoice No],
isnull(s.hid_shpno,'') as [Shipping No],
s.hid_shpseq as [Shipping Seq],
convert(varchar(10),h.hih_slnonb,101) as [Sailing on/abt (ETD)],
s.hid_shpqty as [Invoice Qty],
--s.hid_actvol as [Invoice Actual CBM]
--pd_act.hpd_cbm_cm as [Invoice Actual CBM],
--pd_mod.hpd_cbm_cm as [Invoice Modify CBM]
hpd_actcbm_cm as [Invoice Actual CBM],
hpd_modcbm_cm as [Invoice Modify CBM]

from 
#TEMP_TX_SC (nolock)
left join SCORDHDR (nolock) on soh_cocde = tmp_cocde and soh_ordno = tmp_ordno
left outer join SYSALREP b (nolock) on b.ysr_code1 = soh_salrep
left outer join CUBASINF c1 (nolock) on c1.cbi_cusno = soh_cus1no
left outer join SYSALREP b1 (nolock) on b1.ysr_code1 = c1.cbi_salrep
left outer join CUBASINF c2 (nolock) on c2.cbi_cusno = soh_cus2no
left outer join SCORDDTL d (nolock) on d.sod_cocde = soh_cocde and d.sod_ordno = soh_ordno and d.sod_ordseq = tmp_ordseq
left join IMCOLINF (nolock) on icf_itmno = sod_itmno and sod_colcde = icf_colcde
left outer join VNBASINF v (nolock) on v.vbi_venno = d.sod_venno
left outer join VNBASINF vd (nolock) on vd.vbi_venno = d.sod_dv
left outer join VNBASINF vc (nolock) on vc.vbi_venno = d.sod_cusven
left outer join POORDDTL p (nolock) on d.sod_cocde = p.pod_cocde and d.sod_purord = p.pod_purord and d.sod_purseq = p.pod_purseq
left join POORDHDR (nolock) on p.pod_purord = poh_purord and poh_cocde = p.pod_cocde
left outer join v_imbasinf_rpt i on d.sod_itmno = i.ibi_itmno
left outer join VNBASINF vv (nolock) on vv.vbi_venno = ibi_venno
left outer join IMVENINF (nolock) on d.sod_itmno = ivi_itmno and ivi_def = 'Y'
left outer join IMBOMASS (nolock) on d.sod_itmno = iba_itmno and iba_typ = 'BOM'
left outer join VNBASINF v1 (nolock) on v1.vbi_venno = ivi_venno
left outer join v_immrkup_rpt m (nolock) on m.imu_itmno = i.ibi_itmno and m.imu_pckunt = d.sod_pckunt and m.imu_inrqty = d.sod_inrctn and m.imu_mtrqty = d.sod_mtrctn and m.imu_ventyp = 'D'
--left outer join v_immrkup_rpt m (nolock) on m.imu_itmno = i.ibi_itmno and m.imu_pckunt = d.sod_pckunt and m.imu_inrqty = d.sod_inrctn and m.imu_mtrqty = d.sod_mtrctn and m.imu_ventyp = 'D'  and m.imu_prdven = m.imu_venno
left outer join immrkup pv (nolock) on pv.imu_itmno = i.ibi_itmno and pv.imu_pckunt = d.sod_pckunt and pv.imu_inrqty = d.sod_inrctn and pv.imu_mtrqty = d.sod_mtrctn and pv.imu_ventyp = 'P' and pv.imu_prdven = d.sod_venno
left outer join SHIPGDTL s (nolock) on s.hid_cocde = d.sod_cocde and s.hid_ordno = d.sod_ordno and s.hid_ordseq = d.sod_ordseq
left outer join SHINVHDR j (nolock) on j.hiv_cocde = s.hid_cocde and j.hiv_shpno = s.hid_shpno and  j.hiv_invno = s.hid_invno
left outer join SHIPGHDR h (nolock) on h.hih_cocde = s.hid_cocde and h.hih_shpno = s.hid_shpno

left outer join #TEMP_SHPCKDIM (nolock) on hpd_shpno = s.hid_shpno and hpd_shpseq = s.hid_shpseq

left outer join SYCATCDE YCC0 (nolock) on YCC0.YCC_CATCDE = i.ibi_catlvl0
left outer join SYCATCDE YCC1 (nolock) on YCC1.YCC_CATCDE = i.ibi_catlvl1
left outer join SYCATCDE YCC2 (nolock) on YCC2.YCC_CATCDE = i.ibi_catlvl2
left outer join SYCATCDE YCC3 (nolock) on YCC3.YCC_CATCDE = i.ibi_catlvl3
left outer join SYCATCDE YCC4 (nolock) on YCC4.YCC_CATCDE = i.ibi_catlvl4
left outer join SYLNEINF inlne (nolock) on i.ibi_lnecde = inlne.yli_lnecde    
left outer join SYLNEINF exlne (nolock) on icf_lnecde = exlne.yli_lnecde
left outer join SYSETINF dsg (nolock) on inlne.yli_dsgcde = dsg.ysi_cde and dsg.ysi_typ = 15
left outer join SYSETINF pay (nolock) on soh_paytrm  = pay.ysi_cde and pay.ysi_typ = '04'
where
((@flg_shslndat_fmto = 'N') or (@flg_shslndat_fmto = 'Y' and hih_slnonb between @shslndatfm and @shslndatto))
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and soh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and sod_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_dv_table = 'N') or (@flg_dv_table = 'Y' and sod_dv in (select tmp_dv from #TEMP_DV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and sod_venno in (select tmp_pv from #TEMP_PV (nolock))))
order by soh_cocde, soh_ordno

end
else
begin

select
distinct
soh_cocde as [Company ID],
soh_ordno as [SC No],
soh_ordsts as [SC Status],
convert(varchar(10),soh_issdat,101) as [Issue Date],
convert(varchar(10),soh_rvsdat,101) as [Revised Date],
soh_cus1no + ' - ' + ltrim(c1.cbi_cussna) as [Pri Customer],
soh_cus1no as [Pri Customer Name],
isnull(soh_cus2no + ' - ' + ltrim(c2.cbi_cussna),'') as [Sec Customer],
isnull(soh_cus2no,'') as [Sec Customer Name],
soh_cttper as [Contact Person],
soh_agt as [Agent],
--soh_salrep + ' - ' + isnull(b.ysr_dsc, 'User Not Found') + ' (TEAM ' + isnull(b.ysr_saltem, '') + ')' as [Sales Rep],
--isnull(b1.ysr_saltem, '') as [Sales Team],
c1.cbi_saltem as [Sales Team],
soh_cuspo as [Customer PO],
convert(varchar(10),soh_cpodat,101) as [Cust PO Date],
soh_resppo as [Resp. PO],
soh_bilcty as [Billing Country],
soh_shpcty as [Shipping Country],
convert(varchar(10),d.sod_shpstr,101) as [Ship Start Date],
convert(varchar(10),d.sod_shpend,101) as [Ship End Date],
case convert(varchar(10),d.sod_candat,101) when '01/01/1900' then '' else convert(varchar(10), d.sod_candat,101) end as [Cancel Date],
soh_prctrm as [Price Term],
soh_paytrm + ' - ' + isnull(pay.ysi_dsc,'') as [Payment Term],
soh_ttlvol as [Total Cube (CBM)],
soh_cft as [Total CFT],
ltrim(soh_curcde) as [Currency],
round(soh_netamt, 2) as [Net Amount],
d.sod_ordseq as [SC Seq],
d.sod_itmno as [Item No],
left(d.sod_itmdsc, 200) as [SC Item Desc],
left(i.ibi_engdsc, 200) as [IM Item Desc],
m.imu_ftycst as [IM Fty Cost],
--pv.imu_calftyprc as [IM PV Cal Price],
--pv.imu_negprc as [IM PV Neg Price],
m.imu_basprc as [IM Basic Price],
case vv.vbi_ventyp when 'E' then isnull(icf_lnecde,'') else isnull(i.ibi_lnecde,'') end as [Product Line],
case vv.vbi_ventyp when 'E' then isnull(exlne.yli_lnedsc,'') else isnull(inlne.yli_lnedsc,'') end as [Product Line Desc],
isnull(inlne.yli_dsgcde,'') as [Designer Code],
isnull(dsg.ysi_dsc,'') as [Designer Name],
isnull(i.ibi_catlvl0,'') as [Cat L0],
isnull(YCC0.ycc_catdsc,'') as [Cat L0 Desc],
isnull(i.ibi_catlvl1,'') as [Cat L1],
isnull(YCC1.YCC_CATDSC,'') as [Cat L1 Desc],
isnull(i.ibi_catlvl2,'') as [Cat L2],
isnull(YCC2.YCC_CATDSC,'') as [Cat L2 Desc],
isnull(i.ibi_catlvl3,'') as [Cat L3],
isnull(YCC3.YCC_CATDSC,'') as [Cat L3 Desc],
isnull(i.ibi_catlvl4,'') as [Cat L4],
isnull(YCC4.YCC_CATDSC,'') as [Cat L4 Desc],
i.ibi_typ as [Item Type],

isnull(ysi_mat.ysi_dsc,'') as [Key Material],
case isnull(ysi_nat_i.ysi_dsc,'') when '' then isnull(ysi_nat_e.ysi_dsc,'') else isnull(ysi_nat_i.ysi_dsc,'')  end as [Item Nature], 
isnull(ysi_pg.ysi_dsc,'') as [Product Group],
isnull(ysi_pi.ysi_dsc,'') as [Product Icon],
isnull(ysi_season.ysi_dsc,'') as [Season (IM)],
isnull(sod_season,'') as [Season (SC)],

--ibi_venno as [IM DV],
--vv.vbi_vensna as [IM DV Name],
--ivi_venno as [IM Def PV],
--v1.vbi_vensna as [IM Def PV Name],
--i.ibi_cusven as [IM CV],
isnull(d.sod_dept,'') as [Dept],
--CAST(d.sod_pckunt AS nvarchar(6)) + ' / ' + CAST(d.sod_inrctn AS nvarchar(10)) + ' / ' + CAST(d.sod_mtrctn AS nvarchar(10)) + ' / ' + CAST(d.sod_cft AS nvarchar(10)) + ' / ' + CAST(d.sod_cbm AS nvarchar(10)) as [Packing],
d.sod_pckunt as [UM],
d.sod_conftr as [Conversion Factor],
d.sod_inrctn as [Inner],
d.sod_mtrctn as [Master],
d.sod_cbm as [CBM],
d.sod_cft as [CFT],
d.sod_colcde as [Color Code],
d.sod_coldsc as [Color Desc],
d.sod_cusstyno as [Cust Style No],
d.sod_cusitm as [Cust Item],
d.sod_cussku as [Cust SKU],
d.sod_ordqty as [Order Qty],
d.sod_shpqty as [Total Shipped Qty],
d.sod_itmprc as [SC Basic Price],
d.sod_untprc as [Selling Price],
case year(d.sod_qutdat) when '1900' then '' else convert(char(4),year(d.sod_qutdat)) + '-' + right('0'+ convert(char(2),month(d.sod_qutdat)),2) end as [CIH Period], 
d.sod_pckcst as [Packaging $],
d.sod_itmcom as [Commission $],
d.sod_netuntprc as [Net Price],
d.sod_selprc as [Sub Total],
d.sod_discnt as [Discount %],
d.sod_moqchg as [MOQ Charges %],
d.sod_oneprc as [One Time Price],
d.sod_ctnstr as [CTN No Start],
d.sod_ctnend as [CTN No End],
d.sod_ttlctn as [Total Carton],
d.sod_cususd as [Customer Retail (USD)],
d.sod_cuscad as [Customer Retail (CAD)],
d.sod_hrmcde as [Tariff Code],
case isnull(iba_itmno,'') when '' then '' else 'Y' end as [BOM],
--d.sod_cusven as [CV Code],
d.sod_cusven + ' - ' + isnull(vc.vbi_vensna, '') as [CV Name],
d.sod_tradeven + ' - ' + isnull(vt.vbi_vensna, '') as [TV Name],
d.sod_examven + ' - ' + isnull(ve.vbi_vensna, '') as [FA Name],
--d.sod_venno as [PV Code],
d.sod_venno + ' - ' + isnull(v.vbi_vensna, '') as [PV Name],
d.sod_subcde as [Sub Code],
--v.vbi_vennam as [PV Full Name],
d.sod_venitm as [PV Item],
d.sod_fcurcde as [PV Currency],
d.sod_ftycst as [PV Item Cost],
d.sod_bomcst as [PV TTL BOM Cost],
d.sod_ftyprc as [PV TTL Cost],
--d.sod_dv as [DV Code],
d.sod_dv + ' - ' + isnull(vd.vbi_vensna, '') as [DV Name],
d.sod_dvfcurcde as [DV Currency],
d.sod_dvftycst as [DV Item Cost],
d.sod_dvbomcst as [DV TTL BOM Cost],
d.sod_dvftyprc as [DV TTL Cost],
case year(d.sod_imqutdat) when '1900' then '' else convert(char(4),year(d.sod_imqutdat)) + '-' + right('0'+ convert(char(2),month(d.sod_imqutdat)),2) end as [SC Period],
isnull(p.pod_purord,'') as [PO No],
isnull(p.pod_jobord,'') as [Job No],
convert(varchar(10),poh_credat,101) as [PO Issue Date],
p.pod_ordqty as [PO Order Qty],
p.pod_recqty as [PO Recv Qty],
convert(varchar(10),p.pod_shpstr,101) as [PO Ship Start Date],
convert(varchar(10),p.pod_shpend,101) as [Po Ship End Date],
s.hid_ctrcfs as [Container No],
s.hid_shpno as [Shipping No],
s.hid_shpseq as [Shipping Seq],
s.hid_invno as [Invoice No],
convert(varchar(10),j.hiv_invdat,101) as [Invoice Date],
convert(varchar(10),h.hih_slnonb,101) as [Sailing on/abt (ETD)],
convert(varchar(10),h.hih_arrdat,101) as [Arrival Date (ETA)],
h.hih_ves as [Vessel],
h.hih_voy as [Voyage],
h.hih_potloa as [Port of Loading],
h.hih_dst as [Dest Carrier],
s.hid_cuspo as [Invoice Cust PO],
s.hid_shpqty as [Invoice Qty],
s.hid_untsel as [Invoice Currency],
s.hid_selprc as [Invoice Selling Price],
s.hid_ttlamt as [Invoice Amount],

--s.hid_grswgt as [Invoice Grs Wgt],
--s.hid_netwgt as [Invoice Net Wgt],

--s.hid_actvol as [Invoice Actual CBM],
--pd_act.hpd_cbm_cm as [Invoice Actual CBM],
--pd_mod.hpd_cbm_cm as [Invoice Modify CBM],

hpd_actcbm_cm as [Invoice Actual CBM],
hpd_modcbm_cm as [Invoice Modify CBM],

j.hiv_prctrm as [Invoice Price Term],
j.hiv_paytrm + ' - ' + isnull(payi.ysi_dsc,'')  as [Invoice Payment Term],
j.hiv_ttlamt as [Total Invoice Amount],
j.hiv_ttlvol as [Total Vol],
j.hiv_ttlctn as [Total No of Cartons],
case s.hid_ctrsiz when '' then 'CFS' when '40''HQ(Reef' then '40''HQ(Reefer Dry)' else s.hid_ctrsiz end as [Container Size]
from 
#TEMP_TX_SC (nolock)
left join SCORDHDR (nolock) on soh_cocde = tmp_cocde and soh_ordno = tmp_ordno
left outer join SYSALREP b (nolock) on b.ysr_code1 = soh_salrep
left outer join CUBASINF c1 (nolock) on c1.cbi_cusno = soh_cus1no
left outer join SYSALREP b1 (nolock) on b1.ysr_code1 = c1.cbi_salrep
left outer join CUBASINF c2 (nolock) on c2.cbi_cusno = soh_cus2no
left outer join SCORDDTL d (nolock) on d.sod_cocde = soh_cocde and d.sod_ordno = soh_ordno and d.sod_ordseq = tmp_ordseq
left join IMCOLINF (nolock) on icf_itmno = sod_itmno and sod_colcde = icf_colcde
left outer join VNBASINF v (nolock) on v.vbi_venno = d.sod_venno
left outer join VNBASINF vd (nolock) on vd.vbi_venno = d.sod_dv
left outer join VNBASINF vc (nolock) on vc.vbi_venno = d.sod_cusven
left outer join VNBASINF vt (nolock) on vt.vbi_venno = d.sod_tradeven
left outer join VNBASINF ve (nolock) on ve.vbi_venno = d.sod_examven
left outer join POORDDTL p (nolock) on d.sod_cocde = p.pod_cocde and d.sod_purord = p.pod_purord and d.sod_purseq = p.pod_purseq --and d.sod_ordqty > 0
left join POORDHDR (nolock) on p.pod_purord = poh_purord and poh_cocde = p.pod_cocde
left outer join v_imbasinf_rpt i on d.sod_itmno = i.ibi_itmno
left outer join VNBASINF vv (nolock) on vv.vbi_venno = ibi_venno
left outer join IMVENINF (nolock) on d.sod_itmno = ivi_itmno and ivi_def = 'Y'
left outer join IMBOMASS (nolock) on d.sod_itmno = iba_itmno and iba_typ = 'BOM'
left outer join VNBASINF v1 (nolock) on v1.vbi_venno = ivi_venno
left outer join v_immrkup_rpt m (nolock) on m.imu_itmno = i.ibi_itmno and m.imu_pckunt = d.sod_pckunt and m.imu_inrqty = d.sod_inrctn and m.imu_mtrqty = d.sod_mtrctn and m.imu_ventyp = 'D' 
--left outer join v_immrkup_rpt m (nolock) on m.imu_itmno = i.ibi_itmno and m.imu_pckunt = d.sod_pckunt and m.imu_inrqty = d.sod_inrctn and m.imu_mtrqty = d.sod_mtrctn and m.imu_ventyp = 'D'  and m.imu_prdven = m.imu_venno
left outer join immrkup pv (nolock) on pv.imu_itmno = i.ibi_itmno and pv.imu_pckunt = d.sod_pckunt and pv.imu_inrqty = d.sod_inrctn and pv.imu_mtrqty = d.sod_mtrctn and pv.imu_ventyp = 'P' and pv.imu_prdven = d.sod_venno
left outer join SHIPGDTL s (nolock) on s.hid_cocde = d.sod_cocde and s.hid_ordno = d.sod_ordno and s.hid_ordseq = d.sod_ordseq
left outer join SHINVHDR j (nolock) on j.hiv_cocde = s.hid_cocde and j.hiv_shpno = s.hid_shpno and  j.hiv_invno = s.hid_invno
left outer join SHIPGHDR h (nolock) on h.hih_cocde = s.hid_cocde and h.hih_shpno = s.hid_shpno

left outer join #TEMP_SHPCKDIM (nolock) on hpd_shpno = s.hid_shpno and hpd_shpseq = s.hid_shpseq
/*
left outer join SHPCKDIM pd_act (nolock) on /*pd_act.hpd_cocde = s.hid_cocde and*/ pd_act.hpd_shpno = s.hid_shpno and pd_act.hpd_shpseq = s.hid_shpseq and pd_act.hpd_dimtyp = 'Act'
left outer join SHPCKDIM pd_mod (nolock) on /*pd_mod.hpd_cocde = s.hid_cocde and*/ pd_mod.hpd_shpno = s.hid_shpno and pd_mod.hpd_shpseq = s.hid_shpseq and pd_mod.hpd_dimtyp = 'Mod'
*/
left outer join SYCATCDE YCC0 (nolock) on YCC0.YCC_CATCDE = i.ibi_catlvl0
left outer join SYCATCDE YCC1 (nolock) on YCC1.YCC_CATCDE = i.ibi_catlvl1
left outer join SYCATCDE YCC2 (nolock) on YCC2.YCC_CATCDE = i.ibi_catlvl2
left outer join SYCATCDE YCC3 (nolock) on YCC3.YCC_CATCDE = i.ibi_catlvl3
left outer join SYCATCDE YCC4 (nolock) on YCC4.YCC_CATCDE = i.ibi_catlvl4
left outer join SYLNEINF inlne (nolock) on ibi_lnecde = inlne.yli_lnecde    
left outer join SYLNEINF exlne (nolock) on icf_lnecde = exlne.yli_lnecde
left outer join SYSETINF dsg (nolock) on inlne.yli_dsgcde = dsg.ysi_cde and dsg.ysi_typ = 15
left outer join SYSETINF pay (nolock) on soh_paytrm  = pay.ysi_cde and pay.ysi_typ = '04'
left outer join SYSETINF payi (nolock) on hiv_paytrm  = payi.ysi_cde and payi.ysi_typ = '04'

left outer join IMBASINF im (nolock) on im.ibi_itmno = i.ibi_itmno
left outer join SYSETINF ysi_mat (nolock) on ysi_mat.ysi_cde = im.ibi_material and ysi_mat.ysi_typ = '25'
left outer join SYSETINF ysi_nat_i (nolock) on ysi_nat_i.ysi_cde = im.ibi_itmnat and ysi_nat_i.ysi_typ = '20'
left outer join SYSETINF ysi_nat_e (nolock) on ysi_nat_e.ysi_cde = im.ibi_itmnat and ysi_nat_e.ysi_typ = '29' 
left outer join SYSETINF ysi_pg (nolock) on ysi_pg.ysi_cde = im.ibi_prdgrp and ysi_pg.ysi_typ = '24'
left outer join SYSETINF ysi_pi (nolock) on ysi_pi.ysi_cde = im.ibi_prdicon and ysi_pi.ysi_typ = '28'
left outer join SYSETINF ysi_season (nolock) on  ysi_season.ysi_cde = im.ibi_season and ysi_season.ysi_typ = '19'

where
((@flg_shslndat_fmto = 'N') or (@flg_shslndat_fmto = 'Y' and hih_slnonb between @shslndatfm and @shslndatto))
and ((@flg_cocde_table = 'N') or (@flg_cocde_table = 'Y' and soh_cocde in (select tmp_cocde from #TEMP_COCDE (nolock))))
and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and sod_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
and ((@flg_dv_table = 'N') or (@flg_dv_table = 'Y' and sod_dv in (select tmp_dv from #TEMP_DV (nolock))))
and ((@flg_pv_table = 'N') or (@flg_pv_table = 'Y' and sod_venno in (select tmp_pv from #TEMP_PV (nolock))))
order by soh_cocde, soh_ordno

end


drop table #TEMP_INIT
drop table #TEMP_COCDE
drop table #TEMP_CUS1NO
drop table #TEMP_CUS2NO
drop table #TEMP_ITMNO
drop table #TEMP_DV
drop table #TEMP_PV

drop table #TEMP_TX_SC
drop table #TEMP_SHPCKDIM

drop table #TEMP_SCLIST


END


GO
GRANT EXECUTE ON [dbo].[sp_list_DYR00009] TO [ERPUSER] AS [dbo]
GO
