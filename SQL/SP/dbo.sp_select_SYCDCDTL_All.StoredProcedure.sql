/****** Object:  StoredProcedure [dbo].[sp_select_SYCDCDTL_All]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCDCDTL_All]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCDCDTL_All]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/************************************************************************
Author:		Frankie Cheung
Date:		28th November, 2008
Description:	Select data From SYCDCDTL

************************************************************************/

CREATE procedure [dbo].[sp_select_SYCDCDTL_All]
                                                                                                                                                                                                                                                                 

@idd_cocde	nvarchar(6)  = ' '
                                               
 
AS

begin

Select	idd_creusr as 'idd_status',
 	idd_year,
	idd_cdcde,
 	idd_seq,
	idd_trmcde,	
 	ysi_dsc,
	idd_cbm,	
	idd_nsteril,	
	idd_osteril,
	idd_hsteril,	
	idd_creusr,
	idd_updusr,	
	idd_credat,
	idd_upddat,
	cast(idd_timstp as int) as idd_timstp

 from SYCDCDTL, SYSETINF
 where                                                                                                                                                                                                                                                             
	idd_trmcde = ysi_cde and 
	ysi_typ = '24'
                           
order by 
	idd_year, idd_cdcde, idd_seq

end


GO
GRANT EXECUTE ON [dbo].[sp_select_SYCDCDTL_All] TO [ERPUSER] AS [dbo]
GO
