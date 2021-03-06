/****** Object:  StoredProcedure [dbo].[sp_select_LSP00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_LSP00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_LSP00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





--***********************************************************************************
--*Description	: Lower Selling Price Alert Report
--*Create Date	: 2003-10-08
--*Create By	: Marco Chan
--***********************************************************************************
/*
=====================================================================================
 Modification History                                    
=====================================================================================
Date		Name		Description
=====================================================================================
2003/10/14		Marco Chan	Reconfirm with Anita Leung, the report should according 
				to the Production Vendor View rather than Design Vendor 
				View for getting the result.
2004/02/16		Marco Chan	Fix for MU_SELPRC cannot > 1000 problem
2005-04-06	Lester Wu		replace ALL with UC-G, exclud MS company data from UC-G, retrieve company name from database
=========================================================     
Test Script
=========================================================
sp_select_LSP00001 	'', 
			'', '', 
			'', '', 
			'', '', 
			'', '', 
			'', '', 
			'A', 
			'',
			'A',
			'S'
*/

CREATE PROCEDURE [dbo].[sp_select_LSP00001]

@Cocde nvarchar(6),
@LstUpdFm datetime,
@LstUpdTo datetime,
@CUFm nvarchar(6),
@CUTo nvarchar(6),
@POVenFm nvarchar(20),
@POVenTo nvarchar(20),
@VenTypFm nvarchar(20),
@VenTypTo nvarchar(20),
@ItmFm nvarchar(20),
@ItmTo nvarchar(20),
@ShipItem nvarchar(1),
@Sort nvarchar(20),
@RptTyp nvarchar(1), 
@RptFmt nvarchar(1)

AS

declare 
@OptLstUpd nvarchar(1),
@OptCu nvarchar(1),
@OptItm nvarchar(1),
@OptPOVen nvarchar(1),
@OptVenTyp nvarchar(1)

if @LstUpdFm = ''
   set @OptLstUpd = 'N'
else
begin
   set @OptLstUpd = 'Y'
end

if @CUFm = ''
   set @OptCU = 'N'
else
   set @OptCU = 'Y'

if @POVenFm = ''
   set @OptPOVen = 'N'
else
   set @OptPOVen = 'Y'

if @VenTypFm = ''
   set @OptVenTyp = 'N'
else
   set @OptVenTyp = 'Y'

if @ItmFm = ''
   set @OptItm = 'N'
else
   set @OptItm = 'Y'

if @ShipItem = ''
   set @ShipItem = 'A' -- default all item

if @RptTyp = ''
   set @RptTyp = 'N' -- default New Item only

if @RptTyp = ''
   set @RptFmt = 'S' -- default Standard Report Format (Cystral Report)


declare @rptdate datetime

set @rptdate = getdate()

-- create temp table for result set
select * into #TEMP_RESULT from SCRLSP where 1 = 0

--Lester Wu , 2005-04-06 retrieve company name from database
declare @compName varchar(100)
select @compName = yco_conam from sycominf(nolock) where yco_cocde = @cocde
if @cocde<>'MS'
begin
	set @compName = 'UCPPC & UCP INT''L'
end
------------------------------------------------------------------------------


SELECT SOH_CUS1NO, CBI_CUSSNA, POD_JOBORD,
--	modified at 2003/10/14 begin
--	IVI_VENNO, IVI_VENITM, VBI_VENTYP, IBI_CATLVL3,
	SOD_VENITM, VBI_VENTYP, IBI_CATLVL3,
--	modified at 2003/10/14 end
	SOH_ISSDAT, SOD_ONEPRC, SOD_CURCDE, SOD_NETUNTPRC, SOD_ITMPRC,  SOD_VENNO, SOD_PURORD, SOD_SHPQTY, 
	SOD_COCDE, SOD_ORDNO, SOD_ORDSEQ, SOD_ITMNO, SOD_ITMSTS, SOD_ITMDSC, SOD_COLCDE, SOD_PCKSEQ, SOD_PCKUNT, 
	SOD_INRCTN, SOD_MTRCTN, SOD_CFT, SOD_QUTNO, SOD_ORDQTY, SOD_FCURCDE, SOD_FTYPRC,
	SOD_CREDAT, SOD_UPDDAT
	INTO #SOD_1
