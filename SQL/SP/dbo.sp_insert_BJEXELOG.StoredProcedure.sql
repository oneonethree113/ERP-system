/****** Object:  StoredProcedure [dbo].[sp_insert_BJEXELOG]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_BJEXELOG]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_BJEXELOG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------------------------------------- 
Create  procedure [dbo].[sp_insert_BJEXELOG]                                                                                                                                                                                                                                                                
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
     @cocde   nvarchar(6),   
	 @bel_jobsumid nvarchar(20) ,
     @bel_pgid nvarchar(20),
     @bel_pgname varchar(100),
     @bel_pglog varchar(MAX),
     @bel_remarks nvarchar(300),
        @gsusr   nvarchar (30) 
------------------------------------ 
AS

insert into  BJEXELOG
(
     bel_jobsumid,
     bel_pgid ,
     bel_pgname ,
     bel_pglog ,
     bel_remarks ,
        bel_creusr ,
        bel_updusr,
        bel_credat ,
        bel_upddat,
        bel_timstp  
) 

values(
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
     @bel_jobsumid,
     @bel_pgid ,
     @bel_pgname ,
     @bel_pglog ,
     @bel_remarks ,
          'misbj',
        'misbj',
        getdate(),
        getdate(),
        NULL
)     
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------- 



GO
GRANT EXECUTE ON [dbo].[sp_insert_BJEXELOG] TO [ERPUSER] AS [dbo]
GO
