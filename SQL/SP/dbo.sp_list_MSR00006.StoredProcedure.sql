/****** Object:  StoredProcedure [dbo].[sp_list_MSR00006]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_MSR00006]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_MSR00006]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/***********************************************************************************************************************************************
Modification History
************************************************************************************************************************************************
Modified by		Modified on		Description
************************************************************************************************************************************************
Lester Wu			2005-04-02		replace ALL with UC-G, exclude MS from UC-G, retrieve company name from database
************************************************************************************************************************************************/


-- Checked By Allan Yuen at 27/07/2003


CREATE  PROCEDURE [dbo].[sp_list_MSR00006]

@cocde		nvarchar(6),
@opt1Fm		nvarchar(30),	-- Job No.
@opt1To		nvarchar(30),
@opt2Fm		nvarchar(30),	-- Item No.
@opt2To		nvarchar(30),
@opt3Fm		nvarchar(20),	-- Cust No.
@opt3To		nvarchar(20),
@opt4Fm		nvarchar(30),	-- PO
@opt4To		nvarchar(30),
@opt5Fm		nvarchar(30),	-- SC Issue Date
@opt5To		nvarchar(30),
@opt6Fm		nvarchar(30),	-- SC
@opt6To		nvarchar(30),
@opt7Fm		nvarchar(30),	-- SC
@opt7To		nvarchar(30),
@optPrintOutQty	nvarchar(1),	-- Print Out Qty	
@optPrintUPrc	nvarchar(1),	-- Print Unit Price
@optPrintPO	nvarchar(1),
@creusr 		nvarchar(30)


AS


DECLARE
@opt1	nvarchar(1),
@opt2	nvarchar(1),
@opt3	nvarchar(1),
@opt4	nvarchar(1),
@opt5	nvarchar(1),
@opt6	nvarchar(1),
@opt7	nvarchar(1)

SET @opt1 = 'N'
If @opt1Fm <> '' and @opt1To <> ''
begin
	SET @opt1 = 'Y'
end

SET @opt2 = 'N'
If @opt2Fm <> '' and @opt2To <> ''
begin
	SET @opt2 = 'Y'
end

SET @opt3 = 'N'
If @opt3Fm <> '' and @opt3To <> ''
begin
	SET @opt3 = 'Y'
end

SET @opt4 = 'N'
If @opt4Fm <> '' and @opt4To <> ''
begin
	SET @opt4 = 'Y'
end

SET @opt5 = 'N'
If @opt5Fm <> '' and @opt5To <> ''
begin
	SET @opt5 = 'Y'
end

if @opt5Fm = '' and @opt5To <> '' 
begin
    set @opt5Fm = '01/01/1900'
    SET @opt5 = 'Y'
end

if @opt5Fm <> '' and @opt5To = '' 
begin
    set @opt5to = '01/01/2099'
    SET @opt5 = 'Y'
end

SET @opt6 = 'N'
If @opt6Fm <> '' and @opt6To <> ''
begin
	SET @opt6 = 'Y'
end

SET @opt7 = 'N'
If @opt7Fm <> '' and @opt7To <> ''
begin
	SET @opt7 = 'Y'
end



--Lester Wu 2005-04-02, retrieve company name from database----------------------------------------
declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde<>'UC-G'
begin
	select @compName = yco_conam from sycominf where yco_cocde = @cocde
end
---------------------------------------------------------------------------------------------------------------------


IF @optPrintOutQty  = 'N' 
BEGIN

SELECT	
	soh_cocde,
	sod_ordno,
	sod_ordseq,
	soh_cus1no = cbi_cussna + ' (' + soh_cus1no + ')',	
	 sod_cuspo = case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,
	sod_curcde,
	ordamt = sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,		
	hid_invno= isnull(hid_invno,''),
	hiv_invdat=isnull(hiv_invdat,''),
	
	sum_shpqty = sum(isnull(hid_shpqty,0)),
	sum_ttlamt = sum(isnull(hid_ttlamt,0)),
	-- 2004/02/13 Lester Wu
	@cocde,
	------------------------------
	@opt1Fm,	@opt1To,
	@opt2Fm,	@opt2To,		
	@opt3Fm,	@opt3To,
	@opt4Fm,	@opt4To,
	@opt5Fm,	@opt5To,
	@opt6Fm,	@opt6To,
	@opt7Fm,	@opt7To,
	@optPrintOutQty,	@optPrintUPrc, @optPrintPO,
	@compName as 'compName'


