/****** Object:  StoredProcedure [dbo].[sp_insert_SHCPTBKD_cov]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SHCPTBKD_cov]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SHCPTBKD_cov]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE   procedure [dbo].[sp_insert_SHCPTBKD_cov]
@shb_cocde	nvarchar(6),
@shb_ordno	nvarchar(20),
@shb_ordseq	int,
@shb_itmno	nvarchar(20),
@seq	int,
@shb_cpt	nvarchar(200),
@shb_curcde	nvarchar(6),
@shb_cst	numeric(13,4),
@shb_cstpct	numeric(13,4),
@shb_pct	numeric(6,3),
@creusr		nvarchar(30)

as


insert into SHCPTBKD_cov
(	shb_cocde,	shb_ordno,	shb_ordseq,
	shb_itmno,	shb_cptseq,	shb_cpt,
	shb_curcde,	shb_cst,	shb_cstpct,
	shb_pct,	shb_creusr,	shb_updusr,
	shb_credat,	shb_upddat
)
values
(	@shb_cocde,	@shb_ordno,	@shb_ordseq,
	@shb_itmno,	@seq,	@shb_cpt,
	@shb_curcde,	@shb_cst,	@shb_cstpct,
	@shb_pct,	@creusr,	@creusr,
	getdate(),	getdate()
)












GO
GRANT EXECUTE ON [dbo].[sp_insert_SHCPTBKD_cov] TO [ERPUSER] AS [dbo]
GO
