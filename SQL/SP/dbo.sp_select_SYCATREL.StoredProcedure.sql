/****** Object:  StoredProcedure [dbo].[sp_select_SYCATREL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCATREL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCATREL]    Script Date: 09/29/2017 11:53:54 ******/
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
Description:	Select data From SYCATREL
Parameter:	1. Company
************************************************************************/

CREATE procedure [dbo].[sp_select_SYCATREL]

@vcr_cocde 	nvarchar(6)  = ' '
                                               
AS

begin

select 

a.ycr_catlvl0 + ',' +
a.ycr_catlvl1 + ',' +
a.ycr_catlvl2 + ',' +
a.ycr_catlvl3 + ',' +
a.ycr_catlvl4 + '-' + b.ycc_catdsc as level4

from sycatrel a
left join sycatcde b	on b.ycc_level = '4'  and   a.ycr_catlvl4 = b.ycc_catcde

where                                  
--a.ycr_cocde 	= @vcr_cocde 
a.ycr_cocde 	= ' '

order by a.ycr_catlvl0, a.ycr_catlvl1,a.ycr_catlvl2, a.ycr_catlvl3,a.ycr_catlvl4
end








GO
GRANT EXECUTE ON [dbo].[sp_select_SYCATREL] TO [ERPUSER] AS [dbo]
GO
