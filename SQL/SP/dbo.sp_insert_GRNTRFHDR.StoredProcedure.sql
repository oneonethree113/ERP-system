/****** Object:  StoredProcedure [dbo].[sp_insert_GRNTRFHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_GRNTRFHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_GRNTRFHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: sp_insert_GRNTRFHDR
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

CREATE PROCEDURE [dbo].[sp_insert_GRNTRFHDR]
--sp_help GRNTRFHDR
@cocde 		varchar(6),
@Doc_No 		varchar(20),
@Grh_ImpFty	nvarchar(100),
@Grh_ShpPlc	nvarchar(200),
@Grh_Addr	nvarchar(800),
@Grh_ShpAddr	nvarchar(800),
@Grh_InvHdr	nvarchar(200),
@Grh_AgtNo	varchar(50),
@Grh_TrdCty	nvarchar(100),
@Grh_Car		nvarchar(60),
@Grh_CusUM	nvarchar(60),
@Grh_InvUM	nvarchar(60),
@Grh_TtlCtn	numeric(9,0),    
@Grh_TtlNW	numeric(9,4),
@Grh_TtlGW	numeric(9,4),
--Lester Wu 2006-03-20
@Grh_DlvDat	char(10),
@Grh_CtrNo	varchar(30),
@UserID		varchar(30)
as
BEGIN

INSERT INTO 
	GRNTRFHDR (
		Grh_GrnNo,
		Grh_ImpFty,
		Grh_Addr,
		Grh_ShpPlc,
		Grh_ShpAddr,
		Grh_InvHdr,
		Grh_AgtNo,
		Grh_TrdCty,
		Grh_Car,
		Grh_CusUM,
		Grh_InvUM,
		Grh_TtlNW,
		Grh_TtlGW,
		Grh_TtlCtn,
		--Lester Wu 2006-03-20
		Grh_DlvDat,
		Grh_CtrNo,
		--
		Grh_CreUser,
		Grh_CreDat,
		Grh_UpdUsr,
		Grh_UpdDat
		)
	values (
		@Doc_No,
		@Grh_ImpFty,
		@Grh_Addr,
		@Grh_ShpPlc,
		@Grh_ShpAddr,
		@Grh_InvHdr,
		@Grh_AgtNo,
		@Grh_TrdCty,
		@Grh_Car,
		@Grh_CusUM,
		@Grh_InvUM,
		@Grh_TtlNW,
		@Grh_TtlGW,
		@Grh_TtlCtn,
		--Lester Wu 2006-03-20
		@Grh_DlvDat,
		@Grh_CtrNo,
		--
		@UserID,
		getdate(),
		@UserID,
		getdate()
	)

END







GO
GRANT EXECUTE ON [dbo].[sp_insert_GRNTRFHDR] TO [ERPUSER] AS [dbo]
GO
