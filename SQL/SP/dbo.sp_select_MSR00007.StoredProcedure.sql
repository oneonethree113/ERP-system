/****** Object:  StoredProcedure [dbo].[sp_select_MSR00007]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00007]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00007]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







-- Checked by Allan Yuen at 27/07/2003
-- FOR Test Only --> Lester Wu
-- Combine Alias Customer Selection/Grouping
-- ADD "ALL" Company Selection

-- *
/***********************************************************************************************************************************************
Modification History
************************************************************************************************************************************************
Modified by		Modified on		Description
************************************************************************************************************************************************
Lester Wu			2005-04-02		replace ALL with UC-G, exclude MS from UC-G, retrieve company name from database
Allan Yuen			2006-03-20		Cater External Item Product Line Issue
************************************************************************************************************************************************/


--sp_select_MSR00007 'UCPP','30007','30007','','','','','','','','','','','08/01/2003 00:00:00.000','08/31/2003 23:59:59.000','N','B','C','mis'
--sp_select_MSR00007 'UCPP','','','','','','','','','','','','','08/01/2003 00:00:00.000','08/31/2003 23:59:59.000','N','B','C','mis'

CREATE    PROCEDURE [dbo].[sp_select_MSR00007]

@cocde		nvarchar(6),
@pcFm		nvarchar(6),	@pcTo		nvarchar(6),
@psFm		nvarchar(6),	@psTo		nvarchar(6),
@plFm		nvarchar(10),	@plTo		nvarchar(10),
@itmFm		nvarchar(20),	@itmTo		nvarchar(20),
@custItmFm	nvarchar(20),	@custItmTo	nvarchar(20),
@vnFm		nvarchar(6),	@vnTo		nvarchar(6),
@idFm		nvarchar(30),	@idTo		nvarchar(30),
-- print factory info
	@fi	nvarchar(1),
-- identify select Quotation data , S/C data or Both
	@qs	nvarchar(1),
-- identify show Customer Item or Item 
	@order	nvarchar(1),
	@user	nvarchar(30)

AS

DECLARE
@pcOpt		nvarchar(1),
@psOpt		nvarchar(1),
@plOpt		nvarchar(1),
@itmOpt		nvarchar(1),
@custItmOpt	nvarchar(1),
@idOpt		nvarchar(1),
@vnOpt		nvarchar(1)


SET @pcOpt = 'N'
	If @pcFm <> '' or @pcTo <> ''
	begin
		SET @pcOpt = 'Y'
	end

SET @psOpt = 'N'
	If @psFm <> '' or @psTo <> ''
	begin
		SET @psOpt = 'Y'
	end

SET @plOpt = 'N'
	If @plFm <> '' or  @plTo<> ''
	begin
		SET @plOpt = 'Y'
	end

SET @itmOpt = 'N'
	If @itmFm <> '' or @itmTo <> ''
	begin
		SET @itmOpt = 'Y'
	end


SET @custItmOpt = 'N'
	If @custItmFm <> '' or @custItmTo <> ''
	begin
		SET @custItmOpt = 'Y'
	end

SET @idOpt = 'N'
	If @idFm <> '' or @idTo <> ''
	begin
		SET @idOpt = 'Y'
	end

SET @vnOpt = 'N'
	If @vnFm <> '' or @vnTo <> ''
	begin
		SET @vnOpt = 'Y'
	end


--Lester Wu 2005-04-02, retrieve company name from database----------------------------------------
declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde<>'UC-G'
begin
	select @compName = yco_conam from sycominf where yco_cocde = @cocde
end
---------------------------------------------------------------------------------------------------------------------


-- 2004/02/13 Lester
-- Create Alias Customer Table
select vw_cbi_cusno,vw_cbi_cusali	-- Customer Alias
into #tmp_msr00007_cusali
from vw_cusali
where  (@pcOpt = 'N' or (@pcOpt='Y' and vw_cbi_cusali in (
select distinct vw_cbi_cusali from vw_cusali
--where vw_cbi_cusno between '10011' and '10011'
where vw_cbi_cusno between @pcFm and @pcTo
and vw_cbi_custyp = 'P'
)))
-------------------------------------------------------------------
select vw_cbi_cusno,vw_cbi_cusali	-- Customer Alias
into #tmp_msr00007_cusali_sec
from vw_cusali
where (@psOpt = 'N' or (@psOpt='Y' and vw_cbi_cusali in (
select distinct vw_cbi_cusali from vw_cusali
--where vw_cbi_cusno between '10011' and '10011'
where  vw_cbi_cusno between @psFm and @psTo
and vw_cbi_custyp = 'S'
)))
-- 2004/02/13 Lester
-- Create Alias Customer Table
-------------------------------------------------------------------
--select * from #tmp_msr00007_cusali
--select * from #tmp_msr00007_cusali_sec

