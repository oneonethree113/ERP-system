/****** Object:  StoredProcedure [dbo].[sp_update_IMITMDAT_Refresh]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMITMDAT_Refresh]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMITMDAT_Refresh]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/*
=================================================================
Program ID	: sp_update_IMITMDAT_Refresh
Description	: Update IMITMDAT Status from fixable errors
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-03-21 	David Yue		SP Created
=================================================================
*/

CREATE PROCEDURE [dbo].[sp_update_IMITMDAT_Refresh] 

@usrid		nvarchar(30)

AS

declare -- IMITMDAT --
@iid_venno	nvarchar(6),
@iid_prdven	nvarchar(6),
@iid_venitm	nvarchar(20),
@iid_itmseq	int,
@iid_recseq	int,
@iid_itmtyp	nvarchar(4),
@iid_stage	nvarchar(3),
@iid_lnecde	nvarchar(10),
@iid_catlvl4	nvarchar(20),
@iid_sysmsg	nvarchar(300),
@iid_xlsfil	nvarchar(30),
@iid_chkdat	datetime,
@iid_orgdvenno	nvarchar(6),
@iid_cusven	nvarchar(6)

declare	-- IMITMDATCST --
@iic_cus1no	nvarchar(6),
@iic_cus2no	nvarchar(6)

DECLARE cur_IMITMDAT CURSOR
FOR	select	iid_venno,	iid_prdven,	iid_venitm,
		iid_itmseq,	iid_recseq,	iid_itmtyp,
		iid_recseq,	iid_itmtyp,	iid_stage,
		iid_lnecde,	iid_catlvl4,	iid_sysmsg,
		iid_xlsfil,	iid_chkdat,	iid_orgdsgvenno,
		iid_cusven
	from	IMITMDAT (nolock)
	where	iid_stage = 'I' and
		iid_refresh = 'Y'
OPEN cur_IMITMDAT
FETCH NEXT FROM cur_IMITMDAT INTO
@iid_venno,	@iid_prdven,	@iid_venitm,
@iid_itmseq,	@iid_recseq,	@iid_itmtyp,
@iid_recseq,	@iid_itmtyp,	@iid_stage,
@iid_lnecde,	@iid_catlvl4,	@iid_sysmsg,
@iid_xlsfil,	@iid_chkdat,	@iid_orgdvenno,
@iid_cusven

WHILE @@fetch_status = 0
BEGIN
	select	@iic_cus1no = iic_cus1no,
		@iic_cus2no = iic_cus2no
	from	IMITMDATCST (nolock)
	where	iic_itmseq = @iid_itmseq and
		iic_recseq = @iid_recseq and
		iic_venitm = @iid_venitm and
		iic_xlsfil = @iid_xlsfil and
		iic_chkdat = @iid_chkdat
	
	set @iid_stage = 'W'
	
	-- Check DV --
	if (select count(*) from VNBASINF (nolock) where vbi_venno = @iid_venno) = 0
	begin
		set @iid_stage = 'I'
	end
	else
	begin
		set @iid_stage = case @iid_stage when 'I' then 'I' else 'W' end
	end

	-- Check Original DV --
	if (select count(*) from VNBASINF (nolock) where vbi_venno = @iid_orgdvenno) = 0
	begin
		set @iid_stage = 'I'
	end
	else
	begin
		set @iid_stage = case @iid_stage when 'I' then 'I' else 'W' end
	end

	-- Check PV --
	if (select count(*) from VNBASINF (nolock) where vbi_venno = @iid_prdven) = 0
	begin
		set @iid_stage = 'I'
	end
	else
	begin
		set @iid_stage = case @iid_stage when 'I' then 'I' else 'W' end
	end

	-- Check CV --
	if (select count(*) from VNBASINF (nolock) where vbi_venno = @iid_cusven) = 0
	begin
		set @iid_stage = 'I'
	end
	else
	begin
		set @iid_stage = case @iid_stage when 'I' then 'I' else 'W' end
	end

	if @iid_itmtyp <> 'BOM'
	begin
		if (select count(*) from CUGRPINF (nolock) where cgi_cugrpcde = @iic_cus1no and cgi_flg_int = 'Y') = 0
		begin
			-- Check Primary Customer --
			if (select count(*) from CUBASINF (nolock) where cbi_cusno = @iic_cus1no) = 0
			begin
				set @iid_stage = 'I'
			end
			else
			begin
				-- Check Primary and Secondary Mapping --
				if (select count(*) from CUSUBCUS (nolock) where csc_prmcus = @iic_cus1no and csc_seccus = @iic_cus2no) = 0 and @iic_cus2no <> ''
				begin
					set @iid_stage = 'I'
				end
				else
				begin
					set @iid_stage = case @iid_stage when 'I' then 'I' else 'W' end
				end
			end
		end
		
		if (select count(*) from SYLNEINF (nolock) where yli_lnecde = @iid_lnecde) = 0
		begin
			set @iid_stage = 'I'
		end
		else
		begin
			set @iid_stage = case @iid_stage when 'I' then 'I' else 'W' end
		end
	end

	if @iid_stage = 'W'
	begin
		set @iid_sysmsg = left('(Invalid Before) ' + @iid_sysmsg, 300)
		
		-- Update IMITMDAT --
		update	IMITMDAT
		set	iid_stage = @iid_stage,
			iid_sysmsg = @iid_sysmsg,
			iid_updusr = left('E-'+ @usrid, 30),
			iid_upddat = getdate()
		where	iid_itmseq = @iid_itmseq and
			iid_recseq = @iid_recseq and
			iid_venitm = @iid_venitm and
			iid_xlsfil = @iid_xlsfil and
			iid_chkdat = @iid_chkdat
	end

	FETCH NEXT FROM cur_IMITMDAT INTO
	@iid_venno,	@iid_prdven,	@iid_venitm,
	@iid_itmseq,	@iid_recseq,	@iid_itmtyp,
	@iid_recseq,	@iid_itmtyp,	@iid_stage,
	@iid_lnecde,	@iid_catlvl4,	@iid_sysmsg,
	@iid_xlsfil,	@iid_chkdat,	@iid_orgdvenno,
	@iid_cusven
