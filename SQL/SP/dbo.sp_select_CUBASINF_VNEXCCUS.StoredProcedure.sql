/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_VNEXCCUS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF_VNEXCCUS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_VNEXCCUS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO


















/************************************************************************
Author:		Tommy
Date:		14 March, 2002
Description:	Select Primary Customer for Quotation
************************************************************************/

CREATE         procedure [dbo].[sp_select_CUBASINF_VNEXCCUS]
                                                                                                                                                                                                                                                                 
 

as


begin

select cbi_cusno,cbi_cussna from cubasinf(nolock)
where cbi_cussts = 'A' 
order by cbi_cusno

end 



GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF_VNEXCCUS] TO [ERPUSER] AS [dbo]
GO
