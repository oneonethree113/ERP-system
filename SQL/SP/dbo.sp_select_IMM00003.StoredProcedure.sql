/****** Object:  StoredProcedure [dbo].[sp_select_IMM00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--sp_helptext sp_select_IMM00004
--sp_helptext sp_select_IMM00003

    
  
      /*=========================================================  
Program ID :  sp_select_IMM00003  
Description    :   
Programmer   :   
Create Date    :   
Last Modified   :   
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================  
*/  
  
  
CREATE procedure [dbo].[sp_select_IMM00003]  
@cocde nvarchar(6),  
@itmno nvarchar(20)  
  
as  
  
begin  
  
select   
ibi_cocde,  
ibi_itmno,  
isnull(ibi_lnecde,'') as 'ibi_lnecde',  
isnull(ibi_catlvl0,'') as 'ibi_catlvl0',  
isnull(ibi_catlvl1,'') as 'ibi_catlvl1',  
isnull(ibi_catlvl2,'') as 'ibi_catlvl2',  
isnull(ibi_catlvl3,'') as 'ibi_catlvl3',  
isnull(ibi_catlvl4,'') as 'ibi_catlvl4',  
case ibi_itmsts when 'CMP' then 'CMP - Active Item with complete Info.'   
                when 'HLD' then 'HLD - Active Item Hold by the system'  
  when 'DIS' then 'DIS - Discontinue Item'  
  when 'INC' then 'INC - Inactive Item'  
  when 'CLO' then 'CLO - Closed (UCP Item)'  
  when 'TBC' then 'TBC - To be confirmed Item'  
  -- Lester Wu 2006-09-17  
  when 'OLD' then 'OLD - Old Item'  
                else '' end as 'ibi_itmsts',  
case ibi_typ when 'REG' then 'Regular'  
      when 'ASS' then 'Assortment'  
      when 'BOM' then 'BOM'  
      else 'Other' end as 'ibi_typ',  
isnull(ibi_engdsc,'') as 'ibi_engdsc'  
from   
IMBASINF  
where ibi_itmno = @itmno  
  
  
end  
  



GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00003] TO [ERPUSER] AS [dbo]
GO
