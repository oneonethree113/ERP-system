/****** Object:  StoredProcedure [dbo].[sp_select_INR00014]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00014]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00014]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO









CREATE         PROCEDURE [dbo].[sp_select_INR00014]
	@cocdeStr		varchar(100),
	@vendorStr	varchar(6000),
	@dateFm		datetime,
	@dateTo		datetime,
	@rptType		nvarchar(1),
	@shipSts		nvarchar(1),	-- 'C' = All Shipment, 'P' = Partial Shipment
	@rptPeriod		nvarchar(1)		
As 

CREATE TABLE #TmpReport (
	cocde nvarchar(6),
	coName nvarchar(50),
	venno nvarchar(6),
	venName nvarchar(40),
	dateFm datetime,
	dateTo datetime,
	cbmType nvarchar(1),
	CBM numeric (11,4) default 0
	)

CREATE TABLE #tmp_vendor (
	tmp_venno nvarchar(6) 
	) 

CREATE TABLE #tmp_cocde (
	tmp_cocde nvarchar(6) 
	) 

DECLARE
	@vendor_part	nvarchar(6),
	@vendor_remain	nvarchar(255),

	@cocde_part	nvarchar(6),
	@cocde_remain	nvarchar(255),

	@TmpDate1 	datetime,	
	@TmpDate2 	datetime

-- Split Company Code
Set @cocde_remain = @cocdeStr
While charindex(',', @cocde_remain) <> 0
begin
	Set @cocde_part = ltrim(left(@cocde_remain, charindex(',',@cocde_remain) - 1))
	Set @cocde_remain = right(@cocde_remain, len(@cocde_remain) - charindex(',', @cocde_remain))
	insert into #tmp_cocde (tmp_cocde ) values (@cocde_part)
end
insert into #tmp_cocde (tmp_cocde ) values (ltrim(@cocde_remain))

-- Split Vendor Code	
Set @vendor_remain = @vendorStr
While charindex(',', @vendor_remain) <> 0
begin
	Set @vendor_part = ltrim(left(@vendor_remain, charindex(',',@vendor_remain) - 1))
	Set @vendor_remain = right(@vendor_remain, len(@vendor_remain) - charindex(',', @vendor_remain))
	insert into #tmp_vendor (tmp_venno ) values (@vendor_part)
end
insert into #tmp_vendor (tmp_venno ) values (ltrim(@vendor_remain))
		

-- Split Date Range to 1 week. 2 week or 4 week
set  @TmpDate1 = @dateFm - 7
set  @TmpDate2 = @dateFm - 7

if @rptPeriod = '2'
begin
	set  @TmpDate1 = @dateFm - 14
	set  @TmpDate2 = @dateFm - 14
end
else if @rptPeriod = '4'
begin
	set  @TmpDate1 = @dateFm - 28
	set  @TmpDate2 = @dateFm - 28
end
else
begin
	set  @TmpDate1 = @dateFm - 7
	set  @TmpDate2 = @dateFm - 7
end

while  convert(varchar(10),@dateTo ,121) > convert(varchar(10),@TmpDate2,121)  
begin
	if @rptPeriod = '2'
	begin
		set @TmpDate1 = dateadd ( day , 14, @TmpDate1 )        
		set @TmpDate2 = dateadd ( day , 13, @TmpDate1 )  
	end
	else if @rptPeriod = '4'
	begin
		set @TmpDate1 = dateadd ( day , 28, @TmpDate1 )        
		set @TmpDate2 = dateadd ( day , 27, @TmpDate1 )  
	end
	else
	begin
		set @TmpDate1 = dateadd ( day , 7, @TmpDate1 )        
		set @TmpDate2 = dateadd ( day , 6, @TmpDate1 )  
	end
		
	if convert(varchar(10),@TmpDate2,121)  > convert(varchar(10),@dateTo,121)   
	begin
	    	set @TmpDate2  = @dateTo
	end
	else
	begin
		set @TmpDate2 = @TmpDate2 + ' 23:59:59'
	end

	insert into 
		#TmpReport 
	Select	
		sod_cocde,
		'',
		sod_venno,
		'',
		@TmpDate1,
		@TmpDate2,
		'O',
		case when @shipSts = 'C' then isnull(sum( isnull(sod_cbm * sod_ttlctn, 0)),0) else  isnull(sum( isnull(sod_cbm * sod_ttlctn, 0) * (sod_ordqty -sod_shpqty) / sod_ordqty  ),0)  end
	From	
		SCORDHDR (nolock),
		SCORDDTL (nolock)
	Where	
			soh_cocde = sod_cocde
		and	soh_ordno = sod_ordno
		and	soh_ordsts <> 'CAN'
		and 	sod_ordqty > 0
		and 	sod_shpstr >=  convert(datetime, @TmpDate1, 121) and sod_shpstr <= convert(datetime, @TmpDate2, 121)
		and	(@shipSts = 'C' or (@shipSts = 'P' and sod_ordqty > sod_shpqty))
		and 	sod_cocde in (select tmp_cocde from #tmp_cocde)
		and	sod_venno in (select tmp_venno from #tmp_vendor)
	group by	sod_cocde,
		sod_venno

	if @shipSts = 'C'
	begin
		insert into 
			#TmpReport 
		Select
			hiv_cocde,
			'',
			sod_venno,
			'',
			@TmpDate1,
			@TmpDate2,
			'S',
			round( isnull(sum(isnull(hid_vol,0) * hid_ttlctn),0),4)
		From	
			SHIPGHDR (nolock),
			SHINVHDR (nolock),
			SHIPGDTL (nolock),
			SCORDDTL (nolock)
		Where		hih_cocde = hid_cocde 
			and	hih_shpno = hid_shpno
			and	hid_cocde = sod_cocde 
			and 	hid_ordno = sod_ordno 
			and 	hid_ordseq = sod_ordseq 
			and 	hid_cocde = hiv_cocde 
			and 	hid_shpno = hiv_shpno 
			and 	hid_invno = hiv_invno
			and	hid_itmno = sod_itmno
			and	hiv_invdat >=  convert(datetime,@TmpDate1,121) and hiv_invdat <=  convert(datetime,@TmpDate2,121)
			and 	hiv_cocde in (select tmp_cocde from #tmp_cocde)
			and	sod_venno in (select tmp_venno from #tmp_vendor)
		group by	hiv_cocde,
			sod_venno
	end
	else
	begin
		insert into 
			#TmpReport 
		Select	
			sod_cocde,
			'',
			sod_venno,
			'',
			@TmpDate1,
			@TmpDate2,
			'S',
			isnull(sum( isnull(sod_cbm * sod_ttlctn, 0) * (sod_ordqty -sod_shpqty) / sod_ordqty  ),0)
		From	
			SCORDHDR (nolock),
			SCORDDTL (nolock)
		Where	
				soh_cocde = sod_cocde
			and	soh_ordno = sod_ordno
			and	soh_ordsts <> 'CAN'
			and 	sod_ordqty > 0
			and 	sod_candat >=  convert(datetime, @TmpDate1, 121) and sod_candat <= convert(datetime, @TmpDate2, 121)
			and	sod_ordqty > sod_shpqty
			and 	sod_cocde in (select tmp_cocde from #tmp_cocde)
			and	sod_venno in (select tmp_venno from #tmp_vendor)
		group by	sod_cocde,
			sod_venno
	end

	if not exists(select top 1 cocde from #TmpReport  where datefm = @TmpDate1 and dateTo = @TmpDate2)
	begin
		insert into 
			#TmpReport 
		Select	
			tmp_cocde,
			'',
			tmp_venno,
			'',	
			@TmpDate1,
			@TmpDate2,
			'O',
			0
		from #tmp_cocde, #tmp_vendor

		insert into 
			#TmpReport 
		Select
			tmp_cocde,
			'',
			tmp_venno,
			'',	
			@TmpDate1,
			@TmpDate2,
			'S',
			0
		from #tmp_cocde, #tmp_vendor
	end
END

-- Fill in Vendor Name and Company Name
update #TmpReport  set coName  = SYCOMINF.yco_conam
from SYCOMINF (nolock)
where #TmpReport.cocde = SYCOMINF.yco_cocde

update #TmpReport  set venName  = VNBASINF.vbi_vensna
from VNBASINF (nolock)
where #TmpReport.venno = VNBASINF.vbi_venno

-- Set Report Output
select * from  #TmpReport 
order by Cocde, cbmType, datefm, venno

DROP TABLE #TmpReport
DROP TABLE #tmp_vendor
DROP TABLE #tmp_cocde





GO
GRANT EXECUTE ON [dbo].[sp_select_INR00014] TO [ERPUSER] AS [dbo]
GO
