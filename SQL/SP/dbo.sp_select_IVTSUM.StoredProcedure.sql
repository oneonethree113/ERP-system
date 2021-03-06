/****** Object:  StoredProcedure [dbo].[sp_select_IVTSUM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IVTSUM]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IVTSUM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Wong Hong
Date:		19th dec, 2001
Description:	Select data From IMVTLITY
Parameter:	1. Company
		2. Location
		3. Item
		4. Color Code
		5. UM
		6. Inner
		7. Master
		8. CFT
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IVTSUM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ivt_cocde	nvarchar(6),
@ivt_itmno 	nvarchar(20),
@ivt_colcde	nvarchar(30),
@ivt_untcde nvarchar(6),
@ivt_inrqty	int,
@ivt_mtrqty int,
@ivt_cft	numeric(11,4)

---------------------------------------------- 
 
AS
BEGIN
SELECT
SUM(ivt_qty) as ivt_qty
--------------------------------- 
FROM IMVTLITY
WHERE
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
ivt_cocde	= @ivt_cocde AND
ivt_locatn = @ivt_cocde AND
ivt_itmno 	= @ivt_itmno AND	
ivt_colcde	= @ivt_colcde AND
ivt_untcde = @ivt_untcde AND
ivt_inrqty	= @ivt_inrqty AND
ivt_mtrqty = @ivt_mtrqty AND
ivt_cft	= @ivt_cft	
                                                                                 
---------------------------------------------------------- 
END




GO
GRANT EXECUTE ON [dbo].[sp_select_IVTSUM] TO [ERPUSER] AS [dbo]
GO
