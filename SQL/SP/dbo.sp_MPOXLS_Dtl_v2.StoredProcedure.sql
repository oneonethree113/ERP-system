/****** Object:  StoredProcedure [dbo].[sp_MPOXLS_Dtl_v2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_MPOXLS_Dtl_v2]
GO
/****** Object:  StoredProcedure [dbo].[sp_MPOXLS_Dtl_v2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
=========================================================
Program ID	: sp_MPOXLS_Dtl_v2
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


CREATE   procedure [dbo].[sp_MPOXLS_Dtl_v2]
@Mxd_PONo	as varchar(20),
@Mxd_POSeq	as int,
@Mxd_ReqNo	as varchar(10),
@Mxd_ShpDat	as datetime,
@Mxd_ItmNo	as varchar(20),
@Mxd_ItmNam	as nvarchar(60),
@Mxd_ItmDsc	as nvarchar(30),
@Mxd_ColCde	as varchar(14),
@Mxd_UM	as varchar(5),	     	     
@Mxd_Qty	as numeric(9,2),
@Mxd_UntPrc	as numeric(9,4),    
@Mxd_PckMth	as nvarchar(8),	     	     
@Mxd_Dept	as nvarchar(10),	     	     
@Mxd_PrdNo	as varchar(100),
@Mxd_Rmk	as nvarchar(400),
@Mxd_UpdFlg	as varchar(3),
@FileName	as nvarchar(50),
@DUMMY	as char(1)
as
BEGIN

	Declare 	@errMsg as nvarchar(200) ,
		@Flag as char(1) ,
		@MPO as varchar(20) , 
		@OrdQty as numeric(9,2),
		@ShpQty as numeric(9,2) ,
		@UntPrc as numeric(9,4) , 		
		@VenNo as varchar(30) ,
		@ItmNo as varchar(30) 
		
	set @errMsg = ''
	set @Flag = 'N'	--NEW

	set @MPO = ''
	set @OrdQty = 0
	set @ShpQty = 0
	set @VenNo = ''
	set @ItmNo = ''
	set @UntPrc = 0


-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

	if @Mxd_ItmNo <> '' and @Mxd_ItmNam <> '' 
	begin
		if not exists(Select * from ZSITMLST where zil_itmno = @Mxd_ItmNo)
		begin
			
			insert into ZSITMLST (Zil_ItmNo, Zil_ItmNam, Zil_ItmDesc, Zil_CatCde1, Zil_CatCde2, Zil_Moq, Zil_MtyBy, Zil_CreDat, Zil_CreUsr, Zil_UpdDat, Zil_UpdUsr)
			values (@Mxd_ItmNo,@Mxd_ItmNam,@Mxd_ItmDsc,'','',0,1,getdate(),'XML UPLOAD',getdate(),'XML UPLOAD')
		end
		else
		begin
			
			update ZSITMLST set Zil_ItmNam = @Mxd_ItmNam, Zil_ItmDesc = @Mxd_ItmDsc, Zil_UpdDat = getdate(), Zil_UpdUsr = 'XML UPLOAD'
			where Zil_ItmNo = @Mxd_ItmNo and ( Zil_ItmNam <> @Mxd_ItmNam or Zil_ItmDesc <> @Mxd_ItmDsc)
		end
	end

-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

	if Upper(@Mxd_UpdFlg) <> 'DEL'  and  ltrim(rtrim(isnull(@Mxd_ItmNo,'')))= ''
	begin
		set @errMsg = @errMsg +  case len(@errMsg) when 0 then '' else ' | ' end + 'Item # Empty'
		set @Flag = 'R'
	end

	if Upper(@Mxd_UpdFlg) <> 'DEL' and isnull(@Mxd_UntPrc,0) <= 0 
	begin
		set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'Unit Price Invalid'
		set @Flag = 'R'
	end

	if Upper(@Mxd_UpdFlg) <> 'DEL' and (isnull(@Mxd_ShpDat,'') = '' or @Mxd_ShpDat = '1900/01/01')
	begin
		set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'Ship Date Invalid'
		set @Flag = 'R'
	end
	/*
	else if Upper(@Mxd_UpdFlg) <> 'DEL' 
	begin
		-- Add Logic to Check Modify Ship Date Less Than Previous Ship Date
	end
	*/
	
	if Upper(@Mxd_UpdFlg) <> 'DEL' and isnull(@Mxd_Qty,0) = 0
	begin
		set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'Zero Ord Qty'
		set @Flag = 'R'
	end
	
	if Upper(@Mxd_UpdFlg) <> 'DEL' and isnull(@Mxd_UM,'') = ''
	begin
		set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'UM Empty'
		set @Flag = 'R'
	end

	
	select @MPO = max(isnull(Mxd_MPONo,'')) from MPOXLSDTL where Mxd_PONo = @Mxd_PONo and Mxd_POSeq = @Mxd_POSeq

	if (@Flag <> 'E' or @Flag <> 'R') and isnull(@MPO,'') = '' 
	begin
		if @Flag <> 'E' 		
		begin		
			set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'Existing Record Marked "Old"'
			if upper(@Mxd_UpdFlg) = 'DEL'
			begin
				set @Flag = 'D'
			end
			update MPOXLSDTL set Mxd_MPOFlg = 'O' where Mxd_PONo = @Mxd_PONo and Mxd_POSeq = @Mxd_POSeq and Mxd_MPOFlg <> 'D'
		end
	end
	else if @Flag <> 'R'
	begin
		select 
			@ShpQty = Mpd_ShpQty , 
			@OrdQty = Mpd_Qty , 
			@UntPrc = Mpd_MinPrc 
		from 
			MPORDDTL 
		where 
			Mpd_MPONo = @MPO and  
			Mpd_PONo = @Mxd_PONo and 
			Mpd_POSeq = @Mxd_POSeq
		
		set @errMsg = @errMsg +  case len(@errMsg) when 0 then '' else ' | ' end +  'PO Generated (' + @MPO + ')'

		set @Flag = 'E'

		if Upper(@Mxd_UpdFlg) = 'DEL' 
		begin
			if ((select count(1) from MPORDDTL where Mpd_MpoNo = @MPO) <= 1 )
			begin
				set @errMsg =  @errMsg + case len(@errMsg) when 0 then '' else ' | ' end +  'Only One Dtl Record Remain'
				set @Flag = 'R'
			end
		end

		if @Flag <> 'R'
		begin
			if Upper(@Mxd_UpdFlg) <> 'DEL'  and @Mxd_UntPrc <= 0 
			begin
				set @errMsg = @errMsg +  case len(@errMsg) when 0 then '' else ' | ' end + 'Unit Price Not Valid!'
				set @Flag = 'R'
			end
			else if Upper(@Mxd_UpdFlg) <> 'DEL'  and @Mxd_UntPrc < @UntPrc
			begin
				set @errMsg = @errMsg +  case len(@errMsg) when 0 then '' else ' | ' end + 'Modified Unit Price < Previous Unit Price'
				set @Flag = 'R'
			end
			else if @Mxd_Qty < @ShpQty
			begin
				set @errMsg = @errMsg +  case len(@errMsg) when 0 then '' else ' | ' end + 'Modified Order Qty  < Shipped Qty'
				set @Flag = 'R'
			end 
		end
	end
	

	
