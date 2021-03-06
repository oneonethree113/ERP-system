/****** Object:  StoredProcedure [dbo].[sp_list_POORDSUM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_POORDSUM]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_POORDSUM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Select data From POORDDTL and PORODHDR
Parameter:	1. Company
		2. PO No
************************************************************************/

CREATE procedure [dbo].[sp_list_POORDSUM]
                                                                                                                                                                                                                                                               
@poh_cocde nvarchar(6) ,
@poh_purord nvarchar(20) 
AS
begin
select 
h.poh_pursts,
h.poh_venno,
v.vbi_vensna,
h.poh_prmcus,
c.cbi_cussna,
h.poh_curcde,
d.pod_purord,
d.pod_purseq,
d.pod_itmno,
d.pod_cusitm,
d.pod_vencol,
d.pod_untcde,
d.pod_inrctn,
d.pod_mtrctn,
d.pod_cubcft,
d.pod_recqty,
d.pod_ftyprc,
d.pod_ordqty,
d.pod_engdsc,
d.pod_jobord
from POORDHDR h, POORDDTL d, VNBASINF v, CUBASINF c
where                                                                                                                                                                                                                                                                 
h.poh_cocde = @poh_cocde and
h.poh_purord = @poh_purord and
d.pod_cocde = h.poh_cocde and
d.pod_purord = h.poh_purord and

--v.vbi_cocde = h.poh_cocde and
v.vbi_venno = h.poh_venno and

--c.cbi_cocde = h.poh_cocde and
c.cbi_cusno = h.poh_prmcus

end





GO
GRANT EXECUTE ON [dbo].[sp_list_POORDSUM] TO [ERPUSER] AS [dbo]
GO
