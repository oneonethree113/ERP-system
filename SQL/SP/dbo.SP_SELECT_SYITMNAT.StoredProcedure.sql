/****** Object:  StoredProcedure [dbo].[SP_SELECT_SYITMNAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_SYITMNAT]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_SYITMNAT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[SP_SELECT_SYITMNAT] 
@cocde as nvarchar(6)

AS

BEGIN

select ysi_cde + ' - ' + ysi_dsc as 'itmnat' from sysetinf where ysi_typ = '25'
order by ysi_dsc asc
END



GO
GRANT EXECUTE ON [dbo].[SP_SELECT_SYITMNAT] TO [ERPUSER] AS [dbo]
GO
