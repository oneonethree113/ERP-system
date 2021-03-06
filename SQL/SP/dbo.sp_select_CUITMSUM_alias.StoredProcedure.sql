/****** Object:  StoredProcedure [dbo].[sp_select_CUITMSUM_alias]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMSUM_alias]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMSUM_alias]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/************************************************************************
Author:		Carlos Lui
Date:		06 Jun, 2012
Description:	Select data From CUITMSUM
Parameter:		1. Company
		2. Customer Code
************************************************************************
*/


CREATE   procedure [dbo].[sp_select_CUITMSUM_alias]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cis_cocde nvarchar(6) ,
@cis_itmno nvarchar(20),
@cis_cusitm nvarchar(20),
@cis_seccus nvarchar(6),   
@cis_cusno nvarchar(6),
@cis_cusstyno nvarchar(30),
@gsflgcst char(1),
@gsflgcstext char(1)   
---------------------------------------------- 
 
AS

declare @i as nvarchar(4000)
declare @s as nvarchar(4000)
declare @s2 as nvarchar(4000)
declare @f as nvarchar(4000)
declare @w as nvarchar(4000)
declare @g as nvarchar(4000)
declare @o as nvarchar(4000)

begin

	set @i = ''
	set @s = ''
	set @f = ''
	set @w = ''
	set @g = ''
	set @o = ''
	
	set @i = ' declare @gsflgcst char(1), @gsflgcstext char(1) '
	set @i = @i + '	set @gsflgcst = ' + @gsflgcst
	set @i = @i + ' set @gsflgcstext = ' + @gsflgcstext
	
	set @s = @s +' Select ' +
	'cis_cocde as "Company Code",'+
	'p.cbi_cusno as "Pri. Cust (Previous)",'+
	'cis_seccus as "Sec. Cust. No.",' 
	if @cis_seccus = '' begin set @s = @s +  '''' + '' + '''' + ' as "Sec. Cust. (Previous)", ' end
	if @cis_seccus <> '' begin set @s = @s + ' s.cbi_cusno  as "Sec. Cust. (Previous)", ' end 
	set @s = @s + 'cis_secsna as "Sec.Cust. Name",' +
	'cis_cusitm as "Cust_Item_No",' +
	'cis_itmno as "Item_No",' +
	'cis_cusstyno as "Cust_Style_No",' +
	'cis_ftytmpitm as "Fty_Temp_No",' + 
	'case isnull(ibi_itmsts,''HIS'')' + 
			'when ''CMP'' then ''CMP - Active Item with complete Info.'' ' + 
			'when ''INC'' then ''INC - Active Item with incomplete Info.'' ' + 
			'when ''HLD'' then ''HLD - Active Item Hold by the system'' ' + 
			'when ''DIS'' then ''DIS - Discontinue Item'' ' + 
			'when ''INA'' then ''INA - Inactive Item'' ' + 
			'when ''CLO'' then ''CLO - Closed (UCP Item)'' ' + 
			'when ''TBC'' then ''TBC - To be confirmed Item.'' ' + 
			'when ''OLD'' then ''OLD - Old Item.'' ' +
			'else ''HIS - History'' end ' + 
			'as ''Item Status'',' + 
	'ivi_venitm as "Ven_Item_No",' +
	'case isnull(vbi_vensts,'''') ' + 
			'when ''A'' then ''A - Active'' ' + 
			'when ''D'' then ''D - Discontinue'' ' + 
			'when ''I'' then ''I - Inactive'' ' + 
			'else '''' end as ''Vendor Status'',' + 
	'cis_itmdsc as "Item Desc.",' +
	'cis_colcde as "Color Code",' +
	'cis_coldsc as "Color Desc.",'  +
	'cis_curcde as "CCY",' +
	'case when cis_curcde <> imu_bcurcde then 
	 round(imu_basprc * yce_selrat  ,4)
	else
	 round(imu_basprc ,4) 
	end
	as ''Basic Price'',' +
	'cis_selprc as "Selling Price",' +
	'case when year(cis_qutdat) = 1900 then '''' else
	ltrim(str(year(cis_qutdat))) + ''-'' + right(''0'' +  ltrim(str( month(cis_qutdat))),2) end as ''CIH Period'',' +	
	'case when year(cis_imqutdat) = 1900 then '''' else
	ltrim(str(year(cis_imqutdat))) + ''-'' + right(''0'' +  ltrim(str( month(cis_imqutdat))),2) end as ''IM Period'',' +	
	'isnull(cis_moqchg,0) as "MOQ Charges %",' +
	'cis_cus1no as "Price Key - Cust 1",' +
	'cis_cus2no as "Price Key - Cust 2",' +
	'cis_hkprctrm as "Price Key - HK Price Term",' +
	'cis_ftyprctrm as "Price Key - FTY Price Term",' +
	'cis_trantrm as "Price Key - Transport Term",' +
	'cis_effdat as "Price Key - Effective Date",' +
	'cis_expdat as "Price Key - Expiry Date",' +
	'isnull(cis_netselprc,cis_selprc)  as "Net Selling Price",' +
	' case cis_itmventyp
	 when ''I'' then case @gsflgcst when ''1'' then imu_curcde else ''---'' end
	 when ''J'' then case @gsflgcst when ''1'' then imu_curcde else ''---'' end
	 when ''E'' then case @gsflgcstext when ''1'' then imu_curcde else ''---'' end
	 end as "Factory CCY",' +
	' case cis_itmventyp
	 when ''I'' then case @gsflgcst when ''1'' then imu_ftycst else 0 end
	 when ''J'' then case @gsflgcst when ''1'' then imu_ftycst else 0 end
	 when ''E'' then case @gsflgcstext  when ''1'' then imu_ftycst else 0 end
	 end as "Factory Cost",' +
	' case cis_itmventyp
	 when ''I'' then case @gsflgcst when ''1'' then imu_ftyprc else 0 end
	 when ''J'' then case @gsflgcst when ''1'' then imu_ftyprc else 0 end
	 when ''E'' then case @gsflgcstext when ''1'' then imu_ftyprc else 0 end
	 end as "Factory Price",' 
	
	set @s2 = 
	'case isnull(cis_moq,0) when 0 then '''' else str(cis_moq) end  as ''Comp MOQ'',' + 
	'case isnull(cis_moa,0) when 0 then '''' else cis_moacur end as ''Comp MOA Currency'',' + 
	'case isnull(cis_moa,0) when 0 then '''' else str(cis_moa) end  as ''Comp MOA'',' + 
	'case isnull(cis_moq,0) when 0 then '''' else ltrim(str(cis_moq)) end  as ''CIH MOQ'',' + 
	'cis_moqunttyp as ''CIH MOQ Unt'',' + 
	'case isnull(cis_moa,0) when 0 then '''' else cis_moacur end as ''CIH MOA Currency'',' + 
	'case isnull(cis_moa,0) when 0 then '''' else ltrim(str(cis_moa)) end  as ''CIH MOA'',' + 
	'cis_untcde as "U/M",' + 
	'cis_inrqty as "Inner",' +
	'cis_mtrqty as "Master",' +
	'cis_cft as "CFT",' +
	'cis_cbm as "CBM",' +
	'cis_cussku as "Cust. SKU No.",' +
	'cis_refdoc as "Ref. Doc.",'  + 
	'cis_docdat as "Last Doc. Date",' +
	'cis_cuscol as "Customer Color Code",' +
	'cis_hrmcde as "HSTU / Tariff #",' +
	'cis_dtyrat as "Duty %",' +
	'cis_dept as "Department", ' +
	'cis_typcode as "EAN or UPC",' +
	'cis_code1 as "EAN or UPC Code 1",' +
	'cis_code2 as "EAN or UPC Code 2",' +
	'cis_code3 as "EAN or UPC Code 3",' +
	'cis_cususd as "Customer Retail (USD)",' +
	'cis_cuscad as "Customer Retail (CAD)",' +
	'cis_inrdcm as "Inner L (cm)",' +
	'cis_inrwcm as "Inner W (cm)",' +
	'cis_inrhcm as "Inner H (cm)",' +
	'cis_mtrdcm as "Master L (cm)",' +
	'cis_mtrwcm as "Master W (cm)",' +
	'cis_mtrhcm as "Master H (cm)",' +  
	'cis_inrdin as "Inner L (in)",' +
	'cis_inrwin as "Inner W (in)",' +
	'cis_inrhin as "Inner H (in)",' +
	'cis_mtrdin as "Master L (in)",' +
	'cis_mtrwin as "Master W (in)",' +
	'cis_mtrhin as "Master H (in)",' +
	'cis_ordqty as "Order Qty",' +
	'cis_pckitr as "Packing Instruction",' +
	'cis_conftr as "U/M Factor",' +
	'cis_contopc as "Convert To PC",' +
	'cis_pcprc as "Price For PC",' +
	'cis_credat as "Create Date", ' +  
	'cis_upddat as "Update Date"' 
	
	set @f = @f + 
	' from CUITMSUM (nolock) 
	left join IMBASINF (nolock) on cis_itmno = ibi_itmno 
	left join VNBASINF(nolock) on ibi_venno = vbi_venno
	left join IMBOMASS (nolock) on cis_itmno = iba_itmno
	left join SYCONFTR (nolock) on cis_untcde = ycf_code1 and ycf_code2 = ''PC'' 
	LEFT JOIN IMVENINF (nolock) ON IVI_ITMNO = CIS_ITMNO AND IVI_DEF = ''Y''
	left join IMPRCINF (nolock) on 
	(ivi_venitm = imu_itmno or ivi_itmno = imu_itmno)
	and ibi_typ = imu_typ
	and imu_ventyp = ''D''
	and cis_cus1no = imu_cus1no
	and cis_cus2no = imu_cus2no
	and cis_hkprctrm = imu_hkprctrm
	and cis_ftyprctrm = imu_ftyprctrm
	and cis_trantrm = imu_trantrm
	and cis_untcde = imu_pckunt
	and cis_inrqty = imu_inrqty
	and cis_mtrqty = imu_mtrqty 
	and cis_conftr = imu_conftr
	and imu_venno not in (''0005'',''0006'',''0007'',''0008'',''0009'')
	left join IMPCKINF (nolock) on (ipi_itmno = imu_itmno and ipi_pckunt = imu_pckunt and ipi_inrqty = imu_inrqty and ipi_mtrqty = imu_mtrqty and ipi_conftr = imu_conftr) 
	left join sycurex on yce_frmcur = imu_bcurcde and yce_tocur = cis_curcde and yce_iseff = ''Y'' ,' +
	' CUBASINF p  (nolock) 
	left join CUPRCINF (nolock) on p.cbi_cusno = cpi_cusno '

	 if @cis_seccus <> '' begin set @f = @f +  ', CUBASINF s (nolock) '  end
	
	set @w = @w + ' where ' +	
	'(( cis_cusno = ''' +@cis_cusno  + ''' and p.cbi_cusno = cis_cusno ) or (p.cbi_cusali =' + '''' +
	@cis_cusno + ''' and p.cbi_cusno = cis_cusno)) ' 

	if @cis_seccus = '' 
		begin 
			set @w = @w + ' and cis_seccus = ''' + @cis_seccus + '''' 
		end 
	else
		begin 
			set @w = @w + ' and (( cis_seccus = ''' +@cis_seccus  + ''' and s.cbi_cusno = cis_seccus ) or (s.cbi_cusali =' + '''' +
			@cis_seccus + ''' and s.cbi_cusno = cis_seccus)) ' 
		end
	
	if @cis_itmno <> '' 
	begin
		set @w = @w + ' and cis_itmno  in  '
		set @w = @w + ' 	(Select ibi_itmno  from imbasinf (nolock) where ibi_itmno =  ''' + @cis_itmno + '''' +'  or ibi_alsitmno = ''' + @cis_itmno + ''''  
		set @w = @w + ' 	union '
		set @w = @w + ' select ibi_alsitmno from imbasinf (nolock) where ibi_itmno = ''' + @cis_itmno + ''''  
		set @w = @w + ' 	union '
		set @w = @w + ' 	Select ibi_itmno  from imbasinfh (nolock) where ibi_itmno =  ''' + @cis_itmno + '''' +'  or ibi_alsitmno = ''' + @cis_itmno + ''''  
		set @w = @w + ' 	union '
		set @w = @w + ' select ibi_alsitmno from imbasinfh (nolock) where ibi_itmno = ''' + @cis_itmno + ''''  + ') '
	end
	
	if @cis_cusitm <> '' 
	begin
		set @w = @w + ' and cis_cusitm = ''' + @cis_cusitm + ''''
	end
	
	if @cis_cusstyno <> '' 
	begin
		set @w = @w + ' and cis_cusstyno = ''' + @cis_cusstyno + ''''
	end
	
	set @g = @g + '
	group by 
	cis_cocde, p.cbi_cusno, '
	
	if @cis_seccus <> '' begin set @g = @g + ' s.cbi_cusno, ' end 
	
	set @g = @g + 'cis_seccus, cis_secsna, cis_cusitm, cis_itmno,cis_cusstyno,cis_ftytmpitm,isnull(ibi_itmsts,''HIS''), ivi_venitm,isnull(vbi_vensts,''''), cis_itmdsc, cis_colcde, cis_coldsc,
	cis_curcde, imu_basprc, yce_selrat, imu_bcurcde, imu_basprc, yce_selrat, cis_curcde, imu_bcurcde, imu_basprc,
	cis_selprc, cis_moqchg,
	cis_cus1no, cis_cus2no, cis_hkprctrm, cis_ftyprctrm, cis_trantrm, cis_effdat, cis_expdat,
	cis_netselprc, cis_selprc, imu_curcde, cis_itmventyp, imu_curcde, cis_itmventyp,
	imu_curcde, cis_itmventyp, imu_ftycst, cis_itmventyp, imu_ftycst, cis_itmventyp, imu_ftycst, cis_itmventyp,
	imu_ftyprc, cis_itmventyp, imu_ftyprc, cis_itmventyp, imu_ftyprc, cis_itmventyp, ycf_value, cis_mtrqty,
	ycf_value, cis_mtrqty, ycf_value, cis_mtrqty, ibi_tirtyp, ibi_moqctn, ibi_tirtyp, ibi_typ, ycf_value,
	cis_mtrqty, ycf_value, cis_mtrqty, ycf_value, cis_mtrqty, ycf_value, cis_mtrqty, ycf_value, cis_mtrqty,
	ibi_tirtyp, ibi_moqctn, ibi_tirtyp, ibi_typ, cis_untcde, cis_conftr,cis_moq,cis_moqunttyp,cis_moacur,cis_moa,cis_inrqty, cis_mtrqty, cis_cft, cis_cbm,cis_qutdat, cis_imqutdat,
	cis_cussku, cis_refdoc, cis_docdat, cis_cuscol, cis_hrmcde, cis_dtyrat, cis_dept, cis_typcode,
	cis_code1, cis_code2, cis_code3, cis_cususd, cis_cuscad, cis_inrdcm, cis_inrwcm, cis_inrhcm, cis_mtrdcm,
	cis_mtrwcm, cis_mtrhcm, cis_inrdin,  cis_inrwin, cis_inrhin, cis_mtrdin, cis_mtrwin, cis_mtrhin, cis_ordqty,
	cis_pckitr, cis_contopc,cis_pcprc,
	cis_credat, cis_upddat	'
	
	set @o = @o +  ' order by cis_upddat desc, cis_itmno,  cis_cusitm, cis_cussku, cis_colcde' 
	
	exec(@i+@s+@s2+@f+@w+@g+@o)
end





GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMSUM_alias] TO [ERPUSER] AS [dbo]
GO
