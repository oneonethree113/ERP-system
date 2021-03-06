/****** Object:  StoredProcedure [dbo].[sp_select_CUSHPINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUSHPINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUSHPINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Kenny Chan
Date:		20th DEC, 2001
Description:	Select data From CUSHPINF
Parameter:	1. Company
		2. CUSTOMER NO.
***********************************************************************
11 Jul 2003	Lewis To		Ignor Company code to handle multi company
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_CUSHPINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@csi_cocde nvarchar(6) ,
@csi_cusno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS


begin
 Select 
csi_cocde,
csi_cusno,
csi_csetyp,
csi_cseseq,
csi_csenam,
csi_cseacc,
csi_csedsc,
csi_cseadr,
csi_csestt,
csi_csecty,
csi_csepst,
csi_csectp,
csi_csetil,
csi_csephn,
csi_csefax,
csi_cseeml,
csi_csermk,
csi_csedef,
csi_cseinr,
csi_creusr,
csi_updusr,
csi_credat,
csi_upddat,
cast(csi_timstp as int) as 'csi_timstp'
from CUSHPINF
where
--csi_cocde = @csi_cocde and
csi_cusno =@csi_cusno and
csi_csedef = 'Y'


---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_select_CUSHPINF] TO [ERPUSER] AS [dbo]
GO
