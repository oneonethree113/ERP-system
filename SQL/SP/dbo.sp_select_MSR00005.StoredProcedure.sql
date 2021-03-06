/****** Object:  StoredProcedure [dbo].[sp_select_MSR00005]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00005]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00005]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- Checked by Allan Yuen at 27/07/2003
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Modification History
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modified by	-- Modified on	-- Modification Description
Lester Wu		Feb 11 , 2004	ADD "ALL" COMPANY SELECTION and SECONDARY CUSTOMER SELECTION
Lester Wu		2004/03/08		Add access control on sales team
				Users can obtain the requested data if ;
				1)users are of the same team of the customer's sales representative / 
				2)users without a sales team / 
				3)users belongs to sales team 'S' 
Lester Wu		Mar 15 ,2004	ADD Sort Option (Customer Short Name) and Change Sort Sequence
Lester Wu		Jul 23 ,2004	Amend the @opy6To value
Lester Wu		2005-03-21	Replace "ALL" with "UC-G"
				Cater "MS - Magic Silk" company
				Retrieve Company name from databse
Lester Wu		2005-06-02	Apply new logic of ship date range selection
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
-- OS Job By PO



CREATE     PROCEDURE [dbo].[sp_select_MSR00005]



--DECLARE
@cocde		nvarchar(6),
@opt1Fm		nvarchar(10),	-- Sub Code
@opt1To		nvarchar(10),
@opt2Fm		nvarchar(6),	-- Vendor Code
@opt2To		nvarchar(6),
@opt3Fm		nvarchar(6),	-- Customer Code
@opt3To		nvarchar(6),
-- 2004/02/11 Lester Wu
@secCNF		nvarchar(6),	-- Secondary Code
@secCNT		nvarchar(6),
-------------------------------
@opt4Fm		nvarchar(20),	-- Customer PO #
@opt4To		nvarchar(20),
@opt4s		nvarchar(4),
@opt8Fm		nvarchar(20),	-- SC No.
@opt8To		nvarchar(20),
@opt9Fm		nvarchar(20),	-- Sales Team
@opt9To		nvarchar(20),
@opt5Fm		nvarchar(20),	-- Item No.
@opt5To		nvarchar(20),
@opt6Fm		datetime,--nvarchar(10), --datetime,		-- Ship Start Date
@opt6To		datetime,--nvarchar(10), --datetime,
@opt7Fm		nvarchar(20),	-- PO No.
@opt7To		nvarchar(20),
@optPrintPO	nvarchar(1),
@sort		nvarchar(1),
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
@opt9	nvarchar(1)
-- 2004/02/11 Lester Wu
,@secCustOpt	nvarchar(1)

SET @secCustOpt = 'N'
if @secCNF<>'' or @secCNT<>'' 
begin
	SET @secCustOpt = 'Y'
end
------------------------------

SET @opt1 = 'N'
If @opt1Fm <> '' or @opt1To <> ''
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
If @opt4To <> '' and @opt4s <> ''
begin
	SET @opt4To = ltrim(@opt4To) + ' (' + ltrim(@opt4s) + ')'
end
If @opt4s <> ''
begin
	SET @opt4s = '%' + ltrim(rtrim(@opt4s)) + '%'
end

SET @opt5 = 'N'
If @opt5Fm <> '' and @opt5To <> ''
begin
	SET @opt5 = 'Y'
end

SET @opt6 = 'N'
If @opt6Fm <> '' and @opt6To <> ''
begin
	SET @opt6 = 'Y'
end
/*
If (@opt6Fm <> '' and @opt6To <> '') or (@opt6Fm = '1900/01/01')
begin
	SET @opt6 = 'Y'
end

if @opt6Fm = '1900/01/01'  and @opt6To = convert(nvarchar(10), getdate(),101)
begin
	SET @opt6 = 'N'
end
*/

SET @opt7 = 'N'
If @opt7Fm <> '' and @opt7To <> ''
begin
	SET @opt7 = 'Y'
end

SET @opt8 = 'N'
If @opt8Fm <> '' and @opt8To <> ''
begin
	SET @opt8 = 'Y'