if @pcOpt = 'Y' 
begin
	select @pcFm = case @pcFm when '' then '' else min(vw_cbi_cusali) end,@pcTo= case @pcTo when '' then '' else max(vw_cbi_cusali) end
	from vw_cusali
	where vw_cbi_custyp='P'
	and vw_cbi_cusno between @pcFm and @pcTo
end
if @psOpt = 'Y' 
begin
	select @psFm = case @psFm when '' then '' else min(vw_cbi_cusali) end , @psTo = case @psTo when '' then '' else max(vw_cbi_cusali) end
	from vw_cusali
	where vw_cbi_custyp='S'
	and vw_cbi_cusno between @psFm and @psTo
end
------------------------------------------------------------------------------------------------------
SELECT	
	-- SCORDDTL
	-- 2004/02/14 Lester Wu
	--soh_cocde,
	@cocde as 'cid_cocde',
	-------------------------------
	a.cbi_cusno as 'cid_cusno',	--2
	isnull(soh_cus2no,'') as 'cid_seccus',	--3
	Case @order when 'C' then sod_cusitm else sod_itmno end as 'IC',		--4
	sod_itmno as 'cid_itmno',	--5
	sod_cusitm as 'cid_cusitm',	--6
	sod_cussku as 'cid_cussku',
	left(sod_itmdsc,40) as 'cid_itmdsc',
	ysi_dsc + '/' +  ltrim(str(sod_inrctn,10,0)) + '/' + ltrim(str(sod_mtrctn,10,0)) as 'cid_packing',	--9
	(ysi_dsc) as 'ysi_dsc',
	(sod_inrctn) as 'cid_inrqty',
	(sod_mtrctn) as 'cid_mtrqty',
	(sod_cft) as 'cid_cft',

--	 + '/' + ltrim(str(cid_cft,10,2)),
	sod_colcde as 'cid_colcde',	--14
	(sod_coldsc) as 'cid_coldsc',
	sod_ordqty as 'cid_sumqty',
	sod_curcde  as 'cid_curcde', sod_untprc as 'cid_selprc',
	ltrim(str(sod_cususd,10,2)) as 'cid_cususd',
	ltrim(str(sod_cuscad,10,2)) as 'cid_cuscad',
	sod_ordqty as 'cid_ordqty',
	sod_subcde as 'sod_subcde',
	sod_venno as 'sod_venno',	--23
	sod_venitm as 'sod_venitm',	--24

	sod_fcurcde as 'cid_fcurcde', sod_ftyprc as 'cid_ftyprc', 
	soh_issdat as 'cid_docdat',	--27
	
	-- CUBASINF a
	a.cbi_cussna as 'cbi_cussna',


	-- CUBASINF b
	isnull(b.cbi_cusno,'') as 'SecCustNo',	isnull(b.cbi_cussna,'') as 'SecCustShort',

	-- VNBASINF
	vbi_vensna as 'vbi_vensna',	

	-- Parameter
	@fi as '@fi',	
	@pcFm as '@pcFm',		@pcTo as '@pcTo',
	@psFm as '@psFm',		@psTo as '@psTo',
	@plFm as '@plFm',		@plTo as '@plTo',
	@itmFm as '@itmFm',		@itmTo as '@itmTo',
	@custItmFm as '@custItmFm',	@custItmTo as '@custItmTo',
	@vnFm as '@vnFm',		@vnTo as '@vnTo',
	@idFm as '@idFm',		@idTo as '@idTo',
	@qs as '@qs',
	sod_oneprc as 'cid_onetim',	--48
	soh_ordno as 'soh_ordno',
	@compName as 'compName'

--FROM	SCORDDTL, SCORDHDR, IMBASINF, CUBASINF a, CUBASINF b, VNBASINF, SYSETINF
	-- 2004/02/12 Lester Wu
--	,#tmp_msr00007_cusali pri,#tmp_msr00007_cusali_sec sec

