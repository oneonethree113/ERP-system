/****** Object:  StoredProcedure [dbo].[sp_select_SCM00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCM00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCM00002]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE  PROCEDURE [dbo].[sp_select_SCM00002] 

@cocde	nvarchar(6),
@from	nvarchar(20),
@to	nvarchar(20),
@fntyp	nvarchar(1),
@usrid	nvarchar(30)

AS
BEGIN

declare @feed varchar(10)
set @feed = '
'

if @fntyp = 'Y' 
begin

	DECLARE 
	@rate		numeric(13,11),
	@rate1		numeric(13,11),
	@tmpamt		numeric(13,4),
	@ShpStartDate	datetime,
	@ShpendDate	datetime,
	@CanDatStr	datetime,
	@canDatEnd	datetime
	
	DECLARE -- SCORDDTLHDR
	@sco_ordno	nvarchar(20),
	@sco_cusven	nvarchar(6),
	@sco_purord	nvarchar(20),
	@sco_purseq	int,
	@sco_ttlctn	int,
	@sco_ttlamt	numeric(13,4)
	--@sco_rmk nvarchar(400)
	
	DECLARE -- SCORDDTL
	@sdt_fcurcde	nvarchar(6),
	@sdt_itmsts	nvarchar(4),
	@sdt_venno	nvarchar(6),
	@sdt_tradeven	nvarchar(6),
	@sdt_examven	nvarchar(6),
	@sdt_cusven	nvarchar(6),
	@sdt_purord	nvarchar(20),
	@sdt_purseq	int,
	@sdt_cocde	nvarchar(6),
	@sdt_ordno	nvarchar(20),
	@sdt_ordseq	int,
	@sdt_updpo	nvarchar(1),
	@sdt_chgfty	nvarchar(1),
	@sdt_itmno	nvarchar(20),
	@sdt_itmtyp	nvarchar(4),
	@sdt_itmdsc	nvarchar(800),
	@sdt_colcde	nvarchar(30),
	@sdt_cuscol	nvarchar(30),
	@sdt_coldsc	nvarchar(300),
	@sdt_pckseq	int,
	@sdt_pckunt	nvarchar(6),
	@sdt_inrctn	int,
	@sdt_mtrctn	int,
	@sdt_cft	numeric(11,4),
	@sdt_cbm	numeric(11,4),
	@sdt_qutno	nvarchar(20),
	@sdt_refdat	datetime,
	@sdt_cusitm	nvarchar(20),
	@sdt_cussku	nvarchar(20),
	@sdt_resppo	nvarchar(20),
	@sdt_cuspo	nvarchar(20),
	@sdt_ordqty	int,
	@sdt_discnt	numeric(6,3),
	@sdt_ftyprc	numeric(13,4),
	@sdt_ftycst	numeric(13,4),
	@sdt_oneprc	nvarchar(1),
	@sdt_curcde	nvarchar(6),
	@sdt_selprc	numeric(13,4),
	@sdt_hrmcde	nvarchar(12),
	@sdt_dtyrat	numeric(6,3),
	@sdt_dept	nvarchar(20),
	@sdt_typcode	nvarchar(1),
	@sdt_Code1	nvarchar(25),
	@sdt_Code2	nvarchar(25),
	@sdt_Code3	nvarchar(25),
	@sdt_cususdcur	nvarchar(6),
	@sdt_cususd	numeric(13,4),
	@sdt_cuscadcur	nvarchar(6),
	@sdt_cuscad	numeric(13,4),
	@sdt_inrdin	numeric(11,4),
	@sdt_inrwin	numeric(11,4),
	@sdt_inrhin	numeric(11,4),
	@sdt_mtrdin	numeric(11,4),
	@sdt_mtrwin	numeric(11,4),
	@sdt_mtrhin	numeric(11,4),
	@sdt_inrdcm	numeric(11,4),
	@sdt_inrwcm	numeric(11,4),
	@sdt_inrhcm	numeric(11,4),
	@sdt_mtrdcm	numeric(11,4),
	@sdt_mtrwcm	numeric(11,4),
	@sdt_mtrhcm	numeric(11,4),
	@sdt_shpstr	datetime,
	@sdt_shpend	datetime,
	@sdt_candat	datetime,
	@sdt_posstr	datetime,
	@sdt_posend	datetime,
	@sdt_poscan	datetime,
	@sdt_ctnstr	int,
	@sdt_ctnend	int,
	@sdt_ttlctn	int,
	@sdt_rmk	nvarchar(300),
	@sdt_pormk	nvarchar(300),
	@sdt_invqty	int,
	@sdt_shpqty	int,
	@sdt_subcde	nvarchar(10),
	@sdt_cussub	nvarchar(10),
	@sdt_venitm	nvarchar(20),
	@sdt_pckitr	nvarchar(300),
	@sdt_oldpurord	nvarchar(20),
	@sdt_oldpurseq	int,
	@sdt_pjobno	varchar(20),
	@sdt_seccusitm	varchar(20),
	@sod_alsitmno	varchar(20),
	@sod_alscolcde	varchar(30),
	@sod_qutdat	datetime,
	@sod_imqutdat	datetime,
	@sdt_cus1no	nvarchar(6),
	@sdt_cus2no	nvarchar(6),
	@sdt_ftyprctrm	nvarchar(10),
	@sdt_hkprctrm	nvarchar(10),
	@sdt_trantrm	nvarchar(10),
	@sod_itmchidsc	nvarchar(800)

	DECLARE 
	@ret_code	nvarchar(20),
	@vbi_tsttim	int,
	@vbi_bufday	int
	
	DECLARE -- POORDHDR
	@poh_cocde	nvarchar(6),
	@poh_purord	nvarchar(20),
	@poh_pursts	nvarchar(3),
	@poh_issdat	datetime,
	@poh_venno	nvarchar(6),
	@poh_puradr	nvarchar(200),
	@poh_purstt	nvarchar(20),
	@poh_purcty	nvarchar(6),
	@poh_purpst	nvarchar(20),
	@poh_porctp	nvarchar(20),
	@poh_puragt	nvarchar(6),
	@poh_salrep	nvarchar(30),
	@poh_srname	nvarchar(30),
	@poh_saltem	nvarchar(10),
	@poh_saldiv	nvarchar(20),
	@poh_prmcus	nvarchar(6),
	@poh_seccus	nvarchar(6),
	@poh_shpadr	nvarchar(200),
	@poh_shpstt	nvarchar(20),
	@poh_shpcty	nvarchar(6),
	@poh_shppst	nvarchar(20),
	@poh_prctrm	nvarchar(20),
	@poh_paytrm	nvarchar(20),
	@poh_ttlcbm	numeric(13,4),
	@poh_ttlctn	int,
	@poh_curcde	nvarchar(6),
	@poh_ttlamt	numeric(13,4),
	@poh_discnt	numeric(6,3),
	@poh_netamt	numeric(13,4),
	@poh_spoflg	nvarchar(1),
	@poh_cuspno	nvarchar(20),
	@poh_cpodat	datetime,
	@poh_reppno	nvarchar(20),
	@poh_pocdat	datetime,
	@poh_pocdatend	datetime,
	@poh_shpstr	datetime,
	@poh_shpend	datetime,
	@poh_lbldue	datetime,
	@poh_lblven	nvarchar(20),
	@poh_rmk	nvarchar(400),
	@poh_purchnadr	nvarchar(255),
	@poh_cusctn	int,
	@poh_dest	nvarchar(30)
	
	DECLARE -- POORDDTL
	@pod_cocde	nvarchar(6),
	@pod_purord	nvarchar(20),
	@pod_purseq	int,
	@pod_itmno	nvarchar(20),
	@pod_itmsts	nvarchar(1),
	@pod_venitm	nvarchar(20),
	@pod_cusitm	nvarchar(20),
	@pod_cussku	nvarchar(20),
	@pod_engdsc	nvarchar(800),
	@pod_chndsc	nvarchar(1600),
	@pod_vencol	nvarchar(30),
	@pod_cuscol	nvarchar(30),
	@pod_coldsc	nvarchar(300),
	@pod_pckseq	int,
	--@pod_untcde nvarchar(4),
	@pod_untcde	nvarchar(6),
	@pod_inrctn	int,
	@pod_mtrctn	int,
	@pod_cubcft	numeric(11,4),
	@pod_cbm	numeric(11,4),
	@pod_dept	nvarchar(20),
	@pod_ordqty	int,
	@pod_recqty	int,
	@pod_ftyprc	numeric(13,4),
	@pod_cuspno	nvarchar(20),
	@pod_respno	nvarchar(20),
	@pod_hrmcde	nvarchar(20),
	-- @pod_lblcde nvarchar(20),
	-- Frankie Cheung 20100524
	@pod_lblcde	nvarchar(75),
	@pod_cususdcur	nvarchar(6),
	@pod_cususd	numeric(13,4),
	@pod_cuscadcur	nvarchar(6),
	@pod_cuscad	numeric(13,4),
	@pod_shpstr	datetime,
	@pod_shpend	datetime,
	@pod_candat	datetime,
	@pod_ctnstr	int,
	@pod_ctnend	int,
	@pod_scno	nvarchar(20),
	@pod_ttlctn	int,
	@pod_lneamt	numeric(13,4),
	@pod_lnecub	numeric(13,4),
	@pod_ttlqty	int,
	@pod_scline	int,
	@pod_jobord	nvarchar(20),
	@pod_runno	nvarchar(20),
	@pod_assflg	nvarchar(1),
	@pod_updusr	nvarchar(30),
	@pod_upddat	datetime,
	@pod_prdven	varchar(6),
	@pod_tradeven	varchar(6),
	@pod_examven	varchar(6),
	@pod_prdsubcde	varchar(10),
	@pod_seccusitm	varchar(20),
	@dtyrat		numeric(6,3),
	@typcode	nvarchar(1),
	@code1		nvarchar(25),
	@code2		nvarchar(25),
	@code3		nvarchar(25),
	@pod_pckitr	nvarchar(300),
	@pod_rmk	nvarchar(300)
	
	DECLARE -- POSHPMRK
	@psm_shptyp	nvarchar(30),
	@psm_engdsc	nvarchar(1600),
	@psm_chndsc	nvarchar(3200),
	@psm_engrmk	nvarchar(1600),
	@psm_chnrmk	nvarchar(3200),
	@psm_imgpth	nvarchar(200),
	@psm_imgnam	nvarchar(30)
	
	DECLARE -- POCNTINF
	@pci_cocde	nvarchar(6),
	@pci_purord	nvarchar(20),
	@pci_csenam	nvarchar(20),
	@pci_cseadr	nvarchar(200),
	@pci_csestt	nvarchar(20),
	@pci_csecty	nvarchar(20),
	@pci_csezip	nvarchar(20),
	@pci_fwdtyp	nvarchar(2),
	@pci_fwdacc	nvarchar(20),
	@pci_fwddsc	nvarchar(200),
	@pci_fwditr	nvarchar(20),
	@pci_noptyp	nvarchar(2),
	@pci_nopadr	nvarchar(200),
	@pci_nopstt	nvarchar(20),
	@pci_nopcty	nvarchar(20),
	@pci_nopzip	nvarchar(20),
	@pci_noptil	nvarchar(20),
	@pci_nopphn	nvarchar(30),
	@pci_nopfax	nvarchar(30),
	@pci_nopeml	nvarchar(50)
	
	DECLARE
	@pda_itmno	nvarchar(20),
	@pda_assitm	nvarchar(20),
	@pda_assdsc	nvarchar(800),
	@pda_cusitm	nvarchar(20),
	@pda_colcde	nvarchar(30),
	@pda_coldsc	nvarchar(300),
	@pda_cussku	nvarchar(20),
	@pda_upcean	nvarchar(15),
	@pda_cusrtl	nvarchar(20),
	@pda_pckunt	nvarchar(6),
	@pda_inrqty	int,
	@pda_mtrqty	int,
	@pda_imperiod	datetime,
	@pda_cusstyno	nvarchar(30)
	
	
	DECLARE 
	@pdc_cocde	nvarchar(6),
	@pdc_purord	nvarchar(20),
	@pdc_seq	int,
	@pdc_from	int,
	@pdc_to		int,
	@pdc_ttlctn	int
	
	DECLARE -- PODTLSHP
	@pds_cocde	nvarchar(6),
	@pds_purord	nvarchar(20),
	@pds_seq	int,
	@pds_scfrom	datetime,
	@pds_scto	datetime,
	@pds_pofrom	datetime,
	@pds_poto	datetime,
	@pds_ttlctn	int,
	@pds_ordqty	int,
	@pds_ctnstr	int,
	@pds_ctnend	int,
	@pds_dest	nvarchar(50)
	
	DECLARE -- PODTLBOM
	@pdb_cocde	nvarchar(6),
	@pdb_purord	nvarchar(20),
	@pdb_seq	int,
	@pdb_assitm	nvarchar(20),
	@pdb_bomitm	nvarchar(20),
	@pdb_colcde	nvarchar(30),
	--@pdb_pckunt nvarchar(4),
	@pdb_pckunt	nvarchar(6),
	@pdb_bomqty	int,
	@pdb_venno	nvarchar(6),
	@pdb_ordqty	int,
	@pdb_bomcst	numeric(13,4),
	@pdb_bcurcde	varchar(6),
	@pdb_imftyprc	numeric(13,4),
	@pdb_imcurcde	varchar(6),
	@pdb_curcde	varchar(6),
	@pdb_ftyprc	numeric(13,4),
	@pdb_bompoflg	char(1),
	@pdb_imperiod	datetime
	
	DECLARE
	@imu_curcde	nvarchar(6),
	@imu_ftyprc	numeric(13,4),
	@imu_bcurcde	nvarchar(6),
	@imu_ftycst	numeric(13,4),
	@vbi_curcde	nvarchar(6),
	
	-- Modified by Solo So as at 03-03-2002 
	-- exist flag of PO for no insert of PO Header
	@po_exist	int,
	@VendorType	char(1)
	
	DECLARE
	@startflag	int
		
	DECLARE
	@SC_ORD_NO	nvarchar(20)
		
	DECLARE
	@exeffdat	datetime,
	@exeffdat_old	datetime,
	@rate_old	numeric(13,11),
	@ftyexrate_old	numeric(13,11),
	@bomexrate_old	numeric(13,11),
	@rateffdat	datetime
	
	DECLARE
	@testex		nvarchar(1),
	@debug		nvarchar(1)
	
	--For CUITMPRCDTL Start
	declare @seq_num_cuitmprcdtl as int

	declare @cid_cusno nvarchar(6)
	declare @cid_seccus nvarchar(6)
	declare @cid_itmno nvarchar(20)
	declare @cid_colcde nvarchar(30)
	declare @cid_untcde nvarchar(6)
	declare @cid_conftr numeric(18,0)
	declare @cid_inrqty int
	declare @cid_mtrqty int
	declare @cid_hkprctrm nvarchar(10)
	declare @cid_ftyprctrm nvarchar(10)
	declare @cid_trantrm nvarchar(10)

	declare @cid_refseq int
	declare @cid_apvsts nvarchar(10)
	declare @cis_itmventyp char(1)
	
	declare @cid_verno int
	
	--For CUITMPRCDTL END
	
	set @startflag = 0
	set @testex = 1	 -- use multi-currency exchange
	set @debug = 1 -- use debug


	
	-- New SC PO Ship Date Calculation 20151116
	declare @csf_cus1no nvarchar(10), @csf_cus2no nvarchar(10)
	declare @csf_shpstrbuf int, @csf_shpendbuf int, @csf_cancelbuf int, @ventyp nvarchar(10)
	set @csf_cus1no = ''
	set @csf_cus2no = ''
	set @csf_shpstrbuf = 0
	set @csf_shpendbuf = 0
	set @csf_cancelbuf = 0
	set @ventyp = ''


	DECLARE cur_SCORDDTLHDR CURSOR FOR
	select	distinct
		d.sod_ordno,
		d.sod_cusven
	from	SCORDDTL d (nolock), SCORDHDR h(nolock)
	where	h.soh_ordsts = 'ACT' AND
		h.soh_ordno >= @from AND
		h.soh_ordno <= @to AND
		h.soh_cocde = @cocde AND
		--d.sod_updpo = 'Y' AND **TBD 
		d.sod_ordno = h.soh_ordno AND
		d.sod_cocde = h.soh_cocde 
	group by
		d.sod_ordno, d.sod_cusven 
	order by 
		d.sod_ordno, d.sod_cusven 
	
	OPEN cur_SCORDDTLHDR
	FETCH NEXT FROM cur_SCORDDTLHDR INTO 
	@sco_ordno,	@sco_cusven

	if @@fetch_status <> 0 AND @startflag = 0
	begin
		select 'Order No. Not Found'
		return(99)
	end

	while @@fetch_status = 0
	begin

		select @csf_cus1no = soh_cus1no, @csf_cus2no = soh_cus2no from SCORDHDR (nolock) where soh_ordno = @sco_ordno
		select @ventyp = case vbi_ventyp when 'E' then 'EXT' else 'INT' end from VNBASINF (nolock) where vbi_venno = @sco_cusven
	
		if (select count(*) from CUSHPFML where csf_cus1no = @csf_cus1no and csf_cus2no = @csf_cus2no and csf_venno = @sco_cusven) = 1
		begin
			select @csf_shpstrbuf = csf_shpstrbuf, @csf_shpendbuf = csf_shpendbuf, @csf_cancelbuf = csf_cancelbuf
			from CUSHPFML where csf_cus1no = @csf_cus1no and csf_cus2no = @csf_cus2no and csf_venno = @sco_cusven
		end
		else if (select count(*) from CUSHPFML where csf_cus1no = @csf_cus1no and csf_cus2no = @csf_cus2no and csf_venno = @ventyp) = 1
		begin
			select @csf_shpstrbuf = csf_shpstrbuf, @csf_shpendbuf = csf_shpendbuf, @csf_cancelbuf = csf_cancelbuf
			from CUSHPFML where csf_cus1no = @csf_cus1no and csf_cus2no = @csf_cus2no and csf_venno = @ventyp
		end
		else if (select count(*) from CUSHPFML where csf_cus1no = @csf_cus1no and csf_cus2no = '' and csf_venno = @sco_cusven) = 1
		begin
			select @csf_shpstrbuf = csf_shpstrbuf, @csf_shpendbuf = csf_shpendbuf, @csf_cancelbuf = csf_cancelbuf
			from CUSHPFML where csf_cus1no = @csf_cus1no and csf_cus2no = '' and csf_venno = @sco_cusven
		end
		else
		begin
			select @csf_shpstrbuf = csf_shpstrbuf, @csf_shpendbuf = csf_shpendbuf, @csf_cancelbuf = csf_cancelbuf
			from CUSHPFML where csf_cus1no = @csf_cus1no and csf_cus2no = '' and csf_venno = @ventyp
		end

		--cur_SCORDDTLHDR --> cur_SCORDDTL 
		set @startflag = 1
		DECLARE cur_SCORDDTL CURSOR FOR 
		select	sod_fcurcde,	sod_itmsts,	sod_cusven, 
			sod_purord,	sod_purseq,	sod_cocde,
			sod_ordno,	sod_ordseq,	sod_updpo,
			sod_chgfty,	sod_itmno,	sod_itmtyp,
			sod_itmdsc,	sod_colcde,	sod_cuscol,
			sod_coldsc,	sod_pckseq,	sod_pckunt,
			sod_inrctn,	sod_mtrctn,	sod_cft,
			sod_cbm,	sod_qutno,	sod_refdat,
			sod_cusitm,	sod_cussku,	sod_resppo,
			sod_cuspo,	sod_ordqty,	sod_discnt,
			sod_oneprc,	sod_curcde,	sod_selprc,
			sod_hrmcde,	sod_dtyrat,	sod_dept,
			sod_typcode,	sod_Code1,	sod_Code2,
			sod_Code3,	sod_cususd,	sod_cuscad,
			sod_inrdin,	sod_inrwin,	sod_inrhin,
			sod_mtrdin,	sod_mtrwin,	sod_mtrhin,
			sod_inrdcm,	sod_inrwcm,	sod_inrhcm,
			sod_mtrdcm,	sod_mtrwcm,	sod_mtrhcm,
			sod_shpstr,	sod_shpend,	sod_candat,
			sod_ctnstr,	sod_ctnend,	sod_ttlctn,
			sod_rmk,	sod_invqty,	sod_shpqty,
			sod_ftyprc,	sod_ftycst,	sod_subcde,
			sod_venitm,	sod_pckitr,	sod_oldpurord,
			sod_oldpurseq,	sod_cusven,	sod_cussub,
			sod_pjobno,	sod_seccusitm,	sod_venno,
			sod_alsitmno,	sod_alscolcde,	sod_qutdat,
			sod_imqutdat,	sod_tradeven,	sod_examven,
			sod_posstr,	sod_posend,	sod_poscan,
			sod_cususdcur,	sod_cuscadcur,	sod_pormk,
			sod_cus1no,	sod_cus2no,	sod_ftyprctrm,
			sod_hkprctrm,	sod_trantrm, sod_itmchidsc
		FROM	SCORDDTL (nolock) 
		WHERE	sod_ordno = @sco_ordno and
			sod_cusven = @sco_cusven and
			sod_cocde = @cocde
		ORDER BY sod_purord desc, sod_purseq, sod_itmno

		OPEN cur_SCORDDTL
		FETCH NEXT FROM cur_SCORDDTL INTO 
		@sdt_fcurcde,	@sdt_itmsts,	@sdt_cusven, 
		@sdt_purord,	@sdt_purseq,	@sdt_cocde,
		@sdt_ordno,	@sdt_ordseq,	@sdt_updpo,
		@sdt_chgfty,	@sdt_itmno,	@sdt_itmtyp,
		@sdt_itmdsc,	@sdt_colcde,	@sdt_cuscol,
		@sdt_coldsc,	@sdt_pckseq,	@sdt_pckunt,
		@sdt_inrctn,	@sdt_mtrctn,	@sdt_cft,
		@sdt_cbm,	@sdt_qutno,	@sdt_refdat,
		@sdt_cusitm,	@sdt_cussku,	@sdt_resppo,
		@sdt_cuspo,	@sdt_ordqty,	@sdt_discnt,
		@sdt_oneprc,	@sdt_curcde,	@sdt_selprc,
		@sdt_hrmcde,	@sdt_dtyrat,	@sdt_dept, 
		@sdt_typcode,	@sdt_Code1,	@sdt_Code2,
		@sdt_Code3,	@sdt_cususd,	@sdt_cuscad,
		@sdt_inrdin,	@sdt_inrwin,	@sdt_inrhin,
		@sdt_mtrdin,	@sdt_mtrwin,	@sdt_mtrhin,
		@sdt_inrdcm,	@sdt_inrwcm,	@sdt_inrhcm,
		@sdt_mtrdcm,	@sdt_mtrwcm,	@sdt_mtrhcm,
		@sdt_shpstr,	@sdt_shpend,	@sdt_candat,
		@sdt_ctnstr,	@sdt_ctnend,	@sdt_ttlctn,
		@sdt_rmk,	@sdt_invqty,	@sdt_shpqty,
		@sdt_ftyprc,	@sdt_ftycst,	@sdt_subcde,
		@sdt_venitm,	@sdt_pckitr,	@sdt_oldpurord, 
		@sdt_oldpurseq,	@sdt_cusven,	@sdt_cussub,
		@sdt_pjobno,	@sdt_seccusitm,	@sdt_venno,
		@sod_alsitmno,	@sod_alscolcde,	@sod_qutdat,
		@sod_imqutdat,	@sdt_tradeven,	@sdt_examven,
		@sdt_posstr,	@sdt_posend,	@sdt_poscan,
		@sdt_cususdcur,	@sdt_cuscadcur,	@sdt_pormk,
		@sdt_cus1no,	@sdt_cus2no,	@sdt_ftyprctrm,
		@sdt_hkprctrm,	@sdt_trantrm, @sod_itmchidsc

		DECLARE 
		@hdr_upf	nvarchar(1),
		@cur_purord	nvarchar(20),
		@seqno		int
		
		set @hdr_upf = 'Y'
	
		while @@fetch_status = 0
		begin
	
			--Frankie Cheung 20090930 : Always use latest exchange rate and Curriencies to calculate (requested by user)
			select	@poh_discnt = vbi_discnt,
				@vbi_tsttim = vbi_tsttim,
				@vbi_bufday = vbi_bufday,
				@poh_paytrm = vbi_paytrm,
				@poh_prctrm = vbi_prctrm,
				@poh_curcde = vbi_curcde 
			from	VNBASINF (nolock)
			where	vbi_venno = @sco_cusven 
			
			execute SP_SELECT_MEXRATE @cocde, @sdt_fcurcde, @poh_curcde, "B", '', @return_effdat = @exeffdat output,@return_rate = @rate output
			set @rateffdat = @exeffdat	
			--------------------------------------------------------------
		
			set @cur_purord = ''

			-- Add by Solo, 22/02/02for Keep Seq No if update PO Flag is "N" 
			if @sdt_updpo = 'N'and @sdt_chgfty = 'N'
			begin
				if @sdt_purord <> '' and @sdt_purseq <> 0
				begin
					set @cur_purord = @sdt_purord
					set @seqno = @sdt_purseq 
				end 
			end
			----- 
	
			if @sdt_updpo = 'Y' or @sdt_chgfty = 'Y'
			begin
		
				if @sdt_purord <> '' and @sdt_purseq <> 0
		 
				begin
					set @cur_purord = @sdt_purord
					set @seqno = @sdt_purseq
				end 
				else
				begin
					if @cur_purord = ''
					begin
						select	@cur_purord = poh_purord
						from	POORDHDR (nolock)
						where	poh_cocde = @cocde and
							poh_venno = @sco_cusven and
							poh_ordno = @sco_ordno
		 
						if @cur_purord <> ''
						begin
							select	@seqno = max(pod_purseq) + 1
							from	POORDDTL (nolock)
							where	pod_cocde = @cocde and
								pod_purord = @cur_purord
						end
						else
						begin
							execute sp_select_doc_gen_po @cocde, "PO", @usrid, @purord = @cur_purord OUTPUT
							set @seqno = 1
						end
					end
		 			else
		 			begin
		 				set @seqno = @seqno + 1
		 			end
		 		end

				set @ret_code = @cur_purord 
				
				declare @old_poh_curcde as nvarchar(6)
				set @old_poh_curcde = ''
	
				select	@old_poh_curcde = isnull(poh_curcde,'')
				from	POORDHDR (nolock)
				where	poh_purord = @cur_purord
	 	
				if @old_poh_curcde <> ''
				begin
					set @poh_curcde = @old_poh_curcde
					execute SP_SELECT_MEXRATE @cocde, @sdt_fcurcde, @poh_curcde, "B", '', @return_effdat = @exeffdat output,@return_rate = @rate output
					set @rateffdat = @exeffdat	
				end
		
				UPDATE	SCORDDTL 
				set	sod_purord = @ret_code, 
					sod_purseq = @seqno,
					sod_upddat = getdate(),
					--sod_updusr = 'SYSTEM' 
					sod_updusr = left(@usrid, 30)
				WHERE	sod_cocde = @cocde and
					sod_ordno = @sdt_ordno and
					sod_cusven = @sdt_cusven and
					sod_itmno = @sdt_itmno and
					sod_colcde = @sdt_colcde and
					sod_pckseq = @sdt_pckseq and
					sod_pckunt = @sdt_pckunt and
					sod_inrctn = @sdt_inrctn and
					sod_mtrctn = @sdt_mtrctn and
					sod_ftyprctrm = @sdt_ftyprctrm and
					sod_hkprctrm = @sdt_hkprctrm and
					sod_trantrm = @sdt_trantrm and
					sod_cft = @sdt_cft
-- START	 
				if (select count(*) from POORDHDR (nolock) where poh_cocde = @cocde and poh_purord = @ret_code) = 0 or
					(select count(*) from POORDHDR (nolock) where poh_cocde = @cocde and poh_purord = @ret_code and poh_pursts in ('OPE','REL')) > 0
				begin
					if @sdt_updpo = 'Y' or @sdt_chgfty = 'Y' 
					begin
						--DELETE FROM POORDDTL
						--WHERE pod_cocde = @cocde AND 
						--pod_purord = @ret_code AND
						--pod_purseq = @seqno
					
						delete
						from	PODTLSHP
						where	pds_cocde = @cocde and
							pds_purord = @ret_code and
							pds_seq = @seqno
					
						delete
						from	PODTLCTN
						where	pdc_cocde = @cocde and
							pdc_purord = @ret_code and
							pdc_seq = @seqno
						
						delete
						from	PODTLASS
						where	pda_cocde = @cocde and
							pda_purord = @ret_code and
							pda_seq = @seqno
						
						--- Reset all BOM item order qty to 0 ---
						update	PODTLBOM 
						set	pdb_ordqty = 0
						where	pdb_cocde = @cocde and 
							pdb_purord = @ret_code and
							pdb_seq = @seqno
					end

					-- INSERT NEW PO HEADER 
					if (@sdt_updpo = 'Y' and @hdr_upf = 'Y') or (@sdt_chgfty = 'Y' and @hdr_upf = 'Y')
					begin
						delete
						from	POSHPMRK
						where	psm_cocde = @cocde and
							psm_purord = @ret_code
		
						delete
						from	POCNTINF
						where	pci_cocde = @cocde and
							pci_purord = @ret_code
			 
						select	@poh_puradr = isnull(ct.vci_adr,''),
							@poh_purchnadr = isnull(ct.vci_chnadr,''),
							@poh_purstt = isnull(ct.vci_stt,''),
							@poh_purcty = isnull(ct.vci_cty,''),
							@poh_purpst = isnull(ct.vci_zip,''),
							@poh_porctp = isnull(cp.vci_cntctp, '')
						from	VNCNTINF ct (nolock)
							left join VNCNTINF cp (nolock) on ct.vci_venno = cp.vci_venno and cp.vci_cntdef = 'Y' and cp.vci_cnttyp = 'GENL'
						WHERE
							ct.vci_cnttyp = 'M' and
							ct.vci_venno = @sco_cusven
					
						select	@poh_puragt = soh_agt,
							@poh_salrep = soh_salrep,
							@poh_srname = soh_srname,
							@poh_saldiv = soh_saldiv,
							@poh_saltem = soh_saltem,
							@poh_prmcus = soh_cus1no,
							@poh_seccus = soh_cus2no,
							@poh_shpadr = soh_biladr,
							@poh_shpstt = soh_bilstt,
							@poh_shpcty = soh_bilcty,
							@poh_shppst = soh_bilzip,
							@poh_ttlcbm = soh_ttlvol,
							@poh_ttlctn = soh_ttlctn,
							@poh_ttlamt = soh_ttlamt,
							@poh_spoflg = soh_smpsc,
							@poh_cuspno = soh_cuspo,
							@poh_cpodat = soh_cpodat,
							@poh_reppno = soh_resppo,
							@poh_lbldue = soh_lbldue,
							@poh_lblven = soh_lblven,
							@poh_issdat = soh_issdat,
							@poh_pocdat = '1900-01-01',
							@poh_pocdatend = '1900-01-01',
							@poh_shpstr = soh_shpstr,
							@poh_shpend = soh_shpend,
							@poh_rmk = soh_rmk,
							@poh_cusctn = soh_cusctn,
							@poh_dest = soh_dest
						from	SCORDHDR (nolock)
						where	soh_cocde = @cocde and
							soh_ordno = @sdt_ordno

						if @poh_pocdat <> '1900-01-01'
						begin
							set @poh_pocdat = @poh_pocdat - @csf_cancelbuf
						end
					
						set @poh_shpstr = @poh_shpstr - @csf_shpstrbuf
						set @poh_shpend = @poh_shpend - @csf_shpendbuf
/*				
						if @poh_pocdat <> '1900-01-01'
						begin
							set @poh_pocdat = @poh_pocdat - @vbi_tsttim - @vbi_bufday
						end
					
						set @poh_shpstr = @poh_shpstr - @vbi_tsttim - @vbi_bufday
						set @poh_shpend = @poh_shpend - @vbi_tsttim - @vbi_bufday
*/
-- 20150506 Remove PO Ship Date > getdate, use getdate logic
/*
						
						if getdate() > @poh_pocdat AND @poh_pocdat <> '1900-01-01'
						begin
							set @poh_pocdat = getdate() 
						end
						
						if getdate() > @poh_shpstr			
						begin
							set @poh_shpstr = getdate() 
						end
						
						if getdate() > @poh_shpend
						begin
							set @poh_shpend = getdate()
						end
*/			

	
						---- Preset the Ship Start Date & Stop Date as today ----
						---set @poh_shpend = @ShpStartDate 
						---set @poh_shpstr = @ShpendDate 
						------------------------------------------------------------------ 
						
						set @poh_cocde = @cocde
						set @poh_purord = @ret_code
						set @poh_pursts = 'OPE'
						set @poh_venno = @sco_cusven
		
						update	POORDHDR
						set	poh_pursts = @poh_pursts,
							poh_issdat = getdate(),
							poh_spoflg = @poh_spoflg,
							poh_cuspno = @poh_cuspno,
							poh_cpodat = @poh_cpodat,
							poh_reppno = @poh_reppno,
							poh_curcde = @poh_curcde,
							poh_pocdat = @poh_pocdat,
							poh_pocdatend = @poh_pocdatend,
							poh_shpstr = @poh_shpstr,
							poh_shpend = @poh_shpend,
							--poh_updusr = 'SCM02-SYS',
							poh_updusr = left(@usrid, 30),
							poh_subcde = '',
							poh_cusctn = @poh_cusctn,
							poh_dest = @poh_dest
						where	poh_cocde = @cocde and 
							poh_purord = @ret_code
					
						if @@rowcount = 0 
						begin
							insert into POORDHDR
							(	poh_cocde,	poh_purord,	poh_pursts,
								poh_issdat,	poh_venno,	poh_puradr,
								poh_purstt,	poh_purcty,	poh_purpst,
								poh_porctp,	poh_puragt,	poh_salrep,
								poh_srname,	poh_saltem,	poh_saldiv,
								poh_prmcus,	poh_seccus,	poh_shpadr,
								poh_shpstt,	poh_shpcty,	poh_shppst,
								poh_prctrm,	poh_paytrm,	poh_ttlcbm,
								poh_ttlctn,	poh_curcde,	poh_ttlamt,
								poh_discnt,	poh_spoflg,	poh_cuspno,
								poh_cpodat,	poh_reppno,	poh_pocdat,
								poh_pocdatend,	poh_shpstr,	poh_shpend,
								poh_lbldue,	poh_lblven,	poh_netamt,
								poh_creusr,	poh_updusr,	poh_subcde,
								poh_rmk,	poh_ordno,	poh_purchnadr,
								poh_vndackflg,	poh_cusctn,	poh_dest,
								poh_prctrmflg,	poh_paytrmflg,	poh_lastprctrm, poh_lastpaytrm					
							)
							values
							(	@cocde,		@ret_code,	@poh_pursts,
								getdate(),	@poh_venno,	@poh_puradr,
								@poh_purstt,	@poh_purcty,	@poh_purpst,
								@poh_porctp,	@poh_puragt,	@poh_salrep,
								@poh_srname,	@poh_saltem,	@poh_saldiv,
								@poh_prmcus,	@poh_seccus,	@poh_shpadr,
								@poh_shpstt,	@poh_shpcty,	@poh_shppst,
								@poh_prctrm,	@poh_paytrm,	@poh_ttlcbm,
								0,		@poh_curcde,	0,
								@poh_discnt,	@poh_spoflg,	@poh_cuspno,
								@poh_cpodat,	@poh_reppno,	@poh_pocdat,
								@poh_pocdatend,	@poh_shpstr,	@poh_shpend,
								@poh_lbldue,	@poh_lblven,	0,
								--'SCM02-SYS',	'SCM02-SYS',	'',
								left(@usrid, 30), left(@usrid, 30), '',
								@poh_rmk,	@sco_ordno,	@poh_purchnadr,
								'N',		@poh_cusctn,	@poh_dest,
								'', '', @poh_prctrm,@poh_paytrm
							)
		
							if @@ERROR <> 0			
							begin
								-- return 99 to the calling program to indicate failure. 
								select 'An error occurred when inserting into POORDHDR'
								return(99)
							end
						end-- end of (	if (@sdt_updpo = 'Y' AND @hdr_upf = 'Y') or (@sdt_chgfty = 'Y' AND @hdr_upf = 'Y'))
						
						select	@pci_csenam = sci_csenam,
							@pci_cseadr = sci_cseadr,
							@pci_csestt = sci_csestt,
							@pci_csecty = sci_csecty,
							@pci_csezip = sci_csezip,
							@pci_fwdtyp = sci_fwdtyp,
							@pci_fwdacc = sci_fwdno ,
							@pci_fwddsc = sci_fwddsc,
							@pci_fwditr = sci_fwditr,
							@pci_noptyp = sci_noptyp,
							@pci_nopadr = sci_nopadr,
							@pci_nopstt = sci_nopstt,
							@pci_nopcty = sci_nopcty,
							@pci_nopzip = sci_nopzip,
							@pci_noptil = sci_noptil,
							@pci_nopphn = sci_nopphn,
							@pci_nopfax = sci_nopfax,
							@pci_nopeml = sci_nopeml
						from	SCCNTINF (nolock)
						where	sci_cocde = @cocde and
							sci_ordno = @sdt_ordno
			
						insert into POCNTINF
						(	pci_cocde,	pci_purord,	pci_csenam,
							pci_cseadr,	pci_csestt,	pci_csecty,
							pci_csezip,	pci_fwdtyp,	pci_fwdacc,
							pci_fwddsc,	pci_fwditr,	pci_noptyp,
							pci_nopadr,	pci_nopstt,	pci_nopcty,
							pci_nopzip,	pci_noptil,	pci_nopphn,
							pci_nopfax,	pci_nopeml,	pci_creusr,
							pci_updusr
						)
						values
						(	@cocde,		@ret_code,	@pci_csenam,
							@pci_cseadr,	@pci_csestt,	@pci_csecty,
							@pci_csezip,	@pci_fwdtyp,	@pci_fwdacc,
							@pci_fwddsc,	@pci_fwditr,	@pci_noptyp,
							@pci_nopadr,	@pci_nopstt,	@pci_nopcty,
							@pci_nopzip,	@pci_noptil,	@pci_nopphn,
							--@pci_nopfax,	@pci_nopeml,	'SCM02-SYS',
							@pci_nopfax, 	@pci_nopeml, 	left(@usrid, 30),
							--'SCM02-SYS'
							left(@usrid, 30)
						)
				
						if @@ERROR <> 0 		
						begin 		
							 -- return 99 to the calling program to indicate failure.			
							 select 'An error occurred when inserting into POCNTINF'				
							 return(99) 		
						end
		
						--cur_SCORDDTLHDR --> cur_SCORDDTL --> cur_SCSHPMRK
						DECLARE cur_SCSHPMRK CURSOR FOR
						select	ssm_shptyp,	ssm_engdsc,	ssm_chndsc,
							ssm_engrmk,	ssm_chnrmk,	ssm_imgpth,
							ssm_imgnam
						from	SCSHPMRK (nolock)
						where	ssm_cocde = @cocde and
							ssm_ordno = @sco_ordno 
				
						OPEN cur_SCSHPMRK
						FETCH NEXT FROM cur_SCSHPMRK INTO 
						@psm_shptyp,	@psm_engdsc,	@psm_chndsc, 
						@psm_engrmk,	@psm_chnrmk,	@psm_imgpth, 
						@psm_imgnam 
		
						while @@fetch_status = 0
						begin
				 			insert into POSHPMRK
							(	psm_cocde,	psm_purord,	psm_shptyp,
								psm_engdsc,	psm_chndsc,	psm_engrmk,
								psm_chnrmk,	psm_imgpth,	psm_imgnam,
								psm_creusr,	psm_updusr
							)
							values
							(	@cocde,		@ret_code,	@psm_shptyp,
								@psm_engdsc,	@psm_chndsc,	@psm_engrmk,
								@psm_chnrmk,	@psm_imgpth,	@psm_imgnam,
								--'SCM02-SYS',	'SCM02-SYS'
								left(@usrid, 30), left(@usrid, 30)
							)
				 
							if @@ERROR <> 0 
							begin
								-- return 99 to the calling program to indicate failure.
								SELECT 'An error occurred when inserting into POSHPMRK'
								return(99)
							end 
				
							FETCH NEXT FROM cur_SCSHPMRK INTO 
							@psm_shptyp,	@psm_engdsc,	@psm_chndsc, 
							@psm_engrmk,	@psm_chnrmk,	@psm_imgpth, 
							@psm_imgnam
						end
		
						CLOSE cur_SCSHPMRK 
						DEALLOCATE cur_SCSHPMRK 
				
						set @hdr_upf = 'N' 
				
					end-- end of (if @sdt_updpo = 'Y' or @sdt_chgfty = 'Y') 

										set @pod_jobord = ''
					set @pod_runno = ''
	
					if @sdt_oldpurord <> '' 
					begin
						select	@pod_jobord = pod_jobord,
							@pod_runno = pod_runno,
							@sdt_rmk = pod_rmk
						from	POORDDTL (nolock)
						where	pod_cocde = @cocde and
							pod_purord = @sdt_oldpurord and
							pod_purseq = @sdt_oldpurseq
					end
	
					set @pod_cocde= @cocde
					set @pod_purord = @ret_code	
					set @pod_purseq = @seqno
					set @pod_itmno= @sdt_itmno 	
					set @pod_cusitm = @sdt_cusitm	
					set @pod_cussku = @sdt_cussku
					set @pod_engdsc = @sdt_itmdsc
					set @pod_prdven = @sdt_venno
					set @pod_tradeven = @sdt_tradeven
					set @pod_examven = @sdt_examven
					set @pod_prdsubcde = @sdt_subcde
					set @pod_seccusitm = @sdt_seccusitm 
					set @pod_chndsc = @sod_itmchidsc			
					set @pod_vencol = ''
		
					select	@pod_vencol = icf_vencol
					from	IMCOLINF (nolock) 	
					where	icf_itmno = @sdt_itmno and
						icf_colcde = @sdt_colcde
	
					if @pod_vencol is NULL or @pod_vencol = ''
					begin
						set @pod_vencol = @sdt_colcde
					end
		 
					--select	@pod_chndsc = ibi_chndsc
					--from	IMBASINF (nolock)
					--where	ibi_itmno = @sdt_itmno 
			
					set @pod_cuscol = @sdt_cuscol	
					set @pod_coldsc = @sdt_coldsc	
					set @pod_pckseq = @sdt_pckseq	
					set @pod_untcde = @sdt_pckunt	
					set @pod_inrctn = @sdt_inrctn	
					set @pod_mtrctn = @sdt_mtrctn	
					set @pod_cubcft = @sdt_cft
					set @pod_cbm= @sdt_cbm
					set @pod_dept = @sdt_dept	
					set @pod_ordqty = @sdt_ordqty	
					set @pod_recqty = @sdt_shpqty
			
					select	@VendorType = vbi_ventyp
					from	VNBASINF (nolock)
					where	vbi_venno = @sdt_cusven
					
					set @rate_old = 0		
			
					select	@rate_old = isnull(pod_curexrat,0)
					from	POORDDTL (nolock)
					where	pod_cocde = @cocde and
						pod_purord = @ret_code and
						pod_purseq = @seqno and
						@sdt_fcurcde = pod_orgcur
			
					if @rate_old = 0
					begin
						set @pod_ftyprc = @sdt_ftycst * @rate
					end		
					else
					begin
						set @pod_ftyprc = @sdt_ftycst * @rate_old
					end
			
					set @pod_cuspno = @sdt_cuspo 	
					set @pod_respno = @sdt_resppo	
					set @pod_hrmcde = @sdt_hrmcde	
					set @pod_lblcde = @sdt_code1 + @sdt_code2 + @sdt_code3 	
					set @pod_cususdcur = @sdt_cususdcur
					set @pod_cususd = @sdt_cususd
					set @pod_cuscadcur = @sdt_cuscadcur
					set @pod_cuscad = @sdt_cuscad	
			
					if @sdt_posstr <> '1900-01-01'
					begin
						set @pod_shpstr = @sdt_posstr
					end
					else
					begin
						--set @pod_shpstr = @sdt_shpstr - @vbi_tsttim - @vbi_bufday
						set @pod_shpstr = @sdt_shpstr - @csf_shpstrbuf
					end
					
					if @sdt_posend <> '1900-01-01'
					begin
						set @pod_shpend = @sdt_posend
					end
					else
					begin
						--set @pod_shpend = @sdt_shpend - @vbi_tsttim - @vbi_bufday
						set @pod_shpend = @sdt_shpend - @csf_shpendbuf
					end
			
					if @sdt_poscan <> '1900-01-01'
					begin
						set @pod_candat = @sdt_poscan
					end
					else
					begin
						set @pod_candat = @sdt_candat 
						if @sdt_candat <> '1900-01-01'
						begin
							--set @pod_candat = @sdt_candat - @vbi_tsttim - @vbi_bufday
							set @pod_candat = @sdt_candat - @csf_cancelbuf
