/****** Object:  StoredProcedure [dbo].[sp_select_SMR00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SMR00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SMR00002]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- sp_select_SMR00002 'UCP', '2010-10-01','2010-11-07','1000','9999'

-- Change ETD to Invoice Update Date selection 2011-02-10 Marco Chan
CREATE procedure [dbo].[sp_select_SMR00002] 
(
@cocde nvarchar(6),
@datefm datetime,
@dateto datetime,
@vennofm nvarchar(10),
@vennoto nvarchar(10)
)

AS

BEGIN

/*
create table #TEMP_RESULT
(
tmp_invno	nvarchar(20),
tmp_slnonb	datetime,
tmp_cus1no	nvarchar(10),
tmp_cussna	nvarchar(100),
tmp_purord	nvarchar(20),
tmp_venno	nvarchar(10),
tmp_vensna	nvarchar(100),
tmp_USD		nvarchar(10),
tmp_usdamt	numeric(13,4),
tmp_HKD		nvarchar(10),
tmp_hkdamt	numeric(13,4)
)
*/
--insert into #TEMP_RESULT
select 
hid_invno as 'Invoice No',  
hih_slnonb as 'Shipment Date',
hih_cus1no  as 'Pri Cust',
cbi_cussna  as 'Cust Name', 
hid_purord as 'PO No', 
poh_shpstr as 'PO Header Ship Start',
poh_shpend as 'PO Header Ship End',
poh_venno as 'Vendor No', 
vbi_vensna as 'Vendor Name', 
'USD', 
case poh_curcde when 'USD' then sum(((hid_shpqty * pod_ftyprc) * (100 - poh_discnt)/100)) else 0 end as 'USD Amount',
'HKD',
case poh_curcde when 'HKD' then sum(((hid_shpqty * pod_ftyprc) * (100 - poh_discnt)/100)) else 0 end as 'HKD Amount'
from SHIPGHDR  (nolock)
left join SHIPGDTL  (nolock) on hih_cocde = hid_cocde and hih_shpno = hid_shpno
left join SHINVHDR  (nolock) on hih_cocde = hiv_cocde and hid_shpno = hiv_shpno and hid_invno = hiv_invno
left join POORDDTL  (nolock) on pod_cocde = hih_cocde and pod_purord = hid_purord and pod_purseq = hid_purseq
left join POORDHDR  (nolock) on poh_cocde = hih_cocde and pod_purord = poh_purord
left join CUBASINF  (nolock) on cbi_cusno = hih_cus1no
left join VNBASINF  (nolock) on vbi_venno = poh_venno
where 
--hih_slnonb between @datefm and @dateto 
hiv_upddat between @datefm and @dateto
and ((@cocde <> 'ALL' and   hih_cocde = @cocde) or (@cocde = 'ALL' and hih_cocde in ('UCP','UCPP','PG')))
and poh_venno >= @vennofm and poh_venno <= @vennoto
group by hid_invno, hih_slnonb, hih_cus1no,cbi_cussna, hid_purord, poh_venno, vbi_vensna, poh_curcde, poh_shpstr, poh_shpend

/*
select 
tmp_invno as 'Invoice No', 
tmp_slnonb as 'Shipment Date',
tmp_cus1no as 'Pri Cust',
tmp_cussna as 'Cust Name',
tmp_purord as 'PO No',
tmp_venno as 'Vendor No',
tmp_vensna as 'Vendor Name',
tmp_USD as 'USD',
sum(tmp_usdamt) as 'USD Amount',
tmp_HKD as 'HKD',
sum(tmp_hkdamt) as 'HKD Amount'
from #TEMP_RESULT  (nolock)
group by tmp_invno,tmp_slnonb,tmp_cus1no,tmp_cussna,tmp_purord,tmp_venno,tmp_vensna,tmp_USD,tmp_HKD

drop table #TEMP_RESULT
*/
END

GO
GRANT EXECUTE ON [dbo].[sp_select_SMR00002] TO [ERPUSER] AS [dbo]
GO
