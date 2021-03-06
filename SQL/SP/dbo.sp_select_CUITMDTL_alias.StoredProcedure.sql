/****** Object:  StoredProcedure [dbo].[sp_select_CUITMDTL_alias]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMDTL_alias]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMDTL_alias]    Script Date: 09/29/2017 11:53:53 ******/
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

************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_CUITMDTL_alias]
@cid_cocde nvarchar(6),
@cid_itmno nvarchar(20),
@cid_cusitm nvarchar(20),
@cid_seccus nvarchar(6),
@cid_cusno nvarchar(6),
@cid_cusstyno nvarchar(30),
@gsflgcst char(1),
@gsflgcstext char(1)           

AS

select 
cid_cocde		as 'Company Code',
cid_cusno		as 'Pri. Cust (Previous)',
cid_seccus		as 'Sec. Cust. No.',
case @cid_seccus
	when '' then ''
	else cid_seccus
	end	as 'Sec. Cust. (Previous)', 
cid_secsna		as 'Sec.Cust. Name',
cid_cusitm		as 'Cust_Item_No',
cid_itmno		as 'Item_No',
cid_cusstyno	as 'Cust. Style No.',
cid_ftytmpitm	as 'Fty Temp No',
cid_cussku		as 'Cust. SKU No.',
cid_itmdsc		as 'Item Desc.',
cid_colcde		as 'Color_Code',
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
isnull(cid_moqchg,0)	as 'MOQ Charges',
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
			when 'Y' then cid_fcurcde
			else '' end
	when 'J' then case @gsflgcst
			when 'Y' then cid_fcurcde
			else '' end
	when 'E' then case @gsflgcstext
			when 'Y' then cid_fcurcde
			else '' end
	end	as 'Factory CCY',
case cid_itmventyp
	when 'I' then case @gsflgcst
			when 'Y' then cid_ftycst
			else 0 end
	when 'J' then case @gsflgcst
			when 'Y' then cid_ftycst
			else 0 end
	when 'E' then case @gsflgcstext
			when 'Y' then cid_ftycst
			else 0 end
	end	as 'Factory Cost',
case cid_itmventyp
	when 'I' then case @gsflgcst
			when 'Y' then cid_ftyprc
			else 0 end
	when 'J' then case @gsflgcst
			when 'Y' then cid_ftyprc
			else 0 end
	when 'E' then case @gsflgcstext
			when 'Y' then cid_ftyprc
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
into	#RESULT
from	CUITMDTL (nolock)
where	0<>0

create table	#TMP_PRICUS
(tmp_pricus	nvarchar(6))

create table	#TMP_SECCUS
(tmp_seccus	nvarchar(6))

insert into	#TMP_PRICUS
select	cbi_cusno
from	CUBASINF (nolock)
where	(cbi_cusno = @cid_cusno	or
	 cbi_cusali = @cid_cusno)		and
	@cid_cusno <> ''

insert into	#TMP_SECCUS
select	cbi_cusno
from	CUBASINF (nolock)
where	(cbi_cusno = @cid_seccus	or
	 cbi_cusali = @cid_seccus)		and
	@cid_seccus <> ''

declare @seccusOpt nvarchar(1), @cusitmOpt nvarchar(1), @itmnoOpt nvarchar(1), @cusstynoOpt nvarchar(1)

set @seccusOpt = 'N'
if @cid_seccus <> ''
begin
	set @seccusOpt = 'Y'
end

set @cusitmOpt = 'N'
if @cid_cusitm <> ''
begin
	set @cusitmOpt = 'Y'
end

set @itmnoOpt = 'N'
if @cid_itmno <> ''
begin
	set @itmnoOpt = 'Y'
end

set @cusstynoOpt = 'N'
if @cid_cusstyno <> ''
begin
	set @cusstynoOpt = 'Y'
end

create table	#TMP_ITMLIST
(tmp_itmno	nvarchar(20))

