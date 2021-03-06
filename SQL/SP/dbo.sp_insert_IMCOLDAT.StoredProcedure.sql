/****** Object:  StoredProcedure [dbo].[sp_insert_IMCOLDAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMCOLDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMCOLDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










/*
=================================================================
Program ID	: sp_insert_IMCOLDAT   
Description	: Insert data into IMCOLDAT
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-07-12	David Yue		SP Created
=================================================================
*/

CREATE  procedure [dbo].[sp_insert_IMCOLDAT]
                                                                                                                                                                                                                                                                 
@icd_cocde	nvarchar(6),
@icd_itmseq	int,
@icd_xlsfil	nvarchar(30),
@icd_chkdat	nvarchar(30),
@icd_venitm	nvarchar(20),
@icd_colcde	nvarchar(30),
@icd_coldsc	nvarchar(300),
@usrid		nvarchar(30)

AS

declare -- IMCOLDAT --
@icd_recseq	int,
@icd_stage	nvarchar(1),
@icd_sysmsg	nvarchar(300)

set @icd_stage = 'W'
set @icd_sysmsg = ''

if (select count(*) from IMITMDAT (nolock) where iid_itmseq = @icd_itmseq and iid_xlsfil = @icd_xlsfil and
	iid_chkdat = @icd_chkdat and iid_venitm = @icd_venitm) = 0
begin
	set @icd_stage = 'I'
	set @icd_sysmsg = left(@icd_sysmsg + case @icd_sysmsg when '' then '' else '. ' end + @icd_venitm + ' - Item Info not found in Excel', 300)
end
else
begin
	if dbo.IMBASINF_NewFmt(@icd_venitm) = 'Y'
	begin
		if (select count(*) from IMCOLINF (nolock) where icf_itmno = @icd_venitm and icf_colcde <> @icd_colcde) > 0
		begin
			set @icd_stage = 'I'
			set @icd_sysmsg = left(@icd_sysmsg + case @icd_sysmsg when '' then '' else '. ' end + @icd_colcde + ' - Only one color code per item', 300)
		end
		
		if (select count(*) from IMCOLDAT (nolock) where icd_itmseq = @icd_itmseq and icd_venitm = @icd_venitm) > 0
		begin
			set @icd_stage = 'I'
			set @icd_sysmsg = left(@icd_sysmsg + case @icd_sysmsg when '' then '' else '. ' end + @icd_colcde + ' - Multiple color entry for one item', 300)

			-- Update Stage to 'I' for same Item No. from same Excel file
			update	IMCOLDAT
			set	icd_stage = 'I',
				icd_sysmsg = left(icd_sysmsg + case icd_sysmsg when '' then '' else '. ' end + @icd_colcde + ' - Multiple color entry for one item', 300)
			where	icd_itmseq = @icd_itmseq and
				icd_venitm = @icd_venitm
		end
	end
end

-- Change previous IMCOLDAT entries to Stage 'O' --
update	IMCOLDAT
set	icd_stage = 'O',
	icd_updusr = left('E-'+ @usrid, 30),
	icd_upddat = getdate()
where	icd_itmseq <> @icd_itmseq and
	icd_venitm = @icd_venitm

-- Change IMITMDAT and IMITMDATCST Stage to 'I' if IMCOLDAT Stage is 'I' --
if @icd_stage = 'I'
begin
	update	IMITMDAT
	set	iid_stage = 'I',
		iid_sysmsg = left(iid_sysmsg + case iid_sysmsg when '' then '' else '. ' end + @icd_sysmsg ,300),
		iid_refresh = 'N',
		iid_updusr = left('E-'+ @usrid, 30),
		iid_upddat = getdate()
	where	iid_itmseq = @icd_itmseq and
		iid_venitm = @icd_venitm

	update	IMITMDATCST
	set	iic_stage = 'I',
		iic_updusr = left('E-'+ @usrid, 30),
		iic_upddat = getdate()
	where	iic_itmseq = @icd_itmseq and
		iic_venitm = @icd_venitm
end

-- Retrieve Next Record Sequence
select	@icd_recseq = max(icd_recseq) + 1
from	(
	select	isnull(max(icd_recseq), 0) as icd_recseq
	from 	IMCOLDAT (nolock)
	where	icd_itmseq = @icd_itmseq
	UNION 
	select 	isnull(max(icd_recseq), 0)
	from 	IMCOLDATH (nolock)
	where	icd_itmseq = @icd_itmseq
	) as t

-- Insert into IMCOLDAT --
insert into IMCOLDAT
(	icd_cocde,		icd_venno,		icd_prdven,		
	icd_venitm,		icd_itmseq,		icd_recseq,		
	icd_colcde,		icd_coldsc,		icd_stage,		
	icd_sysmsg,		icd_xlsfil,		icd_veneml,		
	icd_malsts,		icd_chkdat,		icd_creusr,		
	icd_updusr,		icd_credat,		icd_upddat
)
values
(	'',			'',			'',
	@icd_venitm,		@icd_itmseq,		@icd_recseq,
	@icd_colcde,		@icd_coldsc,		@icd_stage,
	@icd_sysmsg,		@icd_xlsfil,		'',
	'N',			@icd_chkdat,		left('E-'+ @usrid, 30),
	left('E-'+ @usrid, 30),	getdate(),		getdate()
)



GO
GRANT EXECUTE ON [dbo].[sp_insert_IMCOLDAT] TO [ERPUSER] AS [dbo]
GO
