/****** Object:  StoredProcedure [dbo].[sp_update_GRNTRFHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_GRNTRFHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_GRNTRFHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: sp_update_GRNTRFHDR
Description   	: 
Programmer  	: Lester Wu
Create Date   	: 2005-08-22
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
2006-03-20	Lester Wu		Update Delivery Date & Container No
=========================================================     

*/

CREATE PROCEDURE [dbo].[sp_update_GRNTRFHDR]
--sp_help GRNTRFHDR
@cocde 		varchar(6) ,
@Doc_No 		varchar(20) ,
@Grh_ImpFty	nvarchar(100) ,
@Grh_ShpPlc	nvarchar(200) ,
@Grh_Addr	nvarchar(800) ,
@Grh_ShpAddr	nvarchar(800) ,
@Grh_InvHdr	nvarchar(200) ,
@Grh_AgtNo	varchar(50) ,
@Grh_TrdCty	nvarchar(100) ,
@Grh_Car		nvarchar(60) ,
@Grh_CusUM	nvarchar(60) ,
@Grh_InvUM	nvarchar(60) ,
@Grh_TtlCtn	numeric(9 ,0) ,    
@Grh_TtlNW	numeric(9 ,4) ,
@Grh_TtlGW	numeric(9 ,4) ,
--Lester Wu 2006-03-20
@Grh_DlvDat	char(10),
@Grh_CtrNo	varchar(30),
@UserID		varchar(30)
as
BEGIN

UPDATE
	GRNTRFHDR 
SET

	Grh_ImpFty = @Grh_ImpFty ,
	Grh_Addr = @Grh_Addr ,
	Grh_ShpPlc = @Grh_ShpPlc ,
	Grh_ShpAddr = @Grh_ShpAddr ,
	Grh_InvHdr = @Grh_InvHdr ,
	Grh_AgtNo = @Grh_AgtNo ,
	Grh_TrdCty = @Grh_TrdCty ,
	Grh_Car = @Grh_Car ,
	Grh_CusUM = @Grh_CusUM ,
	Grh_InvUM = @Grh_InvUM ,
	Grh_TtlNW = @Grh_TtlNW ,
	Grh_TtlGW = @Grh_TtlGW ,
	Grh_TtlCtn = @Grh_TtlCtn ,
	--Lester Wu 2006-03-20
	Grh_DlvDat = @Grh_DlvDat,
	Grh_CtrNo = @Grh_CtrNo, 
	--
	Grh_UpdUsr = @UserID ,
	Grh_UpdDat = getdate()
	
WHERE
	Grh_GrnNo = @Doc_No

END







GO
GRANT EXECUTE ON [dbo].[sp_update_GRNTRFHDR] TO [ERPUSER] AS [dbo]
GO
