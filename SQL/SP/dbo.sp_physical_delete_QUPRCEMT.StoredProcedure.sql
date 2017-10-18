/****** Object:  StoredProcedure [dbo].[sp_physical_delete_QUPRCEMT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_QUPRCEMT]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_QUPRCEMT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003

CREATE PROCEDURE [dbo].[sp_physical_delete_QUPRCEMT] 

@qpe_cocde 	nvarchar(6),
@qpe_qutno 	nvarchar(20),
@qpe_qutseq 	int


AS

delete from QUPRCEMT
where 	qpe_cocde = @qpe_cocde
and 	qpe_qutno = @qpe_qutno
and 	qpe_qutseq = @qpe_qutseq






GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_QUPRCEMT] TO [ERPUSER] AS [dbo]
GO
