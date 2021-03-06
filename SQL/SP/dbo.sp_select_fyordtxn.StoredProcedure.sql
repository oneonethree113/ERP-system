/****** Object:  StoredProcedure [dbo].[sp_select_fyordtxn]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_fyordtxn]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_fyordtxn]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- Checked by Allan Yuen at 28/07/2003

CREATE PROCEDURE [dbo].[sp_select_fyordtxn]
@foi_fyohdr	nvarchar(10)
AS

select	foi_actdat as '修改日期',
	ypp_prdcds as '生產進度',
	foi_expcmp as '預計完成日期', 
	foi_cmpdat as '實際完成日期',
	foi_cmpper as '完成比例',
	foi_warqty as '已進倉數',
	foi_rptqty as '已報知香港數',
	foi_shpqty as '己落貨數'
from	fyordtxn, syprdpro
where	foi_fyohdr = @foi_fyohdr 
and	foi_ftysts = ypp_prdcde
order by	foi_ordseq desc








GO
GRANT EXECUTE ON [dbo].[sp_select_fyordtxn] TO [ERPUSER] AS [dbo]
GO
