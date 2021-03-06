/****** Object:  StoredProcedure [dbo].[sp_list_QUAPPDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_QUAPPDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_QUAPPDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE       PROCEDURE [dbo].[sp_list_QUAPPDTL] 
@qxd_cocde nvarchar(10),
@usrid		nvarchar(30),
@cus1no		nvarchar(10),
@cus2no		nvarchar(10),
@tmpqutno	nvarchar(30)

as

select
qxd_tmpqutno,
qxd_tmpqutseq,
qxd_cat,
qxd_rmk,
qxd_inputdat,
qxd_pricust,
qxd_seccust,
qxd_tmpitm,
qxd_orgum,
qxd_period,
qxd_expdat,
qxd_itmno,
qxd_dsc,
qxd_colcde,
qxd_um,
qxd_inr,
qxd_mtr,
qxd_cft,
qxd_pcftr,
qxd_ccy,
qxd_ftycstA,
qxd_ftycstB,
qxd_ftycstC,
qxd_ftycstD,
qxd_ftycstTran,
qxd_ftycstPack,
qxd_ftycst,
qxd_pckitr,
qxd_inrL,
qxd_inrW,
qxd_inrH,
qxd_mtrL,
qxd_mtrW,
qxd_mtrH,
qxd_inrSize,
qxd_mtrSize,
qxd_lightSpec,
qxd_ftyMU,
qxd_ftyPrc,
qxd_hkMU,
qxd_basprc,
qxd_prctrm,
qxd_trantrm,
qxd_vdrtranflg,
qxd_MU,
qxd_pckcst,
qxd_comm,
qxd_itmcomm,
qxd_stdprc,
qxd_cushcstbuf,
qxd_othdislmt,
qxd_maxdis,
qxd_lowerMU,
qxd_adjMU,
qxd_adjprc,
qxd_msg,
qxd_txtyp,
qxd_sts,
qxd_cocde,
qxd_cus1no,
qxd_cus2no,
qxd_qutno,
qxd_creusr,
qxd_updusr,
qxd_credat,
qxd_upddat,
qxd_timstp,
qxd_venno,
qxd_vensna,
qxd_vencolcde,
qxd_ftyprctrm,
qxd_flgtmp
from QUAPPDTL (nolock)
where --qxd_tmpqutno = @tmpqutno and
qxd_creusr = @usrid and
qxd_pricust = @cus1no and qxd_seccust = @cus2no and
((@tmpqutno = 'ALL') or (@tmpqutno <> 'ALL' and qxd_tmpqutno = @tmpqutno)) 
order by  
qxd_tmpqutno desc, qxd_tmpqutseq, qxd_pricust,qxd_seccust,qxd_itmno



GO
GRANT EXECUTE ON [dbo].[sp_list_QUAPPDTL] TO [ERPUSER] AS [dbo]
GO
