/****** Object:  StoredProcedure [dbo].[sp_SELECT_IMITMEXDAT_dtl]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_SELECT_IMITMEXDAT_dtl]
GO
/****** Object:  StoredProcedure [dbo].[sp_SELECT_IMITMEXDAT_dtl]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO












/*
=========================================================
Program ID	: sp_select_IMITMEXDAT_dtl
Description   	: 
Programmer  	: 
ALTER  Date   	:
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      	Initial  		Description                          
=========================================================
2012/06/18	David Yue	Replaced IMMRKUP and IMMRKUPDTL Table with IMPRCINF
=========================================================
*/

CREATE   PROCEDURE [dbo].[sp_SELECT_IMITMEXDAT_dtl] 

@imu_cocde	nvarchar(6),
@imu_itmno	nvarchar(20),
@imu_venno 	nvarchar(6),
@imu_prdven	nvarchar(6),
@imu_untcde	nvarchar(6),
@imu_cus1no	nvarchar(10),
@imu_cus2no	nvarchar(10),
@imu_mtrqty	int,
@imu_inrqty	int,
@imu_itmseq	int,
@ied_chkdat	datetime,
@ied_xlsfil	nvarchar(50)


AS	

declare
@ied_catlvl4 	nvarchar(20),
@ied_matcde	nvarchar(6),
@ied_itmtyp	nvarchar(4),
@ied_lnecde	nvarchar(50),
@ied_curcde	nvarchar(6),
@ied_ftyprc	numeric(13,4),
@ibd_bomqty	int,
@ied_itmprc	numeric(13,4),
@bomcst		numeric(13,4),
@bomprc		numeric(13,4),
@basprc		numeric(13,4),
@ied_fmlopt	nvarchar(50),
@itmprc_af	numeric(13,4),
@bomcst_af	numeric(13,4),
@bomprc_af	numeric(13,4),
@imu_basprc_af	numeric(13,4),
@imu_fmlopt_af	nvarchar(20),
@expdat_bf	datetime,
@expdat_af	datetime,
@ied_vencol	nvarchar(20),
@ied_vencoldsc	nvarchar(50),
@ied_vencol2	nvarchar(50)



SELECT 	@ied_catlvl4 = ied_catlvl4,	 
	@ied_matcde = ied_matcde,
	@ied_itmtyp = ied_itmtyp,
	@ied_lnecde = ied_lnecde,
	@ied_curcde = ied_curcde,
	@ied_ftyprc = ied_ftyprc,
	@ied_vencol = ied_vencol,
	@ied_vencoldsc = ied_vencoldsc,
	@ied_vencol2 = ied_vencol2
FROM 	IMITMEXDAT c 
WHERE	c.ied_ucpno = @imu_itmno and 	
	c.ied_venno = @imu_venno and  
	c.ied_prdven = @imu_prdven and  
	c.ied_untcde = @imu_untcde and  
	c.ied_mtrqty = @imu_mtrqty and 
	c.ied_inrqty = @imu_inrqty and  
	c.ied_itmseq = @imu_itmseq and
	c.ied_xlsfil = @ied_xlsfil and
	c.ied_chkdat = @ied_chkdat


exec 	sp_calc_extbasprc '', @imu_itmno, @imu_venno, @ied_catlvl4, @ied_matcde, @ied_itmtyp, @ied_lnecde, 
	@ied_curcde, @ied_ftyprc , @ied_xlsfil, @ied_chkdat, @imu_prdven,	
	@itmprc_af = @itmprc_af output, 
	@bomcst_af = @bomcst_af output, 
	@bomprc_af = @bomprc_af output, 
	@imu_basprc_af = @imu_basprc_af output, 
	@imu_fmlopt_af = @imu_fmlopt_af output


SELECT	@expdat_bf = b.ici_expdat,
	@expdat_af = c.ied_expdat
FROM	IMITMEXDAT c, IMCSTINF b
WHERE	c.ied_ucpno = @imu_itmno and
	b.ici_itmno = @imu_itmno and
	c.ied_itmseq = @imu_itmseq

