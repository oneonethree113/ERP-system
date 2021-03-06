/****** Object:  StoredProcedure [dbo].[sp_update_FLDOCATT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_FLDOCATT]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_FLDOCATT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/*
=================================================================
Program ID	: sp_update_FLDOCATT
Description	: Retrieve File Document Attachments
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-05-05 	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_update_FLDOCATT]
@cocde		nvarchar(6),
@docno		nvarchar(20),
@module		nvarchar(6),
@filpath	nvarchar(100),
@chkdat		nvarchar(50),
@usrid		nvarchar(30)

as

update	FLDOCATT
set	fda_filpath = @filpath,
	fda_chkdat = @chkdat,
	fda_updusr = @usrid,
	fda_upddat = getdate()
where	fda_cocde = @cocde and
	fda_docno = @docno and
	fda_module = @module and
	fda_key = ''




GO
GRANT EXECUTE ON [dbo].[sp_update_FLDOCATT] TO [ERPUSER] AS [dbo]
GO
