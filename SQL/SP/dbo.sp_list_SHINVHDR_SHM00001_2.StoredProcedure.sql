/****** Object:  StoredProcedure [dbo].[sp_list_SHINVHDR_SHM00001_2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHINVHDR_SHM00001_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHINVHDR_SHM00001_2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Johnson Lai 
Date:		July 6, 2002
Description:	1. Calc existing ivoice amouts total
************************************************************************/

CREATE procedure [dbo].[sp_list_SHINVHDR_SHM00001_2]

                                                                                                                                                                                                                                                               
@hiv_cocde nvarchar(6) ,
@hiv_shpno nvarchar(20)
AS

select

sum(hiv_ttlamt) as 'hiv_grninvamt'

from SHINVHDR

where hiv_cocde = @hiv_cocde and
hiv_shpno = @hiv_shpno

group by hiv_cocde, hiv_shpno



GO
GRANT EXECUTE ON [dbo].[sp_list_SHINVHDR_SHM00001_2] TO [ERPUSER] AS [dbo]
GO
