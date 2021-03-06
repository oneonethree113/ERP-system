/****** Object:  StoredProcedure [dbo].[sp_list_SHSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Johnson Lai
Date:		19th Jan, 2002
Description:	Select data From SHSHPMRK
Parameter:	1. Company
		2. Ship no
		3. SC no
************************************************************************/
------------------------------------------------- 
CREATE    procedure [dbo].[sp_list_SHSHPMRK]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hsm_cocde nvarchar(6) ,
@hsm_shpno nvarchar(20)
---------------------------------------------- 
 
AS
begin
Select 
hsm_cocde,
hsm_shpno,
hsm_invno,
hsm_ordno,
hsm_shptyp,

hsm_imgnam,
hsm_imgpth,

hsm_engdsc,
hsm_engrmk,
hsm_creusr
--------------------------------- 
from SHSHPMRK
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
hsm_cocde = @hsm_cocde and
hsm_shpno = @hsm_shpno
--and  Rtrim(ltrim(hsm_invno)) <> ''
--and Rtrim(ltrim(hsm_ordno)) <> ''
---------------------------------------------------------- 
--order by hsm_invno,hsm_ordno


end








GO
GRANT EXECUTE ON [dbo].[sp_list_SHSHPMRK] TO [ERPUSER] AS [dbo]
GO
