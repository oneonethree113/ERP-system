/****** Object:  StoredProcedure [dbo].[sp_select_PKDISPRM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKDISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE  procedure [dbo].[sp_select_PKDISPRM]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20),
@type nvarchar(15)


---------------------------------------------- 

 
AS
 

begin

select '' as 'Del', pdp_cocde,pdp_ordno,pdp_type,pdp_seqno,pdp_cde,pdp_dsc,
	pdp_pctamt,pdp_pct,pdp_amt,pdp_creusr,pdp_updusr,pdp_credat,pdp_upddat
from PKDISPRM (nolock)
where pdp_cocde = @code and pdp_ordno = @ordno   and pdp_type = @type


end


 
 

GO
GRANT EXECUTE ON [dbo].[sp_select_PKDISPRM] TO [ERPUSER] AS [dbo]
GO
