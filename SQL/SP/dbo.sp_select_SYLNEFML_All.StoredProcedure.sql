/****** Object:  StoredProcedure [dbo].[sp_select_SYLNEFML_All]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYLNEFML_All]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYLNEFML_All]    Script Date: 09/29/2017 11:53:54 ******/
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


CREATE PROCEDURE [dbo].[sp_select_SYLNEFML_All] 

@ylf_cocde 	nvarchar(6) = ' ',
@ylf_lnecde	nvarchar(12)
/*@ylf_fmlopt	int*/
AS

declare @ylf_timstp int

--Set  @ylf_timstp = (Select max(cast(ylf_timstp as int)) from sylnefml where ylf_cocde = @ylf_cocde and ylf_lnecde = @ylf_lnecde)
Set  @ylf_timstp = (Select max(cast(ylf_timstp as int)) from sylnefml where ylf_cocde = ' ' and ylf_lnecde = @ylf_lnecde)

begin

Select 
ylf_creusr as 'ylf_status',

ylf_cocde,
ylf_lnecde,
ylf_fmlopt,
yfi_prcfml,
yfi_fml,
ylf_creusr,
ylf_updusr,
ylf_credat,
ylf_upddat,
@ylf_timstp as 'ylf_timstp',
ylf_deffml

from SYLNEFML, SYFMLINF

--where ylf_cocde = @ylf_cocde
where ylf_cocde = ' '
and    ylf_lnecde = @ylf_lnecde
/*and    ylf_fmlopt = @ylf_fmlopt*/
and    ylf_cocde = yfi_cocde
and    ylf_fmlopt = yfi_fmlopt
			
order by ylf_lnecde, ylf_fmlopt

end








GO
GRANT EXECUTE ON [dbo].[sp_select_SYLNEFML_All] TO [ERPUSER] AS [dbo]
GO
