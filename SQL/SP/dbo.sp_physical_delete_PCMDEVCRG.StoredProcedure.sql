/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PCMDEVCRG]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_PCMDEVCRG]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PCMDEVCRG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Program ID	: sp_physical_delete_PCMDEVCRG
Description   	: Delete Data for Profit Center Development Charge table 
Programmer  	: Marco Chan
ALTER  Date   	: 19 Sept 2003
Last Modified  	: 
Table Read(s) 	: PCMDEVCRG
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/
CREATE  PROCEDURE [dbo].[sp_physical_delete_PCMDEVCRG] 
@cocde 		varchar(6),
@pdc_pcno 	varchar(20),
@pdc_facde 	varchar(10),
@pdc_cusno	varchar(8)
AS
begin

delete from PCMDEVCRG 
where
	pdc_pcno = @pdc_pcno and
	pdc_facde = @pdc_facde and
	pdc_cusno=@pdc_cusno
end






GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_PCMDEVCRG] TO [ERPUSER] AS [dbo]
GO
