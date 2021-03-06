/****** Object:  StoredProcedure [dbo].[sp_list_SHCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHCPTBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
=================================================================
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
=================================================================
*/


CREATE  procedure [dbo].[sp_list_SHCPTBKD]
@cocde	varchar(6),
@ordno	varchar(20)  --shpno
as

select	'' as 'shb_status',
	shb_cocde,
	shb_ordno,      --shpno
	shb_ordseq,    --shpseq
	shb_itmno,
	shb_cptseq,
	shb_cpt,
	shb_curcde,
	shb_cst,
	shb_cstpct,
	shb_pct,
	shb_creusr
from	SHCPTBKD (nolock)
where	shb_cocde = @cocde and
	shb_ordno = @ordno
order by shb_ordseq, shb_cptseq




GO
GRANT EXECUTE ON [dbo].[sp_list_SHCPTBKD] TO [ERPUSER] AS [dbo]
GO
