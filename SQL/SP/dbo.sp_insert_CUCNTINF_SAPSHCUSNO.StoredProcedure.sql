/****** Object:  StoredProcedure [dbo].[sp_insert_CUCNTINF_SAPSHCUSNO]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUCNTINF_SAPSHCUSNO]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUCNTINF_SAPSHCUSNO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE procedure [dbo].[sp_insert_CUCNTINF_SAPSHCUSNO]
@cocde nvarchar(6),
@value as nvarchar(20),
@cusbatch as nvarchar(1) -- 'Y' /'N'
AS

if @value <> '' and @cusbatch <> ''
begin

declare @intsapshcusno  int
declare @intcounter int
declare @cbi_cusno nvarchar(6)
declare @cci_cnttyp  nvarchar(6)
declare @CCI_CNTSEQ int
declare  @intCurrentNo int 
declare @type nvarchar(20)

set @type = ''
set @cbi_cusno = ''
set @intsapshcusno = 0
set @intcounter = 0 
set @CCI_CNTSEQ = 0 
set @cci_cnttyp = ''
set @intCurrentNo = 0

if upper(@cusbatch) = 'Y'
begin
if upper(@value) = 'P'
begin
set @type = '5%'
end

if  upper(@value) = 'S'
begin
set @type = '6%'
end
end

else if upper(@cusbatch) = 'N'
begin
set @type = @value
end

DECLARE Cust_Cursor CURSOR FOR 
select cbi_cusno from cubasinf where cbi_cusno like @type
--select cbi_cusno from cubasinf where cbi_cusno = '50001'
OPEN Cust_Cursor

FETCH NEXT FROM Cust_Cursor
INTO @cbi_cusno

WHILE @@FETCH_STATUS = 0
BEGIN



select @intcounter = count(*) from cucntinf where cci_cusno = @cbi_cusno and cci_cnttyp in ('M','S','B')

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if (@intcounter >0 )
begin



select  @intCurrentNo = isnull(max(cci_sapshcusno),0) from cucntinf where cci_cusno = @cbi_cusno and cci_cnttyp in ('M','S','B') and cci_sapshcusno <> ''

if  (@intCurrentNo = 0 )
begin
set @intsapshcusno = cast(@cbi_cusno + '000' as int)
end
else
begin
set @intsapshcusno = @intCurrentNo
end


/*
print @intsapshcusno + 1
*/
DECLARE Cnt_Cursor CURSOR FOR 
select cci_cnttyp,CCI_CNTSEQ  from cucntinf where cci_cusno = @cbi_cusno and cci_cnttyp in ('M','S','B') and cci_sapshcusno = '' ORDER BY cci_cnttyp,CCI_CNTSEQ
OPEN Cnt_Cursor

FETCH NEXT FROM Cnt_Cursor
INTO @cci_cnttyp, @CCI_CNTSEQ

WHILE @@FETCH_STATUS = 0
BEGIN

set @intsapshcusno = @intsapshcusno  + 1 

update cucntinf 
set cci_sapshcusno = cast ( @intsapshcusno as nvarchar) , cci_sapreconacc = '1131010000'
where cci_cnttyp = @cci_cnttyp and CCI_CNTSEQ = @CCI_CNTSEQ and cci_cusno = @cbi_cusno and cci_sapshcusno = ''


FETCH NEXT FROM Cnt_Cursor
INTO @cci_cnttyp, @CCI_CNTSEQ
end
close Cnt_Cursor
deallocate  Cnt_Cursor
end

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
set @intcounter = 0 
set @intsapshcusno = 0
set @intCurrentNo = 0
set @cci_cnttyp = ''
set @CCI_CNTSEQ = 0 

FETCH NEXT FROM Cust_Cursor
INTO @cbi_cusno
end



set @cbi_cusno = ''
close Cust_Cursor
deallocate  Cust_Cursor






end


GO
GRANT EXECUTE ON [dbo].[sp_insert_CUCNTINF_SAPSHCUSNO] TO [ERPUSER] AS [dbo]
GO
