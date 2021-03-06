/****** Object:  StoredProcedure [dbo].[sp_select_ZSITMDAT_timstp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_ZSITMDAT_timstp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ZSITMDAT_timstp]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/*
=========================================================
Program ID	: sp_select_ZSITMDAT_timstp
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  	Description                          
=========================================================    
*/

CREATE PROCEDURE [dbo].[sp_select_ZSITMDAT_timstp] 
@zid_cocde 	nvarchar(6),
@zid_itmno	varchar(20),
@zid_seqno	INT,
@zid_mpono	varchar(20),
@Zid_Credat	datetime

AS


select 
	cast(zid_timstp as int) as 'zid_timstp'
from 
	ZSITMDAT
where
	Zid_itmno = @zid_itmno and
	Zid_Seqno =  @zid_seqno and
	Zid_MPONO = @zid_mpono and
	convert(varchar(19),zid_credat,121) = convert(varchar(19),@zid_credat,121)




GO
GRANT EXECUTE ON [dbo].[sp_select_ZSITMDAT_timstp] TO [ERPUSER] AS [dbo]
GO
