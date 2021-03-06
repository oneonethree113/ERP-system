/****** Object:  StoredProcedure [dbo].[sp_insert_IMITMDAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMITMDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMITMDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=================================================================
Program ID	: sp_insert_IMITMDAT
Description	: Insert data into IMITMDAT and IMITMDATCST
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-03-04 	David Yue		SP Created
=================================================================
*/

CREATE  procedure [dbo].[sp_insert_IMITMDAT] 
@iid_cocde	nvarchar(6),
@iid_itmseq	int,
@iid_xlsfil	nvarchar(30),
@iid_chkdat	nvarchar(30),
@iid_prdven	nvarchar(6),
@iid_venno	nvarchar(6),
@iic_cus1no	nvarchar(6),
@iic_cus2no	nvarchar(6),
@iid_ftytmp	nvarchar(1),
@iid_venitm	nvarchar(20),
@iid_engdsc	nvarchar(800),
@iid_chndsc	nvarchar(1600),
@iid_lnecde	nvarchar(10),
@iid_catlvl4	nvarchar(20),
@iid_untcde	nvarchar(10),
@iid_inrqty	int,
@iid_mtrqty	int,
@iid_cft	numeric(11,4),
@iid_conftr	int,
@iid_sapum	nvarchar(6),
@iic_curcde	nvarchar(6),
@iic_ftycstA	numeric(13,4),
@iic_ftycstB	numeric(13,4),
@iic_ftycstC	numeric(13,4),
@iic_ftycstD	numeric(13,4),
@iic_ftycstE	numeric(13,4),
@iic_ftycstTran	numeric(13,4),
@iic_ftycstPack	numeric(13,4),
@iic_ftycst	numeric(13,4),
@iic_ftyprcA	numeric(13,4),
@iic_ftyprcB	numeric(13,4),
@iic_ftyprcC	numeric(13,4),
@iic_ftyprcD	numeric(13,4),
@iic_ftyprcE	numeric(13,4),
@iic_ftyprcTran	numeric(13,4),
@iic_ftyprcPack	numeric(13,4),
@iic_ftyprc	numeric(13,4),
@iid_ftyprctrm	nvarchar(30),
@iid_hkprctrm	nvarchar(30),
@iid_trantrm	nvarchar(30),
@iid_inrdin	numeric(11,4),
@iid_inrwin	numeric(11,4),
@iid_inrhin	numeric(11,4),
@iid_mtrdin	numeric(11,4),
@iid_mtrwin	numeric(11,4),
@iid_mtrhin	numeric(11,4),
@iid_grswgt	numeric(6,3),
@iid_netwgt	numeric(6,3),
@iid_pckitr	nvarchar(300),
@iid_bomflg	nvarchar(1),
@iid_orgdvenno	nvarchar(6),
@iid_moq	int,
@iid_inrsze	nvarchar(500),
@iid_mtrsze	nvarchar(500),
@iid_mat	nvarchar(500),
@iid_fcurcde	nvarchar(6),
@iid_wastage	numeric(5, 2),
@iid_rmk	nvarchar(2000),
@iid_cusven	nvarchar(6),
@iid_alsitmno	nvarchar(30),
@iid_alscolcde	nvarchar(30),
@iid_alstmpitm	nvarchar(30),
@iid_numass	int,
@iic_nat	nvarchar(30),
@iic_negprc	numeric(13,4),
@dat_period	nvarchar(30),
@dat_expdat	nvarchar(30),
@usrid		nvarchar(30)

AS

declare -- IMITMDAT
@iid_recseq	int,
@iid_mode	nvarchar(3),
@iid_itmsts	nvarchar(6),
@iid_sysmsg	nvarchar(300),
@iid_refresh	nvarchar(1),
@iid_stage	nvarchar(1),
@iid_period	datetime,
@iid_expdat	datetime

declare -- IMBASINF
@ibi_venno	nvarchar(6),
@ibi_lnecde	nvarchar(10),
@ibi_catlvl4	nvarchar(20),
@ibi_typ	nvarchar(4),
@ibi_engdsc	nvarchar(800),
@ibi_chndsc	nvarchar(800),
@ibi_moqctn	int,
@ibi_rmk	nvarchar(800),
@ibi_alsitmno	nvarchar(20),
@ibi_orgdvenno	nvarchar(6),
@ibi_wastage	numeric(5, 2),
@ibi_alscolcde	nvarchar(30),
@ibi_ftytmp	nvarchar(1)

declare -- IMPCKINF
@ipi_inrdin	numeric(11, 4),
@ipi_inrwin	numeric(11, 4),
@ipi_inrhin	numeric(11, 4),
@ipi_mtrdin	numeric(11, 4),
@ipi_mtrwin	numeric(11, 4),
@ipi_mtrhin	numeric(11, 4),
@ipi_cft	numeric(11, 4),
@ipi_grswgt	numeric(6, 3),
@ipi_netwgt	numeric(6, 3),
@ipi_pckitr	nvarchar(300),
@ipi_conftr	int,
@ipi_qutdat	datetime,
@ipi_inrsze	nvarchar(500),
@ipi_mtrsze	nvarchar(500),
@ipi_mat	nvarchar(500)

declare -- IMPRCINF
@imu_expdat	datetime,
@imu_curcde	nvarchar(6),
@imu_ftycst	numeric(13, 4),
@imu_ftyprc	numeric(13, 4),
@imu_bcurcde	nvarchar(6),
@imu_bomprc	numeric(13, 4),
@imu_basprc	numeric(13, 4),
@imu_ftyprctrm	nvarchar(10),
@imu_hkprctrm	nvarchar(10)

declare -- IMTMPREL
@itr_tmpitm	nvarchar(20)

set @iid_stage = 'W'
set @iid_sysmsg = ''
set @iid_refresh = 'Y'


-- Check Item No. --
if @iid_venitm = ''
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing Item No.', 300)
	set @iid_refresh = 'N'
