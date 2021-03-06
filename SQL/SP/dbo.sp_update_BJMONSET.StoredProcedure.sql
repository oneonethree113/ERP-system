/****** Object:  StoredProcedure [dbo].[sp_update_BJMONSET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_BJMONSET]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_BJMONSET]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------------------------------------------------------- 
Create           procedure [dbo].[sp_update_BJMONSET]                                                                                                                                                                                                                                                                
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
         @bst_jobid nvarchar(20) ,
     @bst_jobname nvarchar(100),
     @bst_pgid nvarchar(20) ,
     @bst_pgname nvarchar(100),
     @bst_pgstepid nvarchar(20) ,
     @bst_pgstepname nvarchar(100),
        @gsusr   nvarchar (30) 

------------------------------------ 
AS

update BJMONSET

set     bst_jobname = @bst_jobname ,
     bst_pgid = @bst_pgid ,
     bst_pgname = @bst_pgname,
     bst_pgstepid = @bst_pgstepid,
     bst_pgstepname= @bst_pgstepname,
        bst_updusr=  'misbj',
        bst_upddat= getdate() 
 
  where 		   bst_jobid =@bst_jobid
				 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------


GO
GRANT EXECUTE ON [dbo].[sp_update_BJMONSET] TO [ERPUSER] AS [dbo]
GO
