/****** Object:  StoredProcedure [dbo].[sp_list_PackagingReport_Hdr3]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_PackagingReport_Hdr3]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_PackagingReport_Hdr3]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_list_PackagingReport_Hdr3]
---------------------------------------------- 
@code nvarchar(10),
@codelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@cus2nolist nvarchar(1000),
@sccde nvarchar(1000),
@tocde nvarchar(1000),
@itmnolist nvarchar(1000),
@ordissdatfm datetime,
@ordissdatto datetime,
@scpkgcstflag	char(1),
@estpkgcstflag	char(1),
@netpackflag	char(1),
@sctoflag nvarchar(10),
@usrid nvarchar(30)
 
AS
 
SET NOCOUNT ON
begin



declare @flg_cocde_table char(1), 
@flg_cus1no_table char(1),
@flg_cus2no_table char(1),
@flg_scno_table char(1),
@flg_tono_table char(1),
@flg_ordissdat_fmto char(1),
@flg_itmno_table char(1)

declare	@fm nvarchar(100), @to nvarchar(100), @date3 datetime
declare @strPart nvarchar(1000), @strRemain nvarchar(1000)

set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''
set @date3  = ''


create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_CODELIST (tmp_code nvarchar(1000)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS2NO (tmp_cus2no nvarchar(10)) on [PRIMARY]
create table #TEMP_SCNO (tmp_scno nvarchar(20)) on [PRIMARY]
create table #TEMP_TONO (tmp_tono nvarchar(20)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]




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

if (select count(*) from #TEMP_TONO) >= 1
	set @flg_tono_table = 'Y'
else
	set @flg_tono_table = 'N'

if @ordissdatfm <> '1900/01/01'
begin
	set @flg_ordissdat_fmto  = 'Y'
	set @ordissdatto = dateadd(DD,1,@ordissdatto)
end
else
begin
	set @flg_ordissdat_fmto  = 'N'
end

if (select count(*) from #TEMP_ITMNO) >= 1
	set @flg_itmno_table = 'Y'
else
	set @flg_itmno_table = 'N'








declare @CNYtoUSDrate as numeric(13,4)
declare @HKDtoUSDrate as numeric(13,4)

select @CNYtoUSDrate = yce_buyrat from SYCUREX where  yce_iseff = 'Y' and yce_frmcur = 'CNY' and yce_tocur = 'USD'
select @HKDtoUSDrate = yce_buyrat from SYCUREX where  yce_iseff = 'Y' and yce_frmcur = 'HKD' and yce_tocur = 'USD'


create table #TEMP_PKDISPRM_SUM
(
pdp_ordno	nvarchar(30),
pdp_type	nvarchar(10),
pdp_amt		numeric(13,4)
)


insert into #TEMP_PKDISPRM_SUM
select pdp_ordno, pdp_type, sum(pdp_amt) 'pdp_amt'
from PKDISPRM (nolock)
group by pdp_ordno, pdp_type




create table #TEMP_PKG (
pkg_type		nvarchar(10),
pkg_scno		nvarchar(20),
pkg_scseq		int,
pkg_cus1no		nvarchar(200),
pkg_cus2no		nvarchar(200),
pkg_scitmno		nvarchar(30),
pkg_scitmtyp		nvarchar(20),
pkg_scseason		nvarchar(30),

pkg_pckunt		nvarchar(10),
pkg_conftr		int,
pkg_inrctn		int,
pkg_mtrctn		int,

pkg_scordqty		int,

pkg_sccurcde		nvarchar(10),
pkg_scuntprc		numeric(13,4),
pkg_scpkgcst		numeric(13,4),
pkg_scpkgcstttl		numeric(13,4),

pkg_estcurcde		nvarchar(10),
pkg_estpkgcst		numeric(13,4),
pkg_estpkgcstttl	numeric(13,4),

pkg_reqno		nvarchar(20),
pkg_reqseq		int,
pkg_reqpkgitm		nvarchar(30),
pkg_reqordqty		int,
pkg_reqwastage		int,
pkg_reqcurcde		nvarchar(10),
pkg_requntprc		numeric(13,4),

pkg_pkgordno		nvarchar(20),
pkg_pkgordtyp		nvarchar(20), -- 02,09, re-print
pkg_pkgven		nvarchar(20),
pkg_issdat		datetime,
pkg_pkgcurcde		nvarchar(10),
pkg_delamt		numeric(13,4),	-- delivery charges
pkg_disamt		numeric(13,4),	-- discount amount
pkg_preamt		numeric(13,4),	-- premium amount
pkg_pkgordseq		int,
pkg_pkgpkgitm		nvarchar(20),
pkg_pkgseason		nvarchar(30),
pkg_pkgunt		nvarchar(20),
pkg_pkgordqty		int,
pkg_pkgordwastage	int,
pkg_pkgttlordqty	int,
pkg_pkgdivwastage	int,

pkg_pkguntprc		numeric(13,4),
pkg_pkgmoa		numeric(13,4),
pkg_pkgmoauntprc	numeric(13,4),

pkg_pkgttlamtord	numeric(13,4),
pkg_pkgttlamtwas	numeric(13,4),
pkg_pkgttlamtdlv	numeric(13,4),
pkg_pkgttlamtdis	numeric(13,4),
pkg_pkgttlamtpre	numeric(13,4),
)	

if @sctoflag = 'ALL' or @sctoflag = 'SC'
begin
	insert into #TEMP_PKG
	select 
	'SC',
	sod_ordno,
	sod_ordseq,
	isnull(soh_cus1no + ' - ' + pri.cbi_cussna,''),
	isnull(soh_cus2no + ' - ' + sec.cbi_cussna,''),
	sod_itmno,
	sod_itmtyp,
	sod_season,
	sod_pckunt,
	sod_conftr, 
	sod_inrctn,
	sod_mtrctn,
	sod_ordqty,
	sod_curcde,
	sod_untprc,
	sod_pckcst,	
	sod_pckcst * sod_ordqty,
	'',0,0,
	isnull(prd_reqno,''),
	isnull(prd_seq,0),
	isnull(prd_pkgitm,''),
	isnull(prd_ordqty,0),
	isnull(prd_bonqty,0), -- real wastage
	isnull(prd_curcde,''),
	isnull(prd_untprc,0),
	isnull(poh_ordno,''),
	--isnull(poh_gentype,''),
	--isnull(case poh_reprtflg when 'Y' then poh_gentype + '(Reprint)' else poh_gentype end, ''),
	isnull(case poh_reprtflg 
			when 'Y' then 
				(case prd_cate when 'LBL' then 'Ord'
								when 'HTG' then 'Ord'
								when 'HDC' then 'Ord'
								when 'OTH' then 'Ord'
								else 'Req' end) + '(Reprint)' 
			else (case prd_cate when 'LBL' then 'Ord'
								when 'HTG' then 'Ord'
								when 'HDC' then 'Ord'
								when 'OTH' then 'Ord'
								else 'Req' end) end, ''),
	isnull(poh_pkgven,''),
	isnull(poh_issdat,''),
	isnull(pod_curcde,''),
	isnull(poh_delamt,0),
	isnull(dis.pdp_amt,0),
	isnull(pre.pdp_amt,0),
	isnull(pod_seq,0), 
	isnull(pod_pkgitm,''),
	isnull(ysi_dsc,''), -- packing season
	isnull(pod_qtyum,''),
	isnull(pod_ordqty,0),
	isnull(pod_bonqty,0), -- real wastage
	isnull(pod_ttlordqty,0),
	case isnull(pod_ordqty,0) when 0 then 0 else convert(int, isnull(prd_ordqty,0) * (isnull(pod_bonqty,0) / convert(numeric(13,4),pod_ordqty))) end as 'pkg_pkgdivwastage',
	isnull(pod_untprc,0),
	isnull(pod_MOA,0),
	case isnull(pod_ttlordqty,0) when 0 then 0 else isnull(pod_MOA,0) / pod_ttlordqty  end as 'pkg_pkgmoauntprc',
	0,0,0,0,0
	from	
	SCORDHDR (nolock)  
	left join SCORDDTL (nolock) on sod_ordno = soh_ordno
	left join PKREQDTL (nolock) on prd_SCTONO = sod_ordno and prd_SCTOSEQ = sod_ordseq --and prd_assitm =''
	left join PKREQHDR (nolock) on prh_reqno = prd_reqno
	left join PKORDDTL (nolock) on prd_ordno = pod_ordno and prd_ordseq = pod_seq
	left join PKORDHDR (nolock) on poh_ordno = pod_ordno
	left join PKIMBAIF (nolock) on pib_pgitmno = pod_pkgitm
	left join SYSETINF (nolock) on ysi_typ ='19' and ysi_cde = pib_season
	left join CUBASINF pri (nolock) on soh_cus1no = pri.cbi_cusno
	left join CUBASINF sec (nolock) on soh_cus2no = sec.cbi_cusno
	left join #TEMP_PKDISPRM_SUM dis (nolock) on pod_ordno = dis.pdp_ordno and dis.pdp_type = 'D'
	left join #TEMP_PKDISPRM_SUM pre (nolock) on pod_ordno = pre.pdp_ordno and pre.pdp_type = 'P'
	where 
	((@flg_cocde_table = 'N') or (@flg_cocde_table ='Y' and soh_cocde in (select tmp_code from #TEMP_CODELIST(nolock))))
	and ((@flg_ordissdat_fmto  = 'N') or (@flg_ordissdat_fmto  = 'Y' and (soh_issdat between @ordissdatfm  and @ordissdatto)))
	and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and soh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
 	and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and soh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
	and ((@flg_scno_table = 'N') or (@flg_scno_table = 'Y' and sod_ordno in (select tmp_scno from #TEMP_SCNO (nolock))))
	and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and sod_itmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
	and prh_status <> 'CAN'
	--and prd_cate not in ('LBL','HTG')
--	and soh_ordno = 'SC1500963' and sod_itmno = 'F14WR00841MIC'
	order by sod_ordno, sod_ordseq, prd_reqno,prd_seq
end


if @sctoflag = 'ALL' or @sctoflag = 'TO'
begin
	
	insert into #TEMP_PKG
	select 
	'TO',
	tod_toordno,
	tod_toordseq,
	isnull(toh_cus1no + ' - ' + pri.cbi_cussna,''),
	isnull(toh_cus2no + ' - ' + sec.cbi_cussna,''),
	tod_ftyitmno,
	isnull(qud_itmtyp,''),
--	isnull(quh_season,''),
	isnull(toh_season,''),
	tod_pckunt,
	tod_conftr, 
	tod_inrqty,
	tod_mtrqty,
	tod_projqty,
	tod_curcde,
	tod_selprc,
	tod_pckcst,	
	tod_pckcst * tod_projqty,
	'',0,0,
	isnull(prd_reqno,''),
	isnull(prd_seq,0),
	isnull(prd_pkgitm,''),
	isnull(prd_ordqty,0),
	isnull(prd_bonqty,0), -- real wastage
	isnull(prd_curcde,''),
	isnull(prd_untprc,0),
	isnull(poh_ordno,''),
	--isnull(poh_gentype,''),
	--isnull(case poh_reprtflg when 'Y' then poh_gentype + '(Reprint)' else poh_gentype end, ''),
	isnull(case poh_reprtflg 
				when 'Y' then 
					(case prd_cate when 'LBL' then 'Ord'
									when 'HTG' then 'Ord'
									when 'HDC' then 'Ord'
									when 'OTH' then 'Ord'
									else 'Req' end) + '(Reprint)' 
				else (case prd_cate when 'LBL' then 'Ord'
									when 'HTG' then 'Ord'
									when 'HDC' then 'Ord'
									when 'OTH' then 'Ord'
									else 'Req' end) end, ''),
	isnull(poh_pkgven,''),
	isnull(poh_issdat,''),
	isnull(pod_curcde,''),
	isnull(poh_delamt,0),
	isnull(dis.pdp_amt,0),
	isnull(pre.pdp_amt,0),
	isnull(pod_seq,0), 
	isnull(pod_pkgitm,''),
	isnull(ysi_dsc,''), -- packing season
	isnull(pod_qtyum,''),
	isnull(pod_ordqty,0),
	isnull(pod_bonqty,0), -- real wastage
	isnull(pod_ttlordqty,0),
	case isnull(pod_ordqty,0) when 0 then 0 else convert(int, isnull(prd_ordqty,0) * (isnull(pod_bonqty,0) / convert(numeric(13,4),pod_ordqty))) end as 'pkg_pkgdivwastage',
	isnull(pod_untprc,0),
	isnull(pod_MOA,0),
	case isnull(pod_ttlordqty,0) when 0 then 0 else isnull(pod_MOA,0) / pod_ttlordqty  end as 'pkg_pkgmoauntprc',
	0,0,0,0,0
	from	
	TOORDHDR(nolock)
	left join TOORDDTL (nolock)  on tod_toordno = toh_toordno
	left join QUOTNDTL (nolock) on qud_cocde = tod_cocde and tod_qutno = qud_qutno and tod_qutseq = qud_qutseq and tod_ftyitmno = qud_itmno
	left join QUOTNHDR (nolock) on qud_cocde = quh_cocde and qud_qutno = quh_qutno
	left join PKREQDTL (nolock) on prd_SCTONO = tod_toordno and prd_SCTOSEQ = tod_toordseq --and prd_assitm =''
	left join PKREQHDR (nolock) on prh_reqno = prd_reqno
	left join PKORDDTL (nolock) on prd_ordno = pod_ordno and prd_ordseq = pod_seq
	left join PKORDHDR (nolock) on poh_ordno = pod_ordno
	left join PKIMBAIF (nolock) on pib_pgitmno = pod_pkgitm
	left join SYSETINF (nolock) on ysi_typ ='19' and ysi_cde = pib_season
	left join CUBASINF pri (nolock) on toh_cus1no = pri.cbi_cusno
	left join CUBASINF sec (nolock) on toh_cus2no = sec.cbi_cusno
	left join #TEMP_PKDISPRM_SUM dis (nolock) on pod_ordno = dis.pdp_ordno and dis.pdp_type = 'D'
	left join #TEMP_PKDISPRM_SUM pre (nolock) on pod_ordno = pre.pdp_ordno and pre.pdp_type = 'P'
	where 
	tod_latest = 'Y' 
	and ((@flg_cocde_table = 'N') or (@flg_cocde_table ='Y' and toh_cocde in (select tmp_code from #TEMP_CODELIST(nolock))))
	and ((@flg_ordissdat_fmto  = 'N') or (@flg_ordissdat_fmto  = 'Y' and (toh_issdat between @ordissdatfm  and @ordissdatto)))
	and ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and toh_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
 	and ((@flg_cus2no_table = 'N') or (@flg_cus2no_table = 'Y' and toh_cus2no in (select tmp_cus2no from #TEMP_CUS2NO (nolock))))
	and ((@flg_tono_table = 'N') or (@flg_tono_table = 'Y' and tod_toordno in (select tmp_tono from #TEMP_TONO (nolock))))
	and ((@flg_itmno_table = 'N') or (@flg_itmno_table = 'Y' and tod_ftyitmno in (select tmp_itmno from #TEMP_ITMNO (nolock))))
	and prh_status <> 'CAN'
	--and prd_cate not in ('LBL','HTG')
	--and prh_scno not in (select pkg_scno from #TEMP_PKG)
	order by tod_toordno, tod_toordseq, prd_reqno,prd_seq
end




delete from #TEMP_PKG where pkg_pkgordno = ''

update #TEMP_PKG
set pkg_pkgttlamtord = case pkg_pkgmoauntprc when 0 then pkg_pkguntprc * pkg_reqordqty else pkg_pkgmoauntprc * pkg_reqordqty end,
pkg_pkgttlamtwas = case pkg_pkgmoauntprc when 0 then pkg_pkguntprc * pkg_pkgdivwastage else pkg_pkgmoauntprc * pkg_pkgdivwastage end,
pkg_pkgttlamtdlv = case pkg_pkgordqty when 0 then 0 else pkg_delamt * pkg_reqordqty / pkg_pkgordqty end,
pkg_pkgttlamtdis = case pkg_disamt when 0 then 0 else pkg_disamt * pkg_reqordqty / pkg_pkgordqty end,
pkg_pkgttlamtpre = case pkg_preamt when 0 then 0 else pkg_preamt * pkg_reqordqty / pkg_pkgordqty end

create table #TEMP_PKG_POAMT
(
poh_reqno	nvarchar(20),
poh_ordno	nvarchar(30),
poh_ttlamt	numeric(13,4)
)

insert into #TEMP_PKG_POAMT
select pkg_reqno,pkg_pkgordno, sum(pkg_pkgttlamtord + pkg_pkgttlamtwas) from #TEMP_PKG
group by pkg_reqno,pkg_pkgordno


update #TEMP_PKG
set pkg_pkgttlamtdlv = case pkg_pkgttlamtdlv when 0 then 0 else pkg_pkgttlamtdlv * (pkg_pkgttlamtord + pkg_pkgttlamtwas) / poh_ttlamt end,
pkg_pkgttlamtdis = case pkg_pkgttlamtdis when 0 then 0 else pkg_pkgttlamtdis * (pkg_pkgttlamtord + pkg_pkgttlamtwas) / poh_ttlamt end,
pkg_pkgttlamtpre = case pkg_pkgttlamtpre when 0 then 0 else pkg_pkgttlamtpre * (pkg_pkgttlamtord + pkg_pkgttlamtwas) / poh_ttlamt end
from #TEMP_PKG, #TEMP_PKG_POAMT
where pkg_reqno = poh_reqno and pkg_pkgordno = poh_ordno


create table #TEMP_PKESHDR_SUM
(
peh_reqno	nvarchar(20),
peh_itemno	nvarchar(30),
peh_price	numeric(13,4)
)


insert into #TEMP_PKESHDR_SUM
select peh_reqno, peh_itemno, sum(case peh_curcde when 'CNY' then peh_price * @CNYtoUSDrate when 'RMB' then peh_price * @CNYtoUSDrate when 'HKD' then peh_price * @HKDtoUSDrate else peh_price end) 'peh_price'
from PKESHDR (nolock)
where peh_reqno in (select pkg_reqno from #TEMP_PKG (nolock))
and peh_price > 0
group by peh_reqno, peh_itemno

--select * from #TEMP_PKESHDR_SUM
--select * from #TEMP_PKG

update #TEMP_PKG set pkg_estcurcde = 'USD', pkg_estpkgcst = peh_price, pkg_estpkgcstttl = peh_price * pkg_scordqty
from #TEMP_PKG,#TEMP_PKESHDR_SUM
where pkg_reqno = peh_reqno and pkg_scitmno = peh_itemno

update #TEMP_PKG set pkg_estcurcde = 'USD', pkg_estpkgcst = peh_price, pkg_estpkgcstttl = peh_price * pkg_scordqty
from #TEMP_PKG,#TEMP_PKESHDR_SUM
where pkg_scitmno = peh_itemno and pkg_estcurcde = ''


-- Change SC Currency to USD
update #TEMP_PKG set pkg_sccurcde = 'USD', pkg_scpkgcst = case pkg_sccurcde when 'CNY' then pkg_scpkgcst * @CNYtoUSDrate when 'RMB' then pkg_scpkgcst * @CNYtoUSDrate when 'HKD' then pkg_scpkgcst * @HKDtoUSDrate else pkg_scpkgcst end

/*
--select * from #TEMP_PKG
select prh_ToNo,prh_scno,peh_itemno,count(*)'a'
into #TEMP_ERROR_01
 from #TEMP_PKESHDR_SUM, PKREQHDR where peh_reqno = prh_reqno
group by prh_ToNo,prh_scno,peh_itemno
having count(*) > 1

select a.prh_scno, a.peh_itemno, c.* from #TEMP_ERROR_01 a, PKREQHDR b, #TEMP_PKESHDR_SUM c
where a.prh_scno = b.prh_scno and b.prh_reqno = c.peh_reqno  and a.peh_itemno = c.peh_itemno
and a.prh_scno <> ''
union all
select a.prh_tono, a.peh_itemno, c.* from #TEMP_ERROR_01 a, PKREQHDR b, #TEMP_PKESHDR_SUM c
where a.prh_tono = b.prh_tono and b.prh_reqno = c.peh_reqno  and a.peh_itemno = c.peh_itemno
and a.prh_tono <> ''
order by 1,2,3
--select * from PKREQHDR
*/


