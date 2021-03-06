/****** Object:  StoredProcedure [dbo].[sp_select_QUXLS002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUXLS002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUXLS002]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




































CREATE                                                       PROCEDURE [dbo].[sp_select_QUXLS002]
@qxd_cocde		nvarchar(10),
@qxd_qutno		nvarchar(20),
@qxd_xlsfil		nvarchar(50),
@qxd_fildat		nvarchar(30)

AS

declare @tmp_count int
set @tmp_count =0

create table #LIST_RESULT
(
tmp_count int,
tmp_action nvarchar(10),
tmp_id int,
tmp_itmno nvarchar(30),
tmp_venno nvarchar(6),
tmp_vensna nvarchar(40),
tmp_dsc nvarchar(300),
tmp_colcde nvarchar(30),
tmp_pckunt nvarchar(10),
tmp_inrqty int,
tmp_mtrqty int,
tmp_hkprctrm nvarchar(30),
tmp_ftyprctrm nvarchar(30),
tmp_trantrm nvarchar(30),
tmp_basprc numeric(13,4),
tmp_ftyprc numeric(13,4),
res_matchid int,
res_itmno nvarchar(30),
res_colcde nvarchar(30),
res_pckunt nvarchar(10),
res_inrqty int,
res_mtrqty int,
res_hkprctrm nvarchar(30),
res_ftyprctrm nvarchar(30),
res_trantrm nvarchar(30),
res_cus1no nvarchar(10),
res_cus2no nvarchar(10),
res_basprc numeric(13,4),
res_ftyprc numeric(13,4),
res_message nvarchar(300),
res_acttyp nvarchar(10),
res_check nvarchar(10),
res_case nvarchar(10),
res_qutno nvarchar(20),
res_qutseq int,
tmp_contopc nvarchar(1),
tmp_conftr int
)

create table #LIST_PROCESS
(

qxd_seq int,
qxd_itmno nvarchar(30),

qxd_venno nvarchar(6),
qxd_vensna nvarchar(40),
qxd_vencolcde nvarchar(30),

qxd_um nvarchar(10),
qxd_inr int,
qxd_mtr int,

qxd_prctrm nvarchar(30),
qxd_trantrm nvarchar(30)
)


declare @txtyp as nvarchar(30)
declare @pricust as nvarchar(10)
declare @seccust as nvarchar(10)
declare @extcusgrp as nvarchar(10)
declare @intcusgrp as nvarchar(10)

select top 1 @txtyp = qxd_txtyp, @pricust = left(qxd_pricust,5), @seccust = left(qxd_seccust,5) from QUXLSDTL (nolock) where qxd_xlsfil = @qxd_xlsfil and qxd_fildat = @qxd_fildat
select @extcusgrp = cbi_cugrptyp_ext, @intcusgrp = isnull(cbi_cugrptyp_int, '') from CUBASINF (nolock) where cbi_cusno = @pricust


-- For cursor use
declare @chk_itmno nvarchar(30),
 @chk_colcde nvarchar(30),
 @chk_pckunt nvarchar(10),
 @chk_inrqty int,
 @chk_mtrqty int,
 @chk_hkprctrm nvarchar(30),
 @chk_ftyprctrm nvarchar(30),
 @chk_trantrm nvarchar(30),
 @chk_cus1no nvarchar(10),
 @chk_cus2no nvarchar(10),
 @chk_pv nvarchar(10)
 
if @txtyp = 'UPD'
begin
 
	-- U1. Match whole key with Quotation
	insert into #LIST_RESULT
	select 
	@tmp_count,
	'N', 
	qxd_seq, 
	qxd_itmno, 
	qxd_venno, 
	qxd_vensna, 
	qxd_dsc, 
	qxd_vencolcde, 
	qxd_um, 
	qxd_inr, 
	qxd_mtr, 
	qxd_prctrm, 
	qxd_prctrm, 
	qxd_trantrm, 
	qxd_basprc,
	qxd_ftyprc,
	0,   -- use this for contopc 
	qud_itmno, 
	qud_colcde, 
	qud_untcde,
	qud_inrqty,
	qud_mtrqty,
	qud_prctrm,
	qud_ftyprctrm,
	qud_trantrm,
	'',
	'',
	qud_basprc,
	qud_ftyprc,
	'',
	'UPD',
	'Y',
	0,
	qud_qutno,
	qud_qutseq,
	qud_contopc,
	qud_conftr
	from 
	QUXLSDTL (nolock)
	left join QUOTNDTL (nolock) on qud_cocde = @qxd_cocde 
		and qud_qutno = @qxd_qutno 
		and qud_itmno = qxd_itmno 
		and ( 
			(qud_untcde = qxd_um and  qud_inrqty =qxd_inr	and  qud_mtrqty =qxd_mtr)
			OR
			( qud_contopc <>  'Ytest2163776777774'  
			    and left(qud_untcde,2)='ST'
			    and qxd_um='PC'
			    and isnull(qud_conftr,1)*qud_inrqty =qxd_inr	
			    and  isnull(qud_conftr,1)*qud_mtrqty =qxd_mtr
			)
		          )
		and qud_prctrm = qxd_prctrm 
		and qud_trantrm = qxd_trantrm
		and Rtrim(Ltrim(qud_colcde)) = Rtrim(Ltrim(qxd_vencolcde )) --- 20140225
	where qxd_xlsfil = @qxd_xlsfil and qxd_fildat = @qxd_fildat
	and qud_qutno is not null


	update #LIST_RESULT set res_check = 'Y' where tmp_basprc = res_basprc
	---20140123  set 'Y', do NOT check 'Basic Price Different'
 	---update #LIST_RESULT set res_check = 'N', res_message = 'Basic Price Different'
 	update #LIST_RESULT set res_check = 'N', res_case = '0.2',res_message = 'Basic Price Different'
	 	 where (not      ( (round(tmp_basprc,2) = round(res_basprc,2) 
			--	and tmp_contopc<>'Y'
   				)
				or
				  (round(tmp_basprc*7.75,2) = round(res_basprc,2) 
			--	and tmp_contopc<>'Y'
				))

			and 
			not       ( (round(tmp_basprc,2)   =round( res_basprc/tmp_conftr,2)
			--              and tmp_contopc='Y'	
				)
				or 
				  (round(tmp_basprc*7.75,2)   =round( res_basprc/tmp_conftr,2)
			   --           and tmp_contopc='Y'	
				))

			and 
			not       ( (round(tmp_basprc,2)   =round( res_basprc*tmp_conftr,2)
			--              and tmp_contopc='Y'	
				)
				or 
				  (round(tmp_basprc*7.75,2)   =round( res_basprc*tmp_conftr,2)
			   --           and tmp_contopc='Y'	
				))



			)

		and ---20140224
			 (      ( (round(tmp_ftyprc,2) = round(res_ftyprc,2) 
			--	and tmp_contopc<>'Y'
   				)
				or
				  (round(tmp_ftyprc*7.75,2) = round(res_ftyprc,2) 
			--	and tmp_contopc<>'Y'
				))

			  OR
			       ( (round(tmp_ftyprc,2)   =round( res_ftyprc/tmp_conftr,2)
			--              and tmp_contopc='Y'	
				)
				or 
				  (round(tmp_ftyprc*7.75,2)   =round( res_ftyprc/tmp_conftr,2)
			   --           and tmp_contopc='Y'	
				))
			  OR
			       ( (round(tmp_ftyprc,2)   =round( res_ftyprc*tmp_conftr,2)
			--              and tmp_contopc='Y'	
				)
				or 
				  (round(tmp_ftyprc*7.75,2)   =round( res_ftyprc*tmp_conftr,2)
			   --           and tmp_contopc='Y'	
				))
			)		



	-- U2. Not Match whole key with Quotation

	insert into #LIST_PROCESS
	select
	qxd_seq, 
	qxd_itmno, 
	qxd_venno,
	qxd_vensna,
	qxd_vencolcde, 
	qxd_um, 
	qxd_inr, 
	qxd_mtr, 
	qxd_prctrm, 
	qxd_trantrm
	from 
	QUXLSDTL (nolock)
	left join QUOTNDTL (nolock) on qud_cocde = @qxd_cocde 
		and qud_qutno = @qxd_qutno and qud_itmno = qxd_itmno 
		and qud_untcde = qxd_um 	and qud_inrqty = qxd_inr and qud_mtrqty = qxd_mtr and qud_prctrm = qxd_prctrm and qud_trantrm = qxd_trantrm
	where qxd_xlsfil = @qxd_xlsfil and qxd_fildat = @qxd_fildat
	--and qud_qutno is null
	and qxd_itmno not in (
	select qxd_itmno
	from 
	QUXLSDTL (nolock)
	left join QUOTNDTL (nolock) on qud_cocde = @qxd_cocde 
		and qud_qutno = @qxd_qutno 
		and qud_itmno = qxd_itmno 
		and ( 
			(qud_untcde = qxd_um and  qud_inrqty =qxd_inr	and  qud_mtrqty =qxd_mtr)
			OR
			( qud_contopc <>  'Ytest2163776777774'  
			    and left(qud_untcde,2)='ST'
			    and qxd_um='PC'
			    and isnull(qud_conftr,1)*qud_inrqty =qxd_inr	
			    and  isnull(qud_conftr,1)*qud_mtrqty =qxd_mtr
			)
		          )
		and qud_prctrm = qxd_prctrm 
		and qud_trantrm = qxd_trantrm
		and Rtrim(Ltrim(qud_colcde)) = Rtrim(Ltrim(qxd_vencolcde )) --- 20140225
	where qxd_xlsfil = @qxd_xlsfil and qxd_fildat = @qxd_fildat
	and qud_qutno is not null
		)

---select * from #LIST_PROCESS
end
else
begin
	-- NEW case insert all value for doing matching process
	insert into #LIST_PROCESS
	select 
	qxd_seq, 
	qxd_itmno, 
	qxd_venno, 
	qxd_vensna, 
	qxd_vencolcde, 
	qxd_um, 
	qxd_inr, 
	qxd_mtr, 
	qxd_prctrm, 
	qxd_trantrm
	from 
	QUXLSDTL (nolock)
	where qxd_xlsfil = @qxd_xlsfil and qxd_fildat = @qxd_fildat
end


-- NEW / UPD Matching Process
-- N1.1 Match with whole key
	
insert into #LIST_RESULT
select
distinct 
@tmp_count,
'N', 
qxd_seq, 
qxd_itmno, 
qxd_venno, 
qxd_vensna, 
'',
qxd_vencolcde, 
--isnull(icf_colcde,qxd_vencolcde),
qxd_um, 
qxd_inr, 
qxd_mtr, 
qxd_prctrm, 
qxd_prctrm, 
qxd_trantrm, 
0,
0,
0, 
isnull(imu_itmno,''), 
isnull(icf_colcde,'N/A'),
isnull(imu_pckunt,''),
isnull(imu_inrqty,''),
isnull(imu_mtrqty,''),
isnull(imu_hkprctrm,''),
isnull(imu_ftyprctrm,''),
isnull(imu_trantrm,''),
'',
'',
1,
0,
'',--message
'NEW',
'Y',
'1.1',
'',
0,
"N",
1
from #LIST_PROCESS (nolock) 
inner join IMPRCINF (nolock) on imu_itmno = qxd_itmno

		and ( 
			( imu_pckunt = qxd_um and imu_inrqty = qxd_inr and imu_mtrqty = qxd_mtr )
			OR
			( 
			      left(imu_pckunt,2)='ST'
			    and qxd_um='PC'
			    and isnull(imu_conftr,1)*imu_inrqty =qxd_inr	
			    and  isnull(imu_conftr,1)*imu_mtrqty =qxd_mtr
			)
		          )

and Left(imu_hkprctrm,3) = Left(qxd_prctrm,3) and imu_trantrm = qxd_trantrm
--and imu_hkprctrm = qxd_prctrm and imu_trantrm = qxd_trantrm
left join IMCOLINF (nolock) on icf_itmno = qxd_itmno
where (qxd_um <> '' and qxd_mtr <> 0 and qxd_prctrm <> '')
and (icf_colcde = qxd_vencolcde
	or '#' + icf_colcde = qxd_vencolcde	)
and qxd_itmno not in (select itr_tmpitm from IMTMPREL)




-- Case 2, temp Item
	
insert into #LIST_RESULT
select 
distinct
@tmp_count,
'N', 
qxd_seq, 
qxd_itmno, 
qxd_venno, 
qxd_vensna, 
'',
qxd_vencolcde,
--isnull(icf_colcde, qxd_vencolcde),
qxd_um, 
qxd_inr, 
qxd_mtr, 
qxd_prctrm, 
qxd_prctrm, 
qxd_trantrm, 
0,
0,
0, 
isnull(itr_itmno,''),    --temp#, with some real#
isnull(icf_colcde,'N/A'),
isnull(imu_pckunt,''),
isnull(imu_inrqty,''),
isnull(imu_mtrqty,''),
isnull(imu_hkprctrm,''),
isnull(imu_ftyprctrm,''),
isnull(imu_trantrm,''),
'',
'',
0,
0,
'Temp Item with Real Number',--message
'NEW',
'Y',
'2',
'',
0,
"N",
1
from IMTMPREL  (nolock) 
inner join  #LIST_PROCESS  (nolock) on itr_tmpitm = qxd_itmno
inner join IMPRCINF (nolock) on imu_itmno = itr_itmno
left join IMCOLINF (nolock) on icf_itmno = qxd_itmno



-- N4 Item not match case, Item not in IM? Check with complete information ...
----------------
-- Case 4, temp Item
	
insert into #LIST_RESULT
select 
distinct
@tmp_count,
'N', 
qxd_seq, 
qxd_itmno, 
qxd_venno, 
qxd_vensna, 
'',
qxd_vencolcde, 
qxd_um, 
qxd_inr, 
qxd_mtr, 
qxd_prctrm, 
qxd_prctrm, 
qxd_trantrm, 
0,
0,
0, 
isnull(qxd_itmno,''),    --temp#, with some real#
qxd_vencolcde, 
isnull(qxd_um,''),
isnull(qxd_inr,''),
isnull(qxd_mtr,''),
isnull(qxd_prctrm,''),   -- should be FTY prc trm
isnull(qxd_prctrm,''),
isnull(qxd_trantrm,''),
'',
'',
0,
0,
'Item Not In IM (ext)',--message
'NEW',
'Y',
'4',
'',
0,
"N",
1
from QUXLSDTL  (nolock) 
where qxd_itmno not in (select imu_itmno from IMPRCINF)
and
qxd_xlsfil = @qxd_xlsfil and qxd_fildat = @qxd_fildat
and qxd_itmno not in (select res_itmno from #LIST_RESULT)
and not ((qxd_venno >= 'A' and qxd_venno <= 'Z')
	or 
	(qxd_venno >= 'a' and qxd_venno <= 'z'))

---20140220 no 3rd road for Interal Item
insert into #LIST_RESULT
select 
distinct
@tmp_count,
'N', 
qxd_seq, 
qxd_itmno, 
qxd_venno, 
qxd_vensna, 
'',
qxd_vencolcde, 
qxd_um, 
qxd_inr, 
qxd_mtr, 
qxd_prctrm, 
qxd_prctrm, 
qxd_trantrm, 
0,
0,
0, 
isnull(qxd_itmno,''),    --temp#, with some real#
qxd_vencolcde, 
isnull(qxd_um,''),
isnull(qxd_inr,''),
isnull(qxd_mtr,''),
isnull(qxd_prctrm,''),   -- should be FTY prc trm
isnull(qxd_prctrm,''),
isnull(qxd_trantrm,''),
'',
'',
0,
0,
'Item Not In IM (int)',--message
'NEW',
'N',
'4',
'',
0,
"N",
1
from QUXLSDTL  (nolock) 
where qxd_itmno not in (select imu_itmno from IMPRCINF)
and
qxd_xlsfil = @qxd_xlsfil and qxd_fildat = @qxd_fildat
and qxd_itmno not in (select res_itmno from #LIST_RESULT)
and  ((qxd_venno >= 'A' and qxd_venno <= 'Z')
	or 
	(qxd_venno >= 'a' and qxd_venno <= 'z'))



----------------
--update #LIST_RESULT set res_message = 'Item not matched & Item not in IM.', res_acttyp = 'NEW', res_check = 'Y'  where res_itmno = '' and res_case ='4'


-- N1C Item match case, Real Item with CMP status
/*
update #LIST_RESULT set res_message = '', res_acttyp = 'NEW', res_check = '', res_case = '1' 
from #LIST_RESULT, IMBASINF 
where 	res_itmno <> '' and 
	res_itmno = ibi_itmno and 
	ibi_itmsts in ('CMP') and 
	res_check <> 'N'
*/

