/****** Object:  StoredProcedure [dbo].[sp_list_SYSCHCON]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYSCHCON]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYSCHCON]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai 
Date:		Apr 25, 2002
*************************************************************************
2005-08-25	Allan Yuen	Change @module from 2 to 5
*/

CREATE procedure [dbo].[sp_list_SYSCHCON]
                                                                                                                                                                                                                                                               
@cocde	nvarchar(8),
@module nvarchar(5) ,
@usr	nvarchar(30)

 AS
BEGIN
SELECT
*
from SYSCHCON

WHERE
--ssc_cocde = @cocde and
ssc_module = @module

ORDER BY 
ssc_module
END



GO
GRANT EXECUTE ON [dbo].[sp_list_SYSCHCON] TO [ERPUSER] AS [dbo]
GO
