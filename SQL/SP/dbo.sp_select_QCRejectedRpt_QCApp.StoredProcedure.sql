/****** Object:  StoredProcedure [dbo].[sp_select_QCRejectedRpt_QCApp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCRejectedRpt_QCApp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCRejectedRpt_QCApp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_select_QCRejectedRpt_QCApp]
@code             nvarchar(2)
AS

BEGIN
DECLARE @tmprptno VARCHAR(MAX) 
SELECT @tmprptno = COALESCE(@tmprptno + ', ', '') + qrh_tmprptno 
FROM qcrpthdr
where qrh_tmprptno like 'QCP'+@code+ '%'
AND upper(qrh_finalstatus) like '%REJECT%'
AND qrh_rptstatus = 'CONFIRM'
select ISNULL( @tmprptno, '') tmprptno

END

SET QUOTED_IDENTIFIER OFF

GO
GRANT EXECUTE ON [dbo].[sp_select_QCRejectedRpt_QCApp] TO [ERPUSER] AS [dbo]
GO
