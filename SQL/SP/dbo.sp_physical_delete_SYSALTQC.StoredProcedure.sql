/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SYSALTQC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SYSALTQC]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SYSALTQC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_physical_delete_SYSALTQC] 
@yst_cocde	 nvarchar(6) ,
@yst_team		nvarchar(30),
@yst_cus        nvarchar(30),
@yst_seq        BIGINT
AS

delete from SYSALTQC
where
yst_seq = @yst_seq



-----------------------------------------------

--grant execute on sp_physical_delete_SYSALTQC
--to  ERPUSER

--grant execute on sp_physical_delete_SYSALTQC
--to  ERP_USER



--grant execute on sp_insert_SYSALTQC 
--to  ERPUSER

--grant execute on sp_insert_SYSALTQC 
--to  ERP_USER



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SYSALTQC] TO [ERPUSER] AS [dbo]
GO
