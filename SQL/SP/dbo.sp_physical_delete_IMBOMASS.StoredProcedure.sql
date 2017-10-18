/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMBOMASS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_IMBOMASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMBOMASS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 19 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030719	Allan Yuen	Modify For Merge Porject 
				(Disable company code)
*/




/************************************************************************
Author:		Kenny Chan
Date:		28th September, 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_physical_delete_IMBOMASS] 

@iba_cocde  	nvarchar(6),
@iba_itmno  	nvarchar(20),
@iba_assitm	nvarchar(20),
--@iba_pckseq  	int,
@iba_typ  	nvarchar(4),
@iba_colcde  	nvarchar(30)




AS

Delete IMBOMASS
where 
--iba_cocde = @iba_cocde and
iba_itmno = @iba_itmno and
iba_assitm = @iba_assitm and
--iba_pckseq = @iba_pckseq and 
iba_typ = @iba_typ and
iba_colcde = @iba_colcde




-----------------------------









GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_IMBOMASS] TO [ERPUSER] AS [dbo]
GO
