/****** Object:  StoredProcedure [dbo].[sp_update_CUSHPMRK]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUSHPMRK]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/************************************************************************
Author:		Kath Ng     
Date:		5th October, 2001
Description:	Update data into CUSHPMRK
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_update_CUSHPMRK] 
--------------------------------------------------------------------------------------------------------------------------------------

@csm_cocde	nvarchar(6),
@csm_cusno	nvarchar(6),
@csm_seqno	int,
@csm_custyp	nvarchar(1),
@csm_shptyp	nvarchar(30),
@csm_engdsc	nvarchar(1600),
@csm_chndsc	nvarchar(3200),
@csm_engrmk	nvarchar(1600),
@csm_chnrmk	nvarchar(3200),
@csm_imgpth	nvarchar(200),
@csm_imgnam	nvarchar(30),
@csm_cerdoc	nvarchar(500),
@csm_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

update CUSHPMRK set
csm_custyp = @csm_custyp,
csm_shptyp = @csm_shptyp,
csm_engdsc = @csm_engdsc,
csm_chndsc = @csm_chndsc,
csm_engrmk = @csm_engrmk,
csm_chnrmk = @csm_chnrmk,
csm_imgpth = @csm_imgpth,
csm_imgnam = @csm_imgnam,
csm_cerdoc = @csm_cerdoc,
csm_updusr = @csm_updusr,
csm_upddat = getdate()
--------------------------------------------------------------------------------------------------------------------------------------
where 

--csm_cocde = @csm_cocde and 
csm_cusno = @csm_cusno and 
csm_seqno = @csm_seqno
--------------------------------------------------------------------------------------------------------------------------------------




GO
GRANT EXECUTE ON [dbo].[sp_update_CUSHPMRK] TO [ERPUSER] AS [dbo]
GO
