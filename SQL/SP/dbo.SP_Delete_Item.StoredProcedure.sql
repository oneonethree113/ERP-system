/****** Object:  StoredProcedure [dbo].[SP_Delete_Item]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[SP_Delete_Item]
GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Item]    Script Date: 09/29/2017 11:53:53 ******/
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
17 July 2003	Allan Yuen		For Merge Porject
*/



CREATE PROCEDURE [dbo].[SP_Delete_Item] 

@cocde nvarchar(6) = ' ',
@itmno nvarchar(20)

AS

--Delete IMBASINF where ibi_cocde = @cocde and ibi_itmno = @itmno
--Delete  IMPCKINF where ipi_cocde = @cocde and ipi_itmno = @itmno
--Delete  IMVENPCK where ivp_cocde = @cocde and ivp_itmno = @itmno
--Delete  IMMRKUP where imu_cocde = @cocde and imu_itmno = @itmno
--Delete  IMBOMASS where iba_cocde = @cocde and iba_itmno = @itmno
--Delete  IMCOLINF where icf_cocde = @cocde and icf_itmno = @itmno
--Delete  IMVENINF where ivi_cocde = @cocde and ivi_itmno = @itmno
--Delete  IMMATBKD where ibm_cocde = @cocde and ibm_itmno = @itmno
--Delete  IMCTYINF where ici_cocde = @cocde and ici_itmno = @itmno
Delete IMBASINF where ibi_itmno = @itmno
Delete  IMPCKINF where ipi_itmno = @itmno
Delete  IMVENPCK where ivp_itmno = @itmno
Delete  IMMRKUP where imu_itmno = @itmno
Delete  IMBOMASS where iba_itmno = @itmno
Delete  IMCOLINF where icf_itmno = @itmno
Delete  IMVENINF where ivi_itmno = @itmno
Delete  IMMATBKD where ibm_itmno = @itmno
Delete  IMCTYINF where ici_itmno = @itmno





GO
GRANT EXECUTE ON [dbo].[SP_Delete_Item] TO [ERPUSER] AS [dbo]
GO
