/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL_Vendor_P]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUOTNDTL_Vendor_P]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL_Vendor_P]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
















/*	Author : Tommy Ho	*/

/*********************************************************************************************************************************************************************
Modification History
*********************************************************************************************************************************************************************
Modified on		Modified by		Description
*********************************************************************************************************************************************************************
2005-03-10		Lester Wu		Use Vendor type instead of company code for data selection
2006-01-19		Lester Wu		Retrieve Factory Price Term
2006-02-09		Lester Wu		Add Factory Price Cost
2006-02-11		Lester Wu		For DV <> PV Set BOM Cost to Zero
2006-06-22		Marco Chan		Get Ftybomcst from imu_ftybomcst
*********************************************************************************************************************************************************************/


CREATE  PROCEDURE [dbo].[sp_select_QUOTNDTL_Vendor_P] 

@ivi_cocde 	nvarchar(6),
@ivi_itmno	nvarchar(20),
@ipi_untcde	nvarchar(6),
@ipi_inrqty	int,
@ipi_mtrqty	int,
--Added by Mark Lau 20070623

@ipi_conftr	numeric(9),
@creusr		nvarchar(30)

AS

--------------------------------------------
-- Lester Wu 2006-02-09
declare @TtlFtyCst  as numeric(9,4)
declare @Curr as varchar(6)
declare @selRate as numeric(16,11)

declare 
	@rate1 numeric (16,11),
	@iba_curcde varchar (6),
	@iba_untcst numeric(13,4),
	@iba_bomqty int

set @TtlFtyCst = 0
set @Curr = ''


-- AY Renark at 2006-03-10
	select @selRate = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'

--	select 
--		@TtlFtyCst = sum(iba_bomqty*iba_untcst) , 
--		@Curr = iba_curcde
--	from IMBOMASS 
--	where iba_itmno = @ivi_itmno
--	and iba_typ = 'BOM'
--	group by iba_curcde


	-- Get Exchange Rate --
	select @rate1 = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'
	----------------------------

/*
	DECLARE IMBOMASS_cursor CURSOR FOR 
		select iba_curcde, iba_bomqty, iba_untcst from imbomass  
		where iba_itmno = @ivi_itmno

	OPEN IMBOMASS_cursor 

	FETCH NEXT FROM IMBOMASS_cursor 
	INTO @iba_curcde, @iba_bomqty, @iba_untcst

	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		if @iba_curcde = 'USD'
			set @TtlFtyCst = @TtlFtyCst + ((@iba_bomqty * @iba_untcst) /  @rate1) 
		else
			set @TtlFtyCst = @TtlFtyCst + (@iba_bomqty * @iba_untcst) 

		FETCH NEXT FROM IMBOMASS_cursor 
		INTO @iba_curcde, @iba_bomqty, @iba_untcst

	END
	CLOSE IMBOMASS_cursor 
	DEALLOCATE IMBOMASS_cursor 
*/
	set  @Curr = 'HKD'



-- ******* Check for ALias Item or not **********
if (select count(*) from IMBASINF where  ibi_alsitmno = @ivi_itmno and ibi_itmsts <>'CLO') = 0

--if (select count(*) from IMBASINF where ibi_cocde = @ivi_cocde and ibi_itmno = @ivi_itmno) = 1 
if (select count(*) from IMBASINF where --ibi_cocde = @ivi_cocde and 
				ibi_itmno = @ivi_itmno and ibi_itmsts <>'CLO') = 1 

begin
	select 	ivi_def, 		ivi_venno, 	ivi_venitm, 
		imu_ventyp, 	imu_curcde,	vbi_ventyp,
		--(case ivi_cocde when 'ucpp' then
		(case vbi_ventyp when 'I' then 	
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
			        when 'J' then
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
		else
		--imu_ttlcst end) as 'imu_ftyprc',
		imu_ttlcst end)  + isnull(imu_ftybomcst,0)
		-- Lester Wu 2006-02-09, add Fty BOM Cost
