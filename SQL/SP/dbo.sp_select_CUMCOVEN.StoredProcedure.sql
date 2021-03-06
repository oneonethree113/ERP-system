/****** Object:  StoredProcedure [dbo].[sp_select_CUMCOVEN]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUMCOVEN]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUMCOVEN]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/*
=========================================================
Program ID	: sp_select_CUMCOVEN
Description   	: Select Data form Customer Vendor Company relationship Table 
Programmer  	: Lewis To
Create Date   	: 17 Jun 2003
Last Modified  	: 
Table Read(s) 	:CUMCOVEN
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/

CREATE Procedure [dbo].[sp_select_CUMCOVEN]

@running_cocde varchar(6),
@ccv_cusno varchar(6)

AS
begin
select 	'' as 'ccv_del',
	ccv_cusno,
	case ccv_ventyp when 'I' then 'INT'
		        when 'E' then 'EXT' 
		        when 'J' then 'JV' end
	as 'ccv_ventyp',
	ccv_cocde,
	yco_shtnam,
	ccv_vendef,
	ccv_effdat,
	ccv_creusr
from CUMCOVEN
left join sycominf on yco_cocde = ccv_cocde
where ccv_cusno = @ccv_cusno
order by ccv_vendef desc,  ccv_ventyp, ccv_cocde

end



GO
GRANT EXECUTE ON [dbo].[sp_select_CUMCOVEN] TO [ERPUSER] AS [dbo]
GO