end
else
begin
	if (select count(*) from IMBASINF (nolock) where ibi_itmno = @iid_venitm) = 0
	begin
		if (select count(*) from IMBASINFH (nolock) where ibi_itmno = @iid_venitm) > 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_venitm + ' - Item in History', 300)
			set @iid_refresh = 'N'
		end

		-- Check Item No. and DV Mapping --
		if dbo.IMBASINF_NewFmt(@iid_venitm) = 'Y'
		begin
			if @iid_venno <> substring(@iid_venitm, 3, 1)
			begin
				set @iid_stage = 'I'
				set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_venitm + ' / ' + @iid_venno + ' - Invalid Item No. vs DV', 300)
				set @iid_refresh = 'N'
			end
		end
	end
	else
	begin
		-- Check Item No. and DV Mapping --
		if dbo.IMBASINF_NewFmt(@iid_venitm) = 'Y'
		begin
			if @iid_venno <> substring(@iid_venitm, 3, 1)
			begin
				set @iid_stage = 'I'
				set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_venitm + ' / ' + @iid_venno + ' - Invalid Item No. vs DV', 300)
				set @iid_refresh = 'N'
			end
		end
	end
end

-- Check Alias Item No. --
if @iid_alsitmno <> ''
begin
	if (select count(*) from IMBASINF (nolock) where ibi_itmno = @iid_alsitmno) = 0
	begin
		if (select count(*) from IMBASINFH (nolock) where ibi_itmno = @iid_alsitmno) > 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_alsitmno + ' - Alias Item in History', 300)
			set @iid_refresh = 'N'
		end
	end
end

-- Check DV --
if @iid_venno = ''
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing DV', 300)
	set @iid_refresh = 'N'
end
else
begin
	if (select count(*) from VNBASINF (nolock) where vbi_venno = @iid_venno) = 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_venno + ' - DV not found in Vendor Master', 300)
		set @iid_refresh = case @iid_refresh when 'Y' then 'Y' else 'N' end
	end
end

-- Check Original DV --
if @iid_venno <> @iid_orgdvenno
begin
	if (select count(*) from VNBASINF (nolock) where vbi_venno = @iid_orgdvenno) = 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_orgdvenno + ' - Original DV not found in Vendor Master', 300)
		set @iid_refresh = case @iid_refresh when 'Y' then 'Y' else 'N' end
	end
end

-- Check PV --
if @iid_prdven = ''
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing PV', 300)
	set @iid_refresh = 'N'
end
else
begin
	if (select count(*) from VNBASINF (nolock) where vbi_venno = @iid_prdven) = 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_prdven + ' - PV not found in Vendor Master', 300)
		set @iid_refresh = case @iid_refresh when 'Y' then 'Y' else 'N' end
	end
end

-- Check CV --
if (select count(*) from VNBASINF (nolock) where vbi_venno = @iid_cusven) = 0
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_cusven + ' - PV not found in Vendor Master', 300)
	set @iid_refresh = case @iid_refresh when 'Y' then 'Y' else 'N' end
end

-- Check Primary and Secondary Customer --
if @iid_bomflg = 'N'
begin
	if @iic_cus1no = ''
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing Primary Customer', 300)
		set @iid_refresh = 'N'
	end
	else
	begin
		-- Check Vendor / Customer Group Rleation --
		if (select count(*) from CUGRPINF (nolock) where cgi_cugrpcde = @iic_cus1no and cgi_flg_int = 'Y') = 0
		begin
			-- Check Primary Customer exists in CUBASINF --
			if (select count(*) from CUBASINF (nolock) where cbi_cusno = @iic_cus1no) > 0
			begin
				if @iic_cus2no <> ''
				begin
					-- Check Secondary Customer exists in CUBASINF --
					if (select count(*) from CUBASINF (nolock) where cbi_cusno = @iic_cus2no) > 0
					begin
						-- Check Primary and Secondary Customer Mapping --
						if (select count(*) from CUSUBCUS (nolock) where csc_prmcus = @iic_cus1no and csc_seccus = @iic_cus2no) = 0
						begin
							set @iid_stage = 'I'
							set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iic_cus1no + ' / ' + @iic_cus2no + ' - Primary Customer not mapped with Secondary Customer', 300)
							set @iid_refresh = case @iid_refresh when 'Y' then 'Y' else 'N' end
						end
					end
					else
					begin
						set @iid_stage = 'I'
						set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iic_cus1no + 'Secondary Customer not found in Customer Master', 300)
						set @iid_refresh = case @iid_refresh when 'Y' then 'Y' else 'N' end
					end
				end
			end
			else
			begin
				set @iid_stage = 'I'
				set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iic_cus1no + 'Primary Customer not found in Customer Master', 300)
				set @iid_refresh = case @iid_refresh when 'Y' then 'Y' else 'N' end
			end
		end
		else
		begin
			if @iic_cus2no <> ''
			begin
				set @iid_stage = 'I'
				set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iic_cus2no + 'Secondary Customer must be empty when Customer Group is used', 300)
				set @iid_refresh = 'N'
			end
		end
	end
end
else
begin
	if @iic_cus1no <> ''
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'BOM does not have Primary Customer', 300)
		set @iid_refresh = 'N'
	end

	if @iic_cus2no <> ''
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'BOM does not have Secondary Customer', 300)
		set @iid_refresh = 'N'
	end
end

-- Check Item Nature --
if @iic_nat <> ''
begin
	if (select count(*) from SYSETINF (nolock) where ysi_typ = '20' and ysi_dsc = @iic_nat) = 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iic_nat + ' - Item Nature not found', 300)
		set @iid_refresh = 'N'
	end
	else
	begin
		select	@iic_nat = ysi_cde
		from	SYSETINF (nolock)
		where	ysi_dsc = @iic_nat and
			ysi_typ = '20'
	end
end

-- Check UM --
if @iid_untcde = ''
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing UM', 300)
	set @iid_refresh = 'N'
