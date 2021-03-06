/****** Object:  StoredProcedure [dbo].[sp_insert_BJMONSUM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_BJMONSUM]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_BJMONSUM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------------------------------------- 
Create           procedure [dbo].[sp_insert_BJMONSUM]                                                                                                                                                                                                                                                                
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
	@cocde   nvarchar(6),           
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

insert into  BJMONSUM
(

  bms_jobsumid ,
     bms_jobid ,
     bms_pgid,
     bms_jobname ,
     bms_lastflag ,
     bms_jobstartdate ,
     bms_jobenddate ,
     bms_totalpg ,
     bms_status01 ,
     bms_status02 ,
     bms_status03 ,
     bms_status04 ,
     bms_status05 ,
     bms_status06 ,
     bms_status07 ,
     bms_status08 ,
     bms_status09 ,
     bms_status10 ,
     bms_remarks    ,
        bms_creusr ,
        bms_updusr,
        bms_credat ,
        bms_upddat,
        bms_timstp  
)

values(
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
   
@bms_jobsumid ,
     @bms_jobid ,
     @bms_pgid,
     @bms_jobname ,
     @bms_lastflag ,
     @bms_jobstartdate ,
     @bms_jobenddate ,
     @bms_totalpg ,
     @bms_status01 ,
     @bms_status02 ,
     @bms_status03 ,
     @bms_status04 ,
     @bms_status05 ,
     @bms_status06 ,
     @bms_status07 ,
     @bms_status08 ,
     @bms_status09 ,
     @bms_status10 ,
     @bms_remarks ,
        'misbj',
        'misbj',
        getdate(),
        getdate(),
        NULL
)     
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_insert_BJMONSUM] TO [ERPUSER] AS [dbo]
GO