--select * from #TEMP_PKG_SC

-- Create from 02, 09, Reprint
create table #TEMP_PKG_SUM 
(
pkg_scno	nvarchar(20), 
pkg_scseq	int,	 
pkg_cus1no	nvarchar(200), 
pkg_cus2no	nvarchar(200),
pkg_scitmno	nvarchar(30),
pkg_scordqty	int,
pkg_sccurcde	nvarchar(10), 
pkg_scpkgcst	numeric(13,4),
pkg_estcurcde	nvarchar(10),
pkg_estpkgcst	numeric(13,4),
pkg_pkgordtyp	nvarchar(20),
pkg_pkgcurcde	nvarchar(10),
pkg_pkgpoamt	numeric(13,4)
,pkg_pkgven	nvarchar(100)
,pkg_issdat datetime
)



insert into #TEMP_PKG_SUM
select 
pkg_scno, pkg_scseq, pkg_cus1no, pkg_cus2no,
pkg_scitmno,pkg_scordqty,pkg_sccurcde, pkg_scpkgcst,
pkg_estcurcde,pkg_estpkgcst,pkg_pkgordtyp,
'USD' as 'pkg_pkgcurcde',
case pkg_scordqty when 0 then 0 else
( sum(case pkg_pkgcurcde when 'CNY' then pkg_pkgttlamtord * @CNYtoUSDRate when 'RMB' then pkg_pkgttlamtord * @CNYtoUSDRate when 'HKD' then pkg_pkgttlamtord * @HKDtoUSDRate else pkg_pkgttlamtord end) +
--sum(case pkg_pkgcurcde when 'RMB' then pkg_pkgttlamtwas * @CNYtoUSDRate when 'HKD' then pkg_pkgttlamtwas * @HKDtoUSDRate else pkg_pkgttlamtwas end) +
sum(case pkg_pkgcurcde when 'CNY' then pkg_pkgttlamtdlv * @CNYtoUSDRate when 'RMB' then pkg_pkgttlamtdlv * @CNYtoUSDRate when 'HKD' then pkg_pkgttlamtdlv * @HKDtoUSDRate else pkg_pkgttlamtdlv end) -
sum(case pkg_pkgcurcde when 'CNY' then pkg_pkgttlamtdis * @CNYtoUSDRate when 'RMB' then pkg_pkgttlamtdis * @CNYtoUSDRate when 'HKD' then pkg_pkgttlamtdis * @HKDtoUSDRate else pkg_pkgttlamtdis end) +
sum(case pkg_pkgcurcde when 'CNY' then pkg_pkgttlamtpre * @CNYtoUSDRate when 'RMB' then pkg_pkgttlamtpre * @CNYtoUSDRate when 'HKD' then pkg_pkgttlamtpre * @HKDtoUSDRate else pkg_pkgttlamtpre end) ) / pkg_scordqty end
, isnull(pkg_pkgven + ' - ' + vbi_vensna, ''), pkg_issdat
from #TEMP_PKG
left join VNBASINF on vbi_venno = pkg_pkgven
group by pkg_scno, pkg_scseq, pkg_cus1no, pkg_cus2no,pkg_scitmno,pkg_scordqty,pkg_sccurcde, pkg_scpkgcst,pkg_estcurcde,pkg_estpkgcst,pkg_pkgordtyp
,pkg_pkgven, vbi_vensna, pkg_issdat



