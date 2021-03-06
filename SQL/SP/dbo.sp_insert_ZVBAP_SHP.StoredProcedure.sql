/****** Object:  StoredProcedure [dbo].[sp_insert_ZVBAP_SHP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_ZVBAP_SHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_ZVBAP_SHP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_insert_ZVBAP_SHP] 
@MANDT	nvarchar(10),
@ZFILENAME	nvarchar(255),
@ZSEQ	int,
@ZCOMPCODE	nvarchar(10),
@ZPOD_PURORD	nvarchar(20),
@ZJOBNO	nvarchar(25),
@ZPOD_JOBORD nvarchar(25),
@ZPOD_SHPSTR	datetime,
@ZPOD_SHPEND	nvarchar(10),
@ZYSI_DSC	nvarchar(30),
@ZPOD_ORDQTY	int,
@ZCDAT	datetime,
@ZUDAT	datetime,
@ZUFLAG	char(1),
@ZUSEQ	int,
@ZUREST	char(1),
@usrid nvarchar(30)

as

insert into ZVBAP_SHP
(
MANDT,
ZFILENAME,
ZSEQ,
ZCOMPCODE,
ZPOD_PURORD,
ZJOBNO,
ZPOD_JOBORD,
ZPOD_SHPSTR,
ZPOD_SHPEND,
ZYSI_DSC,
ZPOD_ORDQTY,
ZCDAT,
ZUDAT,
ZUFLAG,
ZUSEQ,
ZUREST,
creusr,
updusr,
credat,
upddat
)
values
(
@MANDT,
@ZFILENAME,
@ZSEQ,
@ZCOMPCODE,
@ZPOD_PURORD,
@ZJOBNO,
@ZPOD_JOBORD,
@ZPOD_SHPSTR,
@ZPOD_SHPEND,
@ZYSI_DSC,
@ZPOD_ORDQTY,
@ZCDAT,
@ZUDAT,
@ZUFLAG,
@ZUSEQ,
@ZUREST,
@usrid,
@usrid,
getdate(),
getdate()
)



GO
GRANT EXECUTE ON [dbo].[sp_insert_ZVBAP_SHP] TO [ERPUSER] AS [dbo]
GO
