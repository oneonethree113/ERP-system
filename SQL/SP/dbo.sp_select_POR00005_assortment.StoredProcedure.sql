/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_assortment]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00005_assortment]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_assortment]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sp_select_POR00005_assortment]
@cocde		nvarchar(6),	
@JOBorPO	nvarchar(1),
@JOBfrom	nvarchar(20),
@JOBto		nvarchar(20)

AS

select 
	ivi_venitm as 'ivi_venitm',
	pda_purord as 'pda_purord',
	pda_itmno as 'pda_itmno',
	pda_assitm as 'pda_assitm',
	pda_assdsc as 'pda_assdsc',
	pda_coldsc as 'pda_coldsc',
	pda_cussku as 'pda_cussku',
	pda_upcean as 'pda_upcean',
	pda_cusrtl as 'pda_cusrtl',
	ltrim(pda_pckunt) as 'pda_pckunt',
	pda_cusitm as 'pda_cusitm',
	pda_colcde as 'pda_colcde',
	ltrim(str(pda_inrqty,10,0)) as 'pda_inrqty',
	ltrim(str(pda_mtrqty,10,0)) as 'pda_mtrqty',
	pod_purseq as 'pod_purseq',
	ysi_dsc as 'unit',
	pda_cusstyno
from 	POORDDTL (nolock), PODTLASS (nolock), SYSETINF (nolock),  IMVENINF (nolock), IMBASINF (nolock)
where	pod_cocde = pda_cocde			and
	pod_purord = pda_purord			and
	pod_purseq = pda_seq				and
	pda_assitm = ivi_itmno			and
	pda_assitm = ibi_itmno			and
	--ivi_venno = ibi_venno				and
	ivi_def = 'Y' and
	pda_pckunt = ysi_cde				and
	ysi_typ = '05'				and
	pod_cocde = @cocde				and 	
	(
	 (@JOBorPO = 'J'		and
	  pod_jobord >= @JOBfrom	and
	  pod_jobord <= @JOBto)		or
	 (@JOBorPO = 'P'		and
	  pod_purord >= @JOBfrom	and
	  pod_purord <= @JOBto)		or
	 (@JOBorPO = 'R'		and
	  pod_runno >= @JOBfrom	and
	  pod_runno <= @JOBto))
order by	pda_itmno, pda_assitm, pda_colcde






GO
GRANT EXECUTE ON [dbo].[sp_select_POR00005_assortment] TO [ERPUSER] AS [dbo]
GO
