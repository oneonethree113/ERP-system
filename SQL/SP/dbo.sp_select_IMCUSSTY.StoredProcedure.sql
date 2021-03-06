/****** Object:  StoredProcedure [dbo].[sp_select_IMCUSSTY]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMCUSSTY]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMCUSSTY]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Lester Wu    
Date:		12th September, 2008
Description:	Select data From CUCSTEMT
***********************************************************************
*/

CREATE procedure [dbo].[sp_select_IMCUSSTY]


@ics_cocde	nvarchar(6),
@ics_itmno	nvarchar(20)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------


SELECT	
ics_cusno,
cbi_cussna as 'ics_cussna',
ics_cusstyno,
ics_itmno,
ics_creusr,
ics_updusr,
ics_credat,
ics_upddat,
cast(ics_timstp as int) as ics_timstp
from IMCUSSTY (nolock)
left join CUBASINF (nolock) on cbi_cusno = ics_cusno
where	
ics_itmno = @ics_itmno
order by ics_cusno

END







GO
GRANT EXECUTE ON [dbo].[sp_select_IMCUSSTY] TO [ERPUSER] AS [dbo]
GO