from 	POORDHDR, SCORDDTL, SCORDHDR, CUBASINF, SYSETINF,POORDDTL
left join  SHIPGDTL on pod_cocde = hid_cocde and pod_scno = hid_ordno and pod_scline = hid_ordseq and  pod_purord = hid_purord and pod_purseq = hid_purseq
left join  SHIPGHDR on pod_cocde = hih_cocde and hid_shpno = hih_shpno 
left join  SHINVHDR on pod_cocde = hiv_cocde and hid_invno = hiv_invno 


WHERE	
-- 2004/02/13 Lester Wu
--pod_cocde = @cocde and
--Lester Wu 2005-04-02, replace ALL with UC-G
--(@cocde='ALL' or poh_cocde=@cocde) and 
((@cocde='UC-G' and poh_cocde<>'MS') or poh_cocde=@cocde) and 
-------------------------------
pod_cocde = poh_cocde and pod_purord = poh_purord and
pod_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq and 
pod_cocde = soh_cocde and  pod_scno = soh_ordno and

--pod_cocde = cbi_cocde and soh_cus1no = cbi_cusno 
soh_cus1no = cbi_cusno 

AND	((@opt1 = 'Y' and pod_jobord >= @opt1Fm and pod_jobord <= @opt1To) or @opt1 = 'N')
AND	((@opt2 = 'Y' and sod_itmno >= @opt2Fm and sod_itmno <= @opt2To) or @opt2 = 'N')
AND	((@opt3 = 'Y' and soh_cus1no >= @opt3Fm  and soh_cus1no <=  @opt3To) or @opt3 = 'N')
AND	(
	  ((@opt4 = 'Y' and soh_cuspo >= @opt4Fm and soh_cuspo <= @opt4To) or @opt4 = 'N')
		or
  	  ((@opt4 = 'Y' and sod_cuspo >= @opt4Fm and sod_cuspo <= @opt4To) or @opt4 = 'N')
	)
AND	((@opt5 = 'Y' and soh_issdat >= rtrim(@opt5Fm) + ' 00:00:00' and soh_issdat <= rtrim(@opt5To) + ' 23:59:59' ) or @opt5 = 'N')
AND	((@opt6 = 'Y' and sod_ordno >= @opt6Fm  and sod_ordno <=  @opt6To) or @opt6 = 'N')
AND	((@opt7 = 'Y' and pod_purord >= @opt7Fm  and pod_purord <=  @opt7To) or @opt7 = 'N')


AND 	 sod_ordqty > 0 AND sod_ordqty - sod_shpqty > 0


--AND	ysi_cocde = @cocde and ysi_typ = '05' and ysi_cde = pod_untcde
and 	ysi_typ = '05' and ysi_cde = pod_untcde

group by 	soh_cocde,
	sod_ordno,
	sod_ordseq,
	cbi_cussna + ' (' + soh_cus1no + ')',
	case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,	
	sod_curcde,
	sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,
	hid_invno,
	hiv_invdat

ORDER BY
	soh_cocde,
	sod_ordno,
	sod_ordseq,
	cbi_cussna + ' (' + soh_cus1no + ')',
	case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,
	sod_curcde,
                sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,
	hid_invno,
	hiv_invdat
END

ELSE IF  @optPrintOutQty  = 'Y' 

BEGIN


SELECT	
	soh_cocde,
	sod_ordno,
	sod_ordseq,
	soh_cus1no = cbi_cussna + ' (' + soh_cus1no + ')',	
	 sod_cuspo = case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,
	sod_curcde,
	ordamt = sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,		
	hid_invno= isnull(hid_invno,''),
	hiv_invdat=isnull(hiv_invdat,''),
	
	sum_shpqty = sum(isnull(hid_shpqty,0)),
	sum_ttlamt = sum(isnull(hid_ttlamt,0)),

	-- 2004/02/13 Lester Wu
	@cocde,
	------------------------------
	@opt1Fm,	@opt1To,
	@opt2Fm,	@opt2To,		
	@opt3Fm,	@opt3To,
	@opt4Fm,	@opt4To,
	@opt5Fm,	@opt5To,
	@opt6Fm,	@opt6To,
	@opt7Fm,	@opt7To,
	@optPrintOutQty,	@optPrintUPrc, @optPrintPO,
	@compName as 'compName'


