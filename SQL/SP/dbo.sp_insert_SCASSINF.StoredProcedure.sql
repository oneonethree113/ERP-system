/****** Object:  StoredProcedure [dbo].[sp_insert_SCASSINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SCASSINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SCASSINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/*
=================================================================
Program ID	: sp_insert_SCASSINF
Description	: Insert new entry to SCASSINF
Programmer	: Kenny Chan
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2002-01-11 	Kenny Chan		SP Created
2013-07-11	David Yue		Phase 2 Implementation
2013-10-02	David Yue		Add TO Matching
=================================================================
*/

CREATE PROCEDURE [dbo].[sp_insert_SCASSINF] 

@sai_cocde 	nvarchar(6),	@sai_ordno 	nvarchar(20),	
@sai_ordseq 	int,		@sai_itmno 	nvarchar(20),
@sai_assitm 	nvarchar(20),	@sai_assdsc 	nvarchar(300),	
@sai_cusitm	nvarchar(20),	@sai_colcde	nvarchar(30),
@sai_coldsc	nvarchar(800),	@sai_cussku     nvarchar(20),
@sai_upcean    	nvarchar(15),	@sai_cusrtl	nvarchar(20),
@sai_untcde 	nvarchar(6),	@sai_inrqty	int,
@sai_mtrqty	int,		@sai_imperiod	datetime,
@sai_cusstyno	nvarchar(30),	@sai_toordno	nvarchar(20),
@sai_toordseq	int,		@sod_ordqty	int,
@sai_creusr	nvarchar(30)

AS

insert into SCASSINF
(
	sai_cocde ,	sai_ordno ,	sai_ordseq ,
	sai_itmno ,	sai_assitm ,	sai_assdsc,
	sai_cusitm,	sai_colcde ,	sai_coldsc, 
	sai_cussku,	sai_upcean,	sai_cusrtl,
	sai_untcde,	sai_inrqty ,	sai_mtrqty,	
	sai_creusr ,	sai_updusr ,	sai_imperiod,
	sai_cusstyno,	sai_tordno,	sai_tordseq,
	sai_credat ,	sai_upddat 	
)
values
(
	@sai_cocde ,	@sai_ordno ,	@sai_ordseq ,
	@sai_itmno ,	@sai_assitm ,	@sai_assdsc,
	@sai_cusitm,	@sai_colcde ,	@sai_coldsc,
	@sai_cussku,	@sai_upcean,	@sai_cusrtl,
	@sai_untcde,	@sai_inrqty ,	@sai_mtrqty,	
	@sai_creusr ,	@sai_creusr ,	@sai_imperiod,--Frankie Cheung 20110224 Assd Period
	@sai_cusstyno,	@sai_toordno,	@sai_toordseq,
	getdate() ,	getdate()
)

-- Update SO Quantity for Tentative Order
if @sai_toordno <> ''
begin
	if (select count(*) from TOORDHDR (nolock) where toh_toordno = @sai_toordno and toh_ordsts <> 'CLO') > 0
	begin
		update	TOITMDTL
		set	tid_ordno = @sai_ordno,
			tid_ordseq = @sai_ordseq,
			tid_soqty = tid_soqty + (@sod_ordqty * @sai_mtrqty),
			tid_osqty = tid_toqty - tid_soqty - (@sod_ordqty * @sai_mtrqty),
			tid_updusr = left(@sai_creusr, 30),
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









GO
GRANT EXECUTE ON [dbo].[sp_insert_SCASSINF] TO [ERPUSER] AS [dbo]
GO
