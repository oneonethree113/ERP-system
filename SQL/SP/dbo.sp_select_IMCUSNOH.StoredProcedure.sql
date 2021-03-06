/****** Object:  StoredProcedure [dbo].[sp_select_IMCUSNOH]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMCUSNOH]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMCUSNOH]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[sp_select_IMCUSNOH]
@cocde varchar(6),
@itmno varchar(30)
as
begin

	select 
		' ' as 'icn_status',
		icn_itmno,
		isnull(icn_cusno + ' - ' + cbi_cusnam,'') as 'icn_cusno',
		isnull(cbi_cusnam,'') as 'cbi_cussna',
		icn_rmk,
		icn_credat,
		icn_upddat,
		icn_creusr,
		icn_updusr,
		icn_timstp
	 from IMCUSNOH
	left join CUBASINF on icn_cusno = cbi_cusno
	where icn_itmno = @itmno

end





GO
GRANT EXECUTE ON [dbo].[sp_select_IMCUSNOH] TO [ERPUSER] AS [dbo]
GO
