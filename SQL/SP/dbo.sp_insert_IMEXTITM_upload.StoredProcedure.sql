/****** Object:  StoredProcedure [dbo].[sp_insert_IMEXTITM_upload]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMEXTITM_upload]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMEXTITM_upload]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--sp_insert_IMEXTITM_upload 'UCPP','Product Quote Sheet_2.xls',1,


-- sp_insert_IMEXTITM_upload 'UCPP','MIS'

-- select * from IMEXTITM
/*
sp_select_IMPCKINF 'UCP','051669-fsc0001'

 select * from IMBASINF where ibi_itmno = '051669-fsc0001'
 select * from IMCOLINF where icf_itmno = '051669-fsc0001'
 select * from IMVENINF where ivi_itmno = '051669-fsc0001'
 select * from IMPCKINF where ipi_itmno = '051669-fsc0001'
 select * from IMMRKUP where imu_itmno = '051669-fsc0001'

 delete from IMBASINF where ibi_itmno = '051434-FCB0001'
 delete from IMCOLINF where icf_itmno = '051434-FCB0001'
 delete  from IMVENINF where ivi_itmno = '051434-FCB0001'
 delete  from IMPCKINF where ipi_itmno = '051434-FCB0001'
 delete  from IMMRKUP where imu_itmno = '051434-FCB0001'

*/

