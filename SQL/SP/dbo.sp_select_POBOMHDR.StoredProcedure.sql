/****** Object:  StoredProcedure [dbo].[sp_select_POBOMHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POBOMHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POBOMHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 27/07/2003



/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Select data From POBOMHDR
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_POBOMHDR]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pbh_cocde nvarchar(6) ,
@pbh_bompo nvarchar(20)                                                
---------------------------------------------- 
 
AS
begin
Select 
p.*,
cast(p.pbh_timstp as int) as pbh_timstp,          
v1.vbi_vensna as vbi_vensna1,
v2.vbi_vensna as vbi_vensna2
--------------------------------- 
from POBOMHDR p, VNBASINF v1, VNBASINF v2
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
p.pbh_bvenno = v1.vbi_venno and
--v1.vbi_cocde = @pbh_cocde and

p.pbh_oriven = v2.vbi_venno and
--v2.vbi_cocde = @pbh_cocde and

p.pbh_cocde = @pbh_cocde and
p.pbh_bompo = @pbh_bompo                                                                   
---------------------------------------------------------- 
end






GO
GRANT EXECUTE ON [dbo].[sp_select_POBOMHDR] TO [ERPUSER] AS [dbo]
GO
