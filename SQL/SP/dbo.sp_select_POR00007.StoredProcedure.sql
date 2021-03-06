/****** Object:  StoredProcedure [dbo].[sp_select_POR00007]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00007]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00007]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*
================================================================================
Program ID	: sp_select_POR00007
Programmer	: Lester Wu
Description		: Retrieve BOM PO information
ALTER  Date		: 27th Aug , 2004
Table Read(s)	: POORDHDR,POORDDTL, PODTLBOM, PODTLASS,POBOMHDR,POBOMDTL
Table Write(s)	:
================================================================================
Modification History
================================================================================
Modification Date		Modified By		Description
-------------------------------------------------------------------------------------------------------------------------------------------
2004/10/04		Lester Wu		Search by BOM PO's Vendor No instead of PO's Vendor No 
						(Requested by Anita Leung on 2004/10/04)
2004/10/05		Lester Wu		Calculate Total Amount from PBD_ADJQTY * PBD_NEGPRC
2005/03/10		Lester Wu		Add Cust PO No
===============================================================================
*/

--SP_SELECT_POR00007 'UCP','50130','50130','','','PR0402538-B001','PR0402538-B001','','','','','','','','','','','All','N',0
--SP_SELECT_POR00007 'UCP','50130','50130','','','','','','','','','','','','','01/01/2004','01/31/2004','All','N',0
--SP_SELECT_POR00007 'UCP','','','','','','','SC0302042-J001','SC0302042-J001','','','','','','','01/01/2004','01/31/2004','All','N',0
--SP_SELECT_POR00007 'UCP','','','','','','','','','','','','','','','01/01/2004','01/31/2004','All','N',0
--SP_SELECT_POR00007 'UCP','50130','50130','A','A','','','','','','','','','','','','','All','N',0
--SP_SELECT_POR00007 'UCP','','','','','PR0402407-B001','PR0402407-B001','','','','','','','','','','','All','N',1

CREATE PROCEDURE  [dbo].[sp_select_POR00007]
@cocde 		as nvarchar(6),
@CustNoFm 	as nvarchar(6),
@CustNoTo	as nvarchar(6),
@VenNoFm	as nvarchar(6),
@VenNoTo	as nvarchar(6),
@PONoFm	as nvarchar(20),
@PONoTo		as nvarchar(20),
@JobNoFm	as nvarchar(20),
@JobNoTo	as nvarchar(20),
@BomItemNoFm	as nvarchar(20),
@BomItemNoTo	as nvarchar(20),
@IssDatFm	as datetime,
@IssDatTo		as datetime,
@RevDatFm	as datetime,
@RevDatTo	as datetime,
@ShpDatFm	as datetime,
@ShpDatTo	as datetime,
@optStatus		as nvarchar(3),
@optZero		as char(1),
@RptType		as int

as

