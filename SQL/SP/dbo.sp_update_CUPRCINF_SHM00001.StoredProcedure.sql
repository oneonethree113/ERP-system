/****** Object:  StoredProcedure [dbo].[sp_update_CUPRCINF_SHM00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUPRCINF_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUPRCINF_SHM00001]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO







/************************************************************************
Author:		Johnson Lai
Date:		Aug 02 2002
Description:	Update credit used 
Parameter:	
Disable function for update Credit Limit 20140508
************************************************************************/

CREATE PROCEDURE [dbo].[sp_update_CUPRCINF_SHM00001] 
--------------------------------------------------------------------------------------------------------------------------------------
@cpi_cocde	nvarchar(6),
@cpi_cusno	nvarchar(6),
@cpi_AdjInvAmt	numeric(13,4),
@cpi_updusr	nvarchar(30)
--------------------------------------------------------------------------------------------------------------------------------------
AS

--update CUPRCINF  set
--cpi_cdtuse = cpi_cdtuse + @cpi_adjinvamt ,
--cpi_updusr = @cpi_updusr,
--cpi_upddat = getdate()

/*
update CUBCR  set
cbc_cdtuse = cbc_cdtuse + @cpi_adjinvamt ,
cbc_updusr = @cpi_updusr,
cbc_upddat = getdate()

--------------------------------------------------------------------------------------------------------------------------------------
where 

cbc_cocde	= @cpi_cocde and 
cbc_cusno	= @cpi_cusno
*/
--------------------------------------------------------------------------------------------------------------------------------------

GO
GRANT EXECUTE ON [dbo].[sp_update_CUPRCINF_SHM00001] TO [ERPUSER] AS [dbo]
GO