FROM SCORDHDR (NOLOCK)
LEFT JOIN SCORDDTL (NOLOCK) ON SOD_ORDNO = SOH_ORDNO 
LEFT JOIN POORDDTL (NOLOCK) ON POD_PURORD = SOD_PURORD and POD_PURSEQ = SOD_PURSEQ  
-- For extracting the item category
LEFT JOIN IMBASINF (NOLOCK) ON IBI_ITMNO = SOD_ITMNO
-- Modified at 2003/10/14 begin
-- For extracting the DV vendor type
--LEFT JOIN IMVENINF (NOLOCK) ON IVI_ITMNO = SOD_ITMNO AND IVI_DEF = 'Y'	-- 6168 ?
--LEFT JOIN VNBASINF (NOLOCK) ON VBI_VENNO = IVI_VENNO
LEFT JOIN VNBASINF (NOLOCK) ON VBI_VENNO = SOD_VENNO
-- Modified at 2003/10/14 end
LEFT JOIN CUBASINF (NOLOCK) ON SOH_CUS1NO = CBI_CUSNO
WHERE -- Neglect CANCEL, CLOSE order
	SOH_ORDSTS NOT IN ('CAN', 'CLO') 	-- 6,054 out of 6168
--	AND CONVERT (CHAR(10), SOH_ISSDAT, 111) >= '2003/08/11'	-- 6,148	vs 6168
--	AND CONVERT (CHAR(10), SOD_UPDDAT, 111) >= '2003/08/11'	-- 6,148	vs 6168
--	AND SOD_SHPQTY = 0
ORDER BY SOD_COCDE, SOD_ORDNO, SOD_ITMNO
-- SELECT * FROM #SOD_1

-- Fix for MU_SELPRC cannot > 1000 problem at 20040216
declare @tempnumeric134 numeric(13,4)
set @tempnumeric134 = 0.0

--== Fill up Markup Information. ==--
-- For getting the customer markup by  cust. no. & vendor type & CATLVL3 > NULL
SELECT SOH_CUS1NO, CBI_CUSSNA, POD_JOBORD,
--	modified at 2003/10/14 begin
--	IVI_VENNO, IVI_VENITM, VBI_VENTYP, IBI_CATLVL3, CCM_MARKUP, YFI_FML, [MU_SELPRC] = 0 * 1.000 ,
	SOD_VENITM, VBI_VENTYP, IBI_CATLVL3, CCM_MARKUP, YFI_FML, [MU_SELPRC] = @tempnumeric134 ,
--	modified at 2003/10/14 end
	SOH_ISSDAT, SOD_ONEPRC, SOD_CURCDE, SOD_NETUNTPRC, SOD_ITMPRC,  SOD_VENNO, SOD_PURORD, SOD_SHPQTY, 
	SOD_COCDE, SOD_ORDNO, SOD_ORDSEQ, SOD_ITMNO, SOD_ITMSTS, SOD_ITMDSC, SOD_COLCDE, SOD_PCKSEQ, SOD_PCKUNT, 
	SOD_INRCTN, SOD_MTRCTN, SOD_CFT, SOD_QUTNO, SOD_ORDQTY, SOD_FCURCDE, SOD_FTYPRC,
	SOD_CREDAT, SOD_UPDDAT
	INTO #SOD_2
	FROM #SOD_1
LEFT JOIN CUMCAMRK ON CCM_CUSNO = SOH_CUS1NO AND CCM_VENTYP = VBI_VENTYP AND CCM_CAT = IBI_CATLVL3
LEFT JOIN SYFMLINF ON YFI_FMLOPT = CCM_MARKUP
/*
-- Check # of record w/ & w/o CATLVL3
SELECT * FROM #SOD_2 WHERE MARKUP IS NOT NULL	--   319
SELECT * FROM #SOD_2 WHERE MARKUP IS NULL		-- 5829
*/

-- For getting the customer markup by  cust. no. & vendor type & CATLVL3 = NULL
UPDATE #SOD_2 SET #SOD_2.CCM_MARKUP = ccm.CCM_MARKUP, #SOD_2.YFI_FML = yfi.YFI_FML
	FROM #SOD_2
