/****** Object:  StoredProcedure [mikechu].[sp_check_scftydat]    Script Date: 09/29/2017 11:53:51 ******/
DROP PROCEDURE [mikechu].[sp_check_scftydat]
GO
/****** Object:  StoredProcedure [mikechu].[sp_check_scftydat]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [mikechu].[sp_check_scftydat]
@s_date as datetime,
@e_date as datetime

as
begin

create table #tmp_check_scftydat
(
checkdate datetime,
numofrecord int
)
declare @set_date as  datetime
set @set_date  = @s_date

WHILE (@set_date ) <= @e_date 
BEGIN  
 

	insert into #tmp_check_scftydat
	select @set_date  ,count(*) from scftydat where sfd_credat > @set_date    and
																sfd_credat <DATEADD (day ,1, @set_date  ) 

set @set_date  = DATEADD (day ,1, @set_date  )
END  

select * from #tmp_check_scftydat
drop table #tmp_check_scftydat

end
GO
GRANT EXECUTE ON [mikechu].[sp_check_scftydat] TO [ERPUSER] AS [mikechu]
GO
