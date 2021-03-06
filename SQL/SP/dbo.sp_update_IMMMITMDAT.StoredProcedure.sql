/****** Object:  StoredProcedure [dbo].[sp_update_IMMMITMDAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMMMITMDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMMMITMDAT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/*	Author : Frankie Cheung	*/
/*	Date : 10 Oct  2008	*/

CREATE procedure [dbo].[sp_update_IMMMITMDAT]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imd_cocde	nvarchar(6),
@imd_cus1no 	nvarchar(10),
@imd_cus2no	nvarchar(10),
@imd_itmno	nvarchar(50),
@imd_inrqty	int,
@imd_mtrqty	int,
@imd_itmseq	int,
@imd_recseq	int,
@imd_untcde	nvarchar(60),
@imd_stage	nvarchar(3),
@imd_updusr	nvarchar(30)



                                 

------------------------------------ 
AS

Declare   -- IMMMITMDAT

@imd_venno		nvarchar(6),		@imd_prdven 		nvarchar(6),		@imd_itmtyp		nvarchar(3),
@imd_lnecde		nvarchar(10),		@imd_catlvl4		nvarchar(20),		@imd_aliasItemNo	nvarchar(50),
@imd_engdsc		nvarchar(800),		@imd_chndsc		nvarchar(1600),		@imd_curcde		nvarchar(10),
@imd_mode		nvarchar(3),		@imd_itmsts		nvarchar(3),		@imd_fcA		numeric(13,4),
@imd_fcB		numeric(13,4), 		@imd_fcC		numeric(13,4), 		@imd_fcD		numeric(13,4),
@imd_fcTran		numeric(13,4),		@imd_fcpck		numeric(13,4),		@imd_fcttl		numeric(13,4),
@imd_cft		numeric(13,4),		@imd_icA		numeric(13,4),		@imd_icB		numeric(13,4),	
@imd_icC		numeric(13,4),		@imd_icD		numeric(13,4),		@imd_icTran		numeric(13,4),	
@imd_icpck		numeric(13,4),		@imd_icttl		numeric(13,4),		@imd_hkfmloptA		nvarchar(4),
@imd_hkfmloptB		nvarchar(4),		@imd_hkfmloptC		nvarchar(4),		@imd_hkfmloptD		nvarchar(4),
@imd_hkfmloptT		nvarchar(4),		@imd_hkfmloptP		nvarchar(4),		@imd_ftyfmloptA	nvarchar(4),	
@imd_ftyfmloptB		nvarchar(4),		@imd_ftyfmloptC	nvarchar(4),		@imd_ftyfmloptD	nvarchar(4),	
@imd_ftyfmloptT	nvarchar(4),		@imd_ftyfmloptP		nvarchar(4),		@imd_basprc		numeric(13,4),
@imd_conftr		int,			@imd_inrlin		numeric(13,4),		@imd_inrwin		numeric(13,4),
@imd_inrhin		numeric(13,4),		@imd_mtrlin		numeric(13,4),		@imd_mtrwin		numeric(13,4),
@imd_mtrhin		numeric(13,4),		@imd_splitr		nvarchar(800),		@imd_lgtno		int,
@imd_frtchg		nvarchar(6),		@imd_dbxlbcst		numeric(13,4),		@imd_dbxlbcstch	nvarchar(6),
@imd_tgtret		numeric(13,4),		@imd_pckitr		nvarchar(800),		@imd_lgtspec		nvarchar(800),
@imd_refresh		nvarchar(2),		@imd_xlsfil		nvarchar(30),		@imd_chkdat		datetime,
@imd_sysmsg		nvarchar(300),		@imd_prctrm		nvarchar(100),		@imd_remark		nvarchar(2000),
@imd_ftytmp		char(1),			@imd_std		char(1),			@imd_tranhk		numeric(13,4),
@imd_tranfty		numeric(9),		@imd_nat		nvarchar(6),		@imd_ccA		numeric(13,4),
@imd_ccB		numeric(13,4),		@imd_ccC		numeric(13,4),		@imd_ccD		numeric(13,4),
@imd_cctran		numeric(13,4),		@imd_ccpck		numeric(13,4),		@imd_calftyprc		numeric(13,4),
@imd_negprc		numeric(13,4),		@imd_creusr		nvarchar(30),		@imd_credat		datetime,
@imd_upddat		datetime



 
update IMMMITMDAT
SET
imd_stage = @imd_stage, 	imd_updusr = @imd_updusr,	imd_upddat = getdate() 

