/****** Object:  StoredProcedure [dbo].[sp_select_SCDTLCTN]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCDTLCTN]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCDTLCTN]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003

/************************************************************************
Author:		Kenny Chan
Date:		14th Jan, 2002
Description:	Select data From SCDTLCTN
Parameter:	1. Company
		2. SC No.	
************************************************************************/
CREATE PROCEDURE [dbo].[sp_select_SCDTLCTN] 

@sdc_cocde 	nvarchar(6),
@sdc_ordno	nvarchar(20)--,


AS
select 	
' ' as 'sdc_status',
sdc_cocde,
sdc_ordno,
sdc_seq,
sdc_ctnseq,
sdc_from,
sdc_to,
sdc_ttlctn,
sdc_creusr,
sdc_updusr,
sdc_credat,
sdc_upddat,
cast( sdc_timstp as int) as 'sdc_timstp'

from 	SCDTLCTN
where 	sdc_cocde = @sdc_cocde and 
	sdc_ordno= @sdc_ordno





GO
GRANT EXECUTE ON [dbo].[sp_select_SCDTLCTN] TO [ERPUSER] AS [dbo]
GO
