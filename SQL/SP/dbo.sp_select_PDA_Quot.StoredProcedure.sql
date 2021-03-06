/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Quot]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PDA_Quot]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Quot]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Description   	: sp_select_PDA_Quot
Programmer  	: Mark Lau
Create Date   	: 2008-07-09
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    */ 
CREATE procedure [dbo].[sp_select_PDA_Quot]
@cocde	nvarchar(6),
@qud_cocde	nvarchar(6),
@usrid		nvarchar(30),
@qud_cus1no	nvarchar(10),
@qud_cus2no	nvarchar(10),
@datefrom	nvarchar(10),
@dateto	nvarchar(10),
@qud_tmpqutno 	nvarchar(50),
@typ		nvarchar(1)



as

if ( @typ = '1')
begin
if (@qud_tmpqutno) <> ''
begin
set @datefrom  = ''
end

select	distinct
case when qud_del = 'Y' then qud_del else 'N' end as 'Del',
qud_cocde,
qud_tmpqutno,
qud_seq,
qud_itmno,
qud_colcde,
qud_alsitmno,
qud_alscolcde,
qud_pckseq,
qud_untcde,
qud_inrqty,
qud_mtrqty,
qud_cft,
qud_cus1no,
p.cbi_cussna as 'pcussna',
qud_cus2no,
s.cbi_cussna as 'scussna',
qud_currel,
qud_curcde,
qud_cu1pri,
qud_cu2pri,
qud_prcsec,
qud_grsmgn,
qud_moq,
qud_moa,
qud_smpqty,
qud_disc,
qud_note,
qud_modify,
-- Frankie Cheung 20100422 Add Period
case year(qud_qutdat) when 1900 then '' else
	ltrim(rtrim(str(year(qud_qutdat)))) + '-' +right('00' + ltrim(rtrim(str(month(qud_qutdat)))),2) end as 'Period',
qud_creusr,
qud_credat,
qud_updusr,
qud_upddat,
qud_basprc,
qud_smpunt,
qud_venitm,
qud_aliitm,
qud_ventyp,
qud_cat,
qud_aprsts,
case when qud_del = 'Y' then qud_del else 'N' end as 'Upd'
from pda_quot 
left join cubasinf as p on qud_cus1no = p.cbi_cusno
left join cubasinf as s on qud_cus2no = s.cbi_cusno
left join SYSALREP as q (nolock) on  q.ysr_code = qud_creusr 
left join SYSALREP as u (nolock) on  u.ysr_code = @usrid 
left join SYMUSRCO  (nolock)  on yuc_usrid  = @usrid
where 
(  ( qud_creusr = @usrid or q.ysr_saltem = u.ysr_saltem  or u.ysr_saltem = 'S'  or yuc_supid = @usrid or yuc_usrgrp like '%MGT%' or isnull(u.ysr_saltem,'') = '') and @usrid <> '')
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
((( substring(qud_sessid,1,charindex('_',qud_sessid)) between @datefrom + '000000' and @dateto+'235959' ) and @datefrom <> '')  or @datefrom = '' ) 
and
((qud_tmpqutno = @qud_tmpqutno and @qud_tmpqutno <> '') or @qud_tmpqutno = '')
and  isnull(qud_aprsts,'') = ''  and  isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock)
	order by  
		qud_tmpqutno desc, qud_cocde, qud_seq, qud_cus1no,qud_cus2no,qud_itmno
end



if ( @typ = '2')
begin
if (@qud_tmpqutno) <> ''
begin
set @datefrom  = ''
end

select	distinct
	qud_tmpqutno,
convert(datetime,substring (qud_sessid, 1 , charindex('_',qud_sessid) -1 - 6),111 ) as 'qud_credat',
substring (qud_sessid, charindex('_',qud_sessid) +1 , len(qud_sessid ) -  charindex('_',qud_sessid)) as 'qud_creusr'
from 
	pda_quot 
