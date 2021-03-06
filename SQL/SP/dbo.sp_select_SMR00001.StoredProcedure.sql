/****** Object:  StoredProcedure [dbo].[sp_select_SMR00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SMR00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SMR00001]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO













/***********************************************************************************
Program ID 	: sp_select_SMR00001
Programmer	: Lester Wu		
Table(s) Read	: POORDHDR,POORDDTL,SCORDDTL,SHIPGDTL,SHINVHDR,PODISPRM
		: CUBASINF,VNBASINF
Table(s) Write	: N/A
Description 	: Retrieve PO Information

sp_select_SMR00001 'UCPP','50001','50154','','','','','','','','','','','','','','','04/01/2004','04/15/2004','I','Item No'

************************************************************************************
Modification History
************************************************************************************
Modified on		Modified by		Description
************************************************************************************
2005/01/21		Lester Wu		Rearrange the column and rename column header
************************************************************************************/
CREATE PROCEDURE [dbo].[sp_select_SMR00001]

@COCDE AS NVARCHAR(6),
@CUSTNOFM AS NVARCHAR(6),
@CUSTNOTO AS NVARCHAR(6),
@VENNOFM AS NVARCHAR(6),
@VENNOTO AS NVARCHAR(6),
@PVENNOFM AS NVARCHAR(6),
@PVENNOTO AS NVARCHAR(6),
@CUSTPOFM AS NVARCHAR(20),
@CUSTPOTO AS NVARCHAR(20),
@SCFM AS NVARCHAR(20),
@SCTO AS NVARCHAR(20),
@POFM AS NVARCHAR(20),
@POTO AS NVARCHAR(20),
@ITEMFM AS NVARCHAR(20),
@ITEMTO AS NVARCHAR(20),
@JOBNOFM AS NVARCHAR(20),
@JOBNOTO AS NVARCHAR(20),
@INVFM AS NVARCHAR(20),
@INVTO AS NVARCHAR(20),
@ISSDATFM AS DATETIME,
@ISSDATTO AS DATETIME,
@ETDDATFM AS DATETIME,
@ETDDATTO AS DATETIME,
@OPTVEN AS CHAR(1),
@SORTBY AS NVARCHAR(40),
@LAYOUT AS NVARCHAR(10)

AS
BEGIN

Create Table #CV
(
	CV_venno	nvarchar(6),
	CV_vensna	nvarchar(30),
	CV_ventyp	nvarchar(1)

)

Create Table #DV
(
	DV_venno	nvarchar(6),
	DV_vensna	nvarchar(30),
	DV_ventyp	nvarchar(1)
	
)

Create Table #PV
(
	PV_venno	nvarchar(6),
	PV_vensna	nvarchar(30),
	PV_ventyp	nvarchar(1)
)




Insert into #CV
select vbi_venno, vbi_vensna, vbi_ventyp from vnbasinf (nolock)

Insert into #DV
select vbi_venno, vbi_vensna, vbi_ventyp from vnbasinf (nolock)

Insert into #PV
select vbi_venno, vbi_vensna, vbi_ventyp from vnbasinf (nolock)

-- Added by Mark Lau 20090505, for History Item
--select * into #IM from
--(
--select ibi_itmno, ibi_venno from imbasinf (nolock) where ibi_typ <> 'BOM'
--union
--select ibi_itmno, ibi_venno from imbasinfh (nolock) where ibi_typ <> 'BOM'
--) im
--ORDER BY IBI_ITMNO ASC

----------------------------------------------------------

SELECT
hiv_invno as 'INVOICE NO',			--12
convert(varchar, hih_slnonb, 101) as 'Shipment Date',
convert(varchar,hiv_invdat,101) as 'INVOICE DATE', --inv_dat				--13
poh_prmcus + ' - ' + CBI_CUSSNA as 'CUSTOMER CODE & SHORT NAME',  --cust_cde	--15
case isnull(pod_cuspno,'') when '' then isnull(poh_cuspno,'') else pod_cuspno end  as 'CUSTOMER PO NO', --cust_po	--5
pod_scno as 'S/C NO.',		--4
pod_jobord as 'JOB NO.',	--2
pod_itmno as 'ITEM NO.',	--1
ibi_engdsc as 'ITEM DESC',
sod_ordqty as 'ORDER QTY - S/C',		--6
hid_shpqty as 'SHIP QTY',							--14
pod_untcde as 'UM',				--E

-- Michael Chiu 20170419
(SELECT Top 1 yce_buyrat FROM SYCUREX_ACC (nolock) WHERE [yce_frmcur] = 'CNY' and [yce_tocur] = 'HKD' and hih_slnonb between [yce_effdat]and [yce_expdat]  order by [yce_expdat] DESC) as 'Ex Rate CNY to HKD',

