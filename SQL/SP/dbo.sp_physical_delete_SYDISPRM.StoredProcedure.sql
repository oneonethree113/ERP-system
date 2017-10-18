/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SYDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SYDISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SYDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003



/************************************************************************
Author:		Samuel Chan
Date:		14th September, 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_physical_delete_SYDISPRM] 

@ydp_cocde	nvarchar(6) = ' ',
@ydp_type	nvarchar(1),
@ydp_cde	nvarchar(6)

AS

delete from SYDISPRM

where 	
--ydp_cocde = @ydp_cocde
ydp_cocde = ' '
and 	ydp_type = @ydp_type
and	ydp_cde=@ydp_cde









GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SYDISPRM] TO [ERPUSER] AS [dbo]
GO
