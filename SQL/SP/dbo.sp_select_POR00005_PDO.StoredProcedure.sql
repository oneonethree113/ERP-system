/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00005_PDO]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003
-- Allan Yuen change the sequence no. from XXX to XXXX at 31/03/2004
-- Allan Yuen add Customer PO # at 01/02/2005
-- Allan Yuen add Production Vendor, Sec Customer Item #

/**************************************************************************************************************
Modification History
**************************************************************************************************************
Modified on	Modified by	Description
**************************************************************************************************************
2005-06-09	Lester Wu		Show Previous Job No
2005-07-11	Allan Yuen		Fix Chinese ship truncate space problem.
2005-08-19	Allan Yuen		Management declare to delete ship end date.
2005-10-05	Allan Yuen		Add Item Cost & Currency
***************************************************************************************************************/
CREATE     PROCEDURE [dbo].[sp_select_POR00005_PDO]

@cocde		nvarchar(6),	
@batch		nvarchar(23)


AS


-- Read Company Information --
declare 
	@yco_conam varchar(50),	@yco_addr nvarchar(200),	@yco_logoimgpth varchar(100),	@yco_phoneno varchar(50),	@yco_faxno varchar(50)

SELECT 
	@yco_conam = yco_conam,	
	@yco_addr = yco_addr,
	@yco_logoimgpth = yco_logoimgpth, 
	@yco_phoneno = yco_phoneno,
	@yco_faxno = yco_faxno 
FROM
	SYCOMINF
WHERE
	YCO_COCDE = @cocde
---------------------------------------------


DECLARE
@batno		nvarchar(20),
@batseq		nvarchar(4)

SET @batno = left(@batch,9)
SET @batseq = right(@batch,4)

CREATE TABLE #tmpjob (
tmp_cocde	nvarchar(6)	not null,
tmp_jobord	nvarchar(20)	not null,
tmp_shpdtl	nvarchar(2000)	null,
tmp_ctndtl	nvarchar(1000)	null,
tmp_Assort	ntext	null,
tmp_shpdtl2	ntext	null,
tmp_ctndtl2	ntext	null)  on [PRIMARY]

Declare
@pjd_jobord	nvarchar(20)

DECLARE cur_batno CURSOR
FOR
SELECT	pjd_jobord
FROM	POJBBDTL
WHERE	pjd_cocde = @cocde
AND	pjd_batno = @batno
AND	pjd_batseq = @batseq
AND 	PJd_confrm = 'Y'

OPEN cur_batno
FETCH NEXT FROM cur_batno INTO
@pjd_jobord

WHILE @@fetch_status = 0
BEGIN

	Declare
	@StrDetail		nvarchar(100),	
	@StrDetail2	nvarchar(4000),	
	@StrShpDtl	nvarchar(4000),
	@StrCtnDtl	nvarchar(4000),
	@StrShpDtl2	nvarchar(4000),	
	@StrCtnDtl2	nvarchar(4000)	

