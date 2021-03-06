/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL_CTNETD]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHIPGDTL_CTNETD]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL_CTNETD]    Script Date: 09/29/2017 11:53:54 ******/
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

CREATE         procedure [dbo].[sp_select_SHIPGDTL_CTNETD]


@hid_cocde	nvarchar(6),
@hid_ctnno	nvarchar(20),
@hid_etddat	datetime

 
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
tmp_hid_ctrcfs	nvarchar(20),
tmp_hid_sealno	nvarchar(20),
tmp_hid_ctrsiz	nvarchar(20),
tmp_hid_ttlvol	numeric(13,4),
tmp_hid_ttlvol_man	numeric(13,4)
)

insert into #TEMP_LIST
select distinct
hih_cocde,hih_shpno,hih_cus1no,hih_cus2no,hih_shpsts,
hih_slnonb,hid_shpseq,hid_invno,sod_cusven,hid_ctrcfs,
hid_sealno,hid_ctrsiz,
sod_cbm*sod_ttlctn
--hid_ttlvol
,hpd_ttlcbm_cm
 from SHIPGDTL (nolock) 
	left join SHIPGHDR (nolock)
	on hih_cocde = hid_cocde 
	and hih_shpno = hid_shpno 
	left join SCORDDTL (nolock)
	on hid_ordno = sod_ordno
	and hid_ordseq = sod_ordseq
	left join SHPCKDIM (nolock)
	on	hid_shpno = hpd_shpno 
	and hid_shpseq = hpd_shpseq
	and  hpd_dimtyp = 'Act'

	where hih_slnonb = @hid_etddat 
	and hid_ctrcfs = @hid_ctnno
	and (
	(hid_ctnftr = 1 and ( hpd_pdnum = 5 or hpd_pdnum = 6 )) 
	or (hid_ctnftr = 2 and ( hpd_pdnum = 1 or hpd_pdnum = 2 or hpd_pdnum = 3 or hpd_pdnum = 4 ))   
	)
	

-- Invoice List
declare @invlist nvarchar(200)
declare @invno nvarchar(20)

declare @fcrlist nvarchar(500)
declare @fcrno nvarchar(50)

declare @ctmnolist nvarchar(500)
declare @ctmnamelist nvarchar(500)
declare @ctmno nvarchar(50)
declare @ctmname nvarchar(50)


set @invlist = ''
set @invno = ''
set @fcrlist = ''
set @fcrno = ''
set @ctmnolist  = ''
set @ctmnamelist  = ''
set @ctmno  = ''
set @ctmname  = ''

Declare cur_invlist cursor
for
select distinct tmp_hid_invno from #TEMP_LIST


Open cur_invlist
Fetch next from cur_invlist into @invno

While @@fetch_status = 0
Begin
	set @invlist = @invlist + @invno + ','

	set @fcrno = (select hiv_doc from 
				shinvhdr
				where hiv_invno = @invno
					--and hiv_doctyp like '%FCR%'
					)		
--			select  @invno as '1'
	set @fcrlist = @fcrlist + @fcrno + ','

	set @ctmname = (
			select distinct cbi_cussna
			from 	shinvhdr
			left join shipgdtl on hiv_shpno = hid_shpno
			left join shipghdr on hih_shpno = hid_shpno
			left join CUBASINF on  cbi_cusno = hih_cus1no
			where  hiv_invno = @invno
			)	
	set @ctmnamelist = @ctmnamelist + @ctmname + ','
	set @ctmno = (
			select distinct hih_cus1no
			from 	shinvhdr
			left join shipgdtl on hiv_shpno = hid_shpno
			left join shipghdr on hih_shpno = hid_shpno
			where  hiv_invno = @invno
			)	
	set @ctmnolist = @ctmnolist + @ctmno + ','

	fetch next from cur_invlist into @invno
end
if @invlist <> ''
begin
	set @invlist = substring(@invlist,1, len(@invlist)-1)
end
if @fcrlist <> ''
begin
	set @fcrlist = substring(@fcrlist,1, len(@fcrlist)-1)
end
if @ctmnolist <> ''
begin
	set @ctmnolist = substring(@ctmnolist,1, len(@ctmnolist)-1)
end
if @ctmnamelist <> ''
begin
	set @ctmnamelist = substring(@ctmnamelist,1, len(@ctmnamelist)-1)
end

Close cur_invlist
Deallocate cur_invlist



-- Customer List
declare @cuslist nvarchar(200)
declare @cusnamlist nvarchar(200)
declare @cusno nvarchar(20)
declare @cussna nvarchar(20)

set @cuslist = ''
set @cusnamlist = ''
set @cusno = ''
set @cussna = ''

Declare cur_cuslist cursor
for
select tmp_hih_cus1no, cbi_cussna from #TEMP_LIST, CUBASINF
			 where cbi_cusno = tmp_hih_cus1no
--select distinct tmp_hih_cus1no, cbi_cussna from #TEMP_LIST, CUBASINF where cbi_cusno = tmp_hih_cus1no

Open cur_cuslist
Fetch next from cur_cuslist into @cusno, @cussna

While @@fetch_status = 0
Begin
	set @cuslist = @cuslist + @cusno + ','
	set @cusnamlist = @cusnamlist + @cussna + ','

	fetch next from cur_cuslist into @cusno, @cussna
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
@fcrlist 'tmp_fcrlist',
@ctmnamelist 'tmp_cuslist',
@ctmnolist  'tmp_cusnolist', 
--@cusnamlist 'tmp_cuslist',
--@cuslist 'tmp_cusnolist', 
@ttlcbm 'tmp_ttlcbm', 
@ctrsiz 'tmp_ctrsiz',
'' 'tmp_creusr',
tmp_hid_venno 'tmp_vbi_venno', 
vbi_vensna 'tmp_vbi_vensna', 
sum(tmp_hid_ttlvol) 'tmp_cbm',
sum(tmp_hid_ttlvol_man) 'tmp_mancbm' 
from #TEMP_LIST, VNBASINF
where vbi_venno = tmp_hid_venno
group by tmp_hid_venno, vbi_vensna
drop table #TEMP_LIST




END

















GO
GRANT EXECUTE ON [dbo].[sp_select_SHIPGDTL_CTNETD] TO [ERPUSER] AS [dbo]
GO
