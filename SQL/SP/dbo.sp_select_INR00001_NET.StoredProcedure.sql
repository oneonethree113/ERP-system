/****** Object:  StoredProcedure [dbo].[sp_select_INR00001_NET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00001_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00001_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE                    procedure [dbo].[sp_select_INR00001_NET] 
@cocde nvarchar(6) ,    
@opt1 nvarchar(1),    
@opt2 nvarchar(1),    
@opt3 nvarchar(1),    
@laf    nvarchar(1),    
@opt4 nvarchar(1),    
@opt5 nvarchar(1),    
@opt6 nvarchar(1),    
@from nvarchar(20),    
@to nvarchar(20),   
@optTitle char(1)  ,   
@optSort varchar(6) = 'ITM',  
@printGroup nvarchar(1),  
@PrintAlias nvarchar(1) ,
@printAss  nvarchar(1) ,---  ???? -- Frankie Cheung 20091019
@printCRD  nvarchar(1) ,
@printRTL  nvarchar(1) ,
@printCOO  nvarchar(1) ,
@printFRM  nvarchar(1) ,
@optUCP  nvarchar(1) ,
@usrgrp nvarchar(6) 
AS    
begin    

DECLARE    
@yco_conam varchar(100),    
@yco_addr  varchar(200),    

@yco_phoneno varchar(50),    
@yco_faxno varchar(50),    
@yco_logoimgpth varchar(100)    

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
from SYCOMINF(NOLOCK) where yco_cocde = @cocde    

create table #temp_cmp
(
	tmp_shpno  nvarchar(20),
	tmp_shpseq int,
	tmp_cmp      nvarchar(4000),
)
-- For cursor use
declare
@chk_shpno  nvarchar(20),
@chk_shpseq int,
@cmp_str  nvarchar(4000)
declare
@chk_cpt  nvarchar(500),
@chk_pct numeric(8,2)


declare c_1 CURSOR FOR
select dtl.hid_shpno,dtl.hid_shpseq
from  shipgdtl dtl 
left join shinvhdr  sih
	on dtl.hid_shpno = sih.hiv_shpno
where 	sih.hiv_invno >= @from	
	and sih.hiv_invno <= @to	

Open c_1
FETCH NEXT FROM c_1 INTO @chk_shpno  ,@chk_shpseq
WHILE @@FETCH_STATUS = 0
BEGIN
   set @cmp_str =''

   Declare c_2 CURSOR FOR
   select 
	scb.shb_cpt,scb.shb_pct
	from SHCPTBKD scb (nolock) 
	where 	scb.shb_ordno = @chk_shpno
		and  scb.shb_ordseq = @chk_shpseq
		order by scb.shb_cptseq
   OPEN c_2
   FETCH NEXT FROM c_2 INTO @chk_cpt,@chk_pct
   WHILE @@FETCH_STATUS = 0
   BEGIN
	set @cmp_str = @cmp_str +rtrim(ltrim(Replace(Replace(@chk_cpt,char(10),''),char(13),'')))+ ' ' +convert(nvarchar(9),@chk_pct ) +'%  '
         FETCH NEXT FROM c_2 INTO @chk_cpt,@chk_pct
   END
   CLOSE c_2
   DEALLOCATE c_2

      insert into  #temp_cmp
      select @chk_shpno  ,@chk_shpseq, @cmp_str

FETCH NEXT FROM c_1 INTO @chk_shpno  ,@chk_shpseq
END
CLOSE c_1
DEALLOCATE c_1		  




---------------------------
create table #temp_po
(
	tmp_shpno  nvarchar(20),
	tmp_mannam nvarchar(400),
	tmp_po      nvarchar(4000)
)
-- For cursor use
declare
@po_str  nvarchar(4000)
declare
@chk_mannam  nvarchar(400)
declare
@hid_cuspo nvarchar(40)


declare c_po_1 CURSOR FOR
select distinct dtl.hid_shpno,dtl.hid_mannam
from  shipgdtl dtl 
left join shinvhdr  sih
	on dtl.hid_shpno = sih.hiv_shpno
where 	sih.hiv_invno >= @from	
	and sih.hiv_invno <= @to	

Open c_po_1
FETCH NEXT FROM c_po_1 INTO @chk_shpno  ,@chk_mannam
WHILE @@FETCH_STATUS = 0
BEGIN
   set @po_str =''

   Declare c_po_2 CURSOR FOR
   select 
	dtl.hid_cuspo
	from SHIPGDTL dtl (nolock) 
	where 	dtl.hid_shpno = @chk_shpno
		and  dtl.hid_mannam = @chk_mannam
   OPEN c_po_2
   FETCH NEXT FROM c_po_2 INTO @hid_cuspo
   WHILE @@FETCH_STATUS = 0
   BEGIN
		if charindex(@hid_cuspo,@po_str) = 0 
		begin
		set @po_str = @po_str +@hid_cuspo + ', '
         end
		  FETCH NEXT FROM c_po_2 INTO @hid_cuspo
   END
   CLOSE c_po_2
   DEALLOCATE c_po_2

      insert into  #temp_po
      select @chk_shpno  ,@chk_mannam, @po_str

FETCH NEXT FROM c_po_1 INTO @chk_shpno  ,@chk_mannam
END
CLOSE c_po_1
DEALLOCATE c_po_1

---------------------------





-----------------------------------------------------
		set @opt5 = ''  -- def

if 
	(select count(ipi_pckunt) from IMPCKINF where ipi_itmno in
					(select hid_itmno from shipgdtl where 
						hid_invno <= @to
					and hid_invno >= @from)) =1 
         and 	
	(select distinct top (1)  ipi_pckunt from IMPCKINF where ipi_itmno in
					(select hid_itmno from shipgdtl where 
						hid_invno <= @to
					and hid_invno >= @from) ) ='ST' 
	 
	
	begin
		set @opt5 = 'Y'
	end



if 
	(select count(ipi_pckunt) from IMPCKINF where ipi_itmno in
					(select hid_itmno from shipgdtl where 
						hid_invno <= @to
					and hid_invno >= @from)) =1 
         and 	
	(select distinct top (1)  ipi_pckunt from IMPCKINF where ipi_itmno in
					(select hid_itmno from shipgdtl where 
						hid_invno <= @to
					and hid_invno >= @from) ) ='PC' 
	 
	
	begin
		set @opt5 = 'N'
	end

-----------------------------------------------------

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

create table #temp_table_sum_cussku
(
ctrcfs                    nvarchar(30),
tmp_itmno  nvarchar(20),
tmp_sum	numeric(13,4),
tmp_sum_ctn	int,  
tmp_sum_qty	int,  
tmp_sum_nw	numeric(13,4),  
tmp_sum_gw	numeric(13,4),  
invno                    nvarchar(30)

)



insert into #temp_table_sum
select  distinct cast(dtl.hid_shpseq as nvarchar(20)) as 'dtl.hid_shpseq'  ,
		ltrim(rtrim(dtl.hid_itmno))
		 as 'dtl.hid_itmno',

-- sod.sod_cussku as 'sod.sod_cussku',
	pdm.hpd_pdnum   as 'tmp_pdnum', 
	round(hpd_cbm_cm*dtl.hid_ttlctn,4) , --cbm
	dtl.hid_ttlctn, --ctn
	dtl.hid_shpqty, --qty
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




insert into #temp_table_sum_cussku
select ctrcfs,tmp_itmno,
round(sum(tmp_sum ),3),
sum(tmp_sum_ctn ),
sum(tmp_sum_qty ),
round(sum(tmp_sum_nw ),3),
round(sum(tmp_sum_gw ),3),
invno
from #temp_table_sum
group by invno,ctrcfs,tmp_itmno





  
if @optSort = 'ITM'   
Begin
  Select     
  @opt1  as 'opt1',        
  @opt2  as 'opt2',        
  @opt3  as 'opt3',        
case   when dtl.hid_itmtyp = 'REG' then 'N'  else  'Y' end  as 'opt4',
case   when dtl.hid_conftr >1 then 'Y'  else  'N' end  as 'opt5',

 -- @opt4  as 'opt4',        
--  @opt5  as 'opt5',        
  @opt6  as 'opt6',        
  @laf  as 'laf',        
  case when hiv_aformat = '2' then 'C' else case when hiv_aformat = '1' then 'A' else 'C' end end as 'hiv_aformat',    
  hdr.hih_shpno as'hdr.hih_shpno',    
  cast(dtl.hid_shpseq as nvarchar(20)) as'dtl.hid_shpseq',    
  hdr.hih_smpshp as'hdr.hih_smpshp',
  inv.hiv_invno as 'inv.hiv_invno',    
  ltrim(inv.hiv_cover) as 'inv.hiv_cover',    
  ltrim(cus.cbi_cusnam) as 'cus.cbi_cusnam',    
  ltrim(hdr.hih_bilent) as 'hdr.hih_bilent',    
  ltrim(hdr.hih_biladr) as 'hdr.hih_biladr',     
  ltrim(hdr.hih_bilstt) as 'hdr.hih_bilstt',     
  ltrim(cty.ysi_dsc) as 'cty.ysi_dsc',     
  ltrim(hdr.hih_bilzip) as 'hdr.hih_bilzip',    
  ltrim(pay.ysi_dsc) as 'inv.hiv_paytrm',    
  ltrim(inv.hiv_ftrrmk) as 'inv.hiv_ftrrmk',        
  ltrim(inv.hiv_doctyp) as 'inv.hiv_doctyp',      
  ltrim(inv.hiv_doc) as 'inv.hiv_doc',     
  CONVERT(VARCHAR(10),inv.hiv_invdat,101)   as'inv.hiv_invdat',    
  'PORT OF LOADING: ' + hdr.hih_potloa +char(13)+ 'DESTINATION: ' + hdr.hih_dst as 'hdr.hih_potloa_hih_dst',    
  hdr.hih_ves as'hdr.hih_ves',    
  hdr.hih_voy as'hdr.hih_voy',    
  CONVERT(VARCHAR(10),hdr.hih_slnonb,101)   as'hdr.hih_slnonb',    
  ltrim(dtl.hid_pckrmk) as 'dtl.hid_pckrmk',    
  dtl.hid_ctrcfs as 'dtl.hid_ctrcfs',    
  ltrim(dtl.hid_cuspo) as 'dtl.hid_cuspo',    
  soh.soh_cpodat as 'poh.poh_issdat',    
  dtl.hid_ordno as 'dtl.hid_ordno',    
  soh.soh_issdat as 'soh.soh_issdat',    
  ltrim(dtl.hid_itmshm) as 'dtl.hid_itmshm',    
  ltrim(dtl.hid_mannam) + '' as 'dtl.hid_mannam', 
  
  CASE when cde.ysi_dsc  = 'ST' THEN
	CASE when isnull(dtl.hid_contopc,'') =  'Y' and isnull(dtl.hid_custum,'') = '' THEN
		 ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr))
	ELSE     
		 ltrim(str(dtl.hid_mtrctn))  
	END 
ELSE 
		ltrim(str(dtl.hid_mtrctn))
END As 'dtl.hid_mtrctn_result',   --Michael 20170413
     
   case   when ltrim(dtl.hid_manadr) = '' then '.'  else  dtl.hid_manadr end  as 'dtl.hid_manadr',
  case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm 
  else case when @printGroup = '1' then dbo.groupnewitmno(dtl.hid_itmno)
       else ltrim(rtrim(dtl.hid_itmno))
       end 
  end as 'dtl.hid_itmno',  
  case when @printAlias = '0' then '' 
  else isnull(hid_alsitmno,'') end as 'dtl.hid_alsitmno',  
  ltrim(rtrim(dtl.hid_itmdsc)) as 'dtl.hid_itmdsc',    
  CASE when isnull(dtl.hid_contopc,'') =  'Y' and isnull(dtl.hid_custum,'') <> '' THEN CASE ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr)) +  ' ' + cde.ysi_dsc + ' TO CTN.'    
  ELSE     
	 ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc +' TO BOX, '  + ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc + ' TO CTN.'  END
ELSE
CASE when isnull(dtl.hid_contopc,'') =  'Y' and isnull(dtl.hid_custum,'') = '' THEN
	 CASE  ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN     
	   ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' PC TO CTN.'    
	 ELSE     
	 ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' PC TO BOX, ' + ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' PC TO CTN.' END
ELSE
	 CASE  ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN     
	   ltrim(str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc +' TO CTN.'    
	 ELSE     
	 ltrim(str(dtl.hid_inrctn)) + ' ' + cde.ysi_dsc +' TO BOX, ' + ltrim(str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc +' TO CTN.' END
END
END as 'dtl.packing',
  ltrim(str(dtl.hid_grswgt,10,2)) + ' KGS' as 'dtl.hid_grswgt',    
  ltrim(str(dtl.hid_netwgt,10,2)) + ' KGS' as 'dtl.hid_netwgt',    
  ltrim(str(pdm.hpd_l_cm,10,2)) + ' X ' + ltrim(str( pdm.hpd_w_cm,10,2)) + ' X ' + ltrim(str(pdm.hpd_h_cm,10,2)) + ' CM' as 'dtl.meas',         
  str(dtl.hid_ttlctn) as 'dtl.hid_ttlctn',    
CASE isnull(dtl.hid_contopc,'') when 'Y' THEN
  str(cast(dtl.hid_shpqty*dtl.hid_conftr as int))
ELSE
  str(dtl.hid_shpqty)
END  as 'dtl.hid_shpqty',

  dtl.hid_untsel  as'dtl.hid_untsel',    
case isnull(dtl.hid_contopc,'') when 'Y' then
	str(round(dtl.hid_pcprc,4))
else
	str(round(dtl.hid_selprc,4))
end as 'dtl.hid_selprc',    
  str(round(dtl.hid_ttlamt,2),10,4) as 'dtl.hid_ttlamt',    
  shm.hsm_imgpth  as'shm.hsm_imgpth',
  left(ltrim(shm.hsm_engdsc),1) as 'shm.hsm_engdsc',    
  @cocde as 'cocde',    
  ltrim(dtl.hid_cmprmk) as 'dtl.hid_cmprmk',    
 case when @printGroup = '1'  then 
  dbo.groupnewitmno(sca.hai_assitm)
  else  
  sca.hai_assitm  
  end as 'sca.sai_assitm',  
  sca.hai_assdsc as 'sca.sai_assdsc',    
 sca.hai_coldsc as 'sca.sai_coldsc',    
  sca.hai_cussku as 'sca.sai_cussku',    
  sca.hai_upcean as 'sca.sai_upcean',    
  sca.hai_cusrtl as 'sca.sai_cusrtl',    
  ltrim(saa.ysi_dsc) as 'sca.sai_untcde',    
   cast( dtl.hid_ordseq as nvarchar(20))  as 'dtl.hid_ordseq',    
  sca.hai_cusitm as 'sca.sai_cusitm',    
  sca.hai_colcde as 'sca.sai_colcde',    
  sca.hai_cusstyno as 'sca.sai_cusstyno',    

  ltrim(str(sca.hai_inrqty,10,0)) as 'inner',    
  ltrim(str(sca.hai_mtrqty,10,0)) as 'master',    
  hdr.hih_cus1no as 'hdr.hih_cus1no',    
-- ltrim(cde.ysi_dsc) 
case when isnull(dtl.hid_custum,'') <> '' then dtl.hid_custum else case when isnull(dtl.hid_contopc,'') = 'Y' then 'PC' else ltrim(cde.ysi_dsc) end end as 'cde.ysi_dsc',    
  ltrim(dtl.hid_colcde) as 'dtl.hid_colcde',
 case when @printGroup = '1' then  
case when dbo.groupnewitmcol(dtl.hid_itmno,dtl.hid_colcde,'N') = '' then '' else '(' +  dbo.groupnewitmcol(dtl.hid_itmno,dtl.hid_colcde,'N') + ') ' end
  else
  ''  
  end  +  
  Case rtrim(ltrim(dtl.hid_coldsc)) + ' ' +rtrim(ltrim(dtl.hid_cuscol)) when ' ' then Case rtrim(ltrim(pod_vencol)) when 'N/A' then '' else rtrim(ltrim(pod_vencol)) end else rtrim(ltrim(dtl.hid_coldsc)) + ' ' +rtrim(ltrim(dtl.hid_cuscol)) end AS 'dtl.hid_coldsc' ,
  ltrim(sod.sod_hrmcde) as 'sod.sod_hrmcde',    
  ltrim(inv.hiv_bank) as 'hiv.hiv_bank',    
  ltrim(inv.hiv_ftrrmk) as 'hiv.hiv_ftrrmk',    
  ltrim( dtl.hid_cusitm) as 'dtl.hid_cusitm',
--  ltrim( dtl.hid_cusitm) as 'hid_cusitm',
  sod.sod_typcode as 'sod.sod_typcode', 
  LTRIM(sod.sod_Code1) + LTRIM(sod.sod_Code2) + LTRIM(sod.sod_Code3) AS 'sod.sod_code',    
 --- Additional Field : Duty Rate, Customer Retail & Dept #    
      
  CASE sod.sod_dtyrat when 0 then '' else ltrim(str(sod.sod_dtyrat,10,0)) end AS 'sod.sod_dtyrat',    
  CASE sod.sod_cususd when 0 then '' else ltrim(str(sod.sod_cususd,13,4)) end AS 'sod.sod_cususd',    
  CASE sod.sod_cuscad when 0 then '' else ltrim(str(sod.sod_cuscad,13,4)) end AS 'sod.sod_cuscad',    
  ltrim(sod.sod_dept) as 'sod.sod_dept',    
 -- dtl.hid_ctnstr,    
  ltrim(str(dtl.hid_ctnstr)) + ltrim(str(dtl.hid_ctnend)) as 'dtl.hid_ctnstr',    
case isnull(dtl.hid_contopc,'') when 'Y' then     
  str(round(dtl.hid_pcprc/1.05,2))
else
  str(round(dtl.hid_selprc/1.05,2))
end as 'dtl.hid_Aprc',    
dtl.hid_ctnftr*vw.hid_ttlctn as 'vw_ttlctn',  
  dtl.hid_ctnftr  as 'dtl.hid_ctnftr',
vw.hid_ttlctn as 'vw.hid_ttlctn',

	case isnull(dtl.hid_contopc,'') when 'Y' then
	 	 cast( vw.hid_shpqty*dtl.hid_conftr as int) 
	else
		vw.hid_shpqty
	end as 'vw_shpqty', 
  Case (case when hiv_aformat = '2' then 'C' else ( case when hiv_aformat = '1' then 'A' else 'C' end) end)    
   when 'A' then 
	case isnull(dtl.hid_contopc,'') when 'Y' then
		round(vw.hid_selprc/dtl.hid_conftr/1.05,4) 
	else
		round(vw.hid_selprc/1.05,4) 
	end
    else 
	case isnull(dtl.hid_contopc,'') when 'Y' then
		cast(round(vw.hid_selprc / dtl.hid_conftr,4) as decimal (18,4))
	else
		cast(vw.hid_selprc  as decimal (18,4))
	end
   end as vw_selprc,    
     
  Case case when hiv_aformat = '2' then 'C' else case when hiv_aformat = '1' then 'A' else 'C' end end    
   when 'A' then  vw.sumamtd else vw.sumamt end as vw_sumamt,    
     
  Case @opt4 when 'N' then '' else Case ltrim(dtl.hid_jobno) when '' then '' else  ltrim(dtl.hid_jobno) + '(' + ltrim(dtl.hid_venno) + ')' end end as 'dtl.hid_jobno',    
  sod.sod_itmdsc,    
  isnull(sod_cussku, '') as 'sod.sod_cussku',    
  'TOTAL ' + upper(isnull(prc.ysi_dsc, hiv_prctrm)) as 'hiv_prctrm',    
  shm.hsm_engdsc as 'hsm_engdscM',    
  --2005/03/17 Lester Wu -- Retrieve Company Name , Short Name , Address, Phone, Fax, Email    
  @yco_conam as '@yco_conam',    
  @yco_addr as '@yco_addr',        
    
  @yco_phoneno as '@yco_phoneno',        
  @yco_faxno as '@yco_faxno',        
  @yco_logoimgpth  as '@yco_logoimgpth',      
  @yco_logoimgpth  as 'logoimgpth',      
  @optTitle as '@optTitle',      
-- Lester Wu 2006-07-24   
  '' as '@optSort' ,-- Lester Wu 2006-07-26  
 --Added by Mark Lau 20060929  
 @printAlias as '@printAlias',      

  --Added by Mark Lau 20060928  
		--Added by Mark Lau 20080516, Add CDTVX
case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm
else
  case when @printGroup = '1' then  

 -- Changed by Mark Lau 20090402, use function to perform the logic
/*
  case when len(sca.hai_assitm) < 11 or charindex('-',sca.hai_assitm) > 0 or charindex('/',sca.hai_assitm) >0 or (Upper(substring(sca.hai_assitm,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(sca.hai_assitm,7,2) = 'AS' then ''  
   
  else   
  case when upper(substring(sca.hai_assitm, 3, 1)) = 'A'   or upper(substring(sca.hai_assitm, 3, 1)) = 'C'  or upper(substring(sca.hai_assitm, 3, 1)) = 'D' or upper(substring(sca.hai_assitm, 3, 1)) = 'T' or upper(substring(sca.hai_assitm, 3, 1)) = 'X' or upper(substring(sca.hai_assitm, 3, 1)) = 'V'  then + '(' + substring(sca.hai_assitm,12, len(sca.hai_assitm) - 11) +  ') '    --and (substring(sca.hai_assitm, 4, 1) >= '0' And substring(sca.hai_assitm, 4, 1) <= '9' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then substring(sca.hai_assitm,1,11)  
   else   
   case when upper(substring(sca.hai_assitm, 3, 1)) = 'B' and (substring(sca.hai_assitm, 4, 1) >= '0' And substring(sca.hai_assitm, 4, 1) <= '9' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then    '(' +  substring(sca.hai_assitm,12,len(sca.hai_assitm) - 11) + ') '   
    else   
    case when upper(substring(sca.hai_assitm, 3, 1)) = 'B' and (upper(substring(sca.hai_assitm, 4, 1)) >= 'A' And upper(substring(sca.hai_assitm, 4, 1)) <= 'Z' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then  '(' + substring(sca.hai_assitm,12,len(sca.hai_assitm) - 11) + ') '   
     else ''  
     end  
   end  
  end  
  end  
*/

