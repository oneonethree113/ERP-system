/****** Object:  StoredProcedure [dbo].[sp_select_POSHPMRK_SC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POSHPMRK_SC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POSHPMRK_SC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



------------------------------------------------- 
CREATE procedure [dbo].[sp_select_POSHPMRK_SC]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cocde as nvarchar(6),
@ordno as nvarchar(20)
                                               
---------------------------------------------- 
 
AS
begin

select	distinct
	pod_scno,
	psm_purord,
	psm_shptyp,
	psm_imgnam,
	psm_engdsc,
	psm_chndsc,
	psm_engrmk,
	psm_chnrmk,
	psm_creusr
from	POSHPMRK
	left join POORDDTL on psm_purord = pod_purord
where	pod_scno = @ordno






end




GO
GRANT EXECUTE ON [dbo].[sp_select_POSHPMRK_SC] TO [ERPUSER] AS [dbo]
GO
