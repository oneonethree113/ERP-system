/****** Object:  StoredProcedure [dbo].[sp_insert_SYMCATCDE]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYMCATCDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYMCATCDE]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Checked by Allan Yuen at 28/07/2003  
  
/*  
=========================================================  
Program ID :   
Description    :   
Programmer   :   
ALTER  Date    :   
Last Modified   : 2005-08-11  
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================       
*/  
  
  
CREATE PROCEDURE [dbo].[sp_insert_SYMCATCDE]   
@ymc_cocde nvarchar(6) = ' ',  
@ymc_type char(1),  
@ymc_catcde nvarchar(20),  
@ymc_catdsc nvarchar(200),  
@ymc_catdis nvarchar(200),  
@ymc_cloth char(1),  
@ymc_updusr nvarchar(30)  

AS  

INSERT INTO  SYMCATCDE  
(  
ymc_cocde,  
ymc_type,  
ymc_catcde,  
ymc_catdsc,  
ymc_catdis,  
ymc_cloth,  
ymc_creusr,  
ymc_updusr,  
ymc_credat,  
ymc_upddat  
)  
values  
(  
' ',  
@ymc_type,  
@ymc_catcde,  
@ymc_catdsc,  
@ymc_catdis,  
@ymc_cloth,  
@ymc_updusr,  
@ymc_updusr,  
getdate(),  
getdate()  
)  





GO
GRANT EXECUTE ON [dbo].[sp_insert_SYMCATCDE] TO [ERPUSER] AS [dbo]
GO
