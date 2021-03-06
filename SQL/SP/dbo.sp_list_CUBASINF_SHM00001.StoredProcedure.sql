/****** Object:  StoredProcedure [dbo].[sp_list_CUBASINF_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUBASINF_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUBASINF_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
Parameter:	
=========================================================
 Modification History                                    
=========================================================
 Date      	Initial  	Description          
2003-08-20	Allan Yuen	Fix Deadlock error.               
=========================================================     
*/




CREATE PROCEDURE [dbo].[sp_list_CUBASINF_SHM00001] 

@cbi_cocde as nvarchar(6),
@cbi_custyp as nvarchar(1)

as

SELECT        

cbi_cocde,
cbi_cusno,
cbi_custyp,
cbi_cussts,
case when cbi_cussts = 'A' then cbi_cussna else 
case when cbi_cussts = 'D' then ltrim(cbi_cussna) + '(Discontinue)' else
case when cbi_cussts = 'I' then ltrim(cbi_cussna) + '(Inactive)' end end end as 'cbi_cussna',
cbi_cusnam,
cbi_cusweb,
cbi_salrep,
cbi_salmgt,
cbi_refno,
cbi_cusrat,
cbi_mrkreg,
cbi_mrktyp,
cbi_advord,
cbi_rmk,
cbi_cuspod,
cbi_cusfde,
cbi_cuscfs,
cbi_custhc,
cbi_cuspro,
cbi_cerdoc,
cbi_creusr,
cbi_updusr,
cbi_credat,
cbi_upddat,
cbi_timstp,
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
cpi_cdtlmt,
cpi_cdtuse,
cpi_creusr,
cpi_updusr,
cpi_credat,
cpi_upddat,
cpi_timstp

FROM             
	CUBASINF (nolock)
	left join CUPRCINF (nolock) on 
		--cbi_cocde = cpi_cocde and 
		cbi_cusno = cpi_cusno
WHERE         
	--(cbi_cocde = @cbi_cocde) AND 
	(cbi_custyp = @cbi_custyp) 
	AND (cbi_cussts = 'A')

order by 
	cbi_cusno







GO
GRANT EXECUTE ON [dbo].[sp_list_CUBASINF_SHM00001] TO [ERPUSER] AS [dbo]
GO