from 	 POORDHDR, SCORDDTL, SCORDHDR, CUBASINF, SYSETINF,POORDDTL
left join  SHIPGDTL on pod_cocde = hid_cocde and pod_scno = hid_ordno and pod_scline = hid_ordseq and  pod_purord = hid_purord and pod_purseq = hid_purseq
left join  SHIPGHDR on pod_cocde = hih_cocde and hid_shpno = hih_shpno 
left join  SHINVHDR on pod_cocde = hiv_cocde and hid_invno = hiv_invno 



WHERE	
-- 2004/02/13 Lester Wu
--pod_cocde = @cocde and
--Lester Wu 2005-04-02, replace ALL with UC-G, exclude MS from UC-G
--(@cocde='ALL' or pod_cocde=@cocde) and
((@cocde='UC-G' and pod_cocde<>'MS') or pod_cocde=@cocde) and
--
pod_cocde = poh_cocde and pod_purord = poh_purord and
pod_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq and 
pod_cocde = soh_cocde and  pod_scno = soh_ordno and

--pod_cocde = cbi_cocde and soh_cus1no = cbi_cusno 
soh_cus1no = cbi_cusno 

AND	((@opt1 = 'Y' and pod_jobord >= @opt1Fm and pod_jobord <= @opt1To) or @opt1 = 'N')
AND	((@opt2 = 'Y' and sod_itmno >= @opt2Fm and sod_itmno <= @opt2To) or @opt2 = 'N')
AND	((@opt3 = 'Y' and soh_cus1no >= @opt3Fm  and soh_cus1no <=  @opt3To) or @opt3 = 'N')
AND	(
	  ((@opt4 = 'Y' and soh_cuspo >= @opt4Fm and soh_cuspo <= @opt4To) or @opt4 = 'N')
		or
  	  ((@opt4 = 'Y' and sod_cuspo >= @opt4Fm and sod_cuspo <= @opt4To) or @opt4 = 'N')
	)
AND	((@opt5 = 'Y' and soh_issdat >= rtrim(@opt5Fm) + ' 00:00:00' and soh_issdat <= rtrim(@opt5To) + ' 23:59:59' ) or @opt5 = 'N')
AND	((@opt6 = 'Y' and sod_ordno >= @opt6Fm  and sod_ordno <=  @opt6To) or @opt6 = 'N')
AND	((@opt7 = 'Y' and pod_purord >= @opt7Fm  and pod_purord <=  @opt7To) or @opt7 = 'N')

AND 	 sod_ordqty > 0
AND 	 sod_ordqty - sod_shpqty = 0


--AND	ysi_cocde = @cocde and ysi_typ = '05' and ysi_cde = pod_untcde
and 	ysi_typ = '05' and ysi_cde = pod_untcde

group by 	soh_cocde,
	sod_ordno,
	sod_ordseq,
	cbi_cussna + ' (' + soh_cus1no + ')',
	case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,	
	sod_curcde,
	sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,
	hid_invno,
	hiv_invdat

ORDER BY
	soh_cocde,
	sod_ordno,
	sod_ordseq,
	cbi_cussna + ' (' + soh_cus1no + ')',
	case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,
	sod_curcde,
                sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,
	hid_invno,
	hiv_invdat
END

ELSE IF  @optPrintOutQty  = 'B' 

BEGIN


