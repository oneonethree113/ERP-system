/****** Object:  StoredProcedure [dbo].[sp_update_BJ_LASTFLG]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_BJ_LASTFLG]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_BJ_LASTFLG]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_update_BJ_LASTFLG]
@JOBSUMID nvarchar(20),
@PGID nvarchar(20)
AS
BEGIN

if (select count(1) from bjmonsum where bms_jobsumid = @JOBSUMID and bms_pgid = @PGID) > 0
	update bjmonsum set bms_lastflag = 'N', bms_upddat = GETDATE() WHERE left(bms_jobsumid, 8) = left(@JOBSUMID, 8)
	and bms_jobsumid <> @JOBSUMID and bms_pgid = @PGID and bms_lastflag = 'Y'

END

GO
GRANT EXECUTE ON [dbo].[sp_update_BJ_LASTFLG] TO [ERPUSER] AS [dbo]
GO
