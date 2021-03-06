/****** Object:  StoredProcedure [dbo].[sp_list_IMR00032A]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMR00032A]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMR00032A]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modification History
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modify on	-- Modify by	-- Modification
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
--sp_list_IMR00032A '', '', '01/01/2011','03/31/2011','Y', 'mis'
CREATE         PROCEDURE [dbo].[sp_list_IMR00032A]
@cocde nvarchar(6),
@customer nvarchar(10),
@etdfm	datetime,
@etdto	datetime,
@printamt char(1),
@usrid nvarchar(30)
AS


set @etdto = dateadd(DD,1,@etdto)



select 
distinct
soh_cocde as 'Company Code',
pod_purord as 'PO No', 
isnull(pod_jobord,'') as 'Job No',
isnull(c1.cbi_cusno, '') as 'Pri Cust No',
isnull(c1.cbi_cussna, '') as 'Pri Cust Name',
isnull(c2.cbi_cusno, '') as 'Sec Cust No',
isnull(c2.cbi_cussna, '') as 'Sec Cust Name',
soh_cuspo as 'Cust PO No',
sod_cusitm as 'Cust Item No',
sod_venitm as 'Vendor Item No',
sod_itmdsc as 'Item Desc',
sod_ordqty as 'Order Qty',
sod_pckunt as 'UM',
sod_ordqty - sod_shpqty as 'O/S Qty',
hid_shpqty as 'Shipped Qty',
sod_shpqty as 'Total Shipped Qty',
sod_cususd as 'Customer Retail (USD)',
isnull(convert(varchar(20),pod_shpstr,111),'') as 'Ship Date (Fty)',
isnull(convert(varchar(20),sod_shpstr,111),'') as 'Ship Date (SC)',
isnull(convert(varchar(20),sod_shpend,111),'') as 'Ship End Date (SC)',
convert(char(4),year(sod_shpend)) + '-' + right('0' +ltrim(rtrim(str(month(sod_shpend)))),2) as 'Ship End (YYYY-MM)',

case sod_candat when '1900/01/01' then '' else isnull(convert(varchar(20),sod_candat,111),'') end as 'SC Cancel Date',
isnull(convert(nvarchar(10),hih_slnonb,111),'') as 'ETD Date', 
case sod_candat when '1900/01/01' then 
isnull(convert(int, hih_slnonb - 5 - sod_shpend),999999) 
else
isnull(convert(int, hih_slnonb - 5 - sod_candat),999999) 
end as 'Days of delay',
--'    ' as 'Penalty percentage',
--convert(numeric(13,4),0) as 'Penalty Amount',
isnull(cv.vbi_venno + ' - ' + cv.vbi_vensna, '') as 'CV',
isnull(dv.vbi_venno + ' - ' + dv.vbi_vensna, '') as 'DV',
isnull(pv.vbi_venno + ' - ' + pv.vbi_vensna, '') as 'PV',
hid_shpno as 'Ship No',
hid_shpseq as 'Ship Seq',
--case @printamt when 'Y' then sod_curcde else '' end as 'Currency',
--case @printamt when 'Y' then sod_untprc else 0 end as 'Unit Price',

sod_curcde as 'Currency',
sod_untprc as 'Unit Price',

case @printamt when 'Y' then 
case dv.vbi_ventyp
when 'E' then sod_fcurcde else sod_dvfcurcde end
else '' end as 'Fty Currency',
case @printamt when 'Y' then 
case dv.vbi_ventyp
when 'E' then sod_ftyprc else sod_dvftyprc end
else 0 end as 'Factory Price'
into #TEMP_RESULT
from SCORDHDR (nolock) 
left join SCORDDTL (nolock) on soh_cocde = sod_cocde and soh_ordno = sod_ordno
left join POORDDTL (nolock) on sod_cocde = pod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
left join SHIPGDTL (nolock) on sod_cocde = hid_cocde and sod_ordno = hid_ordno and sod_ordseq = hid_ordseq
left join SHIPGHDR (nolock) on hid_cocde = hih_cocde and hid_shpno = hih_shpno
left join CUBASINF c1 (nolock) on soh_cus1no = c1.cbi_cusno
left join CUBASINF c2 (nolock) on soh_cus2no = c2.cbi_cusno
left join VNBASINF cv (nolock) on sod_cusven = cv.vbi_venno
left join VNBASINF dv (nolock) on sod_dv = dv.vbi_venno
left join VNBASINF pv (nolock) on sod_venno = pv.vbi_venno
where --soh_cus1no = '50068'
--and 
sod_ordqty > 0
--and  sod_ordqty - sod_shpqty > 0
--and hih_slnonb >= @etdfm and hih_slnonb <= @etdto
--and sod_shpstr >= @etdfm and sod_shpstr <= @etdto
and sod_shpend >= @etdfm and sod_shpend <= @etdto

/*
update #TEMP_RESULT set [Penalty percentage] = '1%',[Penalty Amount] = convert(numeric(13,4),[Shipped Qty] * [Customer Retail (USD)] * 1 / 100) where [Days of delay] between 1 and 7
update #TEMP_RESULT set [Penalty percentage] = '2%',[Penalty Amount] = convert(numeric(13,4),[Shipped Qty] * [Customer Retail (USD)] * 2 / 100) where [Days of delay] between 8 and 14
update #TEMP_RESULT set [Penalty percentage] = '5%',[Penalty Amount] = convert(numeric(13,4),[Shipped Qty] * [Customer Retail (USD)] * 5 / 100) where [Days of delay] between 15 and 21
update #TEMP_RESULT set [Penalty percentage] = '10%',[Penalty Amount] = convert(numeric(13,4),[Shipped Qty] * [Customer Retail (USD)] * 10 / 100) where [Days of delay] >= 22
*/

--select * from #TEMP_RESULT where [Days of delay] > 0 order by [CV], [ETD Date]
select * from #TEMP_RESULT order by [Pri Cust No], [Sec Cust No], [Ship End (YYYY-MM)], [ETD Date]

drop table #TEMP_RESULT




GO
GRANT EXECUTE ON [dbo].[sp_list_IMR00032A] TO [ERPUSER] AS [dbo]
GO
