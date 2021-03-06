/****** Object:  StoredProcedure [dbo].[sp_select_SCR00001_matbkd]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCR00001_matbkd]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCR00001_matbkd]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=================================================================
Program ID	: sp_select_SCR00001_matbkd
Description	: Retrieve Material Breakdown for SC Report
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-01-02 	David Yue		SP Created
=================================================================
*/


CREATE PROCEDURE [dbo].[sp_select_SCR00001_matbkd] 
@cocde		nvarchar(6),
@SCfrom		nvarchar(20),
@SCto		nvarchar(20)

AS

select	scb_cocde,
	scb_ordno,
	scb_ordseq,
	scb_itmno,
	scb_cptseq,
	scb_cpt,
	case scb_cst when 0 then '' else scb_curcde end as 'scb_curcde',
	scb_cst,
	scb_cstpct,
	scb_pct
from	SCCPTBKD (nolock)
where	scb_cocde = @cocde and
	scb_ordno between @SCfrom and @SCto


GO
GRANT EXECUTE ON [dbo].[sp_select_SCR00001_matbkd] TO [ERPUSER] AS [dbo]
GO
