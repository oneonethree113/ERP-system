/****** Object:  StoredProcedure [dbo].[sp_select_MSR00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 27/07/2003
-- Modify by	: Lester Wu
-- Modify on	:2004/02/11
-- Modification	:ADD SECONDARY CUSTOMER SELECTION and "ALL" COMPANY SELECTION
-- Modify by	: Lester Wu
-- Modify on	: 2004/03/08
-- Modify by	: Lester Wu
-- Modification	: Add access control on sales team
--		: Users can obtain the requested data if ;
--		: 1)users are of the same team of the customer's sales representative / 
--		: 2)users without a sales team / 
--		: 3)users belongs to sales team 'S' 
--
-- Modify on	: 2005-03-21
-- Modify by	: Lester Wu
-- Modification	: Replace "ALL" with "UC-G"
--		  Cater "MS - Magic Silk" company
--		  Retrieve Company name from databse

CREATE    PROCEDURE [dbo].[sp_select_MSR00003]


@cocde			nvarchar(6),
@CustCodeFm		nvarchar(20),	
@CustCodeTo		nvarchar(20),
-- 2004/02/11 Lester Wu
@SecCustCodeFm		nvarchar(20),	
@SecCustCodeTo		nvarchar(20),
------------------------------
@VendorCodeFm		nvarchar(20),
@VendorCodeTo		nvarchar(20),
@VendorCSNFm		nvarchar(60),
@VendorCSNTo		nvarchar(60),
-- 2004/02/16 Lester Wu
@SalTemFm		nvarchar(1),
@SalTemTo		nvarchar(1),
--@SubCodeFm		nvarchar(10),	
--@SubCodeTo		nvarchar(10),
@creusr 			nvarchar(30)
-- 2004/03/08 Lester Wu
,@SalTem			nvarchar(7)


AS

---------------------------------------------------------------------------------------------------------------------------------------------
DECLARE
	@CC	nvarchar(1),	
	-- 2004/02/11 Lester Wu
	@SCC	nvarchar(1),
	------------------------------
	@VC	nvarchar(1)
	, @ST	nvarchar(1)
	

set @CC = 'N'
	If @CustCodeFm = '' and @CustCodeTo = ''
	begin
		set @CC = 'Y'
	end
-- 2004/02/11 Lester Wu
set @SCC = 'N'
	If @SecCustCodeFm = '' and @SecCustCodeTo = ''
	begin
		set @SCC = 'Y'
	end
-----------------------------
set @VC = 'N'
	If @VendorCodeFm = '' and @VendorCodeTo = ''
	begin
		set @VC = 'Y'
	end
set @ST = 'N'
	if @SalTemFm='' and @SalTemTo=''
	begin
		set @ST = 'Y'
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

SELECT	DISTINCT

	-- SCORDDTL
	@cocde as 'cocde',		
	@CustCodeFm as 'CustCodeFm',			@CustCodeTo as 'CustCodeTo',
-- 2004/02/11 Lester Wu
	@SecCustCodeFm as 'SecCustCodeFm',		@SecCustCodeTo as 'SecCustCodeTo',
------------------------------
	@VendorCodeFm as 'VendorCodeFm',		@VendorCodeTo as 'VendorCodeTo',
	@VendorCSNFm as 'VendorCSNFm',		@VendorCSNTo as 'VendorCSNTo',
-- 2004/02/17 Lester Wu
	@SalTemFm as 'SalTemFm',			@SalTemTo as 'SalTemTo',
-----------------------------
--	SubCodeFm,			@SubCodeTo,
	sod_cusitm	,			sod_itmno,			
	sod_venitm,			sod_itmdsc = MAX(sod_itmdsc),		
	sod_ordqty = SUM(sod_ordqty),		sod_shpqty = SUM(sod_shpqty),
	Outstand = SUM( sod_ordqty - sod_shpqty),
--	sod_subcde,	
	
	
	-- SYSETINF
	isnull(ysi_dsc,'') as 'ysi_dsc',

	--VNBASINF
	isnull(vbi_vensna,'') as 'vbi_vensna',
	
	-- CUBASINF
	pri.cbi_cusno as 'pricbi_cusno',		pri.cbi_cussna as 'pricbi_cussna',
	pri.cbi_cusnam as 'pricbi_cusnam',

	-- 2004/02/11 Lester Wu
	isnull(sec.cbi_cusno,'') as secCustNo,
	isnull(sec.cbi_cussna,'') as secCustSNa,
	isnull(sec.cbi_cusnam,'') as secCustName
	------------------------------
	--Lester Wu 2005-03-21 Retrieve company information form database
	,@compName as 'compName'

FROM	SCORDHDR
left join SCORDDTL on sod_cocde = soh_cocde and sod_ordno = soh_ordno
left join SYSETINF on sod_pckunt = ysi_cde and ysi_typ = '05'
left join CUBASINF pri on soh_cus1no = pri.cbi_cusno
left join VNBASINF on sod_venno = vbi_venno
left join CUBASINF sec on soh_cus2no = sec.cbi_cusno
left join SYSALREP sal on pri.cbi_salrep = sal.ysr_code1
WHERE	
((@cocde<>'UC-G' and  soh_cocde = @cocde)  or (@cocde = 'UC-G' and soh_cocde<>'MS'))
and 	((@CC = 'N' and soh_cus1no between @CustCodeFm and @CustCodeTo) or @CC = 'Y') 
and 	((@SCC = 'N' and soh_cus2no between @SecCustCodeFm and @SecCustCodeTo) or @SCC = 'Y') 
and	((@ST = 'N' and sal.ysr_saltem between @SalTemFm and @SalTemTo) or @ST = 'Y')
and	(@Saltem='' or @Saltem='S' or sal.ysr_saltem=@SalTem)
and	((@vc = 'N' AND sod_venno BETWEEN @VendorCodeFm and @VendorCodeTo) or @VC = 'Y')
and	(sod_ordqty - sod_shpqty) > 0
and 	soh_ordsts <> 'CLO'
--and	pri.cbi_salrep = sal.ysr_code1
--and	sod_pckunt *= ysi_cde and ysi_typ = '05'
--and 	sod_cocde = soh_cocde and sod_ordno = soh_ordno
--and	soh_cus1no = pri.cbi_cusno
--and 	soh_cus2no *= sec.cbi_cusno
--and	sod_venno = vbi_venno
GROUP BY	
sod_cusitm	,	sod_itmno,		sod_venitm,	
ysi_dsc,		vbi_vensna,	pri.cbi_cusno,		pri.cbi_cussna	,	pri.cbi_cusnam
,isnull(sec.cbi_cusno,''),	isnull(sec.cbi_cussna,''),	isnull(sec.cbi_cusnam,'')
ORDER BY 
pri.cbi_cusno,isnull(sec.cbi_cusno,''),
sod_cusitm	,	sod_itmno












GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00003] TO [ERPUSER] AS [dbo]
GO
