/****** Object:  StoredProcedure [dbo].[sp_list_SYCATREL1]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYCATREL1]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYCATREL1]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		Modify For Merge Porject
*/

CREATE procedure [dbo].[sp_list_SYCATREL1]

@vcr_cocde 	nvarchar(6)  = ' '
                                               
AS

begin

select 
ycr_catlvl0 as level0,
ycr_catlvl1 as level1,
ycr_catlvl2 as level2,
ycr_catlvl3 as level3,
ycr_catlvl4 as level4,
/*ycr_catlvl0 + space(20 - len(ycr_catlvl0)) + ',' +  
ycr_catlvl1 + space(20 - len(ycr_catlvl1)) + ',' +  
ycr_catlvl2 + space(20 - len(ycr_catlvl2)) + ',' +  
ycr_catlvl3 + space(20 - len(ycr_catlvl3)) + ',' +  
ycr_catlvl4 + space(20 - len(ycr_catlvl4)) as level01234
*/
a.ycr_catlvl4 + ' - ' + isnull(b.ycc_catdsc,'') as level01234


from sycatrel a

left join sycatcde b
on 
a.ycr_cocde 	= b.ycc_cocde and
a.ycr_catlvl4	= b.ycc_catcde and
b.ycc_level	= 4

where                                  
--ycr_cocde 	= @vcr_cocde 
ycr_cocde 	= ' '

order by ycr_catlvl0, ycr_catlvl1, ycr_catlvl2, ycr_catlvl3, ycr_catlvl4
end





GO
GRANT EXECUTE ON [dbo].[sp_list_SYCATREL1] TO [ERPUSER] AS [dbo]
GO
