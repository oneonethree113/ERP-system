/****** Object:  StoredProcedure [dbo].[sp_physical_delete_QUASSINF_itmno]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_QUASSINF_itmno]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_QUASSINF_itmno]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

CREATE PROCEDURE [dbo].[sp_physical_delete_QUASSINF_itmno] 

@qai_cocde 	nvarchar(6),
@qai_qutno 	nvarchar(20),
@qai_qutseq 	int,
@qai_itmno 	nvarchar(20),
@qai_assitm	nvarchar(20),
@qai_colcde	nvarchar(30)


AS

delete from QUASSINF
where 	qai_cocde = @qai_cocde
and 	qai_qutno = @qai_qutno
and 	qai_qutseq = @qai_qutseq
and 	qai_itmno = @qai_itmno
and 	qai_assitm = @qai_assitm
and 	qai_colcde = @qai_colcde





GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_QUASSINF_itmno] TO [ERPUSER] AS [dbo]
GO
