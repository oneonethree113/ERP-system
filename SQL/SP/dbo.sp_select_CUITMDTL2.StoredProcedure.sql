/****** Object:  StoredProcedure [dbo].[sp_select_CUITMDTL2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMDTL2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMDTL2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/************************************************************************
Author:		Carlos Lui
Date:		06 Jun, 2012
Description:	Select data From CUITMDTL
Parameter:		1. Company
		2. Customer Code
***********************************************************************
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_CUITMDTL2]
                                                                                                                                                                                                                                                                 
@cid_cocde nvarchar(6),
@cid_itmno nvarchar(20),
@cid_cusitm nvarchar(20),
@cid_seccus nvarchar(6),
@cid_cusno nvarchar(6),
@cid_cusstyno nvarchar(30),
@gsflgcst char(1),
@gsflgcstext char(1)             
 
AS

declare @itmnoOpt nvarchar(1), @cusitmOpt nvarchar(1), @cusstynoOpt nvarchar(1)

set @itmnoOpt = 'N'
if @cid_itmno <> ''
begin
	set @itmnoOpt = 'Y'
end

set @cusitmOpt = 'N'
if @cid_cusitm <> ''
begin
	set @cusitmOpt = 'Y'
end

set @cusstynoOpt = 'N'
if @cid_cusstyno <> ''
begin
	set @cusstynoOpt = 'Y'
end

select
cid_cocde		as 'Company Code',
'' 		as 'Alias Pri Cusno',
cid_seccus 		as 'Sec. Cust. No.', 
'' 		as 'Alias Sec Cusno',
cid_secsna 		as 'Sec.Cust. Name',
cid_cusitm 		as 'Cust_Item_No',
cid_itmno 		as 'Item_No',
cid_cusstyno	as 'Cust. Style No.',
cid_ftytmpitm	as 'Fty Temp No',
cid_cussku 	as 'Cust. SKU No.',
cid_itmdsc 		as 'Item Desc.',
cid_colcde 		as 'Color_Code',
cid_coldsc		as 'Color Desc.',
cid_cuscol		as 'Cust. Color Code',
cid_refdoc		as 'Ref. Doc.',
cid_docdat		as 'Last Doc. Date',
cid_ordqty		as 'Order Qty',
case cid_onetim
	when 'N' then ''
	else cid_onetim
	end	as 'OTP',
cid_curcde		as 'CCY',
cid_selprc		as 'Selling Price',
isnull(cid_moqchg,0)	as 'MOQ Charges %',
cid_cus1no		as 'Price Key - Cust 1',
cid_cus2no		as 'Price Key - Cust 2',
cid_hkprctrm	as 'Price Key - HK Price Term',
cid_ftyprctrm	as 'Price Key - FTY Price Term',
cid_trantrm		as 'Price Key - Transport Term',
cid_effdat	 	as 'Price Key - Effective Date',
cid_expdat	 	as 'Price Key - Expiry Date',
isnull(cid_netselprc,cid_selprc) as 'Net Selling Price',
case cid_itmventyp
	when 'I' then case @gsflgcst
			when '1' then cid_fcurcde
			else '' end
	when 'J' then case @gsflgcst
			when '1' then cid_fcurcde
			else '' end
	when 'E' then case @gsflgcstext
			when '1' then cid_fcurcde
			else '' end
	end	as 'Factory CCY',
case cid_itmventyp
	when 'I' then case @gsflgcst
			when '1' then cid_ftycst
			else 0 end
	when 'J' then case @gsflgcst
			when '1' then cid_ftycst
			else 0 end
	when 'E' then case @gsflgcstext
			when '1' then cid_ftycst
			else 0 end
	end	as 'Factory Cost',
case cid_itmventyp
	when 'I' then case @gsflgcst
			when '1' then cid_ftyprc
			else 0 end
	when 'J' then case @gsflgcst
			when '1' then cid_ftyprc
			else 0 end
	when 'E' then case @gsflgcstext
			when '1' then cid_ftyprc
			else 0 end
	end	as 'Factory Price',
cid_untcde		as 'UM',
cid_inrqty		as 'Inner',
cid_mtrqty		as 'Master',
cid_cft		as 'CFT',
cid_cbm		as 'CBM',
case ltrim(rtrim(str(year(cid_qutdat))))
	when '1900' then ''
	else ltrim(rtrim(str(year(cid_qutdat)))) + '-' + right('00' + ltrim(rtrim(str(month(cid_qutdat)))),2)
	end	as 'CIH Period',
cid_hrmcde	as 'HSTU / Tariff #',
cid_dtyrat		as 'Duty %',
cid_dept		as 'Dept.',
cid_typcode	as 'EAN or UPC',
cid_code1		as 'EAN or UPC Code 1',
cid_code2		as 'EAN or UPC Code 2',
cid_code3		as 'EAN or UPC Code 3',
cid_cususd		as 'Customer Retail (USD)',
cid_cuscad		as 'Customer Retail (CAD)',
cid_inrdcm		as 'Inner L (cm)',
cid_inrwcm	as 'Inner W (cm)',
cid_inrhcm		as 'Inner H (cm)',
cid_mtrdcm	as 'Master L (cm)',
cid_mtrwcm	as 'Master W (cm)',
cid_mtrhcm	as 'Master H (cm)',
cid_inrdin		as 'Inner L (in)',
cid_inrwin		as 'Inner W (in)',
cid_inrhin		as 'Inner H (in)',
cid_mtrdin		as 'Master L (in)',
cid_mtrwin		as 'Master W (in)',
cid_mtrhin		as 'Master H (in)',
cid_pckitr		as 'Packing Instruction',
cid_conftr 		as 'U/M Factor',
cid_contopc 	as 'Convert To PC',
cid_pcprc		as 'Price For PC',
cid_seqno		as 'Seq',
cid_credat		as 'Create Date'
from	CUITMDTL (nolock)
where	cid_cusno = @cid_cusno		and
	cid_seccus = @cid_seccus		and
	(@itmnoOpt = 'N'		or
	 (@itmnoOpt = 'Y'	and
	  cid_itmno = @cid_itmno))		and
	(@cusitmOpt = 'N'		or
	 (@cusitmOpt = 'Y'	and
	  cid_cusitm = @cid_cusitm))		and
	(@cusstynoOpt = 'N'		or
	 (@cusstynoOpt = 'Y'	and
	  cid_cusstyno = @cid_cusstyno))
order by	cid_upddat desc, cid_itmno, cid_cusitm, cid_cussku, cid_colcde




GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMDTL2] TO [ERPUSER] AS [dbo]
GO
