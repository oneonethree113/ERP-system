/****** Object:  StoredProcedure [dbo].[sp_select_INR00001SUBA_NET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00001SUBA_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00001SUBA_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



























/*** 24 Jul 2003	Lewia To		Ignor Company code for select system file *********/


CREATE             procedure [dbo].[sp_select_INR00001SUBA_NET]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cocde nvarchar(6) ,
@from nvarchar(20),
@to nvarchar(20) ,
--Added by Mark Lau 20060929    
@printGroup	nvarchar(1)                                          
---------------------------------------------- 
 
AS
begin

Select	distinct
	hdc_shpno as 'hdc_shpno',
	 cast(hdc_shpseq as nvarchar(20)) as  'hdc_shpseq',
	 cast(hdc_ctnseq as nvarchar(20))  as 'hdc_ctnseq',
	ltrim(str(hdc_from)) as 'hdc_from',
	ltrim(str(hdc_to)) as 'hdc_to',
	'C/NO.  '+ltrim(str(hdc_from))  +' - ' + ltrim(str(hdc_to))  as 'hdc_fromto',

	--hid_itmno,	

	--Added by Mark Lau 20060927
		--Added by Mark Lau 20080516, Add CDTVX
	case when isnull(ica_itmno,'') <> '' then ica_cusalsitm 
	else
	case when @printGroup = '1' then
		--dbo.groupnewitmno(hid_itmno)
		--20150707
		ltrim(rtrim(hid_itmno))
		else
		ltrim(rtrim(hid_itmno))
		end end as 'hid_itmno',
	
	hid_ctrcfs,	hid_cuspo,	hid_ordno  as  'hid_ordno',
	CASE ltrim(str(hid_inrctn)) WHEN '0' THEN
		'                       ' + ltrim( str(hid_mtrctn)) + ' ' + ysi_dsc
	ELSE
		ltrim(str(hid_inrctn)) + ' ' + ysi_dsc +'          ' +ltrim( str(hid_mtrctn)) + ' ' + ysi_dsc
	END as 'packing',
	hid_invno as 'hid_invno',
--	ltrim(str(hid_mtrdcm,10,2)) as 'hid_mtrdcm',
	ltrim(str(hpd_l_cm,10,2)) as 'hid_mtrdcm',
--	ltrim(str(hid_mtrwcm,10,2)) as 'hid_mtrwcm',
	ltrim(str(hpd_w_cm,10,2)) as 'hid_mtrwcm',
--	ltrim(str(hid_mtrhcm,10,2)) as 'hid_mtrhcm',
	ltrim(str(hpd_h_cm,10,2)) as 'hid_mtrhcm',
	Case isnull(hid_cusitm, '') when '' then hid_itmno else hid_cusitm end as 'hid_cusitm',
	hid_ctnftr as 	'hid_ctnftr' ,
	convert(int,hpd_pdnum) as 'hpd_pdnum',
Case isnull(hid_cusitm, '') when '' then hid_itmno else hid_cusitm end as 'hid_cusitm'

From 	SHIPGDTL
left join shpckdim pdm on 
	 pdm.hpd_shpno = hid_shpno and pdm.hpd_shpseq = hid_shpseq
		and pdm.hpd_dimtyp = 'Mod'
		and (
			(hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
			or (hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
			)

Left join SYSETINF on case when isnull(hid_custum,'') <> '' then hid_custum else hid_untcde end = ysi_cde and ysi_typ = '05'
left join shipghdr on hih_shpno = hid_shpno
left join SHPCUSSTY ca on  hid_itmno  = ca.ica_itmno  and ca.ica_apvsts = 'Y' and ca.sod_ordno = hid_ordno and ca.sod_ordseq = hid_ordseq
,SHDTLCTN, SHINVHDR
WHERE 	
hiv_cocde = @cocde AND
hiv_invno >= @from AND
hiv_invno <= @to AND
hid_cocde = hiv_cocde AND
hid_shpno = hiv_shpno AND
hdc_cocde = hid_cocde AND
hdc_shpno = hid_shpno AND

hdc_shpseq = hid_shpseq
UNION
Select	distinct
	hid_shpno as 'hid_shpno',
	 cast(hid_shpseq as nvarchar(20)) as  'hdc_shpseq',
	'0' as 'hdc_ctnseq',
	hid_ctnstr as 'hdc_from' ,
	hid_ctnend as 'hdc_to',
	'C/NO.  '+ltrim(str(hid_ctnstr))  +' - ' + ltrim(str(hid_ctnend))  as 'hdc_fromto',

	case when isnull(ica_itmno,'') <> '' then ica_cusalsitm 
	else
	case when @printGroup = '1' then
		--dbo.groupnewitmno(hid_itmno)
		--20150707
		ltrim(rtrim(hid_itmno))

		else
		ltrim(rtrim(hid_itmno))
		end end as 'hid_itmno',

	hid_ctrcfs,	hid_cuspo,	hid_ordno as 'hid_ordno',
	CASE ltrim(str(hid_inrctn)) WHEN '0' THEN
		'                       ' + ltrim( str(hid_mtrctn)) + ' ' + ysi_dsc
	ELSE
		ltrim(str(hid_inrctn)) + ' ' + ysi_dsc +'          ' +ltrim( str(hid_mtrctn)) + ' ' + ysi_dsc
	END as 'Packing',
	hid_invno as 'hid_invno',

--	ltrim(str(hid_mtrdcm,10,2)),
	ltrim(str(hpd_l_cm,10,2)) as 'hid_mtrdcm',
--	ltrim(str(hid_mtrwcm,10,2)),
	ltrim(str(hpd_w_cm,10,2)) as 'hid_mtrwcm',
--	ltrim(str(hid_mtrhcm,10,2)),
	ltrim(str(hpd_h_cm,10,2)) as 'hid_mtrhcm',

	Case isnull(hid_cusitm, '') when '' then hid_itmno else hid_cusitm end,
	hid_ctnftr as 	'hid_ctnftr' ,
convert(int,hpd_pdnum) as 'hpd_pdnum',
Case isnull(hid_cusitm, '') when '' then hid_itmno else hid_cusitm end as 'hid_cusitm'

From 	SHIPGDTL
Left join SYSETINF on case when isnull(hid_custum,'') <> '' then hid_custum else hid_untcde end = ysi_cde and ysi_typ = '05'
left join shipghdr on hih_shpno = hid_shpno
left join SHPCUSSTY ca on  hid_itmno  = ca.ica_itmno  and ca.ica_apvsts = 'Y' and ca.sod_ordno = hid_ordno and ca.sod_ordseq = hid_ordseq
left join shpckdim pdm on 
	 pdm.hpd_shpno = hid_shpno and pdm.hpd_shpseq = hid_shpseq
		and pdm.hpd_dimtyp = 'Mod'
		and (
			(hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
			or (hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
			)
, SHINVHDR
WHERE 	
hiv_cocde = @cocde AND
hiv_invno >= @from AND
hiv_invno <= @to 
and 
hid_cocde = hiv_cocde AND
hid_shpno = hiv_shpno AND
hid_shpno + str(hid_shpseq,4) not in
	(select hdc_shpno + str(hdc_shpseq,4) from SHDTLCTN, SHINVHDR WHERE hiv_cocde = @cocde AND
	hiv_invno >= @from AND
	hiv_invno <= @to  AND
	hdc_cocde = hiv_cocde AND
	hdc_shpno = hiv_shpno) 
ORDER BY  hdc_from



end





















GO
GRANT EXECUTE ON [dbo].[sp_select_INR00001SUBA_NET] TO [ERPUSER] AS [dbo]
GO
