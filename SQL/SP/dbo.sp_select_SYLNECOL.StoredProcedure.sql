/****** Object:  StoredProcedure [dbo].[sp_select_SYLNECOL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYLNECOL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYLNECOL]    Script Date: 09/29/2017 11:53:54 ******/
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

/*
 Samuel
*/

CREATE PROCEDURE [dbo].[sp_select_SYLNECOL] 

@ylc_cocde 	nvarchar(6) = ' ',
@ylc_lnecde	nvarchar(12)
AS

declare @ylc_timstp int

--Set  @ylc_timstp = (Select max(cast(ylc_timstp as int)) from sylnecol where ylc_cocde = @ylc_cocde and ylc_lnecde = @ylc_lnecde)
Set  @ylc_timstp = (Select max(cast(ylc_timstp as int)) from sylnecol where ylc_cocde = ' ' and ylc_lnecde = @ylc_lnecde)

begin

Select 
ylc_creusr as 'ylc_status',
ylc_cocde,
ylc_lnecde,
ylc_colcde,
ylc_coldsc,
ylc_prmstd,
ylc_creusr,
ylc_updusr,
ylc_credat,
ylc_upddat,
@ylc_timstp as ylc_timstp

 from SYLNECOL

--where ylc_cocde = @ylc_cocde
where ylc_cocde = ' ' 
and    ylc_lnecde = @ylc_lnecde

order by ylc_colcde
end




GO
GRANT EXECUTE ON [dbo].[sp_select_SYLNECOL] TO [ERPUSER] AS [dbo]
GO
