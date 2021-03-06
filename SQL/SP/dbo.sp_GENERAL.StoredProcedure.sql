/****** Object:  StoredProcedure [dbo].[sp_GENERAL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_GENERAL]
GO
/****** Object:  StoredProcedure [dbo].[sp_GENERAL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO







/*
'***
'***  Author : Philip YU
'***  Creation Date : 22-June-2000
'***  Description : To call the according stored procedure based on the action in the packed string
'***  Logic : 1.  Input the packed strings. The maximum number of packed string is five.
'***    2. The according stored procedure will be called based the action in the packed string.
'***
'***
'***  Modification History :
'***  Modified by  :
'***  Modified on  :
'***  Modification description :
'***
'***
'***
'***  Note : Information about the auto-generated scripts :
'***   1. The primary key(s) in the table must have the smallest colid.
'***   2. The rightmost 3 characters of the sequence number in the primary key(s) if exists, should be 'seq'.
'***   3. The sequence number in the primary key(s) if exists, must have the last colid within the primary key(s).
'***   4. The usrid, credat, upddat and lckflg must be the last four columns in the table.
'***   5. The name of the display sequence in the table must be 'disply'.
*/
CREATE PROCEDURE [dbo].[sp_GENERAL]
@input_string1 nvarchar(4000), -- input parameter 1
@input_string2 nvarchar(4000), -- input parameter 2
@input_string3 nvarchar(4000), -- input parameter 3
@input_string4 nvarchar(4000), -- input parameter 4
@input_string5 nvarchar(4000) -- input parameter 5
AS
SET NOCOUNT ON -- to disable the display of the number of records return
declare @input_string nvarchar(4000) -- as a temp variable to store the value of the current packed string
declare @which_string int -- the counter that store which packed string is processing
set @which_string = 1
declare @table_name nvarchar(4000) -- to store the current table name in the packed string
declare @previous_table_name nvarchar(4000) -- to store the pervious table name which is used during the checking of the physical delete action sequence
set @previous_table_name = ''
declare @action_position int  -- to store the '㊣' location in the packed string
declare @action nvarchar(4000) -- to store the action code name
declare @separator_position int --  to store the '※' location in the packed string
declare @working_string nvarchar(4000) -- to store the substring value of the packed string
declare @parameter nvarchar(4000) -- to store the parameter values that will be needed in the stored procedure
declare @sp_name nvarchar(4000) -- to store the stored procedure name that will be called
declare @errorcode int -- to store the error code that was returned by the SQL Server
declare @errormessage nvarchar(4000)  -- to store the Custom error message
set @errormessage = 'Internal error occurs.' -- initialize the error message
declare @other_actions_started_before_P int --a boolean flag which is used during the checking of the physical delete action sequence
set @other_actions_started_before_P = 0
BEGIN TRAN -- to begin the transaction, if there is any erros after calling the according stored procedure, all the work will be rollback
while @which_string <=5
begin
 if @which_string = 1
  set @input_string = @input_string1 -- assign the current packed string to the temp variable
 else if @which_string = 2
  set @input_string = @input_string2 -- assign the current packed string to the temp variable
 else if @which_string = 3
  set @input_string = @input_string3 -- assign the current packed string to the temp variable
 else if @which_string = 4
  set @input_string = @input_string4 -- assign the current packed string to the temp variable
 else if @which_string = 5
  set @input_string = @input_string5 -- assign the current packed string to the temp variable
 while len (@input_string) > 0
 begin
  set @action_position = 0 -- initialize the variable
  set @action_position = charindex (N'㊣' , @input_string , 2) -- find the position of the '㊣' character. The prefix N means '㊣' character is a double byte.
  if @action_position > 0 -- not the final string that need to be processed
  begin
   set @working_string = substring (@input_string , 2 , @action_position - 2) -- working string is a substring of the input string that each have ㊣ as the delimiter
   set @input_string = substring (@input_string , @action_position , 4000)  -- input_string = input_string - working_string
  end
  else -- the final string that need to be processed
  begin
   set @working_string = substring (@input_string , 2 , 4000)
   set @input_string = '' -- to assign the empty value to the current packed string such that the next input packed string can be processed
  end
 
  set @separator_position = charindex (N'※' , @working_string) -- find the ※ position
  set @table_name = substring (@working_string , 1 , @separator_position - 1) -- assign the table name
  if @table_name <> @previous_table_name
  begin
   set @previous_table_name = @table_name
   set @other_actions_started_before_P = 0
  end
  set @action = substring (@working_string , @separator_position + 1 , 1) -- to assign the action code
 
  set @working_string = substring (@working_string , @separator_position + 3 , 4000) -- to reassign the working string value
  set @separator_position = charindex (N'※' , @working_string)
  set @sp_name = '' -- initialize the stored procedure name
  while (len (@working_string) > 0)
  begin
   if (@separator_position > 0) -- not the final parameter value
   begin
    set @parameter = substring (@working_string , 1 , @separator_position - 1) -- build the parameters for the stored procedure
    set @sp_name = @sp_name + "'" + @parameter + "'" + ' , '
   end
   else
   begin -- the final parameter value reached
    set @parameter = @working_string
    set @sp_name = @sp_name + "'" + @parameter + "'"
    BREAK -- exit the while (len (@working_string) > 0) loop
   end
   set @working_string = substring (@working_string , @separator_position + 1 , 4000) -- to reassign the working string value
   set @separator_position = charindex (N'※' , @working_string) -- to find the next '※' character 
  end
  -----------------------------------------------------------------
  -- Call the stored procedure according to the ACTION
  -----------------------------------------------------------------
