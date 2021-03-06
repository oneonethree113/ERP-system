/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SCORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SCORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SCORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Kenny Chan
Date:		8th Jan, 2002
Description:	Delete data From SCORDDTL
Parameter:	1. Company
		2. SC No.	
		3.OrdSeq
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Physical_Delete_SCORDDTL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@sod_cocde  nvarchar     (6),
@sod_ordno  nvarchar     (20),
@sod_ordseq int
----------------------------------------------  
AS

begin

if (select count(*) from SCORDDTL (nolock) where sod_cocde = @sod_cocde and sod_ordno = @sod_ordno and sod_ordseq = @sod_ordseq and sod_tordno <> '') > 0
begin
	update	TOITMDTL
	set	tid_ordno = '',
		tid_ordseq = 0,
		tid_soqty = tid_soqty - sod_ordqty,
		tid_osqty = tid_toqty - tid_soqty + sod_ordqty,
		--tid_updusr = left(@creusr, 30),
		tid_upddat = getdate()
	from	TOITMDTL
		join SCORDDTL (nolock) on
			tid_toordno = sod_tordno and
			tid_toordseq = sod_tordseq and
			tid_itmno = sod_itmno
	where	sod_cocde = @sod_cocde and
		sod_ordno = @sod_ordno and
		sod_ordseq = @sod_ordseq and
		sod_tordno <> ''

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
		join SCORDDTL (nolock) on
			tid_toordno = sod_tordno and
			tid_toordseq = sod_tordseq and
			tid_itmno = sod_itmno
	where	sod_cocde = @sod_cocde and
		sod_ordno = @sod_ordno and
		sod_ordseq = @sod_ordseq and
		sod_tordno <> '' and
		tid_toordno = sod_tordno and
		tid_toordseq = sod_tordseq
end

Delete SCORDDTL
Where 
sod_cocde = @sod_cocde  and
sod_ordno = @sod_ordno and
sod_ordseq = @sod_ordseq
---------------------------------------------------------- 
end







GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SCORDDTL] TO [ERPUSER] AS [dbo]
GO