-- N1INC Item match case, Real Item with not CMP status
update #LIST_RESULT set res_message = 'Item not  in CMP status!', res_acttyp = 'NEW', res_check = 'N', res_case = 'INC' 
from #LIST_RESULT, IMBASINF 
where 	res_itmno <> '' and 
	res_itmno = ibi_itmno and 
	ibi_itmsts not in ('CMP') and 
	res_check <> 'N' 

/*
-- Case 2: Temp Itme (NR3.1 Item match case, Temp Item with CMP status, no mapping new item)
update #LIST_RESULT set res_message = '', res_acttyp = 'NEW', res_check = 'Y', res_case = '2' 
--from #LIST_RESULT, IMBASINF 
--left join IMTMPREL on itr_itmno = ibi_itmno
--where res_itmno <> '' and res_itmno = ibi_itmno and ibi_ftytmp = 'Y' and ibi_itmsts in ('CMP') and itr_itmno is null and res_check <> 'N'
from IMTMPREL  (nolock) 
inner join   #LIST_RESULT  (nolock) on itr_itmno = res_itmno
---##need check is a "temp# only" item
---temp comment:
--inner join IMBASINF (nolock) on ibi_itmno = itr_itmno
--where  ibi_ftytmp = 'Y' and ibi_itmsts in ('CMP')  
*/
/*
-- N2INC  Item match case, Temp Item with CMP status, no mapping new item
update #LIST_RESULT set res_message = 'Temp item not in CMP status', res_acttyp = 'Skip', res_check = 'N', res_case = '2.INC' 
from #LIST_RESULT, IMBASINF 
left join IMTMPREL on itr_itmno = ibi_itmno
where res_itmno <> '' 
and res_itmno = ibi_itmno 
and ibi_ftytmp = 'Y' 
and ibi_itmsts not in ('CMP') 
and itr_itmno is null 
and res_check <> 'N' and res_case ='2'
*/

