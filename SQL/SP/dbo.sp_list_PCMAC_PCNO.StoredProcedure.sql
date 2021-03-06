/****** Object:  StoredProcedure [dbo].[sp_list_PCMAC_PCNO]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_PCMAC_PCNO]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_PCMAC_PCNO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/*
=========================================================
Program ID	: sp_lsit_PCMAC_PCNO
Description   	: Retrive Profit Centre list  for Profit Account Interface table 
Programmer  	: Lester Wu
ALTER  Date   	: 27 Nov, 2003
Last Modified  	: 
Table Read(s) 	: PCMAC
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/


CREATE PROCEDURE [dbo].[sp_list_PCMAC_PCNO]
@COCDE NVARCHAR(6)
AS


SELECT DISTINCT PMA_PCNO 
FROM PCMAC
ORDER BY PMA_PCNO





GO
GRANT EXECUTE ON [dbo].[sp_list_PCMAC_PCNO] TO [ERPUSER] AS [dbo]
GO
