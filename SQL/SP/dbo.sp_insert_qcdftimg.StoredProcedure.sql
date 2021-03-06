/****** Object:  StoredProcedure [dbo].[sp_insert_qcdftimg]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_qcdftimg]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_qcdftimg]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insert_qcdftimg] 
		@qdt_tmprptno nvarchar(20)
		,@qdt_dftseq int
		,@qdt_dftcat nvarchar(10)
		,@qdt_imgseq int
		,@qdt_filepath nvarchar(300)
		,@qdt_file nvarchar(MAX)
		,@qdt_creusr nvarchar(30)
		,@qdt_updusr nvarchar(30)
		,@qdt_credat datetime
		,@qdt_upddat datetime

AS BEGIN
	Declare @cur_time as datetime
	set @cur_time = getdate()
	
	INSERT INTO dbo.QCDFTIMG
           (qdt_tmprptno
			,qdt_dftseq
			,qdt_dftcat
			,qdt_imgseq
			,qdt_filepath
			,qdt_file
			,qdt_creusr
			,qdt_updusr
			,qdt_credat
			,qdt_upddat)
     VALUES (@qdt_tmprptno
			,@qdt_dftseq
			,@qdt_dftcat
			,@qdt_imgseq
			,@qdt_filepath
			,cast(N'' as xml).value('xs:base64Binary(sql:variable("@qdt_file"))', 'varbinary(max)')
			,@qdt_creusr
			,@qdt_updusr
			,@cur_time
			,@cur_time)

END




GO
GRANT EXECUTE ON [dbo].[sp_insert_qcdftimg] TO [ERPUSER] AS [dbo]
GO
