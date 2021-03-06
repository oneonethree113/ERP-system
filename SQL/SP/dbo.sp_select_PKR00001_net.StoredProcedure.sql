/****** Object:  StoredProcedure [dbo].[sp_select_PKR00001_net]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKR00001_net]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKR00001_net]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

Create  procedure [dbo].[sp_select_PKR00001_net]
@cocde nvarchar(6) ,
@opthdr nvarchar(1),
@optitm nvarchar(1),
@optcub nvarchar(1),
@optgnw nvarchar(1),
@optjob nvarchar(1),
@optSKU nvarchar(1),
@optCTR	char(1),
@two	char(1),
@thr	char(1),
@fou	char(1),
@fiv	char(1),
@optUCP	char(1),
@from nvarchar(20),
@to nvarchar(20) ,         
@printGroup	nvarchar(1),
@printAlias	nvarchar(1)
AS
begin

DECLARE
@yco_conam	varchar(100),
@yco_addr		varchar(200),

@yco_phoneno	varchar(50),
@yco_faxno	varchar(50),
@yco_logoimgpth	varchar(100)

set @yco_conam = ''
set @yco_addr = ''

set @yco_phoneno = ''
set @yco_faxno = ''


set @yco_logoimgpth = ''

select
@yco_conam=yco_conam,
@yco_addr=yco_addr,

@yco_phoneno= yco_phoneno,
@yco_faxno = yco_faxno,
@yco_logoimgpth = yco_logoimgpth

from 

SYCOMINF(NOLOCK)

where
yco_cocde = @cocde
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

create table #temp_table_sum
(
tmp_seqno	int,
tmp_itmno	  nvarchar(20),
tmp_pdnum int,
tmp_sum	numeric(13,4),  --------cbm
tmp_sum_ctn	int,  
tmp_sum_qty	int,  
tmp_sum_nw	numeric(13,4),  
tmp_sum_gw	numeric(13,4),  
packing               nvarchar(300),
ctrcfs                    nvarchar(30),
invno                    nvarchar(30),
nwgw_meas                    nvarchar(50)

)

create table #temp_table_sum_packing
(
ctrcfs                    nvarchar(30),
tmp_itmno  nvarchar(20),
tmp_pdnum int,
packing               nvarchar(300),
tmp_sum	numeric(13,4),
tmp_sum_ctn	int,  
tmp_sum_qty	int,  
tmp_sum_nw	numeric(13,4),  
tmp_sum_gw	numeric(13,4),  
invno                    nvarchar(30),
nwgw_meas         nvarchar(50)
)
create table #temp_table_sum_container
(
ctrcfs                    nvarchar(30),
tmp_sum	numeric(13,4),
tmp_sum_ctn	int,  
tmp_sum_qty	int,  
tmp_sum_nw	numeric(13,4),  
tmp_sum_gw	numeric(13,4),  
invno                    nvarchar(30)
)
create table #temp_table_sum_invoice
(
tmp_sum	numeric(13,4),
tmp_sum_ctn	int,  
tmp_sum_qty	int,  
tmp_sum_nw	numeric(13,4),  
tmp_sum_gw	numeric(13,4),  
invno                    nvarchar(30)
)

insert into #temp_table_sum
select  distinct cast(dtl.hid_shpseq as nvarchar(20)) as 'dtl.hid_shpseq'  ,

case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm  else
	case when @printGroup = '1' then
		dbo.groupnewitmno(dtl.hid_itmno)
		else
		ltrim(rtrim(dtl.hid_itmno))
		end end as 'dtl.hid_itmno',
	pdm.hpd_pdnum   as 'tmp_pdnum', 
	round(hpd_cbm_cm*dtl.hid_ttlctn,4) , --cbm
	dtl.hid_ttlctn, --ctn
	case dtl.hid_contopc when 'Y' then dtl.hid_shpqty*dtl.hid_conftr else dtl.hid_shpqty end as 'dtl.hid_shpqty', --qty
	round(hpd_nw_kg*dtl.hid_ttlctn,4) , --wgt
	round(hpd_gw_kg*dtl.hid_ttlctn,4) , --wgt
	case when dtl.hid_contopc = 'Y' and isnull(dtl.hid_custum,'') <> '' then
	CASE ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN
		'                       ' + ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) +  ' ' + cde.ysi_dsc
	ELSE
		case len(cde.ysi_dsc) when 6 then
			ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc +'    ' + ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc
		else	
			ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc +'          ' +ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc
		end
	END

else

case  when dtl.hid_contopc  = 'Y' and isnull(dtl.hid_custum,'') = '' then
	CASE ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN
		'                       ' + ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' PC'
	ELSE
		ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' PC          ' +ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' PC'
	END

else
	CASE ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN
		'                       ' + ltrim( str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc
	ELSE
		case len(cde.ysi_dsc) when 6 then
			ltrim(str(dtl.hid_inrctn)) + ' ' + cde.ysi_dsc +'    ' + ltrim( str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc
		else	
			ltrim(str(dtl.hid_inrctn)) + ' ' + cde.ysi_dsc +'          ' +ltrim( str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc
		end
	END
END END as 'dtl.packing',
dtl.hid_ctrcfs as 'dtl.hid_ctrcfs',
inv.hiv_invno as 'inv.hiv_invno',
cast(cast(round(pdm.hpd_nw_kg,2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round(pdm.hpd_gw_kg,2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(ltrim(round(str(pdm.hpd_l_cm,10,2),2))  as numeric(11,2))   as nvarchar(10))  + cast(cast(ltrim(round(str(pdm.hpd_w_cm,10,2),2))  as numeric(11,2))   as nvarchar(10))  + cast(cast(ltrim(round(str(pdm.hpd_h_cm,10,2),2))  as numeric(11,2))   as nvarchar(10))    as 'nwgw_meas'


From 	SHIPGHDR hdr 
left join SYSETINF cty on hdr.hih_bilcty = cty.ysi_cde and cty.ysi_typ = '02'
, 
SHIPGDTL dtl
left join SHPCUSSTY ca on ca.ica_itmno = dtl.hid_itmno and ca.ica_apvsts = 'Y'  and ca.sod_ordno  =  dtl.hid_ordno and ca.sod_ordseq  =  dtl.hid_ordseq
,
SHINVHDR inv
left join SHSHPMRK shm on shm.hsm_cocde = inv.hiv_cocde and shm.hsm_invno = inv.hiv_invno and shm.hsm_shptyp = 'M'
, CUBASINF cus,  SCORDDTL sod, SYSETINF cde,  POORDDTL, 
shpckdim pdm,
	(select hid_cocde, hid_invno, hid_ctrcfs, hid_ttlcub = sum(hid_ttlcub) from v_select_pkr00001 group by hid_cocde, hid_invno, hid_ctrcfs) vw
WHERE 	
hdr.hih_cocde = inv.hiv_cocde and hdr.hih_shpno = inv.hiv_shpno
and	inv.hiv_cocde = dtl.hid_cocde and inv.hiv_shpno = dtl.hid_shpno and inv.hiv_invno = dtl.hid_invno
and 	hdr.hih_cus1no = cus.cbi_cusno
and	dtl.hid_cocde = pod_cocde and dtl.hid_purord = pod_purord and dtl.hid_purseq = pod_purseq
and 	case when isnull(dtl.hid_custum,'') <> '' then dtl.hid_custum else case when dtl.hid_contopc = 'Y' then 'PC' else dtl.hid_untcde end end  = cde.ysi_cde and cde.ysi_typ = '05'
and	dtl.hid_cocde = vw.hid_cocde and dtl.hid_invno = vw.hid_invno and dtl.hid_ctrcfs = vw.hid_ctrcfs
and	hdr.hih_cocde =  @cocde 
and 	sod.sod_cocde = hdr.hih_cocde and sod.sod_ordno = dtl.hid_ordno 
and 	sod.sod_ordseq = dtl.hid_ordseq
and pdm.hpd_shpno = dtl.hid_shpno and pdm.hpd_shpseq = dtl.hid_shpseq
and pdm.hpd_dimtyp = 'Mod'
and (
	(dtl.hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
	or (dtl.hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
	)
and inv.hiv_invno >= @from 
and inv.hiv_invno <= @to




insert into #temp_table_sum_packing
select ctrcfs,tmp_itmno,tmp_pdnum,packing,
round(sum(tmp_sum ),2),
sum(tmp_sum_ctn ),
sum(tmp_sum_qty ),
round(sum(tmp_sum_nw ),2),
round(sum(tmp_sum_gw ),2),
invno,nwgw_meas
from #temp_table_sum
group by invno,ctrcfs,tmp_itmno,tmp_pdnum,packing	,nwgw_meas

insert into #temp_table_sum_container
select ctrcfs,
round(sum(tmp_sum ),2),
sum(tmp_sum_ctn ),
sum(tmp_sum_qty ),
round(sum(tmp_sum_nw ),2),
round(sum(tmp_sum_gw ),2),
invno
from #temp_table_sum_packing
group by invno,ctrcfs



insert into #temp_table_sum_invoice
select 
round(sum(round(tmp_sum,2) ),2),
sum(tmp_sum_ctn),
sum(tmp_sum_qty),
round(sum(round(tmp_sum_nw,2) ),2),
round(sum(round(tmp_sum_gw,2) ),2),
invno
from #temp_table_sum_container
group by invno

--select * from #temp_table_sum
--select * from #temp_table_sum_packing
--select * from #temp_table_sum_container
--select * from #temp_table_sum_invoice


create table #main_temp
(
opthdr nvarchar(1) ,  
optitm nvarchar(1), 
optcub nvarchar(1), 
optgnw nvarchar(1), 
optSKU nvarchar(1), 
optCTR nvarchar(1), 
hdr__hih_shpno nvarchar(30), 
dtl__hid_shpseq int,    
hpd_pdnum int, 
hdr__hih_smpshp nvarchar(1), 
inv__hiv_invno nvarchar(30), 
inv__hiv_cover nvarchar(2900), 
cus__cbi_cusnam nvarchar(50), 
hdr__hih_bilent nvarchar(100), 
hdr__hih_biladr nvarchar(200),  
hdr__hih_bilstt nvarchar(20),  
cty__ysi_dsc nvarchar(200),  
hdr__hih_bilzip nvarchar(20), 
inv__hiv_paytrm nvarchar(20), 
inv__hiv_ftrrmk nvarchar(2900), 
inv__hiv_doctyp nvarchar(30), 
inv__hiv_doc nvarchar(200), 
inv__hiv_invdat datetime,     
hdr__hih_potloa_hih_dst nvarchar(200),     
hdr__hih_ves nvarchar(30), 
hdr__hih_voy nvarchar(30), 
hdr__hih_slnonb datetime,     
dtl__hid_pckrmk nvarchar(40), 
dtl__hid_ctrcfs nvarchar(30), 
dtl__hid_cuspo nvarchar(30), 
dtl__hid_ordno nvarchar(30), 
dtl__hid_itmshm nvarchar(300), 
dtl__hid_mannam nvarchar(300), 
dtl__hid_manadr nvarchar(300), 
dtl__hid_actvol Decimal(11, 4), 
dtl__hid_cusitm  nvarchar(30), 
dtl__hid_itmno nvarchar(30), 
dtl__hid_alsitmno nvarchar(30), 
sod__sod_itmdsc nvarchar(800),  
dtl__hid_itmdsc nvarchar(300),  
sod__sod_itmdsc2 nvarchar(300),  
dtl__hid_colcde  nvarchar(330), 
dtl__packing nvarchar(300), 
dtl__hid_grswgt dECIMAL(11, 4), 
dtl__hid_netwgt dECIMAL(11, 4), 
dtl__hid_mtrdcm dECIMAL(11, 4), 
dtl__hid_mtrwcm dECIMAL(11, 4), 
dtl__hid_mtrhcm dECIMAL(11, 4), 
dtl__hid_ttlctn int, 
dtl__hid_shpqty int, 
dtl__hid_shpqty_pc int, 
dtl__hid_untsel nvarchar(30), 
dtl__hid_selprc dECIMAL(11, 4), 
dtl__hid_ttlamt dECIMAL(11, 4), 
cocde nvarchar(30) ,
hid_ctnftr int
)



create table #main_temp2
(
hdr__hih_shpno nvarchar(30), 
dtl__hid_shpseq int, 
hpd_pdnum int,   
hdr__hih_cus1no nvarchar(30), 
sod__sod_typcode nvarchar(30), 
sod__sod_Code1 nvarchar(30), 
sod__sod_Code2 nvarchar(30), 
sod__sod_Code3 nvarchar(30), 
dtl__hid_ctrsiz nvarchar(30), 
hdr__hih_bilrmk nvarchar(2900), 
--vw__hid_ttlcub dECIMAL(11, 4), 
dtl__hid_inrctn int,  
dtl__hid_mtrctn int,  
dtl__hid_ttlgrs dECIMAL(11, 4), 
dtl__hid_sealno nvarchar(30), 
cde__ysi_dsc nvarchar(300),  
shm__hsm_imgpth nvarchar(300), 
shm__hsm_engdsc nvarchar(1600), 
dtl__hid_color nvarchar(330), 
dtl__hid_jobno nvarchar(30), 
optjob nvarchar(1), 
dtl__hid_ttlgw dECIMAL(11, 4), 
dtl__hid_ttlnw dECIMAL(11, 4), 
dtl__hid_ctnstr nvarchar(30), 
vw__hid_ttlcub dECIMAL(11, 4), 
sod_cussku nvarchar(30), 
shm__hsm_engdscM nvarchar(2900), 
yco_conam nvarchar(50), 
yco_addr nvarchar(300), 
yco_phoneno nvarchar(130),  
yco_faxno nvarchar(130), 
yco_logoimgpth nvarchar(300), 
logoimgpth nvarchar(130), 
aaprintAlias nvarchar(30), 
flg_hih_bilrmk nvarchar(30), 
DisplayItemNo   nvarchar(130), 
hid_resppo nvarchar(130), 
mod_cbm dECIMAL(11, 4), 
ttlctn_mod_cbm dECIMAL(11, 4), 
hih_ttlcbm dECIMAL(11, 4), 
each_grswgt dECIMAL(11, 4), 
each_netwgt dECIMAL(11, 4), 
opt2 nvarchar(1), 
opt3 nvarchar(1), 
opt4 nvarchar(1), 
opt5 nvarchar(1),
optUCP nvarchar(1)
--header_resppo nvarchar(100),
--header_custpo nvarchar(100),
--detail_cuitm nvarchar(100),
--detail_sku nvarchar(100)
)

insert into #main_temp
Select	
	@opthdr as 'opthdr',
	@optitm as 'optitm',
	@optcub as 'optcub',
	@optgnw as 'optgnw',
	@optSKU as 'optSKU',
	@optCTR as 'optCTR',
	hdr.hih_shpno as 'hdr.hih_shpno',
--	dtl.hid_shpseq as 'dtl.hid_shpseq',
  cast(dtl.hid_shpseq as nvarchar(20)) as'dtl.hid_shpseq',    
	pdm.hpd_pdnum as 'pdm.hpd_pdnum',
	hdr.hih_smpshp as 'hdr.hih_smpshp',
	inv.hiv_invno as 'inv.hiv_invno',
	inv.hiv_cover as 'inv.hiv_cover',
	cus.cbi_cusnam as 'cus.cbi_cusnam',

	hdr.hih_bilent as 'hdr.hih_bilent',
	hdr.hih_biladr as 'hdr.hih_biladr', 
	hdr.hih_bilstt as 'hdr.hih_bilstt', 
	cty.ysi_dsc as 'cty.ysi_dsc', 
	hdr.hih_bilzip as 'hdr.hih_bilzip',
	inv.hiv_paytrm as 'inv.hiv_paytrm',
	inv.hiv_ftrrmk as 'inv.hiv_ftrrmk',
	inv.hiv_doctyp as 'inv.hiv_doctyp',
	inv.hiv_doc as 'inv.hiv_doc',
CONVERT(VARCHAR(10),inv.hiv_invdat,101)   as'inv.hiv_invdat',    

  'PORT OF LOADING: ' + hdr.hih_potloa +char(13)+ 'DESTINATION: ' + hdr.hih_dst as 'hdr.hih_potloa_hih_dst',    
	hdr.hih_ves as 'hdr.hih_ves',
	hdr.hih_voy as 'hdr.hih_voy',
CONVERT(VARCHAR(10),hdr.hih_slnonb,101)   as'hdr.hih_slnonb',    

---	For Packing List, Group by Container #
	dtl.hid_pckrmk as 'dtl.hid_pckrmk',
	dtl.hid_ctrcfs as 'dtl.hid_ctrcfs',
---	Total of Cartons for Container

---	For Invoice, Group by Customer PO# and Sales Confirmation #
	dtl.hid_cuspo as 'dtl.hid_cuspo',
	
---	Customer PO Date
	dtl.hid_ordno as 'dtl.hid_ordno',
	
---	SC Revise Date


---	Details Shipmark
	Rtrim(Ltrim(dtl.hid_itmshm))  as 'dtl.hid_itmshm',
---	Carton Details

---	Manufacturers Name & Address
	dtl.hid_mannam as 'dtl.hid_mannam',
	dtl.hid_manadr as 'dtl.hid_manadr',
	dtl.hid_actvol as 'dtl.hid_actvol',

	Case isnull(dtl.hid_cusitm, '') when '' then 
case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm  else

	--dtl.hid_itmno
	--Added by Mark Lau 20060927
		--Added by Mark Lau 20080516, Add CDTVX

	case when @printGroup = '1' then


		-- Changed by Mark Lau 20090402, use function to perform the logic
		/*

		case when len(ltrim(rtrim(dtl.hid_itmno))) < 11 or charindex('-',ltrim(rtrim(dtl.hid_itmno))) > 0 or charindex('/',ltrim(rtrim(dtl.hid_itmno))) >0 or (Upper(substring(ltrim(rtrim(dtl.hid_itmno)),3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(ltrim(rtrim(dtl.hid_itmno)),7,2) = 'AS' then ltrim(rtrim(dtl.hid_itmno))
	
		else 
		case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'A'   or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'B' and (substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1) <= '9' ) And (substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) <= '9') then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)
				else 
				case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'B' and (upper(substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1)) >= 'A' And upper(substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1)) <= 'Z' ) And (substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) <= '9') then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)
					else ltrim(rtrim(dtl.hid_itmno))
				 end
			end
		end
		end
		*/
		dbo.groupnewitmno(dtl.hid_itmno)

		else
		ltrim(rtrim(dtl.hid_itmno))
		end


