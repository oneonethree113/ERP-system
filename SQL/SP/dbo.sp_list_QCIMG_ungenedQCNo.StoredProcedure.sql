/****** Object:  StoredProcedure [dbo].[sp_list_QCIMG_ungenedQCNo]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_QCIMG_ungenedQCNo]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_QCIMG_ungenedQCNo]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_list_QCIMG_ungenedQCNo]

AS
BEGIN  
select distinct qri_tmprptno tmprptno from  qcrptimg where qri_filepath is null and qri_credat < getdate() -30
union 
select distinct qdt_tmprptno tmprptno from  qcdftimg where qdt_filepath is null and qdt_credat < getdate() -30 order by tmprptno
END

GO
GRANT EXECUTE ON [dbo].[sp_list_QCIMG_ungenedQCNo] TO [ERPUSER] AS [dbo]
GO
