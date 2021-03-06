/****** Object:  StoredProcedure [dbo].[sp_update_CUFLGRAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUFLGRAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUFLGRAT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/************************************************************************
Author:		Frankie Cheung
Date:		10th December, 2008
Description:	Update data From CUFLGRAT
***********************************************************************
*/

CREATE procedure [dbo].[sp_update_CUFLGRAT]

@cfr_cocde	nvarchar(6) ,
@cfr_cusno	nvarchar(6),
@cfr_prctrm	nvarchar(100),
@cfr_flgrat	numeric(13,4),
@cfr_updusr	nvarchar(30)
 
AS

BEGIN
--------------------------------------------------------------------------------------------------

update CUFLGRAT
set
	cfr_flgrat = @cfr_flgrat,
	cfr_updusr = @cfr_updusr,
	cfr_upddat = getdate()
WHERE	
	cfr_cusno = @cfr_cusno and
	cfr_prctrm = ltrim(rtrim(@cfr_prctrm))


END



GO
GRANT EXECUTE ON [dbo].[sp_update_CUFLGRAT] TO [ERPUSER] AS [dbo]
GO
