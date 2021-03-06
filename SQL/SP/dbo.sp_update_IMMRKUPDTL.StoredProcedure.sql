/****** Object:  StoredProcedure [dbo].[sp_update_IMMRKUPDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMMRKUPDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMMRKUPDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE procedure [dbo].[sp_update_IMMRKUPDTL]    

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
@imd_negprc numeric (13,4),
@imd_fmlopt nvarchar(10),
@imd_bcurcde nvarchar(12),
@imd_tranhk numeric(13,4),
@imd_tranfty numeric(13,4),
@imd_basprc numeric(13,4),
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
 
BEGIN

	Update IMMRKUPDTL    
	SET     
		imd_fcA = @imd_fcA,
		imd_fcB	= @imd_fcB,
		imd_fcC = @imd_fcC,
		imd_fcD = @imd_fcD,
		imd_fctran = @imd_fctran,
		imd_fcpck = @imd_fcpck,
		imd_ccA = @imd_ccA,
		imd_ccB = @imd_ccB,
		imd_ccC = @imd_ccC,
		imd_ccD = @imd_ccD,
		imd_cctran = @imd_cctran,
		imd_ccpck = @imd_ccpck,
		imd_icA = @imd_icA,
		imd_icB = @imd_icB,
		imd_icC = @imd_icC,
		imd_icD = @imd_icD,
		imd_ictran = @imd_ictran,
		imd_icpck = @imd_icpck,
		imd_fm1A = @imd_fm1A,
		imd_fm1B = @imd_fm1B,
		imd_fm1C = @imd_fm1C,
		imd_fm1D = @imd_fm1D,
		imd_fm1tran = @imd_fm1tran,
		imd_fm1pck = @imd_fm1pck,
		imd_fm2A = @imd_fm2A,
		imd_fm2B = @imd_fm2B,
		imd_fm2C = @imd_fm2C,
		imd_fm2D = @imd_fm2D,
		imd_fm2tran = @imd_fm2tran,
		imd_fm2pck = @imd_fm2pck,
		imd_fcttl = @imd_fcttl, 
		imd_icttl = @imd_icttl,
		imd_fmlopt = @imd_fmlopt,
		imd_basprc = @imd_basprc, 
		imd_calftyprc = @imd_calftyprc,
		imd_negprc = @imd_negprc,
		imd_tranhk = @imd_tranhk,
		imd_tranfty = @imd_tranfty,
		imd_updusr = @gsuser,    
		imd_upddat = Getdate()  
	Where      
		imd_itmno = @imd_itmno and    
		imd_typ = @imd_typ and    
		imd_ventyp = @imd_ventyp and    
		imd_venno = @imd_venno and    
		ltrim(rtrim(imd_prdven)) = ltrim(rtrim(@imd_prdven)) and    
		imd_pckseq = @imd_pckseq and    
		imd_cus1no = @imd_cus1no and
		imd_cus2no = @imd_cus2no

END





GO
GRANT EXECUTE ON [dbo].[sp_update_IMMRKUPDTL] TO [ERPUSER] AS [dbo]
GO
