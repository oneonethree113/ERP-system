/****** Object:  StoredProcedure [dbo].[sp_update_CUSHPINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUSHPINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUSHPINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/************************************************************************
Author:		Kath Ng     
Date:		11th October, 2001
Description:	Update data into CUSHPINF
************************************************************************/

CREATE PROCEDURE [dbo].[sp_update_CUSHPINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@csi_cocde	nvarchar(6),
@csi_cusno	nvarchar(6),
@csi_csetyp	nvarchar(2),
@csi_cseseq	int,
@csi_csenam	nvarchar(30),
@csi_cseacc	nvarchar(50),
@csi_csedsc	nvarchar(200),
@csi_cseadr	nvarchar(200),
@csi_csestt	nvarchar(20),
@csi_csecty	nvarchar(20),
@csi_csepst	nvarchar(20),
@csi_csectp	nvarchar(20),
@csi_csetil	nvarchar(20),
@csi_csephn	nvarchar(30),
@csi_csefax	nvarchar(30),
@csi_cseeml	nvarchar(50),
@csi_csermk	nvarchar(200),
@csi_csedef	nvarchar(1),
@csi_cseinr	nvarchar(200),
@csi_updusr	nvarchar(30),
@Type		nvarchar(2)


--------------------------------------------------------------------------------------------------------------------------------------
AS

IF @Type = 'B' -- For Bank / FCR / BL
BEGIN

UPDATE CUSHPINF

SET	csi_csetyp = @csi_csetyp,
	csi_csenam = @csi_csenam,
	csi_cseadr = @csi_cseadr,
	csi_csestt = @csi_csestt,
	csi_csecty = @csi_csecty,
	csi_csepst = @csi_csepst,
	csi_csectp = @csi_csectp,
	csi_csetil = @csi_csetil,
	csi_csephn = @csi_csephn,
	csi_csefax = @csi_csefax,
	csi_cseeml = @csi_cseeml,
	csi_csedef = @csi_csedef,
	csi_updusr = @csi_updusr,
	csi_upddat = getdate()

WHERE	--csi_cocde = @csi_cocde and
	csi_cusno = @csi_cusno
and	csi_csetyp = @csi_csetyp
and	csi_cseseq = @csi_cseseq

END

-----------------------------------------------------------------------------------------------------------------------------------------
IF @Type = 'C' -- For Forwarder / Courier Information
BEGIN

UPDATE CUSHPINF

SET	csi_csenam = @csi_csenam,
	csi_cseacc = @csi_cseacc,
	csi_csedsc = @csi_csedsc,
	csi_cseadr = @csi_cseadr,
	csi_csestt = @csi_csestt,
	csi_csecty = @csi_csecty,
	csi_csepst = @csi_csepst,
	csi_csectp = @csi_csectp,
	csi_csetil = @csi_csetil,
	csi_csephn = @csi_csephn,
	csi_csefax = @csi_csefax,
	csi_cseeml = @csi_cseeml,
	csi_cseinr = @csi_cseinr,
	csi_csedef = @csi_csedef,
 	csi_updusr = @csi_updusr,
	csi_upddat = getdate()

WHERE	--csi_cocde = @csi_cocde
--and
	csi_cusno = @csi_cusno
and	csi_csetyp = @csi_csetyp
and	csi_cseseq = @csi_cseseq


END

--------------------------------------------------------------------------------------------------------------------------------------








GO
GRANT EXECUTE ON [dbo].[sp_update_CUSHPINF] TO [ERPUSER] AS [dbo]
GO
