/****** Object:  StoredProcedure [dbo].[sp_Insert_QUOTNDTL_from_Excel]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Insert_QUOTNDTL_from_Excel]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_QUOTNDTL_from_Excel]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO









CREATE                   PROCEDURE [dbo].[sp_Insert_QUOTNDTL_from_Excel] 

@txtyp 			nvarchar(30),     --upd/new 

@qxd_xlsfil		nvarchar(50),     --for query QUXLSDTL
@qxd_fildat		nvarchar(30),     --for query QUXLSDTL
@qxd_cocde		nvarchar(10),
@qxd_qutno		nvarchar(20),

@qxd_qutseq int,		-- excel row# / grip row # ;  not seq# in  QUOTNDTL
@tmp_itmno nvarchar(30)


AS

Declare
	@qxd_cat nvarchar (50)  ,
	@qxd_rmk nvarchar (300)  ,
	@qxd_inputdat nvarchar (30)  ,
	@qxd_pricust nvarchar (30)  ,
	@qxd_seccust nvarchar (30)  ,
	@qxd_tmpitm nvarchar (30)  ,
	@qxd_orgum nvarchar (30)  ,
	@qxd_period nvarchar (30)  ,
	@qxd_expdat nvarchar (30)  ,
	@qxd_itmno nvarchar (30)  ,
	@qxd_dsc nvarchar (300)  ,
	@qxd_colcde nvarchar (30)  ,
	@qxd_um nvarchar (30)  ,
	@qxd_inr nvarchar (30)  ,
	@qxd_mtr nvarchar (30)  ,
	@qxd_cft nvarchar (30)  ,
	@qxd_pcftr nvarchar (30)  ,
	@qxd_ccy nvarchar (30)  ,
	@qxd_ftycstA nvarchar (30)  ,
	@qxd_ftycstB nvarchar (30)  ,
	@qxd_ftycstC nvarchar (30)  ,
	@qxd_ftycstD nvarchar (30)  ,
	@qxd_ftycstTran nvarchar (30)  ,
	@qxd_ftycstPack nvarchar (30)  ,
	@qxd_ftycst nvarchar (30)  ,
	@qxd_pckitr nvarchar (300)  ,
	@qxd_inrL nvarchar (30)  ,
	@qxd_inrW nvarchar (30)  ,
	@qxd_inrH nvarchar (30)  ,
	@qxd_mtrL nvarchar (30)  ,
	@qxd_mtrW nvarchar (30)  ,
	@qxd_mtrH nvarchar (30)  ,
	@qxd_inrSize nvarchar (30)  ,
	@qxd_mtrSize nvarchar (30)  ,
	@qxd_lightSpec nvarchar (300)  ,
	@qxd_ftyMU nvarchar (30)  ,
	@qxd_ftyPrc nvarchar (30)  ,
	@qxd_hkMU nvarchar (30)  ,
	@qxd_basprc nvarchar (30)  ,
	@qxd_prctrm nvarchar (30)  ,
	@qxd_trantrm nvarchar (30)  ,
	@qxd_vdrtranflg nvarchar (30)  ,
	@qxd_MU nvarchar (30)  ,
	@qxd_pckcst nvarchar (30)  ,
	@qxd_comm nvarchar (30)  ,
	@qxd_itmcomm nvarchar (30)  ,
	@qxd_stdprc nvarchar (30)  ,
	@qxd_cushcstbuf nvarchar (30)  ,
	@qxd_othdislmt nvarchar (30)  ,
	@qxd_maxdis nvarchar (30)  ,
	@qxd_lowerMU nvarchar (30)  ,
	@qxd_adjMU nvarchar (30)  ,
	@qxd_adjprc nvarchar (30)  ,
	@qxd_msg nvarchar (300)  ,
	@qxd_txtyp nvarchar (10)  ,
	@qxd_sts nvarchar (10)  ,
	@qxd_cus1no nvarchar (10)  ,
	@qxd_cus2no nvarchar (10)  ,

	@real_itmno nvarchar (30)  


-- get data from  QUXLSDTL
Select
@qxd_cat=qxd_cat,
@qxd_rmk=qxd_rmk,			-- hidden
@qxd_inputdat=qxd_inputdat,		-- hidden
@qxd_pricust=qxd_pricust,
@qxd_seccust=qxd_seccust,		-- hidden
@qxd_tmpitm=qxd_tmpitm,		-- hidden
@qxd_orgum=qxd_orgum,
@qxd_period=qxd_period,
@qxd_expdat=qxd_expdat,		-- hidden
@qxd_itmno=qxd_itmno,
@qxd_dsc=qxd_dsc,
@qxd_colcde=qxd_colcde,
@qxd_um=qxd_um,
@qxd_inr=qxd_inr,
@qxd_mtr=qxd_mtr,
@qxd_cft=qxd_cft,
@qxd_pcftr=qxd_pcftr,
@qxd_ccy=qxd_ccy,
@qxd_ftycstA=qxd_ftycstA,
@qxd_ftycstB=qxd_ftycstB,
@qxd_ftycstC=qxd_ftycstC,
@qxd_ftycstD=qxd_ftycstD,
@qxd_ftycstTran=qxd_ftycstTran,
@qxd_ftycstPack=qxd_ftycstPack,
@qxd_ftycst=qxd_ftycst,
@qxd_pckitr=qxd_pckitr,		-- hidden
@qxd_inrL=qxd_inrL,			-- hidden
@qxd_inrW=qxd_inrW,			-- hidden
@qxd_inrH=qxd_inrH,			-- hidden
@qxd_mtrL=qxd_mtrL,			-- hidden
@qxd_mtrW=qxd_mtrW,		-- hidden
@qxd_mtrH=qxd_mtrH,		-- hidden
@qxd_inrSize=qxd_inrSize,		-- hidden
@qxd_mtrSize=qxd_mtrSize,		-- hidden
@qxd_lightSpec=qxd_lightSpec,	-- hidden
@qxd_ftyMU=qxd_ftyMU,
@qxd_ftyPrc=qxd_ftyPrc,
@qxd_hkMU=qxd_hkMU,
@qxd_basprc=qxd_basprc,
@qxd_prctrm=qxd_prctrm,
@qxd_trantrm=qxd_trantrm,
@qxd_vdrtranflg=qxd_vdrtranflg,
@qxd_MU=qxd_MU,
@qxd_pckcst=qxd_pckcst,
@qxd_comm=qxd_comm,
@qxd_itmcomm=qxd_itmcomm,
@qxd_stdprc=qxd_stdprc,
@qxd_cushcstbuf=qxd_cushcstbuf,
@qxd_othdislmt=qxd_othdislmt,
@qxd_maxdis=qxd_maxdis,
@qxd_lowerMU=qxd_lowerMU,
@qxd_adjMU=qxd_adjMU,
@qxd_adjprc=qxd_adjprc,
@qxd_msg=qxd_msg,
@qxd_txtyp=qxd_txtyp,
@qxd_sts=qxd_sts,
@qxd_cus1no=qxd_cus1no,
@qxd_cus2no=qxd_cus2no
from QUXLSDTL
where qxd_xlsfil = @qxd_xlsfil 
and  qxd_fildat = @qxd_fildat
and  qxd_qutno=@qxd_qutno
and  qxd_cocde=@qxd_cocde
and  qxd_itmno =@tmp_itmno 
--and  qxd_colcde= @tmp_colcde
--and  qxd_um=@tmp_pckunt			-- recheck
--and  qxd_inr =@tmp_inrqty
--and  qxd_mtr =@tmp_mtrqty
--and  qxd_prctrm=@tmp_hkprctrm
--and  qxd_trantrm=@tmp_trantrm



if @txtyp<>'UPD'          --For NEW CASE, Additional Info
begin
	update	QUOTNDTL  
	set 
	qud_imrmk = isnull(@qxd_rmk,'') 
--	qud_qutdat =case when  Ltrim(isnull(@qxd_inputdat,''))<> '' and Ltrim(@qxd_inputdat)<> '01/01/1900' then  @qxd_inputdat  else  getdate() end ,
--	qud_expdat =case when Ltrim(isnull(@qxd_expdat,''))<> '' then  @qxd_expdat  else  '01/01/1900' end
	where   qud_qutno=@qxd_qutno
	and  qud_cocde=@qxd_cocde
	and  qud_itmno= @tmp_itmno 
	and  qud_qutseq=@qxd_qutseq 


	update	QUPRCEMT  
	set 
	--qpe_ftycstA = isnull(@qxd_ftycstA,0),
	--qpe_ftycstB = isnull(@qxd_ftycstB,0),
	--qpe_ftycstC = isnull(@qxd_ftycstC,0),
	--qpe_ftycstD = isnull(@qxd_ftycstD,0),
	--qpe_ftycstTran = isnull(@qxd_ftycstTran,0), 
	--qpe_ftycstPack =  isnull(@qxd_ftycstPack,0), 
	qpe_lightspec = isnull(@qxd_lightSpec,0)
	where   qpe_qutno=@qxd_qutno
	and  qpe_cocde=@qxd_cocde
	and  qpe_itmno= @tmp_itmno 
	and  qpe_qutseq=@qxd_qutseq 

end













GO
GRANT EXECUTE ON [dbo].[sp_Insert_QUOTNDTL_from_Excel] TO [ERPUSER] AS [dbo]
GO
