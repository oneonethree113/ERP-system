/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMCTYINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_IMCTYINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMCTYINF]    Script Date: 09/29/2017 11:53:53 ******/
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

/************************************************************************
Author:		Kenny Chan
Date:		24th September, 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_physical_delete_IMCTYINF] 

@ici_cocde	 nvarchar(6),
@ici_itmno 	nvarchar(20),
@ici_ctyseq	int

AS

delete from IMCTYINF
where 	
--ici_cocde = @ici_cocde and
ici_itmno = @ici_itmno and
ici_ctyseq = @ici_ctyseq









GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_IMCTYINF] TO [ERPUSER] AS [dbo]
GO
