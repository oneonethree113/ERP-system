/****** Object:  StoredProcedure [dbo].[sp_select_SYCATCDE_level]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCATCDE_level]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCATCDE_level]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
ALTER  Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		For Merge Porject
2004/09/15	Lester Wu		Return MOA
*/

/*'************************************
     S A M U E L

*/
--sp_select_SYCATCDE_level 'UCPP','#'
CREATE PROCEDURE [dbo].[sp_select_SYCATCDE_level] 

@ycc_cocde	nvarchar(6) = ' ',
@ycc_level		nvarchar(2)

AS

declare @ycc_timstp int

--Set  @ycc_timstp = (Select max(cast(ycc_timstp as int)) from sycatcde where ycc_cocde = @ycc_cocde and ycc_level = @ycc_level )
Set  @ycc_timstp = (Select max(cast(ycc_timstp as int)) from sycatcde where ycc_cocde = ' ' and ycc_level = @ycc_level )

begin
Select 
ycc_creusr as 'ycc_status',
ycc_cocde,
ycc_level,
ycc_catcde,
ycc_catdsc,
ycc_creusr,
ycc_updusr,
ycc_credat,
ycc_upddat,
@ycc_timstp as ycc_timstp
--Lester Wu 2004/09/16 retrun MOA and Create User
,ycc_fflag
,ycc_moq
,ycc_moa
,ycc_creusr as 'ycc_creusr_ori'

-------------------------------------
from SYCATCDE

where 
--ycc_cocde = @ycc_cocde and 
ycc_cocde = ' ' and 
ycc_level = @ycc_level 

order by ycc_catcde

end




GO
GRANT EXECUTE ON [dbo].[sp_select_SYCATCDE_level] TO [ERPUSER] AS [dbo]
GO
