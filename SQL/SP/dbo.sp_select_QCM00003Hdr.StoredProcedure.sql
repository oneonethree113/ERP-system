/****** Object:  StoredProcedure [dbo].[sp_select_QCM00003Hdr]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCM00003Hdr]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCM00003Hdr]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_select_QCM00003Hdr]
	@qcfrom nvarchar(10),
	@qcto nvarchar(10)
AS


--Declare @res_itmcount int 

--set @res_itmcount = (select count (sod_itmno) as temp
--FROM QCREQHDR
--		left join QCREQDTL (nolock) on qch_cocde = qcd_cocde and qch_qcno = qcd_qcno
--		left join POORDDTL (nolock) on pod_cocde = qcd_cocde and pod_purord = qcd_purord and pod_purseq = qcd_purseq
--		left join SCORDDTL (nolock) on sod_cocde = pod_cocde and sod_purord = pod_purord and sod_purseq = pod_purseq
--where qch_qcno between @qcfrom and @qcto
--group by qch_qcno)


SELECT
			qch_cocde, qh.qch_qcno, qch_qcsts, qch_verno, 
			qch_venno, qch_prmcus, qch_seccus, qch_inspyear, qch_inspweek, qch_insptyp, 
			qch_mon, qch_tue, qch_wed, qch_thur, qch_fri, qch_sat, qch_sun, 
			
			qch_sidate =case convert(char, qch_sidate, 101) when '01/01/1900' then '' else convert(char, qch_sidate, 101) end,
			qch_cydate =case convert(char, qch_cydate, 101) when '01/01/1900' then '' else convert(char, qch_cydate, 101) end,
			qch_cispdate =case convert(char, qch_cispdate, 101) when '01/01/1900' then '' else convert(char, qch_cispdate, 101) end,
			qch_rmk, qch_samhdl, 

			res_itmcount as 'res_itmcount',cbi_cussna,

			--Vendor info
			isnull(qvi_adr, '') as 'qvi_adr', isnull( qvi_cty, '') as 'qvi_cty', isnull( qvi_stt, '') as 'qvi_stt', isnull( qvi_city, '') as 'qvi_city', isnull( qvi_town, '') as 'qvi_town', isnull( qvi_zip, '') as 'qvi_zip',  
			isnull(qvi_cntctp, '') as 'qvi_cntctp', isnull( qvi_cnttil, '') as 'qvi_cnttil', isnull( qvi_cntphn, '') as 'qvi_cntphn', isnull( qvi_cntfax, '') as 'qvi_cntfax', isnull( qvi_cnteml, '') as 'qvi_cnteml',  
			qvi_ctrlstate = '', vbi_vensna as 'vbi_vensna',
			
			qch_ctrlstate = 'UPD',
			qch_updusr, 
			qch_credat = convert(char, qch_credat, 101), qch_upddat = convert(char, qch_upddat, 101)
			
		FROM QCREQHDR qh
		LEFT JOIN QCVENINF
			ON qch_cocde = qvi_cocde
			AND qch_qcno = qvi_qcno
		LEFT JOIN CUBASINF 
			ON cbi_cusno = qch_prmcus
		Left join VNBASINF
			on vbi_venno = qch_venno
		left join (
		(select count (sod_itmno)as 'res_itmcount' ,qch_qcno
			FROM QCREQHDR
					left join QCREQDTL (nolock) on qch_cocde = qcd_cocde and qch_qcno = qcd_qcno
					left join POORDDTL (nolock) on pod_cocde = qcd_cocde and pod_purord = qcd_purord and pod_purseq = qcd_purseq
					left join SCORDDTL (nolock) on sod_cocde = pod_cocde and sod_purord = pod_purord and sod_purseq = pod_purseq
			where qch_qcno between @qcfrom and @qcto
			group by qch_qcno)
		) as temp on temp.qch_qcno = qh.qch_qcno
		WHERE
			--qch_cocde = @cocde AND
			qh.qch_qcno between @qcfrom and @qcto
		AND (
			EXISTS (
				select 1 from syusrright
				where  yur_doctyp = 'SC' and yur_lvl = 0
			) 
			OR cbi_saltem in (	
				select yur_para from syusrright
				where  yur_doctyp = 'SC' and yur_lvl = 1
			) or cbi_cusno in 
			(
				select yur_para from syusrright
				where  yur_doctyp = 'SC' and yur_lvl = 2
			)
		)
		
		
		

GO
GRANT EXECUTE ON [dbo].[sp_select_QCM00003Hdr] TO [ERPUSER] AS [dbo]
GO
