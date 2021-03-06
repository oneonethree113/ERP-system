/****** Object:  StoredProcedure [dbo].[sp_insert_IMMATBKD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMMATBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMMATBKD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject
*/

/************************************************************************
Author:		Kenny Chan
Date:		24th September, 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_insert_IMMATBKD] 

@ibm_cocde  	nvarchar(6) = ' ',
@ibm_itmno  	nvarchar(20),
@ibm_mat	nvarchar(200),
@ibm_curcde	nvarchar(6),
@ibm_cst	numeric(13,4),
@ibm_cstper	numeric(13,4),
@ibm_wgtper	numeric(13,4),
@ibm_updusr  	nvarchar(30)


AS
declare @max_seq int

--SET @max_seq = (Select isnull(max(ibm_matseq),0) +1 from IMMATBKD where ibm_cocde = @ibm_cocde and ibm_itmno = @ibm_itmno)
SET @max_seq = (Select isnull(max(ibm_matseq),0) +1 from IMMATBKD where ibm_itmno = @ibm_itmno)

insert into IMMATBKD
(
ibm_cocde,
ibm_itmno,
ibm_matseq,
ibm_mat,
ibm_curcde,
ibm_cst,
ibm_cstper,
ibm_wgtper,
ibm_creusr,
ibm_updusr,
ibm_credat,
ibm_upddat
)

values
(
--@ibm_cocde,
' ',
@ibm_itmno,
@max_seq,
@ibm_mat,
@ibm_curcde,
@ibm_cst,
@ibm_cstper,
@ibm_wgtper,
@ibm_updusr,
@ibm_updusr,
getdate(),
getdate())











GO
GRANT EXECUTE ON [dbo].[sp_insert_IMMATBKD] TO [ERPUSER] AS [dbo]
GO