end
	else dtl.hid_cusitm  end   as 'dtl.hid_cusitm' ,
	--dtl.hid_itmno,


	--Added by Mark Lau 20060927
		--Added by Mark Lau 20080516, Add CDTVX
case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm  else
	case when @printGroup = '1' then

		-- Changed by Mark Lau 20090402, use function to perform the logic
		/*

		case when len(ltrim(rtrim(dtl.hid_itmno))) < 11 or charindex('-',ltrim(rtrim(dtl.hid_itmno))) > 0 or charindex('/',ltrim(rtrim(dtl.hid_itmno))) >0 or (Upper(substring(ltrim(rtrim(dtl.hid_itmno)),3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(ltrim(rtrim(dtl.hid_itmno)),7,2) = 'AS' then ltrim(rtrim(dtl.hid_itmno))
	
		else 
		case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'A'    or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'B' and (substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1) <= '9' ) And (substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) <= '9') then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)
				else 
				case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'B' and (upper(substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1)) >= 'A' And upper(substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1)) <= 'Z' ) And (substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) <= '9') then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)
					else ltrim(rtrim(dtl.hid_itmno))
				 end
			end
		end
		end
*/
		dbo.groupnewitmno(dtl.hid_itmno)
		else
		ltrim(rtrim(dtl.hid_itmno))
		end end as 'dtl.hid_itmno',
	
	case when @printAlias = '0' then '' else isnull(hid_alsitmno,'') end as 'dtl.hid_alsitmno',


