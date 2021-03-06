/****** Object:  StoredProcedure [dbo].[sp_select_QCRMKATT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCRMKATT]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCRMKATT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


Create   procedure [dbo].[sp_select_QCRMKATT]
	@qch_cocde nvarchar(6)
AS

BEGIN

	--Will be slow when many QCNO
	SELECT 
		qch_cocde, 
		qch_qcno, qch_rmk, 

		qcd_purord = isnull(qcd_purord, ''), 
		qcd_purseq = isnull(qcd_purseq, 0), 
		pod_itmno = isnull(pod_itmno, ''), 
		pod_cusitm = isnull(pod_cusitm, ''), 
		
		qcd_rmk = isnull(qcd_rmk, ''),
		
		qch_verdoc, qch_verno
	FROM QCREQHDR
	LEFT JOIN QCREQDTL
		ON qch_cocde = qcd_cocde
		AND qch_qcno = qcd_qcno
	LEFT JOIN POORDDTL
		ON qcd_cocde = pod_cocde
		AND qcd_purord = pod_purord
		AND qcd_purseq  = pod_purseq
	WHERE qch_verdoc < qch_verno
	AND qch_qcsts = 'REL'
	order by qch_qcno
END


GO
GRANT EXECUTE ON [dbo].[sp_select_QCRMKATT] TO [ERPUSER] AS [dbo]
GO
