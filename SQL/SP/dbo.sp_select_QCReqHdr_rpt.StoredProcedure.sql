/****** Object:  StoredProcedure [dbo].[sp_select_QCReqHdr_rpt]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCReqHdr_rpt]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCReqHdr_rpt]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


create  PROCEDURE [dbo].[sp_select_QCReqHdr_rpt]
--	@qctype nvarchar(15),
	@rptdatefm nvarchar(10),
	@rptdateto nvarchar(10),
	@fano nvarchar(12),
	@status nvarchar(12),
	@result nvarchar(12),
	@custno nvarchar(6),
	@fr nvarchar(12),
	@sa nvarchar(12),
	@mi nvarchar(3) 
	
AS 
BEGIN


--set @sa = ltrim(rtrim((@sa))

	SELECT 
	qrh_qcno qcno, 
	qrh_postr po,
	qrh_itmno ucpItem,
    qrh_cusitm custItem , 
    qrh_itmdsc itmdsc , 
	CONVERT(CHAR(10), qrh_inspdat, 101) date,
		'<a href=file/QCRpt/' + qrh_tmprptno+ '.pdf > ' + qrh_tmprptno  + '</a>'
	as 'reportNo_h',
	qrh_tmprptno reportNo,
	case when qrh_rpttyp = 'F' then 'Final' 
	when qrh_rpttyp =  'M' then 'In-Line' else '-' end qcType,

	qrh_rptstatus qrh_rptstatus, 
	qrh_inspresult    qrd_inspresult,

	isnull(qrh_finalstatus,'') as  'finalStatus',

	isnull(qrh_shipapprv,'') as 'qrh_shipapprv',
	 
    isnull(vbi_Vensna ,'' )factory,
	case when secCust.cbi_cussna IS NULL OR secCust.cbi_cussna = '' then priCust.cbi_cussna else secCust.cbi_cussna end customer,
 	qrh_cuspostr custPo  , 
	qrh_retmsg qrh_retmsg
  from
	QCRPTHDR QCH 
			LEFT JOIN QCREQHDR
			ON qch_qcno = qrh_qcno
	LEFT JOIN  
	VNBASINF ON qrh_venno = vbi_venno LEFT JOIN 
	CUBASINF priCust on qrh_cus1no = priCust.cbi_cusno LEFT JOIN 
	CUBASINF secCust on qrh_cus2no = secCust.cbi_cusno LEFT JOIN
	qcrptdtl on qrh_tmprptno = qrd_tmprptno
	where 
--	(qrh_rpttyp = @qctype OR @qctype = '') AND 
	qrh_credat BETWEEN convert(datetime, @rptdatefm, 103) AND convert(datetime, @rptdateto, 103) AND
	(qrh_venno = @fano OR @fano = 'ALL') AND 

	(qrh_rptstatus like @status OR @status = 'ALL') AND 
	(qrd_inspresult like @result OR @result = 'ALL') AND 

	(qrh_finalstatus  like @fr OR @fr = 'ALL') AND 
	(qrh_shipapprv like  '%' + @sa + '%'  OR @sa= 'ALL') AND 

	((qrh_cus1no = @custno OR @custno = 'ALL') OR (qrh_cus2no = @custno OR @custno = 'ALL'))
	and 
	(qrh_tmprptno like   '%' +'QCP'+ @mi + '%'   or  @mi ='ALL')
	and not (qrh_tmprptno  like '%QCP9%')
	--and not (qrh_tmprptno  like '%QCP01%')
	order by  qrh_credat   desc
END



GO
GRANT EXECUTE ON [dbo].[sp_select_QCReqHdr_rpt] TO [ERPUSER] AS [dbo]
GO
