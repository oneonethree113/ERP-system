/****** Object:  StoredProcedure [dbo].[sp_list_VNBASINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNBASINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNBASINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







-- Checked by Allan Yuen at 28/07/2003


CREATE  procedure [dbo].[sp_list_VNBASINF]
	@vbi_cocde nvarchar(6) 
AS

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
cast(vbi_timstp as int) as vbi_timstp,
vbi_ventyp,
vbi_venfty,
vbi_venflag

from 
	VNBASINF
where
 vbi_cocde = ' ' 
order by vbi_venno



GO
GRANT EXECUTE ON [dbo].[sp_list_VNBASINF] TO [ERPUSER] AS [dbo]
GO
