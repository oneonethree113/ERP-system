/****** Object:  StoredProcedure [dbo].[sp_select_PO_IMPORTSAP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PO_IMPORTSAP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PO_IMPORTSAP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO











CREATE    PROCEDURE [dbo].[sp_select_PO_IMPORTSAP]
@cocde nvarchar(6),
@initdata nvarchar(1)
 
AS
BEGIN

if @initdata = 'X'
	begin
		select
		case when pod_jobord <> '' then pod_jobord else pod_scno + '-' + cast(pod_scline as nvarchar) end as zpod_jobord,
		poh_cocde as zcompcode,
		(replicate('0', 10-len(coalesce(v.ysi_sapcde, sod_cusven, v.ysi_sapcde))) + rtrim(coalesce(v.ysi_sapcde, sod_cusven, v.ysi_sapcde))) as zlifnr,
		(replicate('0', 10-len(soh_cus1no)) + rtrim(soh_cus1no)) as pri_kunnr,
		pri.cbi_cussna as pri_kunnr_sna,
		case when soh_cus2no = '' then soh_cus2no else (replicate('0', 10-len(soh_cus2no)) + rtrim(soh_cus2no)) end as sec_kunnr,
		isnull(sec.cbi_cussna,'') as sec_kunnr_sna,
		poh_pursts as zpoh_pursts,
		soh_ordsts as zsoh_ordsts,
		poh_cuspno as zpoh_cuspno,
		convert(nvarchar(8), poh_cpodat ,112) as zpoh_cpodat,
		pod_purord as zpod_purord,
		pod_purseq as zpod_purseq,
		pod_scno as zpod_scno,
		pod_scline as zpod_scline,
		sod_zorvbeln as zsod_zorvbeln,
		sod_zorposnr as zsod_zorposnr,
		case when pod_runno <> '' then pod_runno else pod_purord + '-' + cast(pod_purseq as nvarchar) end as zpod_runno,
		rtrim(pod_itmno) as zpod_itmno,
		rtrim(ibi_engdsc) as zibi_engdsc,
		rtrim(ibi_chndsc) as zibi_chndsc,
		ibi_lnecde as zibi_lnecde,
		pod_venitm as zpod_venitm,
		pod_cusitm as zpod_cusitm,
		sod_ordqty as zsod_ordqty,
		sod_shpqty as zsod_shpqty,
		sod_invqty as zsod_invqty,
		pod_untcde as zpod_untcde,
		isnull(ysi_dsc,'') as zpod_untdsc,
		convert(nvarchar(8), sod_shpstr ,112) as zsod_shpstr,
		convert(nvarchar(8), sod_shpend ,112) as zsod_shpend,
		sod_dv as zsod_dv,
		dv.vbi_vensna as zsod_dv_sna,
		sod_cusven as zsod_cusven,
		cv.vbi_vensna as zsod_cusven_sna,
		sod_venno as zsod_venno,
		pv.vbi_vensna as zsod_venno_sna
		from
		poorddtl (nolock)
		inner join scorddtl (nolock) on sod_cocde = pod_cocde and sod_ordno = pod_scno and sod_ordseq = pod_scline
		inner join scordhdr (nolock) on soh_ordno = sod_ordno and soh_cocde = sod_cocde
		inner join poordhdr (nolock) on poh_purord = pod_purord and poh_cocde = pod_cocde
		left join imbasinf (nolock) on pod_itmno = ibi_itmno
		left join vnbasinf (nolock) on sod_cusven = vbi_venno
		left join (
			select vbi_venno,isnull(ysi_sapcde,0) as ysi_sapcde from vnbasinf (nolock)
			left join sysetinf (nolock) on vbi_venno = ysi_cde and ysi_typ = '23'
			where vbi_ventyp in ('I', 'J')) as v
			on sod_cusven =  v.vbi_venno
		left join sysetinf (nolock) on pod_untcde = ysi_cde and ysi_typ = '05'
		left join cubasinf as pri on soh_cus1no = pri.cbi_cusno
		left join cubasinf as sec on soh_cus2no = sec.cbi_cusno
		left join vnbasinf as dv on sod_dv = dv.vbi_venno 
		left join vnbasinf as cv on sod_cusven = cv.vbi_venno 
		left join vnbasinf as pv on sod_venno  = pv.vbi_venno 
		where
		(poh_credat >= '2009/01/01')
		order by pod_purord, pod_purseq
	end
else
	begin
		select
		case when pod_jobord <> '' then pod_jobord else pod_scno + '-' + cast(pod_scline as nvarchar) end as zpod_jobord,
		poh_cocde as zcompcode,
		(replicate('0', 10-len(coalesce(v.ysi_sapcde, sod_cusven, v.ysi_sapcde))) + rtrim(coalesce(v.ysi_sapcde, sod_cusven, v.ysi_sapcde))) as zlifnr,
		(replicate('0', 10-len(soh_cus1no)) + rtrim(soh_cus1no)) as pri_kunnr,
		pri.cbi_cussna as pri_kunnr_sna,
		case when soh_cus2no = '' then soh_cus2no else (replicate('0', 10-len(soh_cus2no)) + rtrim(soh_cus2no)) end as sec_kunnr,
		isnull(sec.cbi_cussna,'') as sec_kunnr_sna,
		poh_pursts as zpoh_pursts,
		soh_ordsts as zsoh_ordsts,
		poh_cuspno as zpoh_cuspno,
		convert(nvarchar(8), poh_cpodat ,112) as zpoh_cpodat,
		pod_purord as zpod_purord,
		pod_purseq as zpod_purseq,
		pod_scno as zpod_scno,
		pod_scline as zpod_scline,
		sod_zorvbeln as zsod_zorvbeln,
		sod_zorposnr as zsod_zorposnr,
		case when pod_runno <> '' then pod_runno else pod_purord + '-' + cast(pod_purseq as nvarchar) end as zpod_runno,
		rtrim(pod_itmno) as zpod_itmno,
		rtrim(ibi_engdsc) as zibi_engdsc,
		rtrim(ibi_chndsc) as zibi_chndsc,
		ibi_lnecde as zibi_lnecde,
		pod_venitm as zpod_venitm,
		pod_cusitm as zpod_cusitm,
		sod_ordqty as zsod_ordqty,
		sod_shpqty as zsod_shpqty,
		sod_invqty as zsod_invqty,
		pod_untcde as zpod_untcde,
		isnull(ysi_dsc,'') as zpod_untdsc,
		convert(nvarchar(8), sod_shpstr ,112) as zsod_shpstr,
		convert(nvarchar(8), sod_shpend ,112) as zsod_shpend,
		sod_dv as zsod_dv,
		dv.vbi_vensna as zsod_dv_sna,
		sod_cusven as zsod_cusven,
		cv.vbi_vensna as zsod_cusven_sna,
		sod_venno as zsod_venno,
		pv.vbi_vensna as zsod_venno_sna
		from
		poorddtl (nolock)
		inner join scorddtl (nolock) on sod_cocde = pod_cocde and sod_ordno = pod_scno and sod_ordseq = pod_scline
		inner join scordhdr (nolock) on soh_ordno = sod_ordno and soh_cocde = sod_cocde
		inner join poordhdr (nolock) on poh_purord = pod_purord and poh_cocde = pod_cocde
		left join imbasinf (nolock) on pod_itmno = ibi_itmno
		left join vnbasinf (nolock) on sod_cusven = vbi_venno
		left join (
			select vbi_venno,isnull(ysi_sapcde,0) as ysi_sapcde from vnbasinf (nolock)
			left join sysetinf (nolock) on vbi_venno = ysi_cde and ysi_typ = '23'
			where vbi_ventyp in ('I', 'J')) as v
			on sod_cusven =  v.vbi_venno
		left join sysetinf (nolock) on pod_untcde = ysi_cde and ysi_typ = '05'
		left join cubasinf as pri on soh_cus1no = pri.cbi_cusno
		left join cubasinf as sec on soh_cus2no = sec.cbi_cusno
		left join vnbasinf as dv on sod_dv = dv.vbi_venno 
		left join vnbasinf as cv on sod_cusven = cv.vbi_venno 
		left join vnbasinf as pv on sod_venno  = pv.vbi_venno 
		where 
		(convert(nvarchar(10),pod_upddat,111) = convert(nvarchar(10),getdate() ,111) or convert(nvarchar(10),sod_upddat,111) = convert(nvarchar(10),getdate() ,111))
		order by pod_purord, pod_purseq
	end
END












GO
GRANT EXECUTE ON [dbo].[sp_select_PO_IMPORTSAP] TO [ERPUSER] AS [dbo]
GO
