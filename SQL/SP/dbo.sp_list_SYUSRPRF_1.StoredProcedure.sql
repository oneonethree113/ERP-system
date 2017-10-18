/****** Object:  StoredProcedure [dbo].[sp_list_SYUSRPRF_1]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYUSRPRF_1]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYUSRPRF_1]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sp_list_SYUSRPRF_1] 

@cocde nvarchar(6)

AS

select
yup_cocde, 
yup_usrid ,
yup_usrnam ,
yup_paswrd ,
yup_paswrd1 ,
yup_paswrd2 ,
yup_expdat ,
yup_usrgrp ,
yup_usrank ,
yup_supid ,
yup_flgcst ,
yup_flgrel ,
yup_mailad ,
yup_creusr ,
yup_updusr ,
yup_credat ,
yup_upddat,
cast(yup_timstp as int) as 'yup_timstp',
yup_accexp,
yup_displaymode
from SYUSRPRF
--where yup_cocde = @cocde
order by yup_usrid






GO
GRANT EXECUTE ON [dbo].[sp_list_SYUSRPRF_1] TO [ERPUSER] AS [dbo]
GO
