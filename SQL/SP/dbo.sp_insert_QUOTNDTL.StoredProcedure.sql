/****** Object:  StoredProcedure [dbo].[sp_insert_QUOTNDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_QUOTNDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_QUOTNDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



Create PROCEDURE [dbo].[sp_insert_QUOTNDTL] 

@qud_cocde	nvarchar(6) ,	@qud_qutno 	nvarchar(20),	@qud_qutseq 	int,
@qud_itmno 	nvarchar(20),	@qud_itmsts 	nvarchar(4),	@qud_itmdsc 	nvarchar(800),
@qud_alsitmno 	nvarchar(20), 	@qud_alscolcde	nvarchar(30),	@qud_conftr	numeric(9),
@qud_contopc	nvarchar(1),	@qud_pcprc	numeric(13,4),	@qud_hstref 	nvarchar(20),
@qud_colcde 	nvarchar(30),	@qud_cuscol 	nvarchar(30),	@qud_coldsc 	nvarchar(300),
@qud_pckseq 	int,		@qud_untcde 	nvarchar(6),	@qud_inrqty 	int,
@qud_mtrqty 	int,		@qud_cft 		numeric(11,4),	@qud_curcde 	nvarchar(6),
@qud_cus1sp 	numeric(13,4),	@qud_cus2sp 	numeric(13,4),	@qud_cus1dp 	numeric(13,4),
@qud_cus2dp 	numeric(13,4),	@qud_onetim 	nvarchar(1),	@qud_discnt 	numeric(6,3),
@qud_moflag	char(1),		@qud_orgmoq	int,		@qud_orgmoa	numeric(11,4),
@qud_moq 	int,		@qud_moa 	numeric(11,4),	@qud_smpqty 	int,
@qud_hrmcde 	nvarchar(12),	@qud_dtyrat 	numeric(6,3),	@qud_dept 	nvarchar(20),
@qud_cususd 	numeric(13,4),	@qud_cuscad 	numeric(13,4),	@qud_venno 	nvarchar(6),
@qud_subcde	nvarchar(10),	@qud_venitm 	nvarchar(20),	@qud_ftyprc 	numeric(13,4),
@qud_ftycst 	numeric(13,4),	@qud_note 	nvarchar(300),	@qud_image 	nvarchar(1),
@qud_inrdin 	numeric(11,4),	@qud_inrwin 	numeric(11,4),	@qud_inrhin 	numeric(11,4),
@qud_mtrdin 	numeric(11,4),	@qud_mtrwin 	numeric(11,4),	@qud_mtrhin 	numeric(11,4),
@qud_inrdcm 	numeric(11,4),	@qud_inrwcm 	numeric(11,4),	@qud_inrhcm 	numeric(11,4),	
@qud_mtrdcm 	numeric(11,4),	@qud_mtrwcm 	numeric(11,4),	@qud_mtrhcm 	numeric(11,4),	
@qud_grswgt 	numeric(6,3),	@qud_netwgt 	numeric(6,3),	@qud_cosmth 	nvarchar(50),	
@qud_smpprc	numeric(13,4),	@qud_cusitm	nvarchar(20),	@cus1no		nvarchar(6),	
@cus1na		nvarchar(20),	@cus2no		nvarchar(6),	@cus2na		nvarchar(20),	
@qud_prcsec	nvarchar(3),	@qud_grsmgn	numeric(6,3),	@qud_basprc	numeric(13,4),	
@qud_tbm		nvarchar(1),	@qud_tbmsts	nvarchar(3),	@rvsdat		datetime,		
@qud_apprve	nvarchar(1),	@qud_pckitr	nvarchar(300),	
@qud_stkqty	int,		
@qud_cusqty	int,		@qud_smpunt	nvarchar(6),	@qud_qutitmsts	nvarchar(25),	
@qud_fcurcde	nvarchar(6),	@qud_itmtyp	nvarchar(4),	@quh_qutsts	nvarchar(10),	
@qud_prctrm	nvarchar(10),	@qud_cusven	varchar(6),		@qud_cussub	varchar(10),
@qud_ftyprctrm	varchar(20),	@qud_cusstyno	nvarchar(50),	@qud_cbm	numeric(11, 4),
@qud_upc		nvarchar(50),	@qud_specpck	nvarchar(255),	@qud_ftytmpitm	nvarchar(1),
@qud_ftytmpitmno	nvarchar(20),	@qud_custitmcat	nvarchar(12),	@qud_custitmcatfml	nvarchar(6),
@qud_custitmcatamt	numeric(13,4),	@qud_pmu	nvarchar(100),	@qud_imrmk	nvarchar(255),
@qud_rndsts	nvarchar(255),	@qud_calpmu	numeric(13,4),	@qud_moqunttyp	nvarchar(6),
@qud_qutdat	datetime,		@qud_cus1no	nvarchar(6),	@qud_cus2no	nvarchar(6),
@qud_trantrm	nvarchar(10),	@qud_effdat	datetime,		@qud_expdat	datetime,
@qud_itmnotyp	nvarchar(1),	@qud_itmnoreal 	nvarchar(20),	@qud_itmnotmp 	nvarchar(20),
@qud_itmnoven 	nvarchar(20),	@qud_itmnovenno 	nvarchar(6),	@qud_imgpth 	nvarchar(200),
@qud_cususdcur 	nvarchar(6),	@qud_cuscadcur 	nvarchar(6),	
@qud_dv	nvarchar(10),
@qud_tv	nvarchar(10),
@qud_ftyaud	nvarchar(10),
@qud_buyer	nvarchar(20),
@qud_toqty	int,
@qud_tormk	nvarchar(300),
@qud_ftyshpstr	datetime,
@qud_ftyshpend	datetime,
@qud_cushpstr	datetime,
@qud_cushpend	datetime,
@qud_toshipport	nvarchar(50),
@qud_creusr	nvarchar(30)

AS

declare	@seq	int,		@cid_seqno	int
Declare @Itmventyp char(1)

/**  should same as QUPRCEMT
Set  @seq = (	select	isnull(max(qud_qutseq),0) + 1
		from	QUOTNDTL
		where	qud_cocde = @qud_cocde	and
			qud_qutno = @qud_qutno)

select @seq -- Warning : Cannot delete this selection
**/






