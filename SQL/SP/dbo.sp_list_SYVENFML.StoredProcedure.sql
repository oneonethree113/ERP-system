/****** Object:  StoredProcedure [dbo].[sp_list_SYVENFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYVENFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYVENFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 28/07/2003





/************************************************************************
Author:		Kenny Chan
Date:		24-102001
Description:	List data From SYVENFML
Parameter:	1. Company Code range    
************************************************************************/


CREATE procedure [dbo].[sp_list_SYVENFML]
                                                                                                                                                                                                                                                               
@yvf_cocde nvarchar(6)  = ' '
AS

Select 

yvf_cocde,
yvf_venno,
CAST(yvf_fmlopt AS NVARCHAR(10)) + ' - ' + cast(yfi_fml as Nvarchar(300)) as 'yvf_mkpopt',
yvf_def,
yvf_effdat,
yvf_creusr,
yvf_updusr,
yvf_credat,
yvf_upddat,
cast(yvf_timstp as int) as 'yvf_timstp',
isnull(yvf_catcde,'') as 'yvf_catcde',
isnull(yvf_matcde,'') as 'yvf_matcde'


 from SYVENFML
--left join SYFMLINF  on yvf_fmlopt = yfi_fmlopt and yfi_cocde = @yvf_cocde
left join SYFMLINF  on yvf_fmlopt = yfi_fmlopt and yfi_cocde = ' '
where
-- yvf_cocde = @yvf_cocde
yvf_cocde = ' '



GO
GRANT EXECUTE ON [dbo].[sp_list_SYVENFML] TO [ERPUSER] AS [dbo]
GO
