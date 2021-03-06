/****** Object:  StoredProcedure [dbo].[sp_select_CUSUBCUS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_CUSUBCUS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUSUBCUS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Kath Ng     
Date:		13th September, 2001
Description:	Select data From CUSUBCUS
***********************************************************************
11 Jul 2003	Lewis To		Ignor Company code to handle multi company
*/

CREATE procedure [dbo].[sp_select_CUSUBCUS]


@csc_cocde	nvarchar(6),
@csc_relcus	nvarchar(6),
@CusTyp		nvarchar(1)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------

IF @CusTyp = 'P' 
BEGIN


SELECT	'   ' as Status,	csc_cocde,	csc_seccus,	
	cbi_cusnam,
	CASE csc_cusrel	WHEN 'A' THEN 'Active'	WHEN 'P' THEN 'Passive'	END AS csc_cusrel,
	csc_creusr,	csc_updusr,	csc_credat,	
	csc_upddat,	cast(csc_timstp as int) as csc_timstp

FROM	CUSUBCUS
LEFT JOIN CUBASINF ON cbi_cusno = csc_seccus --and cbi_cocde = @csc_cocde

WHERE	--csc_cocde = @csc_cocde and
	csc_prmcus =@csc_relcus


ORDER BY csc_seccus

END
--------------------------------------------------------------------------------------------------

IF @CusTyp = 'S'
BEGIN

SELECT	'   ' as Status,	csc_cocde,	csc_prmcus,	
	cbi_cusnam,
	CASE csc_cusrel	WHEN 'A' THEN 'Active'	WHEN 'P' THEN 'Passive'	END AS csc_cusrel,
	csc_creusr,	csc_updusr,	csc_credat,	
	csc_upddat,	cast(csc_timstp as int) as csc_timstp


FROM	CUSUBCUS
LEFT JOIN CUBASINF ON cbi_cusno = csc_prmcus --and cbi_cocde = @csc_cocde

WHERE	--csc_cocde = @csc_cocde and
	csc_seccus = @csc_relcus
--and	csc_cocde = @csc_cocde

ORDER BY csc_prmcus

END

--------------------------------------------------------------------------------------------------
END







GO
GRANT EXECUTE ON [dbo].[sp_select_CUSUBCUS] TO [ERPUSER] AS [dbo]
GO
