/****** Object:  StoredProcedure [dbo].[sp_insert_SYSALINF_MGR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYSALINF_MGR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYSALINF_MGR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=================================================================
Program ID	: sp_insert_SYSALINF_MGR
Description	: Insert Sales Manager Entry from SYSALINF
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-02-20	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_insert_SYSALINF_MGR]
@cocde	varchar(6),
@saldiv	nvarchar(20),
@salmgr	nvarchar(30),
@creusr	nvarchar(30)

as

insert into SYSALINF
(	ssi_cocde,	ssi_typ,	ssi_saldiv,
	ssi_saltem,	ssi_salmgr,	ssi_creusr,
	ssi_updusr,	ssi_credat,	ssi_upddat
)
values
(	'',		'MGR',		@saldiv,
	'',		@salmgr,	@creusr,
	@creusr,	getdate(),	getdate()
)




GO
GRANT EXECUTE ON [dbo].[sp_insert_SYSALINF_MGR] TO [ERPUSER] AS [dbo]
GO
