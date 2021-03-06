/****** Object:  StoredProcedure [dbo].[sp_select_genBJJOBSUMID]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_genBJJOBSUMID]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_genBJJOBSUMID]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_select_genBJJOBSUMID]
@cocde nvarchar(10),
@PGID nvarchar(20)
AS
BEGIN

declare @jobdat date
declare @newjobseq int

set @jobdat = GETDATE()

if (select count(1) from bjexesum where left(bes_jobsumid, 8) = CONVERT(VARCHAR(10), @jobdat, 112) and bes_pgid = @PGID) > 0
        set @newjobseq = (select TOP 1 CONVERT(INT,  right(bes_jobsumid, LEN(bes_jobsumid) - 8)) + 1 from bjexesum where left(bes_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bes_pgid = @PGID order by bes_jobsumid desc)
else
        set @newjobseq = 1


if (select count(1) from bjexelog where left(bel_jobsumid, 8) = CONVERT(VARCHAR(10), @jobdat, 112) and bel_pgid = @PGID) > 0
        if (select TOP 1 CONVERT(INT,  right(bel_jobsumid, LEN(bel_jobsumid) - 8)) + 1 from bjexelog where left(bel_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bel_pgid = @PGID order by bel_jobsumid desc) > @newjobseq
                set @newjobseq = (select TOP 1 CONVERT(INT,  right(bel_jobsumid, LEN(bel_jobsumid) - 8)) + 1 from bjexelog where left(bel_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bel_pgid = @PGID order by bel_jobsumid desc)

if (select count(1) from bjmonsum where left(bms_jobsumid, 8) = CONVERT(VARCHAR(10), @jobdat, 112) and bms_pgid = @PGID) > 0
        if (select TOP 1 CONVERT(INT,  right(bms_jobsumid, LEN(bms_jobsumid) - 8)) + 1 from bjmonsum where left(bms_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bms_pgid = @PGID order by bms_jobsumid desc) > @newjobseq
                set @newjobseq = (select TOP 1 CONVERT(INT,  right(bms_jobsumid, LEN(bms_jobsumid) - 8)) + 1 from bjmonsum where left(bms_jobsumid, 8) =  CONVERT(VARCHAR(10), @jobdat, 112) and bms_pgid = @PGID order by bms_jobsumid desc)


select CONCAT( CONVERT(VARCHAR(10), @jobdat, 112), replicate('0', 4 - len(@newjobseq)) + cast (@newjobseq as varchar))
                        as 'BJJOBSUMID'  
        

        
END

GO
GRANT EXECUTE ON [dbo].[sp_select_genBJJOBSUMID] TO [ERPUSER] AS [dbo]
GO