--- Get Item Vendor Type ---
set @Itmventyp = isnull(
			(	select	VBI_VENTYP	 
				from	IMBASINF (NOLOCK) 
				left join VNBASINF (NOLOCK) ON VBI_VENNO = IBI_VENNO
				where	IBI_ITMNO = @qud_itmno	and
					VBI_VENTYP IS NOT NULL),
		' ')

insert into	[QUOTNDTL]
	(qud_cocde ,	qud_qutno ,	qud_qutseq ,
	qud_itmno ,	qud_itmsts ,	qud_itmdsc ,
	qud_alsitmno,	qud_alscolcde,	qud_conftr ,
	qud_contopc , 	qud_pcprc,		qud_hstref ,
	qud_colcde ,	qud_cuscol ,	qud_coldsc ,
	qud_pckseq ,	qud_untcde ,	qud_inrqty ,
	qud_mtrqty ,	qud_cft ,		qud_curcde ,
	qud_cus1sp ,	qud_cus2sp ,	qud_cus1dp ,
	qud_cus2dp ,	qud_onetim ,	qud_discnt ,
	qud_moq ,		qud_moa ,		qud_smpqty ,
	qud_hrmcde ,	qud_dtyrat ,	qud_dept ,
	qud_cususd ,	qud_cuscad ,	qud_venno ,
	qud_venitm ,	qud_ftyprc ,	qud_note ,
	qud_image ,	qud_inrdin ,	qud_inrwin ,
	qud_inrhin ,	qud_mtrdin ,	qud_mtrwin ,
	qud_mtrhin ,	qud_inrdcm ,	qud_inrwcm ,
	qud_inrhcm ,	qud_mtrdcm ,	qud_mtrwcm ,
	qud_mtrhcm ,	qud_grswgt ,	qud_netwgt ,
	qud_cosmth ,	qud_creusr ,	qud_updusr ,
	qud_credat ,	qud_upddat ,	qud_smpprc,
	qud_cusitm,	qud_prcsec,	qud_grsmgn,
	qud_basprc,	qud_tbm,		qud_tbmsts,
	qud_apprve,	qud_pckitr,		qud_stkqty,
	qud_cusqty,	qud_smpunt,	qud_qutitmsts,
	qud_fcurcde,	qud_itmtyp,	qud_subcde,
	qud_ftycst,		qud_prctrm,	qud_moflag,
	qud_orgmoq,	qud_orgmoa,	qud_cusven,
	qud_cussub, 	qud_ftyprctrm,	qud_cusstyno ,
	qud_cbm,		qud_upc ,		qud_specpck,
	qud_ftytmpitm,	qud_ftytmpitmno,	qud_custitmcat,
	qud_custitmcatfml,	qud_custitmcatamt,	qud_pmu,
	qud_imrmk,	qud_rndsts,	qud_calpmu,
	qud_moqunttyp,	qud_qutdat,	qud_cus1no,
	qud_cus2no,	qud_trantrm,	qud_effdat,
	qud_expdat,	qud_itmnotyp,	qud_itmnoreal,
	qud_itmnotmp,	qud_itmnoven,	qud_itmnovenno,
	qud_imgpth,	qud_cususdcur,	qud_cuscadcur, 
	qud_dv,
	qud_tv,
	qud_ftyaud,
	qud_buyer,
	qud_toqty,
	qud_tormk,
	qud_ftyshpstr,
	qud_ftyshpend,
	qud_cushpstr,
	qud_cushpend,
	qud_toshipport)
values	(@qud_cocde ,	@qud_qutno ,	@qud_qutseq ,
	@qud_itmno ,	@qud_itmsts ,	@qud_itmdsc ,
	@qud_alsitmno,	@qud_alscolcde,	@qud_conftr ,
	@qud_contopc , 	@qud_pcprc,	@qud_hstref ,
	@qud_colcde ,	@qud_cuscol ,	@qud_coldsc ,
	@qud_pckseq ,	@qud_untcde ,	@qud_inrqty ,
	@qud_mtrqty ,	@qud_cft ,		@qud_curcde ,
	@qud_cus1sp ,	@qud_cus2sp ,	@qud_cus1dp ,
	@qud_cus2dp ,	@qud_onetim ,	@qud_discnt ,
	@qud_moq ,	@qud_moa ,	@qud_smpqty ,
	@qud_hrmcde ,	@qud_dtyrat ,	@qud_dept ,
	@qud_cususd ,	@qud_cuscad ,	@qud_venno ,
	@qud_venitm ,	@qud_ftyprc ,	@qud_note ,
	@qud_image ,	@qud_inrdin ,	@qud_inrwin ,
	@qud_inrhin ,	@qud_mtrdin ,	@qud_mtrwin ,
	@qud_mtrhin ,	@qud_inrdcm ,	@qud_inrwcm ,
	@qud_inrhcm ,	@qud_mtrdcm ,	@qud_mtrwcm ,
	@qud_mtrhcm ,	@qud_grswgt ,	@qud_netwgt ,
	@qud_cosmth ,	@qud_creusr ,	@qud_creusr ,
	getdate() ,		getdate() ,		@qud_smpprc ,
	@qud_cusitm ,	@qud_prcsec ,	@qud_grsmgn ,
	@qud_basprc,	@qud_tbm,	@qud_tbmsts,
	@qud_apprve,	@qud_pckitr,	@qud_stkqty,
	@qud_cusqty,	@qud_smpunt,	@qud_qutitmsts,
	@qud_fcurcde,	@qud_itmtyp,	@qud_subcde,
	@qud_ftycst,	@qud_prctrm,	@qud_moflag,
	@qud_orgmoq,	@qud_orgmoa,	@qud_cusven,
	@qud_cussub, 	@qud_ftyprctrm,	@qud_cusstyno ,
	@qud_cbm,	@qud_upc ,	@qud_specpck,
	@qud_ftytmpitm,	@qud_ftytmpitmno,	@qud_custitmcat,
	@qud_custitmcatfml,	@qud_custitmcatamt,	@qud_pmu,
	@qud_imrmk,	@qud_rndsts,	@qud_calpmu,
	@qud_moqunttyp,	@qud_qutdat,	@qud_cus1no,
	@qud_cus2no,	@qud_trantrm,	@qud_effdat,
	@qud_expdat,	@qud_itmnotyp,	@qud_itmnoreal,
	@qud_itmnotmp,	@qud_itmnoven,	@qud_itmnovenno,
	@qud_imgpth,	@qud_cususdcur,	@qud_cuscadcur,
	@qud_dv,
	@qud_tv,
	@qud_ftyaud,
	@qud_buyer,
	@qud_toqty,
	@qud_tormk,
	@qud_ftyshpstr,
	@qud_ftyshpend,
	@qud_cushpstr,
	@qud_cushpend,
	@qud_toshipport)

