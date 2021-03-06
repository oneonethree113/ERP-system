/****** Object:  StoredProcedure [dbo].[SP_SELECT_IMR00013]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_IMR00013]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_IMR00013]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/***************************************************************************************************
Program ID 	:	SP_SELECT_IMR00013
AUTHOUR	: 	LESTER WU
DESCRIPTION	:	RETRIEVE INFORMATION ABOUT ITEMS WITH AND/OR WITHOUT IMAGES
			ANL	=	ANALYST RESULT
			DTL	=	DETAIL BREAK DOWN
			LST	=	LIST OF ITEM WITHOUT IMAGE
			ORD  	=	LIST OF ORDERED ITEM WITHOUT IMAGE
TABLE READ	:	IMBASINF
TABLE WRITE	:	
******************************************************************************************************
MODIFICATION HISTORY
******************************************************************************************************
MODIFIED ON		MODIFIED BY		DESCRIPTION
2006-05-30		Marco Chan		Remark for the searching item like 'Year%' logic
2006-06-22		Mark Lau		Add a new report type
******************************************************************************************************


*******************************************************************************************************/
--SP_SELECT_IMR00013 'UCPP','04','04','01','01','A - LSDJF','A - LASDFJ','ANL'
CREATE PROCEDURE [dbo].[SP_SELECT_IMR00013]
@COCDE	VARCHAR(6),
@YEARFM	VARCHAR(2),
@YEARTO	VARCHAR(2),
@MTHFM	VARCHAR(2),
@MTHTO	VARCHAR(2),
@VENNOFM	VARCHAR(30),
@VENNOTO	VARCHAR(30),
@OPTRPT	VARCHAR(3),
@ISSDATFM	datetime = '1899-99-99 00:00:00' ,
@ISSDATTO	datetime = '1899-99-99 23:59:59' 

AS
BEGIN

DECLARE 
@strVENNOFM AS VARCHAR(6),
@strVENNOTO AS VARCHAR(6)

SET @strVENNOFM = LEFT(@VENNOFM,CHARINDEX(" - ",@VENNOFM) - 1)
SET @strVENNOTO = LEFT(@VENNOTO,CHARINDEX(" - ",@VENNOTO) - 1)


IF @OPTRPT='ANL'
BEGIN
	SELECT 
		'20' + @YEARFM + ' / ' + @MTHFM as '@YEARFM',
		'20' + @YEARTO + ' / ' + @MTHTO as '@YEARTO',
		@VENNOFM as '@VENNOFM',
		@VENNOTO as '@VENNOTO',
		COUNT(*) AS 'ITEM_CREATED'
		, ISNULL(SUM(CASE ISNULL(IBI_IMGPTH,'') WHEN '' THEN 0 ELSE 1 END),0) AS 'ITEM_W_IMG'
		, CASE COUNT(*) 	WHEN 0 THEN 0.00 
				ELSE ROUND(1*(SUM(CASE ISNULL(IBI_IMGPTH,'') WHEN '' THEN 0.00 ELSE 1.00 END) / COUNT(*)),4) END AS 'ITEM_W_IMG_PCT'
		, ISNULL(SUM(CASE ISNULL(IBI_IMGPTH,'') WHEN '' THEN 1 ELSE 0 END),0) AS 'ITEM_WO_IMG'
		, CASE COUNT(*)	WHEN 0 THEN 0.00
				ELSE 1.00 - ROUND(1*(SUM(CASE ISNULL(IBI_IMGPTH,'') WHEN '' THEN 0.00 ELSE 1.00 END) / COUNT(*)),4) END AS 'ITEM_WO_IMG_PCT'
		

	FROM 
		IMBASINF (NOLOCK)
	WHERE 
		--IBI_ITMNO LIKE '04%'
		IBI_VENNO BETWEEN @strVENNOFM AND @strVENNOTO
--		AND LEFT(IBI_ITMNO,2) BETWEEN @YEARFM AND @YEARTO
		AND (IBI_CREDAT >= '20' + @YEARFM + '-' + @MTHFM + '-01' AND IBI_CREDAT < DATEADD(MONTH,1,'20' + @YEARTO + '-' + @MTHTO + '-01'))
	--SELECT @TTLITEMS,@TTLITEMS_W_IMG,@TTLITEMS_WO_IMG
