/****** Object:  StoredProcedure [dbo].[sp_update_CUAGTINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUAGTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUAGTINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/************************************************************************
Author:		Kath Ng     
Date:		25th September, 2001
Description:	Update data into CUAGTINF
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_update_CUAGTINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@cai_cocde	nvarchar(6),
@cai_cusno	nvarchar(6),
@cai_cusagt	nvarchar(6),
@cai_comrat	numeric(6,3),
@cai_cusdef	nvarchar(1),
@cai_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

UPDATE CUAGTINF  SET

cai_cocde = @cai_cocde,
cai_cusno = @cai_cusno,
cai_cusagt = @cai_cusagt,
cai_comrat = @cai_comrat,
cai_cusdef = @cai_cusdef,
cai_upddat = getdate()
--------------------------------------------------------------------------------------------------------------------------------------

WHERE

--cai_cocde = @cai_cocde and
cai_cusno = @cai_cusno and
cai_cusagt = @cai_cusagt
--------------------------------------------------------------------------------------------------------------------------------------








GO
GRANT EXECUTE ON [dbo].[sp_update_CUAGTINF] TO [ERPUSER] AS [dbo]
GO