--		case  when vbi_ventyp = 'E' then 0 else 		-- For External Item Set BOM Cost to Zero
--			case when imu_venno <> imu_prdven then 0 else	-- For DV <> PV Set BOM Cost to Zero
--				round(isnull(case @Curr when '' then 0 else 
--					case when @Curr = imu_curcde then @TtlFtyCst else 
--						case when imu_curcde = 'USD' then @TtlFtyCst*@selRate  else @TtlFtyCst /@selRate
--						end
--					end  
--				end,0),4)
--			end
--		end
		as 'imu_ftyprc',
		vbi_vensts,		imu_bcurcde,	imu_basprc,
		vbi_vensna,	
		(case vbi_ventyp when 'I' then 	
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
			        when 'J' then
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
		else
		--imu_ttlcst end) as 'imu_ftyprc',
		 imu_ftyprc end) as 'imu_ftycst',
		--Kenny Add on 04-10-2002
		isnull(imu_prctrm,'') + ' - ' + isnull(prc.ysi_dsc,'')  as 'imu_prctrm' , 
		-- Lester Wu 2006-01-19
		isnull(imu_ftyprctrm,'') + ' - ' + isnull(prcfty.ysi_dsc,'')  as 'imu_ftyprctrm'
	from IMVENINF
	left join IMMRKUP 
		on 	--ivi_cocde = imu_cocde 	and 
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven  --imu_venno
	left join VNBASINF 
		on 	--ivi_cocde = vbi_cocde 	and 
			ivi_venno = vbi_venno
	--Kenny Add on 04-10-2002
	left join SYSETINF  prc on
	--prc.ysi_cocde = ivi_cocde and 
		prc.ysi_cde = imu_prctrm and prc.ysi_typ = '03'
	-- Lester Wu 2006-01-19
	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03'
	
	where	--ivi_cocde = @ivi_cocde	and
		ivi_itmno = @ivi_itmno	and
		imu_pckunt = @ipi_untcde	and
		imu_inrqty = @ipi_inrqty	and
		imu_mtrqty = @ipi_mtrqty 	and
		--Added by Mark Lau 20070623
		imu_conftr = @ipi_conftr	and
		imu_ventyp = (case vbi_ventyp when 'E' --(case @ivi_cocde when 'ucp' 
				then 'D'  
			      else 'P' end)	and
		ivi_def = 'Y'		
		-- Lester Wu 2008-10-28
		and -- isnull(imu_std,'') <> 'N'	
		( select count(*) from immrkup where imu_itmno = @ivi_itmno and imu_pckunt = @ipi_untcde	and
		imu_inrqty = @ipi_inrqty	and
		imu_mtrqty = @ipi_mtrqty 	and
		imu_conftr = @ipi_conftr	
		and imu_ventyp = 'D' and imu_std = 'Y' ) > 0 
		
	order by 	ivi_def desc, imu_ventyp desc, ivi_venno
end
else
begin
	select 	ivi_def, 		ivi_venno, 	ivi_venitm, 
		imu_ventyp, 	imu_curcde,	vbi_ventyp,
		(case vbi_ventyp when 'I' then 	
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
			        when 'J' then
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
		else
		--imu_ttlcst end) as 'imu_ftyprc',
		imu_ttlcst end)  + isnull(imu_ftybomcst,0)
		-- Lester Wu 2006-02-09, add Fty BOM Cost
