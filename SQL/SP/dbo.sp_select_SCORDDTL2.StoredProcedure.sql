/****** Object:  StoredProcedure [dbo].[sp_select_SCORDDTL2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCORDDTL2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCORDDTL2]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Carlos Lui
Date:		05 Jul, 2012
Description:	Select data From SCORDDTL
Parameter:		1. Company
		2. SC No.	
***********************************************************************
=========================================================
 Modification History                                    
=========================================================

=========================================================     */
------------------------------------------------- 
CREATE   procedure [dbo].[sp_select_SCORDDTL2]
                                                                                                                                                                                                                                                                 
@sod_cocde nvarchar(6) ,
@sod_ordno nvarchar(20)                                                
 
AS

declare @max_Seq  int

set @max_seq = (	select	isnull(max(sod_ordseq),0)
		from	SCORDDTL (nolock)
		where	sod_cocde = @sod_cocde	and
			sod_ordno = @sod_ordno)
begin


declare @sc_credat datetime

select @sc_credat = soh_credat  from SCORDHDR (nolock) where soh_cocde = @sod_cocde and soh_ordno = @sod_ordno

if @sc_credat > '2011-01-01'
begin

	select	sod_cocde,			sod_ordno,			sod_ordseq,
		sod_updpo,		sod_chgfty,		sod_cusven + ' - ' + ISNULL(bb.vbi_vensna,'') as 'sod_cusven',
		sod_subcde,		sod_venno + ' - ' + ISNULL(aa.vbi_vensna,'') as 'sod_vensna',
								sod_cussub,
		isnull(pod_purord,'') as 'pod_purord',
					isnull(pod_jobord,'') as 'pod_jobord',
								sod_runno,
		sod_pjobno,		sod_itmno,			isnull(sod_cusstyno,'') as 'sod_cusstyno',
		sod_cusitm,		sod_cussku,		sod_seccusitm,
		a.ibi_venno,		isnull(case a.ibi_itmsts
						when 'CMP' then 'CMP - Active Item with complete Info.'
						when 'INC' then 'INC - Active Item with incomplete Info.'
						when 'HLD' then 'HLD - Active Item Hold by the system'
						when 'DIS' then 'DIS - Discontinue Item'
						when 'INA' then 'INA - Inactive Item'
						when 'CLO' then 'CLO - Closed Item (Alias Item)'
						when 'TBC' then 'TBC - To be confirmed Item'
						when 'OLD' then 'OLD - Old Item'
						end,'N/A') as 'ibi_itmsts',
								isnull(b.imu_bcurcde,'N/A') as 'imu_bcurcde',
		isnull(b.imu_basprc,0) as 'imu_basprc',
					sod_itmtyp,		sod_itmdsc,
		sod_cuscol,		cast(sod_colcde as nvarchar(30)) + ' / ' +
					cast(sod_pckunt as nvarchar(6)) + ' / ' +
					cast(sod_inrctn as nvarchar(10)) + ' / ' +
					cast(sod_mtrctn as nvarchar(10)) + ' / ' +
					cast(sod_cft as nvarchar(10)) + ' / ' +
					cast(sod_cbm as nvarchar(10)) as 'sod_colpck',
								sod_pckitr,
		sod_colcde,		sod_inrctn,			sod_mtrctn,
		sod_cft,			sod_cbm,			sod_coldsc,
		sod_pckseq,		sod_pckunt,		sod_qutno,
		sod_refdat,			sod_resppo,		sod_cuspo,
		sod_ordqty,		sod_shpqty,		sod_ordqty - sod_shpqty as 'sod_outqty',
		sod_discnt,			sod_oneprc,		sod_curcde,
		sod_netuntprc,		sod_untprc,		sod_untprc as 'sod_orgunt',
		sod_itmprc,		sod_inrdin,			sod_inrwin,
		sod_inrhin,			sod_mtrdin,		sod_mtrwin,
		sod_mtrhin,		sod_inrdcm,		sod_inrwcm,
		sod_inrhcm,		sod_mtrdcm,		sod_mtrwcm,
		sod_mtrhcm,		sod_ctnstr,			sod_ctnend,
		sod_ttlctn,			sod_moq,			isnull(sod_moqunttyp,'') as 'sod_moqunttyp',
		sod_moqchg,		sod_selprc,			sod_moa,
		sod_rmk,			sod_venno,			sod_purord,
		sod_purseq,		sod_ftyprc as 'sod_orgfty',	sod_creusr,
		sod_updusr,		sod_credat,			sod_upddat,
		cast(sod_timstp as int) as 'sod_timstp',
					@max_seq as 'max_seq',	c.ibi_venno as 'h_ibi_veno',
		isnull(case c.ibi_itmsts 	
			when 'CMP' then 'CMP - Active Item with complete Info.'
			when 'INC' then 'INC - Active Item with incomplete Info.'
			when 'HLD' then 'HLD - Active Item Hold by the system'
			when 'DIS' then 'DIS - Discontinue Item'
			when 'INA' then 'INA - Inactive Item'
			when 'CLO' then 'CLO - Closed Item (Alias Item)'
			when 'TBC' then 'TBC - To be confirmed Item'
			when 'OLD' then 'OLD - Old Item'
			end,'N/A') as 'h_ibi_itmsts',
					isnull(d.imu_bcurcde,'N/A') as 'h_imu_bcurcde',
								isnull(d.imu_basprc,0) as 'h_imu_basprc',
		sod_ftyunt,			sod_venitm,		sod_clmno,
		sod_itmsts,			sod_apprve,		isnull(a.ibi_tirtyp,'0') as 'ibi_tirtyp',
		isnull(c.ibi_tirtyp,'2') as 'h_ibi_tirtyp',
					sod_shpstr,			sod_shpend,
		isnull(convert(nvarchar(10), case sod_candat
					when '1900-01-01' then null 
					else cast(sod_candat as datetime)
					end,101),'  /  /    ') as 'sod_candat',
					sod_fcurcde,		sod_ftycst,
		sod_bomcst,		sod_ftyprc,			isnull(sod_dvfcurcde ,'') as 'sod_dvfcurcde',
		isnull(sod_dvftycst,0) as 'sod_dvftycst',
					isnull(sod_dvbomcst,0) as 'sod_dvbomcst',
								isnull(sod_dvftyprc,0) as 'sod_dvftyprc',
		sod_hrmcde,		sod_dtyrat,			sod_dept,
		sod_typcode,		sod_code1,			sod_code2,
		sod_code3,			sod_cususd,		sod_cuscad,
		sod_oldpurord,		sod_invqty,		sod_orgmoqchg,
		sod_cusmoqchg,		sod_venmoqchg,		sod_assitmcount,
		sod_orgvenno,		isnull(sod_alsitmno,'') as 'sod_alsitmno', 
								isnull(sod_alscolcde,'') as 'sod_alscolcde',
		isnull(sod_ztnvbeln,'') as 'sod_ztnvbeln',
					isnull(sod_ztnposnr,'') as 'sod_ztnposnr',
								isnull(sod_zorvbeln,'') as 'sod_zorvbeln',
		isnull(sod_zorposnr,'') as 'sod_zorposnr',
					sod_conftr,			sod_contopc,
		sod_pcprc,			isnull(sod_custum,'') as 'sod_custum',
								isnull(sod_dv,'')  as 'sod_dv',
		isnull(sod_ftyunt,'') as 'sod_dvftyunt',--isnull(sod_dvftyunt,'') as 'sod_dvftyunt',
					sod_qutdat,			sod_imqutdat,
		isnull(sod_itmcstcur,'') as 'sod_itmcstcur',
					sod_dvitmcst,		sod_ftycst_org,
		sod_bomcst_org,		sod_ftyprc_org,		sod_dvftycst_org,
		sod_dvftyprc_org,		sod_dvbomcst_org,		sod_imqutdat_org,
		sod_venno_org,		sod_fcurcde_org,		sod_dvfcurcde_org,
		sod_imqutdatchg,		sod_cus1no,		sod_cus2no,
		sod_hkprctrm,		sod_ftyprctrm,		sod_trantrm,
		sod_effdat,			sod_expdat
	from	SCORDDTL (nolock)
	left join	IMBASINF a (nolock) on	a.ibi_itmno = sod_itmno 
	left join	IMPRCINF b (nolock) on 	b.imu_status = 'ACT'		and
				b.imu_pckunt = sod_pckunt	and
				b.imu_inrqty = sod_inrctn	and
				b.imu_mtrqty = sod_mtrctn	and
				b.imu_itmno = sod_itmno 	and
				b.imu_cus1no = sod_cus1no	and
				b.imu_cus2no = sod_cus2no	and
