/****** Object:  StoredProcedure [dbo].[sp_select_POSHPMRK]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Select data From POSHPMRK
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_POSHPMRK]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@psm_cocde nvarchar(6) ,
@psm_purord nvarchar(20)

---------------------------------------------- 
 
AS
begin
Select 
psm_shptyp,
psm_engrmk,
psm_chnrmk,
psm_engdsc,
psm_chndsc,
psm_imgpth,
psm_imgnam,
cast(psm_timstp as int) as psm_timstp
--------------------------------- 
from POSHPMRK
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
psm_cocde = @psm_cocde and
psm_purord = @psm_purord
---------------------------------------------------------- 
end




GO
GRANT EXECUTE ON [dbo].[sp_select_POSHPMRK] TO [ERPUSER] AS [dbo]
GO
