/****** Object:  StoredProcedure [dbo].[sp_select_VNBASINF_VENNO]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_VNBASINF_VENNO]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_VNBASINF_VENNO]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO







-- Checked by Allan Yuen at 28/07/2003

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
20030715	Allan Yuen	For Merge Porject
20050823	Allan Yuen	Add Payment Term and Price Term code
*/


CREATE PROCEDURE [dbo].[sp_select_VNBASINF_VENNO] 

@vbi_cocde 	nvarchar(6) = ' '
AS
begin

Select 
vbi_cocde,
vbi_venno,
case when isnull(vbi_venchnnam,'') <> '' then vbi_venchnnam else vbi_vennam end as 'vbi_vennam',
vbi_prctrm,
vbi_paytrm,
-- Added by Mark Lau 20090313
vbi_vensna,
-- Added by Mark Lau 20090327
vbi_ventyp
from VNBASINF
where 
--vbi_cocde = @vbi_cocde
vbi_cocde = ' '

order by vbi_venno
end


GO
GRANT EXECUTE ON [dbo].[sp_select_VNBASINF_VENNO] TO [ERPUSER] AS [dbo]
GO
