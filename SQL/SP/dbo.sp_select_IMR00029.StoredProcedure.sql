/****** Object:  StoredProcedure [dbo].[sp_select_IMR00029]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMR00029]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMR00029]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







--sp_select_IMR00029 '', 'L', 'A', '', ''

CREATE   procedure [dbo].[sp_select_IMR00029]

@cocde		nvarchar(6),
@status		nvarchar(1),
@exception	nvarchar(1),
@fromcredat	nvarchar(10),
@tocredat	nvarchar(10)

AS


create table #TEMP_RESULT
(
tmp_cocde		nvarchar(10),
tmp_scno		nvarchar(20),
tmp_cusno		nvarchar(200),
tmp_jobord		nvarchar(20),
tmp_itmno		nvarchar(20),
tmp_ftyuntcde		nvarchar(10),
tmp_ftyinrqty		int,
tmp_ftymtrqty		int,
tmp_HKuntcde		nvarchar(10),
tmp_HKinrqty		int,
tmp_HKmtrqty		int,
tmp_odrqty		int,
tmp_shpqty		int,
tmp_osqty		int,
tmp_ftyCV		nvarchar(100),
tmp_ftyCVApp		nvarchar(100),
tmp_ftyCVAppFlg		nvarchar(1),
tmp_HKCV		nvarchar(100),
tmp_ConvHKCV		nvarchar(100),
tmp_ftyPV		nvarchar(100),
tmp_HKPV		nvarchar(100),
tmp_ConvHKPV		nvarchar(100),
tmp_fty03Curr		nvarchar(10),
tmp_fty03prc		numeric(13,4),
tmp_HKDVftyprcCurr	nvarchar(10),
tmp_HKDVftyprc		numeric(13,4),
tmp_fty01Curr		nvarchar(10),
tmp_fty01prc		numeric(13,4),
tmp_HKPVftyprcCurr	nvarchar(10),
tmp_HKPVftyprc		numeric(13,4),
tmp_fty02Curr		nvarchar(10),
tmp_fty02prc		numeric(13,4),
tmp_fty04Curr		nvarchar(10),
tmp_fty04prc		numeric(13,4),
tmp_fty05Curr		nvarchar(10),
tmp_fty05prc		numeric(13,4),
tmp_poshpstr		nvarchar(20),
tmp_poshpend		nvarchar(20),
tmp_ftySAPSONo		nvarchar(20),
tmp_ftySAPSOLine	nvarchar(20),
tmp_HKSAPSONo		nvarchar(20),
tmp_HKSAPSOLine		nvarchar(20),
tmp_lastest		nvarchar(1),
tmp_apprvflg		nvarchar(1),
tmp_apprvdt		nvarchar(20),
tmp_cvapprvflg		nvarchar(1),
tmp_cvapprvdt		nvarchar(20),
tmp_CVdiff		nvarchar(1),
tmp_PVdiff		nvarchar(1),
tmp_ftyprc03diff	nvarchar(1),
tmp_ftyprc01diff	nvarchar(1),
tmp_Pckdiff		nvarchar(1),
tmp_SAPSOdiff		nvarchar(1)
)

insert into #TEMP_RESULT
select 	
sod_cocde,
sod_ordno,
soh_cus1no + ' - ' + cbi_cussna,
sfd_jobord,
sfd_itmno,
sfd_um, 
sfd_inrqty, 
sfd_mtrqty,
pod_untcde, 
pod_inrctn, 
pod_mtrctn,
sod_ordqty,
sod_shpqty,
sod_ordqty - sod_shpqty,
sfd_apprvpv,
sfd_zapprwtcv,
sfd_zflgapprcv,
poh_venno, 
isnull(ysi_sapcde,''),
sfd_wtpv,
pod_prdven,
'',
sfd_zi03_cur, 
sfd_zi03,
sod_dvfcurcde, 
sod_dvftyprc,
sfd_zi01_cur, 
sfd_zi01,
sod_fcurcde, 
sod_ftyprc,
sfd_zi02_cur, 
sfd_zi02,
sfd_zi04_cur, 
sfd_zi04,
sfd_zi05_cur, 
sfd_zi05,
convert(nvarchar(20), pod_shpstr, 111),
convert(nvarchar(20), pod_shpend, 111),
sfd_sapno, 
sfd_sapln,    
sod_zorvbeln, 
sod_zorposnr, 
sfd_latest,
sfd_apprvflg,
convert(nvarchar(20),sfd_apprvdt,111), 
sfd_zflgapprcv,
convert(nvarchar(20),sfd_zapprcvdat,111), 
'',
'',
'',
'',
'',
''
from SCFTYDAT (nolock)
left join POORDDTL (nolock) on pod_jobord = sfd_jobord and pod_jobord <> ''
left join POORDHDR (nolock) on pod_cocde = poh_cocde and pod_purord = poh_purord
left join SCORDDTL (nolock) on sod_cocde = pod_cocde and sod_ordno = pod_scno and sod_ordseq = pod_scline
left join SCORDHDR (nolock) on sod_ordno = soh_ordno
left join CUBASINF (nolock) on cbi_cusno = soh_cus1no
left join SYSETINF (nolock) on ysi_typ = '23' and ysi_cde = poh_venno
where 
--((@status = 'L' and sfd_latest = 'Y') or @status = 'A') 
--and sfd_jobord <> '' and sfd_itmno <> '' 
--and sfd_credat  between @fromcredat + ' 00:00:00'  and  @tocredat + ' 23:59:59'
sfd_latest = 'Y'
and sfd_apprvflg in ('X', 'C', 'T')
and sfd_zflgapprcv in ('X', 'C', 'T')
--and sfd_credat > '2009-03-25 16:00:00'	
and sfd_jobord <> ''
and ((pod_shpstr > '2008-12-31') or (pod_shpstr <= '2008-12-31' and sod_ordqty - sod_shpqty > 0))

order by sod_cocde, pod_jobord


--update #TEMP_RESULT set tmp_CVdiff = 'Y' where tmp_ftyCV <> tmp_ConvHKCV
update #TEMP_RESULT set tmp_CVdiff = 'Y' where tmp_ftyCVApp <> tmp_HKCV
update #TEMP_RESULT set tmp_PVdiff = 'Y' where tmp_ftyPV <> tmp_HKPV
update #TEMP_RESULT set tmp_ftyprc03diff = 'Y' where tmp_fty03Curr <> tmp_HKDVftyprcCurr or tmp_fty03prc <> tmp_HKDVftyprc
update #TEMP_RESULT set tmp_ftyprc01diff = 'Y' where tmp_fty01Curr <> tmp_HKPVftyprcCurr or tmp_fty01prc <> tmp_HKPVftyprc
update #TEMP_RESULT set tmp_Pckdiff = 'Y' where tmp_ftyuntcde <> tmp_HKuntcde or tmp_ftyinrqty <> tmp_HKinrqty or tmp_ftymtrqty <> tmp_HKmtrqty
update #TEMP_RESULT set tmp_SAPSOdiff = 'Y' where tmp_ftySAPSONo <> tmp_HKSAPSONo or tmp_ftySAPSOLine <> tmp_HKSAPSOLine

update #TEMP_RESULT set tmp_ftyCV = tmp_ftyCV + ' - ' + ysi_sapchndsc from #TEMP_RESULT, SYSETINF where ysi_typ = '23' and tmp_ftyCV = ysi_sapcde
update #TEMP_RESULT set tmp_ftyCVApp = tmp_ftyCVApp + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_ftyCVApp = vbi_venno
update #TEMP_RESULT set tmp_ConvHKCV = tmp_ConvHKCV + ' - ' + ysi_sapchndsc from #TEMP_RESULT, SYSETINF where ysi_typ = '23' and tmp_ConvHKCV = ysi_sapcde
update #TEMP_RESULT set tmp_HKCV = tmp_HKCV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_HKCV = vbi_venno
update #TEMP_RESULT set tmp_ftyPV = tmp_ftyPV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_ftyPV = vbi_venno
update #TEMP_RESULT set tmp_HKPV = tmp_HKPV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_HKPV = vbi_venno



if @exception = 'V'
	select * from #TEMP_RESULT where tmp_CVdiff = 'Y' or tmp_PVdiff = 'Y' order by tmp_cocde, tmp_jobord
else if @exception = 'C'
	select * from #TEMP_RESULT where tmp_ftyprc03diff = 'Y' or tmp_ftyprc01diff = 'Y' order by tmp_cocde, tmp_jobord
else if @exception = 'P'
	select * from #TEMP_RESULT where tmp_Pckdiff = 'Y' order by tmp_cocde, tmp_jobord
else if @exception = 'S'
	select * from #TEMP_RESULT where tmp_SAPSOdiff = 'Y' order by tmp_cocde, tmp_jobord
else
	select * from #TEMP_RESULT 
	where 	tmp_CVdiff = 'Y' or 
		tmp_PVdiff = 'Y' or 
		tmp_ftyprc03diff = 'Y' or 
		tmp_ftyprc01diff = 'Y' --or tmp_Pckdiff = 'Y' or tmp_SAPSOdiff = 'Y'
	order by tmp_cocde, tmp_jobord

GO
GRANT EXECUTE ON [dbo].[sp_select_IMR00029] TO [ERPUSER] AS [dbo]
GO
