/****** Object:  StoredProcedure [dbo].[sp_select_INR00001B_NET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00001B_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00001B_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





















/*
=================================================================
Program ID	: sp_select_INR00001B_NET
Description	: Retrieve Customer Invoice Data (Walmart)
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2015-05-13 	David Yue		SP Created
=================================================================
*/

CREATE               procedure [dbo].[sp_select_INR00001B_NET] 
@cocde		nvarchar(6) , 
@from		nvarchar(20),    
@to		nvarchar(20),   
@show_hstu	nvarchar(1),    
@show_mannam	nvarchar(1),    
@show_cptbkd	nvarchar(1),    
@laf    	nvarchar(1),    
@show_jobno	nvarchar(1),    
@show_qtybkd	nvarchar(1),    
@show_cussku	nvarchar(1),      
@rpt_heading	char(1) = 0 ,   
@optSort	varchar(6) = 'ITM', 
@printGroup	nvarchar(1),  
@printAlias	nvarchar(1),  
@printAss	nvarchar(1),
@optblank	nvarchar(1)

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

select	case (select count(*) from SHIPGDTL (nolock) where hid_cocde = @cocde and hid_shpno = hih_shpno and hid_invno = hiv_invno) when 1 then 'Y' else 'N' end as 'rpt_single',
	@show_hstu as 'show_hstu',
	@show_mannam as 'show_mannam',
	@show_cptbkd as 'show_cptbkd',
	@show_jobno as 'show_jobno',
	@show_qtybkd as 'show_qtybkd',
	@show_cussku as 'show_cussku',
	@laf as 'laf',
	case @rpt_heading when 0 then 'INVOICE' else 'COMMERCIAL INVOICE' end as 'rpt_title',
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
	right('0' + ltrim(rtrim(str(datepart(dd, hiv_credat)))), 2) + '-' +
		case datepart(mm, hiv_credat) when 1 then 'Jan' when 2 then
		'Feb' when 3 then 'Mar' when 4 then 'Apr' when 5 then 'May'
		when 6 then 'Jun' when 7 then 'Jul' when 8 then 'Aug' when
		9 then 'Sep' when 10 then 'Oct' when 11 then 'Nov' when 12
		then 'Dec' end + '-' + 
		right(ltrim(rtrim(str(datepart(yyyy, hiv_credat)))), 2) as 'hiv_credat_str',
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
	right('0' + ltrim(rtrim(str(datepart(dd, hih_slnonb)))), 2) + '-' +
		case datepart(mm, hih_slnonb) when 1 then 'Jan' when 2 then
		'Feb' when 3 then 'Mar' when 4 then 'Apr' when 5 then 'May'
		when 6 then 'Jun' when 7 then 'Jul' when 8 then 'Aug' when
		9 then 'Sep' when 10 then 'Oct' when 11 then 'Nov' when 12
		then 'Dec' end + '-' + 
		right(ltrim(rtrim(str(datepart(yyyy, hih_slnonb)))), 2) as 'hih_slnonb',
	ltrim(rtrim(paytrm.ysi_dsc)) as 'hiv_paytrm',
	Upper(ltrim(rtrim(prctrm.ysi_dsc))) as 'hiv_prctrm',
	ltrim(rtrim(hih_lcbank)) as 'hih_lcbank',
	ltrim(rtrim(hih_lcno)) as 'hih_lcno',
	ltrim(rtrim(hiv_cover)) as 'hiv_cover',
	hid_shpseq,
	hid_ordno,
	hid_ordseq,
	--isnull(hsm_engdsc, '') as 'hsm_engdsc',
	case len(hid_itmshm) when 0 then ltrim(rtrim(isnull(hsm_engdsc, ''))) else ltrim(rtrim(hid_itmshm)) end as 'hid_itmshm',
	ltrim(rtrim(hid_cuspo)) as 'hid_cuspo',
	ltrim(rtrim(hid_cusitm)) as 'hid_cusitm',
	ltrim(rtrim(sod_dept)) as 'sod_dept',
	ltrim(rtrim(hid_itmdsc)) as 'hid_itmdsc',
	hid_ttlctn,
	hid_contopc,
	case isnull(hid_contopc,'') when 'Y' then (hid_shpqty * hid_conftr) else hid_shpqty end as 'hid_shpqty',
	untcde.ysi_dsc as 'hid_untcde',
	hid_untsel,
	case isnull(hid_contopc,'') when 'Y' then round(hid_selprc / hid_conftr, 4) else round(hid_selprc, 4) end as 'hid_selprc',
	round(hid_shpqty * hid_selprc, 4) as 'hid_sumamt',
	ltrim(rtrim(str(round(round(hid_shpqty * hid_selprc, 4) / hid_ttlctn, 4), 12, 4))) as 'hid_ctnprc',
	sod_code1,
	case (select count(*) from SCASSINF (nolock) where sai_cocde = hid_cocde and 
		sai_ordno = hid_ordno and sai_ordseq = hid_ordseq and sai_itmno = hid_itmno) 
		when 0 then 'N' else 'Y' end as 'hid_assort',
	sod_cusstyno,
	case when isnull(hid_contopc,'') = 'Y' and isnull(hid_custum,'') <> '' then
		case ltrim(rtrim(str(hid_inrctn))) when '0' then ltrim(rtrim(str(hid_mtrctn * hid_conftr))) +
		' ' + untcde.ysi_dsc + ' IN CTN.' else ltrim(rtrim(str(hid_inrctn * hid_conftr))) + ' ' + untcde.ysi_dsc +
		' IN INNER BOX, ' + ltrim(rtrim(str(hid_mtrctn * hid_conftr))) + ' ' + untcde.ysi_dsc + ' IN CTN.' end
		else case when isnull(hid_contopc,'') = 'Y' and isnull(hid_custum,'') = '' then 
		case ltrim(rtrim(str(hid_inrctn))) when '0' then ltrim(rtrim(str(hid_mtrctn * hid_conftr))) +
		' PC IN CTN.' else ltrim(rtrim(str(hid_inrctn * hid_conftr))) + ' PC IN INNER BOX, ' +
		ltrim(rtrim(str(hid_mtrctn * hid_conftr))) + ' PC IN CTN.' end else case ltrim(rtrim(str(hid_inrctn)))
		when '0' then ltrim(rtrim(str(hid_mtrctn))) + ' ' + untcde.ysi_dsc +' IN CTN.' else
		ltrim(rtrim(str(hid_inrctn))) + ' ' + untcde.ysi_dsc +' IN INNER BOX, ' + ltrim(rtrim(str(hid_mtrctn))) +
		' ' + untcde.ysi_dsc +' IN CTN.' end end end as 'hid_packing',
	--ltrim(rtrim(str(hid_ttlctn * hid_grswgt, 10, 2))) + ' KGS' as 'hid_ttlgwt',
	--ltrim(rtrim(str(hid_ttlctn * hid_netwgt, 10, 2))) + ' KGS' as 'hid_ttlnwt',
	hpd_ttlgw_kg as 'hid_ttlgwt',
	hpd_ttlnw_kg as 'hid_ttlnwt',
	hpd_ttlcbm_cm as 'hid_ttlcbm',
