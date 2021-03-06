/****** Object:  StoredProcedure [dbo].[sp_genBJJOBSUMID]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_genBJJOBSUMID]
GO
/****** Object:  StoredProcedure [dbo].[sp_genBJJOBSUMID]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_genBJJOBSUMID]
@PGID nvarchar(10)
AS
BEGIN

declare @jobdat date
declare @newjobseq int

set @jobdat = GETDATE()

if (select count(1) from bjexesum where left(bes_jobsumid, 8) = CONVERT(VARCHAR(10), @jobdat, 112) and bes_pgid = @PGID) > 0
	set @newjobseq = (select TOP 1 CONVERT(INT,  right(bes_jobsumid, 2)) + 1 from bjexesum where left(bes_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bes_pgid = @PGID order by bes_jobsumid desc)
else
	set @newjobseq = 1


if (select count(1) from bjexelog where left(bel_jobsumid, 8) = CONVERT(VARCHAR(10), @jobdat, 112) and bel_pgid = @PGID) > 0
	if (select TOP 1 CONVERT(INT,  right(bel_jobsumid, 2)) + 1 from bjexelog where left(bel_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bel_pgid = @PGID order by bel_jobsumid desc) > @newjobseq
		set @newjobseq = (select TOP 1 CONVERT(INT,  right(bel_jobsumid, 2)) + 1 from bjexelog where left(bel_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bel_pgid = @PGID order by bel_jobsumid desc)

if (select count(1) from bjmonsum where left(bms_jobsumid, 8) = CONVERT(VARCHAR(10), @jobdat, 112) and bms_pgid = @PGID) > 0
	if (select TOP 1 CONVERT(INT,  right(bms_jobsumid, 2)) + 1 from bjmonsum where left(bms_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bms_pgid = @PGID order by bms_jobsumid desc) > @newjobseq
		set @newjobseq = (select TOP 1 CONVERT(INT,  right(bms_jobsumid, 2)) + 1 from bjmonsum where left(bms_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bms_pgid = @PGID order by bms_jobsumid desc)


select CONCAT( CONVERT(VARCHAR(10), @jobdat, 112), replicate('0', 2 - len(@newjobseq)) + cast (@newjobseq as varchar))
	
END

GO
GRANT EXECUTE ON [dbo].[sp_genBJJOBSUMID] TO [ERPUSER] AS [dbo]
GO
