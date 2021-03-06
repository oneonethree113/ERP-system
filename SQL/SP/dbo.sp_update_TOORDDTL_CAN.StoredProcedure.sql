/****** Object:  StoredProcedure [dbo].[sp_update_TOORDDTL_CAN]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_TOORDDTL_CAN]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_TOORDDTL_CAN]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/*
=================================================================
Program ID	: sp_update_TOORDDTL_CAN
Description	: Cancel TO Projected Quantity
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-02-25 	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_update_TOORDDTL_CAN]
@cocde		varchar(6),
@toordno	varchar(30),
@toordseq	int,
@usrid		varchar(30)

as

update	TOORDDTL
set	tod_projqty = 0,
	tod_upddat = getdate(),
	tod_updusr = left('C-' + @usrid, 30)
where	tod_cocde = @cocde and
	tod_toordno = @toordno and
	tod_toordseq = @toordseq and
	tod_projqty > 0



GO
GRANT EXECUTE ON [dbo].[sp_update_TOORDDTL_CAN] TO [ERPUSER] AS [dbo]
GO
