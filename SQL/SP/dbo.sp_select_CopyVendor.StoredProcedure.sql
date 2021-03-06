/****** Object:  StoredProcedure [dbo].[sp_select_CopyVendor]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CopyVendor]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CopyVendor]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








CREATE PROCEDURE [dbo].[sp_select_CopyVendor]
	@COCDE VARCHAR(6),
	@FVENNO VARCHAR(6),
	@TVENNO VARCHAR(6),
	@USER VARCHAR(30)
AS



BEGIN TRAN	
	INSERT INTO
		VNBASINF
			(vbi_cocde, vbi_venno, vbi_vensts, vbi_vensna, 
			vbi_vennam,vbi_venrat, vbi_prctrm, vbi_paytrm, 
			-- Added by Mark Lau 20081027
			vbi_venchnnam,
			vbi_curcde, vbi_discnt, vbi_rmk, 	vbi_ledtim, 
			vbi_tsttim, 	vbi_bufday, vbi_venweb, vbi_dicoti, 
			vbi_orgven, vbi_ventyp,vbi_frurcde,vbi_framt,
			vbi_ventranflg,vbi_venflag,
			 vbi_creusr, vbi_updusr, vbi_credat, vbi_upddat)
		SELECT
--			@COCDE, @TVENNO, 'A', vbi_vensna, 
			' ', @TVENNO, 'A', vbi_vensna, 
			vbi_vennam,vbi_venrat, vbi_prctrm, vbi_paytrm, 
			vbi_venchnnam,
			vbi_curcde, vbi_discnt, vbi_rmk, 	vbi_ledtim, 
			vbi_tsttim, 	vbi_bufday, vbi_venweb, vbi_dicoti, 
			'', vbi_ventyp,vbi_frurcde,vbi_framt ,
			vbi_ventranflg,vbi_venflag,
			@USER, @USER, GETDATE(), GETDATE()
		FROM
			VNBASINF
		WHERE
--			vbi_cocde = @COCDE and
			vbi_venno = @FVENNO
	
	
	INSERT INTO
		VNCATREL
			(vcr_cocde, vcr_venno, vcr_catseq, vcr_catlvl0, 
			vcr_catlvl1, vcr_catlvl2, vcr_catlvl3, vcr_catlvl4, 
			vcr_creusr, vcr_updusr, vcr_credat, vcr_upddat)
		SELECT
--			@COCDE, @TVENNO, vcr_catseq, vcr_catlvl0, 
			' ', @TVENNO, vcr_catseq, vcr_catlvl0, 
			vcr_catlvl1, vcr_catlvl2, vcr_catlvl3, vcr_catlvl4, 
			@USER, @USER, GETDATE(), GETDATE()
		FROM
			VNCATREL
		WHERE
--			vcr_cocde = @COCDE and
			vcr_venno = @FVENNO
	
	INSERT INTO
		VNCNTINF
			(vci_cocde, vci_venno, vci_cnttyp, 	vci_seq, 
			vci_adr, vci_stt, vci_cty, vci_zip, 
			-- Added by Mark Lau 20081027
			vci_cntctp,  vci_cnttil, 	vci_cntphn, vci_cntfax, 
			vci_cnteml, vci_cntdef, 
			vci_chnadr,
			vci_city, vci_town, vci_adrdtl,
			vci_creusr, vci_updusr, 
			vci_credat, 	vci_upddat)
		SELECT
--			@COCDE, @TVENNO, vci_cnttyp, vci_seq, 
			' ', @TVENNO, vci_cnttyp, vci_seq, 
			vci_adr, vci_stt, vci_cty, vci_zip, 
			-- Added by Mark Lau 20081027
			vci_cntctp,  vci_cnttil, 	vci_cntphn, vci_cntfax, 
			vci_cnteml, vci_cntdef, 
			vci_chnadr,
			vci_city, vci_town, vci_adrdtl,
			@USER, @USER, 
			GETDATE(), GETDATE()
		FROM
			VNCNTINF
		WHERE
--			vci_cocde =  @COCDE and
			vci_venno = @FVENNO
	
	
	INSERT INTO
		VNCSEINF
			(vcs_cocde, vcs_venno, vcs_csetyp, vcs_cseseq, 
			vcs_csenam, vcs_cseadr, vcs_csestt, vcs_csecty, 
			vcs_csezip, vcs_csectp, vcs_csetil, 	vcs_csephn, 
			vcs_csefax, vcs_cseeml, vcs_csermk, vcs_csedef, 
			vcs_accno, 	vcs_accnam, vcs_creusr, vcs_updusr, 
			vcs_credat, vcs_upddat)
		SELECT
--			@COCDE, @TVENNO, vcs_csetyp, vcs_cseseq, 
			' ', @TVENNO, vcs_csetyp, vcs_cseseq, 
			vcs_csenam, vcs_cseadr, vcs_csestt, vcs_csecty, 
			vcs_csezip, vcs_csectp, vcs_csetil, 	vcs_csephn, 
			vcs_csefax, vcs_cseeml, vcs_csermk, vcs_csedef, 
			vcs_accno, 	vcs_accnam, @USER, @USER,
			GETDATE(), GETDATE()
		FROM
			VNCSEINF
		WHERE
--			vcs_cocde = @COCDE and
			vcs_venno = @FVENNO


	INSERT INTO
		VNPRCTRM
			(vpt_cocde,vpt_venno,vpt_prctrm,vpt_prcdef,vpt_creusr,
			vpt_updusr,vpt_credat,vpt_upddat)
		SELECT
			' ',@TVENNO,vpt_prctrm,vpt_prcdef,@USER,@USER,
			GETDATE(),GETDATE()
		FROM
			VNPRCTRM
		WHERE
			vpt_venno = @FVENNO

	
	INSERT INTO
		VNCUGREL
			(vcr_cocde,vcr_venno,vcr_cugrpcde,vcr_flg_int,vcr_flg_ext,
			vcr_creusr,vcr_updusr,vcr_credat,vcr_upddat)
		SELECT
			' ',@TVENNO,vcr_cugrpcde,vcr_flg_int,vcr_flg_ext,
			@USER,@USER,GETDATE(),GETDATE()
		FROM
			VNCUGREL
		WHERE
			vcr_venno = @FVENNO

COMMIT TRAN






GO
GRANT EXECUTE ON [dbo].[sp_select_CopyVendor] TO [ERPUSER] AS [dbo]
GO