UPDATE 	IMBASINF
SET	ibi_latrdat = getdate()
WHERE 	ibi_itmno = @qud_itmno


declare @cusstyno as nvarchar(30)
declare @chkdgt as integer
set @cusstyno = isnull(@qud_cusstyno ,'')
if @cusstyno <> '' 
begin
	select @chkdgt = isnull(max(ics_chkdgt) + 1,0) from IMCUSSTY (nolock) where ics_cusno = @cus1no and ics_cusstyno = @cusstyno 

	if (select count(*) from IMCUSSTY (nolock) where  ics_cusstyno = @cusstyno and  ics_cusno = @cus1no and ics_itmno = @qud_itmno) = 0
	begin
		insert into IMCUSSTY (ics_cusno,ics_cusstyno,ics_chkdgt,ics_itmno,ics_creusr,ics_updusr,ics_credat,ics_upddat)
		values (@cus1no,@cusstyno,@chkdgt,@qud_itmno,@qud_creusr,@qud_creusr,getdate(),getdate())
	end
end



declare @quh_year nvarchar(20)
declare @quh_season nvarchar(20)
declare @quh_cus1no nvarchar(10)
declare @quh_cus2no nvarchar(10)

declare @cis_cussna nvarchar(20)
declare @cis_secsna nvarchar(20)


select @quh_year = quh_year, @quh_season = quh_season,@quh_cus1no = quh_cus1no, @quh_cus2no = quh_cus2no from QUOTNHDR (nolock) where quh_cocde = @qud_cocde and quh_qutno = @qud_qutno


--- Get Customer Name For Primary and Secondary ---
if @quh_cus1no <> ''
	select @cis_cussna = cbi_cussna from CUBASINF where cbi_cusno = @quh_cus1no
else 
	select @cis_cussna = ''
	
if @quh_cus2no <> ''
	select @cis_secsna = cbi_cussna from CUBASINF where cbi_cusno = @quh_cus2no
else
	select @cis_secsna = ''






declare @cis_flg as char(1)

declare @cis_key_cocde as nvarchar(10)
declare @cis_key_cusno as nvarchar(10)
declare @cis_key_seccus as nvarchar(10)
declare @cis_key_itmno as nvarchar(20)
declare @cis_key_colcde as nvarchar(30)
declare @cis_key_untcde as nvarchar(10)
declare @cis_key_conftr as int
declare @cis_key_inrqty as int
declare @cis_key_mtrqty as int
declare @cis_key_hkprctrm as nvarchar(10)
declare @cis_key_ftyprctrm as nvarchar(10)
declare @cis_key_trantrm as nvarchar(10)


if @qud_itmnoreal <> '' and @qud_qutitmsts = 'A'  --and @quh_qutsts = 'A' and @qud_qutitmsts = 'A - Active'	and (@qud_apprve = '' or @qud_apprve = 'Y')

	set @cis_flg = 'Y'
else
	set @cis_flg = 'N'

