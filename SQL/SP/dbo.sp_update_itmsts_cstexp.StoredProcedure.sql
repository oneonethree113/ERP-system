/****** Object:  StoredProcedure [dbo].[sp_update_itmsts_cstexp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_itmsts_cstexp]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_itmsts_cstexp]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: sp_update_itmsts_cstexp
Description   	: Update Item Status to 'TBC' if item over cost expire date
Programmer  	: Allan Yuen
ALTER  Date   	:
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description                          
2006-07-29		Marco Chan		Bug Fix due to wrong comparing of date
=========================================================    
*/

CREATE   procedure [dbo].[sp_update_itmsts_cstexp]
                                                                                                                                                                                                                                                                 
--sp_update_itmsts_cstexp 

AS

SET NOCOUNT ON
/*
update
	IMBASINF
SET

	ibi_itmsts = 'TBC',
	ibi_updusr = 'CSTEXP',
	ibi_upddat = GETDATE()
WHERE
	ibi_itmsts = 'CMP' AND
	IBI_ITMNO IN 
	(
	select 
		ibi_itmno
	from 
		imcstinf 
		left join imbasinf on ibi_itmno = ici_itmno
	where 	
	
		ici_expdat > '1900-01-01'  and
		ici_expdat <  getdate() and
		ici_expdat > '2012-09-05'
	)

*/


update IMPRCINF
set imu_status = 'INA', imu_updusr = 'CSTEXP', imu_upddat = getdate()
where imu_expdat > '1900-01-01' and imu_expdat < getdate()
and imu_status = 'ACT'


update IMBASINF 
set ibi_itmsts = 'TBC', ibi_updusr = 'CSTEXP', ibi_upddat = GETDATE()
from IMBASINF
left join IMPRCINF on imu_itmno = ibi_itmno and imu_status = 'ACT'
where ibi_itmsts in ('CMP', 'INC')
and ibi_typ in ('REG', 'ASS')
and imu_itmno is null

GO
GRANT EXECUTE ON [dbo].[sp_update_itmsts_cstexp] TO [ERPUSER] AS [dbo]
GO
