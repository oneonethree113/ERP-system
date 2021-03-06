/****** Object:  StoredProcedure [dbo].[sp_insert_IMMRKUPDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMMRKUPDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMMRKUPDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE PROCEDURE [dbo].[sp_insert_IMMRKUPDTL] 

@imd_cocde nvarchar(12),
@imd_itmno nvarchar(40),
@imd_typ nvarchar(8),
@imd_ventyp nvarchar(8),
@imd_venno nvarchar(12),
@imd_prdven nvarchar(12),
@imd_pckseq int,
@imd_untcde nvarchar(12),
@imd_inrqty int,
@imd_mtrqty int,
@imd_cus1no nvarchar(20),
@imd_cus2no nvarchar(20),
@imd_catlvl4 nvarchar(40),
@imd_cusdsc nvarchar(200),
@imd_curcde nvarchar(12),
@imd_fcA numeric(13,4),
@imd_fcB numeric(13,4),
@imd_fcC numeric(13,4),
@imd_fcD numeric(13,4),
@imd_fctran numeric(13,4),
@imd_fcpck numeric(13,4),
@imd_ccA numeric(13,4),
@imd_ccB numeric(13,4),
@imd_ccC numeric(13,4),
@imd_ccD numeric(13,4),
@imd_cctran numeric(13,4),
@imd_ccpck numeric(13,4),
@imd_icA numeric(13,4),
@imd_icB numeric(13,4),
@imd_icC numeric(13,4),
@imd_icD numeric(13,4),
@imd_ictran numeric(13,4),
@imd_icpck numeric(13,4),
@imd_fm1A nvarchar(10),
@imd_fm1B nvarchar(10),
@imd_fm1C nvarchar(10),
@imd_fm1D nvarchar(10),
@imd_fm1tran nvarchar(10),
@imd_fm1pck nvarchar(10),
@imd_fm2A nvarchar(10),
@imd_fm2B nvarchar(10),
@imd_fm2C nvarchar(10),
@imd_fm2D nvarchar(10),
@imd_fm2tran nvarchar(10),
@imd_fm2pck nvarchar(10),
@imd_fcttl numeric(13,4),
@imd_icttl numeric(13,4),
@imd_calftyprc numeric(13,4),
@imd_negprc numeric(13,4),
@imd_fmlopt nvarchar(10),
@imd_bcurcde nvarchar(12),
@imd_basprc numeric(13,4),
@imd_tranhk numeric(13,4),
@imd_tranfty numeric(13,4),
-- Added by Mark Lau 20090113
@imd_conftr int,
-- Added by Mark Lau 20090423
@imd_prctrm nvarchar(20),
@gsuser nvarchar(100)

--@imd_lgtno int
--@imd_frtchg nvarchar(12)
--@imd_dbxlbcst numeric(13,4)
--@imd_dbxlbcstch nvarchar(12)
--@imd_tgtbas numeric(13,4)
--@imd_tgtret numeric(13,4)
--@imd_pckitr nvarchar(1600)
--@imd_lgtspec nvarchar(1600)
--@imd_creusr nvarchar(100)
--@imd_updusr nvarchar(100)
--@imd_credat datetime(8)
--@imd_upddat datetime(8)


AS

declare
@imd_creusr nvarchar(100),
@imd_updusr nvarchar(100)

set @imd_creusr =  @gsuser
set @imd_updusr =  @gsuser

BEGIN
Insert into IMMRKUPDTL    
(
	imd_cocde,
	imd_itmno,
	imd_typ,
	imd_ventyp,
	imd_venno,
	imd_prdven,
	imd_pckseq,
	imd_untcde,
	imd_inrqty,
	imd_mtrqty,
	imd_cus1no,
	imd_cus2no,
	imd_catlvl4,
	imd_cusdsc,
	imd_curcde,
	imd_fcA,
	imd_fcB,
	imd_fcC,
	imd_fcD,
	imd_fctran,
	imd_fcpck,
	imd_ccA,
	imd_ccB,
	imd_ccC,
	imd_ccD,
	imd_cctran,
	imd_ccpck,
	imd_icA,
	imd_icB,
	imd_icC,
	imd_icD,
	imd_ictran,
	imd_icpck,
	imd_fm1A,
	imd_fm1B,
	imd_fm1C,
	imd_fm1D,
	imd_fm1tran,
	imd_fm1pck,
	imd_fm2A,
	imd_fm2B,
	imd_fm2C,
	imd_fm2D,
	imd_fm2tran,
	imd_fm2pck,
	imd_fcttl,
	imd_icttl,
	imd_calftyprc,
	imd_negprc,
	imd_fmlopt,
	imd_bcurcde,
	imd_basprc,
	imd_tranhk,
	imd_tranfty,
	-- Added by Mark Lau 20090113
	imd_conftr,
	-- Added by Mark Lau 20090423
	imd_prctrm,
	imd_creusr,    
	imd_updusr,    
	imd_credat,    
	imd_upddat,
	-- Added by Mark Lau 20090423
	imd_lgtno,
	imd_frtchg,
	imd_dbxlbcst,
	imd_dbxlbcstch,
	imd_tgtbas,
	imd_tgtret,
	imd_pckitr,
	imd_lgtspec
)    
values    
(    
	' ',    
	@imd_itmno,
	@imd_typ,
	@imd_ventyp,
	@imd_venno,
	@imd_prdven,
	@imd_pckseq,
	@imd_untcde,
	@imd_inrqty,
	@imd_mtrqty,
	@imd_cus1no,
	@imd_cus2no,
	@imd_catlvl4,
	@imd_cusdsc,
	@imd_curcde,
	@imd_fcA,
	@imd_fcB,
	@imd_fcC,
	@imd_fcD,
	@imd_fctran,
	@imd_fcpck,
	@imd_ccA,
	@imd_ccB,
	@imd_ccC,
	@imd_ccD,
	@imd_cctran,
	@imd_ccpck,
	@imd_icA,
	@imd_icB,
	@imd_icC,
	@imd_icD,
	@imd_ictran,
	@imd_icpck,
	@imd_fm1A,
	@imd_fm1B,
	@imd_fm1C,
	@imd_fm1D,
	@imd_fm1tran,
	@imd_fm1pck,
	@imd_fm2A,
	@imd_fm2B,
	@imd_fm2C,
	@imd_fm2D,
	@imd_fm2tran,
	@imd_fm2pck,
	@imd_fcttl,
	@imd_icttl,
	@imd_calftyprc,
	@imd_negprc,
	@imd_fmlopt,
	@imd_bcurcde,
	@imd_basprc,
	@imd_tranhk,
	@imd_tranfty,
	-- Added by Mark Lau 20090113
	@imd_conftr,
	-- Added by Mark Lau 20090423
	@imd_prctrm,
	@imd_creusr,    
	@imd_updusr,    
	getdate(),    
	getdate(),
	-- Added by Mark Lau 20090423
	0,
	'',
	0,
	'',
	0,
	0,
	'',
	''
)    

END








GO
GRANT EXECUTE ON [dbo].[sp_insert_IMMRKUPDTL] TO [ERPUSER] AS [dbo]
GO
