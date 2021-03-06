/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PCMAC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_PCMAC]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PCMAC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

/*
=========================================================
Program ID	: sp_physical_delete_PCMAC
Description   	: Delete Data for Profit Center Account Interface table 
Programmer  	: Marco Chan
Create Date   	: 19 Sept 2003
Last Modified  	: 
Table Read(s) 	: PCMAC
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/
CREATE PROCEDURE [dbo].[sp_physical_delete_PCMAC] 
@cocde 		varchar(6),
@pma_pcno 	varchar(20)
AS
begin

delete from PCMAC
where
	pma_pcno = @pma_pcno
end



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_PCMAC] TO [ERPUSER] AS [dbo]
GO
