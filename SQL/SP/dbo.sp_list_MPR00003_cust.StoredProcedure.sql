/****** Object:  StoredProcedure [dbo].[sp_list_MPR00003_cust]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_MPR00003_cust]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_MPR00003_cust]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/*
=========================================================
Program ID	: sp_list_MPR00003_rpt
Description   	: 6/F Costing Depart -- ????
Programmer  	: Lester Wu
ALTER  Date   	:2005-08-24
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date			Author		Description
2005-10-08	Lester Wu		Cater "Group" filed with value
=========================================================     

*/

--sp_list_MPR00003_cust 'UCPP','GT0500001','GT0500004','MIS'
--sp_list_MPR00003_cust 'UCPP','GT0500001','GT0500001','mis'
--sp_list_MPR00003_cust 'UCPP','GT0800026','GT0800026','mis'
--sp_list_MPR00003_cust 'UCPP','GT0700286','GT0700286','mis'

CREATE  Procedure [dbo].[sp_list_MPR00003_cust]
@cocde	varchar(6),
@GRNFm	varchar(20),
@GRNTo	varchar(20),
@DP			int,
@HIDDEN	int,
@UserID	varchar(30)
as
BEGIN
/*
select * from GRNTRFHDR
select * from GRNTRFDTL
select * from GRNTRFLST
*/

Declare @CTY_LST varchar(100)
Declare @Grd_TTLNW numeric(11,4)
Declare @Grd_TTLGW numeric(11,4)
--Declare @DummyCty nvarchar(200)
Declare @TmpCty nvarchar(20)
--declare @TtlNo integer
declare @TtlNo numeric(9,0)

declare @strCurr varchar(10)

set @strCurr = 'HKD'
select top 1 @strCurr = isnull(grd_curr,'') from GRNTRFDTL where grd_grnno between @GRNFm and @GRNTo 

SET @CTY_LST = ''
------------------------------------------------------------------------------
-- List of Country



------------------------------------------------------------------------------

	create table #tmp_lh(
	_CustFty	nvarchar(50),
	_Bill_Chin	nvarchar(50),
	_Bill_Eng	nvarchar(50)
	)
	--select * from VNBASINF
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','??????','ELLIWELL CO., LTD.')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','??????','ELLIWELL CO., LTD.')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','??????????','UNITED CHINESE PLASTICS PRODUCTS CO., LTD.')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','????????','FORTUNE UNITED INTERNATIONAL LTD')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','????????','WISEMARK INTERNATIONAL LTD.')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','????????','VAST KING ENTERPRISES LTD.')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','????????','CHINA EQUITY ENTERPRISES LTD')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','????????','DRAGON RISE INDUSTRIAL LIMITED')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','??????????','UNION GLORY INT''L LTD.')
	insert into #tmp_lh (_CustFty,_Bill_Chin,_Bill_Eng) values
	('??','??????','NORTHSTATES LIMITED')


select 
	Grd_GrnNo as 'Grn_No',
	isnull(ymc_catdis,'??') as 'Cust_Type',
	Grd_UntPrc as 'Unt_Prc',
	' ' as 'Grd_Cty',
-- Lester Wu 2005-10-31
--	case upper(isnull(Grd_PckUM,'')) when 'YDS' then '?' else '??' end as 'UM' , 
--	sum(case upper(isnull(Grd_PckUM,'')) when 'YDS' then round(Grd_PckWgt * 0.9144,0) else 0 end) as 'ShpQty' , 
/*	case upper(isnull(Zil_CustUM,'')) 
		when '' then '??' 
		when 'YDS' then '?' 
		when 'KG' then '??' 
		else Zil_UM 
	end as 'UM' , 
	sum(
		case upper(isnull(Grd_PckUM,'')) 
			when '' then Grd_PckWgt 
			when 'YDS' then round(Grd_PckWgt * 0.9144,0) 
			when 'KG' then 0 
			else Grd_TtlShpQty
		end
	) as 'ShpQty' , 
*/
	case upper(grd_custum) 
		when 'M' then '米'
