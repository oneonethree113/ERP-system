/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUMCAMRK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUMCAMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUMCAMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
=========================================================
Program ID	: sp_physical_delete_CUMCAMRK
Description   	: Physical_delete Data to  Customer Item Category Markup Table 
Programmer  	: Lewis To
Create Date   	: 18 Jun 2003
Last Modified  	: 
Table Read(s) 	:CUMCAMRK
Table Write(s) 	:CUMCAMRK
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/

Create Procedure [dbo].[sp_physical_delete_CUMCAMRK]

@ccm_cocde	varchar(6),
@ccm_cusno	varchar(6),
@ccm_ventyp	varchar(6),
@ccm_cat		varchar(20),
@ccm_effdat	DATETIME
as
if @ccm_ventyp = 'A'


begin



delete CUMCAMRK 
where ccm_cusno = @ccm_cusno 



end
else
begin



delete CUMCAMRK 
where ccm_cusno = @ccm_cusno and ccm_cat = @ccm_cat and ccm_ventyp = @ccm_ventyp --and
--ccm_cat = @ccm_cat and ccm_effdat = @ccm_effdat



end




GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUMCAMRK] TO [ERPUSER] AS [dbo]
GO
