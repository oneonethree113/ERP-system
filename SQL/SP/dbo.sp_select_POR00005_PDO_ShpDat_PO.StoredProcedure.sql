/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO_ShpDat_PO]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00005_PDO_ShpDat_PO]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO_ShpDat_PO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=================================================================
Program ID	: sp_select_POR00005_PDO_ShpDat_PO
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


CREATE   PROCEDURE [dbo].[sp_select_POR00005_PDO_ShpDat_PO]

@cocde		nvarchar(6),	
@jobno		nvarchar(23),
@batno		nvarchar(25)

AS

declare	@bufferdays int
set @bufferdays = 14

select	@cocde as 'cocde',
	--pjd_batno + '-' + pjd_batseq as 'batch',
	@batno as 'batch',
	pod_jobord,
	poh_venno,
	pds_shpseq as 'pod_shpseq',
	pod_itmno + ltrim(pod_engdsc) +  ysi_dsc + str(pod_inrctn,10,0) + str(pod_mtrctn,10,0) + str(pod_cubcft,10,2) as 'podKey',
	right('0' + ltrim(str(datepart(mm, pds_from))), 2) + '/' + right('0' + ltrim(str(datepart(dd, pds_from))), 2) + '/' + ltrim(str(datepart(yyyy, pds_from))) as 'pod_shpstr',
	right('0' + ltrim(str(datepart(mm, pds_from - @bufferdays))), 2) + '/' + right('0' + ltrim(str(datepart(dd, pds_from - @bufferdays))), 2) + '/' + ltrim(str(datepart(yyyy, pds_from - @bufferdays))) as 'fac_shpstr',
	ysi_dsc as 'pod_untcde',
	pds_ordqty as 'pod_ordqty',
	pds_ctnstr as 'pod_ctnstr',
	pds_ctnend as 'pod_ctnend', 
	ltrim(rtrim(str(pds_ttlctn))) as 'pod_ttlctn',
	pds_dest as 'pds_dest',
	'' as 'pds_rmk'
from	--POJBBDTL (nolock)
	 POORDDTL (nolock) 
		 
	join POORDHDR (nolock) on
		poh_cocde = pod_cocde and
		poh_purord = pod_purord
	join VNBASINF (nolock) on
		vbi_venno = poh_venno
	join SYSETINF (nolock) on
		ysi_typ = '05' and
		ysi_cde = pod_untcde
	join PODTLSHP (nolock) on
		pds_cocde = pod_cocde and
		pds_purord = pod_purord and
		pds_seq = pod_purseq
where	--pjd_cocde = @cocde and
	--pjd_batno = @batch and
	pod_cocde = @cocde and
	pod_jobord = @jobno
	-- and pjd_confrm = 'Y'
UNION
select	@cocde as 'cocde',
	--pjd_batno + '-' + pjd_batseq as 'batch',
	@batno as 'batch',
	pod_jobord,
	poh_venno,
	1,
	pod_itmno + ltrim(pod_engdsc) +  ysi_dsc + str(pod_inrctn,10,0) + str(pod_mtrctn,10,0) + str(pod_cubcft,10,2) as 'podKey',
	right('0' + ltrim(str(datepart(mm, pod_shpstr))), 2) + '/' + right('0' + ltrim(str(datepart(dd, pod_shpstr))), 2) + '/' + ltrim(str(datepart(yyyy, pod_shpstr))) as 'pod_shpstr',
	right('0' + ltrim(str(datepart(mm, pod_shpstr - @bufferdays))), 2) + '/' + right('0' + ltrim(str(datepart(dd, pod_shpstr - @bufferdays))), 2) + '/' + ltrim(str(datepart(yyyy, pod_shpstr - @bufferdays))) as 'fac_shpstr',
	ysi_dsc as 'pod_untcde',
	pod_ordqty,
	pod_ctnstr,
	pod_ctnend, 
	pod_ttlctn,
	'' as 'pds_dest',
	'' as 'pds_rmk'
from	--POJBBDTL (nolock)
	 POORDDTL (nolock) 
		 
	join POORDHDR (nolock) on
		poh_cocde = pod_cocde and
		poh_purord = pod_purord
	join SYSETINF (nolock) on
		ysi_typ = '05' and
		ysi_cde = pod_untcde
where	(select count(*) from PODTLSHP (nolock) where pds_cocde = @cocde and pds_purord = pod_purord and pds_seq = pod_purseq) = 0 and
	pod_cocde = @cocde and
	pod_jobord = @jobno 
	--and pjd_confrm = 'Y'

order by poh_venno, batch





GO
GRANT EXECUTE ON [dbo].[sp_select_POR00005_PDO_ShpDat_PO] TO [ERPUSER] AS [dbo]
GO
