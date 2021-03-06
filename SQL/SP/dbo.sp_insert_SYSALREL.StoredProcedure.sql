/****** Object:  StoredProcedure [dbo].[sp_insert_SYSALREL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYSALREL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYSALREL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/*
=================================================================
Program ID	: sp_insert_SYSALREL
Description	: Insert Sales Rep Entry from SYSALREL
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-02-21 	David Yue		SP Created
2014-01-07	David Yue		Bug Fix
=================================================================
*/


CREATE procedure [dbo].[sp_insert_SYSALREL]
@cocde	varchar(6),
@saltem nvarchar(20),
@saldiv	nvarchar(20),
@salmgr nvarchar(30),
@salrep nvarchar(30),
@default nvarchar(3),
@creusr	nvarchar(30)

as

-- 2014-01-07 Reset previous sales team rep default when new default is selected
if @default = 'Y'
begin
	update	SYSALREL
	set	ssr_default = 'N'
	where	ssr_saltem = @saltem and
		ssr_default = 'Y'
end

insert into SYSALREL
(	ssr_cocde,	ssr_saldiv,	ssr_salmgr,
	ssr_saltem,	ssr_salrep,	ssr_default,
	ssr_creusr,	ssr_updusr,	ssr_credat,
	ssr_upddat
)
values
(	'',		@saldiv,	@salmgr,
	@saltem,	@salrep,	@default,
	@creusr,	@creusr,	getdate(),
	getdate()
)





GO
GRANT EXECUTE ON [dbo].[sp_insert_SYSALREL] TO [ERPUSER] AS [dbo]
GO
