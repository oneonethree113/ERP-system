/****** Object:  StoredProcedure [dbo].[sp_select_pda_quot_lock]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_pda_quot_lock]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_pda_quot_lock]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Description   	: sp_select_pda_quot_lock
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
CREATE procedure [dbo].[sp_select_pda_quot_lock]
@qud_tmpqutno 	nvarchar(20),
@qud_sessid 	nvarchar(50),
@qud_remark	nvarchar(255),
@qud_curusr	nvarchar(30),
@qud_cursaltem	nvarchar(12),
@qud_curpda	nvarchar(50),
@qud_curip	nvarchar(20)

as

select '-1' as 'AffectedRow',* from pda_quot_lock
where qud_tmpqutno = @qud_tmpqutno and qud_sessid = @qud_sessid




GO
GRANT EXECUTE ON [dbo].[sp_select_pda_quot_lock] TO [ERPUSER] AS [dbo]
GO
