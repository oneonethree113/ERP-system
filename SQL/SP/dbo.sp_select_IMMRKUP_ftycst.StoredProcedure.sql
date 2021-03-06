/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUP_ftycst]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMRKUP_ftycst]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUP_ftycst]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Frankie Cheung
Date:		12th July, 2010
Description:	Select Factory Cost From IMMRKUP
Parameter:	
************************************************************************

*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMMRKUP_ftycst]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_cocde 	nvarchar(6) ,
@imu_itmno 	nvarchar(20),
@imu_pckunt 	nvarchar(6),
@imu_inrqty 	int,
@imu_mtrqty 	int,
@dummy	nvarchar(1)

---------------------------------------------- 
 
AS

select imu_ftycst, imu_curcde from IMMRKUP where 
imu_itmno = @imu_itmno  and
imu_pckunt = @imu_pckunt and
imu_inrqty = @imu_inrqty and
imu_mtrqty= @imu_mtrqty and 
imu_ventyp = 'D'








GO
GRANT EXECUTE ON [dbo].[sp_select_IMMRKUP_ftycst] TO [ERPUSER] AS [dbo]
GO
