/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_Q_upditm_wCust]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBASINF_Q_upditm_wCust]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_Q_upditm_wCust]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Lester Wu    
Date:		28th September, 2008
Description:	Select IM data for fty tmp #
***********************************************************************
*/

CREATE PROCEDURE [dbo].[sp_select_IMBASINF_Q_upditm_wCust] 


@ibi_cocde 	nvarchar(6),
@ibi_itmno	nvarchar(20),
@oriitmno	nvarchar(20)       ,
@qud_qutseq	int        ,
@imd_cus1no	nvarchar(20),
@imd_cus2no 	nvarchar(20),
@creusr	nvarchar(30)
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

--------------------------------------------

-- ******* Check for ALias Item or not **********
if (select count(*) from IMBASINF where  ibi_alsitmno = @ibi_itmno and ibi_itmsts <>'CLO') = 0


            if (select count(*) from IMBASINF where  ibi_itmno = @ibi_itmno and ibi_itmsts <>'CLO') = 1 

	begin
	
	select 			@oriitmno as 'qud_itmno',
			@qud_qutseq as 'qud_qutseq',
			ibi_itmno as 'vw_itmno',
			isnull(ibi_engdsc,'') as 'vw_engdsc',
			isnull(icf_colcde,'') as 'vw_colcde', 
			isnull(rtrim(ltrim(imd_untcde)) + '/' +  rtrim(ltrim(str(imd_inrqty))) + '/' +  rtrim(ltrim(str(imd_mtrqty))) ,'') as 'vw_pckunt',
			isnull(ibi_alsitmno,'') as 'ibi_alsitmno',
			isnull(ibi_alscolcde,'') as 'ibi_alscolcde',


			--Added by Mark Lau 20061109
			 'The matched item is in ' + case ibi_itmsts 	
							
							--when 'HLD' then 'Hold'
							when 'DIS' then  'Discontinued'
							--when 'INA' then 'Inactive'
							--when 'TBC' then 'To Be Confirmed '
							--when 'OLD' then 'Old Item'
					end + ' Status.' as 'Remarks',
			isnull(ibi_ftytmp,'') as 'vw_ftytmpitm',
			isnull(imd_basprc,0) as 'vw_basprc'
	from IMVENINF
	left join imbasinf on ibi_itmno = ivi_itmno
	left join imcolinf on ibi_itmno = icf_itmno
	left join IMMRKUP
		on 	 
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven 
	left join IMMRKUPDTL on imu_prdven = imd_prdven and imu_itmno = imd_itmno and imu_pckunt  = imd_untcde and imu_inrqty = imd_inrqty and imu_mtrqty = imd_mtrqty --and imu_conftr = imd_conftr

	left join VNBASINF 
		on 	
			ivi_venno = vbi_venno
	
	left join SYSETINF prc on
	prc.ysi_cocde = ' '
	and prc.ysi_cde = imu_prctrm and prc.ysi_typ = '03'

	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03'
	
	where	
		ivi_itmno = @ibi_itmno	and
		--imd_pckseq = @ipi_pckseq	and
		
		imd_ventyp = 'D'
		and imu_ventyp =
			(case vbi_ventyp when 'I' then 'P' 
				 when 'J' then 'P'
				else 'D' end)	

		and
		ivi_def = 'Y'		
		and imd_cus1no = @imd_cus1no and imd_cus2no = @imd_cus2no
	order by 	ivi_def desc, imd_ventyp desc, ivi_venno
         end
         else
         begin
	select 	@oriitmno as 'qud_itmno',
			@qud_qutseq as 'qud_qutseq',
			ibi_itmno as 'vw_itmno',
			isnull(ibi_engdsc,'') as 'vw_engdsc',
			isnull(icf_colcde,'') as 'vw_colcde', 
			isnull(rtrim(ltrim(imd_untcde)) + '/' +  rtrim(ltrim(str(imd_inrqty))) + '/' +  rtrim(ltrim(str(imd_mtrqty))) ,'') as 'vw_pckunt',
			isnull(ibi_alsitmno,'') as 'ibi_alsitmno',
			isnull(ibi_alscolcde,'') as 'ibi_alscolcde',


			--Added by Mark Lau 20061109
			 'The matched item is in ' + case ibi_itmsts 	
							
							--when 'HLD' then 'Hold'
							when 'DIS' then  'Discontinued'
							--when 'INA' then 'Inactive'
							--when 'TBC' then 'To Be Confirmed '
							--when 'OLD' then 'Old Item'
					end + ' Status.' as 'Remarks',
			isnull(ibi_ftytmp,'') as 'vw_ftytmpitm',
			isnull(imd_basprc,0) as 'vw_basprc'
	from IMVENINFH
	left join imbasinfH on ibi_itmno = ivi_itmno
	left join imcolinfH on ibi_itmno = icf_itmno
	
	left join IMMRKUPH
		on 	 
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven 
	left join IMMRKUPDTL on imu_prdven = imd_prdven and imu_itmno = imd_itmno and imu_pckunt  = imd_untcde and imu_inrqty = imd_inrqty and imu_mtrqty = imd_mtrqty --and imu_conftr = imd_conftr
	left join VNBASINF 
		on 	
			ivi_venno = vbi_venno

	left join SYSETINF prc on
	prc.ysi_cocde = ' ' 
	and prc.ysi_cde = imu_prctrm and prc.ysi_typ = '03'
	
	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03'
	
	where	
		ivi_itmno = @ibi_itmno	and
		--imd_pckseq = @ipi_pckseq	and
		imd_ventyp = 'D'
		and
		imu_ventyp = (case vbi_ventyp when 'I' then 'P' 
				 when 'J' then 'P'
				else 'D' end) and --
		ivi_def = 'Y'	
		and imd_cus1no = @imd_cus1no and imd_cus2no = @imd_cus2no
	order by 	ivi_def desc, imd_ventyp desc, ivi_venno
         end
