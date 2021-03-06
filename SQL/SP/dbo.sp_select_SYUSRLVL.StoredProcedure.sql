/****** Object:  StoredProcedure [dbo].[sp_select_SYUSRLVL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYUSRLVL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYUSRLVL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO













/************************************************************************
Author:		Joe Yim
Date:		15th April, 2010
Description:	Select data From SYUSRLVL

************************************************************************/
CREATE           procedure [dbo].[sp_select_SYUSRLVL]
                                                                                                                                                                                                                                                                 
@yuc_cocde	nvarchar(6)  = ' ',
@yuc_cogrp	nvarchar(6),
@yuc_doctyp	nvarchar(2)
 
AS

begin

Select	yul_lvl,
	yul_desc,
	yuc_doctyp,
	yuc_creusr,
	yuc_updusr,
	yuc_credat,
	yuc_upddat,
	cast(yuc_timstp as int) as yuc_timstp
from  SYUSRCTRL
left join  SYUSRLVL on  yuc_lvl = yul_lvl and yuc_cogrp = yul_cogrp
where yuc_doctyp = @yuc_doctyp and yuc_cogrp = @yuc_cogrp
order by yul_lvl
end








GO
GRANT EXECUTE ON [dbo].[sp_select_SYUSRLVL] TO [ERPUSER] AS [dbo]
GO
