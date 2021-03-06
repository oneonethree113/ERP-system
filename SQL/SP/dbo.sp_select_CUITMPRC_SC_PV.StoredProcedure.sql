/****** Object:  StoredProcedure [dbo].[sp_select_CUITMPRC_SC_PV]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMPRC_SC_PV]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMPRC_SC_PV]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 28/07/2003


/*
=================================================================
Program ID	: sp_select_CUITMPRC_SC_PV
Description	: Retrieve CIH Pricing for Changing External PV
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-06-21 	David Yue		SP Created
2013-10-10	David Yue		Add Latest CIH flag
=================================================================
*/

CREATE procedure [dbo].[sp_select_CUITMPRC_SC_PV]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cis_cocde	nvarchar(6) ,
@cis_itmno	nvarchar(20),
@cis_cusno	nvarchar(6),
@cis_seccus	nvarchar(6),
@cis_colcde	nvarchar(20),
@cis_untcde	nvarchar(20),
@cis_inrqty	int,
@cis_mtrqty	int,
@cis_ftyprctrm	nvarchar(20),
@cis_hkprctrm	nvarchar(20),
@cis_trantrm	nvarchar(20),
@cip_venno	nvarchar(10),
@cip_prdven	nvarchar(10),
@sod_credat	datetime,
@creusr		nvarchar(30)


---------------------------------------------- 
 
AS
BEGIN

-- Find Latest CIH Pricing for each CIH Item entry
select	*
into	#CUITMPRC_tmp
from	(	select	cip_cocde,	cip_cusno,	cip_seccus,
			cip_itmno,	cip_colcde,	cip_untcde,
			cip_conftr,	cip_inrqty,	cip_mtrqty,
			cip_hkprctrm,	cip_ftyprctrm, 	cip_trantrm,
			max(cip_upddat) as cip_upddat,	'N' as cip_latest
		from	CUITMPRC (nolock)
		where	cip_itmno = @cis_itmno and
			cip_cusno = @cis_cusno and
			cip_seccus = @cis_seccus and
			cip_colcde = @cis_colcde and
			cip_untcde = @cis_untcde and
			cip_inrqty = @cis_inrqty and
			cip_mtrqty = @cis_mtrqty and
			cip_ftyprctrm = @cis_ftyprctrm and
			cip_hkprctrm = @cis_hkprctrm and
			cip_trantrm = @cis_trantrm and
			cip_venno = @cip_venno and
			cip_prdven = @cip_prdven and
			@sod_credat between cip_effdat and cip_expdat
		group by cip_cocde, cip_cusno, cip_seccus, cip_itmno, cip_colcde,
			cip_untcde, cip_conftr, cip_inrqty, cip_mtrqty, cip_hkprctrm,
			cip_ftyprctrm, cip_trantrm
	) as table_cih

update	#CUITMPRC_tmp
set	cip_latest = 'Y'
from	#CUITMPRC_tmp tmp
where	(select count(*) from CUITMPRC cih (nolock) where cih.cip_cocde = tmp.cip_cocde and cih.cip_cusno = tmp.cip_cusno and 
	cih.cip_seccus = tmp.cip_seccus and cih.cip_itmno = tmp.cip_itmno and cih.cip_colcde = tmp.cip_colcde and 
	cih.cip_untcde = tmp.cip_untcde and cih.cip_conftr = tmp.cip_conftr and cih.cip_inrqty = tmp.cip_inrqty and
	cih.cip_mtrqty = tmp.cip_mtrqty and cih.cip_hkprctrm = tmp.cip_hkprctrm and cih.cip_ftyprctrm = tmp.cip_ftyprctrm and
	cih.cip_trantrm = tmp.cip_trantrm and cih.cip_upddat > tmp.cip_upddat) = 0

