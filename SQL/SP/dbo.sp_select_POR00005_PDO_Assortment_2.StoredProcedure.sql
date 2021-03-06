/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO_Assortment_2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00005_PDO_Assortment_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO_Assortment_2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=================================================================
Program ID	: sp_select_POR00005_PDO_Assortment_2
Description	: Retrieve PO Data for PDO Report Generation
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-11-05 	David Yue		SP Created
=================================================================
*/


CREATE   PROCEDURE [dbo].[sp_select_POR00005_PDO_Assortment_2]

@cocde		nvarchar(6),	
@batch		nvarchar(23)

AS

select	@cocde as 'cocde',
	pjd_batno + '-' + pjd_batseq as 'batch',
	pod_jobord,
	pod_itmno + ltrim(pod_engdsc) +  ysi_dsc + str(pod_inrctn,10,0) + str(pod_mtrctn,10,0) + str(pod_cubcft,10,2) as 'podKey',
	poh_venno,
	pda_seq,
	pda_itmno,
	pda_assitm,
	ivi_venitm,
	pda_pckunt,
	pda_inrqty,
	pda_mtrqty,
	pda_cusitm,
	pda_assdsc,
	pda_colcde,
	pda_coldsc,
	pda_cussku,
	pod_typcode,
	pda_upcean,
--	case cast(isnull(nullif(pda_cusrtl,0),0) as numeric(13, 2)) when 0 then '' else ltrim(rtrim(str(pda_cusrtl))) end as 'pda_cusrtl',
	case isnull(pda_cusrtl,'') when '0' then '' else ltrim(rtrim(pda_cusrtl)) end as 'pda_cusrtl',
	pda_cusstyno
from	POJBBDTL (nolock)
	join POORDDTL (nolock) on
		pod_cocde = pjd_cocde and
		pod_jobord = pjd_jobord
	join POORDHDR (nolock) on
		poh_cocde = pod_cocde and
		poh_purord = pod_purord
	join SYSETINF (nolock) on
		ysi_typ = '05' and
		ysi_cde = pod_untcde
	join PODTLASS (nolock) on
		pda_cocde = pod_cocde and
		pda_purord = pod_purord and
		pda_seq = pod_purseq
	join IMBASINF (nolock) on
		ibi_itmno = pda_assitm
	join IMVENINF (nolock) on
		ivi_itmno = pda_assitm and
		ivi_venno = ibi_venno
where	pjd_cocde = @cocde and
	pjd_batno = @batch and
	pjd_confrm = 'Y'
order by poh_venno, batch, ivi_venitm




GO
GRANT EXECUTE ON [dbo].[sp_select_POR00005_PDO_Assortment_2] TO [ERPUSER] AS [dbo]
GO
