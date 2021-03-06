/****** Object:  StoredProcedure [dbo].[sp_list_table_name]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_table_name]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_table_name]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: sp_list_table_name
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    
05/06/2003 Allan Yuen   Relocate Audit Log Table Location 
*/

CREATE PROCEDURE [dbo].[sp_list_table_name] 

@cocde 	nvarchar(6),
@table	nvarchar(10)

AS

--select name as 'table' from ucperpdb_aud.sysobjects 
select name as 'table' from ucperpdb_aud..sysobjects 
where xtype = 'U' and sysstat = 99  
and right(name, 4) = '_AUD'
order by name



GO
GRANT EXECUTE ON [dbo].[sp_list_table_name] TO [ERPUSER] AS [dbo]
GO
