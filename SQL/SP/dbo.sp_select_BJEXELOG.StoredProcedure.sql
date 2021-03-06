/****** Object:  StoredProcedure [dbo].[sp_select_BJEXELOG]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_BJEXELOG]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_BJEXELOG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_select_BJEXELOG]
@bel_jobsumid nvarchar(20),
@bel_pgid nvarchar(20)
AS
BEGIN

select bel_jobsumid,
bel_pgid,
bel_pgname,
bel_pglog,
bel_remarks,
bel_creusr,
bel_updusr,
bel_credat,
bel_upddat,
bel_timstp
from BJEXELOG
where
bel_jobsumid = @bel_jobsumid and
bel_pgid = @bel_pgid
END

GO
GRANT EXECUTE ON [dbo].[sp_select_BJEXELOG] TO [ERPUSER] AS [dbo]
GO
