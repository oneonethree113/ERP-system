/****** Object:  StoredProcedure [dbo].[sp_Spring_SUBCUST_PDA]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Spring_SUBCUST_PDA]
GO
/****** Object:  StoredProcedure [dbo].[sp_Spring_SUBCUST_PDA]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Description   	: sp_Spring_SUBCUST_PDA
Programmer  	: PIC
Create Date   	: 2002-07-30
Last Modified  	: 2003-07-22
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    */ 
CREATE procedure [dbo].[sp_Spring_SUBCUST_PDA]

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

GO
GRANT EXECUTE ON [dbo].[sp_Spring_SUBCUST_PDA] TO [ERPUSER] AS [dbo]
GO