case when dbo.groupnewitmcol(sca.hai_assitm,'','N') = '' then '' else '(' +  dbo.groupnewitmcol(sca.hai_assitm,'','N') + ') ' end
  else  
  ''  
end 
  end as 'ColSeq',  
  
 --Added by Mark Lau 20061005  
		--Added by Mark Lau 20080516, Add CDTVX
case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm
else
  case when @printGroup = '1' then  

 -- Changed by Mark Lau 20090402, use function to perform the logic
/*
  case when len(dtl.hid_itmno) < 11 or charindex('-',dtl.hid_itmno) > 0 or charindex('/',dtl.hid_itmno) >0 or (Upper(substring(dtl.hid_itmno,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(dtl.hid_itmno,7,2) = 'AS' then ''  
   
  else   
  case when upper(substring(dtl.hid_itmno, 3, 1)) = 'A'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then + '(' + substring(dtl.hid_itmno,12, len(dtl.hid_itmno) - 11) +  ') '    --and (substring(sca.hai_assitm, 4, 1) >= '0' And substring(sca.hai_assitm, 4, 1) <= '9' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then substring(sca.hai_assitm,1,11)  
   else   
   case when upper(substring(dtl.hid_itmno, 3, 1)) = 'B' and (substring(dtl.hid_itmno, 4, 1) >= '0' And substring(dtl.hid_itmno, 4, 1) <= '9' ) And (substring(dtl.hid_itmno, 5, 1) >= '0' And substring(dtl.hid_itmno, 5, 1) <= '9' ) And  (substring(dtl.hid_itmno, 6, 1) >= '0' And substring(dtl.hid_itmno, 6, 1) <= '9') then    '(' +  substring(dtl.hid_itmno,12,len(dtl.hid_itmno) - 11) + ') '   
    else   
    case when upper(substring(dtl.hid_itmno, 3, 1)) = 'B' and (upper(substring(dtl.hid_itmno, 4, 1)) >= 'A' And upper(substring(dtl.hid_itmno, 4, 1)) <= 'Z' ) And (substring(dtl.hid_itmno, 5, 1) >= '0' And substring(dtl.hid_itmno, 5, 1) <= '9' ) And  (substring(dtl.hid_itmno, 6, 1) >= '0' And substring(dtl.hid_itmno, 6, 1) <= '9') then  '(' + substring(dtl.hid_itmno,12,len(dtl.hid_itmno) - 11) + ') '   
     else ''  
     end  
   end  
  end  
  end  

*/
case when dbo.groupnewitmcol(dtl.hid_itmno,'','N') = '' then '' else '(' +  dbo.groupnewitmcol(dtl.hid_itmno,'','N') + ') ' end
  else  
  ''  
