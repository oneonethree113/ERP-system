/****** Object:  StoredProcedure [dbo].[sp_insert_PCMDEVCRG]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PCMDEVCRG]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PCMDEVCRG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Program ID	: sp_insert_PCMDEVCRG
Description   	: Insert Data for Profit Center Development Charge table 
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
CREATE  procedure [dbo].[sp_insert_PCMDEVCRG]
@cocde 		varchar(6),
@pdc_pcno 	varchar(20),
@pdc_facde 	varchar(10),
@pdc_decfmlopt 	varchar(6),
@pdc_cusno	varchar(8),
@pdc_creusr varchar(30)
AS
begin

insert into PCMDEVCRG(
	pdc_pcno,
	pdc_facde,
	pdc_cusno,
	pdc_decfmlopt,
	pdc_creusr,
	pdc_updusr,
	pdc_credat,
	pdc_upddat)
values (
	@pdc_pcno,
	@pdc_facde,
	@pdc_cusno,
	@pdc_decfmlopt,
	@pdc_creusr,
	@pdc_creusr,
	getdate(),
	getdate())
end







GO
GRANT EXECUTE ON [dbo].[sp_insert_PCMDEVCRG] TO [ERPUSER] AS [dbo]
GO
