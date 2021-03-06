/****** Object:  StoredProcedure [dbo].[sp_update_QUCPTBKD]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QUCPTBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QUCPTBKD]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/************************************************************************
Author:		Lester Wu    
Date:		28th September, 2008
Description:	Update data to QUCPTBKD
***********************************************************************
*/

CREATE PROCEDURE [dbo].[sp_update_QUCPTBKD] 

@qcb_cocde 	nvarchar(6),	@qcb_qutno 	nvarchar(20),	
@qcb_qutseq 	int,		@qcb_itmno 	nvarchar(20),
@qcb_cptseq 	int,		@qcb_cpt 		nvarchar(200),
@qcb_curcde	nvarchar(6),
@qcb_cst	numeric(13,4), 	@qcb_cstpct	numeric(13,4),
@qcb_pct 			numeric(13,4), 			@qcb_updusr	nvarchar(30)

AS


update QUCPTBKD
set	qcb_cpt = @qcb_cpt ,
	qcb_curcde = @qcb_curcde,	qcb_cst = @qcb_cst,	qcb_cstpct = @qcb_cstpct,
	qcb_pct = @qcb_pct,		qcb_updusr = @qcb_updusr,
	qcb_upddat = getdate()
where qcb_cocde = @qcb_cocde and qcb_qutno = @qcb_qutno and qcb_qutseq = @qcb_qutseq and qcb_itmno = @qcb_itmno
and qcb_cptseq = @qcb_cptseq



GO
GRANT EXECUTE ON [dbo].[sp_update_QUCPTBKD] TO [ERPUSER] AS [dbo]
GO