end
  end as 'ItmColSeq'  ,


case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm + ' (' + dtl.hid_itmno +  ')'
else
 case when @printGroup = '1' then  

 -- Changed by Mark Lau 20090402, use function to perform the logic
/*
  case when len(ltrim(rtrim(dtl.hid_itmno))) < 11 or charindex('-',ltrim(rtrim(dtl.hid_itmno))) > 0 or charindex('/',ltrim(rtrim(dtl.hid_itmno))) >0 or (Upper(substring(ltrim(rtrim(dtl.hid_itmno)),3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(ltrim(rtrim(dtl.hid_itmno)),7,2) = 'AS' then ltrim(rtrim(dtl.hid_itmno))  
   
  else   
  case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'A'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)   
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
 end end as 'DisplayItemNo'
 ,@usrgrp as 'UsrGrp' ,
 case   when ltrim(hih_cntyorgn) = '' then ''  else  hih_cntyorgn end  as 'hih_cntyorgn',
dtl.hid_ctnftr AS 'hid_ctnftr',
CONVERT(VARCHAR(10),hiv_cargorcvdat,101)   as'hiv_cargorcvdat',         
@printCRD AS '@printCRD',
@printRTL AS '@printRTL',
@printCOO AS '@printCOO',
@printFRM AS '@printFRM',
@optUCP AS '@optUCP',
hid_resppo as 'hid_resppo',
tmp_table.tmp_cmp,
	sod.sod_typcode as 'sod.sod_typcode',
	sod.sod_Code1 as 'sod.sod_Code1',
isnull(rvl_header_resppo.hrt_rmkval,'') as 'header_resppo',
isnull(rvl_header_custpo.hrt_rmkval,'') as 'header_custpo',
isnull(rvl_detail_cuitm.hrt_rmkval,'') as 'detail_cuitm',
isnull(rvl_detail_cusku.hrt_rmkval,'') as 'detail_sku',
isnull(rvl_header_tax.hrt_rmkval,'') as 'header_tax',
isnull(rvl_header_sig.hrt_rmkval,'') as 'header_sig',
isnull(rvl_header_wood.hrt_rmkval,'') as 'inv_ftrmk',	 
isnull(rvl_header_air.hrt_rmkval,'') as 'header_air',
isnull(dtl.hid_name_f1,'') as 'dtl.hid_name_f1',
isnull(dtl.hid_dsc_f1,'') as 'dtl.hid_dsc_f1',
isnull(dtl.hid_name_f2,'') as 'dtl.hid_name_f2',
isnull(dtl.hid_dsc_f2,'') as 'dtl.hid_dsc_f2',
isnull(dtl.hid_name_f3,'') as 'dtl.hid_name_f3',
isnull(dtl.hid_dsc_f3,'') as 'dtl.hid_dsc_f3',
  case   when ltrim(hiv_lcno) = '' then ''  else  hiv_lcno end  as 'hiv_lcno',
hiv_lcbank  as 'hiv_lcbank',
	right('0' + ltrim(rtrim(str(datepart(dd, hiv_lcdat)))), 2) + ' ' +
		case datepart(mm, hiv_lcdat) when 1 then 'Jan' when 2 then
'Feb' when 3 then 'Mar' when 4 then 'Apr' when 5 then 'May'
		when 6 then 'Jun' when 7 then 'Jul' when 8 then 'Aug' when
		9 then 'Sep' when 10 then 'Oct' when 11 then 'Nov' when 12
		then 'Dec' end + ' ' + 
		right(ltrim(rtrim(str(datepart(yyyy, hiv_lcdat)))), 2) as 'hiv_lcdat',


--CONVERT(nVARCHAR(20),hiv_lcdat,106)   as'hiv_lcdat'     ,
--CONVERT(VARCHAR(10),inv.hiv_lcdat,12)   as'hiv_lcdat'         ,

pdm.hpd_pdnum as 'hpd_pdnum',
ROUND(hiv_ttlamt,2) AS 'hiv_ttlamt',
#temp_table_sum_cussku.tmp_sum as 'cbmsum_itmno',
dtl.hid_conftr as 'dtl.hid_conftr',
dtl.hid_cusstyno as 'dtl.hid_cusstyno',
  ltrim(str(pdm.hpd_l_cm,10,2))  as 'dtl.L' ,        
ltrim(str( pdm.hpd_w_cm,10,2))  as 'dtl.W',         
 ltrim(str(pdm.hpd_h_cm,10,2))  as 'dtl.H',
  isnull(hdp_type,'D') as 'hdp_type',
	isnull(hdp_dsc,'') as 'hdp_cde',
	isnull(hdp_amt,0) as 'hdp_amt',
	isnull(hdp_pctamt,0) as 'hdp_pctamt',
	isnull(ltrim(str(hdp_pct,10,2)),'') as 'hdp_pct',
tmp_po.tmp_po as 'tmp_po',
         isnull(hiv_exptaddr,'') as 'hiv_exptaddr'


 From  SHIPGHDR hdr    
left join SHRMKVAL rvl_header_resppo
		on rvl_header_resppo.hrt_pricustno =  hdr.hih_cus1no
		and rvl_header_resppo.hrt_rmkdsc= 'Header Respective PO #'
left join SHRMKVAL rvl_header_custpo
		on rvl_header_resppo.hrt_pricustno =  hdr.hih_cus1no
		and rvl_header_custpo.hrt_rmkdsc= 'Header Customer PO#'
left join SHRMKVAL rvl_detail_cuitm
		on rvl_detail_cuitm.hrt_pricustno =  hdr.hih_cus1no
		and rvl_detail_cuitm.hrt_rmkdsc= 'Detail Customer Item Number'
left join SHRMKVAL rvl_detail_cusku
		on rvl_detail_cusku.hrt_pricustno = hdr.hih_cus1no
		and rvl_detail_cusku.hrt_rmkdsc= 'Detail Cust SKU#'

left join SHRMKVAL rvl_header_tax
		on rvl_header_tax.hrt_pricustno = hdr.hih_cus1no
		and rvl_header_tax.hrt_rmkdsc= 'TAX'
left join SHRMKVAL rvl_header_sig
		on rvl_header_sig.hrt_pricustno = hdr.hih_cus1no
		and rvl_header_sig.hrt_rmkdsc= 'SIG'
left join SHRMKVAL rvl_header_wood
		on rvl_header_wood.hrt_pricustno = hdr.hih_cus1no
		and rvl_header_wood.hrt_rmkdsc= 'WOOD'

  
left join SHRMKVAL rvl_header_air
		on rvl_header_air.hrt_pricustno = hdr.hih_cus1no
		and rvl_header_air.hrt_rmkdsc= 'AIR'


  left join CUBASINF cus on  --hdr.hih_cocde = cus.cbi_cocde and     
     hdr.hih_cus1no = cus.cbi_cusno    
  left join SYSETINF cty on --hdr.hih_cocde = cty.ysi_cocde and     
     hdr.hih_bilcty = cty.ysi_cde and     
     cty.ysi_typ = '02'    
      
  ,SHINVHDR inv     
  left join SHIPGDTL dtl on inv.hiv_cocde = @cocde and    
     inv.hiv_shpno = dtl.hid_shpno and     
     inv.hiv_invno = dtl.hid_invno    
left join shpckdim pdm on 
	 pdm.hpd_shpno = dtl.hid_shpno and pdm.hpd_shpseq = dtl.hid_shpseq
		and pdm.hpd_dimtyp = 'Mod'
		and (
			(dtl.hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
			or (dtl.hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
			)

left join #temp_cmp tmp_table on
	tmp_table.tmp_shpno =  dtl.hid_shpno
	and tmp_table.tmp_shpseq = dtl.hid_shpseq
 left join  #temp_po  tmp_po on
	tmp_po.tmp_shpno =  dtl.hid_shpno
	and tmp_po.tmp_mannam = dtl.hid_mannam
      
      
-- Added by Mark Lau 20080714, Customer Alias
-- Changed by Mark LAu 20090702
--  left join imcusals ca on  dtl.hid_itmno  = ca.ica_itmno  and ca.ica_apvsts = 'Y' 
 left join SHPCUSSTY ca on  dtl.hid_itmno  = ca.ica_itmno  and ca.ica_apvsts = 'Y' and ca.sod_ordno = dtl.hid_ordno 
and ca.sod_ordseq = dtl.hid_ordseq

  left join SHSHPMRK shm on   
	shm.hsm_cocde = @cocde and     
     shm.hsm_invno = inv.hiv_invno and     
     shm.hsm_shptyp = 'M'     
  left join SYSETINF prc on --prc.ysi_cocde =@cocde and     
     inv.hiv_prctrm = prc.ysi_cde and     
     prc.ysi_typ = '03'    
  left join SYSETINF pay on --pay.ysi_cocde = @cocde and     
     inv.hiv_paytrm = pay.ysi_cde and     
     pay.ysi_typ = '04'    
	--Modified by Mark Lau 20080314, move from low section
  left join SYSETINF cde on inv.hiv_cocde = @cocde and    
--Edited by Mark Lau 20080616 
     case when isnull(dtl.hid_custum,'') <> '' then dtl.hid_custum else case when isnull(dtl.hid_contopc,'') = 'Y' then 'PC' else dtl.hid_untcde end end = cde.ysi_cde and     
     cde.ysi_typ = '05'         
  left join SCORDHDR soh on soh.soh_cocde = @cocde and     
     soh.soh_ordno = dtl.hid_ordno     
  left join SCORDDTL sod on  sod.sod_cocde = @cocde and     
     sod.sod_ordno = dtl.hid_ordno and     
     sod.sod_ordseq = dtl.hid_ordseq    

  left join  v_select_inr00001_wNewItmNo vw on  vw.hid_cocde =@cocde and  
--vw.grp = 1 and
 vw.grp = @printgroup and   
--vw.grp = '0' and   
      vw.hid_invno = inv.hiv_invno  and     
      dtl.hid_cuspo = vw.hid_cuspo and    
      dtl.hid_ordno = vw.hid_ordno and     
      dtl.hid_mannam = vw.hid_mannam and     
case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm
else
case when @printGroup = '1' then  dbo.groupnewitmno(dtl.hid_itmno)
    else  
  ltrim(rtrim(dtl.hid_itmno))  
  end end = vw.hid_itmno and   
      dtl.hid_itmdsc = vw.hid_itmdsc and      
      dtl.hid_inrctn = vw.hid_inrctn and     
      dtl.hid_mtrctn = vw.hid_mtrctn    
      and dtl.hid_selprc = vw.hid_selprc      
	     and cde.ysi_dsc = vw.ysi_dsc
      and     
--      ltrim(str(dtl.hid_grswgt,10,2)) = vw.hid_grswgt and     
--      ltrim(str(dtl.hid_netwgt,10,2)) = vw.hid_netwgt and      
--      ltrim(str(dtl.hid_mtrdcm,10,2)) + ' X ' + ltrim(str( dtl.hid_mtrwcm,10,2)) + ' X ' + ltrim(str(dtl.hid_mtrhcm,10,2)) = vw.MEAS   and  

      ltrim(str(hpd_gw_kg,10,2)) = vw.hid_grswgt and     
      ltrim(str(hpd_nw_kg,10,2)) = vw.hid_netwgt and      

      ltrim(str(hpd_l_cm,10,2)) + ' X ' + ltrim(str(hpd_w_cm,10,2)) + ' X ' + ltrim(str(hpd_h_cm,10,2)) = vw.MEAS   
--	and dtl.hid_ctnftr = vw.hid_ctnftr -- 20150323
and
 case when  dtl.hid_ctnftr=2 then    
		dtl.hid_shpseq
	 else   
		vw.hid_shpseq
	 end = vw.hid_shpseq

and  dtl.hid_ctnftr=vw.hid_ctnftr

 and     vw.hid_invno between @from and @to        
     
  left join POORDDTL on  pod_cocde = @cocde and     
     pod_purord =  dtl.hid_purord and     
     pod_purseq = dtl.hid_purseq    

  left join SHASSINF sca on  --sca.hai_cocde =@cocde  and     
     sca.hai_ordno = dtl.hid_ordno and     
     sca.hai_ordseq = dtl.hid_ordseq     
  left join  SYSETINF saa on  --saa.ysi_cocde = @cocde and     
     sca.hai_untcde = saa.ysi_cde and     
     saa.ysi_typ = '05'    
left join #temp_table_sum_cussku 
	on   
		 rtrim(ltrim(dtl.hid_itmno)) =   rtrim(ltrim(#temp_table_sum_cussku.tmp_itmno))
--	and	dtl.hid_ctrcfs = #temp_table_sum_cussku.ctrcfs
	and	 rtrim(ltrim(dtl.hid_invno)) =  rtrim(ltrim(#temp_table_sum_cussku.invno))
--	and       pdm.hpd_pdnum = #temp_table_sum_cussku.tmp_pdnum
LEFT JOIN SHDISPRM ON hdp_invno = hiv_invno and hdp_cocde = hiv_cocde AND hdp_shpno = hiv_shpno and hdp_seqno = 1


 WHERE      
  hdr.hih_shpsts <> 'HLD'    
 and  hdr.hih_cocde = @cocde    
 and hdr.hih_shpno = dtl.hid_shpno    
 and  inv.hiv_invno >= @from and inv.hiv_invno <= @to    
--and ( (hdr.hih_cus1no =  ca.ica_cusno and isnull(ca.ica_cusno,'') <> '') or  isnull(ca.ica_cusno,'') = '')
end  
else  
begin  
------------------------------------------------------------------------------------------------------------------------------------------------------    
----*** MAKE SURE UPPER PART AND LOWER PART SHOULD IDENTICAL WHEN MODIFY THIS SP  *** ----  
------------------------------------------------------------------------------------------------------------------------------------------------------    
  -- Lower Part --  
------------------------------------------------------------------------------------------------------------------------------------------------------    
------------------------------------------------------------------------------------------------------------------------------------------------------     
 Select     
  @opt1  as 'opt1',        
  @opt2  as 'opt2',        
  @opt3  as 'opt3',        

--  @opt4  as 'opt4',        
--temp use opt4 to indicate assorment or not
case   when dtl.hid_itmtyp = 'REG' then 'N'  else  'Y' end  as 'opt4',
case   when dtl.hid_conftr >1 then 'Y'  else  'N' end  as 'opt5',

--  @opt5  as 'opt5',        
  @opt6  as 'opt6',        
@laf  as 'laf',        
  case when hiv_aformat = '2' then 'C' else case when hiv_aformat = '1' then 'A' else 'C' end end as 'hiv_aformat',    
  hdr.hih_shpno as 'hdr.hih_shpno',    
  cast(dtl.hid_shpseq as nvarchar(20))  as 'dtl.hid_shpseq',    
  hdr.hih_smpshp as 'hdr.hih_smpshp',    
  inv.hiv_invno as 'inv.hiv_invno',
  ltrim(inv.hiv_cover) as 'inv.hiv_cover',    
  ltrim(cus.cbi_cusnam) as 'cus.cbi_cusnam',    
    
  ltrim(hdr.hih_bilent) as 'hdr.hih_bilent',    
  ltrim(hdr.hih_biladr) as 'hdr.hih_biladr',    
  ltrim(hdr.hih_bilstt) as 'hdr.hih_bilstt',     
  ltrim(cty.ysi_dsc) as 'cty.ysi_dsc',     
  ltrim(hdr.hih_bilzip) as 'hdr.hih_bilzip',     
  ltrim(pay.ysi_dsc) as 'inv.hiv_paytrm',    
  ltrim(inv.hiv_ftrrmk) as 'inv.hiv_ftrrmk',    
  ltrim(inv.hiv_doctyp) as 'inv.hiv_doctyp',    
  ltrim(inv.hiv_doc) as 'inv.hiv_doc',    
CONVERT(VARCHAR(10),inv.hiv_invdat,101)   as'inv.hiv_invdat',         
  'PORT OF LOADING: ' + hdr.hih_potloa +char(13)+ 'DESTINATION: ' + hdr.hih_dst as 'hdr.hih_potloa_hih_dst',    
  hdr.hih_ves as 'hdr.hih_ves',    
  hdr.hih_voy as 'hdr.hih_voy',    
CONVERT(VARCHAR(10),hdr.hih_slnonb,101)   as'hdr.hih_slnonb',    
     
 --- For Packing List, Group by Container #    
  ltrim(dtl.hid_pckrmk) as 'dtl.hid_pckrmk',
  dtl.hid_ctrcfs as 'dtl.hid_ctrcfs',

    CASE when cde.ysi_dsc  = 'ST' THEN
	CASE when isnull(dtl.hid_contopc,'') =  'Y' and isnull(dtl.hid_custum,'') = '' THEN
		 ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr))
	ELSE     
		 ltrim(str(dtl.hid_mtrctn))  
	END 
   ELSE 
		ltrim(str(dtl.hid_mtrctn))
  END As 'dtl.hid_mtrctn_result',   --Michael 20170413

 --- Total of Cartons for Container    
     
 --- For Invoice, Group by Customer PO# and Sales Confirmation #    
  ltrim(dtl.hid_cuspo) as 'dtl.hid_cuspo',    
soh.soh_cpodat as  'poh.poh_issdat',    
 --- Customer PO Date    
  dtl.hid_ordno as 'dtl.hid_ordno',
  soh.soh_issdat as 'soh.soh_issdat',
 --- SC Revise Date    
     
     
 --- Details Shipmark    
  ltrim(dtl.hid_itmshm) as 'dtl.hid_itmshm',    
 --- Carton Details    

 --- Manufacturers Name & Address    
  ltrim(dtl.hid_mannam) + '' as 'dtl.hid_mannam',    
  case   when ltrim(dtl.hid_manadr) = '' then '.'  else  dtl.hid_manadr end  as 'dtl.hid_manadr',

 -- ltrim(rtrim(dtl.hid_itmno)) as 'hid_itmno',    
  
 --Added by Mark Lau 20060927  
		--Added by Mark Lau 20080516, Add CDTVX
case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm 
else
 case when @printGroup = '1' then  

 -- Changed by Mark Lau 20090402, use function to perform the logic
/*

  case when len(ltrim(rtrim(dtl.hid_itmno))) < 11 or charindex('-',ltrim(rtrim(dtl.hid_itmno))) > 0 or charindex('/',ltrim(rtrim(dtl.hid_itmno))) >0 or (Upper(substring(ltrim(rtrim(dtl.hid_itmno)),3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(ltrim(rtrim(dtl.hid_itmno)),7,2) = 'AS' then ltrim(rtrim(dtl.hid_itmno))  
   
  else   
  case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'A'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)   
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
  ltrim(rtrim(dtl.hid_itmdsc)) as 'dtl.hid_itmdsc',    
     
 --- Assortment Details    
 --- Component Breakdown    
      
 --- Packing: change all to string and concat.    
CASE when isnull(dtl.hid_contopc,'') =  'Y' and isnull(dtl.hid_custum,'') <> '' THEN
	 CASE  ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN     

	   ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr)) +  ' ' + cde.ysi_dsc + ' TO CTN.'    

	 ELSE     
	 ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc +' TO BOX, '  + ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' ' + cde.ysi_dsc + ' TO CTN.'  END
ELSE
CASE isnull(dtl.hid_contopc,'') when 'Y' Then
	 CASE  ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN     
	   ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' PC TO CTN.'    
	 ELSE     
	 ltrim(str(dtl.hid_inrctn*dtl.hid_conftr)) + ' PC TO BOX, ' + ltrim(str(dtl.hid_mtrctn*dtl.hid_conftr)) + ' PC TO CTN.' END
Else
	 CASE  ltrim(str(dtl.hid_inrctn)) WHEN '0' THEN     
	   ltrim(str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc +' TO CTN.'    
	 ELSE     
	 ltrim(str(dtl.hid_inrctn)) + ' ' + cde.ysi_dsc +' TO BOX, ' + ltrim(str(dtl.hid_mtrctn)) + ' ' + cde.ysi_dsc +' TO CTN.' END
END
END
as 'dtl.packing',    
--  ltrim(str(dtl.hid_grswgt,10,2)) + ' KG' as 'dtl.hid_grswgt',    
--  ltrim(str(dtl.hid_netwgt,10,2)) + ' KG' as 'dtl.hid_netwgt',    
  ltrim(str(pdm.hpd_gw_kg,10,2)) + ' KGS' as 'dtl.hid_grswgt',    
  ltrim(str(pdm.hpd_nw_kg,10,2)) + ' KGS' as 'dtl.hid_netwgt',    

 --- Master Dim are concat.    
--  ltrim(str(dtl.hid_mtrdcm,10,2)) + ' X ' + ltrim(str( dtl.hid_mtrwcm,10,2)) + ' X ' + ltrim(str(dtl.hid_mtrhcm,10,2)) + ' CM' as 'dtl.meas',    
  ltrim(str(pdm.hpd_l_cm,10,2)) + ' X ' + ltrim(str( pdm.hpd_w_cm,10,2)) + ' X ' + ltrim(str(pdm.hpd_h_cm,10,2)) + ' CM' as 'dtl.meas',         
 --- Harmonized Code    
     
  str(dtl.hid_ttlctn) as 'dtl.hid_ttlctn',    
CASE isnull(dtl.hid_contopc,'') when 'Y' Then
  str(cast(dtl.hid_shpqty*dtl.hid_conftr as int))
Else
  str(dtl.hid_shpqty)
End as 'dtl.hid_shpqty',    
 
  dtl.hid_untsel as 'dtl.hid_untsel',    
case isnull(dtl.hid_contopc,'') when 'Y' then  
	str(round(dtl.hid_pcprc,4)) 
else  
	str(round(dtl.hid_selprc,4)) 
end as 'dtl.hid_selprc', 

  str(round(dtl.hid_ttlamt,2),10,4) as 'dtl.hid_ttlamt',    
  shm.hsm_imgpth as 'shm.hsm_imgpth',
  left(ltrim(shm.hsm_engdsc),1) as 'shm.hsm_engdsc',    
  @cocde as 'cocde',    
  ltrim(dtl.hid_cmprmk) as 'dtl.hid_cmprmk',    
--  sca.hai_assitm,    
  
 --Added by Mark Lau 20060927  
		--Added by Mark Lau 20080516, Add CDTVX
 case when @printGroup = '1'  then  
 -- Changed by Mark Lau 20090402, use function to perform the logic
/*
  case when len(sca.hai_assitm) < 11 or charindex('-',sca.hai_assitm) > 0 or charindex('/',sca.hai_assitm) >0 or (Upper(substring(sca.hai_assitm,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(sca.hai_assitm,7,2) = 'AS' then sca.hai_assitm  
   
  else   
  case when upper(substring(sca.hai_assitm, 3, 1)) = 'A'  or upper(substring(sca.hai_assitm, 3, 1)) = 'C'  or upper(substring(sca.hai_assitm, 3, 1)) = 'D' or upper(substring(sca.hai_assitm, 3, 1)) = 'T' or upper(substring(sca.hai_assitm, 3, 1)) = 'X' or upper(substring(sca.hai_assitm, 3, 1)) = 'V'  then substring(sca.hai_assitm,1,11)--and (substring(sca.hai_assitm, 4, 1) >= '0' And substring(sca.hai_assitm, 4, 1) <= '9' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then substring(sca.hai_assitm,1,11)   
   else    
   case when upper(substring(sca.hai_assitm, 3, 1)) = 'B' and (substring(sca.hai_assitm, 4, 1) >= '0' And substring(sca.hai_assitm, 4, 1) <= '9' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then substring(sca.hai_assitm,1,11)  
    else   
    case when upper(substring(sca.hai_assitm, 3, 1)) = 'B' and (upper(substring(sca.hai_assitm, 4, 1)) >= 'A' And upper(substring(sca.hai_assitm, 4, 1)) <= 'Z' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then substring(sca.hai_assitm,1,11)  
     else sca.hai_assitm  
     end  
   end  
  end  
  end  
*/

