/****** Object:  StoredProcedure [dbo].[sp_select_INR00004_3]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00004_3]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00004_3]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
======================================================================
Program ID	: sp_select_INR00004_3
Description		: a stored procedure to retrieve CBM Delivery in the privious of year of @year (Input year value)
Programmer	: Lester Wu
ALTER  Date		: 2004/05/24
Table Read(s)	: SCORDDTL
Table Write(s)	: 
======================================================================
Modification History
======================================================================
Date		Initial		Description
2005-03-29	Lester Wu		replace "ALL" with "UC-G" and exclude MS company from "UC-G"
				retrieve database information from database instead of hardcode
======================================================================

*/


CREATE  PROCEDURE [dbo].[sp_select_INR00004_3]

@cocde	nvarchar(6),
@VenFm	nvarchar(40),
@VenTo	nvarchar(40),
@SCFm	nvarchar(40),
@SCTo	nvarchar(40),
@YEAR 	int

AS 
Declare
@VenFmC	nvarchar(6),
@VenToC	nvarchar(6),
@SCFmC	nvarchar(4),
@SCToC	nvarchar(4)
If @VenFm <> ''
begin
	Set @VenFmC = left(@VenFm, charindex('-', @VenFm) - 1)
end
If @VenTo <> ''
begin
	Set @VenToC = left(@VenTo, charindex('-', @VenTo) - 1)
end
If @SCFm <> ''
begin
	Set @SCFmC = left(@SCFm, charindex('-', @SCFm) - 1)
end
If @SCTo <> ''
begin
	Set @SCToC = left(@SCTo, charindex('-', @SCTo) - 1)
end

--Lester Wu 2005-03-29, retrieve company name from database instead of hardcode
declare @compName as varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde <> 'UC-G' 
BEGIN
	select @compName = yco_conam from SYCOMINF where yco_cocde = @cocde
END
----------------------------------------------------------------------------------------------------
create table #TEMP_CBM_DELIVERY
(
tmp_ordno	nvarchar(20),
tmp_ordseq	int,
tmp_shpseq	int,
tmp_shpstr	datetime,
tmp_cft		numeric(13,4),
tmp_ordqty	int,
tmp_mtrctn	numeric(13,4)
)

declare 
@sod_ordno nvarchar(20),
@sod_ordseq int,
@sds_shpseq int,
@sds_scfrom datetime,
@sod_cft numeric(13,4),
@sds_ordqty int,
@sod_mtrctn int,
@sod_ordqty int,
@sod_shpqty int,
@last_sod_ordno nvarchar(20),
@last_sod_ordseq int,
@used_shpqty int,
@remain_shpqty int

set @sod_ordno = ''
set @sod_ordseq = 0
set @last_sod_ordno = ''
set @last_sod_ordseq = 0
set @used_shpqty = 0
set @remain_shpqty = 0

