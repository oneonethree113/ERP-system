/****** Object:  StoredProcedure [dbo].[sp_select_SYCONFTR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCONFTR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCONFTR]    Script Date: 09/29/2017 11:53:54 ******/
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
CREATE PROCEDURE [dbo].[sp_select_SYCONFTR]

@ycf_cocde	nvarchar(6) = ' '

AS

declare @ycf_timstp int

--Set  @ycf_timstp = (Select max(cast(ycf_timstp as int)) from syconftr where ycf_cocde = @ycf_cocde)
Set  @ycf_timstp = (Select max(cast(ycf_timstp as int)) from syconftr where ycf_cocde = ' ')

begin
Select 
ycf_creusr as 'ycf_status',
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
@ycf_timstp as ycf_timstp

from SYCONFTR

where 
--ycf_cocde = @ycf_cocde
ycf_cocde = ' '

order by ycf_code1

end








GO
GRANT EXECUTE ON [dbo].[sp_select_SYCONFTR] TO [ERPUSER] AS [dbo]
GO