dbo.groupnewitmno(sca.hai_assitm)
  else  
  sca.hai_assitm
  end as 'sca.sai_assitm',  
  sca.hai_assdsc as 'sca.sai_assdsc',    
  sca.hai_coldsc as 'sca.sai_coldsc',    
  sca.hai_cussku as 'sca.sai_cussku',    
  sca.hai_upcean as 'sca.sai_upcean',    
  sca.hai_cusrtl as 'sca.sai_cusrtl',    
  ltrim(saa.ysi_dsc) as 'sca.sai_untcde',    
  cast(dtl.hid_ordseq  as nvarchar(20)) as 'dtl.hid_ordseq',    
  sca.hai_cusitm as 'sca.sai_cusitm',    
  sca.hai_colcde as 'sca.sai_colcde',    
  sca.hai_cusstyno as 'sca.sai_cusstyno',    

  ltrim(str(sca.hai_inrqty,10,0)) as 'inner',    
  ltrim(str(sca.hai_mtrqty,10,0)) as 'master',    
  hdr.hih_cus1no as 'hdr.hih_cus1no',    
-- ltrim(cde.ysi_dsc) 
case when isnull(dtl.hid_custum,'') <> '' then dtl.hid_custum else case when isnull(dtl.hid_contopc,'')  = 'Y' then 'PC' else ltrim(cde.ysi_dsc) end end  as 'cde.ysi_dsc',     
  ltrim(dtl.hid_colcde) as 'dtl.hid_colcde',    
  
 --Added by Mark Lau 20060927  
		--Added by Mark Lau 20080516, Add CDTVX

 case when @printGroup = '1' then  

 -- Changed by Mark Lau 20090402, use function to perform the logic
