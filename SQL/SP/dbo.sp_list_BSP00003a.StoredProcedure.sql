/****** Object:  StoredProcedure [dbo].[sp_list_BSP00003a]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_BSP00003a]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_BSP00003a]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO








/*
=========================================================
Program ID	: sp_list_BSP00003a
Description   	: 
Programmer  	: Marco Chan
ALTER  Date   	: 20/10/2005
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
-- sp_list_BSP00003a '', '03/01/2004 00:00:00.000', '03/30/2004 23:59:59', '', '', '1328', '1328', 'E', '', '', '', '', '', '', '', '', '', '2004 X''''mas Season', 'A', 'Y', 'N', 'X'

*/
create procedure [dbo].[sp_list_BSP00003a]
	@cocde		nvarchar(6),	

	@itmcredatFm	datetime,
	@itmcredatTo	datetime,

	@scissdatFm	datetime,
	@scissdatTo	datetime,

	@vdrFm		nvarchar(20),
	@vdrTo		nvarchar(20),
	@vdrTyp		char(1),

	@itmnoFm	nvarchar(20),
	@itmnoTo	nvarchar(20),
	@itmList	nvarchar(1000),

	@prdlneFm	nvarchar(10),
	@prdlneTo	nvarchar(10),
	@prdlneList	nvarchar(1000),

	@excustFm	nvarchar(10),
	@excustTo	nvarchar(10),
	@excustList	nvarchar(1000),

	@title		nvarchar(100),

	@orderBy	nvarchar(20),
	@printAmt	nvarchar(20),

	@showCust	char(1),
--	@TEMP		nvarchar(10)
	@optSal_Pur	char(1) , 
	@optPrice		char(1)
as

set nocount on 

declare @optItmStr		char(1),
	@optPrdLneStr		char(1),
	@optExCustStr		char(1),
	@ItmStrRemain		nvarchar(1000),
	@PrdLneStrRemain	nvarchar(1000),
	@ExCustStrRemain	nvarchar(1000),
	@ItmStrPart		nvarchar(20),
	@PrdLneStrPart		nvarchar(10),
	@ExCustStrPart		nvarchar(10)
create table #TMP_ITM (tmp_ITMNO nvarchar(20)) on [PRIMARY]
create table #TMP_LNE (tmp_PRDLNE nvarchar(10)) on [PRIMARY]
create table #TMP_EXCUST (tmp_CUSNO nvarchar(10)) on [PRIMARY]
create table #TMP_PCK (tmp_pckunt nvarchar(10), tmp_pckinr int, tmp_pckmtr int) on [PRIMARY]

set @optItmStr = 'N'
if ltrim(rtrim(@itmList)) <> '' 
begin 
	set @optItmStr = 'Y'
	set @ItmStrRemain = @itmList

	while charindex(',',@ItmStrRemain)<>0
	begin
		set @ItmStrPart = ltrim(left(@ItmStrRemain, charindex(',', @ItmStrRemain)-1))
		set @ItmStrRemain = right(@ItmStrRemain, len(@ItmStrRemain) - charindex(',', @ItmStrRemain))
		insert into #TMP_ITM values (@ItmStrPart)
	end

	if charindex(',',@ItmStrRemain) = 0 
		insert into #TMP_ITM values (@ItmStrRemain)
end

set @optPrdLneStr = 'N'
if ltrim(rtrim(@prdlneList)) <> ''
begin
	set @optPrdLneStr = 'Y'
	set @PrdLneStrRemain = @prdlneList

	while charindex(',', @PrdLneStrRemain) <> 0
	begin
		set @PrdLneStrPart = ltrim(left(@PrdLneStrRemain, charindex(',', @PrdLneStrRemain)-1))
		set @PrdLneStrRemain = right(@PrdLneStrRemain, len(@PrdLneStrRemain) - charindex(',', @PrdLneStrRemain))
		insert into #TMP_LNE values (@PrdLneStrPart)
	end

	if charindex(',',@PrdLneStrRemain) = 0 
		insert into #TMP_LNE values (ltrim(@PrdLneStrRemain))
end

