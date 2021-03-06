/****** Object:  StoredProcedure [dbo].[sp_list_SHCI_SHDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHCI_SHDISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHCI_SHDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai 
Date:		Jan 4, 2002
Description:	Select data From SHDISPRM
Parameter:	1. Company
		2. Ship no
		3 D/P type
************************************************************************/

CREATE procedure [dbo].[sp_list_SHCI_SHDISPRM]
                                                                                                                                                                                                                                                               
@hdp_cocde nvarchar(6) ,
@hdp_shpno nvarchar(20),
@hdp_type nvarchar(15)
AS
begin
select 

'   '  as 'DEL',
hdp_cde,
hdp_dsc,
hdp_pctamt,
hdp_pct,
hdp_amt,
hdp_cocde,
hdp_shpno,
hdp_invno,
hdp_type,
hdp_seqno,
hdp_creusr

from SHCI_SHDISPRM

where                                                                                                                                                                                                                                                                 
hdp_cocde	= @hdp_cocde and
hdp_shpno 	= @hdp_shpno and
hdp_type		= @hdp_type

end






GO
GRANT EXECUTE ON [dbo].[sp_list_SHCI_SHDISPRM] TO [ERPUSER] AS [dbo]
GO
