/****** Object:  StoredProcedure [dbo].[sp_list_SHINVHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHINVHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHINVHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO







-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai 
Date:		Jan 4, 2002
Description:	Select data From SHIPGDTL
Parameter:	1. Company
		2. Ship no
************************************************************************/

CREATE  procedure [dbo].[sp_list_SHINVHDR]

                                                                                                                                                                                                                                                               
@hiv_cocde nvarchar(6) ,
@hiv_invno nvarchar(20),
@hiv_shpno nvarchar(20)

AS
begin
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
hiv_plrmk,
hiv_creusr,
hiv_updusr,
hiv_credat,
hiv_upddat,
hiv_timstp

from SHINVHDR
where                                                                                                                                                                                                                                                                 
hiv_cocde = @hiv_cocde and
hiv_shpno = @hiv_shpno and
hiv_invno = @hiv_invno
end







GO
GRANT EXECUTE ON [dbo].[sp_list_SHINVHDR] TO [ERPUSER] AS [dbo]
GO
