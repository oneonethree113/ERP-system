/****** Object:  StoredProcedure [dbo].[sp_select_POORDDTL_QCApp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POORDDTL_QCApp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POORDDTL_QCApp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[sp_select_POORDDTL_QCApp]

 

AS

 

BEGIN

 

 

 

declare @TMP_PONO table (

id     int identity(1,1),

PONO nvarchar(20)

)

 

insert into @TMP_PONO (PONO)

select distinct qpd_purord from QCREQDTL LEFT JOIN QCREQHDR on qcd_qcno = qch_qcno

LEFT JOIN QCPORDTL on qcd_purord = qpd_purord 

where 

 

qch_inspweek > DATEPART(wk,GETDATE()) -3 and qch_inspyear = YEAR(GETDATE())

 

 

 

SELECT

pod_cocde

,pod_purord

,pod_purseq

,pod_prdven

,pod_tradeven

,pod_examven

,pod_prdsubcde

,rtrim(pod_itmno) pod_itmno

,pod_itmsts

,pod_seccusitm

,pod_venitm

,rtrim(pod_cusitm) pod_cusitm

,pod_cussku

,pod_engdsc

,pod_chndsc

,pod_vencol

,pod_cuscol

,pod_coldsc

,pod_pckseq

,pod_untcde

,pod_inrctn

,pod_mtrctn

,pod_cubcft

,pod_cbm

,pod_dept

,pod_ordqty

,pod_recqty

,pod_ftyprc

,pod_cuspno

,pod_respno

,pod_hrmcde

,pod_lblcde

,pod_cususdcur

,pod_cususd

,pod_cuscadcur

,pod_cuscad

,convert(char, pod_shpstr,120) pod_shpstr

,convert(char, pod_shpend,120) pod_shpend

,convert(char, pod_candat,120) pod_candat

,pod_ctnstr

,pod_ctnend

,pod_scno

,pod_ttlctn

,pod_lneamt

,pod_lnecub

,pod_ttlqty

,pod_scline

,pod_jobord

,pod_runno

,pod_assflg

,pod_dtyrat

,pod_typcode

,pod_code1

,pod_code2

,pod_code3

,pod_rmk

,pod_pckitr

,pod_alsitmno

,pod_alscolcde

,pod_orgcur

,pod_curexrat

,convert(char, pod_curexeffdat,120) pod_curexeffdat

,convert(char, pod_qutdat,120) pod_qutdat

,convert(char, pod_imqutdat,120) pod_imqutdat

,pod_cus1no

,pod_cus2no

,pod_hkprctrm

,pod_ftyprctrm

,pod_trantrm

,convert(char, pod_effdat,120) pod_effdat

,convert(char, pod_expdat,120) pod_expdat

,pod_creusr

,pod_updusr

,convert(char, pod_credat,120) pod_credat

,convert(char, pod_upddat,120) pod_upddat

,null pod_timstp

FROM POORDDTL left join @TMP_PONO tmp

ON tmp.PONO = pod_purord

where tmp.PONO is not null

 

 

END

 

 

 

 

 

 

SET QUOTED_IDENTIFIER OFF 


GO
GRANT EXECUTE ON [dbo].[sp_select_POORDDTL_QCApp] TO [ERPUSER] AS [dbo]
GO
