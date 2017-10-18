/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMCUSNO]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_IMCUSNO]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMCUSNO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_physical_delete_IMCUSNO]
@cocde varchar(6),
@itmno varchar(30),
@cusno varchar(30),
@usrid varchar(30)
as
begin
	delete from IMCUSNO 
	where icn_itmno = @itmno
	and icn_cusno = @cusno
end




GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_IMCUSNO] TO [ERPUSER] AS [dbo]
GO
