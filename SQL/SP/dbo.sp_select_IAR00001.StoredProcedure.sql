/****** Object:  StoredProcedure [dbo].[sp_select_IAR00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IAR00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IAR00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



--sp_select_IAR00001 'UCPP','01/01/2005','09/21/2006','''''','mis'

/*
=================================================================
Program ID	: sp_select_IAR00001   
Description	: Impact Analysis Report - By Excel (UPD)
Programmer	: 
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2003-03-04	Lewis To	Add Filter to eliminate the records which have NULL primany customer no in
				Quotation Header to avoid bugs on printing Impact Analysis Report w/o 2nd page
2003-08-11	Allan Yuen	Delete company on selection for merge project.
2004-02-11	Lester Wu	ADD PRINT ALL COMPANY
2004-08-24	Lester Wu	Add alias name for selected fields
2004-10-05	Lester Wu	Add "NOLOCK" to table selected
2005-04-18	Allan Yuen	Fix date format problem in develop environment.
2005-04-19	Lester Wu	1. Retrieve company name from database
				2. Sort the resulting data
2011-03-18	Frankie Cheung	Rewrite the SP that not in text enclosed SQL Format (original SP at bottom)
2012-08-13	David Yue	Replaced IMMRKUP with IMPRCINF Table
2012-08-27	David Yue	Transaction end date extends to 11:59PM
2012-12-14	David Yue	Display Cost Price Customer Information on Ivy Li's request
2013-08-19	David Yue	Add Transport Term
=================================================================
*/

CREATE         PROCEDURE [dbo].[sp_select_IAR00001] 

@cocde		varchar(6),
@transdate	datetime,
@transend	datetime,
@itmlst		varchar(4000),
@cus1nolist     varchar(1000)  ,
@cus2nolist     varchar(1000)  ,
@vennolist     varchar(1000),
@usrid		varchar(30)

AS
----------------------------------
  
declare
@i 		int,		@start 		varchar(20),	@end 		nvarchar(20),
@value		varchar(20),	@condition 	varchar(3000),	@itmnoqry	varchar(2000),
@cus1qry 	varchar(2000),	@cus2qry 	varchar(2000),	@dvqry		varchar(2000),
@itmUpddatQry	varchar(140),	@prcCredatQry	varchar(140),	@prcUpddatQry	varchar(140),
@itmstsqry	varchar(100)

declare	-- Light Spec
@ls_itmno	nvarchar(30),	@ls_cus1no	nvarchar(6),	@ls_cus2no	nvarchar(6),
@ls_pckunt	nvarchar(6),	@ls_inrqty	int,		@ls_mtrqty	int,
@ls_conftr	int,		@ls_hkprctrm	nvarchar(10),	@ls_trantrm	nvarchar(10)

declare -- Temp No. / Asst Items
@ta_itmno	nvarchar(30),	@ta_typ		nvarchar(4),	@ta_cus1no	nvarchar(6),
@ta_cus2no	nvarchar(6),	@ta_pckunt	nvarchar(6),	@ta_inrqty	int,
@ta_mtrqty	int,		@ta_conftr	int,		@ta_hkprctrm	nvarchar(10),
@ta_trantrm	nvarchar(10)


set @itmnoqry = ''
set @cus1qry = ''
set @cus2qry = ''
set @dvqry = ''
set @itmUpddatQry = ''
set @prcCredatQry = ''
set @prcUpddatQry = ''
set @itmstsqry = ''
set @condition = ''

