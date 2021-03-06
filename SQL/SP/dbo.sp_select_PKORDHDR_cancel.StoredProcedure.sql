/****** Object:  StoredProcedure [dbo].[sp_select_PKORDHDR_cancel]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKORDHDR_cancel]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKORDHDR_cancel]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE procedure [dbo].[sp_select_PKORDHDR_cancel]
@poh_cocde nvarchar(6),
@poh_ordno nvarchar(20),
@poh_creusr nvarchar(30)

as

declare @upddat datetime
set @upddat = getdate()
-- 1. PKORDHDR status CANCEL
--select * from PKORDHDR
update PKORDHDR set poh_Delamt = 0 , poh_TtlDelamt = 0 , poh_status='CAN', poh_updusr=left('C-'+ @poh_creusr,30), poh_upddat=@upddat where poh_cocde = @poh_cocde and poh_ordno = @poh_ordno

-- 2. Reset PKINVDTL and PKINVHDR value
update PKINVDTL set pid_ordqty=0, pid_stkqty=0, pid_wgeqty=0, pid_ttlqty=0, pid_updusr=left('C-'+ @poh_creusr,30), pid_upddat=@upddat from PKORDDTL, PKINVDTL where pod_ordno = pid_ordno and pod_ordno = @poh_ordno  and pid_latest = 'Y'

select pih_pkgitm as 'pkgitm',sum(c.pid_stkqty) as 'stkqty' into #TEMP_STKQTY from PKORDDTL a,PKINVHDR b,PKINVDTL c where a.pod_pkgitm = b.pih_pkgitm and b.pih_pkgitm = c.pid_pkgitm and c.pid_latest = 'Y' and a.pod_ordno = @poh_ordno
group by pih_pkgitm

--update PKINVHDR set pih_avlqty = sum(c.pid_stkqty), pih_updusr=left('C-'+ @poh_creusr,30), pih_upddat=@upddat from PKORDDTL a,PKINVHDR b,PKINVDTL c where a.pod_pkgitm = b.pih_pkgitm and b.pih_pkgitm = c.pid_pkgitm and c.pid_latest = 'Y' and a.pod_ordno = @poh_ordno
update PKINVHDR set pih_avlqty=stkqty, pih_updusr=left('C-'+ @poh_creusr,30), pih_upddat=@upddat from PKINVHDR, #TEMP_STKQTY where pih_pkgitm = pkgitm

drop table #TEMP_STKQTY
-- 3. PKORDDTL qty = 0
--select * from PKORDDTL
update PKORDDTL set pod_status='CAN', pod_ordqty=0, pod_stkqty=0, pod_wasper=0, pod_ttlordqty=0, pod_untprc=0, pod_ttlamtqty=0, pod_reqno='', pod_reqseq=0, pod_updusr=left('C-'+ @poh_creusr,30), pod_upddat=@upddat , pod_moa = 0  where pod_cocde = @poh_cocde and pod_ordno = @poh_ordno

-- 4. PKREQDTL remove PO link
update PKREQDTL set prd_ordno='', prd_ordseq=0, prd_updusr=left('C-'+ @poh_creusr,30), prd_upddat=@upddat where prd_cocde = @poh_cocde and prd_ordno = @poh_ordno


--5. Delete Discount and Preium
Delete from pkdisprm where pdp_cocde = @poh_cocde and pdp_ordno = @poh_ordno




















GO
GRANT EXECUTE ON [dbo].[sp_select_PKORDHDR_cancel] TO [ERPUSER] AS [dbo]
GO