if @itmnoOpt = 'Y'
begin
	insert into	#TMP_ITMLIST
	select	ibi_itmno
	from	imbasinf (nolock)
	where	(ibi_itmno = @cid_itmno	or
		 ibi_alsitmno = @cid_itmno)		and
		ibi_itmno <> ''
	union
	select	ibi_alsitmno
	from	imbasinf (nolock)
	where	ibi_itmno = @cid_itmno		and
		ibi_alsitmno <> ''
	union
	select	ibi_itmno
	from	imbasinfh (nolock)
	where	(ibi_itmno = @cid_itmno	or
		 ibi_alsitmno = @cid_itmno)		and
		ibi_itmno <> ''
	union
	select	ibi_alsitmno
	from	imbasinfh (nolock)
	where	ibi_itmno = @cid_itmno		and
		ibi_alsitmno <> ''

	declare @res_itmno nvarchar(20)
	
	declare cur_Itmno cursor
	for
	select	tmp_itmno
	from	#TMP_ITMLIST (nolock)
	
	open cur_Itmno
	fetch next
	from	cur_Itmno
	into	@res_itmno
	
	while @@fetch_status = 0
	begin
		insert into	#RESULT
		select
		cid_cocde		as 'Company Code',
		cid_cusno		as 'Pri. Cust (Previous)',
		cid_seccus		as 'Sec. Cust. No.',
		case @cid_seccus
			when '' then ''
			else cid_seccus
			end	as 'Sec. Cust. (Previous)', 
		cid_secsna		as 'Sec.Cust. Name',
		cid_cusitm		as 'Cust_Item_No',
		cid_itmno		as 'Item_No',
		cid_cusstyno	as 'Cust. Style No.',
		cid_ftytmpitm	as 'Fty Temp No',
		cid_cussku		as 'Cust. SKU No.',
		cid_itmdsc		as 'Item Desc.',
		cid_colcde		as 'Color_Code',
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
		isnull(cid_moqchg,0)	as 'MOQ Charges',
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
					when 'Y' then cid_fcurcde
					else '' end
			when 'J' then case @gsflgcst
					when 'Y' then cid_fcurcde
					else '' end
			when 'E' then case @gsflgcstext
					when 'Y' then cid_fcurcde
					else '' end
			end	as 'Factory CCY',
		case cid_itmventyp
			when 'I' then case @gsflgcst
					when 'Y' then cid_ftycst
					else 0 end
			when 'J' then case @gsflgcst
					when 'Y' then cid_ftycst
					else 0 end
			when 'E' then case @gsflgcstext
					when 'Y' then cid_ftycst
					else 0 end
			end	as 'Factory Cost',
		case cid_itmventyp
			when 'I' then case @gsflgcst
					when 'Y' then cid_ftyprc
					else 0 end
			when 'J' then case @gsflgcst
					when 'Y' then cid_ftyprc
					else 0 end
			when 'E' then case @gsflgcstext
					when 'Y' then cid_ftyprc
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
		where	cid_cusno in (	select	tmp_pricus
					from	#TMP_PRICUS)	and
			((@seccusOpt = 'N'	and
			   cid_seccus = '' )		or
			 (@seccusOpt = 'Y'	and
			   cid_seccus in (	select	tmp_seccus
					from	#TMP_SECCUS)))	and
			(@cusitmOpt = 'N'		or
			 (@cusitmOpt = 'Y'	and
			   cid_cusitm = @cid_cusitm))			and
			(@cusstynoOpt = 'N'		or
			 (@cusstynoOpt = 'Y'	and
			   cid_cusstyno = @cid_cusstyno))			and
			cid_itmno = @res_itmno
		
		fetch next
		from	cur_Itmno
		into	@res_itmno
	end

close cur_Itmno
deallocate cur_Itmno

end
else	--@itmnoOpt <> 'Y'
begin
	insert into	#RESULT
	select
	cid_cocde		as 'Company Code',
	cid_cusno		as 'Pri. Cust (Previous)',
	cid_seccus		as 'Sec. Cust. No.',
	case @cid_seccus
		when '' then ''
		else cid_seccus
		end	as 'Sec. Cust. (Previous)', 
	cid_secsna		as 'Sec.Cust. Name',
	cid_cusitm		as 'Cust_Item_No',
	cid_itmno		as 'Item_No',
	cid_cusstyno	as 'Cust. Style No.',
	cid_ftytmpitm	as 'Fty Temp No',
	cid_cussku		as 'Cust. SKU No.',
	cid_itmdsc		as 'Item Desc.',
	cid_colcde		as 'Color_Code',
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
	isnull(cid_moqchg,0)	as 'MOQ Charges',
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
				when 'Y' then cid_fcurcde
				else '' end
		when 'J' then case @gsflgcst
				when 'Y' then cid_fcurcde
				else '' end
		when 'E' then case @gsflgcstext
				when 'Y' then cid_fcurcde
				else '' end
		end	as 'Factory CCY',
	case cid_itmventyp
		when 'I' then case @gsflgcst
				when 'Y' then cid_ftycst
				else 0 end
		when 'J' then case @gsflgcst
				when 'Y' then cid_ftycst
				else 0 end
		when 'E' then case @gsflgcstext
				when 'Y' then cid_ftycst
				else 0 end
		end	as 'Factory Cost',
	case cid_itmventyp
		when 'I' then case @gsflgcst
				when 'Y' then cid_ftyprc
				else 0 end
		when 'J' then case @gsflgcst
				when 'Y' then cid_ftyprc
				else 0 end
		when 'E' then case @gsflgcstext
				when 'Y' then cid_ftyprc
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
	where	cid_cusno in (	select	tmp_pricus
				from	#TMP_PRICUS)	and
		((@seccusOpt = 'N'	and
		   cid_seccus = '' )		or
		 (@seccusOpt = 'Y'	and
		   cid_seccus in (	select	tmp_seccus
				from	#TMP_SECCUS)))	and
		(@cusitmOpt = 'N'		or
		 (@cusitmOpt = 'Y'	and
		   cid_cusitm = @cid_cusitm))			and
		(@cusstynoOpt = 'N'		or
		 (@cusstynoOpt = 'Y'	and
		   cid_cusstyno = @cid_cusstyno))
end

select	*
from	#RESULT 
order by	[Create Date] desc, [Item_No], [Cust_Item_No], [Cust. SKU No.], [Color_Code]





GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMDTL_alias] TO [ERPUSER] AS [dbo]
GO
