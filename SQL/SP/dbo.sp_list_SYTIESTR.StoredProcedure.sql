/****** Object:  StoredProcedure [dbo].[sp_list_SYTIESTR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYTIESTR]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYTIESTR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		For Merge Porject
*/


/************************************************************************
Author:		Samuel Chan
Date:		13th September, 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_list_SYTIESTR] 

@yts_cocde	nvarchar(6) = ' '


AS

Select 

	yts_cocde, 
	yts_venno, 
	yts_tirtyp ,
	yts_itmtyp,
	yts_tirseq ,
	yts_qtyfr ,
	yts_qtyto ,
	yts_moq ,
	yts_moa ,	
	yts_comrat,
	yts_moqchgfr,
	yts_moqchgto,
	yts_moqchg ,
	yts_moqrbe,
	yts_effdat,
	yts_creusr ,
	yts_updusr, 
	yts_credat ,
	yts_upddat,
	yts_timstp 
	-- Added by Mark Lau 20090203
	, isnull(yts_unttyp,'CTN') as 'yts_unttyp'
from 
	sytiestr
where
--	yts_cocde = @yts_cocde
	yts_cocde = ' '


GO
GRANT EXECUTE ON [dbo].[sp_list_SYTIESTR] TO [ERPUSER] AS [dbo]
GO