LEFT JOIN CUMCAMRK ccm ON ccm.CCM_CUSNO = #SOD_2.SOH_CUS1NO AND ccm.CCM_VENTYP = #SOD_2.VBI_VENTYP AND ccm.CCM_CAT = 'STANDARD'
LEFT JOIN SYFMLINF yfi ON yfi.YFI_FMLOPT = ccm.CCM_MARKUP
WHERE #SOD_2.CCM_MARKUP  IS NULL		-- 5829 vs 5735
-- SELECT * FROM #SOD_2

-- For UCP, filter whether selling price is lower than 5% of (BP * MU)
-- For UCPP, filter whether selling price is lower than BP or selling price is lower than 5% of (BP * MU)
SELECT * INTO #LESSBP FROM #SOD_2
/*
SELECT DISTINCT LEN(FML) FROM #LESSBP
SELECT * FROM #LESSBP WHERE LEN(FML) = 2 	-- (e.g.'*1')		404
SELECT * FROM #LESSBP WHERE LEN(FML) = 5	-- (e.g '/0.95')	4105
SELECT * FROM #LESSBP WHERE LEN(FML) = 10	-- (e.g '/0.88/0.96')	1639
SELECT * FROM #LESSBP WHERE MU_SELPRC = 0 	 -- AND  LEN(FML) IN ( 2  , 5 )
*/

UPDATE #LESSBP SET MU_SELPRC = SOD_ITMPRC WHERE LEN(#LESSBP.YFI_FML) = 2	-- 404
UPDATE #LESSBP SET MU_SELPRC = (SOD_ITMPRC * (RIGHT (#LESSBP.YFI_FML, 4)) ) WHERE LEN(#LESSBP.YFI_FML) = 5 AND LEFT (#LESSBP.YFI_FML, 1) = '*'	-- 79
UPDATE #LESSBP SET MU_SELPRC = (SOD_ITMPRC / (RIGHT (#LESSBP.YFI_FML, 4)) ) WHERE LEN(#LESSBP.YFI_FML) = 5 AND LEFT (#LESSBP.YFI_FML, 1) = '/'	-- 4026	vs 4029
UPDATE #LESSBP SET MU_SELPRC = (SOD_ITMPRC / (SUBSTRING (#LESSBP.YFI_FML, 2, 4)) / (SUBSTRING (#LESSBP.YFI_FML, 7, 4)) ) WHERE LEN(#LESSBP.YFI_FML) = 10 AND LEFT (#LESSBP.YFI_FML, 1) = '/' AND SUBSTRING (#LESSBP.YFI_FML, 6, 1) = '/'	-- 1639	vs 1656
UPDATE #LESSBP SET MU_SELPRC = (SOD_ITMPRC / (SUBSTRING (#LESSBP.YFI_FML, 2, 4)) * (SUBSTRING (#LESSBP.YFI_FML, 7, 4)) ) WHERE LEN(#LESSBP.YFI_FML) = 10 AND LEFT (#LESSBP.YFI_FML, 1) = '/' AND SUBSTRING (#LESSBP.YFI_FML, 6, 1) = '*'	-- 0
UPDATE #LESSBP SET MU_SELPRC = (SOD_ITMPRC * (SUBSTRING (#LESSBP.YFI_FML, 2, 4)) / (SUBSTRING (#LESSBP.YFI_FML, 7, 4)) ) WHERE LEN(#LESSBP.YFI_FML) = 10 AND LEFT (#LESSBP.YFI_FML, 1) = '*' AND SUBSTRING (#LESSBP.YFI_FML, 6, 1) = '/'	-- 0
UPDATE #LESSBP SET MU_SELPRC = (SOD_ITMPRC * (SUBSTRING (#LESSBP.YFI_FML, 2, 4)) * (SUBSTRING (#LESSBP.YFI_FML, 7, 4)) ) WHERE LEN(#LESSBP.YFI_FML) = 10 AND LEFT (#LESSBP.YFI_FML, 1) = '*' AND SUBSTRING (#LESSBP.YFI_FML, 6, 1) = '*'	-- 0

