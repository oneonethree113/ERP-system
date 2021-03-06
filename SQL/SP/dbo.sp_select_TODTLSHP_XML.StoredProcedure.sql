/****** Object:  StoredProcedure [dbo].[sp_select_TODTLSHP_XML]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_TODTLSHP_XML]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_TODTLSHP_XML]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE   PROCEDURE [dbo].[sp_select_TODTLSHP_XML]

AS

select 
tds_toordno, 
tds_toordseq,
tds_verno,
tds_shpseq,
tds_ftyshpstr,
tds_ftyshpend,
tds_cushpstr, 
tds_cushpend,
tds_shpqty,
tds_pckunt,
tds_creusr, 
tds_updusr,
tds_credat,
tds_upddat
from 
TOORDHDR (nolock)
left join TOORDDTL (nolock) on tod_cocde = toh_cocde and tod_toordno = toh_toordno
left join TODTLSHP on tds_cocde = tod_cocde and tds_toordno = tod_toordno and tds_toordseq = tod_toordseq and tds_verno = tod_verno
where toh_ordsts = 'REL' and tod_latest ='Y' and tod_gensapflag = 'Y'
and tod_prdven >= 'A' and tod_prdven <= 'Z'
and (convert(varchar(10),toh_credat,111) = convert(varchar(10),getdate(),111) 
or convert(varchar(10),toh_upddat,111) = convert(varchar(10),getdate(),111))
and tds_cocde is not null

order by tds_toordno, tds_toordseq,tds_verno,tds_shpseq

GO
GRANT EXECUTE ON [dbo].[sp_select_TODTLSHP_XML] TO [ERPUSER] AS [dbo]
GO
