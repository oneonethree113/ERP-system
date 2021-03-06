/****** Object:  StoredProcedure [dbo].[sp_select_QCR00001_excel2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCR00001_excel2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCR00001_excel2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE  PROCEDURE [dbo].[sp_select_QCR00001_excel2] 
@cocde as nvarchar(6),
@qcnolist as nvarchar(2000),
@pricust as nvarchar(6),
@venno as nvarchar(6), 
@inspyear as int, 
@inspweek as int,
@inspweek2 as int,
@para_purord as nvarchar(20)


AS

BEGIN

set nocount on

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
res_cusno nvarchar(10),
res_customer	nvarchar(50),
res_cuspo	nvarchar(500),
res_purord	nvarchar(500),
res_season	nvarchar(500),
res_cussku	nvarchar(500),
res_cusitm	nvarchar(500),
res_cussty	nvarchar(500),
res_itmno	nvarchar(500),
res_itmcount	int, -- res_skucount	int,
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
res_hksale	nvarchar(20),
res_szsale	nvarchar(20),
res_insptyp	nvarchar(20),

--20151030
res_verno int, 
res_upddat nvarchar(20), 
res_city nvarchar(30),
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
res_cusno	nvarchar(10),
res_customer	nvarchar(50),
res_cuspo	nvarchar(500),
res_purord	nvarchar(500),
res_season	nvarchar(500),
res_cussku	nvarchar(500),
res_cusitm	nvarchar(500),
res_cussty	nvarchar(500),
res_itmno	nvarchar(500),
res_itmcount	int, -- res_skucount	int,
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
res_hksale	nvarchar(20),
res_szsale	nvarchar(20),
res_insptyp	nvarchar(20),

--20151030
res_verno int, 
res_upddat nvarchar(20),
res_city nvarchar(30),
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
pri.cbi_cusno,
case isnull(sec.cbi_cussna,'')
when '' then pri.cbi_cussna else pri.cbi_cussna + ' (' + sec.cbi_cussna  +')' end as 'customer',
soh_cuspo,
qcd_purord,
sod_season,
sod_cussku,
sod_cusitm,
sod_cusstyno,
sod_itmno,
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
	qch_qcsts = 'REL'
AND (@venno = 'ALL' or (@venno <> 'ALL' and qch_venno = @venno))
AND (@pricust = 'ALL' or (@pricust <> 'ALL' and qch_prmcus = @pricust))
AND qch_inspyear = @inspyear
AND qch_inspweek >= @inspweek
AND qch_inspweek <= @inspweek2
AND (qcd_purord = @para_purord or @para_purord = '')
order by qch_venno,qcd_purord
--order by qch_qcno

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

declare @cusitm_count int
declare @cusitm_count_start int = 0
declare @cusitm_i int =1
declare @cusitm nvarchar(20)
declare @cusitmlist	nvarchar(500)

declare @cussty_count int
declare @cussty_count_start int = 0
declare @cussty_i int =1
declare @cussty nvarchar(20)
declare @cusstylist	nvarchar(500)
 
 declare @itmno_count int
declare @itmno_count_start int = 0
declare @itmno_i int =1
declare @itmno nvarchar(20)
declare @itmnolist	nvarchar(500)


declare @TMP_CUSSKU table (
cussku_sno	int identity(1,1),
tmp_cussku nvarchar(20)
)

declare @TMP_cusitm table (
cusitm_sno	int identity(1,1),
tmp_cusitm nvarchar(20)
)

declare @TMP_cussty table (
cussty_sno	int identity(1,1),
tmp_cussty nvarchar(20)
)

declare @TMP_ITMNO table (
itmno_sno	int identity(1,1),
tmp_itmno nvarchar(20)
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

	if (select count(*) from @TMP_CUSPO) = 0 
		insert into @TMP_CUSPO (tmp_cuspo) values ('')		

	select @cuspo_count = count(cuspo_sno) from @TMP_CUSPO while (@cuspo_i <= @cuspo_count)
	begin
		select @cuspo = tmp_cuspo from @TMP_CUSPO where cuspo_sno = @cuspo_i + @cuspo_count_start

		set @cuspolist = @cuspolist +  CHAR(10) + @cuspo

		select @cuspo_i = @cuspo_i + 1
	end

	select @cuspo_count_start = isnull(max(cuspo_sno),0) from @TMP_CUSPO
	delete from @TMP_CUSPO

	-- 2. Purchase Order List
	set @purordlist = ''
	set @purord_i = 1

	insert into @TMP_PURORD (tmp_purord)
	select distinct res_purord from @RESULT_FULL where res_qcno = @qcno and res_purord <> '' order by res_purord

	if (select count(*) from @TMP_PURORD) = 0 
		insert into @TMP_PURORD (tmp_purord) values ('')		

	select @purord_count = count(purord_sno) from @TMP_PURORD while (@purord_i <= @purord_count)
	begin
		select @purord = tmp_purord from @TMP_PURORD where purord_sno = @purord_i + @purord_count_start

		set @purordlist = @purordlist +  CHAR(10) + @purord

		select @purord_i = @purord_i + 1
	end

	select @purord_count_start = isnull(max(purord_sno),0) from @TMP_PURORD
	delete from @TMP_PURORD


	-- 3. Season List
	set @seasonlist = ''
	set @season_i = 1

	insert into @TMP_SEASON (tmp_season)
	select distinct res_season from @RESULT_FULL where res_qcno = @qcno and res_season <> '' order by res_season

	if (select count(*) from @TMP_SEASON) = 0 
		insert into @TMP_SEASON (tmp_season) values ('')		

	select @season_count = count(season_sno) from @TMP_SEASON while (@season_i <= @season_count)
	begin
		select @season = tmp_season from @TMP_SEASON where season_sno = @season_i + @season_count_start

		set @seasonlist = @seasonlist +  CHAR(10) + @season

		select @season_i = @season_i + 1
	end

	select @season_count_start = isnull(max(season_sno),0) from @TMP_SEASON
	delete from @TMP_SEASON


	-- 4. Customer SKU List
	set @cusskulist = ''
	set @cussku_i = 1

	set @cusitmlist = ''
	set @cusitm_i = 1

	set @cusstylist = ''
	set @cussty_i = 1

	set @itmnolist = ''
	set @itmno_i = 1

	insert into @TMP_CUSSKU (tmp_cussku)
	select distinct res_cussku from @RESULT_FULL where res_qcno = @qcno and res_cussku <> '' order by res_cussku

	if (select count(*) from @TMP_CUSSKU) = 0 
		insert into @TMP_CUSSKU (tmp_cussku) values ('')		


	insert into @TMP_ITMNO (tmp_itmno)
	select distinct res_itmno from @RESULT_FULL where res_qcno = @qcno and res_itmno <> '' order by res_itmno

	if (select count(*) from @TMP_ITMNO) = 0 
		insert into @TMP_ITMNO (tmp_itmno) values ('')	


	--select * from @TMP_CUSSKU

	select @cussku_count = count(cussku_sno) from @TMP_CUSSKU while (@cussku_i <= @cussku_count)
	begin
		select @cussku = tmp_cussku from @TMP_CUSSKU where cussku_sno = @cussku_i + @cussku_count_start

		set @cusskulist = @cusskulist +  CHAR(10) + @cussku

		select @cussku_i = @cussku_i + 1
	end

	select @cussku_count_start = isnull(max(cussku_sno),0) from @TMP_CUSSKU
	delete from @TMP_CUSSKU



	select @cusitm_count = count(cusitm_sno) from @TMP_cusitm while (@cusitm_i <= @cusitm_count)
	begin
		select @cusitm = tmp_cusitm from @TMP_cusitm where cusitm_sno = @cusitm_i + @cusitm_count_start

		set @cusitmlist = @cusitmlist +  CHAR(10) + @cusitm

		select @cusitm_i = @cusitm_i + 1
	end

	select @cusitm_count_start = isnull(max(cusitm_sno),0) from @TMP_cusitm
	delete from @TMP_cusitm


	select @cussty_count = count(cussty_sno) from @TMP_cussty while (@cussty_i <= @cussty_count)
	begin
		select @cussty = tmp_cussty from @TMP_cussty where cussty_sno = @cussty_i + @cussty_count_start

		set @cusstylist = @cusstylist +  CHAR(10) + @cussty

		select @cussty_i = @cussty_i + 1
	end

	select @cussty_count_start = isnull(max(cussty_sno),0) from @TMP_cussty
	delete from @TMP_cussty


	select @itmno_count = count(itmno_sno) from @TMP_itmno while (@itmno_i <= @itmno_count)
	begin
		select @itmno = tmp_itmno from @TMP_itmno where itmno_sno = @itmno_i + @itmno_count_start

		set @itmnolist = @itmnolist +  CHAR(10) + @itmno

		select @itmno_i = @itmno_i + 1
	end

	select @itmno_count_start = isnull(max(itmno_sno),0) from @TMP_itmno
	delete from @TMP_itmno

	-- 5. SC Ship Window List
	set @scswlist = ''
	set @scsw_i = 1

	insert into @TMP_SCSW (tmp_scsw)
	select distinct res_scsw from @RESULT_FULL where res_qcno = @qcno and res_scsw <> '' order by res_scsw

	if (select count(*) from @TMP_SCSW) = 0
		insert into @TMP_SCSW (tmp_scsw) values ('')

	select @scsw_count = count(scsw_sno) from @TMP_SCSW while (@scsw_i <= @scsw_count)
	begin
		select @scsw = tmp_scsw from @TMP_SCSW where scsw_sno = @scsw_i + @scsw_count_start

		set @scswlist = @scswlist +  CHAR(10) + @scsw

		select @scsw_i = @scsw_i + 1
	end

	select @scsw_count_start = isnull(max(scsw_sno),0) from @TMP_SCSW
	delete from @TMP_SCSW


	-- 6. PO Ship Window List
	set @poswlist = ''
	set @posw_i = 1

	insert into @TMP_POSW (tmp_posw)
	select distinct res_posw from @RESULT_FULL where res_qcno = @qcno and res_posw <> '' order by res_posw

	if (select count(*) from @TMP_POSW) = 0
		insert into @TMP_POSW (tmp_posw) values ('')

	select @posw_count = count(posw_sno) from @TMP_POSW while (@posw_i <= @posw_count)
	begin
		select @posw = tmp_posw from @TMP_POSW where posw_sno = @posw_i + @posw_count_start

		set @poswlist = @poswlist +  CHAR(10) + @posw

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
	res_cusno,
	res_customer,
	@cuspolist,
	@purordlist,
	@seasonlist,
	@cusskulist,
	@cusitmlist,
	@cusstylist,
	@itmnolist,
	@itmno_count,
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
	order by res_venno



	select @qcno_i = @qcno_i + 1
end



select 

res_qcno,
res_verno,
res_upddat,
res_inspweek,
		
res_venno + ' - ' + res_vensna res_vennoandname,
--res_venno,res_vensna,

res_stt,
res_city,
res_town,
res_cusno + ' - ' + res_customer res_cusnoandname,
--res_cusno, 
--res_customer ,
res_cuspo,
res_purord,
res_season,
res_cussku,
res_cusitm,
res_cussty,
res_itmno,
res_itmcount, --res_skucount,
res_scsw,
res_posw,
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
res_rmk,
res_insptyp

from @RESULT_FINAL
ORDER BY res_venno,res_purord

END

GO
GRANT EXECUTE ON [dbo].[sp_select_QCR00001_excel2] TO [ERPUSER] AS [dbo]
GO
