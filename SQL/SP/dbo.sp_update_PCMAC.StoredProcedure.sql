/****** Object:  StoredProcedure [dbo].[sp_update_PCMAC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PCMAC]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PCMAC]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

/*
=========================================================
Program ID	: sp_update_PCMAC
Description   	: Update Data for Profit Account Interface table 
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
CREATE PROCEDURE [dbo].[sp_update_PCMAC] 
@cocde 		varchar(6),
@pma_pcno	nvarchar(20),
@pma_invacno	nvarchar(15),
@pma_siacno	nvarchar(15),
@pma_iaacno	nvarchar(15),
@pma_stacno	nvarchar(15),
@pma_updusr	nvarchar(30)
AS
begin

update PCMAC set 
	pma_invacno_new = @pma_invacno,
	pma_siacno_new = @pma_siacno,
	pma_iaacno_new = @pma_iaacno,
	pma_stacno_new = @pma_stacno,
	pma_updusr = @pma_updusr,
	pma_upddat = getdate()
where
	pma_pcno = @pma_pcno
end





GO
GRANT EXECUTE ON [dbo].[sp_update_PCMAC] TO [ERPUSER] AS [dbo]
GO
