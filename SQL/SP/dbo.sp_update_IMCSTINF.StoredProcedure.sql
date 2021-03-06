/****** Object:  StoredProcedure [dbo].[sp_update_IMCSTINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMCSTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMCSTINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO


/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: Allan Yuen
Create Date   	: 
Last Modified  	: 03 JAN 2006
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
*/

------------------------------------------------- 
CREATE procedure [dbo].[sp_update_IMCSTINF]

@ici_cocde  nvarchar(6) = '',
@ici_itmno  nvarchar(20),
@ici_cstrmk nvarchar(2000),
@ici_expdat datetime = '1900/01/01',
@ici_updusr nvarchar(30)

AS
 
update IMCSTINF
set
	ici_cstrmk= @ici_cstrmk,
	ici_expdat= @ici_expdat,
	ici_updusr= @ici_updusr,
	ici_upddat= getdate()
where
	ici_itmno = @ici_itmno




GO
GRANT EXECUTE ON [dbo].[sp_update_IMCSTINF] TO [ERPUSER] AS [dbo]
GO