create table #TEMP_PKG_SUM_WASTAGE 
(
pkg_scno	nvarchar(20), 
pkg_scseq	int,	 
pkg_cus1no	nvarchar(200), 
pkg_cus2no	nvarchar(200),
pkg_scitmno	nvarchar(30),
pkg_scordqty	int,
pkg_sccurcde	nvarchar(10), 
pkg_scpkgcst	numeric(13,4),
pkg_estcurcde	nvarchar(10),
pkg_estpkgcst	numeric(13,4),
pkg_pkgordtyp	nvarchar(20),
pkg_pkgcurcde	nvarchar(10),
pkg_pkgpoamt	numeric(13,4)
,pkg_pkgven	nvarchar(100)
,pkg_issdat datetime
)



insert into #TEMP_PKG_SUM_WASTAGE
select 
pkg_scno, pkg_scseq, pkg_cus1no, pkg_cus2no,
pkg_scitmno,pkg_scordqty,pkg_sccurcde, pkg_scpkgcst,
pkg_estcurcde,pkg_estpkgcst,pkg_pkgordtyp,
'USD' as 'pkg_pkgcurcde',
case pkg_scordqty when 0 then 0 else
sum(case pkg_pkgcurcde when 'CNY' then pkg_pkgttlamtwas * @CNYtoUSDRate when 'RMB' then pkg_pkgttlamtwas * @CNYtoUSDRate when 'HKD' then pkg_pkgttlamtwas * @HKDtoUSDRate else pkg_pkgttlamtwas end) / pkg_scordqty end
, isnull(pkg_pkgven + ' - ' + vbi_vensna, ''), isnull(pkg_issdat, '')
from #TEMP_PKG
left join VNBASINF on vbi_venno = pkg_pkgven
group by pkg_scno, pkg_scseq, pkg_cus1no, pkg_cus2no,pkg_scitmno,pkg_scordqty,pkg_sccurcde, pkg_scpkgcst,pkg_estcurcde,pkg_estpkgcst,pkg_pkgordtyp
,pkg_pkgven, vbi_vensna, pkg_issdat