/*  
-- NR3.3 Item match case, Temp Item with CMP status, mapped with new item
update #LIST_RESULT set res_message = '', res_acttyp = 'NEW', res_check = 'Y', res_case = '2' 
from #LIST_RESULT 
left join IMTMPREL on itr_tmpitm = tmp_itmno
left join  IMBASINF  on ibi_itmno = itr_itmno
where 
tmp_itmno <> '' --and 
--res_itmno = ibi_itmno
 and ibi_ftytmp = 'Y' and ibi_itmsts in ('CMP') 
and itr_itmno is not null 
*/




-- Do the process for temp to real item
--...
-- Filter for pricing key of cus1no and cus2no

Declare cur_check_prcingkey cursor
for
select 
res_itmno,res_colcde,res_pckunt,res_inrqty,res_mtrqty,res_hkprctrm,res_ftyprctrm,res_trantrm 
from #LIST_RESULT (nolock) where res_acttyp = 'NEW' and res_itmno <> '' and res_check <> 'N'
order by res_itmno,res_colcde,res_pckunt,res_inrqty,res_mtrqty,res_hkprctrm,res_ftyprctrm,res_trantrm

open cur_check_prcingkey
fetch next from cur_check_prcingkey into
@chk_itmno,@chk_colcde,@chk_pckunt,@chk_inrqty,@chk_mtrqty,@chk_hkprctrm,@chk_ftyprctrm,@chk_trantrm

