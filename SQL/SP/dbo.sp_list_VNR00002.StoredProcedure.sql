/****** Object:  StoredProcedure [dbo].[sp_list_VNR00002]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNR00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNR00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 28/07/2003

CREATE PROCEDURE [dbo].[sp_list_VNR00002]

@cocde as nvarchar(10),
@fromyymm as nvarchar(5),
@toyymm as nvarchar(5),
@fromcatlvl4 as nvarchar(30),
@tocatlvl4 as nvarchar(30),
@ascdesc as nvarchar(4),
@NoofVen as int

as

declare @yymm1 as nvarchar(5)
declare @yymm2 as nvarchar(5)
declare @yymm3 as nvarchar(5)
declare @yymm4 as nvarchar(5)
declare @yymm5 as nvarchar(5)
declare @yymm6 as nvarchar(5)
declare @yymm7 as nvarchar(5)
declare @yymm8 as nvarchar(5)
declare @yymm9 as nvarchar(5)
declare @yymm10 as nvarchar(5)
declare @yymm11 as nvarchar(5)
declare @yymm12 as nvarchar(5)


declare @yy as integer
declare @mm as integer
declare @tempyy as integer
declare @counter as integer


set @yy = cast(left(@fromyymm,2) as integer)
set @mm = cast(right(@fromyymm,2) as integer)
set @counter =1

set @yymm1 = @fromyymm

--select @yymm1
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if @mm + @counter >12
	set  @yymm2 = replicate('0',2-len(ltrim(str(@yy+1)))) + ltrim(str(@yy+1)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm2 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +   replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm2
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter =  2
if @mm +  @counter >12
	set  @yymm3 = replicate('0',2-len(ltrim(str(@yy+1)))) + ltrim(str(@yy+1)) + '/' + replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm3 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +   replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm3
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 3
if @mm +  @counter >12
	set  @yymm4 = replicate('0',2-len(ltrim(str(@yy+1)))) + ltrim(str(@yy+1)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm4 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +   replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm4
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 4
if @mm +  @counter >12
	set  @yymm5 = replicate('0',2-len(ltrim(str(@yy+1)))) + ltrim(str(@yy+1)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm5 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +   replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm5
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 5
if @mm +  @counter >12
	set  @yymm6 = replicate('0',2-len(ltrim(str(@yy+1)))) + ltrim(str(@yy+1)) + '/' +   replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm6 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +   replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm6
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 6
if @mm +  @counter >12
	set  @yymm7 = replicate('0',2-len(ltrim(str(@yy + 1)))) + ltrim(str(@yy + 1)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm7 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm7
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 7
if @mm +  @counter >12
	set  @yymm8 = replicate('0',2-len(ltrim(str(@yy + 1)))) + ltrim(str(@yy + 1)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm8 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +   replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm8
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 8
if @mm +  @counter >12
	set  @yymm9 = replicate('0',2-len(ltrim(str(@yy + 1)))) + ltrim(str(@yy + 1)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm9 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm9
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 9
if @mm +  @counter >12
	set  @yymm10 = replicate('0',2-len(ltrim(str(@yy + 1)))) + ltrim(str(@yy + 1)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm10 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm10
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 10
if @mm +  @counter >12
	set  @yymm11 = replicate('0',2-len(ltrim(str(@yy + 1)))) + ltrim(str(@yy + 1)) + '/' +   replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm11 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm11
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

set @counter = 11
if @mm +  @counter > 12
	set  @yymm12 = replicate('0',2-len(ltrim(str(@yy + 1)))) + ltrim(str(@yy+1)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
else
	set  @yymm12 = replicate('0',2-len(ltrim(str(@yy)))) + ltrim(str(@yy)) + '/' +  replicate('0',2-len(ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end)))) + ltrim(str(case (@mm+@counter)%12 when 0 then 12 else (@mm+@counter)%12 end))
--select @yymm12
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

if @yymm2 > @toyymm begin set @yymm2 = "*****" end
if @yymm3 > @toyymm begin set @yymm3 = "*****" end
if @yymm4 > @toyymm begin set @yymm4 = "*****" end
if @yymm5 > @toyymm begin set @yymm5 = "*****" end
if @yymm6 > @toyymm begin set @yymm6 = "*****" end
if @yymm7 > @toyymm begin set @yymm7 = "*****" end
if @yymm8 > @toyymm begin set @yymm8 = "*****" end
if @yymm9 > @toyymm begin set @yymm9 = "*****" end
if @yymm10 > @toyymm begin set @yymm10 = "*****" end
if @yymm11 > @toyymm begin set @yymm11 = "*****" end
if @yymm12 > @toyymm begin set @yymm12 = "*****" end



declare @s as nvarchar(4000)
-- top ' + ltrim(str(@noofvendor)) + ' ' +
set @s = 'select  b.vcr_catlvl4, c.vbi_vensna, c.vbi_curcde, a.*
from vncatrel b 
inner join 
(select  vpf_cocde, vpf_venno,
sum(case vpf_yymm when ''' + @yymm1 + ''' then vpf_mpoamt else 0 end) as [AMTyymm1],
sum(case vpf_yymm when ''' + @yymm2 + ''' then vpf_mpoamt else 0 end) as [AMTyymm2],
sum(case vpf_yymm when ''' + @yymm3 + ''' then vpf_mpoamt else 0 end) as [AMTyymm3],
sum(case vpf_yymm when ''' + @yymm4 + ''' then vpf_mpoamt else 0 end) as [AMTyymm4],
sum(case vpf_yymm when ''' + @yymm5 + ''' then vpf_mpoamt else 0 end) as [AMTyymm5],
sum(case vpf_yymm when ''' + @yymm6 + ''' then vpf_mpoamt else 0 end) as [AMTyymm6],
sum(case vpf_yymm when ''' + @yymm7 + ''' then vpf_mpoamt else 0 end) as [AMTyymm7],
sum(case vpf_yymm when ''' + @yymm8 + ''' then vpf_mpoamt else 0 end) as [AMTyymm8],
sum(case vpf_yymm when ''' + @yymm9 + ''' then vpf_mpoamt else 0 end) as [AMTyymm9],
sum(case vpf_yymm when ''' + @yymm10 + ''' then vpf_mpoamt else 0 end) as [AMTyymm10],
sum(case vpf_yymm when ''' + @yymm11 + ''' then vpf_mpoamt else 0 end) as [AMTyymm11],
sum(case vpf_yymm when ''' + @yymm12 + ''' then vpf_mpoamt else 0 end) as [AMTyymm12],
sum(vpf_mpoamt) as YTD,
''' + @yymm1 + ''' as [yymm1],
''' + @yymm2 + ''' as [yymm2],
''' + @yymm3 + ''' as [yymm3],
''' + @yymm4 + ''' as [yymm4],
''' + @yymm5 + ''' as [yymm5],
''' + @yymm6 + ''' as [yymm6],
''' + @yymm7 + ''' as [yymm7],
''' + @yymm8 + ''' as [yymm8],
''' + @yymm9 + ''' as [yymm9],
''' + @yymm10 + ''' as [yymm10],
''' + @yymm11 + ''' as [yymm11],
''' + @yymm12 + ''' as [yymm12],
''' + @fromyymm + ''' as [@fromyymm],
''' + @toyymm + ''' as [@toyymm],
''' + @fromcatlvl4 + ''' as [@fromcatlvl4],
''' + @tocatlvl4 + ''' as [@tocatlvl4],
''' + @ascdesc + ''' as [@ascdesc],
''' + str(@NoofVen) + ''' as [@NoofVen]

from vnpucinf
where 
--vpf_cocde =  ''' + @cocde + ''' and
vpf_yymm >=  ''' + @yymm1 + ''' and 
vpf_yymm <=  ''' + @toyymm + '''
group by vpf_cocde, vpf_venno) a  

on b.vcr_cocde = a.vpf_cocde and b.vcr_venno = a. vpf_venno 
--left join vnbasinf c on c.vbi_cocde = b.vcr_cocde and c.vbi_venno = b.vcr_venno
left join vnbasinf c on c.vbi_venno = b.vcr_venno
where 
b.vcr_catlvl4 between  ''' + @fromcatlvl4 + ''' and ''' + @tocatlvl4 + '''  
 order by  b.vcr_catlvl4, a.YTD ' + @ascdesc

exec(@s)








GO
GRANT EXECUTE ON [dbo].[sp_list_VNR00002] TO [ERPUSER] AS [dbo]
GO
