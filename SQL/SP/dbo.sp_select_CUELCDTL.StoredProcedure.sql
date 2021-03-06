/****** Object:  StoredProcedure [dbo].[sp_select_CUELCDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUELCDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUELCDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu    
Date:		12th September, 2008
Description:	Select data From CUELCDTL
***********************************************************************
*/

CREATE procedure [dbo].[sp_select_CUELCDTL]


@ced_cocde	nvarchar(6),
@ced_cusno	nvarchar(6)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------


SELECT	
'' as ced_del,
ced_cusno,
ced_grpcde,
cec_grpdsc as 'ced_grpdsc',
ced_seq,
ced_cecde,
ysi_dsc as 'ced_cedsc',
ced_percent,
ced_chg,
ced_creusr,
ced_updusr,
ced_credat,
ced_upddat,
cast(ced_timstp as int) as ced_timstp
from CUELCDTL
left join CUELC on cec_grpcde = ced_grpcde and cec_cusno = ced_cusno
left join SYSETINF on ysi_cde = ced_cecde and ysi_typ = '17'
where	
ced_cusno = @ced_cusno
order by ced_cusno, ced_grpcde, ced_seq

END






GO
GRANT EXECUTE ON [dbo].[sp_select_CUELCDTL] TO [ERPUSER] AS [dbo]
GO
