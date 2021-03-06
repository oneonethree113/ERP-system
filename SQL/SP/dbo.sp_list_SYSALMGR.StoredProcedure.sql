/****** Object:  StoredProcedure [dbo].[sp_list_SYSALMGR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYSALMGR]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYSALMGR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Kath Ng     
Date:		29th November, 2001
Description:	FIND SALE MANAGER 
************************************************************************/

CREATE procedure [dbo].[sp_list_SYSALMGR]
                                                                                                                                                                                                                                                                 

@Company	nvarchar(6), 
@SaleCode	nvarchar(6)                                               
 
AS

BEGIN
------------------------------------------------------------------------------------------------------------------------------------
SELECT	yup_usrid, isnull(yup_usrnam,'') as 'yup_usrnam'
FROM	SYUSRPRF
WHERE yup_usrid = 
(SELECT distinct yuc_supid 
--ysr_salmgr 
FROM symusrco, SYSALREP 
WHERE ysr_code1 = @SaleCode	
and ysr_code = yuc_usrid
 )
--AND ysr_cocde = @Company)
--and yup_cocde = @Company
------------------------------------------------------------------------------------------------------------------------------------
END




GO
GRANT EXECUTE ON [dbo].[sp_list_SYSALMGR] TO [ERPUSER] AS [dbo]
GO
