/****** Object:  StoredProcedure [dbo].[sp_list_FYJOBINF_FTY00001_2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_FYJOBINF_FTY00001_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_FYJOBINF_FTY00001_2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai	
Date:		Mar 03, 2002
Description:	Select data From FYJOBINF
************************************************************************/

CREATE procedure [dbo].[sp_list_FYJOBINF_FTY00001_2]
                                                                                                                                                                                                                                                               
@fji_cocde nvarchar(6),
@fji_creusr nvarchar(30)
 
AS
begin


SELECT fji_ordno, fji_itmno, fji_jobno, fji_ftycde

from FYJOBINF 

where fji_cocde = @fji_cocde

ORDER BY fji_ordno, fji_itmno, fji_jobno, fji_ftycde


end





GO
GRANT EXECUTE ON [dbo].[sp_list_FYJOBINF_FTY00001_2] TO [ERPUSER] AS [dbo]
GO
