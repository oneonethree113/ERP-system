/****** Object:  StoredProcedure [dbo].[sp_select_SYCATCDE]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCATCDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCATCDE]    Script Date: 09/29/2017 11:53:54 ******/
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

/*'************************************
     S A M U E L

*/
CREATE PROCEDURE [dbo].[sp_select_SYCATCDE] 

@ycc_cocde	nvarchar(6) = ' ',
@ycc_level	nvarchar(2),
@ycc_catcde	nvarchar(20)
AS

declare @ycc_timstp int

--Set  @ycc_timstp = (Select max(cast(ycc_timstp as int)) from sycatcde where ycc_cocde = @ycc_cocde and ycc_level = @ycc_level and ycc_catcde = @ycc_catcde)
Set  @ycc_timstp = (Select max(cast(ycc_timstp as int)) from sycatcde where ycc_cocde = ' ' and ycc_level = @ycc_level and ycc_catcde = @ycc_catcde)

begin
Select 
ycc_creusr as 'ycc_status',
ycc_cocde,
ycc_level,
ycc_catcde,
ycc_creusr,
ycc_updusr,
ycc_credat,
ycc_upddat,
@ycc_timstp as ycc_timstp

from SYCATCDE

where 
--ycc_cocde = @ycc_cocde and 
ycc_cocde = ' ' and 
ycc_level = @ycc_level and 
ycc_catcde = @ycc_catcde

order by ycc_level, ycc_catcde

end









GO
GRANT EXECUTE ON [dbo].[sp_select_SYCATCDE] TO [ERPUSER] AS [dbo]
GO
