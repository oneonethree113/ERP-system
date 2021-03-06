/****** Object:  StoredProcedure [dbo].[sp_select_PKREPORD]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKREPORD]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKREPORD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_select_PKREPORD] 
--------------------------------------------------------------------------------------------------------------------------------------

@pro_cocde nvarchar(20),
@pro_ordno nvarchar(20)
--------------------------------------------------------------------------------------------------------------------------------------
AS

begin

select pro_cocde,pro_ordno,pro_repord,pro_creusr
from PKREPORD
where pro_cocde  = @pro_cocde and pro_ordno = @pro_ordno
order by pro_ordno,pro_repord
end



GO
GRANT EXECUTE ON [dbo].[sp_select_PKREPORD] TO [ERPUSER] AS [dbo]
GO
