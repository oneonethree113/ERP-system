/****** Object:  StoredProcedure [dbo].[sp_select_SYCONFTR_SC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCONFTR_SC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCONFTR_SC]    Script Date: 09/29/2017 11:53:54 ******/
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

/************************************************************************
Author:		Kenny Chan
Date:		16th fEB, 2002
Description:	Select data From SYCONFTR
Parameter:	1. Company
		2.Base Unit
		3.Convert Unit
************************************************************************/
CREATE PROCEDURE [dbo].[sp_select_SYCONFTR_SC]

@ycf_cocde	nvarchar(6) = ' ',
@ycf_code1	nvarchar(6),
@ycf_code2	nvarchar(6)
AS


begin
Select 
ycf_cocde,
ycf_code1,
ycf_dsc1,
ycf_code2,
ycf_dsc2,
ycf_oper,
ycf_value,
ycf_systyp,
ycf_creusr,
ycf_updusr,
ycf_credat,
ycf_upddat,
ycf_timstp 

from SYCONFTR

where 
--ycf_cocde = @ycf_cocde and
ycf_cocde = ' ' and
ycf_code1 = @ycf_code1 and
ycf_code2 = @ycf_code2



end






GO
GRANT EXECUTE ON [dbo].[sp_select_SYCONFTR_SC] TO [ERPUSER] AS [dbo]
GO
