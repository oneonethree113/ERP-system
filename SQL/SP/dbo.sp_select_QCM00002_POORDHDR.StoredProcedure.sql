/****** Object:  StoredProcedure [dbo].[sp_select_QCM00002_POORDHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCM00002_POORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCM00002_POORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_select_QCM00002_POORDHDR]
	@cocde nvarchar(10),
	@PONo nvarchar(20)
AS
BEGIN
	SELECT 
	
		--QCREQHDR
		qch_inspyear=-1, qch_inspweek=-1, qch_insptyp="", 
	
		--QCPORDTL
		qpd_cocde="", qpd_qcno="", qpd_qcposeq=-1, qpd_purord="", qpd_del="", 
		qpd_mon="", qpd_tue="", qpd_wed="", qpd_thur="", qpd_fri="", qpd_sat="", qpd_sun="", qpd_rmk="", 
		
		--POORDHDR
		poh_cocde, poh_purord, poh_ordno, poh_ordno,
		poh_credat = convert(char, poh_credat, 101), --poh_credat is Iss Date 
		poh_issdat = convert(char, poh_issdat, 101), --poh_issdat is Rev Date
		poh_venno, poh_cuspno, poh_reppno, 
		poh_shpstr = convert(char, poh_shpstr,101),
		poh_shpend = convert(char, poh_shpend,101),	
		poh_rmk,
		
		--20151023
		poh_prmcus, poh_seccus, 
		
		qpd_ctrlstate = "ADD",
		qpd_act = ""
		


	FROM POORDHDR
		
	WHERE	
		poh_cocde = @cocde  AND 
		poh_purord = @PONo
	AND poh_purord is not NULL




END

GO
GRANT EXECUTE ON [dbo].[sp_select_QCM00002_POORDHDR] TO [ERPUSER] AS [dbo]
GO
