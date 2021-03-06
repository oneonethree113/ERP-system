/****** Object:  StoredProcedure [dbo].[sp_select_IMM00009]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00009]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00009]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_select_IMM00009]
@cocde	varchar(6),
@srcItem	varchar(30),
@updItemList	varchar(1000),
@optList	varchar(40)
as
begin

	create table #_ITMLST(_itm varchar(30))
	declare	@itmRemain varchar(1000), @itmPart varchar(30)
	declare	@isEngDsc char(1), @isMOQ char(1), @isExcl char(1), @isPV char(1), @isCstInfo char(1)
	declare	@tmpItem varchar(30)
	declare	@cstrmk nvarchar(4000) , @expdat datetime
	Declare	@Row_Idx int,@Err_Idx int

	set @Row_Idx = 0
	set @Err_Idx = 0
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- Check Source Item
	
	
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- Check Update Items
	set @itmRemain = ltrim(rtrim(@updItemList))
	while charindex(',',@itmRemain) > 0 
	begin
		set @itmPart = ltrim(rtrim(left(@itmRemain, charindex(',', @itmRemain) - 1)))
		set @itmRemain = ltrim(rtrim(right(@itmRemain,len(@itmRemain) - charindex(',', @itmRemain))))
		if len(@itmPart) > 0 
		begin
			insert into #_ITMLST (_itm) values (@itmPart)
		end
	end
	if len(@itmRemain) > 0
	begin
		insert into #_ITMLST (_itm) values (@itmRemain)
	end
	
	insert into #_ITMLST (_itm) values (@srcItem)
	
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- Check Options
	set @optList = upper(@optList)
	set @isEngDsc = 'N'
	if charindex('ENG',@optList) > 0	set @isEngDsc = 'Y'
	set @isMOQ = 'N'
	if charindex('MOQ',@optList) > 0	set @isMOQ = 'Y'
	set @isExcl = 'N'
	if charindex('EXC',@optList) > 0	set @isExcl = 'Y'
	set @isPV = 'N'
	if charindex('PV',@optList) > 0	set @isPV = 'Y'
	set @isCstInfo = 'N'
	if charindex('CST',@optList) > 0	set @isCstInfo = 'Y'
	
	
	
	select 
		distinct
		
		case bas.ibi_itmno when @srcItem then '' else '*' end as 'ID' , 
		bas.ibi_itmno as 'Item #',
		-- English Description
		case @isEngDsc when 'Y' then bas.ibi_engdsc else '' end as 'Eng Desc',
		-- MOQ / MOA
		case @isMOQ when 'Y' then 
			case bas.ibi_tirtyp  when 0 then 'Standard' else 'Company Defined' end
		else '' end as 'Tier Type', 
		case @isMOQ when 'Y' then ltrim(str(bas.ibi_moqctn))  else '' end as 'MOQ',
		case @isMOQ when 'Y' then bas.ibi_curcde  else '' end as 'Curr(MOA)',
		case @isMOQ when 'Y' then ltrim(str(bas.ibi_moa,13,2))  else '' end as 'MOA',
		case @isMOQ when 'Y' then ltrim(str(bas.ibi_qty))  else '' end as 'Qty',
		-- Exclusive
		--case @isExcl when 'Y' then excl.ici_ctyseq  else '' end as 'Seq',
		case @isExcl when 'Y' then excl.ici_ctycde  else '' end as 'Country',
		case @isExcl when 'Y' then excl.ici_cusno  else '' end as 'Customer Code',
		case @isExcl when 'Y' then convert(varchar(10),excl.ici_valdat,121)  else '' end as 'Validity Date',
		case @isExcl when 'Y' then excl.ici_rmk  else '' end as 'Remark',
		-- Production Vendor
		case @isPV when 'Y' then ven.ivi_venitm else '' end as 'Vendor Item #',
		case @isPV when 'Y' then ven.ivi_venno  else '' end as 'Vendor',
		case @isPV when 'Y' then ven.ivi_def  else '' end as 'Default',
		-- Production Vendoor
		--prd.imu_
		case @isPV when 'Y' then ltrim(str(dsg.imu_pckseq))  else '' end as 'Packing Seq',
		case @isPV when 'Y' then dsg.imu_pckunt  else '' end as 'UM',
		case @isPV when 'Y' then ltrim(str(dsg.imu_inrqty))  else '' end as 'Inr Qty',
		case @isPV when 'Y' then ltrim(str(dsg.imu_mtrqty))  else '' end as 'Mtr Qty',
		case @isPV when 'Y' then ltrim(str(dsg.imu_cft,13,4))  else '' end as 'CFT',
		case @isPV when 'Y' then dsg.imu_bcurcde  else '' end as 'Currency (DV)',
		case @isPV when 'Y' then ltrim(str(dsg.imu_basprc,13,4))  else '' end as 'Basic Price (DV)',
		-- 
		case @isPV when 'Y' then prd.imu_venno  else '' end as 'Design Vendor',
		case @isPV when 'Y' then prd.imu_prdven  else '' end as 'Production Vendor',
		case @isPV when 'Y' then prd.imu_bcurcde  else '' end as 'Currency (PV)',
		case @isPV when 'Y' then ltrim(str(prd.imu_basprc,13,4))  else '' end as 'Basic Price (PV)',
		case @isPV when 'Y' then prd.imu_prctrm  else '' end as 'Price Term',
		case @isPV when 'Y' then prd.imu_fmlopt  else '' end as 'Formula',
		case @isPV when 'Y' then prd.imu_curcde  else '' end as 'Currency',
		case @isPV when 'Y' then ltrim(str(prd.imu_calftyprc,13,4))  else '' end as 'Calculated Cost',
		case @isPV when 'Y' then ltrim(str(prd.imu_negprc,13,4))  else '' end as 'Neg Item Cost',
		case @isPV when 'Y' then ltrim(str(prd.imu_ftybomcst,13,4))  else '' end as 'Fty BOM Cost',
		case @isPV when 'Y' then ltrim(str(prd.imu_ttlcst,13,4))  else '' end as 'Total Cost',
		case @isPV when 'Y' then prd.imu_ftyprctrm else '' end as 'Fty Price Term' ,
		-- Cost Info
		case @isCstInfo when 'Y' then cst.ici_cstrmk else '' end as 'Cost Remarks' , 
		case @isCstInfo when 'Y' then convert(varchar(10),cst.ici_expdat,121) else '' end as 'Cost Expire Date'
		
	from IMBASINF bas (nolock)
	left join IMCTYINF excl (nolock) on bas.ibi_itmno = excl.ici_itmno
	left join IMCSTINF cst (nolock) on bas.ibi_itmno = cst.ici_itmno
	left join IMVENINF ven (nolock) on bas.ibi_itmno = ven.ivi_itmno
	left join IMMRKUP dsg (nolock) on bas.ibi_itmno = dsg.imu_itmno and dsg.imu_ventyp = 'D'
	left join IMMRKUP prd (nolock) on dsg.imu_itmno = prd.imu_itmno and prd.imu_ventyp = 'P' and 
				   dsg.imu_pckunt = prd.imu_pckunt and dsg.imu_mtrqty = prd.imu_mtrqty and dsg.imu_inrqty = prd.imu_inrqty and
				   prd.imu_prdven =  ven.ivi_venno 
				
	where ibi_itmno in (select _itm from #_ITMLST)
	order by 1
	-- ibi_itmno,excl.ici_ctyseq,ven.ivi_venno

end





GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00009] TO [ERPUSER] AS [dbo]
GO
