/****** Object:  StoredProcedure [dbo].[sp_select_IMSALBKGH]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMSALBKGH]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMSALBKGH]    Script Date: 09/29/2017 11:53:53 ******/
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
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject, disable company code
*/

/************************************************************************
Author:		Kenny Chan
Date:		28th September, 2001
************************************************************************/
------------------------------------------------- 
CREATE PROCEDURE [dbo].[sp_select_IMSALBKGH] 

@isb_cocde  nvarchar(6),
@isb_itmno  nvarchar( 20)


AS

SELECT 
isb_cocde,
isb_itmno,
isb_yymm,
isb_mtdbok,
isb_mtdsal,
isb_mtdpur,
isb_creusr,
isb_updusr,
isb_credat,
isb_upddat,
cast(isb_timstp as int) as 'is_timstp'
from IMSALBKGH
where 
--isb_cocde = @isb_cocde and
isb_itmno = @isb_itmno






GO
GRANT EXECUTE ON [dbo].[sp_select_IMSALBKGH] TO [ERPUSER] AS [dbo]
GO