create table #TEMP_PKG_SC
(
pkg_scno	nvarchar(20),
pkg_scseq	int,
pkg_cus1no	nvarchar(200),
pkg_cus2no	nvarchar(200),
pkg_scitmno	nvarchar(30),
pkg_scitmtyp	nvarchar(20),
pkg_scseason	nvarchar(20),
pkg_scordqty	int,
pkg_pckunt	nvarchar(10),
pkg_conftr	int,
pkg_inrctn	int,
pkg_mtrctn	int,
pkg_sccurcde	nvarchar(20), 
pkg_scpkgcst	numeric(13,4)
,pkg_scpkgven	nvarchar(100)
,pkg_issdat	datetime
)

insert into #TEMP_PKG_SC
select distinct sc.pkg_scno,sc.pkg_scseq,sc.pkg_cus1no,sc.pkg_cus2no,sc.pkg_scitmno,pkg_scitmtyp,pkg_scseason,
sc.pkg_scordqty,
pkg_pckunt,
pkg_conftr,
pkg_inrctn,
pkg_mtrctn,
sc.pkg_sccurcde,sc.pkg_scpkgcst, req.pkg_pkgven, sc.pkg_issdat
from #TEMP_PKG sc (nolock)
left join #TEMP_PKG_SUM req on req.pkg_scno = sc.pkg_scno and req.pkg_scseq = sc.pkg_scseq and req.pkg_issdat = sc.pkg_issdat
order by pkg_scno, pkg_scseq