(SELECT Top 1 yce_buyrat FROM SYCUREX_ACC (nolock) WHERE [yce_frmcur] = 'USD' and [yce_tocur] = 'HKD' and hih_slnonb between [yce_effdat]and [yce_expdat]  order by [yce_expdat] DESC) as 'Ex Rate USD to HKD',


sod_curcde as 'SELLING PRICE CURR.',		--8
sod_untprc as 'SELLING PRICE',			--9
case sod_curcde when 'CNY' then sod_untprc *(SELECT Top 1 yce_buyrat FROM SYCUREX_ACC (nolock) WHERE [yce_frmcur] = 'CNY' and [yce_tocur] = 'HKD' and hih_slnonb between [yce_effdat]and [yce_expdat]  order by [yce_expdat] DESC)
when 'USD' then sod_untprc *(SELECT Top 1 yce_buyrat FROM SYCUREX_ACC (nolock) WHERE [yce_frmcur] = 'USD' and [yce_tocur] = 'HKD' and hih_slnonb between [yce_effdat]and [yce_expdat]  order by [yce_expdat] DESC)
 else  sod_untprc end as 'SELLING PRICE(HKD)',	

poh_purord as 'VENDOR PO NO.',	--3
pod_ordqty as 'ORDER QTY - VENDOR PO',	--7
poh_curcde as 'PV – Total Cost Curr.',		--10
pod_ftyprc as 'PV – Total Cost',			--11
case poh_curcde when 'CNY' then pod_ftyprc *(SELECT Top 1 yce_buyrat FROM SYCUREX_ACC (nolock) WHERE [yce_frmcur] = 'CNY' and [yce_tocur] = 'HKD' and hih_slnonb between [yce_effdat]and [yce_expdat]  order by [yce_expdat] DESC)
 when 'USD' then pod_ftyprc *(SELECT Top 1 yce_buyrat FROM SYCUREX_ACC (nolock) WHERE [yce_frmcur] = 'USD' and [yce_tocur] = 'HKD' and hih_slnonb between [yce_effdat]and [yce_expdat]  order by [yce_expdat] DESC)
 else  pod_ftyprc end as 'PV – Total Cost(HKD)',

sod_dvfcurcde as 'DV – Total Cost Curr.',		--10
sod_dvftyprc as 'DV – Total Cost',			--11
case sod_dvfcurcde when 'CNY' then sod_dvftyprc *(SELECT Top 1 yce_buyrat FROM SYCUREX_ACC (nolock) WHERE [yce_frmcur] = 'CNY' and [yce_tocur] = 'HKD' and hih_slnonb between [yce_effdat]and [yce_expdat]  order by [yce_expdat] DESC)
 when 'USD' then sod_dvftyprc *(SELECT Top 1 yce_buyrat FROM SYCUREX_ACC (nolock) WHERE [yce_frmcur] = 'USD' and [yce_tocur] = 'HKD' and hih_slnonb between [yce_effdat]and [yce_expdat]  order by [yce_expdat] DESC)
  else  sod_dvftyprc end as 'DV – Total Cost(HKD)',	