From	SCORDHDR
	left join #tmp_msr00007_cusali_sec sec on soh_cus2no = sec.vw_cbi_cusno
	left join CUBASINF b on sec.vw_cbi_cusali = b.cbi_cusno
	,SCORDDTL 
	left join VNBASINF on sod_venno = vbi_venno 	
	left join SYSETINF on sod_pckunt = ysi_cde and ysi_typ = '05'		
	,IMBASINF, CUBASINF a --, CUBASINF b
	,#tmp_msr00007_cusali pri
	------------------------------
WHERE 

--	sod_cocde = ibi_cocde and sod_itmno = ibi_itmno
	sod_itmno = ibi_itmno

and	sod_cocde = soh_cocde and sod_ordno = soh_ordno

--and 	soh_cus1no = a.cbi_cusno and soh_cocde = a.cbi_cocde
--and 	soh_cus2no *= b.cbi_cusno and soh_cocde *= b.cbi_cocde
--and	sod_venno *= vbi_venno and sod_cocde *= vbi_cocde 
--2004/02/12 Lester Wu
--and 	soh_cus1no = a.cbi_cusno 
and 	case @psOpt when 'Y' then isnull(b.cbi_cusno,'') else 'ALL' end <> ''
and	soh_cus1no = pri.vw_cbi_cusno
and	pri.vw_cbi_cusali = a.cbi_cusno
----------------------------------------------------------
--and	sod_venno *= vbi_venno 
-- 2004/02/13 Lester Wu
--and	sod_cocde = @cocde
--Lester Wu 2005-04-02, replace ALL with UC-G
--d	(@cocde='ALL' or soh_cocde = @cocde)
and	((@cocde='UC-G' and soh_cocde<>'MS') or soh_cocde = @cocde)
----------------------------------------------------------------
--and	sod_cocde *= ysi_cocde and sod_pckunt *= ysi_cde and ysi_typ = '05'
--and	sod_pckunt *= ysi_cde and ysi_typ = '05'

AND	((@vnOpt = 'Y' and sod_venno between @vnFm and @vnTo) or @vnOpt = 'N')
-- 2004/02/12 Lester Wu
-- AND	((@pcOpt = 'Y' and soh_cus1no between @pcFm and @pcTo) or @pcOpt = 'N')
--AND	((@psOpt = 'Y' and soh_cus2no between @psFm and @psTo) or @psOpt = 'N')
------------------------------------------------------------------------------------------------------------------
AND	((@plOpt = 'Y' and ibi_lnecde between @plFm and @plTo) or @plOpt = 'N')
AND	((@itmOpt = 'Y' and sod_itmno between @itmFm and @itmTo) or @itmOpt = 'N')
AND	((@idOpt = 'Y' and soh_issdat between @idFm and @idTo) or @idOpt = 'N')
AND	(@qs = 'S'  or @qs = 'B')
AND	VBI_VENTYP <> 'E'

union

SELECT	
	-- SCORDDTL
	-- 2004/02/14 Lester Wu
	--soh_cocde,
	@cocde as 'cid_cocde',
	-------------------------------
	a.cbi_cusno as 'cid_cusno',	--2
	isnull(soh_cus2no,'') as 'cid_seccus',	--3
	Case @order when 'C' then sod_cusitm else sod_itmno end as 'IC',		--4
	sod_itmno as 'cid_itmno',	--5
	sod_cusitm as 'cid_cusitm',	--6
	sod_cussku as 'cid_cussku',
	  left(sod_itmdsc,40) as 'cid_itmdsc',
	ysi_dsc + '/' +  ltrim(str(sod_inrctn,10,0)) + '/' + ltrim(str(sod_mtrctn,10,0)) as 'cid_packing',	--9
	(ysi_dsc) as 'ysi_dsc',
	(sod_inrctn) as 'cid_inrqty',
	(sod_mtrctn) as 'cid_mtrqty',
	(sod_cft) as 'cid_cft',

