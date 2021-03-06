/****** Object:  StoredProcedure [dbo].[sp_get_QCDFTIMG_IMGData]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_get_QCDFTIMG_IMGData]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_QCDFTIMG_IMGData]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_get_QCDFTIMG_IMGData]
@tmprptno nvarchar(20),
@dftseq int,
@dftcat nvarchar(10),
@imgseq int
AS
BEGIN  
select qdt_file from qcdftimg where 
        qdt_tmprptno = @tmprptno and
        qdt_dftseq = @dftseq and 
        qdt_dftcat = @dftcat and
		qdt_imgseq = @imgseq
END

GO
GRANT EXECUTE ON [dbo].[sp_get_QCDFTIMG_IMGData] TO [ERPUSER] AS [dbo]
GO
