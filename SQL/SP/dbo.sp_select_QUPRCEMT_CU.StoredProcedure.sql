/****** Object:  StoredProcedure [dbo].[sp_select_QUPRCEMT_CU]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUPRCEMT_CU]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUPRCEMT_CU]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






/*=========================================================
Program ID	: 	sp_select_QUPRCEMT_CU
Description   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description

=========================================================
*/
--sp_select_QUPRCEMT_CU 'UCPP','50486','','E','','0002','FOB HK','LCL'
CREATE         PROCEDURE [dbo].[sp_select_QUPRCEMT_CU] 

@cocde	nvarchar(6),
@cus1no	nvarchar(10),
@cus2no	nvarchar(10),--
@ventyp	nvarchar(10),
@itmcat	nvarchar(20),
@venno	nvarchar(6),
@prctrm	nvarchar(10),--
@trantrm nvarchar(10)--

AS
-- temporary declare
--declare @cus2no nvarchar(10)
--set @cus2no = ''
--declare @prctrm nvarchar(10)
--set @prctrm = 'FOB HK'
--declare @trantrm nvarchar(10)
--set @trantrm = 'LCL'

declare @final_cus1no nvarchar(10)
declare @final_cus2no nvarchar(10)
declare @final_venno nvarchar(10)
declare @final_itmcat nvarchar(20)
declare @final_prctrm nvarchar(20)
declare @final_trantrm nvarchar(20)
declare @max_a_date datetime

-- Customer : Sec > Pri 
-- Venno : Venno > INT/EXT > ALL
-- Item Cat : Cat L3 > STANDARD
-- PrcTerm : Extractly Same
-- TranTerm : Extractly Same


create table #TEMP_CUST (tmp_cus1no nvarchar(10), tmp_cus2no nvarchar(10))
if @cus2no <> ''
begin
	insert into #TEMP_CUST (tmp_cus1no, tmp_cus2no) values (@cus1no, @cus2no)
end
insert into #TEMP_CUST (tmp_cus1no, tmp_cus2no) values (@cus1no, '')

create table #TEMP_VEN (tmp_venno nvarchar(10))
insert into #TEMP_VEN (tmp_venno) values (@venno)
if @venno <> 'INT'
begin
	insert into #TEMP_VEN (tmp_venno) values ('INT')
end
if @venno <> 'EXT'
begin
	insert into #TEMP_VEN (tmp_venno) values ('EXT')
end
if @venno <> 'ALL'
begin
	insert into #TEMP_VEN (tmp_venno) values ('ALL')
end

create table #TEMP_CAT (tmp_cat nvarchar(20))
if @itmcat <> 'STANDARD'
begin
	insert into #TEMP_CAT (tmp_cat) values ('STANDARD')
end

if @itmcat = 'FD/XM2.1' or @itmcat = 'FD/XM2.2' or @itmcat = 'FD/XM2.3' or @itmcat = 'FD/XM2.4' or @itmcat = 'FD/XM2.5' or @itmcat = 'FD/XM2.6'
begin
	insert into #TEMP_CAT (tmp_cat) values ('XMAS TREE')
end
else
begin
	insert into #TEMP_CAT (tmp_cat) values (@itmcat)
end

if @venno = '0002' or @venno = '1756'
begin
	insert into #TEMP_CAT (tmp_cat) values ('MAGICSILK')
end
else if (@venno = '1656' or @venno = '1822' or @venno = '1831' or @venno = '1835' or @venno = '1840' or
	@venno = '1851' or @venno = '1852' or @venno = '1876' or @venno = '1908' or @venno = '1925' or
	@venno = '1926' or @venno = '1937' or @venno = '1943' or @venno = '1960' or @venno = '1961' or
	@venno = '1964' or @venno = '1980' or @venno = '1983' or @venno = '1825' or @venno = '1839' or
	@venno = '1884' or @venno = '1974' or @venno = '1995'
	or @venno = '1463')
begin
	insert into #TEMP_CAT (tmp_cat) values ('FLORAL FTY')
end

-- Added Venno 1463 at 20150106
-- Added Venno 1995 at 20150127

--select * from #TEMP_CAT

create table #TEMP_PRCTRM (tmp_prctrm nvarchar(20))
insert into #TEMP_PRCTRM (tmp_prctrm) values (left(@prctrm,3))
--insert into #TEMP_PRCTRM (tmp_prctrm) values (@prctrm)

create table #TEMP_TRANTRM (tmp_trantrm nvarchar(20))
insert into #TEMP_TRANTRM (tmp_trantrm) values (left(@trantrm,3))

