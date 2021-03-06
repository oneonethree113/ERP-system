/****** Object:  StoredProcedure [dbo].[sp_select_QCM00005]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCM00005]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCM00005]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_QCM00005]
	@cocde nvarchar(10), 
	@pricustlist nvarchar(1000),
	@seccustlist nvarchar(1000), 
	@pvlist nvarchar(1000),	
	@inspyear int, 
	@inspweekfm int, 
	@inspweekto int, 
	@insptyp nvarchar(20), 
	@status nvarchar(10),
	@usrid nvarchar(30)
AS

BEGIN
set nocount on

--Search QC Start
CREATE table #TEMP_INIT(tmp_init nvarchar(1000)) on [PRIMARY]
	CREATE table #TEMP_INIT2(tmp_init nvarchar(50)) on [PRIMARY]

	CREATE table #TEMP_CUS1NO(tmp_cus1no nvarchar(50)) on [PRIMARY]
	CREATE table #TEMP_CUS2NO(tmp_cus2no nvarchar(50)) on [PRIMARY]
	CREATE table #TEMP_PV(tmp_venno nvarchar(50)) on [PRIMARY]

	
	DECLARE @token nvarchar(100)
	DECLARE @tmp_fm nvarchar(50)
	DECLARE @tmp_to nvarchar(50)
	
	DECLARE @flg_pricust char(1),
	@flg_seccust char(1),
	@flg_pv char(1)


	SET @flg_pricust = 'N'
	SET @flg_seccust = 'N'
	SET @flg_pv = 'N'

	


	
	--*** Insert Temp Table Start ***--
	--Pri Cust Start	
	IF ltrim(rtrim(@pricustlist)) <> ''
	BEGIN
		SET @flg_pricust = 'Y'
		--INSERT INTO #TEMP_INIT SELECT * FROM dbo.splitstring("10000~10001, 50100, 2% ")
		INSERT INTO #TEMP_INIT SELECT * FROM dbo.splitstring(@pricustlist)
		--SELECT * FROM #TEMP_INIT
		
		DECLARE c CURSOR FORWARD_ONLY FOR SELECT tmp_init from #TEMP_INIT
		OPEN C
		FETCH NEXT FROM C into @token
		
		WHILE @@FETCH_STATUS = 0 
		BEGIN
			if charindex('~', @token) <> 0
			BEGIN
				SET @tmp_fm = left(@token, charindex('~', @token)-1)
				SET @tmp_to = right(@token, len(@token) - charindex('~', @token))
				INSERT INTO #TEMP_INIT2 SELECT cbi_cusno from CUBASINF WHERE cbi_cusno between @tmp_fm and @tmp_to and cbi_custyp = 'P'
			END
			else
			BEGIN
				INSERT INTO #TEMP_INIT2 SELECT cbi_cusno from CUBASINF WHERE cbi_cusno like @token and cbi_custyp = 'P'
			END
			FETCH NEXT FROM C into @token
		END
		INSERT INTO #TEMP_CUS1NO SELECT distinct tmp_init from #TEMP_INIT2
		--SELECT * FROM #TEMP_CUS1NO
		
		CLOSE C
		DEALLOCATE C
		DELETE FROM #TEMP_INIT
		DELETE FROM #TEMP_INIT2
	END
	--Pri Cust End
	
	--Sec Cust Start
	IF ltrim(rtrim(@seccustlist)) <> ''
	BEGIN
		SET @flg_seccust = 'Y'
		--INSERT INTO #TEMP_INIT SELECT * FROM dbo.splitstring("10000~10001, 50100, 2% ")
		INSERT INTO #TEMP_INIT SELECT * FROM dbo.splitstring(@seccustlist)
		
		DECLARE c CURSOR FORWARD_ONLY FOR SELECT tmp_init from #TEMP_INIT
		OPEN C
		FETCH NEXT FROM C into @token
		
		WHILE @@FETCH_STATUS = 0 
		BEGIN
			if charindex('~', @token) <> 0
			BEGIN
				SET @tmp_fm = left(@token, charindex('~', @token)-1)
				SET @tmp_to = right(@token, len(@token) - charindex('~', @token))
				INSERT INTO #TEMP_INIT2 SELECT cbi_cusno from CUBASINF WHERE cbi_cusno between @tmp_fm and @tmp_to and cbi_custyp = 'S'
			END
			else
			BEGIN
				INSERT INTO #TEMP_INIT2 SELECT cbi_cusno from CUBASINF WHERE cbi_cusno like @token and cbi_custyp = 'S'
			END
			FETCH NEXT FROM C into @token
		END
		INSERT INTO #TEMP_CUS2NO SELECT distinct tmp_init from #TEMP_INIT2
		--SELECT * from #TEMP_CUS2NO
		
		CLOSE C
		DEALLOCATE C
		DELETE FROM #TEMP_INIT
		DELETE FROM #TEMP_INIT2
		--Sec Cust End
	END

	--PV Start
	IF ltrim(rtrim(@pvlist)) <> ''
	BEGIN
		SET @flg_pv = 'Y'
		INSERT INTO #TEMP_INIT SELECT * FROM dbo.splitstring(@pvlist)
		
		DECLARE c CURSOR FORWARD_ONLY FOR SELECT tmp_init from #TEMP_INIT
		OPEN C
		FETCH NEXT FROM C into @token
		
		WHILE @@FETCH_STATUS = 0 
		BEGIN
			if charindex('~', @token) <> 0
			BEGIN
				SET @tmp_fm = left(@token, charindex('~', @token)-1)
				SET @tmp_to = right(@token, len(@token) - charindex('~', @token))
				INSERT INTO #TEMP_INIT2 SELECT vbi_venno from VNBASINF WHERE vbi_venno between @tmp_fm and @tmp_to
			END
			else
			BEGIN
				INSERT INTO #TEMP_INIT2 SELECT vbi_venno from VNBASINF WHERE vbi_venno like @token
			END
			FETCH NEXT FROM C into @token
		END
		INSERT INTO #TEMP_PV SELECT distinct tmp_init from #TEMP_INIT2
		--SELECT * from #TEMP_PV
		
		CLOSE C
		DEALLOCATE C
		DELETE FROM #TEMP_INIT
		DELETE FROM #TEMP_INIT2
	END	
	--PV End

	
	--*** Insert Temp Table End ***--

	CREATE table #TEMP_QC(tmp_qcno nvarchar(20)) on [PRIMARY]
	
	INSERT INTO #TEMP_QC(tmp_qcno)
	SELECT
		qch_qcno 
	FROM QCREQHDR
	WHERE
		qch_cocde = @cocde
	AND	((@flg_pv = 'N') OR ( @flg_pv = 'Y' and qch_venno in (select tmp_venno from #TEMP_PV)))		--Vendor
	AND	((@flg_pricust = 'N') OR (@flg_pricust = 'Y' and qch_prmcus in (select tmp_cus1no from #TEMP_CUS1NO)))
	AND ((@flg_seccust = 'N') OR (@flg_seccust = 'Y' and qch_seccus in (select tmp_cus2no from #TEMP_CUS2NO)))
	AND qch_inspyear = @inspyear 
	AND ((@inspweekfm = '') OR (@inspweekfm <> '' and qch_inspweek >= @inspweekfm ))
	AND ((@inspweekto = '') OR ( @inspweekto <> '' and qch_inspweek <= @inspweekto))
	AND ((@insptyp = 'ALL') OR (@insptyp <> 'ALL' and qch_insptyp = @insptyp))
	AND ((@status = 'ALL') OR (@status <> 'ALL' and qch_qcsts = @status))
--Seqrch QC End






declare @RESULT_FULL table (
res_inspyear	nvarchar(50),
res_inspweek	nvarchar(50),
res_qcno	nvarchar(20),
res_qcsts	nvarchar(20),
res_venno	nvarchar(10),
res_vensna	nvarchar(50),
res_stt		nvarchar(50),
res_cty		nvarchar(50),
res_town	nvarchar(50),
res_customer	nvarchar(50),
res_cuspo	nvarchar(500),
res_purord	nvarchar(500),
res_season	nvarchar(500),
res_cussku	nvarchar(500),
res_skucount	int,
res_scsw	nvarchar(500),
res_posw	nvarchar(500),
res_sidat	nvarchar(20),
res_cydat	nvarchar(20),
res_mon		nvarchar(20),
res_tue		nvarchar(20),
res_wed		nvarchar(20),
res_thur	nvarchar(20),
res_fri		nvarchar(20),
res_sat		nvarchar(20),
res_sun		nvarchar(20),
res_ftyadr	nvarchar(300),
res_cnt		nvarchar(200),
res_sample	nvarchar(50),
res_hksale	nvarchar(30),
res_szsale	nvarchar(30),
res_insptyp	nvarchar(20),

--20151030
res_verno int, 
res_upddat nvarchar(20),
res_city nvarchar(50),

--20151203
res_rmk nvarchar(300)
)

declare @RESULT_FINAL table (
res_inspyear	nvarchar(50),
res_inspweek	nvarchar(50),
res_qcno	nvarchar(20),
res_qcsts	nvarchar(20),
res_venno	nvarchar(10),
res_vensna	nvarchar(50),
res_stt		nvarchar(50),
res_cty		nvarchar(50),
res_town	nvarchar(50),
res_customer	nvarchar(50),
res_cuspo	nvarchar(500),
res_purord	nvarchar(500),
res_season	nvarchar(500),
res_cussku	nvarchar(500),
res_skucount	int,
res_scsw	nvarchar(500),
res_posw	nvarchar(500),
res_sidat	nvarchar(20),
res_cydat	nvarchar(20),
res_mon		nvarchar(20),
res_tue		nvarchar(20),
res_wed		nvarchar(20),
res_thur	nvarchar(20),
res_fri		nvarchar(20),
res_sat		nvarchar(20),
res_sun		nvarchar(20),
res_ftyadr	nvarchar(300),
res_cnt		nvarchar(200),
res_sample	nvarchar(50),
res_hksale	nvarchar(30),
res_szsale	nvarchar(30),
res_insptyp	nvarchar(20),

--20151030
res_verno int, 
res_upddat nvarchar(20),
res_city nvarchar(50),

--20151203
res_rmk nvarchar(300)
)

insert into @RESULT_FULL
select 
qch_inspyear,
qch_inspweek,
qch_qcno,
qch_qcsts,
qch_venno,
vbi_vensna,
qvi_stt, --adr.vci_stt,
qvi_cty, --adr.vci_cty,
qvi_town, --'',--Town
case isnull(sec.cbi_cussna,'')
when '' then pri.cbi_cussna else pri.cbi_cussna + ' (' + sec.cbi_cussna + ')' end as 'customer',
soh_cuspo,
qcd_purord,
sod_season,
sod_cussku,
0,
--left(convert(varchar(20),sod_shpstr,103),5) + ' - ' + left(convert(varchar(20),sod_shpend,103),5),
--left(convert(varchar(20),pod_shpstr,103),5) + ' - ' + left(convert(varchar(20),pod_shpend,103),5),
left(convert(varchar(20),soh_shpstr,103),5) + ' - ' + left(convert(varchar(20),soh_shpend,103),5),
left(convert(varchar(20),poh_shpstr,103),5) + ' - ' + left(convert(varchar(20),poh_shpend,103),5),
convert(varchar(20),getdate(),103),
convert(varchar(20),getdate(),103),
case qch_mon when 'Y' then qch_insptyp else '' end as 'qch_mon',
case qch_tue when 'Y' then qch_insptyp else '' end as 'qch_tue',
case qch_wed when 'Y' then qch_insptyp else '' end as 'qch_wed',
case qch_thur when 'Y' then qch_insptyp else '' end as 'qch_thur',
case qch_fri when 'Y' then qch_insptyp else '' end as 'qch_fri',
case qch_sat when 'Y' then qch_insptyp else '' end as 'qch_sat',
case qch_sun when 'Y' then qch_insptyp else '' end as 'qch_sun',
qvi_adr, --adr.vci_chnadr,
--isnull(cnt.vci_cntctp + ' : ' + cnt.vci_cntphn,''),
case isnull(qvi_cntctp + ' : ' + qvi_cntphn, '') when ' : ' then '' else qvi_cntctp + ' : ' + qvi_cntphn end , 
'',
pri.cbi_srname,
case isnull(yst_leader, '') when '' then '' else yst_leader end, --pri.cbi_srname,
qch_insptyp,

--20151030
qch_verno,  
convert(varchar(20),qch_upddat,103),
qvi_city,
--20151203
qch_rmk

from QCREQHDR (nolock)
left join QCREQDTL (nolock) on qch_cocde = qcd_cocde and qch_qcno = qcd_qcno
left join QCVENINF (nolock) on qch_qcno = qvi_qcno
left join SYSALTQC (nolock) on left(yst_cus, 5) = qch_prmcus
left join POORDDTL (nolock) on pod_cocde = qcd_cocde and pod_purord = qcd_purord and pod_purseq = qcd_purseq
left join POORDHDR (nolock) on pod_cocde = poh_cocde and pod_purord = poh_purord
--left join SCORDDTL (nolock) on sod_cocde = pod_cocde and sod_ordno = pod_scno and sod_ordseq = pod_scline
left join SCORDDTL (nolock) on sod_cocde = pod_cocde and sod_purord = pod_purord and sod_purseq = pod_purseq
left join SCORDHDR (nolock) on soh_cocde = sod_cocde and soh_ordno = sod_ordno
left join VNBASINF (nolock) on vbi_venno = qch_venno
--left join VNCNTINF adr (nolock) on adr.vci_venno = vbi_venno and adr.vci_cnttyp = 'M'
left join VNCNTINF cnt (nolock) on cnt.vci_venno = vbi_venno and cnt.vci_cnttyp = 'MAGT'
left join CUBASINF (nolock) pri on qch_prmcus = pri.cbi_cusno
left join CUBASINF (nolock) sec on qch_seccus = sec.cbi_cusno
WHERE
	qch_qcno in (select tmp_qcno from #TEMP_QC)
AND qcd_dtlsts <> 'DEL'	
AND (
	EXISTS (
		select 1 from syusrright
		where yur_usrid = @usrid  and yur_doctyp = 'SC' and yur_lvl = 0
	) 
	OR pri.cbi_saltem in (	
		select yur_para from syusrright
		where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 1
	) or pri.cbi_cusno in 
	(
		select yur_para from syusrright
		where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 2
	)
)

--	qch_qcsts = 'REL'
--AND qch_inspyear = @inspyear
--AND qch_inspweek >= @inspweek
--AND qch_inspweek <= @inspweek2

order by qch_qcno

--select * from @RESULT_FULL

declare @qcno_count int
declare @qcno_i int =1
declare @qcno nvarchar(20)

declare @TMP_QCNO table (
qcno_sno	int identity(1,1),
tmp_qcno nvarchar(20)
)

insert into @TMP_QCNO (tmp_qcno)
select distinct res_qcno from @RESULT_FULL order by res_qcno


-- 1. Customer PO
declare @cuspo_count int
declare @cuspo_count_start int = 0
declare @cuspo_i int =1
declare @cuspo nvarchar(20)
declare @cuspolist	nvarchar(500)

declare @TMP_CUSPO table (
cuspo_sno	int identity(1,1),
tmp_cuspo nvarchar(20)
)

-- 2. Purchase Order
declare @purord_count int
declare @purord_count_start int = 0
declare @purord_i int =1
declare @purord nvarchar(20)
declare @purordlist	nvarchar(500)

declare @TMP_PURORD table (
purord_sno	int identity(1,1),
tmp_purord nvarchar(20)
)

-- 3. Season
declare @season_count int
declare @season_count_start int = 0
declare @season_i int =1
declare @season nvarchar(20)
declare @seasonlist	nvarchar(500)

declare @TMP_SEASON table (
season_sno	int identity(1,1),
tmp_season nvarchar(20)
)

-- 4. Customer SKU
declare @cussku_count int
declare @cussku_count_start int = 0
declare @cussku_i int =1
declare @cussku nvarchar(20)
declare @cusskulist	nvarchar(500)

declare @TMP_CUSSKU table (
cussku_sno	int identity(1,1),
tmp_cussku nvarchar(20)
)

-- 5. SC Ship Window
declare @scsw_count int
declare @scsw_count_start int = 0
declare @scsw_i int =1
declare @scsw nvarchar(20)
declare @scswlist	nvarchar(500)

declare @TMP_SCSW table (
scsw_sno	int identity(1,1),
tmp_scsw nvarchar(20)
)

-- 6. PO Ship Window
declare @posw_count int
declare @posw_count_start int = 0
declare @posw_i int =1
declare @posw nvarchar(20)
declare @poswlist	nvarchar(500)

declare @TMP_POSW table (
posw_sno	int identity(1,1),
tmp_posw nvarchar(20)
)

select @qcno_count = count(qcno_sno) from @TMP_QCNO while (@qcno_i <= @qcno_count)
begin
	select @qcno = tmp_qcno from @TMP_QCNO where qcno_sno = @qcno_i

	-- 1. Customer PO List
	set @cuspolist = ''
	set @cuspo_i = 1

	insert into @TMP_CUSPO (tmp_cuspo)
	select distinct res_cuspo from @RESULT_FULL where res_qcno = @qcno and res_cuspo <> '' order by res_cuspo

	select @cuspo_count = count(cuspo_sno) from @TMP_CUSPO while (@cuspo_i <= @cuspo_count)
	begin
		select @cuspo = tmp_cuspo from @TMP_CUSPO where cuspo_sno = @cuspo_i + @cuspo_count_start

		set @cuspolist = @cuspolist + '
		' + @cuspo

		select @cuspo_i = @cuspo_i + 1
	end

	select @cuspo_count_start = isnull(max(cuspo_sno),0) from @TMP_CUSPO
	delete from @TMP_CUSPO

	-- 2. Purchase Order List
	set @purordlist = ''
	set @purord_i = 1

	insert into @TMP_PURORD (tmp_purord)
	select distinct res_purord from @RESULT_FULL where res_qcno = @qcno and res_purord <> '' order by res_purord

	select @purord_count = count(purord_sno) from @TMP_PURORD while (@purord_i <= @purord_count)
	begin
		select @purord = tmp_purord from @TMP_PURORD where purord_sno = @purord_i + @purord_count_start

		set @purordlist = @purordlist + '
		' + @purord

		select @purord_i = @purord_i + 1
	end

	select @purord_count_start = isnull(max(purord_sno),0) from @TMP_PURORD
	delete from @TMP_PURORD


	-- 3. Season List
	set @seasonlist = ''
	set @season_i = 1

	insert into @TMP_SEASON (tmp_season)
	select distinct res_season from @RESULT_FULL where res_qcno = @qcno and res_season <> '' order by res_season

	select @season_count = count(season_sno) from @TMP_SEASON while (@season_i <= @season_count)
	begin
		select @season = tmp_season from @TMP_SEASON where season_sno = @season_i + @season_count_start

		set @seasonlist = @seasonlist + '
		' + @season

		select @season_i = @season_i + 1
	end

	select @season_count_start = isnull(max(season_sno),0) from @TMP_SEASON
	delete from @TMP_SEASON


	-- 4. Customer SKU List
	set @cusskulist = ''
	set @cussku_i = 1

	insert into @TMP_CUSSKU (tmp_cussku)
	select distinct res_cussku from @RESULT_FULL where res_qcno = @qcno and res_cussku <> '' order by res_cussku

	select @cussku_count = count(cussku_sno) from @TMP_CUSSKU while (@cussku_i <= @cussku_count)
	begin
		select @cussku = tmp_cussku from @TMP_CUSSKU where cussku_sno = @cussku_i + @cussku_count_start

		set @cusskulist = @cusskulist + '
		' + @cussku

		select @cussku_i = @cussku_i + 1
	end

	select @cussku_count_start = isnull(max(cussku_sno),0) from @TMP_CUSSKU
	delete from @TMP_CUSSKU


	-- 5. SC Ship Window List
	set @scswlist = ''
	set @scsw_i = 1

	insert into @TMP_SCSW (tmp_scsw)
	select distinct res_scsw from @RESULT_FULL where res_qcno = @qcno and res_scsw <> '' order by res_scsw

	select @scsw_count = count(scsw_sno) from @TMP_SCSW while (@scsw_i <= @scsw_count)
	begin
		select @scsw = tmp_scsw from @TMP_SCSW where scsw_sno = @scsw_i + @scsw_count_start

		set @scswlist = @scswlist + '
		' + @scsw

		select @scsw_i = @scsw_i + 1
	end

	select @scsw_count_start = isnull(max(scsw_sno),0) from @TMP_SCSW
	delete from @TMP_SCSW


	-- 6. PO Ship Window List
	set @poswlist = ''
	set @posw_i = 1

	insert into @TMP_POSW (tmp_posw)
	select distinct res_posw from @RESULT_FULL where res_qcno = @qcno and res_posw <> '' order by res_posw

	select @posw_count = count(posw_sno) from @TMP_POSW while (@posw_i <= @posw_count)
	begin
		select @posw = tmp_posw from @TMP_POSW where posw_sno = @posw_i + @posw_count_start

		set @poswlist = @poswlist + '
		' + @posw

		select @posw_i = @posw_i + 1
	end

	select @posw_count_start = isnull(max(posw_sno),0) from @TMP_POSW
	delete from @TMP_POSW




	-- Insert into @RESULT_FINAL
--	select @qcno,@cuspolist, @purordlist, @seasonlist, @cusskulist, @cussku_count, @scswlist, @poswlist
	
	insert into @RESULT_FINAL
	select 
	distinct
	res_inspyear,
	res_inspweek,
	res_qcno,
	res_qcsts,
	res_venno,
	res_vensna,
	res_stt,
	res_cty,
	res_town,
	res_customer,
	@cuspolist,
	@purordlist,
	@seasonlist,
	@cusskulist,
	@cussku_count,
	@scswlist,
	@poswlist,
	res_sidat,
	res_cydat,
	res_mon,
	res_tue,
	res_wed,
	res_thur,
	res_fri,
	res_sat,
	res_sun,
	res_ftyadr,
	res_cnt,
	res_sample,
	res_hksale,
	res_szsale,
	res_insptyp,
	--20151030
	res_verno,
	res_upddat,
	res_city,
	res_rmk
	from @RESULT_FULL where res_qcno = @qcno




	select @qcno_i = @qcno_i + 1
end


select 
	res_qcno as 'QC No',
	res_qcsts as 'QC Status', 
	res_verno as 'Version No',
	res_inspweek as 'QC Week',
	res_upddat AS 'Release Date',
	res_vensna as 'Factory',
	res_stt as 'Province',
	res_city as 'City',
	res_town as 'Town',	
	res_customer as 'Customer',
	res_cuspo as 'Customer PO#',
	res_purord as 'Factory PR#',
	res_season as 'Season',
	res_cussku as 'SKU#', 
	res_skucount as 'SKU QTY per FTY', 
	res_scsw as 'Client SC SW',  
	res_posw as 'Client PO SW', 
	res_sidat as 'SI Date', 
	res_cydat as 'CY Date', 
	res_mon as 'Mon',
	res_tue as 'Tue',
	res_wed as 'Wed',
	res_thur as 'Thur',
	res_fri as 'Fri',
	res_sat as 'Sat',	
	res_sun as 'Sun',	
	res_ftyadr as 'Factory Address',
	res_cnt as 'Contact Person & Tel. No',
	res_sample as 'Approval sample / reference picture',
	res_hksale as 'UCP HK Sales',
	res_szsale as 'UCP SZ Merchandiser',
	res_rmk as 'QC Remark',
	res_insptyp as 'Inspection Type'
	
from @RESULT_FINAL


END






GO
GRANT EXECUTE ON [dbo].[sp_select_QCM00005] TO [ERPUSER] AS [dbo]
GO
