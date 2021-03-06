/****** Object:  StoredProcedure [dbo].[sp_insert_PCMAC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PCMAC]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PCMAC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


/*
=========================================================
Program ID	: sp_insert_PCMAC
Description   	: Insert Data for Profit Center Account Interface table 
Programmer  	: Marco Chan
ALTER  Date   	: 19 Sept 2003
Last Modified  	: 
Table Read(s) 	: PCMAC
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/
create procedure [dbo].[sp_insert_PCMAC]
@cocde 		varchar(6),
@pma_pcno	nvarchar(20),
@pma_invacno	nvarchar(15),
@pma_siacno	nvarchar(15),
@pma_iaacno	nvarchar(15),
@pma_stacno	nvarchar(15),
@pma_creusr	nvarchar(30)
AS
begin

insert into PCMAC(
	pma_pcno,
	pma_invacno_new,
	pma_siacno_new,
	pma_iaacno_new,
	pma_stacno_new,
	pma_creusr,
	pma_updusr,
	pma_credat,
	pma_upddat)
values (
	@pma_pcno,
	@pma_invacno,
	@pma_siacno,
	@pma_iaacno,
	@pma_stacno,
	@pma_creusr,
	@pma_creusr,
	getdate(),
	getdate())
end





GO
GRANT EXECUTE ON [dbo].[sp_insert_PCMAC] TO [ERPUSER] AS [dbo]
GO
