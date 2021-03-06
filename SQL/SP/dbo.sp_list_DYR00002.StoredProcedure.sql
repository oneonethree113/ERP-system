/****** Object:  StoredProcedure [dbo].[sp_list_DYR00002]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_DYR00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_DYR00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
***********************************************************************
*/

CREATE  procedure [dbo].[sp_list_DYR00002]
@cocde nvarchar(6),
@cocdelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@usrid nvarchar(30)
 
AS

BEGIN

SET NOCOUNT ON


create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]

declare	@fm nvarchar(100), @to nvarchar(100)

declare @strPart nvarchar(1000), @strRemain nvarchar(1000)

set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''


--#TEMP_CUS1NO
if ltrim(rtrim(@cus1nolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cus1nolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno like @strPart
		end
		else
		begin
			insert into #TEMP_INIT values (@strPart)
		end
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)
		if charindex('~', @strRemain) <> 0 
		begin
			set @fm = ltrim(left(@strRemain, charindex('~', @strRemain)-1))
			set @to = right(@strRemain, len(@strRemain) - charindex('~', @strRemain))
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CUS1NO
	select distinct tmp_init from #TEMP_INIT
end
else
begin

insert into #TEMP_CUS1NO
select 	distinct cbi_cusno
from CUBASINF (nolock)
left join SYSALREP on ysr_cocde = ' ' and  ysr_code1 = cbi_salrep
where
cbi_custyp in ('P','S') and --cbi_cussts = 'A' and
(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'SC' and yur_lvl = 0)
	or ysr_saltem in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 1)
	or cbi_cusno in (select yur_para from syusrright where yur_usrid = @usrid and yur_doctyp = 'SC' and yur_lvl = 2)
) and cbi_cusno > '50000'
order by cbi_cusno

end

SET NOCOUNT OFF




declare @flg_cus1no_table char(1)

