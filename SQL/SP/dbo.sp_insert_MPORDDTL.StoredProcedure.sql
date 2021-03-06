/****** Object:  StoredProcedure [dbo].[sp_insert_MPORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_MPORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_MPORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=========================================================
Program ID	: sp_insert_MPORDDTL
Description   	: 
Programmer  	: Lester Wu
ALTER  Date   	: 2005-07-29
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     

*/



CREATE Procedure [dbo].[sp_insert_MPORDDTL]
@cocde		as varchar(6),
@Mpd_PONo	as varchar(20),
@Mpd_POSeq	as int,
@Mpd_PODat	as datetime,
@Mxd_OrgShpDat	as datetime,
@Mpd_ItmNo	as varchar(20),
@Mpd_ItmNam	as varchar(60),
@Mpd_ItmDsc	as varchar(30),
@Mpd_ColCde	as varchar(24),
@Mpd_UM	as varchar(5),
@Mpd_Qty	as numeric(9,2),
@Mpd_UntPrc	as numeric(18,4),
@Mpd_PckMth	as varchar(8),
@Mpd_HdrRmk	as varchar(400),
@Mpd_Rmk	as varchar(400),
@Mpd_ReqNo	as varchar(10),
@Mpd_PrdNo	as varchar(100),
@Mpd_Dept	as varchar(10),
@Mpd_FilNamH	as varchar(50),
@Mpd_FilSeqH	as int,
@Mpd_FilNam	as varchar(50),
@Mpd_Filseq	as int,
@docNo		as varchar(20),
@UserID		as varchar(30)
as
BEGIN

	insert into MPORDDTL (Mpd_MPONO,Mpd_MPOseq,Mpd_PONo,Mpd_POSeq,Mpd_PODat,Mpd_ShpDat,Mpd_OrgShpDat,Mpd_ReqNo,Mpd_VenItm,Mpd_ItmNo,Mpd_ItmNam,
	Mpd_ItmDsc,Mpd_ColCde,Mpd_UM,Mpd_Qty,Mpd_ShpQty,Mpd_UntPrc,Mpd_PckMth,Mpd_Dept,Mpd_PrdNo,Mpd_FilNamH,
	Mpd_FilseqH,Mpd_FilNam,Mpd_Filseq,Mpd_HdrRmk,Mpd_Rmk,Mpd_CreDat,Mpd_CreUsr,Mpd_UpdDat,Mpd_UpdUsr)

	select @docNo,isnull(max(Mpd_MPOseq),0) + 1,@Mpd_PONo,@Mpd_POSeq,@Mpd_PODat,@Mxd_OrgShpDat,@Mxd_OrgShpDat,@Mpd_ReqNo,'',@Mpd_ItmNo,@Mpd_ItmNam,
	@Mpd_ItmDsc,@Mpd_ColCde,@Mpd_UM,@Mpd_Qty,0,@Mpd_UntPrc,@Mpd_PckMth,@Mpd_Dept,@Mpd_PrdNo,@Mpd_FilNamH,
	@Mpd_FilseqH,@Mpd_FilNam,@Mpd_Filseq,@Mpd_HdrRmk,@Mpd_Rmk,getdate(),@UserID + '_Gen', getdate(),@UserID + '_Gen'
	from MPORDDTL
	where Mpd_MPONO = @docNo

	/*
	update MPORDHDR
	set Mph_SHPDAT = @Mxd_OrgShpDat
	where Mph_MPONO = @docNo 
	and (Mph_ShpDAT is null or (Mph_ShpDAT is not null and Mph_ShpDat > @Mxd_OrgShpDat))
	
	--Update the Ship Date of the same Items with in the same Purchase Order to the min of the same item
	Update MPORDDTL
	set Mpd_SHPDAT = @Mxd_OrgShpDat
	where Mpd_MpoNo = @docNo
	and Mpd_ItmNo = @Mpd_ItmNo
	and (Mpd_ShpDat is null or (Mpd_ShpDat is not null and Mpd_ShpDat > @Mxd_OrgShpDat))


	update MPORDDTL
	set Mpd_MinPrc = @Mpd_UntPrc
	where Mpd_MPONO = @docNo 
	and Mpd_ItmNo = @Mpd_ItmNo
	and (Mpd_MinPrc is null or (Mpd_MinPrc is not null and Mpd_MinPrc > @Mpd_UntPrc))
	*/

	Update  MPOXLSDTL set Mxd_MPOFlg = 'G' , Mxd_MPONo = @docNo , Mxd_UpdDat = getdate(), Mxd_UpdUsr = @UserID
	where Mxd_FilNam = @Mpd_FilNam and Mxd_Seq = @Mpd_FilSeq
	

	Update MPOXLSHDR set Mxh_MPOFlg = 'G' , Mxh_UpdDat = getdate(), Mxh_UpdUsr = @UserID
	where Mxh_FilNam = @Mpd_FilNamH and Mxh_Seq = @Mpd_FilSeqH


END








GO
GRANT EXECUTE ON [dbo].[sp_insert_MPORDDTL] TO [ERPUSER] AS [dbo]
GO
