/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMPRCINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
















------------------------------------------------- 
CREATE  procedure [dbo].[sp_select_IMPRCINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_cocde nvarchar(6) ,
@imu_itmno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS
begin

select
'' as 'imu_cocde',
imu_itmno,
imu_typ,
imu_ventyp,
imu_venno,
imu_prdven,
imu_pckunt + ' / ' + convert(varchar(10), imu_inrqty) + ' / ' + convert(varchar(10),imu_mtrqty) + ' / ' + convert(varchar(20),imu_cft) as 'imu_packing',
imu_pckunt,
imu_conftr,
imu_inrqty,
imu_mtrqty,
imu_period,
imu_cus1no,
imu_cus2no,
imu_ftyprctrm,
imu_hkprctrm,
imu_trantrm,
imu_effdat,
imu_expdat,
imu_status,
imu_curcde,
imu_ftycstA,
imu_ftycstB,
imu_ftycstC,
imu_ftycstD,
imu_ftycstE,
imu_ftycstTran,
imu_ftycstPack,
imu_ftycst,
imu_fmlA,
imu_fmlB,
imu_fmlC,
imu_fmlD,
imu_fmlE,
imu_fmlTran,
imu_fmlPack,
imu_fml,
imu_chgfpA,
imu_chgfpB,
imu_chgfpC,
imu_chgfpD,
imu_chgfpE,
imu_chgfpTran,
imu_chgfpPack,
imu_chgfp,
imu_ftyprcA,
imu_ftyprcB,
imu_ftyprcC,
imu_ftyprcD,
imu_ftyprcE,
imu_ftyprcTran,
imu_ftyprcPack,
imu_ftyprc,
imu_bomcst,
imu_ttlcst,
imu_hkadjper,
isnull(imu_negcst,0) as 'imu_negcst',
isnull(imu_negprc,0) as 'imu_negprc',
isnull(imu_fmlopt + ' - ' + yfi_fml,'') as 'imu_fmlopt',
case imu_typ when 'BOM' then imu_curcde else imu_bcurcde end as 'imu_bcurcde',
imu_itmprc,
imu_bomprc,
imu_basprc,
imu_sysgen,
imu_estprcflg,
imu_estprcref,
imu_cft,
imu_cstchgdat,
imu_pckunt as 'imu_pckunt_org',
imu_conftr as 'imu_conftr_org',
imu_inrqty as 'imu_inrqty_org',
imu_mtrqty as 'imu_mtrqty_org',
imu_cft as 'imu_cft_org',
imu_cus1no as 'imu_cus1no_org',
imu_cus2no as 'imu_cus2no_org',
imu_ftyprctrm as 'imu_ftyprctrm_org',
imu_hkprctrm as 'imu_hkprctrm_org',
imu_trantrm as 'imu_trantrm_org',
imu_creusr,
imu_updusr,
imu_credat,
imu_upddat,
imu_timstp
from IMPRCINF (nolock)
left join SYFMLINF (nolock) on imu_fmlopt = yfi_fmlopt
where imu_itmno = @imu_itmno
--order by imu_pckunt, imu_conftr, imu_inrqty, imu_mtrqty, imu_cft, imu_ftyprctrm, imu_hkprctrm, imu_trantrm, imu_cus1no, imu_cus2no, imu_venno, imu_prdven
order by imu_pckunt, imu_conftr, imu_inrqty, imu_mtrqty, imu_cft,  imu_cus1no, imu_cus2no, imu_venno, imu_prdven

--order by ipi_pckunt,ipi_conftr,ipi_inrqty,ipi_mtrqty,ipi_cft,ipi_cus1no,ipi_cus2no  

end

GO
GRANT EXECUTE ON [dbo].[sp_select_IMPRCINF] TO [ERPUSER] AS [dbo]
GO
