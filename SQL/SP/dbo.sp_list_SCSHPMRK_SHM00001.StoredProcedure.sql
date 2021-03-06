/****** Object:  StoredProcedure [dbo].[sp_list_SCSHPMRK_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SCSHPMRK_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SCSHPMRK_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 27/07/02003



/************************************************************************
Author:		Johnson Lai
Date:		21 Jan, 2001
Description:	Select data From SHSHPMRK
Parameter:	1. Company
		2. SC No.			
***********************************************************************
20 Aug 2003 Allan Yuen fix Deadlock Error 
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_list_SCSHPMRK_SHM00001]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ssm_cocde nvarchar(6) ,
@ssm_ordno nvarchar(20)

---------------------------------------------- 
 
AS
begin
Select 
ssm_ordno,
ssm_shptyp,
ssm_imgnam,
ssm_imgpth,
ssm_engdsc,
ssm_engrmk


--------------------------------- 
from SCSHPMRK (nolock)
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
ssm_cocde = @ssm_cocde and
ssm_ordno = @ssm_ordno and
ssm_shptyp = 'M'
---------------------------------------------------------- 
end









GO
GRANT EXECUTE ON [dbo].[sp_list_SCSHPMRK_SHM00001] TO [ERPUSER] AS [dbo]
GO
