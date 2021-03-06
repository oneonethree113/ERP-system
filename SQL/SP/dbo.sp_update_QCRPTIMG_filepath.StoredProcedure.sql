/****** Object:  StoredProcedure [dbo].[sp_update_QCRPTIMG_filepath]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QCRPTIMG_filepath]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QCRPTIMG_filepath]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_update_QCRPTIMG_filepath]
@tmprptno nvarchar(20),
@inspcde nvarchar(30),
@imgseq int,
@filePath nvarchar(300)
AS
BEGIN  

update qcrptimg set qri_filepath = @filePath, qri_file = null where 
               qri_tmprptno = @tmprptno and
               qri_inspcde = @inspcde and
               qri_imgseq = @imgseq

END

GO
GRANT EXECUTE ON [dbo].[sp_update_QCRPTIMG_filepath] TO [ERPUSER] AS [dbo]
GO