------------------------------------------------------------------------------------------------------------------------------------
	-- Cursor to get Shipment Detail
	SET @StrDetail = ''
	SET @StrDetail2 = ''


	DECLARE cur_SHPDTL cursor
	FOR 
	SELECT	
		Case pds_from when pds_to 
		then 
			convert(char(10), pds_from, 101) + ' (' + convert(char(10), pds_from - 14, 101) + ')' + right('       ' +  ysi_dsc,7) +  str(pds_ordqty,7,0)
		Else 
			convert(char(10), pds_from, 101) + ' (' + convert(char(10), pds_from - 14, 101) + ')' + right('       ' +  ysi_dsc,7) +  str(pds_ordqty,7,0)
		end,

		Case pds_from when pds_to 
		then 
			'<SubShpDtl>' + 
			'<pod_shpstr>' + convert(char(10), pds_from, 101) + '</pod_shpstr>'  + 
			'<ysi_dsc>' + ysi_dsc + '</ysi_dsc>' +
			'<pod_ordqty>' +  ltrim(rtrim(str(pds_ordqty,7,0))) + '</pod_ordqty>' +
			'</SubShpDtl>'  
		Else 
			'<SubShpDtl>' + 
			'<pod_shpstr>' + convert(char(10), pds_from, 101) + '</pod_shpstr>' + 
			'<ysi_dsc>' +  ysi_dsc + '</ysi_dsc>' + 
			'<pod_ordqty>' + ltrim(rtrim(str(pds_ordqty,7,0))) + '</pod_ordqty>' +
			'</SubShpDtl>'  
		end

	FROM	PODTLSHP (nolock), POORDDTL (nolock), SYSETINF (nolock)
	WHERE 	
		pod_untcde = ysi_cde and ysi_typ = '05'
	AND	pds_purord = pod_purord and pds_seq = pod_purseq
	AND 	pds_cocde = @cocde and pod_jobord = @pjd_jobord
	ORDER BY
		convert(char(10), pds_from, 101)


	-------------------------------------------------------------------------------------------------------------------------
	OPEN cur_SHPDTL
	FETCH NEXT FROM cur_SHPDTL INTO
	@StrDetail, @StrDetail2

	SET @StrShpDtl = ''
	SET @StrShpDtl2 = ''

	WHILE @@fetch_status = 0
	BEGIN
		SET @StrShpDtl = @StrShpDtl + @StrDetail + char(10)
		SET @StrShpDtl2 = @StrShpDtl2 + @StrDetail2
		FETCH NEXT FROM cur_SHPDTL INTO
		@StrDetail, @StrDetail2
	END
	CLOSE cur_SHPDTL
	DEALLOCATE cur_SHPDTL
------------------------------------------------------------------------------------------------------------------------------------

	IF @StrShpDtl = ''
		BEGIN
			Select	@StrShpDtl = Case pod_shpstr when pod_shpend 
						then 
							convert(char(10), pod_shpstr, 101) + ' (' + convert(char(10), pod_shpstr - 14, 101) + ')' + right('       ' +  ysi_dsc,7) +  str(pod_ordqty,7,0)
						Else 
							convert(char(10), pod_shpstr, 101) + ' (' + convert(char(10), pod_shpstr - 14, 101) + ')' + right('       ' +  ysi_dsc,7) +  str(pod_ordqty,7,0)
						End,
	
				@StrShpDtl2 = Case pod_shpstr when pod_shpend 
						then 
							'<SubShpDtl>' + 
							'<pod_shpstr>' + convert(char(10), pod_shpstr, 101)  + '</pod_shpstr>' + 
							'<ysi_dsc>' + ysi_dsc + '</ysi_dsc>' + 
							'<pod_ordqty>' + ltrim(rtrim( str(pod_ordqty,7,0))) + '</pod_ordqty>' +
							'</SubShpDtl>'  
						Else 
							'<SubShpDtl>' + 
							'<pod_shpstr>' + convert(char(10), pod_shpstr, 101) + '</pod_shpstr>' + 
							'<ysi_dsc>' +  ysi_dsc + '</ysi_dsc>' + 
							'<pod_ordqty>' + ltrim(rtrim(str(pod_ordqty,7,0)))  + '</pod_ordqty>' + 
							'</SubShpDtl>'  
						end
	
			FROM	POORDDTL (nolock), SYSETINF (nolock)
			WHERE	pod_untcde = ysi_cde and ysi_typ = '05'
			AND	pod_cocde = @cocde and pod_jobord = @pjd_jobord
			ORDER BY	
				convert(char(10), pod_shpstr, 101)
		END
	ELSE
		BEGIN
			SET @StrShpDtl = LEFT(@StrShpDtl, LEN(@StrShpDtl) - 1)
		END

	INSERT INTO 
		#tmpjob 
			(tmp_cocde, tmp_jobord, tmp_shpdtl, tmp_ctndtl, tmp_shpdtl2, tmp_ctndtl2)
		values 
			(@cocde, @pjd_jobord, @strShpDtl, '', @strShpDtl2, '' )

