/****** Object:  StoredProcedure [dbo].[sp_select_SYCOMINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCOMINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCOMINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/************************************************************************
Author:		PIC
Date:		
Description:	List data From SYCOMINF
Parameter:	1. Company Code range    
************************************************************************
10 Sept 2003	Allan Yuen	Add Nolock to speed up the process
*/

------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SYCOMINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yco_cocde nvarchar(6) 

---------------------------------------------- 
 
AS

begin
 Select 
yco_cocde,
yco_addr,
yco_mfystr,
yco_curyer,
yco_systim,
yco_irday,
yco_ir2day,
yco_moq,
yco_curcde,
yco_moa,
yco_bscrat,
yco_datfmt,
yco_ivmth,
yco_commth,
yco_prctle,
yco_expday,
yco_datrme1,
yco_datrme2,
yco_datrme3,
yco_datrme4,
yco_year,
yco_acinv,
yco_acsam,
yco_acinvadj,
yco_acsamtrm,
yco_creusr,
yco_updusr,
yco_credat,
yco_upddat,
cast(yco_timstp as int) as yco_timstp
--year(getdate()) as yco_updusr
                                  
--------------------------------- 
 from SYCOMINF (nolock)
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
 yco_cocde = @yco_cocde
                           
-------------------------- 

                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_select_SYCOMINF] TO [ERPUSER] AS [dbo]
GO
