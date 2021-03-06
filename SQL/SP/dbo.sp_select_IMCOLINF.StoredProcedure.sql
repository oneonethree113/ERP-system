/****** Object:  StoredProcedure [dbo].[sp_select_IMCOLINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMCOLINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMCOLINF]    Script Date: 09/29/2017 11:53:53 ******/
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
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject
*/


/************************************************************************
Author:		Kenny Chan
Date:		14th September, 2001
Description:	Select data From IMCOLINF
Parameter:	1. Company
		2. Item No.	
************************************************************************/
CREATE PROCEDURE [dbo].[sp_select_IMCOLINF]

@icf_cocde	nvarchar(6),
@icf_itmno	nvarchar(20)

AS

Select
' ' as 'icf_status',
'' as 'icf_cocde',
icf_itmno,
--icf_venno,
icf_colcde,
icf_typ,
icf_coldsc,
icf_vencol,
icf_asscol,
icf_lnecde,
icf_ucpcde,
icf_eancde,
icf_swatchpath,
icf_imgpath,
icf_creusr,
icf_updusr,
icf_credat,
icf_upddat,
cast(icf_timstp as int) as icf_timstp,
icf_colseq
from IMCOLINF
where 
--icf_cocde = @icf_cocde and
icf_itmno = @icf_itmno

GO
GRANT EXECUTE ON [dbo].[sp_select_IMCOLINF] TO [ERPUSER] AS [dbo]
GO
