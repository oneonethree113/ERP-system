/****** Object:  StoredProcedure [dbo].[sp_select_QCR00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCR00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCR00003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO


--sp_select_QCR00003 '', ''

CREATE PROCEDURE [dbo].[sp_select_QCR00003] 
@cocde as nvarchar(6),
@qcnolist as nvarchar(2000),
@inspyear as int, 
@inspweek as int

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
res_hksale	nvarchar(20),
res_szsale	nvarchar(20),
res_insptyp	nvarchar(20)
)

declare @RESULT_FINAL table (
res_inspyear	nvarchar(50),
res_inspweek	nvarchar(50),
res_inspdate	nvarchar(50),
res_inspdate2	nvarchar(50),
res_ven01	nvarchar(50),
res_ven02	nvarchar(50),
res_ven03	nvarchar(50),
res_ven04	nvarchar(50),
res_ven05	nvarchar(50),
res_ven06	nvarchar(50),
res_ven07	nvarchar(50),
res_ven08	nvarchar(50),
res_ven09	nvarchar(50),
res_ven10	nvarchar(50),
res_ven11	nvarchar(50),
res_ven12	nvarchar(50),
res_ven13	nvarchar(50),
res_ven14	nvarchar(50),
res_ven15	nvarchar(50),
res_ven16	nvarchar(50),
res_ven17	nvarchar(50),
res_ven18	nvarchar(50),
res_ven19	nvarchar(50),
res_ven20	nvarchar(50))


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
when '' then pri.cbi_cussna else sec.cbi_cussna end as 'customer',
soh_cuspo,
qcd_purord,
sod_season,
sod_cussku,
0,
left(convert(varchar(20),sod_shpstr,103),5) + ' - ' + left(convert(varchar(20),sod_shpend,103),5),
left(convert(varchar(20),pod_shpstr,103),5) + ' - ' + left(convert(varchar(20),pod_shpend,103),5),
convert(varchar(20),getdate(),103),
convert(varchar(20),getdate(),103),
qch_mon,
qch_tue,
qch_wed,
qch_thur,
qch_fri,
qch_sat,
qch_sun,
qvi_adr, --adr.vci_chnadr,
isnull(cnt.vci_cntctp + ' : ' + cnt.vci_cntphn,''),
'',
pri.cbi_srname,
pri.cbi_srname,
qch_insptyp
from QCREQHDR (nolock)
left join QCREQDTL (nolock) on qch_qcno = qcd_qcno
left join QCVENINF (nolock) on qch_qcno = qvi_qcno
left join POORDDTL (nolock) on pod_purord = qcd_purord and pod_purseq = qcd_purseq
--left join SCORDDTL (nolock) on sod_ordno = pod_scno and sod_ordseq = pod_scline
left join SCORDDTL (nolock) on sod_purord = pod_purord and sod_purseq = pod_purseq
left join SCORDHDR (nolock) on soh_ordno = sod_ordno
left join VNBASINF (nolock) on vbi_venno = qch_venno
--left join VNCNTINF adr (nolock) on adr.vci_venno = vbi_venno and adr.vci_cnttyp = 'M'
left join VNCNTINF cnt (nolock) on cnt.vci_venno = vbi_venno and cnt.vci_cnttyp = 'MAGT'
left join CUBASINF (nolock) pri on qch_prmcus = pri.cbi_cusno
left join CUBASINF (nolock) sec on qch_seccus = sec.cbi_cusno
WHERE
	qch_qcsts = 'REL'
AND qch_inspyear = @inspyear
AND qch_inspweek = @inspweek
and qcd_dtlsts <> 'DEL'
order by qch_qcno


declare @week_i int = 1


	 
DECLARE @week_start datetime

SELECT @week_start = dateadd(wk, DATEDIFF(wk, 6, '1/1/' + CONVERT(varchar(4), @inspyear)) + (@inspweek-1), 6)


-- DECLARE @WeekNum INT
      -- , @YearNum char(4);
-- SELECT @WeekNum = 36 
     -- , @YearNum = 2015 
-- SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 6) AS StartOfWeek;




-- 1. Vendor
declare @ven_count int
declare @ven_count_start int = 0
declare @ven_i int =1
declare @ven nvarchar(50)

declare @TMP_VEN table (
ven_sno	int identity(1,1),
tmp_ven nvarchar(50)
)

--update @RESULT_FULL set res_venno = '1756', res_vensna = '哈哈', res_mon = 'Y', res_tue = 'Y' where res_venno = ''

--select * from @RESULT_FULL

while @week_i < 8
begin
	set @ven_i = 1

	if @week_i = 1
	begin
		insert into @RESULT_FINAL
		select distinct @inspyear,@inspweek,'Mon',left(convert(varchar(20), @week_start +1,103),5),
		'','','','','','','','','','',
		'','','','','','','','','',''

		insert into @TMP_VEN (tmp_ven)
		select distinct res_vensna from @RESULT_FULL where res_mon = 'Y' order by res_vensna
	end
	else if @week_i = 2
	begin
		insert into @RESULT_FINAL
		select distinct @inspyear,@inspweek,'Tue',left(convert(varchar(20), @week_start + 2,103),5),
		'','','','','','','','','','',
		'','','','','','','','','',''

		insert into @TMP_VEN (tmp_ven)
		select distinct res_vensna from @RESULT_FULL where res_tue = 'Y' order by res_vensna
	end
	else if @week_i = 3
	begin
		insert into @RESULT_FINAL
		select distinct @inspyear,@inspweek,'Wed',left(convert(varchar(20), @week_start + 3,103),5),
		'','','','','','','','','','',
		'','','','','','','','','',''

		insert into @TMP_VEN (tmp_ven)
		select distinct res_vensna from @RESULT_FULL where res_wed = 'Y' order by res_vensna
	end
	else if @week_i = 4
	begin
		insert into @RESULT_FINAL
		select distinct @inspyear,@inspweek,'Thur',left(convert(varchar(20), @week_start + 4,103),5),
		'','','','','','','','','','',
		'','','','','','','','','',''

		insert into @TMP_VEN (tmp_ven)
		select distinct res_vensna from @RESULT_FULL where res_thur = 'Y' order by res_vensna
	end
	else if @week_i = 5
	begin
		insert into @RESULT_FINAL
		select distinct @inspyear,@inspweek,'Fri',left(convert(varchar(20), @week_start + 5,103),5),
		'','','','','','','','','','',
		'','','','','','','','','',''

		insert into @TMP_VEN (tmp_ven)
		select distinct res_vensna from @RESULT_FULL where res_fri = 'Y' order by res_vensna
	end
	else if @week_i = 6
	begin
		insert into @RESULT_FINAL
		select distinct @inspyear,@inspweek,'Sat',left(convert(varchar(20), @week_start + 6,103),5),
		'','','','','','','','','','',
		'','','','','','','','','',''

		insert into @TMP_VEN (tmp_ven)
		select distinct res_vensna from @RESULT_FULL where res_sat = 'Y' order by res_vensna
	end
	else if @week_i = 7
	begin
		insert into @RESULT_FINAL
		select distinct @inspyear,@inspweek,'Sun',left(convert(varchar(20), @week_start + 7,103),5),
		'','','','','','','','','','',
		'','','','','','','','','',''

		insert into @TMP_VEN (tmp_ven)
		select distinct res_vensna from @RESULT_FULL where res_sun = 'Y' order by res_vensna
	end



	select @ven_count = count(ven_sno) from @TMP_VEN while (@ven_i <= @ven_count)
	begin
		
		select @ven = tmp_ven from @TMP_VEN where ven_sno = @ven_i + @ven_count_start
	
		if @ven_i = 1
			update @RESULT_FINAL set res_ven01 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 2
			update @RESULT_FINAL set res_ven02 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 3
			update @RESULT_FINAL set res_ven03 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 4
			update @RESULT_FINAL set res_ven04 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 5
			update @RESULT_FINAL set res_ven05 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 6
			update @RESULT_FINAL set res_ven06 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 7
			update @RESULT_FINAL set res_ven07 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 8
			update @RESULT_FINAL set res_ven08 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 9
			update @RESULT_FINAL set res_ven09 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 10
			update @RESULT_FINAL set res_ven10 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 11
			update @RESULT_FINAL set res_ven11 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 12
			update @RESULT_FINAL set res_ven12 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 13
			update @RESULT_FINAL set res_ven13 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 14
			update @RESULT_FINAL set res_ven14 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 15
			update @RESULT_FINAL set res_ven15 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 16
			update @RESULT_FINAL set res_ven16 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 17
			update @RESULT_FINAL set res_ven17 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 18
			update @RESULT_FINAL set res_ven18 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 19
			update @RESULT_FINAL set res_ven19 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		else if @ven_i = 20
			update @RESULT_FINAL set res_ven20 = @ven where res_inspdate = case @week_i when 1 then 'Mon' when 2 then 'Tue' when 3 then 'Wed' when 4 then 'Thur' when 5 then 'Fri' when 6 then 'Sat' when 7 then 'Sun' end
		

		select @ven_i = @ven_i + 1


	end
	
	select @ven_count_start = isnull(max(ven_sno),0) from @TMP_VEN
	delete from @TMP_VEN


	select @week_i = @week_i + 1	
end

select * from @RESULT_FINAL



END



GO
GRANT EXECUTE ON [dbo].[sp_select_QCR00003] TO [ERPUSER] AS [dbo]
GO
