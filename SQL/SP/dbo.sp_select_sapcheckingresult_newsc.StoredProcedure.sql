/****** Object:  StoredProcedure [dbo].[sp_select_sapcheckingresult_newsc]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_sapcheckingresult_newsc]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_sapcheckingresult_newsc]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE  PROCEDURE [dbo].[sp_select_sapcheckingresult_newsc]
@checkindate datetime
AS
BEGIN
DECLARE @S_COUNT int
DECLARE @X_COUNT int
DECLARE @F_COUNT int
DECLARE @VBAP_COUNT int
DECLARE @IM_COUNT int
DECLARE @ORDQTYNOTMATCH_COUNT int

set @S_COUNT = (select count(1) from zvbap_hdr where zcdat = (SELECT CONVERT(VARCHAR(10),   @checkindate, 112))
and ZUREST = 'S')

set @X_COUNT = (select count(1) from zvbap_hdr where zcdat = (SELECT CONVERT(VARCHAR(10),   @checkindate, 112))
and ZUREST = 'X')

set @F_COUNT = (select count(1) from zvbap_hdr where zcdat = (SELECT CONVERT(VARCHAR(10),   @checkindate, 112))
and ZUREST = 'F')

set @VBAP_COUNT = (select count(1) from vbap where PSTYV = 'TAN' and
ERDAT = (SELECT CONVERT(VARCHAR(10),   @checkindate, 112)))

if (SELECT datepart(weekday, @checkindate)) = 2
set @IM_COUNT = (select count(1) from sapitemmap(nolock)
where sim_credat between
(SELECT CONVERT(VARCHAR(10), @checkindate-2, 112))
and (SELECT CONVERT(VARCHAR(10),   @checkindate-1, 112)))
else
set @IM_COUNT = (select count(1) from sapitemmap(nolock)
where sim_credat between
(SELECT CONVERT(VARCHAR(10),   @checkindate-1, 112))
and (SELECT CONVERT(VARCHAR(10),   @checkindate, 112)))

set @ORDQTYNOTMATCH_COUNT = (select count(*) from VBAP (nolock)
left join  SCORDDTL (nolock) on sod_zorvbeln = vbeln and sod_zorposnr = posnr
where sod_cocde is not null
and kwmeng <> sod_ordqty and abgru not in ('', 'Z2'))



select @S_COUNT S_COUNT,@X_COUNT X_COUNT,@F_COUNT F_COUNT,@VBAP_COUNT VBAP_COUNT,@IM_COUNT IM_COUNT, @ORDQTYNOTMATCH_COUNT ORDQTYNOTMATCH_COUNT
END

GO
GRANT EXECUTE ON [dbo].[sp_select_sapcheckingresult_newsc] TO [ERPUSER] AS [dbo]
GO
