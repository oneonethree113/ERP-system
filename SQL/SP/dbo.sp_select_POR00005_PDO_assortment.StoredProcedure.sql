/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO_assortment]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00005_PDO_assortment]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO_assortment]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003
-- Allan Yuen change the sequence no. from XXX to XXXX at 31/03/2004


CREATE PROCEDURE [dbo].[sp_select_POR00005_PDO_assortment]


@cocde		nvarchar(6),	
@batch		nvarchar(30)


AS

--set @batch ='bj0200002-001'

DECLARE
@batno		nvarchar(20),
@batseq		nvarchar(4),
@jobord		nvarchar(30)

SET @batno = left(@batch,9)
SET @batseq = right(@batch,4)


select @jobord = pjd_jobord from POJBBDTL
where pjd_batno = @batno and pjd_batseq = @batseq and pjd_cocde = @cocde


select 
	NoOfColor,
	-- IMVENINF
	isnull(ivi_venitm,'') as 'ivi_venitm',
	
	-- PODTLASS
	pda_purord,			pda_itmno,
	pda_assitm,			pda_assdsc,	pda_coldsc,
	pda_cussku,			pda_upcean,	pda_cusrtl,
	pda_pckunt = ltrim(pda_pckunt),			
	pda_cusitm,
	pda_colcde,			
	pda_inrqty = ltrim(str(pda_inrqty,10,0)),
	pda_mtrqty = ltrim(str(pda_mtrqty,10,0)),
	
	-- POORDDTL
	pod_purseq,

	-- SYSETINF 
	ysi_dsc, pda_cusstyno, convert(varchar(20),pda_imperiod,111) 'pda_imperiod'


	From 	POORDDTL (nolock), PODTLASS (nolock), SYSETINF (nolock),  IMVENINF (nolock), IMBASINF (nolock),
		(select  pda_purord as 'C', pda_itmno as 'A', pda_assitm as 'B' , count(*) as 'NoOfColor' from podtlass (nolock) group by pda_purord,pda_itmno, pda_assitm) A
 
	WHERE	
		pod_cocde = pda_cocde 
	and	pod_purord = pda_purord
	and	pod_purseq = pda_seq

	and 	pda_assitm = ivi_itmno	
	and 	pda_assitm = ibi_itmno and ivi_venno = ibi_venno 

	and 	pda_itmno = A.A and pda_assitm = A.B and pda_purord  = A.C

--	and	pod_cocde = ysi_cocde and pda_pckunt = ysi_cde and ysi_typ = '05'	
	and 	pda_pckunt = ysi_cde and ysi_typ = '05'	

	and 	a.a = pda_itmno and a.b = pda_assitm
	and 	pod_jobord = @jobord and pod_cocde = @cocde
	order by	pda_itmno, pda_assitm, pda_colcde


GO
GRANT EXECUTE ON [dbo].[sp_select_POR00005_PDO_assortment] TO [ERPUSER] AS [dbo]
GO
