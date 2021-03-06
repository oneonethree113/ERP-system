/****** Object:  StoredProcedure [dbo].[sp_insert_QUCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_QUCPTBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_QUCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




-- Checked by Allan Yuen at 28/07/2003

/*	Author : Tommy Ho	*/

CREATE PROCEDURE [dbo].[sp_insert_QUCPTBKD] 

@qcb_cocde 	nvarchar(6),	@qcb_qutno 	nvarchar(20),	
@qcb_qutseq 	int,		@qcb_itmno 	nvarchar(20),
@qcb_cptseq 	int,		@qcb_cpt 		nvarchar(200),
-- Added by Lester Wu 2008-10-29
@qcb_curcde	nvarchar(6),
@qcb_cst	numeric(13,4), 	@qcb_cstpct	numeric(13,4),
@qcb_pct 		numeric(13,4), 			@qcb_creusr	nvarchar(30)

AS

-- Added by Lester Wu 2008-10-29
declare @cnt int
set @cnt = 0
-- Get latest seq
select @cnt = isnull(max(qcb_cptseq),0) from qucptbkd 
where qcb_cocde = @qcb_cocde and qcb_qutno = @qcb_qutno and qcb_qutseq = @qcb_qutseq and qcb_itmno = @qcb_itmno



set @cnt = @cnt + 1
set @qcb_cptseq = @cnt



insert into [QUCPTBKD]
(
	qcb_cocde ,	qcb_qutno ,	qcb_qutseq ,
	qcb_itmno ,	qcb_cptseq ,	qcb_cpt ,
	-- Added by Lester Wu 2008-10-29
	qcb_curcde,	qcb_cst,	qcb_cstpct,
	qcb_pct ,		qcb_creusr ,	qcb_updusr ,
	qcb_credat ,	qcb_upddat 	
)
values
(
	@qcb_cocde ,	@qcb_qutno ,	@qcb_qutseq ,
	@qcb_itmno ,	@qcb_cptseq ,	@qcb_cpt ,
	-- Added by Lester Wu 2008-10-29
	@qcb_curcde,	@qcb_cst,	@qcb_cstpct,
	@qcb_pct ,	@qcb_creusr ,	@qcb_creusr ,
	getdate() ,		getdate()
)






GO
GRANT EXECUTE ON [dbo].[sp_insert_QUCPTBKD] TO [ERPUSER] AS [dbo]
GO
