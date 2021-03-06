/****** Object:  StoredProcedure [dbo].[sp_update_IMCLRDAT_XLS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMCLRDAT_XLS]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMCLRDAT_XLS]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













/*
=================================================================
Program ID	: sp_update_IMCLRDAT_XLS
Description	: Remove old IM Data entries to History
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-03-10 	David Yue		SP Created
=================================================================
*/

CREATE  PROCEDURE [dbo].[sp_update_IMCLRDAT_XLS] 

@cocde		nvarchar(6),
@usrid		nvarchar(30)

AS

-- Move outstanding entries to IMITMDATH --
insert into IMITMDATH
(	iid_cocde,		iid_venno,		iid_prdven,		
	iid_venitm,		iid_itmseq,		iid_recseq,		
	iid_itmtyp,		iid_itmno,		iid_mode,		
	iid_itmsts,		iid_stage,		iid_engdsc,		
	iid_chndsc,		iid_lnecde,		iid_catlvl4,		
	iid_untcde,		iid_inrqty,		iid_mtrqty,		
	iid_inrlcm,		iid_inrwcm,		iid_inrhcm,		
	iid_mtrlcm,		iid_mtrwcm,		iid_mtrhcm,		
	iid_cft,		iid_conftr,		iid_sapum,		
	iid_curcde,		iid_ftycst,		iid_ftyprc,		
	iid_ftyprctrm,		iid_prctrm,		iid_trantrm,		
	iid_grswgt,		iid_netwgt,		iid_pckitr,		
	iid_engdsc_bef,		iid_chndsc_bef,		iid_lnecde_bef,		
	iid_catlvl4_bef,	iid_inrlcm_bef,		iid_inrwcm_bef,		
	iid_inrhcm_bef,		iid_mtrlcm_bef,		iid_mtrwcm_bef,		
	iid_mtrhcm_bef,		iid_cft_bef,		iid_conftr_bef,		
	iid_curcde_bef,		iid_ftycst_bef,		iid_ftyprc_bef,		
	iid_prctrm_bef,		iid_grswgt_bef,		iid_netwgt_bef,		
	iid_pckitr_bef,		iid_sysmsg,		iid_xlsfil,		
	iid_veneml,		iid_malsts,		iid_chkdat,		
	iid_refresh,		iid_bomflg,		iid_orgdsgvenno,		
	iid_MOQ,		iid_orgdsgvenno_bef,	iid_moq_bef,		
	iid_fcurcde,		iid_fcurcde_bef,	iid_wastage,		
	iid_wastage_bef,	iid_remark,		iid_remark_bef,		
	iid_cusven,		iid_alsitmno,		iid_alsitmno_bef,		
	iid_alscolcde,		iid_alscolcde_bef,	iid_basprc,		
	iid_basprc_bef,		iid_bomprc,		iid_bomprc_bef,		
	iid_curr_bef,		iid_assconftr,		iid_assconftr_bef,		
	iid_period,		iid_period_bef,		iid_cstexpdat,		
	iid_cstexpdat_bef,	iid_cus1no,		iid_creusr,		
	iid_updusr,		iid_credat,		iid_upddat,		
	iid_inrsze,		iid_mtrsze,		iid_mat,		
	iid_inrsze_bef,		iid_mtrsze_bef,		iid_mat_bef,		
	iid_ftytmp,		iid_alstmpitmno,	iid_ftytmp_bef,		
	iid_alstmpitmno_bef
)
select	cur.iid_cocde,		cur.iid_venno,		cur.iid_prdven,		
	cur.iid_venitm,		cur.iid_itmseq,		cur.iid_recseq,		
	cur.iid_itmtyp,		cur.iid_itmno,		cur.iid_mode,		
	cur.iid_itmsts,		cur.iid_stage,		cur.iid_engdsc,		
	cur.iid_chndsc,		cur.iid_lnecde,		cur.iid_catlvl4,		
	cur.iid_untcde,		cur.iid_inrqty,		cur.iid_mtrqty,		
	cur.iid_inrlcm,		cur.iid_inrwcm,		cur.iid_inrhcm,		
	cur.iid_mtrlcm,		cur.iid_mtrwcm,		cur.iid_mtrhcm,		
	cur.iid_cft,		cur.iid_conftr,		cur.iid_sapum,		
	cur.iid_curcde,		cur.iid_ftycst,		cur.iid_ftyprc,		
	cur.iid_ftyprctrm,	cur.iid_prctrm,		cur.iid_trantrm,		
	cur.iid_grswgt,		cur.iid_netwgt,		cur.iid_pckitr,		
	cur.iid_engdsc_bef,	cur.iid_chndsc_bef,	cur.iid_lnecde_bef,		
	cur.iid_catlvl4_bef,	cur.iid_inrlcm_bef,	cur.iid_inrwcm_bef,		
	cur.iid_inrhcm_bef,	cur.iid_mtrlcm_bef,	cur.iid_mtrwcm_bef,		
	cur.iid_mtrhcm_bef,	cur.iid_cft_bef,	cur.iid_conftr_bef,		
	cur.iid_curcde_bef,	cur.iid_ftycst_bef,	cur.iid_ftyprc_bef,		
	cur.iid_prctrm_bef,	cur.iid_grswgt_bef,	cur.iid_netwgt_bef,		
	cur.iid_pckitr_bef,	cur.iid_sysmsg,		cur.iid_xlsfil,		
	cur.iid_veneml,		cur.iid_malsts,		cur.iid_chkdat,		
	cur.iid_refresh,	cur.iid_bomflg,		cur.iid_orgdsgvenno,		
	cur.iid_MOQ,		cur.iid_orgdsgvenno_bef,cur.iid_moq_bef,		
	cur.iid_fcurcde,	cur.iid_fcurcde_bef,	cur.iid_wastage,		
	cur.iid_wastage_bef,	cur.iid_remark,		cur.iid_remark_bef,		
	cur.iid_cusven,		cur.iid_alsitmno,	cur.iid_alsitmno_bef,		
	cur.iid_alscolcde,	cur.iid_alscolcde_bef,	isnull(cur.iid_basprc,0),
	isnull(cur.iid_basprc_bef,0),	cur.iid_bomprc,		cur.iid_bomprc_bef,		
	cur.iid_curr_bef,	cur.iid_assconftr,	cur.iid_assconftr_bef,		
	cur.iid_period,		cur.iid_period_bef,	cur.iid_cstexpdat,		
	cur.iid_cstexpdat_bef,	cur.iid_cus1no,		cur.iid_creusr,		
	cur.iid_updusr,		cur.iid_credat,		cur.iid_upddat,		
	cur.iid_inrsze,		cur.iid_mtrsze,		cur.iid_mat,		
	cur.iid_inrsze_bef,	cur.iid_mtrsze_bef,	cur.iid_mat_bef,		
	cur.iid_ftytmp,		cur.iid_alstmpitmno,	cur.iid_ftytmp_bef,		
	cur.iid_alstmpitmno_bef