--	hid_ttlctn * hpd_gw_kg as 'hid_ttlgwt',
--	hid_ttlctn * hpd_nw_kg as 'hid_ttlnwt',
--	hid_ttlctn * hpd_cbm_cm as 'hid_ttlcbm',	--hid_grswgt, 
	hpd_gw_kg as 'hid_grswgt',
	--hid_netwgt,
	hpd_nw_kg as 'hid_netwgt',
	hih_cntyorgn,
	sod_hrmcde,
	sod_dtyrat,
	hid_cmprmk,
	hid_mannam,
	hid_manadr,
	Upper(hiv_exptnam) as 'hiv_exptnam',
	Upper(hiv_exptaddr) as 'hiv_exptaddr',
	hiv_ftrrmk,
	isnull(hid_name_f1,'') as 'hid_name_f1',
	isnull(hid_dsc_f1,'') as 'hid_dsc_f1',
	isnull(hid_name_f2,'') as 'hid_name_f2',
	isnull(hid_dsc_f2,'') as 'hid_dsc_f2',
	isnull(hid_name_f3,'') as 'hid_name_f3',
	isnull(hid_dsc_f3,'') as 'hid_dsc_f3',
hiv_lcno as 'hiv_lcno',
hiv_lcbank  as 'hiv_lcbank',
	right('0' + ltrim(rtrim(str(datepart(dd, hiv_lcdat)))), 2) + ' ' +
		case datepart(mm, hiv_lcdat) when 1 then 'Jan' when 2 then
