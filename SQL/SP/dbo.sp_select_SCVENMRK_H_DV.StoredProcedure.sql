/****** Object:  StoredProcedure [dbo].[sp_select_SCVENMRK_H_DV]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCVENMRK_H_DV]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCVENMRK_H_DV]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO















-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Kenny Chan
Date:		7th Jan, 2002
Description:	Select data From IMVENINF,IMMRKUP
Parameter:	1. Company
		2. ITEM NO.
************************************************************************
2003-10-15 Allan Yuen 	Fix select alias item's production vendor code.
2004-08-17 Allan Yuen 	User Anita request to change the logic of select item cost information
		 	for Internal & Joint Venture item. If Internal & Joint Venture item, 
			item cost must be same as calculated fty prc or negoliated fty prc.
2004-09-14 Allan Yuen	Add BOM Cost field.
2005-09-10 Allan Yuen	Fix cost information in Alias item 
2006-01-05 Allan Yuen	Add function to break down internal item cost with BOM cost including
2006-04-27 Marco Chan	Use imu_ftybomcst real storeage
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SCVENMRK_H_DV]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ivi_cocde 	nvarchar(6) ,
@ivi_itmno 	nvarchar(20),
@imu_pckunt 	nvarchar(6),
@imu_inrqty 	int,
@imu_mtrqty 	int,
@vendortype 	varchar(10),
@flag 		varchar(10)
---------------------------------------------- 
 
AS
declare @temp char(1), @AlsItm Char(1), @DV nvarchar(10), @tmp_vendortype 	varchar(10)-- DV is added by Mark Lau 20080820
set @tmp_vendortype = ''

SELECT 
	@vendortype = LTRIM(RTRIM(VBI_VENTYP))
FROM 
	IMBASINF 
	LEFT JOIN VNBASINF ON IBI_VENNO = VBI_VENNO
WHERE 
	IBI_ITMNO = @ivi_itmno

SELECT @TEMP = 
	CASE VBI_VENNO 
	WHEN '0005' THEN 'D'
	WHEN '0006' THEN 'D'
	WHEN '0007' THEN 'D'
	WHEN '0008' THEN 'D'
	WHEN '0009' THEN 'D'
	ELSE
		CASE  VBI_VENTYP  
		WHEN 'E' THEN 'D'
		WHEN 'I' THEN 'P'
		WHEN 'J' THEN 'P'
		END
	END,
      @AlsItm =
	CASE VBI_VENNO 
	WHEN '0005' THEN 'Y'
	WHEN '0006' THEN 'Y'
	WHEN '0007' THEN 'Y'
	WHEN '0008' THEN 'Y'
	WHEN '0009' THEN 'Y'
	ELSE
	'N'
	END
FROM 
	IMBASINFH
	LEFT JOIN IMVENINFH ON IVI_ITMNO = IBI_ITMNO  AND IVI_DEF = 'Y'
	LEFT JOIN VNBASINF ON  VBI_VENNO = IVI_VENNO
WHERE 
	IBI_ITMNO = @ivi_itmno 

-- Added by Mark Lau 20080820, Get DV
select @DV = imu_venno
from immrkuph(nolock)
where
imu_itmno = @ivi_itmno  and  
imu_ventyp = 'D' and 
imu_pckunt =@imu_pckunt and
imu_inrqty = @imu_inrqty and
imu_mtrqty=@imu_mtrqty

select @tmp_vendortype = vbi_ventyp
from vnbasinf (nolock)
where vbi_venno = @DV

if ( @tmp_vendortype <> '' )
begin
set @vendortype = @tmp_vendortype
end


if @flag = 0 
begin 
	IF @AlsItm = 'N' 
	begin
			Select 
				ivi_cocde,
				ivi_itmno,
				ivi_venitm,
				ivi_venno,
				isnull(vbi_vensna,'N/A') as 'vbi_vensna',
				ivi_def,
				ivi_subcde,
				ivi_creusr,
				ivi_updusr,
				ivi_upddat,
				imu_cocde,
				imu_itmno,
				imu_typ,
				imu_ventyp,
				imu_venno,
				isnull(imu_pckseq,0)as 'imu_pckseq',
				isnull(imu_pckunt,'N/A') as 'imu_pckunt',
				imu_inrqty,
				imu_mtrqty,
				imu_cft,
				-- Changed by Mark Lau 20090918
				--isnull(imu_curcde,'USD')as 'imu_curcde',
				isnull(imu_curcde,'HKD')as 'imu_curcde',
				imu_prctrm,
				imu_relatn,
				imu_fmlopt,
				isnull(imu_ftyprc,0) as 'imu_ftycst',
				case @temp 
					when 'P' then
						case imu_negprc when 0 then
							isnull(imu_calftyprc,0) 
						else
							isnull(imu_negprc,0)
						end 
					when 'D' then
						isnull(IMU_TTLCST,0)			
				end as 'imu_ftyprc' ,
	
				case @temp 
					when 'P' then
						case imu_negprc when 0 then
							isnull(imu_calftyprc,0) 
						else
							isnull(imu_negprc,0)
						end 
					when 'D' then
						isnull(imu_ftyprc,0) 			
				end as 'imu_calftyprc',	
			
				isnull(imu_bcurcde,'USD')as 'imu_bcurcde',
				imu_basprc,
				imu_negprc,
				imu_bomcst,
				imu_creusr,
				imu_updusr,
				imu_upddat,
				@vendortype as 'vendortype'
			from 
				IMVENINFH
				left join IMMRKUPH on 
						imu_itmno = ivi_itmno  and  
						ivi_venno = imu_prdven and 
						imu_ventyp = @temp and 
						imu_pckunt =@imu_pckunt and
						imu_inrqty = @imu_inrqty and
						imu_mtrqty=@imu_mtrqty				

				left join VNBASINF on ivi_venno = vbi_venno and vbi_vensts = 'A'
			where 
				ivi_itmno = @ivi_itmno 
				-- Added by Mark Lau 20080820
				and imu_prdven = @DV
			order by 
				ivi_venno
			
			---------------------------------------------------------- 
	end
	else
	BEGIN
			Select 
				ivi_cocde,
				ivi_itmno,
				ivi_venitm,
				ivi_venno,
				isnull(vbi_vensna,'N/A') as 'vbi_vensna',
				ivi_def,
				ivi_subcde,
				ivi_creusr,
				ivi_updusr,
				ivi_upddat,
				imu_cocde,
				imu_itmno,
				imu_typ,
				imu_ventyp,
				imu_venno,
				isnull(imu_pckseq,0)as 'imu_pckseq',
				isnull(imu_pckunt,'N/A') as 'imu_pckunt',
				imu_inrqty,
				imu_mtrqty,
				imu_cft,
				-- Changed by Mark Lau 20090918
				--isnull(imu_curcde,'USD')as 'imu_curcde',
				isnull(imu_curcde,'HKD')as 'imu_curcde',
				imu_prctrm,
				imu_relatn,
				imu_fmlopt,
				isnull(imu_ftyprc,0) as 'imu_ftycst',
				case imu_ventyp
					when 'P' then
						case imu_negprc when 0 then
							isnull(imu_calftyprc,0) 
						else
							isnull(imu_negprc,0)
						end 
					when 'D' then
						isnull(IMU_TTLCST,0)			
				end as 'imu_ftyprc' ,	
				case imu_ventyp
					when 'P' then
						case imu_negprc when 0 then
							isnull(imu_calftyprc,0) 
						else
							isnull(imu_negprc,0)
						end 
					when 'D' then
						isnull(imu_ftyprc,0) 			
				end as 'imu_calftyprc',	
	
				isnull(imu_bcurcde,'USD')as 'imu_bcurcde',
				imu_basprc,
				imu_negprc,
				imu_bomcst,
				imu_creusr,
				imu_updusr,
				imu_upddat,
				@vendortype as 'vendortype'
			from 
				IMBASINFH
				LEFT JOIN IMVENINFH ON 
						IVI_ITMNO = IBI_ITMNO
				left join IMMRKUPH on 
						imu_itmno = ivi_itmno and
						imu_prdven = ivi_venno  and 
						imu_pckunt =@imu_pckunt and
						imu_inrqty = @imu_inrqty and
						imu_mtrqty=@imu_mtrqty				
				left join VNBASINF on ivi_venno = vbi_venno and vbi_vensts = 'A'
			where 
				(IBI_ALSITMNO = @IVI_ITMNO  or IBI_ITMNO = @IVI_ITMNO  ) 
				AND 
				(
				    --- Alias Item ---
				    (IVI_VENNO IN ('0005','0006','0007','0008','0009') AND (LTRIM(RTRIM(VBI_VENTYP)) + LTRIM(RTRIM(IMU_VENTYP)) = 'ID'))  or
				    (IVI_VENNO IN ('0005','0006','0007','0008','0009') AND (LTRIM(RTRIM(VBI_VENTYP)) + LTRIM(RTRIM(IMU_VENTYP)) = 'JD')) or 			
			  	    (IVI_VENNO IN ('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z') AND (LTRIM(RTRIM(VBI_VENTYP)) + LTRIM(RTRIM(IMU_VENTYP)) = 'IP'))   or
				    (IVI_VENNO IN ('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z') AND (LTRIM(RTRIM(VBI_VENTYP)) + LTRIM(RTRIM(IMU_VENTYP)) = 'JP'))
				)
				-- Added by Mark Lau 20080820
				and imu_prdven = @DV
			order by 
				ivi_venno
	end
end
else
begin
-- New Logic --
	-- Get BOM Cost Information --
	declare 
	@ibi_curcde varchar(6),
	@rate numeric (16,11),
--	@imu_ftybomcst numeric (13,4),
	@iba_curcde varchar (6),
	@iba_untcst numeric(13,4),
	@iba_bomqty int

	-- Get Exchange Rate --
	select @rate = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'
	----------------------------
/*	IF @AlsItm = 'N' 
	begin
		-- Get Currency --
		select @ibi_curcde = imu_curcde from immrkuph where imu_itmno = @ivi_itmno 
		---------------------


		set @imu_ftybomcst = 0
	
		DECLARE IMBOMASS_cursor1 CURSOR FOR 
			select iba_curcde, iba_bomqty, iba_untcst from imbomassh  
			where iba_itmno = @ivi_itmno
	
		OPEN IMBOMASS_cursor1
	
		FETCH NEXT FROM IMBOMASS_cursor1
		INTO @iba_curcde, @iba_bomqty, @iba_untcst
	
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if @iba_curcde <> @ibi_curcde
			begin
				if @iba_curcde = 'HKD'
				begin
					set @imu_ftybomcst = @imu_ftybomcst + ((@iba_bomqty * @iba_untcst) *  @rate)
				end
				ELSE
				begin
					set @imu_ftybomcst = @imu_ftybomcst + ((@iba_bomqty * @iba_untcst) /  @rate)
				end
			end
			else
			begin
				set @imu_ftybomcst = @imu_ftybomcst + (@iba_bomqty * @iba_untcst)
			end
	
			FETCH NEXT FROM IMBOMASS_cursor1 
			INTO @iba_curcde, @iba_bomqty, @iba_untcst	
		END
		CLOSE IMBOMASS_cursor1
		DEALLOCATE IMBOMASS_cursor1 
	
		-- Round 
		set @imu_ftybomcst = round(@imu_ftybomcst ,4)
		---------------------------------------
	end
	else
	begin

		-- Get Currency --
		select @ibi_curcde = imu_curcde from immrkuph where imu_itmno = (select ibi_itmno  from imbasinfh where ibi_alsitmno = @ivi_itmno union select ibi_itmno  from imbasinf where ibi_alsitmno = @ivi_itmno)
		---------------------

		set @imu_ftybomcst = 0
	
		DECLARE IMBOMASS_cursor2 CURSOR FOR 
			select iba_curcde, iba_bomqty, iba_untcst from imbomassh  
			where iba_itmno = (select ibi_itmno  from imbasinfh where ibi_alsitmno = @ivi_itmno union select ibi_itmno  from imbasinf where ibi_alsitmno = @ivi_itmno)
	
		OPEN IMBOMASS_cursor2
	
		FETCH NEXT FROM IMBOMASS_cursor2 
		INTO @iba_curcde, @iba_bomqty, @iba_untcst
	
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if @iba_curcde <> @ibi_curcde
			begin
				if @iba_curcde = 'HKD'
				begin
					set @imu_ftybomcst = @imu_ftybomcst + ((@iba_bomqty * @iba_untcst) *  @rate)
				end
				ELSE
				begin
					set @imu_ftybomcst = @imu_ftybomcst + ((@iba_bomqty * @iba_untcst) /  @rate)
				end
			end
			else
			begin
				set @imu_ftybomcst = @imu_ftybomcst + (@iba_bomqty * @iba_untcst)
			end
	
			FETCH NEXT FROM IMBOMASS_cursor2 
			INTO @iba_curcde, @iba_bomqty, @iba_untcst	
		END
		CLOSE IMBOMASS_cursor2 
		DEALLOCATE IMBOMASS_cursor2 
	
		-- Round 
		set @imu_ftybomcst = round(@imu_ftybomcst ,4)
		---------------------------------------
	end
*/
	IF @AlsItm = 'N' 
	begin
			Select 
				ivi_cocde,
				ivi_itmno,
				ivi_venitm,
				ivi_venno,
				isnull(vbi_vensna,'N/A') as 'vbi_vensna',
				ivi_def,
				ivi_subcde,
				ivi_creusr,
				ivi_updusr,
				ivi_upddat,
				imu_cocde,
				imu_itmno,
				imu_typ,
				imu_ventyp,
				imu_venno,
				isnull(imu_pckseq,0)as 'imu_pckseq',
				isnull(imu_pckunt,'N/A') as 'imu_pckunt',
				imu_inrqty,
				imu_mtrqty,
				imu_cft,
				-- Changed by Mark Lau 20090918
				--isnull(imu_curcde,'USD')as 'imu_curcde',
				isnull(imu_curcde,'HKD')as 'imu_curcde',
				imu_prctrm,
				imu_relatn,
				imu_fmlopt,
				isnull(imu_ftyprc,0) as 'imu_ftycst',
				case @temp 
					when 'P' then
						case imu_negprc when 0 then
							isnull(imu_calftyprc,0) 
						else
							isnull(imu_negprc,0)
						end 
					when 'D' then
						isnull(IMU_TTLCST,0)			
				end as 'imu_ftyprc' ,
	
				case @temp 
					when 'P' then
						case imu_negprc when 0 then
							isnull(imu_calftyprc,0) 
						else
							isnull(imu_negprc,0)
						end 
					when 'D' then
						isnull(imu_ftyprc,0) 			
				end as 'imu_calftyprc',	
			
				isnull(imu_bcurcde,'USD')as 'imu_bcurcde',
				imu_basprc,
				imu_negprc,
				case 
					when @vendortype = 'E' then imu_bomcst
