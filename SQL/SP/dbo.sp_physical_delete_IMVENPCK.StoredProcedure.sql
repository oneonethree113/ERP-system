/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMVENPCK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_IMVENPCK]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMVENPCK]    Script Date: 09/29/2017 11:53:53 ******/
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
Date:		20th September, 2001
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_physical_delete_IMVENPCK]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ivp_cocde nvarchar(6) ,
@ivp_itmno nvarchar(20),
@ivp_venno nvarchar(6),
@ivp_pckseq int

                                               
---------------------------------------------- 
 
AS
begin

Delete from IMVENPCK
-----------------------------
Where
--ivp_cocde = @ivp_cocde and
ivp_itmno = @ivp_itmno and
ivp_venno = @ivp_venno and
ivp_pckseq= @ivp_pckseq 


---------------------------------------------------------- 
end








GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_IMVENPCK] TO [ERPUSER] AS [dbo]
GO
