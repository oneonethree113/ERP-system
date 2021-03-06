/****** Object:  StoredProcedure [dbo].[sp_list_POORDDTL_SHM00001_1]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_POORDDTL_SHM00001_1]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_POORDDTL_SHM00001_1]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






















-- Checked by Allan Yuen at 27/07/2002


/************************************************************************
Author:		Johnson Lai
Date:		14th Jan, 2002
Description:	Select data FromPOORDDTL (Cross check with customer)
Parameter:	1. Company
		2. Pri Customer
		3. Sec Customer
		4. JOB No.
***********************************************************************
20 Aug 2003 	Allan Yuen		Fix Deadlock Problem.
2004-01-28	Marco Chan	Add for getting netuntprc from SC
2005-02-01	Lester Wu		Add Missing field (sod_netuntprc)
2005-09-12	Lester Wu		Show show name of P.V. fand C.V.
*/
------------------------------------------------- 
CREATE            procedure [dbo].[sp_list_POORDDTL_SHM00001_1]

@pod_cocde	nvarchar(6),
@pod_jobord	nvarchar(20)
  
AS

DECLARE @CUSPO AS nvarchar(50)

select 
	@CUSPO = sod_cuspo 
from 
	SCORDDTL (nolock)
	inner join SCORDHDR (nolock) on 
		sod_cocde = soh_cocde and 
		sod_ordno = soh_ordno
	inner join POORDDTL (nolock) on 
		sod_cocde = pod_cocde and 
		sod_ordno=pod_scno and 
		sod_ordseq = pod_scline
where 
	pod_cocde = @pod_cocde and
        pod_jobord = @pod_jobord
--**********************************************************************************************


-------------------------------
Create table  #tlt_cov_qty(tlt_covseq int , hid_cocde nvarchar(20), hid_ordno nvarchar(20), hid_ordseq nvarchar(20))


	--michael 20170421 
	
	INSERT INTO #tlt_cov_qty 
	SELECT sum(hid_shpqty),sod_cocde,sod_ordno,sod_ordseq
	FROM SCORDDTL
	left join SHIPGDTL_COV (nolock) on
		sod_cocde = hid_cocde and
		sod_ordno = hid_ordno and
		sod_ordseq = hid_ordseq
	group by sod_cocde,sod_ordno,sod_ordseq
------------------------------
if @CUSPO is null or @CUSPO = ''  

BEGIN

Select 

