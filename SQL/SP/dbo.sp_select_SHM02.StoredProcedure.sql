/****** Object:  StoredProcedure [dbo].[sp_select_SHM02]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHM02]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHM02]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003


CREATE PROCEDURE [dbo].[sp_select_SHM02] 

@cocde	nvarchar(6),
@from	nvarchar(20),
@to	nvarchar(20),
@fntyp	nvarchar(1)

AS

BEGIN
	UPDATE SHCBNHDR SET hnh_notsts = 'REL'
	WHERE hnh_noteno >= @from AND
	hnh_noteno <= @to AND
	(hnh_notsts = 'OPE' OR hnh_notsts = 'HLD' ) AND
	hnh_nottyp = @fntyp
	
END




GO
GRANT EXECUTE ON [dbo].[sp_select_SHM02] TO [ERPUSER] AS [dbo]
GO
