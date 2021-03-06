/****** Object:  StoredProcedure [dbo].[sp_insert_CUELCDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUELCDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUELCDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu
Date:		12th September, 2008
Description:	insert data into CUELCDTL
***********************************************************************
*/

CREATE procedure [dbo].[sp_insert_CUELCDTL]

@ced_cocde	nvarchar(6),
@ced_cusno	nvarchar(6),
@ced_grpcde	nvarchar(6),
@ced_seq	int,
@ced_cecde	nvarchar(6),
@ced_percent	numeric(13, 4),
@ced_chg	char(1),
@ced_creusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


insert into CUELCDTL
(
ced_cusno,
ced_grpcde,
ced_seq,
ced_cecde,
ced_percent,
ced_chg,
ced_creusr,
ced_updusr,
ced_credat,
ced_upddat)
values
(
@ced_cusno,
@ced_grpcde,
@ced_seq,
@ced_cecde,
@ced_percent,
@ced_chg,
@ced_creusr,
@ced_creusr,
getdate(),
getdate()
)

END







GO
GRANT EXECUTE ON [dbo].[sp_insert_CUELCDTL] TO [ERPUSER] AS [dbo]
GO
