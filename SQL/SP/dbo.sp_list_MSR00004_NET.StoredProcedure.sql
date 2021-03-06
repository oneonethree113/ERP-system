/****** Object:  StoredProcedure [dbo].[sp_list_MSR00004_NET]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_MSR00004_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_MSR00004_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO







-- Checked by Allan Yuen at 27/07/2003
/*
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Modification History
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modified on	-- Modified by	--Description
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Feb 11 , 2004	Lester Wu		ADD "ALL" COMPANY SELECTION and SECONDARY CUSTOMER SELECTION
2004/03/08		Lester Wu		Add access control on sales team
				Users can obtain the requested data if ;
				1)users are of the same team of the customer's sales representative / 
				2)users without a sales team / 
				3)users belongs to sales team 'S' 

Mar 15, 2004	Lester Wu		Add Sort Option and Change Sort Sequence

Jun 23, 2004	Lester Wu		Show O/S CBM instead of Cuft

2005-03-21	Lester Wu		Replace "ALL" with "UC-G"
				Cater "MS - Magic Silk" company
				Retrieve Company name from databse
2005-06-02	Lester Wu		Apply new logic for ship date ranage selection
2005-06-20	Lester Wu		Show Production Vendor instead of Custom Vendor
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
CREATE    PROCEDURE [dbo].[sp_list_MSR00004_NET]

-- OS Job By PO

--DECLARE
@cocde		nvarchar(6),
@opt1Fm		nvarchar(10),	-- Vendor
@opt1To		nvarchar(10),
@opt2Fm		nvarchar(30),	-- Sub  Code
@opt2To		nvarchar(30),
@opt3Fm		nvarchar(20),	-- PO No.
@opt3To		nvarchar(20),
@opt4Fm		nvarchar(30),	-- Primary Customer Code
@opt4To		nvarchar(30),
-- 2004/02/11 Lester Wu --------------------------------------------------------------
@secCNF		nvarchar(30),	-- Secondary Customer Code
@secCNT		nvarchar(30),
---------------------------------------------------------------------------------------------
@opt5Fm		nvarchar(30),	-- Customer PO #
@opt5To		nvarchar(30),
@opt9Fm		nvarchar(30),	-- SC No
@opt9To		nvarchar(30),
@optAFm		nvarchar(30),	-- Sales Team
@optATo		nvarchar(30),
@opt6Fm		nvarchar(30),	-- Item No.
@opt6To		nvarchar(30),
@opt7Fm		nvarchar(30),	-- Ship Start Date
@opt7To		nvarchar(30),
@optPrintPO	nvarchar(1),
@optPrintFPrc	nvarchar(1),
@SortBy	nvarchar(1),
@creusr 		nvarchar(30)
,@SalTem		nvarchar(7)

AS


/*
set @opt1Fm = '' 
set @opt2Fm = ''
set @opt2To = ''
set @opt3Fm = ''
set @opt3To = ''
set @opt4Fm = ''
set @opt4To = ''
set @opt5Fm = ''
set @opt5To  = ''
set @opt6Fm = '2001-01-01'
set @opt6To = '2002-04-01'
*/

DECLARE
@opt1	nvarchar(1),
@opt2	nvarchar(1),
@opt3	nvarchar(1),
@opt4	nvarchar(1),
@opt5	nvarchar(1),
@opt6	nvarchar(1),
@opt7	nvarchar(1),
@opt8	nvarchar(1),
@opt9	nvarchar(1),
@optA	nvarchar(1)
-- 2004/02/11 Lester Wu ------------
,@secCustOpt	nvarchar(1)

SET @secCustOpt = 'N'
If @secCNF <>'' and @secCNT <>''
begin
	SET @secCustOpt = 'Y'
end
-------------------------------------------

SET @opt1 = 'N'
If @opt1Fm <> '' and @opt1To <> ''
begin
	SET @opt1 = 'Y'
end

SET @opt2 = 'N'
If @opt2Fm <> '' and @opt2To <> ''
begin
	SET @opt2 = 'Y'
end

SET @opt3 = 'N'
If @opt3Fm <> '' and @opt3To <> ''
begin
	SET @opt3 = 'Y'
end

SET @opt4 = 'N'
If @opt4Fm <> '' and @opt4To <> ''
begin
	SET @opt4 = 'Y'
end

SET @opt5 = 'N'
IF @opt5Fm <> '' and @opt5To <> ''
begin
	SET @opt5= 'Y'
end

SET @opt6 = 'N'
If @opt6Fm <> '' and @opt6To <> ''
begin
	SET @opt6 = 'Y'
end

SET @opt7 = 'N'
If @opt7Fm <> '' and @opt7To <> ''
begin
	SET @opt7 = 'Y'
end

if @opt7Fm = '' and @opt7to <> '' 
begin
    set @opt7Fm = '01/01/1900'
    SET @opt7 = 'Y'
end

if @opt7Fm <> '' and @opt7to = '' 
begin
    set @opt7to = '01/01/2099'
    SET @opt7 = 'Y'
