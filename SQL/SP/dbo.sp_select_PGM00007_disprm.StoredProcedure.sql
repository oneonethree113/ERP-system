/****** Object:  StoredProcedure [dbo].[sp_select_PGM00007_disprm]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PGM00007_disprm]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PGM00007_disprm]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






--sp_select_PGM00007_disprm 'UCP', 'KP1400167,KP1400168'

create PROCEDURE [dbo].[sp_select_PGM00007_disprm] 
@cocde as nvarchar(6),
@ordnolist as nvarchar(2000)

AS

BEGIN

create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]

create table #TEMP_ORDNO (tmp_ordno nvarchar(20)) on [PRIMARY]

declare	@fm nvarchar(100), @to nvarchar(100)

declare @strPart nvarchar(1000), @strRemain nvarchar(1000)

set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''


--#TEMP_ORDNO
if ltrim(rtrim(@ordnolist)) <> ''
begin
	delete from #TEMP_INIT
	set @strRemain = @ordnolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select poh_ordno from PKORDHDR (nolock) where poh_ordno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select poh_ordno from PKORDHDR (nolock) where poh_ordno like @strPart
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
			select poh_ordno from PKORDHDR where poh_ordno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select poh_ordno from PKORDHDR where poh_ordno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_ORDNO
	select distinct tmp_init from #TEMP_INIT
end


declare @ttlamt as numeric(13,2)
declare @delamt as numeric(13,2)
declare @ttldelamt as numeric(13,2)
declare @curcde as nvarchar(20)

select @ttlamt = sum(poh_ttlamt) ,
         @delamt = sum(poh_delamt),
	@ttldelamt = sum(poh_ttldelamt)
	from 
#TEMP_ORDNO ord
left join pkordhdr on ord.tmp_ordno = poh_ordno

select @curcde = pod_curcde
from
#TEMP_ORDNO ord
left join pkorddtl on ord.tmp_ordno = pod_ordno

 
 


select 
ord.tmp_ordno as 'poh_ordno',
@ttlamt as 'ttlamt',
@delamt as 'delamt',
@ttldelamt as 'ttldelamt',
case isnull(pdp_amt,0) when 0 then '' else case pdp_pctamt when 'Percentage' then 
	case pdp_type when 'D' then 'Less- '+convert(nvarchar(20),pdp_pct)+ '%' + pdp_dsc else
				       'Plus- '+convert(nvarchar(20),pdp_pct)+ '%' + pdp_dsc end 
 else case pdp_type when  'D' then     'Less- '+ pdp_dsc else 
			                    'Plus- ' + pdp_dsc  end end end  as 'Dsc' ,
isnull(pdp_amt,0) as 'amt' ,
@curcde as 'curcde'

from 
#TEMP_ORDNO ord
left join pkdisprm on pdp_ordno = ord.tmp_ordno 



drop table #TEMP_INIT
drop table #TEMP_ORDNO



END




GO
GRANT EXECUTE ON [dbo].[sp_select_PGM00007_disprm] TO [ERPUSER] AS [dbo]
GO