--				b.imu_hkprctrm = sod_hkprctrm	and
--				b.imu_ftyprctrm = sod_hkprctrm	and
--				b.imu_trantrm = sod_trantrm	and
--				b.imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--				b.imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)	and
--				b.imu_ventyp = 'D' 		and
				b.imu_prdven = sod_venno	and
				b.imu_venno = case b.imu_cocde
						when 'UCP' then sod_venno 
						else a.ibi_venno
						end
	left join	IMBASINFH c (nolock) on 0 = 1	/*c.ibi_itmno = sod_itmno */
	left join	IMPRCINFH d (nolock) on 0 = 1	/*--d.imu_status = 'ACT'		and
				d.imu_pckunt = sod_pckunt	and
				d.imu_inrqty = sod_inrctn	and
				d.imu_mtrqty = sod_mtrctn	and
				d.imu_itmno = sod_itmno	and
				d.imu_cus1no = sod_cus1no	and
				d.imu_cus2no = sod_cus2no	and
--				d.imu_hkprctrm = sod_hkprctrm	and
--				d.imu_ftyprctrm = sod_hkprctrm	and
--				d.imu_trantrm = sod_trantrm	and
--				d.imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--				d.imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)	and
--				d.imu_ventyp = 'D'		and
				d.imu_prdven = sod_venno	and
				d.imu_venno = case d.imu_cocde
						when 'UCP' then sod_venno 
						else c.ibi_venno 
						end*/
	left join	VNBASINF aa (nolock) on	sod_venno = aa.vbi_venno 
	left join	VNBASINF bb (nolock) on	sod_cusven = bb.vbi_venno 
	left join	POORDDTL (nolock) on	pod_cocde = @sod_cocde	and
				pod_purord = sod_purord	and
				pod_purseq = sod_purseq
	where	sod_cocde = @sod_cocde	and
		sod_ordno = @sod_ordno                                                                                    
	order by sod_ordseq