end
else
begin
	if (select count(*) from SYCONFTR (nolock) where ycf_dsc1 = @iid_untcde and ycf_value = @iid_conftr and ycf_code2 = 'PC' and ycf_systyp = 'Y') = 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_untcde + ' / ' + cast(@iid_conftr as varchar(6)) + ' - Invalid UM and/or Conversion Factor', 300)
		set @iid_refresh = 'N'
	end
	else
	begin
		if @iid_untcde = 'SET'
		begin
			set @iid_untcde = 'ST'
		end
		else
		begin
			select	@iid_untcde = ycf_code1
			from	SYCONFTR (nolock)
			where	ycf_dsc1 = @iid_untcde and
				ycf_value = @iid_conftr and
				ycf_code2 = 'PC' and
				ycf_systyp = 'Y'
		end
	end
end

-- Cross-Check SAP UM with ERP UM and Conversion Factor --
declare @STUM as varchar(10)
set @STUM = ''

if @iid_sapum = ''
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing SAP UM', 300)
	set @iid_refresh = 'N'
end
else
begin
	if @iid_sapum <> 'S00' -- Non assortment Case
	begin
		if @iid_untcde = 'ST' -- Regular with ST unit
		begin
			set @STUM = 'ST' + convert(varchar(10), @iid_conftr)
			set @iid_untcde = @STUM
			if (select count(*) from SYUM (nolock) where yum_msehi = @iid_sapum and yum_zaehl = @iid_conftr and yum_msehtm = @STUM) = 0
			begin
				set @iid_stage = 'I'
				set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_sapum + ' - SAP UM not matched with ERP UM', 300)
				set @iid_refresh = 'N'
			end
			set @iid_conftr = 1
		end
		else
		begin
			if (select count(*) from SYUM (nolock) where yum_msehi = @iid_sapum and yum_zaehl = @iid_conftr and yum_msehtm = @iid_untcde) = 0
			begin
				set @iid_stage = 'I'
				set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_sapum + ' - SAP UM not matched with ERP UM', 300)
				set @iid_refresh = 'N'
			end
		end
	end
end

-- Check FTY Price Term --
if @iid_ftyprctrm = ''
begin
	if @iid_bomflg = 'N'
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing FTY Prc Trm', 300)
		set @iid_refresh = 'N'
	end
end
else
begin
	if @iid_bomflg = 'Y'
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'BOM Item does not have FTY Prc Trm', 300)
		set @iid_refresh = 'N'
	end
	else
	begin
		if (select count(*) from SYSETINF (nolock) where ysi_typ = '03' and ysi_dsc = @iid_ftyprctrm) = 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_ftyprctrm + ' - Invalid FTY Prc Trm', 300)
			set @iid_refresh = 'N'
		end
		else
		begin
			select	@iid_ftyprctrm = ysi_cde
			from	SYSETINF (nolock)
			where	ysi_dsc = @iid_ftyprctrm and
				ysi_typ = '03'
		end	
	end

end

-- Check HK Price Term --
if @iid_hkprctrm = ''
begin
	if @iid_bomflg = 'N'
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing HK Prc Trm', 300)
		set @iid_refresh = 'N'
	end
end
else
begin
	if @iid_bomflg = 'Y'
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'BOM Item does not have HK Prc Trm', 300)
		set @iid_refresh = 'N'
	end
	else
	begin
		if (select count(*) from SYSETINF (nolock) where ysi_typ = '03' and ysi_dsc = @iid_hkprctrm) = 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_hkprctrm + ' - Invalid HK Prc Trm', 300)
			set @iid_refresh = 'N'
		end
		else
		begin
			select	@iid_hkprctrm = ysi_cde
			from	SYSETINF (nolock)
			where	ysi_dsc = @iid_hkprctrm and
				ysi_typ = '03'
		end
	end
end

-- Check Tran Term --
if @iid_trantrm = ''
begin
	if @iid_bomflg = 'N'
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Missing Tran Trm', 300)
		set @iid_refresh = 'N'
	end
end
else
begin
	if @iid_bomflg = 'Y'
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'BOM Item does not have Tran Trm', 300)
		set @iid_refresh = 'N'
	end
	else
	begin
		if (select count(*) from SYSETINF (nolock) where ysi_typ = '30' and ysi_cde = @iid_trantrm) = 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_trantrm + ' - Invalid Tran Trm', 300)
			set @iid_refresh = 'N'
		end
		else
		begin
			select	@iid_trantrm = ysi_cde
			from	SYSETINF (nolock)
			where	ysi_cde = @iid_trantrm and
				ysi_typ = '30'
		end
	end
end

-- Check Period --
set @iid_period = @dat_period
if datepart(yyyy, @iid_period) = 1900 and datepart(mm, @iid_period) = 1
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + substring(@dat_period, 1, 7) + ' - Invalid Period', 300)
	set @iid_refresh = 'N'
end

-- Check Expiry Date --
set @iid_expdat = @dat_expdat
--if @iid_expdat < getdate() and substring(@iid_expdat, 1, 10) <> '1900-01-01'
if @iid_expdat < getdate() and (datepart(yyyy, @iid_expdat) <> 1900 or datepart(mm, @iid_expdat) <> 1 or datepart(dd, @iid_expdat) <> 1)
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + substring(@dat_expdat, 1, 10) + ' - Expiry Date already past', 300)
	set @iid_refresh = 'N'
end

-- Check Product Line / Season Code (Non BOM Item Only) --
--After the enhancement at March, 2017, the system will create a new product line if the product line does not exist
if @iid_bomflg = 'N' and (select count(*) from SYLNEINF (nolock) where yli_lnecde = @iid_lnecde) = 0
begin
	exec sp_insert_SYLNEINF @iid_cocde,@iid_lnecde,'','','',@usrid
end

-- Check Category Level 4 Code (Non BOM Item Only) --
if @iid_bomflg = 'N' and (select count(*) from SYCATREL (nolock) where ycr_catlvl4 = @iid_catlvl4) = 0
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_catlvl4 + ' - Category Code not found', 300)
	set @iid_refresh = case @iid_refresh when 'Y' then 'Y' else 'N' end
