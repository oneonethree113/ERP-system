/****** Object:  StoredProcedure [dbo].[sp_select_PKREQDTL_05_Update]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKREQDTL_05_Update]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKREQDTL_05_Update]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE     Procedure [dbo].[sp_select_PKREQDTL_05_Update]

@Code varchar(20),
@prd_ordno nvarchar(20),
@prd_ordseq int

as begin

select  sum(prd_ordqty),sum(prd_bonqty) from PKREQDTL
where 
prd_cocde  =  @Code and 
prd_ordno = @prd_ordno and 
prd_ordseq = @prd_ordseq

end


 






GO
GRANT EXECUTE ON [dbo].[sp_select_PKREQDTL_05_Update] TO [ERPUSER] AS [dbo]
GO
