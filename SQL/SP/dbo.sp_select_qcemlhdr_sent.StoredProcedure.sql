/****** Object:  StoredProcedure [dbo].[sp_select_qcemlhdr_sent]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qcemlhdr_sent]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qcemlhdr_sent]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
		
		
		
--grant execute on sp_select_qcemlhdr_sent
--to ERP_USER

--grant execute on sp_select_qcemlhdr_sent
--to ERPUSER

create PROCEDURE [dbo].[sp_select_qcemlhdr_sent] 

AS
begin


select distinct qeh_tmprptno
from qcemlhdr  where qeh_mailflg= 'N'

		
END


GO
GRANT EXECUTE ON [dbo].[sp_select_qcemlhdr_sent] TO [ERPUSER] AS [dbo]
GO
