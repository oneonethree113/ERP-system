/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Item_GetPacking2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PDA_Item_GetPacking2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Item_GetPacking2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Description   	: sp_select_PDA_Item_GetPacking2
Programmer  	: Carlos Lui
ALTER  Date   	: 2012-06-26
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description          

*/


CREATE  procedure [dbo].[sp_select_PDA_Item_GetPacking2]

@itmno nvarchar(20)

as

SELECT	ibi_credat,
	' ' as 'ibi_cocde',
	ibi_itmno,
	ipi_pckseq,
	ipi_inrqty,
	ipi_mtrqty,
	ipi_cft,
	ipi_pckunt,
	ipi_conftr,
	ibi_tirtyp, 
	isnull(yts_moq,0) as ibi_moqctn,
	isnull(yts_moa,0) as ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt',
	ipi_qutdat,
	imu_cus1no,
	imu_cus2no,
	imu_hkprctrm,
	imu_ftyprctrm,
	imu_trantrm,
	imu_effdat,
	imu_expdat,
vbi_ventyp,
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
FROM	IMBASINF (NOLOCK) 
left join	VNBASINF on		vbi_venno = ibi_venno,
	IMPCKINF (NOLOCK),
	IMPRCINF (NOLOCK)
left join IMMOQMOA (NOLOCK) on imm_itmno = imu_itmno and imm_cus1no = imu_cus1no 
left join	SYTIESTR (NOLOCK) on	imu_mtrqty >= yts_qtyfr	AND
				imu_mtrqty < yts_qtyto	AND
				imu_venno = yts_venno	AND
				yts_tirtyp = 'M'		AND
				yts_itmtyp = 'R'		AND
				yts_effdat = (	select	top 1 yts_effdat
						from	SYTIESTR
						where	yts_venno = imu_venno
						order by	yts_effdat desc)
left join	SYCONFTR (NOLOCK) on	imu_pckunt = ycf_code1	AND
				ycf_code2 = 'PC',
	IMVENINF (NOLOCK) 
WHERE	(ibi_itmsts = 'CMP'			OR
	 ibi_itmsts = 'INC')				AND
	ibi_tirtyp = '1'				AND
	ibi_itmno = imu_itmno			AND
	ipi_pckunt = imu_pckunt			AND
	ipi_mtrqty = imu_mtrqty			AND
	ipi_inrqty = imu_inrqty			AND
--	imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)			AND
--	imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)	AND
	/*imu_ventyp = case vbi_ventyp
			when 'E' then 'D'
			else 'P'
			end			AND*/
	imu_status = 'ACT'				AND
 	ivi_itmno = ibi_itmno				AND
 	ivi_venno = imu_prdven			AND
	ivi_def = 'Y'				AND
	ibi_venno = imu_venno			AND
	ibi_itmno = ipi_itmno				AND
	ibi_typ = 'reg'				AND
 	ibi_venno not in ('0005','0006','0007','0008','0009')	AND
 	ibi_itmno = @itmno				--AND
	--imu_std = 'Y'

UNION

SELECT	ibi_credat,
	' ' as 'ibi_cocde',
	ibi_itmno,
	ipi_pckseq,
	ipi_inrqty,
	ipi_mtrqty,
	ipi_cft,
	ipi_pckunt,
	ipi_conftr,
	ibi_tirtyp, 
	ibi_moqctn,
	ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt',
	ipi_qutdat,
	imu_cus1no,
	imu_cus2no,
	imu_hkprctrm,
	imu_ftyprctrm,
	imu_trantrm,
	imu_effdat,
	imu_expdat,
vbi_ventyp,
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
FROM	IMBASINF (NOLOCK) 
left join	VNBASINF (NOLOCK) on	vbi_venno = ibi_venno,
	IMPCKINF (NOLOCK),
	IMPRCINF (NOLOCK) 
left join IMMOQMOA (NOLOCK) on imm_itmno = imu_itmno and imm_cus1no = imu_cus1no 
left join	SYCONFTR (NOLOCK) on	imu_pckunt = ycf_code1	AND
				ycf_code2 = 'PC',
	IMVENINF (NOLOCK) 
WHERE	(ibi_itmsts = 'CMP'			OR
	 ibi_itmsts = 'INC')				AND
	ibi_tirtyp = '2'				AND
	ibi_itmno = imu_itmno			AND
	ipi_pckunt = imu_pckunt			AND
	ipi_mtrqty = imu_mtrqty			AND
	ipi_inrqty = imu_inrqty			AND
--	imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)			AND
--	imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)	AND
	/*imu_ventyp = case vbi_ventyp
			when  'E' then 'D'
			else 'P'
			end			AND*/
	imu_status = 'ACT'				AND
 	ivi_itmno = ibi_itmno				AND
 	ivi_venno = imu_prdven			AND
	ivi_def = 'Y'				AND
	ibi_venno = imu_venno			AND
	ibi_itmno = ipi_itmno				AND
	ibi_typ = 'reg'				AND
 	ibi_venno not in ('0005','0006','0007','0008','0009')	AND
 	ibi_itmno = @itmno				--AND
	--imu_std = 'Y'

UNION