end

SET @opt9 = 'N'
If @opt9Fm <> '' and @opt9To <> ''
begin
	SET @opt9 = 'Y'
end

SET @optA = 'N'
If @optAFm <> '' and @optATo <> ''
begin
	SET @optA = 'Y'
end

-- Lester Wu 2004/03/08
SET @SalTem = replace(@SalTem,'_','')
--------------


--Lester Wu 2005-03-21 Retrieve Company information from database
declare @compName as varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde <> 'UC-G' 
begin
	select @compName = yco_conam from SYCOMINF where yco_cocde = @cocde
end 


SELECT	
	--2004/02/11 Lester Wu
	--poh_cocde,
	@cocde as 'poh_cocde',
	-----------------------------
	pod_purord as 'pod_purord', 
	pod_purseq as 'pod_purseq',
	--poh_venno + ' - ' + vbi_vensna,

--	poh_venno + ' - ' + isnull(vbi_vensna,'') + --' (' + sod_subcde + ')' as 'poh_venno'
--	(case sod_subcde when '' then '' else ' -' + sod_subcde  end) as 'poh_venno',
	pod_prdven + ' - ' + isnull(vbi_vensna,'') + (case sod_subcde when '' then '' else ' -' + sod_subcde  end) as 'poh_venno',

	pod_venitm,
	pod_itmno,
	left(pod_engdsc,20) as 'pod_engdsc',
	poh_purord,
	isnull(pod_jobord,'') as 'pod_jobord',
	--pod_cuspno,
	(case len(ltrim(pod_cuspno)) when 0 then poh_cuspno else pod_cuspno end) as 'pod_cuspno',
	--soh_cus1no + ' - ' + cbi_cussna,
	 pri.cbi_cussna as 'soh_cus1no',
	-- 2004/02/11 Lester Wu
	isnull(sec.cbi_cussna,'') as 'secCustSNa',
	------------------------------
	pod_cusitm,
	pod_vencol,
--Kenny Add on 18-10-2002
	convert(varchar,pod_shpstr,101) as 'pod_shpstr',
	convert(varchar,pod_shpend,101) as 'pod_shpend',
	pod_ftyprc,
	poh_curcde  as 'pod_curcde' ,
	pod_ordqty,
	isnull(ysi_dsc,'') as 'pod_untcde',
	--pod_untcde,
	'pod_balqty '   = pod_ordqty - pod_recqty  ,
/*
--	pod_balamt = (case  poh_curcde when 'HKD' then isnull(ysi_buyrat,0) else 1 end) * pod_ftyprc * (pod_ordqty - pod_recqty),
*/
	'pod_balamt ' = pod_ftyprc * (pod_ordqty - pod_recqty),
	'pod_balctn '   = (pod_ordqty - pod_recqty ) / pod_mtrctn,
	--2004/06/23 Lester Wu
	--pod_balcft = round( pod_cubcft * (pod_ordqty - pod_recqty ) / pod_mtrctn,2),
	'pod_balcbm '  = round( round((pod_cubcft / 35.3356),4) * (pod_ordqty - pod_recqty ) / pod_mtrctn,4),
	----------------------------------------------------------------------------------------------------
	pod_cubcft ,
	@opt1Fm as 'opt1Fm-Vendor',		@opt1To as 'opt1To-Vendor',
	@opt2Fm as 'opt2Fm-SubCode',		@opt2To as 'opt2To-SubCode',
	@opt3Fm as 'opt3Fm-PoNo',
	@opt3To as 'opt3To-PoNo',
	@opt4Fm as 'opt4Fm-CustNo',			@opt4To as 'opt4To-CustNo',
-- 2004/02/11 Lester Wu
	@secCNF as 'secCNF',	@secCNT as 'secCNT',	--Secondary Customer
-----------------------------
	@opt5Fm as 'opt5Fm-CustPo',		@opt5To as 'opt5To-CustPo',
	@opt6Fm as 'opt6Fm-ItemNo',		@opt6To as 'opt6To-ItemNo',
	@opt7Fm as 'opt7Fm-ShipDate',
	@opt7To as 'opt7To-ShipDate',		@optPrintPO as 'opt8-ShowPO',
	@optPrintFPrc as 'opt9ShowPrice',
--- Added By Solo So
	@SortBy as 'SortBy',
	SortKey = Case @SortBy when 'C' then (case len(ltrim(pod_cuspno)) when 0 then poh_cuspno else pod_cuspno end) 
	when 'V' then pod_venitm else pod_itmno end,

	@opt9Fm as 'opt9Fm-SCNo',		@opt9To as 'opt9To-SCNo',
	@optAFm as 'optAFm-STFm',	@optATo as 'optATo-STTo'

