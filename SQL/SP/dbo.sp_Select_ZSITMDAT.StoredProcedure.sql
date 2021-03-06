/****** Object:  StoredProcedure [dbo].[sp_Select_ZSITMDAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Select_ZSITMDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_Select_ZSITMDAT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: sp_Select_ZSITMDAT
Description   	: 
Programmer  	: Allan Yuen
Create Date   	:
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
*/


CREATE   procedure [dbo].[sp_Select_ZSITMDAT]
@Zid_cocde	as varchar(6),
@Zid_ItmNo	as varchar(20),
@Zid_Stage	as varchar(3) 

as

declare 	@no 	int
set @no = 1

if ltrim(rtrim(@Zid_ItmNo)) = '' 
	begin

		SELECT
			@no as 'no', 	
			Zid_Stage, 
			Zid_Stage  as 'old_stage', 
			Zid_Itmno, 
			Zid_Seqno, 			
			Zil_ItmNam,
			Zid_UM, 
			Zid_Curr, 
			Zid_UnitPrc, 
			Zid_MPONO, 
			Zid_Remark, 
			Zid_CreDat, 
			Zid_CreUsr, 
			Zid_UpdDat, 	
			Zid_UpdUsr, 
			cast(Zid_TimStp as int) as 'Zid_TimStp'
		from 
			ZSITMDAT 
			LEFT JOIN ZSITMLST ON ZIL_ITMNO = Zid_Itmno
		where
			Zid_Stage = (case @Zid_Stage when '' then 'W' else @Zid_Stage end)	
	end
else
	begin
		SELECT
			@no as 'no', 	
			Zid_Stage, 
			Zid_Stage  as 'old_stage', 
			Zid_Itmno, 
			Zid_Seqno, 			
			Zil_ItmNam,
			Zid_UM, 
			Zid_Curr, 
			Zid_UnitPrc, 
			Zid_MPONO, 
			Zid_Remark, 
			Zid_CreDat, 
			Zid_CreUsr, 
			Zid_UpdDat, 	
			Zid_UpdUsr, 
			cast(Zid_TimStp as int) as 'Zid_TimStp'
		from 
			ZSITMDAT 
			LEFT JOIN ZSITMLST ON ZIL_ITMNO = Zid_Itmno
		where
			Zid_Stage = (case @Zid_Stage when '' then 'W' else @Zid_Stage end)	and
			Zid_ItmNo = @Zid_ItmNo
	end


GO
GRANT EXECUTE ON [dbo].[sp_Select_ZSITMDAT] TO [ERPUSER] AS [dbo]
GO
