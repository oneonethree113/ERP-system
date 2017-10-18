/****** Object:  StoredProcedure [dbo].[sp_insert_SYUSRRIGHT_SUPER]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYUSRRIGHT_SUPER]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYUSRRIGHT_SUPER]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












/************************************************************************
Author:		Joe Yim
Date:		4th June, 2010
Description:	Insert data to SYUSRRIGHT

************************************************************************/

CREATE      PROCEDURE [dbo].[sp_insert_SYUSRRIGHT_SUPER] 
--------------------------------------------------------------------------------------------------------------------------------------
@yur_cocde	nvarchar(6) = ' ',
@yur_usrid	nvarchar(30),
@yur_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYUSRRIGHT

(
yur_cogrp,
yur_usrid,
yur_doctyp,
yur_lvl,
yur_para,
yur_desc,
yur_creusr,
yur_updusr,
yur_credat,
yur_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
Select	distinct yco_cogrp,
	yup_usrid,
	yud_doctyp,
	0,
	'S',
	'Super User',
	@yur_updusr,
	@yur_updusr,
	getdate(),
	getdate()
from syusrprf
left join
(
	select yuc_usrid, yuc_usrgrp, yco_cogrp
	from symusrco
	left join
	sycominf
	on yuc_cocde = yco_cocde
	group by  yuc_usrid, yuc_usrgrp, yco_cogrp
) as a on yup_usrid = yuc_usrid
left join 
(
	select yug_usrgrp, yug_grpdsc from syusrgrp
	group by yug_usrgrp, yug_grpdsc
) as b on yuc_usrgrp = yug_usrgrp
left join  syusrdoc
on yco_cogrp = yud_cogrp  
left join syusrctrl
on yud_cogrp = yuc_cogrp and yud_doctyp = yuc_doctyp
where yup_usrid = @yur_usrid and yuc_lvl = 0  and yuc_usrgrp not like 'SAL%'















GO
GRANT EXECUTE ON [dbo].[sp_insert_SYUSRRIGHT_SUPER] TO [ERPUSER] AS [dbo]
GO
