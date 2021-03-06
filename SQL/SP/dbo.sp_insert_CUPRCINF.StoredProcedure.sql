/****** Object:  StoredProcedure [dbo].[sp_insert_CUPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUPRCINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/************************************************************************
Author:		Kath Ng     
Date:		24th September, 2001
Description:	Insert data into CUPRCINF
Parameter:	1. Company Code range    
		2. Customer Code range    
***********************************************************************
 Modification History                                    
=========================================================
16 Jul 2003	Lewis To		Change insert not to handle Risk and Credit Data
16 Sep 2004	Lester Wu		Insert MOA Charege Flag (cpi_moachgflg)
========================================================= */

CREATE PROCEDURE [dbo].[sp_insert_CUPRCINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@cpi_cocde	nvarchar(6),
@cpi_cusno	nvarchar(6),
@cpi_prcfml	nvarchar(20),
@cpi_prcsec	nvarchar(3),
@cpi_grsmgn	numeric(6,3),
@cpi_prctrm	nvarchar(6),
@cpi_paytrm	nvarchar(6),
@cpi_smpprd	nvarchar(20),
@cpi_smpfgt	nvarchar(20),
@cpi_curcde	nvarchar(6),
@cpi_rsklmt	numeric(13,4),
@cpi_rskuse	numeric(13,4),
@cpi_cdtlmt	numeric(13,4),
@cpi_cdtuse	numeric(13,4),
@cpi_moqchgflg	char(1),
@cpi_moachgflg	char(1),		--Add a check box value for MOA Charges  Lester Wu 2004/09/16
@cpi_quplus	numeric(13,4),
@cpi_quminus	numeric(13,4),
@cpi_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  CUPRCINF

(
cpi_cocde,
cpi_cusno,
cpi_prcfml,
cpi_prcsec,
cpi_grsmgn,
cpi_prctrm,
cpi_paytrm,
cpi_smpprd,
cpi_smpfgt,
cpi_curcde,
--cpi_rsklmt,
--cpi_rskuse,
--cpi_cdtlmt,
cpi_moqchgflg,
cpi_moachgflg,	--Lester Wu 2004/09/16 Add MOA Charge Flag
cpi_quplus,
cpi_quminus,
--cpi_cdtuse,
cpi_creusr,
cpi_updusr,
cpi_credat,
cpi_upddat

 )
--------------------------------------------------------------------------------------------------------------------------------------
values
(
@cpi_cocde,
@cpi_cusno,
@cpi_prcfml,
@cpi_prcsec,
@cpi_grsmgn,
@cpi_prctrm,
@cpi_paytrm,
@cpi_smpprd,
@cpi_smpfgt,
@cpi_curcde,
--@cpi_rsklmt,
--@cpi_rskuse,
--@cpi_cdtlmt,
@cpi_moqchgflg,
@cpi_moachgflg,	--Lester Wu 2004/09/16 Add MOA Charge Flag
@cpi_quplus,
@cpi_quminus,
--@cpi_cdtuse,
@cpi_updusr,
@cpi_updusr,
getdate(),
getdate()
)






GO
GRANT EXECUTE ON [dbo].[sp_insert_CUPRCINF] TO [ERPUSER] AS [dbo]
GO
