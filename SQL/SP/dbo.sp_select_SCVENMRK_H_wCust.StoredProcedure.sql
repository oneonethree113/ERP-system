/****** Object:  StoredProcedure [dbo].[sp_select_SCVENMRK_H_wCust]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCVENMRK_H_wCust]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCVENMRK_H_wCust]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- It is based on sp_select_SCVENMRK_H
/********************************************************************************************************************
Modification History
********************************************************************************************************************
Modify on		Modify by		Description
********************************************************************************************************************
2008-12-16		Mark Lau		For getting fty price with specific customer 
********************************************************************************************************************/ 
CREATE procedure [dbo].[sp_select_SCVENMRK_H_wCust]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ivi_cocde 	nvarchar(6) ,
@ivi_itmno 	nvarchar(20),
@imu_pckunt 	nvarchar(6),
@imu_inrqty 	int,
@imu_mtrqty 	int,
@vendortype 	varchar(10),
@imd_cus1no	nvarchar(20),
@imd_cus2no	nvarchar(20),
@flag 		varchar(10)
---------------------------------------------- 
 
AS
declare @temp char(1), @AlsItm Char(1)

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



/*
select imd_itmno as 'itmno' , imd_untcde as 'untcde' , imd_inrqty as 'inrqty' ,imd_mtrqty as 'mtrqty' ,imd_conftr as 'conftr',
isnull(imd_ventyp,'') as 'ventyp' ,isnull(imd_venno,'') as 'venno' ,isnull(imd_prdven,'') as 'prdven' , isnull( imd_cus1no,'') as 'cus1no', isnull( imd_cus2no,'') as 'cus2no'
into #temp_immrkupdtl 
from immrkupdtl (nolock)
where
imd_itmno = @ivi_itmno	and
imd_untcde = @imu_pckunt and
imd_inrqty = @imu_inrqty	and 	
imd_mtrqty = @imu_mtrqty 	and
imd_ventyp = 'D' and 
imd_cus1no = @imd_cus1no and
imd_cus2no = @imd_cus2no
*/

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
				imd_cocde,
				imd_itmno,
				imd_typ,
				imd_ventyp,
				imd_venno,
				isnull(imd_pckseq,0)as 'imu_pckseq',
				isnull(imd_untcde,'N/A') as 'imu_pckunt',
				imd_inrqty,
				imd_mtrqty,
				imu_cft,
				-- Changed by Mark Lau 20090918
				--isnull(imd_curcde,'USD')as 'imu_curcde',
				isnull(imd_curcde,'HKD')as 'imu_curcde',
				imd_prctrm,
				imu_relatn,
				imd_fmlopt,
				isnull(imd_icttl,0) as 'imu_ftycst',
				case @temp 
					when 'P' then
						case imp_negprc when 0 then
							isnull(imp_calftyprc,0) 
						else
							isnull(imp_negprc,0)
						end 
					when 'D' then
						isnull(IMd_icttl,0)			
				end as 'imu_ftyprc' ,
	
				case @temp 
					when 'P' then
						case imp_negprc when 0 then
							isnull(imp_calftyprc,0) 
						else
							isnull(imp_negprc,0)
						end 
					when 'D' then
						isnull(imd_icttl,0) 			
				end as 'imu_calftyprc',	
			
				isnull(imd_bcurcde,'USD')as 'imu_bcurcde',
				imd_basprc,
				imp_negprc as 'imu_negprc',
				imd_icD,
				imd_creusr,
				imd_updusr,
				imd_upddat
			from 
				IMVENINFH
				left join IMMRKUPH on 
						imu_itmno = ivi_itmno  and  
						ivi_venno = imu_prdven and 
						imu_ventyp = @temp and 
						imu_pckunt =@imu_pckunt and
						imu_inrqty = @imu_inrqty and
						imu_mtrqty=@imu_mtrqty				
				left join immrkupdtl on 
						imu_itmno = imd_itmno  and  
						imu_venno = imd_venno and 
						--imu_ventyp = @temp and 
						imu_pckunt =imd_untcde and
						imu_inrqty = imd_inrqty and
						imu_mtrqty=imd_mtrqty		and
						imu_conftr = imd_conftr	
				left join immrkupdtlpv on 
						imp_itmno = imd_itmno  and  
						--imu_prdven = imd_prdven and 
						imp_venno = imd_venno and
						--imu_ventyp = @temp and 
						imp_untcde =imd_untcde and
						imp_inrqty = imd_inrqty and
						imp_mtrqty=imd_mtrqty		and
						imp_conftr = imd_conftr	and
						imp_cus1no = imd_cus1no and
						imp_cus2no = imd_cus2no

				left join VNBASINF on ivi_venno = vbi_venno and vbi_vensts = 'A'
			where 
				ivi_itmno = @ivi_itmno 
				and isnull(imd_cus1no,'') = @imd_cus1no and isnull(imd_cus2no,'') = @imd_cus2no and imu_prdven = imp_prdven