-- dtl

--select * from  #TEMP_PKDISPRM_SUM
--select * from  #TEMP_PKESHDR_SUM
--select * from  #TEMP_PKG
--select * from  #TEMP_PKG_SC
--select * from  #TEMP_PKG_SUM
--select * from  #TEMP_PKG_SUM_WASTAGE

-- hdr

select 
sc.pkg_scno as [SC/TO No.], 
sc.pkg_scseq as [Seq], 
sc.pkg_cus1no as [Pri Cus], 
sc.pkg_cus2no as [Sec Cus],
sc.pkg_scitmno as [UCP Item], 
sc.pkg_scitmtyp as [Item Type], 
sc.pkg_scseason as [SC Season],
sc.pkg_scordqty as [SC Order Qty],
sc.pkg_pckunt as [UM],
pkg_conftr as [Factor],
pkg_inrctn as [Inner],
pkg_mtrctn as [Master],
sc.pkg_sccurcde as [SC Curr],
sc.pkg_scpkgcst as [(1)SC Pkg Cst],
case isnull(req.pkg_estcurcde,'') when '' then isnull(ord.pkg_estcurcde,'') else
isnull(req.pkg_estcurcde,'') end as [Est Curr], 
case isnull(req.pkg_estpkgcst,0) when 0 then isnull(ord.pkg_estpkgcst,0) else
isnull(req.pkg_estpkgcst,0) end as [Est Cst],
case isnull(req.pkg_pkgven,'') when '' then 
	case isnull(ord.pkg_pkgven,'') when '' then 
		case isnull(rep.pkg_pkgven,'') when '' then '' else rep.pkg_pkgven end  else ord.pkg_pkgven end else req.pkg_pkgven end 'pkg_pkgven',