where 
imd_cus1no = @imd_cus1no and
imd_cus2no = @imd_cus2no and 
imd_itmno = @imd_itmno and
imd_inrqty = @imd_inrqty and
imd_mtrqty = @imd_mtrqty and
imd_itmseq = @imd_itmseq and 	
imd_recseq = @imd_recseq and
imd_untcde = @imd_untcde

---------------------------------------------------------------------------------------------------------------------------------------------------------------------


DECLARE cur_IMMMITMDAT CURSOR
FOR SELECT
	imd_itmno,		imd_venno,		imd_prdven,
	imd_untcde,		imd_mtrqty,		imd_inrqty,
	imd_itmseq,		imd_recseq,		imd_cus1no,
	imd_cus2no,		imd_itmtyp,		imd_lnecde,
	imd_catlvl4,		imd_aliasItemNo,		imd_engdsc,
	imd_chndsc,		imd_curcde,		imd_mode,
	imd_itmsts,		imd_fcA,		imd_fcB,
	imd_fcC,		imd_fcD,		imd_fctran,
	imd_fcpck,		imd_fcttl,		imd_cft,
	imd_icA,			imd_icB,			imd_icC,
	imd_icD,			imd_ictran,		imd_icpck,
	imd_icttl,		imd_hkfmloptA,		imd_hkfmloptB,
	imd_hkfmloptC,		imd_hkfmloptD,		imd_hkfmloptT,
	imd_hkfmloptP,		imd_ftyfmloptA,		imd_ftyfmloptB,
	imd_ftyfmloptC,		imd_ftyfmloptD,		imd_ftyfmloptT,
	imd_ftyfmloptP,		imd_basprc,		imd_conftr,
	imd_inrlin,		imd_inrwin,		imd_inrhin,
	imd_mtrlin,		imd_mtrwin,		imd_mtrhin,
	imd_splitr,		imd_lgtno,		imd_frtchg,
	imd_dbxlbcst,		imd_dbxlbcstch,		imd_tgtret,
	imd_pckitr,		imd_lgtspec,		imd_stage,
	imd_refresh,		imd_xlsfil,		imd_chkdat,
	imd_sysmsg,		imd_prctrm,		imd_remark,
	imd_ftytmp,		imd_std,		imd_tranhk,
	imd_tranfty,		imd_nat,		imd_ccA,
	imd_ccB,		imd_ccC,		imd_ccD,
	imd_cctran,		imd_ccpck,		imd_calftyprc,
	imd_negprc,		imd_creusr,		imd_updusr,
	imd_credat,		imd_upddat	
FROM IMMMITMDAT
WHERE	
	imd_stage = 'O' or imd_stage = 'I'  or imd_stage = 'R'

OPEN cur_IMMMITMDAT
FETCH NEXT FROM cur_IMMMITMDAT INTO 
	@imd_itmno,		@imd_venno,		@imd_prdven,
	@imd_untcde,		@imd_mtrqty,		@imd_inrqty,
	@imd_itmseq,		@imd_recseq,		@imd_cus1no,
	@imd_cus2no,		@imd_itmtyp,		@imd_lnecde,
	@imd_catlvl4,		@imd_aliasItemNo,	@imd_engdsc,
	@imd_chndsc,		@imd_curcde,		@imd_mode,
	@imd_itmsts,		@imd_fcA,		@imd_fcB,
	@imd_fcC,		@imd_fcD,		@imd_fctran,
	@imd_fcpck,		@imd_fcttl,		@imd_cft,
	@imd_icA,		@imd_icB,		@imd_icC,
	@imd_icD,		@imd_ictran,		@imd_icpck,
	@imd_icttl,		@imd_hkfmloptA,	@imd_hkfmloptB,
	@imd_hkfmloptC,	@imd_hkfmloptD,	@imd_hkfmloptT,
	@imd_hkfmloptP,	@imd_ftyfmloptA,	@imd_ftyfmloptB,
	@imd_ftyfmloptC,	@imd_ftyfmloptD,	@imd_ftyfmloptT,
	@imd_ftyfmloptP,	@imd_basprc,		@imd_conftr,
	@imd_inrlin,		@imd_inrwin,		@imd_inrhin,
	@imd_mtrlin,		@imd_mtrwin,		@imd_mtrhin,
	@imd_splitr,		@imd_lgtno,		@imd_frtchg,
	@imd_dbxlbcst,		@imd_dbxlbcstch,	@imd_tgtret,
	@imd_pckitr,		@imd_lgtspec,		@imd_stage,
	@imd_refresh,		@imd_xlsfil,		@imd_chkdat,
	@imd_sysmsg,		@imd_prctrm,		@imd_remark,
	@imd_ftytmp,		@imd_std,		@imd_tranhk,
	@imd_tranfty,		@imd_nat,		@imd_ccA,
	@imd_ccB,		@imd_ccC,		@imd_ccD,
	@imd_cctran,		@imd_ccpck,		@imd_calftyprc,
	@imd_negprc,		@imd_creusr,		@imd_updusr,
	@imd_credat,		@imd_upddat	

