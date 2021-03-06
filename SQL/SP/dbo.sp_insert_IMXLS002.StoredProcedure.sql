/****** Object:  StoredProcedure [dbo].[sp_insert_IMXLS002]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMXLS002]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMXLS002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
	Programmer		: Lester Wu
	Programmer Description	: Insert data into IMEXTITM
	ALTER  Date			: 2005/07/08
	i.     CFT to CBM (1: 0.0283), CBM to CFT (1:35.3357)
	ii.    Inch to CM (1:2.54), CM to Inch (1:0.39)
*/


--select top 10 * from IMBASINF where ibi_credat > '2005-01-01' and ibi_venno not between 'A' and 'Z'
--select yco_cocde,yco_moq,yco_curcde,yco_moa from SYCOMINF

--exec sp_general '㊣IMXLS002※A※UCPP※1234※1234※06/07/2005※ZX011※05-STT00001-CCCC※RD※05-STT00001-CCCC※Testing※PC※10※0※100※1.2※2.1※3.4※2.4※35.4※12.3※12※HK※12.3※PC※20※※Product Quote Sheet_2.xls※07/14/2005 15:30:24※mis', '', '', '', ''

CREATE procedure [dbo].[sp_insert_IMXLS002]
@cocde	varchar(6),
@tmp_VenNo	varchar(6),
@tmp_VenNam	varchar(100),
@tmp_DateTime		Datetime,		--
@tmp_VenItm	varchar(20),
@tmp_ItmNo	varchar(20),
@tmp_VenCol	varchar(20),
@tmp_OurCol	varchar(20),
@tmp_ItmDesc	nvarchar(800),
@tmp_UM	varchar(20),
@tmp_Inner	int,
@tmp_Middle	int,
@tmp_Master	int,
@tmp_InnerL	numeric(13,4),
@tmp_InnerW	numeric(13,4),
@tmp_InnerH	numeric(13,4),
@tmp_MasterL	numeric(13,4),
@tmp_MasterW	numeric(13,4),
@tmp_MasterH	numeric(13,4),
@tmp_CFT	numeric(13,4),
--	@tmp_CBM	numeric(13,4),
@tmp_CurrCst	varchar(6),
@tmp_ItmCst	numeric(13,4),
@tmp_MOQUM	varchar(20),
@tmp_MOQ	int,
@tmp_Exception	varchar(100),
@xlsPath 		varchar(100),
@strFileDate 	datetime,
@gsUsrID		varchar(30)
as
BEGIN
	
/*
select 
	@tmp_VenNo 	as 'tmp_VenNo',
	@tmp_VenNam 	as 'tmp_VenNam',
	@tmp_DateTime 	as 'tmp_DateTime',
	@tmp_VenItm 	as 'tmp_VenItm',
	@tmp_ItmNo 	as 'tmp_ItmNo',
	@tmp_VenCol	as 'tmp_VenCol',
	@tmp_OurCol 	as 'tmp_OurCol',
	@tmp_ItmDesc 	as 'tmp_ItmDesc',
	@tmp_UM 	as 'tmp_UM',
	@tmp_Inner 	as 'tmp_Inner',
	@tmp_Middle 	as 'tmp_Middle',
	@tmp_Master 	as 'tmp_Master',
	@tmp_InnerL 	as 'tmp_InnerL',
	@tmp_InnerW 	as 'tmp_InnerW',
	@tmp_InnerH 	as 'tmp_InnerH',
	@tmp_MasterL 	as 'tmp_MasterL',
	@tmp_MasterW 	as 'tmp_MasterW',
	@tmp_MasterH 	as 'tmp_MasterH',
	@tmp_CFT 	as 'tmp_CFT',
--	@tmp_CBM 	as 'tmp_CBM',
	@tmp_CurrCst 	as 'tmp_CurrCst',
	@tmp_ItmCst 	as 'tmp_ItmCst',
	@tmp_MOQUM 	as 'tmp_MOQUM',
	@tmp_MOQ 	as 'tmp_MOQ',
	@tmp_Exception	as 'tmp_Exception'
	
*/



	Declare 	@CmpFlg as char(1),
		@ApvFlg as char(1),
		@MOQ as int,
		@MOQUM as varchar(20),
		@CBM as numeric(9,4),
		@OurCol as varchar(4),
		@OurItm as varchar(20),
		@Remain as varchar(20),
		@Part as varchar(20),
		@Stage as char(1),
		@PrevStage as char(1),
		@PdItmNo as varchar(30),
		@ItmNoValid as char(1),
		@PrdLne	as varchar(20),
		@MrkUpFml as varchar(20)
		--,@tmp_ItmNo as varchar(20)
		--,@tmp_VenNo as varchar(4)
