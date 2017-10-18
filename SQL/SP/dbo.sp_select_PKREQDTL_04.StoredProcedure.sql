/****** Object:  StoredProcedure [dbo].[sp_select_PKREQDTL_04]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKREQDTL_04]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKREQDTL_04]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO















CREATE  procedure [dbo].[sp_select_PKREQDTL_04]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

	 
 Select prd_reqno , prd_seq , prd_ordno , prd_ordseq
from PKREQDTL(nolock)
where prd_ordno = @ordno and prd_cocde = @code

end


 
 
 















GO
GRANT EXECUTE ON [dbo].[sp_select_PKREQDTL_04] TO [ERPUSER] AS [dbo]
GO
