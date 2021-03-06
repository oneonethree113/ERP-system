/****** Object:  StoredProcedure [dbo].[sp_insert_PCMAGYCRG]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PCMAGYCRG]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PCMAGYCRG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: sp_insert_PCMAGYCRG
Description   	: Insert Data for Profit Center Agency Charge table 
Programmer  	: Marco Chan
ALTER  Date   	: 19 Sept 2003
Last Modified  	: 
Table Read(s) 	: PCMAGYCRG
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
04 Nov 2003	LESTER		Add column pac_cusno               
=========================================================     
*/
CREATE   procedure [dbo].[sp_insert_PCMAGYCRG]
@cocde 		varchar(6),
@pac_pcno 	varchar(20),
@pac_cocde 	varchar(20),
@pac_hdcfmlopt 	varchar(20),
@pac_cusno	varchar(8),
@pac_creusr varchar(30)
AS
begin

insert into PCMAGYCRG(
	pac_pcno,
	pac_cocde,
	pac_cusno,
	pac_hdcfmlopt,
	pac_creusr,
	pac_updusr,
	pac_credat,
	pac_upddat)
values (
	@pac_pcno,
	@pac_cocde,
	@pac_cusno,
	@pac_hdcfmlopt,
	@pac_creusr,
	@pac_creusr,
	getdate(),
	getdate())
end








GO
GRANT EXECUTE ON [dbo].[sp_insert_PCMAGYCRG] TO [ERPUSER] AS [dbo]
GO
