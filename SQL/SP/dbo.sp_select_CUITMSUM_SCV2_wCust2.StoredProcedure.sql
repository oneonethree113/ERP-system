/****** Object:  StoredProcedure [dbo].[sp_select_CUITMSUM_SCV2_wCust2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMSUM_SCV2_wCust2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMSUM_SCV2_wCust2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- It is based on sp_select_CUITMSUM_SCV2
/************************************************************************
Author:		Carlos Lui
Date:		03 Jul, 2012
Description:	Select data From CUITMSUM
Parameter:		1. Company
		2. Item no
********************************************************************************************************************
Modification History
********************************************************************************************************************
Modify on		Modify by		Description
********************************************************************************************************************

********************************************************************************************************************/

CREATE  procedure [dbo].[sp_select_CUITMSUM_SCV2_wCust2]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cis_cocde nvarchar(6) ,
@cis_itmno nvarchar(20),
@cis_seccus nvarchar(6),
@cis_cusno nvarchar(6)
---------------------------------------------- 
 
AS

begin
	---- Create Temp IM Table  ----
	select	* 
	into	#IMTemp
	from 	(	select	ibi_itmno, 		bas.ibi_alsitmno, 	bas.ibi_typ,
				bas.ibi_itmsts,	bas.ibi_tirtyp,	bas.ibi_venno,
				icf_colcde,		icf_vencol,		ipi_pckunt,
				ipi_inrqty,		ipi_mtrqty,		ipi_conftr,
				ipi_cft,		ipi_cbm,		isnull(imu_bcurcde,'') as 'imu_bcurcde',
				isnull(imu_basprc,0) as 'imu_basprc',
						'N' as'ResultStatus',	isnull(bas.ibi_alscolcde,'') as 'ibi_alscolcde',
				bas.ibi_ftytmp,	isnull(imu_cus1no,'') as 'imu_cus1no',
								isnull( imu_cus2no,'')  as 'imu_cus2no',
				imu_hkprctrm,	imu_ftyprctrm,	imu_trantrm,
				imu_effdat,		imu_expdat,imu_ventyp, imu_prdven
			from	imbasinf bas
			left join	imcolinf on		icf_itmno = bas.ibi_itmno 
			left join	impckinf on	ipi_itmno = bas.ibi_itmno 
			left join	imveninf on	ivi_itmno = bas.ibi_itmno	and
						ivi_def = 'Y'
			left join	imprcinf on	imu_itmno = bas.ibi_itmno	and 
						imu_prdven = ivi_venno	and
--						imu_status = 'ACT'		and
						imu_pckunt = ipi_pckunt	and
						imu_inrqty = ipi_inrqty	and
						imu_mtrqty = ipi_mtrqty	--and
--						imu_cft = ipi_cft		--and
--						imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--						imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)
		where	bas.ibi_itmno = @cis_itmno	and
				bas.ibi_itmsts <> 'CLO'
			union 
			select	bas.ibi_itmno,	bas.ibi_alsitmno,	bas.ibi_typ,
				bas.ibi_itmsts,	bas.ibi_tirtyp,	bas.ibi_venno,
				icf_colcde,		icf_vencol,		ipi_pckunt,
				ipi_inrqty,		ipi_mtrqty,		ipi_conftr,
				ipi_cft,		ipi_cbm,		isnull(imu_bcurcde,'') as 'imu_bcurcde',
				isnull(imu_basprc,0) as 'imu_basprc',
						'A' as'ResultStatus',	isnull(bas.ibi_alscolcde,'') as 'ibi_alscolcde',
				bas.ibi_ftytmp,	isnull(imu_cus1no,'') as 'imu_cus1no',
								isnull( imu_cus2no,'') as 'imu_cus2no',
				imu_hkprctrm,	imu_ftyprctrm,	imu_trantrm,
				imu_effdat,		imu_expdat,imu_ventyp, imu_prdven
			from	imbasinf bas
			left join	imbasinf old on 	bas.ibi_alsitmno = old.ibi_itmno 
			left join	imcolinf on		icf_itmno = bas.ibi_itmno 
			left join	impckinf on	ipi_itmno = bas.ibi_itmno 
			left join	imveninf on	ivi_itmno = bas.ibi_itmno	and
						ivi_def = 'Y'
			left join	imprcinf on	imu_itmno = bas.ibi_itmno	and 
						imu_prdven = ivi_venno	and
