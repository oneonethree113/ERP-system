/****** Object:  StoredProcedure [dbo].[sp_update_QCVENINF_QCM00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QCVENINF_QCM00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QCVENINF_QCM00002]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


Create  PROCEDURE [dbo].[sp_update_QCVENINF_QCM00002]
	@qvi_cocde nvarchar(6),
	@qvi_qcno nvarchar(20), @qvi_venno nvarchar(6), 
	
	@qvi_adr nvarchar(200), @qvi_cty nvarchar(100), @qvi_stt nvarchar(100), 
	@qvi_city nvarchar(100), @qvi_town nvarchar(100), @qvi_zip nvarchar(100), 
	
	@qvi_cntctp nvarchar(100), @qvi_cnttil nvarchar(30), @qvi_cntphn nvarchar(30), 
	@qvi_cntfax nvarchar(30), @qvi_cnteml nvarchar(50), 

	@usr nvarchar(30)
AS
BEGIN

	UPDATE QCVENINF
	SET
		qvi_adr = @qvi_adr, 
		qvi_cty = @qvi_cty, 
		qvi_stt = @qvi_stt, 
		qvi_city = @qvi_city, 
		qvi_town = @qvi_town, 
		qvi_zip = @qvi_zip, 
		
		qvi_cntctp = @qvi_cntctp, 
		qvi_cnttil = @qvi_cnttil, 
		qvi_cntphn = @qvi_cntphn, 
		qvi_cntfax = @qvi_cntfax, 
		qvi_cnteml = @qvi_cnteml, 
		
		qvi_updusr = @usr, 
		qvi_upddat = getdate()
	WHERE
		qvi_cocde = @qvi_cocde
	AND qvi_qcno = @qvi_qcno
	AND qvi_venno = @qvi_venno


	
	
END


GO
GRANT EXECUTE ON [dbo].[sp_update_QCVENINF_QCM00002] TO [ERPUSER] AS [dbo]
GO
