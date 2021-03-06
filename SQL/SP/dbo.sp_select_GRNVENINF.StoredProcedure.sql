/****** Object:  StoredProcedure [dbo].[sp_select_GRNVENINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_GRNVENINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_GRNVENINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 2005/10/13
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================
2005-10-10	Allan Yuen	Add Column     

*/



CREATE PROCEDURE [dbo].[sp_select_GRNVENINF] 

@gvi_cocde	varchar(6),
@gvi_type		varchar(6)

AS

SELECT 
	Gvi_VenSna, 
	Gvi_InvVen, 
	Gvi_Type, 
	Gvi_VenNam, 
	Gvi_EngNam, 
	Gvi_VenAddr, 
	Gvi_EngAddr, 
	Gvi_Tel1, 
	Gvi_Tel2, 
	Gvi_Fax, 
	Gvi_TLX, 
	Gvi_CntPer, 
	Gvi_BillTo, 
	Gvi_CC, 
	Gvi_CreDat, 
	Gvi_CreUsr, 
	Gvi_UpdDat, 
	Gvi_UpdUsr
FROM 
	GRNVENINF
WHERE
	GVI_TYPE = @gvi_type
ORDER BY 
	GVI_INVVEN



GO
GRANT EXECUTE ON [dbo].[sp_select_GRNVENINF] TO [ERPUSER] AS [dbo]
GO
