/****** Object:  StoredProcedure [dbo].[sp_select_PKR00001B_NET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKR00001B_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKR00001B_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/*
=================================================================
Program ID	: sp_select_PKR00001B_NET
Description	: Retrieve Packing List Data (Walmart)
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2015-05-22 	David Yue		SP Created
=================================================================
*/

CREATE    procedure [dbo].[sp_select_PKR00001B_NET] 
@cocde		nvarchar(6) , 
@from		nvarchar(20),    
@to		nvarchar(20)

AS    
BEGIN    

declare    
@yco_conam	varchar(100),    
@yco_addr	varchar(200),    
@yco_phoneno	varchar(50),    
@yco_faxno	varchar(50),    
@yco_logoimgpth	varchar(100),
@yco_venid	varchar(7),    
@vw_sumttlctn	int

select	@yco_conam = isnull(yco_conam, ''),
	@yco_addr = isnull(yco_addr, ''),
	@yco_phoneno = isnull(yco_phoneno, ''),
	@yco_faxno = isnull(yco_faxno, ''),
	@yco_logoimgpth = isnull(yco_logoimgpth, ''),
	@yco_venid = isnull(yco_venid, '')
from	SYCOMINF (nolock)
where	yco_cocde = @cocde

select	case (select count(distinct(hid_cusitm))   from SHIPGDTL (nolock) where hid_cocde = @cocde and hid_shpno = hih_shpno and hid_invno = hiv_invno) when 1 then 'Y' else 'N' end as 'rpt_single',
	@cocde as 'yco_cocde',
	@yco_conam as 'yco_conam',
	@yco_addr as 'yco_addr',
	@yco_phoneno as 'yco_phoneno',
	@yco_faxno as 'yco_faxno',
	@yco_logoimgpth as 'yco_logoimgpth',
	@yco_venid as 'yco_venid',
	hiv_invno,
	hih_shpno,
	hiv_credat,
	cbi_cusnam,
	ltrim(rtrim(hih_bilent)) as 'hih_bilent',
	ltrim(rtrim(hih_biladr)) as 'hih_biladr',
	ltrim(rtrim(hih_bilstt)) as 'hih_bilstt',
	ltrim(rtrim(bilcty.ysi_dsc)) as 'hih_bilcty',
	ltrim(rtrim(hih_bilzip)) as 'hih_bilzip',
	ltrim(rtrim(hih_ves)) as 'hih_ves',
	ltrim(rtrim(hih_voy)) as 'hih_voy',
	ltrim(rtrim(hih_potloa)) as 'hih_potloa',
	ltrim(rtrim(hih_dst)) as 'hih_dst',
	ltrim(rtrim(hiv_cover)) as 'hiv_cover',
	hid_shpseq,
	hid_ordno,
	hid_ordseq,
	--isnull(hsm_engdsc, '') as 'hsm_engdsc',
	case len(hid_itmshm) when 0 then ltrim(rtrim(isnull(hsm_engdsc, ''))) else ltrim(rtrim(hid_itmshm)) end as 'hid_itmshm',
	ltrim(rtrim(hid_cuspo)) as 'hid_cuspo',
	ltrim(rtrim(hid_cusitm)) as 'hid_cusitm',
	hid_ttlctn,
	hid_contopc,
	case isnull(hid_contopc,'') when 'Y' then (hid_shpqty * hid_conftr) else hid_shpqty end as 'hid_shpqty',
	case isnull(hid_contopc,'') when 'Y' then (hid_inrctn * hid_conftr) else hid_inrctn end as 'hid_inrctn',
	case isnull(hid_contopc,'') when 'Y' then (hid_mtrctn * hid_conftr) else hid_mtrctn end as 'hid_mtrctn',
--	hid_grswgt,
	hpd_gw_kg as 'hid_grswgt',
--	hid_netwgt,
	hpd_nw_kg as 'hid_netwgt',
	hpd_l_cm as 'hid_mtrdcm',
	hpd_w_cm as 'hid_mtrwcm',
	hpd_h_cm as 'hid_mtrhcm',
	hpd_ttlgw_kg as 'hpd_ttlgw_kg',
	ltrim(rtrim(hid_itmdsc)) as 'hid_itmdsc',
--	hid_ttlctn * hid_grswgt as 'hid_ttlgwt',
	hid_ttlctn * hpd_gw_kg as 'hid_ttlgwt',
--	hid_ttlctn * hid_netwgt as 'hid_ttlnwt',
	hid_ttlctn * hpd_nw_kg as 'hid_ttlnwt',
	hid_ttlvol,
	hih_cntyorgn,
	hpd_ttlcbm_cm,
	hiv_plrmk,
	right('0' + ltrim(rtrim(str(datepart(dd, hiv_credat)))), 2) + '-' +
		case datepart(mm, hiv_credat) when 1 then 'Jan' when 2 then
		'Feb' when 3 then 'Mar' when 4 then 'Apr' when 5 then 'May'
		when 6 then 'Jun' when 7 then 'Jul' when 8 then 'Aug' when
		9 then 'Sep' when 10 then 'Oct' when 11 then 'Nov' when 12
		then 'Dec' end + '-' + 
		right(ltrim(rtrim(str(datepart(yyyy, hiv_credat)))), 2) as 'hiv_credat_str',
	isnull(hid_dsc_f1,'') as 'hid_dsc_f1'



from	SHINVHDR
	join SHIPGHDR (nolock) on
		hih_cocde = hiv_cocde and
		hih_shpno = hiv_shpno
	join CUBASINF (nolock) on
		cbi_cusno = hih_cus1no
	left join SYSETINF bilcty (nolock) on
		bilcty.ysi_typ = '02' and
		bilcty.ysi_cde = hih_bilcty
	join SHIPGDTL (nolock) on
		hid_cocde = hih_cocde and
		hid_shpno = hih_shpno and
		hid_invno = hiv_invno
	left join SHSHPMRK (nolock) on
		hsm_cocde = hih_cocde and
		hsm_invno = hiv_invno and
		hsm_shpno = hih_shpno and
		hsm_shptyp = 'M'
left join shpckdim pdm on 
	 pdm.hpd_shpno = hid_shpno and pdm.hpd_shpseq = hid_shpseq
		and pdm.hpd_dimtyp = 'Mod'
		and (
			(hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
			or (hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
			)

where	hiv_cocde = @cocde and
	hiv_invno between @from and @to
order by hiv_invno, hid_cusitm, hid_shpno

END










GO
GRANT EXECUTE ON [dbo].[sp_select_PKR00001B_NET] TO [ERPUSER] AS [dbo]
GO
