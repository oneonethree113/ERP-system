/****** Object:  StoredProcedure [dbo].[sp_update_CUPRCINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUPRCINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUPRCINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/************************************************************************
Author:		Kath Ng     
Date:		24th September, 2001
Description:	Update data into CUPRCINF
Parameter:	1. Company Code range    
		2. Customer Code range    
***********************************************************************
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
19 Jun 2003	Lewis To	Add field MOQ Charges handle (cpi_moqchg)    
16 Jul 2003	Lewis To	Add handle update risk and credit limite update to CUBCR  
16 Sep	2004	Lester Wu	Update MOA Charege Flag (cpi_moachgflg)         
=========================================================     
*/

CREATE PROCEDURE [dbo].[sp_update_CUPRCINF] 
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
@cpi_moqchgflg	char(1),		--Add a check box value for MOQ Charges
@cpi_moachgflg	char(1),		--Add a check box value for MOA Charges	Lester Wu 2004/09/16
@cpi_quplus	numeric(13,4),
@cpi_quminus	numeric(13,4),
@cpi_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

update CUPRCINF  set


cpi_prcfml = @cpi_prcfml,
cpi_prcsec = @cpi_prcsec,
cpi_grsmgn = @cpi_grsmgn,
cpi_prctrm = @cpi_prctrm,
cpi_paytrm = @cpi_paytrm,
cpi_smpprd = @cpi_smpprd,
cpi_smpfgt = @cpi_smpfgt,
cpi_curcde = @cpi_curcde,
--cpi_rsklmt = @cpi_rsklmt,
--cpi_rskuse = @cpi_rskuse,
--cpi_cdtlmt = @cpi_cdtlmt,
cpi_moqchgflg =@cpi_moqchgflg	,
cpi_moachgflg =@cpi_moachgflg	,	--Lester Wu 2004/09/16 Update MOA Charege Flag
--cpi_cdtuse = @cpi_cdtuse,
cpi_quplus = @cpi_quplus,
cpi_quminus = @cpi_quminus,
cpi_updusr = @cpi_updusr,
cpi_upddat	= getdate()
--------------------------------------------------------------------------------------------------------------------------------------
where 

--cpi_cocde	= @cpi_cocde and 
cpi_cusno	= @cpi_cusno
--------------------------------------------------------------------------------------------------------------------------------------






GO
GRANT EXECUTE ON [dbo].[sp_update_CUPRCINF] TO [ERPUSER] AS [dbo]
GO