end

-- Check Markup Formula --
if (dbo.IMPRCINF_FmlOpt('IM','BASIC','INT', @iic_cus1no, @iic_cus2no, @iid_catlvl4,getdate(),@iid_prdven)) = ''
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'No markup formula found', 300)
	set @iid_refresh = 'N'
end

-- Check BOM Item for invalid Inner/Master/CFT --
if @iid_bomflg = 'Y'
begin
	if @iid_inrqty <> 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + cast(@iid_inrqty as varchar(6)) + ' - BOM Item must Inner Qty of 0', 300)
		set @iid_refresh = 'N'
	end

	if @iid_mtrqty <> 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + cast(@iid_mtrqty as varchar(6)) + ' - BOM Item must Master Qty of 0', 300)
		set @iid_refresh = 'N'
	end

	if @iid_cft <> 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + cast(@iid_cft as varchar(10)) + ' - BOM Item must CFT of 0', 300)
		set @iid_refresh = 'N'
	end
end



-- Check Total Factory Cost <> A+B+C+D+E+Tran+Pack [New added at 20140826]
if ((@iid_bomflg = 'N') and (isnull(@iic_ftycst,0) <> isnull(@iic_ftycstA,0) + isnull(@iic_ftycstB,0) + isnull(@iic_ftycstC,0) + isnull(@iic_ftycstD,0) + isnull(@iic_ftycstE,0) + isnull(@iic_ftycstTran,0) + isnull(@iic_ftycstPack,0)))
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Total Factory Cost <> A+B+C+D+E+Tran+Pack', 300)
	set @iid_refresh = 'N'
end

-- Check Total Factory Price <> A+B+C+D+E+Tran+Pack [New added at 20140826]
--if ((@iid_bomflg = 'N') and (isnull(@iic_ftyprc,0) <> isnull(@iic_ftyprcA,0) + isnull(@iic_ftyprcB,0) + isnull(@iic_ftyprcC,0) + isnull(@iic_ftyprcD,0) + isnull(@iic_ftyprcE,0) + isnull(@iic_ftyprcTran,0) + isnull(@iic_ftyprcPack,0)))
--begin
--	set @iid_stage = 'I'
--	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Total Factory Price <> A+B+C+D+E+Tran+Pack', 300)
--	set @iid_refresh = 'N'
--end

--Check Total Factory Price <> (A+B+C+D+E+Tran+Pack) * (1 - 4.5%) [New added at 20170524]
if ((@iid_bomflg = 'N') and (isnull(@iic_ftyprc,0) <> round( ( isnull(@iic_ftyprcA,0) + isnull(@iic_ftyprcB,0) + isnull(@iic_ftyprcC,0) + isnull(@iic_ftyprcD,0) + isnull(@iic_ftyprcE,0) + isnull(@iic_ftyprcTran,0) + isnull(@iic_ftyprcPack,0) ) * 0.955, 2)))
begin
	set @iid_stage = 'I'
	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Total Factory Price <> (A+B+C+D+E+Tran+Pack) * 0.955', 300)
	set @iid_refresh = 'N'
end



-- Retrieve IMBASINF Data --
select	@ibi_venno = isnull(ibi_venno, ''),
	@ibi_lnecde = isnull(ibi_lnecde, ''),
	@ibi_catlvl4 = isnull(ibi_catlvl4, ''),
	@ibi_typ = isnull(ibi_catlvl4, ''),
	@ibi_engdsc = isnull(ibi_engdsc, ''),
	@ibi_chndsc = isnull(ibi_chndsc, ''),
	@ibi_moqctn = isnull(ibi_moqctn, 0),
	@ibi_rmk = isnull(ibi_rmk, ''),
	@ibi_alsitmno = isnull(ibi_alsitmno, ''),
	@ibi_orgdvenno = isnull(ibi_orgdvenno, ''),
	@ibi_wastage = isnull(ibi_wastage, 0),
	@ibi_alscolcde = isnull(ibi_alscolcde, ''),
	@ibi_ftytmp = isnull(ibi_ftytmp, 'N')
from	IMBASINF (nolock)
where	ibi_itmno = @iid_venitm

-- Retrieve IMPCKINF Data --
select	@ipi_inrdin = isnull(ipi_inrdin, 0),
	@ipi_inrwin = isnull(ipi_inrwin, 0),
	@ipi_inrhin = isnull(ipi_inrhin, 0),
	@ipi_mtrdin = isnull(ipi_mtrdin, 0),
	@ipi_mtrwin = isnull(ipi_mtrwin, 0),
	@ipi_mtrhin = isnull(ipi_mtrhin, 0),
	@ipi_cft = isnull(ipi_cft, 0),
	@ipi_grswgt = isnull(ipi_grswgt, 0),
	@ipi_netwgt = isnull(ipi_netwgt, 0),
	@ipi_pckitr = isnull(ipi_pckitr, ''),
	@ipi_conftr = isnull(ipi_conftr, 0),
	@ipi_qutdat = isnull(ipi_qutdat, '1900-01-01'),
	@ipi_inrsze = isnull(ipi_inrsze, ''),
	@ipi_mtrsze = isnull(ipi_mtrsze, ''),
	@ipi_mat = isnull(ipi_mat, '')
from	IMPCKINF (nolock)
where	ipi_itmno = @iid_venitm and
	ipi_pckunt = @iid_untcde and
	ipi_inrqty = @iid_inrqty and
	ipi_mtrqty = @iid_mtrqty and
	((ipi_conftr <> 1 and  ipi_conftr = @iid_conftr)   or  ipi_conftr = 1 )
	 and
	ipi_cus1no = @iic_cus1no and
	ipi_cus2no = @iic_cus2no

