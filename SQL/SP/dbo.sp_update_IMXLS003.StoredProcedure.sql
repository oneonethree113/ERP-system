/****** Object:  StoredProcedure [dbo].[sp_update_IMXLS003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMXLS003]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMXLS003]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[sp_update_IMXLS003]
@cocde	varchar(6) , 
@UsrId	varchar(30)
AS
BEGIN
	Update IMDISITM
	set idi_flg = 'O'
	where 
	idi_creusr = @UsrId
End




GO
GRANT EXECUTE ON [dbo].[sp_update_IMXLS003] TO [ERPUSER] AS [dbo]
GO
