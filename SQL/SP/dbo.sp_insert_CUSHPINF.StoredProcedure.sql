/****** Object:  StoredProcedure [dbo].[sp_insert_CUSHPINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUSHPINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUSHPINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/************************************************************************
Author:		Kath Ng     
Date:		11th October, 2001
Description:	Insert data into CUSHPINF
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_CUSHPINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@csi_cocde	nvarchar(6),
@csi_cusno	nvarchar(6),
@csi_csetyp	nvarchar(6),
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
@csi_updusr	nvarchar(30)
--------------------------------------------------------------------------------------------------------------------------------------
AS


declare @csi_cseseq as int

set  @csi_cseseq = (select max(csi_cseseq) + 1 from CUSHPINF where --csi_cocde=@csi_cocde and 
						csi_csetyp=@csi_csetyp)


IF @csi_cseseq is null
BEGIN
set @csi_cseseq = 1
END




INSERT INTO  CUSHPINF
(

csi_cocde,	csi_cusno,	csi_csetyp,
csi_cseseq,	csi_csenam,	csi_cseacc,
csi_csedsc,	csi_cseadr,	csi_csestt,
csi_csecty,	csi_csepst,	csi_csectp,
csi_csetil,		csi_csephn,	csi_csefax,
csi_cseeml,	csi_csermk,	csi_csedef,
csi_cseinr,	csi_credat,	csi_upddat,
csi_creusr,	csi_updusr

)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
@csi_cocde,	@csi_cusno,	@csi_csetyp,
@csi_cseseq,	@csi_csenam,	@csi_cseacc,
@csi_csedsc,	@csi_cseadr,	@csi_csestt,
@csi_csecty,	@csi_csepst,	@csi_csectp,
@csi_csetil,	@csi_csephn,	@csi_csefax,
@csi_cseeml,	@csi_csermk,	@csi_csedef,
@csi_cseinr,	getdate(),		getdate(),
@csi_updusr,	@csi_updusr

)








GO
GRANT EXECUTE ON [dbo].[sp_insert_CUSHPINF] TO [ERPUSER] AS [dbo]
GO
