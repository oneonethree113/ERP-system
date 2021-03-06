/****** Object:  StoredProcedure [dbo].[sp_insert_CUAGTINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUAGTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUAGTINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Kath Ng     
Date:		25th September, 2001
Description:	Insert data into CUAGTINF
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_CUAGTINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@cai_cocde	nvarchar(6),
@cai_cusno	nvarchar(6),
@cai_cusagt	nvarchar(6),
@cai_comrat	numeric(6,3),
@cai_cusdef	nvarchar(1),
@cai_updusr	nvarchar(30)
--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  CUAGTINF
(
cai_cocde,
cai_cusno,
cai_cusagt,
cai_comrat,
cai_cusdef,
cai_creusr,
cai_updusr,
cai_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
' ',
--@cai_cocde,
@cai_cusno,
@cai_cusagt,
@cai_comrat,
@cai_cusdef,
@cai_updusr,
@cai_updusr,
getdate()
)








GO
GRANT EXECUTE ON [dbo].[sp_insert_CUAGTINF] TO [ERPUSER] AS [dbo]
GO
