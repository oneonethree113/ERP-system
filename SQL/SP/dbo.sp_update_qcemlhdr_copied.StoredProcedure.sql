/****** Object:  StoredProcedure [dbo].[sp_update_qcemlhdr_copied]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_qcemlhdr_copied]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_qcemlhdr_copied]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--grant execute on sp_select_qcemlhdr_sent
--to ERP_USER

--grant execute on sp_select_qcemlhdr_sent
--to ERPUSER

CREATE PROCEDURE [dbo].[sp_update_qcemlhdr_copied] 

AS
begin

update qcemlhdr  
			set qeh_mailflg='C',
			 qeh_upddat =getdate()
where 
		qeh_mailflg='N'
END


GO
