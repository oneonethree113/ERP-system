/****** Object:  StoredProcedure [dbo].[sp_select_PKORDREC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKORDREC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKORDREC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









CREATE  procedure [dbo].[sp_select_PKORDREC]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

	 
select 	'' as 'Del' ,por_cocde,por_ordno,por_ordseq,por_recseq,por_recdate,por_type,
 vbi_vensna + ' - ' +  por_fty  as 'por_fty' ,por_recqty,por_extqty,
por_um,por_remark,por_invno,por_creusr,por_updusr,por_credat,por_upddat
from pkordrec(nolock)
left join vnbasinf on por_fty = vbi_venno
where por_cocde = @code and por_ordno =  @ordno
order by por_ordseq , por_recseq

end








 





GO
GRANT EXECUTE ON [dbo].[sp_select_PKORDREC] TO [ERPUSER] AS [dbo]
GO
