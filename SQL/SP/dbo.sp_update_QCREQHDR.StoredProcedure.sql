/****** Object:  StoredProcedure [dbo].[sp_update_QCREQHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QCREQHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QCREQHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


Create  PROCEDURE [dbo].[sp_update_QCREQHDR]

	@qch_cocde nvarchar(6), @qch_qcno nvarchar(20), @qch_qcsts nvarchar(5),
	
	--20151026 Allow changing inspect type
	@qch_insptyp nvarchar(15),
	
	@qch_mon char(1), @qch_tue char(1), @qch_wed char(1), @qch_thur char(1), @qch_fri char(1), @qch_sat char(1), @qch_sun char(1), 
	@qch_sidate datetime, @qch_cydate datetime,  @qch_cispdate datetime, @qch_rmk nvarchar(300), @qch_samhdl nvarchar(10),
	
	@qch_updusr nvarchar(30)
AS
BEGIN


	UPDATE QCREQHDR
	SET
		qch_cocde = @qch_cocde,
		qch_qcsts = @qch_qcsts,
		
		qch_insptyp = @qch_insptyp, 
		
		qch_mon = @qch_mon,
		qch_tue = @qch_tue,
		qch_wed = @qch_wed,
		qch_thur = @qch_thur,
		qch_fri = @qch_fri,
		qch_sat = @qch_sat,
		qch_sun = @qch_sun,
		qch_sidate = @qch_sidate,
		qch_cydate = @qch_cydate, 
		qch_cispdate = @qch_cispdate, 
		qch_rmk = @qch_rmk, 
		qch_samhdl = @qch_samhdl, 
		
		
		qch_upddat = getdate(),
		qch_updusr = @qch_updusr
		
	WHERE
		qch_qcno = @qch_qcno

	
END


GO
GRANT EXECUTE ON [dbo].[sp_update_QCREQHDR] TO [ERPUSER] AS [dbo]
GO
