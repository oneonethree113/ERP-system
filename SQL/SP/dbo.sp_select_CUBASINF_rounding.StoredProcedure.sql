/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_rounding]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF_rounding]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_rounding]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
=========================================================
=========================================================
=========================================================     
*/
CREATE  procedure [dbo].[sp_select_CUBASINF_rounding]
                                                                                                                                                                                                                                                                 

@cbi_cocde nvarchar(6) ,
@cbi_cusno nvarchar(20) 
 
AS

begin

Select	cbi_rounding
from CUBASINF
 where
--cbi_cocde = @cbi_cocde and
cbi_cusno = @cbi_cusno


end








GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF_rounding] TO [ERPUSER] AS [dbo]
GO