--		case vbi_ventyp when 'E' then 0 else 
--			case when imu_venno <> imu_prdven then 0 else	-- For DV <> PV Set BOM Cost to Zero
--				round(isnull(case @Curr when '' then 0 else 
--					case when @Curr = imu_curcde then @TtlFtyCst else 
--						case when imu_curcde = 'USD' then @TtlFtyCst*@selRate  else @TtlFtyCst /@selRate
--						end
--					end  
--				end,0),4)
--			end
--		end 
		as 'imu_ftyprc',
		--(case imu_negprc when 0  then imu_calftyprc 
		 --else imu_negprc end) as 'imu_ftyprc',
		vbi_vensts,		imu_bcurcde,	imu_basprc,
		vbi_vensna,
		(case vbi_ventyp when 'I' then 	
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
			        when 'J' then
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
		else
		imu_ftyprc end) as 'imu_ftycst',
		--(case imu_negprc when 0  then imu_calftyprc 
		 --else imu_negprc end) as 'imu_ftycst',
		--imu_ftyprc as 'imu_ftycst',
		--Kenny Add on 04-10-2002
		isnull(imu_prctrm,'') + ' - ' + isnull(prc.ysi_dsc,'')  as 'imu_prctrm' , 
		-- Lester Wu 2006-01-19
		isnull(imu_ftyprctrm,'') + ' - ' + isnull(prcfty.ysi_dsc,'')  as 'imu_ftyprctrm'
	from IMVENINFH
	left join IMMRKUPH 
		on 	--ivi_cocde = imu_cocde 	and 
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven  --imu_venno
	left join VNBASINF 
		on 	--ivi_cocde = vbi_cocde 	and 
			ivi_venno = vbi_venno
	--Kenny Add on 04-10-2002
	left join SYSETINF  prc on
	--prc.ysi_cocde = ivi_cocde and 
			prc.ysi_cde = imu_prctrm and prc.ysi_typ = '03'
	-- Lester Wu 2006-01-19
	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03'
	
	where	--ivi_cocde = @ivi_cocde	and
		ivi_itmno = @ivi_itmno	and
		imu_pckunt = @ipi_untcde	and
		imu_inrqty = @ipi_inrqty	and
		imu_mtrqty = @ipi_mtrqty 	and
		--Added by Mark Lau 20070623
		imu_conftr = @ipi_conftr	and
		imu_ventyp = (case vbi_ventyp when 'E' --(case @ivi_cocde when 'ucp' 
					then 'D'  
			      else 		'P' end)	and
		ivi_def = 'Y'	
		-- Lester Wu 2008-10-28
		and -- isnull(imu_std,'') <> 'N'	
		( select count(*) from immrkup where imu_itmno = @ivi_itmno and imu_pckunt = @ipi_untcde	and
		imu_inrqty = @ipi_inrqty	and
		imu_mtrqty = @ipi_mtrqty 	and
		imu_conftr = @ipi_conftr	
		and imu_ventyp = 'D' and imu_std = 'Y' ) > 0 
	order by 	ivi_def desc, imu_ventyp desc, ivi_venno
end
else
begin
	select 	ivi_def, 		ivi_venno, 	ivi_venitm, 
		imu_ventyp, 	imu_curcde,	vbi_ventyp,
		--(case ivi_cocde when 'ucpp' then 	
		(case vbi_ventyp when 'I'  then --(case @ivi_cocde when 'UCPP' then 	
				(case imu_negprc when 0  then imu_calftyprc 
				 else imu_negprc end)
			        when 'J' then 
				(case imu_negprc when 0  then imu_calftyprc 
				 else imu_negprc end)
		else
--		imu_ttlcst end) as 'imu_ftyprc',
		imu_ttlcst end)  + isnull(imu_ftybomcst,0)
		-- Lester Wu 2006-02-09, add Fty BOM Cost
--		case vbi_ventyp when 'E' then 0 else 
--			case when imu_venno <> imu_prdven then 0 else	-- For DV <> PV Set BOM Cost to Zero
--				round(isnull(case @Curr when '' then 0 else 
--					case when @Curr = imu_curcde then @TtlFtyCst else 
--						case when imu_curcde = 'USD' then @TtlFtyCst*@selRate  else @TtlFtyCst /@selRate
--						end
--					end  
--				end,0),4)
--			end 
--		end 
		as 'imu_ftyprc',


		vbi_vensts,		imu_bcurcde,	imu_basprc,
		vbi_vensna,
		(case vbi_ventyp when 'I' then 	
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
			        when 'J' then
				(case imu_negprc when 0  then imu_calftyprc 
			 	else imu_negprc end) 
		else
		imu_ftyprc end) as 'imu_ftycst',

		--imu_ftyprc as 'imu_ftycst',
		--Kenny Add on 04-10-2002
		isnull(imu_prctrm,'') + ' - ' + isnull(prc.ysi_dsc,'')  as 'imu_prctrm' , 
		-- Lester Wu 2006-01-19
		isnull(imu_ftyprctrm,'') + ' - ' + isnull(prcfty.ysi_dsc,'')  as 'imu_ftyprctrm'
	from IMVENINF
	left join IMMRKUP 
		on 	--ivi_cocde = imu_cocde 	and 
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven  --imu_venno
	left join VNBASINF 
		on 	--ivi_cocde = vbi_cocde 	and 
			ivi_venno = vbi_venno
	--Kenny Add on 04-10-2002
	left join SYSETINF  prc on
	prc.ysi_cocde = ' '  --ivi_cocde 
	and prc.ysi_cde = imu_prctrm and prc.ysi_typ = '03'
	
	-- Lester Wu 2006-01-19
	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03'
	
	where	--ivi_cocde = @ivi_cocde	and
		--ivi_itmno = @ivi_itmno	and
		 (select ivi_venitm from imveninf where ivi_itmno = @ivi_itmno) = ivi_itmno	and
		imu_pckunt = @ipi_untcde	and
		imu_inrqty = @ipi_inrqty	and
		imu_mtrqty = @ipi_mtrqty 	and
		--Added by Mark Lau 20070623
		imu_conftr = @ipi_conftr	and
		--Lester Wu 2005/03/10 Check Logic to use vendor type  instead of copany code
		--imu_ventyp = (case @ivi_cocde when 'ucp' then 'D'  
		--	      else 'P' end)	and
		imu_ventyp = (case vbi_ventyp when 'E' then 'D'  
			      else 'P' end)	and
		------------------------------------------------------------------------------------------------------
		ivi_def = 'Y'		
		-- Lester Wu 2008-10-28
		and --isnull(imu_std,'') <> 'N'	
		( select count(*) from immrkup where imu_itmno = @ivi_itmno and imu_pckunt = @ipi_untcde	and
		imu_inrqty = @ipi_inrqty	and
		imu_mtrqty = @ipi_mtrqty 	and
		imu_conftr = @ipi_conftr	
		and imu_ventyp = 'D' and imu_std = 'Y' ) > 0 
	order by 	ivi_def desc, imu_ventyp desc, ivi_venno
end



GO
GRANT EXECUTE ON [dbo].[sp_select_QUOTNDTL_Vendor_P] TO [ERPUSER] AS [dbo]
GO
