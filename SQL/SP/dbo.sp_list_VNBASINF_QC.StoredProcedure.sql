/****** Object:  StoredProcedure [dbo].[sp_list_VNBASINF_QC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNBASINF_QC]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNBASINF_QC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE    procedure [dbo].[sp_list_VNBASINF_QC] 
	@vbi_vensts nvarchar(1)
as
BEGIN

Select 
	vbi_cocde,
	vbi_venno,
	vbi_vensts,
	vbi_vensna,
	vbi_vennam,
	vbi_venrat,
	vbi_prctrm,
	vbi_paytrm,
	vbi_curcde,
	vbi_discnt,
	vbi_orgven,
	vbi_rmk,
	vbi_ledtim,
	vbi_tsttim,
	vbi_bufday,
	vbi_venweb,
	vbi_ventyp,
	vbi_moqchg,
	vbi_creusr,
	vbi_updusr,
	vbi_credat,
	vbi_upddat,
	vbi_ventyp,
	vbi_venfty,
	vbi_venflag,
	
	res_vensna = vbi_venno + ' - ' + vbi_Vensna
FROM
	VNBASINF
where
	(@vbi_vensts = '' OR (@vbi_vensts <> '' AND vbi_vensts = @vbi_vensts))
order by vbi_venno










END


GO
GRANT EXECUTE ON [dbo].[sp_list_VNBASINF_QC] TO [ERPUSER] AS [dbo]
GO
