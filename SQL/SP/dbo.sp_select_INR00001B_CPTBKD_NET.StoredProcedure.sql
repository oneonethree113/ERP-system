/****** Object:  StoredProcedure [dbo].[sp_select_INR00001B_CPTBKD_NET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00001B_CPTBKD_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00001B_CPTBKD_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
=================================================================
Program ID	: sp_select_INR00001B_CPTBKD_NET
Description	: Retrieve Customer Invoice Data (Walmart) - 
		  Component Breakdown

=================================================================
	MODIFICATION HISTORY
*/

CREATE    procedure [dbo].[sp_select_INR00001B_CPTBKD_NET] 
@cocde		nvarchar(6) ,    
@from		nvarchar(20),
@to		nvarchar(20)

AS    
BEGIN    


create table #tmp_SHCPTBKD
(	hcb_cocde	nvarchar(6),
	hcb_invno	nvarchar(20),
	hcb_shpno	nvarchar(20),
	hcb_cusno	nvarchar(20),
	hcb_shpseq	int,
	hcb_cptseq	int,
	hcb_cpt		nvarchar(300),
	hcb_per		nvarchar(20)--numeric(10, 2)
)

create table #tmp_seq
( tmp_seq int
)

/*
create table #tmp_SHCPTBKD_1
(	hcb_cocde	nvarchar(6),
	hcb_invno	nvarchar(20),
	hcb_shpno	nvarchar(20),
	hcb_shpseq	int,
	hcb_cptseq	int,
	hcb_cpt		nvarchar(300),
	hcb_per		nvarchar(20)--numeric(10, 2)
)
*/



/*
insert into #tmp_SHCPTBKD_1
select @cocde,@from,@shpno,1,1,'','0.00'

insert into #tmp_SHCPTBKD_1
select @cocde,@from,@shpno,1,2,'','0.00'

insert into #tmp_SHCPTBKD_1
select @cocde,@from,@shpno,1,3,'','0.00'

insert into #tmp_SHCPTBKD_1
select @cocde,@from,@shpno,1,4,'','0.00'

insert into #tmp_SHCPTBKD_1
select @cocde,@from,@shpno,1,5,'','0.00'

insert into #tmp_SHCPTBKD_1
select @cocde,@from,@shpno,1,6,'','0.00'

insert into #tmp_SHCPTBKD_1
select @cocde,@from,@shpno,1,7,'','0.00'

insert into #tmp_SHCPTBKD_1
select @cocde,@from,@shpno,1,8,'','0.00'

*/
insert into #tmp_seq
select 1
insert into #tmp_seq
select 2
insert into #tmp_seq
select 3
insert into #tmp_seq
select 4
insert into #tmp_seq
select 5
insert into #tmp_seq
select 6
insert into #tmp_seq
select 7
insert into #tmp_seq
select 8

--select * from SHCPTBKD

insert into #tmp_SHCPTBKD 
select distinct @cocde,hid_invno,shb_ordno,hih_cus1no,shb_ordseq,tmp_seq,'','0.00'
from  SHCPTBKD
	left join shipghdr on shb_ordno = hih_shpno
	left join  #tmp_seq  on 1=1
	left join shipgdtl on  shb_ordno = hid_shpno
			and  shb_ordseq = hid_shpseq
where shb_ordno in 
		(select  hiv_shpno from SHINVHDR where hiv_invno >= @from
							and hiv_invno <= @to
		)


--select * from SHCPTBKD
update #tmp_SHCPTBKD 
set hcb_cpt = Rtrim(Ltrim(shb_cpt)), 
hcb_per = cast( round(shb_pct,1) as decimal(9,1))
from #tmp_SHCPTBKD, SHCPTBKD 
where hcb_shpno = shb_ordno 
and hcb_shpseq = shb_ordseq 
and hcb_cptseq = shb_cptseq


select * from #tmp_SHCPTBKD
order by hcb_shpno ,hcb_shpseq,hcb_cptseq

drop table #tmp_SHCPTBKD
drop table #tmp_seq



END











GO
GRANT EXECUTE ON [dbo].[sp_select_INR00001B_CPTBKD_NET] TO [ERPUSER] AS [dbo]
GO
