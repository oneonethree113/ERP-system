/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Customer_GetPriSecRel]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PDA_Customer_GetPriSecRel]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Customer_GetPriSecRel]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/*
=========================================================
Description   	: sp_select_PDA_Customer_GetPriSecRel
Programmer  	: Mark Lau
Create Date   	: 2008-06-12
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    */ 
CREATE procedure [dbo].[sp_select_PDA_Customer_GetPriSecRel]
@prmcus	nvarchar(10)
as

select 
	'' as 'csc_cocde',
	csc_prmcus,
	csc_seccus,
	cbi_cussna,
	csc_cusrel
from 
	CUSUBCUS (nolock)
	left join CUBASINF (nolock) on --csc_cocde = cbi_cocde and 
					csc_seccus = cbi_cusno
--where csc_cocde = 'UCP'
where csc_prmcus = @prmcus
order by csc_seccus asc






GO
GRANT EXECUTE ON [dbo].[sp_select_PDA_Customer_GetPriSecRel] TO [ERPUSER] AS [dbo]
GO
