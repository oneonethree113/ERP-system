/****** Object:  StoredProcedure [dbo].[sp_update_PKORDDTL_PG05]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PKORDDTL_PG05]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PKORDDTL_PG05]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
















------------------------------------------------- 
CREATE PROCEDURE [dbo].[sp_update_PKORDDTL_PG05] 

@cocde  	nvarchar(6),
@ordno	  	nvarchar(20),
@seq		int,
@ordqty	int , 
@In_was	int ,
@In_char	nvarchar(10),
@user nvarchar(30)

AS

declare @bonqty as int
declare @unitprice as numeric(11,6)
declare @stkqty as int
declare @wasqty as int
declare @cate as nvarchar(20)
declare @wasper as int 
declare @unit as nvarchar(20) 
declare @ttlqty as int
declare @ttlamt as numeric(13,4)
declare @currentttlamt as numeric(13,4)
declare @MOA as numeric(13,4)

select @bonqty = pod_bonqty , @unitprice = pod_untprc , @stkqty = pod_stkqty , @cate = pod_cate , @currentttlamt = pod_ttlamtqty,
	@MOA = pod_MOA
from PKORDDTL (NOLOCK) 
where pod_ordno = @ordno and pod_seq = @seq

select @wasqty = isnull(pwa_wasage,0) , @unit = isnull(pwa_um,'') 
from PKWASGE (NOLOCK)
where pwa_code = @cate and  pwa_qtyfrm <= @ordqty and pwa_qtyto >= @ordqty

if @wasqty is null
begin
	set @wasqty = 0
	set @unit = ''
end

--if @In_was <>0 and @In_char = 'Y' 
if @In_char ='Y'
begin
set @bonqty = @In_was
end



if @unit = 'PC'
begin
set @wasper = 0
set @ttlqty = @ordqty + @bonqty + @stkqty
set @ttlamt = @ttlqty * @unitprice
set @ttlamt = cast(@ttlamt as numeric(13,2))
end
else if @unit = '%'
begin
set @wasper = @wasqty
set @wasqty  = Round((@wasqty * @ordqty) / 100,0)
set @ttlqty = @ordqty + @bonqty + @stkqty
set @ttlamt = @ttlqty * @unitprice
set @ttlamt = cast(@ttlamt as numeric(13,2))
end
else
begin
set @wasper = 0
set @wasqty  = 0
set @ttlqty = 0
set @ttlamt = 0
set @ttlamt = 0
end 
 

declare @last_status nvarchar(10)

select @last_status = poh_status from PKORDHDR (nolock) where poh_ordno = @ordno



-- Update latest Packaging Description
declare @upddsc_flag char(1)

select top 1
prd_engdsc, prd_chndsc,prd_remark,
prd_EInchL,prd_EInchW,prd_EInchH,
prd_EcmL,prd_EcmW,prd_EcmH,
prd_FInchL,prd_FInchW,prd_FInchH,
prd_FcmL,prd_FcmW,prd_FcmH,
prd_matral,prd_matDsc,
prd_tiknes,prd_tikDsc,
prd_prtmtd,prd_prtDsc,
prd_clrfot,prd_clrbck,
prd_finish
into #TMP_PKREQDTL_DSC
from PKREQDTL
where prd_ordno = @ordno and prd_ordseq = @seq
order by prd_credat desc

if (select count(*) from #TMP_PKREQDTL_DSC) <> 1
begin
	set @upddsc_flag = 'N'
end
else
begin
	set @upddsc_flag = 'Y'
end



if @upddsc_flag = 'Y'
begin

update PKORDDTL set 
pod_engdsc = prd_engdsc,
pod_chndsc = prd_chndsc,
pod_remark = prd_remark,
pod_EInchL = prd_EInchL,
pod_EInchW = prd_EInchW,
pod_EInchH = prd_EInchH,
pod_EcmL = prd_EcmL,
pod_EcmW = prd_EcmW,
pod_EcmH = prd_EcmH,
pod_FInchL = prd_FInchL,
pod_FInchW = prd_FInchW,
pod_FInchH = prd_FInchH,
pod_FcmL = prd_FcmL,
pod_FcmW = prd_FcmW,
pod_FcmH = prd_FcmH,
pod_matral = prd_matral,
pod_matDsc = prd_matDsc,
pod_tiknes = prd_tiknes,
pod_tikDsc = prd_tikDsc,
pod_prtmtd = prd_prtmtd,
pod_prtDsc = prd_prtDsc,
pod_clrfot = prd_clrfot,
pod_clrbck = prd_clrbck,
pod_finish = prd_finish,
pod_updusr = @user,
pod_upddat = getdate()
from PKORDDTL,#TMP_PKREQDTL_DSC
where pod_ordno = @ordno and pod_seq = @seq


end




--if @In_was <>0 and @In_char = 'Y' 
if @In_char ='Y'
begin
update PKORDDTL set 
pod_ordqty = @ordqty , 
pod_wasper = @wasper,
pod_wasqty = @wasqty,
pod_ttlordqty = @ttlqty,
pod_ttlamtqty = @ttlamt ,
pod_InWas = @In_char,
pod_bonqty = @In_was,
pod_status = 'OPE',
pod_updusr = @user,
pod_upddat = getdate()
where pod_ordno = @ordno and pod_seq = @seq
end 
else
begin
update PKORDDTL set 
pod_ordqty = @ordqty , 
pod_wasper = @wasper,
pod_wasqty = @wasqty,
pod_ttlordqty = @ttlqty,
pod_ttlamtqty = @ttlamt ,
pod_InWas = @In_char,
pod_status = 'OPE',
pod_updusr = @user,
pod_upddat = getdate()
where pod_ordno = @ordno and pod_seq = @seq
end

if @MOA=0 
begin
update PKORDHDR set 
poh_ttlamt = isnull(cast(poh_ttlamt - @currentttlamt + @ttlamt as numeric(13,2)),0),
poh_status = 'OPE',
poh_updusr = @user ,
poh_upddat = getdate()
where poh_ordno = @ordno
end
else
begin
update PKORDHDR set 
poh_status = 'OPE',
poh_updusr = @user ,
poh_upddat = getdate()
where poh_ordno = @ordno
end




declare @cTtlamt  as numeric(13,4)
declare @ttldis as numeric(13,4)
declare @ttlpre as numeric(13,4)

select @cTtlamt = cast(poh_Delamt + poh_ttlamt as numeric(13,2))
from pkordhdr(nolock) where poh_ordno = @ordno

update pkdisprm set
pdp_amt = round(@cTTlamt * pdp_pct / 100 , 2)
where pdp_ordno = @ordno  and pdp_pctamt = 'Percentage'

select @ttldis = isnull(sum(pdp_amt),0) from pkdisprm(nolock) where pdp_ordno = @ordno and pdp_type = 'D'
select @ttlpre = isnull(sum(pdp_amt),0) from pkdisprm(nolock) where pdp_ordno = @ordno and pdp_type = 'P'


update PKORDHDR set 
poh_TtlDelamt = @cTtlamt + @ttlpre - @ttldis
where poh_ordno = @ordno


if @last_status = 'APV'
begin

update PKORDHDR set 
poh_ver = poh_ver + 1,
poh_updusr = @user ,
poh_upddat = getdate()
where poh_ordno = @ordno

end



drop table #TMP_PKREQDTL_DSC








GO
GRANT EXECUTE ON [dbo].[sp_update_PKORDDTL_PG05] TO [ERPUSER] AS [dbo]
GO
