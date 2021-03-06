/****** Object:  StoredProcedure [dbo].[sp_Check_SC_PO_Pck]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Check_SC_PO_Pck]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_SC_PO_Pck]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003


CREATE PROCEDURE [dbo].[sp_Check_SC_PO_Pck] 


@cocde nvarchar(6),
@typ nvarchar(2)

as 



If @typ = 'SC'
Begin
	Select 	sod_ordno as 'SC #' ,	pod_purord as 'PO #',
		sod_pckunt + '/' + cast(sod_inrctn as nvarchar(10)) + '/' + cast(sod_mtrctn as nvarchar(10)) + '/' + cast(sod_cft as nvarchar(10)) as 'SC Pck',
		pod_untcde + '/' + cast(pod_inrctn as nvarchar(10)) + '/' + cast(pod_mtrctn as nvarchar(10)) + '/' + cast(pod_cubcft as nvarchar(10)) as 'PO Pck',
		sod_credat as 'SC CreateDate',	sod_upddat as 'SC UpdateDate',
		sod_creusr as 'SC CreateUser',	sod_updusr as 'SC UpdateUser',
		pod_credat as 'PO CreateDate',	pod_upddat as 'PO UpdateDate',
		pod_creusr as 'PO CreateUser',	pod_updusr as 'PO UpdateUser'
	From	SCORDDTL , POORDHDR , POORDDTL
	Where	sod_cocde = @cocde and
		poh_cocde = sod_cocde and
		poh_purord = pod_purord and
		pod_cocde = sod_cocde and
		sod_purord = poh_purord and
		sod_purseq = pod_purseq and
		sod_pckunt + '/' + cast(sod_inrctn as nvarchar(10)) + '/' + cast(sod_mtrctn as nvarchar(10)) <>
		pod_untcde + '/' + cast(pod_inrctn as nvarchar(10)) + '/' + cast(pod_mtrctn as nvarchar(10))
End
Else If @typ = 'PO'
Begin
	Select 	sod_ordno as 'SC #' ,	pod_purord as 'PO #',
		sod_pckunt + '/' + cast(sod_inrctn as nvarchar(10)) + '/' + cast(sod_mtrctn as nvarchar(10)) + '/' + cast(sod_cft as nvarchar(10)) as 'SC Pck',
		pod_untcde + '/' + cast(pod_inrctn as nvarchar(10)) + '/' + cast(pod_mtrctn as nvarchar(10)) + '/' + cast(pod_cubcft as nvarchar(10)) as 'PO Pck',
		sod_credat as 'SC CreateDate',	sod_upddat as 'SC UpdateDate',
		sod_creusr as 'SC CreateUser',	sod_updusr as 'SC UpdateUser',
		pod_credat as 'PO CreateDate',	pod_upddat as 'PO UpdateDate',
		pod_creusr as 'PO CreateUser',	pod_updusr as 'PO UpdateUser'
	From	SCORDDTL , POORDHDR , POORDDTL
	Where	sod_cocde = @cocde and
		poh_cocde = sod_cocde and
		poh_purord = pod_purord and
		pod_cocde = sod_cocde and
		pod_scno = sod_ordno  and
		pod_scline = sod_ordseq and
		sod_pckunt + '/' + cast(sod_inrctn as nvarchar(10)) + '/' + cast(sod_mtrctn as nvarchar(10)) <>
		pod_untcde + '/' + cast(pod_inrctn as nvarchar(10)) + '/' + cast(pod_mtrctn as nvarchar(10))
End



GO
GRANT EXECUTE ON [dbo].[sp_Check_SC_PO_Pck] TO [ERPUSER] AS [dbo]
GO
