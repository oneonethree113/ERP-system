/****** Object:  StoredProcedure [dbo].[sp_select_INR00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 27/07/2003


CREATE procedure [dbo].[sp_select_INR00002]
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@cocde nvarchar(6) ,
@opt1 nvarchar(1),
@opt nvarchar(10),
@opt3 nvarchar(1),
@laf nvarchar(1),
@from nvarchar(20)
---------------------------------------------- 
 
AS

BEGIN
Select	distinct
	@opt1,
	@opt,
	@opt3,
	@laf,
	hdr.hih_shpno,
	dtl.hid_shpseq,
--	hdr.hih_smpshp,
	inv.hiv_invno,
--	ltrim(inv.hiv_cover),
--	ltrim(cus.cbi_cussna),

--	ltrim(hdr.hih_bilent),
--	ltrim(hdr.hih_biladr), 
--	ltrim(hdr.hih_bilstt), 
--	ltrim(cty.ysi_dsc), 
--	ltrim(hdr.hih_bilzip),
	ltrim(pay.ysi_dsc),
--	ltrim(inv.hiv_ftrrmk),
--	ltrim(inv.hiv_doctyp),
--	ltrim(inv.hiv_doc),

	inv.hiv_invdat,
	'FROM ' + hdr.hih_potloa + ' TO ' + hdr.hih_dst,
	hdr.hih_ves,
	hdr.hih_voy,
	hdr.hih_slnonb,

---	For Packing List, Group by Container #
	ltrim(dtl.hid_pckrmk),
--	dtl.hid_ctrcfs,
---	Total of Cartons for Container

---	For Invoice, Group by Customer PO# and Sales Confirmation #
	ltrim(soh.soh_cuspo) + ltrim(dtl.hid_ordno) + ltrim(dtl.hid_purord),
	ltrim(dtl.hid_purord),
	poh.poh_issdat,
---	Customer PO Date
	dtl.hid_ordno,
--	soh.soh_rvsdat,
---	SC Revise Date


---	Details Shipmark
	ltrim(dtl.hid_itmshm),
---	Carton Details

---	Manufacturers Name & Address
	ltrim(dtl.hid_mannam),
--	ltrim(dtl.hid_manadr),

--	dtl.hid_cusitm + ' (' + dtl.hid_itmno + ')',
	dtl.hid_itmno,
	pod.pod_venitm + ' (' +  dtl.hid_itmno  + ')', 
	pod.pod_engdsc,	-- dtl.hid_itmdsc,

---	Assortment Details
---	Component Breakdown
	
---	Packing: change all to string and concat.
	ltrim(str(dtl.hid_inrctn)) + ' ' + cde.ysi_dsc +' TO BOX, ' + ltrim(str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc +' TO CTN.',

	ltrim(str(dtl.hid_grswgt,10,2)) + ' KG',
	ltrim(str(dtl.hid_netwgt,10,2)) + ' KG',

---	Master Dim are concat.
	ltrim(str(dtl.hid_mtrdcm,10,2)) + ' X ' + ltrim(str( dtl.hid_mtrwcm,10,2)) + ' X ' + ltrim(str(dtl.hid_mtrhcm,10,2)) + ' CM',

---	Harmonized Code

	str(dtl.hid_ttlctn),
	str(dtl.hid_shpqty),

	poh.poh_curcde,
	str(pod.pod_ftyprc,10,4),	--  str(dtl.hid_selprc,10,4),
	str(round(pod.pod_lneamt,2),10,4),	--  str(dtl.hid_ttlamt,10,4),
	shm.hsm_imgpth,
	shm.hsm_engdsc,
--	@cocde,
	ltrim(dtl.hid_cmprmk),
	sca.sai_assitm,
	sca.sai_assdsc,
	sca.sai_coldsc,
	sca.sai_cussku,
	sca.sai_upcean,
	sca.sai_cusrtl,
	ltrim(saa.ysi_dsc),
	dtl.hid_ordseq,
	sca.sai_cusitm,
	sca.sai_colcde,
	ltrim(str(sca.sai_inrqty,10,0)),
	ltrim(str(sca.sai_mtrqty,10,0)),
	hdr.hih_cus1no,
	ltrim(cde.ysi_dsc),
	ltrim(dtl.hid_colcde),
	ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) AS hid_coldsc,
	ltrim(sod.sod_hrmcde),
	ltrim(inv.hiv_bank),
	ltrim(inv.hiv_ftrrmk),
	ltrim( dtl.hid_cusitm),
	sod.sod_typcode,
	LTRIM(sod.sod_Code1) + LTRIM(sod.sod_Code2) + LTRIM(sod.sod_Code3) AS sod_code,
---	Additional Field : Duty Rate, Customer Retail & Dept #
	
	CASE sod.sod_dtyrat when 0 then '' else ltrim(str(sod.sod_dtyrat,10,0)) end AS sod_dtyrat,
	CASE sod.sod_cususd when 0 then '' else ltrim(str(sod.sod_cususd,13,4)) end AS sod_cususd,
	CASE sod.sod_cuscad when 0 then '' else ltrim(str(sod.sod_cuscad,13,4)) end AS sod_cuscad,
	ltrim(sod.sod_dept),
	
---	Packing Remarks Details
---	To concat. all packing remarks of the invoice
	dtl.hid_venno,
	ltrim(cus.cbi_cussna),
	dtl.hid_ctnstr,

	vw_ttlctn = vw.hid_ttlctn,
	vw_shpqty = vw.hid_shpqty,
	vw.pod_ftyprc,
	vw.sumpmt,

	dtl.hid_cusitm

From 	
SHIPGHDR hdr
left join SHINVHDR inv on hdr.hih_cocde = inv.hiv_cocde and hdr.hih_shpno = inv.hiv_shpno
left join SHIPGDTL dtl on inv.hiv_cocde = dtl.hid_cocde and inv.hiv_shpno = dtl.hid_shpno and inv.hiv_invno = dtl.hid_invno
left join CUBASINF cus on hdr.hih_cus1no = cus.cbi_cusno
left join POORDHDR poh on dtl.hid_cocde = poh.poh_cocde and dtl.hid_purord = poh.poh_purord
left join SCORDHDR soh on soh.soh_cocde = inv.hiv_cocde and soh.soh_ordno = dtl.hid_ordno
left join SCORDDTL sod on sod.sod_cocde = inv.hiv_cocde and sod.sod_ordno = dtl.hid_ordno and sod.sod_ordseq = dtl.hid_ordseq
left join POORDDTL pod on dtl.hid_cocde = pod.pod_cocde and dtl.hid_purord = pod.pod_purord and dtl.hid_purseq = pod.pod_purseq
left join SYSETINF pay on poh.poh_paytrm = pay.ysi_cde and pay.ysi_typ = '04'
left join SHSHPMRK shm on shm.hsm_cocde = inv.hiv_cocde and shm.hsm_invno = inv.hiv_invno and shm.hsm_shptyp = 'M'
left join SYSETINF cde on dtl.hid_untcde = cde.ysi_cde and cde.ysi_typ = '05'
left join SCASSINF sca on sca.sai_cocde = inv.hiv_cocde and sca.sai_ordno = dtl.hid_ordno and sca.sai_ordseq = dtl.hid_ordseq 
left join SYSETINF saa on sca.sai_untcde = saa.ysi_cde and saa.ysi_typ = '05'
left join v_select_inr00002 vw on inv.hiv_cocde =  vw.hid_cocde and inv.hiv_invno = vw.hid_invno and soh.soh_cuspo = vw.soh_cuspo
and	dtl.hid_ordno = vw.hid_ordno 
and 	dtl.hid_itmno = vw.hid_itmno and dtl.hid_itmdsc = vw.hid_itmdsc
and 	dtl.hid_inrctn = vw.hid_inrctn and dtl.hid_mtrctn = vw.hid_mtrctn
WHERE 	
hdr.hih_cocde = @cocde
and 	inv.hiv_invno = @from
and 	dtl.hid_venno =  '0005'

ORDER BY
	inv.hiv_invno, ltrim(soh.soh_cuspo) + ltrim(dtl.hid_ordno) + ltrim(dtl.hid_purord),  dtl.hid_cusitm,
	ltrim(str(dtl.hid_inrctn)) + ' ' + cde.ysi_dsc +' TO BOX, ' + ltrim(str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc +' TO CTN.', ltrim(dtl.hid_colcde)
END







GO
GRANT EXECUTE ON [dbo].[sp_select_INR00002] TO [ERPUSER] AS [dbo]
GO
