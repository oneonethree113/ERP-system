/****** Object:  StoredProcedure [dbo].[sp_select_TOExportExcel]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_TOExportExcel]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_TOExportExcel]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE                         PROCEDURE [dbo].[sp_select_TOExportExcel]   
  
@cocde	nvarchar(6),  
@tono	nvarchar(20)
  
AS  

Declare @_count as int


  
BEGIN  
	SELECT	
	dtl.tod_cocde, dtl.tod_toordno, dtl.tod_toordseq, dtl.tod_verno, dtl.tod_latest, dtl.tod_refno,dtl.tod_match, dtl.tod_sts,
	 dtl.tod_todat,
 	case dtl.tod_customer when '' then cus.cbi_cussna else dtl.tod_customer end as 'tod_customer', 
	dtl.tod_cus1no, dtl.tod_cus2no, dtl.tod_buyer, dtl.tod_category, dtl.tod_jobno,
	 dtl.tod_ftyitmno, dtl.tod_itmsku
	, case dtl.tod_ftytmpitmno when '' then case dtl.tod_venitm when '' then '' else dtl.tod_venitm end else dtl.tod_ftytmpitmno end as 'tod_ftytmpitmno'
	, dtl.tod_itmdsc, dtl.tod_venno, dtl.tod_venitm, dtl.tod_colcde, 
	dtl.tod_inrqty, dtl.tod_mtrqty, dtl.tod_pckunt, dtl.tod_conftr, dtl.tod_cft, dtl.tod_cbm, dtl.tod_ftyprctrm, dtl.tod_hkprctrm,
	 dtl.tod_trantrm, 
	 dtl.tod_period, 
	dtl.tod_fobport, dtl.tod_retail, dtl.tod_projqty, dtl.tod_ftyshpdatstr, dtl.tod_ftyshpdatend,
 	dtl.tod_dsgven + ' - ' + dv.vbi_vensna as 'tod_dsgven', 
	dtl.tod_prdven + ' - ' + pv.vbi_vensna as 'tod_prdven',
	dtl.tod_cusven + ' - ' + cv.vbi_vensna as 'tod_cusven', 
	dtl.tod_imgpth, dtl.tod_sapno, dtl.tod_cuspono, dtl.tod_rmk, dtl.tod_upc, dtl.tod_ctnL,
	 dtl.tod_ctnW, dtl.tod_ctnH, dtl.tod_ctnupc, dtl.tod_venstk, dtl.tod_cushpdatstr, dtl.tod_cushpdatend, dtl.tod_fcurcde, dtl.tod_ftycst,
	 dtl.tod_curcde, dtl.tod_selprc, dtl.tod_qtyb_cuspo, dtl.tod_qtyb_ordqty, dtl.tod_podat, dtl.tod_pcktyp, dtl.tod_qutno, dtl.tod_qutseq,
	dtl.tod_cntctp,
	tod_credat,tod_creusr,tod_upddat,tod_updusr,tod_cntctp
 	toh_cocde, toh_toordno, toh_ordsts, toh_issdat, toh_rvsdat, toh_verno, toh_saldiv, toh_saltem, toh_salrep, toh_custcde, toh_buyer, 
	toh_year, toh_cus1no, toh_cus2no, toh_refqut, toh_to, toh_cc, toh_fm, toh_rmk, toh_season,toh_credat,toh_creusr,toh_upddat,toh_updusr
	--shp.tds_shpseq , shp.tds_ftyshpstr , shp.tds_ftyshpend , shp.tds_cushpstr , shp.tds_cushpend,shp.tds_shpqty,shp.tds_pckunt,
	--isnull(shp.tds_podat,'1/1/1900') as 'tds_podat'         --Change by BN Request no cntper and mult ship
	FROM	
	 TOORDDTL dtl 
	
 	  left  join 	TOORDHDR hdr
	  on 		dtl.tod_cocde = hdr.toh_cocde	AND  
			dtl.tod_toordno = hdr.toh_toordno
 	
	/*left join 		TODTLSHP shp
	on		dtl.tod_cocde = shp.tds_cocde and
			dtl.tod_toordno = shp.tds_toordno and
			dtl.tod_toordseq = shp.tds_toordseq and
			dtl.tod_verno = shp.tds_verno*/
	  
	left join 		CUBASINF cus	
	on 		dtl.tod_cus1no = cus.cbi_cusno

	 
	left join vnbasinf dv on rtrim(dtl.tod_dsgven) = dv.vbi_venno
	left join vnbasinf pv on rtrim(dtl.tod_prdven) = pv.vbi_venno
	left join vnbasinf cv on rtrim(dtl.tod_cusven) = cv.vbi_venno

	where 		tod_cocde = @cocde and 
			tod_toordno = @tono and
			tod_latest = 'Y'


 
	ORDER BY	hdr.toh_toordno, dtl.tod_toordseq-- , shp.tds_shpseq
    
 
  
END





















GO
GRANT EXECUTE ON [dbo].[sp_select_TOExportExcel] TO [ERPUSER] AS [dbo]
GO
