/****** Object:  StoredProcedure [dbo].[sp_update_CUBASINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CUBASINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CUBASINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Kath Ng     
Date:		14th September, 2001
Description:	Update data into CUBASINF
Parameter:	1. Company Code range    
		2. Customer Code range    
************************************************************************
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
ALTER  Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
17 Jun 2003	Lewis To		Add field alias (cbi_cusali)                
=========================================================     
*/
CREATE  PROCEDURE [dbo].[sp_update_CUBASINF] 
--------------------------------------------------------------------------------------------------------------------------------------

@cbi_cocde	nvarchar(6),
@cbi_cusno	nvarchar(6),
@cbi_custyp	nvarchar(1),
@cbi_cussts	nvarchar(1),
@cbi_cussna	nvarchar(30),
@cbi_cusnam	nvarchar(50),
@cbi_cusweb	nvarchar(100),
@cbi_saltem nvarchar(12),
@cbi_saldiv nvarchar(20),
@cbi_salrep	nvarchar(30),
@cbi_salmgt	nvarchar(12),
@cbi_srname	nvarchar(30),
@cbi_refno	nvarchar(8),
@cbi_cusrat	nvarchar(5),
@cbi_mrkreg	nvarchar(20),
@cbi_mrktyp	nvarchar(6),
@cbi_advord	nvarchar(20),
@cbi_rmk		nvarchar(200),
@cbi_cuspod	nvarchar(200),
@cbi_cusfde	nvarchar(200),
@cbi_cuscfs	nvarchar(1),
@cbi_custhc	nvarchar(1),
@cbi_cuspro	nvarchar(3500),
@cbi_cerdoc	nvarchar(500),
@cbi_cusali	nvarchar(6),	--Add by Lewis 
@cbi_cugrptyp_int nvarchar(20),
@cbi_cugrptyp_ext nvarchar(20),
@cbi_rounding int,
@cbi_cbinv	nvarchar(1),
@cbi_cbinvwarn	nvarchar(1) ,
@cbi_updusr	nvarchar(30)
--------------------------------------------------------------------------------------------------------------------------------------
AS

update CUBASINF set

cbi_cocde	=@cbi_cocde,
cbi_cusno = @cbi_cusno,	
cbi_custyp = @cbi_custyp,
cbi_cussts = @cbi_cussts,	
cbi_cussna = @cbi_cussna,	
cbi_cusnam = @cbi_cusnam,
cbi_cusweb = @cbi_cusweb,
cbi_saltem = @cbi_saltem,
cbi_saldiv = @cbi_saldiv,
--cbi_salrep = @cbi_salrep,
cbi_salmgt = @cbi_salmgt,
cbi_srname =@cbi_srname,
cbi_refno = @cbi_refno,
cbi_cusrat  = @cbi_cusrat,
cbi_mrkreg = @cbi_mrkreg,
cbi_mrktyp = @cbi_mrktyp,
cbi_advord = @cbi_advord,
cbi_rmk = @cbi_rmk,
cbi_cuspod = @cbi_cuspod,
cbi_cusfde = @cbi_cusfde,
cbi_cuscfs = @cbi_cuscfs,
cbi_custhc = @cbi_custhc,
cbi_cuspro = @cbi_cuspro,
cbi_updusr = @cbi_updusr,
cbi_cerdoc = @cbi_cerdoc,
cbi_upddat	= getdate(),
cbi_cusali=@cbi_cusali,	--Add by Lewis
cbi_cugrptyp_int = @cbi_cugrptyp_int,
cbi_cugrptyp_ext = @cbi_cugrptyp_ext,
 cbi_rounding  = @cbi_rounding,
cbi_cbinv=@cbi_cbinv,
cbi_cbinvwarn=@cbi_cbinvwarn
--------------------------------------------------------------------------------------------------------------------------------------
where 

--cbi_cocde	= @cbi_cocde and 
cbi_cusno	= @cbi_cusno
--------------------------------------------------------------------------------------------------------------------------------------








GO
GRANT EXECUTE ON [dbo].[sp_update_CUBASINF] TO [ERPUSER] AS [dbo]
GO
