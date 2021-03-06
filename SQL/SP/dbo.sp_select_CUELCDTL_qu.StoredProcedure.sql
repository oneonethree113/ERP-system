/****** Object:  StoredProcedure [dbo].[sp_select_CUELCDTL_qu]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUELCDTL_qu]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUELCDTL_qu]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Lester Wu    
Date:		28th September, 2008
Description:	Select data From CUELCDTL
***********************************************************************
*/

CREATE procedure [dbo].[sp_select_CUELCDTL_qu]


@ced_cocde	nvarchar(6),
@ced_cusno	nvarchar(6)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------


SELECT	
ced_cusno,
ced_grpcde,
cec_grpdsc as 'ced_grpdsc',
ced_seq,
ced_cecde,
ysi_dsc as 'ced_cedsc',
ced_percent,
ced_chg
from CUELCDTL
left join CUELC on cec_grpcde = ced_grpcde and cec_cusno = ced_cusno
left join SYSETINF on ysi_cde = ced_cecde and ysi_typ = '17'
where	
ced_cusno = @ced_cusno
order by ced_cusno, ced_grpcde, ced_seq

END


GO
GRANT EXECUTE ON [dbo].[sp_select_CUELCDTL_qu] TO [ERPUSER] AS [dbo]
GO
