/****** Object:  StoredProcedure [dbo].[sp_select_VMI00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_VMI00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_VMI00001]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: sp_select_VMI00001
Description   	: House Keep Item Master
Programmer  	: PIC
ALTER  Date   	:
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description                          
=========================================================    
2003/03/15		Allan Yuen		Bug Fix Date Selection Error
2003/07/19		Allan Yuen		Modify For Merge Porject 
				(Disable company code)
2004/07/26		Allan Yuen		Add Wastage % field in IMBASINF
2004/09/06		Lester Wu		Add checking to items which belongs to Assortment Items or BOM Items
				Not Move these Items from current table (IMBASINF) to history table (IMBASINFH)
				**Assume no Assorment belongs to an Assortment / Assortment belongs to Regular
2005/01/05		Allan Yuen		Add IMCSTINF Table.
2006/01/23		Allan Yuen		Add Factory Price Term

2007/04/02		Marco Chan		Change by human operation

2009/07/30		Marco Chan		Fix for IMMRKUP, IMPCKINF with conftr
*/

CREATE   procedure [dbo].[sp_select_VMI00001]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cocde nvarchar(6) = ''
                                           
---------------------------------------------- 
 
AS

SET NOCOUNT ON

BEGIN

	DECLARE @yco_irday int,
	@yco_ir2day int,
	@ibi_itmno nvarchar(20),
	@ibi_venno nvarchar(6),
	@yymm nvarchar(5),
	@match int,
	@ibi_itmtyp nvarchar(6)

	if month(getdate()) = 1
		SET @yymm = '01/15'
	else
		SET @yymm = '07/15'
	--- Hard code to execute the program --
	set @match  = 1
	---------------------------------------
	
	IF @match > 0
	BEGIN
		
		SELECT 
			@yco_irday = yco_irday,
			@yco_ir2day = yco_ir2day
		FROM 
			SYCOMINF 
		WHERE 
			yco_cocde = 'UCPP'

		SELECT
			ibi_itmno, 
			ibi_venno,
			case isnull(ibi_typ,'') 	when 'ASS' then '01-ASS'
					when 'REG' then '02-REG'
					when 'BOM' then '03-BOM'
					else '09-OTH' end as 'ibi_itmtyp'
		into 	#TEMP_ITEM
		FROM 
			IMBASINF
		WHERE 
			((datediff(mm, ibi_credat,  GETDATE()) > @yco_ir2day AND ( ibi_latrdat is null or ibi_latrdat = '')) or
			datediff(mm,  ibi_latrdat, GETDATE()) > @yco_irday)  
			AND IBI_ITMSTS <> 'CLO' --AND IBI_ITMSTS <> 'OLD'
		ORDER BY
			[ibi_itmtyp],
			ibi_itmno

		

		delete from #TEMP_ITEM from #TEMP_ITEM, SCORDDTL 
		where sod_itmno = ibi_itmno and (datediff(mm,  sod_credat, GETDATE()) < @yco_irday)
		
		delete from #TEMP_ITEM from #TEMP_ITEM, QUOTNDTL 
		where qud_itmno = ibi_itmno and (datediff(mm,  qud_credat, GETDATE()) < @yco_irday)