/* Current Selection Result */
insert into #TEMP_RESULT
SELECT  
@rptdate,
soh_issdat,
soh_cus1no,
cbi_cussna,
pod_jobord,
sod_cocde,
sod_ordno,
sod_ordseq,
sod_itmno,
sod_itmsts,
sod_itmdsc,
sod_colcde,
sod_pckseq,
sod_pckunt,
sod_inrctn,
sod_mtrctn,
sod_cft,
sod_qutno,
sod_ordqty,
sod_oneprc,
sod_curcde,
sod_netuntprc,
sod_itmprc,
sod_shpqty,
sod_venno,
sod_purord,
sod_fcurcde,
sod_ftyprc,
vbi_ventyp,
--modified at 2003/10/14 begin
--ivi_venno,
--ivi_venitm,
sod_venitm,
--modified at 2003/10/14 end
ibi_catlvl3,
ccm_markup,
yfi_fml,
mu_selprc,
sod_credat,
sod_upddat
FROM #LESSBP	-- Result = 156	vs 173
WHERE 	(
	(SOD_NETUNTPRC < SOD_ITMPRC AND VBI_VENTYP <> 'E') 	-- 80
	OR
	SOD_NETUNTPRC < MU_SELPRC * 0.95	-- 142
	)
	AND SOD_NETUNTPRC <> 0	-- All = 0
	AND SOD_PURORD > ' '
	AND CONVERT (CHAR(10), SOD_CREDAT, 111) >= '2003/10/01'	-- 6,148	vs 6168
--	AND CONVERT (CHAR(10), SOH_ISSDAT, 111) < '2003/08/11'	-- 6,148	vs 6168
--	AND VBI_VENTYP <> 'E'
--	AND DV <> SOD_VENNO
	and
	(@OptLstUpd = 'N' or (sod_upddat between @LstUpdFm and @LstUpdTo)) and
	(@OptCu = 'N' or (soh_cus1no between @CUFm and @CUTo)) and
	(@OptPOVen = 'N' or (sod_venno between @POVenFm and @POVenTo)) and
	(@OptVenTyp = 'N' or (vbi_ventyp between @VenTypFm and @VenTypTo)) and
	(@OptItm = 'N' or (sod_itmno between @ItmFm and @ItmTo)) and
	((@ShipItem = 'A') or 
         (@ShipItem = 'S' and sod_shpqty <> 0) or 
         (@ShipItem = 'N' and sod_shpqty = 0))

-- RptTyp (N new / A all)
if @RptTyp = 'A' 
begin
	delete from SCRLSP
end
else
begin

	/* delete item for displayed previously */
	delete #TEMP_RESULT from #TEMP_RESULT tmp, SCRLSP his
	where 
		tmp.soh_issdat = his.soh_issdat and
		tmp.soh_cus1no = his.soh_cus1no and
		tmp.cbi_cussna = his.cbi_cussna and
		tmp.pod_jobord = his.pod_jobord and
		tmp.sod_cocde = his.sod_cocde and
		tmp.sod_ordno = his.sod_ordno and
		tmp.sod_ordseq = his.sod_ordseq and
		tmp.sod_itmno = his.sod_itmno and
		tmp.sod_itmsts = his.sod_itmsts and
		tmp.sod_itmdsc = his.sod_itmdsc and
		tmp.sod_colcde = his.sod_colcde and
		tmp.sod_pckseq = his.sod_pckseq and
		tmp.sod_pckunt = his.sod_pckunt and
		tmp.sod_inrctn = his.sod_inrctn and
		tmp.sod_mtrctn = his.sod_mtrctn and
		tmp.sod_cft = his.sod_cft and
		tmp.sod_qutno = his.sod_qutno and
		tmp.sod_ordqty = his.sod_ordqty and
		tmp.sod_oneprc = his.sod_oneprc and
		tmp.sod_curcde = his.sod_curcde and
		tmp.sod_netuntprc = his.sod_netuntprc and
		tmp.sod_itmprc = his.sod_itmprc and
		tmp.sod_shpqty = his.sod_shpqty and
		tmp.sod_venno = his.sod_venno and
		tmp.sod_purord = his.sod_purord and
		tmp.sod_fcurcde = his.sod_fcurcde and
		tmp.sod_ftyprc = his.sod_ftyprc and
		tmp.vbi_ventyp = his.vbi_ventyp and
--		modified at 2003/10/14 begin
--		tmp.ivi_venno = his.ivi_venno and
--		tmp.ivi_venitm = his.ivi_venitm and
		tmp.sod_venitm = his.sod_venitm and
