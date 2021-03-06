/****** Object:  StoredProcedure [dbo].[sp_insert_QCVENINF_QCM00002]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_QCVENINF_QCM00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_QCVENINF_QCM00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


Create  PROCEDURE [dbo].[sp_insert_QCVENINF_QCM00002]
	@qvi_cocde nvarchar(6), 
	@qvi_qcno nvarchar(20), @qvi_venno nvarchar(6), 
	
	@qvi_adr nvarchar(200), @qvi_cty nvarchar(30), @qvi_stt nvarchar(30), 
	@qvi_city nvarchar(30), @qvi_town nvarchar(30), @qvi_zip nvarchar(20), 
	
	@qvi_cntctp nvarchar(100), @qvi_cnttil nvarchar(30), @qvi_cntphn nvarchar(30), 
	@qvi_cntfax nvarchar(30), @qvi_cnteml nvarchar(50), 

	@usr nvarchar(30)
AS
BEGIN

	Insert into QCVENINF (
		--KEY
		qvi_cocde, qvi_qcno, qvi_venno,

		qvi_adr, qvi_cty, qvi_stt, qvi_city, qvi_town, qvi_zip, 
		
		qvi_cntctp, qvi_cnttil, qvi_cntphn, qvi_cntfax, qvi_cnteml, 
		
		qvi_creusr, qvi_updusr
	)
	SELECT
		@qvi_cocde, @qvi_qcno, @qvi_venno,
		
		@qvi_adr, @qvi_cty, @qvi_stt, @qvi_city, @qvi_town, @qvi_zip, 
		
		@qvi_cntctp, @qvi_cnttil, @qvi_cntphn, @qvi_cntfax, @qvi_cnteml, 
		
		@usr, @usr
	
END


GO
GRANT EXECUTE ON [dbo].[sp_insert_QCVENINF_QCM00002] TO [ERPUSER] AS [dbo]
GO
