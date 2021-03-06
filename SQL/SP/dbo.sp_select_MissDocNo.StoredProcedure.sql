/****** Object:  StoredProcedure [dbo].[sp_select_MissDocNo]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MissDocNo]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MissDocNo]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003

CREATE PROCEDURE [dbo].[sp_select_MissDocNo] 

@cocde nvarchar(5), 
@typ nvarchar(3)

AS

declare @start nvarchar(10), @end nvarchar(10), @prefix nvarchar(4), @i nvarchar(14),
@len int, @zeros int, @pos int,@docno nvarchar(14)

set nocount on
--set @cocde = 'UCPP'
--set @cocde = 'UCPP'
--set @typ = 'SA'

if @cocde = 'UCP'
begin
	if @typ = 'PO'
		set @prefix = 'PR'
	else if @typ = 'SC'
		set @prefix = 'SC'
	else if @typ = 'SH'
		set @prefix = 'I02'
	else if @typ = 'CU1'
		set @prefix = '3'
	else if @typ = 'CU2'
		set @prefix = '4'
	else if @typ = 'SI'
		set @prefix = 'A'
	else if @typ = 'SA'
		set @prefix = 'R'
end
else if @cocde = 'UCPP'
begin
	if @typ = 'PO'
		set @prefix = 'UP'
	else if @typ = 'SC'
		set @prefix = 'US'
	else if @typ = 'SH'
		set @prefix = 'UI'
	else if @typ = 'CU1'
		set @prefix = '1'
	else if @typ = 'CU2'
		set @prefix = '2'
	else if @typ = 'SI'
		set @prefix = 'UA'
	else if @typ = 'SA'
		set @prefix = 'UR'
end

if @cocde = 'UCP' and @prefix = 'PR' or @cocde = 'UCPP' and @prefix = 'UP'
begin
	select @start = min(replace(poh_purord,@prefix,''))from poordhdr
	where poh_creusr not like 'data%' and poh_cocde = @cocde
	and poh_purord like @prefix+'%'
	select @end = max(replace(poh_purord,@prefix,''))from poordhdr
	where poh_creusr not like 'data%' and poh_cocde = @cocde
	and poh_purord like @prefix+'%'
end
else if @cocde = 'UCP' and @prefix = 'SC' or @cocde = 'UCPP' and @prefix = 'US'
begin
	select @start = min(replace(soh_ordno ,@prefix,''))from scordhdr
	where soh_creusr not like 'data%' and soh_cocde = @cocde
	and soh_ordno like @prefix+'%'
	select @end = max(replace(soh_ordno ,@prefix,''))from scordhdr
	where soh_creusr not like 'data%' and soh_cocde = @cocde
	and soh_ordno like @prefix+'%'
end
else if @cocde = 'UCP' and @prefix = 'I02' or @cocde = 'UCPP' and @prefix = 'UI'
begin
	select @start = min(replace(hiv_invno ,@prefix,''))from shinvhdr
	where hiv_creusr not like 'data%' and hiv_cocde = @cocde
	and hiv_invno like @prefix+'%'
	select @end = max(replace(hiv_invno ,@prefix,''))from shinvhdr
	where hiv_creusr not like 'data%' and hiv_cocde = @cocde
	and hiv_invno like @prefix+'%'
end
else if @cocde = 'UCP' and (@prefix ='3' or @prefix='4') or @cocde = 'UCPP' and (@prefix ='1' or @prefix='2') 
begin
	select @start = min(right(cbi_cusno,len(cbi_cusno)-1)) from cubasinf
--	where cbi_cocde = @cocde and cbi_cusno like @prefix+'%'
	where cbi_cusno like @prefix+'%'
	select @end = max(right(cbi_cusno,len(cbi_cusno)-1)) from cubasinf
	where cbi_cocde = @cocde and cbi_cusno like @prefix+'%'
end
else if @cocde = 'UCP' and @prefix = 'A' or @cocde = 'UCPP' and @prefix = 'UA'
begin
	select @start = min(replace(sih_invno ,@prefix,''))from sainvhdr
	where sih_cocde = @cocde
	and sih_invno like @prefix+'%'
	select @end = max(replace(sih_invno ,@prefix,''))from sainvhdr
	where sih_cocde = @cocde
	and sih_invno like @prefix+'%'
end
else if @cocde = 'UCP' and @prefix = 'R' or @cocde = 'UCPP' and @prefix = 'UR'
begin
	select @start = min(replace(srh_reqno ,@prefix,''))from sareqhdr
	where srh_cocde = @cocde
	and srh_reqno like @prefix+'%'
	select @end = max(replace(srh_reqno ,@prefix,''))from sareqhdr
	where srh_cocde = @cocde
	and srh_reqno like @prefix+'%'
end
else
begin
	select 'Wrong combo A', @typ, @cocde, @prefix
	goto skip
end
/*
select max(poh_purord)from poordhdr
	where poh_creusr not like 'data%' and poh_cocde = @cocde
	and poh_purord like @prefix+'%'
select max(replace(soh_ordno ,@prefix,''))from scordhdr
	where soh_creusr not like 'data%' and soh_cocde = @cocde
	and soh_ordno like @prefix+'%'
*/
set @len = len(@end)