END
CLOSE cur_IMITMDAT
DEALLOCATE cur_IMITMDAT

-- Update IMITMDATCST --
update	IMITMDATCST
set	iic_stage = iid_stage,
	iic_updusr = left('E-'+ @usrid, 30),
	iic_upddat = getdate()
from	IMITMDAT
	join IMITMDATCST on
		iic_itmseq = iid_itmseq and
		iic_recseq = iid_recseq and
		iic_venitm = iid_venitm and
		iic_xlsfil = iid_xlsfil and
		iic_chkdat = iid_chkdat
where	iic_stage = 'I' and
	iid_stage = 'W' and
	iid_updusr = left('E-'+ @usrid, 30)

-- Update IMCOLDAT --
update	IMCOLDAT
set	icd_stage = iid_stage,
	icd_updusr = left('E-'+ @usrid, 30),
	icd_upddat = getdate()
from	IMCOLDAT
	join IMITMDAT on
		icd_itmseq = iid_itmseq and
		icd_venitm = iid_venitm and
		icd_xlsfil = iid_xlsfil and
		icd_chkdat = iid_chkdat
where	icd_stage = 'I' and
	iid_stage = 'W' and
	iid_updusr = left('E-'+ @usrid, 30)

-- Update IMCOMDAT --
update	IMCOMDAT
set	imd_stage = iid_stage,
	imd_updusr = left('E-'+ @usrid, 30),
	imd_upddat = getdate()
from	IMCOMDAT
	join IMITMDAT on
		imd_itmseq = iid_itmseq and
		imd_venitm = iid_venitm and
		imd_xlsfil = iid_xlsfil and
		imd_chkdat = iid_chkdat
where	imd_stage = 'I' and
	iid_stage = 'W' and
	iid_updusr = left('E-'+ @usrid, 30)

-- Update IMBOMDAT --
update	IMBOMDAT
set	ibd_stage = iid_stage,
	ibd_updusr = left('E-'+ @usrid, 30),
	ibd_upddat = getdate()
from	IMBOMDAT
	join IMITMDAT on
		ibd_itmseq = iid_itmseq and
		ibd_venitm = iid_venitm and
		ibd_xlsfil = iid_xlsfil and
		ibd_chkdat = iid_chkdat
where	ibd_stage = 'I' and
	iid_stage = 'W' and
	iid_updusr = left('E-'+ @usrid, 30)

-- Update IMASSDAT --
update	IMASSDAT
set	iad_stage = iid_stage,
	iad_updusr = left('E-'+ @usrid, 30),
	iad_upddat = getdate()
from	IMASSDAT
	join IMITMDAT on
		iad_itmseq = iid_itmseq and
		iad_venitm = iid_venitm and
		iad_xlsfil = iid_xlsfil and
		iad_chkdat = iid_chkdat
where	iad_stage = 'I' and
	iid_stage = 'W' and
	iid_updusr = left('E-'+ @usrid, 30)




GO
GRANT EXECUTE ON [dbo].[sp_update_IMITMDAT_Refresh] TO [ERPUSER] AS [dbo]
GO