CREATE procedure [dbo].[sp_insert_IMEXTITM_upload]
@cocde		as varchar(6),
@UserID		as varchar(30)
as
BEGIN
	--External Item Upload
	DECLARE
	@Iei_FilNam	as varchar(100),
	@Iei_Seq		as int,
	@Iei_ItmNo	as varchar(20),
	@Iei_FilDat	as datetime,
	@Iei_PdItmNo 	as varchar(30),
	@Iei_Venno	as varchar(6),
	@Iei_VenItm	as varchar(20),
	@Iei_VenCol	 as varchar(20),
	@Iei_ItmCol	as varchar(20),
	@Iei_ItmDesc 	as nvarchar(800),
	@Iei_ChiDesc 	as nvarchar(800),
	@Iei_UntCde	as varchar(20),
	@Iei_Inner		as int,
	@Iei_Middle	as int,
	@Iei_Master	as int,
	@Iei_PckInst	as varchar(100),
	@Iei_InnerL	as numeric(9,4),
	@Iei_InnerW	as numeric(9,4),
	@Iei_InnerH	as numeric(9,4),
	@Iei_MasterL	as numeric(9,4),
	@Iei_MasterW	as numeric(9,4),
	@Iei_MasterH 	as numeric(9,4),
	@Iei_CFT		as numeric(9,4),
	@Iei_CBM 	as numeric(9,4),
	@Iei_Curr 		as varchar(6),     	     
	@Iei_ItmCst 	as numeric(9,4),
	@Iei_MOQUM 	as varchar(20),     	     
	@Iei_MOQ 	as int,
	@Iei_MrkUp 	as varchar(20),
	@Iei_MrkCurr 	as varchar(6),     	     
	@Iei_MrkCst 	as numeric(9,4),
	@Iei_ApvFlg	as char(1),     
	@Iei_CmpFlg 	as char(1),	     	     
	@Iei_PrdLne 	as varchar(20),
	@Iei_CatLvl 	as varchar(20),
	@Iei_PrcTrm 	as varchar(20),
	@Iei_Except 	as varchar(100),
	@Iei_Rmk 	as nvarchar(2000),
	@Iei_Stage 	as char(1)
	
	Declare 
		@ibi_itmsts	nvarchar(6),
		@ibi_catlvl0	nvarchar(40),
		@ibi_catlvl1	nvarchar(40),
		@ibi_catlvl2	nvarchar(40),
		@ibi_catlvl3	nvarchar(40)
	
		
	Declare	
		@Row_Idx		int,
		@Err_Idx			int
	

	/* Inch to CM (1:2.54), CM to Inch (1:0.39) */
	Declare 
		@Inch_To_CM as numeric(9,4),
		@CM_To_Inch as numeric(9,4)

	Declare
		@fml	as varchar(10)

	Declare
		@MOQUM as varchar(10),
		@MOQ as int,
		@ConFtr as numeric(9,4)

	set @MOQUM = ''
	set @MOQ = 0


	set @fml = ''

	set @Inch_To_CM = 2.54
	set @CM_To_Inch = 0.39

	set @Row_Idx = 0
	set @Err_Idx = 0
	
	-- Set Default MOQ
	set @MOQUM = 'CTN'
	select @MOQ = yco_moq from SYCOMINF where yco_cocde = @cocde
	if isnull(@MOQ,0) = 0 
	begin
		set @MOQ = 5
	end
	
	--IMEXTITM
	Declare  cur_IMEXTITM cursor
	For
		Select 
			Iei_FilNam	,		Iei_Seq,
			Iei_ItmNo,			Iei_FilDat,	
			Iei_PdItmNo,		Iei_Venno,	
			Iei_VenItm,		Iei_VenCol,
			Iei_ItmCol,			Iei_ItmDesc,
			Iei_ChiDesc,		Iei_UntCde,
			Iei_Inner,			Iei_Middle,	
			Iei_Master,			Iei_PckInst,
			Iei_InnerL,			Iei_InnerW,
			Iei_InnerH,			Iei_MasterL,
			Iei_MasterW,		Iei_MasterH,
			Iei_CFT,			Iei_CBM,	
			Iei_Curr,			Iei_ItmCst,	
			Iei_MOQUM,		Iei_MOQ,	
			Iei_MrkUp,		Iei_MrkCurr,
			Iei_MrkCst	,		Iei_ApvFlg	,
			Iei_CmpFlg,		Iei_PrdLne	,
			Iei_CatLvl,			Iei_PrcTrm	,
			Iei_Except,			Iei_Rmk,	
			Iei_Stage
		From
			 IMEXTITM
		Where
			--Iei_FilNam = @Iei_FilNam and
			--Iei_Seq = @Iei_Seq and
			--Iei_ItmNo = @Iei_ItmNo and
			Iei_ApvFlg = 'A' and
			Iei_CmpFlg = 'Y' and
			Iei_UpdUsr = @UserID
	--
	--

	Open cur_IMEXTITM
	Fetch next from cur_IMEXTITM into
		@Iei_FilNam,		@Iei_Seq,
		@Iei_ItmNo,		@Iei_FilDat,
		@Iei_PdItmNo,		@Iei_Venno,
		@Iei_VenItm,		@Iei_VenCol,
		@Iei_ItmCol,		@Iei_ItmDesc,
		@Iei_ChiDesc,		@Iei_UntCde,
		@Iei_Inner,		@Iei_Middle,
		@Iei_Master,		@Iei_PckInst,
		@Iei_InnerL,		@Iei_InnerW,
		@Iei_InnerH,		@Iei_MasterL,
		@Iei_MasterW,		@Iei_MasterH,
		@Iei_CFT,			@Iei_CBM,
		@Iei_Curr,			@Iei_ItmCst,
		@Iei_MOQUM,		@Iei_MOQ,
		@Iei_MrkUp,		@Iei_MrkCurr,
		@Iei_MrkCst,		@Iei_ApvFlg,
		@Iei_CmpFlg,		@Iei_PrdLne,
		@Iei_CatLvl,		@Iei_PrcTrm,
		@Iei_Except,		@Iei_Rmk,
		@Iei_Stage
	
	While @@fetch_status = 0

	BEGIN
		
		
		if exists(select * from IMBASINF where ibi_itmno =@Iei_ItmNo )  --->><<------
		BEGIN
			update 	
				IMEXTITM 
			set 	
				Iei_Stage = 'R' , 
				Iei_Except = Iei_Except + case len(Iei_Except) when 0 then '' else char(13) + char(10)  end + 'Item exist in IM (Upload)',
				Iei_upddat = getdate(), 
				Iei_UpdUsr = @UserID
			where
				Iei_FilNam = @Iei_FilNam and
				Iei_Seq = @Iei_Seq and
				Iei_ItmNo = @Iei_ItmNo and
				Iei_ApvFlg = 'A' and
				Iei_CmpFlg = 'Y'
				
		END
		ELSE --->><<------
		BEGIN
			BEGIN TRAN

			SET @ibi_catlvl0 = ''
			SET @ibi_catlvl1 = ''
			SET @ibi_catlvl2 = ''
			SET @ibi_catlvl3 = ''
		
		
			select 
				@ibi_catlvl0 = ycr_catlvl0, 
				@ibi_catlvl1 = ycr_catlvl1, 
				@ibi_catlvl2 = ycr_catlvl2, 
				@ibi_catlvl3 = ycr_catlvl3
			from
				sycatrel
			where
				ycr_catlvl4 =  @Iei_CatLvl 
			
			--MOQUM and MOQ may need to Modify before load to Item Master
			/*
			@Iei_MOQ
			@Iei_MOQUM
			@Iei_UntCde
			@Iei_Master
			*/
			set @ConFtr = 0

			if @Iei_Master > 0 and @Iei_UntCde <> '' 
			begin
				if isnull(@Iei_MOQUM,'') = '' or isnull(@Iei_MOQ,0) = 0 
				begin
					set @Iei_MOQUM = @MOQUM
					set @Iei_MOQ = @MOQ
				end
				else if isnull(@Iei_MOQUM,'') <> @Iei_UntCde
				begin
					if (select count(1) from SYCONFTR where ycf_code1 = @Iei_UntCde and ycf_code2 = @Iei_MOQUM) = 1
					begin
						select @ConFtr = isnull(ycf_value,0) from SYCONFTR where ycf_code1 = @Iei_UntCde and ycf_code2 = @Iei_MOQUM
						if @ConFtr > 0 
						begin
							set @Iei_MOQUM = 'CTN'
							set @Iei_MOQ = CEILING(isnull(cast(@Iei_MOQ  as numeric(9,4)) / (@ConFtr * @Iei_Master),0))
						end
					end
					else if (select count(1) from SYCONFTR where ycf_code1 = @Iei_MOQUM and ycf_code2 = @Iei_UntCde ) = 1 
					begin
						select @ConFtr = isnull(ycf_value,0) from SYCONFTR where ycf_code1 = @Iei_MOQUM and ycf_code2 = @Iei_UntCde
						if @ConFtr > 0 
						begin
							set @Iei_MOQUM = 'CTN'
							set @Iei_MOQ = CEILING(isnull((@ConFtr * cast(@Iei_MOQ  as numeric(9,4))) /  @Iei_Master,0))
						end
					end
				end
				else  if isnull(@Iei_MOQUM,'') = @Iei_UntCde
				begin
					set @Iei_MOQUM = 'CTN'
					set @Iei_MOQ = CEILING(isnull(cast(@Iei_MOQ  as numeric(9,4)) /  @Iei_Master,0))
				end
			end
			else
			begin
				set @Iei_MOQUM = @MOQUM
				set @Iei_MOQ = @MOQ
			end
		
			if  @Iei_MOQUM = '' or @Iei_MOQ <= 0
			begin
				set @Iei_MOQUM = @MOQUM
				set @Iei_MOQ = @MOQ
			end




			--Item Basic Info
			insert into  IMBASINF (
				ibi_cocde,		ibi_itmno,		ibi_orgitm,		ibi_lnecde,
				ibi_curcde,		ibi_catlvl0,		ibi_catlvl1,		ibi_catlvl2,
				ibi_catlvl3,		ibi_catlvl4,		ibi_itmsts,		ibi_typ,
				ibi_engdsc,		ibi_chndsc,		ibi_venno,		ibi_cusven,
				ibi_imgpth,		ibi_hamusa,	ibi_hameur,	ibi_dtyusa,
				ibi_dtyeur,		ibi_cosmth,	ibi_rmk,		ibi_tirtyp,
				ibi_moqctn,	ibi_qty,		ibi_moa,		ibi_prvsts,
				ibi_latrdat,		ibi_alsitmno,	ibi_alscat,		ibi_orgdvenno,
				ibi_wastage, 	ibi_creusr,		ibi_updusr,		ibi_credat,
				ibi_upddat
			)
			values(
				'',		@Iei_ItmNo,	'',		@Iei_PrdLne,
				@Iei_Curr,		@ibi_catlvl0,	@ibi_catlvl1,	@ibi_catlvl2,
				@ibi_catlvl3,	@Iei_CatLvl,	'CMP',		'REG',	
				@Iei_ItmDesc,	@Iei_ChiDesc,	@Iei_Venno,	@Iei_Venno,
				'',		'',		'',		0,
				0,		'',		@Iei_Rmk,	2,
				@Iei_MOQ,	1,		0,		'',
				NULL,		'',		'',		'',
				0,		'E-' + @UserID,	'E-' + @UserID,	getdate(),
				getdate()
			)
	
			
			--Error Handle
			select @Err_Idx = @@error, @Row_Idx = @@RowCount
			
			if @Err_Idx = 0 and @Row_Idx = 1
			BEGIN
			
				--Color Info
				insert into IMCOLINF(
					icf_cocde,		icf_itmno,		icf_colcde,		icf_colseq,
					icf_vencol,		icf_coldsc,		icf_typ,		icf_ucpcde,
					icf_eancde,		icf_asscol,		icf_swatchpath,	icf_imgpath,
					icf_creusr,		icf_updusr,		icf_credat,		icf_upddat
				)
				values(
					'',		@Iei_ItmNo,	@Iei_ItmCol,	1,
					@Iei_VenCol,	'',		'',		'',
					'',		'',		'',		'',
					'E-' + @UserID,	'E-' + @UserID,	getdate(),		getdate()
				)
				
				--Error Handle
				select @Err_Idx = @@error, @Row_Idx = @@RowCount
			END
			
			if @Err_Idx = 0 and @Row_Idx = 1
			BEGIN
				
				--Item Vendor Info
				--select * from IMVENINF
				insert into IMVENINF(
					ivi_cocde,		ivi_itmno,		ivi_venitm,		ivi_venno,
					ivi_def,		ivi_subcde,		ivi_creusr,		ivi_updusr,
					ivi_credat,		ivi_upddat
				)
				values(
					'',		@Iei_ItmNo,	@Iei_VenItm,	@Iei_Venno,
					'Y',		'',		'E-' + @UserID,	'E-' + @UserID,
					getdate(),		getdate()
				)
				--Error Handle
				select @Err_Idx = @@error, @Row_Idx = @@RowCount
			END		
	
			if @Err_Idx = 0 and @Row_Idx = 1
			BEGIN
				--Item Markup
				--set @fml  = ltrim(rtrim(left(@Iei_MrkUp,charindex('-',@Iei_MrkUp) - 1)))
				--select @fml
				--select * from IMMRKUP
				insert into IMMRKUP(
					imu_cocde,		imu_itmno,	imu_typ,		imu_ventyp,
					imu_venno,	imu_prdven,	imu_pckseq,	imu_pckunt,
					imu_inrqty,	imu_mtrqty,	imu_cft,		imu_curcde,
					imu_prctrm,	imu_relatn,		imu_fmlopt,	imu_ftycst,
					imu_ftyprc,	imu_calftyprc,	imu_bcurcde,	imu_basprc,
					imu_negprc,	imu_bomcst,	imu_ttlcst,		imu_alsbasprc,
					imu_itmprc,	imu_bomprc,	imu_creusr,	imu_updusr,
					imu_credat,	imu_upddat
				)
				values(
					'',		@Iei_ItmNo,	'REG',		'D',
					@Iei_Venno,	@Iei_Venno,	1,		@Iei_UntCde,
					@Iei_Inner,	@Iei_Master,	@Iei_CFT,		@Iei_Curr,
					@Iei_PrcTrm,	'Yes',		@Iei_MrkUp,		0,
					@Iei_ItmCst,	0,		@Iei_MrkCurr,	@Iei_MrkCst,
					0,		0,		@Iei_ItmCst,	0,
					@Iei_MrkCst,	0,		'E-' + @UserID,	'E-' + @UserID,
					getdate(),		getdate()
				)
				--Error Handle
				select @Err_Idx = @@error, @Row_Idx = @@RowCount
			END		
	
			if @Err_Idx = 0 and @Row_Idx = 1
			BEGIN
			
				--Packing Info
				-- @Inch_To_CM
				--select * from IMPCKINF
				insert into IMPCKINF(
					ipi_cocde,		ipi_itmno,		ipi_pckseq,		ipi_pckunt,
					ipi_mtrqty,		ipi_inrqty,		ipi_inrhin,		ipi_inrwin,
					ipi_inrdin,		
					ipi_inrhcm,				ipi_inrwcm,			ipi_inrdcm,
					ipi_mtrhin,		ipi_mtrwin,			ipi_mtrdin,		
					ipi_mtrhcm,			ipi_mtrwcm,			ipi_mtrdcm,
					ipi_cft,		ipi_cbm,		ipi_grswgt,		ipi_netwgt,		ipi_pckitr,
					ipi_creusr,		ipi_updusr,		ipi_credat,		ipi_upddat
				)
				values(
					'',		@Iei_ItmNo,	1,		@Iei_UntCde,
					@Iei_Master,	@Iei_Inner,	@Iei_InnerH,	@Iei_InnerW,
					@Iei_InnerL,	
					round(@Iei_InnerH*@Inch_To_CM,4),	round(@Iei_InnerW*@Inch_To_CM,4),	round(@Iei_InnerL*@Inch_To_CM,4),
					@Iei_MasterH,	@Iei_MasterW,	@Iei_MasterL,
					round(@Iei_MasterH*@Inch_To_CM,4),	round(@Iei_MasterW*@Inch_To_CM,4),	round(@Iei_MasterL*@Inch_To_CM,4),
					@Iei_CFT,		@Iei_CBM,	0,		0,		@Iei_PckInst,
					'E-' + @UserID,	'E-' + @UserID,	getdate(),		getdate()
				)		
				--Error Handle
				select @Err_Idx = @@error, @Row_Idx = @@RowCount
			END		
	
			if @Err_Idx = 0 and @Row_Idx = 1
			BEGIN
			
				--Packing Info
				-- @Inch_To_CM
				--select * from IMPCKINF
				--select * from IMVENPCK
				insert into IMVENPCK(
					ivp_cocde,		ivp_itmno,		ivp_pckseq,
					ivp_venno,		ivp_relatn,		ivp_creusr,
					ivp_updusr,	ivp_credat,		ivp_upddat
				)
				values(
					'',		@Iei_ItmNo,	1,
					@Iei_Venno,	'Yes',		'E-' + @UserID,
					'E-' + @UserID,	getdate(),		getdate()
				)		
				--Error Handle
				select @Err_Idx = @@error, @Row_Idx = @@RowCount
			END		
	
		
			if @Err_Idx = 0 and @Row_Idx = 1
			BEGIN
			
				Insert Into IMEXTITMH (
					Iei_FilNam	,		Iei_Seq,
					Iei_ItmNo,
					Iei_FilDat,			Iei_PdItmNo,
					Iei_Venno,			Iei_VenItm,
					Iei_VenCol,		Iei_ItmCol,
					Iei_ItmDesc,		Iei_ChiDesc,
					Iei_UntCde,		Iei_Inner,
					Iei_Middle,			Iei_Master,
					Iei_PckInst,		Iei_InnerL,
					Iei_InnerW,		Iei_InnerH,
					Iei_MasterL,		Iei_MasterW,
					Iei_MasterH,		Iei_CFT,
					Iei_CBM,			Iei_Curr,
					Iei_ItmCst,			Iei_MOQUM,
					Iei_MOQ,			Iei_MrkUp,
					Iei_MrkCurr,		Iei_MrkCst	,
					Iei_ApvFlg	,		Iei_CmpFlg,
					Iei_PrdLne	,		Iei_CatLvl,
					Iei_PrcTrm	,		Iei_Except,	
					Iei_Rmk,			Iei_Stage,
					Iei_CreUsr,		Iei_UpdUsr,
					Iei_CreDat,			Iei_UpdDat
					)
	
				Select 
					Iei_FilNam	,		Iei_Seq,
					Iei_ItmNo,
					Iei_FilDat,			Iei_PdItmNo,
					Iei_Venno,			Iei_VenItm,
					Iei_VenCol,		Iei_ItmCol,
					Iei_ItmDesc,		Iei_ChiDesc,
					Iei_UntCde,		Iei_Inner,
					Iei_Middle,			Iei_Master,
					Iei_PckInst,		Iei_InnerL,
					Iei_InnerW,		Iei_InnerH,
					Iei_MasterL,		Iei_MasterW,
					Iei_MasterH,		Iei_CFT,
					Iei_CBM,			Iei_Curr,
					Iei_ItmCst,			Iei_MOQUM,
					Iei_MOQ,			Iei_MrkUp,
					Iei_MrkCurr,		Iei_MrkCst	,
					Iei_ApvFlg	,		Iei_CmpFlg,
					Iei_PrdLne	,		Iei_CatLvl,
					Iei_PrcTrm	,		Iei_Except,	
					Iei_Rmk,			Iei_Stage,
					'E-' + @UserID,		'E-' + @UserID,
					getdate(),			getdate()
				From
					 IMEXTITM
				Where
					Iei_FilNam = @Iei_FilNam and
					Iei_Seq = @Iei_Seq and
					Iei_ItmNo = @Iei_ItmNo and
					Iei_ApvFlg = 'A' and
					Iei_CmpFlg = 'Y'
				--Error Handle
				select @Err_Idx = @@error, @Row_Idx = @@RowCount
			END
	
			if @Err_Idx = 0 and @Row_Idx = 1
			BEGIN
				Delete From
					 IMEXTITM
				Where
					Iei_FilNam = @Iei_FilNam and
					Iei_Seq = @Iei_Seq and
					Iei_ItmNo = @Iei_ItmNo and
					Iei_ApvFlg = 'A' and
					Iei_CmpFlg = 'Y'
				--Error Handle
				select @Err_Idx = @@error, @Row_Idx = @@RowCount
			END
		
			if @Err_Idx = 0 and @Row_Idx = 1
			BEGIN
				COMMIT TRAN
			END	
			else
			BEGIN
				ROLLBACK TRAN
				print 'Load data to Item Master failure! ' 
				return (99)
			END
		END  --->><<------
		
		Fetch next from cur_IMEXTITM into
			@Iei_FilNam,		@Iei_Seq,
			@Iei_ItmNo,		@Iei_FilDat,
			@Iei_PdItmNo,		@Iei_Venno,
			@Iei_VenItm,		@Iei_VenCol,
			@Iei_ItmCol,		@Iei_ItmDesc,
			@Iei_ChiDesc,		@Iei_UntCde,
			@Iei_Inner,		@Iei_Middle,
			@Iei_Master,		@Iei_PckInst,
			@Iei_InnerL,		@Iei_InnerW,
			@Iei_InnerH,		@Iei_MasterL,
			@Iei_MasterW,		@Iei_MasterH,
			@Iei_CFT,			@Iei_CBM,
			@Iei_Curr,			@Iei_ItmCst,
			@Iei_MOQUM,		@Iei_MOQ,
			@Iei_MrkUp,		@Iei_MrkCurr,
			@Iei_MrkCst,		@Iei_ApvFlg,
			@Iei_CmpFlg,		@Iei_PrdLne,
			@Iei_CatLvl,		@Iei_PrcTrm,
			@Iei_Except,		@Iei_Rmk,
			@Iei_Stage

	END
	CLOSE cur_IMEXTITM
	DEALLOCATE cur_IMEXTITM

END




GO
GRANT EXECUTE ON [dbo].[sp_insert_IMEXTITM_upload] TO [ERPUSER] AS [dbo]
GO
