/****** Object:  StoredProcedure [dbo].[sp_select_CUVENINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_CUVENINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUVENINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Kath Ng     
Date:		13th September, 2001
Description:	Select data From CUVENINF
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/
--28 Jul 2003	Lewis To	Ignor Compnay code			*******


CREATE procedure [dbo].[sp_select_CUVENINF]
                                                                                                                                                                                                                                                                 
@cvi_cocde nvarchar(6) ,
@cvi_cusno nvarchar(20) 
                                            
 AS

BEGIN
------------------------------------------------------------------------------------------------------------------------------------------------------
SELECT	'   ' as 'Status',
	cvi_cocde,	cvi_cusno,	cvi_assvid, 
	cvi_assdsc,	cvi_creusr,	cvi_updusr,
	cvi_credat,	cvi_upddat,
	cast(cvi_timstp as int) as cvi_timstp, cvi_assvid as cvi_orgvid
                                  

FROM CUVENINF

WHERE	--cvi_cocde = @cvi_cocde AND	
	cvi_cusno = @cvi_cusno

ORDER BY cvi_assvid

------------------------------------------------------------------------------------------------------------------------------------------------------
END



GO
GRANT EXECUTE ON [dbo].[sp_select_CUVENINF] TO [ERPUSER] AS [dbo]
GO
