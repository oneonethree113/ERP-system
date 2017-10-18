/****** Object:  StoredProcedure [dbo].[sp_update_IMCTYINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMCTYINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMCTYINF]    Script Date: 09/29/2017 11:53:54 ******/
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
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject, disable company code
*/

/************************************************************************
Author:		Kenny Chan
Date:		28th September, 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_update_IMCTYINF] 

@ici_cocde  	nvarchar(6),
@ici_itmno  	nvarchar(20),
@ici_ctyseq	int , 
@ici_cusno 	nvarchar(8),
@ici_ctycde	nvarchar(6),
@ici_valdat 	datetime,
@ici_rmk 	nvarchar(200), 
@ici_updusr  	nvarchar(30)

AS

update IMCTYINF
SET
ici_cusno = @ici_cusno , 
ici_ctycde=@ici_ctycde,
ici_valdat= @ici_valdat,
ici_rmk =@ici_rmk, 
ici_updusr = @ici_updusr,
ici_upddat =getdate()

Where 
--ici_cocde = @ici_cocde and
ici_itmno = @ici_itmno and 
ici_ctyseq = @ici_ctyseq










GO
GRANT EXECUTE ON [dbo].[sp_update_IMCTYINF] TO [ERPUSER] AS [dbo]
GO
