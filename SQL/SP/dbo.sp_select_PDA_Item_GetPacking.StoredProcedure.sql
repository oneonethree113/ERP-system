/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Item_GetPacking]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PDA_Item_GetPacking]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Item_GetPacking]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










/*
=========================================================
Description   	: sp_select_PDA_Item_GetPacking
Programmer  	: Mark Lau
ALTER  Date   	: 2008-06-10
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description          
10 Jun 2008		Mark Lau	Get All Packing For An Item             
*/


CREATE procedure [dbo].[sp_select_PDA_Item_GetPacking]

@itmno nvarchar(20)

as


Select	ibi_credat, ' ' as 'ibi_cocde', ibi_itmno, ipi_pckseq, ipi_inrqty, ipi_mtrqty,
	ipi_cft, ipi_pckunt, ipi_conftr,
	ibi_tirtyp, 
	isnull(yts_moq,0) as ibi_moqctn,
	isnull(yts_moa,0) as ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt',
	ipi_qutdat 				-- Add by Joe on 20100416
FROM	IMBASINF (NOLOCK) 
left join VNBASINF on vbi_venno = ibi_venno,
 IMPCKINF (NOLOCK) , IMMRKUP (NOLOCK) 
left join SYTIESTR (NOLOCK) on imu_mtrqty >= yts_qtyfr and imu_mtrqty < yts_qtyto and --imu_cocde = yts_cocde and 
			imu_venno = yts_venno and yts_tirtyp = 'M' and yts_itmtyp = 'R' and
			yts_effdat = (select top 1 yts_effdat from SYTIESTR where yts_venno = imu_venno order by yts_effdat desc)

left join SYCONFTR (NOLOCK) on --imu_cocde = ycf_cocde and 
		imu_pckunt = ycf_code1 and ycf_code2 = 'PC'
