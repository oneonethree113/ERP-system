/****** Object:  StoredProcedure [dbo].[sp_select_CUCSTAMT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUCSTAMT]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUCSTAMT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu    
Date:		12th September, 2008
Description:	Select data From CUCSTAMT
***********************************************************************
*/

CREATE procedure [dbo].[sp_select_CUCSTAMT]


@cca_cocde	nvarchar(6),
@cca_cusno	nvarchar(6)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------


SELECT	
'' as cca_del,
cca_cusno,
cca_cecde,
ysi_dsc as 'cca_cedsc',
cca_seq,
cca_curcde,
cca_bp1,
cca_bp2,
cca_estqty,
cca_creusr,
cca_updusr,
cca_credat,
cca_upddat,
cast(cca_timstp as int) as cca_timstp
from CUCSTAMT
left join SYSETINF on ysi_cde = cca_cecde and ysi_typ = '17'
where	
cca_cusno = @cca_cusno
order by cca_cusno, cca_seq

END






GO
GRANT EXECUTE ON [dbo].[sp_select_CUCSTAMT] TO [ERPUSER] AS [dbo]
GO
