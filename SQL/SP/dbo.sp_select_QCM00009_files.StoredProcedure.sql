/****** Object:  StoredProcedure [dbo].[sp_select_QCM00009_files]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCM00009_files]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCM00009_files]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE    procedure [dbo].[sp_select_QCM00009_files] 
@cocde as nvarchar(6) , 

@poFm as nvarchar(20) , 
@poTo as nvarchar(20) , 
@usrid	nvarchar(30),
@doctyp nvarchar(2),
@dummy as char(1),
@type as char(1)

as

declare @sel as nvarchar(1)

set @sel = 'N'

if @type = 'P'
begin
/*	
	select distinct sod_ordno + ' - ' + ltrim(rtrim(convert(nvarchar(20),sod_ordseq))) as 'scseq', sod_itmdsc as 'itmdsc'
	from SCORDDTL, SCORDHDR
	where 
		sod_ordno = soh_ordno and
		soh_ordsts <> 'CLO' and soh_ordsts <> 'CAN' and
		sod_ordno >= @poFm and sod_ordno <= @poTo
	order by scseq
*/
	-- Frankie Cheung 20100408 - Only get SC without Batch Number
--	select distinct sod_ordno + ' - ' + ltrim(rtrim(convert(nvarchar(20),sod_ordseq))) as 'scseq', sod_itmdsc as 'itmdsc'
	select distinct 
			@sel as 'pod_sel', 
			pod_purord as 'ordno', 
			pod_purseq as 'ordseq', 
			pri_cust = pri.cbi_cussna, 
			sec_cust = sec.cbi_cussna,
			vbi_vensna,
			--Case IsNull(poh_cuspno,'') when '' then pod_cuspno else poh_cuspno end as 'cuspno',
			pod_cusitm, 
			pod_itmno, 
			pod_chndsc
			
			--pod_jobord, pod_itmno, 
			--case isnull(pjd_jobord,'') when '' then 'N' else 'Y' end as 'job uploaded',
			--case isnull(pjd_jobord,'') when '' then '' else pjd_jobord end as 'pjd_jobno'	

		from  POORDDTL
		left  join  POJBBDTL 
			on (pod_jobord = pjd_jobord)
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
--		Frankie Cheung 20100609
--		soh_ordsts <> 'CLO' and soh_ordsts <> 'CAN' and
		pod_purord >= @poFm and pod_purord <= @poTo 
--		and pjd_creusr <> 'MISBJ'

		and 	(	
				exists
				(	
					select 1 from syusrright
					where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
				)
				or poh_saltem in 
				(	
					select yur_para from syusrright
					where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
				)
				or poh_prmcus in 
				(
					select yur_para from syusrright
					where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
				)
			)



	order by ordno, ordseq




		
end

else if @type = 'H'
begin
/*	
	select distinct sod_ordno + ' - ' + ltrim(rtrim(convert(nvarchar(20),sod_ordseq))) as 'scseq', sod_itmdsc as 'itmdsc'
	from SCORDDTL, SCORDHDR
	where 
		sod_ordno = soh_ordno and
		soh_ordsts <> 'CLO' and soh_ordsts <> 'CAN' and
		sod_ordno >= @poFm and sod_ordno <= @poTo
	order by scseq
*/
	-- Frankie Cheung 20100408 - Only get SC without Batch Number
--	select distinct sod_ordno + ' - ' + ltrim(rtrim(convert(nvarchar(20),sod_ordseq))) as 'scseq', sod_itmdsc as 'itmdsc'
	select distinct 
		@sel as 'pod_sel', 
		pod_purord as 'ordno',
		'0' as 'ordseq',
		pri_cust = pri.cbi_cussna, 
		sec_cust = sec.cbi_cussna,
		vbi_vensna
		
		--'0' as pod_purseq, '' as pod_jobord, '' as pod_itmno, 
			--''  as 'job uploaded',
			--''  as 'pjd_jobno'	

		from  POORDDTL
		left join POORDHDR 
			on poh_cocde = pod_cocde
			AND poh_purord = pod_purord
		left  join  POJBBDTL 
			on (pod_jobord = pjd_jobord)
		left join CUBASINF pri
			on poh_prmcus = pri.cbi_cusno
		left join CUBASINF sec
			on poh_seccus = sec.cbi_cusno
		left join VNBASINF
			on poh_venno = vbi_venno
		
	where 
		pod_cocde = @cocde and
--		Frankie Cheung 20100609
--		soh_ordsts <> 'CLO' and soh_ordsts <> 'CAN' and
		pod_purord >= @poFm and pod_purord <= @poTo 
--		and pjd_creusr <> 'MISBJ'

		and 	(	
				exists
				(	
					select 1 from syusrright
					where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
				)
				or poh_saltem in 
				(	
					select yur_para from syusrright
					where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
				)
				or poh_prmcus in 
				(
					select yur_para from syusrright
					where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
				)
			)



	order by ordno, ordseq
	
end

else if @type = 'Q'
begin 
--Not sure can it check right using cbi_saltem
	select distinct 
		@sel as 'pod_sel', 
		qch_qcno  as 'ordno',--as 'pod_purord', '0' as pod_purseq, '' as 'pod_jobord', '' as 'pod_itmno', 
		'0' as 'ordseq',
		pri_cust = pri.cbi_cussna, 
		sec_cust = sec.cbi_cussna,
		vbi_vensna
		
		--'' as 'job uploaded',
		--'' as 'pjd_jobno'	
	from QCREQHDR
	LEFT JOIN CUBASINF pri
		ON qch_prmcus = pri.cbi_cusno
	LEFT JOIN CUBASINF sec
		ON qch_seccus = sec.cbi_cusno
	LEFT JOIN VNBASINF
		ON qch_venno = vbi_venno
	where 
		--qch_cocde = @cocde and
		qch_qcno >= @poFm and qch_qcno <= @poTo 
	and qch_qcsts <> 'CAN' and qch_qcsts <> 'DEL'
	and 	(	
			exists
			(	
				select 1 from syusrright
				where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
			)
			or pri.cbi_saltem in 
			(	
				select yur_para from syusrright
				where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
			)
			or pri.cbi_cusno in 
			(
				select yur_para from syusrright
				where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
--					and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
			)
		)

end










GO
GRANT EXECUTE ON [dbo].[sp_select_QCM00009_files] TO [ERPUSER] AS [dbo]
GO
