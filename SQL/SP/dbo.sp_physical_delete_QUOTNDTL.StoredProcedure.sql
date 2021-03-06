/****** Object:  StoredProcedure [dbo].[sp_physical_delete_QUOTNDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_QUOTNDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_QUOTNDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



-- Checked by Allan Yuen at 28/07/2003


CREATE PROCEDURE [dbo].[sp_physical_delete_QUOTNDTL] 

@qud_cocde 	nvarchar(6),
@qud_qutno 	nvarchar(20),
@qud_qutseq 	int


AS

delete from QUOTNDTL
where 	qud_cocde = @qud_cocde
and 	qud_qutno = @qud_qutno
and 	qud_qutseq = @qud_qutseq

/*
update 	SAREQDTL 
set	srd_canflg = 'Y'
where 	srd_cocde = @qud_cocde and srd_qutno = @qud_qutno and srd_qutseq = @qud_qutseq
*/
update 	SAORDDTL 	
set 	sad_delflg = 'Q' 
where	sad_cocde = @qud_cocde and sad_qutno = @qud_qutno and sad_qutseq = @qud_qutseq and sad_delflg = 'N'

update 	SAORDDTL 	
set 	sad_delflg = 'RQ' 
where	sad_cocde = @qud_cocde and sad_qutno = @qud_qutno and sad_qutseq = @qud_qutseq and sad_delflg = 'R'



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_QUOTNDTL] TO [ERPUSER] AS [dbo]
GO
