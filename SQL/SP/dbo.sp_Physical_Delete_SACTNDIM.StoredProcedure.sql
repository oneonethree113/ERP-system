/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SACTNDIM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SACTNDIM]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SACTNDIM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Johnson Lai
Date:		24th Feb, 2001
Description:	Delete data From SACTNDIM
Parameter:	1. Company
		2. Invno 
		3 Invseq			
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_SACTNDIM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@scd_cocde  nvarchar(6),
@scd_invno nvarchar(20),
@scd_invseq int,
@scd_ctnseq int

----------------------------------------------  
AS

begin

Delete SACTNDIM
Where 
scd_cocde =  @scd_cocde and
scd_invno = @scd_invno and
scd_invseq = @scd_invseq and
scd_ctnseq = @scd_ctnseq

---------------------------------------------------------- 
end




GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SACTNDIM] TO [ERPUSER] AS [dbo]
GO
