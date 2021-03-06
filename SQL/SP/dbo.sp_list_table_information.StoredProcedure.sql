/****** Object:  StoredProcedure [dbo].[sp_list_table_information]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_table_information]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_table_information]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_list_table_information] 

@cocde 		nvarchar(6),
@table_name	nvarchar(20)

AS

select  	b.name as 'key', 	
case (select d.name from sysindexes i, syscolumns d where i.id = a.id and d.name = b.name 
and (i.status & 0x800) = 0x800 and i.id = d.id 
		and (d.name = index_col (@table_name, i.indid,  1) or
		     d.name = index_col (@table_name, i.indid,  2) or
		     d.name = index_col (@table_name, i.indid,  3) or
		     d.name = index_col (@table_name, i.indid,  4) or
		     d.name = index_col (@table_name, i.indid,  5) or
		     d.name = index_col (@table_name, i.indid,  6) or
		     d.name = index_col (@table_name, i.indid,  7) or
		     d.name = index_col (@table_name, i.indid,  8) or
		     d.name = index_col (@table_name, i.indid,  9) or
		     d.name = index_col (@table_name, i.indid, 10) or
		     d.name = index_col (@table_name, i.indid, 11) or
		     d.name = index_col (@table_name, i.indid, 12) or
		     d.name = index_col (@table_name, i.indid, 13) or
		     d.name = index_col (@table_name, i.indid, 14) or
		     d.name = index_col (@table_name, i.indid, 15) or
		     d.name = index_col (@table_name, i.indid, 16) 
		    ) 
) when b.name then 'Y' else 'N' end as 'PrimaryKey',
	c.name as 'FieldType', 
	case c.name when 'numeric' then ltrim(str(b.xprec)) + '.' + ltrim(str(b.xscale))  
		    when 'nvarchar' then ltrim(str(b.length/2)) 
 	else 
	ltrim(str(b.length)) end as 'FieldLength', 
	
	case b.isnullable when 0 then 'N' 
	else 
	'Y' end as 'Allow Null', 
	isnull((select d.text from syscomments d where b.cdefault = d.id),'') as 'DefaultValue'
from sysobjects a, syscolumns b, systypes c
where a.name = @table_name and a.id = b.id 
and b.xtype = c.xtype and c.xtype = c.xusertype 
order by b.colorder


GO
GRANT EXECUTE ON [dbo].[sp_list_table_information] TO [ERPUSER] AS [dbo]
GO