-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

	if @Flag = 'E'  or @Flag = 'R'
	begin
		insert into MPOEXPDTL (
			Mxd_FilNam,
			Mxd_seq,
			Mxd_PONo,
			Mxd_POSeq,
			Mxd_ReqNo,
			Mxd_ShpDat,
			Mxd_ItmNo,
			Mxd_ItmNam,
			Mxd_ItmDsc,
			Mxd_ColCde,
			Mxd_UM,
			Mxd_Qty,
			Mxd_UntPrc,
			Mxd_PckMth,
			Mxd_Dept,
			Mxd_PrdNo,
			Mxd_Rmk,
			Mxd_UpdFlg,
			Mxd_Expt,
			Mxd_MPOFLG,
			Mxd_MPONO,
			Mxd_CreDat,
			Mxd_CreUsr,
			Mxd_UpdDat,
			Mxd_UpdUsr
		)
		select
			@FileName,
			isnull(max(Mxd_seq),0) + 1,
			@Mxd_PONo,
			@Mxd_POSeq,
			@Mxd_ReqNo,
			@Mxd_ShpDat,
			@Mxd_ItmNo,
			@Mxd_ItmNam,
			@Mxd_ItmDsc,
			@Mxd_ColCde,
			upper(@Mxd_UM),
			@Mxd_Qty,
			@Mxd_UntPrc,
			@Mxd_PckMth,
			@Mxd_Dept,
			@Mxd_PrdNo,
			@Mxd_Rmk,
			@Mxd_UpdFlg,
			@errMsg,
			ltrim(rtrim(@Flag)),
			'',
			getdate(),
			'XML UPLOAD',
			getdate(),
			'XML UPLOAD'
		from
			MPOEXPDTL
		where
			Mxd_FilNam = @FileName		
	end
	else
	begin
		insert into MPOXLSDTL (
			Mxd_FilNam,
			Mxd_seq,
			Mxd_PONo,
			Mxd_POSeq,
			Mxd_ReqNo,
			Mxd_ShpDat,
			Mxd_ItmNo,
			Mxd_ItmNam,
			Mxd_ItmDsc,
			Mxd_ColCde,
			Mxd_UM,
			Mxd_Qty,
			Mxd_UntPrc,
			Mxd_PckMth,
			Mxd_Dept,
			Mxd_PrdNo,
			Mxd_Rmk,
			Mxd_UpdFlg,
			Mxd_Expt,
			Mxd_MPOFLG,
			Mxd_MPONO,
			Mxd_CreDat,
			Mxd_CreUsr,
			Mxd_UpdDat,
			Mxd_UpdUsr
		)
		select
			@FileName,
			isnull(max(Mxd_seq),0) + 1,
			@Mxd_PONo,
			@Mxd_POSeq,
			@Mxd_ReqNo,
			@Mxd_ShpDat,
			@Mxd_ItmNo,
			@Mxd_ItmNam,
			@Mxd_ItmDsc,
			@Mxd_ColCde,
			upper(@Mxd_UM),
			@Mxd_Qty,
			@Mxd_UntPrc,
			@Mxd_PckMth,
			@Mxd_Dept,
			@Mxd_PrdNo,
			@Mxd_Rmk,
			@Mxd_UpdFlg,
			@errMsg,
			ltrim(rtrim(@Flag)),
			'',
			getdate(),
			'XML UPLOAD',
			getdate(),
			'XML UPLOAD'
		from
			MPOXLSDTL
		where
			Mxd_FilNam = @FileName		
	end

END






GO
GRANT EXECUTE ON [dbo].[sp_MPOXLS_Dtl_v2] TO [ERPUSER] AS [dbo]
GO
