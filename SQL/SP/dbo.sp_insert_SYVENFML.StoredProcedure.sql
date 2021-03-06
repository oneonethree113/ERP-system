/****** Object:  StoredProcedure [dbo].[sp_insert_SYVENFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYVENFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYVENFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





-- Checked by Allan Yuen at 28/07/2003




/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYVENFML
Parameter:	1. Company Code range    
		2. Color Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYVENFML] 
--------------------------------------------------------------------------------------------------------------------------------------

@yvf_cocde	nvarchar(6) = ' ',
@yvf_venno	nvarchar(6),
@yvf_fmlopt             nvarchar(5),
@yvf_def                  nvarchar(2),
--@yvf_pmfml	nvarchar(2),
--@yvf_fml	nvarchar(50),
@yvf_updusr	nvarchar(30),
-- Added by Mark Lau 20090204
@yvf_catcde	nvarchar(20),
@yvf_matcde	nvarchar(6),

@yvf_effdat	datetime
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYVENFML

(
yvf_cocde,
yvf_venno,
yvf_fmlopt,
yvf_def,
yvf_effdat,
yvf_creusr,
yvf_updusr,
yvf_credat,
yvf_upddat,
-- Added by Mark Lau 20090204
yvf_catcde,
yvf_matcde
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@yvf_cocde,
' ',
@yvf_venno,
@yvf_fmlopt,
@yvf_def,
@yvf_effdat,
@yvf_updusr,
@yvf_updusr,
getdate(),
getdate(),
-- Added by Mark Lau 20090204
@yvf_catcde,
@yvf_matcde
)



GO
GRANT EXECUTE ON [dbo].[sp_insert_SYVENFML] TO [ERPUSER] AS [dbo]
GO