--		modified at 2003/10/14 end
		tmp.ibi_catlvl3 = his.ibi_catlvl3 and
		tmp.ccm_markup = his.ccm_markup and
		tmp.yfi_fml = his.yfi_fml and
		tmp.mu_selprc = his.mu_selprc and
		tmp.sod_credat = his.sod_credat and
		tmp.sod_upddat = his.sod_upddat

	/* delete item with modification in SCRLSP*/
	delete SCRLSP
	from SCRLSP org, #TEMP_RESULT curr
	where
	org.sod_cocde = curr.sod_cocde and
	org.sod_ordno = curr.sod_ordno and
	org.sod_ordseq = curr.sod_ordseq and
	org.sod_itmno = curr.sod_itmno and
	org.sod_colcde = curr.sod_colcde and
	org.sod_pckseq = curr.sod_pckseq and
	org.sod_pckunt = curr.sod_pckunt and
	org.sod_inrctn = curr.sod_inrctn and
	org.sod_mtrctn = curr.sod_mtrctn
end

/* Insert report into table */
insert into SCRLSP
select * from #TEMP_RESULT

-- RptFmt (E Excel / S Standard cystral report)
if @RptFmt = 'E'
begin
	select 
	cbi_cussna 'Customer Short Name',
	case vbi_ventyp when 'E' then sod_ordno
			else pod_jobord end 'Job / SC Number',
	sod_itmno 'Item Number',
--	modified at 2003/10/14 begin
--	ivi_venitm 'Vendor Item Number',
	sod_venitm 'Vendor Item Number',
-- 	modified at 2003/10/14 end
	sod_venno 'Production Vendor',
	sod_itmdsc 'Item Description',
	sod_pckunt+'('+convert(varchar(10),sod_inrctn)+'/'+convert(varchar(10),sod_mtrctn)+'/'+convert(varchar(10),sod_cft)+')' 'Packing U/M',
	sod_ordqty 'Order Qty',
	sod_curcde 'Currency',
	sod_itmprc 'Basic Price',
	mu_selprc 'Standard Price',
	sod_netuntprc 'Net Selling Price',
	round(((mu_selprc - sod_netuntprc) / mu_selprc) * 100.0,2) 'Difference(%)',
	sod_fcurcde 'Fty Currency',
	sod_ftyprc 'Total Cost' 
	--,@compName as 'compName'
	from #TEMP_RESULT
	order by vbi_ventyp, sod_venno, sod_itmno
	--order by sod_upddat
	--order by soh_issdat
end
else
begin
	select 
	@LstUpdFm 'input_lstupddatfm',
	@LstUpdTo 'input_lstupddatto',
	@CUFm 'input_cusnofm',
	@CUTo 'input_cusnoto',
	@POVenFm 'input_povencdefm',
	@POVenTo 'input_povencdeto',
	@VenTypFm 'input_ventypfm',
	@VenTypTo 'input_ventypto',
	@ItmFm 'input_itmnofm',
	@ItmTo 'input_itmnoto',
	@ShipItem 'input_filter',
	@Sort 'input_sortby',
	convert(varchar(20), soh_issdat, 111) 'soh_issdat',
	soh_cus1no,
	cbi_cussna,
	pod_jobord,
	sod_cocde,
	sod_ordno,
	sod_ordseq,
	sod_itmno,
	sod_itmsts,
	sod_itmdsc,
	sod_colcde,
	sod_pckunt,
	sod_inrctn,
	sod_mtrctn,
	sod_cft,
	sod_qutno,
	sod_ordqty,
	sod_oneprc,
	sod_curcde,
	sod_netuntprc,
	sod_itmprc,
	sod_shpqty,
	sod_venno,
	sod_purord,
	sod_fcurcde,
	sod_ftyprc,
	vbi_ventyp,
--	modified at 2003/10/14 begin
--	ivi_venno,
--	ivi_venitm,
	sod_venitm,
--	modified at 2003/10/14 end
	ibi_catlvl3,
	ccm_markup,
	yfi_fml,
	mu_selprc,
	sod_credat,
	convert(varchar(20),sod_upddat, 111) 'sod_upddat'
	,@compName as 'compName'
	from #TEMP_RESULT
	order by vbi_ventyp, sod_venno, sod_itmno
	--order by sod_upddat
	--order by soh_issdat
end






GO
GRANT EXECUTE ON [dbo].[sp_select_LSP00001] TO [ERPUSER] AS [dbo]
GO
