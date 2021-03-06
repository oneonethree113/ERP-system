/****** Object:  StoredProcedure [dbo].[sp_insert_QUAPPDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_QUAPPDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_QUAPPDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO









/*
=========================================================
Description   	: sp_insert_QUAPPDTL
Table Write(s) 	: QUAPPDTL
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description          
=========================================================     
*/

CREATE     PROCEDURE [dbo].[sp_insert_QUAPPDTL] 

@qxd_tmpqutno nvarchar(50) ,
@qxd_tmpqutseq INT,
@qxd_cat nvarchar(50) ,
@qxd_rmk nvarchar(300) ,
@qxd_inputdat nvarchar(30) ,
@qxd_pricust nvarchar(30) ,
@qxd_seccust nvarchar(30) ,
@qxd_tmpitm nvarchar(30) ,
@qxd_orgum nvarchar(30) ,
@qxd_period nvarchar(30) ,
@qxd_expdat nvarchar(30) ,
@qxd_itmno nvarchar(30) ,
@qxd_dsc nvarchar(300) ,
@qxd_colcde nvarchar(30) ,
@qxd_um nvarchar(30) ,
@qxd_inr nvarchar(30) ,
@qxd_mtr nvarchar(30) ,
@qxd_cft nvarchar(30) ,
@qxd_pcftr nvarchar(30) ,
@qxd_ccy nvarchar(30) ,
@qxd_ftycstA nvarchar(30) ,
@qxd_ftycstB nvarchar(30) ,
@qxd_ftycstC nvarchar(30) ,
@qxd_ftycstD nvarchar(30) ,
@qxd_ftycstTran nvarchar(30) ,
@qxd_ftycstPack nvarchar(30) ,
@qxd_ftycst nvarchar(30) ,
@qxd_pckitr nvarchar(300) ,
@qxd_inrL nvarchar(30) ,
@qxd_inrW nvarchar(30) ,
@qxd_inrH nvarchar(30) ,
@qxd_mtrL nvarchar(30) ,
@qxd_mtrW nvarchar(30) ,
@qxd_mtrH nvarchar(30) ,
@qxd_inrSize nvarchar(30) ,
@qxd_mtrSize nvarchar(30) ,
@qxd_lightSpec nvarchar(300) ,
@qxd_ftyMU nvarchar(30) ,
@qxd_ftyPrc nvarchar(30) ,
@qxd_hkMU nvarchar(30) ,
@qxd_basprc nvarchar(30) ,
@qxd_prctrm nvarchar(30) ,
@qxd_trantrm nvarchar(30) ,
@qxd_vdrtranflg nvarchar(30) ,
@qxd_MU nvarchar(30) ,
@qxd_pckcst nvarchar(30) ,
@qxd_comm nvarchar(30) ,
@qxd_itmcomm nvarchar(30) ,
@qxd_stdprc nvarchar(30) ,
@qxd_cushcstbuf nvarchar(30) ,
@qxd_othdislmt nvarchar(30) ,
@qxd_maxdis nvarchar(30) ,
@qxd_lowerMU nvarchar(30) ,
@qxd_adjMU nvarchar(30) ,
@qxd_adjprc nvarchar(30) ,
@qxd_msg nvarchar(300) ,
@qxd_txtyp nvarchar(10) ,
@qxd_sts nvarchar(10) ,
@qxd_cocde nvarchar(10) ,
@qxd_cus1no nvarchar(10) ,
@qxd_cus2no nvarchar(10) ,
@qxd_qutno nvarchar(10) ,
@qxd_venno nvarchar(6),
@qxd_vensna nvarchar(40),
@qxd_vencolcde nvarchar(30),
@qxd_creusr nvarchar(30) ,
@qxd_updusr nvarchar(30) ,
@qxd_ftyprctrm nvarchar(30)

AS

insert into	QUAPPDTL
(qxd_tmpqutno,
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
qxd_venno,
qxd_vensna,
qxd_vencolcde,
qxd_creusr,
qxd_updusr,
qxd_credat,
qxd_upddat,
qxd_timstp,
qxd_ftyprctrm
)
values	(@qxd_tmpqutno,
@qxd_tmpqutseq,
@qxd_cat,
@qxd_rmk,
@qxd_inputdat,
@qxd_pricust,
@qxd_seccust,
@qxd_tmpitm,
@qxd_orgum,
@qxd_period,
@qxd_expdat,
@qxd_itmno,
@qxd_dsc,
@qxd_colcde,
@qxd_um,
@qxd_inr,
@qxd_mtr,
@qxd_cft,
@qxd_pcftr,
@qxd_ccy,
@qxd_ftycstA,
@qxd_ftycstB,
@qxd_ftycstC,
@qxd_ftycstD,
@qxd_ftycstTran,
@qxd_ftycstPack,
@qxd_ftycst,
@qxd_pckitr,
@qxd_inrL,
@qxd_inrW,
@qxd_inrH,
@qxd_mtrL,
@qxd_mtrW,
@qxd_mtrH,
@qxd_inrSize,
@qxd_mtrSize,
@qxd_lightSpec,
@qxd_ftyMU,
@qxd_ftyPrc,
@qxd_hkMU,
@qxd_basprc,
@qxd_prctrm,
@qxd_trantrm,
@qxd_vdrtranflg,
@qxd_MU,
@qxd_pckcst,
@qxd_comm,
@qxd_itmcomm,
@qxd_stdprc,
@qxd_cushcstbuf,
@qxd_othdislmt,
@qxd_maxdis,
@qxd_lowerMU,
@qxd_adjMU,
@qxd_adjprc,
@qxd_msg,
'New',
@qxd_sts,
@qxd_cocde,
@qxd_cus1no,
@qxd_cus2no,
@qxd_qutno,
@qxd_venno,
@qxd_vensna,
@qxd_vencolcde,
@qxd_creusr,
@qxd_updusr,
GETDATE(),
GETDATE(),
Default,
@qxd_ftyprctrm
)


GO
GRANT EXECUTE ON [dbo].[sp_insert_QUAPPDTL] TO [ERPUSER] AS [dbo]
GO
