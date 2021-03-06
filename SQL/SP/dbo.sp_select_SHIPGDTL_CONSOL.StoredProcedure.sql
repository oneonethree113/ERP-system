/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL_CONSOL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHIPGDTL_CONSOL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL_CONSOL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SHCHGDTL
***********************************************************************
*/

CREATE     procedure [dbo].[sp_select_SHIPGDTL_CONSOL]


@hid_cocde	nvarchar(6),
@hid_consolno	nvarchar(30)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------

create table #TEMP_LIST
(
tmp_hih_cocde	nvarchar(6),
tmp_hih_shpno	nvarchar(20),
tmp_hih_cus1no	nvarchar(10),
tmp_hih_cus2no	nvarchar(10),
tmp_hih_shpsts	nvarchar(6),
tmp_hih_slnonb	datetime,
tmp_hid_shpseq	int,
tmp_hid_invno	nvarchar(20),
tmp_hid_venno	nvarchar(10),
tmp_hid_consolno	nvarchar(20),
tmp_hid_sealno	nvarchar(20),
tmp_hid_ctrsiz	nvarchar(20),
tmp_hid_ttlvol	numeric(13,4)
)

insert into #TEMP_LIST
select distinct
hih_cocde,hih_shpno,hih_cus1no,hih_cus2no,hih_shpsts,
hih_slnonb,hid_shpseq,hid_invno,hid_venno,hid_consolno,
hid_sealno,hid_ctrsiz,hid_ttlvol
 from SHIPGHDR (nolock), SHIPGDTL (nolock)
where hih_cocde = hid_cocde and hih_shpno = hid_shpno 
and hid_consolno = @hid_consolno


-- Invoice List
declare @invlist nvarchar(200)
declare @invno nvarchar(20)

set @invlist = ''
set @invno = ''

Declare cur_invlist cursor
for
select distinct tmp_hid_invno from #TEMP_LIST

Open cur_invlist
Fetch next from cur_invlist into @invno

While @@fetch_status = 0
Begin
	set @invlist = @invlist + @invno + ','

	fetch next from cur_invlist into @invno
end
if @invlist <> ''
begin
	set @invlist = substring(@invlist,1, len(@invlist)-1)
end

Close cur_invlist
Deallocate cur_invlist



-- Customer List
declare @cuslist nvarchar(200)
declare @cusnamlist nvarchar(200)
declare @cusno nvarchar(20)
declare @cussna nvarchar(20)
declare @hid_invno nvarchar(20)

set @cuslist = ''
set @cusnamlist = ''
set @cusno = ''
set @cussna = ''
set @hid_invno = ''

Declare cur_cuslist cursor
for
select distinct a.tmp_hih_cus1no, cbi_cussna, a.tmp_hid_invno  from #TEMP_LIST a 
				left join  CUBASINF on cbi_cusno = a.tmp_hih_cus1no

Open cur_cuslist
Fetch next from cur_cuslist into @cusno, @cussna ,@hid_invno

While @@fetch_status = 0
Begin
	set @cuslist = @cuslist + @cusno + ','
	set @cusnamlist = @cusnamlist + @cussna + ','

	fetch next from cur_cuslist into @cusno, @cussna ,@hid_invno
end

if @cuslist <> '' 
begin
	set @cuslist = substring(@cuslist,1, len(@cuslist)-1)
	set @cusnamlist = substring(@cusnamlist,1, len(@cusnamlist)-1)
end

Close cur_cuslist
Deallocate cur_cuslist



-- Total CBM
declare @ttlcbm numeric(13,4)
select @ttlcbm = sum(tmp_hid_ttlvol) from #TEMP_LIST

-- Container Size
declare @ctrsiz nvarchar(20)
select @ctrsiz = tmp_hid_ctrsiz from #TEMP_LIST


select 
'' as 'tmp_fwdnam',
@invlist 'tmp_invlist',
@cusnamlist 'tmp_cuslist',
@cuslist 'tmp_cusnolist', 
@ttlcbm 'tmp_ttlcbm', 
@ctrsiz 'tmp_ctrsiz',
'' 'tmp_creusr',
tmp_hid_venno 'tmp_vbi_venno', 
vbi_vensna 'tmp_vbi_vensna', 
sum(tmp_hid_ttlvol) 'tmp_cbm',
sum(tmp_hid_ttlvol) 'tmp_mancbm' 
from #TEMP_LIST, VNBASINF
where vbi_venno = tmp_hid_venno
group by tmp_hid_venno, vbi_vensna
drop table #TEMP_LIST




END













GO
GRANT EXECUTE ON [dbo].[sp_select_SHIPGDTL_CONSOL] TO [ERPUSER] AS [dbo]
GO
