/****** Object:  StoredProcedure [dbo].[sp_update_SHCPTBKD]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SHCPTBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SHCPTBKD]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE  procedure [dbo].[sp_update_SHCPTBKD]
@shb_cocde	nvarchar(6),
@shb_ordno	nvarchar(20),
@shb_ordseq	int,
@shb_itmno	nvarchar(20),
@shb_cptseq	int,
@shb_cpt	nvarchar(200),
@shb_curcde	nvarchar(6),
@shb_cst	numeric(13,4),
@shb_cstpct	numeric(13,4),
@shb_pct	numeric(6,3),
@creusr		nvarchar(30)

as

update	SHCPTBKD
set	shb_cpt	= @shb_cpt,
	shb_curcde = @shb_curcde,
	shb_cst = @shb_cst,
	shb_cstpct = @shb_cstpct,
	shb_pct = @shb_pct,
	shb_updusr = @creusr,
	shb_upddat = getdate()
where	shb_cocde = @shb_cocde and
	shb_ordno = @shb_ordno and
	shb_ordseq = @shb_ordseq and
	shb_cptseq = @shb_cptseq









GO
GRANT EXECUTE ON [dbo].[sp_update_SHCPTBKD] TO [ERPUSER] AS [dbo]
GO
