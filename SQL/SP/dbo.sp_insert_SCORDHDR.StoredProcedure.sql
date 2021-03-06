/****** Object:  StoredProcedure [dbo].[sp_insert_SCORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SCORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SCORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_insert_SCORDHDR]

@soh_cocde	nvarchar(6), 	@soh_ordno	nvarchar(20),	@soh_canflg	nvarchar(1),	
@soh_smpsc	nvarchar(1),	@soh_clsout	nvarchar(1),	@soh_rplmnt	nvarchar(1),
@soh_issdat	datetime,	@soh_rvsdat	datetime,	@soh_ordsts	nvarchar(20),
@soh_cus1no	nvarchar(6),	@soh_cus2no	nvarchar(6),	@soh_biladr	nvarchar(200),
@soh_bilstt	nvarchar(20),	@soh_bilcty	nvarchar(20),	@soh_bilzip	nvarchar(20),
@soh_shpadr	nvarchar(200),	@soh_shpstt	nvarchar(20),	@soh_shpcty	nvarchar(20),	
@soh_shpzip	nvarchar(20),	@soh_cttper	nvarchar(50),	@soh_salrep	nvarchar(30),
@soh_saldiv	nvarchar(30),	@soh_saltem	nvarchar(30),	@soh_agt	nvarchar(20),
@soh_prctrm	nvarchar(6),	@soh_paytrm	nvarchar(6),	@soh_sfigtrm	nvarchar(40),
@soh_sprdtrm	nvarchar(20),	@soh_resppo	nvarchar(20),	@soh_ttlvol	numeric(13,4),
@soh_cft	numeric(13, 4),	@soh_curcde	nvarchar(6),	@soh_ttlctn	int,
@soh_ttlamt	numeric(13, 4),	@soh_netamt	numeric(13,4),	@soh_rmk	nvarchar(400),
@soh_cuspo	nvarchar(20),	@soh_cpodat	datetime,	@soh_shpstr	datetime,
@soh_shpend	datetime,	@soh_candat	datetime,	@soh_lbldue	datetime,
@soh_lblven	nvarchar(6),	@soh_zshpcusno	nvarchar(10),	@soh_email	nvarchar(255),
@soh_moqsc	varchar(20), 	@soh_curexrat	numeric(16,11),	@soh_curexeffdat datetime,
@soh_cusctn	nvarchar(10),	@soh_dest	nvarchar(50),
@soh_prctrmflg	char(1),
@soh_paytrmflg	char(1),
@soh_rplflg	char(1),
@soh_clsflg	char(1),
@soh_lastprctrm	nvarchar(6),
@soh_lastpaytrm	nvarchar(6),
@soh_scrmk	nvarchar(1600),
@soh_updusr	nvarchar(30)
		

 
AS
BEGIN

if @soh_cusctn = ''
begin
	set @soh_cusctn = 0
end

set @soh_cuspo = ltrim(rtrim(@soh_cuspo))

insert into SCORDHDR 
(	soh_cocde,		soh_ordno,		soh_verno,
	soh_canflg,		soh_smpsc,		soh_clsout,
	soh_rplmnt, 		soh_issdat,		soh_rvsdat,
	soh_ordsts,		soh_cus1no,		soh_cus2no,
	soh_biladr,		soh_bilstt,		soh_bilcty,
	soh_bilzip,		soh_zshpcusno,		soh_shpadr,
	soh_shpstt,		soh_shpcty,		soh_shpzip,
	soh_cttper,		soh_email,		soh_salrep,
	soh_srname,		soh_saldiv,		soh_saltem,
	soh_agt,		soh_prctrm,		soh_paytrm,
	soh_sfigtrm,		soh_sprdtrm,		soh_resppo,
	soh_ttlvol,		soh_cft,		soh_curcde,
	soh_ttlctn,		soh_ttlamt,		soh_netamt,
	soh_rmk,		soh_cuspo,		soh_cpodat,
	soh_shpstr,		soh_shpend,		soh_candat,
	soh_lbldue,		soh_lblven,		soh_moqsc,
	soh_curexrat ,		soh_curexeffdat,	soh_cusctn,
	soh_dest,		
	soh_prctrmflg,
	soh_paytrmflg,
	soh_rplflg,
	soh_clsflg,
	soh_lastprctrm,
	soh_lastpaytrm,
	soh_scrmk,
	soh_creusr,		soh_updusr,
	soh_credat,		soh_upddat, soh_scupdusr
)
values
(	@soh_cocde,		@soh_ordno,		1,
	@soh_canflg,		@soh_smpsc,		@soh_clsout,
	@soh_rplmnt,		GETDATE(),		GETDATE(),
	@soh_ordsts,		@soh_cus1no,		@soh_cus2no,
	@soh_biladr,		@soh_bilstt,		@soh_bilcty,
	@soh_bilzip,		@soh_zshpcusno,		@soh_shpadr,
	@soh_shpstt,		@soh_shpcty,		@soh_shpzip,
	@soh_cttper,		@soh_email,		'',
	@soh_salrep,		@soh_saldiv,		@soh_saltem,
	@soh_agt,		@soh_prctrm,		@soh_paytrm,
	@soh_sfigtrm,		@soh_sprdtrm,		@soh_resppo,
	@soh_ttlvol,		@soh_cft,		@soh_curcde,
	@soh_ttlctn,		@soh_ttlamt,		@soh_netamt,
	@soh_rmk,		@soh_cuspo,		@soh_cpodat,
	@soh_shpstr,		@soh_shpend,		@soh_candat,
	@soh_lbldue,		@soh_lblven,		@soh_moqsc,
	@soh_curexrat ,		@soh_curexeffdat,	@soh_cusctn,
	@soh_dest,		
	@soh_prctrmflg,
	@soh_paytrmflg,
	@soh_rplflg,
	@soh_clsflg,
	@soh_lastprctrm,
	@soh_lastpaytrm,
	@soh_scrmk,
	@soh_updusr,		@soh_updusr,
	GETDATE(),		GETDATE(), @soh_updusr
)
END

GO
GRANT EXECUTE ON [dbo].[sp_insert_SCORDHDR] TO [ERPUSER] AS [dbo]
GO
