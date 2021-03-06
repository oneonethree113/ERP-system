/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUPRCINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Kath Ng     
Date:		24th September, 2001
Description:	Physical Delete CUPRCINF data
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/
-- 28 Jul 2003 Lewis To	modify for ignor Company code 
CREATE PROCEDURE [dbo].[sp_physical_delete_CUPRCINF] 

@cpi_cocde nvarchar(6),
@cpi_cusno nvarchar(6)

AS

delete from CUPRCINF
where 	--cpi_cocde = @cpi_cocde
--and 	
	cpi_cusno = @cpi_cusno







GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUPRCINF] TO [ERPUSER] AS [dbo]
GO