if ltrim(rtrim(@cis_seccus)) = ''
begin
	select	cis_cocde,
		cis_cusno,
		cis_seccus,
		cis_itmno,
		cis_itmdsc,
		cis_itmventyp,
		cis_cusitm,
		cis_colcde,
		cis_coldsc,
		cis_cuscol,
		cih.cip_venno,
		cih.cip_prdven,
		cis_cusven,
		cis_tradeven,
		cis_examven,
		cis_untcde,
		cis_inrqty,
		cis_mtrqty,
		cis_cft,
		cis_cbm,
		cis_refdoc,
		cis_docdat,
		cih.cip_cus1no,
		cih.cip_cus2no,
		cih.cip_ftyprctrm,
		cih.cip_hkprctrm,
		cih.cip_trantrm,
		cih.cip_effdat,
		cih.cip_expdat,
		cis_cussku,
		cih.cip_fcurcde,
		cih.cip_ftycst,
		cih.cip_bomcst,
		cih.cip_ftyprc,
		cih.cip_curcde,
		cih.cip_muminprc as 'cip_minprc',
		cih.cip_basprc,
		cis_ordqty,
		cih.cip_adjprc as 'cis_selprc',
		cis_hrmcde,
		cis_dtyrat, 
		cis_dept,
		cis_typcode,
		cis_code1,
		cis_code2,
		cis_code3,
		cis_cususdcur,
		cis_cususd,
		cis_cuscadcur,
		cis_cuscad,
		cast(cis_colcde as nvarchar(30)) + ' / ' + cast(cis_untcde as nvarchar(6)) + ' / ' + 
			cast(cis_inrqty as nvarchar(10)) + ' / ' + cast(cis_mtrqty as nvarchar(10)) + ' / ' + 
			cast(cis_cft as nvarchar(10)) + ' / ' + cast(cis_cbm as nvarchar(10)) + ' / ' +
			cis_ftyprctrm + ' / ' + cis_hkprctrm + ' / ' + cis_trantrm as 'cis_colpck',
		cis_inrdin,
		cis_inrwin,
		cis_inrhin,
		cis_mtrdin,
		cis_mtrwin,
		cis_mtrhin,
		cis_inrdcm,
		cis_inrwcm,
		cis_inrhcm,
		cis_mtrdcm,
		cis_mtrwcm,
		cis_mtrhcm,
		cih.cip_qutdat,
		cih.cip_imqutdat,
		cis_creusr,
		cis_updusr,
		cis_credat,
		cis_upddat,
		cast(cis_timstp as int ) as 'cis_timstp',
		cis_pckitr,
		cis_conftr,
		cis_contopc,
		cis_pcprc,
		isnull(cis_cusstyno,'') as 'cis_cusstyno',
		'' as 'imu_std',
		ivi_venitm,
		cis_moq,
		cis_moqunttyp,
		cis_moa,
		cis_season,
		cis_year,
		cip_latest,
		'Y' as cip_effcpo
	from	CUITMPRC cih (nolock)
		join #CUITMPRC_tmp tmp on
			tmp.cip_cocde = cih.cip_cocde and
			tmp.cip_cusno = cih.cip_cusno and
			tmp.cip_seccus = cih.cip_seccus and
			tmp.cip_itmno = cih.cip_itmno and
			tmp.cip_colcde = cih.cip_colcde and
			tmp.cip_untcde = cih.cip_untcde and
			tmp.cip_inrqty = cih.cip_inrqty and
			tmp.cip_mtrqty = cih.cip_mtrqty and
			tmp.cip_hkprctrm = cih.cip_hkprctrm and
			tmp.cip_ftyprctrm = cih.cip_ftyprctrm and
			tmp.cip_trantrm = cih.cip_trantrm and
			tmp.cip_upddat = cih.cip_upddat
		left join CUITMHIS (nolock) on
			cis_cocde = cih.cip_cocde and
			cis_cusno = cih.cip_cusno and
			cis_seccus = cih.cip_seccus and
			cis_itmno = cih.cip_itmno and
			cis_colcde = cih.cip_colcde and
			cis_untcde = cih.cip_untcde and
			cis_inrqty = cih.cip_inrqty and
			cis_mtrqty = cih.cip_mtrqty and
			cis_conftr = cih.cip_conftr and
			cis_hkprctrm = cih.cip_hkprctrm and
			cis_ftyprctrm = cih.cip_ftyprctrm and
			cis_trantrm = cih.cip_trantrm
		left join IMVENINF (nolock) on
			ivi_itmno = cih.cip_itmno and
			ivi_venno = cih.cip_prdven
	where	@sod_credat between cip_effdat and cip_expdat and
		cip_venno = @cip_venno and
		cip_prdven = @cip_prdven and
		cis_itmno in(	select ibi.ibi_itmno from IMBASINF ibi (nolock) 
				left join IMBASINF als (nolock) on ibi.ibi_alsitmno = als.ibi_itmno
				where ibi.ibi_itmno = @cis_itmno or (ibi.ibi_alsitmno = @cis_itmno and isnull(als.ibi_itmsts,'') <> 'OLD')
				UNION
				select ibi.ibi_alsitmno from IMBASINF ibi (nolock) 
				left join IMBASINF als (nolock) on ibi.ibi_alsitmno = als.ibi_itmno
				where ibi.ibi_itmno = @cis_itmno and isnull(als.ibi_itmsts,'') <> 'OLD'
				) and
		cis_cusno in (	select cbi_cusno from CUBASINF (nolock)
				where (cbi_cusali = @cis_cusno or cbi_cusno = @cis_cusno) and cbi_cusno  <> ''
			   	UNION
			   	select cbi_cusali from CUBASINF (nolock)
				where cbi_cusno = @cis_cusno and cbi_cusali <> '' ) and
		cis_seccus = ''
	order by cis_colcde asc, cis_untcde asc, cis_inrqty asc, cis_mtrqty asc, cis_conftr desc
