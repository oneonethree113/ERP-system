/****** Object:  StoredProcedure [dbo].[sp_calc_extbasprc]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_calc_extbasprc]
GO
/****** Object:  StoredProcedure [dbo].[sp_calc_extbasprc]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_calc_extbasprc] 

@cocde			nvarchar(10),
@ied_ucpno		nvarchar(20),
@ied_venno		nvarchar(20),
@catlvl4 		nvarchar(20),
@matcde		nvarchar(6),
@itmtyp			nvarchar(4),
@lnecde		nvarchar(10) ,
@ied_curcde		nvarchar(6),
@ftyprc			numeric(13,4),
@ied_xlsfil		nvarchar(50),
@ied_chkdat		datetime,
@ied_prdven		nvarchar(20),
@itmprc_af		numeric(13,4) output,
@bomcst_af		numeric(13,4) output,
@bomprc_af		numeric(13,4) output,
@imu_basprc_af		numeric(13,4) output,
@imu_fmlopt_af		nvarchar(10) output


AS

DECLARE
@fml			nvarchar(50),
@i			int,
@OP			nvarchar(1),
@end			int,
@temp 			numeric(13,4),
@imu_bom_curcde	nvarchar(6),
@imu_bom_ftyprc	numeric(13,4),
@imu_bom_ftycst	numeric(13,4),	
@iba_fcurcde 		nvarchar(6),
@imu_bcurcde		nvarchar(6),
@iba_ftycst		numeric(13,4), 
@iba_untcst		numeric(13,4),
@imu_selrat		numeric(16,11),	
@imu_buyrat		numeric(16,11),
@imu_ftybomcst_untcst	numeric(13,4),
@imu_ftybomcst_ftycst	numeric(13,4),
@iba_count		int,
@ied_catlvl2		nvarchar(20),
@debug			int,
@ventyp		char(1)

set @ventyp = 'D'

DECLARE 	--IMBOMEXDAT
@ibd_cocde		nvarchar(6),		@ibd_ucpno		nvarchar(20),		@ibd_bomno		nvarchar(20),
@ibd_colcde		nvarchar(200),		@ibd_qty		int,			@ibd_xlsfil 		nvarchar(30),	
@ibd_chkdat		datetime,		@ibd_untcde		nvarchar(6),		@ibd_conftr		int,
@ibd_recseq		int,			@ibd_stage		nvarchar(3),		@ibd_sysmsg		nvarchar(300),	
@ibd_veneml		nvarchar(50),		@ibd_malsts		nvarchar(1),		@ibd_venno		nvarchar(6),	
@ibd_credat		datetime,		@ibd_prdven		nvarchar(6),		@ibd_seqno		int

declare 		-- IMBOMASS
@iba_fmlopt 		varchar(5),		@iba_bombasprc		numeric(13,4),		@iba_bomqty		int,
@iba_costing		char(1),			@iba_curcde		varchar(4),		@iba_mtrqty		int,	
@iba_assitm		nvarchar(20)


set @bomcst_af = 0
set @bomprc_af = 0
set @imu_selrat  = 0
set @imu_buyrat = 0
set @imu_bom_curcde = ''

select 
	@imu_selrat = ysi_selrat ,
	@imu_buyrat = ysi_buyrat 
from 
	SYSETINF (nolock)
where 	
	ysi_typ = '06' and ysi_cde = @ied_curcde

--##########################################

if @itmtyp = 'REG'
BEGIN	
--##########################################

/*********** BOM COST / BOM PRICE FROM EXCEL FILE *********************/


	Declare cur_IMBOMEXDAT CURSOR
	FOR
	SELECT 
		ibd_cocde,	ibd_ucpno, 	ibd_bomno,
		ibd_colcde,	ibd_qty,		ibd_xlsfil,	
		ibd_chkdat,	ibd_untcde,	ibd_conftr,
		ibd_recseq,	ibd_stage,	ibd_veneml,	
		ibd_malsts,	ibd_sysmsg, 	ibd_venno,
		ibd_credat,	ibd_prdven
	FROM 
		IMBOMEXDAT
	WHERE	
		ibd_ucpno = @ied_ucpno and 
		ibd_xlsfil = @ied_xlsfil and 
		ibd_chkdat = @ied_chkdat and 
		ibd_stage in ('W')
		
	OPEN cur_IMBOMEXDAT
	FETCH NEXT FROM cur_IMBOMEXDAT INTO 
		@ibd_cocde,	@ibd_ucpno,	@ibd_bomno,
		@ibd_colcde,	@ibd_qty,	@ibd_xlsfil,	
		@ibd_chkdat,	@ibd_untcde,	@ibd_conftr,
		@ibd_recseq,	@ibd_stage,	@ibd_veneml,	
		@ibd_malsts,	@ibd_sysmsg,	@ibd_venno,
		@ibd_credat,	@ibd_prdven
	
	WHILE @@fetch_status = 0
	BEGIN		

		if @ventyp = 'D'
		begin
			--- Retrive Price Info Information form IM ---
			SET @imu_bom_curcde = ' '
			SET @imu_bom_ftyprc = 0
			set @imu_bcurcde = ''
			set @imu_bom_ftycst = 0.0
			
			SELECT
				@imu_bom_curcde = imu_curcde ,
				@imu_bom_ftyprc  = imu_ftyprc,
				@imu_bcurcde = imu_bcurcde,
				@imu_bom_ftycst = imu_ftycst
			from
				immrkup
			where
				imu_itmno =  @ibd_bomno and
				imu_typ = 'BOM' and
				imu_ventyp = 'D'
			----------------------------------------------

			--NEW BOM ITEM
			set @iba_bomqty = @ibd_qty
			set @iba_curcde = @imu_bom_curcde
			set @iba_untcst = @imu_bom_ftyprc
			-- 20081210 Mark Lau, changed from BP20 to BP10
			set @iba_fmlopt = 'B01'
			set @iba_bombasprc = @imu_bom_ftyprc*1.0
			set @iba_costing = 'N'
			set @iba_fcurcde = @imu_bcurcde
			set @iba_ftycst = @imu_bom_ftycst


	
			--print '_________________' + str(@imu_bom_ftyprc,13,4) + '___________' + str(@iba_bombasprc,13,4)
			
			if 
			(	
				select count(1) from IMBOMASS 
				where 
					iba_itmno = @ied_ucpno and 
					iba_assitm = @ibd_bomno and 
					iba_colcde = @ibd_colcde and 
					iba_typ = 'BOM'
			) > 0 			
			begin
				
				--print 'FOUND'
				------ Retrive Formula Information ----
				select 
					@iba_fmlopt  = iba_fmlopt, 
					@iba_costing = iba_costing
				from 
					IMBOMASS 
				where 
					iba_itmno =@ibd_ucpno and 
					iba_assitm = @ibd_bomno and
					iba_colcde = @ibd_colcde and 
					iba_typ = 'BOM'

				--------------------------------------------------------------
				select 
					@fml = yfi_fml 
				from 
					SYFMLINF 
				where 	
					yfi_fmlopt  = @iba_fmlopt  
	
				--- Update IM BOM Basic Price ---
	--			set @iba_bombasprc = @imu_bom_ftyprc
	--			set @iba_bombasprc = @imu_bom_ftyprc*1.0
	
				if ltrim(rtrim(@fml )) <> '' 
				begin
					while len(@fml) <> 0
					begin
						set @fml = ltrim(@fml)
						set @OP = substring(@fml,1,1)
						set @fml = substring(@fml, 2, len(@fml))
						------
						if (charindex('*', @fml) = 0 and charindex('/', @fml) = 0)
							set @end = len(@fml) + 1
						else if (charindex('*', @fml) = 0) 
							set @end = charindex('/', @fml)
						else if (charindex('/', @fml) = 0) 
							set @end = charindex('*', @fml)
						else
						begin
							if (charindex('*', @fml) < charindex('/', @fml)) 
								set @end = charindex('*', @fml)
							else
								set @end = charindex('/', @fml)
						end	-- charindex('*', @fml) = 0 and ....
						------
						set @temp = substring(@fml, 1, @end -1)			
						------
						if @OP = '*'
							set  @iba_bombasprc =  @iba_bombasprc * @temp
						else if @OP = '/' 
							set  @iba_bombasprc  =  @iba_bombasprc / @temp
						-----			
						set @fml = substring(@fml, @end, len(@fml))
					end	-- while len(@fml) <> 0
				end  -- if ltrim(rtrim(@fml )) <> '' 				
				--------------------------------------------------------------------------------------------------------------------------
				-- Existing BOM ITEM
			end -- if (select count(1) from IMBOMASS ... ) = 0
							
			if @ied_curcde = 'HKD' 
			BEGIN 
				if @ied_curcde = @iba_curcde
				begin
					if @iba_costing = 'Y'
						set @bomcst_af = @bomcst_af + (@iba_bombasprc * @iba_bomqty)
				end
				else
				begin
					If @iba_costing = 'Y'
	 					set @bomcst_af = @bomcst_af + ((@iba_bombasprc *  @iba_bomqty)  / @imu_selrat)				
			 	end -- if @ied_curcde = @iba_curcde
			END
			ELSE  -- if @ied_curcde = 'HKD' 
			BEGIN 
				if @ied_curcde = @iba_curcde
				begin
					if @iba_costing = 'Y'
						set @bomcst_af = @bomcst_af + (@iba_bombasprc * @iba_bomqty)
				end
				else
				begin	
					if @iba_costing = 'Y'
	 					set @bomcst_af = @bomcst_af + ((@iba_bombasprc* @iba_bomqty) * @imu_selrat)
			   	end
			END 	-- if @ied_curcde = 'HKD' 

			-------------------------------------------------------------------------------------
			---- Calculate BOM Price ----
			if @imu_bcurcde = 'HKD'    
			BEGIN 
				if  @iba_curcde = 'HKD'
				begin
					if @iba_costing = 'N'
						set @bomprc_af = @bomprc_af +(@iba_bombasprc * @iba_bomqty)
					
				end
				else   
				begin	
					if @iba_costing = 'N'
						set @bomprc_af = @bomprc_af + ((@iba_bombasprc *  @iba_bomqty) /@imu_selrat)
				end  -- @iba_curcde = 'HKD' 
			END  
			ELSE -- if @imu_bcurcde = 'HKD' , else mean imu_bcurcde = USD
			BEGIN 
				if  @iba_curcde = 'USD'
				begin
					if @iba_costing = 'N'
						set @bomprc_af = @bomprc_af + (@iba_bombasprc * @iba_bomqty)
				end
				else
				begin	
					if @iba_costing = 'N'
						set @bomprc_af = @bomprc_af + ((@iba_bombasprc * @iba_bomqty) * @imu_selrat)
				end
			END -- if @imu_bcurcde = 'HKD' 		
			
		end  -- if @ventyp = 'D'
	
	FETCH NEXT FROM cur_IMBOMEXDAT INTO 
		@ibd_cocde,	@ibd_ucpno,	@ibd_bomno,
		@ibd_colcde,	@ibd_qty,	@ibd_xlsfil,	
		@ibd_chkdat,	@ibd_untcde,	@ibd_conftr,
		@ibd_recseq,	@ibd_stage,	@ibd_veneml,	
		@ibd_malsts,	@ibd_sysmsg,	@ibd_venno,
		@ibd_credat,	@ibd_prdven
	End  -- OPEN cur_IMBOMEXDAT
	CLOSE cur_IMBOMEXDAT
	DEALLOCATE cur_IMBOMEXDAT

