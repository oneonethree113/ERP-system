/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUPRCTRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUPRCTRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUPRCTRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/************************************************************************
Author:		Frankie Cheung
Date:		01st June, 2009
Description:	Physical Delete CUPRCTRM data
Parameter:	1. Company Code range    
		2. Vendor no.
		3. Item Nature Seq.
************************************************************************/


CREATE PROCEDURE [dbo].[sp_physical_delete_CUPRCTRM] 

@cpt_cocde nvarchar(6),
@cpt_cusno nvarchar(6),
@cpt_prctrm nvarchar(6)
 

AS

BEGIN

Delete from CUPRCTRM
where 	
 	cpt_cusno = @cpt_cusno
and 	cpt_prctrm = @cpt_prctrm

END



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUPRCTRM] TO [ERPUSER] AS [dbo]
GO