--						imu_status = 'ACT'		and
						imu_pckunt = ipi_pckunt	and
						imu_inrqty = ipi_inrqty	and
						imu_mtrqty = ipi_mtrqty	--and
--						imu_cft = ipi_cft	--	and
--						imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--						imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)
			where	bas.ibi_alsitmno = @cis_itmno	and
				bas.ibi_itmsts <> 'CLO'	and
				isnull(old.ibi_itmsts,'') <> 'OLD'
			union
			select	bas.ibi_itmno,	bas.ibi_alsitmno,	bas.ibi_typ,
				bas.ibi_itmsts,	bas.ibi_tirtyp,	bas.ibi_venno,
				icf_colcde,		icf_vencol,		ipi_pckunt,
				ipi_inrqty,		ipi_mtrqty,		ipi_conftr,
				ipi_cft,		ipi_cbm,		isnull(imu_bcurcde,'') as 'imu_bcurcde',
				isnull(imu_basprc,0) as 'imu_basprc',
						'H' as'ResultStatus',	isnull(bas.ibi_alscolcde,'') as 'ibi_alscolcde',
				bas.ibi_ftytmp,	isnull(imu_cus1no,'') as 'imu_cus1no',
								isnull( imu_cus2no,'')  as 'imu_cus2no',
				imu_hkprctrm,	imu_ftyprctrm,	imu_trantrm,
				imu_effdat,		imu_expdat,imu_ventyp, imu_prdven
			from	imbasinfh bas
			left join	imcolinfh on	icf_itmno = bas.ibi_itmno 
			left join	impckinfh on	ipi_itmno = bas.ibi_itmno 
			left join	imveninfh on	ivi_itmno = bas.ibi_itmno	and
						ivi_def = 'Y'
			left join	imprcinfh on	imu_itmno = bas.ibi_itmno	and 
						imu_prdven = ivi_venno	and
--						imu_status = 'ACT'		and
						imu_pckunt = ipi_pckunt	and
						imu_inrqty = ipi_inrqty	and
						imu_mtrqty = ipi_mtrqty	--and
--						imu_cft = ipi_cft	--	and
--						imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--						imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)
			where	bas.ibi_itmno = @cis_itmno	and
				bas.ibi_itmsts <> 'CLO'
			union
			select	bas.ibi_itmno,	bas.ibi_alsitmno,	bas.ibi_typ,	
				bas.ibi_itmsts,	bas.ibi_tirtyp,	bas.ibi_venno,
				icf_colcde,		icf_vencol,		ipi_pckunt,
				ipi_inrqty,		ipi_mtrqty,		ipi_conftr,
				ipi_cft,		ipi_cbm,		isnull(imu_bcurcde,'') as 'imu_bcurcde',
				isnull(imu_basprc,0) as 'imu_basprc',
						'HA' as'ResultStatus',	isnull(bas.ibi_alscolcde,'') as 'ibi_alscolcde',
				bas.ibi_ftytmp,	isnull(imu_cus1no,'') as 'imu_cus1no',
								isnull( imu_cus2no,'')  as 'imu_cus2no',
				imu_hkprctrm,	imu_ftyprctrm,	imu_trantrm,
				imu_effdat,		imu_expdat,imu_ventyp, imu_prdven
			from	imbasinfh bas
			left join	imbasinfh old on	bas.ibi_alsitmno = old.ibi_itmno
			left join	imcolinfh on	icf_itmno = bas.ibi_itmno 
			left join	impckinfh on	ipi_itmno = bas.ibi_itmno 
			left join	imveninfh on	ivi_itmno = bas.ibi_itmno	and
						ivi_def = 'Y'
			left join	imprcinfh on	imu_itmno = bas.ibi_itmno	and 
						imu_prdven = ivi_venno	and
