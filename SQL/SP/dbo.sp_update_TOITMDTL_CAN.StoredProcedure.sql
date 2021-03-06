/****** Object:  StoredProcedure [dbo].[sp_update_TOITMDTL_CAN]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_TOITMDTL_CAN]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_TOITMDTL_CAN]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/*
=================================================================
Program ID	: sp_update_TOITMDTL_CAN
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


CREATE procedure [dbo].[sp_update_TOITMDTL_CAN]
@cocde		varchar(6),
@toordno	varchar(30),
@toordseq	int,
@usrid		varchar(30)

as

declare @tid_canqty as int
set @tid_canqty = 0

select	@tid_canqty = isnull(tid_toqty,0)
from	TOITMDTL (nolock)
where	tid_cocde = @cocde and
	tid_toordno = @toordno and
	tid_toordseq = @toordseq

update	TOITMDTL
set	tid_toqty = 0,
	tid_osqty = 0,
	tid_upddat = getdate(),
	tid_updusr = left('C-' + @usrid, 30)
where	tid_cocde = @cocde and
	tid_toordno = @toordno and
	tid_toordseq = @toordseq

select	tid_cocde, 	tid_cus1no, 	tid_cus2no, 
	tid_year, 	tid_itmtyp, 	tid_assitm, 
	tid_itmno, 	tid_tmpitmno, 	tid_venno, 
	tid_venitmno, 	tid_pckunt, 	@tid_canqty as 'tid_canqty'
from	TOITMDTL (nolock)
where	tid_cocde = @cocde and
	tid_toordno = @toordno and
	tid_toordseq = @toordseq



GO
GRANT EXECUTE ON [dbo].[sp_update_TOITMDTL_CAN] TO [ERPUSER] AS [dbo]
GO
