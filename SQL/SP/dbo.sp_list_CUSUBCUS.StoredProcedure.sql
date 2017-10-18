/****** Object:  StoredProcedure [dbo].[sp_list_CUSUBCUS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUSUBCUS]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUSUBCUS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_list_CUSUBCUS] 

@csc_cocde	nvarchar(6),
@csc_prmcus	nvarchar(12),
@csc_seccus	nvarchar(12)

AS

BEGIN

	select * 
	from CUSUBCUS
	where 
	csc_prmcus = @csc_prmcus and 
	csc_seccus = @csc_seccus

END


GO
GRANT EXECUTE ON [dbo].[sp_list_CUSUBCUS] TO [ERPUSER] AS [dbo]
GO
