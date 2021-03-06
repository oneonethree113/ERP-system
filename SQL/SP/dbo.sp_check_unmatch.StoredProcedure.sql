/****** Object:  StoredProcedure [dbo].[sp_check_unmatch]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_check_unmatch]
GO
/****** Object:  StoredProcedure [dbo].[sp_check_unmatch]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003


CREATE procedure [dbo].[sp_check_unmatch]
@module	nvarchar(2)
as
If @module = 'SC'
begin
	select	sod_cocde,
		'SC No' = sod_ordno,
		sod_ordseq,
		'PO No' = isnull(poh_purord,''),
		sod_venno,
		'PO Vendor' =  isnull(poh_venno,''),
		sod_itmno,
		'PO Item No' = isnull(pod_itmno, ''),
		sod_venitm,
		'PO Vendor Item' = isnull(pod_venitm,''),
		'SC Packing' = sod_pckunt + '/ ' + ltrim(str(sod_inrctn)) + '/' + ltrim(str(sod_mtrctn)) + '/' + ltrim(str(sod_cft,2)),
		'PO Packing' = pod_untcde + '/ ' + ltrim(str(pod_inrctn)) + '/' + ltrim(str(pod_mtrctn)) + '/' + ltrim(str(pod_cubcft,2))
	from	SCORDDTL
		left join POORDHDR on poh_cocde =  sod_cocde  and poh_purord = sod_purord
		left join POORDDTL on sod_cocde = pod_cocde and sod_purord = pod_purord and sod_purseq = pod_purseq
	where	sod_purord <> ''
	and	(sod_venno <> poh_venno or sod_itmno <> isnull(pod_itmno, '') or sod_venitm <> isnull(pod_venitm,'')
	or	sod_pckunt + '/ ' + ltrim(str(sod_inrctn)) + '/' + ltrim(str(sod_mtrctn)) + '/' + ltrim(str(sod_cft,2)) <> 
		pod_untcde + '/ ' + ltrim(str(pod_inrctn)) + '/' + ltrim(str(pod_mtrctn)) + '/' + ltrim(str(pod_cubcft,2)))
	order by	sod_cocde, sod_ordno, poh_purord
end



GO
GRANT EXECUTE ON [dbo].[sp_check_unmatch] TO [ERPUSER] AS [dbo]
GO
