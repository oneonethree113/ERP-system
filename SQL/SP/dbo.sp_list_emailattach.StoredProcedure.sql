/****** Object:  StoredProcedure [dbo].[sp_list_emailattach]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_emailattach]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_emailattach]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_list_emailattach]
@esa_mailid nvarchar(20)



AS
BEGIN

select fsm_filepath from EMSYSATT left join FLSTRMAN on esa_fileid = fsm_fileid 
where esa_mailid = @esa_mailid

END


GO
GRANT EXECUTE ON [dbo].[sp_list_emailattach] TO [ERPUSER] AS [dbo]
GO