--------------------------------
declare @lstEmpty as char(1)
set @lstEmpty = 'N'
if len(rtrim(ltrim(replace(@itmlst,'''','')))) <= 0 
begin
	set @lstEmpty = 'Y'
end 

declare @Cus1Empty as char(1)
set @Cus1Empty = 'N'
if len(rtrim(ltrim(replace(@cus1nolist,'''','')))) <= 0 
begin
	set @Cus1Empty = 'Y'
end 


declare @Cus2Empty as char(1)
set @Cus2Empty = 'N'
if len(rtrim(ltrim(replace(@cus2nolist,'''','')))) <= 0 
begin
	set @Cus2Empty = 'Y'
end 


declare @VenEmpty as char(1)
set @VenEmpty = 'N'
if len(rtrim(ltrim(replace(@vennolist,'''','')))) <= 0 
begin
	set @VenEmpty = 'Y'
end 

declare
@itmlst2	varchar(500),
@dummy		varchar(20),
@TIME		int

set @transend = dateadd(day,1,@transend)
set @transend = dateadd(millisecond, -10, @transend)

--Lester Wu 2005-04-06, retrieve company name from database
declare @compName varchar(100)
select @compName = yco_conam from SYCOMINF(NOLOCK) where yco_cocde = @cocde
if @cocde<>'MS' 
begin
	set @compName = 'UNITED CHINESE GROUP'
end

DECLARE	-- IMITMDAT
@iid_cocde 	nvarchar(6),	@iid_venno 	nvarchar(6),	@iid_venitm 	nvarchar(20),	
@iid_xlsfil 	nvarchar(30),	@iid_chkdat	datetime


--Item part
DECLARE @venitm VARCHAR(20)
DECLARE @datbomlist VARCHAR(100)
DECLARE @ibabomlist VARCHAR(100)

CREATE TABLE #tmpBOM_before
(
	venitm_bef nvarchar(20),
	bomlist_bef nvarchar(200)
)

CREATE TABLE #tmpBOM_after
(
	venitm_aft nvarchar(20),
	bomlist_aft nvarchar(200)
)

begin

DECLARE @listStr VARCHAR(100)

CREATE TABLE #tmpItmLst
(
	itmlst nvarchar(50)
)

declare @ItmStrRemain	nvarchar(500)
declare @ItmStrPart	nvarchar(20)

if @lstEmpty <> 'Y'
begin

	set @itmlst = rtrim(ltrim(replace(@itmlst,'''','')))
	
	if @itmlst <> '' 
	begin 
		set @ItmStrRemain = @itmlst
	
		while charindex(',',@ItmStrRemain)<>0
		begin
			set @ItmStrPart = ltrim(left(@ItmStrRemain, charindex(',', @ItmStrRemain)-1))
			set @ItmStrRemain = right(@ItmStrRemain, len(@ItmStrRemain) - charindex(',', @ItmStrRemain))
			insert into #tmpItmLst values (@ItmStrPart)
		end
	
		if charindex(',',@ItmStrRemain) = 0 
			insert into #tmpItmLst values (ltrim(@ItmStrRemain))
	end
end
else
begin
	insert into #tmpItmLst values ('')
end 

DECLARE cur_IMITMDAT CURSOR FOR
select	iid_cocde,	iid_venno,	iid_venitm ,
	iid_xlsfil,	iid_chkdat
from	IMITMDAT (nolock)
where	iid_stage = 'W' and
	iid_mode = 'UPD'

OPEN cur_IMITMDAT
FETCH NEXT FROM cur_IMITMDAT INTO 
@iid_cocde,	@iid_venno,	@iid_venitm,
@iid_xlsfil,	@iid_chkdat

while @@fetch_status = 0
begin
	set @venitm = null
	set @datbomlist = null
	set @ibabomlist = null

	select	@datbomlist = COALESCE(@datbomlist+',' ,'') + ibd_acsno 
	from	IMBOMDAT (nolock)
	where	ibd_venitm = @iid_venitm and 
		ibd_stage = 'W' and 
		ibd_xlsfil = @iid_xlsfil and
		ibd_chkdat = @iid_chkdat

	if isnull(@datbomlist,'') <> '' 
	begin
		insert into #tmpBOM_after 
		select @iid_venitm, @datbomlist
	end
	-----------------------------------------

	select	@ibabomlist = COALESCE(@ibabomlist+',' ,'') + iba_assitm
	from	IMBOMASS (nolock)
	where	iba_itmno = @iid_venitm and
		iba_typ = 'BOM'

	if isnull(@ibabomlist,'') <> '' 
	begin
		insert into #tmpBOM_before
		select	@iid_venitm,	@ibabomlist
	end

	FETCH NEXT FROM cur_IMITMDAT INTO 
	@iid_cocde,	@iid_venno,	@iid_venitm,
	@iid_xlsfil,	@iid_chkdat
end

CLOSE cur_IMITMDAT
DEALLOCATE cur_IMITMDAT

SET ANSI_WARNINGS OFF 
----item part end

-- Process cus1no Query --
create table #tempCus1no(
tempCus1no  nvarchar(6)
)
if charindex('A',@cus1nolist) <> 0 
begin
insert into #tempCus1no values('A')
end

if charindex('B',@cus1nolist) <> 0 
begin
insert into #tempCus1no values('B')
end
if charindex('I',@cus1nolist) <> 0 
begin
insert into #tempCus1no values('I')
end
 if ltrim(rtrim(@cus1nolist)) <> ''
begin
	set @cus1qry = ''
	set @i = 0
	
	while charindex(',',@cus1nolist) <> 0
	begin
		set @i = charindex(',',@cus1nolist)
		if @i = 0 and charindex(@cus1nolist,@cus1qry) = 0
			set @i = len(@cus1nolist)
		set @value = substring(@cus1nolist, 0, @i)
		set @cus1nolist = substring(@cus1nolist,@i+1,len(@cus1nolist)-@i)
		if ltrim(rtrim(@value)) <> ''
		begin
			if charindex('~',@value) > 0
			begin
				set @i = charindex('~',@value)
				set @start = substring(@value, 0, @i)
				set @end = substring(@value, @i+1,len(@value))
				set @cus1qry = @cus1qry + case len(@cus1qry) when 0 then '' else ' or cbi_cusno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @cus1qry = @cus1qry + case len(@cus1qry) when 0 then '' else ' or cbi_cusno ' end + '= ''' + @value + ''''

			end
		end
	end
	
	if charindex(@cus1nolist, @cus1qry) = 0
	begin
		if charindex('~',@cus1nolist) > 0
		begin
			set @i = charindex('~',@cus1nolist)
			set @start = substring(@cus1nolist, 0, @i)
			set @end = substring(@cus1nolist, @i+1,len(@cus1nolist))
			set @cus1qry = @cus1qry + case len(@cus1qry) when 0 then '' else ' or cbi_cusno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
		end
		else
		begin
			set @cus1qry = @cus1qry + case len(@cus1qry) when 0 then '' else ' or cbi_cusno ' end + '= ''' + @cus1nolist + ''''
		end
	end
	
	set @cus1qry = ' where cbi_cusno ' + @cus1qry

	exec ('insert into #tempCus1no select distinct  cbi_cusno from CUBASINF '+@cus1qry)
end -- if ltrim(rtrim(@cus1nolist)) <> ''

--select * from #tempCus1no
--------------------cus1no part end


--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--

-- Process cus2no Query --

create table #tempCus2no(
tempCus2no  nvarchar(6)
)
if charindex('A',@cus2nolist) <> 0 
begin
insert into #tempCus2no values('A')
end

if charindex('B',@cus2nolist) <> 0 
begin
insert into #tempCus2no values('B')
end
if charindex('I',@cus2nolist) <> 0 
begin
insert into #tempCus2no values('I')
end
if @Cus2Empty='N'
begin

	if ltrim(rtrim(@cus2nolist)) <> ''
	begin
		set @cus2qry = ''
		set @i = 0
	
		while charindex(',',@cus2nolist) <> 0
		begin
			set @i = charindex(',',@cus2nolist)
			if @i = 0 and charindex(@cus2nolist,@cus2qry) = 0
				set @i = len(@cus2nolist)
			set @value = substring(@cus2nolist, 0, @i)
			set @cus2nolist = substring(@cus2nolist,@i+1,len(@cus2nolist)-@i)
			if ltrim(rtrim(@value)) <> ''
			begin
				if charindex('~',@value) > 0
				begin
					set @i = charindex('~',@value)
					set @start = substring(@value, 0, @i)
					set @end = substring(@value, @i+1,len(@value))
					set @cus2qry = @cus2qry + case len(@cus2qry) when 0 then '' else ' or cbi_cusno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
				end
				else
				begin
					set @cus2qry = @cus2qry + case len(@cus2qry) when 0 then '' else ' or cbi_cusno ' end + '= ''' + @value + ''''
				end
			end
		end
	
		if charindex(@cus2nolist, @cus2qry) = 0
		begin
			if charindex('~',@cus2nolist) > 0
			begin
				set @i = charindex('~',@cus2nolist)
				set @start = substring(@cus2nolist, 0, @i)
				set @end = substring(@cus2nolist, @i+1,len(@cus2nolist))
				set @cus2qry = @cus2qry + case len(@cus2qry) when 0 then '' else ' or cbi_cusno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @cus2qry = @cus2qry + case len(@cus2qry) when 0 then '' else ' or cbi_cusno ' end + '= ''' + @cus2nolist + ''''
			end
		end
	
		set @cus2qry = ' where cbi_cusno ' + @cus2qry
	end -- if ltrim(rtrim(@cus2nolist)) <> ''
	--select @cus2qry

	--select ('insert into #tempCus2no select distinct  cbi_cusno from CUBASINF'+@cus2qry)
	exec ('insert into #tempCus2no select distinct  cbi_cusno from CUBASINF'+@cus2qry)
	--select * from #tempCus2no
end
---------------------------
----------------------cus2no part end


--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--
-- Process venno Query --
create table #tempVENno(
tempVen  nvarchar(6)
)
if @VenEmpty='N'
begin

	if ltrim(rtrim(@vennolist)) <> ''
	begin
		set @dvqry = ''
		set @i = 0
	
		while charindex(',',@vennolist) <> 0
		begin
			set @i = charindex(',',@vennolist)
			if @i = 0 and charindex(@vennolist,@dvqry) = 0
				set @i = len(@vennolist)
			set @value = substring(@vennolist, 0, @i)
			set @vennolist = substring(@vennolist,@i+1,len(@vennolist)-@i)
			if ltrim(rtrim(@value)) <> ''
			begin
				if charindex('~',@value) > 0
				begin
					set @i = charindex('~',@value)
					set @start = substring(@value, 0, @i)
					set @end = substring(@value, @i+1,len(@value))
					set @dvqry = @dvqry + case len(@dvqry) when 0 then '' else ' or vbi_venno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
				end
				else
				begin
					set @dvqry = @dvqry + case len(@dvqry) when 0 then '' else ' or vbi_venno ' end + '= ''' + @value + ''''
				end
			end
		end
	
		if charindex(@vennolist, @dvqry) = 0
		begin
			if charindex('~',@vennolist) > 0
			begin
				set @i = charindex('~',@vennolist)
				set @start = substring(@vennolist, 0, @i)
				set @end = substring(@vennolist, @i+1,len(@vennolist))
				set @dvqry = @dvqry + case len(@dvqry) when 0 then '' else ' or vbi_venno ' end + 'between ''' + @start + ''' and ''' + @end + ''''
			end
			else
			begin
				set @dvqry = @dvqry + case len(@dvqry) when 0 then '' else ' or vbi_venno ' end + '= ''' + @vennolist + ''''
			end
		end
	
		set @dvqry = ' where vbi_venno ' + @dvqry
	end -- if ltrim(rtrim(@vennolist)) <> ''
	--select @dvqry

	--select ('insert into #tempVENno select distinct  vbi_venno from VNBASINF'+@dvqry)
	exec ('insert into #tempVENno select distinct  vbi_venno from VNBASINF'+@dvqry)
	--select * from #tempVENno
end
---------------------------
----------------------venno part end
---------------condition creating start--------------
end
---------------condition creating end--------------
select	distinct
	case isnull(quh_qutno,'') when '' then '' else 'Q' end as 'type',
	'UPD' as 'Stage',
	@cocde as 'cocde',
	@compName as 'compName',
	ibi_cocde,
	ibi_itmno,
	isnull(itr_tmpitm,'') as 'itr_tmpitm',
	ibi_engdsc,
	iid_venitm,
	ibi_venno,
	vbi_vensna,
	convert(varchar(10),ibi_upddat,101) as 'ibi_upddat',
	ipi_pckseq,
	ipi_pckunt + ' / ' + ltrim(str(ipi_inrqty))+ ' / ' + ltrim(str(ipi_mtrqty)) + ' / ' + ltrim(str(ipi_cft,8,2)) + ' / ' + imu_hkprctrm + ' / ' + imu_trantrm as 'pck_packing',
	iid_untcde + ' / ' + ltrim(str(iid_inrqty)) + ' / ' + ltrim(str(iid_mtrqty)) + ' / ' + ltrim(str(iid_cft,8,2)) + ' / ' + iid_prctrm + ' / ' + iid_trantrm as 'dat_packing',
	-- David Yue 2012-12-14 Add Pricing Customer Info on Ivy Li's request
	ipi_cus1no as 'imu_cus1no',
	ipi_cus2no as 'imu_cus2no',
	max(rtrim(isnull(imu_curcde,'')) +ltrim(str(imu_ftyprc,13,4))) as 'mup_curftyprc',
	max(rtrim(isnull(iid_curcde,'')) + ltrim(str(iid_ftyprc,13,4))) as 'dat_curftyprc',
	rtrim(imu_bcurcde) + ltrim(str(imu_basprc,13,4)) as 'imu_basprc',
	rtrim(isnull(iid_curr_bef,'')) + ltrim(str(iid_basprc,13,4)) as 'iid_ftyprc',
	case imu_ftyprc when 0 then 0 else (iid_ftyprc - imu_ftyprc) / imu_ftyprc * 100 end as 'newbasicprice',
	case imu_basprc when 0 then 0 else (iid_basprc - imu_basprc) / imu_basprc * 100 end as 'newbasicprice2',
	case ltrim(str(year(ipi_qutdat))) when '1900' then '' else ltrim(str(year(ipi_qutdat))) + '-' + right('0' + ltrim(str(month(ipi_qutdat))),2) end as 'pck_qutdat',
	case ltrim(str(year(iid_period))) when '1900' then '' else ltrim(str(year(iid_period))) + '-' + right('0' + ltrim(str(month(iid_period))),2) end as 'dat_qutdat',
	isnull(bomlist_bef,'') as 'bomlist_bef',
	isnull(bomlist_aft,'') as 'bomlist_aft',
	-- Quotation Detail --
	quh_cus1no as 'quh_cus1no',
	pri.cbi_cussna as 'cbi_cussna_pri',
	quh_cus2no as 'quh_cus2no',
	sec.cbi_cussna as 'cbi_cussna_sec',
	quh_qutno as 'quh_qutno',
	quh_rvsdat as 'quh_rvsdat',
	quh_valdat as 'quh_shpstr', 
	quh_valdat as 'quh_shpend',
	quh_curcde as 'quh_curcde',
	case isnull(quh_qutno,'') when '' then null else qud_cus1sp end as 'qud_basprc',
	case isnull(quh_qutno,'') when '' then null else qud_basprc end as 'selprc',
	--0 as 'ordqty',
	case quh_cus1no when null then null else 0 end as 'ordqty',
	ltrim(yfi_fmlopt) +  ' - ' + ltrim(yfi_fml) as 'yfi_prcfml',
	case isnull(quh_qutno,'') when '' then null else qud_fcurcde end as 'sod_fcurcde', 
	case isnull(quh_qutno,'') when '' then null else qud_ftyprc end as 'sod_ftyprc',
	--0 as 'sod_shpqty',
	case quh_cus1no when null then null else 0 end as 'sod_shpqty',
	'' as 'pod_jobord'
from	IMITMDAT (nolock)
	join IMITMDATCST (nolock) on
		iic_venitm = iid_venitm and
		iic_venno = iid_venno and
		iic_prdven = iid_prdven and
		iic_itmseq = iid_itmseq and
		iic_recseq = iid_recseq and
		iic_xlsfil = iid_xlsfil and
		iic_chkdat = iid_chkdat
	join IMBASINF (nolock) on
		ibi_itmno = iid_venitm
	join IMPCKINF (nolock) on
		ipi_itmno = iid_venitm and
		ipi_pckunt = iid_untcde and
		ipi_inrqty = iid_inrqty and
		ipi_mtrqty = iid_mtrqty and 
		ipi_cus1no = iic_cus1no and 
		ipi_cus2no = iic_cus2no
	join IMPRCINF (nolock) on
		imu_itmno = iic_venitm and
		imu_pckunt = iic_untcde and
		imu_inrqty = iic_inrqty and
		imu_mtrqty = iic_mtrqty and
		imu_cus1no = iic_cus1no and
		imu_cus2no = iic_cus2no and
		imu_ftyprctrm = iid_ftyprctrm and
		imu_hkprctrm = iid_prctrm and
		imu_trantrm = iid_trantrm
	join VNBASINF (nolock) on
		vbi_venno = ibi_venno
	left join QUOTNDTL (nolock) on
		(qud_itmno = iid_itmno or qud_itmno = iid_venitm) and
		qud_untcde = iid_untcde and
		qud_inrqty = iid_inrqty and
		qud_mtrqty = iid_mtrqty and
		qud_ftyprctrm = iid_ftyprctrm and
		qud_prctrm = iid_prctrm and
		qud_trantrm = iid_trantrm and
		qud_cus1no = iic_cus1no and
		qud_cus2no = iic_cus2no
	left join QUOTNHDR (nolock) on
		quh_qutno = qud_qutno and
		quh_valdat > @transdate
	left join CUBASINF pri (nolock) on
		pri.cbi_cusno = quh_cus1no
	left join CUBASINF sec (nolock) on
		sec.cbi_cusno = quh_cus2no
	left join #tmpBOM_before on
		iid_itmno = venitm_bef
	left join #tmpBOM_after on 
		iid_itmno = venitm_aft
	left join SYFMLINF (nolock) on
		imu_fmlopt = yfi_fmlopt
	left join IMTMPREL (nolock) on itr_itmno=iid_venitm
where	(@lstEmpty = 'Y' or ibi_itmno in (select itmlst from #tmpItmLst (nolock)) or isnull(ibi_alsitmno,'') in (select itmlst from #tmpItmLst)) and
	--isnull(quh_cus1no,'') <> '' and
	iid_mode = 'UPD' and
	iid_stage = 'W' and
	iid_upddat between @transdate and @transend

	and
	(@Cus1Empty = 'Y' or ipi_cus1no in (select tempCus1no from #tempCus1no))and
	(@Cus2Empty = 'Y' or ipi_cus2no in (select tempCus2no from #tempCus2no) )and 
	(@VenEmpty='Y' or ibi_venno in (select tempVen from #tempVENno) )

group by
	ibi_itmno,
	ibi_engdsc, 
	iid_venitm,
	ibi_venno,
	vbi_vensna,
	ibi_upddat,
	ipi_pckseq,
	ipi_pckunt + ' / ' + ltrim(str(ipi_inrqty)) + ' / ' + ltrim(str(ipi_mtrqty)) + ' / ' + ltrim(str(ipi_cft,8,2)) + ' / ' + imu_hkprctrm + ' / ' + imu_trantrm,
	iid_untcde + ' / ' + ltrim(str(iid_inrqty)) + ' / ' + ltrim(str(iid_mtrqty)) + ' / ' + ltrim(str(iid_cft,8,2)) + ' / ' + iid_prctrm + ' / ' + iid_trantrm,
	ipi_cus1no,
	ipi_cus2no,
	rtrim(imu_bcurcde) + ltrim(str(imu_basprc,13,4)),
	rtrim(isnull(iid_curr_bef,'')) + ltrim(str(iid_basprc,13,4)), 
	case imu_ftyprc when 0 then 0 else (iid_ftyprc - imu_ftyprc) / imu_ftyprc * 100 end,
	case imu_basprc when 0 then 0 else (iid_basprc - imu_basprc) / imu_basprc * 100 end,
	-- Frankie Cheung 20110318 Add Before/After IM Period
	case ltrim(str(year(ipi_qutdat))) when '1900' then '' else ltrim(str(year(ipi_qutdat))) + '-' + right('0' + ltrim(str(month(ipi_qutdat))),2) end,
	case ltrim(str(year(iid_period))) when '1900' then '' else ltrim(str(year(iid_period))) + '-' + right('0' + ltrim(str(month(iid_period))),2) end,
	-- Frankie Cheung 20110318 Add Before/After BOM Info
	isnull(bomlist_bef,''),
	isnull(bomlist_aft,''),
	-----------------------------------------------------
	quh_cus1no,	
	pri.cbi_cussna,
	quh_cus2no, 
	sec.cbi_cussna,
	quh_qutno,
	quh_rvsdat,
	quh_valdat, 
	quh_valdat,
	quh_curcde, 
	qud_cus1sp,
	qud_basprc,
	ltrim(yfi_fmlopt) +  ' - ' + ltrim(yfi_fml),
	qud_fcurcde, 
	qud_ftyprc,
	ibi_cocde
	,isnull(itr_tmpitm,'')
having	ipi_pckunt + ' / ' + ltrim(str(ipi_inrqty)) + ' / ' + ltrim(str(ipi_mtrqty)) + ' / ' + ltrim(str(ipi_cft,8,2)) + ' / ' + imu_hkprctrm + ' / ' + imu_trantrm <>
	iid_untcde + ' / ' + ltrim(str(iid_inrqty)) + ' / ' + ltrim(str(iid_mtrqty)) + ' / ' + ltrim(str(iid_cft,8,2)) + ' / ' + iid_prctrm + ' / ' + iid_trantrm
	or
	max(rtrim(ISNULL(imu_curcde,'')) + str(imu_ftyprc)) <> max(rtrim(ISNULL(iid_curcde,'')) + str(iid_ftyprc))
	or
	rtrim(imu_bcurcde) + ltrim(str(imu_basprc,13,4)) <> rtrim(isnull(iid_curr_bef,'')) + ltrim(str(iid_basprc,13,4)) 
UNION
select	 distinct
	case isnull(soh_ordno,'') when '' then '' else 'S' end as 'type',
	'UPD' as 'Stage',
	@cocde as 'cocde',
	@compName as 'compName',
	ibi_cocde,
	ibi_itmno,
	isnull(itr_tmpitm,'') as 'itr_tmpitm',
	ibi_engdsc,
	iid_venitm,
	ibi_venno,
	vbi_vensna,
	convert(varchar(10),ibi_upddat,101) as 'ibi_upddat',
	ipi_pckseq,
	ipi_pckunt + ' / ' + ltrim(str(ipi_inrqty))+ ' / ' + ltrim(str(ipi_mtrqty)) + ' / ' + ltrim(str(ipi_cft,8,2)) + ' / ' + imu_hkprctrm + ' / ' + imu_trantrm as 'pck_packing',
	iid_untcde + ' / ' + ltrim(str(iid_inrqty)) + ' / ' + ltrim(str(iid_mtrqty)) + ' / ' + ltrim(str(iid_cft,8,2)) + ' / ' + iid_prctrm + ' / ' + iid_trantrm as 'dat_packing',
	-- David Yue 2012-12-14 Add Pricing Customer Info on Ivy Li's request
	ipi_cus1no as 'imu_cus1no',
	ipi_cus2no as 'imu_cus2no',
	max(rtrim(isnull(imu_curcde,'')) +ltrim(str(imu_ftyprc,13,4))) as 'mup_curftyprc',
	max(rtrim(isnull(iid_curcde,'')) + ltrim(str(iid_ftyprc,13,4))) as 'dat_curftyprc',
	rtrim(imu_bcurcde) + ltrim(str(imu_basprc,13,4)) as 'imu_basprc',
	rtrim(isnull(iid_curr_bef,'')) + ltrim(str(iid_basprc,13,4)) as 'iid_ftyprc',
	case imu_ftyprc when 0 then 0 else (iid_ftyprc - imu_ftyprc) / imu_ftyprc * 100 end as 'newbasicprice',
	case imu_basprc when 0 then 0 else (iid_basprc - imu_basprc) / imu_basprc * 100 end as 'newbasicprice2',
	case ltrim(str(year(ipi_qutdat))) when '1900' then '' else ltrim(str(year(ipi_qutdat))) + '-' + right('0' + ltrim(str(month(ipi_qutdat))),2) end as 'pck_qutdat',
	case ltrim(str(year(iid_period))) when '1900' then '' else ltrim(str(year(iid_period))) + '-' + right('0' + ltrim(str(month(iid_period))),2) end as 'dat_qutdat',
	isnull(bomlist_bef,'') as 'bomlist_bef',
	isnull(bomlist_aft,'') as 'bomlist_aft',
	-- Sales Confirmation Detail --
	soh_cus1no as 'quh_cus1no',
	pri.cbi_cussna as 'cbi_cussna_pri',
	soh_cus2no as 'quh_cus2no',
	sec.cbi_cussna as 'cbi_cussna_sec',
	soh_ordno as 'quh_qutno',
	soh_issdat as 'quh_rvsdat',
	sod_shpstr as 'quh_shpstr', 
	sod_shpend as 'quh_shpend',
	soh_curcde as 'quh_curcde',
	sod_untprc as 'qud_basprc',
	sod_itmprc as 'selprc',
	sum(sod_ordqty) as 'ordqty',
	ltrim(yfi_fmlopt) +  ' - ' + ltrim(yfi_fml) as 'yfi_prcfml',
	sod_fcurcde as 'sod_fcurcde', 
	sod_ftyprc as 'sod_ftyprc',
	sum(sod_shpqty) as 'sod_shpqty',
	isnull(pod_jobord,'') as 'pod_jobord'
from	IMITMDAT (nolock)
	join IMITMDATCST (nolock) on
		iic_venitm = iid_venitm and
		iic_venno = iid_venno and
		iic_prdven = iid_prdven and
		iic_itmseq = iid_itmseq and
		iic_recseq = iid_recseq and
		iic_xlsfil = iid_xlsfil and
		iic_chkdat = iid_chkdat
	join IMBASINF (nolock) on
		ibi_itmno = iid_venitm
	join IMPCKINF (nolock) on
		ipi_itmno = iid_venitm and
		ipi_pckunt = iid_untcde and
		ipi_inrqty = iid_inrqty and
		ipi_mtrqty = iid_mtrqty and 
		ipi_cus1no = iic_cus1no and 
		ipi_cus2no = iic_cus2no
	join IMPRCINF (nolock) on
		imu_itmno = iic_venitm and
		imu_pckunt = iic_untcde and
		imu_inrqty = iic_inrqty and
		imu_mtrqty = iic_mtrqty and
		imu_cus1no = iic_cus1no and
		imu_cus2no = iic_cus2no and
		imu_ftyprctrm = iid_ftyprctrm and
		imu_hkprctrm = iid_prctrm and
		imu_trantrm = iid_trantrm
	left join VNBASINF (nolock) on
		vbi_venno = ibi_venno
	left join vw_select_iar00001 on
		sod_itmno = iid_itmno and
		sod_pckunt = iid_untcde and
		sod_inrctn = iid_inrqty and
		sod_mtrctn = iid_mtrqty and
		sod_cus1no = iic_cus1no and
		sod_cus2no = iic_cus2no and
		sod_ftyprctrm = iid_ftyprctrm and
		sod_hkprctrm = iid_prctrm and
		sod_trantrm = iid_trantrm and
		soh_ordsts <> 'CLO'
	left join POORDDTL (nolock) on
		pod_purord = sod_purord and
		pod_purseq = sod_purseq
	left join CUBASINF pri (nolock) on
		pri.cbi_cusno = soh_cus1no
	left join CUBASINF sec (nolock) on
		sec.cbi_cusno = soh_cus2no
	left join #tmpBOM_before on
		iid_itmno = venitm_bef
	left join #tmpBOM_after on 
		iid_itmno = venitm_aft
	left join SYFMLINF (nolock) on
		imu_fmlopt = yfi_fmlopt
	left join IMTMPREL (nolock) on itr_itmno=iid_venitm
where	(@lstEmpty = 'Y' or ibi_itmno in (select itmlst from #tmpItmLst (nolock)) or isnull(ibi_alsitmno,'') in (select itmlst from #tmpItmLst)) and
	--isnull(quh_cus1no,'') <> '' and
	iid_mode = 'UPD' and
	iid_stage = 'W' and
	iid_upddat between @transdate and @transend
	and
	(@Cus1Empty = 'Y'or ipi_cus1no in (select tempCus1no from #tempCus1no))and
	(@Cus2Empty = 'Y' or ipi_cus2no in (select tempCus2no from #tempCus2no))and 
	(@VenEmpty='Y' or ibi_venno in (select tempVen from #tempVENno) )
group by
	ibi_itmno,
	ibi_engdsc, 
	iid_venitm,
	ibi_venno,
	vbi_vensna,
	ibi_upddat,
	ipi_pckseq,
	ipi_pckunt + ' / ' + ltrim(str(ipi_inrqty))+ ' / ' + ltrim(str(ipi_mtrqty)) + ' / ' + ltrim(str(ipi_cft,8,2)) + ' / ' + imu_hkprctrm + ' / ' + imu_trantrm,
	iid_untcde + ' / ' + ltrim(str(iid_inrqty)) + ' / ' + ltrim(str(iid_mtrqty)) + ' / ' + ltrim(str(iid_cft,8,2)) + ' / ' + iid_prctrm + ' / ' + iid_trantrm,
	ipi_cus1no,
	ipi_cus2no,
	rtrim(imu_bcurcde) + ltrim(str(imu_basprc,13,4)),
	rtrim(isnull(iid_curr_bef,'')) + ltrim(str(iid_basprc,13,4)) , 
	case imu_ftyprc when 0 then 0 else (iid_ftyprc - imu_ftyprc) / imu_ftyprc * 100 end,
	case imu_basprc when 0 then 0 else (iid_basprc - imu_basprc) / imu_basprc * 100 end,
	-- Frankie Cheung 20110318 Add Before/After IM Period
	case ltrim(str(year(ipi_qutdat))) when '1900' then '' else ltrim(str(year(ipi_qutdat))) + '-' + right('0' + ltrim(str(month(ipi_qutdat))),2) end,
	case ltrim(str(year(iid_period))) when '1900' then '' else ltrim(str(year(iid_period))) + '-' + right('0' + ltrim(str(month(iid_period))),2) end,
	-- Frankie Cheung 20110318 Add Before/After BOM Info
	isnull(bomlist_bef,''),
	isnull(bomlist_aft,''),
	soh_cus1no,
	pri.cbi_cussna,
	soh_cus2no,
	sec.cbi_cussna,
	soh_ordno,
	soh_issdat,
	sod_shpstr,
	sod_shpend,
	soh_curcde,
	sod_untprc,
	sod_itmprc,
	sod_ordqty,
	ltrim(yfi_fmlopt) + ' - ' + ltrim(yfi_fml),
	sod_fcurcde,
	sod_ftyprc,
	pod_jobord,
	ibi_cocde
	,	isnull(itr_tmpitm,'')
having	ipi_pckunt + ' / ' + ltrim(str(ipi_inrqty)) + ' / ' + ltrim(str(ipi_mtrqty)) + ' / ' + ltrim(str(ipi_cft,8,2)) + ' / ' + imu_hkprctrm + ' / ' + imu_trantrm <>
	iid_untcde + ' / ' + ltrim(str(iid_inrqty)) + ' / ' + ltrim(str(iid_mtrqty)) + ' / ' + ltrim(str(iid_cft,8,2)) + ' / ' + iid_prctrm + ' / ' + iid_trantrm
	or
	max(rtrim(ISNULL(imu_curcde,'')) + ltrim(str(imu_ftyprc,13,4))) <> max(rtrim(ISNULL(iid_curcde,'')) + ltrim(str(iid_ftyprc,13,4)))
	or
	rtrim(imu_bcurcde) + ltrim(str(imu_basprc,13,4)) <> rtrim(isnull(iid_curr_bef,'')) + ltrim(str(iid_basprc,13,4))
order by
	iid_venitm, dat_packing, ibi_engdsc

--	select 1 where @lstEmpty='Y'
--	select 2 where @Cus1Empty='Y'
--select 3 where @Cus2Empty='Y'
--	select 4 where @VenEmpty='Y'
--select charindex('B',@cus1nolist) 
--	select * from  #tmpItmLst
--select * from  #tempCus1no
--select * from  #tempCus2no
--select * from   #tempVENno


drop table #tmpItmLst
drop table #tempCus1no
drop table #tempCus2no
drop table  #tempVENno

drop table #tmpBOM_before
drop table #tmpBOM_after
SET ANSI_WARNINGS ON


















GO
GRANT EXECUTE ON [dbo].[sp_select_IAR00001] TO [ERPUSER] AS [dbo]
GO