if @cis_flg = 'Y'
begin
	-- Insert / Update CUITMHIS
	--set @cis_key_cocde = @qud_cocde
	set @cis_key_cocde = ''
	set @cis_key_cusno = @quh_cus1no
	set @cis_key_seccus = @quh_cus2no
	set @cis_key_itmno = @qud_itmnoreal
	set @cis_key_colcde = @qud_colcde
	set @cis_key_untcde = @qud_untcde
	set @cis_key_conftr = @qud_conftr
	set @cis_key_inrqty = @qud_inrqty
	set @cis_key_mtrqty = @qud_mtrqty
	set @cis_key_hkprctrm = @qud_prctrm
	set @cis_key_ftyprctrm = @qud_ftyprctrm
	set @cis_key_trantrm = @qud_trantrm

	if ((select count(*) from CUITMHIS (nolock) 
			where cis_cocde = @cis_key_cocde and
				cis_cusno = @cis_key_cusno and
				cis_seccus = @cis_key_seccus and
				cis_itmno = @cis_key_itmno and
				cis_colcde = @cis_key_colcde and
				cis_untcde = @cis_key_untcde and
				cis_conftr = @cis_key_conftr and
				cis_inrqty = @cis_key_inrqty and
				cis_mtrqty = @cis_key_mtrqty and
				cis_hkprctrm = @cis_key_hkprctrm and
				cis_ftyprctrm = @cis_key_ftyprctrm and
				cis_trantrm = @cis_key_trantrm ) = 0 )
	begin
		insert into CUITMHIS
		(cis_cocde,cis_cusno,cis_cussna,cis_seccus,cis_secsna,
		cis_itmno,cis_itmdsc,cis_cusitm,cis_colcde,cis_coldsc,
		cis_cuscol,cis_untcde,cis_conftr,cis_inrqty,cis_mtrqty,
		cis_cft,cis_cbm,cis_venno,cis_prdven,cis_cusven,
		cis_tradeven,cis_examven,cis_hkprctrm,cis_ftyprctrm,
		cis_trantrm,cis_cus1no,cis_cus2no,cis_refdoc,cis_docdat,
		cis_qutno,cis_qutseq,cis_cussku,cis_ordqty,cis_moqchg,
		cis_hrmcde,cis_dtyrat,cis_dept,cis_typcode,cis_code1,
		cis_code2,cis_code3,cis_cususdcur,cis_cususd,cis_cuscadcur,
		cis_cuscad,cis_inrdin,cis_inrwin,cis_inrhin,cis_mtrdin,
		cis_mtrwin,cis_mtrhin,cis_inrdcm,cis_inrwcm,cis_inrhcm,
		cis_mtrdcm,cis_mtrwcm,cis_mtrhcm,cis_pckitr,cis_itmventyp,
		cis_tirtyp,cis_moqunttyp,cis_moq,cis_moacur,cis_moa,
		cis_contopc,cis_pcprc,cis_ftytmpitm,cis_cusstyno,cis_year,
		cis_season,cis_creusr,cis_updusr,cis_credat,cis_upddat)
		values
		(@cis_key_cocde,@cis_key_cusno,@cis_cussna,@cis_key_seccus,@cis_secsna,		-- @cus1na->cis_cussna, @cus2na-> cis_seccus
		@cis_key_itmno,@qud_itmdsc,@qud_cusitm,@cis_key_colcde,@qud_coldsc,
		@qud_cuscol,@cis_key_untcde,@cis_key_conftr,@cis_key_inrqty,@cis_key_mtrqty,
		@qud_cft,@qud_cbm,ltrim(rtrim(@qud_dv)),ltrim(rtrim(@qud_venno)),ltrim(rtrim(@qud_cusven)),
		ltrim(rtrim(@qud_tv)),ltrim(rtrim(@qud_ftyaud)),@cis_key_hkprctrm,@cis_key_ftyprctrm,
		@cis_key_trantrm,@qud_cus1no,@qud_cus2no,@qud_qutno,@rvsdat,
		@qud_qutno,@qud_qutseq,'',0,0,
		@qud_hrmcde,@qud_dtyrat,@qud_dept,'U','',
		'','',@qud_cususdcur,@qud_cususd,@qud_cuscadcur,
		@qud_cuscad,@qud_inrdin,@qud_inrwin,@qud_inrhin,@qud_mtrdin,
		@qud_mtrwin,@qud_mtrhin,@qud_inrdcm,@qud_inrwcm,@qud_inrhcm,
		@qud_mtrdcm,@qud_mtrwcm,@qud_mtrhcm,@qud_pckitr,@ItmVenTyp,
		1,@qud_moqunttyp,@qud_moq,@qud_curcde,@qud_moa,
		@qud_contopc,@qud_pcprc,@qud_ftytmpitm,@qud_cusstyno,@quh_year,
		@quh_season,@qud_creusr,@qud_creusr,getdate(),getdate())
	end
	else
	begin
		update CUITMHIS	set
		cis_itmdsc = @qud_itmdsc, 
		cis_cusitm = @qud_cusitm, 
		cis_coldsc = @qud_coldsc, 
		cis_cuscol = @qud_cuscol, 
		cis_cft = @qud_cft, 
		cis_cbm = @qud_cbm, 
		cis_venno = ltrim(rtrim(@qud_dv)), 
		cis_prdven = ltrim(rtrim(@qud_venno)), 
		cis_cusven = ltrim(rtrim(@qud_cusven)), 
		cis_tradeven = ltrim(rtrim(@qud_tv)), 
		cis_examven = ltrim(rtrim(@qud_ftyaud)), 
		cis_cus1no = @qud_cus1no, 
		cis_cus2no = @qud_cus2no, 
		cis_refdoc = @qud_qutno, 
		cis_docdat = @rvsdat, 
		cis_qutno = @qud_qutno, 
		cis_qutseq = @qud_qutseq, 
		--cis_cussku = '', 
		--cis_ordqty = 0, 
		--cis_moqchg = 0, 
		cis_hrmcde = @qud_hrmcde, 
		cis_dtyrat = @qud_dtyrat, 
		cis_dept = @qud_dept, 
		--cis_typcode = 'U', 
		--cis_code1 = '', 
		--cis_code2 = '', 
		--cis_code3 = '', 
		cis_cususdcur = @qud_cususdcur, 
		cis_cususd = @qud_cususd, 
		cis_cuscadcur = @qud_cuscadcur, 
		cis_cuscad = @qud_cuscad, 
		cis_inrdin = @qud_inrdin, 
		cis_inrwin = @qud_inrwin, 
		cis_inrhin = @qud_inrhin, 
		cis_mtrdin = @qud_mtrdin, 
		cis_mtrwin = @qud_mtrwin, 
		cis_mtrhin = @qud_mtrhin, 
		cis_inrdcm = @qud_inrdcm, 
		cis_inrwcm = @qud_inrwcm, 
		cis_inrhcm = @qud_inrhcm, 
		cis_mtrdcm = @qud_mtrdcm, 
		cis_mtrwcm = @qud_mtrwcm, 
		cis_mtrhcm = @qud_mtrhcm, 
		cis_pckitr = @qud_pckitr, 
		cis_itmventyp = @ItmVenTyp, 
		--cis_tirtyp = 1, 
		cis_moqunttyp = @qud_moqunttyp, 
		cis_moq = @qud_moq, 
		cis_moacur = @qud_curcde, 
		cis_moa = @qud_moa, 
		cis_contopc = @qud_contopc, 
		cis_pcprc = @qud_pcprc, 
		cis_ftytmpitm = @qud_ftytmpitm, 
		cis_cusstyno = @qud_cusstyno, 
		cis_year = @quh_year, 
		cis_season = @quh_season, 
		cis_updusr = @qud_creusr, 
		cis_upddat = getdate()
		where 	cis_cocde = @cis_key_cocde and 
			cis_cusno = @cis_key_cusno and 
			cis_seccus = @cis_key_seccus and 
			cis_itmno = @cis_key_itmno and 
			cis_colcde = @cis_key_colcde and 
			cis_untcde = @cis_key_untcde and 
			cis_conftr = @cis_key_conftr and 
			cis_inrqty = @cis_key_inrqty and 
			cis_mtrqty = @cis_key_mtrqty and 
			cis_hkprctrm = @cis_key_hkprctrm and 
			cis_ftyprctrm = @cis_key_ftyprctrm and 
			cis_trantrm = @cis_key_trantrm
	end
