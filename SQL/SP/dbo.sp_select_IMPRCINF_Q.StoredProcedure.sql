/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF_Q]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMPRCINF_Q]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF_Q]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







------------------------------------------------- 
CREATE   procedure [dbo].[sp_select_IMPRCINF_Q]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_cocde nvarchar(6) ,
@imu_itmno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS
begin

select
imu_cocde,
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
imu_cft,
imu_cus1no,
imu_cus2no,
imu_ftyprctrm,
imu_hkprctrm,
imu_trantrm,
imu_effdat,
imu_expdat,
imu_status,
imu_curcde,
imu_ftycst,
imu_ftycstA,
imu_ftycstB,
imu_ftycstC,
imu_ftycstD,
imu_ftycstTran,
imu_ftycstPack,
imu_fmlA,
imu_fmlB,
imu_fmlC,
imu_fmlD,
imu_fmlTran,
imu_fmlPack,
imu_ftyprc,
imu_ftyprcA,
imu_ftyprcB,
imu_ftyprcC,
imu_ftyprcD,
imu_ftyprcTran,
imu_ftyprcPack,
imu_bomcst,
imu_ttlcst,
imu_hkadjper,
imu_negcst,
imu_fmlopt,
imu_bcurcde,
imu_itmprc,
imu_bomprc,
imu_basprc,
imu_period,
imu_cstchgdat
from	IMVENINF, IMPRCINF
where	ivi_itmno = @imu_itmno				and
	ivi_def = 'Y'					and 
	ivi_venno = imu_prdven				and
	ivi_itmno = imu_itmno				 and
	imu_status = 'ACT'				--	and
--	imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--	imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)
order by imu_pckunt, imu_inrqty, imu_mtrqty, imu_cus1no, imu_cus2no, imu_ftyprctrm,imu_hkprctrm,imu_trantrm,imu_effdat,imu_expdat


end








GO
GRANT EXECUTE ON [dbo].[sp_select_IMPRCINF_Q] TO [ERPUSER] AS [dbo]
GO
