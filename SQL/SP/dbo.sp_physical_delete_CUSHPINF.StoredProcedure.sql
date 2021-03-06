/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUSHPINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUSHPINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUSHPINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/************************************************************************
Author:		Kath Ng     
Date:		5th October, 2001
Description:	Physical Delete CUSHPINF data
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_physical_delete_CUSHPINF] 

@csi_cocde	nvarchar(6),
@csi_cusno	nvarchar(6),
@csi_csetyp	nvarchar(2),
@csi_cseseq	int,
@Type		nvarchar(4)

AS
------------------------------------------------------------------------------------------------------------------------
IF @Type = 'DDtl'
BEGIN
DELETE FROM  CUSHPINF
WHERE	--csi_cocde = @csi_cocde AND
	csi_cusno = @csi_cusno
AND	csi_csetyp = @csi_csetyp
AND	csi_cseseq = @csi_cseseq
END
------------------------------------------------------------------------------------------------------------------------

IF @Type = 'DMtr'
BEGIN
DELETE FROM  CUSHPINF
WHERE	--csi_cocde = @csi_cocde AND
	csi_cusno = @csi_cusno
END
------------------------------------------------------------------------------------------------------------------------







GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUSHPINF] TO [ERPUSER] AS [dbo]
GO
