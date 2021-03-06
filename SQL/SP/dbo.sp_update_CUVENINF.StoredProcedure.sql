/****** Object:  StoredProcedure [dbo].[sp_update_CUVENINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUVENINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUVENINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/************************************************************************
Author:		Kath Ng     
Date:		19th September, 2001
Description:	Update data into CUVENINF
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_update_CUVENINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@cvi_cocde	nvarchar(6),
@cvi_cusno	nvarchar(6),
@cvi_orgvid	nvarchar(20),
@cvi_assvid	nvarchar(20),
@cvi_assdsc	nvarchar(200),
@cvi_updusr	nvarchar(12)


--------------------------------------------------------------------------------------------------------------------------------------
AS

update CUVENINF set

cvi_cocde = @cvi_cocde,
cvi_cusno = @cvi_cusno,
cvi_assvid = @cvi_assvid,
cvi_assdsc = @cvi_assdsc,
cvi_updusr = @cvi_updusr,
cvi_upddat = getdate()
--------------------------------------------------------------------------------------------------------------------------------------
where 

--cvi_cocde = @cvi_cocde  and
cvi_cusno = @cvi_cusno and 
cvi_assvid = @cvi_orgvid
--------------------------------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_update_CUVENINF] TO [ERPUSER] AS [dbo]
GO