else

begin
	select 	@oriitmno as 'qud_itmno',
			@qud_qutseq as 'qud_qutseq',
			ibi_itmno as 'vw_itmno',
			isnull(ibi_engdsc,'') as 'vw_engdsc',
			isnull(icf_colcde,'') as 'vw_colcde', 
			isnull(rtrim(ltrim(imd_untcde)) + '/' +  rtrim(ltrim(str(imd_inrqty))) + '/' +  rtrim(ltrim(str(imd_mtrqty))) ,'') as 'vw_pckunt',
			isnull(ibi_alsitmno,'') as 'ibi_alsitmno',
			isnull(ibi_alscolcde,'') as 'ibi_alscolcde',


			--Added by Mark Lau 20061109
			 'The matched item is in ' + case ibi_itmsts 	
							
							--when 'HLD' then 'Hold'
							when 'DIS' then  'Discontinued'
							--when 'INA' then 'Inactive'
							--when 'TBC' then 'To Be Confirmed '
							--when 'OLD' then 'Old Item'
					end + ' Status.' as 'Remarks',
			isnull(ibi_ftytmp,'') as 'vw_ftytmpitm',
			isnull(imd_basprc,0) as 'vw_basprc'
	from IMVENINF
	left join imbasinf on ibi_itmno = ivi_itmno
	left join imcolinf on ibi_itmno = icf_itmno
	left join IMMRKUP
		on 	 
			ivi_itmno = imu_itmno 	and 
			ivi_venno = imu_prdven 
	left join IMMRKUPDTL on imu_prdven = imd_prdven and imu_itmno = imd_itmno and imu_pckunt  = imd_untcde and imu_inrqty = imd_inrqty and imu_mtrqty = imd_mtrqty --and imu_conftr = imd_conftr
left join VNBASINF 
		on 	
			ivi_venno = vbi_venno

	left join SYSETINF  prc on
	prc.ysi_cocde = ' '
	and prc.ysi_cde = imu_prctrm and prc.ysi_typ = '03'
	left join SYSETINF  prcfty on prcfty.ysi_cocde = ' ' and prcfty.ysi_cde = imu_ftyprctrm and prcfty.ysi_typ = '03'
	
	where	
		 (select ivi_venitm from imveninf where ivi_itmno = @ibi_itmno and ivi_def = 'Y') = ivi_itmno	and
		
		--imd_pckseq = @ipi_pckseq	and
		imd_ventyp = 'D'
		and
		imd_ventyp = (case vbi_ventyp when 'I' then 'P' 
				 when 'J' then 'P'
				else 'D' end)	and
	
		ivi_def = 'Y'		
		and imd_cus1no = @imd_cus1no and imd_cus2no = @imd_cus2no
	order by 	ivi_def desc, imd_ventyp desc, ivi_venno
end



GO
GRANT EXECUTE ON [dbo].[sp_select_IMBASINF_Q_upditm_wCust] TO [ERPUSER] AS [dbo]
GO