SELECT	ibi_credat,
	' ' as 'ibi_cocde',
	ibi_itmno,
	ipi_pckseq,
	ipi_inrqty,
	ipi_mtrqty,
	ipi_cft,
	ipi_pckunt,
	ipi_conftr,
	ibi_tirtyp, 
	isnull(yts_moq,0) as ibi_moqctn,
	isnull(yts_moa,0) as ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt',
	ipi_qutdat,
	imu_cus1no,
	imu_cus2no,
	imu_hkprctrm,
	imu_ftyprctrm,
	imu_trantrm,
	imu_effdat,
	imu_expdat,
vbi_ventyp,
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
FROM	IMPDAINF(NOLOCK)
left join	IMBASINF (NOLOCK) on	pda_itmno = ibi_itmno
left join	VNBASINF on		vbi_venno = ibi_venno,
	IMPCKINF (NOLOCK),
	IMPRCINF (NOLOCK) 
left join IMMOQMOA (NOLOCK) on imm_itmno = imu_itmno and imm_cus1no = imu_cus1no 
left join	SYTIESTR (NOLOCK) on	imu_mtrqty >= yts_qtyfr	AND
				imu_mtrqty < yts_qtyto	AND
				imu_venno = yts_venno	AND
				yts_tirtyp = 'M'		AND
				yts_itmtyp = 'R'		AND
				yts_effdat = (	select	top 1 yts_effdat
						from	SYTIESTR
						where	yts_venno = imu_venno
						order by	yts_effdat desc)
left join	SYCONFTR (NOLOCK) on	imu_pckunt = ycf_code1	AND
				ycf_code2 = 'PC',
	IMVENINF (NOLOCK) 
WHERE	(ibi_itmsts = 'CMP'			OR
	 ibi_itmsts = 'INC')				AND
	ibi_tirtyp = '1'				AND
	ibi_itmno = imu_itmno			AND
	ipi_pckunt = imu_pckunt			AND
	ipi_mtrqty = imu_mtrqty			AND
	ipi_inrqty = imu_inrqty			AND
--	imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)			AND
--	imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)	AND
	/*imu_ventyp = case vbi_ventyp
			when 'E' then 'D'
			else 'P'
			end			AND*/
	imu_status = 'ACT'				AND
 	ivi_itmno = ibi_itmno				AND
 	ivi_venno = imu_prdven			AND
	ivi_def = 'Y'				AND
	ibi_venno = imu_venno			AND
	ibi_itmno = ipi_itmno				AND
	ibi_typ = 'reg'				AND
	ibi_itmno is not null				AND
 	ibi_venno not in ('0005','0006','0007','0008','0009')	AND
 	pda_itmno = @itmno				--AND
	--imu_std = 'Y'

UNION

SELECT	ibi_credat,
	' ' as 'ibi_cocde',
	ibi_itmno,
	ipi_pckseq,
	ipi_inrqty,
	ipi_mtrqty,
	ipi_cft,
	ipi_pckunt,
	ipi_conftr,
	ibi_tirtyp, 
	ibi_moqctn,
	ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt',
	ipi_qutdat,
	imu_cus1no,
	imu_cus2no,
	imu_hkprctrm,
	imu_ftyprctrm,
	imu_trantrm,
	imu_effdat,
	imu_expdat,
vbi_ventyp,
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
FROM	IMPDAINF (NOLOCK)
left join	IMBASINF (NOLOCK) on	pda_itmno = ibi_itmno
left join	VNBASINF (NOLOCK) on	vbi_venno = ibi_venno,
	IMPCKINF (NOLOCK),
	IMPRCINF (NOLOCK) 
left join IMMOQMOA (NOLOCK) on imm_itmno = imu_itmno and imm_cus1no = imu_cus1no 
left join	SYCONFTR (NOLOCK) on	imu_pckunt = ycf_code1	AND
				ycf_code2 = 'PC',
	IMVENINF (NOLOCK) 
WHERE	(ibi_itmsts = 'CMP'			OR
	 ibi_itmsts = 'INC')				AND
	ibi_tirtyp = '2'				AND
	ibi_itmno = imu_itmno			AND
	ipi_pckunt = imu_pckunt			AND
	ipi_mtrqty = imu_mtrqty			AND
	ipi_inrqty = imu_inrqty			AND
--	imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)			AND
--	imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)	AND
	/*imu_ventyp = case vbi_ventyp
			when 'E' then 'D'
			else 'P'
			end			AND*/
	imu_status = 'ACT'				AND
 	ivi_itmno = ibi_itmno				AND
 	ivi_venno = imu_prdven			AND
	ivi_def = 'Y'				AND
	ibi_venno = imu_venno			AND
	ibi_itmno = ipi_itmno				AND
	ibi_typ = 'reg'				AND
 	ibi_itmno is not null				AND
 	pda_itmno = @itmno				AND
 	ibi_venno not in ('0005','0006','0007','0008','0009')	--AND
	--imu_std = 'Y'
ORDER BY  ibi_itmno, ipi_pckunt, ipi_inrqty, ipi_mtrqty, ipi_conftr, imu_cus1no desc, imu_cus2no desc, imu_hkprctrm desc, imu_ftyprctrm desc, imu_trantrm desc, imu_effdat desc, imu_expdat desc
--ORDER BY 4 ASC







GO
GRANT EXECUTE ON [dbo].[sp_select_PDA_Item_GetPacking2] TO [ERPUSER] AS [dbo]
GO
