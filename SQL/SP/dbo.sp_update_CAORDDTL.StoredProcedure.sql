/****** Object:  StoredProcedure [dbo].[sp_update_CAORDDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CAORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CAORDDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/************************************************************************
Author:		Marco Chan
Date:		26 Aug 2011
Description:	update data into CAORDDTL
***********************************************************************
*/

CREATE   procedure [dbo].[sp_update_CAORDDTL]



@cad_cocde nvarchar(6),
@cad_caordno nvarchar(20),
@cad_caordseq int,
@cad_clatyp nvarchar(6),
@cad_txcocde nvarchar(6),
@CAD_SHPNO nvarchar(20),
@CAD_SHPSEQ int,
@cad_scordno nvarchar(20),
@cad_scordseq int,
@cad_popurord nvarchar(20),
@cad_popurseq int,
@cad_pojobord nvarchar(20),
@cad_shinvno nvarchar(20),
@cad_sccuspono nvarchar(20),
@cad_shissdat datetime,
@cad_shetddat datetime,
@cad_shetadat datetime,
@cad_itmno nvarchar(20),
@cad_cusitm nvarchar(20),
@cad_cusstyno nvarchar(30),
@cad_venitm nvarchar(20),
@cad_itmdsc nvarchar(800),
@cad_prdven nvarchar(6),
@cad_ventyp nvarchar(6),
@cad_sccurcde nvarchar(6),
@cad_scnetuntprc numeric(13,4),
@cad_scfcurcde nvarchar(6),
@cad_scftyprc numeric(13,4),
@cad_scpckunt nvarchar(6),
@cad_scordqty int ,
@cad_scshpqty int ,
@cad_caqty int ,
@CAD_CAQTY_FINAL int ,
@cad_rmk nvarchar(1000),
@cad_salcur nvarchar(6),
@cad_salamt numeric(13,4),
@cad_grspftamt numeric(13,4),
@cad_calmtamt numeric(13,4),
@cad_cacur nvarchar(6),
@CAD_CAQTYAMT_ORG numeric(13,4),
@CAD_CAQTYAMT_FINAL numeric(13,4),
@cad_caamt_org numeric(13,4),
@cad_caamt_final numeric(13,4),
@CAD_TTLCAAMT_ORG numeric(13,4),
@CAD_TTLCAAMT_FINAL numeric(13,4),
@cad_catoinscur nvarchar(6),
@cad_catoinsamt numeric(13,4),
@cad_catovncur nvarchar(6),
@cad_catovnamt numeric(13,4),
@cad_catohkocur nvarchar(6),
@cad_catohkoamt numeric(13,4),
@CAD_SCUNTCDE nvarchar(6),
@cad_updusr nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------


update CAORDDTL
set
CAD_COCDE	=@CAD_COCDE,
CAD_CAORDNO	=@CAD_CAORDNO,
CAD_CAORDSEQ	=@CAD_CAORDSEQ,
CAD_CLATYP	=@CAD_CLATYP,
CAD_TXCOCDE	=@CAD_TXCOCDE,
CAD_SHPNO	=@CAD_SHPNO,
CAD_SHPSEQ	=@CAD_SHPSEQ,
CAD_SCORDNO	=@CAD_SCORDNO,
CAD_SCORDSEQ	=@CAD_SCORDSEQ,
CAD_POPURORD	=@CAD_POPURORD,
CAD_POPURSEQ	=@CAD_POPURSEQ,
CAD_POJOBORD	=@CAD_POJOBORD,
CAD_SHINVNO	=@CAD_SHINVNO,
CAD_SCCUSPONO	=@CAD_SCCUSPONO,
CAD_SHISSDAT	=@CAD_SHISSDAT,
CAD_SHETDDAT	=@CAD_SHETDDAT,
CAD_SHETADAT	=@CAD_SHETADAT,
CAD_ITMNO	=@CAD_ITMNO,
CAD_CUSITM	=@CAD_CUSITM,
CAD_CUSSTYNO	=@CAD_CUSSTYNO,
CAD_VENITM	=@CAD_VENITM,
CAD_ITMDSC	=@CAD_ITMDSC,
CAD_PRDVEN	=@CAD_PRDVEN,
CAD_VENTYP	=@CAD_VENTYP,
CAD_SCCURCDE	=@CAD_SCCURCDE,
CAD_SCNETUNTPRC	=@CAD_SCNETUNTPRC,
CAD_SCFCURCDE	=@CAD_SCFCURCDE,
CAD_SCFTYPRC	=@CAD_SCFTYPRC,
CAD_SCPCKUNT	=@CAD_SCPCKUNT,
CAD_SCORDQTY	=@CAD_SCORDQTY,
CAD_SCSHPQTY	=@CAD_SCSHPQTY,
CAD_CAQTY	=@CAD_CAQTY,
CAD_CAQTY_FINAL	=@CAD_CAQTY_FINAL,
CAD_RMK	=@CAD_RMK,
CAD_SALCUR	=@CAD_SALCUR,
CAD_SALAMT	=@CAD_SALAMT,
CAD_GRSPFTAMT	=@CAD_GRSPFTAMT,
CAD_CALMTAMT	=@CAD_CALMTAMT,
CAD_CACUR	=@CAD_CACUR,
CAD_CAQTYAMT_ORG	=@CAD_CAQTYAMT_ORG,
CAD_CAQTYAMT_FINAL	=@CAD_CAQTYAMT_FINAL,
CAD_CAAMT_ORG	=@CAD_CAAMT_ORG,
CAD_CAAMT_FINAL	=@CAD_CAAMT_FINAL,
CAD_TTLCAAMT_ORG	=@CAD_TTLCAAMT_ORG,
CAD_TTLCAAMT_FINAL	=@CAD_TTLCAAMT_FINAL,
CAD_CATOINSCUR	=@CAD_CATOINSCUR,
CAD_CATOINSAMT	=@CAD_CATOINSAMT,
CAD_CATOVNCUR	=@CAD_CATOVNCUR,
CAD_CATOVNAMT	=@CAD_CATOVNAMT,
CAD_CATOHKOCUR	=@CAD_CATOHKOCUR,
CAD_CATOHKOAMT	=@CAD_CATOHKOAMT,
CAD_SCUNTCDE	=@CAD_SCUNTCDE,
cad_upddat = getdate()
WHERE	
cad_cocde = @cad_cocde and cad_caordno = @cad_caordno and cad_caordseq = @cad_caordseq

END










GO
GRANT EXECUTE ON [dbo].[sp_update_CAORDDTL] TO [ERPUSER] AS [dbo]
GO
