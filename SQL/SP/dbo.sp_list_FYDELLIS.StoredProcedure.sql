/****** Object:  StoredProcedure [dbo].[sp_list_FYDELLIS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_FYDELLIS]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_FYDELLIS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai	
Date:		Mar 03, 2002
Description:	Select data From FYDELLIS
************************************************************************/

CREATE procedure [dbo].[sp_list_FYDELLIS]
                                                                                                                                                                                                                                                               
@fdl_cocde nvarchar(6) ,
@fdl_creusr nvarchar(30)
 
AS
begin

select * from FYDELLIS

where 

fdl_cocde = @fdl_cocde

end





GO
GRANT EXECUTE ON [dbo].[sp_list_FYDELLIS] TO [ERPUSER] AS [dbo]
GO
