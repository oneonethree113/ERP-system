/****** Object:  StoredProcedure [dbo].[sp_update_BJEXESUM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_BJEXESUM]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_BJEXESUM]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------------------------------------- 
Create  procedure [dbo].[sp_update_BJEXESUM]                                                                                                                                                                                                                                                                
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

     @bes_jobsumid nvarchar(20) ,
     @bes_pgid nvarchar(20),
     @bes_pgname varchar(100),
     @bes_pgstartdate datetime,
     @bes_pgenddate datetime,
	 @bes_status varchar(10),
     @bes_totalstep int,
     @bes_status01 varchar(10),
     @bes_status02 varchar(10),
     @bes_status03 varchar(10),
     @bes_status04 varchar(10),
     @bes_status05 varchar(10),
     @bes_status06 varchar(10),
     @bes_status07 varchar(10),
     @bes_status08 varchar(10),
     @bes_status09 varchar(10),
     @bes_status10 varchar(10),
     @bes_remarks nvarchar(300),
        @gsusr   nvarchar (30) 
          
------------------------------------ 
AS

update  BJEXESUM
set 
     bes_pgname = @bes_pgname ,
     bes_pgstartdate  = @bes_pgstartdate,
     bes_pgenddate  = @bes_pgenddate ,
     bes_status = @bes_status,
     bes_totalstep = @bes_totalstep,
     bes_status01 = @bes_status01,
     bes_status02 = @bes_status02,
     bes_status03 = @bes_status03,
     bes_status04 = @bes_status04 ,
     bes_status05 = @bes_status05 ,
     bes_status06 = @bes_status06,
     bes_status07 = @bes_status07,
     bes_status08 = @bes_status08 ,
     bes_status09 = @bes_status09,
     bes_status10 = @bes_status10 ,
     bes_remarks  = @bes_remarks  ,
        bes_updusr= 'misbj',
        bes_upddat = getdate()
 
  where 		     bes_jobsumid  =@bes_jobsumid  
				and  bes_pgid  =@bes_pgid 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_update_BJEXESUM] TO [ERPUSER] AS [dbo]
GO
