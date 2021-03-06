/****** Object:  StoredProcedure [dbo].[sp_update_BJMONSUM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_BJMONSUM]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_BJMONSUM]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------------------------------------- 
Create           procedure [dbo].[sp_update_BJMONSUM]                                                                                                                                                                                                                                                                
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
         @bms_jobsumid  nvarchar(20),
     @bms_jobid nvarchar(20),
     @bms_pgid nvarchar(20),
     @bms_jobname varchar(100),
     @bms_lastflag nvarchar(1),
     @bms_jobstartdate datetime,
     @bms_jobenddate datetime,
     @bms_totalpg int,
     @bms_status01 varchar(10),
     @bms_status02 varchar(10),
     @bms_status03 varchar(10),
     @bms_status04 varchar(10),
     @bms_status05 varchar(10),
     @bms_status06 varchar(10),
     @bms_status07 varchar(10),
     @bms_status08 varchar(10),
     @bms_status09 varchar(10),
     @bms_status10 varchar(10),
     @bms_remarks nvarchar(300),
        @gsusr   nvarchar (30) 

------------------------------------ 
AS

update  BJMONSUM
set 
     bms_jobname = @bms_jobname,
     bms_lastflag  =@bms_lastflag,
     bms_jobstartdate = @bms_jobstartdate,
     bms_jobenddate = @bms_jobenddate,
     bms_totalpg = @bms_totalpg,
     bms_status01 = @bms_status01,
     bms_status02 = @bms_status02,
     bms_status03 = @bms_status03,
     bms_status04 = @bms_status04,
     bms_status05 = @bms_status05,
     bms_status06 = @bms_status06,
     bms_status07 = @bms_status07,
     bms_status08 = @bms_status08,
     bms_status09 = @bms_status09,
     bms_status10 = @bms_status10,
     bms_remarks    = @bms_remarks   ,
        bms_updusr= 'misbj',
        bms_upddat = getdate()
 
  where 		     bms_jobsumid  =@bms_jobsumid  
				and bms_jobid  =@bms_jobid 
				and bms_pgid = @bms_pgid

---------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_update_BJMONSUM] TO [ERPUSER] AS [dbo]
GO
