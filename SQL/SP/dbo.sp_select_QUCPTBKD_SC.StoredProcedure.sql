/****** Object:  StoredProcedure [dbo].[sp_select_QUCPTBKD_SC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUCPTBKD_SC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUCPTBKD_SC]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=================================================================
Program ID	: sp_select_QUCPTBKD_SC
Description	: Retrieve Component Breakdown from Quotation
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=========
========================================================
2013-05-08 	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_select_QUCPTBKD_SC]
@cocde	varchar(6),
@qutno	varchar(20),
@itmno	varchar(20),
@untcde	varchar(6),
@inrqty	int,
@mtrqty int,
@colcde varchar(20)
as

select	qcb_cocde,
	qcb_qutno,
	qcb_qutseq,
	qcb_itmno,
	qud_untcde,
	qud_inrqty,
	qud_mtrqty,
	qcb_cptseq,
	qcb_cpt,
	qcb_curcde,
	qcb_cst,
	qcb_cstpct,
	qcb_pct,
	qcb_creusr
from	QUCPTBKD (nolock)
	left join QUOTNDTL (nolock) on
		qcb_cocde = qud_cocde and
		qcb_qutno = qud_qutno and
		qcb_qutseq = qud_qutseq and
		qcb_itmno = qud_itmno
where	qud_cocde = @cocde and
	qud_qutno = @qutno and
	qud_itmno = @itmno and
	qud_untcde = @untcde and
	qud_inrqty = @inrqty and
	qud_mtrqty = @mtrqty and
	qud_colcde = @colcde
order by qcb_qutseq, qcb_cptseq



GO
GRANT EXECUTE ON [dbo].[sp_select_QUCPTBKD_SC] TO [ERPUSER] AS [dbo]
GO
