/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHPCKDIM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SHPCKDIM]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHPCKDIM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Johnson Lai
Date:		20th Jan, 2001
Description:	Delete data From SHDISPRM
Parameter:	1. Company
		2. Shipping No		
		3 shpno			
************************************************************************/
------------------------------------------------- 
create  procedure [dbo].[sp_Physical_Delete_SHPCKDIM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hpd_cocde  nvarchar(6),
@hpd_shpno nvarchar(20),
@hpd_shpseq int

----------------------------------------------  
AS

begin

Delete SHPCKDIM
Where 
hpd_cocde =  @hpd_cocde and
hpd_shpno = @hpd_shpno and
hpd_shpseq = @hpd_shpseq

---------------------------------------------------------- 
end









GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SHPCKDIM] TO [ERPUSER] AS [dbo]
GO
