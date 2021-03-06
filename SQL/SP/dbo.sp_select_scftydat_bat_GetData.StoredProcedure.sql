/****** Object:  StoredProcedure [dbo].[sp_select_scftydat_bat_GetData]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_scftydat_bat_GetData]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_scftydat_bat_GetData]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



















--sp_select_scftydat_bat_GetData '', 'L', 'A', '','','','N'

CREATE     procedure [dbo].[sp_select_scftydat_bat_GetData]

@cocde		nvarchar(6),
@status		nvarchar(1),
@exception	nvarchar(1),
@fromcredat	nvarchar(10),
@tocredat	nvarchar(10),
@lotno		nvarchar(255),
@IsDistinct	nvarchar(1)

AS


create table #TEMP_RESULT
(
tmp_cocde		nvarchar(10),
tmp_ordsts		nvarchar(10),
tmp_scno		nvarchar(20),
tmp_cusno		nvarchar(255),
tmp_jobord		nvarchar(20),
tmp_itmno		nvarchar(255),
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
tmp_zapprcvtim		nvarchar(20),
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
sfd_zapprcvdat		,
sfd_zapprcvtim		,
'',
'',
'',
'',
'',
'',
sfd_filename

from SCFTYDAT (nolock)
left join POORDDTL (nolock) on pod_jobord = sfd_jobord and pod_jobord <> ''
left join POORDHDR (nolock) on pod_cocde = poh_cocde and pod_purord = poh_purord
left join SCORDDTL (nolock) on sod_cocde = pod_cocde and sod_ordno = pod_scno and sod_ordseq = pod_scline
left join SCORDHDR (nolock) on sod_ordno = soh_ordno
left join CUBASINF (nolock) on cbi_cusno = soh_cus1no
--left join SYSETINF (nolock) on ysi_typ = '23' and ysi_cde = poh_venno
where 
--((@status = 'L' and sfd_latest = 'Y') or @status = 'A') 
--and sfd_jobord <> '' and sfd_itmno <> '' 
--and sfd_credat  between @fromcredat + ' 00:00:00'  and  @tocredat + ' 23:59:59'
sfd_latest = 'Y'
and sfd_apprvflg in ('X', 'C', 'T') and isnull(sfd_zflgapprcv,'') in ('X', 'C', 'T') and isnull(sfd_zapprwtcv,'') <> ''
--and sfd_credat > '2009-03-25 16:00:00'
and sfd_jobord <> ''
--and ((pod_shpstr > '2008-12-31') or (pod_shpstr <= '2008-12-31' and sod_ordqty - sod_shpqty > 0))
and
soh_ordsts <> 'CLO' and soh_ordsts <> 'HLD' and soh_ordsts <> 'CAN'
and sod_shpqty = 0
order by sod_cocde, pod_jobord


update #TEMP_RESULT set tmp_CVdiff = 'Y' where tmp_ftyCV <> tmp_ConvHKCV
update #TEMP_RESULT set tmp_PVdiff = 'Y' where tmp_ftyPV <> tmp_HKPV
update #TEMP_RESULT set tmp_ftyprc03diff = 'Y' where tmp_fty03Curr <> tmp_HKDVftyprcCurr or tmp_fty03prc <> tmp_HKDVftyprc
update #TEMP_RESULT set tmp_ftyprc01diff = 'Y' where tmp_fty01Curr <> tmp_HKPVftyprcCurr or tmp_fty01prc <> tmp_HKPVftyprc
update #TEMP_RESULT set tmp_Pckdiff = 'Y' where tmp_ftyuntcde <> tmp_HKuntcde or tmp_ftyinrqty <> tmp_HKinrqty or tmp_ftymtrqty <> tmp_HKmtrqty
update #TEMP_RESULT set tmp_SAPSOdiff = 'Y' where tmp_ftySAPSONo <> tmp_HKSAPSONo or tmp_ftySAPSOLine <> tmp_HKSAPSOLine

update #TEMP_RESULT set tmp_ftyCV = tmp_ftyCV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_ftyCV = vbi_venno
update #TEMP_RESULT set tmp_ConvHKCV = tmp_ConvHKCV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_ConvHKCV = vbi_venno
update #TEMP_RESULT set tmp_HKCV = tmp_HKCV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_HKCV = vbi_venno
update #TEMP_RESULT set tmp_ftyPV = tmp_ftyPV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_ftyPV = vbi_venno
update #TEMP_RESULT set tmp_HKPV = tmp_HKPV + ' - ' + vbi_vensna from #TEMP_RESULT, VNBASINF where tmp_HKPV = vbi_venno


-- Added for handling no fty01prc, set fty01curr = fty03curr
update #TEMP_RESULT set tmp_fty01Curr = tmp_HKPVftyprcCurr, tmp_fty01prc = tmp_HKPVftyprc where tmp_fty01prc = 0



declare @currdt as datetime
set @currdt = getdate()

create table #tmp_Exp_A
(
tmp_cocde nvarchar(6),
tmp_lotno nvarchar(255),
tmp_filename nvarchar(255),
tmp_jobord nvarchar(20),
tmp_exptyp nvarchar(6),
tmp_apprv nvarchar(1),
tmp_creusr nvarchar(30),
tmp_credat datetime,
tmp_updusr nvarchar(30),
tmp_upddat datetime

)

-- EXP. 01 ZI01 prc > ZI03 prc
insert into #tmp_Exp_A
select distinct
tmp_cocde,@lotno,tmp_filename ,tmp_jobord,'01','N','SAPUSER',@currdt,'SAPUSER',@currdt
from 
#TEMP_RESULT
where round(tmp_fty01prc*0.955,2) > round(tmp_fty03prc,2) and tmp_fty01prc <> 0  

-- round 2 due to SAP with 2dp only
union
/*
-- EXP. 02 Same Item with packing having different ZI01 prc
select distinct
a.tmp_cocde,@lotno,a.tmp_filename ,a.tmp_jobord,'02','N','SAPUSER',@currdt,'SAPUSER',@currdt
from #TEMP_RESULT as a 
inner join #TEMP_RESULT as b on a.tmp_cusno = b.tmp_cusno and a.tmp_itmno = b.tmp_itmno and a.tmp_hkuntcde = b.tmp_hkuntcde
and a.tmp_hkinrqty = b.tmp_hkinrqty and a.tmp_hkmtrqty = b.tmp_hkmtrqty
and a.tmp_FTYCV = b.tmp_FTYCV and b. tmp_ftyPV = a.tmp_ftyPV and a.tmp_HKDVftyprc = b.tmp_HKDVftyprc 
where a.tmp_fty01prc <> b.tmp_fty01prc and  b.tmp_fty01prc <> 0 and  a.tmp_fty01prc <> 0

and
(
( substring(a.tmp_FTYCV ,1,1) = substring(a.tmp_ConvHKCV ,1,1)) and  (substring(b.tmp_FTYCV ,1,1)  = substring( b.tmp_ConvHKCV,1,1)  ) 

)
and
(
(substring(a. tmp_ftyPV,1,1) <> substring(a.tmp_HKPV,1,1) ) or (substring(b.tmp_ftyPV,1,1) <> substring(b.tmp_HKPV,1,1) )
)

and
( a.tmp_HKDVftyprc =  a.tmp_fty03prc  and  b.tmp_HKDVftyprc =  b.tmp_fty03prc ) 
*/

