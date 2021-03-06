/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_Q_upditm_wCust2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBASINF_Q_upditm_wCust2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_Q_upditm_wCust2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/************************************************************************
Author:		Carlos Lui
Date:		06-17-2012
Description:	Select IM data for fty tmp #
***********************************************************************
*/

CREATE  PROCEDURE [dbo].[sp_select_IMBASINF_Q_upditm_wCust2] 

@ibi_cocde 	nvarchar(6),
@ibi_itmno	nvarchar(20),
@oriitmno		nvarchar(20),
@qud_qutseq	int,
@ipi_pckunt	nvarchar(6),
@ipi_inrqty	int,
@ipi_mtrqty	int,
@ipi_conftr	numeric(9),
@imu_cus1no	nvarchar(20),
@imu_cus2no 	nvarchar(20),
@creusr		nvarchar(30)

AS

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

set  @Curr = 'HKD'

-- ******* Check for ALias Item or not **********
if (select count(*) from IMBASINF where  ibi_alsitmno = @ibi_itmno and ibi_itmsts <>'CLO') = 0
            if (select count(*) from IMBASINF where  ibi_itmno = @ibi_itmno and ibi_itmsts <>'CLO') = 1 
	begin
	
	select		@oriitmno as 'qud_itmno',
			@qud_qutseq as 'qud_qutseq',
			ibi_itmno as 'vw_itmno',
			isnull(ibi_engdsc,'') as 'vw_engdsc',
			isnull(icf_colcde,'') as 'vw_colcde', 
			isnull(rtrim(ltrim(imu_pckunt)) + '/' +  rtrim(ltrim(str(imu_inrqty))) + '/' +  rtrim(ltrim(str(imu_mtrqty))) ,'') as 'vw_pckunt',
			isnull(ibi_alsitmno,'') as 'ibi_alsitmno',
			isnull(ibi_alscolcde,'') as 'ibi_alscolcde',
			'The matched item is in ' + case ibi_itmsts 	
					when 'DIS' then  'Discontinued'
					end + ' Status.' as 'Remarks',
			isnull(ibi_ftytmp,'') as 'vw_ftytmpitm',
			isnull(imu_basprc,0) as 'vw_basprc'
	from IMVENINF
	left join imbasinf on		ibi_itmno = ivi_itmno
	left join imcolinf on		ibi_itmno = icf_itmno
	left join imprcinf on 	 	ivi_itmno = imu_itmno 	and 
				ivi_venno = imu_prdven 
	left join VNBASINF on	ivi_venno = vbi_venno
	left join SYSETINF prc on	prc.ysi_cocde = ' '		and
				prc.ysi_cde = imu_hkprctrm	and
				prc.ysi_typ = '03'
	left join SYSETINF prcfty on	prcfty.ysi_cocde = ' '		and
				prcfty.ysi_cde = imu_ftyprctrm	and
				prcfty.ysi_typ = '03'
	where	ivi_itmno = @ibi_itmno				and
		ivi_def = 'Y'					and 
--		imu_status = 'ACT'					and
		imu_pckunt = @ipi_pckunt				and
		imu_inrqty = @ipi_inrqty				and
		imu_mtrqty = @ipi_mtrqty				--and