/*
union
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
				isnull(imu_curcde,'USD')as 'imu_curcde',
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
				imu_upddat
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
*/
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
				imd_cocde,
				imd_itmno,
				imd_typ,
				imd_ventyp,
				imd_venno,
				isnull(imd_pckseq,0)as 'imu_pckseq',
				isnull(imd_untcde,'N/A') as 'imu_pckunt',
				imd_inrqty,
				imd_mtrqty,
				imu_cft,
				-- Changed by Mark Lau 20090918
				--isnull(imd_curcde,'USD')as 'imu_curcde',
				isnull(imd_curcde,'HKD')as 'imu_curcde',
				imd_prctrm,
				imu_relatn,
				imd_fmlopt,
				isnull(imd_icttl,0) as 'imu_ftycst',
				case imd_ventyp
					when 'P' then
						case imp_negprc when 0 then
							isnull(imp_calftyprc,0) 
						else
							isnull(imp_negprc,0)
						end 
					when 'D' then
						isnull(IMd_icttl,0)			
				end as 'imu_ftyprc' ,	
				case imd_ventyp
					when 'P' then
						case imp_negprc when 0 then
							isnull(imp_calftyprc,0) 
						else
							isnull(imp_negprc,0)
						end 
					when 'D' then
						isnull(imd_icttl,0) 			
				end as 'imu_calftyprc',	
	
				isnull(imd_bcurcde,'USD')as 'imu_bcurcde',
				imd_basprc,
				imp_negprc as 'imu_negprc',
				imd_icD,
				imd_creusr,
				imd_updusr,
				imd_upddat
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
				left join immrkupdtl on 
						imu_itmno = imd_itmno  and  
						imu_venno = imd_venno and 
						--imu_ventyp = @temp and 
						imu_pckunt =imd_untcde and
						imu_inrqty = imd_inrqty and
						imu_mtrqty=imd_mtrqty		and
						imu_conftr = imd_conftr		
				left join immrkupdtlpv on 
						imp_itmno = imd_itmno  and  
						--imu_prdven = imd_prdven and 
						imp_venno = imd_venno and
						--imu_ventyp = @temp and 
						imp_untcde =imd_untcde and
						imp_inrqty = imd_inrqty and
						imp_mtrqty=imd_mtrqty		and
						imp_conftr = imd_conftr		and
						imp_cus1no = imd_cus1no and
						imp_cus2no = imd_cus2no
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
				and isnull(imd_cus1no,'') = @imd_cus1no and isnull(imd_cus2no,'') = @imd_cus2no and imu_prdven = imp_prdven
/*
union
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
				isnull(imu_curcde,'USD')as 'imu_curcde',
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
				imu_upddat
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
*/
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
				imd_cocde,
				imd_itmno,
				imd_typ,
				imd_ventyp,
				imd_venno,
				isnull(imd_pckseq,0)as 'imu_pckseq',
				isnull(imd_untcde,'N/A') as 'imu_pckunt',
				imd_inrqty,
				imd_mtrqty,
				imu_cft,
				-- Changed by Mark Lau 20090918
				--isnull(imd_curcde,'USD')as 'imu_curcde',
				isnull(imd_curcde,'HKD')as 'imu_curcde',
				imd_prctrm,
				imu_relatn,
				imd_fmlopt,
				isnull(imd_icttl,0) as 'imu_ftycst',
				case @temp 
					when 'P' then
						case imp_negprc when 0 then
							isnull(imp_calftyprc,0) 
						else
							isnull(imp_negprc,0)
						end 
					when 'D' then
						isnull(IMd_icttl,0)			
				end as 'imu_ftyprc' ,
	
				case @temp 
					when 'P' then
						case imp_negprc when 0 then
							isnull(imp_calftyprc,0) 
						else
							isnull(imp_negprc,0)
						end 
					when 'D' then
						isnull(imd_icttl,0) 			
				end as 'imu_calftyprc',	
			
				isnull(imd_bcurcde,'USD')as 'imu_bcurcde',
				imd_basprc,
				imp_negprc as 'imu_negprc',
				case 
					when @vendortype = 'E' then imd_icD