end
else
begin
	select	sod_cocde,			sod_ordno,			sod_ordseq,
		sod_updpo,		sod_chgfty,		sod_cusven + ' - ' + ISNULL(bb.vbi_vensna,'') as 'sod_cusven',
		sod_subcde,		sod_venno + ' - ' + ISNULL(aa.vbi_vensna,'') as 'sod_vensna',
								sod_cussub,
		isnull(pod_purord,'') as 'pod_purord',
					isnull(pod_jobord,'') as 'pod_jobord',
								sod_runno,
		sod_pjobno,		sod_itmno,			isnull(sod_cusstyno,'') as 'sod_cusstyno',
		sod_cusitm,		sod_cussku,		sod_seccusitm,
		a.ibi_venno,		isnull(case a.ibi_itmsts
						when 'CMP' then 'CMP - Active Item with complete Info.'
						when 'INC' then 'INC - Active Item with incomplete Info.'
						when 'HLD' then 'HLD - Active Item Hold by the system'
						when 'DIS' then 'DIS - Discontinue Item'
						when 'INA' then 'INA - Inactive Item'
						when 'CLO' then 'CLO - Closed Item (Alias Item)'
						when 'TBC' then 'TBC - To be confirmed Item'
						when 'OLD' then 'OLD - Old Item'
						end,'N/A') as 'ibi_itmsts',
								isnull(b.imu_bcurcde,'N/A') as 'imu_bcurcde',
		isnull(b.imu_basprc,0) as 'imu_basprc',
					sod_itmtyp,		sod_itmdsc,
		sod_cuscol,		cast(sod_colcde as nvarchar(30)) + ' / ' +
					cast(sod_pckunt as nvarchar(6)) + ' / ' +
					cast(sod_inrctn as nvarchar(10)) + ' / ' +
					cast(sod_mtrctn as nvarchar(10)) + ' / ' +
					cast(sod_cft as nvarchar(10)) + ' / ' +
					cast(sod_cbm as nvarchar(10)) as 'sod_colpck',
								sod_pckitr,
		sod_colcde,		sod_inrctn,			sod_mtrctn,
		sod_cft,			sod_cbm,			sod_coldsc,
		sod_pckseq,		sod_pckunt,		sod_qutno,
		sod_refdat,			sod_resppo,		sod_cuspo,
		sod_ordqty,		sod_shpqty,		sod_ordqty - sod_shpqty as 'sod_outqty',
		sod_discnt,			sod_oneprc,		sod_curcde,
		sod_netuntprc,		sod_untprc,		sod_untprc as 'sod_orgunt',
		sod_itmprc,		sod_inrdin,			sod_inrwin,
		sod_inrhin,			sod_mtrdin,		sod_mtrwin,
		sod_mtrhin,		sod_inrdcm,		sod_inrwcm,
		sod_inrhcm,		sod_mtrdcm,		sod_mtrwcm,
		sod_mtrhcm,		sod_ctnstr,			sod_ctnend,
		sod_ttlctn,			sod_moq,			isnull(sod_moqunttyp,'') as 'sod_moqunttyp',
		sod_moqchg,		sod_selprc,			sod_moa,
		sod_rmk,			sod_venno,			sod_purord,
		sod_purseq,		sod_ftyprc as 'sod_orgfty',	sod_creusr,
		sod_updusr,		sod_credat,			sod_upddat,
		cast(sod_timstp as int) as 'sod_timstp',
					@max_seq as 'max_seq',	c.ibi_venno as 'h_ibi_veno',
		isnull(case c.ibi_itmsts 	
			when 'CMP' then 'CMP - Active Item with complete Info.'
			when 'INC' then 'INC - Active Item with incomplete Info.'
			when 'HLD' then 'HLD - Active Item Hold by the system'
			when 'DIS' then 'DIS - Discontinue Item'
			when 'INA' then 'INA - Inactive Item'
			when 'CLO' then 'CLO - Closed Item (Alias Item)'
			when 'TBC' then 'TBC - To be confirmed Item'
			when 'OLD' then 'OLD - Old Item'
			end,'N/A') as 'h_ibi_itmsts',
					isnull(d.imu_bcurcde,'N/A') as 'h_imu_bcurcde',
								isnull(d.imu_basprc,0) as 'h_imu_basprc',
		sod_ftyunt,			sod_venitm,		sod_clmno,
		sod_itmsts,			sod_apprve,		isnull(a.ibi_tirtyp,'0') as 'ibi_tirtyp',
		isnull(c.ibi_tirtyp,'2') as 'h_ibi_tirtyp',
					sod_shpstr,			sod_shpend,
		isnull(convert(nvarchar(10), case sod_candat
					when '1900-01-01' then null 
					else cast(sod_candat as datetime)
					end,101),'  /  /    ') as 'sod_candat',
					sod_fcurcde,		sod_ftycst,
		sod_bomcst,		sod_ftyprc,			isnull(sod_dvfcurcde ,'') as 'sod_dvfcurcde',
		isnull(sod_dvftycst,0) as 'sod_dvftycst',
					isnull(sod_dvbomcst,0) as 'sod_dvbomcst',
								isnull(sod_dvftyprc,0) as 'sod_dvftyprc',
		sod_hrmcde,		sod_dtyrat,			sod_dept,
		sod_typcode,		sod_code1,			sod_code2,
		sod_code3,			sod_cususd,		sod_cuscad,
		sod_oldpurord,		sod_invqty,		sod_orgmoqchg,
		sod_cusmoqchg,		sod_venmoqchg,		sod_assitmcount,
		sod_orgvenno,		isnull(sod_alsitmno,'') as 'sod_alsitmno', 
								isnull(sod_alscolcde,'') as 'sod_alscolcde',
		isnull(sod_ztnvbeln,'') as 'sod_ztnvbeln',
					isnull(sod_ztnposnr,'') as 'sod_ztnposnr',
								isnull(sod_zorvbeln,'') as 'sod_zorvbeln',
		isnull(sod_zorposnr,'') as 'sod_zorposnr',
					sod_conftr,			sod_contopc,
		sod_pcprc,			isnull(sod_custum,'') as 'sod_custum',
								isnull(sod_dv,'')  as 'sod_dv',
		isnull(sod_ftyunt,'') as 'sod_dvftyunt',--isnull(sod_dvftyunt,'') as 'sod_dvftyunt',
					sod_qutdat,			sod_imqutdat,
		isnull(sod_itmcstcur,'') as 'sod_itmcstcur',
					sod_dvitmcst,		sod_ftycst_org,
		sod_bomcst_org,		sod_ftyprc_org,		sod_dvftycst_org,
		sod_dvftyprc_org,		sod_dvbomcst_org,		sod_imqutdat_org,
		sod_venno_org,		sod_fcurcde_org,		sod_dvfcurcde_org,
		sod_imqutdatchg,		sod_cus1no,		sod_cus2no,
		sod_hkprctrm,		sod_ftyprctrm,		sod_trantrm,
		sod_effdat,			sod_expdat
	from	SCORDDTL (nolock)
	left join	IMBASINF a (nolock) on	a.ibi_itmno = sod_itmno 
	left join	IMPRCINF b (nolock) on 	b.imu_status = 'ACT'		and
				b.imu_pckunt = sod_pckunt	and
				b.imu_inrqty = sod_inrctn	and
				b.imu_mtrqty = sod_mtrctn	and
				b.imu_itmno = sod_itmno 	and
				b.imu_cus1no = sod_cus1no	and
				b.imu_cus2no = sod_cus2no	and
