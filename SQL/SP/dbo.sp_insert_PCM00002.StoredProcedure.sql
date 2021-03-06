/****** Object:  StoredProcedure [dbo].[sp_insert_PCM00002]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PCM00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PCM00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=========================================================
Program ID	: sp_insert_PCM00002
Description   	: Add Profit Centre list  for Profit Account Interface table 
Programmer  	: Lester Wu
ALTER  Date   	: 28 Nov, 2003
Last Modified  	: 
Table Read(s) 	: 
Table Write(s) 	: CUMRBT ( Customer Rebate )
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/

CREATE  PROCEDURE [dbo].[sp_insert_PCM00002]
@COCDE 		VARCHAR(6),
@CMR_CUSNO	VARCHAR(20),
@CMR_FMLOPT 	VARCHAR(10),
@CMR_CREUSR 	VARCHAR(30)
AS
BEGIN

INSERT INTO CUMRBT(
	CMR_CUSNO,
	CMR_RBTFMLOPT,
	CMR_CREUSR,
	CMR_UPDUSR,
	CMR_CREDAT,
	CMR_UPDDAT)
VALUES (
	@CMR_CUSNO,
	@CMR_FMLOPT,
	@CMR_CREUSR,
	@CMR_CREUSR,
	GETDATE(),
	GETDATE())
END








GO
GRANT EXECUTE ON [dbo].[sp_insert_PCM00002] TO [ERPUSER] AS [dbo]
GO
