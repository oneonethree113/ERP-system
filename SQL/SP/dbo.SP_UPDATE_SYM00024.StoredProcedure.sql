/****** Object:  StoredProcedure [dbo].[SP_UPDATE_SYM00024]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_UPDATE_SYM00024]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_SYM00024]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE  PROCEDURE [dbo].[SP_UPDATE_SYM00024]
@ibi_cocde NVARCHAR(6),
@itmno		nvarchar(20),
@rmk		nvarchar(4000),
@usrid		nvarchar(30)
AS

begin

update imbasinf 
set ibi_rmk = @rmk,  ibi_upddat = getdate(), ibi_updusr = @usrid
where ibi_itmno = @itmno

END



GO
GRANT EXECUTE ON [dbo].[SP_UPDATE_SYM00024] TO [ERPUSER] AS [dbo]
GO
