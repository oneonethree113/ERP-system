/****** Object:  StoredProcedure [dbo].[sp_select_POR00005]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00005]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00005]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO








/*
=================================================================
Program ID	: sp_select_POR00005
Description	: Select Data for PO Report
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-09-03	David Yue	SP Created
=================================================================
*/

CREATE PROCEDURE [dbo].[sp_select_POR00005]

@cocde		nvarchar(6),
@JP		nvarchar(1),	
@POfrom		nvarchar(20),
@POto		nvarchar(20),
@printGroup	nvarchar(1)

AS

-- Read Company Information --
declare 
@yco_conam	varchar(50),
@yco_addr	nvarchar(200),
@yco_logoimgpth	varchar(100),
@yco_phoneno	varchar(50),
@yco_faxno	varchar(50)

select	@yco_conam = yco_conam,	
	@yco_addr = yco_addr,
	@yco_logoimgpth = yco_logoimgpth, 
	@yco_phoneno = yco_phoneno,
	@yco_faxno = yco_faxno 
from	SYCOMINF (nolock)
where	yco_cocde = @cocde


select	@cocde as 'cocde',
	@yco_conam as 'conam',
	@yco_addr as 'addr',
	@yco_logoimgpth as 'logoimgpth',
	@yco_phoneno as 'phoneno',
	@yco_faxno as 'faxno',
	case when cv.vbi_vennam = '' and cv.vbi_venchnnam <> '' then cv.vbi_venchnnam else case when cv.vbi_vennam <> '' and cv.vbi_venchnnam = '' 
		then cv.vbi_vennam else case when cv.vbi_vennam <> '' and cv.vbi_venchnnam <> '' then cv.vbi_vennam +  ' (' + cv.vbi_venchnnam + ')' 
		end end end as 'vbi_vennam',
	cv.vbi_vensna,
	cbi_cussna as 'cbi_cussna',
	poh_porctp as 'poh_porctp',
	poh_prmcus as 'poh_prmcus',
	poh_venno as 'poh_venno',
	ltrim(str(datepart(mm, poh_credat))) + '/' + ltrim(str(datepart(dd, poh_credat))) + '/' + ltrim(str(datepart(yyyy, poh_credat))) as 'poh_credat',
	ltrim(str(datepart(mm, poh_issdat))) + '/' + ltrim(str(datepart(dd, poh_issdat))) + '/' + ltrim(str(datepart(yyyy, poh_issdat))) as 'poh_issdat',
	ltrim(str(datepart(mm, poh_pocdat))) + '/' + ltrim(str(datepart(dd, poh_pocdat))) + '/' + ltrim(str(datepart(yyyy, poh_pocdat))) as 'poh_pocdat',
	ltrim(str(datepart(mm, poh_pocdatend))) + '/' + ltrim(str(datepart(dd, poh_pocdatend))) + '/' + ltrim(str(datepart(yyyy, poh_pocdatend))) as 'poh_pocdatend',
	poh_cuspno as 'poh_cuspno',
	poh_reppno as 'poh_reppno',
	poh_purord as 'poh_purord', 
	ltrim(rtrim(case @cocde when 'TT' then 'This P.O. is issued on behalf of NEW LEADER. ' + char(10) + char(13) + '此張採購單乃代表 「聯通」發出。' + char(10) + char(13) 
		else case cv.vbi_bvennam when 'NO' then '' else 'This production note is issued on behalf of ' + cv.vbi_bvennam + '. ' + char(10) + char(13) + '此張生產單乃代表 「' + cv.vbi_bvennamc + '」發出。' + char(10) + char(13) end end +
		case poh_cusctn when 0 then '' else 'TOTAL CTN# - ' + ltrim(rtrim(str(poh_cusctn))) + char(10) + char(13) end + case poh_dest when '' then '' else 'DESTINATION: ' + ltrim(rtrim(poh_dest)) end +
		poh_rmk)) as 'poh_rmk',
	ltrim(rtrim(case @cocde when 'TT' then 'This P.O. is issued on behalf of NEW LEADER. ' + char(10) + char(13) + '此張採購單乃代表 「聯通」發出。' + char(10) + char(13) 
		else case cv.vbi_bvennam when 'NO' then '' else 'This production note is issued on behalf of ' + cv.vbi_bvennam + '. ' + char(10) + char(13) + '此張生產單乃代表 「' + cv.vbi_bvennamc + '」發出。' + char(10) + char(13) end end +
		case poh_cusctn when 0 then '' else 'TOTAL CTN# - ' + ltrim(rtrim(str(poh_cusctn))) + char(10) + char(13) end + case poh_dest when '' then '' else 'DESTINATION: ' + ltrim(rtrim(poh_dest)) + char(10) + char(13) end +
		poh_rmk)) as 'poh_rmk_Memo',

	pod_typcode as 'pod_typcode',
	pod_cuscol as 'pod_cuscol',
	pod_scno as 'pod_scno',
	case when @printGroup = '1'  then
		case when len(pod_itmno) < 11 or charindex('-',pod_itmno) > 0 or charindex('/',pod_itmno) >0 or (Upper(substring(pod_itmno,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(pod_itmno,7,2) = 'AS' then pod_itmno
		else 
		case when upper(substring(pod_itmno, 3, 1)) = 'A'   or upper(substring(pod_itmno, 3, 1)) = 'C'  or upper(substring(pod_itmno, 3, 1)) = 'D' or upper(substring(pod_itmno, 3, 1)) = 'T' or upper(substring(pod_itmno, 3, 1)) = 'X' or upper(substring(pod_itmno, 3, 1)) = 'V' then substring(pod_itmno,1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(pod_itmno, 3, 1)) = 'B' and (substring(pod_itmno, 4, 1) >= '0' And substring(pod_itmno, 4, 1) <= '9' ) And (substring(pod_itmno, 5, 1) >= '0' And substring(pod_itmno, 5, 1) <= '9' ) And  (substring(pod_itmno, 6, 1) >= '0' And substring(pod_itmno, 6, 1) <= '9') then substring(pod_itmno,1,11)
				else 
				case when upper(substring(pod_itmno, 3, 1)) = 'B' and (upper(substring(pod_itmno, 4, 1)) >= 'A' And upper(substring(pod_itmno, 4, 1)) <= 'Z' ) And (substring(pod_itmno, 5, 1) >= '0' And substring(pod_itmno, 5, 1) <= '9' ) And  (substring(pod_itmno, 6, 1) >= '0' And substring(pod_itmno, 6, 1) <= '9') then substring(pod_itmno,1,11)
					else pod_itmno
				end
			end
		end
	end
	else
		pod_itmno
	end as 'pod_itmno',
	case when @printGroup = '1'  then
		case when len(pod_venitm) < 11 or charindex('-',pod_venitm) > 0 or charindex('/',pod_venitm) >0 or (Upper(substring(pod_venitm,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(pod_venitm,7,2) = 'AS' then pod_venitm
		else 
		case when upper(substring(pod_venitm, 3, 1)) = 'A' or upper(substring(pod_itmno, 3, 1)) = 'C'  or upper(substring(pod_itmno, 3, 1)) = 'D' or upper(substring(pod_itmno, 3, 1)) = 'T' or upper(substring(pod_itmno, 3, 1)) = 'X' or upper(substring(pod_itmno, 3, 1)) = 'V' then substring(pod_venitm,1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(pod_venitm, 3, 1)) = 'B' and (substring(pod_venitm, 4, 1) >= '0' And substring(pod_venitm, 4, 1) <= '9' ) And (substring(pod_venitm, 5, 1) >= '0' And substring(pod_venitm, 5, 1) <= '9' ) And  (substring(pod_venitm, 6, 1) >= '0' And substring(pod_venitm, 6, 1) <= '9') then substring(pod_venitm,1,11)
				else 
				case when upper(substring(pod_venitm, 3, 1)) = 'B' and (upper(substring(pod_venitm, 4, 1)) >= 'A' And upper(substring(pod_venitm, 4, 1)) <= 'Z' ) And (substring(pod_venitm, 5, 1) >= '0' And substring(pod_venitm, 5, 1) <= '9' ) And  (substring(pod_venitm, 6, 1) >= '0' And substring(pod_venitm, 6, 1) <= '9') then substring(pod_venitm,1,11)
					else pod_venitm
				end
			end
		end
	end
	else
		pod_venitm
	end as 'pod_venitm',
	pod_engdsc as 'pod_engdsc',
	pod_engdsc as 'pod_engdsc_Memo',
	pod_chndsc as 'pod_chndsc',
	pod_chndsc as 'pod_chndsc_Memo',
	pod_inrctn as 'pod_inrctn',
	pod_mtrctn as 'pod_mtrctn',
	pod_cubcft as 'pod_cubcft',
	case isnull(sod_pjobno,'') when '' then pod_rmk
		else '取代 Job # ' + sod_pjobno + case isnull(pod_rmk,'') when '' then ''
			else  char(13) + pod_rmk
		end
	end as 'pod_rmk',
	case isnull(sod_pjobno,'') when '' then pod_rmk
		else '取代 Job # ' + sod_pjobno + case isnull(pod_rmk,'') when '' then ''
			else  char(13) + pod_rmk
		end
	end as 'pod_rmk_Memo',
	pod_jobord as 'pod_jobord',
	pod_cusitm as 'pod_cusitm',
	pod_cussku as 'pod_cussku',
	pod_code1 as 'pod_code1',
	pod_code2 as 'pod_code2',
	pod_code3 as 'pod_code3',
	pod_hrmcde as 'pod_hrmcde',
	pod_cususdcur,
	pod_cususd as 'pod_cususd',
	pod_cuscadcur,
	pod_cuscad as 'pod_cuscad',
	case when @printGroup = '1' then
		case when len(pod_itmno) < 11 or charindex('-',pod_itmno) > 0 or charindex('/',pod_itmno) >0 or (Upper(substring(pod_itmno,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(pod_itmno,7,2) = 'AS' then isnull(pod_vencol,'')
		else 
		case when upper(substring(pod_itmno, 3, 1)) = 'A' or upper(substring(pod_itmno, 3, 1)) = 'C'  or upper(substring(pod_itmno, 3, 1)) = 'D' or upper(substring(pod_itmno, 3, 1)) = 'T' or upper(substring(pod_itmno, 3, 1)) = 'X' or upper(substring(pod_itmno, 3, 1)) = 'V' then + '(' + substring(pod_itmno,12, len(pod_itmno) - 11) +  ') ' + isnull(pod_vencol,'')  --and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(pod_itmno, 3, 1)) = 'B' and (substring(pod_itmno, 4, 1) >= '0' And substring(pod_itmno, 4, 1) <= '9' ) And (substring(pod_itmno, 5, 1) >= '0' And substring(pod_itmno, 5, 1) <= '9' ) And  (substring(pod_itmno, 6, 1) >= '0' And substring(pod_itmno, 6, 1) <= '9') then  '(' +  substring(pod_itmno,12,len(pod_itmno) - 11) + ') ' + isnull(pod_vencol,'') 
				else 
				case when upper(substring(pod_itmno, 3, 1)) = 'B' and (upper(substring(pod_itmno, 4, 1)) >= 'A' And upper(substring(pod_itmno, 4, 1)) <= 'Z' ) And (substring(pod_itmno, 5, 1) >= '0' And substring(pod_itmno, 5, 1) <= '9' ) And  (substring(pod_itmno, 6, 1) >= '0' And substring(pod_itmno, 6, 1) <= '9') then  '(' + substring(pod_itmno,12,len(pod_itmno) - 11) + ') ' +  isnull(pod_vencol,'') 
					else isnull(pod_vencol,'') 
				end
			end
		end
	end
	else
		isnull(pod_vencol,'')
	end as 'pod_vencol',
	pod_coldsc as 'pod_coldsc',
	pod_coldsc as 'pod_coldsc_Memo',
	pod_purseq as 'pod_purseq',
	case when @printGroup = '1'  then
		case when len(pod_itmno) < 11 or charindex('-',pod_itmno) > 0 or charindex('/',pod_itmno) >0 or (Upper(substring(pod_itmno,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(pod_itmno,7,2) = 'AS' then pod_itmno
		else 
		case when upper(substring(pod_itmno, 3, 1)) = 'A' or upper(substring(pod_itmno, 3, 1)) = 'C'  or upper(substring(pod_itmno, 3, 1)) = 'D' or upper(substring(pod_itmno, 3, 1)) = 'T' or upper(substring(pod_itmno, 3, 1)) = 'X' or upper(substring(pod_itmno, 3, 1)) = 'V' then substring(pod_itmno,1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(pod_itmno, 3, 1)) = 'B' and (substring(pod_itmno, 4, 1) >= '0' And substring(pod_itmno, 4, 1) <= '9' ) And (substring(pod_itmno, 5, 1) >= '0' And substring(pod_itmno, 5, 1) <= '9' ) And  (substring(pod_itmno, 6, 1) >= '0' And substring(pod_itmno, 6, 1) <= '9') then substring(pod_itmno,1,11)
				else 
				case when upper(substring(pod_itmno, 3, 1)) = 'B' and (upper(substring(pod_itmno, 4, 1)) >= 'A' And upper(substring(pod_itmno, 4, 1)) <= 'Z' ) And (substring(pod_itmno, 5, 1) >= '0' And substring(pod_itmno, 5, 1) <= '9' ) And  (substring(pod_itmno, 6, 1) >= '0' And substring(pod_itmno, 6, 1) <= '9') then substring(pod_itmno,1,11)
					else pod_itmno
				end
			end
		end
	end
	else
		pod_itmno
	end + ltrim(pod_engdsc) + ysi_dsc + str(pod_inrctn,10,0) + str(pod_mtrctn,10,0) + str(pod_cubcft,10,2) as 'pod_key',
	pod_ctnstr as 'pod_ctnstr',
	pod_ctnend as 'pod_ctnend',
	pod_ttlctn as 'pod_ttlctn',
	ltrim(str(datepart(mm, pod_shpstr))) + '/' + ltrim(str(datepart(dd, pod_shpstr))) + '/' + ltrim(str(datepart(yyyy, pod_shpstr))) as 'pod_shpstr',
	ltrim(str(datepart(mm, pod_shpstr))) + '/' + ltrim(str(datepart(dd, pod_shpstr))) + '/' + ltrim(str(datepart(yyyy, pod_shpstr))) as 'pod_shpend',
	case pod_candat when '1900-01-01' then '' else ltrim(str(datepart(mm, pod_candat))) + '/' + ltrim(str(datepart(dd, pod_candat))) + '/' + ltrim(str(datepart(yyyy, pod_candat))) end as 'pod_candat',
	ysi_dsc as 'pod_untcde',
	pod_ordqty as 'pod_ordqty',
	pod_pckitr as 'pod_pckitr',
	isNull(mrk1.psm_imgpth,'') as 'psm_imgpth_M',
	isNull(mrk2.psm_imgpth,'') as 'psm_imgpth_I',
	isNull(mrk3.psm_imgpth,'') as 'psm_imgpth_S',
	isNull(mrk1.psm_engdsc,'') as 'MainEng',
	isNull(mrk2.psm_engdsc,'') as 'InnerEng',
	isNull(mrk3.psm_engdsc,'') as 'SideEng',
	isNull(mrk1.psm_engdsc,'') as 'MainEng_Memo',
	isNull(mrk2.psm_engdsc,'') as 'InnerEng_Memo',
	isNull(mrk3.psm_engdsc,'') as 'SideEng_Memo',
	isNull(mrk1.psm_chndsc,'') as 'MainChn',
	isNull(mrk1.psm_chndsc,'') as 'MainChn_Memo',
	isNull(mrk2.psm_chndsc,'') as 'InnerChn',
	isNull(mrk2.psm_chndsc,'') as 'InnerChn_Memo',	
	isNull(mrk3.psm_chndsc,'') as 'SideChn',
	isNull(mrk3.psm_chndsc,'') as 'SideChn_Memo',	
	isNull(mrk1.psm_chnrmk,'') as 'MainChnRmk',
	isNull(mrk2.psm_chnrmk,'') as 'InnerChnRmk',
	isNull(mrk3.psm_chnrmk,'') as 'SideChnRmk',
	isNull(mrk1.psm_engrmk,'') as 'MainEngRmk',
	isNull(mrk2.psm_engrmk,'') as 'InnerEngRmk',
	isNull(mrk3.psm_engrmk,'') as 'SideEngRmk',
	poh_venno as 'poh_venno1',
	ysr_dsc as 'ysr_dsc',
	sod_cussub as 'sod_subcde',
	pod_dept as 'dept',
	pod_dtyrat as 'dtyrat',
	ltrim(str(datepart(mm, poh_cpodat))) + '/' + ltrim(str(datepart(dd, poh_cpodat))) + '/' + ltrim(str(datepart(yyyy, poh_cpodat))) as 'poh_cpodat',
	pod_cuspno as 'pod_cuspno',
	isnull(pod_prdven,'') as 'pod_prdven',
	isnull(pod_prdsubcde,'') as 'pod_prdsubcde',
	isnull(ven.vbi_vensna,'') as 'prdVenSna',
	isnull(pod_seccusitm,'') as 'pod_seccusitm', 
	isnull(pod_alsitmno,'') as 'pod_alsitmno',
	isnull(pod_alscolcde,'') as 'pod_alscolcde',
	isnull(pod_respno,'') as 'pod_respno',
	pod_ftyprctrm,
	case poh_signappflg when 'Y' then 'N' else 'Y' end as 'printdraft'
From	
POORDHDR
left join POORDDTL on poh_cocde = pod_cocde and	poh_purord = pod_purord
left join SCORDDTL on pod_cocde = sod_cocde and	pod_scno = sod_ordno and pod_scline = sod_ordseq
left join VNBASINF cv on poh_venno = cv.vbi_venno
left join CUBASINF on poh_prmcus = cbi_cusno
left join SYSALREP on poh_porctp = ysr_code
left join SYSETINF on pod_untcde = ysi_cde and ysi_typ = '05'
left join VNBASINF ven on pod_prdven = ven.vbi_venno
left join POSHPMRK mrk1 on poh_cocde = mrk1.psm_cocde and poh_purord = mrk1.psm_purord and mrk1.psm_shptyp = 'M'
left join POSHPMRK mrk2 on poh_cocde = mrk2.psm_cocde and poh_purord = mrk2.psm_purord and mrk2.psm_shptyp = 'I'
left join POSHPMRK mrk3	on poh_cocde = mrk3.psm_cocde and poh_purord = mrk3.psm_purord and mrk3.psm_shptyp = 'S'
WHERE
pod_cocde is not null and
sod_cocde is not null and 
cv.vbi_venno is not null and
cbi_cusno is not null and
poh_cocde = @cocde and
( (@JP = 'J' and pod_jobord >= @POfrom and pod_jobord <= @POto)	or
  (@JP = 'P' and pod_purord >= @POfrom and pod_purord <= @POto)	or
  (@JP = 'R' and pod_RUNNO >= @POfrom and pod_RUNNO <= @POto) )










GO
GRANT EXECUTE ON [dbo].[sp_select_POR00005] TO [ERPUSER] AS [dbo]
GO