--	dtl.hid_itmdsc,
	convert(nvarchar(100), isnull(sod.sod_itmdsc, ''))  as 'sod.sod_itmdsc', 
	convert(nvarchar(100), isnull(dtl.hid_itmdsc, ''))  as 'dtl.hid_itmdsc', 
	case  when dtl.hid_ctnftr = 2 then
		convert(nvarchar(10), isnull(substring(    Replace(Replace( sod.sod_itmdsc,char(10),''),char(13),'') , 101, 200), ''))  + char(13) + '(2 CTNS Per Item)' + '*' + convert(nvarchar(10), dtl.hid_ctnftr)
	else
		convert(nvarchar(10), isnull(substring(    Replace(Replace( sod.sod_itmdsc,char(10),''),char(13),'') , 101, 200), ''))  + '*' + convert(nvarchar(10), dtl.hid_ctnftr)
	end	
	as	'dtl.hid_itmdsc2',
--	as 'sod.sod_itmdsc2', 
--	dtl.hid_colcde,
--	Case ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) when ' ' then Case ltrim(pod_vencol) when 'N/A' then '' else ltrim(pod_vencol) end else ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) end,
	Case ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) when ' ' then Case ltrim(pod_vencol) when 'N/A' then 'N/A' else ltrim(pod_vencol) end else ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) end  as 'dtl.hid_colcde' ,

