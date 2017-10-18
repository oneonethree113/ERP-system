/****** Object:  StoredProcedure [dbo].[sp_keylist_QCDFTIMG_ungened]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_keylist_QCDFTIMG_ungened]
GO
/****** Object:  StoredProcedure [dbo].[sp_keylist_QCDFTIMG_ungened]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_keylist_QCDFTIMG_ungened]
@tmprptno 	nvarchar(20)

AS
BEGIN  
select qdt_tmprptno, qdt_dftseq, qdt_dftcat, qdt_imgseq ,qdt_filepath from qcdftimg 
where qdt_tmprptno = @tmprptno and qdt_filepath = '' order by qdt_tmprptno, qdt_dftseq, qdt_dftcat, qdt_imgseq 
END

GO
GRANT EXECUTE ON [dbo].[sp_keylist_QCDFTIMG_ungened] TO [ERPUSER] AS [dbo]
GO