-- Retrieve IMPRCINF Data --
select	@imu_expdat = isnull(imu_expdat, '1900-01-01'),
	@imu_curcde = isnull(imu_curcde, ''),
	@imu_ftycst = isnull(imu_ftycst, 0),
	@imu_ftyprc = isnull(imu_ftyprc, 0),
	@imu_bcurcde = isnull(imu_bcurcde, ''),
	@imu_bomprc = isnull(imu_bomprc, 0),
	@imu_basprc = isnull(imu_basprc, 0),
	@imu_ftyprctrm = isnull(imu_ftyprctrm, ''),
	@imu_hkprctrm = isnull(imu_hkprctrm, '')
from	IMPRCINF (nolock)
where	imu_itmno = @iid_venitm and
	imu_prdven = @iid_prdven and
	imu_pckunt = @iid_untcde and
	(imu_conftr = 1  or (imu_conftr <>  1  and imu_conftr = @iid_conftr  ))
	and
	imu_inrqty = @iid_inrqty and
	imu_mtrqty = @iid_mtrqty and
	imu_ftyprctrm = @iid_ftyprctrm and
	imu_hkprctrm = @iid_hkprctrm and
	imu_trantrm = @iid_trantrm and
	imu_cus1no = @iic_cus1no and
	imu_cus2no = @iic_cus2no




select 't1' as 't1'

select	*
		from	IMPRCINF (nolock)
		where	imu_itmno = @iid_alsitmno and
			imu_prdven = @iid_prdven and
			imu_pckunt = @iid_untcde and
			imu_inrqty = @iid_inrqty and
			imu_mtrqty = @iid_mtrqty 
and
	((imu_conftr <> 1  and imu_conftr = @iid_conftr) or (imu_conftr=1 ) ) and

			imu_ftyprctrm = @iid_ftyprctrm and
			imu_hkprctrm = @iid_hkprctrm 

select 't2' as 't2'





-- Retrieve IMTMPREL Data --
select	@itr_tmpitm = isnull(itr_tmpitm, '')
from	IMTMPREL (nolock)
where	itr_itmno = @iid_venitm

-- Check against IMBASINF
if (select count(*) from IMBASINF (nolock) where ibi_itmno = @iid_venitm) > 0
begin
	if @iid_bomflg <> 'Y'
	begin
		-- Check Product Line / Season Code against IM --
		--if @ibi_lnecde <> @iid_lnecde
		--begin
		--	set @iid_stage = 'I'
		--	set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_lnecde + ' - Product Line / Season Code not match with Item Master', 300)
		--	set @iid_refresh = 'N'
		--end

		-- Check Category Level 4 Code against IM --
		if @ibi_catlvl4 <> @iid_catlvl4
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_catlvl4 + ' - Category Code not match with Item Master', 300)
			set @iid_refresh = 'N'
		end
	end

	-- Check PV against IM --
	if (select count(*) from IMVENINF (nolock) where ivi_itmno = @iid_venitm and ivi_venno = @iid_prdven) = 0
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_prdven + ' - PV not found in Item Master', 300)
		set @iid_refresh = 'N'
	end
end

-- Determine Item Status
if (select count(*) from IMPRCINF (nolock) where imu_itmno = @iid_venitm and imu_status = 'ACT') > 0 and
	(select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm) > 0 and
	(select count(*) from IMCOLINF (nolock) where icf_itmno = @iid_venitm) > 0
begin
	set @iid_itmsts = 'CMP'
end
else
begin
	set @iid_itmsts = 'INC'
end

-- Determine Pricing is UPDATE or NEW
if (select count(*) from IMPRCINF (nolock) where imu_itmno = @iid_venitm and imu_prdven = @iid_prdven and
	imu_pckunt = @iid_untcde and imu_inrqty = @iid_inrqty and imu_mtrqty = @iid_mtrqty and
	((imu_conftr <> 1  and imu_conftr = @iid_conftr) or (imu_conftr=1 ) ) and imu_cus1no = @iic_cus1no and imu_cus2no = @iic_cus2no and
	imu_ftyprctrm = @iid_ftyprctrm and imu_hkprctrm = @iid_hkprctrm and imu_trantrm = @iid_trantrm) > 0
begin
	-- UPDATE ITEM --
	set @iid_mode = 'UPD'

	-- Check DV against IM --
	if (select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm and ipi_pckunt = @iid_untcde and 
		ipi_inrqty = @iid_inrqty and ipi_mtrqty = @iid_mtrqty and ( ipi_conftr = @iid_conftr    or  ipi_conftr =1  ) and 
		ipi_cus1no = @iic_cus1no and ipi_cus2no = @iic_cus2no) > 0
	begin
		if @ibi_venno <> @iid_venno
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_venno + ' - Vendor not DV, cannot update Packing', 300)
			set @iid_refresh = 'N'
		end
	end

	-- Check Assortment with same packing only
	if @ibi_typ = 'ASS'
	begin
		if (select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm) > 0 and
			(select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm and ipi_pckunt = @iid_untcde and
			ipi_inrqty = @iid_inrqty and ipi_mtrqty = @iid_mtrqty and (ipi_conftr = @iid_conftr or ipi_conftr =1)) = 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_untcde + '/' + cast(@iid_inrqty as varchar(6)) + '/' + cast(@iid_mtrqty as varchar(6)) + '/' + cast(@iid_conftr as varchar(6)) + ' - Assortment Item already has a packing, cannot create another', 300)
			set @iid_refresh = 'N'
		end
	end

