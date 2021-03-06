/****** Object:  StoredProcedure [dbo].[sp_insert_qcrptdft]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_qcrptdft]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_qcrptdft]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insert_qcrptdft] 
		 @qdt_tmprptno nvarchar(20)
		,@qdt_dftseq int
		,@qdt_dfttyp varchar(20)
		,@qdt_dftdsc nvarchar(200)
		,@qdt_dftcrt int
		,@qdt_dftmaj int
		,@qdt_dftmin int
		,@qdt_creusr nvarchar(30)
		,@qdt_updusr nvarchar(30)
		,@qdt_credat datetime
		,@qdt_upddat datetime

AS BEGIN
	Declare @cur_time as datetime
	set @cur_time = getdate()
	
	INSERT INTO dbo.QCRPTDFT
           (qdt_tmprptno
			,qdt_dftseq
			,qdt_dfttyp
			,qdt_dftdsc
			,qdt_dftcrt
			,qdt_dftmaj
			,qdt_dftmin
			,qdt_creusr
			,qdt_updusr
			,qdt_credat
			,qdt_upddat)
     VALUES (@qdt_tmprptno
			,@qdt_dftseq
			,@qdt_dfttyp
			,@qdt_dftdsc
			,@qdt_dftcrt
			,@qdt_dftmaj
			,@qdt_dftmin
			,@qdt_creusr
			,@qdt_updusr
			,@cur_time
			,@cur_time)

END




GO
GRANT EXECUTE ON [dbo].[sp_insert_qcrptdft] TO [ERPUSER] AS [dbo]
GO
