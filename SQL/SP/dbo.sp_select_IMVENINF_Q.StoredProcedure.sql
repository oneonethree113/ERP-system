/****** Object:  StoredProcedure [dbo].[sp_select_IMVENINF_Q]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMVENINF_Q]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMVENINF_Q]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE   PROCEDURE [dbo].[sp_select_IMVENINF_Q] 
                                                                                                                                                                                                                                                                 
@itr_cocde		nvarchar(6),
@ivi_venitm		nvarchar(20),
@ivi_venno		nvarchar(20),
@imu_cus1no	nvarchar(6),
@imu_cus2no	nvarchar(6)
 
AS
begin

select distinct
	'' as 'Conv',
	'' as 'ID',
	ivi_itmno as itr_itmno,
	icf_colcde as 'itr_color',
	imu_pckunt,
	imu_inrqty,
	imu_mtrqty,
	imu_cft,
	imu_ftyprctrm,
	imu_hkprctrm,
	imu_trantrm,
	cast(imu_pckunt as nvarchar) + ' / ' +
	cast(imu_inrqty as nvarchar) + ' / ' +
	cast(imu_mtrqty as nvarchar) + ' / ' +
	cast(imu_cft as nvarchar) + ' / ' +
	cast(imu_ftyprctrm as nvarchar) + ' / ' +
	cast(imu_hkprctrm as nvarchar) + ' / ' +
	cast(imu_trantrm as nvarchar) as 'itr_pck',
	'' as 'Reason'
from	 IMVENINF (nolock), IMCOLINF (nolock),  IMPRCINF (nolock)
where	ivi_venitm = @ivi_venitm		and
	ivi_venno = @ivi_venno			and
	icf_itmno  = ivi_itmno			and
	ivi_itmno = imu_itmno			and
	ivi_def = 'Y'				and
	ivi_venno = imu_prdven/*			and
	--imu_status = 'ACT'				and
	(imu_cus1no = @imu_cus1no		and
	 imu_cus2no = @imu_cus2no	or
	 imu_cus1no = @imu_cus1no		and
	 imu_cus2no = ''		or
	 imu_cus1no = ''			and
	 imu_cus2no = '')*/

end


GO
GRANT EXECUTE ON [dbo].[sp_select_IMVENINF_Q] TO [ERPUSER] AS [dbo]
GO
