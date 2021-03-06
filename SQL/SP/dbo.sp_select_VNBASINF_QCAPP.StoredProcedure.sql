/****** Object:  StoredProcedure [dbo].[sp_select_VNBASINF_QCAPP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_VNBASINF_QCAPP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_VNBASINF_QCAPP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE  PROCEDURE [dbo].[sp_select_VNBASINF_QCAPP]
	
AS
BEGIN


	SELECT 
	vbi_cocde
	,vbi_venno
	,vbi_vensts
	,vbi_vensna
	,vbi_vennam
	,vbi_venrat
	,vbi_prctrm
	,vbi_paytrm
	,vbi_curcde
	,vbi_discnt
	,vbi_rmk
	,vbi_ledtim
	,vbi_tsttim
	,vbi_bufday
	,vbi_venweb
	,vbi_dicoti
	,vbi_orgven
	,vbi_ventyp
	,vbi_moqchg
	,vbi_bvennam
	,vbi_bvennamc
	,vbi_prcvenno
	,vbi_venchnnam
	,vbi_venfty
	,vbi_frurcde
	,vbi_framt
	,vbi_ventranflg
	,vbi_venflag
	,vbi_creusr
	,vbi_updusr
	,convert(char, vbi_credat,120) vbi_credat
	,convert(char, vbi_upddat,120) vbi_upddat
	FROM VNBASINF
	where VBI_VENSTS = 'A'
	and vbi_venflag = 'U'
	
END


GO
GRANT EXECUTE ON [dbo].[sp_select_VNBASINF_QCAPP] TO [ERPUSER] AS [dbo]
GO