end
SET @opt9 = 'N'
If @opt9Fm <> '' and @opt9To <> ''
begin
	SET @opt9 = 'Y'
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

SELECT	@cocde as '@cocde',
	@opt1Fm as '@opt1Fm',		@opt1To as '@opt1To',
	@opt2Fm as '@opt2Fm',		@opt2To as '@opt2To',
	@opt3Fm as '@opt3Fm',		@opt3To as '@opt3To',
	-- 2004/02/11 Lester Wu
	@secCNF as '@secCNF',	@secCNT as '@secCNT',
	-----------------------------
	@opt4Fm as '@opt4Fm',		@opt4To as '@opt4To',
	@opt5Fm as '@opt5Fm',		@opt5To as '@opt5To',
	@opt6Fm as '@opt6Fm',		@opt6To as '@opt6To',
	@opt7Fm as '@opt7Fm',		@opt7To as '@opt7To',
	@optPrintPO as '@optPrintPO',
	poh_purord as 'poh_purord' ,	isnull(pod_jobord,'') as 'pod_jobord',
	pod_cusitm as 'pod_cusitm' ,
	pod_venitm as 'pod_venitm' ,	
	--left(pod_engdsc,20) as 'pod_engdsc',
	pod_engdsc as 'pod_engdsc' ,
	sod_subcde as 'sod_subcde' ,
	pod_ordqty as 'pod_ordqty' ,	isnull(ysi_dsc,'') as 'pod_untcde',	
	pod_itmno as 'pod_itmno' ,		sod_colcde as 'sod_colcde' ,	--left(sod_colcde,10),
	 pod_ordqty - pod_recqty as 'pod_balqty' ,
	pod_ttlctn * (pod_ordqty - pod_recqty) / pod_ordqty as 'pod_balctn' ,
	convert(varchar(10), pod_shpstr, 101)  as 'pod_shpstr' ,	
	convert(varchar(10), pod_shpend, 101) 	 as 'pod_shpend' ,
	ltrim(str(pod_ordqty))+' '+pod_untcde as 'qty',
--Lester Wu 2005-06-20, show production vendor instead of custom vendor -----------------------------------------------
--	poh_venno + ' - ' + isnull(vbi_vensna,'') + --' (' + sod_subcde + ')' as 'poh_venno'
--	(case sod_subcde when '' then '' else ' (' + sod_subcde + ')' end) + ' (' + poh_prmcus + ')' as 'poh_venno',
	pod_prdven + ' - ' + isnull(vbi_vensna,'') + (case sod_subcde when '' then '' else ' (' + sod_subcde + ')' end) + ' (' + poh_prmcus + ')' as 'poh_venno',
--------------------------------------------------------------------------------------------------------------------------------------------
	(case len(ltrim(pod_cuspno)) when 0 then poh_cuspno else pod_cuspno end) as 'pod_cuspno',
	left(pri.cbi_cussna,20) as 'cbi_cussna',
	-- 2004/02/11 Lester Wu
	left(isnull(sec.cbi_cussna,''),20) as 'secCustSNa',
	@opt8Fm as '@opt8Fm',		@opt8To as '@opt8To',	
	@opt9Fm as '@opt9Fm', 	@opt9To as '@opt9To',
	@sort as '@sort'
	--2004/06/23 Lester Wu
	, round( round((pod_cubcft / 35.3356),4) * (pod_ordqty - pod_recqty ) / pod_mtrctn,4)
	AS 'pod_balcbm'
	----------------------------------------------------------------------------------------------------
	--Lester Wu 2005-03-21 Retrieve company information form database
	,@compName as 'compName'
From	POORDHDR
left join POORDDTL on poh_cocde = pod_cocde and poh_purord = pod_purord
left join SCORDDTL on pod_cocde = sod_cocde AND pod_scno = sod_ordno and pod_scline = sod_ordseq
left join VNBASINF on pod_prdven = vbi_venno
left join SYSETINF on ysi_typ = '05' and ysi_cde = pod_untcde
left join CUBASINF pri on pri.cbi_cusno = poh_prmcus
left join CUBASINF sec on poh_seccus = sec.cbi_cusno
Where	
((@cocde<>'UC-G' and  poh_cocde = @cocde)  or (@cocde = 'UC-G' and poh_cocde<>'MS'))

