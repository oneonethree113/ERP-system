/****** Object:  StoredProcedure [dbo].[sp_select_DER00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_DER00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_DER00003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 27/07/2003


CREATE procedure [dbo].[sp_select_DER00003]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cocde nvarchar(6) ,
@doctype nvarchar(2)   
---------------------------------------------- 
 
AS

IF @doctype = 'QU'
BEGIN

SELECT	'QU',
	quh_cocde,
	ibi_itmsts,
	quh_qutno,
	quh_issdat,
	quh_rvsdat,
	quh_cus1no + ' - ' + pri.cbi_cussna,
	isnull(quh_cus2no + ' - ' + sec.cbi_cussna, ''),
	qud_itmno,
	qud_colcde,
	packing = qud_untcde + '/' + ltrim(str(qud_inrqty,10,0)) + '/' + ltrim(str(qud_mtrqty,10,0)) + '/' + ltrim(str(qud_cft,10,2)),
	price_flag =Case isnull(qud_cus1sp, 0) when 0 then 'N' else 'Y' end,
	qud_venno + ' - ' + vbi_vensna,
	qud_smpqty,
	'',
	ysr_saltem
FROM	QUOTNHDR hdr
left join QUOTNDTL dtl on hdr.quh_cocde = dtl.qud_cocde and hdr.quh_qutno = dtl.qud_qutno
left join CUBASINF pri on hdr.quh_cus1no = pri.cbi_cusno
left join CUBASINF sec on hdr.quh_cus2no = sec.cbi_cusno
left join IMBASINF bas on dtl.qud_itmno = bas.ibi_itmno
left join VNBASINF on qud_venno = vbi_venno
left join SYSALREP srp on hdr.quh_salrep = srp.ysr_code1
WHERE	
	hdr.quh_cocde = @cocde
AND	dtl.qud_qutitmsts <> 'COMPLETE' and hdr.quh_issdat >= '2002-03-12'
ORDER BY
	ysr_saltem, quh_qutno,  qud_itmno

END
IF @doctype = 'SC'
BEGIN
SELECT	'SC',
	soh_cocde,
	ibi_itmsts,
	soh_ordno,
	soh_issdat,
	soh_rvsdat,
	soh_cus1no + ' - ' + pri.cbi_cussna,
	isnull(soh_cus2no + ' - ' + sec.cbi_cussna, ''),
	sod_itmno,
	sod_colcde,
	packing = sod_pckunt + '/' + ltrim(str(sod_inrctn,10,0)) + '/' + ltrim(str(sod_mtrctn,10,0)) + '/' + ltrim(str(sod_cft,10,2)),
	price_flag =Case isnull(sod_untprc, 0) when 0 then 'N' else 'Y' end,
	sod_venno + ' - ' + vbi_vensna,
	sod_ordqty,
	sod_purord,
	''
FROM	SCORDHDR hdr
left join SCORDDTL dtl on hdr.soh_cocde = dtl.sod_cocde and hdr.soh_ordno = dtl.sod_ordno
left join CUBASINF pri on hdr.soh_cus1no = pri.cbi_cusno
left join CUBASINF sec on hdr.soh_cus2no = sec.cbi_cusno
left join IMBASINF bas on dtl.sod_itmno = bas.ibi_itmno
left join VNBASINF on sod_venno = vbi_venno

WHERE	
	hdr.soh_cocde = @cocde
AND	dtl.sod_itmsts = 'INC' and soh_issdat >= '2002-03-12'
ORDER BY
	soh_ordno,  sod_itmno
END





GO
GRANT EXECUTE ON [dbo].[sp_select_DER00003] TO [ERPUSER] AS [dbo]
GO
