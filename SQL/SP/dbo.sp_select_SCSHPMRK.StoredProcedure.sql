/****** Object:  StoredProcedure [dbo].[sp_select_SCSHPMRK]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCSHPMRK]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 27/07/2003



/************************************************************************
Author:		Kenny Chan
Date:		19th dec, 2001
Description:	Select data From SCSHPMRK
Parameter:	1. Company
		2. SC No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SCSHPMRK]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ssm_cocde nvarchar(6) ,
@ssm_ordno nvarchar(20)

---------------------------------------------- 
 
AS
begin
Select 
' ' as 'sdp_status',
ssm_cocde,
ssm_ordno,
ssm_imgnam,
ssm_imgpth,
ssm_shptyp,
ssm_engdsc,
ssm_chndsc,
ssm_engrmk,
ssm_chnrmk,
ssm_creusr,
ssm_updusr,
ssm_credat,
ssm_upddat,

cast(ssm_timstp as int) as ssm_timstp
--------------------------------- 
from SCSHPMRK
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
ssm_cocde = @ssm_cocde and
ssm_ordno = @ssm_ordno 
---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_select_SCSHPMRK] TO [ERPUSER] AS [dbo]
GO