end
else
begin
	-- NEW ITEM --
	set @iid_mode = 'NEW'

	if @ibi_venno <> @iid_venno
	begin
		set @iid_stage = 'I'
		set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_venno + ' - Vendor not DV, cannot create Packing', 300)
		set @iid_refresh = 'N'
	end

	if @ibi_typ = 'ASS'
	begin
		if (select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm) > 0 and
			(select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm and ipi_pckunt = @iid_untcde and
			ipi_inrqty = @iid_inrqty and ipi_mtrqty = @iid_mtrqty and  ( ipi_conftr = @iid_conftr  or   ipi_conftr =1 ) ) = 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_untcde + '/' + cast(@iid_inrqty as varchar(6)) + '/' + cast(@iid_mtrqty as varchar(6)) + '/' + cast(@iid_conftr as varchar(6)) + ' - Assortment Item already has a packing, cannot create another', 300)
			set @iid_refresh = 'N'
		end
	end
	else if @ibi_typ = 'BOM'
	begin
		if (select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm) > 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_venitm + ' - BOM Item already has a packing, cannot create another', 300)
			set @iid_refresh = 'N'
		end
	end
	else if @ibi_typ = 'REG'
	begin
		select	ipi_itmno, ipi_pckunt, ipi_inrqty, ipi_mtrqty, ipi_conftr
		from 	IMPCKINF (nolock)
		where 	ipi_itmno = @iid_venitm
		group by ipi_itmno, ipi_pckunt, ipi_inrqty, ipi_mtrqty, ipi_conftr

		if @@rowcount >= 10
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_venitm + ' - Item already has 10 packing, cannot create another', 300)
			set @iid_refresh = 'N'
		end
	end

	if @iid_venno <> @iid_prdven
	begin
		if (select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm and ipi_pckunt = @iid_untcde and 
			ipi_inrqty = @iid_inrqty and ipi_mtrqty = @iid_mtrqty and ( ipi_conftr = @iid_conftr  or ipi_conftr = 1) and
			ipi_cus1no = @iic_cus1no and ipi_cus2no = @iic_cus2no) = 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_prdven + ' - PV cannot create first packing', 300)
			set @iid_refresh = 'N'
		end
		else
		begin
			if (select count(*) from IMPCKINF (nolock) where ipi_itmno = @iid_venitm) = 0
			begin
				set @iid_stage = 'I'
				set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + @iid_prdven + ' - PV cannot create item', 300)
				set @iid_refresh = 'N'
			end
		end
	end

	if @iid_alsitmno <> ''
	begin
		-- Check Previous Alias Item Used --
		if (select count(*) from IMBASINF (nolock) where ibi_alsitmno = @iid_alsitmno and left(ibi_itmno,11) <> left(@iid_venitm,11)) > 0
		begin
			set @iid_stage = 'I'
			set @iid_sysmsg = left(@iid_sysmsg + case @iid_sysmsg when '' then '' else '. ' end + 'Alias Item already been used', 300)
			set @iid_refresh = 'N'
		end

		-- Retrieve IMBASINF Data from Alias Item No. --
		select	@ibi_venno = isnull(ibi_venno, ''),
			@ibi_lnecde = isnull(ibi_lnecde, ''),
			@ibi_catlvl4 = isnull(ibi_catlvl4, ''),
			@ibi_typ = isnull(ibi_catlvl4, ''),
			@ibi_engdsc = isnull(ibi_engdsc, ''),
			@ibi_chndsc = isnull(ibi_chndsc, ''),
			@ibi_moqctn = isnull(ibi_moqctn, 0),
			@ibi_rmk = isnull(ibi_rmk, ''),
			@ibi_alsitmno = '',
			@ibi_orgdvenno = isnull(ibi_orgdvenno, ''),
			@ibi_wastage = isnull(ibi_wastage, 0),
			@ibi_alscolcde = '',
			@ibi_ftytmp = isnull(ibi_ftytmp, 'N')
		from	IMBASINF (nolock)
		where	ibi_itmno = @iid_alsitmno

		-- Retrieve IMPCKINF Data from Alias Item No. --
		select	@ipi_inrdin = isnull(ipi_inrdin, 0),
			@ipi_inrwin = isnull(ipi_inrwin, 0),
			@ipi_inrhin = isnull(ipi_inrhin, 0),
			@ipi_mtrdin = isnull(ipi_mtrdin, 0),
			@ipi_mtrwin = isnull(ipi_mtrwin, 0),
			@ipi_mtrhin = isnull(ipi_mtrhin, 0),
			@ipi_cft = isnull(ipi_cft, 0),
			@ipi_grswgt = isnull(ipi_grswgt, 0),
			@ipi_netwgt = isnull(ipi_netwgt, 0),
			@ipi_pckitr = isnull(ipi_pckitr, ''),
			@ipi_conftr = isnull(ipi_conftr, 0),
			@ipi_qutdat = isnull(ipi_qutdat, '1900-01-01'),
			@ipi_inrsze = isnull(ipi_inrsze, ''),
			@ipi_mtrsze = isnull(ipi_mtrsze, ''),
			@ipi_mat = isnull(ipi_mat, '')
		from	IMPCKINF (nolock)
		where	ipi_itmno = @iid_alsitmno and
			ipi_pckunt = @iid_untcde and
			ipi_inrqty = @iid_inrqty and
			ipi_mtrqty = @iid_mtrqty and

		(	ipi_conftr = @iid_conftr  or ipi_conftr = 1)

			and
			ipi_cus1no = @iic_cus1no and
			ipi_cus2no = @iic_cus2no
		
		-- Retrieve IMPRCINF Data from Alias Item No. --
		select	@imu_expdat = isnull(imu_expdat, '1900-01-01'),
			@imu_curcde = isnull(imu_curcde, ''),
			@imu_ftycst = isnull(imu_ftycst, 0),
			@imu_ftyprc = isnull(imu_ftyprc, 0),
			@imu_bcurcde = isnull(imu_bcurcde, ''),
			@imu_bomprc = isnull(imu_bomprc, 0),
			@imu_basprc = isnull(imu_basprc, 0),
			@imu_ftyprctrm = isnull(imu_ftyprctrm, ''),
			@imu_hkprctrm = isnull(imu_hkprctrm, '')
		from	IMPRCINF (nolock)
		where	imu_itmno = @iid_alsitmno and
			imu_prdven = @iid_prdven and
			imu_pckunt = @iid_untcde and
			imu_inrqty = @iid_inrqty and
			imu_mtrqty = @iid_mtrqty 