end
else
begin
	select	cis_cocde,
		cis_cusno,
		cis_seccus,
		cis_itmno,
		cis_itmdsc,
		cis_itmventyp,
		cis_cusitm,
		cis_colcde,
		cis_coldsc,
		cis_cuscol,
		cih.cip_venno,
		cih.cip_prdven,
		cis_cusven,
		cis_tradeven,
		cis_examven,
		cis_untcde,
		cis_inrqty,
		cis_mtrqty,
		cis_cft,
		cis_cbm,
		cis_refdoc,
		cis_docdat,
		cih.cip_cus1no,
		cih.cip_cus2no,
		cih.cip_ftyprctrm,
		cih.cip_hkprctrm,
		cih.cip_trantrm,
		cih.cip_effdat,
		cih.cip_expdat,
		cis_cussku,
		cih.cip_fcurcde,
		cih.cip_ftycst,
		cih.cip_bomcst,
		cih.cip_ftyprc,
		cih.cip_curcde,
		cih.cip_muminprc as 'cip_minprc',
		cih.cip_basprc,
		cis_ordqty,
		cih.cip_adjprc as 'cis_selprc',
		cis_hrmcde,
		cis_dtyrat, 
		cis_dept,
		cis_typcode,
		cis_code1,
		cis_code2,
		cis_code3,
		cis_cususdcur,
		cis_cususd,
		cis_cuscadcur,
		cis_cuscad,
		cast(cis_colcde as nvarchar(30)) + ' / ' + cast(cis_untcde as nvarchar(6)) + ' / ' + 
			cast(cis_inrqty as nvarchar(10)) + ' / ' + cast(cis_mtrqty as nvarchar(10)) + ' / ' + 
			cast(cis_cft as nvarchar(10)) + ' / ' + cast(cis_cbm as nvarchar(10)) + ' / ' +
			cis_ftyprctrm + ' / ' + cis_hkprctrm + ' / ' + cis_trantrm as 'cis_colpck',
		cis_inrdin,
		cis_inrwin,
		cis_inrhin,
		cis_mtrdin,
		cis_mtrwin,
		cis_mtrhin,
		cis_inrdcm,
		cis_inrwcm,
		cis_inrhcm,
		cis_mtrdcm,
		cis_mtrwcm,
		cis_mtrhcm,
		cih.cip_qutdat,
		cih.cip_imqutdat,
		cis_creusr,
		cis_updusr,
		cis_credat,
		cis_upddat,
		cast(cis_timstp as int ) as 'cis_timstp',
		cis_pckitr,
		cis_conftr,
		cis_contopc,
		cis_pcprc,
		isnull(cis_cusstyno,'') as 'cis_cusstyno',
		'' as 'imu_std',
		ivi_venitm,
		cis_moq,
		cis_moqunttyp,
		cis_moa,
		cis_season,
		cis_year,
		cip_latest,
		'Y' as cip_effcpo
	from	CUITMPRC cih (nolock)
		join #CUITMPRC_tmp tmp on
			tmp.cip_cocde = cih.cip_cocde and
			tmp.cip_cusno = cih.cip_cusno and
			tmp.cip_seccus = cih.cip_seccus and
			tmp.cip_itmno = cih.cip_itmno and
			tmp.cip_colcde = cih.cip_colcde and
			tmp.cip_untcde = cih.cip_untcde and
			tmp.cip_inrqty = cih.cip_inrqty and
			tmp.cip_mtrqty = cih.cip_mtrqty and
			tmp.cip_hkprctrm = cih.cip_hkprctrm and
			tmp.cip_ftyprctrm = cih.cip_ftyprctrm and
			tmp.cip_trantrm = cih.cip_trantrm and
			tmp.cip_upddat = cih.cip_upddat
		left join CUITMHIS (nolock) on
			cis_cocde = cih.cip_cocde and
			cis_cusno = cih.cip_cusno and
			cis_seccus = cih.cip_seccus and
			cis_itmno = cih.cip_itmno and
			cis_colcde = cih.cip_colcde and
			cis_untcde = cih.cip_untcde and
			cis_inrqty = cih.cip_inrqty and
			cis_mtrqty = cih.cip_mtrqty and
			cis_conftr = cih.cip_conftr and
			cis_hkprctrm = cih.cip_hkprctrm and
			cis_ftyprctrm = cih.cip_ftyprctrm and
			cis_trantrm = cih.cip_trantrm
		left join IMVENINF (nolock) on
			ivi_itmno = cih.cip_itmno and
			ivi_venno = cih.cip_prdven
	where	@sod_credat between cip_effdat and cip_expdat and
		cip_venno = @cip_venno and
		cip_prdven = @cip_prdven and
		cis_itmno in (select ibi.ibi_itmno from IMBASINF ibi (nolock) 
				left join IMBASINF als (nolock) on ibi.ibi_alsitmno = als.ibi_itmno
				where ibi.ibi_itmno = @cis_itmno or (ibi.ibi_alsitmno = @cis_itmno and isnull(als.ibi_itmsts,'') <> 'OLD')
				UNION
				select ibi.ibi_alsitmno from IMBASINF ibi (nolock) 
				left join IMBASINF als (nolock) on ibi.ibi_alsitmno = als.ibi_itmno
				where ibi.ibi_itmno = @cis_itmno and isnull(als.ibi_itmsts,'') <> 'OLD'
				) and
		cis_cusno in (select cbi_cusno from CUBASINF (nolock)
				where (cbi_cusali = @cis_cusno or cbi_cusno = @cis_cusno) and cbi_cusno  <> ''
			   	UNION
			   	select cbi_cusali from CUBASINF (nolock)
				where cbi_cusno = @cis_cusno and cbi_cusali <> '') and
		cis_seccus in (select cbi_cusno from cubasinf (nolock)
				where (cbi_cusali = @cis_seccus or cbi_cusno = @cis_seccus) and cbi_cusno <> ''
			   	UNION
			   	select cbi_cusali from CUBASINF (nolock) where cbi_cusno = @cis_seccus and cbi_cusali  <> '')
	order by cis_colcde asc, cis_untcde asc, cis_inrqty asc, cis_mtrqty asc, cis_conftr desc
end

END












GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMPRC_SC_PV] TO [ERPUSER] AS [dbo]
GO
