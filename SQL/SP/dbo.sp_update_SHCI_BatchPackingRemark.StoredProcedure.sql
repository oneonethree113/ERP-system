/****** Object:  StoredProcedure [dbo].[sp_update_SHCI_BatchPackingRemark]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SHCI_BatchPackingRemark]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SHCI_BatchPackingRemark]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
***********************************************************************
sp_update_SHCI_BatchPackingRemark 'UCP', 'HA1100008','mis'

*/


CREATE procedure [dbo].[sp_update_SHCI_BatchPackingRemark]
@cocde nvarchar(6),
@cshpno nvarchar(20),
@pckrmk	nvarchar(200),
@usrid nvarchar(30)
 
AS

BEGIN

update SHCI_SHIPGDTL set hid_pckrmk = @pckrmk where hid_cocde = @cocde and hid_shpno = @cshpno


END








GO
GRANT EXECUTE ON [dbo].[sp_update_SHCI_BatchPackingRemark] TO [ERPUSER] AS [dbo]
GO
