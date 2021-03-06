/****** Object:  StoredProcedure [dbo].[sp_select_FYPDOHIS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_FYPDOHIS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_FYPDOHIS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=================================================================
Program ID	: sp_select_FYPDOHIS
Description	: Retrieve PDO Document History
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-12-04 	David Yue		SP Created
=================================================================
*/


CREATE PROCEDURE [dbo].[sp_select_FYPDOHIS] 

@cocde  nvarchar(6),
@batfm	nvarchar(10),
@batto	nvarchar(10),
@jobfm	nvarchar(30),
@jobto	nvarchar(30),
@datfm	nvarchar(10),
@datto	nvarchar(10),
@creusr	nvarchar(30)

AS

declare
@fph_cocde	nvarchar(80),
@fph_batno	nvarchar(100),
@fph_jobord	nvarchar(100),
@fph_gendat	nvarchar(100),
@statement	nvarchar(1000),
@condition	nvarchar(420),
@order		nvarchar(100)

if @cocde <> ''
begin
	set @fph_cocde = 'fph_cocde = ''' + @cocde + ''''
end
else
begin
	set @fph_cocde = ''
end

if @batfm <> '' and @batto <> ''
begin
	set @fph_batno = 'fph_batno between ''' + @batfm + ''' and ''' + @batto + ''''
end
else
begin
	set @fph_batno = ''
end

if @jobfm <> '' and @jobto <> ''
begin
	set @fph_jobord = 'fph_jobord between ''' + @jobfm + ''' and ''' + @jobto + ''''
end
else
begin
	set @fph_jobord = ''
end

if @datfm <> '' and @datto <> ''
begin
	set @fph_gendat = 'fph_gendat between ''' + @datfm + ''' and ''' + @datto + ' 23:59:59'''
end
else
begin
	set @fph_gendat = ''
end

set @condition = ''
if @fph_cocde <> ''
begin
	set @condition = ' where ' + @fph_cocde
end
if @fph_batno <> ''
begin
	set @condition = @condition + case len(@condition) when 0 then ' where ' else ' and ' end + @fph_batno
end
if @fph_jobord <> ''
begin
	set @condition = @condition + case len(@condition) when 0 then ' where ' else ' and ' end + @fph_jobord
end
if @fph_gendat <> ''
begin
	set @condition = @condition + case len(@condition) when 0 then ' where ' else ' and ' end + @fph_gendat
end

set @statement = 'select fph_cocde, fph_batno, fph_jobord, convert(nvarchar(10),fph_gendat, 121) as ''fph_gendat'', fph_filnam from FYPDOHIS (nolock)'
set @order = ' order by fph_cocde, fph_batno, fph_jobord'
exec (@statement + @condition + @order)



GO
GRANT EXECUTE ON [dbo].[sp_select_FYPDOHIS] TO [ERPUSER] AS [dbo]
GO
