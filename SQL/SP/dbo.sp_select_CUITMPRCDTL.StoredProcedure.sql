/****** Object:  StoredProcedure [dbo].[sp_select_CUITMPRCDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMPRCDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMPRCDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

Create procedure [dbo].[sp_select_CUITMPRCDTL]
    
@cid_cusno 	nvarchar(6) ,
@cid_seccus	nvarchar(6),
@itmnolist nvarchar(1000),
@cid_cusitm	nvarchar(20),
@cid_cusstyno	nvarchar(30)

---------------------------------------------- 

 
AS
declare @i as nvarchar(4000)
declare @s as nvarchar(4000)
declare @s1 as nvarchar(4000)
declare @f as nvarchar(4000)
declare @w as nvarchar(4000)
declare @g as nvarchar(4000)
declare @o as nvarchar(4000)

begin

create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]

declare	@fm nvarchar(100), @to nvarchar(100)

declare @strPart nvarchar(1000), @strRemain nvarchar(1000)


set @i = ''
set @s = ''
set @f = ''
set @w = ''
set @g = ''
set @o = ''

set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''

--#TEMP_ITMNO
if ltrim(rtrim(@itmnolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @itmnolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_alsitmno from imbasinf (nolock) where ibi_alsitmno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno like @strPart
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno like @strPart
			union all
			select ibi_alsitmno from imbasinf (nolock) where ibi_alsitmno like @strPart
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
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_alsitmno from imbasinf (nolock) where ibi_alsitmno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock)  where ibi_itmno like @strRemain
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno like @strRemain
			union all
			select ibi_alsitmno from imbasinf (nolock) where ibi_alsitmno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_ITMNO
	select distinct tmp_init from #TEMP_INIT
end


set @s = @s +
" select " +
--Key
--"cid_cocde as 'Comp',"  +
--"cid_cusno as 'Pri Cust'," +
--"cis_cussna as 'Pri Cust Name', " +
"cid_seccus as 'Sec Cust', " +
"cis_secsna as 'Sec Cust Name', " +
"cid_itmno as 'Item No', " +
--"cis_itmdsc as 'Itm Dsc', " +
"cid_colcde as 'Color Code', " +
"cis_coldsc as 'Color Desc', " +
"cid_untcde as 'U/M', " +
"cid_conftr as 'Con Ftr', " +
"cid_inrqty as 'Inner', " +
"cid_mtrqty as 'Master', " +

"cis_cft as 'CFT', " +
"cis_cbm as 'CBM', " +
"cid_hkprctrm as 'HK Prc Term', " +
"cid_ftyprctrm as 'Fty Prc Term', " +
"cid_trantrm as 'Tran Term', " +

"cis_pckitr as 'Packing Instruction', " +
--Source
"cid_refdoc as 'Ref Doc', " +
"cid_refseq as 'Ref Seq', " +
"cid_docdat as 'Doc Date', " +
--"case cid_apvsts when 'N' then 'N - No Approval Required' when 'W' then 'W - Waiting For Approval' when 'Y' then 'Y - Approval Granted' Else cid_apvsts END as 'Approval Status', " +
--"case cid_qutitmsts when 'A' then 'A - Active' when 'W' then 'W - Waiting For Approval' when 'TBC' then 'TBC - To Be Confirmed' Else cid_qutitmsts END as 'QU Item Status', " + 

"cid_cus1no as 'PriceKey (Pri)', " +
"cid_cus2no as 'PriceKey (Sec)', " +
"convert(varchar, cid_effdat, 101) as 'Eff Date', " +
"convert(varchar, cid_expdat, 101) as 'Exp date', " +
"cis_venno as 'DV', " +
"cis_prdven as 'PV', " +

"cip_fcurcde as 'Fty Curr', " +
"cip_ftycst as 'Fty Cost', " +
"cip_bomcst as 'BOM Cost', " +
"cip_ftyprc as 'FTY Price', " +
"cip_curcde as 'Curr', " +
"cip_basprc as 'Basic Price', " +
"cip_stdprc as 'Std Price', " +
"cip_markup as 'MU %', " +
"cip_mumin as 'Min MU %', " +
"cip_muminprc as 'Min MU Price', " +
"cip_pckcst as 'Packing Cost', " +
"cip_commsn as 'Comm %', " +
"cip_itmcom as 'Item Comm $', " +
"case isnull(cid_scref, '') when '' then cip_adjprc else cis_untprc end as 'Adj Price', " +
"cis_oneprc as 'OTP', " +
"ltrim(str(year(cip_qutdat))) + '-' + right('0' + ltrim(str(month(cip_qutdat))), 2) as 'Period', " +	

"cid_cusitm as 'Cust Item No', " +
"cid_cusstyno as 'Cust Style No', " +
"cis_cuscol as 'Cust Color', " +
"cis_cussku as 'Cust SKU', " +


-- "cis_cusven as 'CV', " +
-- "cis_tradeven as 'TV', " +
-- "cis_examven as 'FA', " +

"cis_ordqty as 'OrdQty', " +
--"cis_untprc as 'Unit Selling Price', " + 
"cis_hrmcde as 'HSTU/Tariff #', " +
"cis_dtyrat as 'Duty %', " +
"cis_dept as 'Dept', " +
"cis_typcode as 'EAN or UPC', " +
"cis_code1 as 'Code (Merchandise)', " +
"cis_code2 as 'Code (Inner)', " +
"cis_code3 as 'Code (Carton)', " +

"cis_cususdcur as 'Retail 1 Curr', " +
"cis_cususd as 'Retail 1 Price', " +
"cis_cuscadcur as 'Retail 2 Curr', " +
"cis_cuscad as 'Retail 2 Price', " +
"convert(varchar(10), dbo.remove_trailing_zeros(cis_inrdin)) + 'x' + convert(varchar(10),  dbo.remove_trailing_zeros(cis_inrwin))+ 'x' + convert(varchar(10), dbo.remove_trailing_zeros(cis_inrhin)) as 'Inner in (DxWxH)', " +
"convert(varchar(10), dbo.remove_trailing_zeros(cis_mtrdin)) + 'x' + convert(varchar(10),  dbo.remove_trailing_zeros(cis_mtrwin)) + 'x' + convert(varchar(10), dbo.remove_trailing_zeros(cis_mtrhin)) as 'Master in (DxWxH)', " +
"convert(varchar(10), dbo.remove_trailing_zeros(cis_inrdcm)) + 'x' + convert(varchar(10),  dbo.remove_trailing_zeros(cis_inrwcm)) + 'x' + convert(varchar(10), dbo.remove_trailing_zeros(cis_inrhcm)) as 'Inner cm (DxWxH)', " +
"convert(varchar(10), dbo.remove_trailing_zeros(cis_mtrdcm)) + 'x' + convert(varchar(10),  dbo.remove_trailing_zeros(cis_mtrwcm))+ 'x' + convert(varchar(10), dbo.remove_trailing_zeros(cis_mtrhcm)) as 'Master cm (DxWxH)', " +

--"convert(varchar(10), cis_mtrdin) + 'x' + convert(varchar(10), cis_mtrwin) + 'x' + convert(varchar(10), cis_mtrhin) as 'Master in (DxWxH)', " +
--"convert(varchar(10), cis_inrdcm) + 'x' + convert(varchar(10), cis_inrwcm) + 'x' + convert(varchar(10), cis_inrhcm) as 'Inner cm (DxWxH)', " +
--"convert(varchar(10), cis_mtrdcm) + 'x' + convert(varchar(10), cis_mtrwcm) + 'x' + convert(varchar(10), cis_mtrhcm) as 'Master cm (DxWxH)', " +

"case cis_itmventyp when 'I' then 'I - Internal' when 'E' then 'E - External' when 'J' then 'J - Joint Venture' end as 'Ven Type', " +
"case cis_tirtyp when '1' then 'Standard Tier' when '2' then 'Company Defined' end as 'Tier Type', " +
"cis_moqunttyp as 'MOQ Unit', " +
"cis_moq as 'MOQ', " +
"cis_moacur as 'MOA Curr', " +
"cis_moa as 'MOA', " +
"cis_contopc as 'Convert To PC', " +
"cis_pcprc as 'PC Price', " +
"cis_ftytmpitm as 'Fty Temp Item', " + 

"cis_year as 'Year', " +
"cis_season as 'Season', " + 


--Prc Part
	
--"case cip_qutdat when '19000101' then '' else ltrim(str(year(cip_qutdat))) + '-' + right('0' + ltrim(str(month(cip_qutdat))), 2) end as 'Period', " +

--"case cid_mode when 'Q' then 'Quotation' when 'SC' then 'SC' when 'QI' then 'Quotation Create' when 'QU' then 'Quotation Update' when 'EU' then 'Quotation Excel Update' when 'SI' then 'SC Create' when 'SU' then 'SC Update' when 'SA' then 'SC Approval' when 'SY' then 'System Init' Else cid_mode end as 'Mode', " +
--"cid_scref as 'SC RefDoc', " +
"cid_updusr as 'Update User', " +
"cid_seqnum as 'Seq', " +
"cid_credat as 'Create Date' " +

"from CUITMPRCDTL"


set @w = @w + ' where ' +  
 'cid_cusno = ''' + @cid_cusno  + '''' 
	
if @cid_cusitm <>''
		begin
			set @w = @w  + ' and cid_cusitm = ''' +@cid_cusitm  + '''' 
		end
	
if @cid_cusstyno <>''
		begin
			set @w = @w  + ' and cid_cusstyno = ''' +@cid_cusstyno  + '''' 
		end
	 

if @itmnolist <>''
		begin
			set @w = @w  +  ' and cid_itmno in ( Select tmp_itmno from #TEMP_ITMNO (nolock))'
		end

if @cid_seccus <> '' 
		begin 
				set @w = @w + ' and cid_seccus = ''' +@cid_seccus  + '''' 
		end 
		
		
--set @o = 'ORDER BY cid_credat'
set @o = 'ORDER BY cid_cusno, cid_seccus, cid_itmno, cid_colcde, cid_untcde, cid_conftr, cid_inrqty, cid_mtrqty, cid_hkprctrm, cid_ftyprctrm, cid_trantrm, cid_seqnum desc'
		

exec(@s+@w+@o)




drop table #TEMP_INIT 
drop table #TEMP_ITMNO  

end






GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMPRCDTL] TO [ERPUSER] AS [dbo]
GO
