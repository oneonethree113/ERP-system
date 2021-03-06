/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_SR2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF_SR2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_SR2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Tommy
Date:		18 Dec, 2001
Description:	Select Sales Rep of the Customer
************************************************************************/

Create  procedure [dbo].[sp_select_CUBASINF_SR2]
                                                                                                                                                                                                                                                                 
@cocde 	nvarchar(6),
@team  	nvarchar(20),
@creusr	nvarchar(30)
 
AS

begin


 


select 	 substring(a.ssr_saldiv,2,1) + ' - Division ' + substring(a.ssr_saldiv,2,1) as 'ssr_saldiv'
, a.ssr_salmgr ,a.ssr_salrep , c.yup_usrnam as 'yup_repnam'  
, b.yup_usrnam as 'yup_mgrnam'  , a.ssr_saltem,
ssr_salrep + ' - ' + c.yup_usrnam as 'dsc'

from SYSALREL a
left join syusrprf c on c.yup_usrid = a.ssr_salrep
left join syusrprf b on a.ssr_salmgr = b.yup_usrid
where 	a.ssr_cocde = ' ' --@cocde
 	and
	(a.ssr_saltem = @team)
	--or
	--ysr_saltem = 'S')
order by a.ssr_default desc

end

 
 




GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF_SR2] TO [ERPUSER] AS [dbo]
GO
