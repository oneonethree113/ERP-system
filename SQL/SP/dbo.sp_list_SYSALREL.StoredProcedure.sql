/****** Object:  StoredProcedure [dbo].[sp_list_SYSALREL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYSALREL]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYSALREL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=================================================================
Program ID	: sp_list_SYSALREL
Description	: Retrieve all active Sales Rep Infomration entries
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-02-15 	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_list_SYSALREL]
@cocde	varchar(6)
as

select	'' as ssr_del,
	ssr_saltem,
	ssr_saldiv,
	ssr_salmgr,
	ssr_salrep,
	yup_usrnam as ssr_usrnam,
	ssr_default,
	'' as ssr_status
from	SYSALREL, SYUSRPRF
where	ssr_salrep = yup_usrid and yup_accexp > getdate()
order by ssr_saltem, ssr_salrep




GO
GRANT EXECUTE ON [dbo].[sp_list_SYSALREL] TO [ERPUSER] AS [dbo]
GO
