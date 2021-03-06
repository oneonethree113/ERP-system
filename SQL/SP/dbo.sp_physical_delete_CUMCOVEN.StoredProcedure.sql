/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUMCOVEN]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUMCOVEN]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUMCOVEN]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: sp_physica_delete_CUMCOVEN
Description   	: Delete Data form Customer Vendor Company relationship Table 
Programmer  	: Lewis To
Create Date   	: 18 Jun 2003
Last Modified  	: 
Table Read(s) 	:CUMCOVEN
Table Write(s) 	:CUMCOVEN
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/

Create Procedure [dbo].[sp_physical_delete_CUMCOVEN]

@running_cocde varchar(6),
@ccv_cocde varchar(6),
@ccv_cusno varchar(6),
@ccv_ventyp varchar(1)

AS
if @ccv_cocde = 'ALL'
begin
delete CUMCOVEN
where ccv_cusno = @ccv_cusno 

end
else
begin
delete CUMCOVEN
where ccv_cusno = @ccv_cusno and
          ccv_ventyp = @ccv_ventyp and
          ccv_cocde = @ccv_cocde

end




GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUMCOVEN] TO [ERPUSER] AS [dbo]
GO