--	 + '/' + ltrim(str(cid_cft,10,2)),
	sod_colcde as 'cid_colcde',	--14
	(sod_coldsc) as 'cid_coldsc',
	sod_ordqty as 'cid_sumqty',
	sod_curcde  as 'cid_curcde', sod_untprc as 'cid_selprc',
	ltrim(str(sod_cususd,10,2)) as 'cid_cususd',
	  ltrim(str(sod_cuscad,10,2)) as 'cid_cuscad',
	sod_ordqty as 'cid_ordqty',
	sod_subcde as 'sod_subcde',
	sod_venno as 'sod_venno',	--23
	sod_venitm as 'sod_venitm',	--24

	sod_fcurcde as 'cid_fcurcde', sod_ftyprc as 'cid_ftyprc', 
	soh_issdat as 'cid_docdat',	--27
	
	-- CUBASINF a
	a.cbi_cussna as 'cbi_cussna',


	-- CUBASINF b
	isnull(b.cbi_cusno,'') as 'SecCustNo',	isnull(b.cbi_cussna,'') as 'SecCustShort',

	-- VNBASINF
	vbi_vensna as 'vbi_vensna',	

	-- Parameter
	@fi as '@fi',	
	@pcFm as '@pcFm',		@pcTo as '@pcTo',
	@psFm as '@psFm',		@psTo as '@psTo',
	@plFm as '@plFm',		@plTo as '@plTo',
	@itmFm as '@itmFm',		@itmTo as '@itmTo',
	@custItmFm as '@custItmFm',	@custItmTo as '@custItmTo',
	@vnFm as '@vnFm',		@vnTo as '@vnTo',
	@idFm as '@idFm',		@idTo as '@idTo',
	@qs as '@qs',
	sod_oneprc as 'cid_onetim',	--48
	soh_ordno as 'soh_ordno',
	@compName as 'compName'

--FROM	SCORDDTL, SCORDHDR, IMBASINF, CUBASINF a, CUBASINF b, VNBASINF, SYSETINF
	-- 2004/02/12 Lester Wu
--	,#tmp_msr00007_cusali pri,#tmp_msr00007_cusali_sec sec

From	SCORDHDR
	left join #tmp_msr00007_cusali_sec sec on soh_cus2no = sec.vw_cbi_cusno
	left join CUBASINF b on sec.vw_cbi_cusali = b.cbi_cusno
	,SCORDDTL 
	left join VNBASINF on sod_venno = vbi_venno 	
	left join SYSETINF on sod_pckunt = ysi_cde and ysi_typ = '05'
	LEFT JOIN IMCOLINF ON SOD_COLCDE = ICF_COLCDE and sod_itmno = icf_itmno
	,IMBASINF, CUBASINF a --, CUBASINF b
	,#tmp_msr00007_cusali pri
	------------------------------
WHERE 

--	sod_cocde = ibi_cocde and sod_itmno = ibi_itmno
	sod_itmno = ibi_itmno

and	sod_cocde = soh_cocde and sod_ordno = soh_ordno

--and 	soh_cus1no = a.cbi_cusno and soh_cocde = a.cbi_cocde
--and 	soh_cus2no *= b.cbi_cusno and soh_cocde *= b.cbi_cocde
--and	sod_venno *= vbi_venno and sod_cocde *= vbi_cocde 
--2004/02/12 Lester Wu
--and 	soh_cus1no = a.cbi_cusno 
and 	case @psOpt when 'Y' then isnull(b.cbi_cusno,'') else 'ALL' end <> ''
and	soh_cus1no = pri.vw_cbi_cusno
and	pri.vw_cbi_cusali = a.cbi_cusno
----------------------------------------------------------
--and	sod_venno *= vbi_venno 
-- 2004/02/13 Lester Wu
--and	sod_cocde = @cocde
--Lester Wu 2005-04-02, replace ALL with UC-G
--d	(@cocde='ALL' or soh_cocde = @cocde)
and	((@cocde='UC-G' and soh_cocde<>'MS') or soh_cocde = @cocde)
----------------------------------------------------------------
--and	sod_cocde *= ysi_cocde and sod_pckunt *= ysi_cde and ysi_typ = '05'
--and	sod_pckunt *= ysi_cde and ysi_typ = '05'

AND	((@vnOpt = 'Y' and sod_venno between @vnFm and @vnTo) or @vnOpt = 'N')
-- 2004/02/12 Lester Wu
-- AND	((@pcOpt = 'Y' and soh_cus1no between @pcFm and @pcTo) or @pcOpt = 'N')
--AND	((@psOpt = 'Y' and soh_cus2no between @psFm and @psTo) or @psOpt = 'N')
------------------------------------------------------------------------------------------------------------------
--AND	((@plOpt = 'Y' and ibi_lnecde between @plFm and @plTo) or @plOpt = 'N')
AND	((@plOpt = 'Y' and iCF_lnecde between @plFm and @plTo) or @plOpt = 'N')
AND	((@itmOpt = 'Y' and sod_itmno between @itmFm and @itmTo) or @itmOpt = 'N')
AND	((@idOpt = 'Y' and soh_issdat between @idFm and @idTo) or @idOpt = 'N')
AND	(@qs = 'S'  or @qs = 'B')
AND	VBI_VENTYP = 'E'

