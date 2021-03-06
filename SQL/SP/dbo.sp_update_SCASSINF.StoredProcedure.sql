/****** Object:  StoredProcedure [dbo].[sp_update_SCASSINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SCASSINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SCASSINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/*
=================================================================
Program ID	: sp_update_SCASSINF
Description	: Update entry for SCASSINF
Programmer	: Kenny Chan
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2002-01-11 	Kenny Chan		SP Created
2011-02-23	Frankie Cheung		Add Assorted Item Period
2013-07-11	David Yue		Phase 2 Implementation
2013-10-02	David Yue		Add TO Matching
=================================================================
*/


CREATE PROCEDURE [dbo].[sp_update_SCASSINF] 

@sai_cocde 	nvarchar(6),	@sai_ordno 	nvarchar(20),	@sai_ordseq 	int,
@sai_itmno 	nvarchar(20),	@sai_assitm 	nvarchar(20),	@sai_assdsc 	nvarchar(300),	
@sai_cusitm	nvarchar(20),	@sai_colcde	nvarchar(30), 	@sai_coldsc	nvarchar(800),
@sai_cussku      nvarchar(20),	@sai_upcean      nvarchar(15),	@sai_cusrtl	nvarchar(20),
@sai_untcde 	nvarchar(6),	@sai_inrqty	int,		@sai_mtrqty	int,	
@sai_imperiod	datetime,	@sai_cusstyno	nvarchar(30),	@sai_toordno	nvarchar(20),
@sai_toordseq	int,		@sod_ordqty	int,		@old_toordno	nvarchar(20),	
@old_toordseq	int,		@old_ordqty	int,		@sai_updusr	nvarchar(30)

AS

update  SCASSINF
set	sai_assdsc = @sai_assdsc,
	sai_cusitm = @sai_cusitm,
	sai_cussku = @sai_cussku,
	sai_upcean = @sai_upcean,
	sai_cusrtl = @sai_cusrtl,
	sai_coldsc = @sai_coldsc,
	sai_untcde = @sai_untcde,
	sai_inrqty = @sai_inrqty,
	sai_mtrqty = @sai_mtrqty,
	sai_imperiod = @sai_imperiod,
	sai_cusstyno = @sai_cusstyno,
	sai_tordno = @sai_toordno,
	sai_tordseq = @sai_toordseq,
	sai_updusr = @sai_updusr,
	sai_upddat = getdate()
where	sai_cocde = @sai_cocde and
	sai_ordno = @sai_ordno and
	sai_ordseq = @sai_ordseq and
	sai_itmno = @sai_itmno and
	sai_assitm = @sai_assitm and
	sai_colcde = @sai_colcde


-- Check if TO Matching update is required
if @old_toordno <> @sai_toordno or @old_toordseq <> @sai_toordseq or @old_ordqty <> @sod_ordqty
begin
	if (select count(*) from TOORDHDR (nolock) where toh_toordno = @sai_toordno and toh_ordsts <> 'CLO') > 0
	begin
		if @old_toordno = ''
		begin
			-- Update TO Matching
			update	TOITMDTL
			set	tid_ordno = @sai_ordno,
				tid_ordseq = @sai_ordseq,
				tid_soqty = tid_soqty + (@sod_ordqty * @sai_mtrqty),
				tid_osqty = tid_toqty - tid_soqty - (@sod_ordqty * @sai_mtrqty),
				tid_updusr = left(@sai_updusr, 30),
				tid_upddat = getdate()
			where	tid_toordno = @sai_toordno and
				tid_toordseq = @sai_toordseq
	
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
			where	tid_toordno = @sai_toordno and
				tid_toordseq = @sai_toordseq
		end
		else if @old_toordno <> @sai_toordno or @old_toordseq <> @sai_ordseq
		begin
			-- Remove old TO Matching
			update	TOITMDTL
			set	tid_ordno = '',
				tid_ordseq = 0,
				tid_soqty = tid_soqty - (@old_ordqty * @sai_mtrqty),
				tid_osqty = tid_toqty - tid_soqty + (@old_ordqty * @sai_mtrqty),
				tid_updusr = left(@sai_updusr, 30),
				tid_upddat = getdate()
			where	tid_toordno = @old_toordno and
				tid_toordseq = @old_toordseq
	
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
			where	tid_toordno = @old_toordno and
				tid_toordseq = @old_toordseq
	
			-- Update new TO Matching
			update	TOITMDTL
			set	tid_ordno = @sai_ordno,
				tid_ordseq = @sai_ordseq,
				tid_soqty = tid_soqty + (@sod_ordqty * @sai_mtrqty),
				tid_osqty = tid_toqty - tid_soqty - (@sod_ordqty * @sai_mtrqty),
				tid_updusr = left(@sai_updusr, 30),
				tid_upddat = getdate()
			where	tid_toordno = @sai_toordno and
				tid_toordseq = @sai_toordseq
	
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
			where	tid_toordno = @sai_toordno and
				tid_toordseq = @sai_toordseq
		end
		else if @old_ordqty <> @sod_ordqty
		begin
			-- Update order quantity difference TO Matching
			update	TOITMDTL
			set	tid_ordno = @sai_ordno,
				tid_ordseq = @sai_ordseq,
				tid_soqty = tid_soqty + ((@sod_ordqty - @old_ordqty) * @sai_mtrqty),
				tid_osqty = tid_toqty - tid_soqty - ((@sod_ordqty - @old_ordqty) * @sai_mtrqty),
				tid_updusr = left(@sai_updusr, 30),
				tid_upddat = getdate()
			where	tid_toordno = @sai_toordno and
				tid_toordseq = @sai_toordseq
	
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
			where	tid_toordno = @sai_toordno and
				tid_toordseq = @sai_toordseq
		end
	end
end





GO
GRANT EXECUTE ON [dbo].[sp_update_SCASSINF] TO [ERPUSER] AS [dbo]
GO