/*							if @pod_candat > @pod_shpend
							begin
								set @pod_candat = @pod_shpend
							end
*/						end
					end
					
					/*
					if getdate() > @pod_candat AND @pod_candat <> '1900-01-01' 
					begin	
						set @pod_candat = getdate() 	
					end
				
					if getdate() > @pod_shpstr
					begin	
						set @pod_shpstr = getdate() 	
					end 
				
					if getdate() > @pod_shpend
					begin	
						set @pod_shpend = getdate() 	
					end
					*/
				 
					set @pod_ctnstr = @sdt_ctnstr	
					set @pod_ctnend = @sdt_ctnend	
					set @pod_scno = @sdt_ordno 	
					set @pod_ttlctn = @sdt_ttlctn 
				 
					-- AY Fix the Round Error at 06/12/2003
					set @pod_lneamt = round(@sdt_ordqty * @pod_ftyprc,2)
					set @pod_lnecub = @sdt_cft * @sdt_ttlctn
					------------------------------------------------
					set @pod_ttlqty = 0	
					set @pod_scline = @sdt_ordseq 
				
					-- set @pod_jobord = ''		
					set @pod_assflg = '' 	
					set @dtyrat = @sdt_dtyrat	
					set @typcode= @sdt_typcode 	
					set @code1= @sdt_Code1 	
					set @code2= @sdt_Code2 	
					set @code3= @sdt_Code3
					set @pod_venitm = @sdt_venitm	 
					set @pod_pckitr = @sdt_pckitr

					--cur_SCORDDTLHDR --> cur_SCORDDTL
					if @sdt_updpo = 'Y' 
					begin
						update	POORDDTL 
						set	pod_itmsts = @sdt_itmsts,
							pod_venitm = @pod_venitm,
							pod_cusitm = @pod_cusitm,
							pod_cussku = @pod_cussku,
							pod_engdsc = @pod_engdsc,
							-- pod_chndsc = @pod_chndsc,
							-- pod_vencol = @pod_vencol,
							pod_cuscol = @pod_cuscol,
							pod_coldsc = @pod_coldsc,
							pod_cbm = @pod_cbm,
							pod_cubcft = @pod_cubcft,
							pod_dept = @pod_dept,
							pod_ordqty = @pod_ordqty,
							pod_ftyprc = @pod_ftyprc,
							pod_cuspno = @pod_cuspno,
							pod_respno = @pod_respno,
							pod_hrmcde = @pod_hrmcde,
							pod_lblcde = @pod_lblcde,
							pod_cususdcur = @pod_cususdcur,
							pod_cususd = @pod_cususd,
							pod_cuscadcur = @pod_cuscadcur,
							pod_cuscad = @pod_cuscad,
							pod_shpstr = @pod_shpstr,
							pod_shpend = @pod_shpend,
							pod_candat = @pod_candat,
							pod_ctnstr = @pod_ctnstr,
							pod_ctnend = @pod_ctnend,
							pod_ttlctn = @pod_ttlctn,
							pod_lneamt = @pod_lneamt,
							pod_lnecub = @pod_lnecub,
							pod_ttlqty = @pod_ttlqty,
							pod_assflg = @pod_assflg,
							pod_dtyrat = @dtyrat,
							pod_typcode= @typcode,
							pod_Code1= @code1,
							pod_Code2= @code2,
							pod_Code3= @code3,
							pod_pckitr= @pod_pckitr ,
							pod_prdven= @pod_prdven,
							pod_tradeven = @pod_tradeven,
							pod_examven = @pod_examven, 
							pod_prdsubcde = @pod_prdsubcde,
							pod_seccusitm = @pod_seccusitm, 
							-- pod_jobord = @pod_jobord 
							pod_alsitmno = @sod_alsitmno , 
							pod_alscolcde = @sod_alscolcde,
							--pod_updusr = 'SCM02-SYS',
							pod_updusr = left(@usrid, 30),
							pod_upddat = getdate(),
							pod_orgcur=@sdt_fcurcde,
							pod_curexrat = @rate,
							pod_curexeffdat = @exeffdat,
							pod_qutdat = @sod_qutdat,
							pod_imqutdat = @sod_imqutdat,
							pod_rmk = @sdt_pormk,
							pod_cus1no = @sdt_cus1no,
							pod_cus2no = @sdt_cus2no,
							pod_ftyprctrm = @sdt_ftyprctrm,
							pod_hkprctrm = @sdt_hkprctrm,
							pod_trantrm = @sdt_trantrm
						where	pod_cocde = @cocde and 
							pod_purord = @ret_code and
							pod_purseq = @seqno 
						
						if @@rowcount = 0 
						begin

