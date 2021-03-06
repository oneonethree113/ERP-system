/****** Object:  StoredProcedure [dbo].[sp_insert_qcrptdtl]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_qcrptdtl]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_qcrptdtl]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  PROCEDURE [dbo].[sp_insert_qcrptdtl] 
		@qrd_tmprptno nvarchar(20)
		,@qrd_prdmat numeric(13,4)
		,@qrd_prdcmp numeric(13,4)
		,@qrd_prdctnpck numeric(13,4)
		,@qrd_prdrmk nvarchar(500)
		,@qrd_prdexpdat datetime
		,@qrd_scqty int
		,@qrd_scctn int
		,@qrd_scunt nvarchar(6)
		,@qrd_shpqty int
		,@qrd_shpctn int
		,@qrd_shpunt nvarchar(6)
		,@qrd_prdqty int
		,@qrd_prdctn int
		,@qrd_prdunt nvarchar(6)
		,@qrd_qcqty int
		,@qrd_qcctn int
		,@qrd_qcunt nvarchar(6)
		,@qrd_qcpredsc nvarchar(500)
		,@qrd_disptyp1 nvarchar(10)
		,@qrd_sysnwt numeric(13,4)
		,@qrd_sysgwt numeric(13,4)
		,@qrd_actnwt numeric(13,4)
		,@qrd_actgwt numeric(13,4)
		,@qrd_disptyp2 nvarchar(10)
		,@qrd_sysmtrl numeric(13,4)
		,@qrd_sysmtrw numeric(13,4)
		,@qrd_sysmtrh numeric(13,4)
		,@qrd_syscbm numeric(13,4)
		,@qrd_syscft numeric(13,4)
		,@qrd_actmtrl numeric(13,4)
		,@qrd_actmtrw numeric(13,4)
		,@qrd_actmtrh numeric(13,4)
		,@qrd_actcbm numeric(13,4)
		,@qrd_actcft numeric(13,4)
		,@qrd_pckitr nvarchar(500)
		,@qrd_dftcrtalw int
		,@qrd_dftmajalw int
		,@qrd_dftminalw int
		,@qrd_dftcrtfnd int
		,@qrd_dftmajfnd int
		,@qrd_dftminfnd int
		,@qrd_inspresult char(1)
		,@qrd_reinspdat datetime
		,@qrd_creusr nvarchar(30)
		,@qrd_updusr nvarchar(30)
		,@qrd_poqty nvarchar(1000)
		,@qrd_morepoqty nvarchar(1000)
		,@qrd_mtrpc nvarchar(20)
		,@qrd_sampctn int
		,@qrd_pckqty nvarchar (1000)
		,@qrd_morepckqty nvarchar (1000)
		,@qrd_matrmk nvarchar (200)
		,@qrd_cmprmk nvarchar (200)
		,@qrd_pckrmk nvarchar (200)

AS BEGIN
	Declare @cur_time as datetime
	set @cur_time = getdate()
	
	INSERT INTO dbo.QCRPTDTL
           (qrd_tmprptno
			,qrd_prdmat
			,qrd_prdcmp
			,qrd_prdctnpck
			,qrd_prdrmk
			,qrd_prdexpdat
			,qrd_scqty
			,qrd_scctn
			,qrd_scunt
			,qrd_shpqty
			,qrd_shpctn
			,qrd_shpunt
			,qrd_prdqty
			,qrd_prdctn
			,qrd_prdunt
			,qrd_qcqty
			,qrd_qcctn
			,qrd_qcunt
			,qrd_qcpredsc
			,qrd_disptyp1
			,qrd_sysnwt
			,qrd_sysgwt
			,qrd_actnwt
			,qrd_actgwt
			,qrd_disptyp2
			,qrd_sysmtrl
			,qrd_sysmtrw
			,qrd_sysmtrh
			,qrd_syscbm
			,qrd_syscft
			,qrd_actmtrl
			,qrd_actmtrw
			,qrd_actmtrh
			,qrd_actcbm
			,qrd_actcft
			,qrd_pckitr
			,qrd_dftcrtalw
			,qrd_dftmajalw
			,qrd_dftminalw
			,qrd_dftcrtfnd
			,qrd_dftmajfnd
			,qrd_dftminfnd
			,qrd_inspresult
			,qrd_reinspdat
			,qrd_creusr
			,qrd_updusr
			,qrd_credat
			,qrd_upddat
			,qrd_poqty
			,qrd_morepoqty
			,qrd_mtrpc
			,qrd_sampctn
			,qrd_pckqty
			,qrd_morepckqty
			,qrd_matrmk
			,qrd_cmprmk
			,qrd_pckrmk)
     VALUES (@qrd_tmprptno
			,@qrd_prdmat
			,@qrd_prdcmp
			,@qrd_prdctnpck
			,@qrd_prdrmk
			,@qrd_prdexpdat
			,@qrd_scqty
			,@qrd_scctn
			,@qrd_scunt
			,@qrd_shpqty
			,@qrd_shpctn
			,@qrd_shpunt
			,@qrd_prdqty
			,@qrd_prdctn
			,@qrd_prdunt
			,@qrd_qcqty
			,@qrd_qcctn
			,@qrd_qcunt
			,@qrd_qcpredsc
			,@qrd_disptyp1
			,@qrd_sysnwt
			,@qrd_sysgwt
			,@qrd_actnwt
			,@qrd_actgwt
			,@qrd_disptyp2
			,@qrd_sysmtrl
			,@qrd_sysmtrw
			,@qrd_sysmtrh
			,@qrd_syscbm
			,@qrd_syscft
			,@qrd_actmtrl
			,@qrd_actmtrw
			,@qrd_actmtrh
			,@qrd_actcbm
			,@qrd_actcft
			,@qrd_pckitr
			,@qrd_dftcrtalw
			,@qrd_dftmajalw
			,@qrd_dftminalw
			,@qrd_dftcrtfnd
			,@qrd_dftmajfnd
			,@qrd_dftminfnd
			,@qrd_inspresult
			,@qrd_reinspdat
			,@qrd_creusr
			,@qrd_updusr
			,@cur_time
			,@cur_time
			,@qrd_poqty
			,@qrd_morepoqty
			,@qrd_mtrpc
			,@qrd_sampctn
			,@qrd_pckqty
			,@qrd_morepckqty
			,@qrd_matrmk
			,@qrd_cmprmk
			,@qrd_pckrmk)

END


GO
GRANT EXECUTE ON [dbo].[sp_insert_qcrptdtl] TO [ERPUSER] AS [dbo]
GO
