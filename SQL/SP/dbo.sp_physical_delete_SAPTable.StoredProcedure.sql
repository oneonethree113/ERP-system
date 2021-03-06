/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SAPTable]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SAPTable]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SAPTable]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_physical_delete_SAPTable] 
@ZCDATFM	datetime,
@ZCDATTO	datetime

as

delete VBKD
FROM VBKD t1
INNER JOIN ZVBAP_HDR t2
ON t2.ZVBELN =  t1.VBELN AND t2.ZPOSNR = t1.POSNR
WHERE t2.ZCDAT between @ZCDATFM and @ZCDATTO

delete VBAP
FROM VBAP t1
INNER JOIN ZVBAP_HDR t2
ON t2.ZVBELN =  t1.VBELN AND t2.ZPOSNR = t1.POSNR
WHERE t2.ZCDAT between @ZCDATFM and @ZCDATTO

delete VBAK
FROM VBAK t1
INNER JOIN ZVBAP_HDR t2
ON t2.ZVBELN =  t1.VBELN
WHERE t2.ZCDAT between @ZCDATFM and @ZCDATTO
AND t1.ERDAT between @ZCDATFM and @ZCDATTO

delete from ZVBAP_HDR where ZCDAT between @ZCDATFM and @ZCDATTO
delete from ZVBAP_DTL where ZCDAT between @ZCDATFM and @ZCDATTO
delete from ZVBAP_CTN where ZCDAT between @ZCDATFM and @ZCDATTO
delete from ZVBAP_SHP where ZCDAT between @ZCDATFM and @ZCDATTO


GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SAPTable] TO [ERPUSER] AS [dbo]
GO