IF @imu_cus1no = '' 
BEGIN
	SELECT	'Eng Desc' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_engdsc as 'Before ',
		c.ied_engdsc as 'After'
	FROM	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Chin Desc' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_chndsc as 'Before ',
		c.ied_chndsc as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all
	
	SELECT 	'Currency' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_curcde as 'Before ',
		c.ied_curcde as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Factory cost' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_ftycst,13,4)) as 'Before ',
		ltrim(str( c.ied_ftycst,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq
	
	UNION 	all
	
	SELECT 	'Factory price' as 'Field Name',
		c.ied_mode as 'Mode', ltrim(str(b.imu_ftyprc,13,4)) as 'Before ', 
		ltrim(str( c.ied_ftyprc,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Markup Formula' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_fmlopt as 'Before ',
		@imu_fmlopt_af as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = 	@imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Basic Price Currency' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_bcurcde as 'Before ',
		(SELECT	ysi_cde FROM SYSETINF WHERE ysi_typ = '06' and ysi_def = 'Y') as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'BOM Price' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_bomprc,13,4)) as 'Before ',
		ltrim(str( @bomprc_af,13,4)) as 'After'
	FROM	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq
	
	UNION 	all

	SELECT 'Basic Price' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_basprc,13,4)) as 'Before ',
		ltrim(str( @imu_basprc_af,13,4)) as 'After'
	FROM	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

-- Editted by David Yue 2012/06/18: IMPRCINF no longer contains Cat Lvl 4. Use IMBASINF instead
/*
	SELECT distinct
		'Category 4' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_catlvl4 as 'Before ',
		c.ied_catlvl4 as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq
*/

	SELECT 	distinct
		'Category 4' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_catlvl4 as 'Before ',
		c.ied_catlvl4 as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE
		c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.ibi_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and							
		c.ied_itmseq = @imu_itmseq

	UNION 	all
	
	SELECT	'Material' as 'Field Name',  
		c.ied_mode as 'Mode', 
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_cde = b.ibi_material and ysi_typ = '25') as 'Before ',  
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_cde = c.ied_matcde and ysi_typ = '25') as 'After'
	FROM	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all
	
	SELECT	'CFT' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_cft,13,4)) as 'Before ',
		ltrim(str( c.ied_cft,13,4)) as 'After'
	FROM	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'PC (convert to PC Qty)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str( b.imu_conftr,13,0)) as 'Before ',
		ltrim(str( c.ied_conftr,13,0)) as 'After'
	FROM	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'FTY Price term' as 'Field Name',
		c.ied_mode as 'Mode', b.imu_ftyprctrm as 'Before ',
		c.ied_prctrm as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'HK Price term' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_hkprctrm as 'Before ',
		c.ied_hkprctrm as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Inner Measurement L (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_inrdin,13,4)) as 'Before ',
		ltrim(str( c.ied_inrlin,13,4)) as 'After'
	FROM	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Inner Measurement W (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_inrwin,13,4)) as 'Before ',
		ltrim(str( c.ied_inrwin,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde  = @imu_untcde and
		b.ipi_pckunt  = @imu_untcde and
		c.ied_mtrqty  = @imu_mtrqty and
		b.ipi_mtrqty  = @imu_mtrqty and
		c.ied_inrqty  = @imu_inrqty and
		b.ipi_inrqty  = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Inner Measurement H (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_inrhin,13,4)) as 'Before ',
		ltrim(str( c.ied_inrhin,13,4)) as 'After'
	FROM	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 'Master Measurement L (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_mtrdin,13,4)) as 'Before ',
		ltrim(str( c.ied_mtrlin,13,4)) as 'After'
	FROM	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Master Measurement W (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_mtrwin,13,4)) as 'Before ',
		ltrim(str( c.ied_mtrwin,13,4)) as 'After'
	FROM	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Master Measurement H (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_mtrhin,13,4)) as 'Before ',
		ltrim(str( c.ied_mtrhin,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Remark' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_rmk as 'Before ',
		c.ied_remark as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
	  	c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Item Nature' as 'Field Name',
		c.ied_mode as 'Mode',
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_typ = '20' and ysi_cde = b.ibi_itmnat) as 'Before ', 
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_typ = '20' and ysi_cde =  c.ied_nat) as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Finishing' as 'Field Name',
		c.ied_mode as 'Mode',
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_typ = '24' and ysi_cde = b.ibi_finishing) as 'Before', 
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_typ = '24' and ysi_cde =  c.ied_finishing) as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Packing Info customer no.' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ipi_cusno as 'Before ',
		c.ied_cus1no as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Internal Remark' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_rmk as 'Before ', 
		case when c.ied_intrmk = '' then b.ibi_rmk else c.ied_intrmk end as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
	  	c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Cost Expiry Date' as 'Field Name',
		c.ied_mode as 'Mode',
		case when convert(int, b.ici_expdat) = 0 then '' else convert(nvarchar(100), b.ici_expdat) end as 'Before', 
		case when convert(int, c.ied_expdat) = 0 then
			case when convert(int, b.ici_expdat) = 0 then '' else convert(nvarchar(100), b.ici_expdat) end
			else convert(nvarchar(100),c.ied_expdat) end as 'After'
	FROM IMITMEXDAT c, IMCSTINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ici_itmno = @imu_itmno and
	  	c.ied_itmseq = @imu_itmseq

	UNION all

	SELECT	'Cost Remark' as 'Field Name',
		c.ied_mode as 'Mode',
		isnull(b.ici_cstrmk,'') as 'Before ', 
		case when c.ied_cstrmk = '' then isnull(b.ici_cstrmk,'') else c.ied_cstrmk end as 'After'
	FROM 	IMITMEXDAT c, IMCSTINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ici_itmno = @imu_itmno and
	 	c.ied_itmseq = @imu_itmseq
