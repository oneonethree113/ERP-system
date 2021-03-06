/****** Object:  StoredProcedure [dbo].[sp_select_IMM00005]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00005]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00005]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
===========================================
Program ID	: sp_select_IMM00005
Description		: Retrieve information of the input item no
Programmer	: Lester Wu
Create Date		:
Table Read(s)	: IMBASINF, IMMRKUP, SYCATCDE, VNBASINF
Table Write(s)	:
===========================================
Modification History
===========================================
Date		Initial		Description
===========================================

*/

--sp_select_IMM00005 'UCPP','031434-00862'

CREATE procedure [dbo].[sp_select_IMM00005]
@cocde	nvarchar(6),
@ibi_itmno	nvarchar(20)

as
begin


--retrieve timestamp from 
DECLARE @tim_IMVENPCK as int,
	@tim_IMVENINF as int
		


set @tim_IMVENPCK =0
set @tim_IMVENINF = 0
		

select @tim_IMVENPCK = cast(ivp_timstp as int) from IMVENPCK where ivp_itmno=@ibi_itmno

select @tim_IMVENINF =cast(ivi_timstp as int) from IMVENINF where ivi_itmno = @ibi_itmno 

--select @tim_IMVENPCK,@tim_IMVENINF 

select 
ibi_itmno,
ibi_typ,
case ibi_itmsts when 'CMP' then 'CMP - Active Item with complete Info.' 
                when 'HLD' then 'HLD - Active Item Hold by the system'
		when 'DIS' then 'DIS - Discontinue Item'
		when 'INA' then 'INA - Inactive Item'
		when 'CLO' then 'CLO - Closed (UCP Item)'
		when 'INC' then 'INC - Active Item with incomplete Info.' 
		when 'TBC' then 'TBC - To be confirmed Item'
		-- Lester Wu 2006-09-17
		when 'OLD' then 'OLD - Old Item'
                else '' end as 'ibi_itmsts',
ibi_venno + ' - ' + isnull(vbi_vensna,'') as 'ibi_venno',
isnull(ibi_lnecde,'') as 'ibi_lnecde',
case ltrim(rtrim(isnull(ibi_catlvl4,''))) when '' then '' else  isnull(ibi_catlvl4,'') + ' - ' + isnull(ycc_catdsc,'') end  as 'ibi_catlvl4',

ibi_engdsc,
ibi_chndsc,
isnull(imu_curcde,'') as 'imu_curcde',
isnull(imu_ttlcst,0) as 'imu_ttlcst',
isnull(imu_bcurcde,'') as 'imu_bcurcde',
isnull(imu_ftycst,0) as 'imu_ftycst',

cast(ibi_timstp as int) as 'ibi_timstp',
cast(isnull(imu_timstp,0) as int) as 'imu_timstp',
@tim_IMVENPCK as 'ivp_timstp',
@tim_IMVENINF as 'ivi_timstp'

from IMBASINF (NOLOCK)
left join IMMRKUP (NOLOCK)  ON ibi_itmno = imu_itmno
left join SYCATCDE (NOLOCK) ON ycc_level = '4'  and   ibi_catlvl4 = ycc_catcde
left join VNBASINF (NOLOCK) ON ibi_venno = vbi_venno

where ibi_itmno=@ibi_itmno


end





GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00005] TO [ERPUSER] AS [dbo]
GO