set @optExCustStr = 'N'
if ltrim(rtrim(@excustList)) <> ''
begin
	set @optExCustStr = 'Y'
	set @ExCustStrRemain = @excustList

	while charindex(',', @ExCustStrRemain) <> 0
	begin
		set @ExCustStrPart = ltrim(left(@ExCustStrRemain, charindex(',', @ExCustStrRemain)-1))
		set @ExCustStrRemain = right(@ExCustStrRemain, len(@ExCustStrRemain) - charindex(',', @ExCustStrRemain))
		insert into #TMP_EXCUST values (@ExCustStrPart)
	end

	if charindex(',',@ExCustStrRemain) = 0 
		insert into #TMP_EXCUST values (ltrim(@ExCustStrRemain))
end


CREATE TABLE #TMP_RESULT(
	tmp_venno	nvarchar(20),
	tmp_vensna	nvarchar(50),
--	tmp_vensna	nvarchar(20),
	tmp_itmno	nvarchar(20),
	tmp_itmdsc	nvarchar(800),
	tmp_imgpth	nvarchar(200),
	tmp_prdlne	nvarchar(20)
)

CREATE TABLE #RESULT(
	res_reccnt	int,
	res_venno	nvarchar(20),
	--res_vensna	nvarchar(20),
	res_vensna	nvarchar(50),
	res_itmno	nvarchar(20),
	res_itmdsc	nvarchar(800),
	res_pckstr	nvarchar(1000),
	res_baseunt	nvarchar(6),
	res_ordqty	int,
	res_salamtusd	numeric(13,2),	
	res_imgpth	nvarchar(200),
	res_qutcus	nvarchar(1000),
	res_ttlcnt_vdr	int,
	res_qutcnt_vdr	int
)

declare @optVdr char(1), @optItmno char(1), @optPrdlne char(1), @optVdrTyp char(1)
declare @optSCIssDate char(1)

if @vdrFm = ''
	set @optVdr = 'N'
else
	set @optVdr = 'Y'

if @itmnoFm = ''
	set @optItmno = 'N'
else
	set @optItmno = 'Y'

if @prdlneFm = ''
	set @optPrdlne = 'N'
else
	set @optPrdlne = 'Y'

if @scissdatFm = ''
	set @optSCIssDate = 'N'
else
	set @optSCIssDate = 'Y'



insert into #TMP_RESULT
select 
distinct
vbi_venno, 
vbi_vensna,
ibi_itmno,
ibi_engdsc,
ibi_imgpth,
ibi_lnecde
from 
IMBASINF (nolock)
left join IMVENINF (nolock) on ibi_itmno = ivi_itmno and ivi_def = 'Y'
left join VNBASINF (nolock) on vbi_venno = ivi_venno
where
(ibi_credat between @itmcredatFm and @itmcredatTo)
and (@vdrTyp = '' or (vbi_ventyp = @vdrTyp))
and (@optVdr = 'N' or (vbi_venno between @vdrFm and @vdrTo))
and (@optItmno = 'N' or (ibi_itmno between @itmnoFm and @itmnoTo))
and (@optPrdlne = 'N' or (ibi_lnecde between @prdlneFm and @prdlneTo))

if @optItmStr = 'Y' and @optPrdLneStr = 'Y'
begin
	insert into #RESULT
	select
	0,
	a.tmp_venno,
	a.tmp_vensna,
	a.tmp_itmno,
	a.tmp_itmdsc,
	'',
	'',
	0,
	0,
	a.tmp_imgpth,
	'',
	0,
	0
	from 
	#TMP_RESULT a, #TMP_ITM b, #TMP_LNE c
	where a.tmp_itmno = b.tmp_ITMNO
	and a.tmp_prdlne = c.tmp_PRDLNE
end
else if @optItmStr = 'Y'
begin
	insert into #RESULT
	select
	0,
	a.tmp_venno,
	a.tmp_vensna,
	a.tmp_itmno,
	a.tmp_itmdsc,
	'',
	'',
	0,
	0,
	a.tmp_imgpth,
	'',
	0,
	0
	from 
	#TMP_RESULT a, #TMP_ITM b
	where a.tmp_itmno = b.tmp_ITMNO
