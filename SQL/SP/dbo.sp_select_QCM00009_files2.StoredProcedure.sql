/****** Object:  StoredProcedure [dbo].[sp_select_QCM00009_files2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCM00009_files2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCM00009_files2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE    procedure [dbo].[sp_select_QCM00009_files2]
	@cocde as nvarchar(6), 
	@qcno as nvarchar(20), 
	@usrid as nvarchar(30), 
	@doctyp as nvarchar(2)
as
BEGIN
	
		
	CREATE table #TEMP_PONO(tmp_purord nvarchar(20)) on [PRIMARY]
	
	Create table #TEMP_RESULT(
		pod_sel nvarchar(1), 
		ordno nvarchar(50),
		ordseq int, 
		pri_cust nvarchar(50), 
		sec_cust nvarchar(50), 
		vbi_vensna nvarchar(100), 
		pod_cusitm nvarchar(50), 
		pod_itmno nvarchar(50), 
		pod_chndsc nvarchar(4000),
		typ nvarchar(1)		
	)

	INSERT INTO #TEMP_PONO 
	SELECT qpd_purord
	FROM QCPORDTL
	WHERE qpd_cocde = @cocde
		AND qpd_qcno = @qcno 
		AND qpd_del <> 'Y'

	
	--Insert QC 
	INSERT INTO #TEMP_RESULT
	select distinct 
		'N', 
		qch_qcno  as 'ordno',
		'0' as 'ordseq',
		pri.cbi_cussna, 
		isnull(sec.cbi_cussna, ''),
		vbi_vensna,
		'','','',
		'Q'
	from QCREQHDR
	LEFT JOIN CUBASINF pri
		ON qch_prmcus = pri.cbi_cusno
	LEFT JOIN CUBASINF sec
		ON qch_seccus = sec.cbi_cusno
	LEFT JOIN VNBASINF
		ON qch_venno = vbi_venno
	where 
		qch_cocde = @cocde and
		qch_qcno = @qcno
	and qch_qcsts <> 'CAN' and qch_qcsts <> 'DEL'
	and (	
		exists (	
			select 1 from syusrright
			where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
		)
		or pri.cbi_saltem in (	
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
		)
		or pri.cbi_cusno in (
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
		)
	)	
	
	--Insert PO Header
	INSERT INTO #TEMP_RESULT
	select distinct 
		'N',
		pod_purord as 'ordno',
		'0' as 'ordseq',
		pri.cbi_cussna, 
		isnull(sec.cbi_cussna, ''),
		vbi_vensna,
		'','','',
		'H'
		from  POORDDTL
		left join POORDHDR 
			on poh_cocde = pod_cocde
			AND poh_purord = pod_purord
		left  join  POJBBDTL 
			on pod_jobord = pjd_jobord
		left join CUBASINF pri
			on poh_prmcus = pri.cbi_cusno
		left join CUBASINF sec
			on poh_seccus = sec.cbi_cusno
		left join VNBASINF
			on poh_venno = vbi_venno
	where 
		pod_cocde = @cocde and
		pod_purord in (
			select tmp_purord from #TEMP_PONO 
		)
		and (	
			exists (	
				select 1 from syusrright
				where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
			)
			or poh_saltem in (	
				select yur_para from syusrright
				where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
			)
			or poh_prmcus in (
				select yur_para from syusrright
				where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
			)
		)
	order by ordno, ordseq
	
	
	--Insert PO Detail
	INSERT INTO #TEMP_RESULT
	select distinct
			'N', 
			pod_purord as 'ordno',
			pod_purseq as 'ordseq',
			pri.cbi_cussna, 
			isnull(sec.cbi_cussna, ''),
			vbi_vensna,
			pod_cusitm, 
			pod_itmno, 
			pod_chndsc,
			'P'
		from  POORDDTL
		left  join  POJBBDTL 
			on pod_jobord = pjd_jobord
		left join POORDHDR
			ON pod_cocde = poh_cocde
			And pod_purord = poh_purord
		left join CUBASINF pri
			on poh_prmcus = pri.cbi_cusno
		left join CUBASINF sec
			on poh_seccus = sec.cbi_cusno
		left join VNBASINF
			on poh_venno = vbi_venno
	where 
		pod_cocde = @cocde and
		pod_purord in (
			select tmp_purord from #TEMP_PONO 
		)
		-- pod_purord >= @poFm and pod_purord <= @poTo 
		and (	
			exists (	
				select 1 from syusrright
				where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
					-- and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
			)
			or poh_saltem in (	
				select yur_para from syusrright
				where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
					-- and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
			)
			or poh_prmcus in (
				select yur_para from syusrright
				where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
					-- and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
			)
		)
	order by ordno, ordseq
	
	select * from #TEMP_RESULT
	
	

END




GO
GRANT EXECUTE ON [dbo].[sp_select_QCM00009_files2] TO [ERPUSER] AS [dbo]
GO