--and 	poh_cocde = pod_cocde AND poh_purord = pod_purord 
--and 	pod_cocde = sod_cocde AND pod_scno = sod_ordno and pod_scline = sod_ordseq

--AND	pod_prdven = vbi_venno 

--AND	ysi_typ = '05' and ysi_cde = pod_untcde
--AND 	pri.cbi_cusno = poh_prmcus
--AND	poh_seccus *= sec.cbi_cusno



AND	(@SalTem='' or @SalTem='S' or pri.cbi_saltem=@SalTem 
	or pri.cbi_saltem in (select distinct yur_para from syusrright where yur_usrid = @creusr and yur_doctyp = 'PO' and yur_lvl = 1) )
AND	((@opt1 = 'Y' and sod_subcde >= @opt1Fm and sod_subcde <= @opt1To) or @opt1 = 'N')
AND	((@opt2 = 'Y' and pod_prdven >= @opt2Fm and pod_prdven <= @opt2To) or @opt2 = 'N')
AND	((@opt3 = 'Y' and poh_prmcus >= @opt3Fm and poh_prmcus <= @opt3To) or @opt3 = 'N')
AND	((@secCustOpt = 'Y' and poh_seccus >= @secCNF and poh_seccus <= @secCNT) or @secCustOpt = 'N')
AND	(	((@opt4 = 'Y' and poh_cuspno >= @opt4Fm and poh_cuspno <= @opt4To) or @opt4 = 'N')
		or
		((@opt4 = 'Y' and pod_cuspno >= @opt4Fm and pod_cuspno <= @opt4To) or @opt4 = 'N')
	)
AND	((( poh_cuspno like @opt4s or pod_cuspno like @opt4s) and @opt4s <> '') or @opt4s = '')
AND	((@opt5 = 'Y' and pod_itmno >= @opt5Fm and pod_itmno <= @opt5To) or @opt5 = 'N')
AND	((@opt6 = 'Y' and (	pod_shpstr between @opt6Fm and @opt6To + ' 23:59:59.000' 
			or 
			pod_shpend between @opt6Fm and @opt6To + ' 23:59:59.000' 
			or 
			(pod_shpstr < @opt6Fm and pod_shpend > @opt6To + ' 23:59:59.000')
		             )
	)
	 or @opt6 = 'N')
AND	((@opt7 = 'Y' and poh_purord >= @opt7Fm and poh_purord <= @opt7To) or @opt7 = 'N')
AND	((@opt8 = 'Y' and poh_ordno between @opt8Fm and @opt8To) or @opt8 = 'N')
AND	((@opt9 = 'Y' and pri.cbi_saltem between @opt9Fm and @opt9To) or @opt9 = 'N')

AND 	pod_ordqty > 0 AND pod_ordqty - pod_recqty > 0


ORDER BY 
pod_prdven + ' - ' + isnull(vbi_vensna,'') + (case sod_subcde when '' then '' else ' (' + sod_subcde + ')' end) + ' (' + poh_prmcus + ')' ,

	case @sort when 'P' then left(pri.cbi_cussna,20)
		when 'C' then (case len(ltrim(pod_cuspno)) when 0 then poh_cuspno else pod_cuspno end)
		when 'V' then pod_venitm
		when 'S' then convert(char(10),pod_shpstr,111)
		else '' end,

	case @sort when 'P' then convert(char(10),pod_shpstr,111)
		when 'C' then pod_venitm
		when 'V' then convert(char(10),pod_shpstr,111)
		when 'S' then left(pri.cbi_cussna,20)
		else '' end,
	
	case @sort when 'P' then pod_venitm
		when 'C' then convert(char(10),pod_shpstr,111)
		when 'V' then left(pri.cbi_cussna,20)
		when 'S' then  (case len(ltrim(pod_cuspno)) when 0 then poh_cuspno else pod_cuspno end)
		else '' end



GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00005] TO [ERPUSER] AS [dbo]
GO