--Lester Wu 2005-03-29 replace "ALL" with "UC-G"
--IF @COCDE <> 'ALL' 
IF @COCDE <> 'UC-G' 
BEGIN



	insert into #TEMP_CBM_DELIVERY
	select
	sod_ordno,
	sod_ordseq,
	0,
	sod_shpstr,
	sod_cft,
	sod_shpqty,
	sod_mtrctn
	from 	
		scorddtl (nolock)
		left join scdtlshp (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq
		left join vnbasinf (nolock) on vbi_venno = sod_venno 
	where 	
		sds_cocde is null and
		vbi_ventyp <> 'E' and
		year(sod_shpstr) = @YEAR -1  and sod_cocde = @cocde
	and	((@VenFm <> '' and sod_venno between @VenFmC and @VenToC) or @VenFm = '')
	and	((@SCFm <> '' and sod_subcde between @SCFmC and @SCToC) or @SCFm = '')


	insert into #TEMP_CBM_DELIVERY
	select
	sod_ordno,
	sod_ordseq,
	sds_shpseq,
	sds_scfrom,
	sod_cft,
	sds_ordqty,
	sod_mtrctn
	from 	
		scorddtl (nolock)
		left join scdtlshp (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq
		left join vnbasinf (nolock) on vbi_venno = sod_venno 
	where 	
		sds_cocde is not null and
		vbi_ventyp <> 'E' and
		sod_ordqty = sod_shpqty and
--		(year(sod_shpstr) = @YEAR -1 or (year(sds_scfrom) = @YEAR-1 and year(sod_shpstr) <> @YEAR -1))
		year(sds_scfrom) = @YEAR-1 
	and sod_cocde = @cocde
	and	((@VenFm <> '' and sod_venno between @VenFmC and @VenToC) or @VenFm = '')
	and	((@SCFm <> '' and sod_subcde between @SCFmC and @SCToC) or @SCFm = '')

	declare cur_delivery_scdtlshp cursor
	for
	select
	sod_ordno,
	sod_ordseq,
	sds_shpseq,
	sds_scfrom,
	sod_cft,
	sds_ordqty,
	sod_mtrctn,
	sod_ordqty,
	sod_shpqty
	from 	
		scorddtl (nolock)
		left join scdtlshp (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq
		left join vnbasinf (nolock) on vbi_venno = sod_venno 
	where 	
		sds_cocde is not null and
		vbi_ventyp <> 'E' and
		sod_ordqty <> sod_shpqty and
		(year(sod_shpstr) = @YEAR -1 or (year(sds_scfrom) = @YEAR-1 and year(sod_shpstr) = @YEAR-1))  and sod_cocde = @cocde
		--year(sds_scfrom) = @YEAR-1 and sod_cocde = @cocde
	and	((@VenFm <> '' and sod_venno between @VenFmC and @VenToC) or @VenFm = '')
	and	((@SCFm <> '' and sod_subcde between @SCFmC and @SCToC) or @SCFm = '')
	order by sod_ordno,sod_ordseq,sds_shpseq

	open cur_delivery_scdtlshp
	fetch next from cur_delivery_scdtlshp into @sod_ordno,@sod_ordseq,@sds_shpseq,@sds_scfrom,@sod_cft,@sds_ordqty,@sod_mtrctn,@sod_ordqty,@sod_shpqty

	while @@fetch_status = 0
	begin
		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @remain_shpqty = @sod_shpqty
			set @used_shpqty = 0
		end

		if @remain_shpqty - @sds_ordqty >= 0 
		begin
			insert into #TEMP_CBM_DELIVERY
			select @sod_ordno,@sod_ordseq,@sds_shpseq,@sds_scfrom,@sod_cft,@sds_ordqty,@sod_mtrctn
			
			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end
		else if @remain_shpqty > 0
		begin
			insert into #TEMP_CBM_DELIVERY
			select @sod_ordno,@sod_ordseq,@sds_shpseq,@sds_scfrom,@sod_cft,@remain_shpqty,@sod_mtrctn

			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end

		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @last_sod_ordno = @sod_ordno
			set @last_sod_ordseq = @sod_ordseq
		end
		fetch next from cur_delivery_scdtlshp into @sod_ordno,@sod_ordseq,@sds_shpseq,@sds_scfrom,@sod_cft,@sds_ordqty,@sod_mtrctn,@sod_ordqty,@sod_shpqty
	end
	close cur_delivery_scdtlshp
	deallocate cur_delivery_scdtlshp



	select 	'F0' = @cocde,
		'F1' = 'CBM Delivery (LY)', 
		'F2' = @VenFm,
		'F3' = @VenTo,
		'F4' = @SCFm,	
		'F5' = @SCTo,
		'F6' = year(tmp_shpstr),
		'F7' = month(tmp_shpstr), 
		'F8' = case month(tmp_shpstr) 
			when 1 then '01'  + space(30)
			when 2 then '02' + space(30)
			when 3 then '03' + space(30)
			when 4 then '04' + space(30)
			when 5 then '05' + space(30)
			when 6 then '06' + space(30)
			when 7 then '07' + space(30)
			when 8 then '08' + space(30)
			when 9 then '09' + space(30)
			when 10 then '10' + space(30)
			when 11 then '11' + space(30)
			when 12 then '12' + space(30) end,
		'F9' =cast( round(sum(tmp_cft*tmp_ordqty/tmp_mtrctn/35.32),0) as decimal(9,0)),
		'compName' = @compName
	from 	#TEMP_CBM_DELIVERY
	where year(tmp_shpstr) = @YEAR-1
	group by 	year(tmp_shpstr), month(tmp_shpstr)
	order by 	year(tmp_shpstr),month(tmp_shpstr)
END
ELSE
BEGIN


	insert into #TEMP_CBM_DELIVERY
	select
	sod_ordno,
	sod_ordseq,
	0,
	sod_shpstr,
	sod_cft,
	sod_shpqty,
	sod_mtrctn
	from 	
		scorddtl (nolock)
		left join scdtlshp (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq
		left join vnbasinf (nolock) on vbi_venno = sod_venno 
	where 	
		sds_cocde is null and
		vbi_ventyp <> 'E' and
		year(sod_shpstr) = @YEAR -1  --and sod_cocde = @cocde
	and	((@VenFm <> '' and sod_venno between @VenFmC and @VenToC) or @VenFm = '')
	and	((@SCFm <> '' and sod_subcde between @SCFmC and @SCToC) or @SCFm = '')


	insert into #TEMP_CBM_DELIVERY
	select
	sod_ordno,
	sod_ordseq,
	sds_shpseq,
	sds_scfrom,
	sod_cft,
	sds_ordqty,
	sod_mtrctn
	from 	
		scorddtl (nolock)
		left join scdtlshp (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq
		left join vnbasinf (nolock) on vbi_venno = sod_venno 
	where 	
		sds_cocde is not null and
		vbi_ventyp <> 'E' and
		sod_ordqty = sod_shpqty and
		--(year(sod_shpstr) = @YEAR -1 or (year(sds_scfrom) = @YEAR-1 and year(sod_shpstr) <> @YEAR -1)) 
		year(sds_scfrom) = @YEAR-1 
	--and sod_cocde = @cocde
	and	((@VenFm <> '' and sod_venno between @VenFmC and @VenToC) or @VenFm = '')
	and	((@SCFm <> '' and sod_subcde between @SCFmC and @SCToC) or @SCFm = '')

	declare cur_delivery_scdtlshp cursor
	for
	select
	sod_ordno,
	sod_ordseq,
	sds_shpseq,
	sds_scfrom,
	sod_cft,
	sds_ordqty,
	sod_mtrctn,
	sod_ordqty,
	sod_shpqty
	from 	
		scorddtl (nolock)
		left join scdtlshp (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq
		left join vnbasinf (nolock) on vbi_venno = sod_venno 
	where 	
		sds_cocde is not null and
		vbi_ventyp <> 'E' and
		sod_ordqty <> sod_shpqty and
		(year(sod_shpstr) = @YEAR -1  or (year(sds_scfrom) = @YEAR-1 and year(sod_shpstr) <> @YEAR-1))
		--year(sds_scfrom) = @YEAR-1 
	--and sod_cocde = @cocde
	and	((@VenFm <> '' and sod_venno between @VenFmC and @VenToC) or @VenFm = '')
	and	((@SCFm <> '' and sod_subcde between @SCFmC and @SCToC) or @SCFm = '')
	order by sod_ordno,sod_ordseq,sds_shpseq

	open cur_delivery_scdtlshp
	fetch next from cur_delivery_scdtlshp into @sod_ordno,@sod_ordseq,@sds_shpseq,@sds_scfrom,@sod_cft,@sds_ordqty,@sod_mtrctn,@sod_ordqty,@sod_shpqty

	while @@fetch_status = 0
	begin
		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @remain_shpqty = @sod_shpqty
			set @used_shpqty = 0
		end

		if @remain_shpqty - @sds_ordqty >= 0 
		begin
			insert into #TEMP_CBM_DELIVERY
			select @sod_ordno,@sod_ordseq,@sds_shpseq,@sds_scfrom,@sod_cft,@sds_ordqty,@sod_mtrctn
			
			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end
		else if @remain_shpqty > 0
		begin
			insert into #TEMP_CBM_DELIVERY
			select @sod_ordno,@sod_ordseq,@sds_shpseq,@sds_scfrom,@sod_cft,@remain_shpqty,@sod_mtrctn

			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end

		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @last_sod_ordno = @sod_ordno
			set @last_sod_ordseq = @sod_ordseq
		end
		fetch next from cur_delivery_scdtlshp into @sod_ordno,@sod_ordseq,@sds_shpseq,@sds_scfrom,@sod_cft,@sds_ordqty,@sod_mtrctn,@sod_ordqty,@sod_shpqty
	end
	close cur_delivery_scdtlshp
	deallocate cur_delivery_scdtlshp



	select 	'F0' = @cocde,
		'F1' = 'CBM Delivery (LY)', 
		'F2' = @VenFm,
		'F3' = @VenTo,
		'F4' = @SCFm,	
		'F5' = @SCTo,
		'F6' = year(tmp_shpstr),
		'F7' = month(tmp_shpstr), 
		'F8' = case month(tmp_shpstr) 
			when 1 then '01'  + space(30)
			when 2 then '02' + space(30)
			when 3 then '03' + space(30)
			when 4 then '04' + space(30)
			when 5 then '05' + space(30)
			when 6 then '06' + space(30)
			when 7 then '07' + space(30)
			when 8 then '08' + space(30)
			when 9 then '09' + space(30)
			when 10 then '10' + space(30)
			when 11 then '11' + space(30)
			when 12 then '12' + space(30) end,
		'F9' =cast( round(sum(tmp_cft*tmp_ordqty/tmp_mtrctn/35.32),0) as decimal(9,0)),
		'compName' = @compName
	from 	#TEMP_CBM_DELIVERY
	where year(tmp_shpstr) = @YEAR-1
	group by 	year(tmp_shpstr), month(tmp_shpstr)
	order by 	year(tmp_shpstr),month(tmp_shpstr)
END










GO
GRANT EXECUTE ON [dbo].[sp_select_INR00004_3] TO [ERPUSER] AS [dbo]
GO
