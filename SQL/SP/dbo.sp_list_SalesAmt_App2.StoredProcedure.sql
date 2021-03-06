/****** Object:  StoredProcedure [dbo].[sp_list_SalesAmt_App2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SalesAmt_App2]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SalesAmt_App2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       PROCEDURE [dbo].[sp_list_SalesAmt_App2] 
@c_div nvarchar(10),
@c_team	nvarchar(10),
@c_pricust nvarchar(10),
@c_datefrom		nvarchar(10),
@c_dateto	nvarchar(30)

as

select
--soh_saldiv,
soh_saltem as saltem,
--soh_cus1no
sum(soh_ttlamt) as salamt
from SCORDHDR (nolock)
where 
soh_ordsts = 'CLO' and
--soh_saltem <> '' and 
(@c_div = '' OR  (@c_div <> '' and soh_saldiv = @c_div)) and
(@c_team = '' OR (@c_team <> '' and soh_saltem = @c_team)) and
(@c_pricust = '' or (@c_pricust <> '' and soh_cus1no = @c_pricust)) and 
(@c_datefrom = '' or (@c_datefrom <> '' and soh_credat > @c_datefrom)) and 
(@c_dateto = '' or (@c_dateto <> '' and soh_credat < @c_dateto))
group by 
--soh_saldiv
soh_saltem
--soh_cus1no
order by 
--soh_saldiv
soh_saltem 
--soh_cus1no


GO
GRANT EXECUTE ON [dbo].[sp_list_SalesAmt_App2] TO [ERPUSER] AS [dbo]
GO