--poh_venno + ' - ' + VBI_VENSNA as 'FACTORY CODE & SHORT NAME', --fty		--16
pod_prdven + ' - ' + PV_vensna as 'PV – Vendor No. / Name', --fty		--16
poh_venno + ' - ' + CV_vensna as 'CV – Vendor No. / Name', --fty		--16
ibi_venno + ' - ' + DV_vensna as 'DV – Vendor No. / Name', --fty		--16
poh_discnt as 'VENDOR PO DISCOUNT %',						--17
case isnull(DIS.pdp_pctamt,'') when 'P' then str(DIS.pdp_seqno) + ') ' + STR(isnull(DIS.pdp_purpct,0),6,3) + ' %  ' + isnull(DIS.pdp_dsc,'') when 'A' then str(DIS.pdp_seqno) + ') $  ' + ltrim(STR(isnull(DIS.pdp_paamt,0),13,4)) + '  ' + isnull(DIS.pdp_dsc,'')  else '' end  as 'VENDOR PO DISCOUNT %/$', --po_disc		--18
case isnull(PRM.pdp_pctamt,'') when 'P' then str(PRM.pdp_seqno) + ') ' + STR(isnull(PRM.pdp_purpct,0),6,3) + ' % ' + isnull(PRM.pdp_dsc,'') when 'A' then str(PRM.pdp_seqno) + ') $  ' + ltrim(STR(isnull(PRM.pdp_paamt,0),13,4)) + '  ' + isnull(PRM.pdp_dsc,'') else '' end  as 'VENDOR PO PREMIUM INFO %/$', --po_prem	--19
hih_potloa as 'Port of Loading',
hih_dst as 'Port of Destination',
hid_shpno as 'Shipment No',
hid_shpseq as 'Shipment Seq',
ibi_lnecde as 'Line Code',
cpi_paytrm as 'Customer Payment Term',
cpt.ysi_dsc as 'Cust Pay Term Desc',
vbi_paytrm as 'PV Payment Term',
pvpt.ysi_dsc as 'PV Pay Term Desc',
hiv_paytrm as 'Invoice Payment Term',
ipt.ysi_dsc as 'Invoice Pay Term Desc'
into #TEMP_RESULT
from SHIPGHDR (nolock)
left join SHIPGDTL (nolock) on hid_cocde = hih_cocde and hid_shpno = hih_shpno
left join SHINVHDR (nolock) on hiv_cocde = hid_cocde and hiv_shpno = hid_shpno and hiv_invno = hid_invno
left join SYSETINF ipt(nolock) on hiv_paytrm = ipt.ysi_cde and ipt.ysi_typ = '04'
left join POORDDTL (nolock) on pod_cocde = hih_cocde and pod_purord = hid_purord and pod_purseq = hid_purseq 
left join POORDHDR (nolock) on poh_cocde = hih_cocde and poh_purord = pod_purord
left join SCORDDTL (nolock) on sod_cocde = hih_cocde and sod_purord = pod_purord and sod_purseq = pod_purseq
left join PODISPRM DIS (nolock) on DIS.pdp_cocde = hih_cocde and DIS.pdp_purord = poh_purord and DIS.pdp_pdptyp = 'D' and '000' = @LAYOUT 
left join PODISPRM PRM (nolock) on DIS.pdp_cocde = hih_cocde and DIS.pdp_purord = poh_purord and DIS.pdp_pdptyp = 'P' and '000' = @LAYOUT
left join CUBASINF (nolock) on cbi_cusno = hih_cus1no
left join CUPRCINF (nolock) on cpi_cusno = cbi_cusno
left join SYSETINF cpt(nolock) on cpi_paytrm = cpt.ysi_cde and cpt.ysi_typ = '04'
left join IMBASINF (nolock) on ibi_itmno = hid_itmno
left join VNBASINF (nolock) on vbi_venno = pod_prdven
left join SYSETINF pvpt(nolock) on vbi_paytrm = pvpt.ysi_cde and pvpt.ysi_typ = '04'



--FROM POORDHDR(NOLOCK)
--LEFT JOIN POORDDTL(NOLOCK) ON POH_COCDE = POD_COCDE AND POH_PURORD = POD_PURORD
--LEFT JOIN SCORDDTL (NOLOCK) ON POD_COCDE = SOD_COCDE AND POD_PURORD = SOD_PURORD AND POD_PURSEQ = SOD_PURSEQ
--LEFT JOIN SHIPGDTL (NOLOCK) ON POD_COCDE = HID_COCDE AND POD_PURORD = HID_PURORD AND POD_PURSEQ = HID_PURSEQ
--LEFT JOIN SHINVHDR (NOLOCK) ON HID_COCDE = HIV_COCDE AND HID_SHPNO = HIV_SHPNO AND HID_INVNO = HIV_INVNO
--LEFT JOIN SHIPGHDR (NOLOCK) ON POD_COCDE = HIH_COCDE AND HIH_SHPNO = HID_SHPNO
--LEFT JOIN PODISPRM DIS (NOLOCK) ON DIS.PDP_COCDE = POH_COCDE AND DIS.PDP_PURORD = POH_PURORD AND DIS.PDP_PDPTYP = 'D'
--LEFT JOIN PODISPRM PRM (NOLOCK) ON PRM.PDP_COCDE = POH_COCDE AND PRM.PDP_PURORD = POH_PURORD AND PRM.PDP_PDPTYP = 'P'
--LEFT JOIN CUBASINF (NOLOCK) ON POH_PRMCUS = CBI_CUSNO




-- Added by Mark Lau 20090505, for History Item
--LEFT JOIN IMBASINF (NOLOCK) ON IBI_ITMNO = POD_ITMNO
--LEFT JOIN #IM (NOLOCK) ON IBI_ITMNO = POD_ITMNO

--LEFT JOIN VNBASINF (NOLOCK) ON POH_VENNO = VBI_VENNO
LEFT JOIN #PV (NOLOCK) ON PV_venno = POD_PRDVEN
LEFT JOIN #CV (NOLOCK) ON CV_venno = POH_VENNO
LEFT JOIN #DV (NOLOCK) ON DV_venno =  IBI_VENNO

