/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUSUBCUS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUSUBCUS]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUSUBCUS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/************************************************************************
Author:		Kath Ng     
Date:		17th October, 2001
Description:	Physical Delete CUSUBCUS data
************************************************************************/

CREATE PROCEDURE [dbo].[sp_physical_delete_CUSUBCUS] 

@csc_cocde	nvarchar(6),
@csc_prmcus	nvarchar(6),
@csc_seccus	nvarchar(6),
@Type		nvarchar(4)

AS


------------------------------------------------------------------------------------------

IF @Type = 'DDtl'
BEGIN

DELETE from CUSUBCUS

WHERE	--csc_cocde = @csc_cocde and
	csc_prmcus = @csc_prmcus
and	csc_seccus = @csc_seccus
END
------------------------------------------------------------------------------------------


IF @Type = 'DMtr'
BEGIN
DELETE from CUSUBCUS
WHERE	--csc_cocde = @csc_cocde and (
csc_prmcus = @csc_prmcus  or csc_seccus = @csc_prmcus


END
------------------------------------------------------------------------------------------







GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUSUBCUS] TO [ERPUSER] AS [dbo]
GO
