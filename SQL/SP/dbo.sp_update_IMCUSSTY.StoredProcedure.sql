/****** Object:  StoredProcedure [dbo].[sp_update_IMCUSSTY]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMCUSSTY]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMCUSSTY]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Frankie Cheung
Date:		27 Oct, 2008
Description:	Update data in IMCUSSTY
***********************************************************************
*/

CREATE procedure [dbo].[sp_update_IMCUSSTY]

@ics_cocde	nvarchar(6),
@ics_cusno	nvarchar(12),
@ics_cusstyno	nvarchar(60),
@ics_itmno	nvarchar(40),
@userid		nvarchar(30)

AS

BEGIN
--------------------------------------------------------------------------------------------------
	If ( 	select count(*) 
		from IMCUSSTY 
		where ics_cusno = @ics_cusno and ics_cusstyno = @ics_cusstyno
	) <> 0
	begin
		update IMCUSSTY
		set
			ics_itmno = @ics_itmno,
		 	ics_updusr = @userid,
			ics_upddat = getdate() 
		where 
			ics_cusno = @ics_cusno and 
			ics_cusstyno = @ics_cusstyno		
	end
END






GO
GRANT EXECUTE ON [dbo].[sp_update_IMCUSSTY] TO [ERPUSER] AS [dbo]
GO