--	set @CmpFlg = 'Y'
	set @CmpFlg = 'N'
	set @ApvFlg = 'W'
	set @MOQ = 5
	set @MOQUM = 'CTN1'	
	set @MrkUpFml  = ''

	--get default MOQ value from Company Info
	select @MOQ = yco_moq from SYCOMINF where yco_cocde = @cocde

	set @CBM = @tmp_CFT*0.0283

	set @PdItmNo = @tmp_ItmNo

	--set @tmp_ItmNo = '05-STT00001-CCCC'
	--set @tmp_VenNo = '1234'

	-- select right('05-STT00001-CCCC',len('05-STT00001-CCCC') - charindex('-','05-STT00001-CCCC') )
	-- select left('05-STT00001-CCCC',charindex('-','05-STT00001-CCCC') - 1)
	-- select right('00' + str(year(getdate())),2)
	-- 

	if len(@tmp_CurrCst) = 2
	begin
		set @tmp_CurrCst = replace(@tmp_CurrCst,'HK','HKD')
		set @tmp_CurrCst = replace(@tmp_CurrCst,'US','USD')
	end
	
	if @tmp_CurrCst <> 'HKD' and @tmp_CurrCst<> 'USD' 
	begin
		set @tmp_CurrCst = ''
		set @CmpFlg = 'N'
	end

	set @PrdLne = ''
	set @ItmNoValid = 'N'
	set @Stage = 'R'

--select charindex('-','AB-CDDXXXX-CCCC')

if charindex('-',@tmp_ItmNo) = 3
BEGIN


	set @Remain = right(@tmp_ItmNo,len(@tmp_ItmNo) - charindex('-',@tmp_ItmNo) )
	set @Part = left(@tmp_ItmNo,charindex('-',@tmp_ItmNo) - 1)
	-- select SUBSTRING('abcdef', 2, 3)  => 'bcd'

	set @PrdLne = substring(@tmp_ItmNo,5,2) + '/' + left(@tmp_ItmNo,2) + substring(@tmp_ItmNo,4,1) 
	if charindex('-',@Remain) =8 
	BEGIN
		set @OurCol =  right(@Remain, len(@Remain) - charindex('-',@Remain) )
		set @tmp_ItmNo =right('00' + str(year(getdate())),2) + left(@tmp_VenNo,4) + '-' + left(@Remain,charindex('-',@Remain) - 1)
		set @ItmNoValid = 'Y'
		
	END

END

/*
set @OurCol = upper(@OurCol)
set @tmp_ItmNo = upper(@tmp_ItmNo)
set @tmp_VenCol = upper(@tmp_VenCol)
set @tmp_UM = upper(@tmp_UM)
*/

if @ItmNoValid='N'
BEGIN
	--'Invalid Item Format'
	set @OurCol = ''
	set @tmp_ItmNo = ''
	set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Invalid Pd Item No Format'
	set @CmpFlg = 'N'
	set @Stage = 'R'