end







--if @quh_qutsts = 'A'
--begin

-- Insert into Customer Item History (CUITMHIS)
/*
(cis_cocde,
cis_cusno,
cis_cussna,
cis_seccus,
cis_secsna,
cis_itmno,
cis_itmdsc,
cis_cusitm,
cis_colcde,
cis_coldsc,
cis_cuscol,
cis_untcde,
cis_conftr,
cis_inrqty,
cis_mtrqty,
cis_cft,
cis_cbm,
cis_venno,
cis_prdven,
cis_cusven,
cis_tradeven,
cis_examven,
cis_hkprctrm,
cis_ftyprctrm,
cis_trantrm,
cis_cus1no,
cis_cus2no,
cis_refdoc,
cis_docdat,
cis_qutno,
cis_qutseq,
cis_cussku,
cis_ordqty,
cis_moqchg,
cis_hrmcde,
cis_dtyrat,
cis_dept,
cis_typcode,
cis_code1,
cis_code2,
cis_code3,
cis_cususdcur,
cis_cususd,
cis_cuscadcur,
cis_cuscad,
cis_inrdin,
cis_inrwin,
cis_inrhin,
cis_mtrdin,
cis_mtrwin,
cis_mtrhin,
cis_inrdcm,
cis_inrwcm,
cis_inrhcm,
cis_mtrdcm,
cis_mtrwcm,
cis_mtrhcm,
cis_pckitr,
cis_itmventyp,
cis_tirtyp,
cis_moqunttyp,
cis_moq,
cis_moacur,
cis_moa,
cis_contopc,
cis_pcprc,
cis_ftytmpitm,
cis_cusstyno,
cis_year,
cis_season,
cis_creusr,
cis_updusr,
cis_credat,
cis_upddat)
*/

-- Insert into Customer Item Pricing (CUITMPRC)


--end