end
else if @optPrdLneStr = 'Y'
begin
	insert into #RESULT
	select
	0,
	a.tmp_venno,
	a.tmp_vensna,
	a.tmp_itmno,
	a.tmp_itmdsc,
	'',
	'',
	0,
	0,
	a.tmp_imgpth,
	'',
	0,
	0
	from 
	#TMP_RESULT a, #TMP_LNE c
	where a.tmp_prdlne = c.tmp_PRDLNE
end
else
begin
	insert into #RESULT
	select
	0,
	a.tmp_venno,
	a.tmp_vensna,
	a.tmp_itmno,
	a.tmp_itmdsc,
	'',
	'',
	0,
	0,
	a.tmp_imgpth,
	'',
	0,
	0
	from 
	#TMP_RESULT a
end


declare @vendor nvarchar(20), @pre_vendor nvarchar(20)
declare @itmno nvarchar(20)
declare @cussna nvarchar(50), @cusString nvarchar(1000)

declare @pckunt nvarchar(10), @pckmtr int, @pckinr int, @pckcft numeric(13,2), @pckString nvarchar(1000)
declare @pckcount int, @max_sod_credat datetime

declare @ordqty int, @salamtusd numeric(13,4), @baseunt nvarchar(6)

declare @counter0 int, @counter1 int
set @counter0 = 0 -- count for total per vendor
set @counter1 = 0 -- count for quoted total per vendor

set @pre_vendor = ''

declare cur_itmno cursor for select res_venno, res_itmno from #RESULT order by res_venno, res_itmno
open cur_itmno
fetch next from cur_itmno into @vendor, @itmno

