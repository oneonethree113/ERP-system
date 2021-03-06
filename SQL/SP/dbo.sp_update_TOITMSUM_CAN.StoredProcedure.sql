/****** Object:  StoredProcedure [dbo].[sp_update_TOITMSUM_CAN]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_TOITMSUM_CAN]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_TOITMSUM_CAN]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/*
=================================================================
Program ID	: sp_update_TOITMSUM_CAN
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


CREATE procedure [dbo].[sp_update_TOITMSUM_CAN]
@cocde		nvarchar(6),
@cus1no		nvarchar(6),
@cus2no		nvarchar(6),
@year		nvarchar(4),
@assitm		nvarchar(30),
@itmno		nvarchar(30),
@tmpitmno	nvarchar(30),
@venno		nvarchar(6),
@venitmno	nvarchar(30),
@canqty		int,
@usrid		nvarchar(30)

as

update	TOITMSUM
set	tis_toqty = tis_toqty - @canqty,
	tis_osqty = tis_osqty - @canqty,
	tis_upddat = getdate(),
	tis_updusr = left('C-' + @usrid, 30)
where	tis_cocde = @cocde and
	tis_cus1no = @cus1no and
	tis_cus2no = @cus2no and
	tis_year = @year and
	tis_assitm = @assitm and
	tis_itmno = @itmno and
	tis_tmpitmno = @tmpitmno and
	tis_venno = @venno and
	tis_ventimno = @venitmno and
	@canqty > 0



GO
GRANT EXECUTE ON [dbo].[sp_update_TOITMSUM_CAN] TO [ERPUSER] AS [dbo]
GO