--union
/*
-- Same Item with packing, same ZI01 prc, having different CV
--insert into SCFDBEXP(sbe_cocde,sbe_lotno,sbe_filename,sbe_jobord,sbe_exptyp,sbe_apprv,sbe_creusr,sbe_credat,sbe_updusr,sbe_upddat)
select distinct
a.tmp_cocde,@lotno,a.tmp_filename ,a.tmp_jobord,'03','N','SAPUSER',@currdt,'SAPUSER',@currdt
from #TEMP_RESULT as a 
inner join #TEMP_RESULT as b on a.tmp_cusno = b.tmp_cusno and a.tmp_itmno = b.tmp_itmno and a.tmp_hkuntcde = b.tmp_hkuntcde
and a.tmp_hkinrqty = b.tmp_hkinrqty and a.tmp_hkmtrqty = b.tmp_hkmtrqty

where a.tmp_fty01prc = b.tmp_fty01prc and  b.tmp_fty01prc <> 0 and  a.tmp_fty01prc <> 0
and
(
( substring(a.tmp_FTYCV ,1,4) <> substring(a.tmp_ConvHKCV ,1,4)) or  (substring(b.tmp_FTYCV ,1,4) <> substring( b.tmp_ConvHKCV,1,4)  )
)
and
(
(substring(a. tmp_ftyPV,1,4) = substring(a.tmp_HKPV,1,4) ) and (substring(b. tmp_ftyPV,1,4) = substring(b.tmp_HKPV,1,4) )
)


union

-- Same Item with packing, same ZI01 prc, having different PV
--insert into SCFDBEXP(sbe_cocde,sbe_lotno,sbe_filename,sbe_jobord,sbe_exptyp,sbe_apprv,sbe_creusr,sbe_credat,sbe_updusr,sbe_upddat)
select distinct
a.tmp_cocde,@lotno,a.tmp_filename ,a.tmp_jobord,'04','N','SAPUSER',@currdt,'SAPUSER',@currdt
from #TEMP_RESULT as a 
inner join #TEMP_RESULT as b on a.tmp_cusno = b.tmp_cusno and a.tmp_itmno = b.tmp_itmno and a.tmp_hkuntcde = b.tmp_hkuntcde
and a.tmp_hkinrqty = b.tmp_hkinrqty and a.tmp_hkmtrqty = b.tmp_hkmtrqty
where a.tmp_fty01prc = b.tmp_fty01prc and  b.tmp_fty01prc <> 0 and  a.tmp_fty01prc <> 0
and
(
(substring(a. tmp_ftyPV,1,4) <> substring(a.tmp_HKPV,1,4) ) or (substring(b. tmp_ftyPV,1,4) <> substring(b.tmp_HKPV,1,4) )
)
and
(
( substring(a.tmp_FTYCV ,1,4) = substring(a.tmp_ConvHKCV ,1,4)) and  (substring(b.tmp_FTYCV ,1,4)  = substring( b.tmp_ConvHKCV,1,4)  )
)

union
*/

