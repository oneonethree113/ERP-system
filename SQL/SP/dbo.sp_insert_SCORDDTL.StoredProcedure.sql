/****** Object:  StoredProcedure [dbo].[sp_insert_SCORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SCORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SCORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_insert_SCORDDTL]
                                                                                                                                                                                                                                                                 
@sod_cocde	nvarchar(6),
@sod_ordno	nvarchar(20),
@sod_itmno	nvarchar(20),
@sod_colcde	nvarchar(30),
@sod_pckunt	nvarchar(6),
@sod_inrctn	int,
@sod_mtrctn	int,
@sod_cft	numeric(11,4),
@sod_cbm	numeric(11,4),
@sod_hkprctrm	nvarchar(10),
@sod_ftyprctrm	nvarchar(10),
@sod_trantrm	nvarchar(10),
@sod_conftr	numeric(9),
@sod_prcgrp	nvarchar(30),
@sod_cus1no	nvarchar(6),
@sod_cus2no	nvarchar(6),
@sod_effdat	datetime,
@sod_expdat	datetime,
@sod_qutdat	datetime,
@sod_imqutdat	datetime,
@sod_dv		nvarchar(6),
@sod_venno	varchar(6),
@sod_cusven	varchar(6),
@sod_tradeven	varchar(6),
@sod_examven	varchar(6),
--@sod_orgvenno 	nvarchar(6),
@sod_fcurcde	nvarchar(6),
@sod_ftycst	numeric(13,4),
@sod_bomcst	numeric(13,4),
@sod_ftyprc	numeric(13,4),
@sod_ftyunt	nvarchar(6),
@sod_venitm	nvarchar(20),
@sod_dvfcurcde	nvarchar(6),
@sod_dvftycst	numeric(13,4),
@sod_dvbomcst	numeric(13,4),
@sod_dvftyprc	numeric(13,4),
@sod_dvftyunt	nvarchar(6),
@sod_dvitmcst 	numeric(13,4),
@sod_itmcstcur	nvarchar(6),
@sod_itmsts	nvarchar(4),
@sod_itmtyp	nvarchar(4),
@sod_itmdsc	nvarchar(800),
@sod_pckseq	int,
@sod_pckitr	nvarchar(300),
@sod_inrdin	numeric(11,4),
@sod_inrwin	numeric(11,4),
@sod_inrhin	numeric(11,4),	
@sod_mtrdin	numeric(11,4),
@sod_mtrwin	numeric(11,4),
@sod_mtrhin	numeric(11,4),
@sod_inrdcm	numeric(11,4),
@sod_inrwcm	numeric(11,4),
@sod_inrhcm	numeric(11,4),
@sod_mtrdcm	numeric(11,4),
@sod_mtrwcm	numeric(11,4),
@sod_mtrhcm 	numeric(11,4),
@sod_ordqty	int,
@sod_oneprc	nvarchar(1),
@sod_apprve	nvarchar(1),
@sod_curcde	nvarchar(6),
@sod_itmprc	numeric(13,4),
@sod_basprc	numeric(13,4),
@sod_untprc	numeric(13,4),
@sod_pcprc	numeric(13,4),
@sod_netuntprc	numeric(13,4),
@sod_selprc	numeric(13,4),
@sod_alsitmno	varchar(20),
@sod_alscolcde	varchar(30),
@sod_coldsc	nvarchar(300),
@sod_cuscol	nvarchar(30),
@sod_cusitm	nvarchar(20),
@sod_seccusitm	varchar(20),
@sod_cusstyno	nvarchar(30),
@sod_cussku	nvarchar(20),
@sod_custum	nvarchar(6),
@sod_resppo	nvarchar(20),
@sod_cuspo	nvarchar(20),
@sod_cussub	varchar(10),
@sod_season	nvarchar(30),
@sod_year	nvarchar(4),
@sod_hrmcde	nvarchar(12),
@sod_typcode	nvarchar(1),	
@sod_code1	nvarchar(25),
@sod_code2	nvarchar(25),
@sod_code3	nvarchar(25),
@sod_cususdcur	nvarchar(6),
@sod_cususd	numeric(13,4),
@sod_cuscadcur	nvarchar(6),
@sod_cuscad	numeric(13,4),
@sod_dtyrat	numeric(6,3),
@sod_dept	nvarchar(20),
@sod_venmoqchg	char(1),
@sod_cusmoqchg	char(1),
@sod_moqchg	numeric(6,3),
@sod_orgmoqchg	numeric(6,3),
@sod_tirtyp	char(1),
@sod_moq	int,
@sod_moqunttyp	nvarchar(30),
@sod_moa	numeric(11,4),
@sod_shpstr	datetime,
@sod_shpend	datetime,
@sod_candat	datetime,
@sod_ctnstr	int ,
@sod_ctnend	int ,
@sod_ttlctn	int,
@sod_posstr	datetime,
@sod_posend	datetime,
@sod_poscan	datetime,
@sod_rmk	nvarchar(600),
@sod_pormk	nvarchar(600),
@sod_qutno	nvarchar(20),
@sod_refdat	datetime,
@sod_pjobno	varchar(20),
@sod_updpo	nvarchar(1),
@sod_chgfty	nvarchar(1),
@sod_contopc	nvarchar(1),
@sod_ztnvbeln	nvarchar(10),
@sod_ztnposnr	nvarchar(6),
@sod_zorvbeln	nvarchar(10),
@sod_zorposnr	nvarchar(6),
@sod_toordno	nvarchar(30),
@sod_toordseq	nvarchar(10),
@sod_assitmcount int, 
@sod_discnt	numeric(6,3),
@sod_subcde	nvarchar(10),
@sod_clmno	nvarchar(30),
@cis_cusno 	nvarchar(6), --@cusno nvarchar(6)
@cis_seccus	nvarchar(6), --@seccus nvarchar(6)
@status		nvarchar(6),
@closeout	nvarchar(1),
@replace	nvarchar(1),
@sod_effcpo	nvarchar(1),
@markup	numeric(13,4),
@mumin	numeric(13,4),
@mrkprc	numeric(13,4),
@muminprc	numeric(13,4),
@commsn	numeric(13,4),
@itmcom	numeric(13,4),
@pckcst	numeric(13,4),
@stdprc	numeric(13,4),
@sod_name_f1 nvarchar(150),
@sod_dsc_f1 nvarchar(150),
@sod_name_f2 nvarchar(150),
@sod_dsc_f2 nvarchar(150),
@sod_name_f3 nvarchar(150),
@sod_dsc_f3 nvarchar(150),

@sod_ftycst_org		numeric(13,4),
@sod_bomcst_org		numeric(13,4),
@sod_ftyprc_org		numeric(13,4),
@sod_dvftycst_org	numeric(13,4),
@sod_dvbomcst_org	numeric(13,4),
@sod_dvftyprc_org	numeric(13,4),

@sod_moqmoaflg char(1),
@sod_onetimeflg char(1),
@sod_belprcflg char(1),
@sod_chgftycstflg char(1),

@sod_chguntprcflg char(1),
@sod_untprc_org numeric(13,4),
@sod_itmchidsc nvarchar(800),
@sod_dtlttlctn int,
@creusr		nvarchar(30) --@sod_updusr nvarchar(30)
		
AS

declare -- SCORDDTL
@sod_ordseq		int,		@sod_invqty		int,		@sod_shpqty		int,
@sod_oldven		nvarchar(6),	@sod_purord		nvarchar(20),	@sod_purseq		int,
@sod_oldpurord		nvarchar(20),	@sod_oldpurseq		int,		@sod_orgvenno		nvarchar(6),
@sod_fmlopt		varchar(5),	@sod_fml		varchar(300),	@sod_mubasprc		numeric(13, 4),
@sod_fcurcde_org	nvarchar(6),	
--@sod_ftycst_org		numeric(13, 4),	@sod_bomcst_org		numeric(13, 4), @sod_ftyprc_org		numeric(13, 4),	
@sod_dvfcurcde_org	nvarchar(6),	
--@sod_dvftycst_org	numeric(13, 4), @sod_dvbomcst_org	numeric(13, 4),	@sod_dvftyprc_org	numeric(13, 4),	
@sod_imqutdat_org	datetime,
@sod_venno_org		nvarchar(6)

declare	-- Misc
@itmventyp	char(1),
@ibi_catlvl3	varchar(20),
@OP		char(1),
@end		int,
@temp		numeric(13,4),
@fml		varchar(300)


set @sod_itmdsc = rtrim(ltrim(@sod_itmdsc))
set @sod_cuscol = rtrim(ltrim(@sod_cuscol))
set @sod_coldsc = rtrim(ltrim(@sod_coldsc))
set @sod_cusitm = rtrim(ltrim(@sod_cusitm))
set @sod_pckitr = rtrim(ltrim(@sod_pckitr))

set @sod_fcurcde_org = @sod_fcurcde

--set @sod_ftycst_org = @sod_ftycst
--set @sod_bomcst_org = @sod_bomcst
--set @sod_ftyprc_org = @sod_ftyprc
set @sod_dvfcurcde_org = @sod_dvfcurcde
--set @sod_dvftycst_org = @sod_dvftycst
--set @sod_dvbomcst_org = @sod_dvbomcst
--set @sod_dvftyprc_org = @sod_dvftyprc

set @sod_imqutdat_org = @sod_imqutdat

set @sod_venno_org = @sod_venno
set @sod_orgvenno = @sod_venno
set @sod_purord = ''
set @sod_purseq = ''
set @sod_oldpurord = ''
set @sod_oldpurseq = ''

-- *** Data for insert CUITMPRCDTL Start *** --
declare @seq_num_cuitmprcdtl as int
declare @cis_credat as datetime set @cis_credat = getdate()
declare @cis_cussna as nvarchar(20)
declare @cis_secsna as nvarchar(20)
declare @soh_verno as int
declare @flg_cuitmprcdtl as char(1)
-- *** Data for insert CUITMPRCDTL End *** --

--- Get Customer Name For Primary and Secondary ---
if @cis_cusno <> ''
	select @cis_cussna = cbi_cussna from CUBASINF where cbi_cusno = @cis_cusno
	
if @cis_seccus <> ''
	select @cis_secsna = cbi_cussna from CUBASINF where cbi_cusno = @cis_seccus

-- Get Item Vendor Type --
select	@itmventyp = isnull(vbi_ventyp,'')
from	IMBASINF (nolock)
	left join VNBASINF (nolock) on
		vbi_venno = ibi_venno
where	ibi_itmno = @sod_itmno

--Get SC version no
select @soh_verno = soh_verno from SCORDHDR where soh_cocde = @sod_cocde and soh_ordno = @sod_ordno

-- Retrive Category Level 3 --
select	@ibi_catlvl3 = isnull(ibi_catlvl3,'')
from	IMBASINF (nolock)
where	(ibi_itmno = @sod_itmno or ibi_alsitmno = @sod_itmno) and
	ibi_itmsts <> 'CLO'

-- Retrive Customer Markup Formula --
set @sod_fml  = ''
set @sod_fmlopt  = ''

select	@sod_fmlopt  = ccm_markup  
from	CUMCAMRK (nolock) 
where	ccm_cusno = @cis_cusno and
	ccm_ventyp = isnull(@itmventyp,'') and
	ccm_cat = isnull(@ibi_catlvl3 ,'')

if ltrim(rtrim(@sod_fmlopt )) = ''
begin 
	select	@sod_fmlopt  = ccm_markup  
	from	CUMCAMRK (nolock)
	where	ccm_cusno = @cis_cusno and
		ccm_ventyp = isnull(@itmventyp,'') and
		ccm_cat = 'STANDARD'
end

-- Retrive Formula --
select	@sod_fml = yfi_fml
from	SYFMLINF (nolock)
where	yfi_fmlopt = @sod_fmlopt

set @fml = @sod_fml
set @sod_mubasprc  =@sod_itmprc

while len(@fml) <> 0
begin
	set @fml = ltrim(@fml)
	set @OP = substring(@fml,1,1)
	set @fml = substring(@fml, 2, len(@fml))
				
	if (charindex('*', @fml) = 0 and charindex('/', @fml) = 0)
	begin
		set @end = len(@fml) + 1
	end
	else if (charindex('*', @fml) = 0) 
  	begin
		set @end = charindex('/', @fml)
	end
	else if (charindex('/', @fml) = 0) 
	begin
		set @end = charindex('*', @fml)
	end
	else
	begin
		if (charindex('*', @fml) < charindex('/', @fml)) 
		begin
			set @end = charindex('*', @fml)
		end
		else
		begin
			set @end = charindex('/', @fml)
		end
	end
	
	set @temp = substring(@fml, 1, @end -1)

	if @OP = '*'
	begin
		set @sod_mubasprc   = @sod_mubasprc  * @temp
	end
	else if @OP = '/' 
	begin
		set @sod_mubasprc   = @sod_mubasprc  / @temp
	end
				
	set @fml = substring(@fml, @end, len(@fml))
end

select	@sod_ordseq = isnull(max(sod_ordseq),0) + 1
from	SCORDDTL (nolock)
where	sod_cocde = @sod_cocde and
	sod_ordno = @sod_ordno

BEGIN

insert into SCORDDTL
(	sod_cocde,		sod_ordno,		sod_ordseq,
	sod_updpo,		sod_chgfty,		sod_itmno,
	sod_itmsts,		sod_itmtyp,		sod_itmdsc,
	sod_colcde,		sod_cuscol,		sod_coldsc,
	sod_pckseq,		sod_pckunt,		sod_inrctn,
	sod_mtrctn,		sod_cft,		sod_cbm,
	sod_qutno,		sod_refdat,		sod_cusitm,
	sod_cussku,		sod_resppo,		sod_cuspo,
	sod_ordqty,		sod_discnt,		sod_orgmoqchg,
	sod_moqchg,		sod_oneprc,		sod_curcde,
	sod_untprc,		sod_netuntprc,		sod_selprc,
	sod_hrmcde,		sod_dtyrat,		sod_dept,
	sod_typcode,		sod_code1,		sod_code2,
	sod_code3,		sod_cususdcur,		sod_cususd,
	sod_cuscadcur,		sod_cuscad,		sod_inrdin,
	sod_inrwin,		sod_inrhin,		sod_mtrdin,
	sod_mtrwin,		sod_mtrhin,		sod_inrdcm,
	sod_inrwcm,		sod_inrhcm,		sod_mtrdcm,
	sod_mtrwcm,		sod_mtrhcm,		sod_shpstr,
	sod_shpend,		sod_candat,		sod_posstr,
	sod_posend,		sod_poscan,		sod_ctnstr,
	sod_ctnend,		sod_ttlctn,		sod_rmk,
	sod_pormk,		sod_invqty,		sod_shpqty,
	sod_venno,		sod_oldven,		sod_tradeven,
	sod_examven,		sod_purord,		sod_purseq,
	sod_oldpurord,		sod_oldpurseq,		sod_ftycst,
	sod_ftyprc,		sod_bomcst,		sod_fcurcde,
	sod_ftyunt,		sod_venitm,		sod_itmprc,
	sod_basprc,		sod_subcde,		sod_tirtyp,
	sod_moq,		sod_moa,		sod_apprve,
	sod_clmno,		sod_pckitr,		sod_orgvenno,
	sod_assitmcount,	sod_cusmoqchg,		sod_venmoqchg,
	sod_runno,		sod_fmlopt,		sod_fml,
	sod_mubasprc,		sod_cusven,		sod_cussub,
	sod_pjobno,		sod_seccusitm,		sod_alsitmno,
	sod_alscolcde,		sod_ztnvbeln,		sod_ztnposnr,
	sod_zorvbeln,		sod_zorposnr,		sod_conftr,
	sod_contopc,		sod_pcprc,		sod_custum,
	sod_dv,			sod_dvftycst,		sod_dvftyprc,
	sod_dvbomcst,		sod_dvfcurcde,		sod_dvftyunt,
	sod_cusstyno,		sod_moqunttyp,		sod_qutdat,
	sod_imqutdat,		sod_imqutdatchg,	sod_itmcstcur,
	sod_dvitmcst,		sod_ftycst_org,		sod_bomcst_org,
	sod_ftyprc_org,		sod_dvftycst_org,	sod_dvftyprc_org,
	sod_dvbomcst_org,	sod_imqutdat_org,	sod_venno_org,
	sod_fcurcde_org,	sod_dvfcurcde_org,	sod_prcgrp,
	sod_cus1no,		sod_cus2no,		sod_hkprctrm,
	sod_ftyprctrm,		sod_trantrm,		sod_effdat,
	sod_expdat,		sod_tordno,		sod_tordseq,
	sod_year,		sod_season,		sod_effcpo,
	sod_markup,		sod_mumin,		sod_mrkprc,
	sod_muminprc,		sod_commsn,		sod_itmcom,
	sod_pckcst,		sod_stdprc,
	sod_name_f1,		sod_dsc_f1,
	sod_name_f2,		sod_dsc_f2,
	sod_name_f3,		sod_dsc_f3,
	sod_moqmoaflg,		sod_onetimeflg,
	sod_belprcflg,		sod_chgftycstflg,
	sod_chguntprcflg,	sod_untprc_org,
	sod_creusr,		sod_updusr,		sod_credat,
	sod_upddat, sod_scupdusr, sod_itmchidsc, sod_dtlttlctn
)
values
(	@sod_cocde,		@sod_ordno,		@sod_ordseq,
	@sod_updpo,		@sod_chgfty,		@sod_itmno,
	@sod_itmsts,		@sod_itmtyp,		@sod_itmdsc,
	@sod_colcde,		@sod_cuscol,		@sod_coldsc,
	@sod_pckseq,		@sod_pckunt,		@sod_inrctn,
	@sod_mtrctn,		@sod_cft,		@sod_cbm,
	@sod_qutno,		@sod_refdat,		@sod_cusitm,
	@sod_cussku,		@sod_resppo,		@sod_cuspo,
	@sod_ordqty,		@sod_discnt,		@sod_orgmoqchg,
	@sod_moqchg,		@sod_oneprc,		@sod_curcde,
	@sod_untprc,		@sod_netuntprc,		@sod_selprc,
	@sod_hrmcde,		@sod_dtyrat,		@sod_dept,
	@sod_typcode,		@sod_code1,		@sod_code2,
	@sod_code3,		@sod_cususdcur,		@sod_cususd,
	@sod_cuscadcur,		@sod_cuscad,		@sod_inrdin,
	@sod_inrwin,		@sod_inrhin,		@sod_mtrdin,
	@sod_mtrwin,		@sod_mtrhin,		@sod_inrdcm,
	@sod_inrwcm,		@sod_inrhcm,		@sod_mtrdcm,
	@sod_mtrwcm,		@sod_mtrhcm,		@sod_shpstr,
	@sod_shpend,		@sod_candat,		@sod_posstr,
	@sod_posend,		@sod_poscan,		@sod_ctnstr,
	@sod_ctnend,		@sod_ttlctn,		@sod_rmk,
	@sod_pormk,		0,			0,
	@sod_venno,		'',			@sod_tradeven,
	@sod_examven,		@sod_purord,		@sod_purseq,
	@sod_oldpurord,		@sod_oldpurseq,		@sod_ftycst,
	@sod_ftyprc,		@sod_bomcst,		@sod_fcurcde,
	@sod_ftyunt,		@sod_venitm,		@sod_itmprc,
	@sod_basprc,		@sod_subcde,		@sod_tirtyp,
	@sod_moq,		@sod_moa,		@sod_apprve,
	@sod_clmno,		@sod_pckitr,		@sod_orgvenno,
	@sod_assitmcount,	@sod_cusmoqchg,		@sod_venmoqchg,
	'',			@sod_fmlopt,		@sod_fml,
	@sod_mubasprc,		@sod_cusven,		@sod_cussub,
	@sod_pjobno,		@sod_seccusitm,		@sod_alsitmno,
	@sod_alscolcde,		@sod_ztnvbeln,		@sod_ztnposnr,
	@sod_zorvbeln,		@sod_zorposnr,		@sod_conftr,
	@sod_contopc,		@sod_pcprc,		@sod_custum,
	@sod_dv,		@sod_dvftycst,		@sod_dvftyprc,
	@sod_dvbomcst,		@sod_dvfcurcde,		@sod_dvftyunt,
	@sod_cusstyno,		@sod_moqunttyp,		@sod_qutdat,
	@sod_imqutdat,		'N',			@sod_itmcstcur,
	@sod_dvitmcst,		@sod_ftycst_org,	@sod_bomcst_org,
	@sod_ftyprc_org,	@sod_dvftycst_org,	@sod_dvftyprc_org,
	@sod_dvbomcst_org,	@sod_imqutdat_org,	@sod_venno_org,
	@sod_fcurcde_org,	@sod_dvfcurcde_org,	@sod_prcgrp,
	@sod_cus1no,		@sod_cus2no,		@sod_hkprctrm,
	@sod_ftyprctrm,		@sod_trantrm,		@sod_effdat,
	@sod_expdat,		@sod_toordno,		@sod_toordseq,
	@sod_year,		@sod_season,		@sod_effcpo,
	@markup,		@mumin,		@mrkprc,
	@muminprc,		@commsn,		@itmcom,
	@pckcst,		@stdprc,
	@sod_name_f1,		@sod_dsc_f1,
	@sod_name_f2,		@sod_dsc_f2,
	@sod_name_f3,		@sod_dsc_f3,
	@sod_moqmoaflg,		@sod_onetimeflg,
	@sod_belprcflg,		@sod_chgftycstflg,
	@sod_chguntprcflg,	@sod_untprc_org,
	@creusr,		@creusr,		getdate(),
	getdate(), @creusr , @sod_itmchidsc, @sod_dtlttlctn
)	

-- Update SO Quantity for Tentative Order

if @sod_toordno <> ''
begin
	if (select count(*) from TOORDHDR (nolock) where toh_toordno = @sod_toordno and toh_ordsts <> 'CLO') > 0
	begin
		update	TOITMDTL
		set	tid_ordno = @sod_ordno,
			tid_ordseq = @sod_ordseq,
			tid_soqty = tid_soqty + @sod_ordqty,
			tid_osqty = tid_toqty - tid_soqty - @sod_ordqty,
			tid_updusr = left(@creusr, 30),
			tid_upddat = getdate()
		where	tid_toordno = @sod_toordno and
			tid_toordseq = @sod_toordseq
	
		update	TOITMSUM
		set	tis_soqty = tid_soqty,
			tis_osqty = tis_toqty - tid_soqty
		from	TOITMSUM
			join TOITMDTL (nolock) on
				tid_cocde = tis_cocde and
				tid_cus1no = tis_cus1no and
				tid_cus2no = tis_cus2no and
				tid_year = tis_year and
				tid_itmtyp = tis_itmtyp and
				tid_assitm = tis_assitm and
				tid_itmno = tis_itmno and
				tid_tmpitmno = tis_tmpitmno and
				tid_venno = tis_venno and
				tid_venitmno = tis_ventimno and
				tid_pckunt = tis_pckunt
		where	tid_toordno = @sod_toordno and
			tid_toordseq = @sod_toordseq
	end
end


-- Return Order Sequence
select	@sod_ordseq

-- Insert into Customer Item History Summary Information
if @sod_oneprc = 'N' and (@status = 'ACT' or @sod_apprve <> 'W') and @closeout ='N' and @replace ='N'
begin
	if @sod_oneprc = 'N' and (@status = 'ACT' or @sod_apprve <> 'W')
	begin
		if @cis_seccus <> '' 
		begin
		
			if (	select	count(*)
				from	CUITMHIS (nolock)
				where	cis_cusno in (	select	cbi_cusno
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_cusno or
								cbi_cusali = @cis_cusno
							UNION
							select	cbi_cusali
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_cusno)	and
					cis_seccus in (	select	cbi_cusno
							from	CUBASINF (nolock)
							where	(cbi_cusali = @cis_seccus or
								 cbi_cusno = @cis_seccus) and
								cbi_cusno <> ''
							UNION
							select	cbi_cusali
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_seccus and
								cbi_cusali  <> '') and
					cis_itmno in (	select	ibi.ibi_itmno
							from	IMBASINF ibi (nolock)
								left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
							where	ibi.ibi_itmno = @sod_itmno or
								(ibi.ibi_alsitmno = @sod_itmno and
								 isnull(als.ibi_itmsts,'') <> 'OLD')
							UNION
							select	ibi.ibi_alsitmno
							from	imbasinf ibi
							left join	imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
							where	ibi.ibi_itmno = @sod_itmno	and
								isnull(als.ibi_itmsts,'') <> 'OLD') and
					cis_colcde = @sod_colcde and
					cis_untcde = @sod_pckunt and
					cis_inrqty = @sod_inrctn and
					cis_mtrqty = @sod_mtrctn and
					--cis_conftr = @sod_conftr and
					cis_hkprctrm = @sod_hkprctrm and
					cis_ftyprctrm = @sod_ftyprctrm and
					cis_trantrm = @sod_trantrm and
					cis_venno = @sod_dv
			) > 0
			begin
				update	CUITMHIS
				set	cis_itmno = @sod_itmno,
					cis_itmdsc = @sod_itmdsc,
				 	cis_cusitm = @sod_cusitm,
					cis_coldsc = @sod_coldsc,
					cis_cuscol = @sod_cuscol,
					cis_cft = @sod_cft,
					cis_cbm = @sod_cbm,
					cis_prdven = @sod_venno,
					cis_cusven = @sod_cusven,
					cis_tradeven = @sod_tradeven,
					cis_examven = @sod_examven,
					cis_refdoc = @sod_ordno,
					cis_docdat  = getdate(),
					cis_cussku = @sod_cussku,
					cis_ordqty = @sod_ordqty,
					cis_moqchg = @sod_moqchg,
					cis_hrmcde = @sod_hrmcde,
					cis_dtyrat = @sod_dtyrat,
					cis_dept = @sod_dept,
					cis_typcode = @sod_typcode,
					cis_code1  = @sod_code1,
					cis_code2  = @sod_code2,
					cis_code3  = @sod_code3,
					cis_cususdcur = @sod_cususdcur,
					cis_cususd = @sod_cususd,
					cis_cuscadcur = @sod_cuscadcur,
					cis_cuscad = @sod_cuscad,
					cis_inrdin = @sod_inrdin,
					cis_inrwin = @sod_inrwin,
					cis_inrhin = @sod_inrhin,
				 	cis_mtrdin = @sod_mtrdin,
					cis_mtrwin = @sod_mtrwin,
					cis_mtrhin = @sod_mtrhin,
					cis_inrdcm = @sod_inrdcm,
					cis_inrwcm = @sod_inrwcm,
					cis_inrhcm = @sod_inrhcm,
					cis_mtrdcm = @sod_mtrdcm,
					cis_mtrwcm = @sod_mtrwcm,
					cis_mtrhcm = @sod_mtrhcm,
					cis_pckitr = @sod_pckitr,
					cis_itmventyp = @itmventyp,
					cis_ftytmpitm = '',
					cis_cusstyno = @sod_cusstyno,
					cis_year = @sod_year,
					cis_season = @sod_season,
					cis_name_f1 = @sod_name_f1,
					cis_dsc_f1 = @sod_dsc_f1,
					cis_name_f2 = @sod_name_f2,
					cis_dsc_f2 = @sod_dsc_f2,
					cis_name_f3 = @sod_name_f3,
					cis_dsc_f3 = @sod_dsc_f3,
					cis_dtlttlctn = @sod_dtlttlctn,
					cis_itmchidsc = @sod_itmchidsc,
					cis_updusr = @creusr,
					cis_upddat = getdate()	
				where	cis_cusno in (	select	cbi_cusno
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_cusno or
								cbi_cusali = @cis_cusno
							UNION
							select	cbi_cusali
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_cusno)	and
					cis_seccus in (	select	cbi_cusno
							from	CUBASINF (nolock)
							where	(cbi_cusali = @cis_seccus or
								 cbi_cusno = @cis_seccus) and
								cbi_cusno <> ''
							UNION
							select	cbi_cusali
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_seccus and
								cbi_cusali  <> '') and
					cis_itmno in (	select	ibi.ibi_itmno
							from	IMBASINF ibi (nolock)
								left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
							where	ibi.ibi_itmno = @sod_itmno or
								(ibi.ibi_alsitmno = @sod_itmno and
								 isnull(als.ibi_itmsts,'') <> 'OLD')
							UNION
							select	ibi.ibi_alsitmno
							from	imbasinf ibi
							left join	imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
							where	ibi.ibi_itmno = @sod_itmno	and
								isnull(als.ibi_itmsts,'') <> 'OLD') and
					cis_colcde = @sod_colcde and
					cis_untcde = @sod_pckunt and
					cis_inrqty = @sod_inrctn and
					cis_mtrqty = @sod_mtrctn and
					--cis_conftr = @sod_conftr and
					cis_hkprctrm = @sod_hkprctrm and
					cis_ftyprctrm = @sod_ftyprctrm and
					cis_trantrm = @sod_trantrm and
					cis_venno = @sod_dv
			
			end
		
		end
		else
		begin
		
			if (	select	count(*)
				from	CUITMHIS (nolock)
				where	cis_cusno in (	select	cbi_cusno
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_cusno or
								cbi_cusali = @cis_cusno
							UNION
							select	cbi_cusali
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_cusno)	and
					cis_seccus = @cis_seccus and
					cis_itmno in (	select	ibi.ibi_itmno
							from	IMBASINF ibi (nolock)
								left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
							where	ibi.ibi_itmno = @sod_itmno or
								(ibi.ibi_alsitmno = @sod_itmno and
								 isnull(als.ibi_itmsts,'') <> 'OLD')
							UNION
							select	ibi.ibi_alsitmno
							from	imbasinf ibi
							left join	imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
							where	ibi.ibi_itmno = @sod_itmno	and
								isnull(als.ibi_itmsts,'') <> 'OLD') and
					cis_colcde = @sod_colcde and
					cis_untcde = @sod_pckunt and
					cis_inrqty = @sod_inrctn and
					cis_mtrqty = @sod_mtrctn and
					--cis_conftr = @sod_conftr and
					cis_hkprctrm = @sod_hkprctrm and
					cis_ftyprctrm = @sod_ftyprctrm and
					cis_trantrm = @sod_trantrm and
					cis_venno = @sod_dv
			) > 0
			begin
				update	CUITMHIS
				set	cis_itmno = @sod_itmno,
					cis_itmdsc = @sod_itmdsc,
				 	cis_cusitm = @sod_cusitm,
					cis_coldsc = @sod_coldsc,
					cis_cuscol = @sod_cuscol,
					cis_cft = @sod_cft,
					cis_cbm = @sod_cbm,
					cis_prdven = @sod_venno,
					cis_cusven = @sod_cusven,
					cis_tradeven = @sod_tradeven,
					cis_examven = @sod_examven,
					cis_refdoc = @sod_ordno,
					cis_docdat  = getdate(),
					cis_cussku = @sod_cussku,
					cis_ordqty = @sod_ordqty,
					cis_moqchg = @sod_moqchg,
					cis_hrmcde = @sod_hrmcde,
					cis_dtyrat = @sod_dtyrat,
					cis_dept = @sod_dept,
					cis_typcode = @sod_typcode,
					cis_code1  = @sod_code1,
					cis_code2  = @sod_code2,
					cis_code3  = @sod_code3,
					cis_cususdcur = @sod_cususdcur,
					cis_cususd = @sod_cususd,
					cis_cuscadcur = @sod_cuscadcur,
					cis_cuscad = @sod_cuscad,
					cis_inrdin = @sod_inrdin,
					cis_inrwin = @sod_inrwin,
					cis_inrhin = @sod_inrhin,
				 	cis_mtrdin = @sod_mtrdin,
					cis_mtrwin = @sod_mtrwin,
					cis_mtrhin = @sod_mtrhin,
					cis_inrdcm = @sod_inrdcm,
					cis_inrwcm = @sod_inrwcm,
					cis_inrhcm = @sod_inrhcm,
					cis_mtrdcm = @sod_mtrdcm,
					cis_mtrwcm = @sod_mtrwcm,
					cis_mtrhcm = @sod_mtrhcm,
					cis_pckitr = @sod_pckitr,
					cis_itmventyp = @itmventyp,
					cis_ftytmpitm = '',
					cis_cusstyno = @sod_cusstyno,
					cis_year = @sod_year,
					cis_season = @sod_season,
					cis_name_f1 = @sod_name_f1,
					cis_dsc_f1 = @sod_dsc_f1,
					cis_name_f2 = @sod_name_f2,
					cis_dsc_f2 = @sod_dsc_f2,
					cis_name_f3 = @sod_name_f3,
					cis_dsc_f3 = @sod_dsc_f3,
					cis_dtlttlctn = @sod_dtlttlctn,
					cis_itmchidsc = @sod_itmchidsc,
					cis_updusr = @creusr,
					cis_upddat = getdate()	
				where	cis_cusno in (	select	cbi_cusno
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_cusno or
								cbi_cusali = @cis_cusno
							UNION
							select	cbi_cusali
							from	CUBASINF (nolock)
							where	cbi_cusno = @cis_cusno)	and
					cis_seccus = @cis_seccus and
					cis_itmno in (	select	ibi.ibi_itmno
							from	IMBASINF ibi (nolock)
								left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
							where	ibi.ibi_itmno = @sod_itmno or
								(ibi.ibi_alsitmno = @sod_itmno and
								 isnull(als.ibi_itmsts,'') <> 'OLD')
							UNION
							select	ibi.ibi_alsitmno
							from	imbasinf ibi
							left join	imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
							where	ibi.ibi_itmno = @sod_itmno	and
								isnull(als.ibi_itmsts,'') <> 'OLD') and
					cis_colcde = @sod_colcde and
					cis_untcde = @sod_pckunt and
					cis_inrqty = @sod_inrctn and
					cis_mtrqty = @sod_mtrctn and
					--cis_conftr = @sod_conftr and
					cis_hkprctrm = @sod_hkprctrm and
					cis_ftyprctrm = @sod_ftyprctrm and
					cis_trantrm = @sod_trantrm and
					cis_venno = @sod_dv
			
			end
		

		end
	
		--orig place
	end
end

	if @soh_verno > 1 and @status = 'ACT' and @sod_apprve <> 'W' and @closeout = 'N' and @replace = 'N'
		set @flg_cuitmprcdtl = 'Y'
	else
		set @flg_cuitmprcdtl = 'N'
		
	if @flg_cuitmprcdtl = 'Y'
	begin
		Set  @seq_num_cuitmprcdtl = (	select	isnull(max(cid_seqnum),0) + 1
		from	CUITMPRCDTL
		where	
			cid_cusno = @cis_cusno and
			cid_seccus = @cis_seccus and
			cid_itmno = @sod_itmno and
			cid_colcde = @sod_colcde and
			cid_untcde = @sod_pckunt and
			cid_conftr = @sod_conftr and
			cid_inrqty = @sod_inrctn and
			cid_mtrqty = @sod_mtrctn and
			cid_hkprctrm = @sod_hkprctrm and
			cid_ftyprctrm = @sod_ftyprctrm and
			cid_trantrm = @sod_trantrm	
			)
		
		if @sod_apprve = ''
		set @sod_apprve = 'N'
		
		--Query about CUITMPRCDTL Start
			insert into CUITMPRCDTL(
				cid_cocde, cid_cusno, cid_seccus, cid_itmno,
				cid_colcde, cid_untcde, cid_conftr, cid_inrqty,
				cid_mtrqty, cid_hkprctrm, cid_ftyprctrm, cid_trantrm,
			
				cid_seqnum, cid_refdoc, cid_refseq, cid_docdat, cid_apvsts,
				--Data Part Start
				cis_cussna, cis_secsna,
				cis_itmdsc, cis_coldsc, cis_cuscol, cis_cussku, cid_cusitm, cid_cusstyno,
				cis_venno, cis_prdven, cis_cusven, cis_tradeven, cis_examven,
				
				cis_ordqty, cis_untprc, cis_oneprc,
				cis_hrmcde, cis_dtyrat, cis_dept, cis_typcode,
				cis_code1, cis_code2, cis_code3,
				
				cis_cususdcur, cis_cususd, cis_cuscadcur, cis_cuscad,
				
				cis_inrdin, cis_inrwin, cis_inrhin, cis_mtrdin, cis_mtrwin, cis_mtrhin, 
				cis_inrdcm, cis_inrwcm, cis_inrhcm, cis_mtrdcm, cis_mtrwcm, cis_mtrhcm,
				cis_cft, cis_cbm ,cis_pckitr,
				
				cis_itmventyp, cis_tirtyp, cis_moqunttyp, cis_moq, cis_moacur, cis_moa,
				cis_year, cis_season,
				cis_contopc, cis_pcprc, cis_dtlttlctn,cis_itmchidsc,
				
				cid_effdat, cid_expdat, cid_cus1no, cid_cus2no,
				cip_fcurcde, cip_ftycst, cip_bomcst, cip_ftyprc,
				cip_curcde, cip_basprc, cip_markup, cip_mrkprc, 
				cip_pckcst, cip_commsn, cip_itmcom, cip_stdprc, 
				cip_mumin, cip_muminprc, cip_discnt,
				cip_qutdat,
				
				cid_mode,
				cid_scref,
				cid_creusr, cid_updusr, cid_credat, cid_upddat
			)
			values(
				'', @cis_cusno, @cis_seccus, @sod_itmno,
				@sod_colcde, @sod_pckunt, @sod_conftr, @sod_inrctn,
				@sod_mtrctn, @sod_hkprctrm, @sod_ftyprctrm, @sod_trantrm,
				
				@seq_num_cuitmprcdtl, @sod_ordno, @sod_ordseq, getdate(), @sod_apprve, -- cid_docdat
				@cis_cussna, @cis_secsna,
				
				@sod_itmdsc, @sod_coldsc, @sod_cuscol, @sod_cussku, @sod_cusitm, @sod_cusstyno, 
				@sod_dv, @sod_venno, @sod_cusven, @sod_tradeven, @sod_examven,
				
				@sod_ordqty, @sod_untprc, @sod_oneprc,
				@sod_hrmcde, @sod_dtyrat, @sod_dept, @sod_typcode, 
				@sod_code1, @sod_code2, @sod_code3, 
				
				@sod_cususdcur, @sod_cususd, @sod_cuscadcur, @sod_cuscad,
				
				@sod_inrdin, @sod_inrwin, @sod_inrhin, @sod_mtrdin, @sod_mtrwin, @sod_mtrhin, 
				@sod_inrdcm, @sod_inrwcm, @sod_inrhcm, @sod_mtrdcm, @sod_mtrwcm, @sod_mtrhcm,
				@sod_cft, @sod_cbm, @sod_pckitr,
				
				@itmventyp, @sod_tirtyp, @sod_moqunttyp, @sod_moq, @sod_curcde, @sod_moa, --no cis_moacur, 
				@sod_year, @sod_season,
				@sod_contopc, @sod_pcprc,@sod_dtlttlctn,@sod_itmchidsc,
				
				@sod_effdat, @sod_expdat, @sod_cus1no, @sod_cus2no, 
				@sod_fcurcde, 0, @sod_bomcst, @sod_ftyprc, --@sod_ftycst
				@sod_curcde, @sod_basprc, @markup, @mrkprc, 
				@pckcst, @commsn, @itmcom, @stdprc, 
				@mumin, @muminprc, @sod_discnt, 
				@sod_qutdat,
				
				'SI',
				@sod_qutno,
				@creusr, @creusr, @cis_credat, @cis_credat 
				
			)
		--Query about CUITMPRCDTL End
	END
END


GO
GRANT EXECUTE ON [dbo].[sp_insert_SCORDDTL] TO [ERPUSER] AS [dbo]
GO
