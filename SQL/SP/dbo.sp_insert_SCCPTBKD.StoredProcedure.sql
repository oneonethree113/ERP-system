/****** Object:  StoredProcedure [dbo].[sp_insert_SCCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SCCPTBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SCCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








/*
=================================================================
Program ID	: sp_insert_SCCPTBKD
Description	: Insert Component Breakdown for SC
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-07-18 	David Yue		SP Created
=================================================================
*/

CREATE procedure [dbo].[sp_insert_SCCPTBKD]
@scb_cocde	nvarchar(6),
@scb_ordno	nvarchar(20),
@scb_ordseq	int,
@scb_itmno	nvarchar(20),
@scb_cpt	nvarchar(200),
@scb_curcde	nvarchar(6),
@scb_cst	numeric(13,4),
@scb_cstpct	numeric(13,4),
@scb_pct	numeric(6,3),
@creusr		nvarchar(30)

as

declare @maxseq int
select	@maxseq = isnull(max(scb_cptseq),0) + 1
from	SCCPTBKD (nolock)
where	scb_cocde = @scb_cocde and
	scb_ordno = @scb_ordno and
	scb_ordseq = @scb_ordseq

insert into SCCPTBKD
(	scb_cocde,	scb_ordno,	scb_ordseq,
	scb_itmno,	scb_cptseq,	scb_cpt,
	scb_curcde,	scb_cst,	scb_cstpct,
	scb_pct,	scb_creusr,	scb_updusr,
	scb_credat,	scb_upddat
)
values
(	@scb_cocde,	@scb_ordno,	@scb_ordseq,
	@scb_itmno,	@maxseq,	@scb_cpt,
	@scb_curcde,	@scb_cst,	@scb_cstpct,
	@scb_pct,	@creusr,	@creusr,
	getdate(),	getdate()
)






GO
GRANT EXECUTE ON [dbo].[sp_insert_SCCPTBKD] TO [ERPUSER] AS [dbo]
GO
