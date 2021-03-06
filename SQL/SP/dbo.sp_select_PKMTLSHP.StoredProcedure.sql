/****** Object:  StoredProcedure [dbo].[sp_select_PKMTLSHP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKMTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKMTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[sp_select_PKMTLSHP]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

	 
select 	
'' as 'Del' , 
pms_cocde ,
pms_ordno ,
pms_ordseq  ,
pms_shpseq ,
pms_shpstrdat ,
pms_shpenddat ,
pms_shpqty ,
pms_um ,
vbi_vensna   + ' - ' + pms_fty as 'pms_fty'    ,

isnull(pms_address,'') as 'pms_address'  , 
isnull(pms_state,'') as 'pms_state'  , 
isnull(pms_cntry,'') as 'pms_cntry'  , 
isnull(pms_zip,'') as 'pms_zip'  , 
isnull(pms_cntper,'') as 'pms_cntper'  , 
isnull(pms_tel,'') as 'pms_tel'  , 

pms_remark  , 
pms_creusr , 
pms_updusr , 
pms_credat  ,
pms_upddat  
from PKMTLSHP(nolock)
left join vnbasinf(nolock) on pms_fty = vbi_venno
				
where pms_cocde = @code and pms_ordno =  @ordno

end



GO
GRANT EXECUTE ON [dbo].[sp_select_PKMTLSHP] TO [ERPUSER] AS [dbo]
GO