--		when 'M' then '?'
--		when 'KG' then '??'
		when 'KG' then '千克'
--		when '' then '??'
		when '' then ''
		else grd_custum
	end as 'UM' , 
	case isnull(Grd_Grp,'') when '' then sum(Grd_CustQty) else max(Grd_CustQty) end as 'ShpQty' , 
					
-- Lester Wu 2005-10-08
--	sum(Grd_TtlNW) as 'Ttl_NW',
--	sum(Grd_TtlGW) as 'Ttl_GW',
--	sum(Grd_TtlCtn) as 'Ttl_Ctn'
--	case isnull(Grd_Grp,'') when '' then  sum(Grd_TtlNW) else max(Grd_TtlNW) end 'Ttl_NW',
--	case isnull(Grd_Grp,'') when '' then  sum(Grd_TtlGW) else max(Grd_TtlGW) end  'Ttl_GW',
	case isnull(Grd_Grp,'') when '' then  sum(Grd_NW*Grd_TtlCtn) else max(Grd_NW*Grd_TtlCtn) end 'Ttl_NW',
	case isnull(Grd_Grp,'') when '' then  sum(Grd_GW*Grd_TtlCtn) else max(Grd_GW*Grd_TtlCtn) end  'Ttl_GW',
	case isnull(Grd_Grp,'') when '' then sum(Grd_TtlCtn) else max(Grd_TtlCtn) end as 'Ttl_Ctn' , 
	isnull(Grd_Grp,'') as '_grp' ,
	isnull(ymc_catdsc,'??') as 'CustDsc' , 
	min(grd_ctnfm) as 'CTNFM'
into
	#temp1_1
from 
	GRNTRFDTL
	LEFT JOIN SYMCATCDE (NOLOCK) on Grd_CustCat = ymc_catcde and ymc_type = '1'
-- Lester Wu 2005-10-31	
	LEFT JOIN ZSITMLST (NOLOCK) on Grd_ItmNo = Zil_ItmNo 
Where
	Grd_GrnNO between @GRNFm and @GrnTo and 
	Grd_Type <> 'Misc'
Group by 
	Grd_GrnNo ,
	isnull(ymc_catdis,'??') , 
	isnull(ymc_catdsc,'??') , 
	Grd_UntPrc ,
	--Grd_Cty,
-- Lester Wu 2005-10-31
--	case upper(isnull(Grd_PckUM,'')) when 'YDS' then '?' else '??' end , 
	/*case upper(isnull(Zil_CustUM,'')) 
			when '' then '??' 
			when 'YDS' then '?' 
			when 'KG' then '??' 
			else Zil_UM 
		end , */
	case upper(grd_custum) 

		when 'M' then '米'
--		when 'M' then '?'
--		when 'KG' then '??'
		when 'KG' then '千克'
--		when '' then '??'
		when '' then ''
		else grd_custum
	end ,
	isnull(Grd_Grp,'')

-- Lester Wu 2005-10-08
select 
	Grn_No , 
	Cust_Type , 
	Unt_Prc , 
	Grd_Cty , 
	UM , 
	sum(ShpQty) as 'ShpQty' , 
	sum(Ttl_NW) as 'Ttl_NW',
	sum(Ttl_GW) as 'Ttl_GW',
	sum(Ttl_Ctn) as 'Ttl_Ctn' ,
	Custdsc ,
	min(CTNFM) as 'CTNFM'
into
	#temp1
from 
	#temp1_1
Group by 
	Grn_No , 
	Cust_Type , 
	CustDsc,
	Unt_Prc , 
	Grd_Cty , 
	UM --, 
	--ShpQty


SET @Grd_TTLNW = 0
SET @GRd_TTLGW = 0
SET @TtlNo  = 0
SET @CTY_LST   = ''
SET @TmpCty = ''



