/****** Object:  StoredProcedure [dbo].[sp_insert_GRNTRFLST]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_GRNTRFLST]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_GRNTRFLST]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: sp_insert_GRNTRFLST
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
2005-10-14	Lester Wu		Insert Dtl Remark field
*/
--sp_help GRNTRFLST

CREATE  Procedure [dbo].[sp_insert_GRNTRFLST]
@cocde		varchar(6) ,
@Doc_No		varchar(20) ,
@Grl_GrnSeq	int,
@Grl_PONo	varchar(20) ,
@Grl_POSeq	int , 
@Grl_ShpQty	numeric(9,2) ,
@Grl_Curr		varchar(6),
@Grl_UntPrc	numeric(9,4) ,
@Grl_OrgPrc	numeric(9,4) ,
@Grl_MPONo	varchar(20) ,
@Grl_MPOSeq	int ,
@Grl_RevDept	nvarchar(100),
@Grl_DtlRmk	nvarchar(300) , 	-- Lester Wu 2005-10-14
@TimStp		int,
@UsrID		varchar(30)
as
BEGIN
	Declare	
		@Row_Idx		int,
		@Err_Idx			int
	Declare
		@ShpQty			numeric(9,2),
		@OSQty			numeric(9,2)
	
	
	Begin Tran
	
/*
	select 
		@ShpQty = Mpd_ShpQty , 
	          	@OSQty = Mpd_Qty - Mpd_ShpQty
	from  
		MPORDDTL (NOLOCK)
	Where
		Mpd_MPONo = @Grl_MPONo
		and Mpd_MPOSeq = @Grl_MPOSeq
	
*/	

	INSERT INTO GRNTRFLST
		 (
		Grl_GrnNo,
		Grl_GrnSeq,
		Grl_PONo,
		Grl_POSeq,
		Grl_ShpQty,
		Grl_Curr,
		Grl_UntPrc,
		Grl_OrgPrc,
		Grl_MPONo,
		Grl_MPOSeq,
		Grl_RevDept,
		Grl_DtlRmk , 	-- Lester Wu 2005-10-14
		Grl_CreUsr,
		Grl_CreDat,
		Grl_UpdUsr,
		Grl_UpdDat
		)
	VALUES (
		@Doc_No,
		@Grl_GrnSeq,
		@Grl_PONo,
		@Grl_POSeq,
		@Grl_ShpQty,
		@Grl_Curr,
		@Grl_UntPrc,
		@Grl_OrgPrc,
		@Grl_MPONo,
		@Grl_MPOSeq,
		@Grl_RevDept,
		@Grl_DtlRmk , 	-- Lester Wu 2005-10-14
		@UsrID,
		Getdate(),
		@UsrID,
		Getdate()
		)	
	select @Err_Idx = @@error, @Row_Idx = @@RowCount
	
	if @Err_Idx = 0 
	begin
		--select * from MPORDDTL
		Update 
			MPORDDTL 
		Set 
			Mpd_ShpQty = Mpd_ShpQty + @Grl_ShpQty , 
			Mpd_UpdDat = Getdate(),
			Mpd_UpdUsr = 'SH_' + @UsrID
		Where 
			Mpd_MPONo = @Grl_MPONo
			and Mpd_MPOSeq = @Grl_MPOSeq
			and Mpd_ShpQty + @Grl_ShpQty <= Mpd_Qty
		
		select @Err_Idx = @@error, @Row_Idx = @@RowCount
	end


	
	if @Err_Idx = 0 and @Row_Idx = 1
	begin

		if( (select count(1) from MPORDDTL where mpd_mpono = @Grl_MPONo and (Mpd_Qty - Mpd_ShpQty) > 0 ) = 0 )
		begin
			Update MPORDHDR set Mph_MpoSts = 'CLO' , Mph_UpdDat = getdate(), Mph_UpdUsr =  'SH_' + @UsrID
			where mph_mpono = @Grl_MPONO and Mph_MpoSts <> 'CAN'
		end
		else
		begin
			Update MPORDHDR set Mph_MpoSts = 'ACT'  , Mph_UpdDat = getdate(), Mph_UpdUsr =  'SH_' + @UsrID
			where mph_mpono = @Grl_MPONO and Mph_MpoSts <> 'CAN'
		end
		
		commit tran
	end
	else
	begin
		rollback tran
		if @Err_Idx<> 0 
		begin
			return (@Err_Idx)
		end
		else
		begin
			if @Row_Idx = 0 
			begin
				--Print 'Update Ship Qty of ' + @Grl_MPONo + ' failure!' + char(10) + char(13) + 'Please check the OS Qty.'
				print '99'
				return (99)
			end
			else
			begin
				--Print 'Update MPO record ' + @Grl_MPONo + ' failure!' 
				print '88'
				return (88)
			end
		end
	end

END







GO
GRANT EXECUTE ON [dbo].[sp_insert_GRNTRFLST] TO [ERPUSER] AS [dbo]
GO
