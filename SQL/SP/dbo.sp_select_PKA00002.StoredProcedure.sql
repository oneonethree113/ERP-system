/****** Object:  StoredProcedure [dbo].[sp_select_PKA00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKA00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKA00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_select_PKA00002] 
@cocde		nvarchar(6) , 
@poh_ordno	nvarchar(20)

AS    
BEGIN    


create table #TEMP_REQ (tmp_ordno nvarchar(20),
				tmp_ordseq int,
				tmp_sumwas int) on [PRIMARY]

------------------------------------------------ Reprint Order
declare @reprint_list nvarchar(500)
declare @tmp_reprint nvarchar(100)
set @reprint_list = ''
set @tmp_reprint = ''

declare cur_reprintorder cursor
for 
select distinct pro_repord
from PKREPORD(nolock)
where  pro_ordno = @poh_ordno

open cur_reprintorder 
fetch next from cur_reprintorder into @tmp_reprint

while @@fetch_status = 0
begin

if @tmp_reprint <> ''
begin
set @reprint_list = @reprint_list + @tmp_reprint + ','
end

fetch next from cur_reprintorder into @tmp_reprint
end

close cur_reprintorder
deallocate cur_reprintorder

if @reprint_list <>''
	begin
	set @reprint_list =  LEFT(@reprint_list, LEN(@reprint_list) - 1)
	end 

---------------------------------------------

insert into #TEMP_REQ
select prd_ordno,prd_ordseq,sum(prd_bonqty) from pkreqdtl(nolock) where prd_ordno = @poh_ordno
group by prd_ordno, prd_ordseq

----------------------------------------------

select	
distinct
poh_cocde,
isnull(yco_conam, '') as 'yco_conam',
poh_ordno,
poh_pkgven,
isnull(prt.vbi_vensna,'') as 'prt_vbi_vensna',
poh_issdat,
poh_revdat,
poh_status,
poh_iremark as 'poh_dremark',
poh_shpstr,
poh_shpend,
poh_fty,
isnull(fty.vbi_vensna,'') as 'fty_vbi_vensna',
pod_curcde,
poh_ttlamt,
poh_Delamt,
poh_TtlDelamt,
pod_seq,
pod_pkgitm,
pod_engdsc,
pod_status,
pod_ordqty,
pod_stkqty,
pod_wasqty,
pod_bonqty,
pod_ttlordqty,
pod_qtyum as 'um',
pod_untprc,
pod_ttlamtqty,
isnull(prd_reqno,'') as 'prd_reqno',
isnull(prd_seq,0) as 'prd_seq',
isnull(prd_ScToNo,'') as 'prd_ScToNo',
isnull(prd_ScToSeq,0) as 'prd_ScToSeq',
isnull(soh_cus1no,isnull(toh_cus1no,'')) as 'soh_cus1no',
isnull(pri.cbi_cussna,isnull(pri2.cbi_cussna,'')) as 'pri_cbi_cussna', 
isnull(soh_cus2no,isnull(toh_cus2no,'')) as 'soh_cus2no',
isnull(sec.cbi_cussna,isnull(sec2.cbi_cussna,'')) as 'sec_cbi_cussna',
case substring(prd_ScToNo,1,1) when 'T' then  isnull(tod_ftyitmno,'') else isnull(sod_itmno,'') end as 'sod_itmno',
case substring(prd_ScToNo,1,1) when 'T' then
isnull(tod_pckunt + ' / ' + convert(nvarchar(10),tod_inrqty) + ' / ' + convert(nvarchar(10),tod_mtrqty),'')
else
isnull(sod_pckunt + ' / ' + convert(nvarchar(10),sod_inrctn) + ' / ' + convert(nvarchar(10),sod_mtrctn),'')  end as 'packing',
case substring(prd_ScToNo,1,1) when 'T' then isnull(tod_projqty,0) else isnull(sod_ordqty,0) end as 'sod_ordqty',
case substring(prd_ScToNo,1,1) when 'T' then isnull(tod_pckunt,'') else isnull(sod_pckunt,'') end as 'sod_pckunt',
isnull(prd_ttlordqty,0) as 'prd_ttlordqty',
'PC' as 'requm',
isnull(peh_price,0) as 'peh_price',
isnull(peh_curcde,'') as 'peh_curcde',
poh_ver,
@reprint_list as 'pro_repord',
pod_InWas,
tmp_sumwas,
case pod_moa when 0 then pod_ttlamtqty else pod_moa end as 'pod_ttlmoa' 


from	PKORDHDR (nolock)
left join SYCOMINF (nolock) on	yco_cocde = poh_cocde
left join PKORDDTL (nolock) on 	poh_ordno = pod_ordno
left join PKREQDTL (nolock) on 	pod_ordno = prd_ordno and pod_seq = prd_ordseq
left join SCORDDTL (nolock) on 	prd_ScToNo = sod_ordno and prd_ScToSeq = sod_ordseq
left join SCORDHDR (nolock) on 	sod_cocde = soh_cocde and sod_ordno = soh_ordno
left join TOORDDTL (nolock) on 	prd_ScToNo = tod_toordno and prd_ScToSeq = tod_toordseq and tod_latest = 'Y'
left join TOORDHDR (nolock) on 	tod_cocde = toh_cocde and tod_toordno = toh_toordno
left join CUBASINF pri (nolock) on pri.cbi_cusno = soh_cus1no
left join CUBASINF sec (nolock) on sec.cbi_cusno = soh_cus2no
left join CUBASINF pri2 (nolock) on pri2.cbi_cusno = toh_cus1no
left join CUBASINF sec2 (nolock) on sec2.cbi_cusno = toh_cus2no
left join VNBASINF prt (nolock) on poh_pkgven = prt.vbi_venno
left join VNBASINF fty (nolock) on fty.vbi_venno = poh_fty
left join PKESHDR(nolock) on peh_reqno = prd_reqno and peh_itemno = prd_itemno and  peh_assitm =prd_assitm and 
				peh_tmpitmno = prd_tmpitmno and  peh_venno = prd_venno and  
				peh_venitm = prd_venitm  and  peh_colcde = prd_colcde 
left join #TEMP_REQ (nolock) on pod_ordno = tmp_ordno and pod_seq = tmp_ordseq
where	poh_ordno = @poh_ordno and poh_cocde = @cocde
--order by poh_ordno, pod_seq, prd_reqno, prd_seq




drop table #TEMP_REQ

END








GO
GRANT EXECUTE ON [dbo].[sp_select_PKA00002] TO [ERPUSER] AS [dbo]
GO
