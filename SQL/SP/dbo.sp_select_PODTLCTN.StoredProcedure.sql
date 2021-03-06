/****** Object:  StoredProcedure [dbo].[sp_select_PODTLCTN]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PODTLCTN]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PODTLCTN]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Select data From PODTLCTN
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_PODTLCTN]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pdc_cocde nvarchar(6) ,
@pdc_purord nvarchar(20)

---------------------------------------------- 
 
AS
begin
Select 
pdc_seq,
pdc_ctnseq, 
pdc_from,
pdc_to,
pdc_ttlctn,
cast(pdc_timstp as int) as pdc_timstp
--------------------------------- 
from PODTLCTN
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
pdc_cocde = @pdc_cocde and
pdc_purord = @pdc_purord
---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_select_PODTLCTN] TO [ERPUSER] AS [dbo]
GO
