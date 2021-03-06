/****** Object:  StoredProcedure [dbo].[sp_select_SAR00005_bak]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAR00005_bak]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAR00005_bak]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sp_select_SAR00005_bak]
@cocde		nvarchar(6),	
@SARfm		nvarchar(20),	@SARto		nvarchar(20)

AS
 select
	-- SAINVHDR 
	sih_cocde,		sih_curcde,		sih_salrep,
	sih_invno,		sih_cus1no,		sih_cus1ad,		
	sih_cus1st,		sih_cus1cy,		sih_cus1zp,
	sih_cus1cp,	sih_courier,		sih_ttlamt,
	sih_shprmk,	sih_rmk,			sih_hdrrmk,
	sih_doctyp,	sih_docno,

	-- SYSALREP
	sysalrep = ysr_dsc,

	-- SAINVDTL
	sid_itmno,		sid_cusitm,		sid_itmdsc,
	sid_cuscol,		sid_coldsc,			sid_colcde,		
	sid_pckunt,		
	sid_inrqty,		sid_inrqtyStr = str(sid_inrqty),
	sid_mtrqty,	sid_mtrqtyStr = str(sid_mtrqty),
	sid_cft,		sid_cftStr = str(sid_cft),
	sid_selprc,
	sid_untcde,	sid_ttlamt,			sid_smpunt,
	sid_shpqty,	sid_shpqtyStr = str(sid_shpqty),
	sid_chgqty,	sid_chgqtyStr = str(sid_chgqty),
	packing = ltrim(str(isNull(sid_inrqty,0),10,0)) + ltrim(str(isNUll(sid_mtrqty,0),10,0)) + ltrim(str(isNull(sid_cft,0),10,2)) + ltrim(isNull(sid_pckunt,'')),

	-- CUBASINF	
	cbi_cussna,		cbi_cusnam,

	-- SYSETINF
	sysPrc.ysi_dsc,	sysPck.ysi_dsc,	sysSmp.ysi_dsc,	sysUnt.ysi_dsc,	sysCy.ysi_dsc


from 		
SAINVHDR
left join SAINVDTL on sih_cocde = sid_cocde and sih_invno = sid_invno
left join CUBASINF on sih_cus1no = cbi_cusno 
left join SYSALREP on sih_salrep = ysr_code1
left join SYSETINF sysCY on sysCy.ysi_typ = '02' and sih_cus1cy = sysCy.ysi_cde
left join SYSETINF sysPrc on sysPrc.ysi_typ = '03' and sih_prctrm = sysPrc.ysi_cde
left join SYSETINF sysPck on sysPck.ysi_typ = '05' and sid_pckunt = sysPck.ysi_cde
left join SYSETINF sysSmp on sysSmp.ysi_typ = '05' and sid_smpunt = sysSmp.ysi_cde
left join SYSETINF sysUnt on sysUnt.ysi_typ = '05' and sid_untcde = sysUnt.ysi_cde
where 
sih_cocde = @cocde and sih_invno >= @SARfm and sih_invno <= @SARto
and cbi_cusno is not null
order by sih_invno, sid_itmno, sid_selprc



GO
GRANT EXECUTE ON [dbo].[sp_select_SAR00005_bak] TO [ERPUSER] AS [dbo]
GO