,imveninf (NOLOCK) 
WHERE	--ipi_cocde = imu_cocde AND	
(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC')
AND	ibi_tirtyp = '1' 
AND	ibi_itmno = imu_itmno
AND	ipi_pckunt = imu_pckunt 
AND	ipi_mtrqty = imu_mtrqty
AND	ipi_inrqty = imu_inrqty
AND	imu_ventyp = case vbi_ventyp when   'E' then 'D' else 'P' end
and 	ivi_itmno = ibi_itmno
and 	ivi_venno = imu_prdven
AND	ivi_def = 'Y'
AND	ibi_venno = imu_venno
--AND	ibi_cocde = 'UCP'
--AND	ibi_cocde = ipi_cocde
AND	ibi_itmno = ipi_itmno
AND	ibi_typ = 'reg'
and 	ibi_venno not in  ('0005','0006','0007','0008','0009')
and 	ibi_itmno = @itmno
--and (ibi_itmno not like '00A%' and ibi_itmno not like '00B%' and ibi_itmno not like '00U%' and ibi_itmno not like '01A%' and ibi_itmno not like '01B%' and ibi_itmno not like '01U%' and ibi_itmno not like '02A%' and ibi_itmno not like '02B%' and ibi_itmno not like '02U%' and ibi_itmno not like '03A%' and ibi_itmno not like '03B%' and ibi_itmno not like '03U%'and ibi_itmno not like '04A%' and ibi_itmno not like '04B%' and ibi_itmno not like '04U%')
-- Added by Mark Lau 20090318
and imu_std = 'Y'


UNION

Select	ibi_credat, ' ' as 'ibi_cocde', ibi_itmno, ipi_pckseq, ipi_inrqty, ipi_mtrqty,
	ipi_cft, ipi_pckunt,  ipi_conftr,
	ibi_tirtyp, 
	ibi_moqctn,
	ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt',
	ipi_qutdat 				-- Add by Joe on 20100416
FROM	IMBASINF (NOLOCK) 
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno,
 IMPCKINF (NOLOCK) , IMMRKUP (NOLOCK) 
left join SYCONFTR (NOLOCK) on --imu_cocde = ycf_cocde and 
			imu_pckunt = ycf_code1 and ycf_code2 = 'PC'
,imveninf (NOLOCK) 
WHERE	--ipi_cocde = imu_cocde AND
 	(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC')
AND	ibi_tirtyp = '2' 
AND	ibi_itmno = imu_itmno
AND	ipi_pckunt = imu_pckunt 
AND	ipi_mtrqty = imu_mtrqty
AND	ipi_inrqty = imu_inrqty
AND	imu_ventyp = case vbi_ventyp when  'E' then 'D' else 'P' end
and 	ivi_itmno = ibi_itmno
and 	ivi_venno = imu_prdven
AND	ivi_def = 'Y'
AND	ibi_venno = imu_venno
--AND	ibi_cocde = 'UCP'
--AND	ibi_cocde = ipi_cocde
AND	ibi_itmno = ipi_itmno
AND	ibi_typ = 'reg'
and 	ibi_venno not in  ('0005','0006','0007','0008','0009')
and 	ibi_itmno = @itmno
--and (ibi_itmno not like '00A%' and ibi_itmno not like '00B%' and ibi_itmno not like '00U%' and ibi_itmno not like '01A%' and ibi_itmno not like '01B%' and ibi_itmno not like '01U%' and ibi_itmno not like '02A%' and ibi_itmno not like '02B%' and ibi_itmno not like '02U%' and ibi_itmno not like '03A%' and ibi_itmno not like '03B%' and ibi_itmno not like '03U%'and ibi_itmno not like '04A%' and ibi_itmno not like '04B%' and ibi_itmno not like '04U%')
-- Added by Mark Lau 20090318
and imu_std = 'Y'


/**********Lester Wu 2006-03-21, retrieve data of old items*********************************************/
UNION
Select	ibi_credat, ' ' as 'ibi_cocde', ibi_itmno, ipi_pckseq, ipi_inrqty, ipi_mtrqty,
	ipi_cft, ipi_pckunt,  ipi_conftr,
	ibi_tirtyp, 
	isnull(yts_moq,0) as ibi_moqctn,
	isnull(yts_moa,0) as ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt',
	ipi_qutdat 				-- Add by Joe on 20100416
FROM	
IMPDAINF(NOLOCK)
left join IMBASINF (NOLOCK) on pda_itmno = ibi_itmno
left join VNBASINF on vbi_venno = ibi_venno,
 IMPCKINF (NOLOCK) , IMMRKUP (NOLOCK) 
left join SYTIESTR (NOLOCK) on imu_mtrqty >= yts_qtyfr and imu_mtrqty < yts_qtyto and --imu_cocde = yts_cocde and 
			imu_venno = yts_venno and yts_tirtyp = 'M' and yts_itmtyp = 'R'
 and
			yts_effdat = (select top 1 yts_effdat from SYTIESTR where yts_venno = imu_venno order by yts_effdat desc)

left join SYCONFTR (NOLOCK) on --imu_cocde = ycf_cocde and 
		imu_pckunt = ycf_code1 and ycf_code2 = 'PC'
,imveninf (NOLOCK) 
WHERE	--ipi_cocde = imu_cocde AND	
(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC')
AND	ibi_tirtyp = '1' 
AND	ibi_itmno = imu_itmno
AND	ipi_pckunt = imu_pckunt 
AND	ipi_mtrqty = imu_mtrqty
AND	ipi_inrqty = imu_inrqty
AND	imu_ventyp = case vbi_ventyp when   'E' then 'D' else 'P' end
and 	ivi_itmno = ibi_itmno
and 	ivi_venno = imu_prdven
AND	ivi_def = 'Y'
AND	ibi_venno = imu_venno
--AND	ibi_cocde = 'UCP'
--AND	ibi_cocde = ipi_cocde
AND	ibi_itmno = ipi_itmno
AND	ibi_typ = 'reg'
--AND	ibi_credat between @START and @END
--AND	pda_credat between @START and @END
AND	ibi_itmno is not null
and 	ibi_venno not in  ('0005','0006','0007','0008','0009')
and 	pda_itmno = @itmno
-- Added by Mark Lau 20090318
and imu_std = 'Y'


union

Select	ibi_credat, ' ' as 'ibi_cocde', ibi_itmno, ipi_pckseq, ipi_inrqty, ipi_mtrqty,
	ipi_cft, ipi_pckunt,  ipi_conftr,
	ibi_tirtyp, 
	ibi_moqctn,
	ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt',
	ipi_qutdat 				-- Add by Joe on 20100416
FROM	
IMPDAINF (NOLOCK)
left join IMBASINF (NOLOCK) on pda_itmno = ibi_itmno
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno,
 IMPCKINF (NOLOCK) , IMMRKUP (NOLOCK) 
left join SYCONFTR (NOLOCK) on --imu_cocde = ycf_cocde and 
			imu_pckunt = ycf_code1 and ycf_code2 = 'PC'
,imveninf (NOLOCK) 
WHERE	--ipi_cocde = imu_cocde AND
 	(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC')
AND	ibi_tirtyp = '2' 
AND	ibi_itmno = imu_itmno
AND	ipi_pckunt = imu_pckunt 
AND	ipi_mtrqty = imu_mtrqty
AND	ipi_inrqty = imu_inrqty
AND	imu_ventyp = case vbi_ventyp when  'E' then 'D' else 'P' end
and 	ivi_itmno = ibi_itmno
and 	ivi_venno = imu_prdven
AND	ivi_def = 'Y'
AND	ibi_venno = imu_venno
--AND	ibi_cocde = 'UCP'
--AND	ibi_cocde = ipi_cocde
AND	ibi_itmno = ipi_itmno
AND	ibi_typ = 'reg'
--AND	ibi_credat between @START and @END
--and	pda_credat between @START and @END
and 	ibi_itmno is not null
and 	pda_itmno = @itmno
-------------------------------------------------------------------
and 	ibi_venno not in  ('0005','0006','0007','0008','0009')
/**********Lester Wu 2006-03-21, retrieve data of old items*********************************************/
-- Added by Mark Lau 20090318
and imu_std = 'Y'


--der by 1 desc, 7, 3
Order by 4 asc --according to the program code on 20030826









GO
GRANT EXECUTE ON [dbo].[sp_select_PDA_Item_GetPacking] TO [ERPUSER] AS [dbo]
GO
