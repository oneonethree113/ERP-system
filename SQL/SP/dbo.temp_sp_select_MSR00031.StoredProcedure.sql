/****** Object:  StoredProcedure [dbo].[temp_sp_select_MSR00031]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[temp_sp_select_MSR00031]
GO
/****** Object:  StoredProcedure [dbo].[temp_sp_select_MSR00031]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/***********************************************************************************************************************************************
Modification History
************************************************************************************************************************************************
Modified by		Modified on		Description
************************************************************************************************************************************************
Lester Wu			2005-04-02		replace ALL with UC-G, exclude MS from UC-G, retrieve company name from database
************************************************************************************************************************************************/


-- Checked by Allan Yuen at 27/07/2003
-- Rem ibi_itmno by Lester Wu on 2004/03/24

-- temp_sp_select_MSR00031 'UCPP','10004','10004','','','','','01/01/2000','12/31/2000','ALL','0','mis'


CREATE     PROCEDURE [dbo].[temp_sp_select_MSR00031]

@cocde		as nvarchar(8),
-- @From_Inv	as nvarchar(20),
-- @To_Inv		as nvarchar(20),
@From_PriCus	as nvarchar(6),
@To_PriCus	as nvarchar(6),
@VnFm		as nvarchar(6),
@VnTo		as nvarchar(6),
@SCFm		as nvarchar(4),
@SCTo		as nvarchar(4),
@From_Issdat	as nvarchar(10),
@To_Issdat	as nvarchar(10),
@shp_Status     	 as nvarchar(10),
@SortBy		as nvarchar(1),
@Usrid		as nvarchar(30)

AS


--Lester Wu 2005-04-02, retrieve company name from database----------------------------------------
declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde<>'UC-G'
begin
	select @compName = yco_conam from sycominf where yco_cocde = @cocde
end
---------------------------------------------------------------------------------------------------------------------


SELECT


hih_cocde,
hih_shpsts,
hih_cus1no, 
pri_cbi_cussna = isnull(Pri.cbi_cussna, ''),
hih_cus2no, 
sec_cbi_cussna = isnull(Sec.cbi_cussna, ''),
hid_invno, 
hiv_invdat = convert(nvarchar(10), hiv_invdat, 101), 
hid_shpno, 
hih_slnonb = convert(nvarchar(10), hih_slnonb, 101),
hiv_prctrm = isnull(A.ysi_dsc,''),
hiv_paytrm = isnull(B.ysi_dsc,''),
hiv_untamt = isnull(hiv_untamt,''),
hiv_ttlamt = sum(round(isnull(hid_shpqty * hid_selprc,0),2)), 
@cocde as input_cocde,
@From_PriCus as input_opt1Fm_cus1no,
@To_PriCus as input_opt1To_cus2no,
@VnFm as input_VnFm,
@VnTo as input_VnTo,
@SCFm as input_SCFm,
@SCTo as input_SCTo,
@From_Issdat as input_opt2Fm_invdat,
convert(nvarchar(10),@To_Issdat,101) as input_opt2To_invdat, 
@shp_Status as input_opt3_invsts,
@SortBy as input_SortBy,
Case @SortBy when '0' then hid_invno else '' end  as input_SortKey,
@compName as 'compName'

FROM
	SHIPGHDR
		left join CUBASINF Pri on hih_cus1no = Pri.cbi_cusno
		left join CUBASINF Sec on hih_cus2no = Sec.cbi_cusno,

	SHIPGDTL, 
	SHINVHDR 
		left join SYSETINF A on hiv_prctrm = A.ysi_cde and A.ysi_typ = '03'
		left join SYSETINF B on hiv_paytrm = B.ysi_cde and B.ysi_typ = '04',
	SCORDDTL

	--,
	--v_imbasinf_rpt 