and
	((imu_conftr <> 1  and imu_conftr = @iid_conftr) or (imu_conftr=1 ) ) and

			imu_ftyprctrm = @iid_ftyprctrm and
			imu_hkprctrm = @iid_hkprctrm 


--and
--			imu_cus1no = @iic_cus1no and
--			imu_cus2no = @iic_cus2no
	end
end

-- Added by David Yue 2012-12-03 on behalf of request by Anita Leung --
-- New remarks will be added to existing remarks --
if rtrim(ltrim(@ibi_rmk)) <> ''
begin
	set @iid_rmk = left(@iid_rmk + case (len(rtrim(ltrim(@iid_rmk)))) when 0 then '' else char(10) + char(13) end + @ibi_rmk, 2000)
end
else
begin
	set @iid_rmk = left(@iid_rmk, 2000)
end

-- Change IMBASINF Status to Hold if valid --
if @iid_stage <> 'I'
begin
	update	IMBASINF
	set	ibi_prvsts = case ibi_itmsts when 'HLD' then ibi_prvsts else ibi_itmsts end,
		ibi_itmsts = 'HLD',
		ibi_updusr = left('E-'+ @usrid, 30),
		ibi_upddat = getdate()
	where	ibi_itmno = @iid_venitm
end

-- Change previous IMITMDAT entries to Stage 'O' --
update	IMITMDAT
set	iid_stage = 'O',
	iid_updusr = left('E-'+ @usrid, 30),
	iid_upddat = getdate()
from	IMITMDAT
	join IMITMDATCST on
		iic_venitm = iid_venitm and
		iic_itmseq = iid_itmseq and
		iic_recseq = iid_recseq
where	iid_venitm = @iid_venitm and
	iid_venno = @iid_venno and
	iid_prdven = @iid_prdven and
	iid_untcde = @iid_untcde and
	iid_inrqty = @iid_inrqty and
	iid_mtrqty = @iid_mtrqty and
	iic_cus1no = @iic_cus1no and
	iic_cus2no = @iic_cus2no and
	iid_ftyprctrm = @iid_ftyprctrm and
	iid_prctrm = @iid_hkprctrm and
	iid_trantrm = @iid_trantrm and
	iid_stage <> 'O'

-- Change previous IMITMDATCST entries to Stage 'O' --
update	IMITMDATCST
set	iic_stage = 'O',
	iic_updusr = left('E-'+ @usrid, 30),
	iic_upddat = getdate()
from	IMITMDAT
	join IMITMDATCST on
		iic_venitm = iid_venitm and
		iic_itmseq = iid_itmseq and
		iic_recseq = iid_recseq
where	iid_venitm = @iid_venitm and
	iid_venno = @iid_venno and
	iid_prdven = @iid_prdven and
	iid_untcde = @iid_untcde and
	iid_inrqty = @iid_inrqty and
	iid_mtrqty = @iid_mtrqty and
	iic_cus1no = @iic_cus1no and
	iic_cus2no = @iic_cus2no and
	iid_ftyprctrm = @iid_ftyprctrm and
	iid_prctrm = @iid_hkprctrm and
	iid_trantrm = @iid_trantrm and
	iic_stage <> 'O'

-- Normalize all null variables --
set @ibi_venno = isnull(@ibi_venno, '')
set @ibi_lnecde = isnull(@ibi_lnecde, '')
set @ibi_catlvl4 = isnull(@ibi_catlvl4, '')
set @ibi_typ = isnull(@ibi_typ, '')
set @ibi_engdsc = isnull(@ibi_engdsc, '')
set @ibi_chndsc = isnull(@ibi_chndsc, '')
set @ibi_moqctn = isnull(@ibi_moqctn, 0)
set @ibi_rmk = isnull(@ibi_rmk, '')
set @ibi_alsitmno = isnull(@ibi_alsitmno, '')
set @ibi_orgdvenno = isnull(@ibi_orgdvenno, '')
set @ibi_wastage = isnull(@ibi_wastage, 0)
set @ibi_alscolcde = isnull(@ibi_alscolcde, '')
set @ibi_ftytmp = isnull(@ibi_ftytmp, 'N')
set @ipi_inrdin = isnull(@ipi_inrdin, 0)
set @ipi_inrwin = isnull(@ipi_inrwin, 0)
set @ipi_inrhin = isnull(@ipi_inrhin, 0)
set @ipi_mtrdin = isnull(@ipi_mtrdin, 0)
set @ipi_mtrwin = isnull(@ipi_mtrwin, 0)
set @ipi_mtrhin = isnull(@ipi_mtrhin, 0)
set @ipi_cft = isnull(@ipi_cft, 0)
set @ipi_grswgt = isnull(@ipi_grswgt, 0)
set @ipi_netwgt = isnull(@ipi_netwgt, 0)
set @ipi_pckitr = isnull(@ipi_pckitr, '')
set @ipi_conftr = isnull(@ipi_conftr, 0)
set @ipi_qutdat = isnull(@ipi_qutdat, '1900-01-01')
set @ipi_inrsze = isnull(@ipi_inrsze, '')
set @ipi_mtrsze = isnull(@ipi_mtrsze, '')
set @ipi_mat = isnull(@ipi_mat, '')
set @imu_expdat = isnull(@imu_expdat, '1900-01-01')
set @imu_curcde = isnull(@imu_curcde, '')
set @imu_ftycst = isnull(@imu_ftycst, 0)
set @imu_ftyprc = isnull(@imu_ftyprc, 0)
set @imu_bcurcde = isnull(@imu_bcurcde, '')
set @imu_bomprc = isnull(@imu_bomprc, 0)
set @imu_basprc = isnull(@imu_basprc, 0)
set @imu_ftyprctrm = isnull(@imu_ftyprctrm, '')
set @imu_hkprctrm = isnull(@imu_hkprctrm, '')