---	Assortment Details
---	Component Breakdown
	
---	Packing: change all to string and concat.
case when dtl.hid_contopc = 'Y' and isnull(dtl.hid_custum,'') <> '' then
	CASE ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN
		'                       ' + ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) +  ' ' + cde.ysi_dsc
	ELSE
		case len(cde.ysi_dsc) when 6 then
			ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc +'    ' + ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc
		else	
			ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc +'          ' +ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc
		end
	END

else

case  when dtl.hid_contopc  = 'Y' and isnull(dtl.hid_custum,'') = '' then
	CASE ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN
		'                       ' + ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' PC'
	ELSE
		ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' PC          ' +ltrim( str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' PC'
	END

else
	CASE ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN
		'                       ' + ltrim( str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc
	ELSE
		case len(cde.ysi_dsc) when 6 then
			ltrim(str(dtl.hid_inrctn)) + ' ' + cde.ysi_dsc +'    ' + ltrim( str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc
		else	
			ltrim(str(dtl.hid_inrctn)) + ' ' + cde.ysi_dsc +'          ' +ltrim( str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc
		end
	END
END END as 'dtl.packing',

--	dtl.hid_grswgt as 'dtl.hid_grswgt',
--	dtl.hid_netwgt as 'dtl.hid_netwgt',

	pdm.hpd_gw_kg as 'dtl.hid_grswgt',
	pdm.hpd_nw_kg as 'dtl.hid_netwgt',

---	Master Dim are concat.
--	ltrim(str(dtl.hid_mtrdcm,10,2)) as 'dtl.hid_mtrdcm',
--	ltrim(str(dtl.hid_mtrwcm,10,2)) as 'dtl.hid_mtrwcm',
--	ltrim(str(dtl.hid_mtrhcm,10,2)) as 'dtl.hid_mtrhcm',

	ltrim(str(pdm.hpd_l_cm,10,2)) as 'dtl.hid_mtrdcm',
	ltrim(str(pdm.hpd_w_cm,10,2)) as 'dtl.hid_mtrwcm',
	ltrim(str(pdm.hpd_h_cm,10,2)) as 'dtl.hid_mtrhcm',

---	Harmonized Code

	dtl.hid_ttlctn as 'dtl.hid_ttlctn',
	case dtl.hid_contopc when 'Y' then dtl.hid_shpqty*dtl.hid_conftr else dtl.hid_shpqty end as 'dtl.hid_shpqty',
	dtl.hid_shpqty*dtl.hid_conftr  as 'dtl.hid_shpqty_pc',

	dtl.hid_untsel as 'dtl.hid_untsel',
	case dtl.hid_contopc when 'Y' then dtl.hid_pcprc else dtl.hid_selprc end  as 'dtl.hid_selprc',
	dtl.hid_ttlamt as 'dtl.hid_ttlamt',
	@cocde as 'cocde',
	hid_ctnftr AS 'hid_ctnftr'


From 	
SHIPGHDR hdr 
left join SYSETINF cty on hdr.hih_bilcty = cty.ysi_cde and cty.ysi_typ = '02'
, 
SHIPGDTL dtl
left join SHPCUSSTY ca on ca.ica_itmno = dtl.hid_itmno and ca.ica_apvsts = 'Y'  and ca.sod_ordno  =  dtl.hid_ordno and ca.sod_ordseq  =  dtl.hid_ordseq
,
SHINVHDR inv
left join SHSHPMRK shm on shm.hsm_cocde = inv.hiv_cocde and shm.hsm_invno = inv.hiv_invno and shm.hsm_shptyp = 'M'
, 
CUBASINF cus, 
SCORDDTL sod, 
SYSETINF cde, 

POORDDTL, 
shpckdim pdm,
(select hid_cocde, hid_invno, hid_ctrcfs, hid_ttlcub = sum(hid_ttlcub) from v_select_pkr00001 group by hid_cocde, hid_invno, hid_ctrcfs) vw
WHERE 	
hdr.hih_cocde = inv.hiv_cocde and hdr.hih_shpno = inv.hiv_shpno
and	inv.hiv_cocde = dtl.hid_cocde and inv.hiv_shpno = dtl.hid_shpno and inv.hiv_invno = dtl.hid_invno
and 	hdr.hih_cus1no = cus.cbi_cusno
and	dtl.hid_cocde = pod_cocde and dtl.hid_purord = pod_purord and dtl.hid_purseq = pod_purseq
and 	case when isnull(dtl.hid_custum,'') <> '' then dtl.hid_custum else case when dtl.hid_contopc = 'Y' then 'PC' else dtl.hid_untcde end end  = cde.ysi_cde and cde.ysi_typ = '05'
and	dtl.hid_cocde = vw.hid_cocde and dtl.hid_invno = vw.hid_invno and dtl.hid_ctrcfs = vw.hid_ctrcfs
and	hdr.hih_cocde =  @cocde 
and 	sod.sod_cocde = hdr.hih_cocde and sod.sod_ordno = dtl.hid_ordno 
and 	sod.sod_ordseq = dtl.hid_ordseq
and pdm.hpd_shpno = dtl.hid_shpno and pdm.hpd_shpseq = dtl.hid_shpseq
and pdm.hpd_dimtyp = 'Mod'
and (
	(dtl.hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
	or (dtl.hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
	)

and inv.hiv_invno >= @from 
and inv.hiv_invno <= @to










insert into #main_temp2
Select	
	hdr.hih_shpno as 'hdr.hih_shpno',
  cast(dtl.hid_shpseq as nvarchar(20)) as'dtl.hid_shpseq',    
pdm.hpd_pdnum as 'pdm.hpd_pdnum',
	hdr.hih_cus1no as 'hdr.hih_cus1no',
	sod.sod_typcode as 'sod.sod_typcode',
	sod.sod_Code1 as 'sod.sod_Code1',
	sod.sod_Code2 as 'sod.sod_Code2',
	sod.sod_Code3 as 'sod.sod_Code3',
	dtl.hid_ctrsiz as 'dtl.hid_ctrsiz',
	
	
	inv.hiv_plrmk as 'hdr.hih_bilrmk',
	--inv.hiv_ftrrmk as 'hdr.hih_bilrmk',
	
--	round(dtl.hid_actvol * dtl.hid_ttlctn,2),
	--vw.hid_ttlcub as 'vw.hid_ttlcub',
	case dtl.hid_contopc when 'Y' then dtl.hid_inrctn*dtl.hid_conftr else dtl.hid_inrctn end as 'dtl.hid_inrctn', 
	case dtl.hid_contopc when 'Y' then dtl.hid_mtrctn*dtl.hid_conftr else dtl.hid_mtrctn end as 'dtl.hid_mtrctn', 
	dtl.hid_ttlctn * pdm.hpd_gw_kg as 'dtl.hid_ttlgrs',
	--dtl.hid_ttlgrs as 'dtl.hid_ttlgrs',
	dtl.hid_sealno as 'dtl.hid_sealno',
--Edited by Mark Lau 20080616
	case when isnull(dtl.hid_custum,'') <> '' then dtl.hid_custum else case dtl.hid_contopc when 'Y' then 'PC' else cde.ysi_dsc end end as 'cde.ysi_dsc', 
 	 shm.hsm_imgpth as 'shm.hsm_imgpth',
	left(ltrim(shm.hsm_engdsc),1) as 'shm.hsm_engdsc',
	Case ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) when ' ' then Case ltrim(pod_vencol) when 'N/A' then '' else ltrim(pod_vencol) end else ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) end as 'dtl.hid_color',
	/*
	--Added by Mark Lau 20060927
	case when @printGroup = '1' then
		case when len(ltrim(rtrim(dtl.hid_itmno)) ) < 11 or charindex('-',ltrim(rtrim(dtl.hid_itmno)) ) > 0 or charindex('/',ltrim(rtrim(dtl.hid_itmno)) ) >0 or (Upper(substring(ltrim(rtrim(dtl.hid_itmno)) ,3,1)) not in ('A','B','U')) or substring(ltrim(rtrim(d
tl.hid_itmno)) ,7,2) = 'AS' then ''
	
		else 
		case when upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 3, 1)) = 'A' then + '(' + substring(ltrim(rtrim(dtl.hid_itmno)) ,12, len(dtl.hid_itmno) - 11) +  ') ' --and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (s
ubstring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 3, 1)) = 'B' and (substring(ltrim(rtrim(dtl.hid_itmno)) , 4, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 4, 1) <= '9' ) And (substring(ltrim(rtrim(dtl.hid_itmno)) , 5, 1) >= '0' And subs
tring(ltrim(rtrim(dtl.hid_itmno)) , 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)) , 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 6, 1) <= '9') then  '(' +  substring(ltrim(rtrim(dtl.hid_itmno)) ,12,len(ltrim(rtrim(dtl.hid_itmno)) 
) - 11) + ') ' 
				else 
				case when upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 3, 1)) = 'B' and (upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 4, 1)) >= 'A' And upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 4, 1)) <= 'Z' ) And (substring(ltrim(rtrim(dtl.hid_itmno)) , 5, 1) 
>= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)) , 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 6, 1) <= '9') then  '(' + substring(ltrim(rtrim(dtl.hid_itmno)) ,12,len(ltrim(rtrim(dt
l.hid_itmno)) ) - 11) + ') ' 
					else ''
				 end
			end
		end
		end
		else
		''
		end +

	Case ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) when ' ' then Case ltrim(pod_vencol) when 'N/A' then 'N/A' else ltrim(pod_vencol) end else ltrim(dtl.hid_coldsc) + ' ' + ltrim(dtl.hid_cuscol) end,*/
	ltrim(dtl.hid_jobno) + '(' + ltrim(dtl.hid_venno) + ')' as  'dtl.hid_jobno',
	@optjob as 'optjob',
	dtl.hid_ttlctn * dtl.hid_grswgt as 'dtl.hid_ttlgw',
	dtl.hid_ttlctn * dtl.hid_netwgt as 'dtl.hid_ttlnw',
	dtl.hid_ctnstr as 'dtl.hid_ctnstr',
	vw.hid_ttlcub as 'vw.hid_ttlcub',






	isnull(sod.sod_cussku, '') as 'sod_cussku',
	shm.hsm_engdsc as 'shm.hsm_engdscM',
---	Packing Remarks Details
---	To concat. all packing remarks of the invoice
	@yco_conam as 'yco_conam',
	@yco_addr as 'yco_addr',
	@yco_phoneno as 'yco_phoneno', 
	@yco_faxno as 'yco_faxno',
	@yco_logoimgpth as 'yco_logoimgpth',
	@yco_logoimgpth as 'logoimgpth',
	--	
	--Added by Mark Lau 20060929
	@printAlias as '@printAlias',
	--Added by Mark Lau 20070724
	case when len(hdr.hih_bilrmk)>0 then '' else 'H' end as 'flg_hih_bilrmk',



	Case isnull(dtl.hid_cusitm, '') when '' then 

case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm  +  char(13) + char(10) +  '(' + dtl.hid_itmno  +')'  else
	--dtl.hid_itmno
	--Added by Mark Lau 20060927
		--Added by Mark Lau 20080516, Add CDTVX

	case when @printGroup = '1' then

		-- Changed by Mark Lau 20090402, use function to perform the logic
		/*

		case when len(ltrim(rtrim(dtl.hid_itmno))) < 11 or charindex('-',ltrim(rtrim(dtl.hid_itmno))) > 0 or charindex('/',ltrim(rtrim(dtl.hid_itmno))) >0 or (Upper(substring(ltrim(rtrim(dtl.hid_itmno)),3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(ltrim(rtrim(dtl.hid_itmno)),7,2) = 'AS' then ltrim(rtrim(dtl.hid_itmno))
	
		else 
		case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'A'   or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'B' and (substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1) <= '9' ) And (substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) <= '9') then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)
				else 
				case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'B' and (upper(substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1)) >= 'A' And upper(substring(ltrim(rtrim(dtl.hid_itmno)), 4, 1)) <= 'Z' ) And (substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)), 6, 1) <= '9') then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)
					else ltrim(rtrim(dtl.hid_itmno))
				 end
			end
		end
		end

*/
		dbo.groupnewitmno(dtl.hid_itmno)
		else
		ltrim(rtrim(dtl.hid_itmno))
		end


end 
	else dtl.hid_cusitm  end as 'DisplayItemNo'  ,
hid_resppo as 'hid_resppo',
--hpd_ttlcbm_cm/hpd_ctn  as 'mod_cbm',
hpd_cbm_cm  as 'mod_cbm',
round(hpd_ttlcbm_cm,2)  as 'ttlctn_mod_cbm',
--round(dtl.hid_ttlctn*hpd_cbm_cm,2)  as 'ttlctn_mod_cbm',

hih_ttlcbm,
Round(dtl.hid_ttlctn * dtl.hid_grswgt,2) as 'each_grswgt',
Round(dtl.hid_ttlctn * dtl.hid_netwgt,2) as 'each_netwgt',
@two	as  'opt2',
@thr	as 'opt3',
@fou	as 'opt4',
@fiv	as 'opt5',
@optUCP as 'optUCP'

--rvl_header_resppo.hrt_rmkval as 'header_resppo',
--rvl_header_custpo.hrt_rmkval as 'header_custpo',
---rvl_detail_cuitm.hrt_rmkval as 'detail_cuitm',
--rvl_detail_cusku.hrt_rmkval as 'detail_sku'

From 	
SHIPGHDR hdr 
left join SYSETINF cty on hdr.hih_bilcty = cty.ysi_cde and cty.ysi_typ = '02'
, 
SHIPGDTL dtl
left join SHPCUSSTY ca on ca.ica_itmno = dtl.hid_itmno and ca.ica_apvsts = 'Y'  and ca.sod_ordno  =  dtl.hid_ordno and ca.sod_ordseq  =  dtl.hid_ordseq
,
SHINVHDR inv
left join SHSHPMRK shm on shm.hsm_cocde = inv.hiv_cocde and shm.hsm_invno = inv.hiv_invno and shm.hsm_shptyp = 'M'
, 
CUBASINF cus, 
SCORDDTL sod, 
SYSETINF cde, 
POORDDTL, 
shpckdim pdm,
(select hid_cocde, hid_invno, hid_ctrcfs, hid_ttlcub = sum(hid_ttlcub) from v_select_pkr00001 group by hid_cocde, hid_invno, hid_ctrcfs) vw
WHERE 	
hdr.hih_cocde = inv.hiv_cocde and hdr.hih_shpno = inv.hiv_shpno
and	inv.hiv_cocde = dtl.hid_cocde and inv.hiv_shpno = dtl.hid_shpno and inv.hiv_invno = dtl.hid_invno
and 	hdr.hih_cus1no = cus.cbi_cusno
and	dtl.hid_cocde = pod_cocde and dtl.hid_purord = pod_purord and dtl.hid_purseq = pod_purseq
and 	case when isnull(dtl.hid_custum,'') <> '' then dtl.hid_custum else case when dtl.hid_contopc = 'Y' then 'PC' else dtl.hid_untcde end end  = cde.ysi_cde and cde.ysi_typ = '05'
and	dtl.hid_cocde = vw.hid_cocde and dtl.hid_invno = vw.hid_invno and dtl.hid_ctrcfs = vw.hid_ctrcfs
and	hdr.hih_cocde =  @cocde 
and 	sod.sod_cocde = hdr.hih_cocde and sod.sod_ordno = dtl.hid_ordno 
and 	sod.sod_ordseq = dtl.hid_ordseq
and pdm.hpd_shpno = dtl.hid_shpno and pdm.hpd_shpseq = dtl.hid_shpseq
and pdm.hpd_dimtyp = 'Mod'
and (
	(dtl.hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
	or (dtl.hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
	)
and inv.hiv_invno >= @from 
and inv.hiv_invno <= @to



--select * from #main_temp
--select * from #main_temp2

/*
select * from  #main_temp

select * from  #main_temp2

select * From 	 #main_temp 
left join  #main_temp2
		on #main_temp.dtl__hid_shpseq = #main_temp2.dtl__hid_shpseq
*/
--20150325


Select	
	distinct
	opthdr as 'opthdr',
	optitm as 'optitm',
	optcub as 'optcub',
	optgnw as 'optgnw',
	optSKU as 'optSKU',
	optCTR as 'optCTR',
	#main_temp.hdr__hih_shpno as 'hdr.hih_shpno',
	  cast(#main_temp.dtl__hid_shpseq  as nvarchar(20)) as'dtl.hid_shpseq',    
	hdr__hih_smpshp as 'hdr.hih_smpshp',
	inv__hiv_invno as 'inv.hiv_invno',
	inv__hiv_cover as 'inv.hiv_cover',
	cus__cbi_cusnam as 'cus.cbi_cusnam',
	hdr__hih_bilent as 'hdr.hih_bilent',
	hdr__hih_biladr as 'hdr.hih_biladr', 
	hdr__hih_bilstt as 'hdr.hih_bilstt', 
	cty__ysi_dsc as 'cty.ysi_dsc', 
	hdr__hih_bilzip as 'hdr.hih_bilzip',
	inv__hiv_paytrm as 'inv.hiv_paytrm',
	inv__hiv_ftrrmk as 'inv.hiv_ftrrmk',
	inv__hiv_doctyp as 'inv.hiv_doctyp',
	inv__hiv_doc as 'inv.hiv_doc',
	CONVERT(VARCHAR(10),inv__hiv_invdat, 101)   as'inv.hiv_invdat',    
	hdr__hih_potloa_hih_dst  as 'hdr.hih_potloa_hih_dst',    
	hdr__hih_ves as 'hdr.hih_ves',
	hdr__hih_voy as 'hdr.hih_voy',
	CONVERT(VARCHAR(10),hdr__hih_slnonb,101)   as'hdr.hih_slnonb',    
	dtl__hid_pckrmk as 'dtl.hid_pckrmk',
	dtl__hid_ctrcfs as 'dtl.hid_ctrcfs',
	dtl__hid_cuspo as 'dtl.hid_cuspo',
	dtl__hid_ordno as 'dtl.hid_ordno',
	dtl__hid_itmshm as 'dtl.hid_itmshm',
	dtl__hid_mannam as 'dtl.hid_mannam',
	dtl__hid_manadr as 'dtl.hid_manadr',
	dtl__hid_actvol as 'dtl.hid_actvol',
	dtl__hid_cusitm  as 'dtl.hid_cusitm' ,
	dtl__hid_itmno as 'dtl.hid_itmno',
	dtl__hid_alsitmno as 'dtl.hid_alsitmno',
	sod__sod_itmdsc  as 'sod.sod_itmdsc', 
	dtl__hid_itmdsc as 'dtl.hid_itmdsc', 
	sod__sod_itmdsc2 as 'sod.sod_itmdsc2', 
	dtl__hid_colcde as 'dtl.hid_colcde' ,
	 dtl__packing as 'dtl.packing',
	dtl__hid_grswgt as 'dtl.hid_grswgt',
	dtl__hid_netwgt as 'dtl.hid_netwgt',
	dtl__hid_mtrdcm as 'dtl.hid_mtrdcm',
	dtl__hid_mtrwcm as 'dtl.hid_mtrwcm',
	dtl__hid_mtrhcm as 'dtl.hid_mtrhcm',
	dtl__hid_ttlctn as 'dtl.hid_ttlctn',
	dtl__hid_shpqty as 'dtl.hid_shpqty',
	dtl__hid_shpqty_pc as 'dtl.hid_shpqty_pc',
	dtl__hid_untsel as 'dtl.hid_untsel',
	dtl__hid_selprc  as 'dtl.hid_selprc',
	dtl__hid_ttlamt as 'dtl.hid_ttlamt',
	cocde as 'cocde',
	hdr__hih_cus1no as 'hdr.hih_cus1no',
	sod__sod_typcode as 'sod.sod_typcode',
	sod__sod_Code1 as 'sod.sod_Code1',
	sod__sod_Code2 as 'sod.sod_Code2',
	sod__sod_Code3 as 'sod.sod_Code3',
	dtl__hid_ctrsiz as 'dtl.hid_ctrsiz',
	hdr__hih_bilrmk as 'hdr.hih_bilrmk',
	--vw__hid_ttlcub as 'vw.hid_ttlcub',
	dtl__hid_inrctn as 'dtl.hid_inrctn', 
	dtl__hid_mtrctn as 'dtl.hid_mtrctn', 
	dtl__hid_ttlgrs as 'dtl.hid_ttlgrs',
	dtl__hid_sealno as 'dtl.hid_sealno',
	cde__ysi_dsc as 'cde.ysi_dsc', 
 	 shm__hsm_imgpth as 'shm.hsm_imgpth',
	shm__hsm_engdsc as 'shm.hsm_engdsc',
	case when len(dtl__hid_color) <= 16 	then
		dtl__hid_color
		else case when len(dtl__hid_color) <= 32 	then
		left(dtl__hid_color,16) + char(13) + right(dtl__hid_color,16-(32-len(dtl__hid_color)))	
		else  case when len(dtl__hid_color) > 32 	and len(dtl__hid_color) <=48  then
		left(dtl__hid_color,16) + char(13) + right(left(dtl__hid_color,32),16) + char(13) + right(left(dtl__hid_color,48),16-(42-len(dtl__hid_color)))
		else
		left(dtl__hid_color,16) + char(13) + right(left(dtl__hid_color,32),16) + char(13)  +  right(left(dtl__hid_color,48),16) 
		end  end end

	 as 'dtl.hid_color',
	dtl__hid_jobno as  'dtl.hid_jobno',
	optjob as 'optjob',
	dtl__hid_ttlgw as 'dtl.hid_ttlgw',
	dtl__hid_ttlnw as 'dtl.hid_ttlnw',
	dtl__hid_ctnstr as 'dtl.hid_ctnstr',
	vw__hid_ttlcub as 'vw.hid_ttlcub',
	sod_cussku as 'sod_cussku',
	shm__hsm_engdscM as 'shm.hsm_engdscM',
	yco_conam as 'yco_conam',
	yco_addr as 'yco_addr',
	yco_phoneno as 'yco_phoneno', 
	yco_faxno as 'yco_faxno',
	yco_logoimgpth as 'yco_logoimgpth',
	yco_logoimgpth as 'logoimgpth',
	aaprintAlias as '@printAlias',
	flg_hih_bilrmk as 'flg_hih_bilrmk',
	DisplayItemNo as 'DisplayItemNo'  ,
	hid_resppo as 'hid_resppo',
	mod_cbm  as 'mod_cbm',
	ttlctn_mod_cbm as 'ttlctn_mod_cbm',
	hih_ttlcbm as 'hih_ttlcbm',
	each_grswgt as 'each_grswgt',
	each_netwgt as 'each_netwgt',
	opt2	as  'opt2',
	opt3	as 'opt3',
	opt4	as 'opt4',
	opt5	as 'opt5',
	optUCP as 'optUCP',
	hid_ctnftr AS 'hid_ctnftr',
	#temp_table_sum_packing.tmp_sum as 'sum_p',
	#temp_table_sum_container.tmp_sum as 'sum_c',
	#temp_table_sum_invoice.tmp_sum as 'sum_i',
	#temp_table_sum_packing.tmp_sum_ctn as 'sum_ctn_p',
	#temp_table_sum_container.tmp_sum_ctn as 'sum_ctn_c',
	#temp_table_sum_invoice.tmp_sum_ctn as 'sum_ctn_i',
	#temp_table_sum_packing.tmp_sum_qty as 'sum_qty_p',
	#temp_table_sum_container.tmp_sum_qty as 'sum_qty_c',
	#temp_table_sum_invoice.tmp_sum_qty as 'sum_qty_i',
	#temp_table_sum_packing.tmp_sum_nw as 'sum_nw_p',
	#temp_table_sum_container.tmp_sum_nw as 'sum_nw_c',
	#temp_table_sum_invoice.tmp_sum_nw as 'sum_nw_i',
	#temp_table_sum_packing.tmp_sum_gw as 'sum_gw_p',
	#temp_table_sum_container.tmp_sum_gw as 'sum_gw_c',
	#temp_table_sum_invoice.tmp_sum_gw as 'sum_gw_i',
--	header_resppo as 'header_resppo',
--	header_custpo as 'header_custpo',
--	detail_cuitm as 'detail_cuitm',
--	detail_sku as 'detail_sku'
isnull(rvl_header_resppo.hrt_rmkval,'') as 'header_resppo',
isnull(rvl_header_custpo.hrt_rmkval,'') as 'header_custpo',
isnull(rvl_detail_cuitm.hrt_rmkval,'') as 'detail_cuitm',
isnull(rvl_detail_cusku.hrt_rmkval,'') as 'detail_sku',
isnull(rvl_hearder_itmno.hrt_rmkval,'') as 'header_itmno'
,
--shpckdim.hpd_pdnum as 'hpd_pdnum',
#temp_table_sum.tmp_sum as 'tmp_sum',
convert(int,shpckdim.hpd_pdnum) as 'hpd_pdnum'
,cast(cast(round([#main_temp].[dtl__hid_netwgt],2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round([#main_temp].[dtl__hid_grswgt],2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round([#main_temp].[dtl__hid_mtrdcm],2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round([#main_temp].[dtl__hid_mtrwcm],2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round([#main_temp].[dtl__hid_mtrhcm],2)  as numeric(11,2))   as nvarchar(10))   as 'tes'


From 	 #main_temp 
left join  #main_temp2
		on #main_temp.hdr__hih_shpno = #main_temp2.hdr__hih_shpno
		and #main_temp.dtl__hid_shpseq = #main_temp2.dtl__hid_shpseq
		and #main_temp.hpd_pdnum = #main_temp2.hpd_pdnum
 left   join shpckdim on #main_temp.hdr__hih_shpno = shpckdim.hpd_shpno
		and #main_temp.dtl__hid_shpseq = shpckdim.hpd_shpseq
		and #main_temp.hpd_pdnum = shpckdim.hpd_pdnum
		and shpckdim.hpd_dimtyp = 'Mod'
		and (
			(#main_temp.hid_ctnftr = 1 and ( shpckdim.hpd_pdnum = 5 or shpckdim.hpd_pdnum = 6 )) 
				or (#main_temp.hid_ctnftr = 2 and ( shpckdim.hpd_pdnum = 1 or shpckdim.hpd_pdnum = 2 or shpckdim.hpd_pdnum = 3 or shpckdim.hpd_pdnum = 4 ))   
			)


left join #temp_table_sum on
 		[#main_temp].[dtl__hid_shpseq] = #temp_table_sum.tmp_seqno
 	and	[#main_temp].[inv__hiv_invno] = #temp_table_sum.invno
	and       shpckdim.hpd_pdnum = #temp_table_sum.tmp_pdnum

left join #temp_table_sum_packing    on 
		 rtrim(ltrim([#main_temp].[dtl__hid_itmno])) =   rtrim(ltrim(#temp_table_sum_packing.tmp_itmno))
	and	 [#main_temp].[dtl__packing] =  #temp_table_sum_packing.packing
	and	[#main_temp].[dtl__hid_ctrcfs] = #temp_table_sum_packing.ctrcfs
 	and	[#main_temp].[inv__hiv_invno] = #temp_table_sum_packing.invno
	and       shpckdim.hpd_pdnum = #temp_table_sum_packing.tmp_pdnum
   and cast(cast(round([#main_temp].[dtl__hid_netwgt],2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round([#main_temp].[dtl__hid_grswgt],2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round([#main_temp].[dtl__hid_mtrdcm],2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round([#main_temp].[dtl__hid_mtrwcm],2)  as numeric(11,2))   as nvarchar(10))  + cast(cast(round([#main_temp].[dtl__hid_mtrhcm],2)  as numeric(11,2))   as nvarchar(10))    =  #temp_table_sum_packing.nwgw_meas



left join #temp_table_sum_container   on 
	 [#main_temp].dtl__hid_ctrcfs = #temp_table_sum_container.ctrcfs
 	and	[#main_temp].[inv__hiv_invno] = #temp_table_sum_container.invno
left join #temp_table_sum_invoice
 	on	[#main_temp].[inv__hiv_invno] = #temp_table_sum_invoice.invno
left join SHRMKVAL rvl_header_resppo
		on rvl_header_resppo.hrt_pricustno = #main_temp2.hdr__hih_cus1no
		and rvl_header_resppo.hrt_rmkdsc= 'Header Respective PO #'
left join SHRMKVAL rvl_header_custpo
		on rvl_header_custpo.hrt_pricustno = #main_temp2.hdr__hih_cus1no
		and rvl_header_custpo.hrt_rmkdsc= 'Header Customer PO#'
left join SHRMKVAL rvl_detail_cuitm
		on rvl_detail_cuitm.hrt_pricustno = #main_temp2.hdr__hih_cus1no
		and rvl_detail_cuitm.hrt_rmkdsc= 'Detail Customer Item Number'
left join SHRMKVAL rvl_detail_cusku
		on rvl_detail_cusku.hrt_pricustno = #main_temp2.hdr__hih_cus1no
		and rvl_detail_cusku.hrt_rmkdsc= 'Detail Cust SKU#'
left join SHRMKVAL rvl_hearder_itmno
		on rvl_hearder_itmno.hrt_pricustno = #main_temp2.hdr__hih_cus1no
		and rvl_hearder_itmno.hrt_rmkdsc= 'Hearder Item Number'

--where shpckdim.hpd_pdnum <> NULL

drop table #temp_table_sum
drop table #temp_table_sum_packing
drop table #temp_table_sum_container
drop table #temp_table_sum_invoice

end


GO
GRANT EXECUTE ON [dbo].[sp_select_PKR00001_net] TO [ERPUSER] AS [dbo]
GO
