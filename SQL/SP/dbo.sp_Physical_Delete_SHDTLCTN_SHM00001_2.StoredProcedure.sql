/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Johnson Lai
Date:		2 Feb, 2002
Description:	Delete data From SHDTLCTN
Parameter:	1. Company
		2. Shpno	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_2]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hdc_cocde  nvarchar     (6),
@hdc_shpno  nvarchar     (20),
@hdc_shpseq  int
----------------------------------------------  

AS

begin
Delete SHDTLCTN
Where 
hdc_cocde = @hdc_cocde  and
hdc_shpno = @hdc_shpno and
hdc_shpseq =@hdc_shpseq
---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_2] TO [ERPUSER] AS [dbo]
GO
