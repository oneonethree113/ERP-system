/****** Object:  StoredProcedure [dbo].[sp_select_POORDHDR_QCApp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POORDHDR_QCApp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POORDHDR_QCApp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_select_POORDHDR_QCApp]

AS

BEGIN


declare @TMP_PONO table (
id     int identity(1,1),
PONO nvarchar(20)
)

insert into @TMP_PONO (PONO)
select distinct qpd_purord from
 QCREQDTL LEFT JOIN QCREQHDR on qcd_qcno = qch_qcno
   LEFT JOIN QCPORDTL on qcd_purord = qpd_purord where qch_inspweek > DATEPART(wk,GETDATE()) -3 and qch_inspyear = YEAR(GETDATE())
order by qpd_purord





SELECT
 poh_cocde
,poh_purord
,poh_pursts
,convert(char, poh_issdat,120) poh_issdat
,poh_venno
,poh_puradr
,poh_purstt
,poh_purcty
,poh_purpst
,poh_porctp
,poh_puragt
,poh_salrep
,poh_srname
,poh_saldiv
,poh_saltem
,poh_prmcus
,poh_seccus
,poh_shpadr
,poh_shpstt
,poh_shpcty
,poh_shppst
,poh_prctrm
,poh_paytrm
,poh_ttlcbm
,poh_ttlctn
,poh_curcde
,poh_ttlamt
,poh_discnt
,poh_netamt
,poh_spoflg
,poh_cuspno
,convert(char, poh_cpodat,120) poh_cpodat
,poh_reppno
,convert(char, poh_pocdat,120) poh_pocdat
,convert(char, poh_pocdatend,120) poh_pocdatend
,convert(char, poh_shpstr,120) poh_shpstr
,convert(char, poh_shpend,120) poh_shpend
,convert(char, poh_lbldue,120) poh_lbldue
,poh_lblven
,poh_subcde
,poh_rmk
,poh_ordno
,poh_purchnadr
,poh_signappflg
,poh_appcount
,convert(char, poh_appdat,120) poh_appdat
,poh_vndackflg
,poh_cusctn
,poh_dest
,poh_creusr
,poh_updusr
,convert(char, poh_credat,120) poh_credat
,convert(char, poh_upddat,120) poh_upddat
,null poh_timstp
FROM	POORDHDR left join @TMP_PONO tmp
ON tmp.PONO = poh_purord
where tmp.PONO is not null




END





SET QUOTED_IDENTIFIER OFF 

GO
GRANT EXECUTE ON [dbo].[sp_select_POORDHDR_QCApp] TO [ERPUSER] AS [dbo]
GO
