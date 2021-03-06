/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Checklist]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PDA_Checklist]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Checklist]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Description   	: sp_select_PDA_Checklist
Programmer  	: Mark Lau
Create Date   	: 2008-07-24
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    */ 
CREATE procedure [dbo].[sp_select_PDA_Checklist]
@typ	nvarchar(10)

as

select pda_content,pda_typ from pda_checklist
where ( ( pda_typ = @typ and @typ <> '' ) or  @typ = '')



GO
GRANT EXECUTE ON [dbo].[sp_select_PDA_Checklist] TO [ERPUSER] AS [dbo]
GO
