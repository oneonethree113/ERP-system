/****** Object:  StoredProcedure [dbo].[sp_select_qcrptpho]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qcrptpho]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qcrptpho]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[sp_select_qcrptpho] 

AS BEGIN
	
	select distinct qrp_tmprptno from qcrptpho 
	where qrp_flg = 'N'


END



GO
GRANT EXECUTE ON [dbo].[sp_select_qcrptpho] TO [ERPUSER] AS [dbo]
GO
