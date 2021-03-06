/****** Object:  StoredProcedure [dbo].[sp_insert_CUBASINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUBASINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUBASINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************ 
Author:		Kath Ng     
Date:		14th September, 2001
Description:	Insert data into CUBASINF
***********************************************************************
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
CREATE  PROCEDURE [dbo].[sp_insert_CUBASINF] 
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
@cbi_rmk	nvarchar(200),
@cbi_cuspod	nvarchar(20),
@cbi_cusfde	nvarchar(20),
@cbi_cuscfs	nvarchar(1),
@cbi_custhc	nvarchar(1),
@cbi_cuspro	nvarchar(3500),
@cbi_cerdoc 	nvarchar(500),
@cbi_cusali	nvarchar(6),	--Add by Lewis
@cbi_cugrptyp_int nvarchar(20),
@cbi_cugrptyp_ext nvarchar(20),
@cbi_updusr	nvarchar(30),
@cbi_rounding int,
@cbi_cbinv	nvarchar(1),
@cbi_cbinvwarn	nvarchar(1) 


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  CUBASINF 

(
cbi_cocde,
cbi_cusno,
cbi_custyp,
cbi_cussts ,
cbi_cussna,
cbi_cusnam,
cbi_cusweb,
cbi_saltem,
cbi_saldiv,
cbi_salrep,
cbi_salmgt,
cbi_srname,
cbi_refno  ,
cbi_cusrat ,
cbi_mrkreg,
cbi_mrktyp,
cbi_advord,
cbi_rmk ,
cbi_cuspod,
cbi_cusfde,
cbi_cuscfs ,
cbi_custhc ,
cbi_cuspro,
cbi_cerdoc,
cbi_creusr,  
cbi_updusr, 
cbi_credat ,
cbi_upddat,
cbi_cusali,
cbi_cugrptyp_int,
cbi_cugrptyp_ext,
cbi_rounding,
cbi_cbinv,
cbi_cbinvwarn
)

-------------------------------------------------------------------------------------------------------------------------------------- 
values
(
@cbi_cocde,
@cbi_cusno,
@cbi_custyp,
@cbi_cussts,	
@cbi_cussna,	
@cbi_cusnam,
@cbi_cusweb,
@cbi_saltem,
@cbi_saldiv,
@cbi_salrep,
@cbi_salmgt,
@cbi_srname,
@cbi_refno,
@cbi_cusrat,
@cbi_mrkreg,
@cbi_mrktyp,
@cbi_advord,
@cbi_rmk,
@cbi_cuspod,
@cbi_cusfde,
@cbi_cuscfs,
@cbi_custhc,
@cbi_cuspro,
@cbi_cerdoc,
@cbi_updusr,
@cbi_updusr,
getdate(),
getdate(),
@cbi_cusali,
@cbi_cugrptyp_int,
@cbi_cugrptyp_ext,
@cbi_rounding,
@cbi_cbinv,
@cbi_cbinvwarn
)








GO
GRANT EXECUTE ON [dbo].[sp_insert_CUBASINF] TO [ERPUSER] AS [dbo]
GO