while @@fetch_status = 0
begin
	if @pre_vendor = ''
		set @pre_vendor = @vendor
	
	if @pre_vendor = @vendor
	begin
		set @counter0 = @counter0 + 1
	end
	else
	begin
		set @counter0 = 1
		set @counter1 = 0
		set @pre_vendor = @vendor
	end

	set @cusString = ''

	declare cur_cusno cursor for 
	select distinct cbi_cussna 
	from SCORDDTL (nolock)
	left join SCORDHDR (nolock) on sod_ordno = soh_ordno
	left join CUBASINF (nolock) on cbi_cusno = soh_cus1no
	where sod_itmno = @itmno 
	and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
	and cbi_cusno not in (select tmp_CUSNO from #TMP_EXCUST)
	
	open cur_cusno
	fetch next from cur_cusno into @cussna
	
	while @@fetch_status = 0
	begin
		if @cusString = '' 
		begin
			set @cusString = @cussna
		end
		else
		begin
			set @cusString = @cusString + ', ' + @cussna
		end
		
		fetch next from cur_cusno into @cussna
	end
	close cur_cusno
	deallocate cur_cusno


	set @ordqty = 0
	set @salamtusd = 0

	-- Order Qty in PC
	select @ordqty = sum(sod_ordqty * isnull(ycf_value, 0)), @baseunt = ycf_code2 
	from SCORDDTL (nolock)
	left join SCORDHDR (nolock) on sod_ordno = soh_ordno
	left join SYCONFTR (nolock) on ycf_code1 = sod_pckunt
	where sod_itmno = @itmno
	and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
	and soh_cus1no not in (select tmp_CUSNO from #TMP_EXCUST)
	group by ycf_code2

	

	if @optSal_Pur = 'S' 
	begin
/*
		-- Sales Amount in USD
		select @salamtusd = isnull(sum(sod_selprc * isnull(a.ysi_selrat, 0)), 0)
		from SCORDDTL (nolock)
		left join SCORDHDR (nolock) on sod_ordno = soh_ordno
		left join SYSETINF a (nolock) on a.ysi_typ = '06' and a.ysi_cde = sod_curcde
		where sod_itmno = @itmno
		and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
		and soh_cus1no not in (select tmp_CUSNO from #TMP_EXCUST)
*/
		-- Frankie Cheung 20091008
		-- Sales Amount in USD
		select @salamtusd = sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat, 0) end)
		from SCORDDTL (nolock)
		left join SCORDHDR (nolock) on sod_ordno = soh_ordno
		where sod_itmno = @itmno
		and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
		and soh_cus1no not in (select tmp_CUSNO from #TMP_EXCUST)
		----------------------------
	--XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- Lester Wu 2006-05-27, add option to show Purchase Amt
	end
	else if @optSal_Pur = 'P'
	begin
/*	
		-- Purchase Amount in USD
		select @salamtusd =  isnull(sum( isnull(pod_ordqty,0) * isnull(pod_ftyprc,0) * isnull(b.ysi_buyrat, 0)), 0)
		from SCORDDTL (nolock)
		left join SCORDHDR (nolock) on sod_ordno = soh_ordno
		left join POORDDTL (nolock) on sod_purord = pod_purord and sod_purseq = pod_purseq
		left join POORDHDR (nolock) on pod_purord = poh_purord and pod_cocde = poh_cocde
		left join SYSETINF b (nolock) on b.ysi_typ = '06' and b.ysi_cde = isnull(poh_curcde,'')
		where sod_itmno = @itmno
		and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
		and soh_cus1no not in (select tmp_CUSNO from #TMP_EXCUST)
*/
		-- Frankie Cheung 20091008
		-- Purchase Amount in USD 
		select @salamtusd =  isnull(sum( isnull(pod_ordqty,0) * isnull(pod_ftyprc,0) * isnull(yce_buyrat, 0)), 0)
		from SCORDDTL (nolock)
		left join SCORDHDR (nolock) on sod_ordno = soh_ordno
		left join POORDDTL (nolock) on sod_purord = pod_purord and sod_purseq = pod_purseq
		left join POORDHDR (nolock) on pod_purord = poh_purord and pod_cocde = poh_cocde
		,SYCUREX (nolock)
		where sod_itmno = @itmno
		and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
		and soh_cus1no not in (select tmp_CUSNO from #TMP_EXCUST)
		and yce_frmcur =  isnull(poh_curcde,'') and yce_tocur = 'USD' and yce_iseff = 'Y' 
		--------------------------
	end
	--XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

	if @ordqty <> 0 or @salamtusd <> 0
	begin
		-- Packing String
		set @pckString = ''
		delete from #TMP_PCK
	
		insert into #TMP_PCK
		select distinct sod_pckunt, sod_inrctn, sod_mtrctn
		from SCORDDTL (nolock)
		left join SCORDHDR (nolock) on sod_ordno = soh_ordno
		where sod_itmno = @itmno 
		and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
		and soh_cus1no not in (select tmp_CUSNO from #TMP_EXCUST)
	
		declare cur_pck cursor for 
		select distinct tmp_pckunt, tmp_pckinr, tmp_pckmtr from #TMP_PCK
	
		open cur_pck
		fetch next from cur_pck into @pckunt, @pckinr, @pckmtr
		
		while @@fetch_status = 0
		begin
			select @pckcount = count(*) from IMBASINF (nolock), IMPCKINF (nolock)
			where ibi_itmno = ipi_itmno
			and ibi_itmno = @itmno 
			and ipi_pckunt = @pckunt and ipi_mtrqty = @pckmtr and ipi_inrqty = @pckinr
			
			if @pckcount = 1
			begin
				select @pckcft = ipi_cft from IMBASINF (nolock), IMPCKINF (nolock)
				where ibi_itmno = ipi_itmno
				and ibi_itmno = @itmno 
				and ipi_pckunt = @pckunt and ipi_mtrqty = @pckmtr and ipi_inrqty = @pckinr
			end
			else
			begin
				select @max_sod_credat = sod_credat from SCORDDTL (nolock)
				left join SCORDHDR (nolock) on sod_ordno = soh_ordno
				where sod_itmno = @itmno and sod_pckunt = @pckunt and sod_inrctn = @pckinr and sod_mtrctn = @pckmtr
				and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
				and soh_cus1no not in (select tmp_CUSNO from #TMP_EXCUST)
				group by sod_itmno, sod_pckunt, sod_inrctn, sod_mtrctn, sod_credat
	
				select @pckcft = sod_cft from SCORDDTL (nolock)
				left join SCORDHDR (nolock) on sod_ordno = soh_ordno
				where sod_itmno = @itmno and sod_pckunt = @pckunt and sod_inrctn = @pckinr and sod_mtrctn = @pckmtr
				and (@optSCIssDate = 'N' or (soh_issdat between @scissdatFm and @scissdatTo))
				and soh_cus1no not in (select tmp_CUSNO from #TMP_EXCUST)
				and sod_credat = @max_sod_credat
			end
	
			set @pckString = @pckString + isnull(@pckunt, '') + ' / ' + convert(varchar(20), isnull(@pckinr, 0)) + ' / ' + convert(varchar(20), isnull(@pckmtr, 0)) + ' / ' + convert(varchar(20), isnull(round(@pckcft,2), 0)) + char(13)
	
			fetch next from cur_pck into @pckunt, @pckinr, @pckmtr
		end
		close cur_pck
		deallocate cur_pck
	end

	if @ordqty > 0
	begin
		set @counter1 = @counter1 + 1
	end

	update #RESULT set res_reccnt = @counter0, res_qutcus = @cusString, res_pckstr = @pckString, res_ordqty = @ordqty, res_salamtusd = @salamtusd , res_baseunt = @baseunt where res_itmno = @itmno
	update #RESULT set res_ttlcnt_vdr = @counter0, res_qutcnt_vdr = @counter1 where res_venno = @vendor

	fetch next from cur_itmno into @vendor, @itmno
end
close cur_itmno
deallocate cur_itmno


-- Remove data with ordqty = 0
delete from #RESULT where res_ordqty = 0


-- Reorder of sequence by total qty or amount
declare @counter2 int
set @counter2 = 0 

set @pre_vendor = ''


if @orderBy = 'A'
begin
	declare cur_orderAmt cursor for select res_venno, res_itmno from #RESULT order by res_venno, res_salamtusd desc, res_itmno
	open cur_orderAmt
	fetch next from cur_orderAmt into @vendor, @itmno
	
	while @@fetch_status = 0
	begin
		if @pre_vendor = ''

			set @pre_vendor = @vendor

		
		if @pre_vendor = @vendor
		begin
			set @counter2 = @counter2 + 1
		end
		else
		begin
			set @counter2 = 1
			set @pre_vendor = @vendor
		end
	
		update #RESULT set res_reccnt = @counter2 where res_itmno = @itmno
	
		fetch next from cur_orderAmt into @vendor, @itmno
	end
	close cur_orderAmt
	deallocate cur_orderAmt
end
else
begin
	declare cur_orderQty cursor for select res_venno, res_itmno from #RESULT order by res_venno, res_ordqty desc, res_itmno
	open cur_orderQty
	fetch next from cur_orderQty into @vendor, @itmno
	
	while @@fetch_status = 0
	begin
		if @pre_vendor = ''
			set @pre_vendor = @vendor
		
		if @pre_vendor = @vendor
		begin
			set @counter2 = @counter2 + 1
		end
		else
		begin
			set @counter2 = 1
			set @pre_vendor = @vendor
		end
	
		update #RESULT set res_reccnt = @counter2 where res_itmno = @itmno
	
		fetch next from cur_orderQty into @vendor, @itmno
	end
	close cur_orderQty
	deallocate cur_orderQty
end


if @@LANGUAGE <> 'us_english' 
	set LANGUAGE 'us_english'

select 
isnull(convert(varchar(20), @itmcredatFm, 107),'') 'res_itmcredatFm',
isnull(convert(varchar(20), @itmcredatTo, 107),'') 'res_itmcredatTo',
isnull(convert(varchar(20), @scissdatFm, 107),'') 'res_scissdatFm',
isnull(convert(varchar(20), @scissdatTo, 107),'') 'res_scissdatTo',
isnull(@optSCIssDate, '') 'res_optscissdat',
isnull(@title, '') 'res_title',
isnull(@printAmt, '') 'res_printAmt',
isnull(@orderBy, '') 'res_orderBy',
isnull(@showCust, '') 'res_showCust',

isnull(a.res_reccnt, 0) 'res_reccnt1',
isnull(a.res_venno, '') 'res_venno1',
isnull(a.res_vensna, '') 'res_vensna1',
isnull(a.res_itmno, '') 'res_itmno1',
isnull(a.res_itmdsc, '') 'res_itmdsc1',
--isnull(a.res_pckunt, '') + ' / ' + convert(varchar(20), isnull(a.res_pckinr, 0)) + ' / ' + convert(varchar(20), isnull(a.res_pckmtr, 0)) + ' / ' + convert(varchar(20), isnull(round(a.res_pckcft,2), 0)) 'res_pck1',
isnull(a.res_pckstr, '') 'res_pck1',
isnull(a.res_baseunt, '') 'res_baseunt1',
isnull(a.res_ordqty, 0) 'res_ordqty1',
isnull(a.res_salamtusd, 0) 'res_salamtusd1',
isnull(a.res_imgpth, '') 'res_imgpth1',
isnull(a.res_qutcus, '') 'res_qutcus1',
isnull(a.res_ttlcnt_vdr, 0) 'res_ttlcnt_vdr1',
isnull(a.res_qutcnt_vdr, 0) 'res_qutcnt_vdr1',

isnull(b.res_reccnt, 0) 'res_reccnt2',
isnull(b.res_venno, '') 'res_venno2',
isnull(b.res_vensna, '') 'res_vensna2',
isnull(b.res_itmno, '') 'res_itmno2',
isnull(b.res_itmdsc, '') 'res_itmdsc2',
--isnull(b.res_pckunt, '') + ' / ' + convert(varchar(20), isnull(b.res_pckinr, 0)) + ' / ' + convert(varchar(20), isnull(b.res_pckmtr, 0)) + ' / ' + convert(varchar(20), isnull(round(b.res_pckcft,2), 0)) 'res_pck2',
isnull(b.res_pckstr, '') 'res_pck2',
isnull(b.res_baseunt, '') 'res_baseunt2',
isnull(b.res_ordqty, 0) 'res_ordqty2',
isnull(b.res_salamtusd, 0) 'res_salamtusd2',
isnull(b.res_imgpth, '') 'res_imgpth2',
isnull(b.res_qutcus, '') 'res_qutcus2',
isnull(b.res_ttlcnt_vdr, 0) 'res_ttlcnt_vdr2',
isnull(b.res_qutcnt_vdr, 0) 'res_qutcnt_vdr2',

isnull(c.res_reccnt, 0) 'res_reccnt3',
isnull(c.res_venno, '') 'res_venno3',
isnull(c.res_vensna, '') 'res_vensna3',
isnull(c.res_itmno, '') 'res_itmno3',
isnull(c.res_itmdsc, '') 'res_itmdsc3',
--isnull(c.res_pckunt, '') + ' / ' + convert(varchar(20), isnull(c.res_pckinr, 0)) + ' / ' + convert(varchar(20), isnull(c.res_pckmtr, 0)) + ' / ' + convert(varchar(20), isnull(round(c.res_pckcft,2), 0)) 'res_pck3',
isnull(c.res_pckstr, '') 'res_pck3',
isnull(c.res_baseunt, '') 'res_baseunt3',
isnull(c.res_ordqty, 0) 'res_ordqty3',
isnull(c.res_salamtusd, 0) 'res_salamtusd3',
isnull(c.res_imgpth, '') 'res_imgpth3',
isnull(c.res_qutcus, '') 'res_qutcus3',
isnull(c.res_ttlcnt_vdr, 0) 'res_ttlcnt_vdr3',
isnull(c.res_qutcnt_vdr, 0) 'res_qutcnt_vdr3' , 
@optSal_Pur as 'res_Pur_Sql' , 
@optPrice as 'res_Price' 
--@ttlcnt 'res_ttlcnt', 
--@qutcnt 'res_qutcnt'

from #RESULT a
left join #RESULT b on a.res_venno = b.res_venno and a.res_reccnt = b.res_reccnt - 1
left join #RESULT c on b.res_venno = c.res_venno and b.res_reccnt = c.res_reccnt - 1
where  a.res_reccnt % 3 = 1
order by a.res_venno, a.res_reccnt









GO
GRANT EXECUTE ON [dbo].[sp_list_BSP00003a] TO [ERPUSER] AS [dbo]
GO
