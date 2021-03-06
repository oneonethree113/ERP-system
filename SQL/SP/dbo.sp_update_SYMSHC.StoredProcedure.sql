/****** Object:  StoredProcedure [dbo].[sp_update_SYMSHC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYMSHC]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYMSHC]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SYMSHC
***********************************************************************
*/

CREATE procedure [dbo].[sp_update_SYMSHC]


@ysc_cocde	nvarchar(6),
@ysc_chgcde	nvarchar(20),
@ysc_chgdsc	nvarchar(200),
@ysc_chgtyp	char(1),
@ysc_updusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


update SYMSHC
set
ysc_chgdsc = @ysc_chgdsc,
ysc_chgtyp = @ysc_chgtyp,
ysc_updusr = @ysc_updusr,
ysc_upddat = getdate()
WHERE	
ysc_chgcde = @ysc_chgcde


END








GO
GRANT EXECUTE ON [dbo].[sp_update_SYMSHC] TO [ERPUSER] AS [dbo]
GO