--						imu_status = 'ACT'		and
						imu_pckunt = ipi_pckunt	and
						imu_inrqty = ipi_inrqty	and
						imu_mtrqty = ipi_mtrqty	--and
--						imu_cft = ipi_cft		and
--						imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--						imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)
			where	bas.ibi_alsitmno = @cis_itmno	and
				bas.ibi_itmsts <> 'CLO'	and
				isnull(old.ibi_itmsts,'') <> 'OLD'
		) as table_a
	-------------------------------------------------------
	
	--select  * from #IMTemp
	-------------------------------------------------------
	if ltrim(rtrim(@cis_seccus)) <> '' 
	begin 
		select	cis_cocde,		cis_cusno,		cis_seccus,
			cis_itmno,		cis_itmdsc,		cis_cusitm,
			cis_colcde,		cis_coldsc,		cis_cuscol,
			cis_untcde,		cis_inrqty,		cis_mtrqty,
			cis_cft = case ResultStatus
				when 'N' then ISNULL(ipi_cft,0)
				when 'A' then ISNULL(ipi_cft,0)
				when 'H' then ISNULL(ipi_cft,0)
				when 'HA' then ISNULL(ipi_cft,0)
				else 0
				end,	cis_cbm = case ResultStatus
						when 'N' then ISNULL(ipi_cbm,0)
						when 'A' then ISNULL(ipi_cbm,0)
						when 'H' then ISNULL(ipi_cbm,0)
						when 'HA' then ISNULL(ipi_cbm,0)
						else 0
						end,	cis_refdoc,
			cis_docdat,		cis_cussku,		cis_curcde,
			cis_ordqty,		cis_selprc,		cis_hrmcde,
			cis_dtyrat,		cis_dept,		cis_typcode,
			cis_code1,		cis_code2,		cis_code3,
			cis_cususd,		cis_cuscad,		cast(cis_colcde as nvarchar(30)) + ' / ' +
							cast(cis_untcde as nvarchar(6)) + ' / ' +
							cast(cis_inrqty as nvarchar(10)) + ' / ' +
							cast(cis_mtrqty as nvarchar(10)) + ' / ' +
							cast(case	when ipi_cft = 0 or ipi_cft is null then isnull(ipi_cft,cis_cft)
								else ipi_cft 
								end as nvarchar(10)) + ' / ' +
							cast(case	when ipi_cbm= 0 or ipi_cbm is null then isnull(ipi_cbm,cis_cbm)
								else ipi_cbm
								end as nvarchar(10)) as 'cis_colpck',
			cis_inrdin,		cis_inrwin,		cis_inrhin,
			cis_mtrdin,		cis_mtrwin,	cis_mtrhin,
			cis_inrdcm,	cis_inrwcm,	cis_inrhcm,
			cis_mtrdcm,	cis_mtrwcm,	cis_mtrhcm,
			case ResultStatus
				when 'N' then case ibi_itmsts
						when 'CMP' then 'CMP - Active Item with complete Info.'
						when 'INC' then 'INC - Active Item with incomplete Info.'
						when 'HLD' then 'HLD - Active Item Hold by the system'
						when 'DIS' then 'DIS - Discontinue Item'
						when 'INA' then 'INA - Inactive Item'
						when 'CLO' then 'CLO - Closed (UCP Item)'
						when 'TBC' then 'TBC - To be confirmed Item'
						when 'OLD' then 'OLD -Old Item'
						end
				when 'A' then case ibi_itmsts
						when 'CMP' then 'CMP - Active Item with complete Info.'
						when 'INC' then 'INC - Active Item with incomplete Info.'
						when 'HLD' then 'HLD - Active Item Hold by the system'
						when 'DIS' then 'DIS - Discontinue Item'
						when 'INA' then 'INA - Inactive Item'
						when 'CLO' then 'CLO - Closed (UCP Item)'
						when 'TBC' then 'TBC - To be confirmed Item'
						when 'OLD' then 'OLD -Old Item'
						end
				when 'H' then 'N/A'
				when 'HA' then 'N/A'		
				else 'MISSING'
				end as 'ibi_itmsts',
					isnull(ibi_typ,'N/A') as 'ibi_typ',
							isnull(imu_bcurcde,'N/A') as  'imu_bcurcde',
			isnull(imu_basprc,0) as 'imu_basprc',
					cis_qutdat,		cis_creusr,
			cis_updusr,		cis_credat,		cis_upddat,
			cast(cis_timstp as int ) as 'cis_timstp',
					case ResultStatus
						when 'H' then case ibi_itmsts 	
								when 'CMP' then 'CMP - Active Item with complete Info.'
								when 'INC' then 'INC - Active Item with incomplete Info.'
								when 'HLD' then 'HLD - Active Item Hold by the system'
								when 'DIS' then 'DIS - Discontinue Item'
								when 'INA' then 'INA - Inactive Item'
								when 'CLO' then 'CLO - Closed (UCP Item)'
								when 'TBC' then 'TBC - To be confirmed Item'
								when 'OLD' then 'OLD -Old Item'
								else 'CMP'
								end
						when 'HA' then case ibi_itmsts
								when 'CMP' then 'CMP - Active Item with complete Info.'
								when 'INC' then 'INC - Active Item with incomplete Info.'
								when 'HLD' then 'HLD - Active Item Hold by the system'
								when 'DIS' then 'DIS - Discontinue Item'
								when 'INA' then 'INA - Inactive Item'
								when 'CLO' then 'CLO - Closed (UCP Item)'
								when 'TBC' then 'TBC - To be confirmed Item'
								when 'OLD' then 'OLD -Old Item'
								else 'CMP'
								end
						when 'N' then 'N/A'
						when 'A' then 'N/A'		
						else 'N/A'
						end as 'h_ibi_itmsts',
							case ResultStatus
								when 'H' then Isnull(ibi_typ,'N/A') 		
								when 'HA' then Isnull(ibi_typ,'N/A') 
								else 'N/A'
								end as 'h_ibi_typ',	
			case ResultStatus
				when 'H' then isnull(imu_bcurcde,'N/A') 
				when 'HA' then isnull(imu_bcurcde,'N/A') 
				else 'N/A'
				end as 'h_imu_bcurcde',		
					case ResultStatus
						when 'H' then isnull(imu_basprc,0) 
						when 'HA' then isnull(imu_basprc,0) 
						else '0'
						end as 'h_imu_basprc',
							cis_pckitr,
			case ResultStatus
				when 'N' then isnull(ibi_tirtyp,'0') 
				when 'A' then isnull(ibi_tirtyp,'0') 
				else '0'
				end as 'ibi_tirtyp',		
					case ResultStatus
						when 'H' then isnull(ibi_tirtyp,'2') 
						when 'HA' then isnull(ibi_tirtyp,'2') 
						else '2'
						end as 'h_ibi_tirtyp',
							isnull(icf_colcde , '@#') as 'icf_colcde',
			ibi_venno,		ibi_alsitmno,	ibi_alscolcde,
			cis_conftr,		cis_contopc,	cis_pcprc,
			isnull(ibi_ftytmp,'') as 'ibi_ftytmp',
					isnull(cis_cusstyno,'') as 'cis_cusstyno',
							isnull(imu_cus1no , '') as 'imu_cus1no',
			isnull(imu_cus2no , '') as 'imu_cus2no',
					isnull(imu_hkprctrm , '') as 'imu_hkprctrm',
							isnull(imu_ftyprctrm , '') as 'imu_ftyprctrm',
			isnull(imu_trantrm , '') as 'imu_trantrm',
					isnull(imu_effdat , '01/01/1900') as 'imu_effdat',
							isnull(imu_expdat , '01/01/1900') as 'imu_expdat'
			--'' as 'imu_std'
		from	CUITMSUM 
		left join	#IMTemp on	(ibi_itmno = @cis_itmno	or
					 ibi_alsitmno = @cis_itmno)			and
					ltrim(rtrim(cis_colcde)) = ltrim(rtrim(icf_colcde))	and
					cis_untcde = ipi_pckunt			and
					cis_inrqty = ipi_inrqty				and
					cis_mtrqty = ipi_mtrqty			--and
