/****** Object:  StoredProcedure [dbo].[autogen_trigger_for_a_table]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[autogen_trigger_for_a_table]
GO
/****** Object:  StoredProcedure [dbo].[autogen_trigger_for_a_table]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
'***
'***  Author : Philip YU
'***  Creation Date : 28-June-2000
'***  Description : To generate the triggers on the based table for Auditing purpose.
'***  Logic : 1.  Input the table name
'***
'***
'***  Modification History :
'***  Modified by  : Kenny Chan	
'***  Modified on  :28-8-2001
'***  Modification description :
'***
'***
'***  Note : Information about the auto-generated scripts :
'***   1. The primary key(s) in the table must have the smallest colid.
'***   2. The rightmost 3 characters of the sequence number in the primary key(s) if exists, should be 'seq'.
'***   3. The sequence number in the primary key(s) if exists, must have the last colid within the primary key(s).
'***   4. The usrid, credat, upddat and lckflg must be the last four columns in the table.
'***   5. The name of the display sequence in the table must be 'disply'.
*/
CREATE PROCEDURE [dbo].[autogen_trigger_for_a_table]
@table_name nvarchar(20)
AS
set nocount on
--if exists (select * from sysobjects where id = object_id('tr_' + @table_name + '_insert') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
 --RETURN
declare @credat nvarchar(20)
declare @upddat nvarchar(20)
declare @finalcol nvarchar(20)
set @table_name = upper(@table_name)
select 'if exists (select * from sysobjects where id = object_id(''tr_' + @table_name + '_insert'') and OBJECTPROPERTY(id, ''IsTrigger'') = 1)'
select 'drop trigger [tr_' + @table_name + '_insert]'
select 'GO'
select 'CREATE TRIGGER [tr_' + @table_name + '_insert] ON [' + @table_name + ']' + char(13) + 'FOR INSERT' + char(13) + 'AS'
select 'insert into [' + @table_name + '_AUD]' + char(13) + '('
select @credat = name
from syscolumns
where id = object_id(@table_name)
and right(name,6) = 'credat'
--***************************************************************
select
case right(name,6) 
  when 'timstp' then left(name,4) + 'actflg_aud'
  else name + ' ,'
  end
from syscolumns
where id = object_id(@table_name)
order by colid
Select  +')'+ char(13) + 'select'

--***************************************************************
select
case right(name,6) when 'credat' then 'getdate() ,'
  when 'upddat' then @credat + ' ,'
  when 'timstp' then /*name + ',' + Char(13) + */'1'
  else name + ' ,'
  end
from syscolumns
where id = object_id(@table_name)
order by colid
select 'from inserted'
select 'GO'
select 'if exists (select * from sysobjects where id = object_id(''tr_' + @table_name + '_update'') and OBJECTPROPERTY(id, ''IsTrigger'') = 1)'
select 'drop trigger [tr_' + @table_name + '_update]'
select 'GO'
select 'CREATE TRIGGER [tr_' + @table_name + '_update] ON [' + @table_name + ']' + char(13) + 'FOR UPDATE' + char(13) + 'AS'
select 'declare @write_log_date datetime'
select @finalcol = name
from syscolumns
where id = object_id(@table_name)
and colid =
 (select max(colid)
 from syscolumns
 where id = object_id(@table_name))
select @upddat = name
from syscolumns
where id = object_id(@table_name)
and right(name,6) = 'upddat'
--select 'select @deleted_lckflg = ' + @finalcol + ' from deleted'
--select 'select @inserted_lckflg = ' + @finalcol + ' from inserted'
--select 'if @deleted_lckflg = 1 and @inserted_lckflg = 0'
--select 'begin'
--select ' if UPDATE (' + @upddat + ')'
--select ' begin'
select '  set @write_log_date  = getdate()'
select '  insert into [' + @table_name + '_AUD] ' + char(13) + '('
--***************************************************************
select
case right(name,6) 
  when 'timstp' then left(name,4) + 'actflg_aud'
  else name + ' ,'
  end
from syscolumns
where id = object_id(@table_name)
order by colid
Select  +')'+ char(13) + 'select'

--***************************************************************

select
case right(name,6) when 'credat' then '  getdate() ,'
  when 'timstp' then  /*'  ' + name + ',' + Char(13) + */'  2'
  else '  ' + name + ' ,'
  end
from syscolumns
where id = object_id(@table_name)
order by colid
select '  from deleted'
select '  insert into [' + @table_name + '_AUD] ' + char(13) + '('
--***************************************************************
select
case right(name,6) 
  when 'timstp' then left(name,4) + 'actflg_aud'
  else name + ' ,'
  end
from syscolumns
where id = object_id(@table_name)
order by colid
Select  +')'+ char(13) + 'select'

--***************************************************************

select
case right(name,6) when 'credat' then '  @write_log_date ,'
  when 'timstp' then  /*'  ' + name + ',' + Char(13) + */'  3'
  else '  ' + name + ' ,'
  end
from syscolumns
where id = object_id(@table_name)
order by colid
select '  from inserted'
--select ' end'
--select 'end'
--select 'else if @deleted_lckflg = 1 and @inserted_lckflg = 9'
--select 'begin'
--select '  insert into [' + @table_name + '_AUD] select'
--select
--case right(name,6) when 'credat' then '  getdate() ,'
--  when 'lckflg' then '  5'
--  else '  ' + name + ' ,'
--  end
--from syscolumns
--where id = object_id(@table_name)
--order by colid
--select '  from inserted'
--select 'end'
select 'GO'
select 'if exists (select * from sysobjects where id = object_id(''tr_' + @table_name + '_delete'') and OBJECTPROPERTY(id, ''IsTrigger'') = 1)'
select 'drop trigger [tr_' + @table_name + '_delete]'
select 'GO'
select 'CREATE TRIGGER [tr_' + @table_name + '_delete] ON [' + @table_name + ']' + char(13) + 'FOR DELETE' + char(13) + 'AS'
select 'insert into [' + @table_name + '_AUD] ' + char(13) + '('
select @credat = name
from syscolumns
where id = object_id(@table_name)
and right(name,6) = 'credat'
--***************************************************************
select
case right(name,6) 
  when 'timstp' then left(name,4) + 'actflg_aud'
  else name + ' ,'
  end
from syscolumns
where id = object_id(@table_name)
order by colid
Select  +')'+ char(13) + 'select'

--***************************************************************


select
case right(name,6) when 'credat' then 'getdate() ,'
  when 'upddat' then 'getdate() ,'
  when 'timstp' then  /*'  ' + name + ',' + Char(13) + */'  4'
  else name + ' ,'
  end
from syscolumns
where id = object_id(@table_name)
order by colid
select 'from deleted'
select 'GO'
set nocount off






GO
GRANT EXECUTE ON [dbo].[autogen_trigger_for_a_table] TO [ERPUSER] AS [dbo]
GO
