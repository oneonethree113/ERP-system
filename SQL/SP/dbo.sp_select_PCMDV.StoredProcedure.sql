/****** Object:  StoredProcedure [dbo].[sp_select_PCMDV]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PCMDV]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PCMDV]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
=========================================================
Program ID	: sp_select_PCMDV
Description   	: Select Data form Profit Center Associated Design Vendor Table 
Programmer  	: Marco Chan
Create Date   	: 18 Sept 2003
Last Modified  	: 
Table Read(s) 	: PCMDV
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/
create procedure [dbo].[sp_select_PCMDV]
@cocde varchar(6),
@pdv_pcno varchar(20)
AS
begin

select 	'' as 'pdv_del',
 	pdv_pcno,
	pdv_vencde, 
	vbi_vennam 'pdv_vennam',
	pdv_creusr,
	'' as 'pdv_status'
from	PCMDV
left join VNBASINF on vbi_venno = pdv_vencde
where pdv_pcno = @pdv_pcno
order by pdv_pcno, pdv_vencde
end




GO
GRANT EXECUTE ON [dbo].[sp_select_PCMDV] TO [ERPUSER] AS [dbo]
GO
