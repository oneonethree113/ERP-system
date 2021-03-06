/****** Object:  StoredProcedure [dbo].[sp_update_CAORDITM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CAORDITM]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CAORDITM]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












/************************************************************************
Author:		Marco Chan
Date:		26 Aug 2011
Description:	insert data into CAORDDTL
***********************************************************************
*/

CREATE    procedure [dbo].[sp_update_CAORDITM]

@CAI_COCDE	nvarchar(6),		
@CAI_CAORDNO	nvarchar(20),		
@CAI_CAORDSEQ	int,		
@CAI_CLATYP		nvarchar(6),	
@CAI_TXCOCDE	nvarchar(6),		
@CAI_ITMNO	nvarchar(30),		
@CAI_ITMDSC	nvarchar(800),		
@CAI_RMK	nvarchar(800),		
@CAI_SALCUR	nvarchar(6),		
@CAI_SALAMT	decimal(13,4),		
@CAI_GRSPFTAMT	decimal(13,4),		
@CAI_CALMTAMT	decimal(13,4),		
@CAI_CACUR	nvarchar(6),		
@CAI_CAQTYAMT_ORG	decimal(13,4),		
@CAI_CAQTYAMT_FINAL	decimal(13,4),		
@CAI_CAAMT_ORG	decimal(13,4),		
@CAI_CAAMT_FINAL	decimal(13,4),		
@CAI_TTLCAAMT_ORG	decimal(13,4),		
@CAI_TTLCAAMT_FINAL	decimal(13,4),		
@CAI_APP1FLG		nvarchar(1),	
@CAI_APP1FLGBY		nvarchar(30),	
@CAI_APP1FLGDAT	datetime,		
@CAI_CATOINSCUR	nvarchar(6),		
@CAI_CATOINSAMT	decimal(13,4),		
@CAI_CATOVNCUR	nvarchar(6),		
@CAI_CATOVNAMT	decimal(13,4),		
@CAI_CATOHKOCUR	nvarchar(6),		
@CAI_CATOHKOAMT	decimal(13,4),		
@CAI_APP2FLG		nvarchar(1),	
@CAI_APP2FLGBY		nvarchar(30),	
@CAI_APP2FLGDAT	datetime,		
@cai_cusitm		nvarchar(30),
@cai_cusstyno		nvarchar(30),
@cai_venitm		nvarchar(30),
@cai_prdven		nvarchar(1),
@cai_updusr nvarchar(30)			

 
AS

BEGIN

--------------------------------------------------------------------------------------------------


update CAORDITM
set
CAI_COCDE			=@CAI_COCDE,
CAI_CAORDNO			=@CAI_CAORDNO,
CAI_CAORDSEQ			=@CAI_CAORDSEQ,
CAI_CLATYP			=@CAI_CLATYP,
CAI_TXCOCDE			=@CAI_TXCOCDE,
CAI_ITMNO			=@CAI_ITMNO,
CAI_ITMDSC			=@CAI_ITMDSC,
CAI_RMK			=@CAI_RMK,
CAI_SALCUR			=@CAI_SALCUR,
CAI_SALAMT			=@CAI_SALAMT,
CAI_GRSPFTAMT			=@CAI_GRSPFTAMT,
CAI_CALMTAMT			=@CAI_CALMTAMT,
CAI_CACUR			=@CAI_CACUR,
CAI_CAQTYAMT_ORG			=@CAI_CAQTYAMT_ORG,
CAI_CAQTYAMT_FINAL			=@CAI_CAQTYAMT_FINAL,
CAI_CAAMT_ORG			=@CAI_CAAMT_ORG,
CAI_CAAMT_FINAL			=@CAI_CAAMT_FINAL,
CAI_TTLCAAMT_ORG			=@CAI_TTLCAAMT_ORG,
CAI_TTLCAAMT_FINAL			=@CAI_TTLCAAMT_FINAL,
CAI_APP1FLG			=@CAI_APP1FLG,
CAI_APP1FLGBY			=@CAI_APP1FLGBY,
CAI_APP1FLGDAT			=@CAI_APP1FLGDAT,
CAI_CATOINSCUR			=@CAI_CATOINSCUR,
CAI_CATOINSAMT			=@CAI_CATOINSAMT,
CAI_CATOVNCUR			=@CAI_CATOVNCUR,
CAI_CATOVNAMT			=@CAI_CATOVNAMT,
CAI_CATOHKOCUR			=@CAI_CATOHKOCUR,
CAI_CATOHKOAMT			=@CAI_CATOHKOAMT,
CAI_APP2FLG			=@CAI_APP2FLG,
CAI_APP2FLGBY			=@CAI_APP2FLGBY,
CAI_APP2FLGDAT			=@CAI_APP2FLGDAT,
cai_cusitm=@cai_cusitm,
cai_cusstyno=@cai_cusstyno,
cai_venitm=@cai_venitm,
cai_prdven=@cai_prdven,
cai_updusr=@cai_updusr 
where
CAI_COCDE=@CAI_COCDE and 
CAI_CAORDNO = @CAI_CAORDNO and
CAI_CAORDSEQ =@CAI_CAORDSEQ




END











GO
GRANT EXECUTE ON [dbo].[sp_update_CAORDITM] TO [ERPUSER] AS [dbo]
GO
