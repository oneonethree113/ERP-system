/****** Object:  StoredProcedure [dbo].[sp_select_SYUSRPRF_1]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYUSRPRF_1]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYUSRPRF_1]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/*	Author : Tommy Ho	
=========================================================
Program ID	: 	sp_select_SYUSRPRF_1
Description   	: Get User Profile and rights  by Multi Comapny
Programmer  	: 
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
3 Jul 2003		Lewis To		Change get user rights from SYMUSRCO and 
				 get all compnay info for the user               
=========================================================  
*/
CREATE PROCEDURE [dbo].[sp_select_SYUSRPRF_1] 

@cocde nvarchar(6),
@usrid nvarchar(30)

AS

select 
--yup_cocde , 	-- change define by SYMUSRCO
yuc_cocde,
vw.yup_usrid ,
vw.yup_usrnam ,
vw.yup_paswrd ,
vw.yup_paswrd1 ,
vw.yup_paswrd2 ,
vw.yup_expdat ,
--yup_usrgrp ,\
--yup_usrank , \
--yup_supid ,    }	change to get from SYMUSRCO
--yup_flgcst ,    /
--yup_flgrel ,   /
yuc_usrgrp ,    
yuc_usrank ,
yuc_supid ,
yuc_flgcst ,
yuc_flgcstext ,
yuc_flgrel ,
yuc_flgdef,
vw.yup_mailad ,
vw.yup_creusr ,
vw.yup_updusr ,
vw.yup_credat ,
vw.yup_upddat,
cast(vw.yup_timstp as int) as 'yup_timstp',
isnull(ysr_saltem,'') as 'ysr_saltem',
vw.yup_accexp

 from (select top 1 yup_cocde,			--\
	yup_usrid ,				 --\	
	yup_usrnam ,			  --\
	yup_paswrd ,			   --\
	yup_paswrd1 ,			    --} select one user profile detail only 
	yup_paswrd2 ,			   --/
	yup_expdat ,			  --/
	yup_mailad ,			 --/
	yup_creusr ,			--/
	yup_updusr ,		                 --/
	yup_credat ,		                --/
	yup_upddat,		               --/
	cast(yup_timstp as int) as 'yup_timstp',        --/
	yup_accexp		             --/
	from syusrprf where yup_usrid = @usrid) vw
left join SYMUSRCO  on  yuc_usrid = @usrid 
left join  SYSALREP on --ysr_cocde = yuc_cocde and 
		ysr_code = yuc_usrid 
where 	--yup_cocde = @cocde and 
	yuc_usrid = @usrid
order by    yuc_flgdef desc,  yuc_cocde





GO
GRANT EXECUTE ON [dbo].[sp_select_SYUSRPRF_1] TO [ERPUSER] AS [dbo]
GO
