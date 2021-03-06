/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_SR_refresh]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF_SR_refresh]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_SR_refresh]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/************************************************************************
Author:		Tommy
Date:		7 March, 2002
Description:	Select Sales Rep of the Customer
************************************************************************/

CREATE procedure [dbo].[sp_select_CUBASINF_SR_refresh]
                                                                                                                                                                                                                                                                 
@cocde	 	nvarchar(6),
@quh_salrep 	nvarchar(30),
@cbi_salrep	nvarchar(30),
@creusr		nvarchar(30)
 
AS

begin

select 	ysr_code1, 	ysr_dsc, 		ysr_saltem, 
	ysr_code1 + ' - ' + ysr_dsc + ' (TEAM '+ysr_saltem+')'  as 'dsc'
from SYSALREP
where 	ysr_cocde = ' ' --@cocde
 	and (ysr_code1 = @quh_salrep or 
	(ysr_saltem = (select ysr_saltem from sysalrep where ysr_cocde = ' ' --@cocde
		 and ysr_code1 = @cbi_salrep))
	or 
	ysr_saltem = 'S')

end





GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF_SR_refresh] TO [ERPUSER] AS [dbo]
GO
