/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_QCAPP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF_QCAPP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_QCAPP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


Create  PROCEDURE [dbo].[sp_select_CUBASINF_QCAPP]
	
AS
BEGIN


	SELECT 
		cbi_cocde
	,cbi_cusno
	,cbi_custyp
	,cbi_cussts
	,cbi_cussna
	,cbi_cusnam
	,cbi_cusweb
	,cbi_saltem
	,cbi_saldiv
	,cbi_salrep
	,cbi_salmgt
	,cbi_srname
	,cbi_refno
	,cbi_cusrat
	,cbi_mrkreg
	,cbi_mrktyp
	,cbi_advord
	,cbi_rmk
	,cbi_cuspod
	,cbi_cusfde
	,cbi_cuscfs
	,cbi_custhc
	,cbi_cuspro
	,cbi_cerdoc
	,cbi_cusali
	,cbi_cugrptyp_int
	,cbi_cugrptyp_ext
	,cbi_rounding
	,cbi_cbinv
	,cbi_cbinvwarn
	,cbi_creusr
	,cbi_updusr
	,convert(char, cbi_credat,120) cbi_credat
	,convert(char, cbi_upddat,120) cbi_upddat
	FROM CUBASINF
	where cbi_cussts = 'A'
END


GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF_QCAPP] TO [ERPUSER] AS [dbo]
GO
