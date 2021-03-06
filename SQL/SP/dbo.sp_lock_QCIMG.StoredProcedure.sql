/****** Object:  StoredProcedure [dbo].[sp_lock_QCIMG]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_lock_QCIMG]
GO
/****** Object:  StoredProcedure [dbo].[sp_lock_QCIMG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_lock_QCIMG]
@tmprptno 	nvarchar(20)

AS
declare @updateRow int
BEGIN  
SET NOCOUNT ON;

set @updateRow = 0;
update qcrptimg set qri_filepath = '' where qri_tmprptno = @tmprptno and qri_filepath is null
set @updateRow = @updateRow + (select @@rowcount)
update qcdftimg set qdt_filepath = '' where qdt_tmprptno = @tmprptno and qdt_filepath is null
set @updateRow = @updateRow + (select @@rowcount)
select @updateRow updateRow 
END

GO
GRANT EXECUTE ON [dbo].[sp_lock_QCIMG] TO [ERPUSER] AS [dbo]
GO
