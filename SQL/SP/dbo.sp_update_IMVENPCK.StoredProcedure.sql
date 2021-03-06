/****** Object:  StoredProcedure [dbo].[sp_update_IMVENPCK]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMVENPCK]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMVENPCK]    Script Date: 09/29/2017 11:53:54 ******/
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
17 July 2003	Allan Yuen		For Merge Porject, disable company code
*/

/************************************************************************
Author:		Kenny Chan
Date:		20th September, 2001
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_update_IMVENPCK]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ivp_cocde nvarchar(6) ,
@ivp_itmno nvarchar(20) ,
@ivp_pckseq int,
@ivp_venno nvarchar(6),
@ivp_relatn nvarchar(4),
@ivp_updusr nvarchar(30)
                                               
---------------------------------------------- 
 
AS

Update IMVENPCK
-----------------------------
SET ivp_pckseq=@ivp_pckseq,
ivp_venno=@ivp_venno,
ivp_relatn = @ivp_relatn,
ivp_updusr=@ivp_updusr,
ivp_upddat=getdate()                                 
--------------------------------- 

 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- ivp_cocde = @ivp_cocde and
 ivp_itmno = @ivp_itmno and 
ivp_pckseq = @ivp_pckseq and
ivp_venno = @ivp_venno
                           
-------------------------- 

                                                           
----------------------------------------------------------










GO
GRANT EXECUTE ON [dbo].[sp_update_IMVENPCK] TO [ERPUSER] AS [dbo]
GO
