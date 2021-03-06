/****** Object:  StoredProcedure [dbo].[sp_list_SCDTLCTN_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SCDTLCTN_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SCDTLCTN_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 27/07/2003

/*
=========================================================
Program ID	: sp_list_SCDTLCTN_SHM00001
Description   	: 
Programmer  	: Allan Yuen
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      	Initial  	Description          
2003-06-17	Allan Yuen	Fix Deadlock error.               
=========================================================     
*/


CREATE PROCEDURE [dbo].[sp_list_SCDTLCTN_SHM00001]

@cocde as nvarchar(6),
@ordno as nvarchar(20),
@ordseq as int

AS

SELECT sdc_from , sdc_to 

FROM SCDTLCTN (nolock)

WHERE  sdc_cocde = @cocde and
	sdc_ordno = @ordno and
	sdc_seq = @ordseq

ORDER BY  sdc_from








GO
GRANT EXECUTE ON [dbo].[sp_list_SCDTLCTN_SHM00001] TO [ERPUSER] AS [dbo]
GO