sod_ordno, 
sod_ordseq, 
isnull(soh_cuspo,'') as 'sod_cuspo',
sod_itmno, 
sod_itmtyp,
sod_itmdsc,
sod_cusitm,
sod_colcde,
sod_cuscol,
sod_coldsc,
sod_pckunt,
sod_inrctn,
sod_mtrctn,
sod_mtrdcm,
sod_mtrwcm,
sod_mtrhcm,
sod_cbm,
--sod_ordqty - sod_shpqty as 'sod_shpqty',
0 as 'sod_shpqty',
sod_ordqty - sod_shpqty - ISNULL(#tlt_cov_qty.tlt_covseq,0) as 'sod_outqty',
--sod_ordqty  as 'sod_outqty',
-----------------------------------------------------------------------------------
--2005-09-12 Lester Wu,  Show show name of P.V. fand C.V.
--sod_venno,
--sod_cusven,
sod_venno + case isnull(pv.vbi_vensna,'') when '' then '' else ' - ' + pv.vbi_vensna end as 'sod_venno' , 
sod_cusven + case isnull(cv.vbi_vensna,'') when '' then '' else ' - ' + cv.vbi_vensna end as 'sod_cusven' , 
-----------------------------------------------------------------------------------
cast(sod_colcde as nvarchar(30)) + ' / ' + 
cast(sod_pckunt as nvarchar(6)) + ' / ' + 
cast(sod_inrctn as nvarchar(10)) + ' / ' + 
cast(sod_mtrctn as nvarchar(10)) + ' / ' + 
cast(sod_cft as nvarchar(10)) + ' / ' + 
cast(sod_cbm as nvarchar(10)) + ' / ' + 
cast(sod_ftyprctrm as nvarchar(10)) + ' / ' + 
cast(sod_hkprctrm as nvarchar(10)) + ' / ' + 
cast(sod_trantrm as nvarchar(10)) as 'sod_colpck',
isnull(soh_cus1no,'') as 'soh_cus1no',
isnull(soh_cus2no,'') as 'soh_cus2no',
isnull(soh_prctrm,'') as 'soh_prctrm',
isnull(soh_paytrm,'') as 'soh_paytrm',
isnull(pod_jobord,'') as 'pod_jobord',
isnull(pod_purord,'') as 'pod_purord',
isnull(pod_purseq,0) as 'pod_purseq',
isnull(pv.vbi_vennam,'') as 'vbi_vennam',
sod_untprc,
sod_netuntprc,
isnull(soh_ordsts,'') as 'soh_ordsts',
isnull(poh_pursts,'') as 'poh_pursts',
--Added by Mark Lau 20060929
isnull(sod_alsitmno,'') as 'sod_alsitmno',
isnull(sod_alscolcde,'') as 'sod_alscolcde' , 
isnull(sod_conftr,1) as 'sod_conftr' , 
isnull(sod_contopc,'') as 'sod_contopc' , 
isnull(sod_pcprc,0) as 'sod_pcprc',
--Added by Mark Lau 20080611
isnull(sod_custum,'') as 'sod_custum',
-- Added by Mark Lau 20090515
isnull(sod_cusstyno,'') as 'sod_cusstyno',
case sod_resppo when '' then soh_resppo else sod_resppo end as 'sod_resppo',
isnull(sod_cussku,'') as 'sod_cussku',
soh_rplmnt as 'soh_rplmnt',
isnull(ssm_engdsc,'') as 'ssm_engdsc',
isnull(sod_examven,'') +' - '+ isnull(cv.vbi_vennam,'')  as 'sod_examven',
		isnull(sod_covqty,'0') as 'sod_covqty',
		isnull(sod_name_f1,'') as 'sod_name_f1',
		isnull(sod_dsc_f1,'') as 'sod_dsc_f1',
		isnull(sod_name_f2,'') as 'sod_name_f2',
		isnull(sod_dsc_f2,'') as 'sod_dsc_f2',
		isnull(sod_name_f3,'') as 'sod_name_f3',
		isnull(sod_dsc_f3,'') as 'sod_dsc_f3'

from 
	SCORDDTL (nolock)
	inner join SCORDHDR (nolock) on 
		sod_cocde = soh_cocde and 
		sod_ordno = soh_ordno
	inner join POORDDTL (nolock) on 
		sod_cocde = pod_cocde and 
		sod_ordno=pod_scno and 
		sod_ordseq = pod_scline

left join SCSHPMRK  (nolock) on  soh_cocde = ssm_cocde and soh_ordno=ssm_ordno and ssm_shptyp = 'M'
	left join POORDHDR (nolock) on 
		sod_cocde = poh_cocde and 
		pod_purord = poh_purord 
-- Lester Wu 2005-09-12, show vendor short name of C.V and P.V
--	inner join VNBASINF (nolock) on 
--		--sod_cocde = vbi_cocde and 
--		sod_venno = vbi_venno
	inner join VNBASINF pv (nolock) on 
		sod_venno = pv.vbi_venno
	inner join VNBASINF cv (nolock) on 
		sod_cusven = cv.vbi_venno
		--michael 20170421 
	left join #tlt_cov_qty (nolock) on
		sod_cocde = hid_cocde and
		sod_ordno = hid_ordno and
		sod_ordseq = hid_ordseq
where 
	pod_cocde = @pod_cocde and
	pod_jobord = @pod_jobord                                      


order by 
	sod_cocde, sod_ordno, sod_itmno, sod_colcde ,sod_pckunt,sod_inrctn,sod_mtrctn,sod_cbm
END

ELSE

BEGIN
Select 
sod_ordno, 
sod_ordseq, 
sod_cuspo,
sod_itmno, 
sod_itmtyp,
sod_itmdsc,
sod_cusitm,
sod_colcde,
sod_cuscol,
sod_coldsc,
sod_pckunt,
sod_inrctn,
sod_mtrctn,
sod_mtrdcm,
sod_mtrwcm,
sod_mtrhcm,
sod_cbm,
--sod_ordqty - sod_shpqty as 'sod_shpqty',
0 as 'sod_shpqty',
sod_ordqty - sod_shpqty - ISNULL(#tlt_cov_qty.tlt_covseq,0) as 'sod_outqty',
--sod_ordqty  as 'sod_outqty',
-----------------------------------------------------------------------------------
--2005-09-12 Lester Wu,  Show show name of P.V. fand C.V.
--sod_venno,
--sod_cusven,
sod_venno + case isnull(pv.vbi_vensna,'') when '' then '' else ' - ' + pv.vbi_vensna end as 'sod_venno' , 
sod_cusven + case isnull(cv.vbi_vensna,'') when '' then '' else ' - ' + cv.vbi_vensna end as 'sod_cusven' , 
-----------------------------------------------------------------------------------
cast(sod_colcde as nvarchar(30)) + ' / ' + 
cast(sod_pckunt as nvarchar(6)) + ' / ' + 
cast(sod_inrctn as nvarchar(10)) + ' / ' + 
cast(sod_mtrctn as nvarchar(10)) + ' / ' + 
cast(sod_cft as nvarchar(10)) + ' / ' + 
cast(sod_cbm as nvarchar(10)) + ' / ' + 
cast(sod_ftyprctrm as nvarchar(10)) + ' / ' + 
cast(sod_hkprctrm as nvarchar(10)) + ' / ' + 
cast(sod_trantrm as nvarchar(10)) as 'sod_colpck',
isnull(soh_cus1no,'') as 'soh_cus1no',
isnull(soh_cus2no,'') as 'soh_cus2no',
isnull(soh_prctrm,'') as 'soh_prctrm',
isnull(soh_paytrm,'') as 'soh_paytrm',
isnull(pod_jobord,'') as 'pod_jobord',
isnull(pod_purord,'') as 'pod_purord',
isnull(pod_purseq,0) as 'pod_purseq',
isnull(pv.vbi_vennam,'') as 'vbi_vennam',
sod_untprc,
--Lester Wu 2005/02/01 Add the missing field for the lower part of this sp
sod_netuntprc,
-----------------------------------------------------------------------------------------
isnull(soh_ordsts,'') as 'soh_ordsts',
isnull(poh_pursts,'') as 'poh_pursts',
--Added by Mark Lau 20060929
isnull(sod_alsitmno,'') as 'sod_alsitmno',
isnull(sod_alscolcde,'') as 'sod_alscolcde' , 
isnull(sod_conftr,1) as 'sod_conftr' , 
isnull(sod_contopc,'') as 'sod_contopc' , 
isnull(sod_pcprc,0) as 'sod_pcprc',
--Added by Mark Lau 20080611
isnull(sod_custum,'') as 'sod_custum',
-- Added by Mark Lau 20090515
isnull(sod_cusstyno,'') as 'sod_cusstyno',
case sod_resppo when '' then soh_resppo else sod_resppo end as 'sod_resppo',isnull(sod_cussku,'') as 'sod_cussku',
soh_rplmnt as 'soh_rplmnt',
isnull(ssm_engdsc,'') as 'ssm_engdsc',
isnull(sod_examven,'') +' - '+ isnull(cv.vbi_vennam,'')  as 'sod_examven',
		isnull(sod_covqty,'0') as 'sod_covqty',
		isnull(sod_name_f1,'') as 'sod_name_f1',
		isnull(sod_dsc_f1,'') as 'sod_dsc_f1',
		isnull(sod_name_f2,'') as 'sod_name_f2',
		isnull(sod_dsc_f2,'') as 'sod_dsc_f2',
		isnull(sod_name_f3,'') as 'sod_name_f3',
		isnull(sod_dsc_f3,'') as 'sod_dsc_f3'

from 
	SCORDDTL (nolock)
	inner join SCORDHDR (nolock) on 
		sod_cocde = soh_cocde and 
		sod_ordno = soh_ordno
left join SCSHPMRK  (nolock) on  soh_cocde = ssm_cocde and soh_ordno=ssm_ordno and ssm_shptyp = 'M'
	inner join POORDDTL (nolock) on 
		sod_cocde = pod_cocde and 
		sod_ordno=pod_scno and 
		sod_ordseq = pod_scline
	left join POORDHDR (nolock) on 
		sod_cocde = poh_cocde and 
		pod_purord = poh_purord 
	-- ? y use inner join 
	-- Lester Wu 2005-09-12, show vendor short name of C.V and P.V
--	inner join VNBASINF (nolock) on 
--		--sod_cocde = vbi_cocde and 
--		sod_venno = vbi_venno
	
	inner join VNBASINF pv (nolock) on 
		sod_venno = pv.vbi_venno
	inner join VNBASINF cv (nolock) on 
		sod_cusven = cv.vbi_venno
		--michael 20170421 
	left join #tlt_cov_qty (nolock) on
		sod_cocde = hid_cocde and
		sod_ordno = hid_ordno and
		sod_ordseq = hid_ordseq
where 
	pod_cocde = @pod_cocde and
	pod_jobord = @pod_jobord        
                              
order by 
	sod_cocde, sod_ordno, sod_itmno, sod_colcde ,sod_pckunt,sod_inrctn,sod_mtrctn,sod_cbm

END




GO
GRANT EXECUTE ON [dbo].[sp_list_POORDDTL_SHM00001_1] TO [ERPUSER] AS [dbo]
GO