WHILE @@fetch_status = 0
BEGIN		


	insert into IMMMITMDATH
	(	
		imd_itmno,		imd_venno,		imd_prdven,
		imd_untcde,		imd_mtrqty,		imd_inrqty,
		imd_itmseq,		imd_recseq,		imd_cus1no,
		imd_cus2no,		imd_itmtyp,		imd_lnecde,
		imd_catlvl4,		imd_aliasItemNo,		imd_engdsc,
		imd_chndsc,		imd_curcde,		imd_mode,
		imd_itmsts,		imd_fcA,		imd_fcB,
		imd_fcC,		imd_fcD,		imd_fctran,
		imd_fcpck,		imd_fcttl,		imd_cft,
		imd_icA,			imd_icB,			imd_icC,
		imd_icD,			imd_ictran,		imd_icpck,
		imd_icttl,		imd_hkfmloptA,		imd_hkfmloptB,
		imd_hkfmloptC,		imd_hkfmloptD,		imd_hkfmloptT,
		imd_hkfmloptP,		imd_ftyfmloptA,		imd_ftyfmloptB,
		imd_ftyfmloptC,		imd_ftyfmloptD,		imd_ftyfmloptT,
		imd_ftyfmloptP,		imd_basprc,		imd_conftr,
		imd_inrlin,		imd_inrwin,		imd_inrhin,
		imd_mtrlin,		imd_mtrwin,		imd_mtrhin,
		imd_splitr,		imd_lgtno,		imd_frtchg,
		imd_dbxlbcst,		imd_dbxlbcstch,		imd_tgtret,
		imd_pckitr,		imd_lgtspec,		imd_stage,
		imd_refresh,		imd_xlsfil,		imd_chkdat,
		imd_sysmsg,		imd_prctrm,		imd_remark,
		imd_ftytmp,		imd_std,		imd_tranhk,
		imd_tranfty,		imd_nat,		imd_ccA,
		imd_ccB,		imd_ccC,		imd_ccD,
		imd_cctran,		imd_ccpck,		imd_calftyprc,
		imd_negprc,		imd_creusr,		imd_updusr,
		imd_credat,		imd_upddat	
	)
	values
	(		
		@imd_itmno,		@imd_venno,		@imd_prdven,
		@imd_untcde,		@imd_mtrqty,		@imd_inrqty,
		@imd_itmseq,		@imd_recseq,		@imd_cus1no,
		@imd_cus2no,		@imd_itmtyp,		@imd_lnecde,
		@imd_catlvl4,		@imd_aliasItemNo,	@imd_engdsc,
		@imd_chndsc,		@imd_curcde,		@imd_mode,
		@imd_itmsts,		@imd_fcA,		@imd_fcB,
		@imd_fcC,		@imd_fcD,		@imd_fctran,
		@imd_fcpck,		@imd_fcttl,		@imd_cft,
		@imd_icA,		@imd_icB,		@imd_icC,
		@imd_icD,		@imd_ictran,		@imd_icpck,
		@imd_icttl,		@imd_hkfmloptA,	@imd_hkfmloptB,
		@imd_hkfmloptC,	@imd_hkfmloptD,	@imd_hkfmloptT,
		@imd_hkfmloptP,	@imd_ftyfmloptA,	@imd_ftyfmloptB,
		@imd_ftyfmloptC,	@imd_ftyfmloptD,	@imd_ftyfmloptT,
		@imd_ftyfmloptP,	@imd_basprc,		@imd_conftr,
		@imd_inrlin,		@imd_inrwin,		@imd_inrhin,
		@imd_mtrlin,		@imd_mtrwin,		@imd_mtrhin,
		@imd_splitr,		@imd_lgtno,		@imd_frtchg,
		@imd_dbxlbcst,		@imd_dbxlbcstch,	@imd_tgtret,
		@imd_pckitr,		@imd_lgtspec,		@imd_stage,
		@imd_refresh,		@imd_xlsfil,		@imd_chkdat,
		@imd_sysmsg,		@imd_prctrm,		@imd_remark,
		@imd_ftytmp,		@imd_std,		@imd_tranhk,
		@imd_tranfty,		@imd_nat,		@imd_ccA,
		@imd_ccB,		@imd_ccC,		@imd_ccD,
		@imd_cctran,		@imd_ccpck,		@imd_calftyprc,
		@imd_negprc,		@imd_creusr,		@imd_updusr,
		@imd_credat,		@imd_upddat	
	)

	
	Delete from IMMMITMDAT 
	Where	
		imd_cus1no = @imd_cus1no and
		imd_cus2no = @imd_cus2no and 
		imd_itmno = @imd_itmno and
		imd_inrqty = @imd_inrqty and
		imd_mtrqty = @imd_mtrqty and
		imd_itmseq = @imd_itmseq and 	
		imd_recseq = @imd_recseq and
		imd_untcde = @imd_untcde and
		(imd_stage = 'O' or imd_stage = 'I'  or imd_stage = 'R') 