UNION

SELECT	
	-- QUOTNDTL
	-- 2004/02/14 Lester Wu
	-- qud_cocde,
	@cocde as 'cid_cocde',
	-------------------------------
	a.cbi_cusno as 'cid_cusno',
	isnull(quh_cus2no,'') as 'cid_seccus',
	Case @order when 'C' then qud_cusitm else qud_itmno end as 'IC',
	qud_itmno as 'cid_itmno',

	qud_cusitm as 'cid_cusitm',
	'' as 'cid_cussku',
	left(qud_itmdsc,40) as 'cid_itmdsc',
	ysi_dsc + '/' +  ltrim(str(qud_inrqty,10,0)) + '/' + ltrim(str(qud_mtrqty,10,0)) as 'cid_packing',
	(ysi_dsc) as 'ysi_dsc',
	(qud_inrqty) as 'cid_inrqty',
	(qud_mtrqty) as 'cid_mtrqty',
	(qud_cft) as 'cid_cft',
--	 + '/' + ltrim(str(cid_cft,10,2)),
	qud_colcde as 'cid_colcde',
	(qud_coldsc) as 'cid_coldsc',
	0 as 'cid_sumqty',
	qud_curcde  as 'cid_curcde', qud_cus1dp as 'cid_selprc',
	ltrim(str(qud_cususd,10,2)) as 'cid_cususd',
	ltrim(str(qud_cuscad,10,2)) as 'cid_cuscad',
	0 as 'cid_ordqty',

	qud_subcde as 'sod_subcde',
	qud_venno as 'sod_venno',
	qud_venitm as 'sod_venitm',

	
	--CUITMDTL
	qud_fcurcde as 'cid_fcurcde', qud_ftyprc as 'cid_ftyprc', 
	quh_issdat as 'cid_docdat',
	
	-- CUBASINF a
	a.cbi_cussna as 'cbi_cussna',


	-- CUBASINF b
	isnull(b.cbi_cusno,'') as 'SecCustNo',	isnull(b.cbi_cussna,'') as 'SecCustShort',


	-- VNBASINF
	vbi_vensna as 'vbi_vensna',	

	@fi as '@fi', 
	@pcFm as '@pcFm',		@pcTo as '@pcTo',
	@psFm as '@psFm',		@psTo as '@psTo',
	@plFm as '@plFm',		@plTo as '@plTo',
	@itmFm as '@itmFm',		@itmTo as '@itmTo',
	@custItmFm as '@custItmFm',	@custItmTo as '@custItmTo',
	@vnFm as '@vnFm',		@vnTo as '@vnTo',
	@idFm as '@idFm',		@idTo as '@idTo',
	@qs as '@qs',
	qud_onetim as 'cid_onetim',
	quh_qutno as 'soh_ordno',
	@compName as 'compName'

--FROM	QUOTNDTL, IMBASINF, QUOTNHDR, CUBASINF a, CUBASINF b , VNBASINF, SYSETINF
	-- 2004/02/12 Lester Wu
--	,#tmp_msr00007_cusali pri,#tmp_msr00007_cusali_sec sec

From 	QUOTNHDR
	left join #tmp_msr00007_cusali_sec sec on quh_cus2no = sec.vw_cbi_cusno
	left join CUBASINF b on sec.vw_cbi_cusali = b.cbi_cusno
	,QUOTNDTL
	left join VNBASINF on qud_venno = vbi_venno
	left join SYSETINF on qud_untcde = ysi_cde and ysi_typ = '05'	
	,IMBASINF,  CUBASINF a --, CUBASINF b
	 , #tmp_msr00007_cusali pri
	-------------------------------
WHERE	
--	qud_cocde = ibi_cocde and qud_itmno = ibi_itmno
	qud_itmno = ibi_itmno

and	qud_cocde = quh_cocde and qud_qutno = quh_qutno

