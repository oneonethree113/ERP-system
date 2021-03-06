/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Kath Ng     
Date:		13th September, 2001
Description:	Select data From CUBASINF
****************
Modified by Solo So As at 2002-07-06
Add field for CUM00002.FRM
to handle Inactive or Discontinue Customer
************************************************************************
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
ALTER  Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
17 Jun 2003	Lewis To		Add field alias (cbi_cusali)      
11 Jul 2003	Lewis To		Ignor the COmpany Code to handle multi COmpany          
=========================================================     
*/
CREATE procedure [dbo].[sp_select_CUBASINF]
                                                                                                                                                                                                                                                                 

@cbi_cocde nvarchar(6) ,
@cbi_cusno nvarchar(20) 
 
AS

begin

Select	cbi_cocde,	cbi_cusno,	cbi_custyp,
	cbi_cussts,	cbi_cussna,	cbi_cusnam,
	cbi_cusweb,      isnull(cbi_saltem ,'')as 'cbi_saltem' ,  
	isnull(cbi_saldiv,'')as 'cbi_saldiv',	cbi_salrep,	
	cbi_salmgt, 	cbi_srname,
	cbi_refno,	cbi_cusrat,	cbi_mrkreg,
	cbi_mrktyp,	cbi_advord,	isnull(cbi_rmk, ' ') AS cbi_rmk,
	cbi_cuspod,	cbi_cusfde,	cbi_cuscfs,
	cbi_custhc,	cbi_cuspro,	cbi_creusr,	
	cbi_updusr,	cbi_credat,	cbi_upddat,	
	cbi_cerdoc,
	cast(cbi_timstp as int) as cbi_timstp,
	isnull(ysr_saltem,'') as 'ysr_saltem',
	cbi_cusnam_id = Case cbi_cussts when 'A' then cbi_cusnam when 'I' then rtrim(cbi_cusnam) + '(Inactive)' when 'D' then rtrim(cbi_cusnam) + '(Discontinue)' else cbi_cusnam end,
	isnull(cbi_cusali,'')   as 'cbi_cusali' ,-- add by Lewis
	isnull(cbi_cugrptyp_int ,'') as 'cbi_cugrptyp_int',
	isnull(cbi_cugrptyp_ext,'') as 'cbi_cugrptyp_ext',
	cbi_rounding,
	cbi_cbinv,
	cbi_cbinvwarn
 from CUBASINF
left join  SYSALREP  on ysr_cocde =' ' -- cbi_cocde 
and ysr_code1 = cbi_salrep
 where
--cbi_cocde = @cbi_cocde and
cbi_cusno = @cbi_cusno


end







GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF] TO [ERPUSER] AS [dbo]
GO