select 'Company', @cocde
select 'Start', @Prefix+@start
select 'End', @Prefix+@end

set @i = @start
while @i <= @end
begin
	set @docno = @prefix+@i
--	select @cocde, @docno
	if @cocde = 'UCP' and @prefix = 'PR' or @cocde = 'UCPP' and @prefix = 'UP'
	begin
		if (select count(*) from poordhdr
		where poh_creusr not like 'data%' and 
		poh_cocde = @cocde
		and poh_purord = @docno) = 0
			select @cocde, @docno
	end
	else if @cocde = 'UCP' and @prefix = 'SC' or @cocde = 'UCPP' and @prefix = 'US'
	begin

		if (select count(*) from scordhdr
		where soh_creusr not like 'data%' and soh_cocde = @cocde
		and soh_ordno = @docno) = 0
			select @cocde, @docno
	end
	else if @cocde = 'UCP' and @prefix = 'I02' or @cocde = 'UCPP' and @prefix = 'UI'
	begin
		if (select count(*) from shinvhdr
		where hiv_creusr not like 'data%' and hiv_cocde = @cocde
		and hiv_invno = @docno) = 0
			select @cocde, @docno
	end
	else if @cocde = 'UCP' and @prefix in ('3','4') or @cocde = 'UCPP' and @prefix in ('1','2')
	begin
		if (select count(*) from cubasinf
--		where cbi_cocde = @cocde and cbi_cusno = @docno) = 0
		where cbi_cusno = @docno) = 0
			select @cocde, @docno
	end
	else if @cocde = 'UCP' and @prefix = 'A' or @cocde = 'UCPP' and @prefix = 'UA'
	begin
		if (select count(*) from sainvhdr
		where sih_cocde = @cocde and sih_invno = @docno) = 0
			select @cocde, @docno
	end
	else if @cocde = 'UCP' and @prefix = 'R' or @cocde = 'UCPP' and @prefix = 'UR'
	begin
		if (select count(*) from sareqhdr
		where srh_cocde = @cocde and srh_reqno = @docno) = 0
			select @cocde, @docno
	end	
	else
	begin
		select 'Wrong combo'
		goto skip
	end
	
	set @i=@i+1
	set @zeros = @len - len(@i)
	set @pos = 1
	while @pos <= @zeros
	begin
		set @i = '0' + @i
		set @pos = @pos + 1
	end
	--select @i
end
skip:



GO
GRANT EXECUTE ON [dbo].[sp_select_MissDocNo] TO [ERPUSER] AS [dbo]
GO
