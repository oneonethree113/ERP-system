/****** Object:  StoredProcedure [dbo].[sp_select_IMM00015_IMBOMEXDAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00015_IMBOMEXDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00015_IMBOMEXDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=================================================================
Program ID	: sp_select_IMM00015_IMBOMEXDAT
Description	: Retrieve IMBOMEXDAT Data from IM
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-12-04 	David Yue		SP Created
=================================================================
*/


CREATE PROCEDURE [dbo].[sp_select_IMM00015_IMBOMEXDAT] 

@itmno	nvarchar(30)

AS

select	iba_itmno,
	iba_assitm,
	iba_colcde,
	ycf_dsc1 as 'iba_pckunt',
	cast(ycf_value as int) as 'iba_conftr',
	iba_bomqty
from	IMBOMASS (nolock)
	join SYCONFTR (nolock) on
		ycf_systyp = 'Y' and
		ycf_code1 = iba_pckunt and
		ycf_code2 = 'PC'
where	iba_itmno = @itmno and
	iba_typ = 'BOM'


GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00015_IMBOMEXDAT] TO [ERPUSER] AS [dbo]
GO
