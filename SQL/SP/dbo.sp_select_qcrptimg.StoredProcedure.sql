/****** Object:  StoredProcedure [dbo].[sp_select_qcrptimg]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qcrptimg]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qcrptimg]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_select_qcrptimg] 
@TmpRPTNo as nvarchar(30)

AS
begin

SELECT 
qrc_rptimgdis_group,qrc_rptimgdis_order,qri_file , '' as 'rmk'
from qcrptimg   
		LEFT JOIN QCRPTCDE 
		ON qri_inspcde =qrc_inspcde
where  qri_tmprptno = @TmpRPTNo 
		and qrc_rptimgdis_group <= 50
			and qri_inspcde <> 'result_qcsign'
				and qri_inspcde <> 'result_suppliersign'
		order by qrc_rptimgdis_group,qrc_rptimgdis_order
		
END



GO
GRANT EXECUTE ON [dbo].[sp_select_qcrptimg] TO [ERPUSER] AS [dbo]
GO
