/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SYHRMCDE]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SYHRMCDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SYHRMCDE]    Script Date: 09/29/2017 11:53:53 ******/
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
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		For Merge Porject
*/

/*
Samuel
*/
CREATE PROCEDURE [dbo].[sp_physical_delete_SYHRMCDE] 


@yhc_cocde	 nvarchar(6) = ' ',
@yhc_tarzon 	nvarchar(1),
@yhc_hrmcde	nvarchar(12),
@yhc_usrid	nvarchar(30)
AS


delete from SYHRMCDE
--where 	yhc_cocde = @yhc_cocde
where 	yhc_cocde = ' '
and 	yhc_tarzon= @yhc_tarzon
and	yhc_hrmcde=@yhc_hrmcde










GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SYHRMCDE] TO [ERPUSER] AS [dbo]
GO
