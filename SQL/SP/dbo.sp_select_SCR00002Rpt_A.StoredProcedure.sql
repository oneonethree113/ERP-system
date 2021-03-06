/****** Object:  StoredProcedure [dbo].[sp_select_SCR00002Rpt_A]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCR00002Rpt_A]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCR00002Rpt_A]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Kenny Chan
Date:		17th March, 2002
Description:	SCR00002 Report

************************************************************************/
CREATE   PROCEDURE [dbo].[sp_select_SCR00002Rpt_A] 

@cocde 		nvarchar(6),
@CustFrom	nvarchar(6),
@CustTo		nvarchar(6),
@DateFrom	Datetime,
@DateTo		Datetime,
@usrid	nvarchar(30),
@doctyp	nvarchar(2)

AS

/* Frankie Cheung 20091008 
Declare @CurrencyRate numeric(11,4)
SET @DateTo = @DateTo + ' 23:59:59.988'
Select @CurrencyRate= ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD' --and ysi_cocde = @cocde
*/


Select 	@cocde as 'cocde',		@custFrom as 'CustFrom', 	@CustTo as 'CustTo', 	
	CONVERT(VARCHAR(10),@DateFrom ,101) as 'DateFrom',	CONVERT(VARCHAR(10),@DateTo ,101) as 'DateTo',
	a.cbi_cusno  as 'cbi_cusno', 	a.cbi_cusnam  as 'cbi_cussna', 	
	Case a.sod_selprc When 0 then 0 else a.sod_selprc/1000 end   as 'Sod_total', 
	Case isnull(b.sod_selprc,0) When 0 then 0 else b.sod_selprc/1000 end  as 'Sod_FDET',   	--1
	Case isnull(c.sod_selprc,0) When 0 then 0 else c.sod_selprc/1000 end  as 'Sod_FDHF',	--2
	Case isnull(d.sod_selprc,0) When 0 then 0 else d.sod_selprc/1000 end as 'Sod_FDHW',	--3
	Case isnull(e.sod_selprc,0) When 0 then 0 else e.sod_selprc/1000 end as 'Sod_FDMD',	--4
	Case isnull(f.sod_selprc,0) When 0 then 0 else f.sod_selprc/1000 end  as 'Sod_FDOH',		--5
	Case isnull(g.sod_selprc,0) When 0 then 0 else g.sod_selprc/1000 end  as 'Sod_FDVT',	--6
	Case isnull(h.sod_selprc,0) When 0 then 0 else h.sod_selprc/1000 end as 'Sod_FDXM',	--7
	Case isnull(i.sod_selprc,0) When 0 then 0 else i.sod_selprc/1000 end  as 'Sod_GPGP',		--8
	Case isnull(j.sod_selprc,0) When 0 then 0 else j.sod_selprc/1000 end  as 'Sod_HDAB',		--9
	Case isnull(k.sod_selprc,0) When 0 then 0 else k.sod_selprc/1000 end as 'Sod_HDCA',	--10
	Case isnull(l.sod_selprc,0) When 0 then 0 else l.sod_selprc/1000 end  as 'Sod_HDIA',		--11
	Case isnull(m.sod_selprc,0) When 0 then 0 else m.sod_selprc/1000 end as 'Sod_HDIF',	--12
	Case isnull(n.sod_selprc,0) When 0 then 0 else n.sod_selprc/1000 end as 'Sod_HDSC',	--13
	Case isnull(o.sod_selprc,0) When 0 then 0 else o.sod_selprc/1000 end as 'Sod_OTOT', 
	'' as 'compName'	
from 
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				--ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = @cocde and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordsts <> 'CAN' and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
	
Group by cbi_cusno , cbi_cusnam
) a 
--Cat FD/ET
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				--ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = @cocde and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	soh_ordsts <> 'CAN' and
	sod_cocde = soh_cocde and
	ibi_catlvl1 ='FD/ET' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) b
on a.cbi_cusno = b.cbi_cusno 
--Cat FD/HF
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc *@CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				--ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = @cocde and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	soh_ordsts <> 'CAN' and
	sod_cocde = soh_cocde and
	ibi_catlvl1 ='FD/HF' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) c
on (c.cbi_cusno = a.cbi_cusno)
--CAT FD/HW
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				--ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = @cocde and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='FD/HW' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) d
on (d.cbi_cusno = a.cbi_cusno)
--CAT FD/MD
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				--ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='FD/MD' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) e
on (e.cbi_cusno = a.cbi_cusno)
--CAT FD/OH
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				--ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='FD/OH' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) f
on (f.cbi_cusno = a.cbi_cusno)
--CAT FD/VT
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				--ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='FD/VT' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) g
on (g.cbi_cusno = a.cbi_cusno)
--CAT FD/XM
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
			--ibi_cocde =  sod_cocde and 
			ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='FD/XM' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) h
on (h.cbi_cusno = a.cbi_cusno)
--CAT GP/GP
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
			ibi_cocde =  sod_cocde and 
			ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='GP/GP' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) i
on (i.cbi_cusno = a.cbi_cusno)
--CAT HD/AB
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='HD/AB' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) j
on (j.cbi_cusno = a.cbi_cusno)

--CAT HD/CA
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
			--ibi_cocde =  sod_cocde and 
			ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='HD/CA' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) k
on (k.cbi_cusno = a.cbi_cusno)

--CAT HD/IA
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
			--ibi_cocde =  sod_cocde and 
			ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='HD/IA' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) l
on (l.cbi_cusno = a.cbi_cusno)

--CAT HD/IF
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				--ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='HD/IF' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) m
on (m.cbi_cusno = a.cbi_cusno)
--CAT HD/SC
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
				---ibi_cocde =  sod_cocde and 
				ibi_itmno = sod_itmno 
	Where	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	ibi_catlvl1 ='HD/SC' and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) n
on (n.cbi_cusno = a.cbi_cusno)
--CAT OT/OT
left Join
(
Select cbi_cusno , cbi_cusnam ,
--	Sum(CASE sod_curcde when 'HKD' then sod_selprc * @CurrencyRate else sod_selprc end) as 'sod_selprc'
	--Frankie Cheung 20091007
	sum(case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end) as 'sod_selprc'
	From SCORDHDR,CUBASINF
	,SCORDDTL
	left join IMBASINF on 
			--ibi_cocde =  sod_cocde and 
			ibi_itmno = sod_itmno 
	Where	
	soh_cocde = 'UCPP' and
	--cbi_cocde = soh_cocde and 
	cbi_cusno = soh_cus1no and
	soh_ordno = sod_ordno and
	sod_cocde = soh_cocde and
	soh_ordsts <> 'CAN' and
	(ibi_catlvl1 ='OT/OT' or ibi_catlvl1 ='' or ibi_catlvl1 is Null) and
	soh_credat Between @DateFrom and @DateTo and 
	cbi_cusno between @CustFrom and @CustTo
Group by cbi_cusno , cbi_cusnam
) o
on (o.cbi_cusno = a.cbi_cusno)

order by a.cbi_cusno








GO
GRANT EXECUTE ON [dbo].[sp_select_SCR00002Rpt_A] TO [ERPUSER] AS [dbo]
GO