/*

  case when len(ltrim(rtrim(dtl.hid_itmno)) ) < 11 or charindex('-',ltrim(rtrim(dtl.hid_itmno)) ) > 0 or charindex('/',ltrim(rtrim(dtl.hid_itmno)) ) >0 or (Upper(substring(ltrim(rtrim(dtl.hid_itmno)) ,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(ltrim(rtrim(dtl.hid_itmno)) ,7,2) = 'AS' then ''  
  else   
  case when upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 3, 1)) = 'A'   or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then + '(' + substring(ltrim(rtrim(dtl.hid_itmno)) ,12, len(dtl.hid_itmno) - 11) +  ') ' --and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)  
   else   
   case when upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 3, 1)) = 'B' and (substring(ltrim(rtrim(dtl.hid_itmno)) , 4, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 4, 1) <= '9' ) And (substring(ltrim(rtrim(dtl.hid_itmno)) , 5, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)) , 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 6, 1) <= '9') then  '(' +  substring(ltrim(rtrim(dtl.hid_itmno)) ,12,len(ltrim(rtrim(dtl.hid_itmno)) ) - 11) + ') '   
    else   
    case when upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 3, 1)) = 'B' and (upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 4, 1)) >= 'A' And upper(substring(ltrim(rtrim(dtl.hid_itmno)) , 4, 1)) <= 'Z' ) And (substring(ltrim(rtrim(dtl.hid_itmno)) , 5, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 5, 1) <= '9' ) And  (substring(ltrim(rtrim(dtl.hid_itmno)) , 6, 1) >= '0' And substring(ltrim(rtrim(dtl.hid_itmno)) , 6, 1) <= '9') then  '(' + substring(ltrim(rtrim(dtl.hid_itmno)) ,12,len(ltrim(rtrim(dtl.hid_itmno)) ) - 11) + ') '   
     else ''  
     end  
   end  
  end  
  end  

*/
case when dbo.groupnewitmcol(dtl.hid_itmno,dtl.hid_colcde,'N') = '' then '' else '(' +  dbo.groupnewitmcol(dtl.hid_itmno,dtl.hid_colcde,'N') + ') ' end
  else  
  ''  
  end   +  
  Case rtrim(ltrim(dtl.hid_coldsc)) + ' ' +rtrim(ltrim(dtl.hid_cuscol)) when ' ' then Case rtrim(ltrim(pod_vencol)) when 'N/A' then '' else rtrim(ltrim(pod_vencol)) end else rtrim(ltrim(dtl.hid_coldsc)) + ' ' +rtrim(ltrim(dtl.hid_cuscol)) end AS 'dtl.hid_coldsc'   ,    
  ltrim(sod.sod_hrmcde) as 'sod.sod_hrmcde',    
  ltrim(inv.hiv_bank) as 'hiv.hiv_bank',    
  ltrim(inv.hiv_ftrrmk) as 'hiv.hiv_ftrrmk',    
  ltrim( dtl.hid_cusitm) as 'dtl.hid_cusitm',    
  sod.sod_typcode as 'sod.sod_typcode',    
  LTRIM(sod.sod_Code1) + LTRIM(sod.sod_Code2) + LTRIM(sod.sod_Code3) AS 'sod.sod_code',    
 --- Additional Field : Duty Rate, Customer Retail & Dept #    
      
  CASE sod.sod_dtyrat when 0 then '' else ltrim(str(sod.sod_dtyrat,10,0)) end AS 'sod.sod_dtyrat',    
  CASE sod.sod_cususd when 0 then '' else ltrim(str(sod.sod_cususd,13,4)) end AS 'sod.sod_cususd',    
  CASE sod.sod_cuscad when 0 then '' else ltrim(str(sod.sod_cuscad,13,4)) end AS 'sod.sod_cuscad',    
  ltrim(sod.sod_dept) as 'sod.sod_dept',    
 -- dtl.hid_ctnstr,    
  ltrim(str(dtl.hid_ctnstr)) + ltrim(str(dtl.hid_ctnend)) as 'dtl.hid_ctnstr',    