END
ELSE IF @OPTRPT='DTL'
BEGIN
	SELECT 
		'20' + @YEARFM + ' / ' + @MTHFM as '@YEARFM',
		'20' + @YEARTO + ' / ' + @MTHTO as '@YEARTO',
		@VENNOFM as '@VENNOFM',
		@VENNOTO as '@VENNOTO',
		IBI_VENNO + CASE ISNULL(VBI_VENNO,'') WHEN '' THEN '' ELSE ' - ' + VBI_VENSNA END AS 'IBI_VENNO'
		,COUNT(*) AS 'ITEM_CREATED'
		, ISNULL(SUM(CASE ISNULL(IBI_IMGPTH,'') WHEN '' THEN 0 ELSE 1 END),0) AS 'ITEM_W_IMG'
		, CASE COUNT(*) 	WHEN 0 THEN 0
				ELSE ROUND(100*(SUM(CASE ISNULL(IBI_IMGPTH,'') WHEN '' THEN 0.00 ELSE 1.00 END) / COUNT(*)),2) END AS 'ITEM_W_IMG_PCT'
		, ISNULL(SUM(CASE ISNULL(IBI_IMGPTH,'') WHEN '' THEN 1 ELSE 0 END),0) AS 'ITEM_WO_IMG'
		, CASE COUNT(*) 	WHEN 0 THEN 0
				ELSE 100.00 - ROUND(100*(SUM(CASE ISNULL(IBI_IMGPTH,'') WHEN '' THEN 0.00 ELSE 1.00 END) / COUNT(*)),2) END AS 'ITEM_WO_IMG_PCT'
	FROM 
		IMBASINF (NOLOCK)
		LEFT JOIN VNBASINF(NOLOCK) ON IBI_VENNO = VBI_VENNO
	WHERE 
		--IBI_ITMNO LIKE '04%'
		IBI_VENNO BETWEEN @strVENNOFM AND @strVENNOTO
--		AND LEFT(IBI_ITMNO,2) BETWEEN @YEARFM AND @YEARTO
		AND (IBI_CREDAT >= '20' + @YEARFM + '-' + @MTHFM + '-01' AND IBI_CREDAT < DATEADD(MONTH,1,'20' + @YEARTO + '-' + @MTHTO + '-01'))
	GROUP BY 
		IBI_VENNO + CASE ISNULL(VBI_VENNO,'') WHEN '' THEN '' ELSE ' - ' + VBI_VENSNA END
	ORDER BY 
		IBI_VENNO



END
ELSE IF @OPTRPT='LST'
BEGIN
	SELECT 
		'20' + @YEARFM + ' / ' + @MTHFM as '@YEARFM',
		'20' + @YEARTO + ' / ' + @MTHTO as'@YEARTO',
		@VENNOFM as '@VENNOFM',
		@VENNOTO as '@VENNOTO',
		IBI_ITMNO as 'IBI_ITMNO',
		IVI_venitm as 'IVI_ITMNO',
		IBI_VENNO + CASE ISNULL(VBI_VENNO,'') WHEN '' THEN '' ELSE ' - ' + VBI_VENSNA END AS 'IBI_VENNO'
	FROM 
		IMBASINF (NOLOCK)
		LEFT JOIN VNBASINF(NOLOCK) ON IBI_VENNO = VBI_VENNO
		LEFT JOIN IMVENINF (NOLOCK) ON IVI_ITMNO = IBI_ITMNO
	WHERE 
		--IBI_ITMNO LIKE '04%'
		IBI_VENNO BETWEEN @strVENNOFM AND @strVENNOTO
--		AND LEFT(IBI_ITMNO,2) BETWEEN @YEARFM AND @YEARTO
		AND (IBI_CREDAT >= '20' + @YEARFM + '-' + @MTHFM + '-01' AND IBI_CREDAT < DATEADD(MONTH,1,'20' + @YEARTO + '-' + @MTHTO + '-01'))
		AND ISNULL(IBI_IMGPTH,'') =''		
	ORDER BY 
		IBI_VENNO

END



ELSE IF @OPTRPT='ORD'or @OPTRPT='ORE'

/*
IMR_00013d by Mark
*/

BEGIN

DECLARE 
@strVENNOFM_d VARCHAR(6),
@strVENNOTO_d  VARCHAR(6),
@venitm VARCHAR(100),
@itmno   VARCHAR(100),
@venno VARCHAR(100),
@cust1 VARCHAR(100),
@cust2 VARCHAR(100),
@jobNo VARCHAR(100),
@comb_cust VARCHAR(100),
@comb_SCNo VARCHAR(100),
@POshipstr datetime,
@POshipend datetime,
@comb_POship VARCHAR(500)


SET @strVENNOFM_d = LEFT(@VENNOFM,CHARINDEX(' - ',@VENNOFM) - 1)
SET @strVENNOTO_d = LEFT(@VENNOTO,CHARINDEX(' - ',@VENNOTO) - 1)

