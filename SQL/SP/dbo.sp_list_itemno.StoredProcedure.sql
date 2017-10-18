/****** Object:  StoredProcedure [dbo].[sp_list_itemno]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_itemno]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_itemno]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject
*/


CREATE PROCEDURE [dbo].[sp_list_itemno]

@cocde as nvarchar(6)

as

select 
	ibi_itmno, 
	ibi_lnecde, 
	ibi_credat
from 
	IMBASINF
where 
--	ibi_cocde = @cocde and
	ibi_credat > '2002-03-12 0:00' and
	left(ibi_itmno,2) = '02'
order 
	by ibi_itmno





GO
GRANT EXECUTE ON [dbo].[sp_list_itemno] TO [ERPUSER] AS [dbo]
GO