/*
-- EXP. 03 Same Item with packing, same ZI01 prc, having different both CV and PV
select distinct
a.tmp_cocde,@lotno,a.tmp_filename ,a.tmp_jobord,'03','N','SAPUSER',@currdt,'SAPUSER',@currdt
from #TEMP_RESULT as a 
inner join #TEMP_RESULT as b on a.tmp_cusno = b.tmp_cusno and a.tmp_itmno = b.tmp_itmno and a.tmp_hkuntcde = b.tmp_hkuntcde
and a.tmp_hkinrqty = b.tmp_hkinrqty and a.tmp_hkmtrqty = b.tmp_hkmtrqty
where 
a.tmp_fty01prc = b.tmp_fty01prc and  b.tmp_fty01prc <> 0 and  a.tmp_fty01prc <> 0
and
(
	(
	(substring(a. tmp_ftyPV,1,1) <> substring(a.tmp_HKPV,1,1) ) or (substring(b. tmp_ftyPV,1,1) <> substring(b.tmp_HKPV,1,1) )
	)
or
	(
	( substring(a.tmp_FTYCV ,1,4) <> substring(a.tmp_ConvHKCV ,1,4)) or  (substring(b.tmp_FTYCV ,1,4) <> substring( b.tmp_ConvHKCV,1,4)  )
	)
)

union
*/
/*
-- EXP. 04 Different CV, but ftycv is 3041, system cannot determine the vendor code (A, B, U)
select distinct
tmp_cocde,@lotno,tmp_filename ,tmp_jobord,'04','N','SAPUSER',@currdt,'SAPUSER',@currdt
from 
#TEMP_RESULT
where
( substring(tmp_FTYCV,1,4) <> substring(tmp_ConvHKCV,1,4) and substring(tmp_FTYCV,1,4) = '3041' ) 

union
*/

-- EXP. 05 SC not in REL Status
select distinct
tmp_cocde,@lotno,tmp_filename ,tmp_jobord,'05','N','SAPUSER',@currdt,'SAPUSER',@currdt
from 
#TEMP_RESULT
where
tmp_ordsts <> 'REL'

union

-- EXP. 06 FTY PV Curr <> HK DV Curr
select distinct
tmp_cocde,@lotno,tmp_filename ,tmp_jobord,'06','N','SAPUSER',@currdt,'SAPUSER',@currdt
from 
#TEMP_RESULT
where
tmp_fty01Curr <> tmp_fty03Curr  and tmp_fty01prc <> 0  

