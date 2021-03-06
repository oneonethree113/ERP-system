/****** Object:  StoredProcedure [dbo].[sp_update_SHCHGDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SHCHGDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SHCHGDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SHCHGDTL
***********************************************************************
*/

CREATE   procedure [dbo].[sp_update_SHCHGDTL]

@scd_cocde	nvarchar(6),
@scd_docno	nvarchar(20),
@scd_fwdnam	nvarchar(200),
@scd_venno	nvarchar(6),
@scd_chgcde	nvarchar(20),
@scd_syscbm	numeric(13,4),
@scd_mancbm	numeric(13,4),
@scd_curcde	nvarchar(6),
@scd_fee	numeric(13,4),
@scd_updusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


update SHCHGDTL
set
scd_syscbm = @scd_syscbm,
scd_mancbm = @scd_mancbm,
scd_fee = @scd_fee,
scd_updusr = @scd_updusr,
scd_upddat = getdate()
WHERE	
scd_docno = @scd_docno
and scd_fwdnam = @scd_fwdnam
and scd_venno = @scd_venno
and scd_chgcde = @scd_chgcde
and scd_curcde = @scd_curcde


END











GO
GRANT EXECUTE ON [dbo].[sp_update_SHCHGDTL] TO [ERPUSER] AS [dbo]
GO