-- Marco Chan 2006-04-27
--					when @vendortype <> 'E' and imu_venno = imu_prdven then @imu_ftybomcst
--					else 0
					when @vendortype <> 'E' then imd_icD
				end as 'imu_bomcst',
				--imu_bomcst,
				imd_creusr,
				imd_updusr,
				imd_upddat
			from 
				IMVENINFH
				left join IMMRKUPH on 
						imu_itmno = ivi_itmno  and  
						ivi_venno = imu_prdven and 
						imu_ventyp = @temp and 
						imu_pckunt =@imu_pckunt and
						imu_inrqty = @imu_inrqty and
						imu_mtrqty=@imu_mtrqty
				left join immrkupdtl on 
						imu_itmno = imd_itmno  and  
						imu_venno = imd_venno and  
						--imu_ventyp = @temp and 
						imu_pckunt =imd_untcde and
						imu_inrqty = imd_inrqty and
						imu_mtrqty=imd_mtrqty		and
						imu_conftr = imd_conftr	
				left join immrkupdtlpv on 
						imp_itmno = imd_itmno  and  
						--imu_prdven = imd_prdven and 
						imp_venno = imd_venno and
						--imu_ventyp = @temp and 
						imp_untcde =imd_untcde and
						imp_inrqty = imd_inrqty and
						imp_mtrqty=imd_mtrqty		and
						imp_conftr = imd_conftr		and
						imp_cus1no = imd_cus1no and
						imp_cus2no = imd_cus2no
				left join VNBASINF on 
						ivi_venno = vbi_venno and 
						vbi_vensts = 'A'
			where 
				ivi_itmno = @ivi_itmno 
				and isnull(imd_cus1no,'') = @imd_cus1no and isnull(imd_cus2no,'') = @imd_cus2no and imu_prdven = imp_prdven
/*
union
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
				isnull(imu_curcde,'USD')as 'imu_curcde',
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
				imu_upddat
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
*/
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
				imd_cocde,
				imd_itmno,
				imd_typ,
				imd_ventyp,
				imd_venno,
				isnull(imd_pckseq,0)as 'imu_pckseq',
				isnull(imd_untcde,'N/A') as 'imu_pckunt',
				imd_inrqty,
				imd_mtrqty,
				imu_cft,
				-- Changed by Mark Lau 20090918
				--isnull(imd_curcde,'USD')as 'imu_curcde',
				isnull(imd_curcde,'HKD')as 'imu_curcde',
				imd_prctrm,
				imu_relatn,
				imd_fmlopt,
				isnull(imd_icttl,0) as 'imu_ftycst',
				case imd_ventyp
					when 'P' then
						case imp_negprc when 0 then
							isnull(imp_calftyprc,0) 
						else
							isnull(imp_negprc,0)
						end 
					when 'D' then
						isnull(IMd_icttl,0)			
				end as 'imu_ftyprc' ,
				case imd_ventyp
					when 'P' then
						case imp_negprc when 0 then
							isnull(imp_calftyprc,0) 
						else
							isnull(imp_negprc,0)
						end 
					when 'D' then
						isnull(imd_icttl,0) 			
				end as 'imu_calftyprc',	
	
				isnull(imd_bcurcde,'USD')as 'imu_bcurcde',
				imd_basprc,
				imp_negprc as 'imu_negprc',
				case 
					when @vendortype = 'E' then imd_icD
-- Marco Chan 2006-04-27
--					when @vendortype <> 'E' and imu_venno = imu_prdven then @imu_ftybomcst
--					else 0
					when @vendortype <> 'E' then imd_icD
				end as 'imu_bomcst',
				--imu_bomcst,
				imd_creusr,
				imd_updusr,
				imd_upddat

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
				left join immrkupdtl on 
						imu_itmno = imd_itmno  and  
						imu_venno = imd_venno and  
						--imu_ventyp = @temp and 
						imu_pckunt =imd_untcde and
						imu_inrqty = imd_inrqty and
						imu_mtrqty=imd_mtrqty		and
						imu_conftr = imd_conftr	
				left join immrkupdtlpv on 
						imp_itmno = imd_itmno  and  
						--imu_prdven = imd_prdven and 
						imp_venno = imd_venno and
						--imu_ventyp = @temp and 
						imp_untcde =imd_untcde and
						imp_inrqty = imd_inrqty and
						imp_mtrqty=imd_mtrqty		and
						imp_conftr = imd_conftr		and
						imp_cus1no = imd_cus1no and
						imp_cus2no = imd_cus2no
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
				and isnull(imd_cus1no,'') = @imd_cus1no and isnull(imd_cus2no,'') = @imd_cus2no and imu_prdven = imp_prdven
/*
union
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
				isnull(imu_curcde,'USD')as 'imu_curcde',
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
				imu_upddat
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
*/
			order by 
				ivi_venno
	end
end

--drop table #temp_immrkupdtl



GO
GRANT EXECUTE ON [dbo].[sp_select_SCVENMRK_H_wCust] TO [ERPUSER] AS [dbo]
GO