while @@fetch_status = 0
begin
	select @chk_pv = ivi_venno from IMVENINF (nolock) where ivi_itmno = @chk_itmno and ivi_def = 'Y'

	--select @pricust,@seccust,@chk_itmno,@chk_colcde,@chk_pckunt,@chk_inrqty,@chk_mtrqty,@chk_hkprctrm,@chk_ftyprctrm,@chk_trantrm

	if (select count(*) from IMPRCINF (nolock) 
		where imu_itmno = @chk_itmno 
		and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty 
		and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm 
		and imu_prdven = @chk_pv 
		and imu_cus1no = @pricust and imu_cus2no = @seccust 
		and imu_status = 'ACT') = 1
	begin
		set @chk_cus1no = @pricust
		set @chk_cus2no = @seccust
	end
	else if (select count(*) from IMPRCINF (nolock) 
		where imu_itmno = @chk_itmno 
		and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty 
		and imu_hkprctrm = @chk_hkprctrm 
		and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm 
		and imu_prdven = @chk_pv 
		and imu_cus1no = @pricust 
		and (Ltrim(imu_cus2no) = '' or  imu_cus2no is null) 
		and imu_status = 'ACT') = 1
	begin
		set @chk_cus1no = @pricust
		set @chk_cus2no = ''
	end
	else if (select count(*) from IMPRCINF (nolock) where imu_itmno = @chk_itmno and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm and imu_prdven = @chk_pv and imu_cus1no = @extcusgrp and (imu_cus2no = '' or  imu_cus2no is null) and imu_status = 'ACT') = 1
	begin
		set @chk_cus1no = @extcusgrp
		set @chk_cus2no = ''
	end
	else if (select count(*) from IMPRCINF (nolock) where imu_itmno = @chk_itmno and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm and imu_prdven = @chk_pv and imu_cus1no = @intcusgrp and (imu_cus2no = '' or  imu_cus2no is null) and imu_status = 'ACT') = 1
	 begin
	                set @chk_cus1no = @intcusgrp
	                set @chk_cus2no = ''
	end
	else if (select count(*) from IMPRCINF (nolock) where imu_itmno = @chk_itmno and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm and imu_prdven = @chk_pv and imu_cus1no = '' and imu_cus2no = '' and imu_status = 'ACT') = 1
	begin
		set @chk_cus1no = ''
		set @chk_cus2no = ''
	end
	else if  (select count(*) --temp #  case only
			from IMBASINF (nolock)
			left join IMTMPREL (nolock) on itr_tmpitm = ibi_itmno
			where ibi_ftytmp = 'Y'  and itr_itmno is null
			and ibi_itmno= @chk_itmno)	>0
	begin
		set @chk_cus1no = ''
		set @chk_cus2no = ''
	end
	else
	begin
		set @chk_cus1no = 'error'  --- test
		set @chk_cus2no = 'error'  ---test
	end

	if @chk_cus1no = 'error'
	begin
		update #LIST_RESULT set res_check = 'N', res_message = 'No valid pricing'
		 where res_itmno = @chk_itmno 
			and res_pckunt = @chk_pckunt 
			and res_inrqty = @chk_inrqty 
			and res_mtrqty = @chk_mtrqty 
			and res_hkprctrm = @chk_hkprctrm 
			and res_ftyprctrm = @chk_ftyprctrm 
			and res_trantrm = @chk_trantrm
		--- temp condition
		--- and res_itmno not in (select itr_itmno from IMTMPREL)
		--- 20140213
		and res_case <> '4'
	
	end
	else
	begin
		update #LIST_RESULT set res_check = 'Y', res_cus1no = @chk_cus1no, res_cus2no = @chk_cus2no
		 where res_itmno = @chk_itmno and res_pckunt = @chk_pckunt and res_inrqty = @chk_inrqty and res_mtrqty = @chk_mtrqty and res_hkprctrm = @chk_hkprctrm and res_ftyprctrm = @chk_ftyprctrm and res_trantrm = @chk_trantrm
		and res_check <> 'N'
	end

	fetch next from cur_check_prcingkey into
	@chk_itmno,@chk_colcde,@chk_pckunt,@chk_inrqty,@chk_mtrqty,@chk_hkprctrm,@chk_ftyprctrm,@chk_trantrm
end
close cur_check_prcingkey
deallocate cur_check_prcingkey






select 
tmp_count,
tmp_action,
tmp_id,
tmp_itmno,
tmp_venno,
tmp_vensna,
tmp_dsc,
tmp_colcde,
tmp_pckunt,
tmp_inrqty,
tmp_mtrqty,
tmp_hkprctrm,
tmp_ftyprctrm,
tmp_trantrm,
--tmp_basprc,
res_matchid,
res_itmno,
res_colcde,
res_pckunt,
res_inrqty,
res_mtrqty,
res_hkprctrm,
res_ftyprctrm,
res_trantrm,
--res_basprc,
--res_cus1no,
--res_cus2no,
res_message,
res_acttyp,
res_check,
res_case--,
--res_quono,
--res_qutseq,
--tmp_contopc
--tmp_conftr
from #LIST_RESULT
order by tmp_id

drop table #LIST_RESULT
drop table #LIST_PROCESS






























































GO
GRANT EXECUTE ON [dbo].[sp_select_QUXLS002] TO [ERPUSER] AS [dbo]
GO
