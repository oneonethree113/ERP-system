/****** Object:  StoredProcedure [dbo].[sp_list_QCRPTHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_QCRPTHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_QCRPTHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_list_QCRPTHDR]
	@qctype nvarchar(15),
	@rptdatefm nvarchar(10),
	@rptdateto nvarchar(10),
	@fano nvarchar(12),
	@custno nvarchar(6),
		@mi nvarchar(3) 

AS 
BEGIN
	create table #itmno
	(
	tmp_itmno nvarchar(30),
	tmp_cuspostr nvarchar(1000),
	tmp_rptno nvarchar(30)
	)

	declare @itmno  nvarchar(30)
	declare @morepo  nvarchar(1000)
 declare @morecuspo  nvarchar(1000)
 DECLARE @CIndexmore smallint
	declare @TmpRPTNo nvarchar(30)
	declare @tmp_str  nvarchar(30)


--------------------------------------------------------------------------------

	insert into #itmno
	select
		case ltrim(Rtrim(qrh_itmno)) 
		when '' then
		qrh_othitmno
		else
		qrh_itmno
		end as 'qrh_itmno','',qrh_tmprptno
	from
		QCRPTHDR QCH LEFT JOIN  
	VNBASINF ON qrh_venno = vbi_venno LEFT JOIN 
	CUBASINF priCust on qrh_cus1no = priCust.cbi_cusno LEFT JOIN 
	CUBASINF secCust on qrh_cus2no = secCust.cbi_cusno LEFT JOIN
	qcrptdtl on qrh_tmprptno = qrd_tmprptno
	where (qrh_rpttyp = @qctype OR @qctype = '') AND 
	qrh_credat BETWEEN convert(datetime, @rptdatefm, 103) AND DATEADD(day,1,convert(datetime, @rptdateto, 103)) AND
	(qrh_venno = @fano OR @fano = 'ALL') AND 
	((qrh_cus1no = @custno OR @custno = 'ALL') OR (qrh_cus2no = @custno OR @custno = 'ALL'))
	and qrh_rpttyp = 'F' 
	and  qrh_rptstatus like '%CONFIRM%'
	--and not (qrh_tmprptno  like '%QCP9%')
	--and not (qrh_tmprptno  like '%QCP01%')
	and 	(qrh_tmprptno like   '%' +'QCP'+ @mi + '%'   or  @mi ='ALL')


	-- select * from #itmno
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------

DECLARE @itmnoCursor as CURSOR;
 
SET @itmnoCursor = CURSOR FOR
SELECT tmp_itmno,tmp_rptno
 FROM #itmno
 
OPEN @itmnoCursor;
FETCH NEXT FROM @itmnoCursor INTO @itmno, @TmpRPTNo;
 
WHILE @@FETCH_STATUS = 0
BEGIN
 
------------------------

set @morepo   = (select qrh_morepo from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
if rtrim(ltrim(@morepo  )) = ''
begin
set @morepo   = (select qrh_othpostr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
end

set @morecuspo = ''

WHILE (@morepo <>''  )

BEGIN

SET @CIndexmore=CHARINDEX(';',@morepo )
IF @CIndexmore=0 SET @CIndexmore=LEN(@morepo )+1

set @tmp_str = (select top 1 poh_cuspno from poordhdr	where poh_purord= SUBSTRING(@morepo ,1,@CIndexmore-1))
set @morecuspo =@morecuspo +  @tmp_str  + ','

IF @CIndexmore=LEN(@morepo )+1 BREAK
IF CHARINDEX(';',@morepo ) = 0	 BREAK

SET @morepo =SUBSTRING(@morepo ,@CIndexmore+1,LEN(@morepo )-@CIndexmore)

END


 update #itmno
	set tmp_cuspostr=  @morecuspo
	where tmp_itmno = @itmno

------------------------
	
FETCH NEXT FROM @itmnoCursor INTO @itmno, @TmpRPTNo;
END
 
CLOSE @itmnoCursor;
DEALLOCATE @itmnoCursor;

--------------------------------------------------------------------------------
--------------------------------------------------------------------------------

	-- select * from #itmno









	SELECT CONVERT(CHAR(10), qrh_inspdat, 101) date,
	--CONVERT(CHAR(10), qrh_inspdat, 101) date,
		'<a href=file/QCRpt/' + qrh_tmprptno+ '.pdf > ' + qrh_tmprptno  + '</a>'
	as 'reportNo_h',
	 qrh_tmprptno
	as 'reportNo',

	qrh_finalstatus finalStatus,
	qrh_shipapprv shipapprv,
	case when qrh_rpttyp = 'F' then 'Final' 
	when qrh_rpttyp =  'I' then 'In-Line' else '-' end qcType,
	qrh_rptstatus qrh_rptstatus, 
--	case when qrd_inspresult = 'P' then 'PENDING' 
--	when qrd_inspresult = 'F' then 'FAIL' 
--	when qrd_inspresult =  'A' then 'PASS' else '-' end rst,
	 qrh_inspresult as  'rst',



	vbi_Vensna factory,
	case when secCust.cbi_cussna IS NULL OR secCust.cbi_cussna = '' then priCust.cbi_cussna else secCust.cbi_cussna end customer,
	qrh_qcno requestNo,
	case qrh_postr
	when '' then
	Replace(qrh_morepo,';',',') + Replace(qrh_othpostr,';',',')  
	else
	qrh_postr + ',' + Replace(qrh_morepo,';',',') + Replace(qrh_othpostr,';',',')  
	end as 'po',
	
	qrh_itmno ucpItem,

	case qrh_cuspostr
	when '' then
	 Replace(tmp_cuspostr,';',',') 
	else
	qrh_cuspostr + ',' + Replace(tmp_cuspostr,';',',') 
	end as 'custPo',
	




	qrh_cusitm custItem, 
	qrh_retmsg qrh_retmsg
	from
		QCRPTHDR QCH LEFT JOIN  
	VNBASINF ON qrh_venno = vbi_venno LEFT JOIN 
	CUBASINF priCust on qrh_cus1no = priCust.cbi_cusno LEFT JOIN 
	CUBASINF secCust on qrh_cus2no = secCust.cbi_cusno LEFT JOIN
					qcrptdtl on qrh_tmprptno = qrd_tmprptno
	left join #itmno  on tmp_rptno = qrh_tmprptno

	where (qrh_rpttyp = @qctype OR @qctype = '') AND 
	qrh_credat BETWEEN convert(datetime, @rptdatefm, 103) AND  DATEADD(day,1,convert(datetime, @rptdateto, 103)) AND
	(qrh_venno = @fano OR @fano = 'ALL') AND 
	((qrh_cus1no = @custno OR @custno = 'ALL') OR (qrh_cus2no = @custno OR @custno = 'ALL'))
	and qrh_rpttyp = 'F' 
	and  qrh_rptstatus like '%CONFIRM%'
	--and not (qrh_tmprptno  like '%QCP9%')
	--and not (qrh_tmprptno  like '%QCP01%')
	and 	(qrh_tmprptno like   '%' +'QCP'+ @mi + '%'   or  @mi ='ALL')
	order by  qrh_credat desc
END
----




 



GO
GRANT EXECUTE ON [dbo].[sp_list_QCRPTHDR] TO [ERPUSER] AS [dbo]
GO
