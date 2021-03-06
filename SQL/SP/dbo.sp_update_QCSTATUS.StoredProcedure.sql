/****** Object:  StoredProcedure [dbo].[sp_update_QCSTATUS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QCSTATUS]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QCSTATUS]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


Create  PROCEDURE [dbo].[sp_update_QCSTATUS]

	@cocde nvarchar(6), @qcno nvarchar(20), @qcsts nvarchar(5)

AS
BEGIN
	Declare @cur_time as datetime
	set @cur_time = getdate()

	UPDATE QCREQHDR
	SET
		qch_qcsts = @qcsts,
		qch_upddat = @cur_time
	WHERE
		qch_qcno = @qcno

	UPDATE QCREQDTL
	SET
		qcd_dtlsts = @qcsts,
		qcd_upddat = @cur_time
	WHERE
		qcd_qcno = @qcno
	
	
	
END

GO
GRANT EXECUTE ON [dbo].[sp_update_QCSTATUS] TO [ERPUSER] AS [dbo]
GO
