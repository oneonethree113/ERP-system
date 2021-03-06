/****** Object:  StoredProcedure [dbo].[sp_select_QUCPTBKD]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUCPTBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUCPTBKD]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_select_QUCPTBKD] 

@cocde 		nvarchar(6),
@qutno		nvarchar(20)--,
--@itmno 		nvarchar(20),
--@qutseq		int

AS

declare	@mode 	nvarchar(3)
set @mode = ''


--rem by Lester Wu 2008-10-29
/*
select 	@mode as 'mode', 	qcb_qutno,		qcb_qutseq,	qcb_itmno,
	qcb_cptseq,	qcb_cpt,		qcb_pct
*/
select 	'' as 'DEL', *, @mode as 'mode'

from 	QUCPTBKD 
where 	qcb_cocde = @cocde and 
	qcb_qutno = @qutno --and 
--	qcb_itmno = @itmno and	
--	qcb_qutseq = @qutseq 
order by 	qcb_qutseq, qcb_cptseq


GO
GRANT EXECUTE ON [dbo].[sp_select_QUCPTBKD] TO [ERPUSER] AS [dbo]
GO
