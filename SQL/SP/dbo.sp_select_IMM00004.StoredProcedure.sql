/****** Object:  StoredProcedure [dbo].[sp_select_IMM00004]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00004]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00004]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--sp_helptext sp_select_IMM00004
--sp_helptext sp_select_IMM00003
/*=========================================================    
Program ID :  sp_select_IMM00004    
Description    :  select Item's information for IM    
Programmer   :  Lester Wu    
ALTER  Date    :      
Last Modified   :      
Table Read(s)  : IMBASINF    
Table Write(s)  :     
=========================================================    
 Modification History                                        
=========================================================    
Date  Author  Description    
=========================================================    
*/    
    
    -- sp_select_IMM00004 'UCPP','06A51LD061A01,06A51DA002A01,06A51DA002A02,06A51DA002A03,06A51DA002A04,06A51DA002A05,06A51DA003A01'
CREATE procedure [dbo].[sp_select_IMM00004]    
@cocde nvarchar(6),    
@itmno nvarchar(600)    
    
as    
    
begin    
    
	create table #_ITMLST(_itm varchar(30))
	declare	@itmRemain varchar(1000), @itmPart varchar(30)
	Declare	@Row_Idx int,@Err_Idx int

	set @Row_Idx = 0
	set @Err_Idx = 0
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- Check Source Item
	
	
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- Check Update Items
	set @itmRemain = ltrim(rtrim(@itmno))
	while charindex(',',@itmRemain) > 0 
	begin
		set @itmPart = ltrim(rtrim(left(@itmRemain, charindex(',', @itmRemain) - 1)))
		set @itmRemain = ltrim(rtrim(right(@itmRemain,len(@itmRemain) - charindex(',', @itmRemain))))
		if len(@itmPart) > 0 
		begin
			insert into #_ITMLST (_itm) values (@itmPart)
		end
	end
	if len(@itmRemain) > 0
	begin
		insert into #_ITMLST (_itm) values (@itmRemain)
	end
	
	if ( select count(1) from #_ITMLST left join  IMBASINF on ibi_itmno = _itm where ibi_itmsts not in ('CMP','HLD') ) > 0
	begin
		select ibi_itmno + ' - ' + ibi_itmsts as 'ibi_itmsts' from #_ITMLST  left join IMBASINF on ibi_itmno = _itm where ibi_itmsts not in ('CMP','HLD')
		return (0)
	end


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
  when 'INC' then 'INC - Active Item with incomplete Info.'    
  when 'CLO' then 'CLO - Closed (UCP Item)'    
  when 'TBC' then 'TBC - To be confirmed'    
  -- Lester Wu 2006-09-17    
  when 'OLD' then 'OLD -Old Item'    
                else '' end as 'ibi_itmsts',    
case ibi_typ when 'REG' then 'Regular'    
      when 'ASS' then 'Assortment'    
      when 'BOM' then 'BOM'    
      else 'Other' end as 'ibi_typ',    
isnull(ibi_engdsc,'') as 'ibi_engdsc',    
cast(ibi_timstp as int) as ibi_timstp    
from     
#_ITMLST
left join IMBASINF on ibi_itmno = _itm
--where ibi_itmno = @itmno    
  where ibi_itmno is not null  
    
end    
    
    
    
    
  




GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00004] TO [ERPUSER] AS [dbo]
GO
