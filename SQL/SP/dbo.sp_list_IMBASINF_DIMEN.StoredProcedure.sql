/****** Object:  StoredProcedure [dbo].[sp_list_IMBASINF_DIMEN]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMBASINF_DIMEN]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMBASINF_DIMEN]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
*/


CREATE PROCEDURE [dbo].[sp_list_IMBASINF_DIMEN]

@ibi_cocde as nvarchar(6)

AS

BEGIN

select distinct 
	ibi_prdsizetyp + ' ' + 
	convert(nvarchar(20), ibi_prdsizeval) + ' ' + 
	(select ysi_dsc from sysetinf where ysi_typ = '27' and ysi_cde = ibi_prdsizeunt) as 'ibi_dimen' 
from IMBASINF 
order by ibi_dimen

END


GO
GRANT EXECUTE ON [dbo].[sp_list_IMBASINF_DIMEN] TO [ERPUSER] AS [dbo]
GO
