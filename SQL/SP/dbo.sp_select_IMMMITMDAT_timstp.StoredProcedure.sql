/****** Object:  StoredProcedure [dbo].[sp_select_IMMMITMDAT_timstp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMMITMDAT_timstp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMMITMDAT_timstp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*	Author : Tommy Ho	*/

CREATE PROCEDURE [dbo].[sp_select_IMMMITMDAT_timstp] 
@imd_cocde 		nvarchar(6),
@imd_cus1no 		nvarchar(100),	@imd_cus2no	nvarchar(100),	
@imd_itmno		nvarchar(500),	@imd_inrqty	int,
@imd_mtrqty		int,		@imd_itmseq	int,
@imd_recseq		int,		@imd_untcde	nvarchar(60)

AS

select 	cast(imd_timstp as int) as 'imd_timstp'
from  IMMMITMDAT

where 	
	imd_cus1no = @imd_cus1no 	and	imd_cus2no = @imd_cus2no	and
	imd_itmno = @imd_itmno	and 	imd_inrqty = @imd_inrqty	and
	imd_mtrqty = @imd_mtrqty	and	imd_itmseq = @imd_itmseq	and
	imd_recseq = @imd_recseq	and	imd_untcde = @imd_untcde


GO
GRANT EXECUTE ON [dbo].[sp_select_IMMMITMDAT_timstp] TO [ERPUSER] AS [dbo]
GO
