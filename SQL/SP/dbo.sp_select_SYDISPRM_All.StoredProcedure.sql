/****** Object:  StoredProcedure [dbo].[sp_select_SYDISPRM_All]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYDISPRM_All]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYDISPRM_All]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Kenny Chan
Date:		13th September, 2001
Description:	Select data From SYDISPRM
Parameter:	1. Company
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SYDISPRM_All]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ydp_cocde nvarchar(6) = ' '

---------------------------------------------- 
 
AS

begin
 Select 
ydp_cocde,
ydp_type,
ydp_cde,
ydp_dsc,
ydp_creusr,
ydp_updusr,
ydp_credat,
ydp_upddat,
cast(ydp_timstp as int) as 'ydp_timstp '
--------------------------------- 
 from SYDISPRM
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- ydp_cocde = @ydp_cocde  and
ydp_cocde = ' ' and
 ydp_sts = 'A'

order by 
ydp_cocde,
ydp_type,
ydp_cde
-------------------------- 

                                                           
---------------------------------------------------------- 
end






GO
GRANT EXECUTE ON [dbo].[sp_select_SYDISPRM_All] TO [ERPUSER] AS [dbo]
GO
