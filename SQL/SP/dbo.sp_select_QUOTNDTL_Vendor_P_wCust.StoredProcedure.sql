/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL_Vendor_P_wCust]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUOTNDTL_Vendor_P_wCust]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL_Vendor_P_wCust]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












-- It is based on sp_select_QUOTNDTL_Vendor_P
/********************************************************************************************************************
Modification History
********************************************************************************************************************
Modify on		Modify by		Description
********************************************************************************************************************
2008-10-28		Lester Wu		For getting price with customer 
********************************************************************************************************************/

CREATE  PROCEDURE [dbo].[sp_select_QUOTNDTL_Vendor_P_wCust] 

@ivi_cocde 	nvarchar(6),
@ivi_itmno	nvarchar(20),
@ipi_untcde	nvarchar(6),
@ipi_inrqty	int,
@ipi_mtrqty	int,
@ipi_conftr	numeric(9),
@imd_cus1no	nvarchar(20),
@imd_cus2no 	nvarchar(20),
@creusr		nvarchar(30)

AS

--------------------------------------------

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



	select @selRate = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'

	-- Get Exchange Rate --
	select @rate1 = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'
	----------------------------


	set  @Curr = 'HKD'



-- ******* Check for ALias Item or not **********
if (select count(*) from IMBASINF where  ibi_alsitmno = @ivi_itmno and ibi_itmsts <>'CLO') = 0

--if (select count(*) from IMBASINF where ibi_cocde = @ivi_cocde and ibi_itmno = @ivi_itmno) = 1 
if (select count(*) from IMBASINF where --ibi_cocde = @ivi_cocde and 
				ibi_itmno = @ivi_itmno and ibi_itmsts <>'CLO') = 1 

begin
	select 	ivi_def, 		ivi_venno, 	ivi_venitm, 
		imd_ventyp as 'imu_ventyp', 	imd_curcde as 'imu_curcde',	vbi_ventyp,
		--(case ivi_cocde when 'ucpp' then
		(case vbi_ventyp when 'I' then 	
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
			        when 'J' then
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
		else
		--imu_ttlcst end) as 'imu_ftyprc',
		imd_icttl end)  + isnull(imd_icD,0)

		as 'imu_ftyprc',
		vbi_vensts,		imd_bcurcde as 'imu_bcurcde',	imd_basprc as 'imu_basprc',
		vbi_vensna,	
		(case vbi_ventyp when 'I' then 	
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
			        when 'J' then
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
		else

		 imd_fcttl end) as 'imu_ftycst',

		isnull(imd_prctrm,'') + ' - ' + isnull(prc.ysi_dsc,'')  as 'imu_prctrm' , 

		isnull(imu_ftyprctrm,'') + ' - ' + isnull(prcfty.ysi_dsc,'')  as 'imu_ftyprctrm'
	from IMVENINF
	left join IMMRKUP 
		on 	 
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven  
	left join IMMRKUPDTL on imu_venno = imd_venno and imu_itmno = imd_itmno and imu_pckunt  = imd_untcde and imu_inrqty = imd_inrqty and imu_mtrqty = imd_mtrqty and imu_conftr = imd_conftr
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
	left join VNBASINF 
		on 	 
			ivi_venno = vbi_venno

	left join SYSETINF  prc on
		prc.ysi_cde = imd_prctrm and prc.ysi_typ = '03'
	-- Lester Wu 2006-01-19
	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03'
	
	where	
		ivi_itmno = @ivi_itmno	and
		imd_untcde = @ipi_untcde	and
		imd_inrqty = @ipi_inrqty	and
		imd_mtrqty = @ipi_mtrqty 	and
		--Added by Mark Lau 20070623
		--imd_conftr = @ipi_conftr	and
		imd_ventyp = 'D'		and
		imu_ventyp = (case vbi_ventyp when 'E' 
				then 'D'  
			      else 'P' end)	and
		ivi_def = 'Y'		
		and imd_cus1no = @imd_cus1no and imd_cus2no = @imd_cus2no  and imu_prdven = imp_prdven 
	order by 	ivi_def desc, imd_ventyp desc, ivi_venno
