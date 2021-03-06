/****** Object:  StoredProcedure [dbo].[sp_list_CUSALREP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUSALREP]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUSALREP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/************************************************************************
Author:		Kath Ng     
Date:		11th December, 2001
Description:	List data From SYSALREP
***********************************************************************
7 Jul 2003		Lewis To		Ignor Comp Code for handle multi Company
*/

CREATE procedure [dbo].[sp_list_CUSALREP]
                                                                                                                                                                                                                                                                 
@gsCompany	nvarchar(6),
@CusSale		nvarchar(8)

 
AS

BEGIN
--------------------------------------------------------------------------------------------------------------------------
SELECT DISTINCT	ysr_code,		ysr_dsc,
		ysr_saltem,	 
			ysr_code1,	cbi_salrep

FROM	SYSALREP

JOIN 	CUBASINF	ON	cbi_salrep = ysr_code1
			AND	cbi_salrep = @CusSale
			--AND	cbi_cocde = @gsCompany

--WHERE ysr_cocde = @gsCompany
--------------------------------------------------------------------------------------------------------------------------
END





GO
GRANT EXECUTE ON [dbo].[sp_list_CUSALREP] TO [ERPUSER] AS [dbo]
GO
