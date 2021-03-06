/****** Object:  StoredProcedure [dbo].[sp_select_CUPRCINF_CUM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUPRCINF_CUM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUPRCINF_CUM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
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
17 Sept 2003	Marco Chan	Fix for secondary customer record not found problem
16 Sep	2004	Lester Wu	Return MOA Charege Flag (cpi_moachgflg)
========================================================= */

CREATE procedure [dbo].[sp_select_CUPRCINF_CUM00001]
                                                                                                                                                                                                                                                                 

@cpi_cocde	nvarchar(6),
@cpi_cusno	nvarchar(6)
                                               
 
AS



begin 
Select	cpi_cocde,		cpi_cusno,		cpi_prcfml,
	cpi_prcsec,		cpi_grsmgn,	
	cpi_prctrm,	cpi_paytrm,	cpi_smpprd,
	cpi_smpfgt,
	cpi_curcde,
	isnull(cbc_cdtlmt, 0) as 'cpi_cdtlmt',
	isnull(cbc_cdtuse, 0) as 'cpi_cdtuse',
	cast(cpi_timstp as int) as cpi_timstp,
	isnull(cbc_rsklmt, 0) as 'cpi_rsklmt',
	isnull(cbc_rskuse, 0) as 'cpi_rskuse',
 	isnull(cpi_moqchgflg,'N') as 'cpi_moqchgflg',
	isnull(cpi_moachgflg,'N') as 'cpi_moachgflg',	--2004/09/16 Lester Wu	Return MOA Charege Flag (cpi_moachgflg)
	cpi_quplus,
	cpi_quminus
 from CUPRCINF
left join CUBCR on cbc_cusno = cpi_cusno
 where
 cpi_cusno = @cpi_cusno 
end






GO
GRANT EXECUTE ON [dbo].[sp_select_CUPRCINF_CUM00001] TO [ERPUSER] AS [dbo]
GO
