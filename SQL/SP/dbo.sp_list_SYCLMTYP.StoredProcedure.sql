/****** Object:  StoredProcedure [dbo].[sp_list_SYCLMTYP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYCLMTYP]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYCLMTYP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
ALTER  Date   	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
*/



CREATE   PROCEDURE [dbo].[sp_list_SYCLMTYP] 

@ycc_cocde 	nvarchar(6) = ' '
AS

Select 
'' as 'yct_del',
yct_cde,
yct_dsc,
yct_cus,
yct_ven,
yct_ucp,
yct_Salaccrgt,	
yct_Shpaccrgt,
yct_Acctaccrgt,
yct_SMApprgt,
yct_SZApprgt,
yct_ShpApprgt,
yct_AppAmt,	
yct_creusr,
yct_updusr,
yct_credat,
yct_upddat,
yct_timstp

from SYCLMTYP











GO
GRANT EXECUTE ON [dbo].[sp_list_SYCLMTYP] TO [ERPUSER] AS [dbo]
GO
