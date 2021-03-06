/****** Object:  StoredProcedure [dbo].[sp_insert_IMCUSNO]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMCUSNO]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMCUSNO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_insert_IMCUSNO]
@cocde varchar(6),
@itmno varchar(30),
@cusno varchar(30),
@rmk nvarchar(1000),
@usrid varchar(30)
as
begin
	if (select count(1) from IMCUSNO(nolock) where icn_itmno = @itmno and icn_cusno = @cusno) <= 0
	begin
		insert into IMCUSNO (icn_itmno, icn_cusno, icn_rmk,icn_credat,icn_upddat,icn_creusr,icn_updusr)
		values (@itmno, @cusno, isnull(@rmk, ''), getdate(), getdate(), @usrid, @usrid)
	end
end




GO
GRANT EXECUTE ON [dbo].[sp_insert_IMCUSNO] TO [ERPUSER] AS [dbo]
GO