/*
-- Insert into Customer Item History Summary Information
if @quh_qutsts = 'A' 
begin
	if	@qud_tbm = 'N'		and
		@qud_qutitmsts = 'A - Active'	and
		(@qud_apprve = ''	or
		 @qud_apprve = 'Y')
	begin
		if @qud_onetim = 'N' 
		begin
			if @cus2no   <> '' 
			begin 
				if (	select	count(*) 
					from 	CUITMSUM 
					where 	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)		and
						cis_seccus in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	(cbi_cusali = @cus2no or
									 cbi_cusno = @cus2no) and
									cbi_cusno <> ''
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus2no and
									cbi_cusali <> '')		and
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 
								union
								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <> 'OLD')	and
						cis_colcde = @qud_colcde				and
						cis_untcde = @qud_untcde				and 
						cis_inrqty = @qud_inrqty				and 
						cis_conftr = @qud_conftr				and
						cis_mtrqty = @qud_mtrqty) = 0
				begin
					insert into	[CUITMSUM]
						(cis_cocde ,	cis_cusno ,		cis_itmno ,
						 cis_itmdsc ,	cis_cusitm ,	cis_colcde ,
						 cis_coldsc ,	cis_cuscol ,		cis_untcde ,
						 cis_inrqty ,	cis_mtrqty ,	cis_cft ,
						 cis_cbm ,		cis_refdoc ,		cis_docdat ,
						 cis_cussku ,	cis_ordqty ,	cis_curcde ,
						 cis_selprc ,	cis_hrmcde ,	cis_dtyrat ,
						 cis_dept ,		cis_typcode ,	cis_code1 ,	
						 cis_code2 ,	cis_code3 ,		cis_cususd ,
						 cis_cuscad ,	cis_inrdin ,		cis_inrwin ,
						 cis_inrhin ,	cis_mtrdin ,	cis_mtrwin ,
						 cis_mtrhin ,	cis_inrdcm ,	cis_inrwcm ,
						 cis_inrhcm ,	cis_mtrdcm ,	cis_mtrwcm ,
						 cis_mtrhcm ,	cis_creusr ,		cis_updusr ,
						 cis_credat ,	cis_upddat ,	cis_pckitr ,
						 cis_seccus ,	cis_secsna ,	cis_fcurcde ,
						 cis_ftyprc ,	cis_ftycst,		cis_netselprc,
						 cis_moqchg,	cis_itmventyp,	cis_moq,
						 cis_moa,		cis_moacur,	cis_conftr ,
						 cis_contopc,	cis_pcprc,		cis_ftytmpitm,
						 cis_cusstyno,	cis_moqunttyp,	cis_qutdat,
						 cis_cus1no,	cis_cus2no,	cis_hkprctrm,
						 cis_ftyprctrm,	cis_trantrm,	cis_effdat,
						 cis_expdat)  
					values	(' ',		@cus1no,		@qud_itmno,
						 @qud_itmdsc,	@qud_cusitm,	@qud_colcde,
						 @qud_coldsc,	@qud_cuscol,	@qud_untcde,
						 @qud_inrqty,	@qud_mtrqty,	@qud_cft,
						 @qud_cft/35.3356,	@qud_qutno,	@rvsdat,
						 '',		0,		@qud_curcde,
						 @qud_cus1dp,	@qud_hrmcde,	@qud_dtyrat,
						 @qud_dept,	'U',		'',		
						 '',		'',		@qud_cususd,
						 @qud_cuscad,	@qud_inrdin,	@qud_inrwin,
						 @qud_inrhin,	@qud_mtrdin,	@qud_mtrwin,
						 @qud_mtrhin,	@qud_inrdcm,	@qud_inrwcm,
						 @qud_inrhcm,	@qud_mtrdcm,	@qud_mtrwcm,
						 @qud_mtrhcm,	@qud_creusr,	@qud_creusr,
						 getdate(),		getdate(),		@qud_pckitr,
						 @cus2no,		@cus2na,		@qud_fcurcde,
						 @qud_ftyprc,	@qud_ftycst,	@qud_cus1dp,
						 0,		@ItmVenTyp,	case @qud_moflag
											when 'Q' then @qud_moq
											else 0 end,
						 case @qud_moflag
							when 'A' then @qud_moa
							else 0 end,	@qud_curcde,	@qud_conftr ,
						 @qud_contopc,	@qud_pcprc,	isnull(@qud_ftytmpitmno,''),
						 isnull(@qud_cusstyno,''), @qud_moqunttyp,	@qud_qutdat,
						 @qud_cus1no,	@qud_cus2no,	@qud_prctrm,
						 @qud_ftyprctrm,	@qud_trantrm,	@qud_effdat,
						 @qud_expdat)  
				end
				else
				begin	
					update	CUITMSUM 	
					set 	cis_itmno = @qud_itmno,	cis_itmdsc = @qud_itmdsc, 	cis_cusitm = @qud_cusitm,
						cis_coldsc = @qud_coldsc,	cis_cuscol = @qud_cuscol,	cis_cft = @qud_cft,
						cis_cbm = @qud_cft/35.3356,	cis_refdoc = @qud_qutno,	cis_curcde = @qud_curcde,
						cis_selprc = @qud_cus1dp, 	cis_hrmcde = @qud_hrmcde,	cis_dtyrat = @qud_dtyrat,
						cis_dept = @qud_dept,		cis_cususd = @qud_cususd,	cis_cuscad = @qud_cuscad,
						cis_inrdin = @qud_inrdin,	cis_inrwin = @qud_inrwin,	cis_inrhin = @qud_inrhin,
					 	cis_mtrdin = @qud_mtrdin,	cis_mtrwin = @qud_mtrwin,	cis_mtrhin = @qud_mtrhin,
						cis_inrdcm = @qud_inrdcm,	cis_inrwcm = @qud_inrwcm,	cis_inrhcm = @qud_inrhcm,	
						cis_mtrdcm = @qud_mtrdcm,	cis_mtrwcm = @qud_mtrwcm,	cis_mtrhcm = @qud_mtrhcm,
						cis_updusr = @qud_creusr,	cis_upddat = getdate(),		cis_docdat = @rvsdat,
						cis_pckitr = @qud_pckitr,	cis_fcurcde = @qud_fcurcde,	cis_ftyprc = @qud_ftyprc,
						cis_ftycst = @qud_ftycst,	cis_netselprc = @qud_cus1dp,	cis_moqchg = 0,
						cis_itmventyp = @ItmVenTyp,	cis_moq = case @qud_moflag
											when 'Q' then @qud_moq
											else 0 end,	cis_moa = case @qud_moflag
														when 'A' then @qud_moa
														else 0 end,
						cis_moacur = @qud_curcde,	cis_contopc = @qud_contopc,	cis_pcprc = @qud_pcprc,
						cis_ftytmpitm = isnull(@qud_ftytmpitmno,''),	cis_cusstyno = isnull(@qud_cusstyno,''), cis_moqunttyp = @qud_moqunttyp,
						cis_qutdat = @qud_qutdat,	cis_cus1no = @qud_cus1no,	cis_cus2no = @qud_cus2no,
						cis_hkprctrm = @qud_prctrm,	cis_ftyprctrm = @qud_ftyprctrm,	cis_trantrm = @qud_trantrm,
						cis_effdat = @qud_effdat,	cis_expdat = @qud_expdat
					where	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)		and
						cis_seccus in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	(cbi_cusali = @cus2no or
									 cbi_cusno = @cus2no) and
									 cbi_cusno <> ''
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus2no and
									cbi_cusali <> '')		and
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 
								union
								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <>'OLD')	and
						cis_colcde = @qud_colcde				and 
						cis_untcde = @qud_untcde				and 
						cis_inrqty = @qud_inrqty 				and 
						cis_conftr = @qud_conftr 				and
						cis_mtrqty = @qud_mtrqty
				end
			end
			else  -- i.e. @cus2no = '' 	
			begin
				if (	select	count(*) 
					from 	CUITMSUM 
					where 	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)		and
						cis_seccus = @cus2no					and
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 
								union
								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <>'OLD')	and
						cis_colcde = @qud_colcde				and 
						cis_untcde = @qud_untcde 				and 
						cis_inrqty = @qud_inrqty 				and 
						cis_conftr = @qud_conftr 				and
						cis_mtrqty = @qud_mtrqty) = 0
				begin
					insert into	[CUITMSUM]
						(cis_cocde ,	cis_cusno ,		cis_itmno ,
						 cis_itmdsc ,	cis_cusitm ,	cis_colcde ,
						 cis_coldsc ,	cis_cuscol ,		cis_untcde ,
						 cis_inrqty ,	cis_mtrqty ,	cis_cft ,
						 cis_cbm ,		cis_refdoc ,		cis_docdat ,
						 cis_cussku ,	cis_ordqty ,	cis_curcde ,
						 cis_selprc ,	cis_hrmcde ,	cis_dtyrat ,
						 cis_dept ,		cis_typcode ,	cis_code1 ,	
						 cis_code2 ,	cis_code3 ,		cis_cususd ,
						 cis_cuscad ,	cis_inrdin ,		cis_inrwin ,
						 cis_inrhin ,	cis_mtrdin ,	cis_mtrwin ,
						 cis_mtrhin ,	cis_inrdcm ,	cis_inrwcm ,
						 cis_inrhcm ,	cis_mtrdcm ,	cis_mtrwcm ,
						 cis_mtrhcm ,	cis_creusr ,		cis_updusr ,
						 cis_credat ,	cis_upddat ,	cis_pckitr ,
						 cis_seccus ,	cis_secsna ,	cis_fcurcde ,
						 cis_ftyprc ,	cis_ftycst,		cis_netselprc,
					 	 cis_moqchg,	cis_itmventyp,	cis_moq,	
					 	 cis_moa,		cis_moacur	,	cis_conftr ,
						 cis_contopc, 	cis_pcprc,		cis_ftytmpitm,
						 cis_cusstyno,	cis_moqunttyp,	cis_qutdat,
						 cis_cus1no,	cis_cus2no,	cis_hkprctrm,
						 cis_ftyprctrm,	cis_trantrm,	cis_effdat,
						 cis_expdat)  
					values	(' ',		@cus1no,		@qud_itmno,
						 @qud_itmdsc,	@qud_cusitm,	@qud_colcde,
						 @qud_coldsc,	@qud_cuscol,	@qud_untcde,
						 @qud_inrqty,	@qud_mtrqty,	@qud_cft,
						 @qud_cft/35.3356,	@qud_qutno,	@rvsdat,
						 '',		0,		@qud_curcde,
						 @qud_cus1dp,	@qud_hrmcde,	@qud_dtyrat,
						 @qud_dept,	'U',		'',		
						 '',		'',		@qud_cususd,
						 @qud_cuscad,	@qud_inrdin,	@qud_inrwin,
						 @qud_inrhin,	@qud_mtrdin,	@qud_mtrwin,
						 @qud_mtrhin,	@qud_inrdcm,	@qud_inrwcm,
						 @qud_inrhcm,	@qud_mtrdcm,	@qud_mtrwcm,
						 @qud_mtrhcm,	@qud_creusr,	@qud_creusr,
						 getdate(),		getdate(),		@qud_pckitr,
						 @cus2no,		@cus2na,		@qud_fcurcde,
						 @qud_ftyprc,	@qud_ftycst,	@qud_cus1dp,
						 0,		@ItmVenTyp,	case @qud_moflag
											when 'Q' then @qud_moq
											else 0 end,
						 case @qud_moflag
							when 'A' then @qud_moa
							else 0 end,	@qud_curcde,	@qud_conftr ,
						 @qud_contopc,	@qud_pcprc,	 isnull(@qud_ftytmpitmno,''),
						 isnull(@qud_cusstyno,''), @qud_moqunttyp,	@qud_qutdat,
						 @qud_cus1no,	@qud_cus2no,	@qud_prctrm,
						 @qud_ftyprctrm,	@qud_trantrm,	@qud_effdat,
						 @qud_expdat)  
				end
				else -- i.e. CUITMSUM > 0 
				begin	
					update	CUITMSUM 	
					set 	cis_itmno = @qud_itmno,	cis_itmdsc = @qud_itmdsc, 	cis_cusitm = @qud_cusitm,
						cis_coldsc = @qud_coldsc,	cis_cuscol = @qud_cuscol,	cis_cft = @qud_cft,
						cis_cbm = @qud_cft/35.3356,	cis_refdoc = @qud_qutno,	cis_curcde = @qud_curcde,
						cis_selprc = @qud_cus1dp, 	cis_hrmcde = @qud_hrmcde,	cis_dtyrat = @qud_dtyrat,	
						cis_dept = @qud_dept,		cis_cususd = @qud_cususd,	cis_cuscad = @qud_cuscad,
						cis_inrdin = @qud_inrdin,	cis_inrwin = @qud_inrwin,	cis_inrhin = @qud_inrhin, 	
						cis_mtrdin = @qud_mtrdin,	cis_mtrwin = @qud_mtrwin,	cis_mtrhin = @qud_mtrhin,
						cis_inrdcm = @qud_inrdcm,	cis_inrwcm = @qud_inrwcm,	cis_inrhcm = @qud_inrhcm,	
						cis_mtrdcm = @qud_mtrdcm,	cis_mtrwcm = @qud_mtrwcm,	cis_mtrhcm = @qud_mtrhcm,
						cis_updusr = @qud_creusr,	cis_upddat = getdate(),		cis_docdat = @rvsdat,		
						cis_pckitr = @qud_pckitr,	cis_fcurcde = @qud_fcurcde,	cis_ftyprc = @qud_ftyprc,
						cis_ftycst = @qud_ftycst,	cis_netselprc = @qud_cus1dp,	cis_moqchg = 0,
						cis_itmventyp = @ItmVenTyp,	cis_moq = case @qud_moflag
											when 'Q' then @qud_moq
											else 0 end,	cis_moa = case @qud_moflag
														when 'A' then @qud_moa
														else 0 end,
						cis_moacur = @qud_curcde,	cis_contopc = @qud_contopc,	cis_pcprc = @qud_pcprc,
						cis_ftytmpitm = isnull(@qud_ftytmpitmno,''),	cis_cusstyno = isnull(@qud_cusstyno,''), cis_moqunttyp = @qud_moqunttyp,
						cis_qutdat = @qud_qutdat,	cis_cus1no = @qud_cus1no,	cis_cus2no = @qud_cus2no,
						cis_hkprctrm = @qud_prctrm,	cis_ftyprctrm = @qud_ftyprctrm,	cis_trantrm = @qud_trantrm,
						cis_effdat = @qud_effdat,	cis_expdat = @qud_expdat
					where	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)		and
						cis_seccus =  @cus2no 				and 
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 
								union
								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <>'OLD')	and
						cis_colcde = @qud_colcde 				and 
						cis_untcde = @qud_untcde 				and 
						cis_inrqty = @qud_inrqty 				and 
						cis_conftr = @qud_conftr 				and
						cis_mtrqty = @qud_mtrqty
				end
			end
		end	
	end
		
	--Insert into Customer Item History Detail Information
	if @qud_tbm = 'N'  
	begin
		set	@cid_seqno = (	select	isnull(max(cid_seqno),0) + 1
					from	CUITMDTL 
					where 	cid_cocde = @qud_cocde	and
						cid_cusno = @cus1no		and
						cid_seccus = @cus2no 	and
						cid_itmno = @qud_itmno 	and 
						cid_colcde = @qud_colcde 	and
						cid_inrqty = @qud_inrqty 	and 
						cid_untcde = @qud_untcde 	and
						cid_conftr = @qud_conftr)

		insert into	[CUITMDTL]
			(cid_cocde ,	cid_cusno ,		cid_seqno ,
			 cid_itmno ,	cid_itmdsc ,	cid_cusitm ,
			 cid_colcde ,	cid_coldsc ,	cid_cuscol ,
			 cid_untcde ,	cid_inrqty ,		cid_mtrqty ,
			 cid_cft ,		cid_cbm ,		cid_refdoc ,
			 cid_docdat ,	cid_cussku ,	cid_ordqty ,
			 cid_curcde ,	cid_selprc ,		cid_hrmcde ,
			 cid_dtyrat ,	cid_dept ,		cid_typcode ,
		 	 cid_code1 ,	cid_code2 ,		cid_code3 ,
			 cid_cususd ,	cid_cuscad ,	cid_inrdin ,
			 cid_inrwin ,	cid_inrhin ,		cid_mtrdin ,
			 cid_mtrwin ,	cid_mtrhin ,	cid_inrdcm ,
			 cid_inrwcm ,	cid_inrhcm ,	cid_mtrdcm ,
			 cid_mtrwcm ,	cid_mtrhcm ,	cid_onetim,
			 cid_creusr ,	cid_updusr ,	cid_credat ,
			 cid_upddat ,	cid_pckitr ,		cid_seccus ,
			 cid_secsna ,	cid_fcurcde ,	cid_ftyprc ,
			 cid_ftycst,		cid_netselprc,	cid_moqchg,
			 cid_itmventyp,	cid_moq,		cid_moa,
			 cid_moacur,	cid_conftr,		cid_contopc,
			 cid_pcprc,		cid_ftytmpitm,	cid_cusstyno,
			 cid_moqunttyp,	cid_qutdat,		cid_cus1no,
			 cid_cus2no,	cid_hkprctrm,	cid_ftyprctrm,
			 cid_trantrm,	cid_effdat,		cid_expdat)   
		values	(@qud_cocde,	@cus1no,		@cid_seqno,
			 @qud_itmno,	@qud_itmdsc,	@qud_cusitm,
			 @qud_colcde,	@qud_coldsc,	@qud_cuscol,
			 @qud_untcde,	@qud_inrqty,	@qud_mtrqty,
			 @qud_cft,		@qud_cft/35.3356,	@qud_qutno,
			 @rvsdat,		'',		0,
			 @qud_curcde,	@qud_cus1dp,	@qud_hrmcde,
			 @qud_dtyrat,	@qud_dept,	'U',
			 '',		'',		'',
			 @qud_cususd,	@qud_cuscad,	@qud_inrdin,
			 @qud_inrwin,	@qud_inrhin,	@qud_mtrdin,
			 @qud_mtrwin,	@qud_mtrhin,	@qud_inrdcm,
			 @qud_inrwcm,	@qud_inrhcm,	@qud_mtrdcm,
			 @qud_mtrwcm,	@qud_mtrhcm,	@qud_onetim,
			 @qud_creusr,	@qud_creusr,	getdate(),	
			 getdate(),		@qud_pckitr,	@cus2no,
			 @cus2na,		@qud_fcurcde,	@qud_ftyprc,
			 @qud_ftycst,	@qud_cus1dp,	0,
			 @itmventyp,	case @qud_moflag
						when 'Q' then @qud_moq
						else 0 end,	case @qud_moflag
								when 'A' then @qud_moa
								else 0 end,
			 @qud_curcde,	@qud_conftr,	@qud_contopc,
			 @qud_pcprc,	isnull(@qud_ftytmpitmno,''),	isnull(@qud_cusstyno,''),
			 @qud_moqunttyp,	@qud_qutdat,	@qud_cus1no,
			 @qud_cus2no,	@qud_prctrm,	@qud_ftyprctrm,
			 @qud_trantrm,	@qud_effdat,	@qud_expdat)  
	end
end
*/




GO
GRANT EXECUTE ON [dbo].[sp_insert_QUOTNDTL] TO [ERPUSER] AS [dbo]
GO