end
else
begin
	select 	ivi_def, 		ivi_venno, 	ivi_venitm, 
		imd_ventyp as 'imu_ventyp', 	imd_curcde as 'imu_curcde',	vbi_ventyp,
		(case vbi_ventyp when 'I' then 	
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
			        when 'J' then
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
		else

		imd_icttl end)  + isnull(imd_icD,0)

		as 'imu_ftyprc',

		vbi_vensts,		imd_bcurcde as 'imu_bcurcde',	imd_basprc as 'imu_basprc',
		vbi_vensna,
		(case vbi_ventyp when 'I' then 	
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
			        when 'J' then
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
		else
		imd_fcttl end) as 'imu_ftycst',
		isnull(imd_prctrm,'') + ' - ' + isnull(prc.ysi_dsc,'')  as 'imu_prctrm' , 
		isnull(imu_ftyprctrm,'') + ' - ' + isnull(prcfty.ysi_dsc,'')  as 'imu_ftyprctrm'
	from IMVENINFH
	left join IMMRKUPH 
		on 	
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven 
	left join IMMRKUPDTL on imu_venno = imd_venno and imu_itmno = imd_itmno and imu_pckunt  = imd_untcde and imu_inrqty = imd_inrqty and imu_mtrqty = imd_mtrqty and imu_conftr = imd_conftr
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
	left join VNBASINF 
		on 	
			ivi_venno = vbi_venno

	left join SYSETINF  prc on
 
			prc.ysi_cde = imd_prctrm and prc.ysi_typ = '03'

	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03' 
	
	where	
		ivi_itmno = @ivi_itmno	and
		imd_untcde = @ipi_untcde	and
		imd_inrqty = @ipi_inrqty	and
		imd_mtrqty = @ipi_mtrqty 	and
		--Added by Mark Lau 20070623
		--imu_conftr = @ipi_conftr	and
		imd_ventyp = 'D' and 
		imu_ventyp = (case vbi_ventyp when 'E' 
					then 'D'  
			      else 		'P' end)	and
		ivi_def = 'Y'	
		and imd_cus1no = @imd_cus1no and imd_cus2no = @imd_cus2no  and imu_prdven = imp_prdven 
	order by 	ivi_def desc, imd_ventyp desc, ivi_venno
end
else
begin
	select 	ivi_def, 		ivi_venno, 	ivi_venitm, 
		imd_ventyp as 'imu_ventyp', 	imd_curcde as 'imu_curcde',	vbi_ventyp,
	
		(case vbi_ventyp when 'I'  then  	
				(case imd_negprc when 0  then imd_calftyprc 
				 else imd_negprc end)
			        when 'J' then 
				(case imd_negprc when 0  then imd_calftyprc 
				 else imd_negprc end)
		else

		imd_icttl end) + isnull(imd_icD,0)
	
		as 'imu_ftyprc',


		vbi_vensts,		imd_bcurcde as 'imu_bcurcde',	imd_basprc as 'imu_basprc',
		vbi_vensna,
		(case vbi_ventyp when 'I' then 	
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
			        when 'J' then
				(case imd_negprc when 0  then imd_calftyprc 
			 	else imd_negprc end) 
		else
		imd_fcttl end) as 'imu_ftycst',

		isnull(imd_prctrm,'') + ' - ' + isnull(prc.ysi_dsc,'')  as 'imu_prctrm' , 
		isnull(imu_ftyprctrm,'') + ' - ' + isnull(prcfty.ysi_dsc,'')  as 'imu_ftyprctrm'
	from IMVENINF
	left join IMMRKUP 
		on 	 
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven  
	left join IMMRKUPDTL on imu_venno = imd_venno and imu_itmno = imd_itmno and imu_pckunt  = imd_untcde and imu_inrqty = imd_inrqty and imu_mtrqty = imd_mtrqty and imu_conftr = imd_conftr
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
	left join VNBASINF 
		on 	
			ivi_venno = vbi_venno

	left join SYSETINF  prc on
	prc.ysi_cocde = ' '   
	and prc.ysi_cde = imd_prctrm and prc.ysi_typ = '03'
	

	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03'
	
	where	
		 (select ivi_venitm from imveninf where ivi_itmno = @ivi_itmno) = ivi_itmno	and
		imd_untcde = @ipi_untcde	and
		imd_inrqty = @ipi_inrqty	and
		imd_mtrqty = @ipi_mtrqty 	and
		--Added by Mark Lau 20070623
		--imu_conftr = @ipi_conftr	and

		imd_ventyp = 'D'
		and
		imu_ventyp = (case vbi_ventyp when 'E' then 'D'  
			      else 'P' end)	and
		------------------------------------------------------------------------------------------------------
		ivi_def = 'Y'		
		and imd_cus1no = @imd_cus1no and imd_cus2no = @imd_cus2no  and imu_prdven = imp_prdven 

	order by 	ivi_def desc, imd_ventyp desc, ivi_venno
end



GO
GRANT EXECUTE ON [dbo].[sp_select_QUOTNDTL_Vendor_P_wCust] TO [ERPUSER] AS [dbo]
GO
