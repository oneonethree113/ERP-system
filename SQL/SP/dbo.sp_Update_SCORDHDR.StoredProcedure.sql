/****** Object:  StoredProcedure [dbo].[sp_Update_SCORDHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_SCORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_SCORDHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_Update_SCORDHDR]
                                                                                                                                                                                                                                                                 

@soh_cocde	nvarchar(6), 	@soh_ordno	nvarchar(20),	@soh_verno	int,	       	
@soh_canflg	nvarchar(1),	@soh_smpsc	nvarchar(1),	@soh_clsout	nvarchar(1),	
@soh_rplmnt	nvarchar(1),	@soh_issdat	datetime,	@soh_rvsdat	datetime,	
@soh_ordsts	nvarchar(20),	@soh_cus1no	nvarchar(6),	@soh_cus2no	nvarchar(6),	
@soh_biladr	nvarchar(200),	@soh_bilstt	nvarchar(20),	@soh_bilcty	nvarchar(20),	
@soh_bilzip	nvarchar(20),	@soh_shpadr	nvarchar(200),	@soh_shpstt	nvarchar(20),	
@soh_shpcty	nvarchar(20),	@soh_shpzip	nvarchar(20),	@soh_cttper	nvarchar(50),	
@soh_salrep	nvarchar(30),	@soh_saldiv	nvarchar(30),	@soh_saltem	nvarchar(30),
@soh_agt	nvarchar(20),	@soh_prctrm	nvarchar(6),	@soh_paytrm	nvarchar(6),	
@soh_sfigtrm	nvarchar(40),	@soh_sprdtrm	nvarchar(20),	@soh_resppo	nvarchar(20),	
@soh_ttlvol	numeric(13,4),	@soh_cft	numeric(13,4),	@soh_curcde	nvarchar(6),	
@soh_ttlctn	int,		@soh_ttlamt	numeric(13,4), 	@soh_Netamt	numeric(13,4),	
@soh_rmk	nvarchar(400),	@soh_cuspo	nvarchar(20),	@soh_cpodat	datetime,	
@soh_shpstr	datetime,	@soh_shpend	datetime,	@soh_candat	datetime,	
@soh_lbldue	datetime,	@soh_lblven	nvarchar(6),	@soh_zshpcusno	nvarchar(10),	
@soh_email	nvarchar(255),	@soh_moqsc	varchar(20),	@soh_curexrat	numeric(16,11),	
@soh_curexeffdat  datetime,	@soh_cusctn	int,		@soh_dest	nvarchar(50),	
@soh_prctrmflg	char(1),
@soh_paytrmflg	char(1),
@soh_rplflg	char(1),
@soh_clsflg	char(1),
@soh_scrmk	nvarchar(1600),
@creusr		nvarchar(30)


AS
BEGIN

update	SCORDHDR
set	soh_smpsc = @soh_smpsc,
	soh_clsout = @soh_clsout,
	soh_rplmnt = @soh_rplmnt,
	soh_canflg = @soh_canflg,
	--soh_issdat = @soh_issdat,
	--soh_rvsdat = GETDATE(),
	soh_ordsts = @soh_ordsts,
	soh_cus1no = @soh_cus1no,
	soh_cus2no = @soh_cus2no,
	soh_biladr = @soh_biladr,
	soh_bilstt = @soh_bilstt,
	soh_bilcty = @soh_bilcty,
	soh_bilzip = @soh_bilzip,
	soh_shpadr = @soh_shpadr,
	soh_shpstt = @soh_shpstt,
	soh_shpcty = @soh_shpcty,
	soh_shpzip = @soh_shpzip,
	soh_cttper = @soh_cttper,
	--soh_salrep = @soh_salrep,
	soh_srname = @soh_salrep,
	soh_saldiv = @soh_saldiv,
	soh_saltem = @soh_saltem,
	soh_agt = @soh_agt,
	soh_prctrm = @soh_prctrm,
	soh_paytrm = @soh_paytrm,
	soh_sfigtrm = @soh_sfigtrm,
	soh_sprdtrm = @soh_sprdtrm,
	soh_resppo = @soh_resppo,
	soh_ttlvol = @soh_ttlvol,
	soh_cft = @soh_cft,
	soh_curcde = @soh_curcde,
	soh_ttlctn = @soh_ttlctn,
	soh_ttlamt = @soh_ttlamt,
	soh_netamt = @soh_netamt,
	soh_rmk = @soh_rmk,
	soh_cuspo = rtrim(ltrim(@soh_cuspo)),
	soh_cpodat = @soh_cpodat,
	soh_shpstr = @soh_shpstr,
	soh_shpend = @soh_shpend,
	soh_candat = @soh_candat,
	soh_lbldue = @soh_lbldue,
	soh_lblven = @soh_lblven,
	soh_zshpcusno = @soh_zshpcusno,
	soh_email = @soh_email,
	soh_moqsc = @soh_moqsc ,
	soh_curexrat = @soh_curexrat ,
	soh_curexeffdat  = @soh_curexeffdat,
	soh_cusctn = @soh_cusctn,
	soh_dest = @soh_dest,
	soh_prctrmflg = @soh_prctrmflg,
	soh_paytrmflg = @soh_paytrmflg,
	soh_rplflg = @soh_rplflg,
	soh_clsflg = @soh_clsflg,
	soh_updusr = @creusr,
	soh_upddat = getdate(),
	soh_scrmk = @soh_scrmk,
	soh_scupdusr = @creusr
where	soh_cocde = @soh_cocde and
	soh_ordno = @soh_ordno                                                                                    

END

GO
GRANT EXECUTE ON [dbo].[sp_Update_SCORDHDR] TO [ERPUSER] AS [dbo]
GO
