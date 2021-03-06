/****** Object:  StoredProcedure [dbo].[sp_update_PCMDEVCRG]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PCMDEVCRG]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PCMDEVCRG]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Program ID	: sp_update_PCMDEVCRG
Description   	: Update Data for Profit Center Development Charge table 
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
CREATE  PROCEDURE [dbo].[sp_update_PCMDEVCRG] 
@cocde 		varchar(6),
@pdc_pcno	nvarchar(20),
@pdc_facde	nvarchar(10),
@pdc_decfmlopt	nvarchar(6),
@pdc_cusno	nvarchar(8),
@pdc_updusr	nvarchar(30)
AS
begin

update PCMDEVCRG set 
	pdc_decfmlopt = @pdc_decfmlopt,
	pdc_updusr = @pdc_updusr,
	pdc_upddat = getdate()
where
	pdc_pcno = @pdc_pcno and
	pdc_facde = @pdc_facde and
	pdc_cusno=@pdc_cusno
end







GO
GRANT EXECUTE ON [dbo].[sp_update_PCMDEVCRG] TO [ERPUSER] AS [dbo]
GO
