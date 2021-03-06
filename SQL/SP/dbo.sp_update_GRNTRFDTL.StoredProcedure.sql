/****** Object:  StoredProcedure [dbo].[sp_update_GRNTRFDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_GRNTRFDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_GRNTRFDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=========================================================
Program ID	: sp_update_GRNTRFDTL
Description   	: 
Programmer  	: Lester Wu
Create Date   	:
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date			Author		Description
=========================================================     
2005-10-14	Lester Wu		Update Dtl Remark field
*/
--sp_help GRNTRFDTL

CREATE Procedure [dbo].[sp_update_GRNTRFDTL]
@cocde		varchar(6),
@Grd_GrnNo	varchar(20),
@Grd_Seq		int,
@Grd_Type	varchar(50) ,
@Grd_MpoNo	varchar(20) ,	
@Grd_RefNo	varchar(20) ,
@Grd_ItmNo	varchar(20) ,
@Grd_ItmNam	nvarchar(60) ,
@Grd_ItmDsc	nvarchar(50) ,
@Grd_Curr	varchar(6) ,
@Grd_UntPrc	numeric(13,4) ,    
@Grd_Color	nvarchar(30) ,
@Grd_CustCat	nvarchar(20) ,
@Grd_Cty		nvarchar(20) ,	     
@Grd_CTNFm	varchar(20) ,
@Grd_CTNTo	varchar(20) ,
@Grd_TtlCTN	numeric(13,0) ,    
@Grd_CtnUM	nvarchar(30) ,
@Grd_GW	numeric(13,4) ,    
@Grd_NW	numeric(13 ,4) ,    
@Grd_TtlGW	numeric(13,4) ,    
@Grd_TtlNW	numeric(13,4) ,    
@Grd_PckWgt	numeric(18,4) ,    
@Grd_PckUM	nvarchar(30) ,
@Grd_Grp		nvarchar(40) ,
@Grd_TtlShpQty	numeric(13,2) ,    
@Grd_ShpUM	nvarchar(30) ,
@Grd_RevDept	nvarchar(50) ,	   
@Grd_CustUM	nvarchar(30) , 	-- Lester Wu 2005-10-14  
@Grd_DtlRmk	nvarchar(300) ,	-- Lester Wu 2005-10-14
@Grd_CustQty	numeric(13,4) ,    
@Grd_PrtGrp		int,	-- Frankie Cheung 20091015
@TimStp		int,
@UsrID		varchar(30)
as
BEGIN

	Declare	
		@Row_Idx		int,
		@Err_Idx			int

	Begin Tran

		UPDATE 
			GRNTRFDTL
		SET 
			Grd_Type = @Grd_Type,
			Grd_MpoNo = @Grd_MpoNo ,
			Grd_RefNo = @Grd_RefNo ,
			Grd_ItmNo = @Grd_ItmNo ,
			Grd_ItmNam = @Grd_ItmNam ,
			Grd_ItmDsc = @Grd_ItmDsc ,
			Grd_Color = @Grd_Color ,
			Grd_Curr = @Grd_Curr ,
			Grd_UntPrc = @Grd_UntPrc ,
			Grd_TtlShpQty = @Grd_TtlShpQty ,
			Grd_ShpUM = @Grd_ShpUM ,
			Grd_RevDept = @Grd_RevDept ,
			Grd_CustCat = @Grd_CustCat ,
			Grd_Cty = @Grd_Cty ,
			Grd_CTNFm = @Grd_CTNFm ,
			Grd_CTNTo = @Grd_CTNTo ,
			Grd_TtlCTN = @Grd_TtlCTN ,
			Grd_CtnUM = @Grd_CtnUM ,
			Grd_GW = @Grd_GW ,
			Grd_NW = @Grd_NW ,
			Grd_TtlGW = @Grd_TtlGW ,
			Grd_TtlNW = @Grd_TtlNW ,
			Grd_PckWgt = @Grd_PckWgt ,
			Grd_PckUM = @Grd_PckUM ,
			Grd_Grp = @Grd_Grp ,
			Grd_CustUM = @Grd_CustUM , -- Lester Wu 2005-10-14
			Grd_DtlRmk = @Grd_DtlRmk ,	-- Lester Wu 2005-10-14
			Grd_UpdUsr = @UsrID ,
			Grd_UpdDat = Getdate(),
			Grd_CustQty = @Grd_CustQty,
			Grd_PrtGrp = @Grd_PrtGrp	--Frankie Cheung 20091015	
		Where 
		Grd_GrnNo = @Grd_GrnNo
		and Grd_Seq = @Grd_Seq

	select @Err_Idx = @@error, @Row_Idx = @@RowCount

	if @Err_Idx = 0 
	begin
		commit tran
	end
	else
	begin
		rollback tran
		return (@Err_Idx)
	end


END









GO
GRANT EXECUTE ON [dbo].[sp_update_GRNTRFDTL] TO [ERPUSER] AS [dbo]
GO