/*
		-- For internal vendor, only housekeep item in DIS status	
		delete from #TEMP_ITEM from #TEMP_ITEM a , IMBASINF b
		where a.ibi_itmno = b.ibi_itmno and b.ibi_itmsts <> 'DIS' 
		and b.ibi_venno >= 'A' and b.ibi_venno <= 'Z'
*/

		DECLARE cur_itmno CURSOR
		FOR 
			/*
				Lester Wu 2004/09/06
				Sort the Items to be Delete by Item Type with the following order ('ASS','REG','BOM')
				Assortment Items meet the criteria are to be deleted first, then Regular and BOM
				Items with records in IMBOMASS will not be moved from current to history
			*/			
			SELECT
			ibi_itmno, 
			ibi_venno,
			ibi_itmtyp
			from #TEMP_ITEM
			ORDER BY
			ibi_itmtyp, ibi_itmno
		
		OPEN cur_itmno
		FETCH NEXT FROM cur_itmno INTO
		@ibi_itmno, @ibi_venno
		--Lester Wu 2004/09/06
		,@ibi_itmtyp
		---------------------------
		WHILE @@fetch_status = 0
		BEGIN
		
		/*===================================================================
			Lester Wu 2004/09/06
			Items with records in IMBOMASS will not be moved from Current to History
		====================================================================*/
		IF NOT EXISTS(SELECT * FROM IMBOMASS WHERE IBA_ASSITM = @ibi_itmno)
		--BEGIN
		--	PRINT @ibi_itmno + ' -- Reference by other items'
		--END
		--ELSE
		BEGIN
		/*==================================================================*/
			PRINT @ibi_itmno
			-- Backup IMBASINF --
		
			INSERT INTO IMBASINFH 
			(
				ibi_cocde,
				ibi_itmno,
				ibi_orgitm,
				ibi_lnecde,
				ibi_prdtyp,
				ibi_curcde,
				ibi_catlvl0,
				ibi_catlvl1,
				ibi_catlvl2,
				ibi_catlvl3,
				ibi_catlvl4,
				ibi_itmsts,
				ibi_typ,
				ibi_engdsc,
				ibi_chndsc,
				ibi_venno,
				ibi_cusven,
				ibi_tradeven,
				ibi_examven,
				ibi_imgpth,
				ibi_hamusa,
				ibi_hameur,
				ibi_dtyusa,
				ibi_dtyeur,
				ibi_cosmth,
				ibi_rmk,
				ibi_tirtyp,
				ibi_moqctn,
				ibi_qty,
				ibi_moa,
				ibi_prvsts,
				ibi_latrdat,
				ibi_alsitmno,
				ibi_alscat,
				ibi_orgdvenno,
				ibi_wastage,
				ibi_pditmno,
				ibi_mbcde,
				ibi_mbname,
				ibi_alscolcde,
				ibi_ftytmp,
				ibi_itmnat,
				ibi_dsgno,
				ibi_finishing,
				ibi_material,
				ibi_prdsizeTyp,
				ibi_prdsizeUnt,
				ibi_prdsizeVal,
				ibi_moqunttyp,
				ibi_prdicon,
				ibi_prdgrp,
				ibi_imgpthhr,
				ibi_season,
				ibi_designer,
				ibi_devteam,
				ibi_type,
				ibi_year,
				ibi_addreq_forma,
				ibi_addreq_ccbi,
				ibi_addreq_ster,
				ibi_creusr,
				ibi_updusr,
				ibi_credat,
				ibi_upddat
			)
			SELECT 
				ibi_cocde,
				ibi_itmno,
				ibi_orgitm,
				ibi_lnecde,
				ibi_prdtyp,
				ibi_curcde,
				ibi_catlvl0,
				ibi_catlvl1,
				ibi_catlvl2,
				ibi_catlvl3,
				ibi_catlvl4,
				ibi_itmsts,
				ibi_typ,
				ibi_engdsc,
				ibi_chndsc,
				ibi_venno,
				ibi_cusven,
				ibi_tradeven,
				ibi_examven,
				ibi_imgpth,
				ibi_hamusa,
				ibi_hameur,
				ibi_dtyusa,
				ibi_dtyeur,
				ibi_cosmth,
				ibi_rmk,
				ibi_tirtyp,
				ibi_moqctn,
				ibi_qty,
				ibi_moa,
				ibi_prvsts,
				ibi_latrdat,
				ibi_alsitmno,
				ibi_alscat,
				ibi_orgdvenno,
				ibi_wastage,
				ibi_pditmno,
				ibi_mbcde,
				ibi_mbname,
				ibi_alscolcde,
				ibi_ftytmp,
				ibi_itmnat,
				ibi_dsgno,
				ibi_finishing,
				ibi_material,
				ibi_prdsizeTyp,
				ibi_prdsizeUnt,
				ibi_prdsizeVal,
				ibi_moqunttyp,
				ibi_prdicon,
				ibi_prdgrp,
				ibi_imgpthhr,
				ibi_season,
				ibi_designer,
				ibi_devteam,
				ibi_type,
				ibi_year,
				ibi_addreq_forma,
				ibi_addreq_ccbi,
				ibi_addreq_ster,
				ibi_creusr,
				ibi_updusr,
				ibi_credat,
				ibi_upddat
			FROM 
				IMBASINF 
			WHERE 
				ibi_itmno = @ibi_itmno 
		
			UPDATE 
				IMBASINFH 
			SET 
				ibi_itmsts = 'INA'
			WHERE 
				ibi_itmno = @ibi_itmno 
						
			DELETE FROM IMBASINF WHERE ibi_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------
			
			-- Backup IMBOMASS --	
			INSERT INTO IMBOMASSH 
			(
				iba_cocde,
				iba_itmno,
				iba_assitm,
				iba_typ,
				iba_colcde,
				iba_pckunt,
				iba_bomqty,
				iba_inrqty,
				iba_mtrqty,
				iba_altitmno,
				iba_costing,
				iba_genpo,
				iba_curcde,
				iba_untcst,
				iba_ftyfmlopt,
				iba_fmlopt,
				iba_bombasprc,
				iba_fcurcde,
				iba_ftycst,
				iba_period,
				iba_creusr,
				iba_updusr,
				iba_credat,
				iba_upddat
			)
			SELECT
				iba_cocde,
				iba_itmno,
				iba_assitm,
				iba_typ,
				iba_colcde,
				iba_pckunt,
				iba_bomqty,
				iba_inrqty,
				iba_mtrqty,
				iba_altitmno,
				iba_costing,
				iba_genpo,
				iba_curcde,
				iba_untcst,
				iba_ftyfmlopt,
				iba_fmlopt,
				iba_bombasprc,
				iba_fcurcde,
				iba_ftycst,
				iba_period,
				iba_creusr,
				iba_updusr,
				iba_credat,
				iba_upddat
			FROM 
				IMBOMASS 
			WHERE 
				iba_itmno = @ibi_itmno 
		
			DELETE FROM IMBOMASS WHERE iba_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------
			
			-- Backup IMCOLINF --				
			INSERT INTO IMCOLINFH
			(
				icf_cocde,
				icf_itmno,
				icf_colcde,
				icf_colseq,
				icf_vencol,
				icf_coldsc,
				icf_typ,
				icf_ucpcde,
				icf_eancde,
				icf_asscol,
				icf_swatchpath,
				icf_imgpath,
				icf_venno,
				icf_lnecde,
				icf_creusr,
				icf_updusr,
				icf_credat,
				icf_upddat
			)
			SELECT 
				icf_cocde,
				icf_itmno,
				icf_colcde,
				icf_colseq,
				icf_vencol,
				icf_coldsc,
				icf_typ,
				icf_ucpcde,
				icf_eancde,
				icf_asscol,
				icf_swatchpath,
				icf_imgpath,
				icf_venno,
				icf_lnecde,
				icf_creusr,
				icf_updusr,
				icf_credat,
				icf_upddat
			FROM 
				IMCOLINF 
			WHERE 
				icf_itmno = @ibi_itmno 
			
			DELETE FROM IMCOLINF WHERE icf_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------
			
			-- Backup IMCTYINF --				
			INSERT INTO IMCTYINFH
			(
				ici_cocde,
				ici_itmno,
				ici_ctyseq,
				ici_ctycde,
				ici_cusno,
				ici_valdat,
				ici_rmk,
				ici_creusr,
				ici_updusr,
				ici_credat,
				ici_upddat
			)
			SELECT 
				ici_cocde,
				ici_itmno,
				ici_ctyseq,
				ici_ctycde,
				ici_cusno,
				ici_valdat,
				ici_rmk,
				ici_creusr,
				ici_updusr,
				ici_credat,
				ici_upddat
			FROM 
				IMCTYINF 
			WHERE 
				ici_itmno = @ibi_itmno 
			
			DELETE FROM IMCTYINF WHERE ici_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMMATBKD --
			INSERT INTO IMMATBKDH
			(
				ibm_cocde,
				ibm_itmno,
				ibm_matseq,
				ibm_mat,
				ibm_curcde,
				ibm_cst,
				ibm_cstper,
				ibm_wgtper,
				ibm_creusr,
				ibm_updusr,
				ibm_credat,
				ibm_upddat
			)
			SELECT 
				ibm_cocde,
				ibm_itmno,
				ibm_matseq,
				ibm_mat,
				ibm_curcde,
				ibm_cst,
				ibm_cstper,
				ibm_wgtper,
				ibm_creusr,
				ibm_updusr,
				ibm_credat,
				ibm_upddat
			FROM 
				IMMATBKD 
			WHERE 
				ibm_itmno = @ibi_itmno 
			
			DELETE FROM IMMATBKD WHERE ibm_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMPRCINF --
			INSERT INTO IMPRCINFH
			(
				imu_cocde,
				imu_itmno,
				imu_typ,
				imu_ventyp,
				imu_venno,
				imu_prdven,
				imu_pckunt,
				imu_conftr,
				imu_inrqty,
				imu_mtrqty,
				imu_cft,
				imu_cus1no,
				imu_cus2no,
				imu_ftyprctrm,
				imu_hkprctrm,
				imu_trantrm,
				imu_effdat,
				imu_expdat,
				imu_status,
				imu_curcde,
				imu_ftycst,
				imu_ftycstA,
				imu_ftycstB,
				imu_ftycstC,
				imu_ftycstD,
				imu_ftycstTran,
				imu_ftycstPack,
				imu_fml,
				imu_fmlA,
				imu_fmlB,
				imu_fmlC,
				imu_fmlD,
				imu_fmlTran,
				imu_fmlPack,
				imu_chgfp,
				imu_chgfpA,
				imu_chgfpB,
				imu_chgfpC,
				imu_chgfpD,
				imu_chgfpTran,
				imu_chgfpPack,
				imu_ftyprc,
				imu_ftyprcA,
				imu_ftyprcB,
				imu_ftyprcC,
				imu_ftyprcD,
				imu_ftyprcTran,
				imu_ftyprcPack,
				imu_bomcst,
				imu_ttlcst,
				imu_hkadjper,
				imu_negcst,
				imu_negprc,
				imu_fmlopt,
				imu_bcurcde,
				imu_itmprc,
				imu_bomprc,
				imu_basprc,
				imu_period,
				imu_cstchgdat,
				imu_sysgen,
				imu_estprcflg,
				imu_estprcref,
				imu_creusr,
				imu_updusr,
				imu_credat,
				imu_upddat
			)
			SELECT
				imu_cocde,
				imu_itmno,
				imu_typ,
				imu_ventyp,
				imu_venno,
				imu_prdven,
				imu_pckunt,
				imu_conftr,
				imu_inrqty,
				imu_mtrqty,
				imu_cft,
				imu_cus1no,
				imu_cus2no,
				imu_ftyprctrm,
				imu_hkprctrm,
				imu_trantrm,
				imu_effdat,
				imu_expdat,
				imu_status,
				imu_curcde,
				imu_ftycst,
				imu_ftycstA,
				imu_ftycstB,
				imu_ftycstC,
				imu_ftycstD,
				imu_ftycstTran,
				imu_ftycstPack,
				imu_fml,
				imu_fmlA,
				imu_fmlB,
				imu_fmlC,
				imu_fmlD,
				imu_fmlTran,
				imu_fmlPack,
				imu_chgfp,
				imu_chgfpA,
				imu_chgfpB,
				imu_chgfpC,
				imu_chgfpD,
				imu_chgfpTran,
				imu_chgfpPack,
				imu_ftyprc,
				imu_ftyprcA,
				imu_ftyprcB,
				imu_ftyprcC,
				imu_ftyprcD,
				imu_ftyprcTran,
				imu_ftyprcPack,
				imu_bomcst,
				imu_ttlcst,
				imu_hkadjper,
				imu_negcst,
				imu_negprc,
				imu_fmlopt,
				imu_bcurcde,
				imu_itmprc,
				imu_bomprc,
				imu_basprc,
				imu_period,
				imu_cstchgdat,
				imu_sysgen,
				imu_estprcflg,
				imu_estprcref,
				imu_creusr,
				imu_updusr,
				imu_credat,
				imu_upddat
			FROM 
				IMPRCINF 
			WHERE 
				imu_itmno = @ibi_itmno 
			
			DELETE FROM IMPRCINF WHERE imu_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMPCKINF --			
			INSERT INTO IMPCKINFH
			(
				ipi_cocde,
				ipi_itmno,
				ipi_pckseq,
				ipi_pckunt,
				ipi_mtrqty,
				ipi_inrqty,
				ipi_inrhin,
				ipi_inrwin,
				ipi_inrdin,
				ipi_inrhcm,
				ipi_inrwcm,
				ipi_inrdcm,
				ipi_mtrhin,
				ipi_mtrwin,
				ipi_mtrdin,
				ipi_mtrhcm,
				ipi_mtrwcm,
				ipi_mtrdcm,
				ipi_cft,
				ipi_cbm,
				ipi_grswgt,
				ipi_netwgt,
				ipi_pckitr,
				ipi_sappckid,
				ipi_conftr,
				ipi_cusno,
				ipi_qutdat,
				ipi_creusr,
				ipi_updusr,
				ipi_credat,
				ipi_upddat,
				ipi_inrsze,
				ipi_mtrsze,
				ipi_mat
			)
			SELECT 
				ipi_cocde,
				ipi_itmno,
				ipi_pckseq,
				ipi_pckunt,
				ipi_mtrqty,
				ipi_inrqty,
				ipi_inrhin,
				ipi_inrwin,
				ipi_inrdin,
				ipi_inrhcm,
				ipi_inrwcm,
				ipi_inrdcm,
				ipi_mtrhin,
				ipi_mtrwin,
				ipi_mtrdin,
				ipi_mtrhcm,
				ipi_mtrwcm,
				ipi_mtrdcm,
				ipi_cft,
				ipi_cbm,
				ipi_grswgt,
				ipi_netwgt,
				ipi_pckitr,
				ipi_sappckid,
				ipi_conftr,
				ipi_cusno,
				ipi_qutdat,
				ipi_creusr,
				ipi_updusr,
				ipi_credat,
				ipi_upddat,
				ipi_inrsze,
				ipi_mtrsze,
				ipi_mat
			FROM 
				IMPCKINF 
			WHERE 
				ipi_itmno = @ibi_itmno 
			
			DELETE FROM IMPCKINF WHERE ipi_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMSALBKG --
			INSERT INTO IMSALBKGH
			(
				isb_cocde,
				isb_itmno,
				isb_yymm,
				isb_mtdbok,
				isb_mtdsal,
				isb_mtdpur,
				isb_creusr,
				isb_updusr,
				isb_credat,
				isb_upddat
			)
			SELECT 
				isb_cocde,
				isb_itmno,
				isb_yymm,
				isb_mtdbok,
				isb_mtdsal,
				isb_mtdpur,
				isb_creusr,
				isb_updusr,
				isb_credat,
				isb_upddat
			FROM 
				IMSALBKG 
			WHERE 
				isb_itmno = @ibi_itmno 
			
			DELETE FROM IMSALBKG WHERE isb_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMVENINF --
			INSERT INTO IMVENINFH
			(
				ivi_cocde,
				ivi_itmno,
				ivi_venitm,
				ivi_venno,
				ivi_def,
				ivi_subcde,
				ivi_creusr,
				ivi_updusr,
				ivi_credat,
				ivi_upddat
			)
			SELECT 
				ivi_cocde,
				ivi_itmno,
				ivi_venitm,
				ivi_venno,
				ivi_def,
				ivi_subcde,
				ivi_creusr,
				ivi_updusr,
				ivi_credat,
				ivi_upddat
			FROM 
				IMVENINF 
			WHERE 
				ivi_itmno = @ibi_itmno 
			
			DELETE FROM IMVENINF WHERE ivi_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMVENPCK --
			INSERT INTO IMVENPCKH
			(
				ivp_cocde,
				ivp_itmno,
				ivp_pckseq,
				ivp_venno,
				ivp_relatn,
				ivp_creusr,
				ivp_updusr,
				ivp_credat,
				ivp_upddat
			) 
			SELECT 
				ivp_cocde,
				ivp_itmno,
				ivp_pckseq,
				ivp_venno,
				ivp_relatn,
				ivp_creusr,
				ivp_updusr,
				ivp_credat,
				ivp_upddat
			FROM 
				IMVENPCK 
			WHERE 
				ivp_itmno = @ibi_itmno  
			
			DELETE FROM IMVENPCK WHERE ivp_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMCSTINF --
			INSERT INTO IMCSTINFH
			(
				ici_cocde,
				ici_itmno,
				ici_cstrmk,
				ici_expdat,
				ici_creusr,
				ici_updusr,
				ici_credat,
				ici_upddat
			)
			SELECT
				ici_cocde,
				ici_itmno,
				ici_cstrmk,
				ici_expdat,
				ici_creusr,
				ici_updusr,
				ici_credat,
				ici_upddat
			FROM
				IMCSTINF
			WHERE
				ICI_ITMNO = @ibi_itmno

			DELETE FROM IMCSTINF WHERE ici_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMCUSNO --
			INSERT INTO IMCUSNOH
			(
				icn_itmno,
				icn_cusno,
				icn_rmk,
				icn_credat,
				icn_upddat,
				icn_creusr,
				icn_updusr
			)
			SELECT
				icn_itmno,
				icn_cusno,
				icn_rmk,
				icn_credat,
				icn_upddat,
				icn_creusr,
				icn_updusr
			FROM
				IMCUSNO
			WHERE
				ICN_ITMNO = @ibi_itmno

			DELETE FROM IMCUSNO WHERE icn_itmno = @ibi_itmno 
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

			-- Backup IMMOQMOA --
			INSERT INTO IMMOQMOAH
			(
				imm_cocde,
				imm_itmno,
				imm_cus1no,
				imm_cus2no,
				imm_tirtyp,
				imm_moqunttyp,
				imm_moqctn,
				imm_qty,
				imm_curcde,
				imm_moa,
				imm_creusr,
				imm_updusr,
				imm_credat,
				imm_upddat
			)
			SELECT
				imm_cocde,
				imm_itmno,
				imm_cus1no,
				imm_cus2no,
				imm_tirtyp,
				imm_moqunttyp,
				imm_moqctn,
				imm_qty,
				imm_curcde,
				imm_moa,
				imm_creusr,
				imm_updusr,
				imm_credat,
				imm_upddat
			FROM
				IMMOQMOA
			WHERE
				IMM_ITMNO = @ibi_itmno

			DELETE FROM IMMOQMOA WHERE IMM_ITMNO = @ibi_itmno
			-------------------------------------------------------------------------------------------------------------------------------------------------------			

		END
			FETCH NEXT FROM cur_itmno INTO
			@ibi_itmno, @ibi_venno,@ibi_itmtyp
		END
	
		CLOSE cur_itmno
		DEALLOCATE cur_itmno
	
	END
END













GO
GRANT EXECUTE ON [dbo].[sp_select_VMI00001] TO [ERPUSER] AS [dbo]
GO