isnull(sc.pkg_issdat,'') as [pkg_issdat],
'USD' as [Pkg Curr],
isnull(req.pkg_pkgpoamt,0) as [02 order(A)], -- Box/Tray/PDQ.
isnull(ord.pkg_pkgpoamt,0) as [09 order(B)], -- Label/Sticker/Handtag
isnull(req.pkg_pkgpoamt,0) + isnull(ord.pkg_pkgpoamt,0) as [(2)Cal. Ttl Cst (A+B)],
--'',
isnull(rep.pkg_pkgpoamt,0) as [Reprint(C)],
--'',
isnull(wastreq.pkg_pkgpoamt,0) as [02 wastage(A1)], -- Box/Tray/PDQ.
isnull(wastord.pkg_pkgpoamt,0) as [09 wastage(B1)], -- Label/Sticker/Handtag
isnull(wastrep.pkg_pkgpoamt,0) as [Reprint wastage(C1)],
--'',
isnull(req.pkg_pkgpoamt,0) + isnull(ord.pkg_pkgpoamt,0) + isnull(rep.pkg_pkgpoamt,0)+ isnull(wastreq.pkg_pkgpoamt,0) + isnull(wastord.pkg_pkgpoamt,0) + isnull(wastrep.pkg_pkgpoamt,0) as [(3)Act. Ttl Cst (A+B+C+A1+B1+C1)], -- Total Actual
--'',
case isnull(req.pkg_pkgpoamt,0) when 0 then 0 else round((isnull(wastreq.pkg_pkgpoamt,0) / isnull(req.pkg_pkgpoamt,0)) * 100,4) end as [A Wastage%(A1/A)],
case isnull(ord.pkg_pkgpoamt,0) when 0 then 0 else round((isnull(wastord.pkg_pkgpoamt,0) / isnull(ord.pkg_pkgpoamt,0)) * 100,4) end as [B Wastage%(B1/B)],
case isnull(rep.pkg_pkgpoamt,0) when 0 then 0 else round((isnull(wastrep.pkg_pkgpoamt,0) / isnull(rep.pkg_pkgpoamt,0)) * 100,4) end as [C Wastage%(C1/C)],
--'',
case sc.pkg_scpkgcst when 0 then 0 else sc.pkg_scpkgcst - (isnull(req.pkg_pkgpoamt,0) + isnull(ord.pkg_pkgpoamt,0)) end as [X(1-2)], -- Excess included packaging Cost per order
case sc.pkg_scpkgcst when 0 then 0 else sc.pkg_scpkgcst - (isnull(req.pkg_pkgpoamt,0) + isnull(ord.pkg_pkgpoamt,0) + isnull(rep.pkg_pkgpoamt,0)+ isnull(wastreq.pkg_pkgpoamt,0) + isnull(wastord.pkg_pkgpoamt,0) + isnull(wastrep.pkg_pkgpoamt,0)) end as [Y(1-3)], -- Excess included packaging cost per actual
--'',
round(case sc.pkg_scpkgcst when 0 then 0 else ((sc.pkg_scpkgcst - (isnull(req.pkg_pkgpoamt,0) + isnull(ord.pkg_pkgpoamt,0) + isnull(rep.pkg_pkgpoamt,0)+ isnull(wastreq.pkg_pkgpoamt,0) + isnull(wastord.pkg_pkgpoamt,0) + isnull(wastrep.pkg_pkgpoamt,0)))/sc.pkg_scpkgcst) * 100 end,2) as [Z(1-3)/1], 
--'',
(isnull(req.pkg_pkgpoamt,0) + isnull(ord.pkg_pkgpoamt,0) + isnull(rep.pkg_pkgpoamt,0)+ isnull(wastreq.pkg_pkgpoamt,0) + isnull(wastord.pkg_pkgpoamt,0) + isnull(wastrep.pkg_pkgpoamt,0)) * sc.pkg_scordqty as [(3)Act. Ttl Cst (A+B+C+A1+B1+C1) * sc qty] -- Total Actual Used
into #TEMP_RESULT
from #TEMP_PKG_SC sc
left join #TEMP_PKG_SUM req on req.pkg_scno = sc.pkg_scno and req.pkg_scseq = sc.pkg_scseq and req.pkg_pkgordtyp = 'Req' and sc.pkg_scpkgven = req.pkg_pkgven and sc.pkg_issdat = req.pkg_issdat
left join #TEMP_PKG_SUM ord on ord.pkg_scno = sc.pkg_scno and ord.pkg_scseq = sc.pkg_scseq and ord.pkg_pkgordtyp = 'Ord' and sc.pkg_scpkgven = ord.pkg_pkgven and sc.pkg_issdat = ord.pkg_issdat
left join #TEMP_PKG_SUM rep on rep.pkg_scno = sc.pkg_scno and rep.pkg_scseq = sc.pkg_scseq and rep.pkg_pkgordtyp in ('Ord(Reprint)','Req(Reprint)') and sc.pkg_scpkgven = rep.pkg_pkgven and sc.pkg_issdat = rep.pkg_issdat
left join #TEMP_PKG_SUM_WASTAGE wastreq on wastreq.pkg_scno = sc.pkg_scno and wastreq.pkg_scseq = sc.pkg_scseq and wastreq.pkg_pkgordtyp = 'Req' and wastreq.pkg_pkgven = sc.pkg_scpkgven and sc.pkg_issdat = wastreq.pkg_issdat
left join #TEMP_PKG_SUM_WASTAGE wastord on wastord.pkg_scno = sc.pkg_scno and wastord.pkg_scseq = sc.pkg_scseq and wastord.pkg_pkgordtyp = 'Ord' and wastord.pkg_pkgven = sc.pkg_scpkgven and sc.pkg_issdat = wastord.pkg_issdat
left join #TEMP_PKG_SUM_WASTAGE wastrep on wastrep.pkg_scno = sc.pkg_scno and wastrep.pkg_scseq = sc.pkg_scseq and wastrep.pkg_pkgordtyp in ('Ord(Reprint)','Req(Reprint)') and wastrep.pkg_pkgven = sc.pkg_scpkgven and sc.pkg_issdat = wastrep.pkg_issdat

