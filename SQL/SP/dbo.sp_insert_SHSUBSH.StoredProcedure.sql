/****** Object:  StoredProcedure [dbo].[sp_insert_SHSUBSH]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SHSUBSH]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SHSUBSH]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
***********************************************************************
sp_insert_SHSUBSH 'UCP','50155', '01/01/2010', '05/01/2010','S', '','mis'
*/


CREATE procedure [dbo].[sp_insert_SHSUBSH]
@hsh_cocde nvarchar(10),
@hsh_cinvno nvarchar(20),
@hsh_cshpno nvarchar(20),
@hsh_invno nvarchar(20),
@hsh_shpno nvarchar(20),
@hsh_cusno nvarchar(10),
@usrid nvarchar(30)
 
AS

BEGIN

insert into SHSUBSH
(hsh_cocde,
 hsh_cinvno,
 hsh_cshpno,
 hsh_invno,
 hsh_shpno,
 hsh_cusno,
 hsh_creusr,
 hsh_updusr,
 hsh_credat,
 hsh_upddat)
values
(@hsh_cocde,
 @hsh_cinvno,
 @hsh_cshpno,
 @hsh_invno,
 @hsh_shpno,
 @hsh_cusno,
 @usrid,
 @usrid,
 getdate(),
 getdate())



END








GO
GRANT EXECUTE ON [dbo].[sp_insert_SHSUBSH] TO [ERPUSER] AS [dbo]
GO
