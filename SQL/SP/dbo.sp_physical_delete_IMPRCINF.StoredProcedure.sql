/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_IMPRCINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_IMPRCINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












------------------------------------------------- 
CREATE procedure [dbo].[sp_physical_delete_IMPRCINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_cocde nvarchar(6),
@imu_itmno nvarchar(20),
@imu_venno nvarchar(6),
@imu_prdven nvarchar(6),
@imu_pckunt nvarchar(6),
@imu_inrqty int,
@imu_mtrqty int,
@imu_cus1no nvarchar(6),
@imu_cus2no nvarchar(6),
@imu_ftyprctrm nvarchar(10),
@imu_hkprctrm nvarchar(10),
@imu_trantrm nvarchar(10)
                     
---------------------------------------------- 
 
AS
begin

delete IMPRCINF
where imu_itmno = @imu_itmno
and imu_venno = @imu_venno
and imu_prdven = @imu_prdven
and imu_pckunt = @imu_pckunt
and imu_inrqty = @imu_inrqty
and imu_mtrqty = @imu_mtrqty
and imu_cus1no = @imu_cus1no
and imu_cus2no = @imu_cus2no
and imu_ftyprctrm = @imu_ftyprctrm
and imu_hkprctrm = @imu_hkprctrm
and imu_trantrm = @imu_trantrm

end



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_IMPRCINF] TO [ERPUSER] AS [dbo]
GO
