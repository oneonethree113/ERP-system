/****** Object:  StoredProcedure [dbo].[sp_check_QCRpt]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_check_QCRpt]
GO
/****** Object:  StoredProcedure [dbo].[sp_check_QCRpt]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sp_check_QCRpt]
@cocde		nvarchar(20),	
@venno		nvarchar(10),
@cus1no		nvarchar(10),
@cus2no		nvarchar(10),
@itmno		nvarchar(30),	
@cusitm		nvarchar(30),
@postr		nvarchar(2000),
@cuspostr	nvarchar(2000),
@morepostr	nvarchar(2000),
@withreq	nvarchar(10),
@actcde		nvarchar(20),
@usrid		nvarchar(30)

AS

SET NOCOUNT ON

create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_PO (tmp_po nvarchar(20)) on [PRIMARY]
create table #TEMP_CUSPO (tmp_cuspo nvarchar(20)) on [PRIMARY]
create table #TEMP_MOREPO (tmp_morepo nvarchar(20)) on [PRIMARY]

declare	@fm nvarchar(100), @to nvarchar(100)
declare @strPart nvarchar(1000), @strRemain nvarchar(1000)

set @itmno  = Replace(@itmno,'–','-')
set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''

--#TEMP_PO
if ltrim(rtrim(@postr)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @postr
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))

		insert into #TEMP_INIT values (@strPart)
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)

		insert into #TEMP_INIT values (@strRemain)
	end
	insert into #TEMP_PO
	select distinct tmp_init from #TEMP_INIT
end

--#TEMP_CUSPO
if ltrim(rtrim(@cuspostr)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cuspostr
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))

		insert into #TEMP_INIT values (@strPart)
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)

		insert into #TEMP_INIT values (@strRemain)
	end
	insert into #TEMP_CUSPO
	select distinct tmp_init from #TEMP_INIT
end


--#MORE_PO
if ltrim(rtrim(@morepostr)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @morepostr
	while charindex(';', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(';', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(';', @strRemain))

		insert into #TEMP_INIT values (@strPart)
	end
	if charindex(';',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)

		insert into #TEMP_INIT values (@strRemain)
	end
	insert into #TEMP_MOREPO
	select distinct tmp_init from #TEMP_INIT
end


declare @return_status nvarchar(20), @return_message nvarchar(2000)
set @return_status = 'VALID'
set @return_message = ''

--[192.168.1.214\MSSQLSERVER2012].[UCPERPDB]
--[192.168.1.214\MSSQLSERVER2012].[UCPERPDB]

-- 1. Check Venno
if @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[VNBASINF] where vbi_venno = @venno) <> 1 
begin
	set @return_status = 'IN-VALID'
	set @return_message = 'Vendor Number :' + @venno + ' not found'
end

-- 2. Check Primary Customer
if @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[CUBASINF] where cbi_cusno = @cus1no) <> 1 
begin
	set @return_status = 'IN-VALID'
	set @return_message = 'Customer Number :' + @cus1no + ' not found'
end
/*
-- 3. Check Secondary Customer
if @return_status = 'VALID' and @cus2no <> '' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[CUBASINF] where cbi_cusno = @cus2no) <> 1
begin
	set @return_status = 'IN-VALID'
	set @return_message = 'Customer Number :' + @cus2no + ' not found'
end
*/
-- 4. Check Item Number
if @withreq = 'Y' and @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[IMBASINF] where ibi_itmno = @itmno) <> 1 
begin
	set @return_status = 'IN-VALID'
	set @return_message = 'Item Number :' + @itmno + ' not found'
end

-- 5. Check Item Number in PO
if @withreq = 'Y' and @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDDTL] where pod_itmno = @itmno) = 0 
begin
	set @return_status = 'IN-VALID'
	set @return_message = 'Item Number :' + @itmno + ' not found in any Purchase Order'
end

-- 6. Check Customer Item vs Item Number in PO
if  @withreq = 'Y' and @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDDTL]  where pod_itmno = @itmno and pod_cusitm = @cusitm) = 0 
begin
	set @return_status = 'IN-VALID'
	set @return_message = 'Customer Item Number :' + @cusitm + ' not found in any Purchase Order with item number (' + @itmno + ')'
end

-- 7. Check Pri, Sec Customer, Vendor, Item, Cust Item in PO
if @withreq = 'Y' and @return_status = 'VALID' and 
	(select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDHDR] , [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDDTL]
			where poh_cocde = pod_cocde and poh_purord = pod_purord
			and poh_prmcus = @cus1no
			and poh_venno = @venno 
			and pod_itmno = @itmno and pod_cusitm = @cusitm) = 0 
begin
	set @return_status = 'IN-VALID'
	set @return_message = 'No PO found for Customer (' + @cus1no + '), Vendor(' + @venno + '), Item(' + @itmno + '), Cust Item(' + @cusitm + ')'
end

-- 8. Check PO vs Pri, Sec Customer, Vendor, Item, Cust Item
declare @invalid_postr nvarchar(2000), @invalid_po nvarchar(20)
set @invalid_postr = ''
set @invalid_po = ''
declare @po nvarchar(20)
set @po = ''
if @withreq = 'Y' and @return_status = 'VALID' 
begin
	declare cur_PO cursor
	for
	select tmp_po from #TEMP_PO (nolock)

	open cur_PO
	fetch next from cur_PO into @po
	while @@fetch_status = 0
	begin
		if @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDHDR] 
			left join [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDDTL] on poh_cocde = pod_cocde and poh_purord = pod_purord and pod_itmno = @itmno and pod_cusitm = @cusitm 
			where poh_purord = @po and poh_prmcus = @cus1no and poh_venno = @venno) = 0
		begin
			set @return_status = 'IN-VALID'
			set @return_message = 'PO (' + @po + ') not match with Customer (' + @cus1no + '), Vendor(' + @venno + '), Item(' + @itmno + '), Cust Item(' + @cusitm + ')'
		end
		fetch next from cur_PO into @po
	end
	close cur_PO
	deallocate cur_PO
