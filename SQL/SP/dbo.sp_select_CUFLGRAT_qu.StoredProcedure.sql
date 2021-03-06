/****** Object:  StoredProcedure [dbo].[sp_select_CUFLGRAT_qu]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUFLGRAT_qu]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUFLGRAT_qu]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/***********************************************************************************
Author:		Frankie Cheung
Date:		10th December, 2008
Description:	Select data From CUFLGRAT (Customer Flight Rate)
************************************************************************************
*/

CREATE procedure [dbo].[sp_select_CUFLGRAT_qu]

@cfr_cocde	nvarchar(6),
@cfr_cusno	nvarchar(10),
@cfr_prctrm	nvarchar(12),
@creusr	nvarchar(30) 
AS

BEGIN

--------------------------------------------------------------------------------------------------


SELECT	
'' as cfr_del,
cfr_cocde,
cfr_cusno,
cfr_prctrm,
isnull(cfr_flgrat,0) as 'cfr_flgrat' ,
cfr_creusr,
cfr_updusr,
cfr_credat,
cfr_upddat

from CUFLGRAT
where	
cfr_cusno = @cfr_cusno and
cfr_prctrm = @cfr_prctrm
order by cfr_cusno, cfr_prctrm

END



GO
GRANT EXECUTE ON [dbo].[sp_select_CUFLGRAT_qu] TO [ERPUSER] AS [dbo]
GO