-- Retrieve Next Record Sequence
select	@iid_recseq = max(iid_recseq) + 1
from	(
	select	isnull(max(iid_recseq), 0) as iid_recseq
	from 	IMITMDAT (nolock)
	where	iid_itmseq = @iid_itmseq
	UNION 
	select 	isnull(max(iid_recseq), 0) 
	from 	IMITMDATH (nolock)
	where	iid_itmseq = @iid_itmseq
	) as t

-- Insert into IMITMDAT
insert into IMITMDAT
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
	iid_moq,		iid_orgdsgvenno_bef,	iid_moq_bef,
	iid_fcurcde,		iid_fcurcde_bef,	iid_wastage,
	iid_wastage_bef,	iid_inrsze,		iid_mtrsze,
	iid_mat,		iid_inrsze_bef,		iid_mtrsze_bef,
	iid_mat_bef,		iid_remark,		iid_remark_bef,
	iid_cusven,		iid_alsitmno,		iid_alsitmno_bef,
	iid_alscolcde,		iid_alscolcde_bef,	iid_ftytmp,
	iid_ftytmp_bef,		iid_alstmpitmno,	iid_alstmpitmno_bef,
	iid_basprc,		iid_basprc_bef,		iid_bomprc,
	iid_bomprc_bef,		iid_curr_bef,		iid_assconftr,
	iid_assconftr_bef,	iid_period,		iid_period_bef,
	iid_cstexpdat,		iid_cstexpdat_bef,	iid_cus1no,
	iid_creusr,		iid_updusr,		iid_credat,
	iid_upddat
)
values
(	'',			@iid_venno,		@iid_prdven,
	@iid_venitm,		@iid_itmseq,		@iid_recseq,
	'',			@iid_venitm,		@iid_mode,
	@iid_itmsts,		@iid_stage,		@iid_engdsc,
	@iid_chndsc,		@iid_lnecde,		@iid_catlvl4,
	@iid_untcde,		@iid_inrqty,		@iid_mtrqty,
	@iid_inrdin,		@iid_inrwin,		@iid_inrhin,
	@iid_mtrdin,		@iid_mtrwin,		@iid_mtrhin,
	@iid_cft,		@iid_conftr,		@iid_sapum,
	@iic_curcde,		@iic_ftycst,		@iic_ftyprc,
	@iid_ftyprctrm,		@iid_hkprctrm,		@iid_trantrm,
	@iid_grswgt,		@iid_netwgt,		@iid_pckitr,
	@ibi_engdsc,		@ibi_chndsc,		@ibi_lnecde,
	@ibi_catlvl4,		@ipi_inrdin,		@ipi_inrwin,
	@ipi_inrhin,		@ipi_mtrdin,		@ipi_mtrwin,
	@ipi_mtrhin,		@ipi_cft,		@ipi_conftr,
	@imu_curcde,		@imu_ftycst,		@imu_ftyprc,
	@imu_ftyprctrm,		@ipi_grswgt,		@ipi_netwgt,
	@ipi_pckitr,		@iid_sysmsg,		@iid_xlsfil,
	'',			'N',			@iid_chkdat,
	@iid_refresh,		@iid_bomflg,		@iid_orgdvenno,
	@iid_moq,		@ibi_orgdvenno,		@ibi_moqctn,
	'',			'',			@iid_wastage,
	@ibi_wastage,		@iid_inrsze,		@iid_mtrsze,
	@iid_mat,		@ipi_inrsze,		@ipi_mtrsze,
	@ipi_mat,		@iid_rmk,		@ibi_rmk,
	@iid_cusven,		@iid_alsitmno,		@ibi_alsitmno,
	@iid_alscolcde,		@ibi_alscolcde,		@iid_ftytmp,
	@ibi_ftytmp,		@iid_alstmpitm,		@itr_tmpitm,
	0,			@imu_basprc,		0,
	@imu_bomprc,		@imu_bcurcde,		0,
	0,			@iid_period,		@ipi_qutdat,
	@iid_expdat,		@imu_expdat,		@iic_cus1no,
	left('E-'+ @usrid,30),	left('E-'+ @usrid,30),	getdate(),
	getdate()
)

insert into IMITMDATCST
(	iic_cocde,		iic_venno,		iic_prdven,
	iic_venitm,		iic_itmseq,		iic_recseq,
	iic_xlsfil,		iic_chkdat,		iic_cus1no,
	iic_cus2no,		iic_stage,		iic_untcde,
	iic_inrqty,		iic_mtrqty,		iic_fcA,
	iic_fcB,		iic_fcC,		iic_fcD,
	iic_fcE,
	iic_fcTran,		iic_fcPack,		iic_ftycst,
	iic_icA,		iic_icB,		iic_icC,
	iic_icD,		
	iic_icE,
	iic_icTran,		iic_icPack,
	iic_ftyprc,		iic_nat,		iic_negprc,
	iic_conftr,		iic_creusr,		iic_updusr,
	iic_credat,		iic_upddat
)
values
(	'',			@iid_venno,		@iid_prdven,
	@iid_venitm,		@iid_itmseq,		@iid_recseq,
	@iid_xlsfil,		@iid_chkdat,		@iic_cus1no,
	@iic_cus2no,		@iid_stage,		@iid_untcde,
	@iid_inrqty,		@iid_mtrqty,		@iic_ftycstA,
	@iic_ftycstB,		@iic_ftycstC,		@iic_ftycstD,
	@iic_ftycstE,
	@iic_ftycstTran,	@iic_ftycstPack,	@iic_ftycst,
	@iic_ftyprcA,		@iic_ftyprcB,		@iic_ftyprcC,
	@iic_ftyprcD,		
	@iic_ftyprcE,
	@iic_ftyprcTran,	@iic_ftyprcPack,
	@iic_ftyprc,		@iic_nat,		@iic_negprc,
	@iid_conftr,		left('E-'+ @usrid,30),	left('E-'+ @usrid,30),
	getdate(),		getdate()
)


GO
GRANT EXECUTE ON [dbo].[sp_insert_IMITMDAT] TO [ERPUSER] AS [dbo]
GO
