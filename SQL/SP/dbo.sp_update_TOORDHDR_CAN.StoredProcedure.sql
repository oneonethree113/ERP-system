/****** Object:  StoredProcedure [dbo].[sp_update_TOORDHDR_CAN]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_TOORDHDR_CAN]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_TOORDHDR_CAN]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/*
=================================================================
Program ID	: sp_update_TOORDHDR_CAN
Description	: Cancel TO Item
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-02-25 	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_update_TOORDHDR_CAN]
@cocde		varchar(6),
@toordno	varchar(30),
@usrid		varchar(30)

as

update	TOORDHDR
set	toh_ordsts = 'CAN',
	toh_upddat = getdate(),
	toh_updusr = left('C-' + @usrid, 30)
where	toh_cocde = @cocde and
	toh_toordno = @toordno



GO
GRANT EXECUTE ON [dbo].[sp_update_TOORDHDR_CAN] TO [ERPUSER] AS [dbo]
GO
