/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PCMAGYCRG]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_PCMAGYCRG]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PCMAGYCRG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: sp_physical_delete_PCMAGYCRG
Description   	: Delete Data for Profit Center Agency Charge table 
Programmer  	: Marco Chan
ALTER  Date   	: 19 Sept 2003
Last Modified  	: 
Table Read(s) 	: PCMAGYCRG
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/
CREATE    PROCEDURE [dbo].[sp_physical_delete_PCMAGYCRG] 
@cocde 		varchar(6),
@pac_pcno 	varchar(20),
@pac_cocde 	varchar(20),
@pac_cusno	varchar(8)
AS
begin

delete from PCMAGYCRG 
where
	pac_pcno = @pac_pcno and
	pac_cocde = @pac_cocde and
	pac_cusno=@pac_cusno
end







GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_PCMAGYCRG] TO [ERPUSER] AS [dbo]
GO
