/****** Object:  StoredProcedure [dbo].[sp_select_MSR00031_Bak]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00031_Bak]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00031_Bak]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_select_MSR00031_Bak]

@Cocde		as nvarchar(8),
-- @From_Inv	as nvarchar(20),
-- @To_Inv		as nvarchar(20),
@From_PriCus	as nvarchar(6),
@To_PriCus	as nvarchar(6),
@From_Issdat	as nvarchar(10),
@To_Issdat	as nvarchar(10),
@shp_Status     	 as nvarchar(10),
-- @SortBy		as nvarchar(1),
@Usrid		as nvarchar(30)

AS

declare @sql as nvarchar(4000)

set @sql = '

SELECT

DISTINCT

hih_cocde,
hih_shpsts,
hih_cus1no, 
pri_cbi_cussna = isnull(Pri.cbi_cussna, ''''),
hih_cus2no, 
sec_cbi_cussna = isnull(Sec.cbi_cussna, ''''),
hid_invno, 
hiv_invdat = convert(nvarchar(10), hiv_invdat, 101), 
hid_shpno, 
hih_slnonb = convert(nvarchar(10), hih_slnonb, 101),
hiv_prctrm = isnull(A.ysi_dsc,''''),
hiv_paytrm = isnull(B.ysi_dsc,''''),
hiv_untamt = isnull(hiv_untamt, ''''),
hiv_ttlamt = isnull(hiv_ttlamt,0), ' +

'''' + @From_PriCus + ''',''' +
'' + @To_PriCus + ''',''' +
'' + @From_Issdat + ''',''' +
'' + @To_Issdat + ''',''' +
'' + @shp_Status + '''' +

' FROM

SHIPGHDR
left join SHIPGDTL on hih_cocde = hid_cocde and hih_shpno = hid_shpno
left join SHINVHDR on hih_cocde = hiv_cocde and hid_shpno = hiv_shpno and hid_invno = hiv_invno
left join CUBASINF Pri on hih_cocde = Pri.cbi_cocde and hih_cus1no = Pri.cbi_cusno
left join CUBASINF Sec on hih_cocde = Sec.cbi_cocde and hih_cus2no = Sec.cbi_cusno
left join SYSETINF A on hih_cocde = A.ysi_cocde and hiv_prctrm = A.ysi_cde and A.ysi_typ = ''03''
left join SYSETINF B on hih_cocde = B.ysi_cocde and hiv_paytrm = B.ysi_cde and B.ysi_typ = ''04''
WHERE

hid_cocde = ' + '''' + @cocde + '' + 

''' and hih_cus1no between ''' +

case @From_PriCus when '' then '0' else @From_PriCus end

+ ''' and ''' +

case @To_PriCus  when '' then 'Z' else @To_PriCus end

+ ''' and hiv_invdat between ''' + 

case @From_Issdat when '' then '01/01/1900' else @From_Issdat + ' 00:00:00' end

+ ''' and ''' +

case @to_Issdat when '' then '01/01/3000' else @to_Issdat + ' 23:59:59.998' end

 + 

case @shp_Status  when  'ALL' then '' else ''' and hih_shpsts = ''' + @shp_Status end

+ '''' +

' ORDER BY hih_cus1no, hih_cus2no, hid_invno '


exec(@sql)



GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00031_Bak] TO [ERPUSER] AS [dbo]
GO
