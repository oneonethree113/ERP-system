/****** Object:  StoredProcedure [dbo].[sp_update_QUOTNHDR_qutsts]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QUOTNHDR_qutsts]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QUOTNHDR_qutsts]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




create  PROCEDURE [dbo].[sp_update_QUOTNHDR_qutsts] 

@quh_cocde	nvarchar(6),	
@quh_qutno	nvarchar(20),
@quh_qutsts	nvarchar(20),
@quh_creusr	nvarchar(30)
AS

UPDATE 	QUOTNHDR
SET	
	quh_qutsts = @quh_qutsts,
	quh_updusr = @quh_creusr
WHERE	quh_cocde = @quh_cocde 	and
 	quh_qutno = @quh_qutno






GO
GRANT EXECUTE ON [dbo].[sp_update_QUOTNHDR_qutsts] TO [ERPUSER] AS [dbo]
GO