END -- if @ventyp = 'D'


/*

-------------------------- Calculate BOM Cost & BOM Price -------------
set @bomcst_af = 0
set @bomprc_af = 0
set @imu_selrat  = 0
set @imu_buyrat = 0		
set @iba_count = 0

select 	
	@imu_selrat = ysi_selrat ,
	@imu_buyrat = ysi_buyrat 
from 	
	SYSETINF (nolock)
where	
	ysi_typ = '06' and ysi_cde = @ied_curcde


-- Calculate FtyBOMCst
set @imu_ftybomcst_untcst = 0.0
set @imu_ftybomcst_ftycst = 0.0


DECLARE cur_calbom CURSOR
FOR	Select
		iba_costing,	iba_curcde,	iba_bomqty,
		iba_bombasprc,	iba_fcurcde,	iba_ftycst,
		iba_untcst
	From 
		IMBOMASS
	Where 
		iba_itmno = @ied_ucpno AND IBA_TYP = 'BOM'

OPEN cur_calbom
FETCH NEXT FROM cur_calbom INTO 
		@iba_costing,	@iba_curcde,	@iba_bomqty, 
		@iba_bombasprc, @iba_fcurcde, 	@iba_ftycst, 
		@iba_untcst

WHILE @@fetch_status = 0
BEGIN	
	
	if @bomqty = 0 
	begin
		set @bomqty = @iba_bomqty
	end

	---- Calculate BOM Cost ----
	if @ied_curcde = 'HKD' 
	BEGIN 
		if @ied_curcde = @iba_curcde
		begin
			if @iba_costing = 'Y'
				set @bomcst_af = @bomcst_af + (@iba_bombasprc * @bomqty)
	    	end
		else
		begin	
			if @iba_costing = 'Y'
					set @bomcst_af = @bomcst_af + ((@iba_bombasprc *  @bomqty)  / @imu_selrat)
	   	end
	END
	ELSE -- if @ied_curcde = 'HKD' , else mean not HKD
	BEGIN 
		if @ied_curcde = @iba_curcde
		begin
			if @iba_costing = 'Y'
				set @bomcst_af = @bomcst_af + (@iba_bombasprc * @bomqty)
		end
		else
		begin
			if @iba_costing = 'Y'
					set @bomcst_af = @bomcst_af + ((@iba_bombasprc* @bomqty) * @imu_selrat)
	   	end
	END -- if @ied_curcde = 'HKD' 
	-------------------------------------------------------------------------------------
	
	---- Calculate BOM Price ----
	if @imu_bcurcde = 'HKD'    
	BEGIN 
		if  @iba_curcde = 'HKD'
		begin
			if @iba_costing = 'N'
				set @bomprc_af = @bomprc_af +(@iba_bombasprc * @bomqty)
		end
		else
		begin	
			if @iba_costing = 'N'
				set @bomprc_af = @bomprc_af + ((@iba_bombasprc *  @bomqty) /@imu_selrat)
		end
	END
	ELSE	-- if @imu_bcurcde = 'HKD' , else mean <> HKD
	BEGIN 
		if  @iba_curcde = 'USD'
		begin
			if @iba_costing = 'N'
				set @bomprc_af = @bomprc_af + (@iba_bombasprc * @bomqty)
		end
		else
		begin	
			if @iba_costing = 'N'
				set @bomprc_af = @bomprc_af + ((@iba_bombasprc * @bomqty) * @imu_selrat)
		end
	END	-- if @imu_bcurcde = 'HKD' 


	-- Calculation of FtyBOMCst -- All change to HKD
	If @iba_curcde = 'USD' 
	begin
		set @imu_ftybomcst_untcst = @imu_ftybomcst_untcst + round(((@iba_untcst * @bomqty) / @imu_selrat), 4)
	end
	else
	begin
		set @imu_ftybomcst_untcst = @imu_ftybomcst_untcst + round((@iba_untcst * @bomqty), 4)
	end

	if @iba_fcurcde = 'USD'
	begin
		set @imu_ftybomcst_ftycst = @imu_ftybomcst_ftycst + round(((@iba_ftycst * @bomqty) / @imu_selrat),4)
	end
	else
	begin
		set @imu_ftybomcst_ftycst = @imu_ftybomcst_ftycst + round((@iba_ftycst * @bomqty),4)
	end

FETCH NEXT FROM cur_calbom INTO 
	@iba_costing, 		@iba_curcde, 		@iba_bomqty, 
	@iba_bombasprc, 	@iba_fcurcde, 		@iba_ftycst, 
	@iba_untcst
END	-- OPEN cur_calbom
CLOSE cur_calbom
DEALLOCATE cur_calbom
set @bomprc_af = round(@bomprc_af,4)
set @bomcst_af = round(@bomcst_af,4)
set @imu_ftybomcst_untcst = round(@imu_ftybomcst_untcst,4)
set @imu_ftybomcst_ftycst = round(@imu_ftybomcst_ftycst,4)

*/




