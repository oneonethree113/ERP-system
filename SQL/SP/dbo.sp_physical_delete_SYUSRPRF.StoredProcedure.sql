/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SYUSRPRF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SYUSRPRF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SYUSRPRF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_physical_delete_SYUSRPRF] 

@yup_cocde nvarchar(6),
@yup_usrid nvarchar(30)


AS


delete from SYUSRPRF
where 	--yup_cocde = @yup_cocde and
 	yup_usrid = @yup_usrid








GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SYUSRPRF] TO [ERPUSER] AS [dbo]
GO
