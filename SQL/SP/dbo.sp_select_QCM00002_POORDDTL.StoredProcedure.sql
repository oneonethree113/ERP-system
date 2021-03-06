/****** Object:  StoredProcedure [dbo].[sp_select_QCM00002_POORDDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCM00002_POORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCM00002_POORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE  PROCEDURE [dbo].[sp_select_QCM00002_POORDDTL]
	@cocde nvarchar(10), 
	@pod_purord nvarchar(20), 
	@pod_purseq int
AS
BEGIN
	SELECT 
		--QCREQHDR
		-- qch_cocde, qch_qcno, qch_qcsts,
		qch_venno= '', qch_prmcus='', qch_seccus='', qch_inspyear=-1, qch_inspweek=-1, qch_insptyp='',
		--QCREQDTL
		qcd_cocde='', qcd_qcno='', qcd_qcseq='', 
		qcd_dtlsts='', qcd_genby='', 
		--qcd_inspmode, qcd_inspyear, qcd_inspwkfm, qcd_inspwkto, 
		qcd_flgpolink='', qcd_qcposeq='', qcd_purord='', qcd_purseq=-1, 

		qcd_mon='', qcd_tue='', qcd_wed='', qcd_thur='', qcd_fri='', qcd_sat='', qcd_sun='', 
		qcd_samhdl='', 
		qcd_sidate ='',
		qcd_cydate = '',
		
		qcd_rmk='',
		
		qcd_schdat='', 
		
		
		--POORDHDR
		poh_purord, 
		poh_ordno, --SC No
		poh_pursts, 
		poh_credat = convert(char, poh_credat, 101), --poh_credat is Iss Date 
		poh_issdat = convert(char, poh_issdat, 101), --poh_issdat is Rev Date
		poh_venno, 
		poh_cuspno, poh_reppno,
		poh_shpstr = convert(char, poh_shpstr,101),
		poh_shpend = convert(char, poh_shpend,101),	
		poh_rmk,
		--POORDDTL
		pod_purseq,
		pod_itmno, 
		pod_jobord,
		pod_prdven, pod_tradeven, pod_examven,
		pod_venitm, pod_cusitm, pod_seccusitm, pod_cussku,
		pod_engdsc, pod_chndsc, 
		pod_vencol, pod_cuscol, pod_coldsc, pod_pckitr,
		
		pod_untcde, pod_inrctn, pod_mtrctn, pod_cubcft, 
		pod_ordqty, pod_cuspno, pod_respno, 
		pod_candat, 
		pod_shpstr = convert(char, pod_shpstr, 101),
		pod_shpend = convert(char, pod_shpend, 101),
		pod_ctnstr, pod_ctnend, pod_ttlctn, 
		pod_rmk, pod_credat, pod_upddat,pod_updusr,
		
		--Control
		qcd_ctrlstate = "",
		"DEL" = ''
		
		
	--FROM QCREQHDR
	--LEFT JOIN QCREQDTL
	--	ON qch_qcno = qcd_qcno
	FROM POORDHDR
	
	LEFT JOIN POORDDTL 
		ON poh_cocde = pod_cocde
		AND poh_purord = pod_purord
	WHERE
		pod_cocde = @cocde
	AND pod_purord = @pod_purord
	AND	pod_purseq = @pod_purseq



END

GO
GRANT EXECUTE ON [dbo].[sp_select_QCM00002_POORDDTL] TO [ERPUSER] AS [dbo]
GO