--		imu_conftr = @ipi_conftr				and
--		imu_cus1no = @imu_cus1no				and
--		imu_cus2no = @imu_cus2no				and
--		imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--		imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)
	order by 	ivi_def desc, imu_ventyp desc, ivi_venno
         end
         else
         begin
	select 		@oriitmno as 'qud_itmno',
			@qud_qutseq as 'qud_qutseq',
			ibi_itmno as 'vw_itmno',
			isnull(ibi_engdsc,'') as 'vw_engdsc',
			isnull(icf_colcde,'') as 'vw_colcde', 
			isnull(rtrim(ltrim(imu_pckunt)) + '/' +  rtrim(ltrim(str(imu_inrqty))) + '/' +  rtrim(ltrim(str(imu_mtrqty))) ,'') as 'vw_pckunt',
			isnull(ibi_alsitmno,'') as 'ibi_alsitmno',
			isnull(ibi_alscolcde,'') as 'ibi_alscolcde',
			'The matched item is in ' + case ibi_itmsts 	
					when 'DIS' then  'Discontinued'
					end + ' Status.' as 'Remarks',
			isnull(ibi_ftytmp,'') as 'vw_ftytmpitm',
			isnull(imu_basprc,0) as 'vw_basprc'
	from IMVENINFH
	left join imbasinfH on		ibi_itmno = ivi_itmno
	left join imcolinfH on		ibi_itmno = icf_itmno
	left join imprcinfh on 	 	ivi_itmno = imu_itmno 	and 
				ivi_venno = imu_prdven 
	left join VNBASINF on 	ivi_venno = vbi_venno
	left join SYSETINF prc on	prc.ysi_cocde = ' '		and
				prc.ysi_cde = imu_hkprctrm	and
				prc.ysi_typ = '03'
	left join SYSETINF prcfty on	prcfty.ysi_cocde = ' '		and
				prcfty.ysi_cde = imu_ftyprctrm	and
				prcfty.ysi_typ = '03'
	where	ivi_itmno = @ibi_itmno				and
		ivi_def = 'Y'					and
--		imu_status = 'ACT'					and
		imu_pckunt = @ipi_pckunt				and
		imu_inrqty = @ipi_inrqty				and
		imu_mtrqty = @ipi_mtrqty				--and
--		imu_cus1no = @imu_cus1no				and
--		imu_cus2no = @imu_cus2no				and
--		imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--		imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)
	order by 	ivi_def desc, imu_ventyp desc, ivi_venno
         end
else

begin
	select 		@oriitmno as 'qud_itmno',
			@qud_qutseq as 'qud_qutseq',
			ibi_itmno as 'vw_itmno',
			isnull(ibi_engdsc,'') as 'vw_engdsc',
			isnull(icf_colcde,'') as 'vw_colcde', 
			isnull(rtrim(ltrim(imu_pckunt)) + '/' +  rtrim(ltrim(str(imu_inrqty))) + '/' +  rtrim(ltrim(str(imu_mtrqty))) ,'') as 'vw_pckunt',
			isnull(ibi_alsitmno,'') as 'ibi_alsitmno',
			isnull(ibi_alscolcde,'') as 'ibi_alscolcde',
			'The matched item is in ' + case ibi_itmsts 	
					when 'DIS' then  'Discontinued'
					end + ' Status.' as 'Remarks',
			isnull(ibi_ftytmp,'') as 'vw_ftytmpitm',
			isnull(imu_basprc,0) as 'vw_basprc'
	from IMVENINF
	left join imbasinf on		ibi_itmno = ivi_itmno
	left join imcolinf on		ibi_itmno = icf_itmno
	left join imprcinf on 	 	ivi_itmno = imu_itmno 	and 
				ivi_venno = imu_prdven 
	left join VNBASINF on	ivi_venno = vbi_venno
	left join SYSETINF prc on	prc.ysi_cocde = ' '		and
				prc.ysi_cde = imu_hkprctrm	and
				prc.ysi_typ = '03'
	left join SYSETINF prcfty on	prcfty.ysi_cocde = ' '		and
				prcfty.ysi_cde = imu_ftyprctrm	and
				prcfty.ysi_typ = '03'
	where	(
			select ivi_venitm
			from imveninf
			where	ivi_itmno = @ibi_itmno	and
				ivi_def = 'Y' ) = ibi_itmno	and
--		imu_status = 'ACT'					and
		imu_pckunt = @ipi_pckunt				and
		imu_inrqty = @ipi_inrqty				and
		imu_mtrqty = @ipi_mtrqty				--and
--		imu_conftr = @ipi_conftr				and
--		imu_cus1no = @imu_cus1no				and
--		imu_cus2no = @imu_cus2no				and
--		imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--		imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)
	order by 	ivi_def desc, imu_ventyp desc, ivi_venno
end





GO
GRANT EXECUTE ON [dbo].[sp_select_IMBASINF_Q_upditm_wCust2] TO [ERPUSER] AS [dbo]
GO
