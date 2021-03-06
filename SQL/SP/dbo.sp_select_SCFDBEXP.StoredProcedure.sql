/****** Object:  StoredProcedure [dbo].[sp_select_SCFDBEXP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCFDBEXP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCFDBEXP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













CREATE  procedure [dbo].[sp_select_SCFDBEXP]
                                                                                                                                                                                                                                                                 
@cocde 	nvarchar(6),
@sbe_exptyp	nvarchar(6),
/*
@jobordf	nvarchar(30),
@jobordt	nvarchar(30),
@itmnof		nvarchar(30),
@itmnot		nvarchar(30),
*/
@IsDistinct	nvarchar(1),
@usrid	nvarchar(30),
@doctyp	nvarchar(2)
 
AS


create table #TEMP_RESULT
(
reccount int,
sbe_apprv nvarchar(1),
sbe_cocde nvarchar(6),
sbe_lotno nvarchar(255),
sbe_filename nvarchar(255),
sbe_jobord nvarchar(30),
yet_cde nvarchar(6),
sbe_exptyp nvarchar(255),
sbe_creusr nvarchar(30),
sbe_credat datetime,
sbe_updusr nvarchar(30),
sbe_upddat datetime,
tmp_cocde		nvarchar(10),
tmp_ordsts		nvarchar(10),
tmp_scno		nvarchar(20),
tmp_cusno		nvarchar(100),
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
tmp_ftyCV		nvarchar(20),
tmp_HKCV		nvarchar(20),
tmp_ConvHKCV		nvarchar(20),
tmp_ftyPV		nvarchar(20),
tmp_HKPV		nvarchar(20),
tmp_ConvHKPV		nvarchar(20),
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
tmp_zflgapprcv 		nvarchar(6),
tmp_zapprcvdat		nvarchar(20),
tmp_CVdiff		nvarchar(1),
tmp_PVdiff		nvarchar(1),
tmp_ftyprc03diff	nvarchar(1),
tmp_ftyprc01diff	nvarchar(1),
tmp_Pckdiff		nvarchar(1),
tmp_SAPSOdiff		nvarchar(1),
tmp_FileName		nvarchar(255)

)

insert into #TEMP_RESULT
select 	
0 ,
sbe_apprv,
sbe_cocde,
sbe_lotno,
sbe_filename,
sbe_jobord,
yet_cde,
isnull(yet_desc,'') as 'yet_desc',
sbe_creusr,
sbe_credat,
'' as 'sbe_updusr',
sbe_upddat,
sod_cocde,
soh_ordsts,
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
sfd_zapprwtcv,
poh_venno, 
sfd_zapprwtcv,
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
sfd_zflgapprcv 		,
convert(nvarchar(20),sfd_zapprcvdat,111), 
'',
'',
'',
'',
'',
'',
sfd_filename

from  SCFDBEXP (nolock)
inner join SCFTYDAT(nolock) on sfd_jobord = sbe_jobord
left join POORDDTL (nolock) on pod_jobord = sfd_jobord and pod_jobord <> ''
left join POORDHDR (nolock) on pod_cocde = poh_cocde and pod_purord = poh_purord
left join SCORDDTL (nolock) on sod_cocde = pod_cocde and sod_ordno = pod_scno and sod_ordseq = pod_scline
left join SCORDHDR (nolock) on sod_ordno = soh_ordno
left join CUBASINF (nolock) on cbi_cusno = soh_cus1no
left join SYSALREP on cbi_salrep = ysr_code1 and ysr_cocde = ' '
--left join SYSETINF (nolock) on ysi_typ = '23' and ysi_cde = poh_venno
left join SYEXPTYP on sbe_exptyp = yet_cde
where 
--((@status = 'L' and sfd_latest = 'Y') or @status = 'A') 
--and sfd_jobord <> '' and sfd_itmno <> '' 
--and sfd_credat  between @fromcredat + ' 00:00:00'  and  @tocredat + ' 23:59:59'
sfd_latest = 'Y'
and sfd_apprvflg in ('X', 'C', 'T') and isnull(sfd_zflgapprcv,'') = 'X' and isnull(sfd_zapprwtcv,'') <> ''
--and sfd_credat > '2009-03-25 16:00:00'
and sfd_jobord <> ''
--and ((pod_shpstr > '2008-12-31') or (pod_shpstr <= '2008-12-31' and sod_ordqty - sod_shpqty > 0))
--and
--(  @sbe_exptyp = ''  or (  @sbe_exptyp <> ''  and sbe_exptyp = @sbe_exptyp ) )
and isnull(sbe_jobord,'') <> '' 
and 	(	
		exists
		(	
			select 1 from syusrright
			where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
		or ysr_saltem in 
		(	
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
		or soh_cus1no in 
		(
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
	)
order by sod_cocde, pod_jobord


if ( @IsDistinct <> 'Y')
begin


update #TEMP_RESULT set tmp_ftyCV = tmp_ftyCV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_ftyCV = vbi_venno
update #TEMP_RESULT set tmp_ConvHKCV = tmp_ConvHKCV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_ConvHKCV = vbi_venno
update #TEMP_RESULT set tmp_HKCV = tmp_HKCV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_HKCV = vbi_venno
update #TEMP_RESULT set tmp_ftyPV = tmp_ftyPV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_ftyPV = vbi_venno
update #TEMP_RESULT set tmp_HKPV = tmp_HKPV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_HKPV = vbi_venno

select * from #TEMP_RESULT
where
sbe_apprv = 'N' 
order by sbe_jobord, 
tmp_itmno,tmp_ftyuntcde,tmp_ftyinrqty,tmp_ftymtrqty

end

else

begin

/*
select distinct sbe_cocde as 'tmp_cocde', pod_scno as 'tmp_scno' from SCFDBEXP
left join poorddtl(nolock) on pod_jobord = sbe_jobord
where
sbe_apprv = 'Y' and isnull(sbe_jobord,'') <> ''
*/


select distinct sbe_cocde as 'tmp_cocde', tmp_scno as 'tmp_scno' ,'Y' as 'tmp_do' into #TMP_DO from #TEMP_RESULT
where
sbe_apprv = 'Y' 
and
(
( tmp_fty01prc <> tmp_HKPVftyprc and tmp_fty01prc > 0 )--and tmp_fty01curr = tmp_HKPVftyprcCurr )
or 
( substring(tmp_FTYCV,1,1) <> substring(tmp_HKCV,1,1 )  and tmp_fty01prc > 0 )--and tmp_fty01curr =tmp_HKPVftyprcCurr) 
or
( substring(tmp_ftyPV,1,1) <> substring(tmp_HKPV,1,1)  and tmp_fty01prc > 0 )--and tmp_fty01curr = tmp_HKPVftyprcCurr)
)


select * from #TMP_DO


union
select distinct sbe_cocde as 'tmp_cocde', tmp_scno as 'tmp_scno' ,'N' as 'tmp_do' from #TEMP_RESULT
where
sbe_apprv = 'Y' 
and 
tmp_scno not in ( select tmp_scno from #TMP_DO)




end


GO
GRANT EXECUTE ON [dbo].[sp_select_SCFDBEXP] TO [ERPUSER] AS [dbo]
GO
