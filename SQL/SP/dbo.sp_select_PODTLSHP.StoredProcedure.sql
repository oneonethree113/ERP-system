/****** Object:  StoredProcedure [dbo].[sp_select_PODTLSHP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PODTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PODTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=================================================================
Program ID	: sp_select_PODTLSHP
Description	: Select data From PODTLSHP
Programmer	: Wong Hong
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2002-01-04 	Wong Hong		SP Created
2013-08-01	David Yue		Phase 2 Implementation
=================================================================
*/



CREATE procedure [dbo].[sp_select_PODTLSHP]


@pds_cocde nvarchar(6) ,
@pds_purord nvarchar(20)
 
AS
BEGIN


select	' ' as 'pds_status',
	pds_seq,
	pds_shpseq,
	pds_from,
	pds_to,
	pds_ordqty,
	pds_ctnstr,
	pds_ctnend,
	pds_ttlctn,
	pds_dest,
	pds_creusr,
	pds_updusr,
	pds_credat,
	pds_upddat,
	cast(pds_timstp as int) as pds_timstp
from	PODTLSHP (nolock)
where	pds_cocde = @pds_cocde and
	pds_purord = @pds_purord
	order by pds_seq, pds_from, pds_to

END






GO
GRANT EXECUTE ON [dbo].[sp_select_PODTLSHP] TO [ERPUSER] AS [dbo]
GO