WHERE 
(hih_slnonb BETWEEN @ETDDATFM AND @ETDDATTO + ' 23:59:59') AND
(@COCDE='ALL' OR @COCDE=hih_cocde) AND
(@CUSTNOFM='' OR (@CUSTNOFM<>'' AND poh_prmcus BETWEEN @CUSTNOFM AND @CUSTNOTO)) AND
(@VENNOFM='' OR (@VENNOFM<>'' AND poh_venno BETWEEN @VENNOFM AND @VENNOTO)) AND
(@PVENNOFM='' OR (@PVENNOFM<>'' AND pod_prdven BETWEEN @PVENNOFM AND @PVENNOTO)) AND
(
	(@CUSTPOFM='' OR (@CUSTPOFM<>'' AND isnull(poh_cuspno,'') BETWEEN @CUSTPOFM AND @CUSTPOTO)) 
	OR
	(@CUSTPOFM='' OR (@CUSTPOFM<>'' AND isnull(pod_cuspno,'') BETWEEN @CUSTPOFM AND @CUSTPOTO)) 
) AND
(@SCFM='' OR (@SCFM<>'' AND pod_scno BETWEEN @SCFM AND @SCTO)) AND
(@POFM='' OR (@POFM<>'' AND poh_purord BETWEEN @POFM AND @POTO)) AND
(@ITEMFM='' OR (@ITEMFM<>'' AND pod_itmno BETWEEN @ITEMFM AND @ITEMTO)) AND
(@JOBNOFM='' OR (@JOBNOFM<>'' AND pod_jobord BETWEEN @JOBNOFM AND @JOBNOTO)) AND
(@INVFM='' OR (@INVFM<>'' AND ISNULL(hiv_invno,'') BETWEEN @INVFM AND @INVTO)) AND
--(@ETDDATFM='' OR (ISNULL(hih_slnonb,'') BETWEEN @ETDDATFM AND @ETDDATTO + ' 23:59:59')) AND
(@ISSDATFM='' OR (@ISSDATFM<>'' AND ISNULL(hiv_invdat,'') BETWEEN @ISSDATFM AND @ISSDATTO + ' 23:59:59')) AND
--VBI_ventyp BETWEEN CASE @OPTVEN WHEN 'I' THEN 'I' ELSE 'E' END AND CASE @OPTVEN WHEN 'E' THEN 'E' ELSE 'J' END
CV_ventyp BETWEEN CASE @OPTVEN WHEN 'I' THEN 'I' ELSE 'E' END AND CASE @OPTVEN WHEN 'E' THEN 'E' ELSE 'J' END AND
PV_ventyp BETWEEN CASE @OPTVEN WHEN 'I' THEN 'I' ELSE 'E' END AND CASE @OPTVEN WHEN 'E' THEN 'E' ELSE 'J' END AND
DV_ventyp BETWEEN CASE @OPTVEN WHEN 'I' THEN 'I' ELSE 'E' END AND CASE @OPTVEN WHEN 'E' THEN 'E' ELSE 'J' END 

ORDER BY 
CASE @SORTBY
WHEN 'Customer No. / Name' THEN poh_prmcus + ' - ' + CBI_CUSSNA
--WHEN 'Vendor No. / Name' THEN poh_venno + ' - ' + VBI_VENSNA
WHEN 'PV – Vendor No. / Name' THEN pod_prdven + ' - ' + PV_vensna
WHEN 'CV – Vendor No. / Name' THEN poh_venno + ' - ' + CV_vensna
-- Changed by Mark Lau 20090505
WHEN 'DV – Vendor No. / Name' THEN ibi_venno + ' - ' + DV_vensna
WHEN 'Item No' THEN pod_itmno
WHEN 'S/C No' THEN pod_scno
WHEN 'Customer PO No' THEN case isnull(pod_cuspno,'') when '' then isnull(poh_cuspno,'') else pod_cuspno end
WHEN 'Vendor PO No' THEN pod_purord
WHEN 'Job No' THEN pod_jobord
WHEN 'Invoice No' THEN hiv_invno
WHEN 'Invoice Issue Date' THEN convert(nvarchar(10),hiv_invdat,112)
WHEN 'Shipment Date' THEN convert(nvarchar(10),hih_slnonb,112)
ELSE  pod_itmno END


select distinct * from #TEMP_RESULT


drop Table #CV
drop Table #DV
drop Table #PV

--drop table #IM


END


GO
GRANT EXECUTE ON [dbo].[sp_select_SMR00001] TO [ERPUSER] AS [dbo]
GO
