/****** Object:  StoredProcedure [dbo].[sp_select_MSR00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
















--sp_select_MSR00001 'PG','','','','','','','','','50154','50154','','','','','','','','07/16/2004 00:00:00.000','07/21/2004 23:59:59.000','','','','','Y','C','_'






--sp_select_MSR00001 'UCPP','','','','','','','','','','','60355','60355','','','','','11/15/2003 00:00:00.000','12/15/2003 23:59:59.000','','','','','Y','C'
--sp_select_MSR00001 'UCPP','','','','','','','','','','','','','','','','','','11/15/2003 00:00:00.000','12/15/2003 23:59:59.000','','','','','Y','C','_'
--sp_select_MSR00001 'UCPP','','','','','','','','','','','','','','','','','','11/15/2003 00:00:00.000','12/15/2003 23:59:59.000','','','','','N','S','_'

-- Checked by Allan Yuen at 27/07/2003
/*
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modification History
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modify on	-- Modify by	-- Modification
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
2004/02/11		Lester Wu		Add Secondary Customer Selection and "ALL" company selection
				Add Sales Team Selection
	
2004/03/08		Lester Wu		Add access control on sales team
				Users can obtain the requested data if ;
				1)users are of the same team of the customer's sales representative / 
				2)users without a sales team / 
				3)users belongs to sales team 'S' 

2004/03/15		Lester Wu		Add Partial Cust. PO # selection 

2004/06/23		Lester Wu		Show O/S CBM 

2004/07/23		Lester Wu		adjust the character length of  opt6Fm , opt6To , opt7Fm and opt7To

2005-03-21	Lester Wu		Replace "ALL" with "UC-G"
				Cater "MS - Magic Silk" company
				Retrieve Company name from databse

2005-06-02	Lester Wu		Apply new ship date range selection logic
				i.e records with either ship start date or ship end date within the input ship range will be show

---------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/

CREATE         PROCEDURE [dbo].[sp_select_MSR00001]

	@cocde	nvarchar(6),
-- Product line
	@opt1Fm	nvarchar(10),		@opt1To	nvarchar(10),
-- Sub Code
	@opt2Fm	nvarchar(4),		@opt2To	nvarchar(4),	
-- Sales Team
	@STFm	nvarchar(1),		@STTo	nvarchar(1),
-- Vendor Code
	@opt3Fm	nvarchar(4),		@opt3To	nvarchar(4),	
-- Customer No.
	@opt4Fm	nvarchar(6),		@opt4To	nvarchar(6),	
--Secondary Customer No.
	@secCNF	nvarchar(6),		@secCNT	nvarchar(6),
-- CPO
	@opt12Fm	nvarchar(20),		@opt12To	nvarchar(20),
-- Lester Wu 2004/03/15
	@optCPO nvarchar(4),
-----------------------------
--sp_select_MSR00001 'ALL','','','','','','','','','','','','','','','221','','','','','','','','','N','C',''

-- SC #
	@opt5Fm	nvarchar(20),		@opt5To	nvarchar(20),	
-- SC Issued Date
--Lester Wu 2004/07/23
--adjust the character length
--	@opt6Fm	nvarchar(10),		@opt6To nvarchar(10),
	@opt6Fm	nvarchar(30),		@opt6To nvarchar(30),
-----------------------------------------------------------------
-- Ship Start Date
--Lester Wu 2004/07/23
--adjust the character length
--	@opt7Fm	nvarchar(10),		@opt7To	nvarchar(10),	
	@opt7Fm	nvarchar(30),		@opt7To	nvarchar(30),	
------------------------------------------------------------------
-- Job Order
	--@opt8Fm	nvarchar(20),	--@opt8To	nvarchar(20),	
-- Item #
	@opt9Fm	nvarchar(20),		@opt9To	nvarchar(20),
-- Optional Radio Buttom
	@opt10	nvarchar(1),
-- Sorting By
	@opt11	nvarchar(1)
-- Frankie Cheung 20120316
	,@creusr nvarchar(30)

--Lester Wu 2004/03/08		
	,@SalTem nvarchar(7)

AS

---------------------------------------------------------------------------------------------------------------------------------------------
DECLARE
@opt1	nvarchar(1),	
@opt2	nvarchar(1),	
-- 2004/02/16
@optST	nvarchar(1),
--------------------------------
@opt3	nvarchar(1),	
@opt4	nvarchar(1),	
-- 2004/02/11 Lester Wu
@SecCustOpt	nvarchar(1),
--------------------------------
@opt5	nvarchar(1),	
@opt6	nvarchar(1),	
@opt7	nvarchar(1),	
@opt8	nvarchar(1),	
@opt9	nvarchar(1),
@opt12 nvarchar(1)



--Lester Wu 2004/03/15 
declare	@optP_PO nvarchar(6)
	set @optP_PO = ltrim(rtrim(@optCPO))
-------------------------------------------

-- Lester Wu 2004/03/08
SET @SalTem = replace(@SalTem,'_','')
--------------

set @opt1 = 'N'
	If @opt1Fm = '' and @opt1To = ''
	begin
		set @opt1 = 'Y'
	end

set @opt2 = 'N'
	If @opt2Fm = '' and @opt2To = ''
	begin
		set @opt2 = 'Y'
	end

-- 2004/02/16 Lester Wu
set @optST = 'N'
	If @STFm = '' and @STTo = ''
	begin
	  	set @optST = 'Y'
	end
----------------------------------------------------------

set @opt3 = 'N'
	If @opt3Fm = '' and @opt3To = ''
	begin
		set @opt3 = 'Y'
	end

set @opt4 = 'N'
	If @opt4Fm = '' and @opt4To = ''
	begin
	  	set @opt4 = 'Y'
	end
-- 2004/02/11 Lester Wu
set @SecCustOpt = 'N'
	If @secCNF = '' and @secCNT = ''
	begin
	  	set @SecCustOpt = 'Y'
	end
---------------------------------------------------------

set @opt5 = 'N'
	If @opt5Fm = '' and @opt5To = ''
	begin
		set @opt5 = 'Y'
	end

set @opt6 = 'N'
--	If @opt6Fm = '__/__/____' and @opt6To = '__/__/____'
	If @opt6Fm = '' and @opt6To = ''
	begin
		set @opt6Fm = ''
		set @opt6To = ''
	 	set @opt6 = 'Y'
	end

set @opt7 = 'N'
--	If @opt7Fm = '__/__/____' and @opt7To = '__/__/____'
	If @opt7Fm = '' and @opt7To = ''
	begin
		set @opt7Fm = ''
		set @opt7To = ''
		set @opt7 = 'Y'
	end

set @opt9 = 'N'
	If @opt9Fm = '' and @opt9To = ''
	begin
		set @opt9 = 'Y'
	end

set @opt12 = 'N'
	If @opt12Fm = '' and @opt12To = ''
	begin
		set @opt12 = 'Y'
	end
-- Lester Wu 2004/03/15
	if @opt12To <>'' and @optP_PO<>'' 
	begin
		set @opt12To = ltrim(@opt12To) + ltrim(@optP_PO)
	end

	if @optP_PO<>'' 
	begin
		set @optP_PO = '%' + ltrim(rtrim(@optP_PO)) + '%'
	end
-----------------------------
---------------------------------------------------------------------------------------------------------------------------------------------
--select @optP_PO,@opt12Fm,@opt12To,@opt12

--Lester Wu 2005-03-21 Retrieve Company information from database
declare @compName as varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde <> 'UC-G' 
begin
	select @compName = yco_conam from SYCOMINF where yco_cocde = @cocde
end 

SELECT	


	-- Parameter
	@cocde as 'cocde',
	@opt1Fm as 'opt1Fm',		@opt1To as 'opt1To',
	@opt2Fm as 'opt2Fm',		@opt2To as 'opt2To',
-- 2004/02/16 Lester Wu
	@STFm as 'STFm',		@STTo as 'STTo',
------------------------------	
	@opt3Fm as 'opt3Fm',		@opt3To as 'opt3To',
	@opt4Fm as 'opt4Fm',		@opt4To as 'opt4To',
-- 2004/02/11 Lester Wu
	@secCNF as 'secCNF',	@secCNT as 'secCNT',
------------------------------
	@opt5Fm as 'opt5Fm',		@opt5To as 'opt5To',
-- Lester Wu 2004/07/23
-- return issue date in the format of MM/DD/YYYY
--	@opt6Fm as 'opt6Fm',		@opt6To as 'opt6To',
	convert(nvarchar(10),@opt6Fm,101) as 'opt6Fm',
	convert(nvarchar(10),@opt6To,101) as 'opt6To',
--------------------------------------------------------------
-- Lester Wu 2004/07/23
-- return ship date in the format of MM/DD/YYYY
--	@opt7Fm  as 'opt7Fm',		@opt7To as 'opt7To',
	convert(nvarchar(10),@opt7Fm,101)  as 'opt7Fm',
	convert(nvarchar(10),@opt7To,101)  as 'opt7To',
---------------------------------------------------------------
	@opt9Fm as 'opt9Fm',		@opt9To as 'opt9To',
	@opt10 as 'opt10',		@opt11 as 'opt11',
	@opt12Fm as 'opt12Fm',		@opt12To as 'opt12To',

	-- CUBASINF
	pri.cbi_cusno as 'pricbi_cusno', 	pri.cbi_cussna as 'pricbi_cussna',

	--CUBASINF sec  (2004/02/11 Lester Wu)
	isnull(sec.cbi_cusno,'') as secCustNo, isnull(sec.cbi_cussna,'') as secCustName,
	-- SCORDHDR
	soh_curcde,

	-- SCORDDTL

	sod_ordno,
	sod_cuspo = Case IsNull(sod_cuspo,'') when '' then soh_cuspo else sod_cuspo end,
	sod_cusitm,
	
	-- POORDDTL
	isnull(pod_venitm,'') as 'pod_venitm',

	-- SCORDDTL
	sod_itmno,		sod_itmdsc,

	-- POORDDTL
	isnull(pod_jobord,'') as 'pod_jobord',

	-- SCORDDTL
	outstandQty = sod_ordqty - sod_shpqty,
	sod_pckunt,
	outstandCtn = sod_ttlctn * (sod_ordqty - sod_shpqty) / sod_ordqty,
	sod_untprc,
	sod_untprcStr =  ltrim(str(sod_untprc,10,4)),	
	outstandAmt = sod_selprc * (sod_ordqty - sod_shpqty) / sod_ordqty,
	outstandAmtStr = ltrim(str(sod_selprc * (sod_ordqty - sod_shpqty) / sod_ordqty,10,4)) ,		
	sod_shpstr,
	sod_shpend,
 	sod_subcde,	
	
	-- SYSETINF
	isnull(ysi_dsc,'') as 'ysi_dsc',

	-- VNBASINF
 	isnull(vbi_vensna, '') as 'vbi_vensan',
	-- 2003/12/18  by Lester Wu, Add "sod_Venno"
	sod_venno
	--
	--,isnull(ysr_saltem,'') as 'ysr_saltem'
	--,pri.cbi_salrep as 'pricbi_salrep'
	--,sal.ysr_code1 as 'salysr_code1'
	--2004/06/23 Lester Wu
	,sod_balcbm = round( round((sod_cft / 35.3356),4) * (sod_ordqty - sod_shpqty ) / sod_mtrctn,4)
	----------------------------------------------------------------------------------------------------
	--Lester Wu 2005-03-21 Retrieve company information form database
	,@compName as 'compName'
	--Frankie Cheung 20090824 - Add Cancel Date
	,case when sod_candat <> cast('1900-01-01 00:00:00.000' as datetime) then  CONVERT(char(10),sod_candat,101)  else ''  end as 'sod_candat'
	,case sod_resppo when '' then soh_resppo else sod_resppo end as 'soh_resppo'
	
FROM	SCORDHDR
left join SCORDDTL on sod_cocde = soh_cocde and sod_ordno = soh_ordno
left join POORDDTL on pod_cocde = sod_cocde and pod_purord = sod_purord and pod_purseq = sod_purseq
left join IMBASINF on ibi_itmno = sod_itmno
left join SYSETINF on ysi_cde = sod_pckunt and ysi_typ = '05'
left join VNBASINF on vbi_venno = sod_venno
left join CUBASINF pri on pri.cbi_cusno = soh_cus1no
left join CUBASINF sec on sec.cbi_cusno = soh_cus2no

Where	
((@cocde<>'UC-G' and  soh_cocde = @cocde)  or (@cocde = 'UC-G' and soh_cocde<>'MS'))
AND	(sod_ordqty - sod_shpqty) > 0
and 	soh_ordsts <> 'CLO'
AND	(@SalTem='' or @SalTem='S' or pri.cbi_saltem = @SalTem 
	or pri.cbi_saltem in (select distinct yur_para from syusrright where yur_usrid = @creusr and yur_doctyp = 'SC' and yur_lvl = 1) )
AND	((@opt1 = 'N' and ibi_lnecde >= @opt1Fm and ibi_lnecde <= @opt1To) or @opt1 = 'Y')
AND	((@opt2 = 'N' and sod_subcde >= @opt2Fm and sod_subcde <= @opt2To) or @opt2 = 'Y')
-- 2004/02/16 Lester Wu
--AND	((@optST = 'N' and  isnull(sal.ysr_saltem,'')>= @STFm and  isnull(sal.ysr_saltem,'')<= @STTo) or @optST = 'Y')
AND	((@optST = 'N' and  isnull(pri.cbi_saltem,'')>= @STFm and  isnull(pri.cbi_saltem,'')<= @STTo) or @optST = 'Y')
------------------------------
AND	((@opt3 = 'N' and sod_venno >= @opt3Fm and sod_venno <= @opt3To) or @opt3 = 'Y')
AND	((@opt4 = 'N' and soh_cus1no >= @opt4Fm and soh_cus1no <= @opt4To) or @opt4 = 'Y')
-- 2004/02/11 Lester Wu
AND	((@SecCustOpt = 'N' and isnull(soh_cus2no,'') >= @secCNF and isnull(soh_cus2no,'') <= @secCNT) or @SecCustOpt = 'Y')
------------------------------
--AND	((@opt5 = 'N' and sod_cocde = @cocde and sod_ordno >= @opt5Fm and sod_ordno <= @opt5To) or @opt5 = 'Y')
AND	((@opt5 = 'N' and sod_ordno >= @opt5Fm and sod_ordno <= @opt5To) or @opt5 = 'Y')

AND	((@opt6 = 'N' and soh_issdat >= @opt6Fm and soh_issdat <= @opt6To) or @opt6 = 'Y')

--Lester Wu 2005-06-02, apply new ship start date selection logic
--AND	((@opt7 = 'N' and sod_shpstr >= @opt7Fm and sod_shpend <= @opt7To) or @opt7 = 'Y')
AND	((@opt7 = 'N' and (	sod_shpstr between @opt7Fm and @opt7To 
			or 
			sod_shpend between @opt7Fm and @opt7To
			or
			(sod_shpstr <= @opt7Fm and sod_shpend >= @opt7To)) 
	)or @opt7 = 'Y')

--AND	((@opt7 = 'N' and sod_shpstr >= @opt7Fm) or @opt7 = 'Y')
AND	((@opt9 = 'N' and sod_itmno >= @opt9Fm and sod_itmno <= @opt9To) or @opt9 = 'Y')
AND	((@opt12 = 'N' and ((soh_cuspo between @opt12Fm and @opt12To) or (sod_cuspo between @opt12Fm and @opt12To)) ) or @opt12 = 'Y')
AND	(@optP_PO='' or (@optP_PO<>'' and (soh_cuspo like @optP_PO or sod_cuspo like @optP_PO)))
--Kenny Remark it on 18-10-2002
/*
ORDER BY	
	case @opt11 when 'C' then (Case IsNull(sod_cuspo,'') when '' then soh_cuspo else sod_cuspo end) else cast(sod_shpstr as nvarchar(10)) end
	,sod_ordno, sod_cusitm, pod_venitm, sod_itmno
*/


-- 2004/02/11 Lester Wu

order by	pri.cbi_cusno, isnull(sec.cbi_cusno,''),
	case @opt11 
		when 'C' then Case IsNull(sod_cuspo,'') when '' then soh_cuspo else sod_cuspo end
		when 'S' then isnull(convert(char(10),sod_shpstr,111),'')
		else '' end,

	case @opt11
		when 'C' then sod_itmno
		when 'S' then Case IsNull(sod_cuspo,'') when '' then soh_cuspo else sod_cuspo end
		else '' end,
	case @opt11 
		when 'C' then isnull(convert(char(10),sod_shpstr,111),'')
		when 'S' then sod_itmno
		else '' end


GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00001] TO [ERPUSER] AS [dbo]
GO
