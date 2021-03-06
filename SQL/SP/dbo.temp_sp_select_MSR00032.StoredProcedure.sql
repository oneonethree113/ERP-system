/****** Object:  StoredProcedure [dbo].[temp_sp_select_MSR00032]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[temp_sp_select_MSR00032]
GO
/****** Object:  StoredProcedure [dbo].[temp_sp_select_MSR00032]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE       PROCEDURE [dbo].[temp_sp_select_MSR00032] 

@cocde		nvarchar(6),
@FromItmno 	nvarchar(20),
@ToItmno	nvarchar(20),
@FromVenno	nvarchar(6),
@ToVenno	nvarchar(6),
@FromSubcde	nvarchar(6),
@ToSubcde	nvarchar(6),
@FromCusno	nvarchar(6),
@ToCusno	nvarchar(6),
@saltem	nvarchar(1),	
@usrid		nvarchar(30)


AS
Declare
@Venno		nvarchar(1),
@Subcde	nvarchar(1),
@Cusno		nvarchar(1)

IF @FromVenno <> '' 
Begin
	SET @Venno = 'Y'
End
Else
Begin
	SET @Venno = 'N'
End

IF @FromSubcde <> '' 
Begin
	SET @Subcde = 'Y'
End
Else
Begin
	SET @Subcde = 'N'
End

IF @FromCusno <> ''
Begin
	SET @Cusno = 'Y'
End
Else
Begin
	SET @Cusno = 'N'
End


--Lester Wu 2005-04-02, retrieve company name from database----------------------------------------
declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde<>'UC-G'
begin
	select @compName = yco_conam from sycominf where yco_cocde = @cocde
end
---------------------------------------------------------------------------------------------------------------------

/*
SET @cocde = 'UCPP'
SET @FromItmno = '6100000'
SET @ToItmno = '6100090'
SET @FromVenno = 'A'
SET @ToVenno = 'Z'
SET @FromSubcde = ''
SET @ToSubcde = ''
SET @FromCusno = '10001'
SET @ToCusno = '20699'
*/

--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
-- Lester Wu 2006-09-19

--Frankie Cheung 20090525
Create Table #_CusList
(
	_tmcusno nvarchar(6),
)


--Frankie Cheung 20090525
create table #_ItemList
(
	input_cocde nvarchar(6),
	input_FromItmno nvarchar(20),
	input_ToItmno	 nvarchar(20),
	input_FromVenno nvarchar(6),
	input_ToVenno nvarchar(6),
	input_FromSubcde nvarchar(6),
	input_ToSubcde nvarchar(6),
	input_FromCusno nvarchar(6),
	input_ToCusno nvarchar(6),
	Itmno nvarchar(20),
	Colpck nvarchar(100),
	Type nvarchar(4),
	DOCType nvarchar(2),
	Cus1no nvarchar(6),
	Cussna_sort nvarchar(50),
	DocNo nvarchar(20),
	Cussna nvarchar(30),
	issdat datetime,
	rvsdat datetime,
	smpUM nvarchar(6),
	venno nvarchar(30),
	subcde nvarchar(10),
	OrderQty int,
	ShpQty int,
	OSQty int,
	ShpStr datetime,
	ShpEnd datetime,
	compName varchar(100)	
)


create table #_ItemNo(
	_ItmNo varchar(30)
)

insert into #_ItemNo
select bas.ibi_itmno from IMBASINF bas
where bas.ibi_itmno between @FromItmno and @ToItmno
union 
select bas.ibi_alsitmno from IMBASINF bas
left join IMBASINF als on bas.ibi_alsitmno = als.ibi_itmno and als.ibi_itmsts = 'OLD'
where bas.ibi_itmno between @FromItmno and @ToItmno and 
len(isnull(bas.ibi_alsitmno,'')) > 0 and
als.ibi_itmno is not null
union
select bas.ibi_itmno from IMBASINF bas
left join IMBASINF als on bas.ibi_alsitmno = als.ibi_itmno and als.ibi_itmsts = 'OLD'
where bas.ibi_alsitmno between  @FromItmno and @ToItmno and 
len(isnull(bas.ibi_alsitmno,'')) > 0 and
als.ibi_itmno is not null
union
select bas.ibi_itmno from IMBASINFH bas
where bas.ibi_itmno between @FromItmno and @ToItmno

