/****** Object:  StoredProcedure [dbo].[sp_list_SYCATCDE_CUM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYCATCDE_CUM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYCATCDE_CUM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_list_SYCATCDE_CUM00001] 

@ycc_cocde 	nvarchar(6),
@ycc_level		int
AS

--declare @ycc_timstp int

--Set  @ycc_timstp = (Select max(cast(ycc_timstp as int)) from SYCATCDE_CUM00001 where ycc_cocde = @ycc_cocde)

Select distinct
--ycc_creusr as 'ycc_status',
--ycc_cocde
--ycc_level,
ycc_catcde
--ycc_creusr,
--ycc_updusr,
--ycc_credat,
--ycc_upddat,
--@ycc_timstp as ycc_timstp

from SYCATCDE
where --ycc_cocde = @ycc_cocde and 
ycc_level = @ycc_level








GO
GRANT EXECUTE ON [dbo].[sp_list_SYCATCDE_CUM00001] TO [ERPUSER] AS [dbo]
GO
