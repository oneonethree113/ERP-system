/****** Object:  StoredProcedure [dbo].[sp_select_POORDHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










/*
=================================================================
Program ID	: sp_select_POORDHDR
Description	: Select data From POORDHDR
Programmer	: Wong Hong
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2002-01-04 	Wong Hong		SP Created
2013-07-31	David Yue		Phase 2 Implementation
=================================================================
*/



CREATE procedure [dbo].[sp_select_POORDHDR]


@poh_cocde nvarchar(6) ,
@poh_purord nvarchar(20)                                                


AS

BEGIN

select	distinct
	poh_purord,
	poh_pursts,
	poh_issdat,
	poh_venno ,
	poh_puradr,
	poh_purstt,
	poh_purcty,
	poh_purpst,
	poh_porctp,
	poh_puragt,
	poh_salrep,
	poh_srname,
	poh_prmcus,
	poh_seccus,
	poh_shpadr,
	poh_shpstt,
	poh_shpcty,
	poh_shppst,
	poh_prctrm,
	poh_paytrm,
	poh_ttlcbm,
	poh_ttlctn,
	poh_curcde,
	poh_ttlamt,
	poh_discnt,
	poh_netamt,
	poh_spoflg,
	poh_cuspno,
	poh_cpodat,
	poh_reppno,
	poh_shpstr = convert(char, poh_shpstr,101),
	poh_shpend = convert(char, poh_shpend,101),
	poh_lbldue,
	poh_lblven,
	poh_subcde,
	poh_rmk = isnull(poh_rmk, ''),
	poh_ordno ,
	poh_credat,
	isnull(cast(Case poh_pocdat  when '1900-01-01' then null else convert(char(10),poh_pocdat,101) end as nvarchar(10)),'  /  /    ') as 'poh_pocdat',
	isnull(cast(Case poh_pocdatend  when '1900-01-01' then null else convert(char(10),poh_pocdatend,101) end as nvarchar(10)),'  /  /    ') as 'poh_pocdatend',
	soh_rplmnt,
	sod_subcde,
	cast(poh_timstp as int) as poh_timstp,          
	vbi_vensna = Case vbi_vensts when 'A' then vbi_vensna when 'I' then rtrim(vbi_vensna) + '(Inactive)' else rtrim(vbi_vensna) + '(Discontinue)' end,
	cbi_saltem,
	poh_updusr,
	poh_upddat,
	poh_purchnadr,
	poh_signappflg,
	poh_vndackflg,
	case poh_cusctn when 0 then '' else cast(poh_cusctn as nvarchar(10)) end as poh_cusctn,
	poh_dest
from	POORDHDR (nolock), VNBASINF (nolock), SCORDHDR (nolock), SCORDDTL (nolock), CUBASINF (nolock)--, SYSALREP (nolock)
where	poh_venno = vbi_venno and
	poh_cocde = soh_cocde and
	poh_ordno = soh_ordno and
	poh_cocde = sod_cocde and
	poh_ordno = sod_ordno and
	poh_prmcus = cbi_cusno and
	poh_cocde = @poh_cocde and
	poh_purord = @poh_purord

END









GO
GRANT EXECUTE ON [dbo].[sp_select_POORDHDR] TO [ERPUSER] AS [dbo]
GO