--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
/*
--Frankie Cheung 20090525
Insert into #_CusList
select 	distinct cbi_cusno		
from 	CUBASINF, SYSALREP
where	ysr_code = cbi_salrep and
	cbi_custyp = 'P' and
	(	ysr_saltem between 
		(	case @saltem when 'S'  then '' else @saltem end)
		and
		(	case @saltem when 'S' then 'ZZZZZZ' else @saltem end)	
		or 
		ysr_saltem between	
		(	case @saltem when ''  then '' else @saltem end)
		and
		(	case @saltem when '' then 'ZZZZZZ' else @saltem end)	
	)
order by cbi_cusno
*/
Insert into #_CusList
select 	distinct cbi_cusno		
from 	CUBASINF
where	cbi_custyp = 'P' and
	(	cbi_saltem between 
		(	case @saltem when 'S'  then '' else @saltem end)
		and
		(	case @saltem when 'S' then 'ZZZZZZ' else @saltem end)	
		or 
		cbi_saltem between	
		(	case @saltem when ''  then '' else @saltem end)
		and
		(	case @saltem when '' then 'ZZZZZZ' else @saltem end)	
	)
order by cbi_cusno

--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


--Frankie Cheung 20090525
Insert into #_ItemList
----------------------------
Select 	@cocde	as 'input_cocde'	, 	--1
	@FromItmno as 'input_FromItm'	,
	@ToItmno as 'input_ToItm'	,
	@FromVenno as 'input_FromVen'	,
	@ToVenno as 'input_ToVen'	,
	@FromSubcde as 'input_FromSubcde'	,
	@ToSubcde as 'input_ToSubcde'	,
	@FromCusno as 'input_FromCust'	,
	@ToCusno as 'input_ToCust'	,
	ltrim(rtrim(qud_itmno)) as 'Itmno',
	-- Johnson Oct 17 2002
	qud_colcde + '/' +
	qud_untcde + '/' + cast(qud_inrqty as nvarchar(10)) + '/' + cast(qud_mtrqty as nvarchar(10)) as 'Colpck' ,
	'1-QU' as 'Type',	
	'QU' as 'DocType',	
	quh_cus1no as 'Cusno',
	-- 2004/02/17 Lester Wu
	cbi_cussna,
	-----------------------------
	qud_qutno as 'Doc_no',
	quh_cus1no + ' - ' + cbi_cussna as 'PriCust',	
	quh_issdat as 'IssDate',	
	quh_rvsdat as 'ResDate',	
	'1' as 'SmpUM',		
	qud_venno + ' - ' + vbi_vensna as 'Vensna' ,	
	qud_subcde,	
	0 as 'Ordqty',	
	0 as 'Shpqty',	
	0 as 'OSqty',
	'01-01-1900' as 'ShpStr',	
	'01-01-1900' as 'ShpEnd'
	,@compName as 'compName'
from 
#_ItemNo (nolock)
left join QUOTNDTL (nolock) on _itmno = qud_itmno
left join QUOTNHDR (nolock) on quh_cocde = qud_cocde and quh_qutno = qud_qutno
left join VNBASINF (nolock) on  qud_venno = vbi_venno
left join CUBASINF (nolock) on quh_cus1no = cbi_cusno
/*
QUOTNHDR(NOLOCK)
--Left join CUBASINF on cbi_cocde = @cocde and cbi_cusno = quh_cus1no
Left join CUBASINF(NOLOCK) on cbi_cusno = quh_cus1no
,QUOTNDTL
--Left join VNBASINF on vbi_cocde = @cocde and vbi_venno = qud_venno
Left join VNBASINF(NOLOCK) on vbi_venno = qud_venno
*/

