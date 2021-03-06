/****** Object:  StoredProcedure [dbo].[sp_IMR00009]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_IMR00009]
GO
/****** Object:  StoredProcedure [dbo].[sp_IMR00009]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Kath Ng     
Date:		21st January, 2001
Report ID:	IMR00009
Description:	Document Report For Label
************************************************************************/

CREATE PROCEDURE [dbo].[sp_IMR00009] 
                                                                                                                                                                                                                                                                 
@gsCompany	nvarchar(8),
@FromJobno	nvarchar(20),
@ToJobno	nvarchar(20)

 
AS

BEGIN
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Select	
	@gsCompany,
	@FromJobno,
	@ToJobno,
	hdr.poh_venno,
	dtl.pod_jobord,
	dtl.pod_cusitm, 
	dtl.pod_venitm, 
	dtl.pod_cussku,
	dtl.pod_engdsc,
	dtl.pod_cuscol,
	dtl.pod_coldsc,
	dtl.pod_dept,
	dtl.pod_cususd, 
	dtl.pod_cuscad,
	dtl.pod_inrctn,
	dtl.pod_mtrctn,
	dtl.pod_code1, 
	dtl.pod_ordqty,
	dtl.pod_code2, 
	case dtl.pod_inrctn when 0 then 0 else dtl.pod_ordqty / dtl.pod_inrctn end,
	dtl.pod_code3, 
	case dtl.pod_mtrctn when 0 then 0 else dtl.pod_ordqty / dtl.pod_mtrctn end,
	ven.vbi_vennam,
	hdr.poh_lbldue

From	POORDHDR hdr
left join POORDDTL dtl on hdr.poh_cocde = dtl.pod_cocde and hdr.poh_purord = dtl.pod_purord
left join VNBASINF ven on hdr.poh_lblven = ven.vbi_venno
Where 	
dtl.pod_scno between @FromJobno and @ToJobno and dtl.pod_cocde = @gsCompany

order by	hdr.poh_venno,dtl.pod_scno, dtl.pod_cusitm

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
END






GO
GRANT EXECUTE ON [dbo].[sp_IMR00009] TO [ERPUSER] AS [dbo]
GO