left join cubasinf as p on qud_cus1no = p.cbi_cusno
left join cubasinf as s on qud_cus2no = s.cbi_cusno
left join SYSALREP as q (nolock) on  q.ysr_code = qud_creusr 
left join SYSALREP as u (nolock) on  u.ysr_code = @usrid 
left join SYMUSRCO  (nolock)  on yuc_usrid  = @usrid
where 
(  ( qud_creusr = @usrid or q.ysr_saltem = u.ysr_saltem  or u.ysr_saltem = 'S'  or yuc_supid = @usrid or yuc_usrgrp like '%MGT%' or isnull(u.ysr_saltem,'') = '') and @usrid <> '')
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
((( substring(qud_sessid,1,charindex('_',qud_sessid)) between @datefrom + '000000' and @dateto+'235959' ) and @datefrom <> '')  or @datefrom = '' ) 
--substring(qud_sessid,1,charindex('_',qud_sessid)) between @datefrom + '000000' and @dateto+'235959'
and
((qud_tmpqutno = @qud_tmpqutno and @qud_tmpqutno <> '') or @qud_tmpqutno = '')
and  isnull(qud_aprsts,'') = ''  and   isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock)
order by  
	qud_tmpqutno asc
end



if ( @typ = '3')
begin
select *
from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and  
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and  
isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock)
order by  
	qud_tmpqutno asc
end


if ( @typ = '4')
begin
select distinct qud_tmpqutno, qud_cocde, qud_cus1no, qud_cus2no
from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and  
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock)
group by  qud_tmpqutno, qud_cocde, qud_cus1no, qud_cus2no
order by  qud_tmpqutno, qud_cocde, qud_cus1no, qud_cus2no asc
end


if ( @typ = '5')
begin

-- UCPP Header
select *
from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'UCP'
and qud_seq = 
(
select min(qud_seq) from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'UCP'
)
union

-- UCP Header
select * from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'UCPP'
and qud_seq = 
(
select min(qud_seq) from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'UCPP'
)

union

-- PG Header
select * from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'PG'
and qud_seq = 
(
select min(qud_seq) 
from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'PG'
)

union

-- EW Header
select * from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'EW'
and qud_seq = 
(
select min(qud_seq)
from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'EW'
)

union

-- HX Header
select * from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'HX'
and qud_seq = 
(
select min(qud_seq) from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'HX'
)

union

-- TT Header
select * from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'TT'
and qud_seq = 
(
select min(qud_seq) from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'TT'
)

union

-- HB Header
select * from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'HB'
and qud_seq = 
(
select min(qud_seq) from pda_quot 
where 
qud_tmpqutno = @qud_tmpqutno
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
 isnull(qud_aprsts,'') = ''  and    isnull(qud_qutno,'') = ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock) and qud_cocde = 'HB'
)

order by  qud_sessid, qud_cocde, qud_cus1no, qud_cus2no, qud_seq asc
end


if ( @typ = '6')
begin

if (@qud_tmpqutno) <> ''
begin
set @datefrom  = ''
end

select distinct qud_cocde, qud_cus1no, qud_cus2no,qud_tmpqutno, qud_qutno
from pda_quot 
left join cubasinf as p on qud_cus1no = p.cbi_cusno
left join cubasinf as s on qud_cus2no = s.cbi_cusno
left join SYSALREP as q (nolock) on  q.ysr_code = qud_creusr 
left join SYSALREP as u (nolock) on  u.ysr_code = @usrid 
left join SYMUSRCO  (nolock)  on yuc_usrid  = @usrid
where 
(  ( qud_creusr = @usrid or q.ysr_saltem = u.ysr_saltem  or u.ysr_saltem = 'S'  or yuc_supid = @usrid or yuc_usrgrp like '%MGT%' or isnull(u.ysr_saltem,'') = '') and @usrid <> '')
and 
( ( qud_cus1no = @qud_cus1no and @qud_cus1no <> '' ) or  @qud_cus1no = '')
and 
( ( qud_cus2no = @qud_cus2no and @qud_cus2no <> '' ) or  @qud_cus2no = '')
and 
((( substring(qud_sessid,1,charindex('_',qud_sessid)) between @datefrom + '000000' and @dateto+'235959' ) and @datefrom <> '')  or @datefrom = '' ) 
--substring(qud_sessid,1,charindex('_',qud_sessid)) between @datefrom + '000000' and @dateto+'235959'
and
((qud_tmpqutno = @qud_tmpqutno and @qud_tmpqutno <> '') or @qud_tmpqutno = '')
and  isnull(qud_aprsts,'') = 'G'  and   isnull(qud_qutno,'') <> ''  
--and qud_cocde = @qud_cocde
and qud_tmpqutno not in (select distinct (qud_tmpqutno) from pda_quot_lock)
order by  qud_tmpqutno asc
end








GO
GRANT EXECUTE ON [dbo].[sp_select_PDA_Quot] TO [ERPUSER] AS [dbo]
GO
