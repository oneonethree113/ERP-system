/****** Object:  StoredProcedure [dbo].[sp_insert_CUCSTAMT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUCSTAMT]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUCSTAMT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu
Date:		12th September, 2008
Description:	insert data into CUCSTAMT
***********************************************************************
*/

CREATE procedure [dbo].[sp_insert_CUCSTAMT]

@cca_cocde	nvarchar(6),
@cca_cusno 	nvarchar(6),
@cca_cecde	nvarchar(6),
@cca_seq	int,
@cca_curcde	nvarchar(6),
@cca_bp1	numeric(13, 4),
@cca_bp2	numeric(13, 4),
@cca_estqty	numeric(13, 0),
@cca_creusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


insert into CUCSTAMT
(
cca_cusno,
cca_cecde,
cca_seq,
cca_curcde,
cca_bp1,
cca_bp2,
cca_estqty,
cca_creusr,
cca_updusr,
cca_credat,
cca_upddat)
values
(
@cca_cusno,
@cca_cecde,
@cca_seq,
@cca_curcde,
@cca_bp1,
@cca_bp2,
@cca_estqty,
@cca_creusr,
@cca_creusr,
getdate(),
getdate()
)

END







GO
GRANT EXECUTE ON [dbo].[sp_insert_CUCSTAMT] TO [ERPUSER] AS [dbo]
GO
