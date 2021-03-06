/****** Object:  StoredProcedure [dbo].[sp_select_IMM00015_IMITMEXDAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00015_IMITMEXDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00015_IMITMEXDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=================================================================
Program ID	: sp_select_IMM00015_IMITMEXDAT
Description	: Retrieve IMITMEXDAT Data from IM
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-12-04 	David Yue		SP Created
=================================================================
*/


CREATE PROCEDURE [dbo].[sp_select_IMM00015_IMITMEXDAT] 

@itmno	nvarchar(30)

AS

select	case vbi_ventyp when 'E' then '' else 'X' end as 'status',
	ibi_venno,
	ivi_venno,
	ibi_cusven,
	imu_cus1no,
	imu_cus2no,
	ivi_venitm,
	ibi_itmno,
	ibi_dsgno,
	case ibi_typ when 'ASS' then 'AST' else ibi_typ end as 'ibi_typ',
	ibi_catlvl4,
	ibi_engdsc,
	ibi_chndsc,
	isnull(mat.ysi_dsc,'') as 'ibi_material',
	isnull(nat.ysi_dsc,'') as 'ibi_itmnat',
	isnull(grp.ysi_dsc,'') as 'ibi_prdgrp',
	isnull(icn.ysi_dsc,'') as 'ibi_prdicon',
	case ibi_prdtyp when 'ODM' then 'OEM+S.R.' else ibi_prdtyp end as 'ibi_prdtyp',
	isnull(ibi_prdsizeval,'') as 'ibi_prdsizeval',
	isnull(prd.ysi_dsc,'') as 'ibi_prdsizeunt',
	ibi_prdsizetyp,
	icf_colcde,
	icf_coldsc,
	icf_vencol,
	ibi_lnecde,
	ycf_dsc1 as 'ipi_pckunt',
	ipi_conftr,
	ipi_inrqty,
	ipi_mtrqty,
	ipi_inrdin,
	ipi_inrwin,
	ipi_inrhin,
	ipi_mtrdin,
	ipi_mtrwin,
	ipi_mtrhin,
	ipi_cft,
	'INCH' as 'ipi_pckmsr',
	case ipi_grswgt when 0 then '' else cast(ipi_grswgt as varchar(14)) end as 'ipi_grswgt',
	case ipi_netwgt when 0 then '' else cast(ipi_netwgt as varchar(14)) end as 'ipi_netwgt',
	ipi_pckitr,
	ftyprctrm.ysi_dsc as 'imu_ftyprctrm',
	hkprctrm.ysi_dsc as 'imu_hkprctrm',
	imu_trantrm,
	imu_curcde,
	imu_ftyprc,
	isnull(imm_moqunttyp,'') as 'imm_moqunttyp',
	isnull(case imm_moqctn when 0 then '' else cast(imm_moqctn as varchar(14)) end, '') as 'imm_moqctn',
	isnull(case imm_moa when 0 then '' else imm_curcde end, '') as 'imm_curcde',
	isnull(case imm_moa when 0 then '' else cast(imm_moa as varchar(14)) end, '') as 'imm_moa',
	right('0' + cast(datepart(mm, ipi_qutdat) as varchar(2)), 2) + '/' + right('0' + cast(datepart(dd, ipi_qutdat) as varchar(2)), 2) + '/' + cast(datepart(yyyy, ipi_qutdat) as varchar(4)) as 'ipi_qutdat',
	right('0' + cast(datepart(mm, imu_expdat) as varchar(2)), 2) + '/' + right('0' + cast(datepart(dd, imu_expdat) as varchar(2)), 2) + '/' + cast(datepart(yyyy, imu_expdat) as varchar(4)) as 'imu_expdat',
	ibi_rmk,
	isnull(ici_cstrmk,'') as 'ici_cstrmk',
	imu_estprcflg,
	imu_estprcref
from	IMPRCINF (nolock)
	join IMBASINF (nolock) on
		ibi_itmno = imu_itmno
	join VNBASINF (nolock) on
		vbi_venno = ibi_venno
	join IMVENINF (nolock) on
		ivi_itmno = imu_itmno and
		ivi_venno = imu_prdven
	left join SYSETINF mat (nolock) on
		mat.ysi_typ = '25' and
		mat.ysi_cde = ibi_material
	left join SYSETINF nat (nolock) on
		nat.ysi_typ = '29' and
		nat.ysi_cde = ibi_itmnat
	left join SYSETINF grp (nolock) on
		grp.ysi_typ = '24' and
		grp.ysi_cde = ibi_prdgrp
	left join SYSETINF icn (nolock) on
		icn.ysi_typ = '28' and
		icn.ysi_cde = ibi_prdicon
	left join SYSETINF prd (nolock) on
		prd.ysi_typ = '27' and
		prd.ysi_cde = ibi_prdsizeunt
	join IMCOLINF (nolock) on
		icf_itmno = ibi_itmno
	join IMPCKINF (nolock) on
		ipi_itmno = ibi_itmno and
		ipi_pckunt = imu_pckunt and
		ipi_inrqty = imu_inrqty and
		ipi_mtrqty = imu_mtrqty and
		ipi_cus1no = imu_cus1no and
		ipi_cus2no = imu_cus2no
	join SYCONFTR (nolock) on
		ycf_systyp = 'Y' and
		ycf_code1 = ipi_pckunt and
		ycf_code2 = 'PC'
	left join IMMOQMOA (nolock) on
		imm_itmno = imu_itmno and
		imm_cus1no = imu_cus1no and
		imm_cus2no = imu_cus2no
	left join IMCSTINF (nolock) on
		ici_itmno = imu_itmno
	left join SYSETINF ftyprctrm (nolock) on
		ftyprctrm.ysi_typ = '03' and
		ftyprctrm.ysi_cde = imu_ftyprctrm
	left join SYSETINF hkprctrm (nolocK) on
		hkprctrm.ysi_typ = '03' and
		hkprctrm.ysi_cde = imu_hkprctrm
where	imu_itmno = @itmno
order by ivi_venno, ipi_pckunt, ipi_inrqty, ipi_mtrqty, imu_cus1no, imu_cus2no, imu_ftyprctrm, imu_hkprctrm, imu_trantrm


GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00015_IMITMEXDAT] TO [ERPUSER] AS [dbo]
GO
