/****** Object:  StoredProcedure [dbo].[sp_list_problem_inv]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_problem_inv]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_problem_inv]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_list_problem_inv] 

AS


create table #temp_a
(
a_amt decimal(13,4),
a_invno  nvarchar(20)
)
create table #temp_b
(
b_amt decimal(13,4),
b_invno  nvarchar(20)
)
create table #temp_c
(
c_amt decimal(13,4),
c_invno  nvarchar(20)
)
insert into #temp_a
select sum(hid_ttlamt),hid_invno  from shipgdtl    
		where hid_credat > '2015-03-03'
	group by hid_invno

insert into #temp_b
select  sum(case hdp_type when 'D' then hdp_amt*(-1)
		            when 'P' then   hdp_amt  end), hdp_invno
 from SHDISPRM 
		where hdp_credat > '2015-03-03'
	group by  hdp_invno

insert into #temp_c
SELECT hiv_ttlamt , hiv_invno FROM shinvhdr where hiv_credat > '2015-03-03'

select (a_amt + isnull(b_amt,0) - c_amt) ,* from
#temp_a
	left join #temp_b
	on [#temp_a].a_invno = [#temp_b].b_invno
	left join #temp_c
	on [#temp_a].a_invno = [#temp_c].c_invno
	where (a_amt + isnull(b_amt,0) - c_amt) > 1
		or (a_amt + isnull(b_amt,0) - c_amt) < -1

drop table  #temp_a
drop table  #temp_b
drop table  #temp_c



--select  '123.12','test1','1221.1','test2','121','test3'
GO
GRANT EXECUTE ON [dbo].[sp_list_problem_inv] TO [ERPUSER] AS [dbo]
GO
