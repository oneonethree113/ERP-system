/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF_ftycst]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMPRCINF_ftycst]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF_ftycst]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Carlos Lui
Date:		09 Jul, 2012
Description:	Select Factory Cost From IMPRCINF
Parameter:	
************************************************************************

*/
------------------------------------------------- 
CREATE  procedure [dbo].[sp_select_IMPRCINF_ftycst]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_cocde 	nvarchar(6) ,
@imu_itmno 	nvarchar(20),
@imu_pckunt 	nvarchar(6),
@imu_inrqty 	int,
@imu_mtrqty 	int,
@imu_cus1no	nvarchar(6),
@imu_cus2no	nvarchar(6),
@dummy		nvarchar(1)

---------------------------------------------- 
 
AS

declare @key_imu_cus1no nvarchar(10)
declare @key_imu_cus2no nvarchar(10)
declare @9999_flag char(1)

if (select count(*) from imprcinf
where	imu_itmno = @imu_itmno				and
	imu_status = 'ACT'				and
	imu_pckunt = @imu_pckunt			and
	imu_inrqty = @imu_inrqty			and
	imu_mtrqty= @imu_mtrqty				and
	imu_venno = imu_prdven				and
	imu_cus1no = @imu_cus1no			and
	imu_cus2no = @imu_cus2no) = 1 
begin
	set @key_imu_cus1no = @imu_cus1no
	set @key_imu_cus2no = @imu_cus2no
	set @9999_flag = 'N'
end
else if (select count(*) from imprcinf
where	imu_itmno = @imu_itmno				and
	imu_status = 'ACT'				and
	imu_pckunt = @imu_pckunt			and
	imu_inrqty = @imu_inrqty			and
	imu_mtrqty= @imu_mtrqty				and
	imu_venno = imu_prdven				and
	imu_cus1no = @imu_cus1no			and
	imu_cus2no = '') = 1 
begin
	set @key_imu_cus1no = @imu_cus1no
	set @key_imu_cus2no = ''
	set @9999_flag = 'Y'
end
else if (select count(*) from imprcinf
where	imu_itmno = @imu_itmno				and
	imu_status = 'ACT'				and
	imu_pckunt = @imu_pckunt			and
	imu_inrqty = @imu_inrqty			and
	imu_mtrqty= @imu_mtrqty				and
	imu_venno = imu_prdven				and
	imu_cus1no = ''			and
	imu_cus2no = '') = 1 
begin
	set @key_imu_cus1no = ''
	set @key_imu_cus2no = ''
	set @9999_flag = 'Y'
end
else
begin
	set @key_imu_cus1no = @imu_cus1no
	set @key_imu_cus2no = @imu_cus2no
	set @9999_flag = 'N'
end




select	imu_ftycst, imu_curcde
from	imprcinf
where	imu_itmno = @imu_itmno				and
	imu_status = 'ACT'				and
	imu_pckunt = @imu_pckunt			and
	imu_inrqty = @imu_inrqty			and
	imu_mtrqty= @imu_mtrqty				and
	imu_venno = imu_prdven				and
	imu_cus1no = @key_imu_cus1no			and
	imu_cus2no = @key_imu_cus2no			--and
--	imu_hkprctrm = @imu_hkprctrm				and
--	imu_ftyprctrm = @imu_ftyprctrm				and
--	imu_trantrm = @imu_trantrm				and
--	imu_effdat <= CONVERT(varchar(100), GETDATE(), 1)		and
--	imu_expdat >= CONVERT(varchar(100),  dateadd(dd, 1, GETDATE()), 1)







GO
GRANT EXECUTE ON [dbo].[sp_select_IMPRCINF_ftycst] TO [ERPUSER] AS [dbo]
GO
