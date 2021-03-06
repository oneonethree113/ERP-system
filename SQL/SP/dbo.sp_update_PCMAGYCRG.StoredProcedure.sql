/****** Object:  StoredProcedure [dbo].[sp_update_PCMAGYCRG]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PCMAGYCRG]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PCMAGYCRG]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Program ID	: sp_update_PCMAGYCRG
Description   	: Update Data for Profit Center Agency Charge table 
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
CREATE  PROCEDURE [dbo].[sp_update_PCMAGYCRG] 
@cocde 		varchar(6),
@pac_pcno 	varchar(20),
@pac_cocde 	varchar(20),
@pac_hdcfmlopt 	varchar(6),
@pac_cusno	varchar(8),
@pac_updusr 	varchar(30)
AS
begin

update PCMAGYCRG set 
	pac_hdcfmlopt = @pac_hdcfmlopt,
	pac_updusr = @pac_updusr,
	pac_upddat = getdate()
	
where
	pac_pcno = @pac_pcno and
	pac_cocde = @pac_cocde and
	pac_cusno=@pac_cusno
end







GO
GRANT EXECUTE ON [dbo].[sp_update_PCMAGYCRG] TO [ERPUSER] AS [dbo]
GO