begin
	declare	@optCUST	AS CHAR(1),
		@optVEN		AS CHAR(1),
		@optPO		AS CHAR(1),
		@optJOB		AS CHAR(1),
		@optBOMITEM	AS CHAR(1),
		@optISSDAT	AS CHAR(1),
		@optREVDAT	AS CHAR(1),
		@optSHPDAT	AS CHAR(1)
		
	SET @optCUST = 'N'
	SET @optVEN = 'N'
	SET @optPO = 'N'
	SET @optJOB = 'N'
	SET @optBOMITEM = 'N'
	SET @optISSDAT = 'N'
	SET @optREVDAT = 'N'
	SET @optSHPDAT = 'N'
	
	IF @CustNoFm<>'' and @CustNoTo<>'' 
	BEGIN
		SET @optCUST = 'Y'	
	END
	
	IF @VenNoFm<>'' and @VenNoTo<>'' 
	BEGIN
		SET @optVEN = 'Y'
	END
	
	IF @PONoFm<>'' and @PONoTo <>'' 
	BEGIN
		SET @optPO = 'Y'
		SET @PONoFm = LEFT(@PONoFm,CHARINDEX('-',@PONoFm)-1)
		SET @PONoTo = LEFT(@PONoTo,CHARINDEX('-',@PONoTo)-1)
	END
	
	IF @JobNoFm<>'' and @JobNoTo<>''
	BEGIN
		SET @optJOB = 'Y'
	END
	
	IF @BomItemNoFm<>'' and @BomItemNoTo <>'' 
	BEGIN
		SET @optBOMITEM='Y'
	END
	
	IF @IssDatFm<>'' and @IssDatTo<>'' 
	BEGIN
		SET @optISSDAT='Y'
	END
	
	IF @RevDatFm<>'' and @RevDatFm<>'' 
	BEGIN
		SET @optREVDAT = 'Y'
	END
	
	IF @ShpDatFm<>'' and @ShpDatTo<>'' 
	BEGIN
		SET  @optSHPDAT = 'Y'
	END
	
	SELECT distinct 
		ISNULL(A.VBI_VENSNA,'') AS 'PRODUCTION VENDOR',
		CASE ISNULL(CBI_CUSSNA,'') WHEN '' THEN POH_PRMCUS
						ELSE POH_PRMCUS + ' - ' + CBI_CUSSNA
					END AS 'CUST. CODE & SHORT NAME',
		isnull(PBH_CUSPO,'') AS 'CUST PO NO',
		POD_JOBORD AS 'JOB NO',
		POD_ITMNO AS 'ORIGINAL ITEM NO',
		ISNULL(PBD_ASSITM,'') AS 'ASSORTED ITEM NO',
		POD_VENCOL AS 'VENDOR COLOR CODE',
		POD_UNTCDE + ' / ' + LTRIM(STR(POD_INRCTN)) + ' / ' + LTRIM(STR(POD_MTRCTN)) + ' / ' + CAST(POD_CUBCFT  AS NVARCHAR(30)) AS 'PACKING(UM / INNER / OUTER / CFT)',
		POD_ORDQTY AS 'ORDER QUANTITY',
		ISNULL(PBD_PQBOM,0)  AS 'PER QTY OF BOM',
		CONVERT(VARCHAR(10),POD_SHPSTR,110)  AS 'SHIP START DATE',
		CONVERT(VARCHAR(10),POD_SHPEND,110)  AS 'SHIP END DATE',
		ISNULL(B.VBI_VENSNA,'') AS 'BOM VENDOR NAME',
		PBH_BOMPO AS 'BOM PO NO',
		PBD_ITMNO AS 'BOM ITEM NO',
		PBD_RVENITM AS 'SUSTITUTE VENDOR ITEM NO',
		ISNULL(PBD_ENGDSC,'') AS 'BOM ENGLISH DESCRIPTION',
		ISNULL(PBD_CHNDSC,'') AS 'BOM CHINESE DESCRIPTION',
		PBD_VCODSC AS 'BOM VENDOR COLOR CODE',
		PBD_UNTCDE AS 'BOM UM',
		ISNULL(PBD_ADJQTY,0) AS 'BOM ORDER QTY',
		ISNULL(PBH_CURCDE,'') AS 'BOM CURRENCY',
		ISNULL(PBD_NEGPRC,0) AS 'BOM UNIT PRICE',
		ROUND(ISNULL(PBD_ADJQTY,0) * ISNULL(PBD_NEGPRC,0.0000),2) AS 'BOM TOTAL AMOUNT',
		CONVERT(VARCHAR(10),PBD_SHPSTR,110)  AS 'BOM SHIP START DATE',
		CONVERT(VARCHAR(10),PBD_SHPEND,110) AS 'BOM SHIP END DATE',
		CONVERT(VARCHAR(10),PBH_RVSDAT,110) AS 'BOM REVISE DATE',
		CONVERT(VARCHAR(19),PBD_UPDDAT,110) + ' ' + CONVERT(VARCHAR(19),PBD_UPDDAT,108) AS 'BOM UPDATE DATE / TIME'
	INTO	#POR00007
	FROM	POBOMHDR (NOLOCK) 
		LEFT JOIN POBOMDTL (NOLOCK) ON	PBD_COCDE = PBH_COCDE		and
						PBD_BOMPO = PBH_BOMPO
		LEFT JOIN POORDDTL (NOLOCK) ON	PBD_COCDE = POD_COCDE		and
						PBD_REFPO = POD_PURORD		and
						PBD_REGITM = POD_ITMNO		and
						PBD_COLCDE = POD_VENCOL
		LEFT JOIN POORDHDR (NOLOCK) ON	POD_COCDE = POH_COCDE		and
						POD_PURORD= POH_PURORD
		LEFT JOIN VNBASINF B (NOLOCK) ON	PBH_BVENNO = B.VBI_VENNO
		LEFT JOIN CUBASINF (NOLOCK) ON	POH_PRMCUS = CBI_CUSNO
		LEFT JOIN VNBASINF A (NOLOCK) ON	POH_VENNO = A.VBI_VENNO
	WHERE	POH_COCDE IS NOT NULL						and
		(@cocde='ALL'	or
		 POH_COCDE = @cocde)						and
		(@optCUST = 'N'	or
		 (@optCUST = 'Y'		and
		   POH_PRMCUS BETWEEN @CustNoFm and @CustNoTo))			and
		(@optVEN = 'N'	or
		 (@optVEN = 'Y'		and
		   PBH_BVENNO BETWEEN @VenNoFm and @VenNoTo))			and
		(@optPO = 'N'	or
		 (@optPO = 'Y'		and
		   POH_PURORD BETWEEN @PONoFm and @PONoTo))			and
		(@optJOB = 'N'	or
		 (@optJOB = 'Y'		and
		   POD_JOBORD BETWEEN @JobNoFm and @JobNoTo))			and
		(@optBOMITEM = 'N' or
		 (@optBOMITEM = 'Y'	and
		   ISNULL(PBD_ITMNO,'') BETWEEN @BomItemNoFm and @BomItemNoTo))	and
		(@optISSDAT = 'N'	or
		 (@optISSDAT = 'Y'		and
		   PBH_ISSDAT BETWEEN @IssDatFm and @IssDatTo + '23:59:59' ))		and
		(@optREVDAT = 'N'	or
		 (@optREVDAT = 'Y'		and
		   PBH_RVSDAT BETWEEN @RevDatFm and @RevDatTo + '23:59:59'))		and
		(@optSHPDAT = 'N'	or
		 (@optSHPDAT = 'Y'		and
		   PBD_SHPSTR BETWEEN @ShpDatFm and @ShpDatTo + ' 23:59:59'))		and
		(@optZero = 'N'	or
		 (@optZero = 'Y'		and
		   PBD_ORDQTY > 0 ))						and
		(@optStatus = 'ALL'	or
		 (@optStatus <> 'ALL'		and
		   PBH_bomsts=@optStatus))
	
	IF @RptType = 0 --REPORT TYPE = PO
		SELECT		[PRODUCTION VENDOR],
				[CUST. CODE & SHORT NAME],
				[CUST PO NO],
				[JOB NO],
				[ORIGINAL ITEM NO],
				[ASSORTED ITEM NO],
				[VENDOR COLOR CODE],
				[PACKING(UM / INNER / OUTER / CFT)],
				[ORDER QUANTITY],
				[BOM ITEM NO],
				[PER QTY OF BOM],
				[SHIP START DATE],
				[SHIP END DATE]
		FROM		#POR00007
		ORDER BY	[PRODUCTION VENDOR],[CUST. CODE & SHORT NAME],[JOB NO]	
	ELSE IF @RptType = 1 -- REPORT TYPE = BOM PO 
		SELECT		[BOM VENDOR NAME],
				[BOM PO NO],
				[CUST PO NO],
				[JOB NO],
				[BOM ITEM NO],
				[SUSTITUTE VENDOR ITEM NO],
				[BOM ENGLISH DESCRIPTION],
				[BOM CHINESE DESCRIPTION],
				[BOM VENDOR COLOR CODE],
				[BOM UM],
				[BOM ORDER QTY],
				[BOM CURRENCY],
				[BOM UNIT PRICE],
				[BOM TOTAL AMOUNT],
				[BOM SHIP START DATE],
				[BOM SHIP END DATE],
				[BOM REVISE DATE],
				[BOM UPDATE DATE / TIME]
		FROM		#POR00007
		ORDER BY	[BOM VENDOR NAME],[BOM PO NO],[BOM ITEM NO]
	ELSE --REPORT TYPE = BOTH
		SELECT		* 
		FROM		#POR00007
		ORDER BY	[PRODUCTION VENDOR],[CUST. CODE & SHORT NAME],[JOB NO]
end





GO
GRANT EXECUTE ON [dbo].[sp_select_POR00007] TO [ERPUSER] AS [dbo]
GO
