/****** Object:  StoredProcedure [dbo].[sp_insert_QCREQDTL_QCM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_QCREQDTL_QCM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_QCREQDTL_QCM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_insert_QCREQDTL_QCM00001]
	--Basic
	@qcd_cocde nvarchar(6), @qcd_qcno nvarchar(20), @qcd_qcseq int,
	@qcd_dtlsts nvarchar(5),  @qcd_genby nvarchar(2),  
	@qcd_flgpolink char(1), @qcd_qcposeq int, @qcd_purord nvarchar(20), @qcd_purseq int, 
	
	--QC Detail
	@mon char, @tue char, @wed char, @thur char, @fri char, @sat char, @sun char, 
	@qcd_samhdl nvarchar(10), 
	--@qcd_sidate datetime, @qcd_cydate datetime, @qcd_rmk nvarchar(300), 
	
	
	--@qcd_inspyear int, @qcd_inspweek int, 
	
	--@qcd_insptyp nvarchar(15),  @qcd_genby nvarchar(2), 
	--@qcd_sidate datetime, @qcd_cydate datetime,
	--@qcd_samhdl nvarchar(10), @qcd_rmk nvarchar(300), 
	

	--Basic
	@usr nvarchar(30)
AS
BEGIN
	Declare @cur_time as datetime
	set @cur_time = getdate()

	Insert into QCREQDTL (
		qcd_cocde, qcd_qcno, qcd_qcseq, 
		qcd_dtlsts, qcd_genby, 
		qcd_flgpolink, qcd_qcposeq, qcd_purord, qcd_purseq, 

		qcd_mon, qcd_tue, qcd_wed, qcd_thur, qcd_fri, qcd_sat, qcd_sun, 
		qcd_samhdl, --qcd_sidate, qcd_cydate, qcd_rmk, 
		
		qcd_creusr, qcd_updusr
	)
	SELECT
		@qcd_cocde, @qcd_qcno, @qcd_qcseq, 
		@qcd_dtlsts, @qcd_genby, 
		@qcd_flgpolink, @qcd_qcposeq, @qcd_purord, @qcd_purseq, 
		
		@mon, @tue, @wed, @thur, @fri, @sat, @sun, 
		@qcd_samhdl, --@qcd_sidate, @qcd_cydate, @qcd_rmk, 
		

		
		@usr, @usr
	
END


GO
GRANT EXECUTE ON [dbo].[sp_insert_QCREQDTL_QCM00001] TO [ERPUSER] AS [dbo]
GO
