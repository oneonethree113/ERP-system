/****** Object:  StoredProcedure [dbo].[sp_keylist_QCRPTIMG_ungened]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_keylist_QCRPTIMG_ungened]
GO
/****** Object:  StoredProcedure [dbo].[sp_keylist_QCRPTIMG_ungened]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_keylist_QCRPTIMG_ungened]
@tmprptno 	nvarchar(20)

AS
BEGIN  
select qri_tmprptno , qri_inspcde, qri_imgseq ,qri_filepath from qcrptimg 
where qri_tmprptno = @tmprptno and qri_filepath = '' order by qri_tmprptno , qri_inspcde, qri_imgseq 
END

GO
GRANT EXECUTE ON [dbo].[sp_keylist_QCRPTIMG_ungened] TO [ERPUSER] AS [dbo]
GO