--and 	quh_cus1no = a.cbi_cusno and quh_cocde = a.cbi_cocde
--and 	quh_cus2no *= b.cbi_cusno and quh_cocde *= b.cbi_cocde
--and	qud_venno *= vbi_venno and qud_cocde *= vbi_cocde 
-- 2004/02/12 Lester Wu
--and 	quh_cus1no = a.cbi_cusno 
--and 	quh_cus2no *= b.cbi_cusno 
and 	case @psOpt when 'Y' then isnull(b.cbi_cusno,'') else 'ALL' end <> ''
-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX 
and	quh_cus1no = pri.vw_cbi_cusno
and	pri.vw_cbi_cusali = a.cbi_cusno

-------------------------------------------------------
--and	qud_venno *= vbi_venno 
-- 2004/02/13 Lester Wu
--and	qud_cocde = @cocde
--Lester Wu 2005-04-02, replace ALL with UC-G
--and	(@cocde='ALL' or qud_cocde = @cocde)
and	((@cocde='UC-G' and qud_cocde<>'MS') or qud_cocde = @cocde)

--and	qud_cocde *= ysi_cocde and qud_untcde *= ysi_cde and ysi_typ = '05'
--and	qud_untcde *= ysi_cde and ysi_typ = '05'

AND	((@vnOpt = 'Y' and qud_venno between @vnFm and @vnTo) or @vnOpt = 'N')
-- 2004/02/12 Lester Wu
--AND	((@pcOpt = 'Y' and quh_cus1no between @pcFm and @pcTo) or @pcOpt = 'N')
--AND	((@psOpt = 'Y' and quh_cus2no between @psFm and @psTo) or @psOpt = 'N')
AND	((@plOpt = 'Y' and ibi_lnecde between @plFm and @plTo) or @plOpt = 'N')
AND	((@itmOpt = 'Y' and qud_itmno between @itmFm and @itmTo) or @itmOpt = 'N')
AND	((@custItmOpt = 'Y' and qud_cusitm between @custItmFm and @custItmTo) or @custItmOpt = 'N')
AND	((@idOpt = 'Y' and quh_issdat between @idFm and @idTo) or @idOpt = 'N')
AND	(@qs = 'Q' or @qs = 'B')
AND	VBI_VENTYP <> 'E'

UNION

SELECT	
	-- QUOTNDTL
	-- 2004/02/14 Lester Wu
	-- qud_cocde,
	@cocde as 'cid_cocde',
	-------------------------------
	a.cbi_cusno as 'cid_cusno',
	isnull(quh_cus2no,'') as 'cid_seccus',
	  Case @order when 'C' then qud_cusitm else qud_itmno end as 'IC',
	qud_itmno as 'cid_itmno',

	qud_cusitm as 'cid_cusitm',
	'' as 'cid_cussku',
	left(qud_itmdsc,40) as 'cid_itmdsc',
	ysi_dsc + '/' +  ltrim(str(qud_inrqty,10,0)) + '/' + ltrim(str(qud_mtrqty,10,0)) as 'cid_packing',
	(ysi_dsc) as 'ysi_dsc',
	(qud_inrqty) as 'cid_inrqty',
	(qud_mtrqty) as 'cid_mtrqty',
	(qud_cft) as 'cid_cft',
--	 + '/' + ltrim(str(cid_cft,10,2)),
	qud_colcde as 'cid_colcde',
	(qud_coldsc) as 'cid_coldsc',
	0 as 'cid_sumqty',
	qud_curcde  as 'cid_curcde', qud_cus1dp as 'cid_selprc',
	ltrim(str(qud_cususd,10,2)) as 'cid_cususd',
	ltrim(str(qud_cuscad,10,2)) as 'cid_cuscad',
	0 as 'cid_ordqty',

	qud_subcde as 'sod_subcde',
	qud_venno as 'sod_venno',
	qud_venitm as 'sod_venitm',

	
	--CUITMDTL
	qud_fcurcde as 'cid_fcurcde', qud_ftyprc as 'cid_ftyprc', 
	quh_issdat as 'cid_docdat',
	
	-- CUBASINF a
	a.cbi_cussna as 'cbi_cussna',


	-- CUBASINF b
	isnull(b.cbi_cusno,'') as 'SecCustNo',	isnull(b.cbi_cussna,'') as 'SecCustShort',


	-- VNBASINF
	vbi_vensna as 'vbi_vensna',	

	@fi as '@fi', 
	@pcFm as '@pcFm',		@pcTo as '@pcTo',
	@psFm as '@psFm',		@psTo as '@psTo',
	@plFm as '@plFm',		@plTo as '@plTo',
	@itmFm as '@itmFm',		@itmTo as '@itmTo',
	@custItmFm as '@custItmFm',	@custItmTo as '@custItmTo',
	@vnFm as '@vnFm',		@vnTo as '@vnTo',
	@idFm as '@idFm',		@idTo as '@idTo',
	@qs as '@qs',
	qud_onetim as 'cid_onetim',
	quh_qutno as 'soh_ordno',
	@compName as 'compName'

