/****** Object:  StoredProcedure [dbo].[sp_insert_SYMSHC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYMSHC]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYMSHC]    Script Date: 09/29/2017 11:53:53 ******/
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

CREATE procedure [dbo].[sp_insert_SYMSHC]

@ysc_cocde	nvarchar(6),
@ysc_chgcde	nvarchar(20),
@ysc_chgdsc	nvarchar(200),
@ysc_chgtyp	char(1),
@ysc_creusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


insert into SYMSHC
(
ysc_chgcde,
ysc_chgdsc,
ysc_chgtyp,
ysc_creusr,
ysc_updusr,
ysc_credat,
ysc_upddat)
values
(
@ysc_chgcde,
@ysc_chgdsc,
@ysc_chgtyp,
@ysc_creusr,
@ysc_creusr,
getdate(),
getdate()
)

END








GO
GRANT EXECUTE ON [dbo].[sp_insert_SYMSHC] TO [ERPUSER] AS [dbo]
GO
