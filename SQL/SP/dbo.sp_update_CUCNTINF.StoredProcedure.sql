/****** Object:  StoredProcedure [dbo].[sp_update_CUCNTINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUCNTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUCNTINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/************************************************************************
Author:		Kath Ng     
Date:		15th September, 2001
Description:	Update data into CUCNTINF
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************/

CREATE PROCEDURE [dbo].[sp_update_CUCNTINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@cci_cocde	nvarchar(6),
@cci_cusno	nvarchar(6),
@cci_cntseq	int,
@cci_cnttyp	nvarchar(6),
@cci_cntadr	nvarchar(200),
@cci_cntstt		nvarchar(20),
@cci_cntcty	nvarchar(6),
@cci_cntpst	nvarchar(20),
@cci_cntctp	nvarchar(50),
@cci_cnttil		nvarchar(30),
@cci_cntphn	nvarchar(30),
@cci_cntfax	nvarchar(30),
@cci_cnteml	nvarchar(200),
@cci_cntrmk	nvarchar(200),
@cci_cntdef	nvarchar(1),
@cci_updusr	nvarchar(30),
@Type		nvarchar(6)

AS

begin
------------------------------------------------------------------------------------------
if @Type = 'B' --- For Billing Address
begin
	
UPDATE CUCNTINF 
SET	cci_cntadr = @cci_cntadr,
	cci_cntstt = @cci_cntstt,
	cci_cntcty = @cci_cntcty,	
	cci_cntpst = @cci_cntpst,
	cci_cntdef = @cci_cntdef,
	cci_updusr = @cci_updusr,	
	cci_upddat = getdate()
where 
	--cci_cocde = @cci_cocde  and
	cci_cusno = @cci_cusno and 
	cci_cnttyp = @cci_cnttyp and
	cci_cntseq = @cci_cntseq
end
------------------------------------------------------------------------------------------

if @Type = 'S'  ---- For Shipping Address
begin
UPDATE CUCNTINF
SET	cci_cntadr = @cci_cntadr,
	cci_cntstt = @cci_cntstt,
	cci_cntcty = @cci_cntcty,	
	cci_cntpst = @cci_cntpst,
	cci_cntdef = @cci_cntdef,
	cci_updusr = @cci_updusr,	
	cci_upddat = getdate()
where 
	--cci_cocde = @cci_cocde  and
	cci_cusno = @cci_cusno and 
	cci_cnttyp = @cci_cnttyp and
	cci_cntseq = @cci_cntseq
end
------------------------------------------------------------------------------------------

IF @Type = 'M'  --- For Mailing Address
BEGIN

	IF @cci_cntseq = '1'  -- Update Record but no mailing record in CUCNTINF ( Modify on 9th October, 2001 by Kath)
	BEGIN
	INSERT INTO CUCNTINF
	(
	cci_cocde,
	cci_cusno,
	cci_cntseq,
	cci_cnttyp,
	cci_cntadr,
	cci_cntstt,
	cci_cntcty ,
	cci_cntpst ,
	cci_creusr,
	cci_updusr,
	cci_upddat
	)
	values
	(
	@cci_cocde,
	@cci_cusno,
	@cci_cntseq,
	@cci_cnttyp,
	@cci_cntadr,
	@cci_cntstt,
	@cci_cntcty,
	@cci_cntpst,
	@cci_updusr,
	@cci_updusr,
	getdate()	
	)
	END
	
	ELSE
	BEGIN

	UPDATE CUCNTINF
	SET	cci_cntadr = @cci_cntadr,
		cci_cntstt = @cci_cntstt,
		cci_cntcty = @cci_cntcty,	
		cci_cntpst = @cci_cntpst,
		cci_updusr = @cci_updusr,	
		cci_upddat = getdate()
	where 
		--cci_cocde = @cci_cocde  and
		cci_cusno = @cci_cusno and 
		cci_cnttyp = @cci_cnttyp 
	END
END

------------------------------------------------------------------------------------------

IF @Type = 'C'  ---- For Contact
BEGIN
UPDATE CUCNTINF
SET	cci_cnttyp = @cci_cnttyp,
	cci_cntctp = @cci_cntctp,
	cci_cnttil = @cci_cnttil,
	cci_cntphn = @cci_cntphn,
	cci_cntfax = @cci_cntfax,
	cci_cnteml = @cci_cnteml,
	cci_cntdef = @cci_cntdef,
	cci_updusr = @cci_updusr,	
	cci_upddat = getdate()
WHERE
	--cci_cocde = @cci_cocde  and
	cci_cusno = @cci_cusno and 
	cci_cnttyp = @cci_cnttyp and
	cci_cntseq = @cci_cntseq
END
------------------------------------------------------------------------------------------

IF @Type = 'ADMN'  
or @Type = 'MAGT'  
or @Type = 'SALE'  
or @Type = 'BUYR'  
or @Type = 'SHIP'  
or @Type = 'ACCT'  


BEGIN
UPDATE CUCNTINF
SET	cci_cntadr = @cci_cntadr,
	cci_cntstt = @cci_cntstt,
	cci_cntcty = @cci_cntcty,	
	cci_cntpst = @cci_cntpst,
	cci_cntdef = @cci_cntdef,
	cci_updusr = @cci_updusr,	
	cci_upddat = getdate()
WHERE
	--cci_cocde = @cci_cocde  and
	cci_cusno = @cci_cusno and 
	cci_cnttyp = @cci_cnttyp and
	cci_cntseq = @cci_cntseq
END
------------------------------------------------------------------------------------------
END

GO
GRANT EXECUTE ON [dbo].[sp_update_CUCNTINF] TO [ERPUSER] AS [dbo]
GO
