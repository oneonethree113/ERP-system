/****** Object:  StoredProcedure [dbo].[sp_select_PODISPRM_SC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PODISPRM_SC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PODISPRM_SC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_select_PODISPRM_SC]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pdp_cocde nvarchar(6) ,
@pdp_purord nvarchar(20),
@pdp_pdptyp nvarchar(1)                                     
---------------------------------------------- 
 
AS
begin
Select 
' ' as 'pdp_status',
p.pdp_cocde,
p.pdp_purord,
p.pdp_seqno,
p.pdp_dpltyp,
case p.pdp_dsc when '' then s.ydp_dsc else p.pdp_dsc end as 'pdp_dsc',
p.pdp_pctamt,
p.pdp_purpct,
p.pdp_paamt,
p.pdp_creusr,
p.pdp_updusr,
p.pdp_credat,
p.pdp_upddat,
cast(p.pdp_timstp as int) as pdp_timstp
--------------------------------- 
from PODISPRM p , POORDHDR poh, SYDISPRM s
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
p.pdp_cocde = @pdp_cocde and
--p.pdp_purord = @pdp_purord and
poh.poh_ordno = @pdp_purord and
p.pdp_pdptyp = @pdp_pdptyp and 
--s.ydp_cocde = p.pdp_cocde and
s.ydp_type = p.pdp_pdptyp and
s.ydp_cde = p.pdp_dpltyp and
p.pdp_purord = poh.poh_purord
---------------------------------------------------------- 
end

GO
GRANT EXECUTE ON [dbo].[sp_select_PODISPRM_SC] TO [ERPUSER] AS [dbo]
GO
