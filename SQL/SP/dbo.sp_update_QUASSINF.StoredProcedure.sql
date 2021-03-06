/****** Object:  StoredProcedure [dbo].[sp_update_QUASSINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QUASSINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QUASSINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 27/07/2003 


/************************************************************************
Author:		Tommy Ho
Date:		17th Jan, 2002
Description:	Update data From SCASSINF
************************************************************************/

CREATE PROCEDURE [dbo].[sp_update_QUASSINF] 

@qai_cocde 	nvarchar(6),	@qai_qutno 	nvarchar(20),	
@qai_qutseq 	int,		@qai_itmno 	nvarchar(20),
@qai_assitm 	nvarchar(20),	@qai_assdsc 	nvarchar(800),	
@qai_cusitm	nvarchar(20),	@qai_cusstyno	nvarchar(30),
@qai_colcde	nvarchar(30),
@qai_coldsc	nvarchar(300),	@qai_cussku           	nvarchar(20),	
@qai_upcean      	nvarchar(15),	@qai_cusrtl	nvarchar(20),	
@qai_untcde 	nvarchar(6),	@qai_inrqty	int,		
@qai_mtrqty	int,		
@qai_imperiod	datetime,
@qai_updusr	nvarchar(30)

AS

update  QUASSINF	set	qai_assdsc = @qai_assdsc,	qai_cusitm = @qai_cusitm,
			qai_cussku = @qai_cussku,	qai_upcean = @qai_upcean,
			qai_cusrtl = @qai_cusrtl,	qai_updusr = @qai_updusr,
			qai_upddat = GETDATE(),	qai_coldsc = @qai_coldsc, qai_cusstyno = @qai_cusstyno,
qai_imperiod = @qai_imperiod	
where 	qai_cocde = @qai_cocde 	and	qai_qutno = @qai_qutno 	and
	qai_qutseq = @qai_qutseq 	and	qai_itmno = @qai_itmno 	and
	qai_assitm = @qai_assitm 	and	qai_colcde = @qai_colcde



GO
GRANT EXECUTE ON [dbo].[sp_update_QUASSINF] TO [ERPUSER] AS [dbo]
GO