case isnull(dtl.hid_contopc,'') when 'Y' then     
  str(round(dtl.hid_pcprc/1.05,2))
else
  str(round(dtl.hid_selprc/1.05,2))
end as 'dtl.hid_Aprc',    

 --- Packing Remarks Details    
 --- To concat. all packing remarks of the invoice    
 -- Total amount of a invoice    
dtl.hid_ctnftr* vw.hid_ttlctn as 'vw_ttlctn',    
  dtl.hid_ctnftr  as 'dtl.hid_ctnftr',
vw.hid_ttlctn as 'vw.hid_ttlctn',

 case isnull(dtl.hid_contopc,'') when 'Y' then  cast( vw.hid_shpqty*dtl.hid_conftr as int)  else vw.hid_shpqty end  as 'vw_shpqty', 
  --vw.hid_selprc as vw_debprc,  -- For debug only    
  --Case @laf when 'A' then round(vw.hid_selprc/1.05,2) else vw.hid_selprc end as vw_selprc,    
  --Case @laf when 'A' then  vw.sumamtd else vw.sumamt end as vw_sumamt,    
      
  Case (case when hiv_aformat = '2' then 'C' else ( case when hiv_aformat = '1' then 'A' else 'C' end) end)    
   when 'A' then 
	case isnull(dtl.hid_contopc,'') when 'Y' then 
	cast(	round(vw.hid_selprc/dtl.hid_conftr/1.05,4)  as decimal (18,4))
	else
		cast( round(vw.hid_selprc/1.05,4)  as decimal (18,4))
	end
   else 
	case isnull(dtl.hid_contopc,'') when 'Y' then 
		cast(round(vw.hid_selprc / dtl.hid_conftr,4)  as decimal (18,4))
	else
		cast(vw.hid_selprc    as decimal (18,4))
	end
   end as vw_selprc,    
     
  Case case when hiv_aformat = '2' then 'C' else case when hiv_aformat = '1' then 'A' else 'C' end end    
   when 'A' then  vw.sumamtd else vw.sumamt end as vw_sumamt,    
     
  Case @opt4 when 'N' then '' else Case ltrim(dtl.hid_jobno) when '' then '' else  ltrim(dtl.hid_jobno) + '(' + ltrim(dtl.hid_venno) + ')' end end as 'dtl.hid_jobno',    
  sod.sod_itmdsc as 'sod.sod_itmdsc',    
  isnull(sod_cussku, '') as 'sod.sod_cussku',    
  'TOTAL ' + upper(isnull(prc.ysi_dsc, hiv_prctrm)) as 'hiv_prctrm',    
  shm.hsm_engdsc as 'hsm_engdscM',    
  --2005/03/17 Lester Wu -- Retrieve Company Name , Short Name , Address, Phone, Fax, Email    
  @yco_conam as '@yco_conam',    
  @yco_addr as '@yco_addr',        
      
  @yco_phoneno as '@yco_phoneno',        
  @yco_faxno as '@yco_faxno',        
  @yco_logoimgpth  as '@yco_logoimgpth',      
  @yco_logoimgpth  as 'logoimgpth',      
  @optTitle as '@optTitle',      -- Lester Wu 2006-07-24   
  ltrim( dtl.hid_cusitm)  as '@optSort' ,-- Lester Wu 2006-07-26  
  --    
  
 @printAlias as '@printAlias',      
  
  
  --Added by Mark Lau 20060928  
		--Added by Mark Lau 20080516, Add CDTVX