-- 20150506 Remove PO Ship Date > getdate, use getdate logic
/*
							if getdate() > @pod_candat AND @pod_candat <> '1900-01-01' 
							begin	
								set @pod_candat = getdate() 	
							end
						
							if getdate() > @pod_shpstr
							begin	
								set @pod_shpstr = getdate() 	
							end 
						
							if getdate() > @pod_shpend
							begin	
								set @pod_shpend = getdate() 	
							end
*/	

							if ltrim(rtrim(@sdt_pormk)) = ''
							begin
								set @pod_rmk = @sdt_rmk
							end
							else
							begin
								set @pod_rmk = @sdt_pormk + @feed + @sdt_rmk
							end
													
							-- INSERT NEW PO DETAIL
							insert into POORDDTL
							(	pod_cocde,		pod_purord,		pod_purseq,
								pod_itmno,		pod_itmsts,		pod_venitm,
								pod_cusitm,		pod_cussku,		pod_engdsc,
								pod_chndsc,		pod_vencol,		pod_cuscol,
								pod_coldsc,		pod_pckseq,		pod_untcde,
								pod_inrctn,		pod_mtrctn,		pod_cubcft,
								pod_cbm,		pod_dept,		pod_ordqty,
								pod_recqty,		pod_ftyprc,		pod_cuspno,
								pod_respno,		pod_hrmcde,		pod_lblcde,
								pod_cususdcur,		pod_cususd,		pod_cuscadcur,
								pod_cuscad,		pod_shpstr,		pod_shpend,
								pod_candat,		pod_ctnstr,		pod_ctnend,
								pod_scno,		pod_ttlctn,		pod_lneamt,
								pod_lnecub,		pod_ttlqty,		pod_scline,
								pod_jobord,		pod_runno,		pod_assflg,
								pod_dtyrat,		pod_typcode,		pod_code1,
								pod_code2,		pod_code3,		pod_creusr,
								pod_updusr,		pod_pckitr,		pod_rmk,
								pod_prdven,		pod_tradeven,		pod_examven,
								pod_prdsubcde,		pod_seccusitm,		pod_alsitmno,
								pod_alscolcde,		pod_orgcur,		pod_curexrat,
								pod_curexeffdat,	pod_qutdat,		pod_imqutdat,
								pod_cus1no,		pod_cus2no,		pod_ftyprctrm,
								pod_hkprctrm,		pod_trantrm
							)
							values
							(	@pod_cocde,		@pod_purord,		@pod_purseq,
								@pod_itmno,		@sdt_itmsts,		@pod_venitm,
								@pod_cusitm,		@pod_cussku,		@pod_engdsc,
								@pod_chndsc,		@pod_vencol,		@pod_cuscol,
								@pod_coldsc,		@pod_pckseq,		@pod_untcde,
								@pod_inrctn,		@pod_mtrctn,		@pod_cubcft,
								@pod_cbm,		@pod_dept,		@pod_ordqty - @pod_recqty,
								0,			@pod_ftyprc,		@pod_cuspno,
								@pod_respno,		@pod_hrmcde,		@pod_lblcde,
								@pod_cususdcur,		@pod_cususd,		@pod_cuscadcur,
								@pod_cuscad,		@pod_shpstr,		@pod_shpend,
								@pod_candat,		@pod_ctnstr,		@pod_ctnend,
								@pod_scno,		@pod_ttlctn,		@pod_lneamt,
								@pod_lnecub,		@pod_ttlqty,		@pod_scline,
								@pod_jobord,		@pod_runno,		@pod_assflg,
								@dtyrat,		@typcode,		@code1,
								--@code2,			@code3,			'SCM02-SYS',
								@code2,			@code3,			left(@usrid, 30),
								--'SCM02-SYS',		@pod_pckitr,		@pod_rmk,
								left(@usrid, 30), @pod_pckitr,		@pod_rmk,
								@pod_prdven,		@pod_tradeven,		@pod_examven,
								@pod_prdsubcde,		@pod_seccusitm,		@sod_alsitmno ,
								@sod_alscolcde,		@sdt_fcurcde,		@rate,
								@exeffdat,		@sod_qutdat,		@sod_imqutdat,
								@sdt_cus1no,		@sdt_cus2no,		@sdt_ftyprctrm,
								@sdt_hkprctrm,		@sdt_trantrm
							)
					
							-- Insert into First Ship Date Record
							insert into SCORDFSD
							(	sof_cocde,	sof_ordno,	sof_ordseq,
								sof_ordqty,	sof_shpstr,	sof_shpend,
								sof_candat,	sof_creusr,	sof_credat
							)
							values
							(	@sdt_cocde,	@sdt_ordno,	@sdt_ordseq,
								@sdt_ordqty,	@sdt_shpstr,	@sdt_shpend,
								@sdt_candat,	@usrid,		getdate()
							)
						end-- end of (if @@rowcount = 0)	
						
						if @@ERROR <> 0		
						begin 		 
							 -- return 99 to the calling program to indicate failure.
							 select 'An error occurred when inserting into POORDDTL'
							 return(99) 		 
						end 
					end-- end of (if @sdt_updpo = 'Y')

					--- Change Factory ----
					if @sdt_chgfty = 'Y'
					begin
						select	@pod_chndsc = pod_chndsc,
							@pod_shpstr = pod_shpstr,
							@pod_shpend = pod_shpend,
							@pod_candat = pod_candat,
							@sdt_rmk = pod_rmk
						from	POORDDTL (nolock) 
						where 	pod_cocde = @cocde and
							pod_purord = @sdt_oldpurord and
							pod_purseq = @sdt_oldpurseq
					
						update	POORDDTL
						set	pod_itmsts = @sdt_itmsts,
							pod_venitm = @pod_venitm,
							pod_cusitm = @pod_cusitm,
							pod_cussku = @pod_cussku,
							pod_engdsc = @pod_engdsc,
							pod_cuscol = @pod_cuscol,
							pod_coldsc = @pod_coldsc,
							pod_cbm = @pod_cbm,
							pod_dept = @pod_dept,
							pod_ordqty = @pod_ordqty,
							pod_ftyprc = @pod_ftyprc,
							pod_cuspno = @pod_cuspno,
							pod_respno = @pod_respno,
							pod_hrmcde = @pod_hrmcde,
							pod_lblcde = @pod_lblcde,
							pod_cususdcur = @pod_cususdcur,
							pod_cususd = @pod_cususd,
							pod_cuscadcur = @pod_cuscadcur,
							pod_cuscad = @pod_cuscad,
							pod_shpstr = @pod_shpstr,
							pod_shpend = @pod_shpend,
							pod_candat = @pod_candat,
							pod_ctnstr = @pod_ctnstr,
							pod_ctnend = @pod_ctnend,
							pod_ttlctn = @pod_ttlctn,
							pod_lneamt = @pod_lneamt,
							pod_lnecub = @pod_lnecub,
							pod_ttlqty = @pod_ttlqty,
							pod_assflg = @pod_assflg,
							pod_dtyrat = @dtyrat,
							pod_typcode = @typcode,
							pod_code1 = @code1,
							pod_code2 = @code2,
							pod_code3 = @code3,
							--pod_updusr = 'SCM02-SYS', 
							pod_updusr = left(@usrid, 30),
							pod_pckitr= @pod_pckitr,
							pod_prdven= @pod_prdven,
							pod_tradeven = @pod_tradeven,
							pod_examven = @pod_examven,
							pod_prdsubcde = @pod_prdsubcde,
							pod_seccusitm = @pod_seccusitm,
							-- pod_jobord = @pod_jobord 
							pod_alsitmno = @sod_alsitmno , 
							pod_alscolcde = @sod_alscolcde,
							pod_orgcur=@sdt_fcurcde,
							pod_curexrat = @rate,
							pod_curexeffdat = @exeffdat,
							 --pod_rmk = @sdt_rmk
							pod_qutdat = @sod_qutdat,
							pod_imqutdat = @sod_imqutdat,
							pod_cus1no = @sdt_cus1no,
							pod_cus2no = @sdt_cus2no,
							pod_ftyprctrm = @sdt_ftyprctrm,
							pod_hkprctrm = @sdt_hkprctrm,
							pod_trantrm = @sdt_trantrm
						where	pod_cocde = @cocde and
							pod_purord = @ret_code and
							pod_purseq = @seqno 
			
						if @@rowcount = 0 
						begin
							if ltrim(rtrim(@sdt_pormk)) = ''
							begin
								set @pod_rmk = @sdt_rmk
							end
							else
							begin
								set @pod_rmk = @sdt_pormk + @feed + @sdt_rmk
							end
	
							-- INSERT NEW PO DETAIL
							insert into POORDDTL
							(	pod_cocde,		pod_purord,		pod_purseq,
								pod_itmno,		pod_itmsts,		pod_venitm,
								pod_cusitm,		pod_cussku,		pod_engdsc,
								pod_chndsc,		pod_vencol,		pod_cuscol,
								pod_coldsc,		pod_pckseq,		pod_untcde,
								pod_inrctn,		pod_mtrctn,		pod_cubcft,
								pod_cbm,		pod_dept,		pod_ordqty,
								pod_recqty,		pod_ftyprc,		pod_cuspno,
								pod_respno,		pod_hrmcde,		pod_lblcde,
								pod_cususdcur,		pod_cususd,		pod_cuscadcur,
								pod_cuscad,		pod_shpstr,		pod_shpend,
								pod_candat,		pod_ctnstr,		pod_ctnend,
								pod_scno,		pod_ttlctn,		pod_lneamt,
								pod_lnecub,		pod_ttlqty,		pod_scline,
								pod_jobord,		pod_runno,		pod_assflg,
								pod_dtyrat,		pod_typcode,		pod_code1,
								pod_code2,		pod_code3,		pod_creusr,
								pod_updusr,		pod_pckitr,		pod_rmk,
								pod_prdven,		pod_tradeven,		pod_examven,
								pod_prdsubcde,		pod_seccusitm,		pod_alsitmno,
								pod_alscolcde,		pod_orgcur,		pod_curexrat,
								pod_curexeffdat,	pod_qutdat,		pod_imqutdat,
								pod_cus1no,		pod_cus2no,		pod_ftyprctrm,
								pod_hkprctrm,		pod_trantrm
							)
							values
							(	@pod_cocde,		@pod_purord, 		@pod_purseq,
								@pod_itmno,		@sdt_itmsts,		@pod_venitm,
								@pod_cusitm,		@pod_cussku,		@pod_engdsc,
								@pod_chndsc,		@pod_vencol,		@pod_cuscol,
								@pod_coldsc,		@pod_pckseq,		@pod_untcde,
								@pod_inrctn,		@pod_mtrctn,		@pod_cubcft,
								@pod_cbm,		@pod_dept,		@pod_ordqty - @pod_recqty,
								0,			@pod_ftyprc,		@pod_cuspno,
								@pod_respno,		@pod_hrmcde,		@pod_lblcde,
								@pod_cususdcur,		@pod_cususd,		@pod_cuscadcur,
								@pod_cuscad,		@pod_shpstr,		@pod_shpend,
								@pod_candat,		@pod_ctnstr,		@pod_ctnend,
								@pod_scno,		@pod_ttlctn,		@pod_lneamt,
								@pod_lnecub,		@pod_ttlqty,		@pod_scline,
								@pod_jobord,		@pod_runno,		@pod_assflg,
								@dtyrat,		@typcode,		@code1,
								--@code2,			@code3,			'SCM02-SYS',
								@code2,			@code3,			left(@usrid, 30),
								--'SCM02-SYS' ,		@pod_pckitr,		@pod_rmk,
								left(@usrid, 30), @pod_pckitr,		@pod_rmk,
								@pod_prdven,		@pod_tradeven,		@pod_examven,
								@pod_prdsubcde,		@pod_seccusitm,		@sod_alsitmno ,
								@sod_alscolcde,		@sdt_fcurcde,		@rate,
								@exeffdat,		@sod_qutdat,		@sod_imqutdat,
								@sdt_cus1no,		@sdt_cus2no,		@sdt_ftyprctrm,
								@sdt_hkprctrm,		@sdt_trantrm
							)
						end
		 
						if @@ERROR <> 0		
						begin 		 
							 -- return 99 to the calling program to indicate failure.
							 SELECT 'An error occurred when inserting into POORDDTL'
							 return(99) 		 
						end
					end-- end of (	if@sdt_chgfty = 'Y')

					--cur_SCORDDTLHDR --> cur_SCORDDTL -->cur_SCASSINF 
					DECLARE cur_SCASSINF CURSOR FOR
					select 	sai_itmno,	sai_assitm,	sai_assdsc,
						sai_cusitm,	sai_colcde,	sai_coldsc,
						sai_cussku,	sai_upcean,	sai_cusrtl,
						sai_untcde,	sai_inrqty,	sai_mtrqty,
						sai_imperiod,	sai_cusstyno
					from	SCASSINF (nolock)
					where	sai_cocde = @cocde and		
						sai_ordno = @sdt_ordno and
						sai_ordseq = @sdt_ordseq
	
					OPEN cur_SCASSINF
					FETCH NEXT FROM cur_SCASSINF INTO
					@pda_itmno,	@pda_assitm,	@pda_assdsc,
					@pda_cusitm,	@pda_colcde,	@pda_coldsc,
					@pda_cussku,	@pda_upcean,	@pda_cusrtl,
					@pda_pckunt,	@pda_inrqty,	@pda_mtrqty,
					@pda_imperiod,	@pda_cusstyno
	
					while @@fetch_status = 0
					begin
		
						if @sdt_updpo = 'Y'or @sdt_chgfty = 'Y'
						begin
							insert into PODTLASS
							(	pda_cocde,	pda_purord,	pda_seq,
								pda_itmno,	pda_assitm,	pda_assdsc, 
								pda_cusitm,	pda_colcde,	pda_coldsc,
								pda_cussku,	pda_cusstyno,	pda_upcean,
								pda_cusrtl,	pda_pckunt,	pda_inrqty,
								pda_mtrqty,	pda_creusr,	pda_updusr,
								pda_imperiod
							)
							values
							(	@cocde,		@ret_code,	@seqno,
								@pda_itmno,	@pda_assitm,	@pda_assdsc,
								@pda_cusitm,	@pda_colcde,	@pda_coldsc,
								@pda_cussku,	@pda_cusstyno,	@pda_upcean,
								@pda_cusrtl,	@pda_pckunt,	@pda_inrqty,
								--@pda_mtrqty,	'SCM02-SYS',	'SCM02-SYS',
								@pda_mtrqty,	left(@usrid, 30), left(@usrid, 30),
								@pda_imperiod
							) 
					
							if @@ERROR <> 0			
							begin 
								-- return 99 to the calling program to indicate failure.			
								select 'An error occurred when inserting into PODTLASS'
								return(99) 
							end 
						end-- end of (if @sdt_updpo = 'Y'or @sdt_chgfty = 'Y')
	
						--cur_SCORDDTLHDR --> cur_SCORDDTL -->cur_SCASSINF -->cur_BOM2	 
						DECLARE cur_BOM2 CURSOR FOR		
						select	sbi_assitm,	sbi_bomitm,	sbi_pckunt,
							sbi_ordqty,	sbi_venno,	sbi_fcurcde,
							sbi_ftyprc,	sbi_colcde,	vbi_curcde, 
							sbi_bcurcde,	sbi_bomcst,	sbi_bompoflg
							,sbi_imperiod	-- Frankie Cheung 20110307 Add BOM IM Period
						from	SCBOMINF (nolock),
							VNBASINF (nolock) 
						where	sbi_cocde = @cocde and
							sbi_ordno = @sdt_ordno and
							sbi_ordseq = @sdt_ordseq and
							vbi_venno = sbi_venno and
							sbi_assitm = @pda_assitm
			
						OPEN cur_BOM2 		
						FETCH NEXT FROM cur_BOM2 INTO
						@pdb_assitm,	@pdb_assitm,	@pdb_pckunt,		
						@pdb_bomqty,	@pdb_venno,	@pdb_bcurcde,		
						@pdb_bomcst,	@pdb_colcde,	@vbi_curcde,
						@pdb_curcde,	@pdb_ftyprc,	@pdb_bompoflg,
						@pdb_imperiod
	 		
						while @@fetch_status = 0 	
						begin
							set @pdb_ordqty = (@pod_ordqty * @pda_mtrqty)/@pod_mtrctn * @pdb_bomqty 
								
							if @sdt_updpo = 'Y'or @sdt_chgfty = 'Y'
							begin
								execute SP_SELECT_MEXRATE @cocde, @pdb_bcurcde, @vbi_curcde, "B", '', @return_effdat = @exeffdat output,@return_rate = @rate output
								set @rateffdat = @exeffdat
								
								set @rate1 = 0
								execute SP_SELECT_MEXRATE @cocde, @pdb_curcde, @vbi_curcde, "B", '', @return_effdat = @exeffdat output,@return_rate = @rate1 output
			
								select	@ftyexrate_old = isnull(pdb_ftycurexrat,0),
									@bomexrate_old = isnull(pdb_bomcurexrat,0)
								from	PODTLBOM (nolock)
								where	pdb_cocde = @cocde and
									pdb_purord = @ret_code and
									pdb_seq = @seqno and
									pdb_assitm = @pda_assitm and
									pdb_bomitm = @pdb_assitm and
									pdb_colcde = @pdb_colcde
	
								if @ftyexrate_old <> 0 
								begin
									set @rate1 = @ftyexrate_old	
								end
								
								if @bomexrate_old <> 0 
								begin
									set @rate = @bomexrate_old	
								end
						
								update	PODTLBOM
								set	pdb_ordqty = @pdb_ordqty,
									pdb_imcurcde= @pdb_curcde,
									pdb_imftyprc= @pdb_ftyprc, 
									pdb_curcde = @vbi_curcde,
									pdb_ftyprc=@pdb_ftyprc*@rate1, 
									pdb_bcurcde = @pdb_bcurcde,
									pdb_bomcst =@pdb_bomcst*@rate,
									pdb_pckunt = @pdb_pckunt,
									pdb_bomqty= @pdb_bomqty, 
									pdb_venno = @pdb_venno, 
									pdb_upddat = getdate(),
									--pdb_updusr = 'SCM02-SYS', 
									pdb_updusr = left(@usrid, 30),
									pdb_bompoflg = @pdb_bompoflg,
									pdb_imperiod = @pdb_imperiod
								where	pdb_cocde = @cocde and
									pdb_purord = @ret_code and
									pdb_seq = @seqno and
									pdb_assitm = @pda_assitm and
									pdb_bomitm = @pdb_assitm and
									pdb_colcde = @pdb_colcde
						
								if @@rowcount = 0
								begin
									insert into PODTLBOM 
									(	pdb_cocde,		pdb_purord,		pdb_seq,
										pdb_assitm,		pdb_bomitm,		pdb_colcde,
										pdb_pckunt,		pdb_bomqty,		pdb_venno,
										pdb_curcde,		pdb_imcurcde,		pdb_imftyprc,
										pdb_ftyprc,		pdb_bcurcde,		pdb_bomcst,
										pdb_ordqty,		pdb_bpolne,		pdb_bompno,
										pdb_creusr,		pdb_updusr,		pdb_bompoflg,
										pdb_ftycurexrat,	pdb_ftycurexeffdat,	pdb_bomcurexrat, 
										pdb_bomcurexeffdat,	pdb_imperiod					 
									) 
									values 
									(	@cocde,			@ret_code,		@seqno,
										@pda_assitm,		@pdb_assitm,		@pdb_colcde,
										@pdb_pckunt,		@pdb_bomqty,		@pdb_venno,
										@vbi_curcde,		@pdb_curcde,		@pdb_ftyprc,
										@pdb_ftyprc * @rate1,	@pdb_bcurcde,		@pdb_bomcst * @rate,
										@pdb_ordqty,		0,			'',
										--'SCM02-SYS',		'SCM02-SYS',		@pdb_bompoflg,
										left(@usrid, 30), left(@usrid, 30), @pdb_bompoflg,
										@rate1,			@exeffdat,		@rate, 
										@rateffdat,		@pdb_imperiod
									)
								end
						
								if @@ERROR <> 0 				
								begin 
									 -- return 99 to the calling program to indicate failure.
									 select 'An error occurred when inserting into PODTLBOM'						
									 return(99)	
								end
							end-- end of (if @sdt_updpo = 'Y'or @sdt_chgfty = 'Y' )
		 	
							FETCH NEXT FROM cur_BOM2 INTO
							@pdb_assitm,	@pdb_assitm,	@pdb_pckunt,		
							@pdb_bomqty,	@pdb_venno,	@pdb_bcurcde,		
							@pdb_bomcst,	@pdb_colcde,	@vbi_curcde,
							@pdb_curcde,	@pdb_ftyprc,	@pdb_bompoflg,
							@pdb_imperiod
						end
	
						CLOSE cur_BOM2		
						DEALLOCATE cur_BOM2
	
	
						FETCH NEXT FROM cur_SCASSINF INTO
						@pda_itmno,	@pda_assitm,	@pda_assdsc,
						@pda_cusitm,	@pda_colcde,	@pda_coldsc,
						@pda_cussku,	@pda_upcean,	@pda_cusrtl,
						@pda_pckunt,	@pda_inrqty,	@pda_mtrqty,
						@pda_imperiod, 	@pda_cusstyno
					end 
					
					CLOSE cur_SCASSINF 	
					DEALLOCATE cur_SCASSINF
	
					--cur_SCORDDTLHDR --> cur_SCORDDTL --> cur_SCDTLSHP
	
					DECLARE cur_SCDTLSHP CURSOR FOR
					select	sds_shpseq,	sds_scfrom,	sds_scto,
						sds_pofrom,	sds_poto,	sds_ordqty,
						sds_ctnstr,	sds_ctnend,	sds_ttlctn,
						sds_dest
					from	SCDTLSHP (nolock)
					where	sds_cocde = @cocde and
						sds_ordno = @sdt_ordno and
						sds_seq = @sdt_ordseq
		
					OPEN cur_SCDTLSHP	
					FETCH NEXT FROM cur_SCDTLSHP INTO	
					@pds_seq,	@pds_scfrom,	@pds_scto,
					@pds_pofrom,	@pds_poto,	@pds_ordqty,
					@pds_ctnstr,	@pds_ctnend,	@pds_ttlctn,
					@pds_dest
			 
					while @@fetch_status = 0 
					begin
						if @sdt_updpo = 'Y' or @sdt_chgfty = 'Y'
						begin 
							if @pds_pofrom = '1900-01-01'
							begin
								--set @pds_pofrom = @pds_scfrom - @vbi_tsttim - @vbi_bufday
								set @pds_pofrom = @pds_scfrom - @csf_shpstrbuf
							end