--////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	-- Cursor to get Carton Detail

	SET @StrDetail = ''
	SET @StrDetail2 = ''

	DECLARE cur_CTNDTL cursor
	FOR 
	SELECT	
		str(pdc_from,6,0) + ' - ' + str(pdc_to,6,0) + ' (' + ltrim(str(pdc_ttlctn,5,0)) + ')',
		-- Generate XML ---
		'<SubCtnNo>' + 
		'<pod_ctnstr>' + ltrim(rtrim(str(pdc_from,6,0))) + '</pod_ctnstr>' +
		'<pod_ctnend>' +  ltrim(rtrim(str(pdc_to,6,0))) + '</pod_ctnend>' +
		'<pod_subttlctn>' + '(' + rtrim(ltrim(str(pdc_ttlctn,5,0))) + ')' + '</pod_subttlctn>' +
		'</SubCtnNo>' 
		------------------------

	FROM 	PODTLCTN (nolock), POORDDTL (nolock)
	WHERE 	pod_cocde = pdc_cocde and pod_purord = pdc_purord and pod_purseq = pdc_seq
	AND	pdc_cocde = @cocde and pod_jobord = @pjd_jobord
	ORDER BY
		str(pdc_from,7,0)


	OPEN cur_CTNDTL
	FETCH NEXT FROM cur_CTNDTL INTO
	@StrDetail,  @StrDetail2

	SET @StrCtnDtl = ''
	SET @StrCtnDtl2 = ''

	WHILE @@fetch_status = 0
	BEGIN
		SET @StrCtnDtl = @StrCtnDtl + @StrDetail + char(10)
		SET @StrCtnDtl2 = @StrCtnDtl2 + @StrDetail2
		FETCH NEXT FROM cur_CTNDTL INTO
		@StrDetail,  @StrDetail2
	END
	CLOSE cur_CTNDTL
	DEALLOCATE cur_CTNDTL

	IF @StrCtnDtl = ''
	BEGIN
		SELECT	
			@StrCtnDtl = str(pod_ctnstr,6,0) + ' - ' + str(pod_ctnend,6,0)+ ' (' + ltrim(str(pod_ttlctn,5,0)) + ')',
			--- Generate XML ---
			@StrCtnDtl2 = 
				'<SubCtnNo>' + 
				'<pod_ctnstr>' + ltrim(rtrim(str(pod_ctnstr,6,0)))  + '</pod_ctnstr>' +
				'<pod_ctnend>' + ltrim(rtrim(str(pod_ctnend,6,0)))  + '</pod_ctnend>' +
				'<pod_subttlctn>' + '(' + rtrim(ltrim(str(pod_ttlctn,5,0))) + ')' + '</pod_subttlctn>' +
				'</SubCtnNo>' 
			--------------------------

		FROM	POORDDTL (nolock)
		WHERE	pod_cocde = @cocde and pod_jobord = @pjd_jobord
		ORDER BY
			str(pod_ctnstr,7,0)
	END
	ELSE
	BEGIN
		SET @StrCtnDtl = LEFT(@StrCtnDtl, LEN(@StrCtnDtl) - 1)
	END

	UPDATE 
		#tmpjob 
	SET 
		tmp_ctndtl = @StrCtnDtl,
		tmp_ctndtl2 = @StrCtnDtl2
	WHERE	
		tmp_cocde = @cocde
	AND	tmp_jobord = @pjd_jobord

	FETCH NEXT FROM cur_batno INTO
	@pjd_jobord
END
CLOSE cur_batno
DEALLOCATE cur_batno


Declare @nCountAss	int
Select @nCountAss = count(*) from PODTLASS (nolock), POORDDTL (nolock), #tmpjob (nolock)
Where 	pod_cocde = pda_cocde and pod_purord = pda_purord and pod_purseq = pda_seq
and	pod_jobord = tmp_jobord  and pod_cocde = tmp_cocde