--				b.imu_hkprctrm = sod_hkprctrm	and
--				b.imu_ftyprctrm = sod_hkprctrm	and
--				b.imu_trantrm = sod_trantrm	and
--				b.imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--				b.imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)	and
--				b.imu_ventyp = 'D' 		and
				b.imu_prdven = sod_venno	and
				b.imu_venno = case b.imu_cocde
						when 'UCP' then sod_venno 
						else a.ibi_venno
						end
	left join	IMBASINFH c (nolock) on 	c.ibi_itmno = sod_itmno 
	left join	IMPRCINFH d (nolock) on 	--d.imu_status = 'ACT'		and
				d.imu_pckunt = sod_pckunt	and
				d.imu_inrqty = sod_inrctn	and
				d.imu_mtrqty = sod_mtrctn	and
				d.imu_itmno = sod_itmno	and
				d.imu_cus1no = sod_cus1no	and
				d.imu_cus2no = sod_cus2no	and
--				d.imu_hkprctrm = sod_hkprctrm	and
--				d.imu_ftyprctrm = sod_hkprctrm	and
--				d.imu_trantrm = sod_trantrm	and
--				d.imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--				d.imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)	and
--				d.imu_ventyp = 'D'		and
				d.imu_prdven = sod_venno	and
				d.imu_venno = case d.imu_cocde
						when 'UCP' then sod_venno 
						else c.ibi_venno 
						end
	left join	VNBASINF aa (nolock) on	sod_venno = aa.vbi_venno 
	left join	VNBASINF bb (nolock) on	sod_cusven = bb.vbi_venno 
	left join	POORDDTL (nolock) on	pod_cocde = @sod_cocde	and
				pod_purord = sod_purord	and
				pod_purseq = sod_purseq
	where	sod_cocde = @sod_cocde	and
		sod_ordno = @sod_ordno                                                                                    
	order by sod_ordseq
end



end


GO
GRANT EXECUTE ON [dbo].[sp_select_SCORDDTL2] TO [ERPUSER] AS [dbo]
GO
