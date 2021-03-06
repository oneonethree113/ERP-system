/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL_co]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHIPGDTL_co]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL_co]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO














/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SHCHGDTL
***********************************************************************
*/

CREATE     procedure [dbo].[sp_select_SHIPGDTL_co]


@hid_cocde	nvarchar(6),
@hid_ctnno	nvarchar(20),
@hid_etddat	datetime

 
AS

BEGIN

select distinct hid_cocde as 'company'
 from shipgdtl 
		left join  shipghdr on
			hih_shpno =  hid_shpno
			where 
				 hid_ctrcfs = @hid_ctnno
			and  hih_slnonb = @hid_etddat 


--------------------------------------------------------------------------------------------------
END

GO
GRANT EXECUTE ON [dbo].[sp_select_SHIPGDTL_co] TO [ERPUSER] AS [dbo]
GO
