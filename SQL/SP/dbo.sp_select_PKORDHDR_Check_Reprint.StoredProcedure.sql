/****** Object:  StoredProcedure [dbo].[sp_select_PKORDHDR_Check_Reprint]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKORDHDR_Check_Reprint]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKORDHDR_Check_Reprint]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_select_PKORDHDR_Check_Reprint] 
--------------------------------------------------------------------------------------------------------------------------------------

@pro_ordno nvarchar(20)
--------------------------------------------------------------------------------------------------------------------------------------
AS

begin

select poh_cocde , poh_status , poh_ordno
from PKORDHDR(nolock)
where poh_ordno = @pro_ordno

end


GO
GRANT EXECUTE ON [dbo].[sp_select_PKORDHDR_Check_Reprint] TO [ERPUSER] AS [dbo]
GO
