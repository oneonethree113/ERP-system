/****** Object:  StoredProcedure [dbo].[sp_insert_IMCSTINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMCSTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMCSTINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/*
=========================================================
Program ID	: sp_insert_IMCSTINF
Description   	: Insert IMCSTINF
Programmer  	: Allan Yuen
Create Date   	: 
Last Modified  	: 06 JAN 2006
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
*/
CREATE procedure [dbo].[sp_insert_IMCSTINF]

@ici_cocde  nvarchar(6) = '',
@ici_itmno  nvarchar(20),
@ici_cstrmk nvarchar(2000),
@ici_expdat datetime = '1900/01/01',
@ici_updusr nvarchar(30)
AS
 
insert into imcstinf
(
ici_cocde,
ici_itmno,
ici_cstrmk,
ici_expdat,
ici_creusr,
ici_updusr,
ici_credat,
ici_upddat
)

values(
@ici_cocde,
@ici_itmno,
@ici_cstrmk,
@ici_expdat,
@ici_updusr,
@ici_updusr,
getdate(),
getdate()
)      
---------------------------------------------------------------------------------------------------------------------------------------------------------------------





GO
GRANT EXECUTE ON [dbo].[sp_insert_IMCSTINF] TO [ERPUSER] AS [dbo]
GO