/*
Get distinct item by the given criteria
*/
SELECT DISTINCT 
	IVI_venitm
	, ibi_itmno
	,IBI_VENNO + CASE ISNULL(VBI_VENNO,'') WHEN '' THEN '' ELSE ' - ' + VBI_VENSNA END AS 'IBI_VENNO'
	INTO #Temp_Itm
FROM IMBASINF
	LEFT JOIN VNBASINF(NOLOCK) ON IBI_VENNO = VBI_VENNO
	LEFT JOIN IMVENINF (NOLOCK) ON IVI_ITMNO = IBI_ITMNO
WHERE 

	IBI_VENNO BETWEEN @strVENNOFM_d AND @strVENNOTO_d
	--AND LEFT(IBI_ITMNO,2) BETWEEN @YEARFM AND @YEARTO
	AND (IBI_CREDAT >= '20' + @YEARFM + '-' + @MTHFM + '-01' AND IBI_CREDAT < DATEADD(MONTH,1,'20' + @YEARTO + '-' + @MTHTO + '-01'))
	AND ISNULL(IBI_IMGPTH,'') =''	

--GROUP BY IBI_VENNO + CASE ISNULL(VBI_VENNO,'') WHEN '' THEN '' ELSE ' - ' + VBI_VENSNA END, ibi_itmno, IVI_venitm
ORDER BY ibi_itmno


/*
Get related sales order by the given issue date
*/
SELECT sod_ordno,sod_itmno
	,  (  cus1.cbi_cussna) AS 'cbi_Cust1'
	, ( cus2.cbi_cussna) AS 'cbi_Cust2'
	,isnull(pod_jobord,'') AS 'jobNo'
	,sod_posstr as 'POshipstr'
	,sod_posend as 'POshipend'
--cus1.cbi_cusno + '  -  ' +                                                 cus2.cbi_cusno + '  -  ' +

INTO #Temp_Sales

FROM SCORDDTL
left join SCORDHDR(NOLOCK) ON soh_ordno = sod_ordno
left join  CUBASINF as cus1 (nolock) ON  cus1.cbi_cusno=soh_cus1no
left join  CUBASINF as cus2 (nolock) ON  cus2.cbi_cusno=soh_cus2no
left join POORDDTL (nolock) on
	pod_cocde = sod_cocde and
	pod_scno = sod_ordno and
	pod_scline = sod_ordseq
WHERE
(soh_issdat >=@ISSDATFM and soh_issdat <@ISSDATTO)


--select * from #Temp_Sales where sod_itmno='161756-00142'

/*
Looping Starts
*/
--if  @OPTRPT='ORE'
--begin 
--select 	('20' + @YEARFM + '/' + @MTHFM) AS 'YEARFM',
--	('20' + @YEARTO + '/' + @MTHTO) AS 'YEARTO',
--	@VENNOFM '@VENNOFM',
--	@VENNOTO '@VENNOTO',
--	@ISSDATFM  AS 'ISSDATFM',
--	@ISSDATTO AS 'ISSDATTO ', * from #Temp_Sales
--end
if @OPTRPT='ORE'
begin
select 	('20' + @YEARFM + '/' + @MTHFM) AS 'YEARFM',
	('20' + @YEARTO + '/' + @MTHTO) AS 'YEARTO',
	@VENNOFM '@VENNOFM',
	@VENNOTO '@VENNOTO',
	@ISSDATFM  AS 'ISSDATFM',
	@ISSDATTO AS 'ISSDATTO ', 
	IVI_venitm,
	ibi_itmno,
	IBI_VENNO,
	cbi_Cust1,
	jobNo,
	LEFT(CONVERT(VARCHAR, POshipstr, 120), 10)+" ~ "+ LEFT(CONVERT(VARCHAR, POshipend, 120), 10) from #Temp_Itm left join #Temp_Sales on sod_itmno=ibi_itmno where sod_ordno IS NOT NULL and sod_ordno<>''

ORDER BY ibi_Itmno
end
else
begin


SET @venitm   = ''
SET @itmno = ''
SET @comb_cust=''
SET @cust1=''
SET @cust2=''
SET @comb_SCNo =''
SET @comb_POship =''

--select * from #Temp_Sales

CREATE TABLE #tmp_result(

	Venitem	varchar(30),
	Itmno	varchar(30),
	venno	varchar(30),
	comb_cust varchar(255),
	comb_job varchar(255),
	comb_POship varchar(500)
	)



