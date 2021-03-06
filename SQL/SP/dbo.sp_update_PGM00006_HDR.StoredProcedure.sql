/****** Object:  StoredProcedure [dbo].[sp_update_PGM00006_HDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PGM00006_HDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PGM00006_HDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










/*
=================================================================
Program ID	: sp_update_PGM00006_HDR
Description	: update SC Detail Approve Flag
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-05-13 	David Yue		SP Created
=================================================================
*/


CREATE  procedure [dbo].[sp_update_PGM00006_HDR]
@cocde	varchar(6),
@ordno	varchar(20),
@action	varchar(6),
@creusr	varchar(30)

as

update	PKORDHDR
set	poh_status = case ltrim(rtrim(@action)) when 'Y' then 'APV' when 'W' then poh_status end,
	poh_updusr = ltrim(rtrim(@creusr)),
	poh_upddat = getdate()
where	poh_cocde = @cocde and
	poh_ordno = @ordno








GO
GRANT EXECUTE ON [dbo].[sp_update_PGM00006_HDR] TO [ERPUSER] AS [dbo]
GO