----------------
END
ELSE
BEGIN
---------------
	-- Start of records with Primary Customer Specific 

	SELECT	'Eng Desc' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_engdsc as 'Before ',
		c.ied_engdsc as 'After'
	FROM	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Chin Desc' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_chndsc as 'Before ',
		c.ied_chndsc as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all
	
	SELECT 	'Currency' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_curcde as 'Before ',
		c.ied_curcde as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_cus1no = @imu_cus1no and
		b.imu_cus2no = @imu_cus2no and									
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Factory cost' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_ftycst,13,4)) as 'Before ',
		ltrim(str(c.ied_ftycst,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_cus1no = @imu_cus1no and
		b.imu_cus2no = @imu_cus2no and									
		c.ied_itmseq = @imu_itmseq

	UNION 	all
	
	SELECT 	'Factory price' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_ftyprc,13,4)) as 'Before ',
		ltrim(str(c.ied_ftyprc,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_cus1no = @imu_cus1no and
		b.imu_cus2no = @imu_cus2no and									
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Markup Formula' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_fmlopt as 'Before ',
		@imu_fmlopt_af as 'After'
	FROM	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = 	@imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_cus1no = @imu_cus1no and
		b.imu_cus2no = @imu_cus2no and									
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Basic Price Currency' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_bcurcde as 'Before ', 
		(SELECT ysi_cde FROM SYSETINF WHERE ysi_typ = '06' and ysi_def = 'Y') as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde  = @imu_untcde and
		b.imu_pckunt  = @imu_untcde and
		c.ied_mtrqty  = @imu_mtrqty and
		b.imu_mtrqty  = @imu_mtrqty and
		c.ied_inrqty  = @imu_inrqty and
		b.imu_inrqty  = @imu_inrqty and
		b.imu_cus1no = @imu_cus1no and
		b.imu_cus2no = @imu_cus2no and									
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'BOM Price' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_bomprc,13,4)) as 'Before ',
		ltrim(str(@bomprc_af,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_cus1no = @imu_cus1no and
		b.imu_cus2no = @imu_cus2no and									
		c.ied_itmseq = @imu_itmseq
	
	UNION 	all

	SELECT 	'Basic Price' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_basprc,13,4)) as 'Before ',
		ltrim(str(@imu_basprc_af,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_cus1no = @imu_cus1no and
		b.imu_cus2no = @imu_cus2no and								
		c.ied_itmseq = @imu_itmseq

	UNION 	all
-- Editted by David Yue 2012/06/18: IMPRCINF no longer contains Cat Lvl 4. Use IMBASINF instead
/*
	SELECT 	'Category 4' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_catlvl4 as 'Before ',
		c.ied_catlvl4 as 'After'
	FROM 	IMITMEXDAT c, IMMRKUPDTL b
	WHERE
		c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_cus1no = @imu_cus1no and
		b.imu_cus2no = @imu_cus2no and									
		c.ied_itmseq = @imu_itmseq
*/

	SELECT 	'Category 4' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_catlvl4 as 'Before ',
		c.ied_catlvl4 as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE
		c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.ibi_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and							
		c.ied_itmseq = @imu_itmseq

	UNION all
	
	SELECT	'Material' as 'Field Name',  
		c.ied_mode as 'Mode', 
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_cde = b.ibi_material and ysi_typ = '25') as 'Before ',  
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_cde = c.ied_matcde and ysi_typ = '25') as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all
	
	SELECT 	'CFT' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.imu_cft,13,4)) as 'Before ',
		ltrim(str( c.ied_cft,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'PC (convert to PC Qty)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str( b.imu_conftr,13,0)) as 'Before ',
		ltrim(str( c.ied_conftr,13,0)) as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'FTY Price term' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_ftyprctrm as 'Before ',
		c.ied_prctrm as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
		c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
		c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde = @imu_untcde and
		b.imu_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.imu_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.imu_inrqty = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'HK Price term' as 'Field Name',
		c.ied_mode as 'Mode',
		b.imu_hkprctrm as 'Before ',
		c.ied_hkprctrm as 'After'
	FROM 	IMITMEXDAT c, IMPRCINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.imu_itmno = @imu_itmno and
	  	c.ied_venno = @imu_venno and
		b.imu_venno = @imu_venno and
	  	c.ied_prdven = @imu_prdven and
		b.imu_prdven = @imu_prdven and
		c.ied_untcde  = @imu_untcde and
		b.imu_pckunt  = @imu_untcde and
		c.ied_mtrqty  = @imu_mtrqty and
		b.imu_mtrqty  = @imu_mtrqty and
		c.ied_inrqty  = @imu_inrqty and
		b.imu_inrqty  = @imu_inrqty and
		b.imu_ventyp = 'D' and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Inner Measurement L (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_inrdin,13,4)) as 'Before ',
		ltrim(str( c.ied_inrlin,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Inner Measurement W (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_inrwin,13,4)) as 'Before ',
		ltrim(str(c.ied_inrwin,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Inner Measurement H (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_inrhin,13,4)) as 'Before ',
		ltrim(str(c.ied_inrhin,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde  = @imu_untcde and
		b.ipi_pckunt  = @imu_untcde and
		c.ied_mtrqty  = @imu_mtrqty and
		b.ipi_mtrqty  = @imu_mtrqty and
		c.ied_inrqty  = @imu_inrqty and
		b.ipi_inrqty  = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Master Measurement L (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_mtrdin,13,4)) as 'Before ',
		ltrim(str(c.ied_mtrlin,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde  = @imu_untcde and
		b.ipi_pckunt  = @imu_untcde and
		c.ied_mtrqty  = @imu_mtrqty and
		b.ipi_mtrqty  = @imu_mtrqty and
		c.ied_inrqty  = @imu_inrqty and
		b.ipi_inrqty  = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Master Measurement W (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_mtrwin,13,4)) as 'Before ',
		ltrim(str(c.ied_mtrwin,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION	all

	SELECT 	'Master Measurement H (in)' as 'Field Name',
		c.ied_mode as 'Mode',
		ltrim(str(b.ipi_mtrhin,13,4)) as 'Before ',
		ltrim(str(c.ied_mtrhin,13,4)) as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Remark' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_rmk as 'Before ',
		c.ied_remark as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
	  	c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Item Nature' as 'Field Name',
		c.ied_mode as 'Mode',
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_typ = '20' and ysi_cde = b.ibi_itmnat) as 'Before', 
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_typ = '20' and ysi_cde = c.ied_nat) as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Finishing' as 'Field Name',
		c.ied_mode as 'Mode',
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_typ = '24' and ysi_cde = b.ibi_finishing) as 'Before', 
		(SELECT ysi_dsc FROM SYSETINF WHERE ysi_typ = '24' and ysi_cde = c.ied_finishing) as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT 	'Packing Info customer no.' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ipi_cusno as 'Before ',
		c.ied_cus1no as 'After'
	FROM 	IMITMEXDAT c, IMPCKINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ipi_itmno = @imu_itmno and
		c.ied_untcde = @imu_untcde and
		b.ipi_pckunt = @imu_untcde and
		c.ied_mtrqty = @imu_mtrqty and
		b.ipi_mtrqty = @imu_mtrqty and
		c.ied_inrqty = @imu_inrqty and
		b.ipi_inrqty = @imu_inrqty and
		c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Internal Remark' as 'Field Name',
		c.ied_mode as 'Mode',
		b.ibi_rmk as 'Before ', 
		case when c.ied_intrmk = '' then b.ibi_rmk else c.ied_intrmk end as 'After'
	FROM 	IMITMEXDAT c, IMBASINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ibi_itmno = @imu_itmno and
	 	c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Cost Expiry Date' as 'Field Name',
		c.ied_mode as 'Mode',
		case when convert(int, b.ici_expdat) = 0 then '' else convert(nvarchar(100), b.ici_expdat) end as 'Before', 
		case when convert(int, c.ied_expdat) = 0 
			then case when convert(int, b.ici_expdat) = 0 then '' else convert(nvarchar(100), b.ici_expdat) end
			else convert(nvarchar(100),c.ied_expdat) end as 'After'
	FROM 	IMITMEXDAT c, IMCSTINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ici_itmno = @imu_itmno and
	  	c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Cost Remark' as 'Field Name',
		c.ied_mode as 'Mode',
		isnull(b.ici_cstrmk,'') as 'Before ', 
		case when c.ied_cstrmk = '' then isnull(b.ici_cstrmk,'') else c.ied_cstrmk end as 'After'
	FROM 	IMITMEXDAT c, IMCSTINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.ici_itmno = @imu_itmno and
	  	c.ied_itmseq = @imu_itmseq

	UNION 	all

	SELECT	'Color Code' as 'Field Name',
		c.ied_mode as 'Mode',
		isnull(b.icf_colcde,'') as 'Before ', 
		case when ltrim(rtrim(c.ied_vencol)) = '' then isnull(b.icf_colcde,'') else c.ied_vencol end as 'After'
	FROM 	IMITMEXDAT c, IMCOLINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.icf_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq and
		b.icf_colcde = @ied_vencol

	UNION 	all

	SELECT	'Color Description' as 'Field Name',
		c.ied_mode as 'Mode',
		isnull(b.icf_coldsc,'') as 'Before ', 
		case when ltrim(rtrim(c.ied_vencoldsc)) = '' then isnull(b.icf_coldsc,'') else c.ied_vencoldsc end as 'After'
	FROM 	IMITMEXDAT c, IMCOLINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.icf_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq and
		b.icf_colcde = @ied_vencol

	UNION 	all

	SELECT	'Vendor Color Code' as 'Field Name',
		c.ied_mode as 'Mode',
		isnull(b.icf_vencol,'') as 'Before ', 
		case when ltrim(rtrim(c.ied_vencol2)) = '' then isnull(b.icf_vencol,'') else c.ied_vencol2 end as 'After'
	FROM 	IMITMEXDAT c, IMCOLINF b
	WHERE	c.ied_ucpno = @imu_itmno and
		b.icf_itmno = @imu_itmno and
		c.ied_itmseq = @imu_itmseq and
		b.icf_colcde = @ied_vencol

END










GO
GRANT EXECUTE ON [dbo].[sp_SELECT_IMITMEXDAT_dtl] TO [ERPUSER] AS [dbo]
GO