from	IMITMDAT cur
where	(iid_stage = 'O' or 
	 (iid_stage not in ('A','W') and iid_credat <= dateadd(dd, -1, getdate())) or 
	 (iid_stage in ('A','W') and iid_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMITMDATH his where his.iid_itmseq = cur.iid_itmseq and his.iid_recseq = cur.iid_recseq) = 0

-- Delete outstanding entries from IMITMDAT --
delete	cur
from	IMITMDAT cur
where	(iid_stage = 'O' or 
	 (iid_stage not in ('A','W') and iid_credat <= dateadd(dd, -1, getdate())) or 
	 (iid_stage in ('A','W') and iid_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMITMDATH his where his.iid_itmseq = cur.iid_itmseq and his.iid_recseq = cur.iid_recseq) = 1
	and iid_venitm <> ''

-- Move outstanding entries to IMITMDATCSTH --
insert into IMITMDATCSTH
(	iic_cocde,		iic_venno,		iic_prdven,		
	iic_venitm,		iic_itmseq,		iic_recseq,		
	iic_xlsfil,		iic_chkdat,		iic_cus1no,		
	iic_cus2no,		iic_stage,		iic_untcde,		
	iic_mtrqty,		iic_inrqty,		iic_fcA,		
	iic_fcB,		iic_fcC,		iic_fcD,		
	iic_fcTran,		iic_fcPack,		iic_ftycst,		
	iic_icA,		iic_icB,		iic_icC,		
	iic_icD,		iic_icTran,		iic_icPack,		
	iic_ftyprc,		iic_nat,		iic_negprc,		
	iic_conftr,		iic_creusr,		iic_updusr,		
	iic_credat,		iic_upddat
)
select	iic_cocde,		iic_venno,		iic_prdven,		
	iic_venitm,		iic_itmseq,		iic_recseq,		
	iic_xlsfil,		iic_chkdat,		iic_cus1no,		
	iic_cus2no,		iic_stage,		iic_untcde,		
	iic_mtrqty,		iic_inrqty,		iic_fcA,		
	iic_fcB,		iic_fcC,		iic_fcD,		
	iic_fcTran,		iic_fcPack,		iic_ftycst,		
	iic_icA,		iic_icB,		iic_icC,		
	iic_icD,		iic_icTran,		iic_icPack,		
	iic_ftyprc,		iic_nat,		iic_negprc,		
	iic_conftr,		iic_creusr,		iic_updusr,		
	iic_credat,		iic_upddat
from	IMITMDATCST cur
where	(iic_stage = 'O' or 
	 (iic_stage not in ('A','W') and iic_credat <= dateadd(dd, -1, getdate())) or 
	 (iic_stage in ('A','W') and iic_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMITMDATCSTH his where his.iic_itmseq = cur.iic_itmseq and his.iic_recseq = cur.iic_recseq) = 0

-- Delete outstanding entries from IMITMDATCST --
delete	cur
from	IMITMDATCST cur
where	(iic_stage = 'O' or 
	 (iic_stage not in ('A','W') and iic_credat <= dateadd(dd, -1, getdate())) or 
	 (iic_stage in ('A','W') and iic_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMITMDATCSTH his where his.iic_itmseq = cur.iic_itmseq and his.iic_recseq = cur.iic_recseq) = 1

-- Move outstanding entries to IMCOLDATH --
insert into IMCOLDATH
(	icd_cocde,		icd_venno,		icd_prdven,		
	icd_venitm,		icd_itmseq,		icd_recseq,		
	icd_colcde,		icd_coldsc,		icd_stage,		
	icd_sysmsg,		icd_xlsfil,		icd_veneml,		
	icd_malsts,		icd_chkdat,		icd_creusr,		
	icd_updusr,		icd_credat,		icd_upddat
)
select	icd_cocde,		icd_venno,		icd_prdven,		
	icd_venitm,		icd_itmseq,		icd_recseq,		
	icd_colcde,		icd_coldsc,		icd_stage,		
	icd_sysmsg,		icd_xlsfil,		icd_veneml,		
	icd_malsts,		icd_chkdat,		icd_creusr,		
	icd_updusr,		icd_credat,		icd_upddat
from	IMCOLDAT cur
where	(icd_stage = 'O' or 
	 (icd_stage not in ('A','W') and icd_credat <= dateadd(dd, -1, getdate())) or 
	 (icd_stage in ('A','W') and icd_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMCOLDATH his where his.icd_itmseq = cur.icd_itmseq and his.icd_recseq = cur.icd_recseq) = 0

-- Delete outstanding entries from IMCOLDAT --
delete	cur
from	IMCOLDAT cur
where	(icd_stage = 'O' or 
	 (icd_stage not in ('A','W') and icd_credat <= dateadd(dd, -1, getdate())) or 
	 (icd_stage in ('A','W') and icd_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMCOLDATH his where his.icd_itmseq = cur.icd_itmseq and his.icd_recseq = cur.icd_recseq) = 1

-- Move outstanding entries to IMCOMDATH --
insert into IMCOMDATH
(	imd_cocde,		imd_venno,		imd_prdven,
	imd_venitm,		imd_itmseq,		imd_recseq,
	imd_cosmth,		imd_compon,		imd_asstive,
	imd_rmk,		imd_stage,		imd_sysmsg,
	imd_xlsfil,		imd_veneml,		imd_malsts,
	imd_chkdat,		imd_creusr,		imd_updusr,
	imd_credat,		imd_upddat
)
select	imd_cocde,		imd_venno,		imd_prdven,
	imd_venitm,		imd_itmseq,		imd_recseq,
	imd_cosmth,		imd_compon,		imd_asstive,
	imd_rmk,		imd_stage,		imd_sysmsg,
	imd_xlsfil,		imd_veneml,		imd_malsts,
	imd_chkdat,		imd_creusr,		imd_updusr,
	imd_credat,		imd_upddat
from	IMCOMDAT cur
where	(imd_stage = 'O' or 
	 (imd_stage not in ('A','W') and imd_credat <= dateadd(dd, -1, getdate())) or 
	 (imd_stage in ('A','W') and imd_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMCOMDATH his where his.imd_itmseq = cur.imd_itmseq and his.imd_recseq = cur.imd_recseq) = 0


-- Delete outstanding entries from IMCOMDAT --
delete	cur
from	IMCOMDAT cur
where	(imd_stage = 'O' or 
	 (imd_stage not in ('A','W') and imd_credat <= dateadd(dd, -1, getdate())) or 
	 (imd_stage in ('A','W') and imd_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMCOMDATH his where his.imd_itmseq = cur.imd_itmseq and his.imd_recseq = cur.imd_recseq) = 1

-- Move outstanding entries to IMBOMDATH --
insert into IMBOMDATH
(	ibd_cocde,		ibd_venno,		ibd_prdven,		
	ibd_venitm,		ibd_acsno,		ibd_itmseq,		
	ibd_recseq,		ibd_seqno,		ibd_colcde,
	ibd_qty,		ibd_untcde,		ibd_conftr,
	ibd_stage,		ibd_sysmsg,		ibd_xlsfil,
	ibd_veneml,		ibd_malsts,		ibd_chkdat,
	ibd_itmdsc,		ibd_period,		ibd_creusr,
	ibd_updusr,		ibd_credat,		ibd_upddat
)
select	ibd_cocde,		ibd_venno,		ibd_prdven,		
	ibd_venitm,		ibd_acsno,		ibd_itmseq,		
	ibd_recseq,		0,			ibd_colcde,
	ibd_qty,		ibd_untcde,		ibd_conftr,
	ibd_stage,		ibd_sysmsg,		ibd_xlsfil,
	ibd_veneml,		ibd_malsts,		ibd_chkdat,
	ibd_itmdsc,		ibd_period,		ibd_creusr,	
	ibd_updusr,		ibd_credat,		ibd_upddat
from	IMBOMDAT cur
where	(ibd_stage = 'O' or 
	 (ibd_stage not in ('A','W') and ibd_credat <= dateadd(dd, -1, getdate())) or 
	 (ibd_stage in ('A','W') and ibd_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMBOMDATH his where his.ibd_itmseq = cur.ibd_itmseq and his.ibd_recseq = cur.ibd_recseq) = 0

-- Delete outstanding entries from IMBOMDAT --
delete	cur
from	IMBOMDAT cur
where	(ibd_stage = 'O' or 
	 (ibd_stage not in ('A','W') and ibd_credat <= dateadd(dd, -1, getdate())) or 
	 (ibd_stage in ('A','W') and ibd_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMBOMDATH his where his.ibd_itmseq = cur.ibd_itmseq and his.ibd_recseq = cur.ibd_recseq) = 1

-- Move outstanding entries to IMASSDATH --
insert into IMASSDATH
(	iad_cocde,		iad_venno,		iad_prdven,		
	iad_venitm,		iad_acsno,		iad_itmseq,		
	iad_recseq,		iad_colcde,		iad_inrqty,		
	iad_mtrqty,		iad_untcde,		iad_conftr,		
	iad_stage,		iad_sysmsg,		iad_xlsfil,		
	iad_veneml,		iad_malsts,		iad_chkdat,		
	iad_period,		iad_creusr,		iad_updusr,
	iad_credat,		iad_upddat
)
select	iad_cocde,		iad_venno,		iad_prdven,		
	iad_venitm,		iad_acsno,		iad_itmseq,		
	iad_recseq,		iad_colcde,		iad_inrqty,		
	iad_mtrqty,		iad_untcde,		iad_conftr,		
	iad_stage,		iad_sysmsg,		iad_xlsfil,		
	iad_veneml,		iad_malsts,		iad_chkdat,		
	iad_period,		iad_creusr,		iad_updusr,
	iad_credat,		iad_upddat
from	IMASSDAT cur
where	(iad_stage = 'O' or 
	 (iad_stage not in ('A','W') and iad_credat <= dateadd(dd, -1, getdate())) or 
	 (iad_stage in ('A','W') and iad_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMASSDATH his where his.iad_itmseq = cur.iad_itmseq and his.iad_recseq = cur.iad_recseq) = 0

-- Delete outstanding entries from IMASSDAT --
delete	cur
from	IMASSDAT cur
where	(iad_stage = 'O' or 
	 (iad_stage not in ('A','W') and iad_credat <= dateadd(dd, -1, getdate())) or 
	 (iad_stage in ('A','W') and iad_credat <= dateadd(dd, -7, getdate()))
	) and
	(select count(*) from IMASSDATH his where his.iad_itmseq = cur.iad_itmseq and his.iad_recseq = cur.iad_recseq) = 1





GO
GRANT EXECUTE ON [dbo].[sp_update_IMCLRDAT_XLS] TO [ERPUSER] AS [dbo]
GO
