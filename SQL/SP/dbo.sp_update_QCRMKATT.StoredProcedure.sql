/****** Object:  StoredProcedure [dbo].[sp_update_QCRMKATT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QCRMKATT]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QCRMKATT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


Create   procedure [dbo].[sp_update_QCRMKATT]
	@qch_cocde nvarchar(6),
	@qch_qcno nvarchar(20)
AS

BEGIN
	UPDATE QCREQHDR
	SET qch_verdoc = qch_verno
	WHERE
		qch_cocde = @qch_cocde
	AND qch_qcno = @qch_qcno
		
	
END


GO
GRANT EXECUTE ON [dbo].[sp_update_QCRMKATT] TO [ERPUSER] AS [dbo]
GO
