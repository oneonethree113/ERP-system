/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SCASSINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SCASSINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SCASSINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 27/07/2003 

/************************************************************************
Author:		Kenny Chan
Date:		11th jan, 2002
Description:	Delete data From SCASSINF
Parameter:	1. Company
		2. SC No.	
************************************************************************/
CREATE PROCEDURE [dbo].[sp_physical_delete_SCASSINF] 

@sai_cocde 	nvarchar(6),
@sai_ordno 	nvarchar(20),
@sai_ordseq 	int,
@sai_itmno	nvarchar(20) =null,
@sai_assitm	nvarchar(20) =null,
@sai_colcde	nvarchar(30) =null


AS

if (select count(*) from SCASSINF (nolock) where sai_cocde = @sai_cocde and sai_ordno = @sai_ordno and sai_ordseq = @sai_ordseq and sai_tordno <> '') > 0
begin
	update	TOITMDTL
	set	tid_ordno = '',
		tid_ordseq = 0,
		tid_soqty = tid_soqty - (sod_ordqty * sai_mtrqty),
		tid_osqty = tid_toqty - tid_soqty + (sod_ordqty * sai_mtrqty),
		--tid_updusr = left(@sai_updusr, 30),
		tid_upddat = getdate()
	from	TOITMDTL
		join SCASSINF (nolock) on
			tid_toordno = sai_tordno and
			tid_toordseq = sai_tordseq
		join SCORDDTL (nolock) on
			sod_cocde = sai_cocde and
			sod_ordno = sai_ordno and
			sod_ordseq = sai_ordseq
	where	sai_cocde = @sai_cocde and
		sai_ordno = @sai_ordno and
		sai_ordseq = @sai_ordseq and
		sai_tordno <> ''

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
		join SCASSINF (nolock) on
			tid_toordno = sai_tordno and
			tid_toordseq = sai_tordseq
		join SCORDDTL (nolock) on
			sod_cocde = sai_cocde and
			sod_ordno = sai_ordno and
			sod_ordseq = sai_ordseq
	where	sod_cocde = @sai_cocde and
		sod_ordno = @sai_ordno and
		sod_ordseq = @sai_ordseq and
		sod_tordno <> '' and
		tid_toordno = sai_tordno and
		tid_toordseq = sai_tordseq
end

IF @SAI_ITMNO IS NULL 
	begin
		delete from SCASSINF
		where 	sai_cocde = @sai_cocde
		and 	sai_ordno = @sai_ordno
		and 	sai_ordseq = @sai_ordseq
	end
else
	begin
		delete from SCASSINF
		where 	sai_cocde = @sai_cocde
		and 	sai_ordno = @sai_ordno
		and 	sai_ordseq = @sai_ordseq
		and  	sai_itmno = @sai_itmno	
		and 	sai_assitm = @sai_assitm	
		and 	sai_colcde = @sai_colcde
	end




GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SCASSINF] TO [ERPUSER] AS [dbo]
GO