--union
--MC 20131008
/*
-- EXP. 07 FTY PV Prc = 0
select distinct
tmp_cocde,@lotno,tmp_filename ,tmp_jobord,'07','N','SAPUSER',@currdt,'SAPUSER',@currdt
from 
#TEMP_RESULT
where
tmp_fty01prc = 0 
*/

/*
union
-- EXP. 08 Different CV, but ftycv is 3051, system cannot determine the vendor code (C, D)
select distinct
tmp_cocde,@lotno,tmp_filename ,tmp_jobord,'08','N','SAPUSER',@currdt,'SAPUSER',@currdt
from 
#TEMP_RESULT
where
( substring(tmp_FTYCV,1,4) <> substring(tmp_ConvHKCV,1,4) and substring(tmp_FTYCV,1,4) = '3051' ) 

*/



-- Remove all exception
delete from SCFDBEXP


/*
-- Remove duplication exception
delete  SCFDBEXP from SCFDBEXP
inner join  #tmp_Exp_A on sbe_jobord = tmp_jobord-- and sbe_filename = tmp_filename and sbe_lotno = tmp_lotno 
where  sbe_apprv = 'N'

-- Exceptions have been already approved
delete  #tmp_Exp_A from #tmp_Exp_A
inner join  SCFDBEXPH on sbe_jobord = tmp_jobord and sbe_filename = tmp_filename --and sbe_lotno = tmp_lotno 
where sbe_apprv = 'Y'

*/
-- Already Executed before
delete  #TEMP_RESULT from #TEMP_RESULT
inner join  SCFDBhdr on sbh_jobord = tmp_jobord and sbh_filename = tmp_filename --and sbe_lotno = tmp_lotno 

-- Delete exception
delete  r from #TEMP_RESULT as r
inner join  #tmp_Exp_A as e on e.tmp_jobord = r.tmp_jobord and r.tmp_filename = e.tmp_filename 


insert into SCFDBEXP(sbe_cocde,sbe_lotno,sbe_filename,sbe_jobord,sbe_exptyp,sbe_apprv,sbe_creusr,sbe_credat,sbe_updusr,sbe_upddat)
select distinct
tmp_cocde,tmp_lotno,tmp_filename ,tmp_jobord,tmp_exptyp,tmp_apprv,tmp_creusr,tmp_credat,tmp_updusr,tmp_upddat
from  #tmp_Exp_A


-- Added by Mark Lau 20091009, delete CLO exception
delete SCFDBEXP from SCFDBEXP
inner join poorddtl (nolock) on sbe_jobord = pod_jobord
inner join scordhdr (nolock) on soh_ordno = pod_scno
where soh_ordsts = 'CLO'


if ( @IsDistinct = 'N' )
begin
	select  * from #TEMP_RESULT 
	where 
	(
	( tmp_fty01prc <> tmp_HKPVftyprc /*and tmp_fty01prc > 0*/ and tmp_fty01curr = tmp_HKPVftyprcCurr )
	or 
	( substring(tmp_FTYCV,1,1) <> substring(tmp_HKCV,1,1 )  /*and tmp_fty01prc > 0*/ and tmp_fty01curr =tmp_HKPVftyprcCurr) 
	or
	( substring(tmp_ftyPV,1,1) <> substring(tmp_HKPV,1,1)  /*and tmp_fty01prc > 0*/ and tmp_fty01curr = tmp_HKPVftyprcCurr)
	)

	order by tmp_scno asc
end
else
begin
	select   distinct  tmp_cocde, tmp_scno  from #TEMP_RESULT 
	where 
/*
	tmp_jobord like 'SC0902129%'  


and
*/
	(
	( tmp_fty01prc <> tmp_HKPVftyprc /*and tmp_fty01prc > 0*/ and tmp_fty01curr = tmp_HKPVftyprcCurr )
	or 
	( substring(tmp_FTYCV,1,1) <> substring(tmp_HKCV,1,1 )  /*and tmp_fty01prc > 0*/ and tmp_fty01curr = tmp_HKPVftyprcCurr) 
	or
	( substring(tmp_ftyPV,1,1) <> substring(tmp_HKPV,1,1)  /*and tmp_fty01prc > 0*/ and tmp_fty01curr = tmp_HKPVftyprcCurr)
	)

	order by tmp_scno asc 
end

drop table #tmp_Exp_A
drop table #TEMP_RESULT


GO
GRANT EXECUTE ON [dbo].[sp_select_scftydat_bat_GetData] TO [ERPUSER] AS [dbo]
GO
