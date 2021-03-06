/****** Object:  StoredProcedure [dbo].[sp_abc]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_abc]
GO
/****** Object:  StoredProcedure [dbo].[sp_abc]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_abc]
as 

begin 

declare @delivery nvarchar(500)

create table #TEMP_POSEQ
(
tmp_ordno	nvarchar(20),
tmp_seq		int,
tmp_delivery	nvarchar(500),
tmp_address	nvarchar(2000)
)

insert into #TEMP_POSEQ
select pod_ordno, pod_seq, '  ', '  '
from pkorddtl 
where  pod_ordno in ('KG1400107', 'KG1400110')

select 
pod_ordno, pod_seq, poh_shpstr,poh_fty, pod_shpstr,pod_fty, pms_shpstrdat,pms_shpqty, pms_fty
into #TEMP_DELIVERY
from 
#TEMP_POSEQ
left join pkorddtl on pod_ordno = tmp_ordno and pod_seq = tmp_seq
left join pkordhdr  on pod_ordno = poh_ordno
left join pkmtlshp on pms_ordno = pod_ordno and pms_ordseq = pod_seq


create table #TEMP_FTY_LIST
(
	tmp_fty	nvarchar(200)
)

declare 
@pod_ordno nvarchar(20),
@pod_seq int,
@poh_shpstr datetime,
@poh_fty nvarchar(200),
@pod_shpstr datetime,
@pod_fty nvarchar(200),
@pms_shpstrdat datetime,
@pms_shpqty int,
@pms_fty nvarchar(200)

declare @last_ordno nvarchar(20), @last_seq int

set @last_ordno = ''
set @last_seq = 0
set @delivery = ''

select 
pod_ordno, pod_seq, poh_shpstr,poh_fty, pod_shpstr,pod_fty, pms_shpstrdat,pms_shpqty, pms_fty
from #TEMP_DELIVERY

declare cur_delivery cursor
for
select 
pod_ordno, pod_seq, poh_shpstr,poh_fty, pod_shpstr,pod_fty, pms_shpstrdat,pms_shpqty, pms_fty
from #TEMP_DELIVERY

open cur_delivery
fetch next from cur_delivery into
@pod_ordno,
@pod_seq,
@poh_shpstr,
@poh_fty,
@pod_shpstr,
@pod_fty,
@pms_shpstrdat,
@pms_shpqty,
@pms_fty

while @@fetch_status = 0
begin
	if @last_ordno <> @pod_ordno or @last_seq <> @pod_seq
	begin
		update #TEMP_POSEQ set tmp_delivery = @delivery where tmp_ordno = @last_ordno and tmp_seq = @last_seq
		set @delivery = ''
	end

	if @pms_fty <> '' and @pms_fty is not null
	begin
		set @delivery = @delivery + '
' + convert(varchar(10),@pms_shpstrdat,111) + '     ' + convert(varchar(10),@pms_shpqty) + '     ' + @pms_fty
		insert into #TEMP_FTY_LIST
		select @pms_fty
	end
	else if @pod_fty <> ''
	begin
		set @delivery = @delivery + '
' + convert(varchar(10),@pod_shpstr,111) + '     ' + @pod_fty
		insert into #TEMP_FTY_LIST
		select @pod_fty
	end
	else
	begin
		set @delivery = @delivery + '
' + convert(varchar(10),@poh_shpstr,111) + '     ' + @poh_fty
		insert into #TEMP_FTY_LIST
		select @poh_fty
	end

	set @last_ordno = @pod_ordno
	set @last_seq = @pod_seq

fetch next from cur_delivery into
@pod_ordno,
@pod_seq,
@poh_shpstr,
@poh_fty,
@pod_shpstr,
@pod_fty,
@pms_shpstrdat,
@pms_shpqty,
@pms_fty

end


update #TEMP_POSEQ set tmp_delivery = @delivery where tmp_ordno = @last_ordno and tmp_seq = @last_seq




declare 
@fty nvarchar(200),
@address nvarchar(2000)

declare cur_address2 cursor
for
select distinct tmp_fty from #TEMP_FTY_LIST where tmp_fty <> ''

open cur_address2
fetch next from cur_address2 into @fty

while @@fetch_status = 0
begin

	set @address = @address + '
'


fetch next from cur_address2 into @fty
end


--select distinct tmp_fty from #TEMP_FTY_LIST where tmp_fty <> ''

select * from #TEMP_POSEQ

--select * from #TEMP_DELIVERY

drop table #TEMP_POSEQ
drop table #TEMP_DELIVERY
drop table #TEMP_FTY_LIST

--close cur_address
end




--sp_abc



GO