Where	
	/*quh_cocde = qud_cocde and
	quh_qutno = qud_qutno and*/
	-- XXXXXXXXXXXXX
	-- 2004/02/11 Lester Wu
	-- quh_cocde = @cocde and
	--Lester Wu 2005-04-04, replace ALL with UC-G and exclude MS company data from UC-G
--	(@cocde = 'ALL' or quh_cocde = @cocde) and 
	((@cocde = 'UC-G' and quh_cocde<>'MS') or quh_cocde = @cocde) and
	-- XXXXXXXXXXXXXX
	--qud_itmno between @FromItmno and @ToItmno and 
	--qud_itmno  in ( select _ItmNo from #_ItemNo (nolock) ) and	-- Lester Wu 2006-09-19
	qud_itmno is not null and
	
	((quh_cus1no between @FromCusno and @ToCusno and @Cusno ='Y') or @cusno = 'N') and
	((qud_venno between @FromVenno and @ToVenno and @Venno = 'Y') or @Venno = 'N') and

	((qud_subcde between @FromSubcde and @ToSubcde and @Subcde = 'Y') or @Subcde ='N') 
Group by 
	ltrim(rtrim(qud_itmno)) ,
	qud_colcde + '/' +
	qud_untcde + '/' + cast(qud_inrqty as nvarchar(10)) + '/' + cast(qud_mtrqty as nvarchar(10)) ,
	quh_cus1no ,	qud_qutno ,
	-- 2004/02/17 Lester Wu
	cbi_cussna,
	------------------------------
	quh_cus1no + ' - ' + cbi_cussna,	
	quh_issdat ,	
	quh_rvsdat,
	qud_venno + ' - ' + vbi_vensna ,	qud_subcde

Union

(
Select 	@cocde		as 'input_cocde'	, 	--1
	@FromItmno 	as 'input_FromItmno'	, 	
	@ToItmno	as 'input_ToItmno'	, 
	@FromVenno	as 'input_FromVenno'	, 
	@ToVenno	as 'input_ToVenno'	, 
	@FromSubcde	as 'input_FromSubcde'	, 
	@ToSubcde	as 'input_ToSubcde'	, 
	@FromCusno	as 'input_FromCusno'	, 
	@ToCusno	as 'input_ToCusno'	, 
	ltrim(rtrim(sod_itmno)),
	sod_colcde + '/' +
	sod_pckunt  + '/' + cast(sod_inrctn as nvarchar(10)) + '/' + cast(sod_mtrctn as nvarchar(10)) ,
	'2-SC' as 'Type',	'SC',	soh_cus1no,
	-- 2004/02/17 Lester Wu
	cbi_cussna,
	---------------------------------------------------------------------------------------------------
	--Lester Wu 2004/11/25
	--soh_ordno,
	case isnull(pod_jobord,'') when '' then soh_ordno else pod_jobord end,
	----------------------------------------------------------------------------------------------------

	soh_cus1no + ' - ' + cbi_cussna as 'PriCust',
	soh_issdat,	soh_rvsdat,	'1',	
	sod_venno + ' - ' + vbi_vensna,	
	sod_subcde,	sum(sod_ordqty),	sum(sod_shpqty),	sum(sod_ordqty) - sum(sod_shpqty),
	sod_shpstr,	sod_shpend
	,@compName as 'compName'
from 

#_ItemNo (nolock)
left join SCORDDTL(NOLOCK) on _itmno = sod_itmno
left join SCORDHDR(NOLOCK) on soh_cocde = sod_cocde and soh_ordno = sod_ordno 
Left join CUBASINF(NOLOCK) on  soh_cus1no = cbi_cusno
Left join VNBASINF(NOLOCK) on sod_venno = vbi_venno 
left join POORDDTL(NOLOCK) on sod_cocde = pod_cocde AND sod_purord = pod_purord AND sod_purseq = pod_purseq

/*
SCORDHDR(NOLOCK)
--Left join CUBASINF on cbi_cocde = @cocde and cbi_cusno = soh_cus1no
Left join CUBASINF(NOLOCK) on cbi_cusno = soh_cus1no
,SCORDDTL(NOLOCK)
--Left join VNBASINF on vbi_cocde = @cocde and vbi_venno = sod_venno
Left join VNBASINF(NOLOCK) on vbi_venno = sod_venno
--Lester Wu 2004/11/25Show Job No in POORDHDR instead of SC order no
left join POORDDTL(NOLOCK) on sod_cocde = pod_cocde AND	sod_purord = pod_purord AND sod_purseq = pod_purseq
--pod_cocde *= sod_cocde and dtl.pod_scno *= sod_ordno and dtl.pod_scline *= sod_ordseq
*/

Where	--soh_cocde = sod_cocde and
	--soh_ordno = sod_ordno and

	-- XXXXXXXXXXXXXXXX
	-- 2004/02/11 Lester Wu
	--soh_cocde = @cocde and
	--Lester Wu 2005-04-04, replace ALL with UC-G and exclude MS company data from UC-G
--	(@cocde = 'ALL'  or  soh_cocde = @cocde) and 
	((@cocde = 'UC-G' and soh_cocde<>'MS')  or  soh_cocde = @cocde) and 
	-- XXXXXXXXXXXXXXXX

	--sod_itmno between @FromItmno and @ToItmno and	--2006-09-19
	--sod_itmno  in ( select _ItmNo from #_ItemNo (nolock) ) and
	sod_itmno is not  null and
	((soh_cus1no between @FromCusno and @ToCusno and @Cusno = 'Y') or @Cusno = 'N') and
	((sod_venno between @FromVenno and @ToVenno and @Venno = 'Y') or @Venno = 'N') and
	((sod_subcde between @FromSubcde and @ToSubcde and @Subcde = 'Y') or @Subcde = 'N')

group by 
	ltrim(rtrim(sod_itmno)),
	sod_colcde + '/' +
	sod_pckunt  + '/' + cast(sod_inrctn as nvarchar(10)) + '/' + cast(sod_mtrctn as nvarchar(10)) ,
	soh_cus1no,
	-- 2004/02/17 Lester Wu
	cbi_cussna,
	-----------------------------
	--------------------------------------------------------------------------------------
	--Lester Wu 2004/11/25
	--soh_ordno,
	case isnull(pod_jobord,'') when '' then soh_ordno else pod_jobord end,
	--------------------------------------------------------------------------------------
	soh_cus1no + ' - ' + cbi_cussna ,
	soh_issdat,	soh_rvsdat,	
	sod_venno + ' - ' + vbi_vensna,	
	sod_subcde,	
	sod_shpstr,	sod_shpend
)
UNION
(
Select 	@cocde		as 'input_cocde'	, 	--1
	@FromItmno 	as 'input_FromItmno'	, --2
	@ToItmno		as 'input_ToItmno'	,	--3
	@FromVenno		as 'input_FromVenno'	,	--4
	@ToVenno		as 'input_ToVenno'	,	--5
	@FromSubcde		as 'input_FromSubcde'	,	--6
	@ToSubcde		as 'input_ToSubcde'	,	--7
	@FromCusno		as 'input_FromCusno'	,	--8
	@ToCusno		as 'input_ToCusno'	,	--9	
	ltrim(rtrim(sad_itmno)),		--10
	sad_colcde + '/' +
	sad_untcde + '/' + cast(sad_inrqty as nvarchar(10)) + '/' + cast(sad_mtrqty as nvarchar(10)) ,	-- 11
	'3-SR' as 'Type',
	'SR',	
	sad_cus1no,	-- 14
	-- 2004/02/17 Lester Wu
	cbi_cussna,
	-----------------------------
	sad_reqno,		-- 15
	sad_cus1no + ' - ' + cbi_cussna as 'PriCust',
	srh_issdat,	
	srh_rvsdat,	
	sad_smpuntcde,	-- 19
	sad_venno + ' - ' + vbi_vensna,	
	sad_subcde,	Sum(sad_smpqty),	Sum(sad_shpqty),	Sum(sad_smpqty) -Sum( sad_shpqty),
	'01-01-1900',	'01-01-1900'
	,@compName as 'compName'
	
from 
#_ItemNo (nolock)
left join SAORDDTL(NOLOCK) on _itmno = sad_itmno
left join SAREQHDR(NOLOCK)  on srh_cocde = sad_cocde and srh_reqno = sad_reqno  
Left join CUBASINF(NOLOCK)  on cbi_cusno = sad_cus1no
Left join VNBASINF(NOLOCK)  on vbi_venno = sad_venno

/*
SAORDDTL(NOLOCK) 
left join SAREQHDR(NOLOCK)  on 
-- 2004/02/11 Lester Wu
--srh_cocde = @cocde 
srh_cocde = sad_cocde
----------------------------
and srh_reqno = sad_reqno  
--Left join CUBASINF on cbi_cocde = @cocde and cbi_cusno = sad_cus1no
--Left join VNBASINF on vbi_cocde = @cocde and vbi_venno = sad_venno
Left join CUBASINF(NOLOCK)  on cbi_cusno = sad_cus1no
Left join VNBASINF(NOLOCK)  on vbi_venno = sad_venno
*/


Where	-- 2004/02/11
	--sad_cocde = @cocde and
	--Lester W
--	(@cocde='ALL' or sad_cocde=@cocde) and 
	((@cocde='UC-G' and sad_cocde<>'MS' ) or sad_cocde=@cocde) and 
	---------------------------------
	--sad_itmno between @FromItmno and @ToItmno and	--2006-09-19
	--sad_itmno  in ( select _ItmNo from #_ItemNo (nolock) ) and
	sad_itmno is not null and
	((sad_cus1no between @FromCusno and @ToCusno and @Cusno = 'Y') or @Cusno = 'N') and
	((sad_venno between @FromVenno and @ToVenno and @Venno = 'Y') or @Venno = 'N') and
	((sad_subcde between @FromSubcde and @ToSubcde and @Subcde = 'Y') or @Subcde ='N')

Group by 
	ltrim(rtrim(sad_itmno)),		
	sad_colcde + '/' +
	sad_untcde + '/' + cast(sad_inrqty as nvarchar(10)) + '/' + cast(sad_mtrqty as nvarchar(10)) ,
	sad_cus1no,
	-- 2004/02/17 Lester Wu
	cbi_cussna,
	-----------------------------
	sad_reqno,
	sad_cus1no + ' - ' + cbi_cussna ,
	srh_issdat,	srh_rvsdat,
	sad_smpuntcde,
	sad_venno + ' - ' + vbi_vensna,	
	sad_subcde

)

--Lester Wu
--2004/08/13 
--Retrive data from Sample Invoice and mark as 'SA'
--XXXXXXXXXXXXXXXXXXXXXXXXXXxxxxxxxxXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
UNION
(
Select 	@cocde	as 'input_cocde'	, 	--1
	@FromItmno 	as 'input_FromItmno',	--2
	@ToItmno	as 'input_ToItmno',	--3
	@FromVenno	as 'input_FromVenno',	--4
	@ToVenno	as 'input_ToVenno',	--5
	@FromSubcde	as 'input_FromSubcde',	--6
	@ToSubcde	as 'input_ToSubcde',	--7
	@FromCusno	as 'input_FromCusno',	--8
	@ToCusno	as 'input_ToCusno',	--9	
	ltrim(rtrim(sid_itmno)),		--10
	sid_colcde + '/' +
	sid_pckunt + '/' + cast(sid_inrqty as nvarchar(10)) + '/' + cast(sid_mtrqty as nvarchar(10)) ,	-- 11
	'4-SA' as 'Type',
	'SA',	
	sih_cus1no,	-- 14
	cbi_cussna,
	sih_invno,		-- 15
	sih_cus1no + ' - ' + cbi_cussna as 'PriCust',
	sih_issdat,	
	sih_rvsdat,	
	sid_smpunt,	-- 19
	sid_venno + ' - ' + vbi_vensna,	
	sid_subcde,	Sum(sid_shpqty),	Sum(sid_shpqty),	0,
	'01-01-1900',	'01-01-1900'
	,@compName as 'compName'	
from 
#_ItemNo
left join SAINVDTL(NOLOCK) on _itmno = sid_itmno
Left join VNBASINF(NOLOCK)  on vbi_venno = sid_venno
left join SAINVHDR(NOLOCK) on sih_cocde = sid_cocde and sih_invno = sid_invno
Left join CUBASINF(NOLOCK)  on cbi_cusno = sih_cus1no

/*
SAINVDTL(NOLOCK) 
Left join VNBASINF(NOLOCK)  on vbi_venno = sid_venno
,SAINVHDR(NOLOCK) 
Left join CUBASINF(NOLOCK)  on cbi_cusno = sih_cus1no
*/

Where	/*sih_cocde=sid_cocde and
	sih_invno = sid_invno and*/
	--Lester Wu 2005-04-04, replace ALL with UC-G and exclude MS company data from UC-G
--	(@cocde='ALL' or sih_cocde=@cocde) and 
	((@cocde='UC-G' and sih_cocde<>'MS') or sih_cocde=@cocde) and 
	---------------------------------
--	sid_itmno between @FromItmno and @ToItmno and
	--sid_itmno in ( select _ItmNo from #_ItemNo (nolock) ) and
	sid_itmno is not null and
	((sih_cus1no between @FromCusno and @ToCusno and @Cusno = 'Y') or @Cusno = 'N') and
	((sid_venno between @FromVenno and @ToVenno and @Venno = 'Y') or @Venno = 'N') and
	((sid_subcde between @FromSubcde and @ToSubcde and @Subcde = 'Y') or @Subcde ='N')

Group by 
	ltrim(rtrim(sid_itmno)),
	sid_colcde + '/' + sid_pckunt + '/' + cast(sid_inrqty as nvarchar(10)) + '/' + cast(sid_mtrqty as nvarchar(10)) ,
	sih_cus1no,
	cbi_cussna,
	sih_invno,
	sih_cus1no + ' - ' + cbi_cussna,
	sih_issdat,	
	sih_rvsdat,	
	sid_smpunt,
	sid_venno + ' - ' + vbi_vensna,	
	sid_subcde

)
--XXXXXXXXXXXXXXXXXXXXXXXXXXxxxxxxxxXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

--Order by 10,11,12,14,15,19
Order by 10,11,12,15,16,20

--XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

--Frankie Cheung 20090525
select 
	input_cocde,
	input_FromItmno,
	input_ToItmno	,
	input_FromVenno,
	input_ToVenno ,
	input_FromSubcde ,
	input_ToSubcde ,
	input_FromCusno ,
	input_ToCusno,
	Itmno,
	Colpck,
	Type,
	DOCType,
	Cus1no,
	Cussna_sort,
	DocNo,
	Cussna,
--	convert(varchar(10), issdat, 101)  as 'issdat',
--	convert(varchar(10), rvsdat, 101)  as 'rvsdat',
	issdat,
	rvsdat,
	smpUM,
	venno,
	subcde,
	OrderQty,
	ShpQty,
	OSQty,
	ShpStr,
	ShpEnd,
	compName 
 from #_ItemList 
where #_ItemList.Cus1no in
(
	select * from #_CusList
)
order by itmno

drop table #_ItemNo
--Frankie Cheung 20090525
drop table #_ItemList
drop table #_CusList




GO
GRANT EXECUTE ON [dbo].[temp_sp_select_MSR00032] TO [ERPUSER] AS [dbo]
GO
