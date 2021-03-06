/****** Object:  StoredProcedure [dbo].[sp_select_BJ_rpt_BJMONSUM ]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_BJ_rpt_BJMONSUM ]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_BJ_rpt_BJMONSUM ]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  procedure [dbo].[sp_select_BJ_rpt_BJMONSUM ]                                                                                                                                                                                                                                                                
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
AS
  SET NOCOUNT ON
begin
select * from BJMONSUM 
 where bms_credat > Cast(Replace(cast(DateAdd(Day, Datediff(Day,0, GetDate() -1), 0) as nvarchar(30)),'12:00AM','14:59') as datetime)
order by bms_jobid  ,bms_credat  
end

GO
GRANT EXECUTE ON [dbo].[sp_select_BJ_rpt_BJMONSUM ] TO [ERPUSER] AS [dbo]
GO
