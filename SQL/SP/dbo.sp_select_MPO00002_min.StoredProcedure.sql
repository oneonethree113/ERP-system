/****** Object:  StoredProcedure [dbo].[sp_select_MPO00002_min]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPO00002_min]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPO00002_min]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
=========================================================
Program ID	: sp_select_MPO00002_min
Description   	: 
Programmer  	: Lester Wu
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

--sp_select_MPO00002_min 'UCPP','MP0500032','mis'

CREATE procedure [dbo].[sp_select_MPO00002_min]
@cocde		as varchar(6),
@MPONo 	as varchar(20),
@UsrID		as varchar(30)
as
begin
	Declare	
		@Row_Idx		int,
		@Err_Idx			int,
		@ttl_Amt			numeric(13,4)
	--Set the min unit price	
	begin tran

	update 
		MPORDDTL 
	set 
	--select * from MPORDDTL 
		mpd_minprc = isnull(a.MinPrc,Mpd_UntPrc),
		mpd_shpdat = isnull(a.MinShp,Mpd_ShpDat),
		mpd_UpdDat = getdate(),
		mpd_UpdUsr = @UsrID + '_MIN'
	from (
		select 
			Mpd_MpoNo as 'MpoNo',
			Mpd_ItmNo as 'ItmNo',
			Mpd_UM as 'UM',
			min(Mpd_UntPrc) as 'MinPrc' ,
			min(Mpd_OrgShpDat) as 'MinShp'
		from 
			MPORDDTL
		where 
			Mpd_MPONo = @MPONo -- 'MP0500032'
		group by
			 Mpd_MpoNo,Mpd_ItmNo, Mpd_UM

	) a
	--,MPORDDTL
	where 	--Mpd_MPONO = @MPONo and  
		a.MpoNo = Mpd_MpoNo and 
		a.ItmNo = Mpd_ItmNo and
		a.UM = Mpd_UM

	select @Err_Idx = @@error, @Row_Idx = @@RowCount
	
	if @Err_Idx = 0 
	begin

		set @ttl_Amt = 0

		select 
			@ttl_Amt = round(sum(Mpd_Qty * Mpd_MinPrc),2)
		from
			MPORDDTL
		where 
			Mpd_MPONo =@MPONO
		group by 
			Mpd_MpoNo

--select * from MPORDHDR where mph_mpono = 'MP0500032'
		update 
			MPORDHDR
		set 
			Mph_ttlAmt =  @ttl_Amt,
			Mph_NetAmt = round(@ttl_Amt * (1 - Mph_discnt),2) , 
			Mph_UpdDat = getdate(),
			Mph_UpdUsr = @UsrID + '_MIN'
		where 
			Mph_MPONo =@MPONO 
		
	end
	
	select @Err_Idx = @@error, @Row_Idx = @@RowCount
	
	if @Err_Idx = 0 
	begin
		commit tran	
		select 'Update Success' as 'return'
		--print 'Update Success'
		--return (99)
	end
	else
	begin
		rollback tran
		--print '99'
		--return (99)
		
	end	
end






GO
GRANT EXECUTE ON [dbo].[sp_select_MPO00002_min] TO [ERPUSER] AS [dbo]
GO