--Calculate Basic Price START---for Design Vendor-----------------------------------------

if ltrim(rtrim(@lnecde)) <> ''
begin

--	select @imu_fmlopt_af = yaf_fmlopt, @fml = yaf_fml from SYCATFML 
--	where 	
--		yaf_lnecde = @lnecde and
--		yaf_catcde = @catlvl4

	Select 
		@ied_catlvl2 = ycr_catlvl2 
	from 
		SYCATREL 
	where 
		ycr_catlvl4 = ltrim(rtrim(@catlvl4))	
	
	
	select 
		@imu_fmlopt_af = yvf_fmlopt 
	from 
		SYVENFML 
	where
		yvf_venno = @ied_venno and
		yvf_catcde = @ied_catlvl2 and
		yvf_matcde = @matcde and
		yvf_def = 'Y' 		
	
	if @imu_fmlopt_af is NULL 
	begin
		if @itmtyp = 'BOM' 
		begin
			-- fmlopt B01 for BOM of External Factory
			set @imu_fmlopt_af = 'B01'
		end
	end
	else	
	begin
		Select @fml = yfi_fml from SYFMLINF where yfi_fmlopt = @imu_fmlopt_af
	end
end
else
begin
	set @imu_fmlopt_af = ''
	set @fml = "*1"
