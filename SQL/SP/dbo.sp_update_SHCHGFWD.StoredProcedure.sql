/****** Object:  StoredProcedure [dbo].[sp_update_SHCHGFWD]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SHCHGFWD]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SHCHGFWD]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO















/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SHCHGFWD
***********************************************************************
*/
CREATE      procedure [dbo].[sp_update_SHCHGFWD]

@scf_docno nvarchar(20),
@scf_fwdnam nvarchar(200),
@scf_fwdinv nvarchar(200),
@scf_fcrno nvarchar(200),
@scf_fcurcde nvarchar(10),
@scf_exrate decimal(9,4),
@scf_rmk nvarchar(1000),
@scf_ttlamt decimal(13,4),
@scf_updusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


update SHCHGFWD
set
scf_fwdnam=@scf_fwdnam,
scf_fwdinv = @scf_fwdinv,
scf_fcrno = @scf_fcrno,
scf_fcurcde = @scf_fcurcde,
scf_exrate = @scf_exrate,
scf_rmk = @scf_rmk,
scf_ttlamt= @scf_ttlamt,
scf_updusr = @scf_updusr,
scf_upddat = getdate()
WHERE	
scf_docno = @scf_docno
and scf_fwdnam = @scf_fwdnam



END














GO
GRANT EXECUTE ON [dbo].[sp_update_SHCHGFWD] TO [ERPUSER] AS [dbo]
GO
