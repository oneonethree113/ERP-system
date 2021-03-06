/****** Object:  StoredProcedure [dbo].[sp_update_PKWASGE]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PKWASGE]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PKWASGE]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO










/************************************************************************
Author:		Kath Ng     
Date:		25th September, 2001
Description:	Insert data into PKWASGE
************************************************************************/

CREATE PROCEDURE [dbo].[sp_update_PKWASGE] 
--------------------------------------------------------------------------------------------------------------------------------------

@pwa_cocde nvarchar(6),
@pwa_code nvarchar(6),
@seq	int,
@pwa_qtyfrm int,
@pwa_qtyto  int,
@pwa_wasage numeric(13,4),
@pwa_um nvarchar(12),
@user nvarchar(30)
--------------------------------------------------------------------------------------------------------------------------------------
AS

begin

update PKWASGE 
set pwa_qtyfrm = @pwa_qtyfrm,
pwa_qtyto = @pwa_qtyto,
pwa_wasage = @pwa_wasage,
pwa_um = @pwa_um,
pwa_upddat = getdate(),
pwa_updusr =  @user
where pwa_code = @pwa_code and pwa_seq = @seq


end





GO
GRANT EXECUTE ON [dbo].[sp_update_PKWASGE] TO [ERPUSER] AS [dbo]
GO
