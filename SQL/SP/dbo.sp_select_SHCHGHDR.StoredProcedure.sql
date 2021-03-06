/****** Object:  StoredProcedure [dbo].[sp_select_SHCHGHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHCHGHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHCHGHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SHCHGHDR
***********************************************************************
*/

CREATE  procedure [dbo].[sp_select_SHCHGHDR]


@sch_cocde	nvarchar(6),
@sch_docno	nvarchar(20)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------
select
sch_docno,
sch_typ,
sch_sts,
sch_curcde,
sch_exchrat,
sch_pckdat,
sch_ctrcfs,
sch_ctrsiz,
sch_invlst,
sch_cuslst,
sch_cusnolst,
sch_etddat,
sch_rmk,
sch_creusr,
sch_updusr,
sch_credat,
sch_upddat,
sch_timstp
from SHCHGHDR 
where sch_docno = @sch_docno


END









GO
GRANT EXECUTE ON [dbo].[sp_select_SHCHGHDR] TO [ERPUSER] AS [dbo]
GO
