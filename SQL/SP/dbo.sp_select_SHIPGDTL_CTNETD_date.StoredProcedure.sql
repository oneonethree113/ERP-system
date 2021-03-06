/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL_CTNETD_date]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHIPGDTL_CTNETD_date]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL_CTNETD_date]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE       procedure [dbo].[sp_select_SHIPGDTL_CTNETD_date]


@hid_cocde	nvarchar(6),
@hid_ctnno	nvarchar(20)

 
AS

BEGIN

--------------------------------------------------------------------------------------------------
declare @sevendaysbefore datetime
declare @sevendaysafter datetime
declare @now datetime
set @now = getdate()

set @sevendaysbefore = dateadd(day,-10,@now)
set @sevendaysafter = dateadd(day,+10,@now)

select 
max(hih_slnonb) as 'hih_slnonb'
 from SHIPGHDR (nolock), SHIPGDTL (nolock)
where hih_cocde = hid_cocde 
--and hih_cocde=@hid_cocde
and hih_shpno = hid_shpno 
and hid_ctrcfs =  @hid_ctnno
and hih_slnonb <=@sevendaysafter
and hih_slnonb >=@sevendaysbefore



END





GO
GRANT EXECUTE ON [dbo].[sp_select_SHIPGDTL_CTNETD_date] TO [ERPUSER] AS [dbo]
GO
