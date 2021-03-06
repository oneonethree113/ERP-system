/****** Object:  StoredProcedure [dbo].[sp_select_VNCATREL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_VNCATREL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_VNCATREL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




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
20030715	Allan Yuen		For Merge Porject
*/

/************************************************************************
Author:		Johnson Lai 
Date:		18th September, 2001
Description:	Select data From VNCATREL
Parameter:	1. Company
		2. Vendor No.	
************************************************************************/

CREATE procedure [dbo].[sp_select_VNCATREL]

@vcr_cocde 	nvarchar(20)  = ' ',
@vcr_venno  	nvarchar(6) 
                                               
AS

begin

select 

a.vcr_catlvl0 + '-' + b.ycc_catdsc as level0,
a.vcr_catlvl1 + '-' + c.ycc_catdsc as level1,
a.vcr_catlvl2 + '-' + d.ycc_catdsc as level2,
a.vcr_catlvl3 + '-' + e.ycc_catdsc as level3,
a.vcr_catlvl4 + '-' + f.ycc_catdsc as level4

from vncatrel a
left join sycatcde b 	on b.ycc_level = '0'  and   a.vcr_catlvl0 = b.ycc_catcde 
left join sycatcde c 	on c.ycc_level = '1'  and   a.vcr_catlvl1 = c.ycc_catcde
left join sycatcde d 	on d.ycc_level = '2'  and   a.vcr_catlvl2 = d.ycc_catcde
left join sycatcde e	on e.ycc_level = '3'  and   a.vcr_catlvl3 = e.ycc_catcde
left join sycatcde f	on f.ycc_level = '4'  and   a.vcr_catlvl4 = f.ycc_catcde

where                                  
--a.vcr_cocde 	= @vcr_cocde and
a.vcr_cocde 	= ' ' and
a.vcr_venno 	= @vcr_venno

end








GO
GRANT EXECUTE ON [dbo].[sp_select_VNCATREL] TO [ERPUSER] AS [dbo]
GO