where
((@scpkgcstflag = 'N') or (@scpkgcstflag ='Y' and sc.pkg_scpkgcst> 0)) and
((@estpkgcstflag = 'N') or (@estpkgcstflag ='Y' and isnull(req.pkg_estpkgcst,0)> 0)) and
((@netpackflag = 'N') or (@netpackflag ='Y' and isnull(req.pkg_pkgpoamt,0) + isnull(ord.pkg_pkgpoamt,0) + isnull(rep.pkg_pkgpoamt,0)> 0))




select distinct 
[SC/TO No.], 
[Seq], 
[Pri Cus], 
[Sec Cus],
[UCP Item], 
[Item Type], 
[SC Season],
[SC Order Qty],
[UM],
[Factor],
[Inner],
[Master],
[pkg_pkgven],
[pkg_issdat],
[Pkg Curr],
[02 order(A)],
[09 order(B)],
[(2)Cal. Ttl Cst (A+B)],
[Reprint(C)],
[02 wastage(A1)],
[09 wastage(B1)],
[Reprint wastage(C1)],
[(3)Act. Ttl Cst (A+B+C+A1+B1+C1)],
[A Wastage%(A1/A)],
[B Wastage%(B1/B)],
[C Wastage%(C1/C)],
[X(1-2)],
[Y(1-3)],
[Z(1-3)/1], 
[(3)Act. Ttl Cst (A+B+C+A1+B1+C1) * sc qty]
from #TEMP_RESULT



select 
[Pri Cus], 
[Sec Cus],
[SC Season],
[pkg_pkgven],
year([pkg_issdat]), month([pkg_issdat]),
[Pkg Curr],
sum([(3)Act. Ttl Cst (A+B+C+A1+B1+C1) * sc qty]) [Total Amount]
from #TEMP_RESULT
group by [Pri Cus], [Sec Cus],[SC Season],[pkg_pkgven],[Pkg Curr],year([pkg_issdat]), month([pkg_issdat])
order by substring([Pri Cus],9,len([Pri Cus]) -9), [Sec Cus],year([pkg_issdat]), month([pkg_issdat])














drop table #TEMP_PKDISPRM_SUM
drop table #TEMP_PKESHDR_SUM
drop table #TEMP_PKG
drop table #TEMP_PKG_SC
drop table #TEMP_PKG_SUM
drop table #TEMP_PKG_SUM_WASTAGE
drop table #TEMP_PKG_POAMT

drop table #TEMP_INIT 
drop table #TEMP_CUS1NO 
drop table #TEMP_CUS2NO 
drop table #TEMP_SCNO
drop table #TEMP_TONO
drop table #TEMP_ITMNO 
drop table #TEMP_CODELIST










end


 
 




GO
