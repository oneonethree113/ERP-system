/****** Object:  StoredProcedure [dbo].[sp_select_IMM00006_check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00006_check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00006_check]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
======================================================
Program ID	: sp_select_IMM00006_check
Description		: check timstamp of input item no
		: 
Programmer	: Lester Wu
ALTER  Date	: 13th Sep , 2004
Table Read(s)	: 
Table Write(s)	: IMBASINF,IMVENPCK,IMVENINF,IMMRKUP
======================================================
Modification History
======================================================
Date		Initial		Description
======================================================

*/

CREATE PROCEDURE [dbo].[sp_select_IMM00006_check]
@cocde as nvarchar(6),
@ibi_itmno as nvarchar(20)

as
begin

DECLARE		@tim_IMBASINF as int,
		@tim_IMMRKUP as int,
 		@tim_IMVENPCK as int,
		@tim_IMVENINF as int

set @tim_IMBASINF =0
set @tim_IMMRKUP = 0
set @tim_IMVENPCK =0
set @tim_IMVENINF = 0
		

select @tim_IMBASINF = cast(ibi_timstp as int) from IMBASINF where ibi_itmno=@ibi_itmno order by ibi_upddat desc

select @tim_IMMRKUP =cast(imu_timstp as int) from IMMRKUP where imu_itmno = @ibi_itmno order by imu_upddat desc

select @tim_IMVENPCK = cast(ivp_timstp as int) from IMVENPCK where ivp_itmno=@ibi_itmno order by ivp_upddat desc

select @tim_IMVENINF =cast(ivi_timstp as int) from IMVENINF where ivi_itmno = @ibi_itmno order by ivi_upddat desc

select 	@tim_IMBASINF as 'ibi_timstp',
	@tim_IMMRKUP as 'imu_timstp',
	@tim_IMVENPCK as 'ivp_timstp',
	@tim_IMVENINF as 'ivi_timstp'


end 





GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00006_check] TO [ERPUSER] AS [dbo]
GO
