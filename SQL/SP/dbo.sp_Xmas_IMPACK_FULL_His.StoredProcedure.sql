/****** Object:  StoredProcedure [dbo].[sp_Xmas_IMPACK_FULL_His]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Xmas_IMPACK_FULL_His]
GO
/****** Object:  StoredProcedure [dbo].[sp_Xmas_IMPACK_FULL_His]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










/*
=========================================================
Description   	: Xmas_IMPACK_Full_His
Programmer  	: PIC
ALTER  Date   	: 2002-07-30
Last Modified  	: 2003-02-07
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description                          
=========================================================     
2003-02-07	VICTOR LEUNG	To find the year for searching data
2003-07-23	Lewis To		Change to use singlr file
2006-03-21	Lester Wu		Retrieve Data of Old Items
*/

CREATE procedure [dbo].[sp_Xmas_IMPACK_FULL_His]

as


DECLARE @TEMPDATE NVARCHAR(30)
DECLARE @START DATETIME
DECLARE @END DATETIME
DECLARE @Year VARCHAR(4)

-- Added by Victor Leung 20030207 -------------------
-- To find the year for searching data --------------
--if substring(convert(varchar(10), getdate(), 111),6,5) between '01/01' and '05/31'
--	SET @Year = LTRIM(STR(YEAR(getdate())-1))
--else
	SET @Year = LTRIM(STR(YEAR(getdate())))

-- REM by Mark Lau 20080331
--SET @TEMPDATE = STR(@Year) + '-02-15'+ ' 00:00:00.000'
SET @TEMPDATE = STR(@Year) + '-06-01'+ ' 00:00:00.000'
SET @START = @TEMPDATE

-- REM by Mark Lau 20080331
--SET @TEMPDATE = STR(@Year) + '-05-31' + ' 23:59:59.998'
SET @TEMPDATE = STR(@Year) + '-09-30' + ' 23:59:59.998'
SET @END = @TEMPDATE

------------------------------------------------------
 
Select	ibi_credat,
	' ' as 'ibi_cocde', ibi_itmno, ipi_pckseq, ipi_inrqty, ipi_mtrqty,
	ipi_cft, ipi_pckunt, 
	ibi_tirtyp, 
	isnull(yts_moq,0) as ibi_moqctn,
	isnull(yts_moa,0) as ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt'
FROM	IMBASINF (NOLOCK) 
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno, 
IMPCKINF (NOLOCK) , IMMRKUP (NOLOCK) 
left join SYTIESTR (NOLOCK) on imu_mtrqty >= yts_qtyfr and imu_mtrqty < yts_qtyto --and imu_cocde = yts_cocde 
			and  imu_venno = yts_venno and yts_tirtyp = 'M' and yts_itmtyp = 'R' and
			yts_effdat = (select top 1 yts_effdat from SYTIESTR where yts_venno = imu_venno order by yts_effdat desc)

left join SYCONFTR (NOLOCK) on --imu_cocde = ycf_cocde and 
			imu_pckunt = ycf_code1 and ycf_code2 = 'PC'