SELECT	
	soh_cocde,
	sod_ordno,
	sod_ordseq,
	soh_cus1no = cbi_cussna + ' (' + soh_cus1no + ')',	
	 sod_cuspo = case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,
	sod_curcde,
	ordamt = sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,		
	hid_invno= isnull(hid_invno,''),
	hiv_invdat=isnull(hiv_invdat,''),
	
	sum_shpqty = sum(isnull(hid_shpqty,0)),
	sum_ttlamt = sum(isnull(hid_ttlamt,0)),
	-- 2004/02/13 Lester Wu
	@cocde,
	------------------------------
	@opt1Fm,	@opt1To,
	@opt2Fm,	@opt2To,		
	@opt3Fm,	@opt3To,
	@opt4Fm,	@opt4To,
	@opt5Fm,	@opt5To,
	@opt6Fm,	@opt6To,
	@opt7Fm,	@opt7To,
	@optPrintOutQty,	@optPrintUPrc, @optPrintPO,
	@compName as 'compName'


from 	POORDHDR, SCORDDTL, SCORDHDR, CUBASINF, SYSETINF,POORDDTL
left join  SHIPGDTL on pod_cocde = hid_cocde and pod_scno = hid_ordno and pod_scline = hid_ordseq and  pod_purord = hid_purord and pod_purseq = hid_purseq
left join  SHIPGHDR on pod_cocde = hih_cocde and hid_shpno = hih_shpno 
left join  SHINVHDR on pod_cocde = hiv_cocde and hid_invno = hiv_invno 


WHERE	
-- 2004/02/13 Lester Wu
--pod_cocde = @cocde and
--Lester Wu 2005-04-02, replace ALL with UC-G
--(@cocde='ALL' or pod_cocde=@cocde) and 
((@cocde='UC-G' and pod_cocde<>'MS') or pod_cocde=@cocde) and
--------------------------------
pod_cocde = poh_cocde and pod_purord = poh_purord and
pod_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq and 
pod_cocde = soh_cocde and  pod_scno = soh_ordno and
--pod_cocde = cbi_cocde and soh_cus1no = cbi_cusno 
soh_cus1no = cbi_cusno 


AND	((@opt1 = 'Y' and pod_jobord >= @opt1Fm and pod_jobord <= @opt1To) or @opt1 = 'N')
AND	((@opt2 = 'Y' and sod_itmno >= @opt2Fm and sod_itmno <= @opt2To) or @opt2 = 'N')
AND	((@opt3 = 'Y' and soh_cus1no >= @opt3Fm  and soh_cus1no <=  @opt3To) or @opt3 = 'N')
AND	(
	  ((@opt4 = 'Y' and soh_cuspo >= @opt4Fm and soh_cuspo <= @opt4To) or @opt4 = 'N')
		or
  	  ((@opt4 = 'Y' and sod_cuspo >= @opt4Fm and sod_cuspo <= @opt4To) or @opt4 = 'N')
	)
AND	((@opt5 = 'Y' and soh_issdat >= rtrim(@opt5Fm) + ' 00:00:00' and soh_issdat <= rtrim(@opt5To) + ' 23:59:59' ) or @opt5 = 'N')
AND	((@opt6 = 'Y' and sod_ordno >= @opt6Fm  and sod_ordno <=  @opt6To) or @opt6 = 'N')
AND	((@opt7 = 'Y' and pod_purord >= @opt7Fm  and pod_purord <=  @opt7To) or @opt7 = 'N')

AND 	 sod_ordqty > 0
--AND 	 sod_ordqty > 0 AND sod_ordqty - sod_shpqty > 0


--AND	ysi_cocde = @cocde and ysi_typ = '05' and ysi_cde = pod_untcde
and 	ysi_typ = '05' and ysi_cde = pod_untcde

group by 	soh_cocde,
	sod_ordno,
	sod_ordseq,
	cbi_cussna + ' (' + soh_cus1no + ')',
	case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,	
	sod_curcde,
	sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,
	hid_invno,
	hiv_invdat

ORDER BY
	soh_cocde,
	sod_ordno,
	sod_ordseq,
	cbi_cussna + ' (' + soh_cus1no + ')',
	case sod_cuspo when '' then soh_cuspo else sod_cuspo end,
	pod_purord,
	pod_jobord,
	sod_itmno,
	sod_cusitm,
	sod_shpstr,
	sod_ordqty,
	sod_curcde,
                sod_ordqty * sod_untprc,
	ysi_dsc,
	sod_untprc,
	hid_invno,
	hiv_invdat
END





GO
GRANT EXECUTE ON [dbo].[sp_list_MSR00006] TO [ERPUSER] AS [dbo]
GO
