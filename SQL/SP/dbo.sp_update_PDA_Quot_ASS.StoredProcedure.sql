/****** Object:  StoredProcedure [dbo].[sp_update_PDA_Quot_ASS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PDA_Quot_ASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PDA_Quot_ASS]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Description   	: sp_update_PDA_Quot_Ass
Programmer  	: Mark Lau
Create Date   	: 2008-07-23
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    */ 
CREATE procedure [dbo].[sp_update_PDA_Quot_ASS]
@cocde	nvarchar(6),
@qud_cocde	nvarchar(6),
@qud_cus1no		nvarchar(10),
@qud_cus2no	nvarchar(10),
@qud_tmpqutno nvarchar(50),
@qud_assitm	nvarchar(20),
@qud_seq	int,
@qud_itmno	nvarchar(20),
@qud_aprsts	nvarchar(1),
@qud_updusr	nvarchar(30)


as

update pda_quot_ass
set qud_aprsts =  @qud_aprsts, qud_updusr = @qud_updusr , qud_upddat = getdate(), 
qud_del  = case when @qud_aprsts = 'D' then 'Y' else 'N' end
where
--qud_cocde = @qud_cocde and 
qud_cus1no = @qud_cus1no and qud_cus2no = @qud_cus2no and qud_tmpqutno = @qud_tmpqutno
and qud_assitm = @qud_assitm and qud_itmno = @qud_itmno and qud_seq = @qud_seq



GO
GRANT EXECUTE ON [dbo].[sp_update_PDA_Quot_ASS] TO [ERPUSER] AS [dbo]
GO