-- 20150506 Remove PO Ship Date > getdate, use getdate logic
/*							if getdate() > @pds_pofrom
							begin
								set @pds_pofrom = getdate()
							end
*/							
							if @pds_poto = '1900-01-01'
							begin
								--set @pds_poto = @pds_scto - @vbi_tsttim - @vbi_bufday
								set @pds_poto = @pds_scto - @csf_shpendbuf
							end

--20150506 Remove PO Ship Date > getdate, use getdate logic
/*							if getdate() > @pds_poto
							begin
								set @pds_poto = getdate()
							end
*/							
							insert into PODTLSHP
							(	pds_cocde,	pds_purord,	pds_seq,
								pds_shpseq,	pds_from,	pds_to,
								pds_ordqty,	pds_ctnstr,	pds_ctnend,
								pds_ttlctn,	pds_dest,	pds_creusr,
								pds_updusr,	pds_credat,	pds_upddat
							)
							values
							(	@cocde,		@ret_code,	@seqno,
								@pds_seq,	@pds_pofrom,	@pds_poto,
								@pds_ordqty,	@pds_ctnstr,	@pds_ctnend,
								--@pds_ttlctn,	@pds_dest,	'SCM02-SYS',
								@pds_ttlctn,	@pds_dest,	left(@usrid, 30),
								--'SCM02-SYS',	getdate(),	getdate()
								left(@usrid, 30), getdate(), getdate()
							)
								
							-- Insert into First Ship Date Record
							INSERT INTO SCDTLFSD
							(	sdf_cocde,	sdf_ordno,	sdf_ordseq,
								sdf_shpseq,	sdf_ttlctn,	sdf_from,
								sdf_to,		sdf_creusr,	sdf_credat
							)
							VALUES
							(	@sdt_cocde,	@sdt_ordno,	@sdt_ordseq,
								@pds_seq,	@pds_ttlctn,	@pds_scfrom,
								@pds_scto,	@usrid,		getdate()
							)
							
							if @@ERROR <> 0			
							begin 
								-- return 99 to the calling program to indicate failure.
								SELECT 'An error occurred when inserting into PODTLSHP'
								return(99)
							end
						end -- end of (if @sdt_updpo = 'Y') 
		
						FETCH NEXT FROM cur_SCDTLSHP INTO	
						@pds_seq,	@pds_scfrom,	@pds_scto,
						@pds_pofrom,	@pds_poto,	@pds_ordqty,
						@pds_ctnstr,	@pds_ctnend,	@pds_ttlctn,
						@pds_dest
					end
		
					CLOSE cur_SCDTLSHP 	
					DEALLOCATE cur_SCDTLSHP 

					--- Cater Regular Item with BOM Only --- 	
					--cur_SCORDDTLHDR --> cur_SCORDDTL --> cur_BOM1
					DECLARE cur_BOM1 CURSOR FOR
					select	sbi_assitm,	sbi_bomitm,	sbi_pckunt,
						sbi_ordqty,	sbi_venno,	sbi_fcurcde,
						sbi_ftyprc,	sbi_colcde,	vbi_curcde, 
						sbi_bcurcde,	sbi_bomcst,	sbi_bompoflg,
						sbi_imperiod
					from	SCBOMINF (nolock),
						VNBASINF (nolock) 
					where	sbi_cocde = @cocde and
						sbi_ordno = @sdt_ordno and
						sbi_ordseq = @sdt_ordseq and
						vbi_venno = sbi_venno and
						ltrim(rtrim(sbi_assitm)) = ''
	
					OPEN cur_BOM1	
					FETCH NEXT FROM cur_BOM1 INTO
					@pda_assitm,	@pdb_assitm,	@pdb_pckunt, 		 
					@pdb_bomqty,	@pdb_venno,	@pdb_bcurcde, 		 
					@pdb_bomcst,	@pdb_colcde,	@vbi_curcde,
					@pdb_curcde,	@pdb_ftyprc,	@pdb_bompoflg,
					@pdb_imperiod
	
					while @@fetch_status = 0
					begin
						set @pdb_ordqty = @pod_ordqty * @pdb_bomqty
	
						if @sdt_updpo = 'Y'or @sdt_chgfty = 'Y'
						begin 
							set @rate1 = 0
							execute SP_SELECT_MEXRATE @cocde, @pdb_bcurcde, @vbi_curcde, "B", '', @return_effdat = @exeffdat output,@return_rate = @rate1 output 
					
							select	@ftyexrate_old = isnull(pdb_ftycurexrat,0),
								@bomexrate_old = isnull(pdb_bomcurexrat,0)
							from	PODTLBOM (nolock)
							where	pdb_cocde = @cocde and
								pdb_purord = @ret_code and
								pdb_seq = @seqno and
								pdb_assitm = @pda_assitm and
								pdb_bomitm = @pdb_assitm and
								pdb_colcde = @pdb_colcde
	
							if @ftyexrate_old <> 0 
							begin
								set @rate1 = @ftyexrate_old	
							end
				
							if @bomexrate_old <> 0 
							begin
								set @rate = @bomexrate_old	
							end
			
							update	PODTLBOM
							set	pdb_ordqty = @pdb_ordqty,
								pdb_imcurcde= @pdb_curcde,
								pdb_imftyprc= @pdb_ftyprc, 
								pdb_curcde = @vbi_curcde,
								pdb_ftyprc = @pdb_ftyprc*@rate1, 
								pdb_bcurcde = @pdb_bcurcde,
								pdb_bomcst = @pdb_bomcst*@rate,
								pdb_pckunt = @pdb_pckunt,
								pdb_bomqty = @pdb_bomqty, 
								pdb_venno = @pdb_venno, 
								pdb_upddat = getdate(),
								--pdb_updusr = 'SCM02-SYS' , 
								pdb_updusr = left(@usrid, 30),
								pdb_bompoflg = @pdb_bompoflg,
								pdb_imperiod = @pdb_imperiod
							where	pdb_cocde = @cocde and
								pdb_purord = @ret_code and
								pdb_seq = @seqno and
								pdb_assitm = @pda_assitm and
								pdb_bomitm = @pdb_assitm and
								pdb_colcde = @pdb_colcde
	
							if @@rowcount = 0
							begin
								INSERT INTO PODTLBOM 
								(	pdb_cocde,		pdb_purord,		pdb_seq,
									pdb_assitm,		pdb_bomitm,		pdb_colcde,
									pdb_pckunt,		pdb_bomqty,		pdb_venno,
									pdb_curcde,		pdb_imcurcde,		pdb_imftyprc, 
									pdb_ftyprc,		pdb_bcurcde,		pdb_bomcst,
									pdb_ordqty,		pdb_bpolne,		pdb_bompno,
									pdb_creusr,		pdb_updusr,		pdb_bompoflg,
									pdb_ftycurexrat,	pdb_ftycurexeffdat,	pdb_bomcurexrat, 
									pdb_bomcurexeffdat,	pdb_imperiod
								) 
								VALUES 
								(	@cocde,			@ret_code,		@seqno,
									@pda_assitm,		@pdb_assitm,		@pdb_colcde,
									@pdb_pckunt,		@pdb_bomqty,		@pdb_venno,
									@vbi_curcde,		@pdb_curcde,		@pdb_ftyprc,
									@pdb_ftyprc * @rate1,	@pdb_bcurcde,		@pdb_bomcst * @rate,
									@pdb_ordqty,		0, 			'',
									--'SCM02-SYS',		'SCM02-SYS',		@pdb_bompoflg,
									left(@usrid, 30), left(@usrid, 30), @pdb_bompoflg,
									@rate1, 		@exeffdat,		@rate,
									@rateffdat,		@pdb_imperiod
								)
							end
		
							if @@ERROR <> 0			
							begin 
								-- return 99 to the calling program to indicate failure.
								select 'An error occurred when inserting into PODTLBOM'
								return(99) 
							end 			 
						end-- end of (	if @sdt_updpo = 'Y'or @sdt_chgfty = 'Y')
						
						FETCH NEXT FROM cur_BOM1 INTO 	 
						@pda_assitm,	@pdb_assitm,	@pdb_pckunt, 		 
						@pdb_bomqty,	@pdb_venno,	@pdb_bcurcde, 		 
						@pdb_bomcst,	@pdb_colcde,	@vbi_curcde,
						@pdb_curcde,	@pdb_ftyprc,	@pdb_bompoflg,
						@pdb_imperiod
					end
					
					CLOSE cur_BOM1 	
					DEALLOCATE cur_BOM1
				end
			end
	 
			FETCH NEXT FROM cur_SCORDDTL INTO 
			@sdt_fcurcde,	@sdt_itmsts,	@sdt_cusven, 
			@sdt_purord,	@sdt_purseq,	@sdt_cocde,
			@sdt_ordno,	@sdt_ordseq,	@sdt_updpo,
			@sdt_chgfty,	@sdt_itmno,	@sdt_itmtyp,
			@sdt_itmdsc,	@sdt_colcde,	@sdt_cuscol,
			@sdt_coldsc,	@sdt_pckseq,	@sdt_pckunt,
			@sdt_inrctn,	@sdt_mtrctn,	@sdt_cft,
			@sdt_cbm,	@sdt_qutno,	@sdt_refdat,
			@sdt_cusitm,	@sdt_cussku,	@sdt_resppo,
			@sdt_cuspo,	@sdt_ordqty,	@sdt_discnt,
			@sdt_oneprc,	@sdt_curcde,	@sdt_selprc,
			@sdt_hrmcde,	@sdt_dtyrat,	@sdt_dept, 
			@sdt_typcode,	@sdt_Code1,	@sdt_Code2,
			@sdt_Code3,	@sdt_cususd,	@sdt_cuscad,
			@sdt_inrdin,	@sdt_inrwin,	@sdt_inrhin,
			@sdt_mtrdin,	@sdt_mtrwin,	@sdt_mtrhin,
			@sdt_inrdcm,	@sdt_inrwcm,	@sdt_inrhcm,
			@sdt_mtrdcm,	@sdt_mtrwcm,	@sdt_mtrhcm,
			@sdt_shpstr,	@sdt_shpend,	@sdt_candat,
			@sdt_ctnstr,	@sdt_ctnend,	@sdt_ttlctn,
			@sdt_rmk,	@sdt_invqty,	@sdt_shpqty,
			@sdt_ftyprc,	@sdt_ftycst,	@sdt_subcde,
			@sdt_venitm,	@sdt_pckitr,	@sdt_oldpurord, 
			@sdt_oldpurseq,	@sdt_cusven,	@sdt_cussub,
			@sdt_pjobno,	@sdt_seccusitm,	@sdt_venno,
			@sod_alsitmno,	@sod_alscolcde,	@sod_qutdat,
			@sod_imqutdat,	@sdt_tradeven,	@sdt_examven,
			@sdt_posstr,	@sdt_posend,	@sdt_poscan,
			@sdt_cususdcur,	@sdt_cuscadcur,	@sdt_pormk,
			@sdt_cus1no,	@sdt_cus2no,	@sdt_ftyprctrm,
			@sdt_hkprctrm,	@sdt_trantrm, @sod_itmchidsc
		end 
		
		CLOSE cur_SCORDDTL
		DEALLOCATE cur_SCORDDTL

		---- Calculate the Ship Start Date & Ship end Date ---
		select	@ShpStartDate = min(pod_shpstr)
		from	POORDDTL (nolock)
		where	pod_cocde = @cocde and
			pod_purord = @ret_code
		
		select	@ShpendDate = max(pod_shpend)
		from	POORDDTL (nolock)
		where	pod_cocde = @cocde and
			pod_purord = @ret_code
		---------------------------------------------------------------
		
		select	@pod_ttlctn = sum(pod_ttlctn),
			@pod_lnecub = sum(pod_lnecub),
			@pod_lneamt = round(sum(pod_lneamt),2),
			@pod_jobord = ''
		from	POORDDTL (nolock)
		where	pod_cocde = @cocde and
			pod_purord = @ret_code
	
		update	PODISPRM
		set	pdp_paamt = round(@pod_lneamt * pdp_purpct / 100,2)
		where	pdp_cocde = @cocde and
			pdp_purord = @ret_code and
			pdp_pctamt = 'P'
		
		select	@tmpamt = sum(p.pdp_paamt) - sum(d.pdp_paamt)
		from	PODISPRM p (nolock),
			PODISPRM d (nolock)
		where	p.pdp_cocde = @cocde and
			p.pdp_purord = @ret_code and
			p.pdp_pdptyp = 'P' and
			d.pdp_cocde = p.pdp_cocde and
			d.pdp_purord = p.pdp_purord and
			d.pdp_pdptyp = 'D'
	
		if @tmpamt is NULL
		begin
			set @tmpamt = 0
		end
 
		-- DY 2013-11-22 Add PO Cancel Window based on POORDDTL Cancel Date
		if (select count(*) from POORDDTL (nolock) where pod_cocde = @cocde and pod_purord = @ret_code and pod_candat <> '1900-01-01') = 0
		begin
			set @CanDatStr = '1900-01-01'
			set @CanDatEnd = '1900-01-01'
		end
		else
		begin
			select	@CanDatStr = min(pod_candat),
				@CanDatEnd = max(pod_candat)
			from	POORDDTL (nolock)
			where	pod_cocde = @cocde and
				pod_purord = @ret_code and
				pod_candat <> '1900-01-01'
		end

		update	POORDHDR 
		set	poh_shpstr = @ShpStartDate, 
			poh_shpend = @ShpendDate ,
			poh_ttlctn = @pod_ttlctn,
			poh_ttlcbm = @pod_lnecub,
			poh_ttlamt = @pod_lneamt,
			poh_netamt = round((@pod_lneamt + @tmpamt) * (1 - (@poh_discnt/100)),2),
			poh_pocdat = @CanDatStr,
			poh_pocdatend = @canDatEnd,
			poh_upddat = getdate(),
			--poh_updusr = 'SCM02-SYS'
			poh_updusr = left(@usrid, 30)
		where	poh_cocde = @cocde and
			poh_purord = @ret_code 

		FETCH NEXT FROM cur_SCORDDTLHDR INTO 
		@sco_ordno,	@sco_cusven
	end
 
	CLOSE cur_SCORDDTLHDR 
	DEALLOCATE cur_SCORDDTLHDR
	
	-- Change Factory Processing --
	-- update old purchase order's order qty.
	update	p
	set	p.pod_ordqty = p.pod_recqty,
		p.pod_lneamt = p.pod_recqty * p.pod_ftyprc,
		p.pod_lnecub = p.pod_cubcft * p.pod_recqty / p.pod_mtrctn,
		p.pod_ttlctn = p.pod_recqty / p.pod_mtrctn,
		p.pod_scno = '',
		p.pod_scline = 0,
		p.pod_jobord = '',
		p.pod_runno = '',
		p.pod_upddat = getdate(),
		--p.pod_updusr = 'SCM02-SYS'
		p.pod_updusr = left(@usrid, 30)
	from	POORDDTL p (nolock),
		SCORDDTL s (nolock),
		SCORDHDR h (nolock)
	where	h.soh_cocde = s.sod_cocde and
		h.soh_ordno = s.sod_ordno and
		s.sod_cocde = p.pod_cocde and
		s.sod_oldpurord = p.pod_purord and
		s.sod_oldpurseq = p.pod_purseq and
		(s.sod_oldpurord <> s.sod_purord or s.sod_oldpurseq <> s.sod_purseq) and
		h.soh_ordsts = 'ACT' and
		h.soh_ordno >= @from and
		h.soh_ordno <= @to and
		h.soh_cocde = @cocde

	-- check for old purord & purseq <> current purord and purseq 
	DECLARE
	@purord		nvarchar(20),
	@purseq		int

	DECLARE
	@bompno		nvarchar(20),
	@bpolne		int,
	@bomitm		nvarchar(20),
	@bomcolcde	nvarchar(30),
	@ordqty		int,
	@ttlamt		numeric (13,4),
	@disprc		numeric (13,4),
	@disamt		numeric (13,4)

	DECLARE cur_OLDPO CURSOR FOR
	select distinct
		d.sod_oldpurord
	from	SCORDDTL d (nolock),
		SCORDHDR h (nolock)
	where	h.soh_ordsts = 'ACT' and
		h.soh_ordno >= @from and
		h.soh_ordno <= @to and
		h.soh_cocde = @cocde and
		d.sod_ordno = h.soh_ordno and
		d.sod_cocde = h.soh_cocde and
		d.sod_oldpurord <> '' and
		d.sod_oldpurord is NOT NULL
	group by
		d.sod_oldpurord

	OPEN cur_OLDPO
	FETCH NEXT FROM cur_OLDPO INTO 
	@purord 

	while @@fetch_status = 0
	begin
		select	@pod_ttlctn = sum(pod_ttlctn),
			@pod_lnecub = SUM(pod_lnecub),
			@pod_lneamt = SUM(pod_lneamt)
		from	POORDDTL (nolock)
		where	pod_cocde = @cocde and
			pod_purord = @purord
 
		update	PODISPRM
		set	pdp_paamt = Round(@pod_lneamt * pdp_purpct / 100,2)
		where	pdp_cocde = @cocde and
			pdp_purord = @purord and
			pdp_pctamt = 'P'
 		
		select	@tmpamt = SUM(p.pdp_paamt) - SUM(d.pdp_paamt)
		from	PODISPRM p (nolock),
			PODISPRM d (nolock)
		where	p.pdp_cocde = @cocde and
			p.pdp_purord = @purord and
			p.pdp_pdptyp = 'P' and
			d.pdp_cocde = p.pdp_cocde and
			d.pdp_purord = p.pdp_purord and
			d.pdp_pdptyp = 'D'
 
		if @tmpamt IS NULL
		begin
			set @tmpamt = 0
		end
 
		update	POORDHDR
		set	poh_ttlctn = @pod_ttlctn,
			poh_ttlcbm = @pod_lnecub,
			poh_ttlamt = @pod_lneamt,
			poh_netamt = round((@pod_lneamt + @tmpamt) * (1 - (@poh_discnt/100)),2),
			poh_upddat = getdate(),
			--poh_updusr = 'SCM02-SYS'
			poh_updusr = left(@usrid, 30)
		where	poh_cocde = @cocde and
			poh_purord = @purord

		FETCH NEXT FROM cur_OLDPO INTO 
		@purord 
	end 

	CLOSE cur_OLDPO 
	DEALLOCATE cur_OLDPO 

	DECLARE cur_OLDPO CURSOR FOR 
	select	distinct
		d.sod_oldpurord,
		d.sod_oldpurseq
	from	SCORDDTL d (nolock),
		SCORDHDR h (nolock)
	where	h.soh_ordsts = 'ACT' and
		h.soh_ordno >= @from and
		h.soh_ordno <= @to and
		h.soh_cocde = @cocde and
		d.sod_ordno = h.soh_ordno and
		d.sod_cocde = h.soh_cocde and
		d.sod_oldpurord <> '' and
		d.sod_oldpurord is NOT NULL
	group by
		d.sod_oldpurord, d.sod_oldpurseq

	OPEN cur_OLDPO
	FETCH NEXT FROM cur_OLDPO INTO 
	@purord,	@purseq

	while @@fetch_status = 0
	begin
		--- Update BOM PO Information ---
		DECLARE cur_BOMPO CURSOR FOR 
		select	pdb_bompno,	pdb_bpolne,	pdb_bomitm,
			pdb_colcde,	pdb_ordqty
		from	PODTLBOM (nolock)
		where	pdb_cocde = @cocde and
			pdb_purord = @purord and
			pdb_seq = @purseq
		
		OPEN cur_BOMPO
		FETCH NEXT FROM cur_BOMPO INTO 
		@bompno,	@bpolne,	@bomitm, 
		@bomcolcde,	@ordqty 
	
		while @@fetch_status = 0
		begin
			if LTRIM(RTRIM(@bompno)) <> '' 
			begin
				update	POBOMDTL
				set	pbd_orgordqty = 0,
					pbd_ordqty = 0,
					pbd_adjqty = 0,
					pbd_bomamt = 0,
					pbd_rioqty = 0,
					pbd_refpo = '',
					--pbd_updusr = 'SCM02-SYS',
					pbd_updusr = left(@usrid, 30),
					pbd_upddat = getdate()
				where	pbd_cocde = @cocde and
					pbd_bompo = @bompno and
					pbd_bomseq= @bpolne and
					pbd_itmno = @bomitm and
					pbd_vencol = @bomcolcde

				select	@ttlamt = sum(pbd_bomamt) 
				from	POBOMDTL (nolock)
				where	pbd_cocde = @cocde and 
					pbd_bompo = @bompno

				select	@disprc = pbh_disprc
				from	POBOMHDR (nolock)
				where	pbh_cocde = @cocde and
					pbh_bompo = @bompno
 
				set @disamt = round(@ttlamt - (@ttlamt * @disprc / 100),2)
 
				update	POBOMHDR
				set	pbh_ttlamt = @ttlamt,
					pbh_disamt = @disamt,
					--pbh_updusr = 'SCM02-SYS',
					pbh_updusr = left(@usrid, 30),
					pbh_upddat = getdate()
				where	pbh_cocde = @cocde and 
					pbh_bompo = @bompno
			end

			FETCH NEXT FROM cur_BOMPO INTO 
			@bompno,	@bpolne,	@bomitm, 
			@bomcolcde,	@ordqty 
		end
		
		CLOSE cur_BOMPO
		DEALLOCATE cur_BOMPO

		-- Reset the Order Qty --
		update	PODTLBOM
		set	pdb_ordqty = 0,
			pdb_bompno = '',
			pdb_bpolne = 0
		where	pdb_cocde = @cocde and
			pdb_purord = @purord and
			pdb_seq = @purseq
 
		FETCH NEXT FROM cur_OLDPO INTO 
		@purord,	@purseq
	end
	
	CLOSE cur_OLDPO 
	DEALLOCATE cur_OLDPO 

	update	d
	set	d.sod_oldpurord = '',
		d.sod_oldpurseq = 0
	from	SCORDDTL d,
		SCORDHDR h
	WHERE	h.soh_ordsts = 'ACT' and
		h.soh_ordno >= @from and
		h.soh_ordno <= @to and
		h.soh_cocde = @cocde and
		d.sod_ordno = h.soh_ordno and
		d.sod_cocde = h.soh_cocde and
		(d.sod_updpo = 'Y' or d.sod_chgfty = 'Y') and
		d.sod_oldpurord <> '' and
		d.sod_oldpurord is NOT NULL

	update	d
	set	d.sod_updpo = 'N',
		d.sod_chgfty = 'N' 
	from	SCORDDTL d,
		SCORDHDR h
	where	h.soh_ordsts = 'ACT' and
		h.soh_ordno >= @from and
		h.soh_ordno <= @to and
		h.soh_cocde = @cocde and
		d.sod_ordno = h.soh_ordno and
		d.sod_cocde = h.soh_cocde 

	DECLARE cur_SCNO CURSOR FOR
	select	distinct
		soh_ordno
	from	SCORDHDR (nolock) 
	where	soh_ordsts = 'ACT' and
		soh_ordno >= @from and
		soh_ordno <= @to and
		soh_cocde = @cocde

	OPEN cur_SCNO 
	FETCH NEXT FROM cur_SCNO INTO 
	@SC_ORD_NO 

	while @@fetch_status = 0
	begin
		--Update SCORDHDR order status Start
		update	SCORDHDR
		set	soh_ordsts = 'REL',
			soh_upddat = getdate(),
			--soh_updusr = 'SCM02-SYS' 
			soh_updusr = left(@usrid, 30)
		where	soh_cocde = @cocde and
			soh_ordno = @SC_ORD_NO
		--Update SCORDHDR order status End
		
		--Insert CUITMPRCDTL Start
		SELECT @cid_verno = soh_verno
		FROM SCORDHDR (nolock)
		WHERE soh_cocde = @cocde
		AND soh_ordno = @SC_ORD_NO
		
		print @cid_verno
		print @SC_ORD_NO
		--Only Insert when version = 1
		if @cid_verno = 1
		BEGIN
			DECLARE cur_CUITMPRCDTL CURSOR FOR
			select 
				soh_cus1no, soh_cus2no, sod_itmno,
				sod_colcde, sod_pckunt, sod_conftr, sod_inrctn,
				sod_mtrctn, sod_hkprctrm, sod_ftyprctrm, sod_trantrm,
				sod_ordseq, sod_apprve
			FROM SCORDHDR (nolock)
			INNER JOIN SCORDDTL
				ON sod_ordno = soh_ordno
			WHERE soh_cocde = @cocde
			AND soh_ordno = @SC_ORD_NO
			
			OPEN cur_CUITMPRCDTL
			FETCH NEXT FROM cur_CUITMPRCDTL INTO
				@cid_cusno,@cid_seccus,@cid_itmno,
				@cid_colcde,@cid_untcde,@cid_conftr,@cid_inrqty,@cid_mtrqty,
				@cid_hkprctrm,@cid_ftyprctrm,@cid_trantrm,
				@cid_refseq,@cid_apvsts
				 
			WHILE @@fetch_status = 0
			BEGIN
				--Get Sequence number for CUITMPRCDTL
				Set  @seq_num_cuitmprcdtl = (	select	isnull(max(cid_seqnum),0) + 1
				from	CUITMPRCDTL
				where	
					cid_cusno = @cid_cusno and
					cid_seccus = @cid_seccus and
					cid_itmno = @cid_itmno and
					cid_colcde = @cid_colcde and
					cid_untcde = @cid_untcde and
					cid_conftr = @cid_conftr and
					cid_inrqty = @cid_inrqty and
					cid_mtrqty = @cid_mtrqty and
					cid_hkprctrm = @cid_hkprctrm and
					cid_ftyprctrm = @cid_ftyprctrm and
					cid_trantrm = @cid_trantrm
				)

				if @cid_apvsts = ''
					set @cid_apvsts = 'N'
				
				--Get Item Vendor Type
				select	@cis_itmventyp = isnull(vbi_ventyp,'')
				from	IMBASINF (nolock)
					left join VNBASINF (nolock) on
						vbi_venno = ibi_venno
				where	ibi_itmno = @cid_itmno
				
				print @SC_ORD_NO+' '+convert(varchar(5),@cid_refseq)
				
				--Insert Start
				INSERT INTO CUITMPRCDTL(
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
					cis_contopc, cis_pcprc,
					
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
				SELECT
					'', soh_cus1no, soh_cus2no, sod_itmno,
					sod_colcde, sod_pckunt, sod_conftr, sod_inrctn,
					sod_mtrctn, sod_hkprctrm, sod_ftyprctrm, sod_trantrm,
					
					@seq_num_cuitmprcdtl, sod_ordno, sod_ordseq, soh_upddat, @cid_apvsts,
					cus1.cbi_cussna, cus2.cbi_cussna,
					sod_itmdsc, sod_coldsc, sod_cuscol, sod_cussku, sod_cusitm, sod_cusstyno,
					sod_dv, sod_venno, sod_cusven, sod_tradeven, sod_examven, 
					
					sod_ordqty, sod_untprc, sod_oneprc,
					sod_hrmcde, sod_dtyrat, sod_dept, sod_typcode,
					sod_code1, sod_code2, sod_code3,
					
					sod_cususdcur, sod_cususd, sod_cuscadcur, sod_cuscad,
					
					sod_inrdin, sod_inrwin, sod_inrhin, sod_mtrdin, sod_mtrwin, sod_mtrhin,
					sod_inrdcm, sod_inrwcm, sod_inrhcm, sod_mtrdcm, sod_mtrwcm, sod_mtrhcm, 
					sod_cft, sod_cbm, sod_pckitr, 
					
					@cis_itmventyp, sod_tirtyp, sod_moqunttyp, sod_moq, sod_curcde, sod_moa, 
					sod_year, sod_season, 
					sod_contopc, sod_pcprc,
					
					sod_effdat, sod_expdat, sod_cus1no, sod_cus2no, 
					sod_fcurcde, 0, sod_bomcst, sod_ftyprc, --sod_ftycst
					sod_curcde, sod_basprc, sod_markup, sod_mrkprc, 
					sod_pckcst, sod_commsn, sod_itmcom, sod_stdprc, 
					sod_mumin, sod_muminprc, sod_discnt, 
					sod_qutdat, 
					
					'SR', 
					sod_qutno, 
					sod_creusr, sod_updusr, getdate(), getdate()
				FROM  [dbo].[scordhdr]
				INNER JOIN [dbo].[scorddtl]
					ON sod_cocde = soh_cocde
					AND sod_ordno = soh_ordno
				LEFT JOIN [dbo].[CUBASINF] AS cus1
					ON soh_cus1no = cus1.cbi_cusno
				LEFT JOIN [dbo].[CUBASINF] AS cus2
					ON soh_cus2no = cus2.cbi_cusno
				WHERE sod_ordno = @SC_ORD_NO
				AND sod_ordseq = @cid_refseq
				--Insert CUITMPRCDDTL End
				
				FETCH NEXT FROM cur_CUITMPRCDTL INTO
					@cid_cusno,@cid_seccus,@cid_itmno,
					@cid_colcde,@cid_untcde,@cid_conftr,@cid_inrqty,@cid_mtrqty,
					@cid_hkprctrm,@cid_ftyprctrm,@cid_trantrm,
					@cid_refseq, @cid_apvsts
			END
	
			CLOSE cur_CUITMPRCDTL
			DEALLOCATE cur_CUITMPRCDTL
		END
		

		FETCH NEXT FROM cur_SCNO INTO @SC_ORD_NO
	end

	CLOSE cur_SCNO
	DEALLOCATE cur_SCNO
	
	if @@ERROR <> 0
	begin
		select 'An error occurred when updating into SCORDHDR'
		return(99)
	end
	
	-- Update All PO Ship Dates back to SCORDDTL
	update	SCORDDTL
	set	sod_posstr = pod_shpstr,
		sod_posend = pod_shpend,
		sod_poscan = pod_candat
	from	SCORDDTL
		left join SCORDHDR (nolock) on
			soh_cocde = sod_cocde and
			soh_ordno = sod_ordno
		join POORDDTL (nolock) on
			pod_cocde = sod_cocde and
			pod_scno = sod_ordno and
			pod_scline = sod_ordseq
		join POORDHDR (nolock) on
			poh_cocde = pod_cocde and
			poh_purord = pod_purord
	where	soh_ordsts = 'REL' and
		sod_cocde = @cocde and
		sod_ordno between @from and @to
	
	update	SCDTLSHP
	set	sds_pofrom = pds_from,
		sds_poto = pds_to
	from	SCDTLSHP
		left join SCORDDTL (nolock) on
			sod_cocde = sds_cocde and
			sod_ordno = sds_ordno and
			sod_ordseq = sds_seq
		left join SCORDHDR (nolock) on
			soh_cocde = sds_cocde and
			soh_ordno = sds_ordno
		join POORDDTL (nolock) on
			pod_cocde = sod_cocde and
			pod_scno = sod_ordno and
			pod_scline = sod_ordseq
		join PODTLSHP (nolock) on
			pds_cocde = pod_cocde and
			pds_purord = pod_purord and
			pds_seq = pod_purseq and
			pds_shpseq = sds_shpseq and
			pds_ordqty = sds_ordqty and
			pds_ctnstr = sds_ctnstr and
			pds_ctnend = sds_ctnend and
			pds_ttlctn = sds_ttlctn
	where	soh_ordsts = 'REL' and
		sod_cocde = @cocde and
		sod_ordno between @from and @to

	if @@ERROR <> 0 
	begin
		-- return 99 to the calling program to indicate failure.
		select 'An error occurred when updating into SCORDDTL'
		return(99)
	end
	else
	begin
		return(0)
	end
end-- end of ( if @fntyp = 'Y')at early start 
 
if @fntyp = 'N' 
begin
	update	SCORDHDR
	set	soh_ordsts = 'ACT',
		soh_rvsdat = getdate(),
		soh_verno = soh_verno + 1,
		soh_upddat = getdate(),
		soh_updusr = left(@usrid, 30) 
	where	soh_ordsts = 'REL' and
		soh_ordno >= @from and
		soh_ordno <= @to and
		soh_cocde = @cocde

	if @@rowcount = 0
 	begin
		select 'Order No Not Found'
		return(99)
	end
	
	-- Concatenate SC DTL Rmk to PO DTL Rmk in SCORDDTL for version 2
	update	SCORDDTL
	set	sod_pormk = left(sod_pormk + case sod_pormk when '' then '' else @feed end + sod_rmk, 300),
		sod_upddat = getdate(),
		sod_updusr = left(@usrid, 30) 
	from	SCORDDTL
		left join SCORDHDR (nolock) on
			soh_cocde = sod_cocde and
			soh_ordno = sod_ordno
	where	sod_cocde = @cocde and
		sod_ordno between @from and @to and
		soh_ordsts = 'ACT' and
		soh_verno = 2
	
end 
---------------------------------------------------------------------------------------------------

END

GO
GRANT EXECUTE ON [dbo].[sp_select_SCM00002] TO [ERPUSER] AS [dbo]
GO
