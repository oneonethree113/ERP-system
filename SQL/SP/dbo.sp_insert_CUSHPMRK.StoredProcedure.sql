/****** Object:  StoredProcedure [dbo].[sp_insert_CUSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/************************************************************************
Author:		Kath Ng     
Date:		5th October, 2001
Description:	Insert data into CUSHPMRK
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_CUSHPMRK] 
--------------------------------------------------------------------------------------------------------------------------------------

@csm_cocde	nvarchar(6),
@csm_cusno	nvarchar(6),
@csm_custyp	nvarchar(1),
@csm_shptyp	nvarchar(30),
@csm_engdsc	nvarchar(1600),
@csm_chndsc	nvarchar(3200),
@csm_engrmk	nvarchar(1600),
@csm_chnrmk	nvarchar(1600),
@csm_imgpth	nvarchar(200),
@csm_imgnam	nvarchar(30),
@csm_cerdoc	nvarchar(500),
@csm_updusr	nvarchar(30)
--------------------------------------------------------------------------------------------------------------------------------------
AS


declare @csm_seqno as int

set  @csm_seqno = (select max(csm_seqno) + 1 from CUSHPMRK where --csm_cocde=@csm_cocde and 
							csm_cusno=@csm_cusno)


IF @csm_seqno is null
BEGIN
set @csm_seqno = 1
END


INSERT INTO  CUSHPMRK
(
csm_cocde,	csm_cusno,
csm_seqno,	csm_custyp,	csm_shptyp,	
csm_engdsc,	csm_chndsc,	csm_engrmk,
csm_chnrmk,	csm_imgpth,	csm_imgnam,
csm_cerdoc,	csm_creusr,	csm_updusr,	
csm_credat,	csm_upddat

)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
@csm_cocde,	@csm_cusno,
@csm_seqno,	@csm_custyp,	@csm_shptyp,	
@csm_engdsc,	@csm_chndsc,	@csm_engrmk,	
@csm_chnrmk,	@csm_imgpth,	@csm_imgnam,	
@csm_cerdoc,	@csm_updusr,	@csm_updusr,	
getdate(),		getdate()

)




GO
GRANT EXECUTE ON [dbo].[sp_insert_CUSHPMRK] TO [ERPUSER] AS [dbo]
GO
