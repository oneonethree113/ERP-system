/****** Object:  StoredProcedure [dbo].[sp_select_IMM00001_ass]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00001_ass]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00001_ass]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--sp_select_IMM00001_ass  'UCPP','ST2'

 CREATE  procedure [dbo].[sp_select_IMM00001_ass]  
@cocde as varchar(6),  
@UM varchar(20)  
as  
begin  
  
select src.ycf_code1 as 'srcum',case isnull(des.ycf_code1,'') when 'ST1' then 'ST' else isnull(des.ycf_code1,'')  end as 'desum' ,src.ycf_value as 'conftr'  
from SYCONFTR src  
left join SYCONFTR des on src.ycf_dsc1 = des.ycf_dsc1  
where src.ycf_code1 = @UM  
and des.ycf_value = 1  
and des.ycf_systyp = 'N'  
  


end  



GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00001_ass] TO [ERPUSER] AS [dbo]
GO
