/****** Object:  StoredProcedure [dbo].[sp_select_CUPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUPRCINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Kath Ng     
Date:		24th September, 2001
Description:	Select data From CUPRCINF
Parameter:	1. Company Code range    
		2. Customer Code range    
***********************************************************************
 Modification History                                    
=========================================================
16 Jul 2003	Lewis To		Change to get risk credit Date from CUBCR, 
				field name dose not change
08 Oct 2004	Allan Yuen	Add select MOA Charge Flag
========================================================= */

CREATE procedure [dbo].[sp_select_CUPRCINF]
                                                                                                                                                                                                                                                                 

@cpi_cocde	nvarchar(6),
@cpi_cusno	nvarchar(6)
                                               
 
AS


if @cpi_cocde = ' '  or @cpi_cocde = ''  
begin 
Select	cpi_cocde,		cpi_cusno,		cpi_prcfml,
	cpi_prcsec,		cpi_grsmgn,	
	cpi_prctrm,	cpi_paytrm,	cpi_smpprd,
	cpi_smpfgt,
	cpi_curcde,
	cbc_cdtlmt as 'cpi_cdtlmt',
	cbc_cdtuse as 'cpi_cdtuse',
	cast(cpi_timstp as int) as cpi_timstp,
	cbc_rsklmt as 'cpi_rsklmt',
	cbc_rskuse as 'cpi_rskuse',
 	isnull(cpi_moqchgflg,'N') as 'cpi_moqchgflg',
 	isnull(cpi_moachgflg,'N') as 'cpi_moachgflg',
 	cpi_quplus,
 	cpi_quminus                                  

 from CUPRCINF, CUBCR
 where
 --cpi_cocde = @cpi_cocde and
 cpi_cusno = @cpi_cusno and
cbc_cusno = @cpi_cusno 
end

if @cpi_cocde <> ' ' and @cpi_cocde <> ''  
begin 
Select	cpi_cocde,		cpi_cusno,		cpi_prcfml,
	cpi_prcsec,		cpi_grsmgn,	
	cpi_prctrm,	cpi_paytrm,	cpi_smpprd,
	cpi_smpfgt,
	cpi_curcde,
	cbc_cdtlmt as 'cpi_cdtlmt',
	cbc_cdtuse as 'cpi_cdtuse',
	cast(cpi_timstp as int) as cpi_timstp,
	cbc_rsklmt as 'cpi_rsklmt',
	cbc_rskuse as 'cpi_rskuse',
 	isnull(cpi_moqchgflg,'N') as 'cpi_moqchgflg',
 	isnull(cpi_moachgflg,'N') as 'cpi_moachgflg',
 	cpi_quplus,
 	cpi_quminus                                  

 from CUPRCINF, CUBCR
 where
cpi_cusno = @cpi_cusno and
cbc_cusno = @cpi_cusno and
cbc_cocde = @cpi_cocde 
	
                           
end



GO
GRANT EXECUTE ON [dbo].[sp_select_CUPRCINF] TO [ERPUSER] AS [dbo]
GO
