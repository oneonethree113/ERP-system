/****** Object:  StoredProcedure [dbo].[sp_select_return_fmlopt_dtl]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_return_fmlopt_dtl]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_return_fmlopt_dtl]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_select_return_fmlopt_dtl] 

@cocde	nvarchar(6),
@fmlopt	nvarchar(5)

AS

select  (yfi_fmlopt + ' - ' +yfi_fml) as fmlstr  From syfmlinf where yfi_fmlopt = @fmlopt


GO
GRANT EXECUTE ON [dbo].[sp_select_return_fmlopt_dtl] TO [ERPUSER] AS [dbo]
GO
