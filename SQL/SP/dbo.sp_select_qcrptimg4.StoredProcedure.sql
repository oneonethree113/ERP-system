/****** Object:  StoredProcedure [dbo].[sp_select_qcrptimg4]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qcrptimg4]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qcrptimg4]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_select_qcrptimg4] 
@TmpRPTNo as nvarchar(30)

AS
begin
	
	SELECT 
	1000+qrc_rptimgdis_group as'group',
	qrc_rptimgdis_order,
	qri_file , 
	'' as 'rmk' into #result1
	from qcrptimg   
			LEFT JOIN QCRPTCDE 
			ON qri_inspcde =qrc_inspcde
	where  qri_tmprptno = @TmpRPTNo 
			and (
			(qrc_rptimgdis_group <= 50
				and qri_inspcde <> 'result_qcsign'
				and qri_inspcde <> 'result_suppliersign' ) )
			order by qrc_rptimgdis_group,qrc_rptimgdis_order

	--Defect image
	SELECT 
	2000+bb.qdt_dftseq as 'group',
	bb.qdt_imgseq as 'qrc_rptimgdis_order',
	bb.qdt_file as 'qri_file',
	aa.qdt_dftdsc +' ('  + 
		case 
		when bb.qdt_dftcat like '%Crit%'
			then  'Critical'
			else  bb.qdt_dftcat
		end
		 + ')' 
		as 'rmk' into #result2
	from qcdftimg  bb
				left join QCRPTDFT aa
					on bb.qdt_tmprptno = aa.qdt_tmprptno
					and  bb.qdt_dftseq  = aa.qdt_dftseq  
	where  bb.qdt_tmprptno = @TmpRPTNo 
			order by bb.qdt_dftseq,bb.qdt_imgseq

	--Remark image
	SELECT 
	3000+qrc_rptimgdis_group as'group',
	qrc_rptimgdis_order,
	qri_file , 
	'' as 'rmk' into #result3
	from qcrptimg   
			LEFT JOIN QCRPTCDE 
			ON qri_inspcde =qrc_inspcde
	where  qri_tmprptno = @TmpRPTNo 
			and (
		
		
			(qrc_rptimgdis_group > 50))
			order by qrc_rptimgdis_group,qrc_rptimgdis_order



	insert into #result2	select * from #result1;
	insert into #result2	select * from #result3;
	select * from #result2
	drop table #result1 ,#result2,#result3
END




GO
GRANT EXECUTE ON [dbo].[sp_select_qcrptimg4] TO [ERPUSER] AS [dbo]
GO