END
else
BEGIN
	
	--'Valid'
	set @Stage = 'N'
	set @tmp_Exception = ''

	-----------------------------------------------------
	--Check External Item Info Complete or not
	-----------------------------------------------------
	/*
	if @tmp_VenNo = '' or @tmp_VenItm = '' or @tmp_ItmNo = '' or @tmp_VenCol = '' or @tmp_OurCol = '' or @tmp_ItmDesc = '' or 
		@tmp_UM = '' or (@tmp_Inner = 0 and (@tmp_Middle = 0 or @tmp_Master = 0 )) or @tmp_InnerL = 0 or @tmp_InnerW = 0 or 
		@tmp_InnerH = 0 or @tmp_MasterL = 0 or @tmp_MasterW = 0 or @tmp_MasterH = 0 or @tmp_CFT	 = 0 or @tmp_CurrCst	= '' or
		@tmp_ItmCst = 0 
	begin
		set @CmpFlg = 'N'
	end
	*/
	-----------------------------------------------------
	--Check MOQ Unit and MOQ value 
	------------------------------------------------------
	--select * from SYCONFTR where ycf_code1 like '%C%'
	/*
	if @tmp_MOQUM = '' or @tmp_MOQ = 0 
	begin
		set @tmp_MOQUM = @MOQUM
		set @tmp_MOQ = @MOQ
	end
	*/
	------------------------------------------------------
	--Check Conversion Factor Exist or Not
	-------------------------------------------------------
	if @tmp_MOQUM <> @tmp_UM
	begin
		if not exists(
				select * from SYCONFTR 
				where (ycf_code1 = @tmp_MOQUM and ycf_code2 = @tmp_UM) 
				or (ycf_code1 = @tmp_UM and ycf_code2 = @tmp_MOQUM)
			)
		begin
			set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Conversion Factor Not Exist'
			set @CmpFlg = 'N'
		end
	end
	------------------------------------------------------
	-- Check Vendor No Exist or Not
	------------------------------------------------------
	if not exists (
			select * from VNBASINF where vbi_venno = @tmp_venno
		)
	begin
		set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Vendor No Not Exist'
		set @CmpFlg = 'N'
	end
		
	------------------------------------------------------
	-- Check Color Code Exist or Not
	------------------------------------------------------
	if not exists (
			select * from SYCOLINF where yci_colcde = @OurCol
		)
	begin
		set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Item Color Not Exist'
		set @CmpFlg = 'N'
		Set @Stage = 'R'
	end

	-------------------------------------------------------
	--Check Item Exist in External Item Table or Not
	--------------------------------------------------------
	--N : New		O : Old		
	--U : Update	R : Reject

	if exists(select * from IMEXTITM where iei_itmno = @tmp_ItmNo and Iei_stage  = 'U' and Iei_ApvFlg = 'R')
	begin
		update IMEXTITM set Iei_stage = 'O' where iei_itmno = @tmp_ItmNo and Iei_stage = 'U' and Iei_ApvFlg = 'R'
		set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Item Exist in External Item Table'
		set @Stage = 'N'
	end
	else if exists(select * from IMEXTITM where iei_itmno = @tmp_ItmNo and Iei_stage  = 'U')
	begin
		set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Item Exist in External Item Table'
		set @Stage = 'R'
	end
	else if exists(select * from IMEXTITM where iei_itmno = @tmp_ItmNo and Iei_stage = 'N')
	begin
		update IMEXTITM set Iei_stage = 'O' where iei_itmno = @tmp_ItmNo and Iei_stage = 'N'
		set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Overwirte Existing External Item'
		set @Stage = 'N'
	end

	-------------------------------------------------------
	--Check Item Exist in Item Master or Not  (Vendor + Vendor No)
	--------------------------------------------------------
	if exists(select * from IMVENINF where ivi_venitm = @tmp_VenItm and ivi_venitm = @tmp_VenNo )
	begin
		set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Vendor and Vendor Item Exist'
		set @CmpFlg = 'N'
		set @Stage = 'R'	--Eject of Item already exist in Item Master
	end	

	-------------------------------------------------------
	--Check Item Exist in Item Master or Not (Our Item No)
	--------------------------------------------------------
	if exists(select * from IMBASINF where ibi_itmno = @tmp_ItmNo)
	begin
		set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Item Exist in Item Master'
		set @CmpFlg = 'N'
		set @Stage = 'R'	--Eject of Item already exist in Item Master
	end

	--select * from IMEXTITM
	
	
	-------------------------------------------------------
	--Check Product Line Exist in SYLNEINF or Not 
	--------------------------------------------------------
	if @PrdLne<> ''
	begin
		if not exists(select * from SYLNEINF where yli_lnecde = @PrdLne )
		begin
			set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Product line not exit'
			set @CmpFlg = 'N'
			set @Stage = 'R'
		end
	end
	
	if @tmp_Master > 0 and @tmp_Inner > 0 
	begin
		if (@tmp_Master % @tmp_Inner) > 0
		begin
			set @tmp_Exception = @tmp_Exception + case len(@tmp_Exception) when 0 then '' else char(13) + char(10)  end + 'Master Qty not multiple of Inner Qty'
			set @CmpFlg = 'N'
		end


	end

