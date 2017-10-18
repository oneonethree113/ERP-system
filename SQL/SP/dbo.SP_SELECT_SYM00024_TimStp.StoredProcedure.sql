/****** Object:  StoredProcedure [dbo].[SP_SELECT_SYM00024_TimStp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_SYM00024_TimStp]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_SYM00024_TimStp]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE  PROCEDURE [dbo].[SP_SELECT_SYM00024_TimStp]
@icf_cocde 	NVARCHAR(6),
@icf_itmno	nvarchar(20),
@icf_colcde	nvarchar(100)
AS

begin

select cast( icf_timstp as int ) as 'icf_timstp',icf_updusr from imcolinf
where icf_itmno = @icf_itmno
and icf_colcde = @icf_colcde

END


GO
GRANT EXECUTE ON [dbo].[SP_SELECT_SYM00024_TimStp] TO [ERPUSER] AS [dbo]
GO
