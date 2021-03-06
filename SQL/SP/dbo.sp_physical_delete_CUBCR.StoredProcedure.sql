/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUBCR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUBCR]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUBCR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/*=========================================================
Program ID	: 	sp_physical_delete_CUBCR
Description   	: 	Delete Record From Customer Risk and Credit 
Programmer  	: 	Lewis To	
Create Date   	: 	16 Jul 2003
Last Modified  	: 
Table Read(s) 	:	
Table Write(s) 	:	CUBCR
=========================================================
 Modification History                                    
=========================================================
=========================================================     
*/
CREATE PROCEDURE [dbo].[sp_physical_delete_CUBCR] 

@cbc_cocde		varchar(6) ,
@cbc_cusno		varchar(6)  

as

delete from CUBCR 
where   cbc_cusno = @cbc_cusno 



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUBCR] TO [ERPUSER] AS [dbo]
GO
