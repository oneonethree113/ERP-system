/****** Object:  StoredProcedure [dbo].[sp_list_SHCI_SHINVHDR_SHM00006_1]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHCI_SHINVHDR_SHM00006_1]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHCI_SHINVHDR_SHM00006_1]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai 
Date:		Jan 4, 2002
Description:	1. select invoice by shipping no.
************************************************************************/

CREATE procedure [dbo].[sp_list_SHCI_SHINVHDR_SHM00006_1]

                                                                                                                                                                                                                                                               
@hiv_cocde nvarchar(6) ,
@hiv_shpno nvarchar(20)
AS

select
hiv_cocde,
hiv_shpno,
hiv_invno,
convert(char(10), hiv_invdat,  101) as 'hiv_invdat',
hiv_prctrm,
hiv_paytrm,
hiv_doctyp,
hiv_doc,
hiv_cover,
hiv_ftrrmk,
hiv_untamt,
hiv_ttlamt,
hiv_ttlvol,
hiv_ttlctn,
hiv_bank,
hiv_aformat,
hiv_invamt,
hiv_afamt,
hiv_invsts,
hiv_creusr,
hiv_LcStmt

from SHCI_SHINVHDR

where hiv_cocde = @hiv_cocde and
hiv_shpno = @hiv_shpno






GO
GRANT EXECUTE ON [dbo].[sp_list_SHCI_SHINVHDR_SHM00006_1] TO [ERPUSER] AS [dbo]
GO
