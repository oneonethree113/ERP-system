/****** Object:  StoredProcedure [dbo].[sp_select_CUSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Kath Ng     
Date:		5th October, 2001
Description:	Select data From CUSHPMRK
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************
2003-04-23 Allan Yuen Chang the sorting sequence.
11 Jul 2003	Lewis To		Ignor Company code to handle multi company
*/

CREATE procedure [dbo].[sp_select_CUSHPMRK]
                                                                                                                                                                                                                                                                 

@csm_cocde nvarchar(6) ,
@csm_cusno nvarchar(20) 
                                               
 
AS

begin

Select	'   ' as status,
	csm_cocde, 	csm_cusno,	csm_seqno,
	csm_custyp,	csm_shptyp,	csm_engdsc,	
	csm_chndsc,	csm_engrmk,	csm_chnrmk,	
	csm_imgpth,	csm_imgnam,	csm_cerdoc,	
	csm_creusr,	csm_updusr,	csm_credat,	
	csm_upddat,	cast(csm_timstp as int) as csm_timstp
                                  

from CUSHPMRK
where
                                                                                                                                                                                                                                                                 

--csm_cocde = @csm_cocde and 	-- remark by Lewis
csm_cusno = @csm_cusno
--order by csm_cocde, csm_cusno, csm_seqno
-- Allan Yuen chang the shorting sequence
order by csm_cocde, csm_cusno, csm_shptyp, csm_imgnam

end




GO
GRANT EXECUTE ON [dbo].[sp_select_CUSHPMRK] TO [ERPUSER] AS [dbo]
GO
