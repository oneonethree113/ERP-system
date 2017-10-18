/****** Object:  StoredProcedure [dbo].[sp_select_MPM00003_DLVDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPM00003_DLVDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPM00003_DLVDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE procedure [dbo].[sp_select_MPM00003_DLVDTL]
@cocde	as varchar(6)
as
BEGIN

	select 
		'~*OLD*~' as 'STS',
		* 
	from 
		MPDLVDTL
	where 
		Mdd_DocNo = 'XXX'
END






GO
GRANT EXECUTE ON [dbo].[sp_select_MPM00003_DLVDTL] TO [ERPUSER] AS [dbo]
GO
