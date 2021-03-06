/****** Object:  StoredProcedure [dbo].[sp_select_IMVENPCKH]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMVENPCKH]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMVENPCKH]    Script Date: 09/29/2017 11:53:53 ******/
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
Date:		20th September, 2001
Description:	Select data From IMVENPCK
Parameter:	1. Company
		2. Item No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMVENPCKH]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ivp_cocde nvarchar(6) ,
@ivp_itmno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS


begin
 Select 
-----------------------------
ivp_cocde,
ivp_itmno,
ivp_pckseq,
ivp_venno,
ivp_relatn,
ivp_creusr,
ivp_updusr,
ivp_credat,
ivp_upddat,
cast(ivp_timstp as int) as ivp_timstp
                                  
--------------------------------- 
 from IMVENPCKH
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- ivp_cocde = @ivp_cocde and
 ivp_itmno = @ivp_itmno
                           
-------------------------- 

                                                           
---------------------------------------------------------- 
end







GO
GRANT EXECUTE ON [dbo].[sp_select_IMVENPCKH] TO [ERPUSER] AS [dbo]
GO
