/****** Object:  StoredProcedure [dbo].[sp_update_SCM00006_HDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SCM00006_HDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SCM00006_HDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








/*
=================================================================
Program ID	: sp_update_SCM00006_HDR
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


CREATE  procedure [dbo].[sp_update_SCM00006_HDR]
@cocde	varchar(6),
@ordno	varchar(20),
@action	varchar(6),
@soh_prctrmflg char(1),
@soh_paytrmflg char(1),
@soh_rplflg char(1),
@soh_clsflg char(1),
@creusr	varchar(30)

as

update	SCORDHDR
set	soh_ordsts = case ltrim(rtrim(@action)) when 'Y' then 'ACT' when 'W' then soh_ordsts end,
	soh_prctrmflg = @soh_prctrmflg,
	soh_lastprctrm = case @soh_prctrmflg when 'Y' then soh_prctrm else soh_lastprctrm end,
	soh_paytrmflg = @soh_paytrmflg,
	soh_lastpaytrm = case @soh_paytrmflg when 'Y' then soh_paytrm else soh_lastpaytrm end,
	soh_rplflg = @soh_rplflg,
	soh_clsflg = @soh_clsflg,
	soh_updusr = left(ltrim(rtrim('A-' + @creusr)),30),
	soh_upddat = getdate()
where	soh_cocde = @cocde and
	soh_ordno = @ordno







GO
GRANT EXECUTE ON [dbo].[sp_update_SCM00006_HDR] TO [ERPUSER] AS [dbo]
GO
