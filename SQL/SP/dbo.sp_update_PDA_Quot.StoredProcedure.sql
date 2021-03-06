/****** Object:  StoredProcedure [dbo].[sp_update_PDA_Quot]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PDA_Quot]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PDA_Quot]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Description   	: sp_update_PDA_Quot
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
CREATE procedure [dbo].[sp_update_PDA_Quot]
@cocde	nvarchar(6),
@qud_cocde	nvarchar(6),
@qud_cus1no		nvarchar(10),
@qud_cus2no	nvarchar(10),
@qud_tmpqutno nvarchar(50),
@qud_seq	int,
@qud_itmno	nvarchar(20),
@qud_aprsts	nvarchar(1),
@qud_qutno	nvarchar(20),
@qud_qutseq	int,
@qud_updusr	nvarchar(30)


as

update pda_quot
set qud_aprsts =  @qud_aprsts, qud_updusr = @qud_updusr , qud_upddat = getdate(), qud_qutno = @qud_qutno, qud_qutseq = @qud_qutseq,
qud_del  = case when @qud_aprsts = 'D' then 'Y' else 'N' end
where
qud_cocde = @qud_cocde and 
qud_cus1no = @qud_cus1no and qud_cus2no = @qud_cus2no and qud_tmpqutno = @qud_tmpqutno
and qud_seq = @qud_seq and qud_itmno = @qud_itmno



GO
GRANT EXECUTE ON [dbo].[sp_update_PDA_Quot] TO [ERPUSER] AS [dbo]
GO