case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm
else
  case when @printGroup = '1' then  
-- Changed by Mark Lau 20090402, use function to perform the logic
/*
  case when len(sca.hai_assitm) < 11 or charindex('-',sca.hai_assitm) > 0 or charindex('/',sca.hai_assitm) >0 or (Upper(substring(sca.hai_assitm,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(sca.hai_assitm,7,2) = 'AS' then ''  
   
  else   
  case when upper(substring(sca.hai_assitm, 3, 1)) = 'A'  or upper(substring(sca.hai_assitm, 3, 1)) = 'C'  or upper(substring(sca.hai_assitm, 3, 1)) = 'D' or upper(substring(sca.hai_assitm, 3, 1)) = 'T' or upper(substring(sca.hai_assitm, 3, 1)) = 'X' or upper(substring(sca.hai_assitm, 3, 1)) = 'V'  then + '(' + substring(sca.hai_assitm,12, len(sca.hai_assitm) - 11) +  ') '    --and (substring(sca.hai_assitm, 4, 1) >= '0' And substring(sca.hai_assitm, 4, 1) <= '9' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then substring(sca.hai_assitm,1,11)  
   else   
   case when upper(substring(sca.hai_assitm, 3, 1)) = 'B' and (substring(sca.hai_assitm, 4, 1) >= '0' And substring(sca.hai_assitm, 4, 1) <= '9' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then    '(' +  substring(sca.hai_assitm,12,len(sca.hai_assitm) - 11) + ') '   
    else   
    case when upper(substring(sca.hai_assitm, 3, 1)) = 'B' and (upper(substring(sca.hai_assitm, 4, 1)) >= 'A' And upper(substring(sca.hai_assitm, 4, 1)) <= 'Z' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then  '(' + substring(sca.hai_assitm,12,len(sca.hai_assitm) - 11) + ') '   
     else ''  
     end  
   end  
  end  
  end  
*/
case when dbo.groupnewitmcol(sca.hai_assitm,'','N') = '' then '' else '(' +  dbo.groupnewitmcol(sca.hai_assitm,'','N') + ') ' end

  else  
  ''
  end end as 'ColSeq',  
  --Added by Mark Lau 20061005  
		--Added by Mark Lau 20080516, Add CDTVX
case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm
else
  case when @printGroup = '1' then  
-- Changed by Mark Lau 20090402, use function to perform the logic
/*

  case when len(dtl.hid_itmno) < 11 or charindex('-',dtl.hid_itmno) > 0 or charindex('/',dtl.hid_itmno) >0 or (Upper(substring(dtl.hid_itmno,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(dtl.hid_itmno,7,2) = 'AS' then ''  
   
  else   
  case when upper(substring(dtl.hid_itmno, 3, 1)) = 'A'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then + '(' + substring(dtl.hid_itmno,12, len(dtl.hid_itmno) - 11) +  ') '    --and (substring(sca.hai_assitm, 4, 1) >= '0' And substring(sca.hai_assitm, 4, 1) <= '9' ) And (substring(sca.hai_assitm, 5, 1) >= '0' And substring(sca.hai_assitm, 5, 1) <= '9' ) And  (substring(sca.hai_assitm, 6, 1) >= '0' And substring(sca.hai_assitm, 6, 1) <= '9') then substring(sca.hai_assitm,1,11)  
   else   
   case when upper(substring(dtl.hid_itmno, 3, 1)) = 'B' and (substring(dtl.hid_itmno, 4, 1) >= '0' And substring(dtl.hid_itmno, 4, 1) <= '9' ) And (substring(dtl.hid_itmno, 5, 1) >= '0' And substring(dtl.hid_itmno, 5, 1) <= '9' ) And  (substring(dtl.hid_itmno, 6, 1) >= '0' And substring(dtl.hid_itmno, 6, 1) <= '9') then    '(' +  substring(dtl.hid_itmno,12,len(dtl.hid_itmno) - 11) + ') '   
    else   
    case when upper(substring(dtl.hid_itmno, 3, 1)) = 'B' and (upper(substring(dtl.hid_itmno, 4, 1)) >= 'A' And upper(substring(dtl.hid_itmno, 4, 1)) <= 'Z' ) And (substring(dtl.hid_itmno, 5, 1) >= '0' And substring(dtl.hid_itmno, 5, 1) <= '9' ) And  (substring(dtl.hid_itmno, 6, 1) >= '0' And substring(dtl.hid_itmno, 6, 1) <= '9') then  '(' + substring(dtl.hid_itmno,12,len(dtl.hid_itmno) - 11) + ') '   
     else ''  
     end  
   end  
  end  
  end  

*/
case when dbo.groupnewitmcol(dtl.hid_itmno,'','N') = '' then '' else '(' +  dbo.groupnewitmcol(dtl.hid_itmno,'','N') + ') ' end
  else  
  ''  
  end end as 'ItmColSeq'  ,

case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm + ' (' + dtl.hid_itmno +  ')'
else
 case when @printGroup = '1' then  
