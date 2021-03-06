/****** Object:  StoredProcedure [dbo].[sp_update_IMUPDDAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMUPDDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMUPDDAT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE    PROCEDURE [dbo].[sp_update_IMUPDDAT] 

@usrid		nvarchar(30)

AS

declare -- IMASSDAT --
@iad_venitm		nvarchar(20),
@iad_acsno		nvarchar(20),
@iad_colcde		nvarchar(30),
@iad_period		datetime

declare -- IMBASINF --
@ibi_cosmth		nvarchar(50)

declare -- IMBOMASS --
@iba_curcde		nvarchar(6),
@iba_untcst		numeric(13, 4),
@iba_fcurcde		nvarchar(6),
@iba_ftycst		numeric(13, 4)

declare -- IMBOMDAT --
@ibd_venitm		nvarchar(20),
@ibd_acsno		nvarchar(20),
@ibd_itmseq		int,
@ibd_recseq		int,
@ibd_colcde		nvarchar(30),
@ibd_qty			int,
@ibd_untcde		nvarchar(6),
@ibd_conftr		int,
@ibd_xlsfil		nvarchar(30),
@ibd_chkdat		datetime,
@ibd_itmdsc		nvarchar(3200),
@ibd_period		datetime

declare -- IMCOLDAT --
@icd_venitm		nvarchar(20),
@icd_itmseq		int,
@icd_recseq		int,
@icd_colcde		nvarchar(30),
@icd_coldsc		nvarchar(300),
@icd_xlsfil		nvarchar(30),
@icd_chkdat		datetime

declare -- IMCOLINF --
@icf_colseq		int

declare -- IMITMDAT --
@iid_venno		nvarchar(6),
@iid_prdven		nvarchar(6),
@iid_venitm		nvarchar(20),
@iid_itmseq		int,
@iid_recseq		int,
@iid_itmtyp		nvarchar(4),
@iid_itmno		nvarchar(20),
@iid_mode		nvarchar(3),
@iid_itmsts		nvarchar(3),
@iid_stage		nvarchar(3),
@iid_engdsc		nvarchar(800),
@iid_chndsc		nvarchar(1600),
@iid_lnecde		nvarchar(10),
@iid_catlvl4		nvarchar(20),
@iid_untcde		nvarchar(6),
@iid_inrqty		int,
@iid_mtrqty		int,
@iid_inrlcm		numeric(11, 4), -- inches
@iid_inrwcm		numeric(11, 4), -- inches
@iid_inrhcm		numeric(11, 4), -- inches
@iid_mtrlcm		numeric(11, 4), -- inches
@iid_mtrwcm		numeric(11, 4), -- inches
@iid_mtrhcm		numeric(11, 4), -- inches
@iid_cft		numeric(11, 4),
@iid_conftr		int,
@iid_curcde		nvarchar(6),
@iid_ftycst		numeric(13, 4),
@iid_ftyprc		numeric(13, 4),
@iid_ftyprctrm		nvarchar(100),
@iid_hkprctrm		nvarchar(100),
@iid_trantrm		nvarchar(100),
@iid_grswgt		numeric(6, 3),
@iid_netwgt		numeric(6, 3),
@iid_pckitr		nvarchar(300),
@iid_xlsfil		nvarchar(30),
@iid_chkdat		datetime,
@iid_orgdsgvenno	nvarchar(6),
@iid_moq		int,
@iid_fcurcde		nvarchar(6),
@iid_wastage		numeric(5, 2),
@iid_remark		nvarchar(2000),
@iid_cusven		nvarchar(6),
@iid_alsitmno		nvarchar(30),
@iid_alscolcde		nvarchar(30),
@iid_bomcst		numeric(13, 4),
@iid_fmlopt		nvarchar(5),
@iid_itmprc		numeric(13, 4),
@iid_bcurcde		nvarchar(6),
@iid_basprc		numeric(13, 4),
@iid_bomprc		numeric(13, 4),
@iid_period		datetime,
@iid_effdat		datetime,
@iid_cstexpdat		datetime,
@iid_inrsze		nvarchar(500),
@iid_mtrsze		nvarchar(500),
@iid_mat		nvarchar(500),
@iid_ftytmp		nvarchar(1),
@iid_alstmpitmno	nvarchar(20)

declare	-- IMITMDATCST --
@iic_venno		nvarchar(6),
@iic_prdven		nvarchar(6),
@iic_venitm		nvarchar(20),
@iic_itmseq		int,
@iic_recseq		int,
@iic_xlsfil		nvarchar(30),
@iic_chkdat		datetime,
@iic_cus1no		nvarchar(6),
@iic_cus2no		nvarchar(6),
@iic_untcde		nvarchar(6),
@iic_inrqty		int,
@iic_mtrqty		int,
@iic_ftycstA		numeric(13, 4),
@iic_ftycstB		numeric(13, 4),
@iic_ftycstC		numeric(13, 4),
@iic_ftycstD		numeric(13, 4),
@iic_ftycstE		numeric(13, 4),
@iic_ftycstTran		numeric(13, 4),
@iic_ftycstPack		numeric(13, 4),
@iic_ftycst		numeric(13, 4),
@iic_ftyprcA		numeric(13, 4),
@iic_ftyprcB		numeric(13, 4),
@iic_ftyprcC		numeric(13, 4),
@iic_ftyprcD		numeric(13, 4),
@iic_ftyprcE		numeric(13, 4),
@iic_ftyprcTran		numeric(13, 4),
@iic_ftyprcPack		numeric(13, 4),
@iic_ftyprc		numeric(13, 4),
@iic_chgfp		numeric(13, 2),
@iic_chgfpA		numeric(13, 2),
@iic_chgfpB		numeric(13, 2),
@iic_chgfpC		numeric(13, 2),
@iic_chgfpD		numeric(13, 2),
@iic_chgfpE		numeric(13, 2),
@iic_chgfpTran		numeric(13, 2),
@iic_chgfpPack		numeric(13, 2),
@iic_nat		nvarchar(6),
@iic_negprc		numeric(13, 4),
@iic_conftr		int

declare -- IMPCKINF --
@ipi_pckseq		int

declare -- IMPRCCHG --
@ipc_chgreason		nvarchar(800)

declare -- IMPRCINF --
@imu_prdven		nvarchar(6),
@imu_ventyp		nvarchar(1),
@imu_effdat		datetime,
@imu_expdat		datetime,
@imu_curcde		nvarchar(6),
@imu_ftycst		numeric(13, 4),
@imu_ftycstA		numeric(13, 4),
@imu_ftycstB		numeric(13, 4),
@imu_ftycstC		numeric(13, 4),
@imu_ftycstD		numeric(13, 4),
@imu_ftycstE		numeric(13, 4),
@imu_ftycstTran		numeric(13, 4),
@imu_ftycstPack		numeric(13, 4),
@imu_ftyprc		numeric(13, 4),
@imu_ftyprcA		numeric(13, 4),
@imu_ftyprcB		numeric(13, 4),
@imu_ftyprcC		numeric(13, 4),
@imu_ftyprcD		numeric(13, 4),
@imu_ftyprcE		numeric(13, 4),
@imu_ftyprcTran		numeric(13, 4),
@imu_ftyprcPack		numeric(13, 4),
@imu_ttlcst		numeric(13, 4),
@imu_bomcst		numeric(13, 4),
@imu_bomprc		numeric(13, 4),
@imu_hkadjper		numeric(13, 4),
@imu_negcst		numeric(13, 4),
@imu_negprc		numeric(13, 4),
@imu_fmlopt		nvarchar(5),
@imu_bcurcde		nvarchar(6),
@imu_itmprc		numeric(13, 4),
@imu_basprc		numeric(13, 4),
@imu_period		nvarchar(10),
@imu_cstchgdat		datetime

declare -- Misc --
@cbmcft			numeric(12, 4),
@incm			numeric(10, 4),
@selrat			numeric(16, 11)


create table #tmp_IMPCKINF
(					ipi_itmno nvarchar(20),
					ipi_pckunt nvarchar(20),
					ipi_conftr int,
					ipi_inrqty int,
					ipi_mtrqty int,
					ipi_cus1no nvarchar(20),
					ipi_cus2no nvarchar(20),
					ipi_qutdat datetime
)


DECLARE cur_IMITMDAT CURSOR
FOR	select	iid_venno,		iid_prdven,		iid_venitm,
		iid_itmseq,		iid_recseq,		iid_itmtyp,
		iid_itmno,		iid_mode,		iid_itmsts,
		iid_stage,		iid_engdsc,		iid_chndsc,
		iid_lnecde,		iid_catlvl4,		iid_untcde,
		iid_inrqty,		iid_mtrqty,		iid_inrlcm,
		iid_inrwcm,		iid_inrhcm,		iid_mtrlcm,
		iid_mtrwcm,		iid_mtrhcm,		iid_cft,
		iid_conftr,		iid_curcde,		iid_ftycst,
		iid_ftyprc,		iid_ftyprctrm,		iid_prctrm,
		iid_trantrm,		iid_grswgt,		iid_netwgt,
		iid_pckitr,		iid_xlsfil,		iid_chkdat,
		iid_orgdsgvenno,	iid_moq,		iid_fcurcde,
		iid_wastage,		iid_remark,		iid_cusven,
		iid_alsitmno,		iid_alscolcde,		iid_period,
		iid_cstexpdat,		iid_inrsze,		iid_mtrsze,
		iid_mat,		iid_ftytmp,		iid_alstmpitmno
	from	IMITMDAT (nolock)
	where	iid_stage in ('A','R') and
		iid_mode = 'UPD' and
		iid_updusr = @usrid
	order by iid_itmtyp, iid_venitm, iid_stage, iid_chkdat
		
OPEN cur_IMITMDAT
FETCH NEXT FROM cur_IMITMDAT INTO
@iid_venno,		@iid_prdven,		@iid_venitm,
@iid_itmseq,		@iid_recseq,		@iid_itmtyp,
@iid_itmno,		@iid_mode,		@iid_itmsts,
@iid_stage,		@iid_engdsc,		@iid_chndsc,
@iid_lnecde,		@iid_catlvl4,		@iid_untcde,
@iid_inrqty,		@iid_mtrqty,		@iid_inrlcm,
@iid_inrwcm,		@iid_inrhcm,		@iid_mtrlcm,
@iid_mtrwcm,		@iid_mtrhcm,		@iid_cft,
@iid_conftr,		@iid_curcde,		@iid_ftycst,
@iid_ftyprc,		@iid_ftyprctrm,		@iid_hkprctrm,
@iid_trantrm,		@iid_grswgt,		@iid_netwgt,
@iid_pckitr,		@iid_xlsfil,		@iid_chkdat,
@iid_orgdsgvenno,	@iid_moq,		@iid_fcurcde,
@iid_wastage,		@iid_remark,		@iid_cusven,
@iid_alsitmno,		@iid_alscolcde,		@iid_period,
@iid_cstexpdat,		@iid_inrsze,		@iid_mtrsze,
@iid_mat,		@iid_ftytmp,		@iid_alstmpitmno

select	@cbmcft = isnull(ycf_value,0)
from	SYCONFTR (nolock)
where	ycf_code1 = 'CBM' and
	ycf_code2 = 'CFT'

set @incm = 2.54

WHILE @@fetch_status = 0
BEGIN
	-- Retrieve IMITMDATCST --
	select	@iic_venno = iic_venno,
		@iic_prdven = iic_prdven,
		@iic_venitm = iic_venitm,
		@iic_itmseq = iic_itmseq,
		@iic_recseq = iic_recseq,
		@iic_xlsfil = iic_xlsfil,
		@iic_chkdat = iic_chkdat,
		@iic_cus1no = iic_cus1no,
		@iic_cus2no = iic_cus2no,
		@iic_untcde = iic_untcde,
		@iic_inrqty = iic_inrqty,
		@iic_mtrqty = iic_mtrqty,
		@iic_ftycstA = iic_fcA,
		@iic_ftycstB = iic_fcB,
		@iic_ftycstC = iic_fcC,
		@iic_ftycstD = iic_fcD,
		@iic_ftycstE = iic_fcE,
		@iic_ftycstTran = iic_fcTran,
		@iic_ftycstPack = iic_fcPack,
		@iic_ftycst = iic_ftycst,
		@iic_ftyprcA = iic_icA,
		@iic_ftyprcB = iic_icB,
		@iic_ftyprcC = iic_icC,
		@iic_ftyprcD = iic_icD,
		@iic_ftyprcE = iic_icE,
		@iic_ftyprcTran = iic_icTran,
		@iic_ftyprcPack = iic_icPack,
		@iic_ftyprc = iic_ftyprc,
		@iic_nat = iic_nat,
		@iic_negprc = iic_negprc,
		@iic_conftr = iic_conftr
	from	IMITMDATCST (nolocK)
	where	iic_venitm = @iid_venitm and
		iic_itmseq = @iid_itmseq and
		iic_recseq = @iid_recseq and
		iic_xlsfil = @iid_xlsfil and
		iic_chkdat = @iid_chkdat
	
	if @iid_stage = 'A'
	begin
-- IMCOLINF START --
		DECLARE cur_IMCOLDAT CURSOR
		FOR	select	icd_venitm,	icd_itmseq,	icd_recseq,
				icd_colcde,	icd_coldsc,	icd_xlsfil,
				icd_chkdat
			from	IMCOLDAT (nolock)
			where	icd_venitm = @iid_venitm and
				icd_itmseq = @iid_itmseq and
				icd_xlsfil = @iid_xlsfil and
				icd_chkdat = @iid_chkdat and
				icd_stage not in ('I','R','O')
			order by icd_itmseq, icd_recseq, icd_colcde
		
		OPEN cur_IMCOLDAT
		FETCH NEXT FROM cur_IMCOLDAT INTO
		@icd_venitm,	@icd_itmseq,	@icd_recseq,
		@icd_colcde,	@icd_coldsc,	@icd_xlsfil,
		@icd_chkdat
		
		WHILE @@fetch_status = 0
		BEGIN
			if (select count(*) from IMCOLINF (nolock) where icf_itmno = @iid_venitm and icf_vencol = @icd_colcde) = 0
			begin
				-- Determine Next Color Sequence --
				select	@icf_colseq = max(icf_colseq) + 1
				from	(
					select	isnull(max(icf_colseq), 0) as icf_colseq
					from	IMCOLINF (nolock)
					where	icf_itmno = @iid_venitm
					UNION
					select	isnull(max(icf_colseq), 0) as icf_colseq
					from	IMCOLINFH (nolock)
					where	icf_itmno = @iid_venitm
					) as t
				
				-- Insert into IMCOLINF --
				insert into IMCOLINF
				(	icf_cocde,		icf_itmno,		icf_colcde,	
					icf_colseq,		icf_vencol,		icf_coldsc,	
					icf_typ,		icf_ucpcde,		icf_eancde,	
					icf_creusr,		icf_updusr,		icf_credat,	
					icf_upddat
				)
				values
				(	'',			@iid_venitm,		@icd_colcde,
					@icf_colseq,		@icd_colcde,		@icd_coldsc,
					'',			'',			'',
					left('E-'+ @usrid, 30),	left('E-'+ @usrid, 30),	getdate(),
					getdate()
				)
			end
			else
			begin
				-- Update IMCOLINF --
				update	IMCOLINF
				set	icf_coldsc = @icd_coldsc,
					icf_updusr = left('E-'+ @usrid, 30),
					icf_upddat = getdate()
				where	icf_itmno = @iid_venitm and
					icf_vencol = @icd_colcde
			end

			FETCH NEXT FROM cur_IMCOLDAT INTO
			@icd_venitm,	@icd_itmseq,	@icd_recseq,
			@icd_colcde,	@icd_coldsc,	@icd_xlsfil,
			@icd_chkdat
		END
		CLOSE cur_IMCOLDAT
		DEALLOCATE cur_IMCOLDAT

		-- Insert into IMCOLDATH --
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
			left('E-'+ @usrid, 30),	icd_credat,		getdate()
		from	IMCOLDAT cur
		where	icd_venitm = @iid_venitm and
			icd_itmseq = @iid_itmseq and
			icd_xlsfil = @iid_xlsfil and
			icd_chkdat = @iid_chkdat and
			icd_stage not in ('I','R','O') and
			(select count(*) from IMCOLDATH his where his.icd_itmseq = cur.icd_itmseq and his.icd_recseq = cur.icd_recseq) = 0

		-- Remove from IMCOLDAT --
		delete	cur
		from	IMCOLDAT cur
		where	icd_venitm = @iid_venitm and
			icd_itmseq = @iid_itmseq and
			icd_xlsfil = @iid_xlsfil and
			icd_chkdat = @iid_chkdat and
			icd_stage not in ('I','R','O') and
			(select count(*) from IMCOLDATH his where his.icd_itmseq = cur.icd_itmseq and his.icd_recseq = cur.icd_recseq) = 1
-- IMCOLINF END --
		
-- IMMATBKD START --
		if (select count(*) from IMCOMDAT (nolock) where imd_venitm = @iid_venitm and imd_itmseq = @iid_itmseq) > 0
		begin
			-- Remove previous Materials from IMMATBKD --
			delete
			from	IMMATBKD
			where	ibm_itmno = @iid_venitm
			
			-- Insert into IMMATBKD --
			insert into IMMATBKD
			(	ibm_cocde,		ibm_itmno,		ibm_matseq,
				ibm_mat,		ibm_curcde,		ibm_cst,
				ibm_cstper,		ibm_wgtper,		ibm_creusr,
				ibm_updusr,		ibm_credat,		ibm_upddat
			)
			select	'',			@iid_venitm,		imd_recseq,
				imd_compon,		@iid_curcde,		0,
				imd_asstive,		0,			left('E-'+ @usrid, 30),
				left('E-'+ @usrid, 30),	getdate(),		getdate()
			from	IMCOMDAT (nolock)
			where	imd_venitm = @iid_venitm and
				imd_itmseq = @iid_itmseq and
				imd_xlsfil = @iid_xlsfil and
				imd_chkdat = @iid_chkdat and
				imd_stage not in ('I','R','O')
			order by imd_recseq

			-- Move to IMCOMDATH --
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
				imd_chkdat,		imd_creusr,		left('E-'+ @usrid, 30),
				imd_credat,		getdate()	
			from	IMCOMDAT cur
			where	imd_venitm = @iid_venitm and
				imd_itmseq = @iid_itmseq and
				imd_xlsfil = @iid_xlsfil and
				imd_chkdat = @iid_chkdat and
				imd_stage not in ('I','R','O') and
				(select count(*) from IMCOMDATH his where his.imd_itmseq = cur.imd_itmseq and his.imd_recseq = cur.imd_recseq) = 0

			-- Remove from IMCOMDAT --
			delete	cur
			from	IMCOMDAT cur
			where	imd_venitm = @iid_venitm and
				imd_itmseq = @iid_itmseq and
				imd_xlsfil = @iid_xlsfil and
				imd_chkdat = @iid_chkdat and
				imd_stage not in ('I','R','O') and
				(select count(*) from IMCOMDATH his where his.imd_itmseq = cur.imd_itmseq and his.imd_recseq = cur.imd_recseq) = 1
		end
-- IMMATBKD END --

-- IMBOMASS (ASS) START --
		if @iid_itmtyp = 'ASS'
		begin
			DECLARE cur_IMASSDAT CURSOR
			FOR	select	iad_venitm,	iad_acsno,	iad_colcde,
					iad_period
				from	IMASSDAT (nolock)
				where	iad_venitm = @iid_venitm and
					iad_itmseq = @iid_itmseq and
					iad_xlsfil = @iid_xlsfil and
					iad_chkdat = @iid_chkdat and
					iad_stage not in ('I','R','O')
			OPEN cur_IMASSDAT
			FETCH NEXT FROM cur_IMASSDAT INTO
			@iad_venitm,	@iad_acsno,	@iad_colcde,
			@iad_period
			
			WHILE @@fetch_status = 0
			BEGIN
				-- Update IMBOMASS --
				update	IMBOMASS
				set	iba_period = @iad_period,
					iba_updusr = left('E-'+ @usrid, 30),
					iba_upddat = getdate()
				where	iba_itmno = @iid_itmno and
					iba_assitm = @iad_acsno and
					iba_colcde = @iad_colcde and
					iba_typ = 'ASS'
				
				FETCH NEXT FROM cur_IMASSDAT INTO
				@iad_venitm,	@iad_acsno,	@iad_colcde,
				@iad_period
			END
			CLOSE cur_IMASSDAT
			DEALLOCATE cur_IMASSDAT
			
			-- Move to IMASSDATH --
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
				iad_period,		iad_creusr,		left('E-'+ @usrid, 30),
				iad_credat,		getdate()
			from	IMASSDAT cur
			where	iad_venitm = @iid_venitm and
				iad_itmseq = @iid_itmseq and
				iad_xlsfil = @iid_xlsfil and
				iad_chkdat = @iid_chkdat and
				iad_stage not in ('I','R','O') and
				(select count(*) from IMASSDATH his where his.iad_itmseq = cur.iad_itmseq and his.iad_recseq = cur.iad_recseq) = 0
			
			-- Remove from IMASSDAT --
			delete	cur
			from	IMASSDAT cur
			where	iad_venitm = @iid_venitm and
				iad_itmseq = @iid_itmseq and
				iad_xlsfil = @iid_xlsfil and
				iad_chkdat = @iid_chkdat and
				iad_stage not in ('I','R','O') and
				(select count(*) from IMASSDATH his where his.iad_itmseq = cur.iad_itmseq and his.iad_recseq = cur.iad_recseq) = 1
		end
-- IMBOMASS (ASS) END --

-- IMBOMASS (BOM) START --
		if (select count(*) from IMBOMDAT (nolock) where ibd_venitm = @iid_venitm and ibd_itmseq = @iid_itmseq and
			ibd_xlsfil = @iid_xlsfil and ibd_chkdat = @iid_chkdat) > 0
		begin
			-- Remove previous BOM from IMBOMASS --
			delete
			from	IMBOMASS
			where	iba_typ = 'BOM' and
				exists (select ibd_venitm from IMBOMDAT (nolock) where ibd_venitm = iba_itmno and 
					ibd_stage not in ('I','O') and ibd_itmseq = @iid_itmseq)

			DECLARE cur_IMBOMDAT CURSOR
			FOR 	select	ibd_venitm,	ibd_acsno,	ibd_itmseq,
					ibd_recseq,	ibd_colcde,	ibd_qty,
					ibd_untcde,	ibd_conftr,	ibd_xlsfil,
					ibd_chkdat,	ibd_itmdsc,	ibd_period
				from	IMBOMDAT (nolock)
				where	ibd_venitm = @iid_venitm and
					ibd_itmseq = @iid_itmseq and
					ibd_xlsfil = @iid_xlsfil and
					ibd_chkdat = @iid_chkdat and
					ibd_stage not in ('I','R','O')

			OPEN cur_IMBOMDAT
			FETCH NEXT FROM cur_IMBOMDAT INTO
			@ibd_venitm,	@ibd_acsno,	@ibd_itmseq,
			@ibd_recseq,	@ibd_colcde,	@ibd_qty,
			@ibd_untcde,	@ibd_conftr,	@ibd_xlsfil,
			@ibd_chkdat,	@ibd_itmdsc,	@ibd_period

			WHILE @@fetch_status = 0
			BEGIN
				-- Retrieve BOM Pricing Info --
				set @iba_curcde = ''
				set @iba_untcst = 0
				set @iba_fcurcde = ''
				set @iba_ftycst = 0
				
				select	@iba_curcde = imu_curcde,
					@iba_untcst = imu_ftyprc,
					@iba_fcurcde = imu_bcurcde,
					@iba_ftycst = imu_ftycst
				from	IMPRCINF (nolock)
				where	imu_itmno = @ibd_acsno and
					imu_typ = 'BOM'

				if (select count(*) from IMBOMASS (nolock) where iba_itmno = @iid_venitm and
					iba_assitm = @ibd_acsno and iba_colcde = @ibd_colcde and iba_typ = 'BOM') = 0
				begin
					-- Insert into IMBOMASS --
					insert into IMBOMASS
					(	iba_cocde,		iba_itmno,		iba_assitm,
						iba_typ,		iba_colcde,		iba_pckunt,
						iba_bomqty,		iba_inrqty,		iba_mtrqty,
						iba_altitmno,		iba_costing,		iba_genpo,
						iba_curcde,		iba_untcst,		iba_ftyfmlopt,
						iba_fmlopt,		iba_bombasprc,		iba_fcurcde,
						iba_ftycst,		iba_period,		iba_creusr,
						iba_updusr,		iba_credat,		iba_upddat
					)
					values
					(	'',			@iid_venitm,		@ibd_acsno,
						'BOM',			@ibd_colcde,		@ibd_untcde,
						@ibd_qty,		0,			0,
						'',			'N',			'Y',
						@iba_curcde,		@iba_untcst,		'PDV',
						'PDV',			0,			@iba_fcurcde,
						@iba_ftycst,		@ibd_period,		left('E-'+ @usrid, 30),
						left('E-'+ @usrid, 30),	getdate(),		getdate()
					)
				end
				else
				begin
					update	IMBOMASS
					set	iba_pckunt = @ibd_untcde,
						iba_bomqty = @ibd_qty,
						iba_curcde = @iba_curcde,
						iba_untcst = @iba_untcst,
						iba_ftyfmlopt = 'PDV',
						iba_fmlopt = 'PDV',
						iba_bombasprc = 0,
						iba_fcurcde = @iba_fcurcde,
						iba_ftycst = @iba_ftycst,
						iba_period = @ibd_period,
						iba_updusr = left('E-'+ @usrid, 30), 
						iba_upddat = getdate()
					where	iba_itmno = @iid_venitm and
						iba_assitm = @ibd_acsno and
						iba_colcde = @ibd_colcde and
						iba_typ = 'BOM'
				end
				
				FETCH NEXT FROM cur_IMBOMDAT INTO
				@ibd_venitm,	@ibd_acsno,	@ibd_itmseq,
				@ibd_recseq,	@ibd_colcde,	@ibd_qty,
				@ibd_untcde,	@ibd_conftr,	@ibd_xlsfil,
				@ibd_chkdat,	@ibd_itmdsc,	@ibd_period
			END
			CLOSE cur_IMBOMDAT
			DEALLOCATE cur_IMBOMDAT
			
			-- Move to IMBOMDATH --
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
				left('E-'+ @usrid, 30),	ibd_credat,		getdate()
			from	IMBOMDAT cur
			where	ibd_venitm = @iid_venitm and
				ibd_itmseq = @iid_itmseq and
				ibd_xlsfil = @iid_xlsfil and
				ibd_chkdat = @iid_chkdat and
				ibd_stage not in ('I','R','O') and
				(select count(*) from IMBOMDATH his where his.ibd_itmseq = cur.ibd_itmseq and his.ibd_recseq = cur.ibd_recseq) = 0
			
			-- Remove from IMBOMDAT --
			delete	cur
			from	IMBOMDAT cur
			where	ibd_venitm = @iid_venitm and
				ibd_itmseq = @iid_itmseq and
				ibd_xlsfil = @iid_xlsfil and
				ibd_chkdat = @iid_chkdat and
				ibd_stage not in ('I','R','O') and
				(select count(*) from IMBOMDATH his where his.ibd_itmseq = cur.ibd_itmseq and his.ibd_recseq = cur.ibd_recseq) = 1
		end
-- IMBOMASS (BOM) END --

-- IMPRCINF START --
		-- Determine Basic Price Currency --
		select	@iid_bcurcde = isnull(ysi_cde, '')
		from	SYSETINF (nolock)
		where	ysi_typ = '06' and
			ysi_def = 'Y'
		
		-- Determine Exchange Rate --
		set	@selrat = 0
		select	@selrat = isnull(yce_selrat, 0)
		from	SYCUREX (nolock)
		where	yce_frmcur = @iid_curcde and
			yce_tocur = @iid_bcurcde and
			yce_iseff = 'Y'
		
		-- Determine Price Change Reason --
		set	@ipc_chgreason = ''
		select	@ipc_chgreason = isnull(ipc_chgreason,'')
		from	IMPRCCHG_tmp (nolock)
		where	ipc_itmno = @iid_venitm and
			ipc_venno = @iid_venno and
			ipc_prdven = @iid_prdven and
			ipc_pckunt = @iid_untcde and
			ipc_inrqty = @iid_inrqty and
			ipc_mtrqty = @iid_mtrqty and
			ipc_cus1no = @iic_cus1no and
			ipc_cus2no = @iic_cus2no and
			ipc_ftyprctrm = @iid_ftyprctrm and
			ipc_hkprctrm = @iid_hkprctrm and
			ipc_trantrm = @iid_trantrm and
			ipc_creusr = @usrid
		
		--update tmp table
					
		if (select count(1) from #tmp_IMPCKINF (nolock)
					where 
					ipi_itmno = @iid_venitm  and
					ipi_pckunt = @iid_untcde and
					ipi_conftr = @iid_conftr and
					ipi_inrqty = @iid_inrqty and
					ipi_mtrqty = @iid_mtrqty and
					ipi_cus1no = @iic_cus1no and
					ipi_cus2no = @iic_cus2no
				) = 0 
				begin
					insert into #tmp_IMPCKINF
					select	ipi_itmno,
								ipi_pckunt,
								ipi_conftr,
								ipi_inrqty ,
								ipi_mtrqty ,
								ipi_cus1no ,
								ipi_cus2no ,
								ipi_qutdat
						from IMPCKINF
						where 
								ipi_itmno = @iid_venitm and
								ipi_pckunt = @iid_untcde and
								ipi_conftr = @iid_conftr and
								ipi_inrqty = @iid_inrqty and
								ipi_mtrqty = @iid_mtrqty and
								ipi_cus1no = @iic_cus1no and
								ipi_cus2no = @iic_cus2no

				end





		-- Update All PV Prices according to IMITMDAT --


		DECLARE cur_IMPRCINF CURSOR
		FOR	select	imu_effdat,	imu_expdat,	imu_curcde,
				imu_ftycst,	imu_ftycstA,	imu_ftycstB,
				imu_ftycstC,	imu_ftycstD,	imu_ftycstE,
				imu_ftycstTran,
				imu_ftycstPack,	imu_ftyprc,	imu_ftyprcA,
				imu_ftyprcB,	imu_ftyprcC,	imu_ftyprcD,
				imu_ftyprcE,
				imu_ftyprcTran,	imu_ftyprcPack,	imu_ttlcst,
				imu_bomcst,	imu_hkadjper,	imu_negcst,
				imu_negprc,	imu_fmlopt,	imu_bcurcde,
				imu_itmprc,	imu_basprc,	ltrim(rtrim(str(datepart(yyyy, ipi_qutdat)))) + '-' + right('0' + ltrim(rtrim(str(datepart(mm, ipi_qutdat)))), 2),
				imu_cstchgdat,	imu_ventyp,	imu_prdven,
				imu_bomprc
			from	IMPRCINF (nolock)
				left join #tmp_IMPCKINF (nolock) on
					ipi_itmno = imu_itmno and
					ipi_pckunt = imu_pckunt and
					ipi_conftr = imu_conftr and
					ipi_inrqty = imu_inrqty and
					ipi_mtrqty = imu_mtrqty and
					ipi_cus1no = imu_cus1no and
					ipi_cus2no = imu_cus2no
			where	imu_itmno = @iid_venitm and
				imu_venno = @iid_venno and
				imu_pckunt = @iid_untcde and
				imu_inrqty = @iid_inrqty and
				imu_mtrqty = @iid_mtrqty and
--				imu_cft = @iid_cft and
				imu_cus1no = @iic_cus1no and
				imu_cus2no = @iic_cus2no and
				imu_conftr = @iid_conftr and
				imu_ftyprctrm = @iid_ftyprctrm and
				imu_hkprctrm = @iid_hkprctrm and
				imu_trantrm = @iid_trantrm
		OPEN cur_IMPRCINF
		FETCH NEXT FROM cur_IMPRCINF INTO
		@imu_effdat,		@imu_expdat,		@imu_curcde,
		@imu_ftycst,		@imu_ftycstA,		@imu_ftycstB,
		@imu_ftycstC,		@imu_ftycstD,		@imu_ftycstE,
		@imu_ftycstTran,
		@imu_ftycstPack,	@imu_ftyprc,		@imu_ftyprcA,
		@imu_ftyprcB,		@imu_ftyprcC,		@imu_ftyprcD,
		@imu_ftyprcE,
		@imu_ftyprcTran,	@imu_ftyprcPack,	@imu_ttlcst,
		@imu_bomcst,		@imu_hkadjper,		@imu_negcst,
		@imu_negprc,		@imu_fmlopt,		@imu_bcurcde,
		@imu_itmprc,		@imu_basprc,		@imu_period,
		@imu_cstchgdat,		@imu_ventyp,		@imu_prdven,
		@imu_bomprc

		WHILE @@fetch_status = 0
		BEGIN
			set @iid_bomcst = 0
			set @iid_bomprc = 0
			set @iid_itmprc = 0
			set @iid_basprc = 0
			set @iid_effdat = cast(datepart(yyyy, getdate()) as varchar(4)) + '-' + right('0' + cast(datepart(mm, getdate()) as varchar(2)), 2) + '-' + cast(right('0' + datepart(dd, getdate()), 2) as varchar(2)) + ' 00:00:00.000'
			set @iic_chgfp = 0
			set @iic_chgfpA = 0
			set @iic_chgfpB = 0
			set @iic_chgfpC = 0
			set @iic_chgfpD = 0
			set @iic_chgfpE = 0
			set @iic_chgfpTran = 0
			set @iic_chgfpPack = 0
			
			-- Determine Expiry Date --
			if @iid_cstexpdat = '1900-01-01'
			begin

				begin
					set @iid_cstexpdat = cast(datepart(yyyy, dateadd(yyyy, 1, getdate())) as varchar(4)) + '-' + right('0' + cast(datepart(mm, getdate()) as varchar(2)), 2) + '-' + cast(right('0' + datepart(dd, getdate() - 1), 2) as varchar(2)) + ' 23:59:59.990'
				end
			end
			


			if @iid_itmtyp = 'BOM'
			begin
				set @iid_fmlopt = ''
				-- Calculate Formula and Basic Price --
				exec sp_select_IMPRCINF_BasPrc @iid_itmseq, @iid_recseq, @iid_venitm, @iid_itmtyp, @iid_xlsfil, @iid_chkdat, @iid_fmlopt output, @iid_bomcst output, @iid_bcurcde output, @iid_itmprc output, @iid_bomprc output, @iid_basprc output				

				if @imu_ftyprc <> @iid_ftyprc or @imu_basprc <> @iid_basprc or 
					@imu_ftyprcA<>@iic_ftyprcA or 
					@imu_ftyprcB<>@iic_ftyprcB or 
					@imu_ftyprcC<>@iic_ftyprcC or 
					@imu_ftyprcD<>@iic_ftyprcD or 
					@imu_ftyprcE<>@iic_ftyprcE or 
					@imu_ftyprcTran<>@iic_ftyprcTran or
					@imu_ftyprcPack<>@iic_ftyprcPack or
					--
					@imu_ftycstA<>@iic_ftycstA or
					@imu_ftycstB<>@iic_ftycstB or
					@imu_ftycstC<>@iic_ftycstC or
					@imu_ftycstD<>@iic_ftycstD or
					@imu_ftycstE<>@iic_ftycstE or
					@imu_ftycstTran<>@iic_ftycstTran or
					@imu_ftycstPack<>@iic_ftycstPack or

					--
				       @imu_ftycst <> @iid_ftycst or 
					@imu_period <> ltrim(rtrim(str(datepart(yyyy, @iid_period)))) + '-' + right('0' + ltrim(rtrim(str(datepart(mm, @iid_period)))), 2)
				begin
					update	IMPRCINF
					set	imu_cft = @iid_cft,
						imu_effdat = @iid_effdat,
						imu_expdat = @iid_cstexpdat,
						imu_status = 'ACT',
						imu_curcde = @iid_curcde,
						imu_ftycst = @iid_ftycst,
						imu_ftycstA = 0,
						imu_ftycstB = 0,
						imu_ftycstC = 0,
						imu_ftycstD = 0,
						imu_ftycstE = 0,
						imu_ftycstTran = 0,
						imu_ftycstPack = 0,
						imu_ftyprc = @iid_ftyprc,
						imu_ftyprcA = 0,
						imu_ftyprcB = 0,
						imu_ftyprcC = 0,
						imu_ftyprcD = 0,
						imu_ftyprcE = 0,
						imu_ftyprcTran = 0,
						imu_ftyprcPack = 0,
						imu_chgfp = @iic_chgfp,
						imu_chgfpA = @iic_chgfpA,
						imu_chgfpB = @iic_chgfpB,
						imu_chgfpC = @iic_chgfpC,
						imu_chgfpD = @iic_chgfpD,
						imu_chgfpE = @iic_chgfpE,
						imu_chgfpTran = @iic_chgfpTran,
						imu_chgfpPack = @iic_chgfpPack,
						imu_bomcst = 0,
						imu_ttlcst = @iid_ftyprc,
						imu_negcst = 0,
						imu_negprc = 0,
						imu_hkadjper = 0,
						imu_fmlopt = @iid_fmlopt,
						imu_bcurcde = @iid_bcurcde,
						imu_itmprc = 0,
						imu_bomprc = 0,
						imu_basprc = 0,
						--imu_period = (cast(datepart(yyyy, @iid_period) as varchar(4)) + '-' + cast(right('0' + datepart(mm, @iid_period), 2) as varchar(2))),
						imu_period = ltrim(rtrim(str(datepart(yyyy, @iid_period)))) + '-' + right('0' + ltrim(rtrim(str(datepart(mm, @iid_period)))), 2),
						imu_cstchgdat = getdate(),
						imu_updusr = left('E-'+ @usrid, 30),
						imu_upddat = getdate()
					where	imu_itmno = @iid_itmno and
						imu_typ = 'BOM' and
						imu_venno = @iid_venno and
						imu_prdven = @imu_prdven and
						imu_pckunt = @iid_untcde and
						imu_inrqty = @iid_inrqty and
						imu_mtrqty = @iid_mtrqty and
						imu_cus1no = @iic_cus1no and
						imu_cus2no = @iic_cus2no and
						imu_ftyprctrm = @iid_ftyprctrm and
						imu_hkprctrm = @iid_hkprctrm and
						imu_trantrm = @iid_trantrm
					
					-- Insert into IMPRCCHG --
					insert into IMPRCCHG
					(	imu_cocde,		imu_itmno,		imu_typ,
						imu_ventyp,		imu_venno,		imu_prdven,
						imu_pckunt,		imu_conftr,		imu_inrqty,
						imu_mtrqty,		imu_cft,		imu_cus1no,
						imu_cus2no,		imu_ftyprctrm,		imu_hkprctrm,
						imu_trantrm,		imu_chgdat,		imu_chgreason,
						imu_effdat_before,	imu_expdat_before,	imu_curcde_before,
						imu_ftycst_before,	
						imu_ftycstA_before,	imu_ftycstB_before,	imu_ftycstC_before,	
						imu_ftycstD_before,	imu_ftycstE_before,	imu_ftycstTran_before,
						imu_ftycstPack_before,	
						imu_fmlA_before,	imu_fmlB_before,	imu_fmlC_before,	
						imu_fmlD_before,	imu_fmlE_before,	imu_fmlTran_before,
						imu_fmlPack_before,	
						imu_ftyprc_before,	
						imu_ftyprcA_before,	imu_ftyprcB_before,	imu_ftyprcC_before,	
						imu_ftyprcD_before,	imu_ftyprcE_before,	imu_ftyprcTran_before,	
						imu_ftyprcPack_before,	
						imu_bomcst_before,
						imu_ttlcst_before,	imu_hkadjper_before,	imu_negcst_before,
						imu_negprc_before,	imu_fmlopt_before,	imu_bcurcde_before,
						imu_itmprc_before,	imu_bomprc_before,	imu_basprc_before,
						imu_period_before,	imu_cstchgdat_before,	imu_effdat_after,
						imu_expdat_after,	imu_curcde_after,	
						imu_ftycst_after,
						imu_ftycstA_after,	imu_ftycstB_after,	imu_ftycstC_after,
						imu_ftycstD_after,	imu_ftycstE_after,	imu_ftycstTran_after,	
						imu_ftycstPack_after,
						imu_fmlA_after,		imu_fmlB_after,		imu_fmlC_after,
						imu_fmlD_after,		imu_fmlE_after,		imu_fmlTran_after,	
						imu_fmlPack_after,
						imu_ftyprc_after,	
						imu_ftyprcA_after,	imu_ftyprcB_after,	imu_ftyprcC_after,	
						imu_ftyprcD_after,	imu_ftyprcE_after,	imu_ftyprcTran_after,
						imu_ftyprcPack_after,	
						imu_bomcst_after,	imu_ttlcst_after,
						imu_hkadjper_after,	imu_negcst_after,	imu_negprc_after,
						imu_fmlopt_after,	imu_bcurcde_after,	imu_itmprc_after,
						imu_bomprc_after,	imu_basprc_after,	imu_period_after,
						imu_cstchgdat_after,	imu_creusr,		imu_updusr,
						imu_credat,		imu_upddat
					)
					values
					(	'UCPP',			@iid_venitm,		@iid_itmtyp,
						@imu_ventyp,		@iid_venno,		@imu_prdven,
						@iid_untcde,		@iid_conftr,		@iid_inrqty,
						@iid_mtrqty,		@iid_cft,		@iic_cus1no,
						@iic_cus2no,		@iid_ftyprctrm,		@iid_hkprctrm,
						@iid_trantrm,		getdate(),		@ipc_chgreason,
						@imu_effdat,		@imu_expdat,		@imu_curcde,
						@imu_ftycst,		
						@imu_ftycstA,		@imu_ftycstB,		@imu_ftycstC,		
						@imu_ftycstD,		@imu_ftycstE,		@imu_ftycstTran,
						@imu_ftycstPack,	
						'',			'',			'',
						'',			'',			'',
						'',			
						@imu_ftyprc,		
						@imu_ftyprcA,		@imu_ftyprcB,		@imu_ftyprcC,		
						@imu_ftyprcD,		@imu_ftyprcE,		@imu_ftyprcTran,	
						@imu_ftyprcPack,	
						@imu_bomcst,
						@imu_ttlcst,		@imu_hkadjper,		@imu_negcst,
						@imu_negprc,		@imu_fmlopt,		@imu_bcurcde,
						@imu_itmprc,		@imu_bomprc,		@imu_basprc,
						@imu_period,		@imu_cstchgdat,		@iid_effdat,
						@iid_cstexpdat,		@iid_curcde,		
						@iid_ftycst,
						0,			0,			0,
						0,			0,			0,
						0,
						'',			'',			'',
						'',			'',			'',
						'',
						@iid_ftyprc,		
						0,			0,			0,
						0,			0,			0,
						0,			
						0,			@iid_ftyprc,
						0,			0,			0,
						@iid_fmlopt,		@iid_bcurcde,		0,
						0,			0,			ltrim(rtrim(str(datepart(yyyy, @iid_period)))) + '-' + right('0' + ltrim(rtrim(str(datepart(mm, @iid_period)))), 2),
						getdate(),		left('E-'+ @usrid, 30),	left('E-'+ @usrid, 30),
						getdate(),		getdate()
					)
				end
			end
			else
			begin
				set @iid_fmlopt = ''
				-- Calculate Formula and Basic Price --
				exec sp_select_IMPRCINF_BasPrc @iid_itmseq, @iid_recseq, @iid_venitm, @iid_itmtyp, @iid_xlsfil, @iid_chkdat, @iid_fmlopt output, @iid_bomcst output, @iid_bcurcde output, @iid_itmprc output, @iid_bomprc output, @iid_basprc output
				
				if @imu_ftyprc <> @iid_ftyprc or @imu_basprc <> @iid_basprc or 				
					@imu_ftyprcA<>@iic_ftyprcA or 
					@imu_ftyprcB<>@iic_ftyprcB or 
					@imu_ftyprcC<>@iic_ftyprcC or 
					@imu_ftyprcD<>@iic_ftyprcD or 
					@imu_ftyprcE<>@iic_ftyprcE or 
					@imu_ftyprcD<>@iic_ftyprcD or 
					@imu_ftyprcE<>@iic_ftyprcE or 
					@imu_ftyprcTran<>@iic_ftyprcTran or
					@imu_ftyprcPack<>@iic_ftyprcPack or
					--
					@imu_ftycstA<>@iic_ftycstA or
					@imu_ftycstB<>@iic_ftycstB or
					@imu_ftycstC<>@iic_ftycstC or
					@imu_ftycstD<>@iic_ftycstD or
					@imu_ftycstE<>@iic_ftycstE or
					@imu_ftycstTran<>@iic_ftycstTran or
					@imu_ftycstPack<>@iic_ftycstPack or

					--
				       @imu_ftycst <> @iid_ftycst or 
					@imu_period <> ltrim(rtrim(str(datepart(yyyy, @iid_period)))) + '-' + right('0' + ltrim(rtrim(str(datepart(mm, @iid_period)))), 2)
				begin
					-- Calculate Change Percentage --
					if @iid_ftycst = 0 or @iid_ftyprc = 0
						set @iic_chgfp = 0
					else
						set @iic_chgfp = round((@iid_ftyprc / @iid_ftycst * 100) - 100, 2)
					if @iic_ftycstA = 0 or @iic_ftyprcA = 0
						set @iic_chgfpA = 0
					else
						set @iic_chgfpA = round((@iic_ftyprcA / @iic_ftycstA * 100) - 100, 2)
					if @iic_ftycstB = 0 or @iic_ftyprcB = 0
						set @iic_chgfpB = 0
					else
						set @iic_chgfpB = round((@iic_ftyprcB / @iic_ftycstB * 100) - 100, 2)
					if @iic_ftycstC = 0 or @iic_ftyprcC = 0
						set @iic_chgfpC = 0
					else
						set @iic_chgfpC = round((@iic_ftyprcC / @iic_ftycstC * 100) - 100, 2)
					if @iic_ftycstD = 0 or @iic_ftyprcD = 0
						set @iic_chgfpD = 0
					else
						set @iic_chgfpD = round((@iic_ftyprcD / @iic_ftycstD * 100) - 100, 2)
					if @iic_ftycstE = 0 or @iic_ftyprcE = 0
						set @iic_chgfpE = 0
					else
						set @iic_chgfpE = round((@iic_ftyprcE / @iic_ftycstE * 100) - 100, 2)
					if @iic_ftycstTran = 0 or @iic_ftyprcTran = 0
						set @iic_chgfpTran = 0
					else
						set @iic_chgfpTran = round((@iic_ftyprcTran / @iic_ftycstTran * 100) - 100, 2)
					if @iic_ftycstPack = 0 or @iic_ftyprcPack = 0
						set @iic_chgfpPack = 0
					else
						set @iic_chgfpPack = round((@iic_ftyprcPack / @iic_ftycstPack * 100) - 100, 2)
					
					-- Update IMPRCINF --
					update	IMPRCINF
					set	imu_cft = @iid_cft,
						imu_effdat = @iid_effdat,
						imu_expdat = @iid_cstexpdat,
						imu_status = 'ACT',
						imu_curcde = @iid_curcde,
						imu_ftycst = @iid_ftycst,
						imu_ftycstA = isnull(@iic_ftycstA,0),
						imu_ftycstB = isnull(@iic_ftycstB,0),
						imu_ftycstC = isnull(@iic_ftycstC,0),
						imu_ftycstD = isnull(@iic_ftycstD,0),
						imu_ftycstE = isnull(@iic_ftycstE,0),
						imu_ftycstTran = isnull(@iic_ftycstTran,0),
						imu_ftycstPack = isnull(@iic_ftycstPack,0),
						imu_chgfp = @iic_chgfp,
						imu_chgfpA = @iic_chgfpA,
						imu_chgfpB = @iic_chgfpB,
						imu_chgfpC = @iic_chgfpC,
						imu_chgfpD = @iic_chgfpD,
						imu_chgfpE = @iic_chgfpE,
						imu_chgfpTran = @iic_chgfpTran,
						imu_chgfpPack = @iic_chgfpPack,
						imu_ftyprc = @iid_ftyprc,
						imu_ftyprcA = isnull(@iic_ftyprcA,0),
						imu_ftyprcB = isnull(@iic_ftyprcB,0),
						imu_ftyprcC = isnull(@iic_ftyprcC,0),
						imu_ftyprcD = isnull(@iic_ftyprcD,0),
						imu_ftyprcE = isnull(@iic_ftyprcE,0),
						imu_ftyprcTran = isnull(@iic_ftyprcTran,0),
						imu_ftyprcPack = isnull(@iic_ftyprcPack,0),
						imu_bomcst = 0,
						imu_ttlcst = @iid_ftyprc,
						imu_negcst = 0,
						imu_negprc = @iic_negprc,
						imu_hkadjper = 0,
						imu_fmlopt = @iid_fmlopt,
						imu_bcurcde = @iid_bcurcde,
						imu_itmprc = @iid_itmprc,
						imu_bomprc = 0,
						imu_basprc = @iid_basprc,
						--imu_period = (cast(datepart(yyyy, @iid_period) as varchar(4)) + '-' + cast(right('0' + datepart(mm, @iid_period), 2) as varchar(2))),
						imu_period = ltrim(rtrim(str(datepart(yyyy, @iid_period)))) + '-' + right('0' + ltrim(rtrim(str(datepart(mm, @iid_period)))), 2),
						imu_cstchgdat = getdate(),
						imu_updusr = left('E-'+ @usrid, 30),
						imu_upddat = getdate()
					where	imu_itmno = @iid_itmno and
						imu_typ = @iid_itmtyp and
						imu_venno = @iid_venno and
						imu_prdven = @imu_prdven and
						imu_pckunt = @iid_untcde and
						imu_inrqty = @iid_inrqty and
						imu_mtrqty = @iid_mtrqty and
						imu_cus1no = @iic_cus1no and
						imu_cus2no = @iic_cus2no and
						imu_ftyprctrm = @iid_ftyprctrm and
						imu_hkprctrm = @iid_hkprctrm and
						imu_trantrm = @iid_trantrm
					
					-- Insert into IMPRCCHG --
					insert into IMPRCCHG
					(	imu_cocde,		imu_itmno,		imu_typ,
						imu_ventyp,		imu_venno,		imu_prdven,
						imu_pckunt,		imu_conftr,		imu_inrqty,
						imu_mtrqty,		imu_cft,		imu_cus1no,
						imu_cus2no,		imu_ftyprctrm,		imu_hkprctrm,
						imu_trantrm,		imu_chgdat,		imu_chgreason,
						imu_effdat_before,	imu_expdat_before,	imu_curcde_before,
						imu_ftycst_before,	
						imu_ftycstA_before,	imu_ftycstB_before,	imu_ftycstC_before,	
						imu_ftycstD_before,	imu_ftycstE_before,	imu_ftycstTran_before,
						imu_ftycstPack_before,	
						imu_fmlA_before,	imu_fmlB_before,	imu_fmlC_before,	
						imu_fmlD_before,	imu_fmlE_before,	imu_fmlTran_before,
						imu_fmlPack_before,	
						imu_ftyprc_before,	
						imu_ftyprcA_before,	imu_ftyprcB_before,	imu_ftyprcC_before,	
						imu_ftyprcD_before,	imu_ftyprcE_before,	imu_ftyprcTran_before,	
						imu_ftyprcPack_before,	
						imu_bomcst_before,
						imu_ttlcst_before,	imu_hkadjper_before,	imu_negcst_before,
						imu_negprc_before,	imu_fmlopt_before,	imu_bcurcde_before,
						imu_itmprc_before,	imu_bomprc_before,	imu_basprc_before,
						imu_period_before,	imu_cstchgdat_before,	imu_effdat_after,
						imu_expdat_after,	imu_curcde_after,	
						imu_ftycst_after,
						imu_ftycstA_after,	imu_ftycstB_after,	imu_ftycstC_after,
						imu_ftycstD_after,	imu_ftycstE_after,	imu_ftycstTran_after,	
						imu_ftycstPack_after,
						imu_fmlA_after,		imu_fmlB_after,		imu_fmlC_after,
						imu_fmlD_after,		imu_fmlE_after,		imu_fmlTran_after,	
						imu_fmlPack_after,
						imu_ftyprc_after,	
						imu_ftyprcA_after,	imu_ftyprcB_after,	imu_ftyprcC_after,	
						imu_ftyprcD_after,	imu_ftyprcE_after,	imu_ftyprcTran_after,
						imu_ftyprcPack_after,	
						imu_bomcst_after,	imu_ttlcst_after,
						imu_hkadjper_after,	imu_negcst_after,	imu_negprc_after,
						imu_fmlopt_after,	imu_bcurcde_after,	imu_itmprc_after,
						imu_bomprc_after,	imu_basprc_after,	imu_period_after,
						imu_cstchgdat_after,	imu_creusr,		imu_updusr,
						imu_credat,		imu_upddat
					)
					values
					(	'UCPP',			@iid_venitm,		@iid_itmtyp,
						@imu_ventyp,		@iid_venno,		@imu_prdven,
						@iid_untcde,		@iid_conftr,		@iid_inrqty,
						@iid_mtrqty,		@iid_cft,		@iic_cus1no,
						@iic_cus2no,		@iid_ftyprctrm,		@iid_hkprctrm,
						@iid_trantrm,		getdate(),		@ipc_chgreason,
						@imu_effdat,		@imu_expdat,		@imu_curcde,
						@imu_ftycst,		
						@imu_ftycstA,		@imu_ftycstB,		@imu_ftycstC,		
						@imu_ftycstD,		@imu_ftycstE,		@imu_ftycstTran,
						@imu_ftycstPack,	
						'',			'',			'',
						'',			'',			'',
						'',			
						@imu_ftyprc,		
						@imu_ftyprcA,		@imu_ftyprcB,		@imu_ftyprcC,		
						@imu_ftyprcD,		@imu_ftyprcE,		@imu_ftyprcTran,	
						@imu_ftyprcPack,	
						@imu_bomcst,
						@imu_ttlcst,		@imu_hkadjper,		@imu_negcst,
						@imu_negprc,		@imu_fmlopt,		@imu_bcurcde,
						@imu_itmprc,		@imu_bomprc,		@imu_basprc,
						@imu_period,		@imu_cstchgdat,		@iid_effdat,
						@iid_cstexpdat,		@iid_curcde,		
						@iid_ftycst,
						@iic_ftycstA,		@iic_ftycstB,		@iic_ftycstC,
						@iic_ftycstD,		@iic_ftycstE,		@iic_ftycstTran,	
						@iic_ftycstPack,
						'',			'',			'',
						'',			'',			'',
						'',
						@iid_ftyprc,		
						@iic_ftyprcA,		@iic_ftycstB,		@iic_ftyprcC,		
						@iic_ftycstD,		@iic_ftycstE,		@iic_ftycstTran,
						@iic_ftyprcPack,	
						@imu_bomcst,		@iid_ftyprc,
						0,			0,			@iic_negprc,
						@iid_fmlopt,		@iid_bcurcde,		@iid_itmprc,
						@iid_bomprc,		@iid_basprc,		ltrim(rtrim(str(datepart(yyyy, @iid_period)))) + '-' + right('0' + ltrim(rtrim(str(datepart(mm, @iid_period)))), 2),
						getdate(),		left('E-'+ @usrid, 30),	left('E-'+ @usrid, 30),
						getdate(),		getdate()
					)
				end
			end
			
			FETCH NEXT FROM cur_IMPRCINF INTO
			@imu_effdat,		@imu_expdat,		@imu_curcde,
			@imu_ftycst,		@imu_ftycstA,		@imu_ftycstB,
			@imu_ftycstC,		@imu_ftycstD,		@imu_ftycstE,
			@imu_ftycstTran,
			@imu_ftycstPack,	@imu_ftyprc,		@imu_ftyprcA,
			@imu_ftyprcB,		@imu_ftyprcC,		@imu_ftyprcD,
			@imu_ftyprcE,
			@imu_ftyprcTran,	@imu_ftyprcPack,	@imu_ttlcst,
			@imu_bomcst,		@imu_hkadjper,		@imu_negcst,
			@imu_negprc,		@imu_fmlopt,		@imu_bcurcde,
			@imu_itmprc,		@imu_basprc,		@imu_period,
			@imu_cstchgdat,		@imu_ventyp,		@imu_prdven,
			@imu_bomprc
		END
		CLOSE cur_IMPRCINF
		DEALLOCATE cur_IMPRCINF
-- IMPRCINF END --

-- IMPCKINF START --
		if (select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm and ipi_pckunt = @iid_untcde and
			ipi_conftr = @iid_conftr and ipi_inrqty = @iid_inrqty and ipi_mtrqty = @iid_mtrqty and 
			ipi_cus1no = @iic_cus1no and ipi_cus2no = @iic_cus2no) = 0
		begin
			select	@ipi_pckseq = max(ipi_pckseq) + 1
			from	(
				select	isnull(max(ipi_pckseq), 0) as ipi_pckseq
				from	IMPCKINF (nolock)
				where	ipi_itmno = @iid_venitm
				UNION
				select	isnull(max(ipi_pckseq), 0) as ipi_pckseq
				from	IMPCKINFH (nolock)
				where	ipi_itmno = @iid_venitm
				) as t
			
			-- Insert into IMPCKINF --
			insert into IMPCKINF
			(	ipi_cocde,		ipi_itmno,		ipi_pckseq,
				ipi_pckunt,		ipi_inrqty,		ipi_mtrqty,
				ipi_inrhin,		ipi_inrwin,		ipi_inrdin,
				ipi_inrhcm,		ipi_inrwcm,		ipi_inrdcm,
				ipi_mtrhin,		ipi_mtrwin,		ipi_mtrdin,
				ipi_mtrhcm,		ipi_mtrwcm,		ipi_mtrdcm,
				ipi_cft,		ipi_cbm,		ipi_cus1no,
				ipi_cus2no,		ipi_grswgt,		ipi_netwgt,
				ipi_pckitr,		ipi_sappckid,		ipi_conftr,
				ipi_cusno,		ipi_qutdat,		ipi_inrsze,
				ipi_mtrsze,		ipi_mat,		ipi_creusr,
				ipi_updusr,		ipi_credat,		ipi_upddat
			)
			values
			(	'',			@iid_venitm,		@ipi_pckseq,
				@iid_untcde,		@iid_inrqty,		@iid_mtrqty,
				@iid_inrhcm,		@iid_inrwcm,		@iid_inrlcm,
				@iid_inrhcm * @incm,	@iid_inrwcm * @incm,	@iid_inrlcm * @incm,
				@iid_mtrhcm,		@iid_mtrwcm,		@iid_mtrlcm,
				@iid_mtrhcm * @incm,	@iid_mtrwcm * @incm,	@iid_mtrlcm * @incm,
				@iid_cft,		@iid_cft * @cbmcft,	@iic_cus1no,
				@iic_cus2no,		@iid_grswgt,		@iid_netwgt,
				@iid_pckitr,		'',			@iid_conftr,
				@iic_cus1no,		@iid_period,		@iid_inrsze,
				@iid_mtrsze,		@iid_mat,		left('E-'+ @usrid, 30),
				left('E-'+ @usrid, 30),	getdate(),		getdate()
			)
	
			-- Insert into IMVENPCK --
			insert into IMVENPCK
			(	ivp_cocde,		ivp_itmno,		ivp_pckseq,
				ivp_venno,		ivp_relatn,		ivp_creusr,
				ivp_updusr,		ivp_credat,		ivp_upddat
			)
			values
			(	'',			@iid_venitm,		@ipi_pckseq,
				@iid_venno,		'YES',			left('E-'+ @usrid, 30),
				left('E-'+ @usrid, 30),	getdate(),		getdate()
			)
		end
		else
		begin
			-- Update to IMPCKINF --
			update	IMPCKINF
			set	ipi_inrhin = @iid_inrhcm,
				ipi_inrwin = @iid_inrwcm,
				ipi_inrdin = @iid_inrlcm,
				ipi_inrhcm = @iid_inrhcm * @incm,
				ipi_inrwcm = @iid_inrwcm * @incm,
				ipi_inrdcm = @iid_inrlcm * @incm,
				ipi_mtrhin = @iid_mtrhcm,
				ipi_mtrwin = @iid_mtrwcm,
				ipi_mtrdin = @iid_mtrlcm,
				ipi_mtrhcm = @iid_mtrhcm * @incm,
				ipi_mtrwcm = @iid_mtrwcm * @incm,
				ipi_mtrdcm = @iid_mtrlcm * @incm,
				ipi_cft = @iid_cft,
				ipi_cbm = @iid_cft * @cbmcft,
				ipi_grswgt = @iid_grswgt,
				ipi_netwgt = @iid_netwgt,
				ipi_qutdat = @iid_period,
				ipi_pckitr = @iid_pckitr,
				ipi_mat = @iid_mat,
				ipi_inrsze = @iid_inrsze, --2014
				ipi_mtrsze = @iid_mtrsze,		
				ipi_updusr = left('E-'+ @usrid, 30),
				ipi_upddat = getdate()
			where	ipi_itmno = @iid_venitm and
				ipi_pckunt = @iid_untcde and
				ipi_inrqty = @iid_inrqty and
				ipi_mtrqty = @iid_mtrqty and
				ipi_conftr = @iid_conftr and
				ipi_cus1no = @iic_cus1no and
				ipi_cus2no = @iic_cus2no
		end
-- IMPCKINF END --

-- IMTMPREL START --
		if ltrim(rtrim(@iid_alstmpitmno)) <> ''
		begin

			if (select count(*) from IMTMPREL (nolock) where itr_itmno = @iid_venitm and itr_tmpitm = @iid_alstmpitmno) = 0
			begin
				insert into IMTMPREL
				(	itr_cocde,		itr_itmno,		itr_tmpitm,
					itr_creusr,		itr_updusr,		itr_credat,
					itr_upddat
				)
				values
				(	'UCPP',			@iid_venitm,		ltrim(rtrim(@iid_alstmpitmno)),
					left('E-'+ @usrid, 30),	left('E-'+ @usrid, 30),	getdate(),
					getdate()
				)
			end
		end
-- IMTMPREL END --

-- IMBASINF START --
		-- Determine Item Status --
		if (select count(*) from IMCOLINF (nolock) where icf_itmno = @iid_venitm) > 0 and
		   (select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm) > 0 and
		   (select count(*) from IMPRCINF (nolock) where imu_itmno = @iid_venitm) > 0
		begin
			set @iid_itmsts = 'CMP'
		end
		else
		begin
			set @iid_itmsts = 'INC'
		end

		-- Determine Construction Method --
		set @ibi_cosmth = ''
		select top 1
			@ibi_cosmth = imd_cosmth
		from	IMCOMDAT (nolock)
		where	imd_venitm = @iid_venitm and
			imd_itmseq = @iid_itmseq and
			imd_xlsfil = @iid_xlsfil and
			imd_chkdat = @iid_chkdat
		order by imd_credat
		
		-- Update to IMBASINF --
		update	IMBASINF
		set	--ibi_itmsts = @iid_itmsts,
			ibi_itmsts = case (select count(*) from IMITMDAT (nolock) where iid_venitm = @iid_venitm and (iid_itmseq <> @iid_itmseq or
					(iid_itmseq = @iid_itmseq and iid_recseq <> @iid_recseq)) and iid_stage in ('W')) when 0 then @iid_itmsts
					else ibi_itmsts end,
			--ibi_prvsts = @iid_itmsts,
			ibi_prvsts = case (select count(*) from IMITMDAT (nolock) where iid_venitm = @iid_venitm and (iid_itmseq <> @iid_itmseq or
					(iid_itmseq = @iid_itmseq and iid_recseq <> @iid_recseq)) and iid_stage in ('W')) when 0 then @iid_itmsts
					else ibi_prvsts end,
			ibi_cosmth = isnull(@ibi_cosmth,''),
			ibi_catlvl4 = isnull(@iid_catlvl4,''),
			ibi_lnecde = isnull(@iid_lnecde,''),
			ibi_engdsc = left(@iid_engdsc,800),
			ibi_chndsc = left(@iid_chndsc,800),
			ibi_tirtyp = case when @iid_moq > 0 then '2' else '1' end,
			ibi_moqctn = case when @iid_moq > 0 then @iid_moq else 0 end,
			ibi_rmk = left(@iid_remark, 2000),
			ibi_wastage = @iid_wastage,
			ibi_ftytmp = @iid_ftytmp,
			ibi_updusr = left('E-'+ @usrid, 30),
			ibi_upddat = getdate()
		where	ibi_itmno = @iid_venitm
-- IMBASINF END --
	end
	else
	begin
		-- Rejected Item --
		update	IMBASINF
		set	--ibi_itmsts = ibi_prvsts,
			ibi_itmsts = case (select count(*) from IMITMDAT (nolock) where iid_venitm = @iid_venitm and (iid_itmseq <> @iid_itmseq or
					(iid_itmseq = @iid_itmseq and iid_recseq <> @iid_recseq)) and iid_stage in ('W')) when 0 then ibi_prvsts 
					else ibi_itmsts end,
			--ibi_prvsts = ibi_itmsts,
			ibi_prvsts = case (select count(*) from IMITMDAT (nolock) where iid_venitm = @iid_venitm and (iid_itmseq <> @iid_itmseq or
					(iid_itmseq = @iid_itmseq and iid_recseq <> @iid_recseq)) and iid_stage in ('W')) when 0 then ibi_itmsts 
					else ibi_prvsts end,
			ibi_updusr = left('E-'+ @usrid, 30),
			ibi_upddat = getdate()
		where	ibi_itmno = @iid_venitm and
			(select count(*) from IMITMDAT (nolock) where iid_venitm = @iid_venitm and (iid_itmseq <> @iid_itmseq or
				iid_recseq <> @iid_recseq) and iid_stage in ('W','A','R')) = 0
	end

	-- Move to IMITMDATCSTH --
	insert into IMITMDATCSTH
	(	iic_cocde,		iic_venno,		iic_prdven,		
		iic_venitm,		iic_itmseq,		iic_recseq,		
		iic_xlsfil,		iic_chkdat,		iic_cus1no,		
		iic_cus2no,		iic_stage,		iic_untcde,		
		iic_mtrqty,		iic_inrqty,		
		iic_fcA,		iic_fcB,		iic_fcC,		
		iic_fcD,		iic_fcE,		iic_fcTran,		
		iic_fcPack,		
		iic_ftycst,		
		iic_icA,		iic_icB,		iic_icC,		
		iic_icD,		iic_icE,		iic_icTran,		
		iic_icPack,		
		iic_ftyprc,		iic_nat,		iic_negprc,		
		iic_conftr,		iic_creusr,		iic_updusr,		
		iic_credat,		iic_upddat
	)
	select	iic_cocde,		iic_venno,		iic_prdven,		
		iic_venitm,		iic_itmseq,		iic_recseq,		
		iic_xlsfil,		iic_chkdat,		iic_cus1no,		
		iic_cus2no,		iic_stage,		iic_untcde,		
		iic_mtrqty,		iic_inrqty,		
		iic_fcA,		iic_fcB,		iic_fcC,		
		iic_fcD,		iic_fcE,		iic_fcTran,		
		iic_fcPack,		
		iic_ftycst,		
		iic_icA,		iic_icB,		iic_icC,		
		iic_icD,		iic_icE,		iic_icTran,		
		iic_icPack,		
		iic_ftyprc,		iic_nat,		iic_negprc,		
		iic_conftr,		iic_creusr,		left('E-'+ @usrid, 30),		
		iic_credat,		getdate()
	from	IMITMDATCST cur
	where	iic_venitm = @iid_venitm and
		iic_itmseq = @iid_itmseq and
		iic_xlsfil = @iid_xlsfil and
		iic_chkdat = @iid_chkdat and
		--iic_stage not in ('I','O') and
		(select count(*) from IMITMDATCSTH his where his.iic_itmseq = @iid_itmseq and his.iic_recseq = @iid_recseq) = 0
	
	-- Remove from IMITMDATCST --
	delete	cur
	from	IMITMDATCST cur
	where	iic_venitm = @iid_venitm and
		iic_itmseq = @iid_itmseq and
		iic_recseq = @iid_recseq and
		iic_xlsfil = @iid_xlsfil and
		iic_chkdat = @iid_chkdat and
		--iic_stage not in ('I','O') and
		(select count(*) from IMITMDATCSTH his where his.iic_itmseq = @iid_itmseq and his.iic_recseq = @iid_recseq) = 1

	-- Move to IMITMDATH --
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
		cur.iid_alscolcde,	cur.iid_alscolcde_bef,	cur.iid_basprc,		
		cur.iid_basprc_bef,	cur.iid_bomprc,		cur.iid_bomprc_bef,		
		cur.iid_curr_bef,	cur.iid_assconftr,	cur.iid_assconftr_bef,		
		cur.iid_period,		cur.iid_period_bef,	cur.iid_cstexpdat,		
		cur.iid_cstexpdat_bef,	cur.iid_cus1no,		cur.iid_creusr,		
		left('E-'+ @usrid, 30),	cur.iid_credat,		getdate(),		
		cur.iid_inrsze,		cur.iid_mtrsze,		cur.iid_mat,		
		cur.iid_inrsze_bef,	cur.iid_mtrsze_bef,	cur.iid_mat_bef,		
		cur.iid_ftytmp,		cur.iid_alstmpitmno,	cur.iid_ftytmp_bef,		
		cur.iid_alstmpitmno_bef
	from	IMITMDAT cur
	where	iid_venitm = @iid_venitm and
		iid_itmseq = @iid_itmseq and
		iid_recseq = @iid_recseq and
		iid_xlsfil = @iid_xlsfil and
		iid_chkdat = @iid_chkdat and
		iid_stage not in ('I','O') and
		(select count(*) from IMITMDATH his where his.iid_itmseq = @iid_itmseq and his.iid_recseq = @iid_recseq) = 0
	
	-- Remove from IMITMDAT --
	delete	cur
	from	IMITMDAT cur
	where	iid_venitm = @iid_venitm and
		iid_itmseq = @iid_itmseq and
		iid_recseq = @iid_recseq and
		iid_xlsfil = @iid_xlsfil and
		iid_chkdat = @iid_chkdat and
		iid_stage not in ('I','O') and
		(select count(*) from IMITMDATH his where his.iid_itmseq = @iid_itmseq and his.iid_recseq = @iid_recseq) = 1
	
	FETCH NEXT FROM cur_IMITMDAT INTO
	@iid_venno,		@iid_prdven,		@iid_venitm,
	@iid_itmseq,		@iid_recseq,		@iid_itmtyp,
	@iid_itmno,		@iid_mode,		@iid_itmsts,
	@iid_stage,		@iid_engdsc,		@iid_chndsc,
	@iid_lnecde,		@iid_catlvl4,		@iid_untcde,
	@iid_inrqty,		@iid_mtrqty,		@iid_inrlcm,
	@iid_inrwcm,		@iid_inrhcm,		@iid_mtrlcm,
	@iid_mtrwcm,		@iid_mtrhcm,		@iid_cft,
	@iid_conftr,		@iid_curcde,		@iid_ftycst,
	@iid_ftyprc,		@iid_ftyprctrm,		@iid_hkprctrm,
	@iid_trantrm,		@iid_grswgt,		@iid_netwgt,
	@iid_pckitr,		@iid_xlsfil,		@iid_chkdat,
	@iid_orgdsgvenno,	@iid_moq,		@iid_fcurcde,
	@iid_wastage,		@iid_remark,		@iid_cusven,
	@iid_alsitmno,		@iid_alscolcde,		@iid_period,
	@iid_cstexpdat,		@iid_inrsze,		@iid_mtrsze,
	@iid_mat,		@iid_ftytmp,		@iid_alstmpitmno
END
CLOSE cur_IMITMDAT
DEALLOCATE cur_IMITMDAT




drop table #tmp_IMPCKINF



GO
GRANT EXECUTE ON [dbo].[sp_update_IMUPDDAT] TO [ERPUSER] AS [dbo]
GO