SELECT 
	Grn_No as '_GrnNo',
	 SUM(TTL_NW) as '_TTLNW', 
	 SUM(TTL_GW) as '_TTLGW',
	SUM(Ttl_Ctn) as '_TtlNo'
INTO
	#temp2
FROM
	#temp1
Group by
	Grn_No


DECLARE Cty_cursor CURSOR FOR 
--SELECT  distinct Grd_Cty as 'Grd_Cty' from #temp1 group by Grd_Cty order by Grd_Cty
SELECT  distinct Grd_Cty as 'Grd_Cty' 
From
	GRNTRFDTL
Where
	Grd_GrnNO between @GRNFm and @GrnTo and 
	Grd_Type <> 'Misc'

OPEN Cty_cursor

FETCH NEXT FROM Cty_cursor 
INTO @TmpCty

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @CTY_LST  = @CTY_LST  + @TmpCty  + ', '
	FETCH NEXT FROM Cty_cursor 
	INTO @TmpCty
END
CLOSE Cty_cursor
DEALLOCATE Cty_cursor

if LEN(@CTY_LST) > 0 
begin
	SET @CTY_LST  =  SUBSTRING(@CTY_LST ,1,LEN(@CTY_LST)-1)
end 


--- Result ------

select 
	Grn_No as 'Grh_GrnNo',
	--isnull(_Bill_Chin,'') as '_Bill_Chin',
	--isnull(Grh_ShpPlc,'') as 'Grh_ShpPlc',
	isnull(inv.Gvi_VenNam,'') as '_Bill_Chin',
	isnull(dest.Gvi_VenNam,'') as 'Grh_ShpPlc' ,
	isnull(Grh_AgtNo,'') as 'Grh_ArgNo',
	isnull(Grh_TrdCty,'') as 'Grh_TrdCty',
	@CTY_LST as 'CtyLst',
--	@CTY_LST as 'Cty_Lst',
	Grd_Cty as 'Cty',
	Cust_Type as 'CustType',
	UM as 'UM',
	--case UM when '??' then Ttl_NW else ShpQty end as 'Ttl_NW',
	ShpQty  as 'TtlNW',
--	Ttl_GW,
	Unt_Prc  as 'UntPrc',
	--Unt_Prc * case UM when '??' then Ttl_NW else ShpQty end as 'Ttl_Amt', 
	round(Unt_Prc * ShpQty,@DP) as 'Ttl_Amt', 
	_TtlNo as 'Grd_TtlCtn' ,
	_TTLGW as 'Grd_TtlGW' ,
	_TTLNW as 'Grd_TtlNW' , 
	@strCurr as 'strCurr' , 
	CTNFM  as 'CTNFM',
	isnull(Grh_CusUM,'') as 'CUSTUM' , 
	isnull(Grh_InvUM,'') as 'INVUM' ,
	@DP as 'DP',
	@HIDDEN as 'HIDDEN'
from 
	#temp1 
	Left Join #temp2 on Grn_No = _GrnNo
	Left Join GRNTRFHDR on Grn_No = Grh_GrnNo
	LEFT JOIN GRNVENINF cust (NOLOCK)  on Grh_ImpFty = cust.Gvi_VenSna and cust.Gvi_Type = 'CUST'
	LEFT JOIN GRNVENINF inv (NOLOCK)  on cust.Gvi_InvVen = inv.Gvi_VenSna and inv.Gvi_Type = 'INV'
	LEFT JOIN GRNVENINF dest (NOLOCK)  on Grh_ShpPlc = dest.Gvi_VenSna and dest.Gvi_Type = 'CUST'
	--LEFT JOIN #tmp_lh on Grh_ImpFty = _CustFty
order by
	Grn_No,len(CTNFM), CTNFM, Cust_Type,CustDsc, Unt_Prc

drop table #temp2
drop table #temp1
--drop table #tmp_lh

END












GO
GRANT EXECUTE ON [dbo].[sp_list_MPR00003_cust] TO [ERPUSER] AS [dbo]
GO
