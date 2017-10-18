/****** Object:  StoredProcedure [dbo].[sp_select_PKMLTSHP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKMLTSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKMLTSHP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








CREATE  procedure [dbo].[sp_select_PKMLTSHP]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

	 
select 	
'N' as 'Del' , 
pms_cocde ,
pms_ordno ,
pms_ordseq  ,
pms_shpseq ,
pms_shpstrdat ,
pms_shpenddat ,
pms_shpqty ,
pms_um ,
pms_fty  ,
pms_remark  , 
pms_creusr , 
pms_updusr , 
pms_credat  ,
pms_upddat  
from pkmltshp(nolock)
				
where pms_cocde = @code and pms_ordno =  @ordno
order by pms_ordseq , pms_shpseq
end













GO
GRANT EXECUTE ON [dbo].[sp_select_PKMLTSHP] TO [ERPUSER] AS [dbo]
GO