if (select count(*) from #TEMP_CUS1NO) >= 1
	set @flg_cus1no_table = 'Y'
else
	set @flg_cus1no_table = 'N'

if @flg_cus1no_table = 'Y'
begin

select	
distinct 
--pri.cbi_cocde as [Company ID],
pri.cbi_cusno as [Customer No],
--pri.cbi_cusali as [Pri Alias Cust],	
pri.cbi_custyp as [Customer Type],
pri.cbi_cussts as [Customer Status],
pri.cbi_cussna as [Customer Short Name],
pri.cbi_cusnam as [Customer Name],
--pri.cbi_salrep as [Sales Rep],
--ysr_saltem as [Sales Team],
yup_usrnam as [Sales Rep],
pri.cbi_saltem as [Sales Team],
pri.cbi_salmgt as [Sales Manager],
pri.cbi_saldiv as [Sales Division],
pri.cbi_rounding as [Dp Rounding],
pri.cbi_cugrptyp_int as [Cust Group Int],
pri.cbi_cugrptyp_ext as [Cust Group Ext],
pri.cbi_cusrat as [Customer Rating],
pri.cbi_mrkreg as [Market Region],
pri.cbi_mrktyp as [Market Type],
cci_cntadr as [Address],
cci_cntstt as [State],
cci_cntcty as [Country Code],
isnull(yai1.ysi_dsc,'') as [Country Name],
cci_cntpst as [Zip Code],
cci_cnttyp as [Nature],
case isnull(yai13.ysi_dsc, '') when '' then '' else yai13.ysi_dsc end as [Nature Desc],
cci_cntdef as [Contact Default],
cci_cntctp as [Contact],
cci_cnttil as [Title],
cci_cntphn as [Phone],
cci_cntfax as [Fax],
cci_cnteml as [Email],
cai_cusagt as [Agent],
yai_stnam as [Agent Short Name],
cai_comrat as [Commission],
cpi_prctrm as [Price Term Code],
isnull(yai2.ysi_dsc,'') as [Price Term Desc],
cpi_paytrm as [Payment Term Code],
isnull(yai3.ysi_dsc,'') as [Payment Term Desc],
--isnull(cpi_prcsec,'') as [Gross Margin], 
--cpi_grsmgn as [Markup %], 
cpi_smpprd as [Sample Product Term],
yst1.yst_trmdsc as [Sample Product Term Desc],
cpi_smpfgt as [Sample Freight Term],
yst2.yst_trmdsc as [Sample Freight Term Desc],
csc_seccus as [Related Sec Customer],
sec.cbi_cussna as [Related Sec Cust Short Name],
sec.cbi_cusali as [Related Sec Alias Cust],
csc_cusrel as [Relation],
convert(varchar(20), pri.cbi_credat, 111) as [Create Date] ,
convert(varchar(20), pri.cbi_upddat, 111) as [Updated Date],
case ccv_ventyp when 'I' then 'INT' when 'E' then 'EXT' when 'J' then 'JV' end as [Vendor Type], 
ccv_cocde as [Vendor Company],
ccv_vendef as [Vendor Default],
--ccm_cat as [Price Category],  
--ccm_markup + ' - ' + fml.yfi_fml as [Price MarkUp Formula],
cbc_curcde as [Price Risk Currency],
cbc_rsklmt as [Price Risk Limit],  
cbc_rskuse as [Price Risk Used],
cbc_cdtlmt as [Price Risk Credit Limit],  
cbc_cdtuse as [Price Risk Credit Used],
pri.cbi_rmk as [Customer Remark]
from	
#TEMP_CUS1NO (nolock)
left join CUBASINF pri (nolock) on pri.cbi_cusno = tmp_cus1no
left OUTER join CUAGTINF (nolock) on pri.cbi_cusno = cai_cusno
left OUTER join SYAGTINF (nolock) on cai_cusagt = yai_agtcde
left OUTER join SYSALREP (nolock) on pri.cbi_salrep = ysr_code1
left OUTER join CUPRCINF (nolock ) on pri.cbi_cusno = cpi_cusno
left OUTER join CUSUBCUS (nolock) on  pri.cbi_cusno = csc_prmcus
left OUTER join CUCNTINF (nolock) on pri.cbi_cusno = cci_cusno 
left OUTER join CUBASINF sec (nolock) on csc_seccus = sec.cbi_cusno
left outer join sysetinf yai1 (nolock) on yai1.ysi_typ = '02' and cci_cntcty = yai1.ysi_cde
left outer join sysetinf yai2 (nolock) on yai2.ysi_typ = '03' and cpi_prctrm = yai2.ysi_cde
left outer join sysetinf yai3 (nolock) on yai3.ysi_typ = '04' and cpi_paytrm= yai3.ysi_cde
left outer join sysetinf yai13 (nolock) on yai13.ysi_typ = '13' and cci_cnttyp = yai13.ysi_cde
left outer join sysmptrm yst1 (nolock) on cpi_smpprd = yst1.yst_trmcde 
left outer join sysmptrm yst2 (nolock) on cpi_smpfgt  = yst2.yst_trmcde
left outer join CUMCOVEN (nolock) on pri.cbi_cusno = ccv_cusno
left outer join CUMCAMRK (nolock) on pri.cbi_cusno = ccm_cusno and ccv_ventyp = ccm_ventyp
left outer join syfmlinf fml (nolock) on fml.yfi_fmlopt = ccm_markup
left outer join CUBCR (nolock) on cbc_cusno = pri.cbi_cusno and cbc_cocde = ccv_cocde
left outer join SYUSRPRF (nolock) on yup_usrid = pri.cbi_srname
--where (cci_cnttyp='M' or cci_cnttyp='BUYR' or cci_cnttyp = 'MAGT')
where cci_delete <> 'Y'

order by pri.cbi_cusno

end 
else
begin

select	
distinct 
--pri.cbi_cocde as [Company ID],
pri.cbi_cusno as [Customer No],
--pri.cbi_cusali as [Pri Alias Cust],	
pri.cbi_custyp as [Customer Type],
pri.cbi_cussts as [Customer Status],
pri.cbi_cussna as [Customer Short Name],
pri.cbi_cusnam as [Customer Name],
--pri.cbi_salrep as [Sales Rep],
--ysr_saltem as [Sales Team],
yup_usrnam as [Sales Rep],
pri.cbi_saltem as [Sales Team],
pri.cbi_salmgt as [Sales Manager],
pri.cbi_saldiv as [Sales Division],
pri.cbi_rounding as [Dp Rounding],
pri.cbi_cugrptyp_int as [Cust Group Int],
pri.cbi_cugrptyp_ext as [Cust Group Ext],
pri.cbi_cusrat as [Customer Rating],
pri.cbi_mrkreg as [Market Region],
pri.cbi_mrktyp as [Market Type],
cci_cntadr as [Address],
cci_cntstt as [State],
cci_cntcty as [Country Code],
isnull(yai1.ysi_dsc,'') as [Country Name],
cci_cntpst as [Zip Code],
cci_cnttyp as [Nature],
case isnull(yai13.ysi_dsc, '') when '' then '' else yai13.ysi_dsc end as [Nature Desc],
cci_cntdef as [Contact Default],
cci_cntctp as [Contact],
cci_cnttil as [Title],
cci_cntphn as [Phone],
cci_cntfax as [Fax],
cci_cnteml as [Email],
cai_cusagt as [Agent],
yai_stnam as [Agent Short Name],
cai_comrat as [Commission],
cpi_prctrm as [Price Term Code],
isnull(yai2.ysi_dsc,'') as [Price Term Desc],
cpi_paytrm as [Payment Term Code],
isnull(yai3.ysi_dsc,'') as [Payment Term Desc],
--isnull(cpi_prcsec,'') as [Gross Margin], 
--cpi_grsmgn as [Markup %], 
cpi_smpprd as [Sample Product Term],
yst1.yst_trmdsc as [Sample Product Term Desc],
cpi_smpfgt as [Sample Freight Term],
yst2.yst_trmdsc as [Sample Freight Term Desc],
csc_seccus as [Related Sec Customer],
sec.cbi_cussna as [Related Sec Cust Short Name],
sec.cbi_cusali as [Related Sec Alias Cust],
csc_cusrel as [Relation],
convert(varchar(20), pri.cbi_credat, 111) as [Create Date] ,
convert(varchar(20), pri.cbi_upddat, 111) as [Updated Date],
case ccv_ventyp when 'I' then 'INT' when 'E' then 'EXT' when 'J' then 'JV' end as [Vendor Type], 
ccv_cocde as [Vendor Company],
ccv_vendef as [Vendor Default],
--ccm_cat as [Price Category],  
--ccm_markup + ' - ' + fml.yfi_fml as [Price MarkUp Formula],
cbc_curcde as [Price Risk Currency],
cbc_rsklmt as [Price Risk Limit],  
cbc_rskuse as [Price Risk Used],
cbc_cdtlmt as [Price Risk Credit Limit],  
cbc_cdtuse as [Price Risk Credit Used],
pri.cbi_rmk as [Customer Remark]
from	CUBASINF pri (nolock)
left OUTER join CUAGTINF (nolock) on pri.cbi_cusno = cai_cusno
left OUTER join SYAGTINF (nolock) on cai_cusagt = yai_agtcde
left OUTER join SYSALREP (nolock) on pri.cbi_salrep = ysr_code1
left OUTER join CUPRCINF (nolock ) on pri.cbi_cusno = cpi_cusno
left OUTER join CUSUBCUS (nolock) on  pri.cbi_cusno = csc_prmcus
left OUTER join CUCNTINF (nolock) on pri.cbi_cusno = cci_cusno 
left OUTER join CUBASINF sec (nolock) on csc_seccus = sec.cbi_cusno
left outer join sysetinf yai1 (nolock) on yai1.ysi_typ = '02' and cci_cntcty = yai1.ysi_cde
left outer join sysetinf yai2 (nolock) on yai2.ysi_typ = '03' and cpi_prctrm = yai2.ysi_cde
left outer join sysetinf yai3 (nolock) on yai3.ysi_typ = '04' and cpi_paytrm= yai3.ysi_cde
left outer join sysetinf yai13 (nolock) on yai13.ysi_typ = '13' and cci_cnttyp = yai13.ysi_cde
left outer join sysmptrm yst1 (nolock) on cpi_smpprd = yst1.yst_trmcde 
left outer join sysmptrm yst2 (nolock) on cpi_smpfgt  = yst2.yst_trmcde
left outer join CUMCOVEN (nolock) on pri.cbi_cusno = ccv_cusno
left outer join CUMCAMRK (nolock) on pri.cbi_cusno = ccm_cusno and ccv_ventyp = ccm_ventyp
left outer join syfmlinf fml (nolock) on fml.yfi_fmlopt = ccm_markup
left outer join CUBCR (nolock) on cbc_cusno = pri.cbi_cusno and cbc_cocde = ccv_cocde
left outer join SYUSRPRF (nolock) on yup_usrid = pri.cbi_srname
--where (cci_cnttyp='M' or cci_cnttyp='BUYR' or cci_cnttyp = 'MAGT')
where cci_delete <> 'Y'

order by pri.cbi_cusno


end




drop table #TEMP_INIT
drop table #TEMP_CUS1NO

END



GO
GRANT EXECUTE ON [dbo].[sp_list_DYR00002] TO [ERPUSER] AS [dbo]
GO
