/****** Object:  StoredProcedure [dbo].[sp_select_CUITMHIS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMHIS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMHIS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
















/*
=========================================================
Author:		Kenny Chan
Date:		6th FEB, 2002
Description:	Select data From SAORDDTL
Parameter:		1. Company
		2. Item No.
		3. Color Code
		4. Update_date	
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description          
 18-03-2003	Lewis To		Change when fields empty, range 
				from ='' instead of '0'
06-08-2003	Lewis To		Change to ignor company code of CUST ans system file               
=========================================================     
*/
CREATE    procedure [dbo].[sp_select_CUITMHIS]
                                                                                                                                                                                                                                                                 


@cis_cusno 	nvarchar(6) ,
@cis_seccus	nvarchar(6),
@itmnolist nvarchar(1000),
@cis_cusitm	nvarchar(20),
@cis_cusstyno	nvarchar(30)

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
' select ' +
'cis_cocde as "Comp",'+
'cis_cusno as "Pri Cust",'+
'cis_cussna as "P Cust Name",'+
'cis_seccus as "Sec Cust",'+
'cis_secsna as "S Cust Name",'+
'cis_itmno as "Item No",'+
'cis_itmdsc as "Itm Dsc",'+
'cis_cusitm as "Cust Itm",'+
'cis_cusstyno as "Cusstyno",'+
'cis_colcde as "Color",'+
'cis_coldsc as "Col Dsc",'+
'cis_cuscol as "Cust Col",'+
'cis_untcde as "UM",'+
'cis_conftr as "Con Ftr",'+
'cis_inrqty as "Inner",'+
'cis_mtrqty as "Master",'+
'cis_cft as "CFT",'+
'cis_cbm as "CBM",'+
'cis_hkprctrm as "HKPrcTerm",'+
'cis_ftyprctrm as "FtyPrcTerm",'+
'cis_trantrm as "TranTerm",'+
'cis_pckitr as "Pack Instr",'+
'cis_venno as "DV",'+
'cis_cusven as "CV",'+
'cis_prdven as "PV",'+
'cis_tradeven as "TV",'+
'cis_examven as "FA",'+
'cis_cus1no as "PriceKey1",'+
'cis_cus2no as "PriceKey2",'+
'cis_refdoc as "Ref Doc",'+
'cis_docdat as "Doc Date",'+
'cis_qutno as "Qut No",'+
'cis_qutseq as "Qut Seq",'+
'cis_cussku as "Cust SKU",'+
'cis_ordqty as "OrdQty",'+
'cis_moqchg as "MOQ Chg",'+
'cis_hrmcde as "HrmCode",'+
'cis_dtyrat as "DutyRate",'+
'cis_dept as "Dept",'+
'cis_typcode as "EAN or UPC",'+
'cis_code1 as "Code1",'+
'cis_code2 as "Code2",'+
'cis_code3 as "Code3",'+
'cis_cususdcur as "Retail1 Curr",'+
'cis_cususd as "Retail1 Prc",'+
'cis_cuscadcur as "Retail2 Curr",'+
'cis_cuscad as "Retail2 Prc",'+

"convert(varchar(10), dbo.remove_trailing_zeros(cis_inrdin)) + 'x' + convert(varchar(10),  dbo.remove_trailing_zeros(cis_inrwin))+ 'x' + convert(varchar(10), dbo.remove_trailing_zeros(cis_inrhin)) as 'Inner in DxWxH', " +
"convert(varchar(10), dbo.remove_trailing_zeros(cis_mtrdin)) + 'x' + convert(varchar(10),  dbo.remove_trailing_zeros(cis_mtrwin)) + 'x' + convert(varchar(10), dbo.remove_trailing_zeros(cis_mtrhin)) as 'Master in DxWxH', " +
"convert(varchar(10), dbo.remove_trailing_zeros(cis_inrdcm)) + 'x' + convert(varchar(10),  dbo.remove_trailing_zeros(cis_inrwcm)) + 'x' + convert(varchar(10), dbo.remove_trailing_zeros(cis_inrhcm)) as 'Inner cm DxWxH', " +
"convert(varchar(10), dbo.remove_trailing_zeros(cis_mtrdcm)) + 'x' + convert(varchar(10),  dbo.remove_trailing_zeros(cis_mtrwcm))+ 'x' + convert(varchar(10), dbo.remove_trailing_zeros(cis_mtrhcm)) as 'Master cm DxWxH', " +

-- 'convert(varchar(10),cis_inrdin) + "x" + convert(varchar(10),cis_inrwin) + "x" + convert(varchar(10),cis_inrhin) as "Inner in DxWxH",'+
-- 'convert(varchar(10),cis_mtrdin) + "x" + convert(varchar(10),cis_mtrwin) + "x" + convert(varchar(10),cis_mtrhin) as "Master in DxWxH",'+
-- 'convert(varchar(10),cis_inrdcm) + "x" + convert(varchar(10),cis_inrwcm) + "x" + convert(varchar(10),cis_inrhcm) as "Inner cm DxWxH",'+
-- 'convert(varchar(10),cis_mtrdcm) + "x" + convert(varchar(10),cis_mtrwcm) + "x" + convert(varchar(10),cis_mtrhcm) as "Master cm DxWxH",'+
'case cis_itmventyp when ''I'' then ''I - Internal'' when ''E'' then ''E - External'' when ''J'' then ''J - Joint Venture'' end as "IM VenTyp",'+
'case cis_tirtyp when ''1'' then ''Standard Tier'' when ''2'' then ''Company Definded'' end as "Tier",'+
'cis_moqunttyp as "MOQ Unit",'+
'cis_moq as "MOQ",'+
'cis_moacur as "MOA Curr",'+
'cis_moa as "MOA",'+
'cis_contopc as "ConvToPC",'+
'cis_pcprc as "PC Price",'+
'cis_ftytmpitm as "FtyTempItm",'+
'cis_year as "Year",'+
'cis_season as "Season"'+
' from CUITMHIS (nolock)'


set @w = @w + ' where ' +  
 'cis_cusno = ''' + @cis_cusno  + '''' 

if @cis_seccus <> '' 
		begin 
				set @w = @w + ' and cis_seccus = ''' +@cis_seccus  + '''' 
		end 
	
if @cis_cusitm <>''
		begin
			set @w = @w  + ' and cis_cusitm = ''' +@cis_cusitm  + '''' 
		end
	
if @cis_cusstyno <>''
		begin
			set @w = @w  + ' and cis_cusstyno = ''' +@cis_cusstyno  + '''' 
		end
	 

if @itmnolist <>''
		begin
			set @w = @w  +  ' and cis_itmno in ( Select tmp_itmno from #TEMP_ITMNO (nolock))'
		end

	
	
exec(@s+@w)




drop table #TEMP_INIT 
drop table #TEMP_ITMNO  

end












GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMHIS] TO [ERPUSER] AS [dbo]
GO
