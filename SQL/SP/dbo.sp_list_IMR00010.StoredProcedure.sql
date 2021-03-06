/****** Object:  StoredProcedure [dbo].[sp_list_IMR00010]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMR00010]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMR00010]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE    PROCEDURE [dbo].[sp_list_IMR00010]

@cocde as nvarchar(6),
@stage as nvarchar(30),
@fromcusno as nvarchar(6),
@tocusno as nvarchar(6),
@fromcredat as nvarchar(10),
@tocredat as nvarchar(10),
@usrid as nvarchar(30)
-------------------------------

AS

create table #TEMP_CUST
(
tmp_cusno nvarchar(6)
)

create table #TEMP_SALTEM
(
tmp_saltem nvarchar(10)
)


--declare @saltem nvarchar(6)
--select @saltem = isnull(ysr_saltem, '') from SYSALREP where ysr_code = @usrid
insert into #TEMP_SALTEM
select isnull(yur_para, '') from SYUSRRIGHT where yur_usrid = @usrid and yur_doctyp = 'QU' and yur_lvl = 1

declare @saltemS int
set @saltemS = 0

select @saltemS = count(*) from #TEMP_SALTEM where tmp_saltem = 'S'

if (@usrid = 'mis') or (@saltemS >= 1) -- full control for Cus Style
begin
	insert into #TEMP_CUST
	select cbi_cusno from CUBASINF where cbi_cusno between @fromcusno and @tocusno 
end
else
begin
	insert into #TEMP_CUST
	select cbi_cusno from CUBASINF, SYSALREP, #TEMP_SALTEM  
	where cbi_cusno between @fromcusno and @tocusno
	and cbi_salrep = ysr_code1 
	and ysr_saltem = tmp_saltem
end


declare @W as char(1)
declare @A as char(1)
declare @R as char(1)
declare @O as char(1)
declare @I as char(1)
--@A@,@I@,@O@,@R@,@W@
if charindex('@W@', @stage) > 0
	set @W = 'Y'
else
	set @W = 'N'

if charindex('@A@', @stage) > 0
	set @A = 'Y'
else
	set @A = 'N'

if charindex('@R@', @stage) > 0
	set @R = 'Y'
else
	set @R = 'N'

if charindex('@O@', @stage) > 0
	set @O = 'Y'
else
	set @O = 'N'

if charindex('@I@', @stage) > 0
	set @I = 'Y'
else
	set @I = 'N'

declare @outputoption nvarchar(100)
set @outputoption = ''
if @W = 'Y'
begin
set @outputoption = @outputoption + ' W ,'
end

if @A = 'Y'
begin
set @outputoption = @outputoption + ' A ,'
end

if @R = 'Y'
begin
set @outputoption = @outputoption + ' R ,'
end

if @O = 'Y'
begin
set @outputoption = @outputoption + ' O ,'
end

if @I = 'Y'
begin
set @outputoption = @outputoption + ' I ,'
end

if len(@outputoption) > 0
begin
set @outputoption = substring(@outputoption,1, len(@outputoption) -1)
end

--" A , I , O , R , W "




select-- distinct
a.iic_sts as 'iid_stage',--0
a.iic_cusno as 'iid_cusno',--1
a.iic_cusstyno as 'iic_cusstyno',--2 
a.iic_upload as 'iic_upload',--3
a.iic_itmno as 'iic_itmno',--4 
a.iic_seq as 'iic_seq',--5
a.iic_mode as 'iic_mode',--6
a.iic_sysmsg + ' (' +a.iic_filnam  + ')' as 'iic_sysmsg', --7
@outputoption as 'stage', --8
@fromcusno as 'fromcusno',
@tocusno as 'tocusno',
@fromcredat as 'fromcredat',
@tocredat as 'tocredat'

,cast(a.iic_credat as smalldatetime) as 'credat' -- this field will not be shown in rpt
 from   IMITMCUSSTY a
left join  SYSALREP on ysr_code = a.iic_creusr 
, #TEMP_CUST

--Added by Mark Lau 20081204


 where
tmp_cusno = a.iic_cusno
and
a.iic_credat  between @fromcredat + ' 00:00:00'  and  @tocredat + ' 23:59:59'   and 
( (@W = 'Y' and a.iic_sts = 'W') or (@A = 'Y' and a.iic_sts = 'A') or 
 (@R = 'Y' and a.iic_sts = 'R') or (@O = 'Y' and a.iic_sts = 'O') or 
 (@I = 'Y' and a.iic_sts = 'I'))


union



select-- distinct
a.iic_sts as 'iid_stage',--0
a.iic_cusno as 'iid_cusno',--1
a.iic_cusstyno as 'iic_cusstyno',--2 
a.iic_upload as 'iic_upload',--3
a.iic_itmno as 'iic_itmno',--4 
a.iic_seq as 'iic_seq',--5
a.iic_mode as 'iic_mode',--6
a.iic_sysmsg + ' (' +a.iic_filnam  + ')' as 'iid_sysmsg', --7
@outputoption as 'stage', --8
@fromcusno as 'fromcusno',
@tocusno as 'tocusno',
@fromcredat as 'fromcredat',
@tocredat as 'tocredat'

,cast(a.iic_credat as smalldatetime) as 'credat' -- this field will not be shown in rpt
 from   IMITMCUSSTYH a
--Added by Mark Lau 20081204
left join  SYSALREP on ysr_code = a.iic_creusr 
, #TEMP_CUST



 where
tmp_cusno = a.iic_cusno 
and
a.iic_credat  between @fromcredat + ' 00:00:00'  and  @tocredat + ' 23:59:59'   and 
( (@W = 'Y' and a.iic_sts = 'W') or (@A = 'Y' and a.iic_sts = 'A') or 
 (@R = 'Y' and a.iic_sts = 'R') or (@O = 'Y' and a.iic_sts = 'O') or 
 (@I = 'Y' and a.iic_sts = 'I'))


union


select-- distinct
a.iic_sts as 'iid_stage',--0
a.iic_cusno as 'iid_cusno',--1
a.iic_cusstyno as 'iic_cusstyno',--2 
a.iic_upload as 'iic_upload',--3
a.iic_itmno as 'iic_itmno',--4 
a.iic_seq as 'iic_seq',--5
a.iic_mode as 'iic_mode',--6
a.iic_sysmsg + ' (' +a.iic_filnam  + ')' as 'iid_sysmsg', --7
@outputoption as 'stage', --8
@fromcusno as 'fromcusno',
@tocusno as 'tocusno',
@fromcredat as 'fromcredat',
@tocredat as 'tocredat'

,cast(a.iic_credat as smalldatetime) as 'credat' -- this field will not be shown in rpt
 from   IMITMCUSSTY a
left join  SYSALREP on ysr_code = a.iic_creusr 

--Added by Mark Lau 20081204


 where
a.iic_credat  between @fromcredat + ' 00:00:00'  and  @tocredat + ' 23:59:59'   and 
( (@W = 'Y' and a.iic_sts = 'W') or (@A = 'Y' and a.iic_sts = 'A') or 
 (@R = 'Y' and a.iic_sts = 'R') or (@O = 'Y' and a.iic_sts = 'O') or 
 (@I = 'Y' and a.iic_sts = 'I'))
and substring(iic_sysmsg,1,6) in ('[E004]', '[E006]')





 order by a.iic_sts, a.iic_cusno,  
--cast(a.iic_credat as smalldatetime) 
[credat]
, a.iic_cusstyno






GO
GRANT EXECUTE ON [dbo].[sp_list_IMR00010] TO [ERPUSER] AS [dbo]
GO
