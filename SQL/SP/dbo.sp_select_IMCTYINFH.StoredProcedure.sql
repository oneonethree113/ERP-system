/****** Object:  StoredProcedure [dbo].[sp_select_IMCTYINFH]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMCTYINFH]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMCTYINFH]    Script Date: 09/29/2017 11:53:53 ******/
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
17 July 2003	Allan Yuen		For Merge Porject, disable company code
*/

/************************************************************************
Author:		Kenny Chan
Date:		28th September, 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_select_IMCTYINFH] 

@ici_cocde  	nvarchar(6),
@ici_itmno  	nvarchar(20)

AS


Select 
' ' as 'ici_status',
ici_cocde,
ici_itmno,
ici_ctyseq , 
isnull(ici_cusno + ' - ' + cbi_cusnam,'') as 'ici_cusno',
ISNULL(cbi_cusnam,'N\A')as 'cbi_cusnam',
isnull(ici_ctycde + ' - ' + ysi_dsc, '') as 'ici_ctycde',
ici_valdat ,
ici_rmk , 
ici_creusr,
ici_updusr  ,
ici_credat  ,
ici_upddat ,
cast(ici_timstp as int) as 'ici_timstp'

from IMCTYINFH (nolock)
left join CUBASINF (nolock) on ici_cusno = cbi_cusno --and cbi_cocde = @ici_cocde
left join SYSETINF (nolock) on ysi_typ = '02' and ysi_cde = ici_ctycde
Where 
--ici_cocde = @ici_cocde and
ici_itmno = @ici_itmno 

order by ici_valdat desc








GO
GRANT EXECUTE ON [dbo].[sp_select_IMCTYINFH] TO [ERPUSER] AS [dbo]
GO
