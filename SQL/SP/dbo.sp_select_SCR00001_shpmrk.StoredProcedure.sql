/****** Object:  StoredProcedure [dbo].[sp_select_SCR00001_shpmrk]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCR00001_shpmrk]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCR00001_shpmrk]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=================================================================
Program ID	: sp_select_SCR00001_shpmrk
Description	: Retrieve Shipmark Details for SCR00001 Report
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-09-26	David Yue		SP Created
=================================================================
*/

CREATE   PROCEDURE [dbo].[sp_select_SCR00001_shpmrk]
@cocde		nvarchar(6),	
@Sup0		nvarchar(1),
@SCfrom		nvarchar(20),	
@SCto		nvarchar(20),
@CRmk		nvarchar(1), 
@printcusals	nvarchar(1),
@usrid		nvarchar(30),
@doctyp		nvarchar(2)

AS

select	-- Shipmark
	soh_cocde,
	soh_ordno,
	case when @printcusals = '1' and sod_cusstyno <> '' then sod_cusstyno
		else ltrim(left(case when sod_itmtyp = 'ASS' then sod_itmno else dbo.groupnewitmno(sod_itmno) end +'          ',20)) end +
		case when isnull(sod_custum,'') <>'' then sod_custum else case when sod_contopc = 'Y' then 'PC' else ltrim(sod_pckunt) end end + 'x' +
		case when sod_contopc = 'Y' then  convert(varchar(40),sod_inrctn * sod_conftr) else convert(varchar(20),sod_inrctn) end + 'x' + 
		case when sod_contopc = 'Y' then  convert(varchar(40),sod_mtrctn * sod_conftr) else convert(varchar(20),sod_mtrctn) end + 'x' + 
		convert(varchar(20),sod_cft)+ 'x' + sod_ftyprctrm + 'x' + sod_hkprctrm + 'x' + sod_trantrm +  'x' + 
		case when sod_contopc = 'Y' then convert(varchar(40),sod_netuntprc/sod_conftr) else convert(varchar(20),sod_netuntprc) end + 'x' +
		ltrim(sod_itmdsc) + 'x' + ltrim(sod_cuspo) as 'sodKey',
	isNull(shpmrkM.ssm_imgpth,'') as 'psm_imgpth_M',
	isNull(shpmrkI.ssm_imgpth,'') as 'psm_imgpth_I',
	isNull(shpmrkS.ssm_imgpth,'') as 'psm_imgpth_S',
	ltrim(replace(replace(isnull(shpmrkM.ssm_engdsc,''), char(13), ''), char(10), '')) as 'MainEng',
	isNull(shpmrkM.ssm_engdsc,'') as 'MainEng_Memo',	
	ltrim(replace(replace(isnull(shpmrkI.ssm_engdsc,''), char(13), ''), char(10), '')) as 'InnerEng',
	isNull(shpmrkI.ssm_engdsc,'') as 'InnerEng_Memo',	
	ltrim(replace(replace(isnull(shpmrkS.ssm_engdsc,''), char(13), ''), char(10), '')) as 'SideEng',
	isNull(shpmrkS.ssm_engdsc,'') as 'SideEng_Memo',
	case @CRmk when 'Y' then ltrim(replace(replace(isnull(shpmrkM.ssm_chndsc,''), char(13), ''), char(10), '')) else '' end as 'MainChnDsc',
	case @CRmk when 'Y' then ltrim(replace(replace(isnull(shpmrkI.ssm_chndsc,''), char(13), ''), char(10), '')) else '' end as 'InnerChnDsc',
	case @CRmk when 'Y' then ltrim(replace(replace(isnull(shpmrkS.ssm_chndsc,''), char(13), ''), char(10), '')) else '' end as 'SideChnDsc',
	isNull(shpmrkM.ssm_chndsc,'') as 'MainChn_Memo',
	isNull(shpmrkI.ssm_chndsc,'') as 'InnerChn_Memo',
	isNull(shpmrkS.ssm_chndsc,'') as 'SideChn_Memo',
	case @CRmk when 'Y' then ltrim(replace(replace(isnull(shpmrkM.ssm_chnrmk,''), char(13), ''), char(10), '')) else '' end as 'MainChnRmk',
	case @CRmk when 'Y' then ltrim(replace(replace(isnull(shpmrkI.ssm_chnrmk,''), char(13), ''), char(10), '')) else '' end as 'InnerChnRmk',
	case @CRmk when 'Y' then ltrim(replace(replace(isnull(shpmrkS.ssm_chnrmk,''), char(13), ''), char(10), '')) else '' end as 'SideChnRmk',
	isNull(shpmrkM.ssm_chnrmk,'') as 'MainChnRmk_Memo',
	isNull(shpmrkI.ssm_chnrmk,'') as 'InnerChnRmk_Memo',	
	isNull(shpmrkS.ssm_chnrmk,'') as 'SideChnRmk_Memo',
	case len(ltrim(replace(replace(isnull(shpmrkM.ssm_engrmk,''), char(13), ''), char(10), ''))) when 0 then '0' else '1' end as 'MERk',
	case len(ltrim(replace(replace(isnull(shpmrkI.ssm_engrmk,''), char(13), ''), char(10), ''))) when 0 then '0' else '1' end as 'IERk',
	case len(ltrim(replace(replace(isnull(shpmrkS.ssm_engrmk,''), char(13), ''), char(10), ''))) when 0 then '0' else '1' end as 'SERk',
	ltrim(isnull(shpmrkM.ssm_engrmk,'')) as 'MainEngRmk',
	ltrim(isnull(shpmrkI.ssm_engrmk,'')) as 'InnerEngRmk',
	ltrim(isnull(shpmrkS.ssm_engrmk,'')) as 'SideEngRmk'
from	SCORDDTL (nolock)
	left join SCORDHDR (nolock) on
		soh_cocde = sod_cocde and
		soh_ordno = sod_ordno
	left join CUBASINF cus1 (nolock) on
		cus1.cbi_cusno = soh_cus1no
	left join SCSHPMRK shpmrkM (nolock) on
		shpmrkM.ssm_cocde = soh_cocde and
		shpmrkM.ssm_ordno = soh_ordno and
		shpmrkM.ssm_shptyp = 'M'
	left join SCSHPMRK shpmrkI (nolock) on
		shpmrkI.ssm_cocde = soh_cocde and
		shpmrkI.ssm_ordno = soh_ordno and
		shpmrkI.ssm_shptyp = 'I'
	left join SCSHPMRK shpmrkS (nolock) on
		shpmrkS.ssm_cocde = soh_cocde and
		shpmrkS.ssm_ordno = soh_ordno and
		shpmrkS.ssm_shptyp = 'S'
where	sod_cocde = @cocde and
	sod_ordno between @SCfrom and @SCto and
	((@Sup0 = 'Y' and sod_ordqty > 0) or (@Sup0 = 'N' )) and
	(	exists (select 1 from SYUSRRIGHT (nolock) where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 0) or
		cus1.cbi_saltem in (select yur_para from SYUSRRIGHT (nolock) where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1) or
		--soh_cus1no in (select yur_para from SYUSRRIGHT (nolock) where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2)
		(select count(*) from SYUSRRIGHT (nolock) where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2 and yur_para = cus1.cbi_cusno) > 0
	)





GO
GRANT EXECUTE ON [dbo].[sp_select_SCR00001_shpmrk] TO [ERPUSER] AS [dbo]
GO
