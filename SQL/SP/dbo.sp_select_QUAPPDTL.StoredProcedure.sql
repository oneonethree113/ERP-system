/****** Object:  StoredProcedure [dbo].[sp_select_QUAPPDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUAPPDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUAPPDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO









/*
=========================================================
Description   	: [sp_select_QUAPPDTL]
Table Write(s) 	: QUAPPDTL
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description          
=========================================================     
*/

CREATE     PROCEDURE [dbo].[sp_select_QUAPPDTL] 

@qxd_tmpqutno nvarchar(50) ,
@qxd_tmpqutseq INT

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
qxd_ftyprctrm
from QUAPPDTL (nolock)
where qxd_tmpqutno = @qxd_tmpqutno and qxd_tmpqutseq = @qxd_tmpqutseq

GO
GRANT EXECUTE ON [dbo].[sp_select_QUAPPDTL] TO [ERPUSER] AS [dbo]
GO