create table #TEMP_FML_RESULT (
tmp_cus1no	nvarchar(10),
tmp_cus2no	nvarchar(10),
tmp_venno	nvarchar(20),
tmp_cat		nvarchar(20),
tmp_prctrm	nvarchar(20),
tmp_trantrm	nvarchar(20)
)






insert into #TEMP_FML_RESULT
select ccf_cus1no, ccf_cus2no, ccf_venno, ccf_cat, ccf_prctrm, ccf_trantrm
from CUCALFML (nolock), #TEMP_CUST (nolock), #TEMP_VEN (nolock), #TEMP_CAT (nolock), #TEMP_PRCTRM (nolock), #TEMP_TRANTRM (nolock)
where ccf_cus1no = tmp_cus1no and ccf_cus2no = tmp_cus2no and 
ccf_venno = tmp_venno and 
ccf_cat = tmp_cat and 
left(ccf_prctrm,3) = left(tmp_prctrm,3)
and ccf_trantrm = tmp_trantrm
and ccf_iseff = 'Y'   ---2014

--select * from #TEMP_CUST
--select * from #TEMP_VEN
--select * from #TEMP_CAT
--select * from #TEMP_PRCTRM
--select * from #TEMP_TRANTRM


--select '000', * from #TEMP_FML_RESULT
if ( select count(*) from #TEMP_FML_RESULT (nolock)) >= 1
begin

-- 0. Filter PrcTrm, TranTrm (currently no use)
--set @final_prctrm = @prctrm
--set @final_trantrm = @trantrm

-- 1. Filter Vendor
if (select count(*) from #TEMP_FML_RESULT (nolock) where tmp_venno <> 'ALL') >= 1
begin
	delete from #TEMP_FML_RESULT where tmp_venno = 'ALL'
end
--select '001',@ventyp,* from #TEMP_FML_RESULT
if (select count(*) from #TEMP_FML_RESULT (nolock) where tmp_venno <> 'INT' and tmp_venno <> 'EXT') >= 1
begin
	delete from #TEMP_FML_RESULT where tmp_venno in ('INT','EXT')
end
else
begin
	if @ventyp = 'E'
	begin
		delete from #TEMP_FML_RESULT where tmp_venno in ('INT')
	end
	else
	begin
		delete from #TEMP_FML_RESULT where tmp_venno in ('EXT')
	end
end
--select '002',* from #TEMP_FML_RESULT

-- 2. Filter Category
if (select count(*) from #TEMP_FML_RESULT (nolock) where tmp_cat <> 'STANDARD') >= 1
begin
	delete from #TEMP_FML_RESULT where tmp_cat = 'STANDARD'
end
--select '003',* from #TEMP_FML_RESULT

if (select count(*) from #TEMP_FML_RESULT (nolock) where tmp_cat <> 'XMAS TREE') >= 1
begin
	delete from #TEMP_FML_RESULT where tmp_cat = 'XMAS TREE'
end


--select '004',* from #TEMP_FML_RESULT

-- 3. Filter Customer
if (select count(*) from #TEMP_FML_RESULT (nolock) where tmp_cus2no <> '') >= 1
begin
	delete from #TEMP_FML_RESULT where tmp_cus2no = ''
end

--select '005',* from #TEMP_FML_RESULT

---starting from UAT2, could be more than one formular
---Just select the latest one by processing
if (select count(*) from #TEMP_FML_RESULT (nolock)) >= 1 
begin
	select @final_cus1no = tmp_cus1no, @final_cus2no = tmp_cus2no, @final_venno = tmp_venno, @final_itmcat = tmp_cat, @final_prctrm = tmp_prctrm, @final_trantrm = tmp_trantrm from #TEMP_FML_RESULT (nolock)
end
else
begin
	set @final_cus1no = ''
	set @final_cus2no = ''
	set @final_venno = ''
	set @final_itmcat = ''
	set @final_prctrm = ''
	set @final_trantrm = ''
end

end
else
begin

set @final_cus1no = ''
set @final_cus2no = ''
set @final_venno = ''
set @final_itmcat = ''
set @final_prctrm = ''
set @final_trantrm = ''

end

--select @final_cus1no,@final_cus2no,@final_venno,@final_itmcat,@final_prctrm,@final_trantrm

--select * from #TEMP_CUST
--select * from #TEMP_VEN
--select * from #TEMP_CAT
--select * from #TEMP_PRCTRM
--select * from #TEMP_TRANTRM


declare	@ventranflg	char(1)

set 	@ventranflg = ''

if (	select	count(*)
	from	CUCALFML
	where	ccf_cocde = @cocde		and
		ccf_cus1no = @cus1no	and
		ccf_venno = @ventyp		and
		ccf_cat = @itmcat
		) = 0
begin
	set @itmcat = 'STANDARD'
end




select	@ventranflg = vbi_ventranflg
from	VNBASINF
where	vbi_venno = @venno


------------------UAT2----------------------
create table #pre_date (a_date datetime)




insert into #pre_date
select ccf_effdat
from CUCALFML
where ccf_cocde = ''		and
	ccf_cus1no = @final_cus1no 
	 and ccf_cus2no = @final_cus2no 
	and ccf_venno = @final_venno and 
	ccf_cat = @final_itmcat 
	and left(ccf_prctrm,3) = left(@final_prctrm,3) 
	and ccf_trantrm = @final_trantrm
	and ccf_iseff = 'Y'
	and DATEDIFF(mi,ccf_effdat,getdate())	> 0
			-- earlier than today, cmoparing minute

select @max_a_date = max(a_date) 
from
#pre_date

--
if @max_a_date is null
begin
	set @max_a_date = '1900-01-01'
end
--


------------------UAT2-----------------------


select	ccf_cocde,		ccf_cus1no,	ccf_cus2no,
	ccf_cat,		ccf_venno,	@ventranflg as 'ccf_ventranflg',
	ccf_prctrm,		ccf_trantrm,	
	ccf_curcde,
	ccf_cumu*100 as'ccf_cumu',		ccf_pm*100 as 'ccf_pm',		ccf_cush*100 as 'ccf_cush',
	ccf_thccusper*100 as 'ccf_thccusper',	ccf_upsper*100 as 'ccf_upsper',		ccf_labper*100 as 'ccf_labper',
	ccf_faper*100 as 'ccf_faper',		ccf_cstbufper*100 as 'ccf_cstbufper',	ccf_othper*100 as 'ccf_othper',
	ccf_pliper*100 as 'ccf_pliper',		ccf_dmdper*100 as 'ccf_dmdper',	ccf_rbtper*100 as 'ccf_rbtper',
	ccf_pkgper*100 as 'ccf_pkgper',	ccf_comper*100 as 'ccf_comper',	ccf_icmper*100 as 'ccf_icmper'
from 	CUCALFML (nolock)
where	ccf_cocde = ''		and
	ccf_cus1no = @final_cus1no and ccf_cus2no = @final_cus2no and ccf_venno = @final_venno and 
	ccf_cat = @final_itmcat and left(ccf_prctrm,3) = left(@final_prctrm,3) and ccf_trantrm = @final_trantrm
	and ccf_iseff = 'Y'
	and ccf_effdat = @max_a_date  ---

drop table #TEMP_CUST
drop table #TEMP_VEN
drop table #TEMP_CAT
drop table #TEMP_PRCTRM
drop table #TEMP_TRANTRM
drop table #TEMP_FML_RESULT







/*
declare	@ventran	char(1)

set 	@ventran = ''

if (	select	count(*)
	from	CUCALFML
	where	ccf_cocde = @cocde		and
		ccf_cus1no = @cus1no	and
		ccf_venno = @ventyp		and
		ccf_cat = @itmcat) = 0
begin
	set @itmcat = 'STANDARD'
end

select	@ventran = vbi_ventyp
from	VNBASINF
where	vbi_cocde = @cocde		and
	vbi_venno = @venno

select	ccf_cocde,		ccf_cus1no,	ccf_cus2no,
	ccf_cat,		ccf_venno as 'ccf_ventyp',		ccf_curcde,
	ccf_cumu,		ccf_pm,		ccf_cush,
	ccf_thccusper,	ccf_upsper,		ccf_labper,
	ccf_faper,		ccf_cstbufper,	ccf_othper,
	ccf_pliper,		ccf_dmdper,	ccf_rbtper,
	ccf_pkgper,	ccf_comper,	ccf_icmper,
	@ventran as 'ccf_ventran'
from 	CUCALFML (nolock)
where	ccf_cocde = @cocde		and
	ccf_cus1no = @cus1no	and
	ccf_venno = @ventyp		and
	ccf_cat = @itmcat

*/
GO
GRANT EXECUTE ON [dbo].[sp_select_QUPRCEMT_CU] TO [ERPUSER] AS [dbo]
GO