DECLARE Itm_cursor CURSOR FOR 
SELECT    IVI_venitm
	,ibi_itmno
	,IBI_VENNO  
FROM
	 #Temp_Itm

OPEN Itm_cursor

FETCH NEXT FROM Itm_cursor
INTO @venitm,@itmno,@venno

WHILE @@FETCH_STATUS = 0
BEGIN

	begin
		DECLARE Result_cursor CURSOR FOR 
		SELECT DISTINCT cbi_Cust1
		--,cbi_Cust2
		--cus1.cbi_cusno + '  -  ' +                                                 cus2.cbi_cusno + '  -  ' +
		FROM #Temp_Sales
		WHERE
		sod_itmno =@itmno
		--ORDER BY sod_itmno

		OPEN Result_cursor

		FETCH NEXT FROM Result_cursor
		INTO @cust1--,@cust2

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @comb_cust  = @comb_cust + @cust1 + '  '--+ Case ISNULL(@cust2,'') WHEN '' THEN '' ELSE  @cust2 + ', ' END

			FETCH NEXT FROM Result_cursor
			INTO @cust1--,@cust2
		END
	end


	begin
		DECLARE Result_cursor2 CURSOR FOR 
		SELECT DISTINCT jobNo,POshipstr,POshipend
		--,cbi_Cust2
		--cus1.cbi_cusno + '  -  ' +                                                 cus2.cbi_cusno + '  -  ' +
		FROM #Temp_Sales
		WHERE
		sod_itmno =@itmno
		--ORDER BY sod_itmno




		OPEN Result_cursor2

		FETCH NEXT FROM Result_cursor2
		INTO @jobNo,@POshipstr,@POshipend--,@cust2

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @comb_SCNo  = @comb_SCNo + Case ISNULL(@jobNo,'') WHEN '' THEN '' ELSE  @jobNo + ' ' END   -- @jobNo + ',  '--+ Case ISNULL(@cust2,'') WHEN '' THEN '' ELSE  @cust2 + ', ' END
			set @comb_POship=@comb_POship+LEFT(CONVERT(VARCHAR, @POshipstr, 120), 10)  + '~'+LEFT(CONVERT(VARCHAR, @POshipend, 120), 10)  + ' '
			FETCH NEXT FROM Result_cursor2
			INTO @jobNo,@POshipstr,@POshipend--,@cust2
		END
	end



	IF LEN(@comb_cust) > 0 
	BEGIN
		SET @comb_cust  =  SUBSTRING(@comb_cust ,1,LEN(@comb_cust))
		if LEN(@comb_SCNo)>0
		begin
			SET @comb_SCNo  =  SUBSTRING(@comb_SCNo ,1,LEN(@comb_SCNo))
		end
		if LEN(@comb_POship)>0
		begin
			SET @comb_POship  =  SUBSTRING(@comb_POship ,1,LEN(@comb_POship))
		end

		INSERT INTO #tmp_result (Venitem,	Itmno,	venno,	comb_cust,	comb_job,	comb_POship) 
		VALUES(					@venitm,	@itmno,	@venno,	@comb_cust,	@comb_SCNo,	@comb_POship)
	END

	SET @comb_cust  =''
	SET @comb_SCNo  =''
	set @comb_POship=''
	CLOSE Result_cursor
	DEALLOCATE Result_cursor
	CLOSE Result_cursor2
	DEALLOCATE Result_cursor2


	FETCH NEXT FROM Itm_cursor
	INTO @venitm,@itmno,@venno


END
CLOSE Itm_cursor
DEALLOCATE Itm_cursor

SELECT
	('20' + @YEARFM + '/' + @MTHFM) AS 'YEARFM',
	('20' + @YEARTO + '/' + @MTHTO) AS 'YEARTO',
	@VENNOFM '@VENNOFM',
	@VENNOTO '@VENNOTO',
	LEFT(CONVERT(VARCHAR, @ISSDATFM, 120), 10)  AS 'ISSDATFM',
	LEFT(CONVERT(VARCHAR, @ISSDATTO, 120), 10) AS 'ISSDATTO ', 
	Venitem as 'Venitem',
	Itmno as 'Itmno',
	venno as 'venno',
	comb_cust as 'comb_cust',
	comb_job as 'comb_job',
	comb_POship as 'comb_POship'

FROM #tmp_result
WHERE comb_cust IS NOT NULL and comb_cust<>''
ORDER BY Itmno

end
end


END



GO
GRANT EXECUTE ON [dbo].[SP_SELECT_IMR00013] TO [ERPUSER] AS [dbo]
GO