'Feb' when 3 then 'Mar' when 4 then 'Apr' when 5 then 'May'
		when 6 then 'Jun' when 7 then 'Jul' when 8 then 'Aug' when
		9 then 'Sep' when 10 then 'Oct' when 11 then 'Nov' when 12
		then 'Dec' end + ' ' + 
		right(ltrim(rtrim(str(datepart(yyyy, hiv_lcdat)))), 2) as 'hiv_lcdat',


--'01 FEB 2015' as 'hiv_lcdat',

--left(convert(NVARCHAR(9), hiv_lcdat, 106),2) + '-' +  left(right(convert(NVARCHAR(9), hiv_lcdat, 106),6),3) + '-' + right(convert(NVARCHAR(9), hiv_lcdat, 106),2)   as'hiv_lcdat'     ,

--CONVERT(VARCHAR(3), DATENAME(MM, hiv_lcdat), 100)  as'hiv_lcdat',
--cast(CONVERT(nVARCHAR(20),hiv_lcdat,106) as nvarchar(20))   as'hiv_lcdat'     ,
--CONVERT(nVARCHAR(20),hiv_lcdat,106)   as'hiv_lcdat'     ,
hih_cus1no,
@optblank as 'optblank'    

from	SHINVHDR
	join SHIPGHDR (nolock) on
		hih_cocde = hiv_cocde and
		hih_shpno = hiv_shpno
	join CUBASINF (nolock) on
		cbi_cusno = hih_cus1no
	left join SYSETINF bilcty (nolock) on
		bilcty.ysi_typ = '02' and
		bilcty.ysi_cde = hih_bilcty
	left join SYSETINF paytrm (nolock) on
		paytrm.ysi_typ = '04' and
		paytrm.ysi_cde = hiv_paytrm
	left join SYSETINF prctrm (nolock) on
		prctrm.ysi_typ = '03' and
		prctrm.ysi_cde = hiv_prctrm
	join SHIPGDTL (nolock) on
		hid_cocde = hih_cocde and
		hid_shpno = hih_shpno and
		hid_invno = hiv_invno
	left join SHSHPMRK (nolock) on
		hsm_cocde = hih_cocde and
		hsm_invno = hiv_invno and
		hsm_shpno = hih_shpno and
		hsm_shptyp = 'M'
	left join SCORDDTL (nolock) on
		sod_cocde = hid_cocde and
		sod_ordno = hid_ordno and
		sod_ordseq = hid_ordseq
	left join SYSETINF untcde (nolock) on
		untcde.ysi_typ = '05' and
		untcde.ysi_cde = case when isnull(hid_custum,'') <> '' then hid_custum else case when isnull(hid_contopc,'') = 'Y' then 'PC' else hid_untcde end end
left join shpckdim pdm on 
	 pdm.hpd_shpno = hid_shpno and pdm.hpd_shpseq = hid_shpseq
		and pdm.hpd_dimtyp = 'Mod'
		and (
			(hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
			or (hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
			)

where	hiv_cocde = @cocde and
	hiv_invno between @from and @to and
	hih_shpsts <> 'HLD'
order by hiv_invno, hid_cusitm, hid_shpno

END



















GO
GRANT EXECUTE ON [dbo].[sp_select_INR00001B_NET] TO [ERPUSER] AS [dbo]
GO
