/****** Object:  StoredProcedure [dbo].[sp_update_GRNTRFLST]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_GRNTRFLST]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_GRNTRFLST]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: sp_update_GRNTRFLST
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
--sp_help GRNTRFLST

CREATE Procedure [dbo].[sp_update_GRNTRFLST]
@cocde		varchar(6) ,
@Doc_No		varchar(20) ,
@Grl_GrnSeq	int,
@OriShpQty	numeric(9,2) ,
@Grl_ShpQty	numeric(9,2) ,
@Grl_MPONo	varchar(20) ,
@Grl_MPOSeq	int ,
@Grl_DtlRmk	nvarchar(300) ,	-- Lester Wu 2005-10-14
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
	

	Update 
		GRNTRFLST
	Set
		Grl_ShpQty = @Grl_ShpQty,
		Grl_DtlRmk = @Grl_DtlRmk , 	-- Lester Wu 2005-10-14
		Grl_UpdUsr =  'SH_' + @UsrID ,
		Grl_UpdDat = Getdate()
	Where
		Grl_GrnNo = @Doc_No
		and Grl_GrnSeq = @Grl_GrnSeq
		and Grl_MPONo = @Grl_MPONo
		and Grl_MPOSeq = @Grl_MPOSeq

	select @Err_Idx = @@error, @Row_Idx = @@RowCount
	
	if @Err_Idx = 0 
	begin
		--select * from MPORDDTL
		Update 
			MPORDDTL 
		Set 
			Mpd_ShpQty = Mpd_ShpQty  + (@Grl_ShpQty - @OriShpQty) , 
			Mpd_UpdDat = Getdate(),
			Mpd_UpdUsr = 'SH_' + @UsrID
		Where 
			Mpd_MPONo = @Grl_MPONo
			and Mpd_MPOSeq = @Grl_MPOSeq
			and Mpd_ShpQty + (@Grl_ShpQty - @OriShpQty) <=  Mpd_Qty
		
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
				--Print 'Update Ship Qty of ' + @Grl_MPONo + ' ( ' + @Grl_MPOSeq + ' )  failure!' + char(10) + char(13) + 'Please check the OS Qty.'
				Print '99'
				return (99)
			end
			else
			begin
				--Print 'Update MPO record ' + @Grl_MPONo + ' failure!' 
				Print '88'
				return (88)
			end
		end
	end

END







GO
GRANT EXECUTE ON [dbo].[sp_update_GRNTRFLST] TO [ERPUSER] AS [dbo]
GO
