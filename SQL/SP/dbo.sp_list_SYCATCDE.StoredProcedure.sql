/****** Object:  StoredProcedure [dbo].[sp_list_SYCATCDE]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYCATCDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYCATCDE]    Script Date: 09/29/2017 11:53:53 ******/
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



CREATE PROCEDURE [dbo].[sp_list_SYCATCDE] 

@ycc_cocde 	nvarchar(6) = ' '
AS

declare @ycc_timstp int

Set  @ycc_timstp = (
			Select 
				max(cast(ycc_timstp as int)) 
			from 
				sycatcde 
			where 
				--ycc_cocde = @ycc_cocde
				ycc_cocde = ' '
		   )
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
--where ycc_cocde = @ycc_cocde
where ycc_cocde = ' '







GO
GRANT EXECUTE ON [dbo].[sp_list_SYCATCDE] TO [ERPUSER] AS [dbo]
GO
