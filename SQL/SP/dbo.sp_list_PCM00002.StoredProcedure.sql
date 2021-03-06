/****** Object:  StoredProcedure [dbo].[sp_list_PCM00002]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_PCM00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_PCM00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO







/*
=========================================================
Program ID	: sp_list_PCM00002
Description   	: Retrive Profit Centre list  for Profit Account Interface table 
Programmer  	: Lester Wu
ALTER  Date   	: 27 Nov, 2003
Last Modified  	: 
Table Read(s) 	: CUMRBT ( Customer Rebate )
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/

CREATE    PROCEDURE [dbo].[sp_list_PCM00002]
@COCDE NVARCHAR(6)
AS


SELECT 	'' as 'cmr_del',
	cmr_cusno,
	cbi_cusnam as 'cmr_cusnam',
	cmr_rbtfmlopt,
	cmr_rbtfmlopt  + '-' + yfi_fml  as 'cmr_fml',
	isnull(yfi_prcfml,'') as 'cmr_dsc',
	'' as 'cmr_creusr',
	'' as 'cmr_status'

FROM CUMRBT 
LEFT JOIN CUBASINF ON  cbi_cusno=cmr_cusno
LEFT JOIN SYFMLINF ON yfi_fmlopt=cmr_rbtfmlopt
ORDER BY cmr_cusno

select * from SYFMLINF





GO
GRANT EXECUTE ON [dbo].[sp_list_PCM00002] TO [ERPUSER] AS [dbo]
GO