--/*	poh_purord,	pod_jobord,	pod_cusitm,
--	pod_venitm,	left(pod_engdsc,20),	sod_subcde,
--	pod_ordqty,	ysi_dsc as 'pod_untcde',	
--	pod_itmno,	sod_colcde,	--left(sod_colcde,10),
--	pod_balqty = pod_ordqty - pod_recqty,
--	pod_balctn = pod_ttlctn * (pod_ordqty - pod_recqty) / pod_ordqty,
--	pod_shpstr,	pod_shpend,
--	ltrim(str(pod_ordqty))+' '+pod_untcde as 'qty',
--	poh_venno + ' - ' + isnull(vbi_vensna,'') + --' (' + sod_subcde + ')' as 'poh_venno'
--	(case sod_subcde when '' then '' else ' (' + sod_subcde + ')' end) as 'poh_venno',
--	(case len(ltrim(pod_cuspno)) when 0 then left(poh_cuspno,18) else left(pod_cuspno,18) end) as 'pod_cuspno',
--	left(cbi_cussna,10)
--*/

	, @compName as 'compName'

FROM	POORDHDR
left join POORDDTL on poh_cocde = pod_cocde and poh_purord = pod_purord
left join SCORDDTL on pod_cocde = sod_cocde AND pod_scno = sod_ordno and pod_scline= sod_ordseq
left join VNBASINF on pod_prdven = vbi_venno
left join SYSETINF on ysi_typ = '05' and ysi_cde = pod_untcde
left join CUBASINF pri on pri.cbi_cusno = poh_prmcus
left join CUBASINF sec on poh_seccus = sec.cbi_cusno
left join SYSALREP on ysr_code1 = pri.cbi_salrep
WHERE	
((@cocde<>'UC-G' and  poh_cocde = @cocde)  or (@cocde = 'UC-G' and poh_cocde<>'MS'))
AND 	pod_ordqty > 0 AND pod_ordqty - pod_recqty > 0

AND	((@opt1 = 'Y' and pod_prdven >= @opt1Fm and pod_prdven <= @opt1To) or @opt1 = 'N')
AND	((@opt2 = 'Y' and sod_subcde >= @opt2Fm and sod_subcde <= @opt2To) or @opt2 = 'N')
AND	((@opt3 = 'Y' and pod_purord >= @opt3Fm  and pod_purord <=  @opt3To) or @opt3 = 'N')
AND	((@opt4 = 'Y' and poh_prmcus >= @opt4Fm and poh_prmcus <= @opt4To) or @opt4 = 'N')
AND	((@secCustOpt = 'Y' and poh_seccus >= @secCNF and poh_prmcus <= @secCNT) or @secCustOpt = 'N')
AND	(	((@opt5 = 'Y' and poh_cuspno >= @opt5Fm and poh_cuspno <= @opt5To) or @opt5 = 'N')
		or
		((@opt5 = 'Y' and pod_cuspno >= @opt5Fm and pod_cuspno <= @opt5To) or @opt5 = 'N')
	)
AND	((@opt6 = 'Y' and pod_itmno >= @opt6Fm and pod_itmno <= @opt6To) or @opt6 = 'N')
AND	((@opt7 = 'Y' and (	pod_shpstr between rtrim(@opt7Fm) + ' 00:00:00' and rtrim(@opt7To) + ' 23:59:59' 
			or
			pod_shpend between rtrim(@opt7Fm) + ' 00:00:00' and rtrim(@opt7To) + ' 23:59:59' )
			or
			(pod_shpstr < rtrim(@opt7Fm) and pod_shpend > rtrim(@opt7To) + ' 23:59:59' )
			) 
	or @opt7 = 'N')
AND	((@opt9 = 'Y' and poh_ordno between @opt9Fm and @opt9To) or @opt9 = 'N')
AND	((@optA = 'Y' and ysr_saltem between @optAFm and @optATo) or @optA = 'N')


AND	(@SalTem='' or @SalTem='S' or ysr_saltem=@SalTem)
ORDER BY
pod_prdven + ' - ' + isnull(vbi_vensna,'') + (case sod_subcde when '' then '' else ' -' + sod_subcde  end),

	case @SortBy when 'P' then  pri.cbi_cussna
		when 'C' then (case len(ltrim(pod_cuspno)) when 0 then poh_cuspno else pod_cuspno end)
		when 'V' then pod_venitm
		when 'I' then convert(char(12),pod_shpstr,111)
		else '' end,
	
	case @SortBy when 'P' then convert(char(12),pod_shpstr,111)
		when 'C' then pod_venitm
		when 'V' then convert(char(12),pod_shpstr,111)
		when 'I' then  pri.cbi_cussna
		else '' end,
	
	case @SortBy when 'P' then pod_venitm
		when 'C' then convert(char(12),pod_shpstr,111)
		when 'V' then  pri.cbi_cussna
		when 'I' then  (case len(ltrim(pod_cuspno)) when 0 then poh_cuspno else pod_cuspno end)
		else '' end













GO
GRANT EXECUTE ON [dbo].[sp_list_MSR00004_NET] TO [ERPUSER] AS [dbo]
GO