end

SET @fml = LTRIM(RTRIM(@fml))
SET @i  = 1

set @fml = replace(@fml, ' ','')

if (substring(@fml,1,1) <> '*') and (substring(@fml,1,1)<> '/')
begin
	set @fml = '*' + @fml
end
--- Assign Basic Price	---
set @itmprc_af = @ftyprc + @bomcst_af
set @imu_basprc_af = @itmprc_af

while len(@fml) <> 0
begin
	set @fml = ltrim(@fml)
	set @OP = substring(@fml,1,1)
	set @fml = substring(@fml, 2, len(@fml))
			
	if (charindex('*', @fml) = 0 and charindex('/', @fml) = 0)
	begin
		set @end = len(@fml) + 1
	end
	else if (charindex('*', @fml) = 0) 
	begin
		set @end = charindex('/', @fml)
	end
	else if (charindex('/', @fml) = 0) 
	begin
		set @end = charindex('*', @fml)
	end
	else
	begin
		if (charindex('*', @fml) < charindex('/', @fml)) 
		begin
			set @end = charindex('*', @fml)
		end
		else
		begin
			set @end = charindex('/', @fml)
		end
	end

	set @temp = substring(@fml, 1, @end -1)

	if @OP = '*'
	begin		
		set @imu_basprc_af = @imu_basprc_af * @temp
	end
	else if @OP = '/' 

	begin
		set @imu_basprc_af = @imu_basprc_af / @temp
	end
	
	set @fml = substring(@fml, @end, len(@fml))		
end

--- Answer plus currency conversion
set @imu_basprc_af = round(@imu_basprc_af * @imu_selrat,4)
set @imu_basprc_af = @imu_basprc_af + @bomprc_af





GO
GRANT EXECUTE ON [dbo].[sp_calc_extbasprc] TO [ERPUSER] AS [dbo]
GO
