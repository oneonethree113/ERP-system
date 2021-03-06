/****** Object:  StoredProcedure [dbo].[sp_update_PGM00006_DTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PGM00006_DTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PGM00006_DTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/*
=================================================================
Program ID	: sp_update_PGM00006_DTL
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


CREATE procedure [dbo].[sp_update_PGM00006_DTL]
@cocde	varchar(6),
@ordno	varchar(20),
@ordseq int,
@action	varchar(6),
@creusr	varchar(30)

as
begin

update	PKORDDTL
set	pod_status = case ltrim(rtrim(@action)) when 'Y' then 'APV' when 'W' then pod_status end,
	pod_updusr = left(ltrim(rtrim('A-' + @creusr)),30),
	pod_upddat = getdate()
where	pod_ordno = @ordno and
	pod_seq = @ordseq



end





GO
GRANT EXECUTE ON [dbo].[sp_update_PGM00006_DTL] TO [ERPUSER] AS [dbo]
GO
