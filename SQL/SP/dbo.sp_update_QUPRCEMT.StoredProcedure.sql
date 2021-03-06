/****** Object:  StoredProcedure [dbo].[sp_update_QUPRCEMT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QUPRCEMT]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QUPRCEMT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_update_QUPRCEMT] 

@qpe_cocde	nvarchar(6),	@qpe_qutno	nvarchar(20),	@qpe_qutseq	int,
@qpe_itmno	nvarchar(20),	@qpe_untcde	nvarchar(6),	@qpe_inrqty	int,
@qpe_mtrqty	int,		@qpe_cft		numeric(11,4),	@qpe_cbm		numeric(11,4),
@qpe_ftyprctrm	nvarchar(10),	@qpe_prctrm	nvarchar(10),	@qpe_trantrm	nvarchar(10),
@qpe_fml_cus1no	nvarchar(10),	@qpe_fml_cus2no	nvarchar(10),	@qpe_fml_cat		nvarchar(20),
@qpe_fml_venno	nvarchar(10),	@qpe_fml_ventranflg	char(1),		@qpe_fcurcde	nvarchar(10),
@qpe_ftycst	numeric(13, 4),	@qpe_ftyprc	numeric(13, 4),	@qpe_curcde	nvarchar(10),
@qpe_basprc	numeric(13, 4),	@qpe_mu		numeric(13, 4),	@qpe_mumin	numeric(13, 4),
@qpe_muprc	numeric(13, 4),	@qpe_muminprc	numeric(13, 4),	@qpe_cus1sp	numeric(13, 4),	@qpe_cus1dp	numeric(13, 4),
@qpe_cushcstbufper	numeric(13, 4),	@qpe_cushcstbufamt	numeric(13, 4),	@qpe_othdisper	numeric(13, 4),
@qpe_maxapvper	numeric(13, 4),	@qpe_maxapvamt	numeric(13, 4),	@qpe_spmuper	numeric(13, 4),
@qpe_dpmuper	numeric(13, 4),	@qpe_cumu	numeric(13, 4),	@qpe_pm		numeric(13, 4),
@qpe_cush	numeric(13, 4),	@qpe_thccusper	numeric(13, 4),	@qpe_upsper	numeric(13, 4),
@qpe_labper	numeric(13, 4),	@qpe_faper	numeric(13, 4),	@qpe_cstbufper	numeric(13, 4),
@qpe_othper	numeric(13, 4),	@qpe_pliper	numeric(13, 4),	@qpe_dmdper	numeric(13, 4),
@qpe_rbtper	numeric(13, 4),	@qpe_subttlper	numeric(13, 4),	@qpe_pkgper	numeric(13, 4),
@qpe_comper	numeric(13, 4),	@qpe_icmper	numeric(13, 4),	@qpe_stdprc	numeric(13,4),
@qpe_ftycstA	numeric(13, 4), @qpe_ftycstB	numeric(13, 4), @qpe_ftycstC	numeric(13, 4),
@qpe_ftycstD	numeric(13, 4), 
@qpe_ftycstE	numeric(13, 4),
@qpe_ftycstTran	numeric(13, 4), @qpe_ftycstPack	numeric(13, 4),
@qpe_lightspec	nvarchar(300), @qpe_creusr	nvarchar(30)

AS

begin

--Update QUPRCEMT Start

update	QUPRCEMT
set	qpe_itmno = @qpe_itmno,	qpe_untcde = @qpe_untcde,	qpe_inrqty = @qpe_inrqty,
	qpe_mtrqty = @qpe_mtrqty,	qpe_cft = @qpe_cft,		qpe_cbm = @qpe_cbm,
	qpe_ftyprctrm = @qpe_ftyprctrm,	qpe_prctrm = @qpe_prctrm,	qpe_trantrm = @qpe_trantrm,
	qpe_fml_cus1no = @qpe_fml_cus1no,	qpe_fml_cus2no = @qpe_fml_cus2no,	qpe_fml_cat = @qpe_fml_cat,
	qpe_fml_venno = @qpe_fml_venno,	qpe_fml_ventranflg = @qpe_fml_ventranflg,	qpe_fcurcde = @qpe_fcurcde,
	qpe_ftycst = @qpe_ftycst,	qpe_ftyprc = @qpe_ftyprc,	qpe_curcde = @qpe_curcde,
	qpe_basprc = @qpe_basprc,	qpe_mu = @qpe_mu,		qpe_mumin = @qpe_mumin,
	qpe_muprc = @qpe_muprc,		qpe_muminprc = @qpe_muminprc,	qpe_cus1sp = @qpe_cus1sp,	qpe_cus1dp = @qpe_cus1dp,
	qpe_cushcstbufper = @qpe_cushcstbufper,	qpe_cushcstbufamt = @qpe_cushcstbufamt,	qpe_othdisper = @qpe_othdisper,
	qpe_maxapvper = @qpe_maxapvper,	qpe_maxapvamt = @qpe_maxapvamt,	qpe_spmuper = @qpe_spmuper,
	qpe_dpmuper = @qpe_dpmuper,	qpe_cumu = @qpe_cumu,	qpe_pm = @qpe_pm,
	qpe_cush = @qpe_cush,	qpe_thccusper = @qpe_thccusper,	qpe_upsper = @qpe_upsper,
	qpe_labper = @qpe_labper,	qpe_faper = @qpe_faper,	qpe_cstbufper = @qpe_cstbufper,
	qpe_othper = @qpe_othper,	qpe_pliper = @qpe_pliper,	qpe_dmdper = @qpe_dmdper,
	qpe_rbtper = @qpe_rbtper,	qpe_subttlper = @qpe_subttlper,	qpe_pkgper = @qpe_pkgper,
	qpe_comper = @qpe_comper,	qpe_icmper = @qpe_icmper,	qpe_stdprc = @qpe_stdprc,
	qpe_ftycstA = @qpe_ftycstA, 	qpe_ftycstB = @qpe_ftycstB,	qpe_ftycstC = @qpe_ftycstC,
	qpe_ftycstD = @qpe_ftycstD,	
	qpe_ftycstE = @qpe_ftycstE,
	qpe_ftycstTran = @qpe_ftycstTran,	qpe_ftycstPack = @qpe_ftycstPack,
	qpe_lightspec = @qpe_lightspec,	qpe_updusr = @qpe_creusr,	qpe_upddat = getdate()
where	qpe_cocde = @qpe_cocde	and
	qpe_qutno = @qpe_qutno	and
	qpe_qutseq = @qpe_qutseq




declare @quh_qutsts as nvarchar(20)
declare @qud_itmsts as nvarchar(20)
declare @qud_qutitmsts as nvarchar(20)
declare @quh_cus1no as nvarchar(10)
declare @quh_cus2no as nvarchar(10)

declare @qud_itmnoreal as nvarchar(20)
declare @qud_apprve as nvarchar(10)
declare @qud_dv as nvarchar(10)
declare @qud_venno as nvarchar(10)
declare @qud_colcde as nvarchar(30)
declare @qud_conftr as int
declare @qud_effdat as datetime
declare @qud_expdat as datetime
declare @qud_cus1no as nvarchar(10)
declare @qud_cus2no as nvarchar(10)
declare @qud_qutdat as datetime
--declare @qud_imqutdat as datetime


-- *** Data for insert CUITMPRCDTL Start *** --
declare @qud_cusitm as nvarchar(20)
declare @qud_cusstyno as nvarchar(30)
declare @cis_cussna as nvarchar(20)
declare @cis_secsna as nvarchar(20)
declare @qud_itmdsc as nvarchar(800)
declare @qud_coldsc as nvarchar(300)
declare @qud_cuscol as nvarchar(30)
declare @qud_cft as numeric(11, 4)
declare @qud_cbm as numeric(11, 4)
declare @qud_prdven as nvarchar(10)	--ltrim(rtrim(@qud_venno))
declare @qud_cusven as nvarchar(10)
declare @qud_tv as nvarchar(10)
declare @qud_examven as nvarchar(10) --ltrim(rtrim(@qud_ftyaud))
declare @qud_qutno as nvarchar(20)
declare @qud_qutseq as int
declare @cis_cussku as nvarchar(20) SET @cis_cussku = '' -- ''
declare @cis_ordqty as int SET @cis_ordqty = 0 -- 0
declare @cis_moqchg as numeric(13, 4) SET @cis_moqchg = 0 -- 0
declare @qud_hrmcde as nvarchar(12)
declare @qud_dtyrat as numeric(6,3)
declare @qud_dept as nvarchar(20)
declare @cis_typcode as nvarchar(1) SET @cis_typcode = 'U'-- 'U'
declare @cis_code1 as nvarchar(25) SET @cis_code1 = '' -- ''
declare @cis_code2 as nvarchar(25) SET @cis_code2 = '' -- ''
declare @cis_code3 as nvarchar(25) SET @cis_code3 = '' -- ''
declare @qud_cususdcur as nvarchar(10)
declare @qud_cususd as numeric(11,4)
declare @qud_cuscadcur as nvarchar(10)
declare @qud_cuscad as numeric(11,4)
declare @qud_inrdin as numeric(11,4)
declare @qud_inrwin as numeric(11,4)
declare @qud_inrhin as numeric(11,4)
declare @qud_mtrdin as numeric(11,4)
declare @qud_mtrwin as numeric(11,4)
declare @qud_mtrhin as numeric(11,4)
declare @qud_inrdcm as numeric(11,4)
declare @qud_inrwcm as numeric(11,4)
declare @qud_inrhcm as numeric(11,4)
declare @qud_mtrdcm as numeric(11,4)
declare @qud_mtrwcm as numeric(11,4)
declare @qud_mtrhcm as numeric(11,4)
declare @qud_pckitr as nvarchar(300)
declare @qud_itmventyp as char(1) --need to get by selecting other table
declare @cis_tirtyp as char(1) SET @cis_tirtyp = '1' -- '1'
declare @qud_moqunttyp as nvarchar(6)
declare @qud_moq as int 
declare @qud_moacur as varchar(6) -- qud_curcde
declare @qud_moa as numeric(11,4)
declare @qud_contopc as nvarchar(1)
declare @qud_pcprc as numeric(13,4)
declare @qud_ftytmpitm as nvarchar(20)
declare @quh_year as nvarchar(4) --from QUOTNHDR
declare @quh_season as nvarchar(20) --from QUOTNHDR

declare @qud_creusr as nvarchar(30)
declare @qud_updusr as nvarchar(30)
declare @qud_credat as datetime
declare @qud_upddat as datetime

declare @seq_num_cuitmprcdtl as int
-- *** Data for insert CUITMPRCDTL End *** --


select 
@quh_qutsts = quh_qutsts, @quh_cus1no = quh_cus1no, @quh_cus2no = isnull(quh_cus2no,''),
@quh_year = quh_year, @quh_season = quh_season
from QUOTNHDR (nolock) where quh_cocde = @qpe_cocde and quh_qutno = @qpe_qutno

select @qud_itmnoreal = qud_itmnoreal, @qud_apprve = qud_apprve, @qud_qutitmsts = qud_qutitmsts,
@qud_itmsts = qud_itmsts,
@qud_dv = qud_dv, @qud_venno = qud_venno, @qud_colcde = qud_colcde, @qud_conftr = qud_conftr,
@qud_effdat = qud_effdat, @qud_expdat = qud_expdat,
@qud_cus1no = qud_cus1no, @qud_cus2no = qud_cus2no,
@qud_qutdat = qud_qutdat,
--Data for insert CUITMPRCDTL Start
@qud_cusitm = qud_cusitm, @qud_cusstyno = qud_cusstyno, @qud_itmdsc = qud_itmdsc,
@qud_coldsc = qud_coldsc, @qud_cuscol = qud_cuscol, @qud_cft = qud_cft,
@qud_cbm = qud_cbm, @qud_prdven = @qud_venno, @qud_cusven = qud_cusven, 
@qud_tv = qud_tv, @qud_examven = qud_ftyaud, @qud_qutno = qud_qutno,
@qud_qutseq = qud_qutseq, @qud_hrmcde = qud_hrmcde, @qud_dtyrat = qud_dtyrat, 
@qud_dept = qud_dept, @qud_cususdcur = qud_cususdcur, @qud_cususd = qud_cususd,
@qud_cuscadcur = qud_cuscadcur, @qud_cuscad = qud_cuscad, @qud_inrdin = qud_inrdin, 
@qud_inrwin = qud_inrwin, @qud_inrhin = qud_inrhin, @qud_mtrdin = qud_mtrdin, 
@qud_mtrwin = qud_mtrwin, @qud_mtrhin = qud_mtrhin, @qud_inrdcm = qud_inrdcm, 
@qud_inrwcm = qud_inrwcm, @qud_inrhcm = qud_inrhcm, @qud_mtrdcm = qud_mtrdcm, 
@qud_mtrwcm = qud_mtrwcm, @qud_mtrhcm = qud_mtrhcm, @qud_pckitr = qud_pckitr,
@qud_moqunttyp = qud_moqunttyp, @qud_moq = qud_moq, @qud_moacur = qud_curcde,
@qud_moa = qud_moa, @qud_contopc = qud_contopc, @qud_pcprc = qud_pcprc,
@qud_ftytmpitm = qud_ftytmpitm, @qud_creusr = qud_creusr, @qud_updusr = @qud_updusr, 
@qud_credat = qud_credat, @qud_upddat = qud_upddat
--Data for insert CUITMPRCDTL End
from QUOTNDTL (nolock) where qud_cocde = @qpe_cocde and qud_qutno = @qpe_qutno and qud_qutseq = @qpe_qutseq

--- Get Item Vendor Type ---
set @qud_itmventyp = isnull(
			(	select	VBI_VENTYP	 
				from	IMBASINF (NOLOCK) 
				left join VNBASINF (NOLOCK) ON VBI_VENNO = IBI_VENNO
				where	IBI_ITMNO = @qpe_itmno	and
					VBI_VENTYP IS NOT NULL),
		' ')

--- Get Customer Name For Primary and Secondary ---
if @quh_cus1no <> ''
	select @cis_cussna = cbi_cussna from CUBASINF where cbi_cusno = @quh_cus1no
else 
	select @cis_cussna = ''
	
if @quh_cus2no <> ''
	select @cis_secsna = cbi_cussna from CUBASINF where cbi_cusno = @quh_cus2no
else
	select @cis_secsna = ''
	

declare @cip_flg as char(1)

declare @cip_key_cocde as nvarchar(10)
declare @cip_key_cusno as nvarchar(10)
declare @cip_key_seccus as nvarchar(10)
declare @cip_key_itmno as nvarchar(20)
declare @cip_key_venno as nvarchar(20)
declare @cip_key_prdven as nvarchar(20)
declare @cip_key_colcde as nvarchar(30)
declare @cip_key_untcde as nvarchar(10)
declare @cip_key_conftr as int
declare @cip_key_inrqty as int
declare @cip_key_mtrqty as int
declare @cip_key_hkprctrm as nvarchar(10)
declare @cip_key_ftyprctrm as nvarchar(10)
declare @cip_key_trantrm as nvarchar(10)
declare @cip_key_effdat as datetime
declare @cip_key_expdat as datetime


set @cip_key_cocde = ''
set @cip_key_cusno = @quh_cus1no
set @cip_key_seccus = @quh_cus2no
set @cip_key_itmno = @qud_itmnoreal
set @cip_key_venno = @qud_dv
set @cip_key_prdven = @qud_venno
set @cip_key_colcde = @qud_colcde
set @cip_key_untcde = @qpe_untcde 
set @cip_key_conftr = @qud_conftr
set @cip_key_inrqty = @qpe_inrqty
set @cip_key_mtrqty = @qpe_mtrqty
set @cip_key_hkprctrm = @qpe_prctrm
set @cip_key_ftyprctrm = @qpe_ftyprctrm
set @cip_key_trantrm = @qpe_trantrm
set @cip_key_effdat = @qud_effdat
set @cip_key_expdat = @qud_expdat


if @qud_itmnoreal <> '' and @qud_qutitmsts = 'A' and @qud_itmsts <> 'TBC' --and @quh_qutsts = 'A' and @qud_qutitmsts = 'A - Active'	and (@qud_apprve = '' or @qud_apprve = 'Y')
	set @cip_flg = 'Y'
else
	set @cip_flg = 'N'



if @cip_flg = 'Y'
begin
	-- Insert / Update CUITMPRC


	
	if ((select count(*) from CUITMPRC (nolock) 
			where 	cip_cocde = @cip_key_cocde and 
				cip_cusno = @cip_key_cusno and
				cip_seccus = @cip_key_seccus and
				cip_itmno = @cip_key_itmno and
				cip_venno = @cip_key_venno and
				--cip_prdven = @cip_key_prdven and
				cip_colcde = @cip_key_colcde and
				cip_untcde = @cip_key_untcde and
				cip_conftr = @cip_key_conftr and
				cip_inrqty = @cip_key_inrqty and
				cip_mtrqty = @cip_key_mtrqty and
				cip_hkprctrm = @cip_key_hkprctrm and
				cip_ftyprctrm = @cip_key_ftyprctrm and
				cip_trantrm = @cip_key_trantrm and
		--		cip_effdat = @cip_key_effdat and
		--		cip_expdat = @cip_key_expdat ) = 0 ) 
				left(convert(varchar(20),cip_effdat,111),10) = left(convert(varchar(20),@cip_key_effdat,111),10) and
				left(convert(varchar(20),cip_expdat,111),10) = left(convert(varchar(20),@cip_key_expdat,111),10)) = 0)

	begin
		insert into CUITMPRC 
		(cip_cocde,cip_cusno,cip_seccus,cip_itmno,cip_venno,
		cip_prdven,cip_colcde,cip_untcde,cip_conftr,cip_inrqty,
		cip_mtrqty,cip_hkprctrm,cip_ftyprctrm,cip_trantrm,cip_cus1no,
		cip_cus2no,cip_effdat,cip_expdat,cip_refdoc,cip_refseq,
		cip_docdat,cip_fcurcde,cip_ftycst,cip_bomcst,cip_ftyprc,
		cip_curcde,cip_basprc,cip_markup,cip_mrkprc, cip_mumin, cip_muminprc, cip_pckcst,
		cip_commsn,cip_itmcom,cip_stdprc,cip_discnt,cip_adjprc, cip_pcprc,
		cip_qutdat,cip_imqutdat,cip_creusr,cip_updusr,cip_credat,
		cip_upddat)
		values
		(@cip_key_cocde,@cip_key_cusno,@cip_key_seccus,@cip_key_itmno,@cip_key_venno,
		@cip_key_prdven,@cip_key_colcde,@cip_key_untcde,@cip_key_conftr,@cip_key_inrqty,
		@cip_key_mtrqty,@cip_key_hkprctrm,@cip_key_ftyprctrm,@cip_key_trantrm,@qud_cus1no,
		@qud_cus2no,@cip_key_effdat,@cip_key_expdat,@qpe_qutno,@qpe_qutseq,
		getdate(),@qpe_fcurcde,@qpe_ftycst,0,@qpe_ftyprc,
		@qpe_curcde,@qpe_basprc,@qpe_mu,@qpe_muprc,@qpe_mumin,@qpe_muminprc,@qpe_pkgper,
		@qpe_comper,@qpe_icmper,@qpe_cus1sp,0,@qpe_cus1dp, @qud_pcprc,
		@qud_qutdat,'1900/01/01',@qpe_creusr,@qpe_creusr,getdate(),
		getdate())
		
		-- Update other PV Prices in CIH
		update CUITMPRC set 
		cip_cus1no = @qud_cus1no,
		cip_cus2no = @qud_cus2no,
		cip_refdoc = @qpe_qutno,
		cip_refseq = @qpe_qutseq,
		cip_docdat = getdate(),
		cip_fcurcde = @qpe_fcurcde,
		cip_ftycst = @qpe_ftycst,
--		cip_bomcst = 0,
		cip_ftyprc = @qpe_ftyprc,
		cip_curcde = @qpe_curcde,
		cip_basprc = @qpe_basprc,
		cip_markup = @qpe_mu,
		cip_mrkprc = @qpe_muprc,
		cip_mumin = @qpe_mumin,
		cip_muminprc = @qpe_muminprc,
		cip_pckcst = @qpe_pkgper,
		cip_commsn = @qpe_comper,
		cip_itmcom = @qpe_icmper,
		cip_pcprc = @qud_pcprc,
		cip_stdprc = @qpe_cus1sp,
--		cip_discnt = 0,
		cip_adjprc = @qpe_cus1dp,
		cip_qutdat = @qud_qutdat,
--		cip_imqutdat = '1900/01/01',
		cip_updusr = @qpe_creusr,
		cip_upddat = getdate()
		where 
		cip_cocde = @cip_key_cocde and
		cip_cusno = @cip_key_cusno and
		cip_seccus = @cip_key_seccus and
		cip_itmno = @cip_key_itmno and
		cip_venno = @cip_key_venno and
		cip_prdven <> @cip_key_prdven and
		cip_colcde = @cip_key_colcde and
		cip_untcde = @cip_key_untcde and
		cip_conftr = @cip_key_conftr and
		cip_inrqty = @cip_key_inrqty and
		cip_mtrqty = @cip_key_mtrqty and
		cip_hkprctrm = @cip_key_hkprctrm and
		cip_ftyprctrm = @cip_key_ftyprctrm and
		cip_trantrm = @cip_key_trantrm and
--		cip_effdat = @cip_key_effdat and
--		cip_expdat = @cip_key_expdat
		left(convert(varchar(20),cip_effdat,111),10) = left(convert(varchar(20),@cip_key_effdat,111),10) and
		left(convert(varchar(20),cip_expdat,111),10) = left(convert(varchar(20),@cip_key_expdat,111),10)
	end
	else
	begin

		update CUITMPRC set 
		cip_cus1no = @qud_cus1no,
		cip_cus2no = @qud_cus2no,
		cip_refdoc = @qpe_qutno,
		cip_refseq = @qpe_qutseq,
		cip_docdat = getdate(),
		cip_fcurcde = @qpe_fcurcde,
		cip_ftycst = @qpe_ftycst,
--		cip_bomcst = 0,
		cip_ftyprc = @qpe_ftyprc,
		cip_curcde = @qpe_curcde,
		cip_basprc = @qpe_basprc,
		cip_markup = @qpe_mu,
		cip_mrkprc = @qpe_muprc,
		cip_mumin = @qpe_mumin,
		cip_muminprc = @qpe_muminprc,
		cip_pckcst = @qpe_pkgper,
		cip_commsn = @qpe_comper,
		cip_itmcom = @qpe_icmper,
		cip_pcprc = @qud_pcprc,
		cip_stdprc = @qpe_cus1sp,
--		cip_discnt = 0,
		cip_adjprc = @qpe_cus1dp,
		cip_qutdat = @qud_qutdat,
--		cip_imqutdat = '1900/01/01',
		cip_updusr = @qpe_creusr,
		cip_upddat = getdate()
		where 
		cip_cocde = @cip_key_cocde and
		cip_cusno = @cip_key_cusno and
		cip_seccus = @cip_key_seccus and
		cip_itmno = @cip_key_itmno and
		cip_venno = @cip_key_venno and
		--cip_prdven = @cip_key_prdven and
		cip_colcde = @cip_key_colcde and
		cip_untcde = @cip_key_untcde and
		cip_conftr = @cip_key_conftr and
		cip_inrqty = @cip_key_inrqty and
		cip_mtrqty = @cip_key_mtrqty and
		cip_hkprctrm = @cip_key_hkprctrm and
		cip_ftyprctrm = @cip_key_ftyprctrm and
		cip_trantrm = @cip_key_trantrm and
--		cip_effdat = @cip_key_effdat and
--		cip_expdat = @cip_key_expdat
		left(convert(varchar(20),cip_effdat,111),10) = left(convert(varchar(20),@cip_key_effdat,111),10) and
		left(convert(varchar(20),cip_expdat,111),10) = left(convert(varchar(20),@cip_key_expdat,111),10)

	end

	--- Get Greatest number of seq number in CUITMPRCDTL
	Set  @seq_num_cuitmprcdtl = (	select	isnull(max(cid_seqnum),0) + 1
		from	CUITMPRCDTL
		where	
			cid_cusno = @cip_key_cusno and
			cid_seccus = @cip_key_seccus and
			cid_itmno = @cip_key_itmno and
			cid_colcde = @cip_key_colcde and
			cid_untcde = @cip_key_untcde and
			cid_conftr = @cip_key_conftr and
			cid_inrqty = @cip_key_inrqty and
			cid_mtrqty = @cip_key_mtrqty and
			cid_hkprctrm = @cip_key_hkprctrm and
			cid_ftyprctrm = @cip_key_ftyprctrm and
			cid_trantrm = @cip_key_trantrm	
			)
			
	if @qud_apprve = ''
		set @qud_apprve = 'N'
	else if @qud_apprve = 'N'
		set @qud_apprve = 'W'
	else if @qud_apprve = 'Y'
		set @qud_apprve = 'Y'

	insert into CUITMPRCDTL(
		cid_cocde, cid_cusno, cid_seccus, cid_itmno,
		cid_colcde, cid_untcde, cid_conftr, cid_inrqty,
		cid_mtrqty, cid_hkprctrm, cid_ftyprctrm, cid_trantrm,
		
		cid_seqnum, cid_refdoc, cid_refseq, cid_docdat, cid_apvsts, cid_qutitmsts,
		--Data Part Start
		cis_cussna, cis_secsna,
		cis_itmdsc, cis_coldsc, cis_cuscol, cid_cusitm, cid_cusstyno,
		cis_venno, cis_prdven, cis_cusven, cis_tradeven, cis_examven,
	
		cis_cususdcur, cis_cususd, cis_cuscadcur, cis_cuscad,
		
		cis_inrdin, cis_inrwin, cis_inrhin, cis_mtrdin, cis_mtrwin, 
		cis_mtrhin, cis_inrdcm, cis_inrwcm, cis_inrhcm, cis_mtrdcm, 
		cis_mtrwcm, cis_mtrhcm, 
		cis_cft, cis_cbm, cis_pckitr,
		
		cis_itmventyp, cis_tirtyp, cis_moqunttyp, cis_moq, cis_moacur, cis_moa,
		cis_year, cis_season, 
		cis_ftytmpitm, cis_contopc, cis_pcprc,
		--Data Part End	
		--Price Part Start
		cid_effdat, cid_expdat, cid_cus1no, cid_cus2no,
		cip_fcurcde, cip_ftycst, cip_bomcst, cip_ftyprc,
		cip_curcde, cip_basprc, cip_markup, cip_mrkprc, 
		cip_pckcst, cip_commsn, cip_itmcom, cip_stdprc, 
		cip_mumin, cip_muminprc, cip_discnt, cip_adjprc, 
		cip_qutdat,
		--Price Part End
		
		--Other Part Start
		cid_mode, cid_creusr, cid_updusr, cid_credat, cid_upddat
		--Other Part End
	)
	values(
		@cip_key_cocde,@cip_key_cusno,@cip_key_seccus,@cip_key_itmno,
		@cip_key_colcde,@cip_key_untcde,@cip_key_conftr,@cip_key_inrqty,
		@cip_key_mtrqty,@cip_key_hkprctrm,@cip_key_ftyprctrm,@cip_key_trantrm,
		--@cip_key_venno,@cip_key_effdat,@cip_key_expdat,
		
		@seq_num_cuitmprcdtl, @qpe_qutno, @qpe_qutseq, getdate(), @qud_apprve, @qud_qutitmsts,--cid_docdat
		--Data Part Start
		@cis_cussna, @cis_secsna,
		@qud_itmdsc, @qud_coldsc, @qud_cuscol, @qud_cusitm, @qud_cusstyno,
		@cip_key_venno, @qud_prdven, @qud_cusven, @qud_tv, @qud_examven,
		
		@qud_cususdcur, @qud_cususd, @qud_cuscadcur, @qud_cuscad,
		
		@qud_inrdin, @qud_inrwin, @qud_inrhin, @qud_mtrdin, @qud_mtrwin, 
		@qud_mtrhin, @qud_inrdcm, @qud_inrwcm, @qud_inrhcm, @qud_mtrdcm, 
		@qud_mtrwcm, @qud_mtrhcm, 
		@qud_cft, @qud_cbm, @qud_pckitr,
		
		@qud_itmventyp, @cis_tirtyp, @qud_moqunttyp, @qud_moq, @qud_moacur, @qud_moa, 
		@quh_year, @quh_season,
		@qud_ftytmpitm, @qud_contopc, @qud_pcprc,
		
		@cip_key_effdat,@cip_key_expdat, @qud_cus1no, @qud_cus2no,	
		--Data Part End
		--Price Part Start
		@qpe_fcurcde, @qpe_ftycst, 0, @qpe_ftyprc,
		@qpe_curcde, @qpe_basprc, @qpe_mu, @qpe_muprc,
		@qpe_pkgper, @qpe_comper, @qpe_icmper,@qpe_cus1sp,
		@qpe_mumin, @qpe_muminprc, 0, @qpe_cus1dp,
		@qud_qutdat,
		--Price Part End
		--Other Part Start
		'QU', @qud_creusr, @qud_creusr, @qud_credat, @qud_credat
		--Other Part End
		
	)


	
end


end



GO
GRANT EXECUTE ON [dbo].[sp_update_QUPRCEMT] TO [ERPUSER] AS [dbo]
GO
