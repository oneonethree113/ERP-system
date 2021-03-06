/****** Object:  StoredProcedure [dbo].[sp_insert_IMBOMDAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMBOMDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMBOMDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

/*
=================================================================
Program ID	: sp_insert_IMBOMDAT   
Description	: Insert data into IMBOMDAT
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-07-14	David Yue		SP Created
=================================================================
*/

CREATE procedure [dbo].[sp_insert_IMBOMDAT]

@ibd_cocde	nvarchar(6),
@ibd_itmseq	int,
@ibd_xlsfil	nvarchar(30),
@ibd_chkdat	nvarchar(30),
@ibd_venitm	nvarchar(20),
@ibd_acsno	nvarchar(20),
@ibd_itmdsc	nvarchar(300),
@ibd_colcde	nvarchar(30),
@ibd_untcde	nvarchar(6),
@ibd_conftr	int,
@ibd_qty	int,
@ibd_period	nvarchar(30),
@usrid		nvarchar(30)

AS

declare -- IMBOMDAT --
@ibd_recseq	int,
@ibd_stage	nvarchar(1),
@ibd_sysmsg	nvarchar(300),
@ibd_period_bef	datetime

set @ibd_period_bef = '1900-01-01'
set @ibd_stage = 'W'
set @ibd_sysmsg = ''

if (select count(*) from IMITMDAT (nolock) where iid_itmseq = @ibd_itmseq and iid_xlsfil = @ibd_xlsfil and
	iid_chkdat = @ibd_chkdat and iid_venitm = @ibd_venitm) = 0
begin
	set @ibd_stage = 'I'
	set @ibd_sysmsg = left(@ibd_sysmsg + case @ibd_sysmsg when '' then '' else '. ' end + @ibd_venitm + ' - Item Info not found in Excel', 300)
end
else
begin
	-- Check IMITMDAT if Item Exists --
	if (select count(*) from IMITMDAT (nolock) where iid_itmseq = @ibd_itmseq and iid_venitm = @ibd_venitm) = 0
	begin
		set @ibd_stage = 'I'
		set @ibd_sysmsg = left(@ibd_sysmsg + case @ibd_sysmsg when '' then '' else '. ' end + @ibd_acsno + ' - Invalid BOM Item', 300)
	end
	
	-- Retrieve Previous BOM Period --
	select	top 1
		@ibd_period_bef = isnull(iba_period, '1900-01-01')
	from	IMBOMASS (nolock)
	where	iba_itmno = @ibd_venitm and
		iba_typ = 'BOM' and
		iba_assitm = @ibd_acsno and
		iba_colcde = @ibd_colcde
	
	if (select count(*) from IMBASINF (nolock) where ibi_itmno = @ibd_acsno and ibi_typ = 'BOM') = 0
	begin
		set @ibd_stage = 'I'
		set @ibd_sysmsg = left(@ibd_sysmsg + case @ibd_sysmsg when '' then '' else '. ' end + @ibd_acsno + ' - Invalid BOM Item', 300)
	end
	else
	begin
		if (select count(*) from IMBASINF (nolock) where ibi_itmno = @ibd_acsno and ibi_typ = 'BOM' and ibi_itmsts = 'CMP') = 0
		begin
			set @ibd_stage = 'I'
			set @ibd_sysmsg = left(@ibd_sysmsg + case @ibd_sysmsg when '' then '' else '. ' end + @ibd_acsno + ' - BOM Item not in Complete status', 300)
		end
	
		if (select count(*) from IMCOLINF (nolock) where icf_itmno = @ibd_acsno and icf_colcde = @ibd_colcde) = 0
		begin
			set @ibd_stage = 'I'
			set @ibd_sysmsg = left(@ibd_sysmsg + case @ibd_sysmsg when '' then '' else '. ' end + @ibd_acsno + ' - BOM Item color code not found in IM', 300)
		end
	
		if (select count(*) from IMPCKINF (nolock) where ipi_itmno = @ibd_acsno and ipi_pckunt = @ibd_untcde and 
			ipi_conftr = @ibd_conftr and cast(datepart(yyyy, ipi_qutdat) as varchar(4)) + '-' + right('0' + cast(datepart(mm, ipi_qutdat) as varchar(2)), 2) <> @ibd_period) = 0
		begin
			set @ibd_stage = 'I'
			set @ibd_sysmsg = left(@ibd_sysmsg + case @ibd_sysmsg when '' then '' else '. ' end + substring(@ibd_period,1,7) + ' - BOM Item period not matched with IM', 300)
		end
	end
end

-- Change previous IMCOMDAT entries to Stage 'O' --
update	IMBOMDAT
set	ibd_stage = 'O',
	ibd_updusr = left('E-'+ @usrid, 30),
	ibd_upddat = getdate()
where	ibd_itmseq <> @ibd_itmseq and
	ibd_venitm = @ibd_venitm

-- Change IMITMDAT and IMITMDATCST Stage to 'I' if IMCOMDAT Stage is 'I' --
if @ibd_stage = 'I'
begin
	update	IMITMDAT
	set	iid_stage = 'I',
		iid_sysmsg = left(iid_sysmsg + case iid_sysmsg when '' then '' else '. ' end + @ibd_sysmsg ,300),
		iid_refresh = 'N',
		iid_updusr = left('E-'+ @usrid, 30),
		iid_upddat = getdate()
	where	iid_itmseq = @ibd_itmseq and
		iid_venitm = @ibd_venitm

	update	IMITMDATCST
	set	iic_stage = 'I',
		iic_updusr = left('E-'+ @usrid, 30),
		iic_upddat = getdate()
	where	iic_itmseq = @ibd_itmseq and
		iic_venitm = @ibd_venitm
end

-- Retrieve Next Record Sequence
select	@ibd_recseq = max(ibd_recseq) + 1
from	(
	select	isnull(max(ibd_recseq), 0) as ibd_recseq
	from 	IMBOMDAT (nolock)
	where	ibd_itmseq = @ibd_itmseq
	UNION 
	select 	isnull(max(ibd_recseq), 0)
	from 	IMBOMDATH (nolock)
	where	ibd_itmseq = @ibd_itmseq
	) as t

-- Insert into IMBOMDAT --
insert into IMBOMDAT
(	ibd_cocde,		ibd_venno,		ibd_prdven,		
	ibd_venitm,		ibd_acsno,		ibd_itmseq,		
	ibd_recseq,		ibd_colcde,		ibd_qty,		
	ibd_untcde,		ibd_conftr,		ibd_stage,		
	ibd_sysmsg,		ibd_xlsfil,		ibd_veneml,		
	ibd_malsts,		ibd_chkdat,		ibd_itmdsc,		
	ibd_period,		ibd_creusr,		ibd_updusr,
	ibd_credat,		ibd_upddat
)
values
(	'',			'',			'',
	@ibd_venitm,		@ibd_acsno,		@ibd_itmseq,
	@ibd_recseq,		@ibd_colcde,		@ibd_qty,
	@ibd_untcde,		@ibd_conftr,		@ibd_stage,
	@ibd_sysmsg,		@ibd_xlsfil,		'',
	'N',			@ibd_chkdat,		@ibd_itmdsc,
	@ibd_period,		left('E-'+ @usrid, 30),	left('E-'+ @usrid, 30),
	getdate(),		getdate()
)



GO
GRANT EXECUTE ON [dbo].[sp_insert_IMBOMDAT] TO [ERPUSER] AS [dbo]
GO
