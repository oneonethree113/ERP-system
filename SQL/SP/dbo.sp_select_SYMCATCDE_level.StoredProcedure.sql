/****** Object:  StoredProcedure [dbo].[sp_select_SYMCATCDE_level]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYMCATCDE_level]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYMCATCDE_level]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
  
  
CREATE PROCEDURE [dbo].[sp_select_SYMCATCDE_level]   
  
@ymc_cocde nvarchar(6) = ' ',  
@ymc_type char(1)  
  
AS  
  
declare @ymc_timstp int  
  
--Set  @ymc_timstp = (Select max(cast(ymc_timstp as int)) from SYMCATCDE where ymc_cocde = @ymc_cocde and ymc_level = @ymc_level )  
Set  @ymc_timstp = (Select max(cast(ymc_timstp as int)) from SYMCATCDE where ymc_cocde = ' ' and ymc_type = @ymc_type )  
  
begin  
Select   
ymc_creusr as 'ymc_status',  
ymc_cocde,  
ymc_type,  
ymc_catcde,  
ymc_catdsc,  
ymc_catdis,
ymc_cloth,
ymc_creusr,  
ymc_updusr,  
ymc_credat,  
ymc_upddat,  
@ymc_timstp as ymc_timstp  
,ymc_creusr as 'ymc_creusr_ori'  
  
-------------------------------------  
from SYMCATCDE  
  
where   
ymc_cocde = ' ' and   
ymc_type = @ymc_type  
  
order by ymc_catcde  
  
end  
  
  
  




GO
GRANT EXECUTE ON [dbo].[sp_select_SYMCATCDE_level] TO [ERPUSER] AS [dbo]
GO