--					cis_cft = ipi_cft				and
--					cis_cus1no = imu_cus1no			and
--					cis_cus2no = imu_cus2no			
/*and
					cis_hkprctrm = imu_hkprctrm			and
					cis_ftyprctrm = imu_ftyprctrm			and
					cis_trantrm = imu_trantrm*/
		where	cis_cusno in (	select	cbi_cusno
					from	cubasinf (nolock)
					where	(cbi_cusali = @cis_cusno or
						 cbi_cusno = @cis_cusno)	and
						cbi_cusno  <> ''
					union
					select	cbi_cusali
					from	cubasinf (nolock)
					where	cbi_cusno = @cis_cusno	and
						cbi_cusali <> '')			and
			cis_seccus in (	select	cbi_cusno
					from	cubasinf (nolock)
					where	(cbi_cusali = @cis_seccus or
						 cbi_cusno = @cis_seccus)	and
						cbi_cusno <> ''
					union
					select	cbi_cusali
					from	cubasinf (nolock)
					where	cbi_cusno = @cis_seccus	and
						cbi_cusali  <> '')			and
			cis_itmno in (	select	ibi.ibi_itmno
					from	imbasinf ibi (nolock) 
					left join	imbasinf als (nolock) on	ibi.ibi_alsitmno = als.ibi_itmno
					where	ibi.ibi_itmno = @cis_itmno	or
						(ibi.ibi_alsitmno = @cis_itmno and
						 isnull(als.ibi_itmsts,'') <> 'OLD')
					union
					select	ibi.ibi_alsitmno
					from	imbasinf ibi (nolock)
					left join	imbasinf als (nolock) on	ibi.ibi_alsitmno = als.ibi_itmno
					where	ibi.ibi_itmno = @cis_itmno	and
						isnull(als.ibi_itmsts,'') <> 'OLD')
		order by	cis_colcde asc , cis_untcde asc, cis_conftr desc
	end
	else	--if ltrim(rtrim(@cis_seccus)) ='' 
	begin
		select	cis_cocde,		cis_cusno,		cis_seccus,
			cis_itmno,		cis_itmdsc,		cis_cusitm,
			cis_colcde,		cis_coldsc,		cis_cuscol,
			cis_untcde,		cis_inrqty,		cis_mtrqty,	
			cis_cft = case ResultStatus
				when 'N' then ISNULL(ipi_cft,0)
				when 'A' then ISNULL(ipi_cft,0)
				when 'H' then ISNULL(ipi_cft,0)
				when 'HA' then ISNULL(ipi_cft,0)
				else 0
				end,	cis_cbm = case ResultStatus
						when 'N' then ISNULL(ipi_cbm,0)
						when 'A' then ISNULL(ipi_cbm,0)
						when 'H' then ISNULL(ipi_cbm,0)
						when 'HA' then ISNULL(ipi_cbm,0)
						else 0
						end,	cis_refdoc,
			cis_docdat,		cis_cussku,		cis_curcde,
			cis_ordqty,		cis_selprc,		cis_hrmcde,
			cis_dtyrat,		cis_dept,		cis_typcode,
			cis_code1,		cis_code2,		cis_code3,
			cis_cususd,		cis_cuscad, 	cast(cis_colcde as nvarchar(30)) + ' / ' +
							cast(cis_untcde as nvarchar(6)) + ' / ' +
							cast(cis_inrqty as nvarchar(10)) + ' / ' +
							cast(cis_mtrqty as nvarchar(10)) + ' / ' +
							cast(case	when ipi_cft = 0 or ipi_cft is null then isnull(ipi_cft,cis_cft) 
								else ipi_cft
								end as nvarchar(10)) + ' / ' +
								cast(case	when ipi_cbm= 0 or ipi_cbm is null then isnull(ipi_cbm,cis_cbm)
									else ipi_cbm
									end as nvarchar(10)) as 'cis_colpck',
			cis_inrdin,		cis_inrwin,		cis_inrhin,
			cis_mtrdin,		cis_mtrwin,	cis_mtrhin,
			cis_inrdcm,	cis_inrwcm,	cis_inrhcm,
			cis_mtrdcm,	cis_mtrwcm,	cis_mtrhcm,
			case ResultStatus
				when 'N' then case ibi_itmsts 	
						when 'CMP' then 'CMP - Active Item with complete Info.'
						when 'INC' then 'INC - Active Item with incomplete Info.'
						when 'HLD' then 'HLD - Active Item Hold by the system'
						when 'DIS' then 'DIS - Discontinue Item'
						when 'INA' then 'INA - Inactive Item'
						when 'CLO' then 'CLO - Closed (UCP Item)'
						when 'TBC' then 'TBC - To be confirmed Item'
						when 'OLD' then 'OLD -Old Item'
						end
				when 'A' then case ibi_itmsts 	
						when 'CMP' then 'CMP - Active Item with complete Info.'
						when 'INC' then 'INC - Active Item with incomplete Info.'
						when 'HLD' then 'HLD - Active Item Hold by the system'
						when 'DIS' then 'DIS - Discontinue Item'
						when 'INA' then 'INA - Inactive Item'
						when 'CLO' then 'CLO - Closed (UCP Item)'
						when 'TBC' then 'TBC - To be confirmed Item'
						when 'OLD' then 'OLD -Old Item'
						end
				when 'H' then 'N/A'
				when 'HA' then 'N/A'		
				else 'MISSING'
				end as 'ibi_itmsts',
					isnull(ibi_typ,'N/A') as 'ibi_typ',
							isnull(imu_bcurcde,'N/A') as 'imu_bcurcde',
			isnull(imu_basprc,0) as 'imu_basprc',
					cis_qutdat,		cis_creusr,
			cis_updusr,		cis_credat,		cis_upddat,
			cast(cis_timstp as int ) as 'cis_timstp',
					case ResultStatus
						when 'H' then case ibi_itmsts
								when 'CMP' then 'CMP - Active Item with complete Info.'
								when 'INC' then 'INC - Active Item with incomplete Info.'
								when 'HLD' then 'HLD - Active Item Hold by the system'
								when 'DIS' then 'DIS - Discontinue Item'
								when 'INA' then 'INA - Inactive Item'
								when 'CLO' then 'CLO - Closed (UCP Item)'
								when 'TBC' then 'TBC - To be confirmed Item'
								when 'OLD' then 'OLD -Old Item'
								else 'CMP'
								end
						when 'HA' then case ibi_itmsts 	
								when 'CMP' then 'CMP - Active Item with complete Info.'
								when 'INC' then 'INC - Active Item with incomplete Info.'
								when 'HLD' then 'HLD - Active Item Hold by the system'
								when 'DIS' then 'DIS - Discontinue Item'
								when 'INA' then 'INA - Inactive Item'
								when 'CLO' then 'CLO - Closed (UCP Item)'
								when 'TBC' then 'TBC - To be confirmed Item'
								when 'OLD' then 'OLD -Old Item'
								else 'CMP'
								end
						when 'N' then 'N/A'
						when 'A' then 'N/A'		
						else 'N/A'
						end as 'h_ibi_itmsts',
							case ResultStatus
								when 'H' then Isnull(ibi_typ,'N/A') 		
								when 'HA' then Isnull(ibi_typ,'N/A') 
								else 'N/A'
								end as 'h_ibi_typ',	
			case ResultStatus
				when 'H' then isnull(imu_bcurcde,'N/A') 
				when 'HA' then isnull(imu_bcurcde,'N/A') 
				else 'N/A'
				end as 'h_imu_bcurcde',
					case ResultStatus
						when 'H' then isnull(imu_basprc,0) 
						when 'HA' then isnull(imu_basprc,0) 
						else '0'
						end as 'h_imu_basprc',
							cis_pckitr,
			case ResultStatus
				when 'N' then isnull(ibi_tirtyp,'0') 
				when 'A' then isnull(ibi_tirtyp,'0') 
				else '0'
				end as 'ibi_tirtyp',
					case ResultStatus
						when 'H' then isnull(ibi_tirtyp,'2') 
						when 'HA' then isnull(ibi_tirtyp,'2') 
						else '2'
						end as 'h_ibi_tirtyp',
							isnull(icf_colcde , '@#') as 'icf_colcde',
			ibi_venno,		ibi_alsitmno,	ibi_alscolcde,
			cis_conftr,		cis_contopc,	cis_pcprc,
			isnull(ibi_ftytmp,'') as 'ibi_ftytmp',
					isnull(cis_cusstyno,'') as 'cis_cusstyno',
							isnull(imu_cus1no , '') as 'imu_cus1no',
			isnull(imu_cus2no , '') as 'imu_cus2no',
					isnull(imu_hkprctrm , '') as 'imu_hkprctrm',
							isnull(imu_ftyprctrm , '') as 'imu_ftyprctrm',
			isnull(imu_trantrm , '') as 'imu_trantrm',
					isnull(imu_effdat , '01/01/1900') as 'imu_effdat',
							isnull(imu_expdat , '01/01/1900') as 'imu_expdat'
			--'' as 'imu_std'
		from	CUITMSUM 
		left join	#IMTemp on	(ibi_itmno = @cis_itmno	or
					 ibi_alsitmno = @cis_itmno)			and
					ltrim(rtrim(cis_colcde)) = ltrim(rtrim(icf_colcde))	and
					cis_untcde = ipi_pckunt			and
					cis_inrqty = ipi_inrqty				and
					cis_mtrqty = ipi_mtrqty			--and
					--cis_cft = ipi_cft				and
					--cis_cus1no = imu_cus1no			and
					--cis_cus2no = imu_cus2no			
