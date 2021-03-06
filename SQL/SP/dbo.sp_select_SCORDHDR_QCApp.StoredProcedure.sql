/****** Object:  StoredProcedure [dbo].[sp_select_SCORDHDR_QCApp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCORDHDR_QCApp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCORDHDR_QCApp]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_select_SCORDHDR_QCApp]

AS

BEGIN
/*
declare @TMP_PONO table (
id            int identity(1,1),
PONO nvarchar(20)
)

insert into @TMP_PONO (PONO)
select distinct qpd_purord from QCPORDTL
order by qpd_purord


declare @TMP_SCNO table (
id     int identity(1,1),
SCNO nvarchar(20)
)

insert into @TMP_SCNO (SCNO)
select distinct soh_ordno FROM @TMP_PONO
LEFT JOIN POORDHDR ON poh_purord = PONO
LEFT JOIN SCORDHDR ON poh_ordno = soh_ordno
LEFT JOIN QCREQDTL on poh_purord = qcd_purord
LEFT JOIN QCREQHDR on qcd_qcno = qch_qcno
LEFT JOIN QCPORDTL on qcd_purord = qpd_purord 
and qch_inspweek > DATEPART(wk,GETDATE()) -3 and qch_inspyear = YEAR(GETDATE())
order by soh_ordno



SELECT 
 soh_cocde
,soh_ordno
,soh_verno
,soh_smpsc
,soh_canflg
,soh_clsout
,soh_rplmnt
,convert(char, soh_issdat,120) soh_issdat
,convert(char, soh_rvsdat,120) soh_rvsdat
,soh_ordsts
,soh_cus1no
,soh_cus2no
,soh_biladr
,soh_bilstt
,soh_bilcty
,soh_bilzip
,soh_zshpcusno
,soh_shpadr
,soh_shpstt
,soh_shpcty
,soh_shpzip
,soh_cttper
,soh_salrep
,soh_srname
,soh_saldiv
,soh_saltem
,soh_agt
,soh_prctrm
,soh_paytrm
,soh_sfigtrm
,soh_sprdtrm
,soh_resppo
,soh_ttlvol
,soh_cft
,soh_curcde
,soh_ttlctn
,soh_ttlamt
,soh_netamt
,soh_rmk
,soh_cuspo
,convert(char, soh_cpodat,120) soh_cpodat
,convert(char, soh_shpstr,120) soh_shpstr
,convert(char, soh_shpend,120) soh_shpend
,convert(char, soh_candat,120) soh_candat
,convert(char, soh_lbldue,120) soh_lbldue
,soh_lblven
,soh_moqsc
,soh_email
,soh_curexrat
,convert(char, soh_curexeffdat,120) soh_curexeffdat
,soh_cusctn
,soh_dest
,soh_creusr
,soh_updusr
,convert(char, soh_credat,120) soh_credat
,convert(char, soh_upddat,120) soh_upddat
,null soh_timstp
FROM SCORDHDR left join @TMP_SCNO tmp
ON tmp.SCNO = soh_ordno
where tmp.SCNO is not null

*/

SELECT
distinct 
 soh_cocde
,soh_ordno
,soh_verno
,soh_smpsc
,soh_canflg
,soh_clsout
,soh_rplmnt
,convert(char, soh_issdat,120) soh_issdat
,convert(char, soh_rvsdat,120) soh_rvsdat
,soh_ordsts
,soh_cus1no
,soh_cus2no
,soh_biladr
,soh_bilstt
,soh_bilcty
,soh_bilzip
,soh_zshpcusno
,soh_shpadr
,soh_shpstt
,soh_shpcty
,soh_shpzip
,soh_cttper
,soh_salrep
,soh_srname
,soh_saldiv
,soh_saltem
,soh_agt
,soh_prctrm
,soh_paytrm
,soh_sfigtrm
,soh_sprdtrm
,soh_resppo
,soh_ttlvol
,soh_cft
,soh_curcde
,soh_ttlctn
,soh_ttlamt
,soh_netamt
,soh_rmk
,soh_cuspo
,convert(char, soh_cpodat,120) soh_cpodat
,convert(char, soh_shpstr,120) soh_shpstr
,convert(char, soh_shpend,120) soh_shpend
,convert(char, soh_candat,120) soh_candat
,convert(char, soh_lbldue,120) soh_lbldue
,soh_lblven
,soh_moqsc
,soh_email
,soh_curexrat
,convert(char, soh_curexeffdat,120) soh_curexeffdat
,soh_cusctn
,soh_dest
,soh_creusr
,soh_updusr
,convert(char, soh_credat,120) soh_credat
,convert(char, soh_upddat,120) soh_upddat
,null soh_timst
from QCREQHDR (nolock)
LEFT JOIN QCREQDTL (nolock) on qch_qcno = qcd_qcno
left join POORDDTL (nolock) on pod_purord = qcd_purord and pod_purseq = qcd_purseq
left join SCORDDTL (nolock) on sod_ordno = pod_scno and sod_ordseq = pod_scline
left join SCORDHDR (nolock) on sod_ordno = soh_ordno
where qch_inspweek > DATEPART(wk,GETDATE()) -3 and qch_inspyear = YEAR(GETDATE())
and sod_cocde is not null

END




SET QUOTED_IDENTIFIER OFF 

GO
GRANT EXECUTE ON [dbo].[sp_select_SCORDHDR_QCApp] TO [ERPUSER] AS [dbo]
GO