end

-- 9. Check Cust PO vs Pri, Sec Customer, Vendor, Item, Cust Item
declare @invalid_cuspostr nvarchar(2000), @invalid_cuspo nvarchar(20)
set @invalid_cuspostr = ''
set @invalid_cuspo = ''
if @withreq = 'Y' and @return_status = 'VALID' 
begin
	declare cur_cusPO cursor
	for
	select tmp_cuspo from #TEMP_CUSPO (nolock)

	open cur_cusPO
	fetch next from cur_cusPO into @po
	while @@fetch_status = 0
	begin
		if @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDHDR]
			left join [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDDTL] on poh_cocde = pod_cocde and poh_purord = pod_purord and pod_itmno = @itmno and pod_cusitm = @cusitm 
			where poh_cuspno = @po and poh_prmcus = @cus1no and poh_venno = @venno) = 0
		begin
			set @return_status = 'IN-VALID'
			set @return_message = 'Cust PO (' + @po + ') not match with Customer (' + @cus1no + '), Vendor(' + @venno + '), Item(' + @itmno + '), Cust Item(' + @cusitm + ')'
		end
		fetch next from cur_cusPO into @po
	end
	close cur_cusPO
	deallocate cur_cusPO
end

-- 10. Check MorePO vs Pri, Sec Customer, Vendor, Item, Cust Item
declare @invalid_morepostr nvarchar(2000), @invalid_morepo nvarchar(20)
set @invalid_morepostr = ''
set @invalid_morepo = ''
if @withreq = 'Y' and @return_status = 'VALID' 
begin
	declare cur_morePO cursor
	for
	select tmp_morepo from #TEMP_MOREPO (nolock)

	open cur_morePO
	fetch next from cur_morePO into @po
	while @@fetch_status = 0
	begin
		if @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDHDR] 
			left join [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDDTL] on poh_cocde = pod_cocde and poh_purord = pod_purord and pod_itmno = @itmno and pod_cusitm = @cusitm 
			where poh_purord = @po and poh_prmcus = @cus1no and poh_venno = @venno 
			) = 0
		begin
			set @return_status = 'IN-VALID'
			set @return_message = 'MORE PO (' + @po + ') not match with Customer (' + @cus1no + '), Vendor(' + @venno + '), Item(' + @itmno + '), Cust Item(' + @cusitm + ')'
		end
		fetch next from cur_morePO into @po
	end
	close cur_morePO
	deallocate cur_morePO
end

-- 11. withreq = 'N' Check PO vs Pri, Vendor, UCP Item
set @invalid_morepostr = ''
set @invalid_morepo = ''
if @withreq = 'N' and @return_status = 'VALID' 
begin
	declare cur_morePO_2 cursor
	for
	select tmp_morepo from #TEMP_MOREPO (nolock)

	open cur_morePO_2
	fetch next from cur_morePO_2 into @po
	while @@fetch_status = 0
	begin
		if @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDHDR] 
			left join [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDDTL] on poh_cocde = pod_cocde and poh_purord = pod_purord and pod_itmno = @itmno 
			where poh_purord = @po and poh_prmcus = @cus1no and poh_venno = @venno and pod_cocde is not null
			) = 0
		begin
			set @return_status = 'IN-VALID'
			set @return_message = 'Without Req PO (' + @po + ') not match with Customer (' + @cus1no + '), Vendor(' + @venno + '), Item(' + @itmno + ')'
		end
		fetch next from cur_morePO_2 into @po
	end
	close cur_morePO_2
	deallocate cur_morePO_2
end



-- 12. withreq = 'N' Check PO vs Pri, Sec Customer, Vendor, Cust Item
set @invalid_postr = ''
set @invalid_po = ''
if @withreq = 'N' and @cusitm <> '' and @return_status = 'VALID' 
begin
	declare cur_morePO_2 cursor
	for
	select tmp_morepo from #TEMP_MOREPO (nolock)

	open cur_morePO_2
	fetch next from cur_morePO_2 into @po
	while @@fetch_status = 0
	begin
		if @return_status = 'VALID' and (select count(*) from [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDHDR] 
			left join [192.168.1.214\MSSQLSERVER2012].[UCPERPDB].[dbo].[POORDDTL] on poh_cocde = pod_cocde and poh_purord = pod_purord and pod_cusitm = @cusitm 
			where poh_purord = @po and poh_prmcus = @cus1no and poh_venno = @venno and pod_cocde is not null
			) = 0
		begin
			set @return_status = 'IN-VALID'
			set @return_message = 'Without Req PO (' + @po + ') not match with Customer (' + @cus1no + '), Vendor(' + @venno + '), Cust Item(' + @cusitm + ')'
		end
		fetch next from cur_morePO_2 into @po
	end
	close cur_morePO_2
	deallocate cur_morePO_2
end






if @actcde = 'CONFIRM' and @return_status = 'VALID'
begin
	set @return_status = 'CONFIRM'
end

begin
update qcrpthdr set qrh_rptstatus = @return_status where qrh_tmprptno = @cocde
exec sp_send_QCRptCheckingResultEmail @cocde, @actcde, @return_status, @return_message
end

select @return_status return_status, @return_message return_message




GO
GRANT EXECUTE ON [dbo].[sp_check_QCRpt] TO [ERPUSER] AS [dbo]
GO
