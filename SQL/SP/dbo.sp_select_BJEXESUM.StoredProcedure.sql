/****** Object:  StoredProcedure [dbo].[sp_select_BJEXESUM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_BJEXESUM]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_BJEXESUM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_select_BJEXESUM]
@bes_jobsumid nvarchar(20),
@bes_pgid nvarchar(20)
AS
BEGIN

select bes_jobsumid,
bes_pgid,
bes_pgname,
bes_pgstartdate,
bes_pgenddate,
bes_status,
bes_totalstep,
bes_status01,
bes_status02,
bes_status03,
bes_status04,
bes_status05,
bes_status06,
bes_status07,
bes_status08,
bes_status09,
bes_status10,
bes_remarks,
bes_creusr,
bes_updusr,
bes_credat,
bes_upddat,
bes_timstp
from BJEXESUM
where
bes_jobsumid = @bes_jobsumid and
bes_pgid = @bes_pgid	
END

GO
GRANT EXECUTE ON [dbo].[sp_select_BJEXESUM] TO [ERPUSER] AS [dbo]
GO