-- Changed by Mark Lau 20090402, use function to perform the logic
/*
  case when len(ltrim(rtrim(dtl.hid_itmno))) < 11 or charindex('-',ltrim(rtrim(dtl.hid_itmno))) > 0 or charindex('/',ltrim(rtrim(dtl.hid_itmno))) >0 or (Upper(substring(ltrim(rtrim(dtl.hid_itmno)),3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(ltrim(rtrim(dtl.hid_itmno)),7,2) = 'AS' then ltrim(rtrim(dtl.hid_itmno))  
   
  else   
  case when upper(substring(ltrim(rtrim(dtl.hid_itmno)), 3, 1)) = 'A'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'C'  or upper(substring(dtl.hid_itmno, 3, 1)) = 'D' or upper(substring(dtl.hid_itmno, 3, 1)) = 'T' or upper(substring(dtl.hid_itmno, 3, 1)) = 'X' or upper(substring(dtl.hid_itmno, 3, 1)) = 'V'  then substring(ltrim(rtrim(dtl.hid_itmno)),1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)   
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
 end end as 'DisplayItemNo' ,
@usrgrp as 'UsrGrp',
case   when ltrim(hih_cntyorgn) = '' then ''  else  hih_cntyorgn end  as 'hih_cntyorgn',
dtl.hid_ctnftr AS 'hid_ctnftr',
CONVERT(VARCHAR(10),hiv_cargorcvdat,101)   as'hiv_cargorcvdat',         
@printCRD AS '@printCRD',
@printRTL AS '@printRTL',
@printCOO AS '@printCOO',
@printFRM AS '@printFRM',
@optUCP AS '@optUCP',
hid_resppo as 'hid_resppo',
tmp_table.tmp_cmp,
	sod.sod_typcode as 'sod.sod_typcode',
	sod.sod_Code1 as 'sod.sod_Code1',
@cocde,
@printgroup,
inv.hiv_invno,
dtl.hid_cuspo,
dtl.hid_ordno,
dtl.hid_mannam,
dtl.hid_itmno,
ca.ica_itmno,
dbo.groupnewitmno(dtl.hid_itmno),
cde.ysi_dsc,
isnull(rvl_header_resppo.hrt_rmkval,'') as 'header_resppo',
isnull(rvl_header_custpo.hrt_rmkval,'') as 'header_custpo',
isnull(rvl_detail_cuitm.hrt_rmkval,'') as 'detail_cuitm',
isnull(rvl_detail_cusku.hrt_rmkval,'') as 'detail_sku',
isnull(rvl_header_tax.hrt_rmkval,'') as 'header_tax',
isnull(rvl_header_sig.hrt_rmkval,'') as 'header_sig',
isnull(rvl_header_wood.hrt_rmkval,'') as 'inv_ftrmk',  

isnull(rvl_header_air.hrt_rmkval,'') as 'header_air',

isnull(dtl.hid_name_f1,'') as 'dtl.hid_name_f1',
isnull(dtl.hid_dsc_f1,'') as 'dtl.hid_dsc_f1',
isnull(dtl.hid_name_f2,'') as 'dtl.hid_name_f2',
isnull(dtl.hid_dsc_f2,'') as 'dtl.hid_dsc_f2',
isnull(dtl.hid_name_f3,'') as 'dtl.hid_name_f3',
isnull(dtl.hid_dsc_f3,'') as 'dtl.hid_dsc_f3',
  case   when ltrim(hiv_lcno) = '' then ''  else  hiv_lcno end  as 'hiv_lcno',
  hiv_lcbank  as 'hiv_lcbank',
	right('0' + ltrim(rtrim(str(datepart(dd, hiv_lcdat)))), 2) + ' ' +
		case datepart(mm, hiv_lcdat) when 1 then 'Jan' when 2 then
'Feb' when 3 then 'Mar' when 4 then 'Apr' when 5 then 'May'
		when 6 then 'Jun' when 7 then 'Jul' when 8 then 'Aug' when
		9 then 'Sep' when 10 then 'Oct' when 11 then 'Nov' when 12
		then 'Dec' end + ' ' + 
		right(ltrim(rtrim(str(datepart(yyyy, hiv_lcdat)))), 2) as 'hiv_lcdat',


--CONVERT(nVARCHAR(20),hiv_lcdat,106)   as'hiv_lcdat'     ,
pdm.hpd_pdnum as 'hpd_pdnum',         
ROUND(hiv_ttlamt,2) AS 'hiv_ttlamt',
#temp_table_sum_cussku.tmp_sum as 'cbmsum_itmno',
dtl.hid_conftr as 'dtl.hid_conftr',
dtl.hid_cusstyno as 'dtl.hid_cusstyno',
  ltrim(str(pdm.hpd_l_cm,10,2))  as 'dtl.L' ,        
ltrim(str( pdm.hpd_w_cm,10,2))  as 'dtl.W',         
 ltrim(str(pdm.hpd_h_cm,10,2))  as 'dtl.H',         
isnull(hdp_type,'D') as 'hdp_type',
	isnull(hdp_dsc,'') as 'hdp_cde',
	isnull(hdp_amt,0) as 'hdp_amt',
	isnull(hdp_pctamt,0) as 'hdp_pctamt',
	isnull(ltrim(str(hdp_pct,10,2)),'') as 'hdp_pct',
tmp_po.tmp_po as 'tmp_po',
isnull(hiv_exptaddr,'') as 'hiv_exptaddr'

 From  SHIPGHDR hdr    

left join SHRMKVAL rvl_header_resppo
		on rvl_header_resppo.hrt_pricustno =  hdr.hih_cus1no
		and rvl_header_resppo.hrt_rmkdsc= 'Header Respective PO #'
left join SHRMKVAL rvl_header_custpo
		on rvl_header_custpo.hrt_pricustno =  hdr.hih_cus1no
		and Rtrim(Ltrim(rvl_header_custpo.hrt_rmkdsc))= 'Header Customer PO#'
left join SHRMKVAL rvl_detail_cuitm
		on rvl_detail_cuitm.hrt_pricustno =  hdr.hih_cus1no
		and rvl_detail_cuitm.hrt_rmkdsc= 'Detail Customer Item Number'
left join SHRMKVAL rvl_detail_cusku
		on rvl_detail_cusku.hrt_pricustno = hdr.hih_cus1no
		and rvl_detail_cusku.hrt_rmkdsc= 'Detail Cust SKU#'
left join SHRMKVAL rvl_header_tax
		on rvl_header_tax.hrt_pricustno = hdr.hih_cus1no
		and rvl_header_tax.hrt_rmkdsc= 'TAX'
left join SHRMKVAL rvl_header_sig
		on rvl_header_sig.hrt_pricustno = hdr.hih_cus1no
		and rvl_header_sig.hrt_rmkdsc= 'SIG'
left join SHRMKVAL rvl_header_wood
		on rvl_header_wood.hrt_pricustno = hdr.hih_cus1no
		and rvl_header_wood.hrt_rmkdsc= 'WOOD'
left join SHRMKVAL rvl_header_air
		on rvl_header_air.hrt_pricustno = hdr.hih_cus1no
		and rvl_header_air.hrt_rmkdsc= 'AIR'


  left join CUBASINF cus on  --hdr.hih_cocde = cus.cbi_cocde and     
     hdr.hih_cus1no = cus.cbi_cusno    
  left join SYSETINF cty on --hdr.hih_cocde = cty.ysi_cocde and     
     hdr.hih_bilcty = cty.ysi_cde and     
     cty.ysi_typ = '02'    
  ,SHINVHDR inv     
  left join SHIPGDTL dtl on inv.hiv_cocde = @cocde and    
     inv.hiv_shpno = dtl.hid_shpno and     
     inv.hiv_invno = dtl.hid_invno    
left join shpckdim pdm on 
	 pdm.hpd_shpno = dtl.hid_shpno and pdm.hpd_shpseq = dtl.hid_shpseq
		and pdm.hpd_dimtyp = 'Mod'
		and (
			(dtl.hid_ctnftr = 1 and ( pdm.hpd_pdnum = 5 or pdm.hpd_pdnum = 6 )) 
			or (dtl.hid_ctnftr = 2 and ( pdm.hpd_pdnum = 1 or pdm.hpd_pdnum = 2 or pdm.hpd_pdnum = 3 or pdm.hpd_pdnum = 4 ))   
			)

left join #temp_cmp tmp_table on
	tmp_table.tmp_shpno =  dtl.hid_shpno
	and tmp_table.tmp_shpseq = dtl.hid_shpseq
 left join  #temp_po  tmp_po on
	tmp_po.tmp_shpno =  dtl.hid_shpno
	and tmp_po.tmp_mannam = dtl.hid_mannam
-- Added by Mark Lau 20080714, Customer Alias
-- Changed by Mark Lau 20090702
--  left join imcusals ca on  dtl.hid_itmno  = ca.ica_itmno  and ca.ica_apvsts = 'Y' 
 left join SHPCUSSTY ca on  dtl.hid_itmno  = ca.ica_itmno  and ca.ica_apvsts = 'Y' and ca.sod_ordno = dtl.hid_ordno 
and ca.sod_ordseq = dtl.hid_ordseq

  left join SHSHPMRK shm on  
	 shm.hsm_cocde = @cocde and     
     shm.hsm_invno = inv.hiv_invno and     
     shm.hsm_shptyp = 'M'     
  left join SYSETINF prc on --prc.ysi_cocde =@cocde and     
     inv.hiv_prctrm = prc.ysi_cde and     
     prc.ysi_typ = '03'    
  left join SYSETINF pay on --pay.ysi_cocde = @cocde and     
     inv.hiv_paytrm = pay.ysi_cde and     
     pay.ysi_typ = '04'    
  left join SCORDHDR soh on soh.soh_cocde = @cocde and     
     soh.soh_ordno = dtl.hid_ordno     
  left join SCORDDTL sod on  sod.sod_cocde = @cocde and     
     sod.sod_ordno = dtl.hid_ordno and     
     sod.sod_ordseq = dtl.hid_ordseq    
	--Modified by Mark Lau 20080314, move from low section
  left join SYSETINF cde on inv.hiv_cocde = @cocde and
--Edited by Mark Lau 20080616 
     case when isnull(dtl.hid_custum,'') <> '' then dtl.hid_custum else case when isnull(dtl.hid_contopc,'')  = 'Y' then 'PC' else dtl.hid_untcde end end = cde.ysi_cde and     
     cde.ysi_typ = '05'  

left join v_select_inr00001_cusitm_wNewItmNo vw on  
vw.hid_cocde =@cocde and  
--vw.grp = 1 and
 vw.grp = @printgroup and  
vw.hid_invno = inv.hiv_invno  and
dtl.hid_cuspo = vw.hid_cuspo and    
dtl.hid_ordno = vw.hid_ordno and     
dtl.hid_mannam = vw.hid_mannam and     
--dtl.hid_itmno = vw.hid_itmno and     

case when isnull(ca.ica_itmno,'') <> '' then ca.ica_cusalsitm
else case when @printGroup = '1' then dbo.groupnewitmno(dtl.hid_itmno)
else ltrim(rtrim(dtl.hid_itmno)) end end = vw.hid_itmno  and
   
dtl.hid_itmdsc = vw.hid_itmdsc and      
dtl.hid_inrctn = vw.hid_inrctn and     
dtl.hid_mtrctn = vw.hid_mtrctn and 

dtl.hid_selprc = vw.hid_selprc and 
cde.ysi_dsc = vw.ysi_dsc and     
ltrim(str(hpd_gw_kg,10,2)) = vw.hid_grswgt and     
ltrim(str(hpd_nw_kg,10,2)) = vw.hid_netwgt and      
ltrim(str(hpd_l_cm,10,2)) + ' X ' + ltrim(str( hpd_w_cm,10,2)) + ' X ' + ltrim(str(hpd_h_cm,10,2)) = vw.MEAS and  
ltrim( dtl.hid_cusitm) = vw.hid_cusitm and  
-- dtl.hid_ctnftr = vw.hid_ctnftr -- 20150323
--and 
 case when  dtl.hid_ctnftr=2 then    
		dtl.hid_shpseq
	 else   
		vw.hid_shpseq
	 end = vw.hid_shpseq
and  dtl.hid_ctnftr=vw.hid_ctnftr
and vw.hid_invno between @from and @to        
  
  left join POORDDTL on  pod_cocde = @cocde and     
     pod_purord =  dtl.hid_purord and     
     pod_purseq = dtl.hid_purseq    
  
  left join SHASSINF sca on  --sca.hai_cocde =@cocde  and     
     sca.hai_ordno = dtl.hid_ordno and     
     sca.hai_ordseq = dtl.hid_ordseq     
  left join  SYSETINF saa on  --saa.ysi_cocde = @cocde and     
     sca.hai_untcde = saa.ysi_cde and     
     saa.ysi_typ = '05'    

left join #temp_table_sum_cussku 
	on   
		 rtrim(ltrim(dtl.hid_itmno)) =   rtrim(ltrim(#temp_table_sum_cussku.tmp_itmno))
--	and	dtl.hid_ctrcfs = #temp_table_sum_cussku.ctrcfs
	and	 rtrim(ltrim(dtl.hid_invno)) =  rtrim(ltrim(#temp_table_sum_cussku.invno))
--	and       pdm.hpd_pdnum = #temp_table_sum_cussku.tmp_pdnum
LEFT JOIN SHDISPRM ON hdp_invno = hiv_invno and hdp_cocde = hiv_cocde AND hdp_shpno = hiv_shpno and hdp_seqno = 1


 WHERE      
  hdr.hih_shpsts <> 'HLD'    
 and  hdr.hih_cocde = @cocde    
 and hdr.hih_shpno = dtl.hid_shpno    
 and  inv.hiv_invno >= @from and inv.hiv_invno <= @to    
--and ( (hdr.hih_cus1no =  ca.ica_cusno and isnull(ca.ica_cusno,'') <> '') or  isnull(ca.ica_cusno,'') = '')
end  
    

end




















drop table  #temp_cmp
drop table  #temp_table_sum_cussku
drop table #temp_po




























GO
GRANT EXECUTE ON [dbo].[sp_select_INR00001_NET] TO [ERPUSER] AS [dbo]
GO
