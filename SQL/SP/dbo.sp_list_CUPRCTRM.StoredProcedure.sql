/****** Object:  StoredProcedure [dbo].[sp_list_CUPRCTRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUPRCTRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUPRCTRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO















CREATE  procedure [dbo].[sp_list_CUPRCTRM]
                                                                                                                                                                                                                                                                
@cpt_cocde 	nvarchar(6) ,
@cpt_cusno 	nvarchar(6)

AS
Select 

cpt_cocde,
cpt_cusno,
cpt_prctrm + ' - ' + ltrim(rtrim(isnull(ysi_dsc,''))) as 'cpt_prctrm',
cpt_prcdef,
cpt_creusr,
cpt_updusr,
cpt_credat,
cpt_upddat,
cpt_timstp

 

from dbo.CUPRCTRM left join  SYSETINF on cpt_prctrm = ysi_cde


where cpt_cusno  = @cpt_cusno and ysi_typ = '03'

 












GO
GRANT EXECUTE ON [dbo].[sp_list_CUPRCTRM] TO [ERPUSER] AS [dbo]
GO