END
--000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
--000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
	
	select @MrkUpFml=	yvf_fmlopt from SYVENFML where yvf_venno = @tmp_VenNo and yvf_def = 'Y'

	insert into IMEXTITM (
			Iei_FilNam,	Iei_Seq,		Iei_FilDat,		
			Iei_PdItmNo,
			Iei_Venno,		Iei_VenItm,	Iei_ItmNo,
			Iei_VenCol,	Iei_ItmCol,		Iei_ItmDesc,
			Iei_UntCde,	Iei_PrdLne,	Iei_MrkUp,
			Iei_Inner,		Iei_Middle,		Iei_Master,
			Iei_InnerL,		Iei_InnerW,	Iei_InnerH,	
			Iei_MasterL,	Iei_MasterW,	Iei_MasterH,
			Iei_CFT,		Iei_CBM,		Iei_PrcTrm,
			Iei_Curr,		Iei_ItmCst,
			Iei_MOQUM,	Iei_MOQ,
			Iei_ApvFlg,	Iei_CmpFlg,
			Iei_Except,		Iei_Stage,
			Iei_CreUsr,	Iei_UpdUsr,
			Iei_CreDat,		Iei_UpdDat

		)
	--select * from IMEXTITM
	--sp_help  IMEXTITM
	select
			@xlsPath,			isnull(max(Iei_Seq),0) + 1,	convert(varchar(10),getdate(),101),	--@tmp_DateTime,	
			@PdItmNo,
			@tmp_VenNo, 		UPPER(@tmp_VenItm),	UPPER(@tmp_ItmNo),
			UPPER(@tmp_VenCol),	UPPER(@OurCol),		@tmp_ItmDesc,
			UPPER(@tmp_UM),		UPPER(@PrdLne),		@MrkUpFml,
			@tmp_Inner,		@tmp_Middle,		@tmp_Master,
			@tmp_InnerL,		@tmp_InnerW,		@tmp_InnerH,
			@tmp_MasterL,		@tmp_MasterW,		@tmp_MasterH,
			@tmp_CFT,		@CBM,			'FOB HK',
			@tmp_CurrCst,		@tmp_ItmCst,
			@tmp_MOQUM,		@tmp_MOQ,
			@ApvFlg,			@CmpFlg,
			ltrim(@tmp_Exception),	@Stage,
			@gsUsrID,		@gsUsrID,	
			getdate(),			getdate()
	from 
		IMEXTITM
	where 
		Iei_FilNam = @xlsPath


--000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
--000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
END







GO
GRANT EXECUTE ON [dbo].[sp_insert_IMXLS002] TO [ERPUSER] AS [dbo]
GO
