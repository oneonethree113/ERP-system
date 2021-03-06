/****** Object:  StoredProcedure [dbo].[sp_list_SalesAmt_App3]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SalesAmt_App3]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SalesAmt_App3]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       PROCEDURE [dbo].[sp_list_SalesAmt_App3] 
@c_div nvarchar(10),
@c_team	nvarchar(10),
@c_pricust nvarchar(10),
@c_datefrom		nvarchar(10),
@c_dateto	nvarchar(30),
@c_option1 nvarchar(10)

as

Create table #TMP_RESULT(
	res_saldiv nvarchar(20),
	res_saltem nvarchar(10),
	res_cus1no nvarchar(6),
	res_cussna nvarchar(40),
	res_itmno nvarchar(30),
	res_venno nvarchar(250),
	res_ordqty int,
	res_shpqty int, 
	res_ttlamt numeric(13,4),
	res_shpamt numeric(13,4)
)

Create table #RESULT_1(
	res_saldiv nvarchar(20),
	res_saltem nvarchar(10),
	res_cus1no nvarchar(6),
	res_cussna nvarchar(40),
	res_itmno nvarchar(30),
	res_venno nvarchar(250),
	res_ordqty int, 
	res_shpqty int, 	
	res_ttlamt numeric(13,4),
	res_shpamt numeric(13,4)
) 

--PartI Raw Data
insert into #TMP_RESULT
select
	soh_saldiv,
	soh_saltem,
	soh_cus1no, 
	isnull(cbi_cussna,'') as 'cbi_cussna', 
	sod_itmno, 
	sod_venno +  ' - ' +  isnull(vbi_vensna,'') as 'sod_venno',  
	sum(sod_ordqty * isnull(ycf_value, 0)) as 'res_ordqty', 
	sum(sod_shpqty * isnull(ycf_value,0)) as 'res_shpqty', 
	sum(case soh_curexrat when 0 then 0 else round((sod_netuntprc/soh_curexrat)*sod_ordqty, 4) end) as 'res_ttlamt', 
	sum(case soh_curexrat when 0 then 0 else round((sod_netuntprc/soh_curexrat)*sod_shpqty , 4) end) as 'res_shpamt'
from SCORDHDR (nolock)
LEFT JOIN SCORDDTL(NOLOCK)  
	on soh_cocde = sod_cocde and soh_ordno = sod_ordno
LEFT JOIN IMBASINF(NOLOCK)  
	on sod_itmno = ibi_itmno
LEFT JOIN VNBASINF(NOLOCK)  
	on sod_venno  = vbi_venno
LEFT JOIN SYCONFTR(NOLOCK)  
	on sod_pckunt = ycf_code1
LEFT JOIN CUBASINF(NOLOCK)  
	on soh_cus1no = cbi_cusno
where 
--soh_ordsts = 'CLO' and
--soh_saltem <> '' and 
(
	(@c_option1 = 'all') OR 
	(@c_option1='os' and (sod_ordqty - sod_shpqty) > 0 and soh_ordsts <> 'CLO') OR
	(@c_option1='shp' and sod_shpqty > 0)
) and
(@c_div = '' OR  (@c_div <> '' and soh_saldiv = @c_div)) and
(@c_team = '' OR (@c_team <> '' and soh_saltem = @c_team)) and
(@c_pricust = '' or (@c_pricust <> '' and soh_cus1no = @c_pricust)) and 
(@c_datefrom = '' or (@c_datefrom <> '' and soh_issdat > @c_datefrom)) and 
(@c_dateto = '' or (@c_dateto <> '' and soh_issdat < @c_dateto))
group by 
	soh_saldiv,
	soh_saltem,
	soh_ordno , 
	soh_cus1no , 
	isnull(cbi_cussna,'') , 
	sod_itmno, 
	sod_venno +  ' - ' +  isnull(vbi_vensna,'')

	
	
--PartII Group Result
insert into #RESULT_1
(
	res_saldiv,
	res_saltem,
	res_cus1no, 
	res_cussna, 
	res_itmno,
	res_venno,
	res_ordqty,
	res_shpqty,
	res_ttlamt,
	res_shpamt
)
select
	res_saldiv,
	res_saltem,
	res_cus1no,
	res_cussna,
	res_itmno,
	res_venno,
	sum(res_ordqty),
	sum(res_shpqty),
	sum(res_ttlamt),
	sum(res_shpamt)
from
	#TMP_RESULT
group by
	res_saldiv,
	res_saltem,
	res_cus1no,
	res_cussna,
	res_itmno,
	res_venno
	
--Return result	
select
	res_saldiv,
	res_saltem,
	res_cus1no, 
	res_cussna, 
	res_itmno,
	res_venno, 
	res_ordqty,
	res_shpqty,
	cast(res_ttlamt as int) as res_ttlamt,
	cast(res_shpamt as int) as res_shpamt,
	case res_ordqty 
		when 0 then 0 
		else 100*res_shpqty/res_ordqty
	end as 'res_shpratio'
from
	#RESULT_1
order by
	res_saldiv,
	res_saltem,
	res_cus1no, 
	res_cussna, 
	res_itmno,
	res_venno
	

GO
GRANT EXECUTE ON [dbo].[sp_list_SalesAmt_App3] TO [ERPUSER] AS [dbo]
GO