/*and
					cis_hkprctrm = imu_hkprctrm			and
					cis_ftyprctrm = imu_ftyprctrm			and
					cis_trantrm = imu_trantrm*/
		where	cis_cusno in (	select	cbi_cusno
					from	cubasinf (nolock)
					where	(cbi_cusali = @cis_cusno or
						 cbi_cusno = @cis_cusno)	and
						cbi_cusno <> ''
					union
					select	cbi_cusali
					from	cubasinf (nolock)
					where	cbi_cusno = @cis_cusno	and
						cbi_cusali <> '')			and
			cis_seccus = ''						and
			cis_itmno in (	select	ibi.ibi_itmno
					from	imbasinf ibi (nolock) 
					left join	imbasinf als (nolock) on	ibi.ibi_alsitmno = als.ibi_itmno
					where	ibi.ibi_itmno = @cis_itmno	or
						(ibi.ibi_alsitmno = @cis_itmno and
						 isnull(als.ibi_itmsts,'') <> 'OLD')
					union	
					select	ibi.ibi_alsitmno
					from	imbasinf ibi (nolock) 
					left join	imbasinf als (nolock) on	ibi.ibi_alsitmno = als.ibi_itmno
					where	ibi.ibi_itmno = @cis_itmno	and
						isnull(als.ibi_itmsts,'') <> 'OLD')
		order by	cis_colcde asc , cis_untcde asc, cis_conftr desc                                                 
	---------------------------------------------------------- 
	end
	drop table #IMTemp
end

GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMSUM_SCV2_wCust2] TO [ERPUSER] AS [dbo]
GO
