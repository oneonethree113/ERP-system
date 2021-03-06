/****** Object:  StoredProcedure [dbo].[sp_insert_CURETPRC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CURETPRC]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CURETPRC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu
Date:		12th September, 2008
Description:	insert data into CURETPRC
***********************************************************************
*/

CREATE procedure [dbo].[sp_insert_CURETPRC]
@crp_cocde	nvarchar(6),
@crp_cusno	nvarchar(6),
@crp_rpcde	nvarchar(6),
@crp_pmu	nvarchar(100),
@crp_fml	nvarchar(6),
@crp_default	char(1),
@crp_creusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


insert into CURETPRC
(
crp_cusno,
crp_rpcde,
crp_pmu,
crp_fml,
crp_default,
crp_creusr,
crp_updusr,
crp_credat,
crp_upddat
)
values
(
@crp_cusno,
@crp_rpcde,
@crp_pmu,
@crp_fml,
@crp_default,
@crp_creusr,
@crp_creusr,
getdate(),
getdate()
)

END







GO
GRANT EXECUTE ON [dbo].[sp_insert_CURETPRC] TO [ERPUSER] AS [dbo]
GO