FETCH NEXT FROM cur_IMMMITMDAT INTO 
	@imd_itmno,		@imd_venno,		@imd_prdven,
	@imd_untcde,		@imd_mtrqty,		@imd_inrqty,
	@imd_itmseq,		@imd_recseq,		@imd_cus1no,
	@imd_cus2no,		@imd_itmtyp,		@imd_lnecde,
	@imd_catlvl4,		@imd_aliasItemNo,	@imd_engdsc,
	@imd_chndsc,		@imd_curcde,		@imd_mode,
	@imd_itmsts,		@imd_fcA,		@imd_fcB,
	@imd_fcC,		@imd_fcD,		@imd_fctran,
	@imd_fcpck,		@imd_fcttl,		@imd_cft,
	@imd_icA,		@imd_icB,		@imd_icC,
	@imd_icD,		@imd_ictran,		@imd_icpck,
	@imd_icttl,		@imd_hkfmloptA,	@imd_hkfmloptB,
	@imd_hkfmloptC,	@imd_hkfmloptD,	@imd_hkfmloptT,
	@imd_hkfmloptP,	@imd_ftyfmloptA,	@imd_ftyfmloptB,
	@imd_ftyfmloptC,	@imd_ftyfmloptD,	@imd_ftyfmloptT,
	@imd_ftyfmloptP,	@imd_basprc,		@imd_conftr,
	@imd_inrlin,		@imd_inrwin,		@imd_inrhin,
	@imd_mtrlin,		@imd_mtrwin,		@imd_mtrhin,
	@imd_splitr,		@imd_lgtno,		@imd_frtchg,
	@imd_dbxlbcst,		@imd_dbxlbcstch,	@imd_tgtret,
	@imd_pckitr,		@imd_lgtspec,		@imd_stage,
	@imd_refresh,		@imd_xlsfil,		@imd_chkdat,
	@imd_sysmsg,		@imd_prctrm,		@imd_remark,
	@imd_ftytmp,		@imd_std,		@imd_tranhk,
	@imd_tranfty,		@imd_nat,		@imd_ccA,
	@imd_ccB,		@imd_ccC,		@imd_ccD,
	@imd_cctran,		@imd_ccpck,		@imd_calftyprc,
	@imd_negprc,		@imd_creusr,		@imd_updusr,
	@imd_credat,		@imd_upddat	
END -- WHILE @@fetch_status = 0
CLOSE cur_IMMMITMDAT
DEALLOCATE cur_IMMMITMDAT







GO
GRANT EXECUTE ON [dbo].[sp_update_IMMMITMDAT] TO [ERPUSER] AS [dbo]
GO
