/****** Object:  StoredProcedure [dbo].[sp_select_ACEDIBAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_ACEDIBAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ACEDIBAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



create procedure [dbo].[sp_select_ACEDIBAT]

AS
begin
select 
	aeb_cocde, 
	aeb_pstdat
FROM 
	ACEDIBAT


END


GO
GRANT EXECUTE ON [dbo].[sp_select_ACEDIBAT] TO [ERPUSER] AS [dbo]
GO
