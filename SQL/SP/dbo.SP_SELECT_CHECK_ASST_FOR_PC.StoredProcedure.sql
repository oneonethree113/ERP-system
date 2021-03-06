/****** Object:  StoredProcedure [dbo].[SP_SELECT_CHECK_ASST_FOR_PC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[SP_SELECT_CHECK_ASST_FOR_PC]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_CHECK_ASST_FOR_PC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
Project : Assortment UM
It aims to check the assortment's Vendor where is A, B or U

*/

CREATE  PROCEDURE [dbo].[SP_SELECT_CHECK_ASST_FOR_PC]
@COCDE NVARCHAR(6),
@ITMNO NVARCHAR(20)
AS


BEGIN
	select distinct
	isnull(iba_itmno,'') as 'ibi_itmno'
	 from imbomass
	where iba_typ = 'ASS' and iba_itmno = @ITMNO
	
END


GO
GRANT EXECUTE ON [dbo].[SP_SELECT_CHECK_ASST_FOR_PC] TO [ERPUSER] AS [dbo]
GO
