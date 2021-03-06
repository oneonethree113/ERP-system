/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUFLGRAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUFLGRAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUFLGRAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/************************************************************************
Author:		Frankie Cheung
Date:		10th December, 2008
Description:	delete data From CUFLGRAT
***********************************************************************
*/

CREATE procedure [dbo].[sp_physical_delete_CUFLGRAT]

@cfr_cocde	nvarchar(6),
@cfr_cusno	nvarchar(6),
@cfr_prctrm	nvarchar(100)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------

Delete FROM CUFLGRAT
WHERE	
cfr_cusno = @cfr_cusno and
cfr_prctrm = ltrim(rtrim(@cfr_prctrm))

END


GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUFLGRAT] TO [ERPUSER] AS [dbo]
GO
