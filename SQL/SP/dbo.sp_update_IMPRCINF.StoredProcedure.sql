/****** Object:  StoredProcedure [dbo].[sp_update_IMPRCINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMPRCINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMPRCINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
















------------------------------------------------- 
CREATE   procedure [dbo].[sp_update_IMPRCINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_cocde nvarchar(6),
@imu_itmno nvarchar(20),
@imu_typ nvarchar(4),
@imu_ventyp nvarchar(4),
@imu_venno nvarchar(6),
@imu_prdven nvarchar(6),
@imu_pckunt nvarchar(6),
@imu_conftr int,
@imu_inrqty int,
@imu_mtrqty int,
@imu_cft numeric(11, 4),
@imu_cus1no nvarchar(6),
@imu_cus2no nvarchar(6),
@imu_ftyprctrm nvarchar(10),
@imu_hkprctrm nvarchar(10),
@imu_trantrm nvarchar(10),
@imu_effdat datetime,
@imu_expdat datetime,
@imu_status nvarchar(6),
@imu_curcde nvarchar(6),
@imu_ftycst numeric(13, 4),
@imu_ftycstA numeric(13, 4),
@imu_ftycstB numeric(13, 4),
@imu_ftycstC numeric(13, 4),
@imu_ftycstD numeric(13, 4),
@imu_ftycstE numeric(13, 4),
@imu_ftycstTran numeric(13, 4),
@imu_ftycstPack numeric(13, 4),
@imu_fml nvarchar(5),
@imu_fmlA nvarchar(5),
@imu_fmlB nvarchar(5),
@imu_fmlC nvarchar(5),
@imu_fmlD nvarchar(5),
@imu_fmlE nvarchar(5),
@imu_fmlTran nvarchar(5),
@imu_fmlPack nvarchar(5),
@imu_chgfp numeric(13, 4),
@imu_chgfpA numeric(13, 4),
@imu_chgfpB numeric(13, 4),
@imu_chgfpC numeric(13, 4),
@imu_chgfpD numeric(13, 4),
@imu_chgfpE numeric(13, 4),
@imu_chgfpTran numeric(13, 4),
@imu_chgfpPack numeric(13, 4),
@imu_ftyprc numeric(13, 4),
@imu_ftyprcA numeric(13, 4),
@imu_ftyprcB numeric(13, 4),
@imu_ftyprcC numeric(13, 4),
@imu_ftyprcD numeric(13, 4),
@imu_ftyprcE numeric(13, 4),
@imu_ftyprcTran numeric(13, 4),
@imu_ftyprcPack numeric(13, 4),
@imu_bomcst numeric(13, 4),
@imu_ttlcst numeric(13, 4),
@imu_hkadjper numeric(13, 4),
@imu_negcst numeric(13, 4),
@imu_negprc numeric(13, 4),
@imu_fmlopt nvarchar(5),
@imu_bcurcde nvarchar(6),
@imu_itmprc numeric(13, 4),
@imu_bomprc numeric(13, 4),
@imu_basprc numeric(13, 4),
@imu_estprcflg char(1),
@imu_estprcref nvarchar(50),
@imu_period nvarchar(10),
@imu_cstchgdat datetime,
@imu_pckunt_org nvarchar(6),
@imu_conftr_org int,
@imu_inrqty_org int,
@imu_mtrqty_org int,
@imu_cft_org numeric(11, 4),
@imu_cus1no_org nvarchar(6),
@imu_cus2no_org nvarchar(6),
@imu_ftyprctrm_org nvarchar(10),
@imu_hkprctrm_org nvarchar(10),
@imu_trantrm_org nvarchar(10),
@imu_updusr nvarchar(30)
                     
---------------------------------------------- 
 
AS
begin

-- David Yue	2012-09-17	Changed expiry date to 11:59:99PM of the specified date
declare @expdat datetime
set @expdat = dateadd(millisecond,86340990,@imu_expdat)

update IMPRCINF
set 
imu_cft = @imu_cft,
imu_cus1no = @imu_cus1no,
imu_cus2no = @imu_cus2no,
imu_ftyprctrm = @imu_ftyprctrm,
imu_hkprctrm = @imu_hkprctrm,
imu_trantrm = @imu_trantrm,
imu_effdat = @imu_effdat,
-- David Yue	2012-09-17	Changed expiry date to 11:59:99PM of the specified date
imu_expdat = @expdat,
imu_status = @imu_status,
imu_curcde = @imu_curcde,
imu_ftycst = @imu_ftycst,
imu_ftycstA = @imu_ftycstA,
imu_ftycstB = @imu_ftycstB,
imu_ftycstC = @imu_ftycstC,
imu_ftycstD = @imu_ftycstD,
imu_ftycstE = @imu_ftycstE,
imu_ftycstTran = @imu_ftycstTran,
imu_ftycstPack = @imu_ftycstPack,
imu_fml = @imu_fml,
imu_fmlA = @imu_fmlA,
imu_fmlB = @imu_fmlB,
imu_fmlC = @imu_fmlC,
imu_fmlD = @imu_fmlD,
imu_fmlE = @imu_fmlE,
imu_fmlTran = @imu_fmlTran,
imu_fmlPack = @imu_fmlPack,
imu_chgfp = @imu_chgfp,
imu_chgfpA = @imu_chgfpA,
imu_chgfpB = @imu_chgfpB,
imu_chgfpC = @imu_chgfpC,
imu_chgfpD = @imu_chgfpD,
imu_chgfpE = @imu_chgfpE,
imu_chgfpTran = @imu_chgfpTran,
imu_chgfpPack = @imu_chgfpPack,
imu_ftyprc = @imu_ftyprc,
imu_ftyprcA = @imu_ftyprcA,
imu_ftyprcB = @imu_ftyprcB,
imu_ftyprcC = @imu_ftyprcC,
imu_ftyprcD = @imu_ftyprcD,
imu_ftyprcE = @imu_ftyprcE,
imu_ftyprcTran = @imu_ftyprcTran,
imu_ftyprcPack = @imu_ftyprcPack,
imu_bomcst = @imu_bomcst,
imu_ttlcst = @imu_ttlcst,
imu_hkadjper = @imu_hkadjper,
imu_negcst = @imu_negcst,
imu_negprc = @imu_negprc,
imu_fmlopt = @imu_fmlopt,
imu_bcurcde = @imu_bcurcde,
imu_itmprc = @imu_itmprc,
imu_bomprc = @imu_bomprc,
imu_basprc = @imu_basprc,
imu_period = @imu_period,
imu_sysgen = 'N',
imu_estprcflg = @imu_estprcflg,
imu_estprcref = @imu_estprcref,
imu_cstchgdat = @imu_cstchgdat,
imu_updusr = @imu_updusr,
imu_upddat = getdate()
from IMPRCINF (nolock)
where imu_itmno = @imu_itmno
and imu_venno = @imu_venno
and imu_prdven = @imu_prdven
and imu_pckunt = @imu_pckunt_org
and imu_conftr = @imu_conftr_org
and imu_inrqty = @imu_inrqty_org
and imu_mtrqty = @imu_mtrqty_org
and imu_cft = @imu_cft_org
and imu_cus1no = @imu_cus1no_org
and imu_cus2no = @imu_cus2no_org
and imu_ftyprctrm = @imu_ftyprctrm_org
and imu_hkprctrm = @imu_hkprctrm_org
and imu_trantrm = @imu_trantrm_org

end








GO
GRANT EXECUTE ON [dbo].[sp_update_IMPRCINF] TO [ERPUSER] AS [dbo]
GO