--select @sp_name
--return


  if @action = 'A' -- A for Add
  begin
   set @sp_name = 'sp_insert_' + @table_name + ' ' + @sp_name  -- build the final stored procedure name
   exec (@sp_name) -- call the according stored procedure
   set @errorcode = @@error -- assign the error code raised by the SQL Server to the variable
    if @errorcode <> 0 -- if error occurs
   begin
    ROLLBACK TRAN -- undo all the transactions that have done up to this point
    select @errormessage = yrc_erreds from SYERRCDE where yrc_errcde = @errorcode -- find the custom error message based on the error code
    set @errormessage ='{{1~' + -- build the packed error message to the program. 1 means the error
      @table_name +'~' +
      @action + '~' +
      convert(nvarchar(4000) , @errorcode) + '~' + @errormessage
    RAISERROR(@errormessage , 18 , 1)
    RETURN  -- exit the procedure
   end
   set @other_actions_started_before_P = 1
  end
  else if @action = 'U'  -- U for Update
  begin
   set @sp_name = 'sp_update_' + @table_name + ' ' + @sp_name
   exec (@sp_name)
   set @errorcode = @@error
    if @errorcode <> 0
   begin
    ROLLBACK TRAN
    select @errormessage = yrc_erreds from SYERRCDE where yrc_errcde = @errorcode
    set @errormessage ='{{1~' +
      @table_name +'~' +
      @action + '~' +
      convert(nvarchar(4000) , @errorcode) + '~' + @errormessage
    RAISERROR(@errormessage , 18 , 1)
    RETURN
   end
   set @other_actions_started_before_P = 1
  end
  else if @action  = 'D'  -- D for logical delete
  begin
   set @sp_name = 'sp_logical_delete_' + @table_name + ' ' + @sp_name
   exec (@sp_name)
   set @errorcode = @@error
    if @errorcode <> 0
   begin
    ROLLBACK TRAN
    select @errormessage = yrc_erreds from SYERRCDE where yrc_errcde = @errorcode
    set @errormessage ='{{1~' +
      @table_name +'~' +
      @action + '~' +
      convert(nvarchar(4000) , @errorcode) + '~' + @errormessage
    RAISERROR(@errormessage , 18 , 1)
    RETURN
   end
   set @other_actions_started_before_P = 1
  end
  else if @action  = 'R'  -- R for reset flag
  begin
   set @sp_name = 'sp_reset_flag_' + @table_name + ' ' + @sp_name
   exec (@sp_name)
   set @errorcode = @@error
    if @errorcode <> 0
   begin
    ROLLBACK TRAN
    select @errormessage = yrc_erreds from SYERRCDE where yrc_errcde = @errorcode
    set @errormessage ='{{1~' +
      @table_name +'~' +
      @action + '~' +
      convert(nvarchar(4000) , @errorcode) + '~' + @errormessage
    RAISERROR(@errormessage , 18 , 1)
    RETURN
   end
   set @other_actions_started_before_P = 1
  end
  else if @action  = 'S'  -- S for Select
  begin
   set @sp_name = 'sp_select_' + @table_name + ' ' + @sp_name
   exec (@sp_name)
   set @errorcode = @@error
    if @errorcode <> 0
   begin
    ROLLBACK TRAN
    select @errormessage = yrc_erreds from SYERRCDE where yrc_errcde = @errorcode
    set @errormessage ='{{1~' +
      @table_name +'~' +
      @action + '~' +
      convert(nvarchar(4000) , @errorcode) + '~' + @errormessage
    RAISERROR(@errormessage , 18 , 1)
    RETURN
   end
   set @other_actions_started_before_P = 1
  end
  else if @action  = 'L'  -- L for List
  begin
   set @sp_name = 'sp_list_' + @table_name + ' ' + @sp_name
   exec (@sp_name)
   set @errorcode = @@error
    if @errorcode <> 0
   begin
    ROLLBACK TRAN
    select @errormessage = yrc_erreds from SYERRCDE where yrc_errcde = @errorcode
    set @errormessage ='{{1~' +
      @table_name +'~' +
      @action + '~' +
      convert(nvarchar(4000) , @errorcode) + '~' + @errormessage
    RAISERROR(@errormessage , 18 , 1)
    RETURN
   end
   set @other_actions_started_before_P = 1
  end
  else if @action  = 'P'  -- P for Physical delete
  begin
   if @other_actions_started_before_P = 1
   begin
    ROLLBACK TRAN
    select @errormessage = yrc_erreds from SYERRCDE where yrc_errcde = 50001
    set @errormessage ='{{1~' +
      @table_name +'~' +
      @action + '~' +
      convert(nvarchar(4000) , 50001) + '~' + @errormessage
    RAISERROR(@errormessage , 18 , 1)
    RETURN
   end
   set @sp_name = 'sp_physical_delete_' + @table_name + ' ' + @sp_name
   exec (@sp_name)
   set @errorcode = @@error
    if @errorcode <> 0
   begin
    ROLLBACK TRAN
    select @errormessage = yrc_erreds from SYERRCDE where yrc_errcde = @errorcode
    set @errormessage ='{{1~' +
      @table_name +'~' +
      @action + '~' +
      convert(nvarchar(4000) , @errorcode) + '~' + @errormessage
    RAISERROR(@errormessage , 18 , 1)
    RETURN
   end
  end
  ---------------------------------------
  -- End of the ACTION checking
  ---------------------------------------
 end
 set @which_string = @which_string + 1
end
COMMIT TRAN -- to write the changes to the database
SET NOCOUNT OFF
RETURN  -- exit the procedure







GO
GRANT EXECUTE ON [dbo].[sp_GENERAL] TO [ERPUSER] AS [dbo]
GO