/*
left join SHIPGDTL on hih_cocde = hid_cocde and hih_shpno = hid_shpno
left join SHINVHDR on hih_cocde = hiv_cocde and hid_shpno = hiv_shpno and hid_invno = hiv_invno
--left join CUBASINF Pri on hih_cocde = Pri.cbi_cocde and hih_cus1no = Pri.cbi_cusno
--left join CUBASINF Sec on hih_cocde = Sec.cbi_cocde and hih_cus2no = Sec.cbi_cusno
left join CUBASINF Pri on hih_cus1no = Pri.cbi_cusno
left join CUBASINF Sec on hih_cus2no = Sec.cbi_cusno

left join SCORDDTL on hih_cocde = sod_cocde and hid_ordno = sod_ordno and hid_ordseq = sod_ordseq

--left join SYSETINF A on hih_cocde = A.ysi_cocde and hiv_prctrm = A.ysi_cde and A.ysi_typ = '03'
--left join SYSETINF B on hih_cocde = B.ysi_cocde and hiv_paytrm = B.ysi_cde and B.ysi_typ = '04'
left join SYSETINF A on hiv_prctrm = A.ysi_cde and A.ysi_typ = '03'
left join SYSETINF B on hiv_paytrm = B.ysi_cde and B.ysi_typ = '04'
*/




WHERE 
		hih_cocde = hid_cocde
	and	hih_shpno = hid_shpno 
	and	hid_cocde = sod_cocde 
	and 	hid_ordno = sod_ordno 
	and 	hid_ordseq = sod_ordseq 
	and 	hid_cocde = hiv_cocde 
	and 	hid_shpno = hiv_shpno 
	and 	hid_invno = hiv_invno
	and	hid_itmno = sod_itmno
--	and 	left(hid_colcde,10) = left(sod_colcde,10)

-- 2004/03/23 Lester Wu
--	and	ltrim(rtrim(sod_itmno)) = ltrim(rtrim(ibi_itmno))
--	and	sod_itmno = ibi_itmno
-- 2004/02/11 Lester Wu

--	and	hid_cocde = @cocde 
--Lester Wu 2005-04-02, replace ALL with UC-G
--	and	(@cocde='ALL' or hih_cocde = @cocde)
	and	((@cocde='UC-G' and hih_cocde <> 'MS') or hih_cocde = @cocde)

and 	((@To_PriCus  <> '' and  hih_cus1no Between @From_PriCus   and @To_PriCus ) or @To_PriCus = '')

--and 	hiv_invdat between convert(datetime,  @From_Issdat , 121) and convert(datetime, @to_Issdat, 121) 
and 	hiv_invdat >=  convert(datetime,  @From_Issdat , 121) and hiv_invdat <=   convert(datetime, @to_Issdat, 121) 

/*and 	((hih_issdat between @From_Issdat + ' 00:00:00' and @to_Issdat + ' 23:59:59.998' and @From_Issdat <> '') or
	(hih_issdat between  '01/01/1900' and  '01/01/3000' and @From_Issdat = ''))
*/
and	((hih_shpsts = @shp_Status and @shp_Status <> '') or @shp_Status = 'ALL')
and	((hid_venno between @VnFm and @VnTo and @VnFm <> '') or @VnFm = '')
and	((sod_subcde between @SCFm and @SCTo and @SCFm <> '') or @SCFm = '')
group by	
	hih_cocde, 
	hih_shpsts, 
	hih_cus1no, 
	isnull(Pri.cbi_cussna, ''), 
	hih_cus2no, isnull(Sec.cbi_cussna, ''),
	hid_invno, 
	convert(nvarchar(10), hiv_invdat, 101),  
	hid_shpno, convert(nvarchar(10), hih_slnonb, 101),
	isnull(A.ysi_dsc,''), 
	isnull(B.ysi_dsc,''), 
	isnull(hiv_untamt,'')
order by	
	Case @SortBy when '0' then hid_invno else '' end, hih_cus1no, hih_cus2no, hid_invno













GO
GRANT EXECUTE ON [dbo].[temp_sp_select_MSR00031] TO [ERPUSER] AS [dbo]
GO
