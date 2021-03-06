/****** Object:  StoredProcedure [dbo].[sp_list_CUCNTINF_SAM00003]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUCNTINF_SAM00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUCNTINF_SAM00003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





/************************************************************************
Author:		Johnson Lai
Date:		8 Feb, 2002
Description:	Select data From CUCNTINF
Parameter:	1. Company
		2. Customer No.	
		3. BUYR
************************************************************************/

CREATE procedure [dbo].[sp_list_CUCNTINF_SAM00003]

@cci_cocde 	nvarchar(6) ,
@cci_cnttyp	nvarchar(6)
                                              
AS

-- Billing ----------------------------------------------------------------------------------------------------------------
begin

SELECT	

cci_cocde,
cci_cusno,
cci_cnttyp,
cci_cntseq,
cci_cntadr,
cci_cntstt,
cci_cntcty,
cci_cntpst,
cci_cntctp,
cci_cnttil,
cci_cntphn,
cci_cntfax,
cci_cnteml,
cci_cntrmk,
cci_cntdef,
cci_creusr

 
FROM CUCNTINF

WHERE	--cci_cocde	= @cci_cocde and                                                                                                                                                                                                                         
	cci_cnttyp <>  'B' and
	cci_cnttyp <> 'M' and
	cci_cnttyp <> 'S' 

ORDER BY cci_cusno, cci_cntctp


END
------------------------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_list_CUCNTINF_SAM00003] TO [ERPUSER] AS [dbo]
GO
