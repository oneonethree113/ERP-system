/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUP_BOMASS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMRKUP_BOMASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUP_BOMASS]    Script Date: 09/29/2017 11:53:53 ******/
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
20030715	Allan Yuen		Modify For Merge Porject
20100825	Marco Chan		New BOM Calculation
*/


/************************************************************************
Author:		Kenny Chan
Date:		13th September, 2001
Description:	Select data From IMMRKUP
Parameter:	1. Company
		2. Item No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMMRKUP_BOMASS]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_cocde nvarchar(6) ,
@imu_itmno nvarchar(20) ,
@imu_pckunt NVARCHAR(6)
---------------------------------------------- 
 
AS


begin
 Select 
imu_itmno,
imu_typ,
cast(imu_pckunt as nvarchar(10) )+ ' / ' +
cast(imu_inrqty  as nvarchar(10) )+ ' / ' +
cast(imu_mtrqty as nvarchar(10) )+ ' / ' +
cast(imu_cft as nvarchar(20) )	    as 'imu_packing',
imu_curcde,
imu_ftycst,
imu_ftyprc,
imu_ttlcst,
imu_bcurcde,
imu_basprc,
imu_curcde as 'imu_Calcurcde',
imu_calftyprc,
imu_negprc,
imu_prctrm,
imu_creusr,
imu_updusr,
imu_credat,
imu_upddat
                                  
--------------------------------- 
 from IMMRKUP
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- imu_cocde = @imu_cocde and
 imu_itmno = @imu_itmno and
 imu_pckunt = @imu_pckunt and
 imu_ventyp =  'D'

-------------------------- 

                                                           
---------------------------------------------------------- 
end






GO
GRANT EXECUTE ON [dbo].[sp_select_IMMRKUP_BOMASS] TO [ERPUSER] AS [dbo]
GO