Set @nCountAss = @nCountAss * 4 + 3

select 
	@cocde as '@cocde',
	@yco_conam as '@yco_conam',
	@yco_addr as '@yco_addr',
	@yco_logoimgpth as '@yco_logoimgpth',
	@yco_phoneno as '@yco_phoneno',
	@yco_faxno as '@yco_faxno',
	@batch as '@batch',
	-- VNBASINF (Custom Vendor)
	
	-- changed by Mark Lau 20090103
	case when isnull(aa.vbi_venchnnam,'') <> '' then aa.vbi_venchnnam else aa.vbi_vennam end as 'vbi_vennam',	aa.vbi_vensna as 'vbi_vensna',

	-- VNBASINF (Production Vendor)
	case when isnull(bb.vbi_venchnnam,'') <> '' then bb.vbi_venchnnam else bb.vbi_vennam end as 'prd_vennam',	bb.vbi_vensna as 'prd_vensna',

	--CUBASINF	
	cbi_cussna,	

	-- POORDHDR
	poh_porctp,	 poh_prmcus,	poh_venno,
	poh_credat = ltrim(str(datepart(mm, poh_credat))) + '/' + ltrim(str(datepart(dd, poh_credat))) + '/' + ltrim(str(datepart(yyyy, poh_credat))),
	poh_issdat = ltrim(str(datepart(mm, poh_issdat))) + '/' + ltrim(str(datepart(dd, poh_issdat))) + '/' + ltrim(str(datepart(yyyy, poh_issdat))),
	poh_pocdat = ltrim(str(datepart(mm, poh_pocdat))) + '/' + ltrim(str(datepart(dd, poh_pocdat))) + '/' + ltrim(str(datepart(yyyy, poh_pocdat))),
	poh_cuspno,	 poh_reppno,	
	poh_purord,	 poh_curcde,
	ltrim(rtrim(case @cocde when 'TT' then 'This P.O. is issued on behalf of NEW LEADER. ' + char(10) + char(13) + '此張採購單乃代表 「聯通」發出。' + char(10) + char(13) 
		else case aa.vbi_bvennam when 'NO' then '' else 'This production note is issued on behalf of ' + aa.vbi_bvennam + '. ' + char(10) + char(13) + '此張生產單乃代表 「' + aa.vbi_bvennamc + '」發出。' + char(10) + char(13) end end +
		case poh_cusctn when 0 then '' else 'TOTAL CTN# - ' + ltrim(rtrim(str(poh_cusctn))) + char(10) + char(13) end + case poh_dest when '' then '' else 'DESTINATION: ' + ltrim(rtrim(poh_dest)) + char(10) + char(13) end +
		poh_rmk)) as 'poh_rmk',
	ltrim(rtrim(case @cocde when 'TT' then 'This P.O. is issued on behalf of NEW LEADER. ' + char(10) + char(13) + '此張採購單乃代表 「聯通」發出。' + char(10) + char(13) 
		else case aa.vbi_bvennam when 'NO' then '' else 'This production note is issued on behalf of ' + aa.vbi_bvennam + '. ' + char(10) + char(13) + '此張生產單乃代表 「' + aa.vbi_bvennamc + '」發出。' + char(10) + char(13) end end +
		case poh_cusctn when 0 then '' else 'TOTAL CTN# - ' + ltrim(rtrim(str(poh_cusctn))) + char(10) + char(13) end + case poh_dest when '' then '' else 'DESTINATION: ' + ltrim(rtrim(poh_dest)) + char(10) + char(13) end +
		poh_rmk)) as 'poh_rmk_Memo',
	-- POORDDTL
	pod_typcode,	pod_cuscol,	
	pod_scno,		pod_itmno,	pod_venitm,		
	pod_engdsc,	pod_engdsc_Memo = pod_engdsc,
	pod_chndsc,	pod_chndsc_Memo = pod_chndsc,
	pod_inrctn,	
	pod_mtrctn,	pod_cubcft,	
	---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	case isnull(sod_pjobno,'') when '' then pod_rmk
			else '取代 Job # ' + sod_pjobno + case isnull(pod_rmk,'') when '' then '' else  char(10) + char(13) + pod_rmk end end as 'pod_rmk',
	case isnull(sod_pjobno,'') when '' then pod_rmk
			else '取代 Job # ' + sod_pjobno + case isnull(pod_rmk,'') when '' then '' else  char(10) +char(13) + pod_rmk end end as 'pod_rmk_Memo',		
	---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	pod_jobord,	pod_cusitm,	pod_cussku,
	pod_code1, 	pod_code2, 	pod_code3,
	pod_hrmcde,	pod_cususd, 	pod_cuscad,
	pod_vencol,	
	pod_coldsc,	pod_coldsc_Memo = pod_coldsc,
	pod_purseq,

	pod_key = pod_itmno + ltrim(pod_engdsc) +  ysi_dsc + str(pod_inrctn,10,0) + str(pod_mtrctn,10,0) + str(pod_cubcft,10,2),
	pod_ctnstr,		pod_ctnend,	pod_ttlctn = str(pod_ttlctn),
	pod_shpstr = ltrim(str(datepart(mm, pod_shpstr))) + '/' + ltrim(str(datepart(dd, pod_shpstr))) + '/' + ltrim(str(datepart(yyyy, pod_shpstr))),	
	pod_shpend = ltrim(str(datepart(mm, pod_shpstr))) + '/' + ltrim(str(datepart(dd, pod_shpstr))) + '/' + ltrim(str(datepart(yyyy, pod_shpstr))),	
	pod_untcde = ysi_dsc,
	pod_ordqty,	pod_pckitr,
	pod_prdven,
	pod_prdsubcde,
	pod_seccusitm,
	pod_ftyprc,
	-- POSHPMRK
	MainMrk = isNull(mrk1.psm_imgpth,''),	InnerMrk = isNull(mrk2.psm_imgpth,''),	SideMrk = isNull(mrk3.psm_imgpth,''),
	MainEng = replace(Case isNull(mrk1.psm_engdsc, '') When '' then '' Else 'ξ' + replace(mrk1.psm_engdsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),
	InnerEng = replace(Case isNull(mrk2.psm_engdsc, '') When '' then '' Else 'ξ' + replace(mrk2.psm_engdsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),
	SideEng = replace(Case isNull(mrk3.psm_engdsc, '') When '' then '' Else  'ξ' + replace(mrk3.psm_engdsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),

	MainEng_Memo = replace(Case isNull(mrk1.psm_engdsc, '') When '' then '' Else 'ξ' + replace(mrk1.psm_engdsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),
	InnerEng_Memo = replace(Case isNull(mrk2.psm_engdsc, '') When '' then '' Else 'ξ' + replace(mrk2.psm_engdsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),
	SideEng_Memo = replace(Case isNull(mrk3.psm_engdsc, '') When '' then '' Else  'ξ' + replace(mrk3.psm_engdsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),

	MainChn = replace(Case isNull(mrk1.psm_chndsc, '') When '' then '' Else 'ξ' + replace(mrk1.psm_chndsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),
	InnerChn = replace(Case isNull(mrk2.psm_chndsc, '') When '' then '' Else 'ξ' + replace(mrk2.psm_chndsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),
	SideChn = replace(Case isNull(mrk3.psm_chndsc, '') When '' then '' Else  'ξ' + replace(mrk3.psm_chndsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),

	MainChn_Memo = replace(Case isNull(mrk1.psm_chndsc, '') When '' then '' Else 'ξ' + replace(mrk1.psm_chndsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),
	InnerChn_Memo = replace(Case isNull(mrk2.psm_chndsc, '') When '' then '' Else 'ξ' + replace(mrk2.psm_chndsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),
	SideChn_Memo = replace(Case isNull(mrk3.psm_chndsc, '') When '' then '' Else  'ξ' + replace(mrk3.psm_chndsc, char(13)+char(10), char(13)+char(10)+ 'ξ') end, ',','，'),

	
	MainChnRmk = replace(isNull(mrk1.psm_chnrmk,''), ',','，'),	InnerChnRmk = replace(isNull(mrk2.psm_chnrmk,''), ',','，'),	SideChnRmk = replace(isNull(mrk3.psm_chnrmk,''), ',','，'),
	MainEngRmk = replace(isNull(mrk1.psm_engrmk,''), ',','，'),	InnerEngRmk = replace(isNull(mrk2.psm_engrmk,''), ',','，'),	SideEngRmk = replace(isNull(mrk3.psm_engrmk,''), ',','，'),

	poh_venno as '@poh_venno',
	isnull(ysr_dsc,'') as 'ysr_dsc',
	sod_subcde,
	pod_dept,
	pod_dtyrat,
	tmp_shpdtl,
	tmp_ctndtl,
	isnull(tmp_Assort,'') as 'tmp_Assort',
	RmkLen = @nCountAss + 2 + len(isnull(sod_pjobno,'') + pod_rmk)/30 +
	Case when (len(poh_rmk) - len(replace(poh_rmk, char(13), ''))+1> len(poh_rmk)/80)then
	len(poh_rmk) - len(replace(poh_rmk, char(13), ''))+1 else
	len(poh_rmk)/80 end + 
	Case when (len(mrk1.psm_engrmk) - len(replace(mrk1.psm_engrmk, char(13), ''))+1> len(mrk1.psm_engrmk)/80)then
	len(mrk1.psm_engrmk) - len(replace(mrk1.psm_engrmk, char(13), ''))+1 else
	len(mrk1.psm_engrmk)/80 end + 
	Case when (len(mrk1.psm_chnrmk) - len(replace(mrk1.psm_chnrmk, char(13), ''))+1 > len(mrk1.psm_chnrmk)/80) then
	len(mrk1.psm_chnrmk) - len(replace(mrk1.psm_chnrmk, char(13), ''))+1 else
	len(mrk1.psm_chnrmk)/80 end,
	poh_cpodat,
	tmp_shpdtl2,
	tmp_ctndtl2,
	pod_runno,
	pod_cuspno , 
	pod_alsitmno , 
	pod_alscolcde,
	isnull(pod_respno,'') as 'pod_respno'
From	
#tmpjob
left join POORDDTL (nolock) on pod_jobord = tmp_jobord  and pod_cocde = tmp_cocde 
left join POORDHDR (nolock) on poh_cocde = pod_cocde and poh_purord = pod_purord
left join SCORDDTL (nolock)on pod_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
left join VNBASINF aa (nolock) on poh_venno = aa.vbi_venno
left join VNBASINF bb (nolock) on pod_prdven = bb.vbi_venno
left join CUBASINF (nolock) on poh_prmcus = cbi_cusno
left join SYSETINF (nolock) on pod_untcde = ysi_cde and ysi_typ = '05'
left join SYSALREP (nolock) on poh_porctp = ysr_code
left join POSHPMRK mrk1 (nolock) on poh_cocde = mrk1.psm_cocde and poh_purord = mrk1.psm_purord and mrk1.psm_shptyp = 'M'
left join POSHPMRK mrk2 (nolock) on poh_cocde = mrk2.psm_cocde and poh_purord = mrk2.psm_purord and mrk2.psm_shptyp = 'I'
left join POSHPMRK mrk3 (nolock) on poh_cocde = mrk3.psm_cocde and poh_purord = mrk3.psm_purord and mrk3.psm_shptyp = 'S'
WHERE	
pod_cocde is not null and
poh_cocde is not null and
sod_cocde is not null







GO
GRANT EXECUTE ON [dbo].[sp_select_POR00005_PDO] TO [ERPUSER] AS [dbo]
GO