,IMVENINF (NOLOCK) 
WHERE	--ipi_cocde = imu_cocde AND
	(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC')
AND	ibi_tirtyp = '1' 
AND	ibi_itmno = imu_itmno
AND	ipi_pckunt = imu_pckunt 
AND	ipi_mtrqty = imu_mtrqty
AND	ipi_inrqty = imu_inrqty
AND	imu_ventyp = case vbi_ventyp when 'E' then   'D' else 'P' end
AND	ibi_venno = imu_venno
and 	ivi_itmno = ibi_itmno
AND	ibi_venno = imu_venno
AND	ivi_venno = imu_prdven
and 	ivi_def = 'Y'
--AND	ibi_cocde = 'UCP'
--AND	ibi_cocde = ipi_cocde
AND	ibi_itmno = ipi_itmno
AND	ibi_typ = 'reg'
AND	ibi_credat between @START and @END
-- Added by Mark Lau 20090318
and imu_std = 'Y'



UNION

Select	ibi_credat,
	' ' as 'ibi_cocde', ibi_itmno, ipi_pckseq, ipi_inrqty, ipi_mtrqty,
	ipi_cft, ipi_pckunt, 
	ibi_tirtyp, 
	ibi_moqctn,
	ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt'
FROM	IMBASINF (NOLOCK) 
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno,
 IMPCKINF (NOLOCK) , IMMRKUP (NOLOCK) 
left join SYCONFTR (NOLOCK) on --imu_cocde = ycf_cocde and 
			imu_pckunt = ycf_code1 and ycf_code2 = 'PC'
,IMVENINF (NOLOCK) 
WHERE	--ipi_cocde = imu_cocde AND
 	(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC')
AND	ibi_tirtyp = '2' 
AND	ibi_itmno = imu_itmno
AND	ipi_pckunt = imu_pckunt 
AND	ipi_mtrqty = imu_mtrqty
AND	ipi_inrqty = imu_inrqty
AND	imu_ventyp = case vbi_ventyp when 'E' then   'D' else 'P' end
AND	ibi_venno = imu_venno
and 	ivi_itmno = ibi_itmno
AND	ibi_venno = imu_venno
AND	ivi_venno = imu_prdven
and 	ivi_def = 'Y'
--AND	ibi_cocde = 'UCP'
--AND	ibi_cocde = ipi_cocde
AND	ibi_itmno = ipi_itmno
AND	ibi_typ = 'reg'
AND	ibi_credat between @START and @END
-- Added by Mark Lau 20090318
and imu_std = 'Y'


/**************Lester Wu 2006-03-21, retrieve data of old items******************/
/*UNION


Select	ibi_credat,
	' ' as 'ibi_cocde', ibi_itmno, ipi_pckseq, ipi_inrqty, ipi_mtrqty,
	ipi_cft, ipi_pckunt, 
	ibi_tirtyp, 
	isnull(yts_moq,0) as ibi_moqctn,
	isnull(yts_moa,0) as ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt'
FROM	
IMPDAINF (NOLOCK)
left join IMBASINF (NOLOCK) on pda_itmno = ibi_itmno
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno, 
IMPCKINF (NOLOCK) , IMMRKUP (NOLOCK) 
left join SYTIESTR (NOLOCK) on imu_mtrqty >= yts_qtyfr and imu_mtrqty < yts_qtyto --and imu_cocde = yts_cocde 
			and  imu_venno = yts_venno and yts_tirtyp = 'M' and yts_itmtyp = 'R'
left join SYCONFTR (NOLOCK) on --imu_cocde = ycf_cocde and 
			imu_pckunt = ycf_code1 and ycf_code2 = 'PC'
,IMVENINF (NOLOCK) 
WHERE	--ipi_cocde = imu_cocde AND
	(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC')
AND	ibi_tirtyp = '1' 
AND	ibi_itmno = imu_itmno
AND	ipi_pckunt = imu_pckunt 
AND	ipi_mtrqty = imu_mtrqty
AND	ipi_inrqty = imu_inrqty
AND	imu_ventyp = case vbi_ventyp when 'E' then   'D' else 'P' end
AND	ibi_venno = imu_venno
and 	ivi_itmno = ibi_itmno
AND	ibi_venno = imu_venno
AND	ivi_venno = imu_prdven
and 	ivi_def = 'Y'
--AND	ibi_cocde = 'UCP'
--AND	ibi_cocde = ipi_cocde
AND	ibi_itmno = ipi_itmno
AND	ibi_typ = 'reg'
--AND	ibi_credat between @START and @END
--AND	pda_credat between @START and @END
AND	ibi_itmno is not null


UNION

Select	ibi_credat,
	' ' as 'ibi_cocde', ibi_itmno, ipi_pckseq, ipi_inrqty, ipi_mtrqty,
	ipi_cft, ipi_pckunt, 
	ibi_tirtyp, 
	ibi_moqctn,
	ibi_moa,
	imu_bcurcde, 
	imu_basprc, 
	isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,ipi_pckunt) as 'ipi_smpunt'
FROM	
IMPDAINF (NOLOCK)
left join IMBASINF (NOLOCK) on pda_itmno = ibi_itmno
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno,
 IMPCKINF (NOLOCK) , IMMRKUP (NOLOCK) 
left join SYCONFTR (NOLOCK) on --imu_cocde = ycf_cocde and 
			imu_pckunt = ycf_code1 and ycf_code2 = 'PC'
,IMVENINF (NOLOCK) 
WHERE	--ipi_cocde = imu_cocde AND
 	(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC')
AND	ibi_tirtyp = '2' 
AND	ibi_itmno = imu_itmno
AND	ipi_pckunt = imu_pckunt 
AND	ipi_mtrqty = imu_mtrqty
AND	ipi_inrqty = imu_inrqty
AND	imu_ventyp = case vbi_ventyp when 'E' then   'D' else 'P' end
AND	ibi_venno = imu_venno
and 	ivi_itmno = ibi_itmno
AND	ibi_venno = imu_venno
AND	ivi_venno = imu_prdven
and 	ivi_def = 'Y'
--AND	ibi_cocde = 'UCP'
--AND	ibi_cocde = ipi_cocde
AND	ibi_itmno = ipi_itmno
AND	ibi_typ = 'reg'
--AND	ibi_credat between @START and @END
--AND	pda_credat between @START and @END
AND	ibi_itmno is not null
*/

/**************Lester Wu 2006-03-21, retrieve data of old items******************/

Order by 1 desc, 7, 3


GO
GRANT EXECUTE ON [dbo].[sp_Xmas_IMPACK_FULL_His] TO [ERPUSER] AS [dbo]
GO
