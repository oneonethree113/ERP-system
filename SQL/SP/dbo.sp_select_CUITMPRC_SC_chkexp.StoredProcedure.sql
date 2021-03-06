/****** Object:  StoredProcedure [dbo].[sp_select_CUITMPRC_SC_chkexp]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMPRC_SC_chkexp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMPRC_SC_chkexp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 28/07/2003


/*
=================================================================
Program ID	: sp_select_CUITMPRC_SC_chkexp
Description	: Retrieve CIH entries for specified Item No.
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-04-22 	David Yue		SP Created
2013-10-10	David Yue		Add Latest CIH flag
2014-07-29	Marco Chan		Add checking for Expiry date 
					Customer PO Date > Expiry Date is not allowed for SC
=================================================================
*/

CREATE procedure [dbo].[sp_select_CUITMPRC_SC_chkexp]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cis_cocde nvarchar(6) ,
@cis_itmno nvarchar(20),
@cis_cusno nvarchar(6),
@cis_seccus nvarchar(6),
@sod_credat datetime


---------------------------------------------- 
 
AS
BEGIN

select count(*) 'expcount' from CUITMPRC (nolock) where 
cip_cusno = @cis_cusno and cip_seccus = @cis_seccus and
cip_itmno = @cis_itmno and @sod_credat < cip_expdat


END


GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMPRC_SC_chkexp] TO [ERPUSER] AS [dbo]
GO