-- Marco Chan 2006-04-27
--					when @vendortype <> 'E' and imu_venno = imu_prdven then @imu_ftybomcst
--					else 0
					when @vendortype <> 'E' then imu_ftybomcst
				end as 'imu_bomcst',
				--imu_bomcst,
				imu_creusr,
				imu_updusr,
				imu_upddat,
				@vendortype as 'vendortype'
			from 
				IMVENINFH
				left join IMMRKUPH on 
						imu_itmno = ivi_itmno  and  
						ivi_venno = imu_prdven and 
						imu_ventyp = @temp and 
						imu_pckunt =@imu_pckunt and
						imu_inrqty = @imu_inrqty and
						imu_mtrqty=@imu_mtrqty
				left join VNBASINF on 
						ivi_venno = vbi_venno and 
						vbi_vensts = 'A'
			where 
				ivi_itmno = @ivi_itmno 
				-- Added by Mark Lau 20080820
				and imu_prdven = @DV
			order by 
				ivi_venno
			
	end
	else
	BEGIN
			Select 
				ivi_cocde,
				ivi_itmno,
				ivi_venitm,
				ivi_venno,
				isnull(vbi_vensna,'N/A') as 'vbi_vensna',
				ivi_def,
				ivi_subcde,
				ivi_creusr,
				ivi_updusr,
				ivi_upddat,
				imu_cocde,
				imu_itmno,
				imu_typ,
				imu_ventyp,
				imu_venno,
				isnull(imu_pckseq,0)as 'imu_pckseq',
				isnull(imu_pckunt,'N/A') as 'imu_pckunt',
				imu_inrqty,
				imu_mtrqty,
				imu_cft,
				-- Changed by Mark Lau 20090918
				--isnull(imu_curcde,'USD')as 'imu_curcde',
				isnull(imu_curcde,'HKD')as 'imu_curcde',
				imu_prctrm,
				imu_relatn,
				imu_fmlopt,
				isnull(imu_ftyprc,0) as 'imu_ftycst',
				case imu_ventyp
					when 'P' then
						case imu_negprc when 0 then
							isnull(imu_calftyprc,0) 
						else
							isnull(imu_negprc,0)
						end 
					when 'D' then
						isnull(IMU_TTLCST,0)			
				end as 'imu_ftyprc' ,
				case imu_ventyp
					when 'P' then
						case imu_negprc when 0 then
							isnull(imu_calftyprc,0) 
						else
							isnull(imu_negprc,0)
						end 
					when 'D' then
						isnull(imu_ftyprc,0) 			
				end as 'imu_calftyprc',	
	
				isnull(imu_bcurcde,'USD')as 'imu_bcurcde',
				imu_basprc,
				imu_negprc,
				case 
					when @vendortype = 'E' then imu_bomcst
