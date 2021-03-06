/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUVENINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUVENINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUVENINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/************************************************************************
Author:		Kath Ng     
Date:		13th September, 2001
Description:	Physical Delete CUVENINF data
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_physical_delete_CUVENINF] 

@cvi_cocde	nvarchar(6),
@cvi_cusno	nvarchar(6),
@cvi_assvid	nvarchar(20),
@Type		nvarchar(4)

AS

--------------------------------------------------------------------------------------------------------------
IF @Type = 'DDtl'
BEGIN
DELETE FROM CUVENINF
WHERE 	--cvi_cocde = @cvi_cocde AND
 	cvi_cusno = @cvi_cusno
AND 	cvi_assvid = @cvi_assvid
END
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
IF @Type = 'DMtr'
BEGIN
DELETE FROM CUVENINF
WHERE 	--cvi_cocde = @cvi_cocde AND
 	cvi_cusno = @cvi_cusno
END
--------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUVENINF] TO [ERPUSER] AS [dbo]
GO
