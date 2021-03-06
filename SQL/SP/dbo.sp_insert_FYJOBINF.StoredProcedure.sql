/****** Object:  StoredProcedure [dbo].[sp_insert_FYJOBINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_FYJOBINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_FYJOBINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Checked by Allan Yuen at 28/07/2003  
  
CREATE PROCEDURE [dbo].[sp_insert_FYJOBINF]   
--------------------------------------------------------------------------------------------------------------------------------------  
  
@fji_cocde nvarchar(6),  
@fji_jobno nvarchar(20),  
@fji_ftycde nvarchar(6),  
@fji_itmno nvarchar(20),  
@fji_ordno nvarchar(20),  
@fji_creusr nvarchar(30)  
--------------------------------------------------------------------------------------------------------------------------------------  
AS  
  
INSERT INTO  FYJOBINF  
(  
fji_cocde,  
fji_jobno,  
fji_ftycde,  
fji_itmno,  
fji_ordno,  
fji_creusr,  
fji_updusr ,
fji_credat ,
fji_upddat
)   
--------------------------------------------------------------------------------------------------------------------------------------  
values  
(  
@fji_cocde,  
@fji_jobno,  
@fji_ftycde,  
@fji_itmno,  
@fji_ordno,  
@fji_creusr,  
@fji_creusr  ,
-- Lester Wu 
getdate(),
getdate()
)  
  
  





GO
GRANT EXECUTE ON [dbo].[sp_insert_FYJOBINF] TO [ERPUSER] AS [dbo]
GO
