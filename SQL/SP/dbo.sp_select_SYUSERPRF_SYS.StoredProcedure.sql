/****** Object:  StoredProcedure [dbo].[sp_select_SYUSERPRF_SYS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYUSERPRF_SYS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYUSERPRF_SYS]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/*
Samuel Chan 
Date : 17/10/2001
*/

CREATE PROCEDURE [dbo].[sp_select_SYUSERPRF_SYS] 

@yup_cocde	nvarchar(6)

AS

select 
distinct 
yup_cocde ,
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
cast(yup_timstp as int) as 'yup_timstp'
from syusrprf
	LEFT JOIN SYMUSRCO ON YUC_USRID = yup_usrid 
where 	
--yup_cocde = @yup_cocde and
(yuc_usrgrp like 'SAL%' or yuc_usrgrp like 'MSAL%')

--yup_usrgrp like 'SAL%'

order by
	yup_usrid



GO
GRANT EXECUTE ON [dbo].[sp_select_SYUSERPRF_SYS] TO [ERPUSER] AS [dbo]
GO