--FROM	QUOTNDTL, IMBASINF, QUOTNHDR, CUBASINF a, CUBASINF b , VNBASINF, SYSETINF
	-- 2004/02/12 Lester Wu
--	,#tmp_msr00007_cusali pri,#tmp_msr00007_cusali_sec sec

From 	QUOTNHDR
	left join #tmp_msr00007_cusali_sec sec on quh_cus2no = sec.vw_cbi_cusno
	left join CUBASINF b on sec.vw_cbi_cusali = b.cbi_cusno
	,QUOTNDTL
	left join VNBASINF on qud_venno = vbi_venno
	left join SYSETINF on qud_untcde = ysi_cde and ysi_typ = '05'	
	LEFT JOIN IMCOLINF ON QUD_COLCDE = ICF_COLCDE and qud_itmno = icf_itmno
	,IMBASINF,  CUBASINF a --, CUBASINF b
	 , #tmp_msr00007_cusali pri
	-------------------------------
WHERE	
--	qud_cocde = ibi_cocde and qud_itmno = ibi_itmno
	qud_itmno = ibi_itmno

and	qud_cocde = quh_cocde and qud_qutno = quh_qutno

--and 	quh_cus1no = a.cbi_cusno and quh_cocde = a.cbi_cocde
--and 	quh_cus2no *= b.cbi_cusno and quh_cocde *= b.cbi_cocde
--and	qud_venno *= vbi_venno and qud_cocde *= vbi_cocde 
-- 2004/02/12 Lester Wu
--and 	quh_cus1no = a.cbi_cusno 
--and 	quh_cus2no *= b.cbi_cusno 
and 	case @psOpt when 'Y' then isnull(b.cbi_cusno,'') else 'ALL' end <> ''
-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX 
and	quh_cus1no = pri.vw_cbi_cusno
and	pri.vw_cbi_cusali = a.cbi_cusno

-------------------------------------------------------
--and	qud_venno *= vbi_venno 
-- 2004/02/13 Lester Wu
--and	qud_cocde = @cocde
--Lester Wu 2005-04-02, replace ALL with UC-G
--and	(@cocde='ALL' or qud_cocde = @cocde)
and	((@cocde='UC-G' and qud_cocde<>'MS') or qud_cocde = @cocde)

--and	qud_cocde *= ysi_cocde and qud_untcde *= ysi_cde and ysi_typ = '05'
--and	qud_untcde *= ysi_cde and ysi_typ = '05'

AND	((@vnOpt = 'Y' and qud_venno between @vnFm and @vnTo) or @vnOpt = 'N')
-- 2004/02/12 Lester Wu
--AND	((@pcOpt = 'Y' and quh_cus1no between @pcFm and @pcTo) or @pcOpt = 'N')
--AND	((@psOpt = 'Y' and quh_cus2no between @psFm and @psTo) or @psOpt = 'N')
--AND	((@plOpt = 'Y' and ibi_lnecde between @plFm and @plTo) or @plOpt = 'N')
AND	((@plOpt = 'Y' and ICF_lnecde between @plFm and @plTo) or @plOpt = 'N')
AND	((@itmOpt = 'Y' and qud_itmno between @itmFm and @itmTo) or @itmOpt = 'N')
AND	((@custItmOpt = 'Y' and qud_cusitm between @custItmFm and @custItmTo) or @custItmOpt = 'N')
AND	((@idOpt = 'Y' and quh_issdat between @idFm and @idTo) or @idOpt = 'N')
AND	(@qs = 'Q' or @qs = 'B')
AND	VBI_VENTYP = 'E'


ORDER BY
	 2, 3, 4, 5, 6, 14, 9,  27 desc,48












GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00007] TO [ERPUSER] AS [dbo]
GO