-- Marco Chan 2006-04-27
--					when @vendortype <> 'E' and imu_venno = imu_prdven then @imu_ftybomcst
--					else 0
					when @vendortype <> 'E' then imu_ftybomcst
				end as 'imu_bomcst',
				--imu_bomcst,
				imu_creusr,
				imu_updusr,
				imu_upddat,
				@vendortype as 'vendortype'
			from 
				IMBASINFH
				LEFT JOIN IMVENINFH ON 
						IVI_ITMNO = IBI_ITMNO
				left join IMMRKUPH on 
						imu_itmno = ivi_itmno and
						imu_prdven = ivi_venno  and 
						imu_pckunt =@imu_pckunt and
						imu_inrqty = @imu_inrqty and
						imu_mtrqty=@imu_mtrqty
				left join VNBASINF on ivi_venno = vbi_venno and vbi_vensts = 'A'
			where 
				(IBI_ALSITMNO = @IVI_ITMNO  or IBI_ITMNO = @IVI_ITMNO  ) 
				AND 
				(
				    --- Alias Item ---
				    (IVI_VENNO IN ('0005','0006','0007','0008','0009') AND (LTRIM(RTRIM(VBI_VENTYP)) + LTRIM(RTRIM(IMU_VENTYP)) = 'ID'))  or
				    (IVI_VENNO IN ('0005','0006','0007','0008','0009') AND (LTRIM(RTRIM(VBI_VENTYP)) + LTRIM(RTRIM(IMU_VENTYP)) = 'JD')) or 			
			  	    (IVI_VENNO IN ('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z') AND (LTRIM(RTRIM(VBI_VENTYP)) + LTRIM(RTRIM(IMU_VENTYP)) = 'IP'))   or
				    (IVI_VENNO IN ('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z') AND (LTRIM(RTRIM(VBI_VENTYP)) + LTRIM(RTRIM(IMU_VENTYP)) = 'JP'))
				)
				-- Added by Mark Lau 20080820
				and imu_prdven = @DV
			order by 
				ivi_venno
	end
end







GO
GRANT EXECUTE ON [dbo].[sp_select_SCVENMRK_H_DV] TO [ERPUSER] AS [dbo]
GO
