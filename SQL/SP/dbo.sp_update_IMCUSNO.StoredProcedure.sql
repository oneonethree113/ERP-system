/****** Object:  StoredProcedure [dbo].[sp_update_IMCUSNO]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMCUSNO]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMCUSNO]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_update_IMCUSNO]
@cocde varchar(6),
@itmno varchar(30),
@cusno varchar(30),
@rmk nvarchar(1000),
@usrid varchar(30)
as
begin
	update IMCUSNO
	set icn_rmk = @rmk, icn_upddat = getdate(), icn_updusr = @usrid
	where icn_itmno = @itmno
	and icn_cusno = @cusno
end




GO
GRANT EXECUTE ON [dbo].[sp_update_IMCUSNO] TO [ERPUSER] AS [dbo]
GO
